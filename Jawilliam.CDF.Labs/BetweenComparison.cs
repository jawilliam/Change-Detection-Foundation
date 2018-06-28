using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml.Linq;
using Jawilliam.CDF.Actions;
using Jawilliam.CDF.Approach;
using Jawilliam.CDF.Approach.GumTree;
using Jawilliam.CDF.Labs.DBModel;
using Microsoft.CodeAnalysis.CSharp;

namespace Jawilliam.CDF.Labs
{
    public class BetweenComparison : ImprecisionDiagnostic<MissedElement>
    {
        /// <summary>
        /// Gets or sets the configuration for the comparison.
        /// </summary>
        public virtual Criterion Config { get; set; }

        /// <summary>
        /// Looks for symptoms of imprecision.
        /// </summary>
        /// <param name="leftDelta">left delta.</param> 
        /// <param name="rightDelta">right delta.</param>
        /// <param name="pair">file revision pair being analized.</param>
        /// <param name="token">mechanism for cancelling the analisys.</param>
        public virtual IEnumerable<BetweenSymptom> Compare(Delta leftDelta, Delta rightDelta, FileRevisionPair pair, CancellationToken token)
        {
            //var lDelta = this.Config.LeftDeltaContainer(leftDelta, pair);
            //var leftOriginalTree = ElementTree.Read(lDelta.OriginalTree, Encoding.Unicode);
            //var leftModifiedTree = ElementTree.Read(lDelta.ModifiedTree, Encoding.Unicode);
            //var leftDetectionResult = (DetectionResult)leftDelta.DetectionResult;
            var leftOriginalTree = this.Config.GetTree((leftDelta, pair, true));
            var leftModifiedTree = this.Config.GetTree((leftDelta, pair, false));
            var leftDetectionResult = (DetectionResult)leftDelta.DetectionResult;

            var rightOriginalTree = this.Config.GetTree((rightDelta, pair, true));
            var rightModifiedTree = this.Config.GetTree((rightDelta, pair, false));
            var rightDetectionResult = (DetectionResult)rightDelta.DetectionResult;

            if (this.Config.Matches)
            {
                foreach (var leftMatch in leftDetectionResult.Matches)
                {
                    if (!rightDetectionResult.Matches.Any(rightMatch => this.Config.MatchCompare(leftMatch, leftDetectionResult, rightMatch, rightDetectionResult)))
                    {
                        yield return this.CreateBetweenMatchInfo("LR", leftMatch,
                            leftDetectionResult, rightDetectionResult,
                            leftOriginalTree, leftModifiedTree,
                            rightOriginalTree, rightModifiedTree);
                    }
                }

                if (this.Config.TwoWay)
                {
                    foreach (var rightMatch in rightDetectionResult.Matches)
                    {
                        if (!leftDetectionResult.Matches.Any(leftMatch => this.Config.MatchCompare(rightMatch, rightDetectionResult, leftMatch, leftDetectionResult)))
                        {
                            yield return this.CreateBetweenMatchInfo("RL", rightMatch,
                                leftDetectionResult, rightDetectionResult,
                                leftOriginalTree, leftModifiedTree,
                                rightOriginalTree, rightModifiedTree);
                        }
                    }
                }
            }

            //if (this.Config.Actions)
            //{
            //    foreach (var leftAction in leftDetectionResult.Actions)
            //    {
            //        if (!rightDetectionResult.Actions.Any(rightAction => this.Config.ActionCompare(leftAction, leftDetectionResult, rightAction, rightDetectionResult)))
            //        {
            //            //yield return new BetweenSymptom
            //            //{
            //            //    Id = Guid.NewGuid(),
            //            //    Pattern = $"{way}-Actions",
            //            //    Left = this.CreateBetweenPartInfo(this.Config.LeftName, Enum.GetName(typeof(ActionKind), leftAction.Action), 
            //            //                leftDetectionResult, leftOriginalTree, leftModifiedTree, leftAction),
            //            //    Right = this.CreateBetweenPartInfo(this.Config.RightName, "", null, null)
            //            //    //Right = this.CreateBetweenPartInfo(this.Config.RightName, rightDetectionResult,
            //            //    //    rightOriginalTree, rightModifiedTree, null)
            //            //};
            //        }
            //    }
            //}
        }

