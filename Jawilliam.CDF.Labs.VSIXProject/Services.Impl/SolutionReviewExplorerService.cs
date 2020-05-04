using Jawilliam.CDF.Labs.Common.DBModel;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using Jawilliam.CDF.Labs.VSIXProject.Models;
using System;
using System.IO;
using System.Xml.Linq;
using Jawilliam.CDF.Approach;
using System.Collections.ObjectModel;
using Jawilliam.CDF.CSharp.RoslynML;
using System.Data.Entity.Infrastructure;

namespace Jawilliam.CDF.Labs.VSIXProject.Services.Impl
{
    /// <summary>
    /// Implements a EF-based <see cref="ViewModels.SolutionReviewExplorerViewModel"/>'s service that .
    /// </summary>
    public class SolutionReviewExplorerService : ISolutionReviewExplorerService
    {
        public virtual Configuration GetAppConfig()
        {
            ExeConfigurationFileMap configMap = new ExeConfigurationFileMap
            {
                ExeConfigFilename = @"app.config" // the path of the custom app.config
            };
            return ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
        }

        private GitRepository CreateRepository(string project)
        {
            Configuration config = this.GetAppConfig();
            var connectionString = config.ConnectionStrings.ConnectionStrings[project].ConnectionString;

            return new GitRepository(connectionString) { Name = project };
        }

        /// <summary>
        /// Gets the delta comparisons existing in a given project between the given left approach and the given right approach. 
        /// </summary>
        /// <param name="project">project name.</param>
        /// <param name="leftApproach">left approach.</param>
        /// <param name="rightApproach">right approach.</param>
        /// <returns>A summary for each existing delta comparison.</returns>
        public virtual IEnumerable<DisagreedDeltaDescriptor> GetDisagreedDeltas(string project, ChangeDetectionApproaches leftApproach, ChangeDetectionApproaches rightApproach)
        {
            IList<DeltaComparison> deltaComparisons = null;
            using (var db = this.CreateRepository(project))
            {
                ((IObjectContextAdapter)db).ObjectContext.CommandTimeout = 600;
                deltaComparisons = db.DeltaComparisonSet.AsNoTracking().Where(s =>
                     (s.Left.Approach == leftApproach && s.Right.Approach == rightApproach) ||
                     (s.Right.Approach == leftApproach && s.Left.Approach == rightApproach)).ToList();                
            }

            return deltaComparisons.Select(delegate (DeltaComparison deltaComparison, int i)
            {
                var xComparison = deltaComparison.XMatching;

                var lr = (xComparison.Matching?.OfType<LRMatchSymptom>().Count(s => s.Left.Approach == (int)leftApproach) ?? 0) +
                         (xComparison.Matching?.OfType<RLMatchSymptom>().Count(s => s.Right.Approach == (int)leftApproach) ?? 0);
                var rl = (xComparison.Matching?.OfType<LRMatchSymptom>().Count(s => s.Left.Approach == (int)rightApproach) ?? 0) +
                         (xComparison.Matching?.OfType<RLMatchSymptom>().Count(s => s.Right.Approach == (int)rightApproach) ?? 0);
                var total = lr + rl;

                return new DisagreedDeltaDescriptor{ 
                    Index = i + 1,
                    LeftId = deltaComparison.LeftId,
                    RightId = deltaComparison.RightId,
                    AllMismatches = total,
                    LrMismatches = lr,
                    RlMismatches = rl };
            });
        }

