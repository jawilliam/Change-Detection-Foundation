using CommandDotNet;
using CommandDotNet.Attributes;
using Jawilliam.CDF;
using Jawilliam.CDF.Approach;
using Jawilliam.CDF.CSharp.RoslynML;
using Jawilliam.CDF.Labs.DBModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Jawilliam.Tools.CCL
{
    partial class CCL
    {
        [ApplicationMetadata(Name = "rate", Description = "Rate...")]
        public virtual void RateMismatches(RateArgs args)
        {
            var comparisonSetLeftId = Guid.Parse(args.ComparisonSetLeftId);
            var comparisonSetRightId = Guid.Parse(args.ComparisonSetRightId);

            var project = Projects.Single(p => p.Name == args.Project);
            using (var dbRepository = new GitRepository(project.Name) {Name = project.Name})
            {
                ((IObjectContextAdapter) dbRepository).ObjectContext.CommandTimeout = 600;

                var info = (from cs in dbRepository.DeltaComparisonSet
                    where cs.LeftId == comparisonSetLeftId && cs.RightId == comparisonSetRightId
                    select new
                    {
                        ComparisonSet = cs,
                        cs.Left.RevisionPair,
                        cs.Left.RevisionPair.FromFileVersion,
                        cs.Left.RevisionPair.FileVersion,
                        RatedDelta =
                            cs.Left.RevisionPair.Deltas.Where(d =>
                                d.Approach == ChangeDetectionApproaches.Manually)
                    }).Single();

                var delta = info.RatedDelta.SingleOrDefault();
                //dbRepository.Deltas.Where(d => d.RevisionPair.Id == revisionPairId && d.Approach == ChangeDetectionApproaches.Manually).Load();
                //var delta = dbRepository.Deltas.SingleOrDefault(d => d.RevisionPair.Id == revisionPairId && d.Approach == ChangeDetectionApproaches.Manually);
                if (delta == null)
                {
                    delta = new Delta
                    {
                        Id = Guid.NewGuid(), Approach = ChangeDetectionApproaches.Manually,
                        RevisionPair = info.RevisionPair,
                        Matching = "<Matches/>",
                        Differencing = "<Actions/>"
                    };
                    dbRepository.Deltas.Add(delta);
                }

                var dr = (DetectionResult)delta.DetectionResult;
                var fullFileFormat = (FileFormatKind) Enum.Parse(typeof(FileFormatKind), args.FullFileFormat);

                //var roslynMlServices = new RoslynML();

                var originalVersion = dbRepository.FileFormats.AsNoTracking()
                    .Single(ff => ff.Kind == fullFileFormat && ff.FileVersion.Id == delta.RevisionPair.FromFileVersion.Id);
                var modifiedVersion = dbRepository.FileFormats.AsNoTracking()
                    .Single(ff => ff.Kind == fullFileFormat && ff.FileVersion.Id == delta.RevisionPair.FileVersion.Id);
                var xOriginalTree = XElement.Load(new StringReader(originalVersion.XmlTree));
                var xModifiedTree = XElement.Load(new StringReader(modifiedVersion.XmlTree));
                var oElements = xOriginalTree.PostOrder(n => n.Elements().Where(e => e is XNode))
                    .ToDictionary(n => n.RmId());
                var mElements = xModifiedTree.PostOrder(n => n.Elements().Where(e => e is XNode))
                    .ToDictionary(n => n.RmId());
                //var fullOriginalTree = roslynMlServices.AsGumtreefiedElementTree(xOriginalTree, true);
                //var fullModifiedTree = roslynMlServices.AsGumtreefiedElementTree(xModifiedTree, true);

                this.Download(new DownloadArgs
                {
                    Project = args.Project,
                    RevisionPairId = info.RevisionPair.Id.ToString(),
                    OriginalPath = args.OriginalPath,
                    ModifiedPath = args.ModifiedPath
                });

                if (args.Trace != null)
                    System.IO.File.AppendAllText(args.Trace,
                        $"{Environment.NewLine}{Environment.NewLine}" +
                        $"Starting comparison set ({args.ComparisonSetLeftId},{args.ComparisonSetRightId}) " +
                        $"{DateTime.Now.ToString("F", CultureInfo.InvariantCulture)} - {project.Name}");
                foreach (var betweenSymptom in info.ComparisonSet.XMatching.Matching)
                {
                    //this.RateMismatch(args, dr, betweenSymptom);
                    var mismatch = betweenSymptom is LRMatchSymptom lr
                        ? lr.Left
                        : ((RLMatchSymptom)betweenSymptom).Right;

                    (MatchDescriptor currentMatch, MatchDescriptor newMatch) ratedOriginal = (null, null), ratedModified = (null, null);
                    if (mismatch.Original.Element.Id != "-1")
                        ratedOriginal = this.RateMismatchedVersion(args, betweenSymptom, true, dr, oElements, mElements);
                    if (mismatch.Modified.Element.Id != "-1")
                        ratedModified = this.RateMismatchedVersion(args, betweenSymptom, false, dr, oElements, mElements);

                    var version = betweenSymptom is LRMatchSymptom ? "LR" : "RL";
                    if (args.Trace != null)
                        System.IO.File.AppendAllText(args.Trace,
                            $"{Environment.NewLine}{Environment.NewLine}" +
                            $"Rated mismatch {version} ({mismatch.Original.Element.Id},{mismatch.Modified.Element.Id}){Environment.NewLine}" +
                            $"  ({ratedOriginal.newMatch?.ToString() ?? ""}, {ratedOriginal.newMatch?.ToString() ?? ""}){Environment.NewLine}" +
                            $"  ({ratedModified.newMatch?.ToString() ?? ""}, {ratedModified.newMatch?.ToString() ?? ""}){Environment.NewLine} " +
                            $"{DateTime.Now.ToString("F", CultureInfo.InvariantCulture)} - {project.Name}");
                }
                if (args.Trace != null)
                    System.IO.File.AppendAllText(args.Trace,
                        $"{Environment.NewLine}{Environment.NewLine}" +
                        $"Ending comparison set ({args.ComparisonSetLeftId},{args.ComparisonSetRightId}) " +
                        $"{DateTime.Now.ToString("F", CultureInfo.InvariantCulture)} - {project.Name}");
            }
            Console.Out.WriteLine($"DONE!!!");
        }

        /// <summary>
        /// Command line logic to rate the original or modified version of a divergent match.
        /// </summary>
        /// <param name="args">Contains the input and computed information.</param>
        /// <param name="mismatch">the divergent match</param>
        /// <param name="originalIfTrueOtherwiseModified">indicates if the version to be rated is the original or the modified one.</param>
        /// <param name="manualDetectionResult">The detection result manually rated so far.</param>
        /// <returns>the current match, </returns>
        protected virtual (MatchDescriptor currentMatch, MatchDescriptor newMatch) RateMismatchedVersion(RateArgs args, BetweenSymptom mismatch,
            bool originalIfTrueOtherwiseModified, DetectionResult manualDetectionResult,
            IReadOnlyDictionary<string, XElement> oElements, IReadOnlyDictionary<string, XElement> mElements)
        {
            var matchInfo = mismatch is LRMatchSymptom lr
                ? lr.Left
                : ((RLMatchSymptom)mismatch).Right;

            var versionId = originalIfTrueOtherwiseModified ? matchInfo.Original.Element.Id : matchInfo.Modified.Element.Id;
            var alreadyMatched = this.IsAlreadyMatched(args, manualDetectionResult, originalIfTrueOtherwiseModified, versionId,
                oElements, mElements, out var alreadyMatchedInfo);

            (string RoslynId, string SrcmlId) originalInfo = (null, null), modifiedInfo = (null, null);
            if (!alreadyMatched || alreadyMatchedInfo.Undo)
            {
                var candidateMatches = new List<MatchDescriptor>(2);
                if (mismatch is LRMatchSymptom lrMismatch)
                {
                    candidateMatches.Add(new MatchDescriptor
                    {
                        Original = new ElementVersion {Id = lrMismatch.Left.Original.Element.Id},
                        Modified = new ElementVersion {Id = lrMismatch.Left.Modified.Element.Id}
                    });

                    if (originalIfTrueOtherwiseModified && lrMismatch.OriginalAtRight.Original.Element.Id != "-1")
                    {
                        candidateMatches.Add(new MatchDescriptor
                        {
                            Original = new ElementVersion {Id = lrMismatch.OriginalAtRight.Original.Element.Id},
                            Modified = new ElementVersion {Id = lrMismatch.OriginalAtRight.Modified.Element.Id}
                        });
                    }
                    else if (!originalIfTrueOtherwiseModified &&
                             lrMismatch.ModifiedAtRight.Modified.Element.Id != "-1")
                    {
                        candidateMatches.Add(new MatchDescriptor
                        {
                            Original = new ElementVersion {Id = lrMismatch.ModifiedAtRight.Original.Element.Id},
                            Modified = new ElementVersion {Id = lrMismatch.ModifiedAtRight.Modified.Element.Id}
                        });
                    }
                }
                else
                {
                    var rlMismatch = (RLMatchSymptom) mismatch;
                    candidateMatches.Add(new MatchDescriptor
                    {
                        Original = new ElementVersion {Id = rlMismatch.Right.Original.Element.Id},
                        Modified = new ElementVersion {Id = rlMismatch.Right.Modified.Element.Id}
                    });

                    if (originalIfTrueOtherwiseModified && rlMismatch.OriginalAtLeft.Original.Element.Id != "-1")
                    {
                        candidateMatches.Add(new MatchDescriptor
                        {
                            Original = new ElementVersion {Id = rlMismatch.OriginalAtLeft.Original.Element.Id},
                            Modified = new ElementVersion {Id = rlMismatch.OriginalAtLeft.Modified.Element.Id}
                        });
                    }
                    else if (!originalIfTrueOtherwiseModified &&
                             rlMismatch.ModifiedAtLeft.Modified.Element.Id != "-1")
                    {
                        candidateMatches.Add(new MatchDescriptor
                        {
                            Original = new ElementVersion {Id = rlMismatch.ModifiedAtLeft.Original.Element.Id},
                            Modified = new ElementVersion {Id = rlMismatch.ModifiedAtLeft.Modified.Element.Id}
                        });
                    }
                }

                var version = this.GetVersionDescription(originalIfTrueOtherwiseModified);
                Console.WriteLine($"Are any of these matches correct for the {version} version?");
                for (var i = 0; i < candidateMatches.Count; i++)
                {
                    Console.WriteLine(
                        $"{i} - ({this.PrintVersion(candidateMatches[i].Original.Id, oElements)}, " +
                                $"{this.PrintVersion(candidateMatches[i].Modified.Id, mElements)})");
                }

                Console.WriteLine($"{candidateMatches.Count} - NONE");
                var answer = this.ReadString("Type an answer number",
                    candidateMatches.Select((m, i) => i.ToString(CultureInfo.InvariantCulture))
                        .Union(new string[] {candidateMatches.Count.ToString(CultureInfo.InvariantCulture)})
                        .ToArray());

                if (answer != candidateMatches.Count.ToString(CultureInfo.InvariantCulture))
                {
                    var i = int.Parse(answer, CultureInfo.InvariantCulture);
                    originalInfo = (candidateMatches[i].Original.Id, this.ReadElementVersion(true, false).SrcmlId);
                    modifiedInfo = (candidateMatches[i].Modified.Id, this.ReadElementVersion(false, false).SrcmlId);
                }
                else
                {
                    originalInfo = this.ReadElementVersion(true);
                    modifiedInfo = this.ReadElementVersion(false);
                }
            }

            var currentMatch = alreadyMatched && alreadyMatchedInfo.Undo ? alreadyMatchedInfo.currentMatch : null;
            var newMatch = originalInfo.RoslynId != null || originalInfo.SrcmlId != null ||
                           modifiedInfo.RoslynId != null || modifiedInfo.SrcmlId != null 
                ? new MatchDescriptor 
                {
                    Original = new ElementVersion {Id = originalInfo.RoslynId, Label = originalInfo.SrcmlId},
                    Modified = new ElementVersion {Id = modifiedInfo.RoslynId, Label = modifiedInfo.SrcmlId},
                } 
                : null;

            return (currentMatch, newMatch);
        }

        private string PrintVersion(string id, IReadOnlyDictionary<string, XElement> elements)
        {
            if (id == "-1")
                return "NOTHING";

            var version = elements[id];
            return $"GtId-{version.GtID()} " +
                   $"RoslynMlId-{version.RmId()} " +
                   $"line:{version.StartLine()} " +
                   $"column:{version.StartColumn()} " +
                   $"label:{version.Label()} " +
                   $"hint:{version.Hint()}";
        }

        private bool IsAlreadyMatched(RateArgs args, DetectionResult detectionResult,
            bool originalIfTrueOtherwiseModified, string versionId,
            IReadOnlyDictionary<string, XElement> oElements, IReadOnlyDictionary<string, XElement> mElements,
            out (bool Undo, MatchDescriptor currentMatch) alreadyMatchedInfo)
        {
            var version = this.GetVersionDescription(originalIfTrueOtherwiseModified);
            var alreadyMatched = originalIfTrueOtherwiseModified
                ? detectionResult.Matches.SingleOrDefault(m => m.Original.Id == versionId)
                : detectionResult.Matches.SingleOrDefault(m => m.Modified.Id == versionId);

            if (alreadyMatched != null)
            {
                Console.WriteLine($"The {version} version is already matched");
                Console.WriteLine(
                    $"({this.PrintVersion(alreadyMatched.Original.Id, oElements)}, " +
                    $"{this.PrintVersion(alreadyMatched.Modified.Id, mElements)})");

                do
                {
                    string answer = null;
                    var confirmed = false;

                    answer = ReadString("Do you want to undo it (y/n)?", new[] {"y", "n"});
                    confirmed = this.ReadString(answer.ToLowerInvariant() == "y"
                                    ? "Confirm that you want to undo it (y/n)"
                                    : "Confirm that you do not want to undo it (y/n)", new[] {"y", "n"}) == "y";

                    if (!confirmed)
                        continue;

                    alreadyMatchedInfo = (answer == "y", alreadyMatched);
                    return true;
                } while (true);
            }

            alreadyMatchedInfo = (false, null);
            return false;
        }

        private string ReadString(string message, string[] expectedValues = null)
        {
            string input = null;
            do
            {
                Console.WriteLine(message);
                input = Console.ReadLine();
            } while (input == null || (!expectedValues?.Contains(input) ?? true));

            return input;
        }

        private (string RoslynId, string SrcmlId) ReadElementVersion(bool originalIfTrueOtherwiseModified,
            bool fullyIfTrueOtherwisePartially = true)
        {
            string input = null, roslynId = null, srcmlId = null;
            do
            {
                var version = this.GetVersionDescription(originalIfTrueOtherwiseModified);
                if (fullyIfTrueOtherwisePartially)
                    roslynId = ReadString($"Characterize the correct match: {version} Roslyn ID");

                input = this.ReadString("Do you know its srcML ID (y/n)?", new[] {"y", "n"});
                if (input == "y")
                    srcmlId = ReadString($"Characterize the correct match: {version} srcML ID");
            } while (input == null);

            return (roslynId, srcmlId);
        }

        private string GetVersionDescription(bool originalIfTrueOtherwiseModified)
        {
            return originalIfTrueOtherwiseModified ? "ORIGINAL" : "MODIFIED";
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="args"></param>
        ///// <example></example>
        //[ApplicationMetadata(Name = "review", Description = "Rate...")]
        //public virtual void ReviewMismatches(ReviewArgs args)
        //{
        //    this.Download(args);
        //    var revisionPairId = Guid.Parse(args.ComparisonSetId);

        //    var project = Projects.Single(p => p.Name == args.Project);
        //    using (var dbRepository = new GitRepository(project.Name) { Name = project.Name })
        //    {
        //        ((IObjectContextAdapter)dbRepository).ObjectContext.CommandTimeout = 600;

        //        var fileRevisionPair = dbRepository.FileRevisionPairs
        //            .Include("Principal.FileVersion.Content")
        //            .Include("Principal.FromFileVersion.Content")
        //            .AsNoTracking().Single(frp => frp.Principal.Id == revisionPairId);

        //        var originalRoot = SyntaxFactory.ParseCompilationUnit(fileRevisionPair.Principal.FromFileVersion.Content.SourceCode).SyntaxTree.GetRoot();
        //        var originalContentNode = originalRoot.NormalizeWhitespace("", Environment.NewLine);
        //        var modifiedRoot = SyntaxFactory.ParseCompilationUnit(fileRevisionPair.Principal.FileVersion.Content.SourceCode).SyntaxTree.GetRoot();
        //        var modifiedContentNode = modifiedRoot.NormalizeWhitespace("", Environment.NewLine);

        //        System.IO.File.WriteAllText(args.OriginalPath, originalContentNode.ToFullString());
        //        System.IO.File.WriteAllText(args.ModifiedPath, modifiedContentNode.ToFullString());
        //    }
        //    Console.Out.WriteLine($"DONE!!!"
    }

    //public class ReviewArgs : DownloadArgs
    //{
    //    [Argument(Name = "leftApproach")] public string LeftApproach { get; set; }

    //    [Argument(Name = "rightFileFormat")] public string RightFileFormat { get; set; }

    //    [Option(ShortName = "direction")] public string Direction { get; set; }
    //}

    public class RateArgs : IArgumentModel
    {
        [Argument(Name = "project")]
        public string Project { get; set; }

        [Argument(Name = "comparisonSetLeftId")]
        public string ComparisonSetLeftId { get; set; }

        [Argument(Name = "comparisonSetRightId")]
        public string ComparisonSetRightId { get; set; }

        [Option(ShortName = "originalPath")]
        public string OriginalPath { get; set; }

        [Option(ShortName = "modifiedPath")]
        public string ModifiedPath { get; set; }

        //[Argument(Name = "originalId")] public string OriginalId { get; set; }

        //[Argument(Name = "modifiedId")] public string ModifiedId { get; set; }

        //[Argument(Name = "deltaFileFormat")] public string DeltaFileFormat { get; set; }

        [Argument(Name = "fullFileFormat")] public string FullFileFormat { get; set; }

        //[Option(ShortName = "direction")]
        //public string Direction { get; set; }

        [Option(ShortName = "trace")]
        public string Trace { get; set; }

        ///// <summary>
        ///// The detection result manually rated so far.
        ///// </summary>
        //public DetectionResult DetectionResult { get; set; }

        //public Dictionary<string, XElement> OElements { get; set; }

        //public Dictionary<string, XElement> MElements { get; set; }
    }
}