        /// <summary>
        /// Creates a description of match missed in a contrasting detection.
        /// </summary>
        /// <param name="missedMatch">the missed match.</param>
        /// <param name="leftDetection">the change detection result according to the left solution.</param>
        /// <param name="rightDetection">the change detection result according to the right solution.</param>
        /// <param name="leftOriginalTree">the original tree analized in the left behavior.</param>
        /// <param name="leftModifiedTree">the modified tree analized in the left behavior.</param>
        /// <param name="rightOriginalTree">the original tree analized in the right behavior.</param>
        /// <param name="rightModifiedTree">the modified tree analized in the right behavior.</param>
        /// <param name="way">flags to know if the analisys was done forward ("LR") or redward ("RL").</param>
        /// <returns>an structure describing the missed match and how the conceptual versions were detected in the contrasting result.</returns>
        protected virtual BetweenSymptom CreateBetweenMatchInfo(string way, RevisionDescriptor missedMatch, DetectionResult leftDetection, DetectionResult rightDetection, ElementTree leftOriginalTree, ElementTree leftModifiedTree, ElementTree rightOriginalTree, ElementTree rightModifiedTree)
        {
            ElementTree missedOriginal, missedModified, divergentOriginal, divergentModified;
            RevisionDescriptor divergentMatch;
            switch (way)
            {
                case "LR":
                    missedOriginal = leftOriginalTree.PostOrder(n => n.Children).First(n => n.Root.Id == missedMatch.Original.Id);
                    missedModified = leftModifiedTree.PostOrder(n => n.Children).First(n => n.Root.Id == missedMatch.Modified.Id);
                    var lr = new LRMatchSymptom
                    {
                        Id = Guid.NewGuid(),
                        IsTop = true,
                        Left = new BetweenMatchInfo
                        {
                            PartName = this.Config.LeftName,
                            Approach = (int)this.Config.Left,
                            Original = this.CreateElementContext(missedOriginal),
                            Modified = this.CreateElementContext(missedModified)
                        }
                    };

                    divergentMatch = this.Config.DivergentMatchForOriginal(missedMatch, leftDetection, rightDetection); 
                    divergentOriginal = divergentMatch != null 
                        ? rightOriginalTree.PostOrder(n => n.Children).FirstOrDefault(n => n.Root.Id == divergentMatch.Original.Id)
                        : null;
                    divergentModified = divergentMatch != null
                        ? rightModifiedTree.PostOrder(n => n.Children).FirstOrDefault(n => n.Root.Id == divergentMatch.Modified.Id)
                        : null;
                    lr.OriginalAtRight = new BetweenMatchInfo
                    {
                        PartName = this.Config.RightName,
                        Approach = (int)this.Config.Right,
                        Original = this.CreateElementContext(divergentOriginal),
                        Modified = this.CreateElementContext(divergentModified)
                    };

                    divergentMatch = this.Config.DivergentMatchForModified(missedMatch, leftDetection, rightDetection);
                    divergentOriginal = divergentMatch != null
                        ? rightOriginalTree.PostOrder(n => n.Children).FirstOrDefault(n => n.Root.Id == divergentMatch.Original.Id)
                        : null;
                    divergentModified = divergentMatch != null
                        ? rightModifiedTree.PostOrder(n => n.Children).FirstOrDefault(n => n.Root.Id == divergentMatch.Modified.Id)
                        : null;
                    lr.ModifiedAtRight = new BetweenMatchInfo
                    {
                        PartName = this.Config.RightName,
                        Approach = (int)this.Config.Right,
                        Original = this.CreateElementContext(divergentOriginal),
                        Modified = this.CreateElementContext(divergentModified)
                    };

                    return lr;
                case "RL":
                    missedOriginal = rightOriginalTree.PostOrder(n => n.Children).First(n => n.Root.Id == missedMatch.Original.Id);
                    missedModified = rightModifiedTree.PostOrder(n => n.Children).First(n => n.Root.Id == missedMatch.Modified.Id);
                    var rl = new RLMatchSymptom
                    {
                        Id = Guid.NewGuid(),
                        IsTop = true,
                        Right = new BetweenMatchInfo
                        {
                            PartName = this.Config.RightName,
                            Approach = (int)this.Config.Right,
                            Original = this.CreateElementContext(missedOriginal),
                            Modified = this.CreateElementContext(missedModified)
                        }
                    };

                    divergentMatch = this.Config.DivergentMatchForOriginal(missedMatch, rightDetection, leftDetection);
                    divergentOriginal = divergentMatch != null
                        ? leftOriginalTree.PostOrder(n => n.Children).FirstOrDefault(n => n.Root.Id == divergentMatch.Original.Id)
                        : null;
                    divergentModified = divergentMatch != null
                        ? leftModifiedTree.PostOrder(n => n.Children).FirstOrDefault(n => n.Root.Id == divergentMatch.Modified.Id)
                        : null;
                    rl.OriginalAtLeft = new BetweenMatchInfo
                    {
                        PartName = this.Config.LeftName,
                        Approach = (int)this.Config.Left,
                        Original = this.CreateElementContext(divergentOriginal),
                        Modified = this.CreateElementContext(divergentModified)
                    };

                    divergentMatch = this.Config.DivergentMatchForModified(missedMatch, rightDetection, leftDetection);
                    divergentOriginal = divergentMatch != null
                        ? leftOriginalTree.PostOrder(n => n.Children).FirstOrDefault(n => n.Root.Id == divergentMatch.Original.Id)
                        : null;
                    divergentModified = divergentMatch != null
                        ? leftModifiedTree.PostOrder(n => n.Children).FirstOrDefault(n => n.Root.Id == divergentMatch.Modified.Id)
                        : null;
                    rl.ModifiedAtLeft = new BetweenMatchInfo
                    {
                        PartName = this.Config.LeftName,
                        Approach = (int)this.Config.Left,
                        Original = this.CreateElementContext(divergentOriginal),
                        Modified = this.CreateElementContext(divergentModified)
                    };

                    return rl;
                default: throw new ArgumentOutOfRangeException(nameof(way), "Way is expected to be 'LR' or 'RL'");
            }
        }