        /// <summary>
        /// Loads the content of a given disagreed delta.
        /// </summary>
        /// <param name="project">project name.</param>
        /// <param name="leftDeltaId">left delta's ID.</param>
        /// <param name="rightDeltaId">right delta's ID.</param>
        /// <param name="info">describes the appproach being loaded.</param>
        /// <returns>The set of found disagreed mismatches.</returns>
        public virtual DisagreedDeltaContent LoadDisagreedDelta(string project, Guid leftDeltaId, Guid rightDeltaId, ApproachInfo info)
        {
            DeltaComparison deltaComparison = null;
            FileFormat originalFileVersion = null, modifiedFileVersion = null;
            Delta review = null;
            using (var db = this.CreateRepository(project))
            {
                ((IObjectContextAdapter)db).ObjectContext.CommandTimeout = 600;
                deltaComparison = db.DeltaComparisonSet.AsNoTracking()
                    .Include("Left.RevisionPair.FromFileVersion.Content")
                    .Include("Left.RevisionPair.FileVersion.Content")
                    .Single(s =>
                     (s.LeftId == leftDeltaId && s.RightId == rightDeltaId) ||
                     (s.RightId == rightDeltaId && s.LeftId == leftDeltaId));

                db.LoadFileRevisionPair(deltaComparison.Left.RevisionPair.FromFileVersion.Id,
                    deltaComparison.Left.RevisionPair.FileVersion.Id, true, info.FileFormat,
                    out originalFileVersion, out modifiedFileVersion);

                review = db.Deltas
                    .Include("RevisionPair")
                    .SingleOrDefault(d => d.RevisionPair.Id == deltaComparison.Left.RevisionPair.Id &&
                                          d.Approach == ChangeDetectionApproaches.Manually)
                    ?? new Delta 
                    { 
                        Id = Guid.NewGuid(), 
                        RevisionPair = deltaComparison.Left.RevisionPair, 
                        Approach = ChangeDetectionApproaches.Manually,
                        DetectionResult = DetectionResult.Read(null, System.Text.Encoding.UTF8)
                    };
                //db.Deltas.Local.
            }

            var disagreedMatches = deltaComparison.XMatching.Matching.Select(m => new RateableMatch(m));
            var content = new DisagreedDeltaContent
            {
                LeftId = leftDeltaId,
                RightId = rightDeltaId,
                DisagreedMatches = new ObservableCollection<RateableMatch>(disagreedMatches),
                //Comparison = deltaComparison,
                FullAsts = new XAstRevisionPair()
                {
                    Original = XElement.Load(new StringReader(originalFileVersion.XmlTree)),
                    Modified = XElement.Load(new StringReader(modifiedFileVersion.XmlTree))
                },
                ContentVersionPair = (deltaComparison.Left.RevisionPair.FromFileVersion.Content,
                                      deltaComparison.Left.RevisionPair.FileVersion.Content),
                Review = review
            };

            // Attaching GumTree information.
            foreach (var dm in disagreedMatches)
            {
                switch (dm.DivergentMatch)
                {
                    case LRMatchSymptom lr:
                        lr.Left.Original.Element = new Models.ElementDescription
                        {
                            Source = lr.Left.Original.Element,
                            GumTreeId = content.FullAsts.RoslynOriginals[lr.Left.Original.Element.Id].GtID()
                        };
                        lr.Left.Modified.Element = new Models.ElementDescription
                        {
                            Source = lr.Left.Modified.Element,
                            GumTreeId = content.FullAsts.RoslynModifieds[lr.Left.Modified.Element.Id].GtID()
                        };
                        if (lr.OriginalAtRight?.Original?.Element != null &&
                            lr.OriginalAtRight?.Original?.Element.Id != "-1")
                        {
                            lr.OriginalAtRight.Original.Element = new Models.ElementDescription
                            {
                                Source = lr.OriginalAtRight.Original.Element,
                                GumTreeId = content.FullAsts.RoslynOriginals[lr.OriginalAtRight.Original.Element.Id].GtID()
                            };
                        }
                        if (lr.OriginalAtRight?.Modified?.Element != null &&
                            lr.OriginalAtRight?.Modified?.Element.Id != "-1")
                        {
                            lr.OriginalAtRight.Modified.Element = new Models.ElementDescription
                            {
                                Source = lr.OriginalAtRight.Modified.Element,
                                GumTreeId = content.FullAsts.RoslynModifieds[lr.OriginalAtRight.Modified.Element.Id].GtID()
                            };
                        }
                        if (lr.ModifiedAtRight?.Original?.Element != null &&
                            lr.ModifiedAtRight?.Original?.Element.Id != "-1")
                        {
                            lr.ModifiedAtRight.Original.Element = new Models.ElementDescription
                            {
                                Source = lr.ModifiedAtRight.Original.Element,
                                GumTreeId = content.FullAsts.RoslynOriginals[lr.ModifiedAtRight.Original.Element.Id].GtID()
                            };
                        }
                        if (lr.ModifiedAtRight?.Modified?.Element != null &&
                            lr.ModifiedAtRight?.Modified?.Element.Id != "-1")
                        {
                            lr.ModifiedAtRight.Modified.Element = new Models.ElementDescription
                            {
                                Source = lr.ModifiedAtRight.Modified.Element,
                                GumTreeId = content.FullAsts.RoslynModifieds[lr.ModifiedAtRight.Modified.Element.Id].GtID()
                            };
                        }
                        break;
                    case RLMatchSymptom rl:
                        rl.Right.Original.Element = new Models.ElementDescription
                        {
                            Source = rl.Right.Original.Element,
                            GumTreeId = content.FullAsts.RoslynOriginals[rl.Right.Original.Element.Id].GtID()
                        };
                        rl.Right.Modified.Element = new Models.ElementDescription
                        {
                            Source = rl.Right.Modified.Element,
                            GumTreeId = content.FullAsts.RoslynModifieds[rl.Right.Modified.Element.Id].GtID()
                        };
                        if (rl.OriginalAtLeft?.Original?.Element != null &&
                            rl.OriginalAtLeft?.Original?.Element.Id != "-1")
                        {
                            rl.OriginalAtLeft.Original.Element = new Models.ElementDescription
                            {
                                Source = rl.OriginalAtLeft.Original.Element,
                                GumTreeId = content.FullAsts.RoslynOriginals[rl.OriginalAtLeft.Original.Element.Id].GtID()
                            };
                        }
                        if (rl.OriginalAtLeft?.Modified?.Element != null &&
                            rl.OriginalAtLeft?.Modified?.Element.Id != "-1")
                        {
                            rl.OriginalAtLeft.Modified.Element = new Models.ElementDescription
                            {
                                Source = rl.OriginalAtLeft.Modified.Element,
                                GumTreeId = content.FullAsts.RoslynModifieds[rl.OriginalAtLeft.Modified.Element.Id].GtID()
                            };
                        }
                        if (rl.ModifiedAtLeft?.Original?.Element != null &&
                            rl.ModifiedAtLeft?.Original?.Element.Id != "-1")
                        {
                            rl.ModifiedAtLeft.Original.Element = new Models.ElementDescription
                            {
                                Source = rl.ModifiedAtLeft.Original.Element,
                                GumTreeId = content.FullAsts.RoslynOriginals[rl.ModifiedAtLeft.Original.Element.Id].GtID()
                            };
                        }
                        if (rl.ModifiedAtLeft?.Modified?.Element != null &&
                            rl.ModifiedAtLeft?.Modified?.Element.Id != "-1")
                        {
                            rl.ModifiedAtLeft.Modified.Element = new Models.ElementDescription
                            {
                                Source = rl.ModifiedAtLeft.Modified.Element,
                                GumTreeId = content.FullAsts.RoslynModifieds[rl.ModifiedAtLeft.Modified.Element.Id].GtID()
                            };
                        }
                        break;
                    default:
                        throw new InvalidDataException();
                }
            }

            return content;
        }

        /// <summary>
        /// Saves the manually rated delta.
        /// </summary>
        /// <param name="project">project name.</param>
        /// <param name="delta">delta to be submitted.</param>
        public virtual void SubmitReview(string project, Delta delta)
        {
            using var db = this.CreateRepository(project);
            //var review = db.Deltas.SingleOrDefault(d => d.RevisionPair.Id == delta.RevisionPair.Id &&
            //                                            d.Approach == ChangeDetectionApproaches.Manually);
            
            if (db.Deltas.Any(d => d.RevisionPair.Id == delta.RevisionPair.Id &&
                                   d.Approach == ChangeDetectionApproaches.Manually))
            {
                db.Deltas.Attach(delta);
                db.Entry(delta).State = System.Data.Entity.EntityState.Modified;
            }
            else
            {
                db.Deltas.Attach(delta);
                db.Entry(delta).State = System.Data.Entity.EntityState.Added;
            }
            //?? new Delta
            //{
            //    Id = delta.Id,
            //    RevisionPair = delta.RevisionPair,
            //    Approach = ChangeDetectionApproaches.Manually                
            //};

            //review.Matching = delta.Matching;
            //review.Differencing = delta.Differencing;

            db.SaveChanges();
        }
    }
}