        private ElementContext CreateElementContext(ElementTree missedOriginal)
        {
            return new ElementContext
            {
                Element = new ElementDescription
                {
                    Hint = missedOriginal?.Root.Value,
                    Id = missedOriginal?.Root.Id ?? "-1",
                    Type = missedOriginal?.Root.Label ?? ""
                },
                ScopeHint = missedOriginal == null ? null : this.GetPath(missedOriginal.Ancestors())
            };
        }

        //private BetweenPartInfo CreateBetweenPartInfo(string partName, string operation,
        //    DetectionResult detectionResult, ElementTree originalTree,
        //    ElementTree modifiedTree, ActionDescriptor action)
        //{
        //    ElementTree originalOrParent, modifiedOrElement;
        //    switch (action.Action)
        //    {
        //        case ActionKind.Update:
        //            var update = (UpdateOperationDescriptor)action;
        //            var match = detectionResult.Matches.Single(m => m.Original.Id == update.Element.Id);
        //            originalOrParent = originalTree.PostOrder(n => n.Children)
        //                .First(n => n.Root.Id == match.Original.Id);
        //            modifiedOrElement = modifiedTree.PostOrder(n => n.Children)
        //                .First(n => n.Root.Id == match.Modified.Id);
        //            break;
        //        case ActionKind.Insert:
        //            var insert = (InsertOperationDescriptor)action;
        //            originalOrParent = originalTree.PostOrder(n => n.Children)
        //                .FirstOrDefault(n => n.Root.Id == insert.Parent.Id);
        //            modifiedOrElement = modifiedTree.PostOrder(n => n.Children)
        //                .First(n => n.Root.Id == insert.Element.Id);
        //            break;
        //        case ActionKind.Delete:
        //            var delete = (DeleteOperationDescriptor)action;
        //            modifiedOrElement = originalTree.PostOrder(n => n.Children)
        //                .First(n => n.Root.Id == delete.Element.Id);
        //            originalOrParent = originalTree.PostOrder(n => n.Children)
        //                .First(n => n.Root.Id == modifiedOrElement.Parent.Root.Id);
        //            break;
        //        case ActionKind.Move:
        //            var move = (MoveOperationDescriptor)action;
        //            originalOrParent = originalTree.PostOrder(n => n.Children)
        //                .FirstOrDefault(n => n.Root.Id == move.Parent.Id);
        //            modifiedOrElement = originalTree.PostOrder(n => n.Children)
        //                .First(n => n.Root.Id == move.Element.Id);
        //            break;
        //        //case ActionKind.Align:
        //        //    break;
        //        default:
        //            throw new ArgumentOutOfRangeException();
        //    }
        //    return this.CreateBetweenPartInfo(partName, operation, originalOrParent, modifiedOrElement);
        //}

        /// <summary>
        /// Looks for symptoms of imprecision.
        /// </summary>
        /// <param name="skipThese">local criterion for determining elements that should be ignored.</param>
        /// <param name="saveChanges">Enables or disables the persistence of the changes.</param>
        public virtual void Recognize(Func<FileRevisionPair, bool> skipThese, bool saveChanges = true)
        {
            this.Analyze(f => f.Principal.Deltas.Any(d => d.Approach == this.Config.Left &&
                                                          d.Matching != null && 
                                                          d.Differencing != null && 
                                                          d.Report == null) && 
                              f.Principal.Deltas.Any(d => d.Approach == this.Config.Right &&
                                                          d.Matching != null && 
                                                          d.Differencing != null && 
                                                          d.Report == null), 
            delegate (FileRevisionPair pair, CancellationToken token)
            {
                if (skipThese?.Invoke(pair) ?? false) return;
                var leftDelta = this.SqlRepository.Deltas.Single(d => d.RevisionPair.Id == pair.Principal.Id && d.Approach == this.Config.Left);
                var rightDelta = this.SqlRepository.Deltas.Single(d => d.RevisionPair.Id == pair.Principal.Id && d.Approach == this.Config.Right);
                
                try
                {
                    var symptoms = this.Compare(leftDelta, rightDelta, pair, token).ToList();
                    //if (symptoms.Count > 0)
                    //    this.Rate(pair);
                    foreach (var betweenSymptom in symptoms)
                    {
                        if (saveChanges)
                            leftDelta.Symptoms.Add(betweenSymptom);
                    }
                }
                catch (OperationCanceledException)
                {
                    this.Report.AppendLine($"CANCELED;{pair.Id}");
                    throw;
                }
                catch (OutOfMemoryException)
                {
                    this.Report.AppendLine($"OUTOFMEMORY;{pair.Id}");
                    throw;
                }
            }, saveChanges, /*"Principal"*/ "Principal.FileVersion"/*".Content"*/, "Principal.FromFileVersion"/*".Content"*/);
        }

        public virtual void ConnectMatchSymptoms(Func<FileRevisionPair, bool> skipThese = null, bool saveChanges = true)
        {
            this.Analyze(f => f.Principal.Deltas.Any(d => d.Approach == this.Config.Left &&
                                                             d.Matching != null &&
                                                             d.Differencing != null &&
                                                             d.Report == null && (d.Symptoms.OfType<LRMatchSymptom>().Any() || d.Symptoms.OfType<RLMatchSymptom>().Any())) &&
                                 f.Principal.Deltas.Any(d => d.Approach == this.Config.Right &&
                                                             d.Matching != null &&
                                                             d.Differencing != null &&
                                                             d.Report == null),
               delegate (FileRevisionPair pair, CancellationToken token)
               {
                   if (skipThese?.Invoke(pair) ?? false) return;
                   var leftDelta = this.SqlRepository.Deltas.Single(d => d.RevisionPair.Id == pair.Principal.Id && d.Approach == this.Config.Left);
                   var rightDelta = this.SqlRepository.Deltas.Single(d => d.RevisionPair.Id == pair.Principal.Id && d.Approach == this.Config.Right);

                   try
                   {
                       ConnectMatchSymptoms(leftDelta, rightDelta, pair);
                   }
                   catch (OperationCanceledException)
                   {
                       this.Report.AppendLine($"CANCELED;{pair.Id}");
                       throw;
                   }
                   catch (OutOfMemoryException)
                   {
                       this.Report.AppendLine($"OUTOFMEMORY;{pair.Id}");
                       throw;
                   }
               }, saveChanges, "Principal" /*"Principal.FileVersion.Content", "Principal.FromFileVersion.Content"*/);
        }

        private void ConnectMatchSymptoms(Delta leftDelta, Delta rightDelta, FileRevisionPair pair)
        {
            //var lDelta = this.Config.LeftDeltaContainer(leftDelta, pair);
            var leftOriginalTree = this.Config.GetTree((leftDelta, pair, true));
            //var leftModifiedTree = ElementTree.Read(leftDelta.ModifiedTree, Encoding.Unicode);
            //var leftDetectionResult = (DetectionResult)leftDelta.DetectionResult;

            //var rDelta = this.Config.RightDeltaContainer(rightDelta, pair);
            var rightOriginalTree = this.Config.GetTree((rightDelta, pair, true));
            //var rightModifiedTree = ElementTree.Read(rightDelta.ModifiedTree, Encoding.Unicode);
            //var rightDetectionResult = (DetectionResult)rightDelta.DetectionResult;

            if (this.Config.Matches)
            {
                var lApproach = (int)this.Config.Left;
                var rApproach = (int)this.Config.Right;
                var lrMatchSymptoms = this.SqlRepository.Symptoms.OfType<LRMatchSymptom>().Where(s => s.Delta.Id == leftDelta.Id && 
                                      (s.Left.Approach == lApproach && s.OriginalAtRight.Approach == rApproach && s.ModifiedAtRight.Approach == rApproach))
                                      .ToList();
                var leftBfs = leftOriginalTree.BreadthFirstOrder(e => e.Children).Reverse().ToList();
                foreach (var item in leftBfs)
                {
                    var lrMatches = lrMatchSymptoms.Where(lr => lr.Left.Original.Element.Id == item.Root.Id).ToList();
                    if (!lrMatches.Any()) continue;
                    if (lrMatches.Count > 1)
                        ;

                    foreach (var lrMatch in lrMatches)
                    {
                        bool fullSubtree = true;
                        foreach (var child in item.Children)
                        {
                            var lrChildMatches = lrMatchSymptoms.Where(lr => lr.Left.Original.Element.Id == child.Root.Id).ToList();
                            if (lrChildMatches.Count > 1)
                                ;
                            fullSubtree &= lrChildMatches.Any();
                            foreach (var lrChildMatch in lrChildMatches)
                            {
                                lrMatch.Symptoms.Add(lrChildMatch);
                            }
                        }
                        if (fullSubtree)
                            lrMatch.Notes = lrMatch.Notes == null
                             ? (SymptomNotes.Full | SymptomNotes.SubTree)
                             : lrMatch.Notes | SymptomNotes.Full | SymptomNotes.SubTree;
                    }
                }

                if (this.Config.TwoWay)
                {
                    var rlMatchSymptoms = this.SqlRepository.Symptoms.OfType<RLMatchSymptom>().Where(s => s.Delta.Id == leftDelta.Id &&
                                          (s.Right.Approach == rApproach && s.OriginalAtLeft.Approach == lApproach && s.ModifiedAtLeft.Approach == lApproach))
                                          .ToList();
                    var rightBfs = rightOriginalTree.BreadthFirstOrder(e => e.Children).Reverse().ToList();
                    foreach (var item in rightBfs)
                    {
                        var rlMatches = rlMatchSymptoms.Where(rl => rl.Right.Original.Element.Id == item.Root.Id).ToList();
                        if (!rlMatches.Any()) continue;
                        if (rlMatches.Count > 1)
                            ;

                        foreach (var rlMatch in rlMatches)
                        {
                            bool fullSubtree = true;
                            foreach (var child in item.Children)
                            {
                                var rlChildMatches = rlMatchSymptoms.Where(rl => rl.Right.Original.Element.Id == child.Root.Id).ToList();
                                if (rlChildMatches.Count > 1)
                                    ;
                                fullSubtree &= rlChildMatches.Any();
                                foreach (var rlChildMatch in rlChildMatches)
                                {
                                    rlMatch.Symptoms.Add(rlChildMatch);
                                }
                            }
                            if (fullSubtree)
                                rlMatch.Notes = rlMatch.Notes == null
                                 ? (SymptomNotes.Full | SymptomNotes.SubTree)
                                 : rlMatch.Notes | SymptomNotes.Full | SymptomNotes.SubTree;
                        }
                    }
                }
            }

            //if (this.Config.Actions)
            //{
            //    //foreach (var leftAction in leftDetectionResult.Actions)
            //    //{
            //    //    if (!rightDetectionResult.Actions.Any(
            //    //            rightAction =>
            //    //                this.Config.ActionCompare(leftAction, leftDetectionResult, rightAction, rightDetectionResult)))
            //    //    {
            //    //        //yield return new BetweenSymptom
            //    //        //{
            //    //        //    Id = Guid.NewGuid(),
            //    //        //    Pattern = $"{way}-Actions",
            //    //        //    Left = this.CreateBetweenPartInfo(this.Config.LeftName, Enum.GetName(typeof(ActionKind), leftAction.Action), 
            //    //        //                leftDetectionResult, leftOriginalTree, leftModifiedTree, leftAction),
            //    //        //    Right = this.CreateBetweenPartInfo(this.Config.RightName, "", null, null)
            //    //        //    //Right = this.CreateBetweenPartInfo(this.Config.RightName, rightDetectionResult,
            //    //        //    //    rightOriginalTree, rightModifiedTree, null)
            //    //        //};
            //    //    }
            //    //}
            //}
        }

        /// <summary>
        /// Iterates symptoms to be rated.
        /// </summary>
        public virtual void Rate(FileRevisionPair pair, InteropArgs fileVersionPaths = null, SourceCodeCleaner cleaner = null)
        {
            var fvp = fileVersionPaths ?? new InteropArgs
            {
                Original = @"E:\SourceCode\O1.cs",
                Modified = @"E:\SourceCode\M1.cs"
            };

            var original = SyntaxFactory.ParseCompilationUnit(pair.Principal.FromFileVersion.Content.SourceCode).SyntaxTree.GetRoot();
            var modified = SyntaxFactory.ParseCompilationUnit(pair.Principal.FileVersion.Content.SourceCode).SyntaxTree.GetRoot();

            var preprocessedOriginal = cleaner != null ? cleaner.Clean(original) : original;
            var preprocessedModified = cleaner != null ? cleaner.Clean(modified) : modified;
            System.IO.File.WriteAllText(fvp.Original, preprocessedOriginal.ToFullString(), Encoding.Default);
            System.IO.File.WriteAllText(fvp.Modified, preprocessedModified.ToFullString(), Encoding.Default);
        }

        /// <summary>
        /// Looks for symptoms of imprecision.
        /// </summary>
        public override void Recognize()
        {
            this.Recognize(null, false);
        }

        /// <summary>
        /// Reports the totals of between match symptoms, as well their percentages in relation to the project corpus.
        /// </summary>
        /// <returns>numbers discriminating among LR-matches and RL-matches, and also the total of matches.</returns>
        public virtual (string Project, int TotalOfFileRevisionPairs, (int LR, int RL, int All) TotalOfSymptoms, (int LR, int RL, int All) TotalOfAffectedFileRevisionPairs, (double LR, double RL, double All) PercentageOfAffectedFileRevisionPairs) ReportBetweenMatches()
        {
            var fileRevisionPairs = this.SqlRepository.FileRevisionPairs.AsNoTracking().Where(f =>
                              f.Principal.Deltas.Any(d => d.Approach == this.Config.Left &&
                                                          d.Matching != null &&
                                                          d.Differencing != null &&
                                                          d.Report == null) &&
                              f.Principal.Deltas.Any(d => d.Approach == this.Config.Right &&
                                                          d.Matching != null &&
                                                          d.Differencing != null &&
                                                          d.Report == null));

            var totalOfFrps = fileRevisionPairs.Count();
            var affectedFrps = from f in fileRevisionPairs
                               let d = f.Principal.Deltas.Where(d => d.Approach == this.Config.Left &&
                                                          d.Matching != null &&
                                                          d.Differencing != null &&
                                                          d.Report == null)
                               select d.FirstOrDefault();

            var totalOfLrSymptoms = !affectedFrps.Any() ? 0 : affectedFrps.Sum(d => d == null ? 0 : d.Symptoms.OfType<LRMatchSymptom>().Where(s => s.Parent == null).Count());
            var totalOfRlSymptoms = !affectedFrps.Any() ? 0 : affectedFrps.Sum(d => d == null ? 0 : d.Symptoms.OfType<RLMatchSymptom>().Where(s => s.Parent == null).Count());

            var totalOfLrAffectedFrps = !affectedFrps.Any() ? 0 : affectedFrps.Count(d => d == null ? false : d.Symptoms.OfType<LRMatchSymptom>().Where(s => s.Parent == null).Any());
            var totalOfRlAffectedFrps = !affectedFrps.Any() ? 0 : affectedFrps.Count(d => d == null ? false : d.Symptoms.OfType<RLMatchSymptom>().Where(s => s.Parent == null).Any());
            var totalOfAffectedFrps = !affectedFrps.Any() ? 0 : affectedFrps.Count(d => d == null ? false : d.Symptoms.OfType<LRMatchSymptom>().Where(s => s.Parent == null).Any() ||
                                                                                                            d.Symptoms.OfType<RLMatchSymptom>().Where(s => s.Parent == null).Any());

            return (this.SqlRepository.Name, totalOfFrps, 
                    (totalOfLrSymptoms, totalOfRlSymptoms, totalOfLrSymptoms + totalOfRlSymptoms), 
                    (totalOfLrAffectedFrps, totalOfRlAffectedFrps, totalOfAffectedFrps),
                    (totalOfFrps == 0 ? 0 : totalOfLrAffectedFrps * 100d / totalOfFrps, 
                     totalOfFrps == 0 ? 0 : totalOfRlAffectedFrps * 100d / totalOfFrps, 
                     totalOfFrps == 0 ? 0 : totalOfAffectedFrps * 100d / totalOfFrps));
        }

        /// <summary>
        /// Gathers a referential summary and save it in <see cref="FileRevisionPairAnalyzer.Report"/>.
        /// </summary>
        public override void ReportSummary()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Iterates symptoms to be rated.
        /// </summary>
        public override void Rate()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns a configuration to check for reversible changes.
        /// </summary>
        public virtual void ConfigGumTreeVsReversedGumTree()
        {
            this.Config = new Criterion
            {
                Left = ChangeDetectionApproaches.NativeGumTree,
                LeftName = "GumTree",
                Right = ChangeDetectionApproaches.InverseOfNativeGumTree,
                RightName = "ReversedGumTree",
                TwoWay = true,
                MatchCompare = (leftMatch, leftDelta, rightMatch, rightDelta) => 
                    leftMatch.Original.Id == rightMatch.Modified.Id &&
                    leftMatch.Modified.Id == rightMatch.Original.Id,
                ActionCompare = delegate(ActionDescriptor leftAction, DetectionResult leftDelta, ActionDescriptor rightAction, DetectionResult rightDelta)
                {
                    switch (leftAction.Action)
                    {
                        case ActionKind.Update:
                            if (rightAction.Action == ActionKind.Update)
                            {
                                var l = (UpdateOperationDescriptor)leftAction;
                                var leftMatch = leftDelta.Matches.Single(m => m.Original.Id == l.Element.Id);
                                var r = (UpdateOperationDescriptor)rightAction;
                                var rightMatch = rightDelta.Matches.Single(m => m.Original.Id == r.Element.Id);

                                return leftMatch.Original.Id == rightMatch.Modified.Id &&
                                       leftMatch.Modified.Id == rightMatch.Original.Id;
                            }
                            break;
                        case ActionKind.Insert:
                            if (rightAction.Action == ActionKind.Delete)
                            {
                                var l = (InsertOperationDescriptor)leftAction;
                                var r = (DeleteOperationDescriptor)rightAction;
                                return l.Element.Id == r.Element.Id;
                            }
                            break;
                        case ActionKind.Delete:
                            if (rightAction.Action == ActionKind.Insert)
                            {
                                var l = (DeleteOperationDescriptor)leftAction;
                                var r = (InsertOperationDescriptor)rightAction;
                                return l.Element.Id == r.Element.Id;
                            }
                            break;
                        case ActionKind.Move:
                            if (rightAction.Action == ActionKind.Move)
                            {
                                var l = (MoveOperationDescriptor)leftAction;
                                var leftMatch = leftDelta.Matches.Single(m => m.Original.Id == l.Element.Id);
                                var r = (MoveOperationDescriptor)rightAction;
                                var rightMatch = rightDelta.Matches.Single(m => m.Original.Id == r.Element.Id);

                                return leftMatch.Original.Id == rightMatch.Modified.Id &&
                                       leftMatch.Modified.Id == rightMatch.Original.Id;
                            }
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                    return false;
                },
                DivergentMatchForOriginal = (missedMatch, leftDetection, rightDetection) => 
                    rightDetection.Matches.FirstOrDefault(m => missedMatch.Original.Id == m.Modified.Id),
                DivergentMatchForModified = (missedMatch, leftDetection, rightDetection) =>
                    rightDetection.Matches.FirstOrDefault(m => missedMatch.Modified.Id == m.Original.Id)
            };
        }

        /// <summary>
        /// Returns a configuration to check for reversible changes.
        /// </summary>
        /// <param name="leftName"></param>
        /// <param name="leftApproach"></param>
        /// <param name="rightApproach"></param>
        /// <param name="rightName"></param>
        public virtual void ConfigLeftVsRight((ChangeDetectionApproaches Approach, string Name) left, (ChangeDetectionApproaches Approach, string Name) right)
        {
            this.Config = new Criterion
            {
                Left = left.Approach,
                LeftName = left.Name,
                Right = right.Approach,
                RightName = right.Name,
                TwoWay = true,
                MatchCompare = (leftMatch, leftDelta, rightMatch, rightDelta) => leftMatch.Original.Id == rightMatch.Original.Id && leftMatch.Modified.Id == rightMatch.Modified.Id,
                ActionCompare = delegate (ActionDescriptor leftAction, DetectionResult leftDelta, ActionDescriptor rightAction, DetectionResult rightDelta)
                {
                    switch (leftAction.Action)
                    {
                        case ActionKind.Update:
                            if (rightAction.Action == ActionKind.Update)
                            {
                                var l = (UpdateOperationDescriptor)leftAction;
                                var leftMatch = leftDelta.Matches.Single(m => m.Original.Id == l.Element.Id);
                                var r = (UpdateOperationDescriptor)rightAction;
                                var rightMatch = rightDelta.Matches.Single(m => m.Original.Id == r.Element.Id);

                                return leftMatch.Original.Id == rightMatch.Modified.Id && leftMatch.Modified.Id == rightMatch.Original.Id;
                            }
                            break;
                        case ActionKind.Insert:
                            if (rightAction.Action == ActionKind.Insert)
                            {
                                var l = (InsertOperationDescriptor)leftAction;
                                var r = (InsertOperationDescriptor)rightAction;
                                return l.Element.Id == r.Element.Id && l.Parent.Id == r.Parent.Id && l.Position == r.Position;
                            }
                            break;
                        case ActionKind.Delete:
                            if (rightAction.Action == ActionKind.Delete)
                            {
                                var l = (DeleteOperationDescriptor)leftAction;
                                var r = (DeleteOperationDescriptor)rightAction;
                                return l.Element.Id == r.Element.Id;
                            }
                            break;
                        case ActionKind.Move:
                            if (rightAction.Action == ActionKind.Move)
                            {
                                var l = (MoveOperationDescriptor)leftAction;
                                var r = (MoveOperationDescriptor)rightAction;
                                return l.Element.Id == r.Element.Id && l.Parent.Id == r.Parent.Id && l.Position == r.Position;
                            }
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                    return false;
                },
                DivergentMatchForOriginal = (missedMatch, leftDetection, rightDetection) => rightDetection.Matches.FirstOrDefault(m => missedMatch.Original.Id == m.Original.Id),
                DivergentMatchForModified = (missedMatch, leftDetection, rightDetection) => rightDetection.Matches.FirstOrDefault(m => missedMatch.Modified.Id == m.Modified.Id),
                //LeftDeltaContainer = (ld, frp) => ld,
                //RightDeltaContainer = (rd, frp) => this.SqlRepository.Deltas.Single(d => frp.Principal.Id == d.RevisionPair.Id && d.Approach == left.Approach),
                //GetTree = delegate ((Delta Delta, FileRevisionPair Pair, bool TrueForOriginalOtherwiseModified) args)
                //{
                //    var d = 
                //}
            };
        }

        /// <summary>
        /// Implements placeholders to configure the between comparison.
        /// </summary>
        public class Criterion
        {
            /// <summary>
            /// Gets or sets the left-comparing approach.
            /// </summary>
            public virtual ChangeDetectionApproaches Left { get; set; }

            /// <summary>
            /// Gets or sets the name of the left-comparing approach.
            /// </summary>
            public virtual string LeftName { get; set; }

            /// <summary>
            /// Gets or sets the left-comparing approach.
            /// </summary>
            public virtual ChangeDetectionApproaches Right { get; set; }

            /// <summary>
            /// Gets or sets the name of the right-comparing approach.
            /// </summary>
            public virtual string RightName { get; set; }

            /// <summary>
            /// Gets or sets if the comparison is left-to-right and right-to-left (TRUE), or just left-to-right (FALSE).
            /// </summary>
            public virtual bool TwoWay { get; set; }

            /// <summary>
            /// Enables or disables the matching analysis.
            /// </summary>
            public virtual bool Matches { get; set; } = true;

            /// <summary>
            /// Enables or disables the actions analysis.
            /// </summary>
            public virtual bool Actions { get; set; } = true;

            /// <summary>
            /// Gets or sets how to compare two matching sets.
            /// </summary>
            public Func<RevisionDescriptor, DetectionResult, RevisionDescriptor, DetectionResult, bool> MatchCompare { get; set; }

            /// <summary>
            /// Gets or sets how to: given a match supposely not detected, know how its original was otherwise matched.
            /// </summary>
            public Func<RevisionDescriptor, DetectionResult, DetectionResult, RevisionDescriptor> DivergentMatchForOriginal { get; set; }

            /// <summary>
            /// Gets or sets how to: given a match supposely not detected, know how its modified was otherwise matched.
            /// </summary>
            public Func<RevisionDescriptor, DetectionResult, DetectionResult, RevisionDescriptor> DivergentMatchForModified { get; set; }

            /// <summary>
            /// Gets or sets how to compare two detection results.
            /// </summary>
            public Func<ActionDescriptor, DetectionResult, ActionDescriptor, DetectionResult, bool> ActionCompare { get; set; }

            ///// <summary>
            ///// Gets or sets the delta from which to take the left ASTs (original and modified).
            ///// </summary>
            //public virtual Func<Delta, FileRevisionPair, Delta> LeftDeltaContainer { get; set; } = (d, frp) => d;

            ///// <summary>
            ///// Gets or sets the delta from which to take the right ASTs (original and modified).
            ///// </summary>
            //public virtual Func<Delta, FileRevisionPair, Delta> RightDeltaContainer { get; set; } = (d, frp) => d;

            /// <summary>
            /// Gets or sets the how to get the original (or modified) tree of the left (or right) comparing delta.
            /// </summary>
            public virtual Func<(Delta Delta, FileRevisionPair Pair, bool TrueForOriginalOtherwiseModified), ElementTree> GetTree { get; set; } 
                = (a) => a.TrueForOriginalOtherwiseModified
                ? ElementTree.Read(a.Delta.OriginalTree, Encoding.Unicode) 
                : ElementTree.Read(a.Delta.ModifiedTree, Encoding.Unicode);
        }
    }
}