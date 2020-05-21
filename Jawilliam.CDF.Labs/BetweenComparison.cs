using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml.Linq;
using Jawilliam.CDF.Actions;
using Jawilliam.CDF.Approach;
using Jawilliam.CDF.Approach.GumTree;
using Jawilliam.CDF.Labs.DBModel;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jawilliam.CDF.Labs
{
    public class BetweenComparison : BaseImprecisionComparison<BetweenSymptom>
    {
        /// <summary>
        /// Gets or sets the configuration for the comparison.
        /// </summary>
        public virtual BetweenComparisonCriterion Config { get; set; }

        /// <summary>
        /// Looks for symptoms of imprecision.
        /// </summary>
        /// <param name="leftDelta">left delta.</param> 
        /// <param name="rightDelta">right delta.</param>
        /// <param name="pair">file revision pair being analyzed.</param>
        /// <param name="token">mechanism for cancelling the analysis.</param>
        public virtual IEnumerable<BetweenSymptom> Compare(Delta leftDelta, Delta rightDelta, FileRevisionPair pair, CancellationToken token)
        {
            //var lDelta = this.Config.LeftDeltaContainer(leftDelta, pair);
            //var leftOriginalTree = ElementTree.Read(lDelta.OriginalTree, Encoding.Unicode);
            //var leftModifiedTree = ElementTree.Read(lDelta.ModifiedTree, Encoding.Unicode);
            //var leftDetectionResult = (DetectionResult)leftDelta.DetectionResult;
            var lOriginalTree = this.Config.GetTree((leftDelta, pair, true));
            var lModifiedTree = this.Config.GetTree((leftDelta, pair, false));
            var leftDetectionResult = (DetectionResult)leftDelta.DetectionResult;
            this.Config?.Align?.Invoke(lOriginalTree, lModifiedTree, leftDetectionResult, true);
            var leftOriginalTree = lOriginalTree.PostOrder(n => n.Children).Where(n => n.Root.Id != null).ToDictionary(n => n.Root.Id);
            var leftModifiedTree = lModifiedTree.PostOrder(n => n.Children).Where(n => n.Root.Id != null).ToDictionary(n => n.Root.Id);

            var rOriginalTree = this.Config.GetTree((rightDelta, pair, true));
            var rModifiedTree = this.Config.GetTree((rightDelta, pair, false));
            var rightDetectionResult = (DetectionResult)rightDelta.DetectionResult;
            this.Config?.Align?.Invoke(rOriginalTree, rModifiedTree, rightDetectionResult, false);
            var rightOriginalTree = rOriginalTree.PostOrder(n => n.Children).Where(n => n.Root.Id != null).ToDictionary(n => n.Root.Id);
            var rightModifiedTree = rModifiedTree.PostOrder(n => n.Children).Where(n => n.Root.Id != null).ToDictionary(n => n.Root.Id);

            if (this.Config.Matches)
            {
                foreach (var leftMatch in leftDetectionResult.Matches)
                {
                    if (!rightDetectionResult.Matches.Any(rightMatch => this.Config.MatchCompare("LR", leftMatch, leftDetectionResult, rightMatch, rightDetectionResult)))
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
                        if (!leftDetectionResult.Matches.Any(leftMatch => this.Config.MatchCompare("RL", rightMatch, rightDetectionResult, leftMatch, leftDetectionResult)))
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
            //        if (!rightDetectionResult.Actions.Any(rightAction => this.Config.ActionCompare("LR", leftAction, leftDetectionResult, rightAction, rightDetectionResult)))
            //        {
            //            yield return new BetweenSymptom
            //            {
            //                Id = Guid.NewGuid(),
            //                Pattern = $"{way}-Actions",
            //                Left = this.CreateBetweenPartInfo(this.Config.LeftName, Enum.GetName(typeof(ActionKind), leftAction.Action),
            //                            leftDetectionResult, leftOriginalTree, leftModifiedTree, leftAction),
            //                Right = this.CreateBetweenPartInfo(this.Config.RightName, "", null, null)
            //                //Right = this.CreateBetweenPartInfo(this.Config.RightName, rightDetectionResult,
            //                //    rightOriginalTree, rightModifiedTree, null)
            //            };
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
        protected virtual BetweenSymptom CreateBetweenMatchInfo(string way, MatchDescriptor missedMatch, DetectionResult leftDetection, DetectionResult rightDetection,
                  Dictionary<string, ElementTree> leftOriginalTree, Dictionary<string, ElementTree> leftModifiedTree, Dictionary<string, ElementTree> rightOriginalTree, Dictionary<string, ElementTree> rightModifiedTree)
        {
            ElementTree missedOriginal, missedModified, divergentOriginal, divergentModified;
            MatchDescriptor divergentMatch;
            switch (way)
            {
                case "LR":
                    //missedOriginal = leftOriginalTree[missedMatch.Original.Id];
                    missedOriginal = leftOriginalTree.ContainsKey(missedMatch.Original.Id)
                        ? leftOriginalTree[missedMatch.Original.Id]
                        : null;
                    //missedModified = leftModifiedTree[missedMatch.Modified.Id];
                    missedModified = leftModifiedTree.ContainsKey(missedMatch.Modified.Id)
                        ? leftModifiedTree[missedMatch.Modified.Id]
                        : null;
                    var lr = new LRMatchSymptom
                    {
                        //Id = Guid.NewGuid(),
                        //IsTop = true,
                        Left = new BetweenMatchInfo
                        {
                            PartName = this.Config.LeftName,
                            Approach = (int)this.Config.Left,
                            Original = missedOriginal != null 
                                ? this.CreateElementContext(missedOriginal)
                                : this.CreateElementContext(missedMatch.Original),
                            Modified = missedModified != null
                                ? this.CreateElementContext(missedModified)
                                : this.CreateElementContext(missedMatch.Modified)
                        }
                    };

                    divergentMatch = this.Config.DivergentMatchForOriginal("LR", missedMatch, leftDetection, rightDetection); 
                    divergentOriginal = divergentMatch != null 
                        ? (rightOriginalTree.ContainsKey(divergentMatch.Original.Id) ? rightOriginalTree[divergentMatch.Original.Id] : null)
                        : null;
                    divergentModified = divergentMatch != null
                        ? (rightModifiedTree.ContainsKey(divergentMatch.Modified.Id) ? rightModifiedTree[divergentMatch.Modified.Id] : null)
                        : null;
                    lr.OriginalAtRight = new BetweenMatchInfo
                    {
                        PartName = this.Config.RightName,
                        Approach = (int)this.Config.Right,
                        Original = divergentOriginal != null
                                ? this.CreateElementContext(divergentOriginal)
                                : this.CreateElementContext(divergentMatch?.Original),
                        Modified = divergentModified != null
                                ? this.CreateElementContext(divergentModified)
                                : this.CreateElementContext(divergentMatch?.Modified)
                    };

                    divergentMatch = this.Config.DivergentMatchForModified("LR", missedMatch, leftDetection, rightDetection);
                    divergentOriginal = divergentMatch != null
                        ? (rightOriginalTree.ContainsKey(divergentMatch.Original.Id) ? rightOriginalTree[divergentMatch.Original.Id] : null)
                        : null;
                    divergentModified = divergentMatch != null
                        ? (rightModifiedTree.ContainsKey(divergentMatch.Modified.Id) ? rightModifiedTree[divergentMatch.Modified.Id] : null)
                        : null;
                    lr.ModifiedAtRight = new BetweenMatchInfo
                    {
                        PartName = this.Config.RightName,
                        Approach = (int)this.Config.Right,
                        Original = divergentOriginal != null
                                ? this.CreateElementContext(divergentOriginal)
                                : this.CreateElementContext(divergentMatch?.Original),
                        Modified = divergentModified != null
                                ? this.CreateElementContext(divergentModified)
                                : this.CreateElementContext(divergentMatch?.Modified)
                    };

                    return lr;
                case "RL":
                    //var r = rightOriginalTree.PostOrder(n => n.Children).OrderBy(n => n.Root.Id).Where(n => int.Parse(n.Root.Id) >= 3261).ToArray();
                    missedOriginal = rightOriginalTree.ContainsKey(missedMatch.Original.Id)
                        ? rightOriginalTree[missedMatch.Original.Id]
                        : null;
                    missedModified = rightModifiedTree.ContainsKey(missedMatch.Modified.Id)
                        ? rightModifiedTree[missedMatch.Modified.Id]
                        : null;
                    var rl = new RLMatchSymptom
                    {
                        //Id = Guid.NewGuid(),
                        //IsTop = true,
                        Right = new BetweenMatchInfo
                        {
                            PartName = this.Config.RightName,
                            Approach = (int)this.Config.Right,
                            Original = missedOriginal != null
                                ? this.CreateElementContext(missedOriginal)
                                : this.CreateElementContext(missedMatch.Original),
                            Modified = missedModified != null
                                ? this.CreateElementContext(missedModified)
                                : this.CreateElementContext(missedMatch.Modified)
                        }
                    };

                    divergentMatch = this.Config.DivergentMatchForOriginal("RL", missedMatch, rightDetection, leftDetection);
                    divergentOriginal = divergentMatch != null
                        ? (leftOriginalTree.ContainsKey(divergentMatch.Original.Id) ? leftOriginalTree[divergentMatch.Original.Id] : null)
                        : null;
                    divergentModified = divergentMatch != null
                        ? (leftModifiedTree.ContainsKey(divergentMatch.Modified.Id) ? leftModifiedTree[divergentMatch.Modified.Id] : null)
                        : null;
                    rl.OriginalAtLeft = new BetweenMatchInfo
                    {
                        PartName = this.Config.LeftName,
                        Approach = (int)this.Config.Left,
                        Original = divergentOriginal != null
                                ? this.CreateElementContext(divergentOriginal)
                                : this.CreateElementContext(divergentMatch?.Original),
                        Modified = divergentModified != null
                                ? this.CreateElementContext(divergentModified)
                                : this.CreateElementContext(divergentMatch?.Modified)
                    };

                    divergentMatch = this.Config.DivergentMatchForModified("RL", missedMatch, rightDetection, leftDetection);
                    divergentOriginal = divergentMatch != null
                        ? (leftOriginalTree.ContainsKey(divergentMatch.Original.Id) ? leftOriginalTree[divergentMatch.Original.Id] : null)
                        : null;
                    divergentModified = divergentMatch != null
                        ? (leftModifiedTree.ContainsKey(divergentMatch.Modified.Id) ? leftModifiedTree[divergentMatch.Modified.Id] : null)
                        : null;
                    rl.ModifiedAtLeft = new BetweenMatchInfo
                    {
                        PartName = this.Config.LeftName,
                        Approach = (int)this.Config.Left,
                        Original = divergentOriginal != null
                                ? this.CreateElementContext(divergentOriginal)
                                : this.CreateElementContext(divergentMatch?.Original),
                        Modified = divergentModified != null
                                ? this.CreateElementContext(divergentModified)
                                : this.CreateElementContext(divergentMatch?.Modified)
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
                //ScopeHint = missedOriginal == null ? null : this.GetPath(missedOriginal.Ancestors())
            };
        }

        private ElementContext CreateElementContext(ElementVersion missedOriginal)
        {
            return new ElementContext
            {
                ScopeHint = $"##FILTEREDOUT?##",
                Element = new ElementDescription
                {
                    Hint = missedOriginal?.Value,
                    Id = missedOriginal?.Id ?? "-1",
                    Type = missedOriginal?.Label ?? ""
                },
                //ScopeHint = missedOriginal == null ? null : this.GetPath(missedOriginal.Ancestors())
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
        /// 
        /// </summary>
        /// <param name="saveChanges"></param>
        /// <param name="pair"></param>
        /// <param name="leftDelta"></param>
        /// <param name="rightDelta"></param>
        /// <param name="token"></param>
        protected override void RecognizeCore(bool saveChanges, FileRevisionPair pair, Delta leftDelta, Delta rightDelta, CancellationToken token)
        {
            var deltaComparison = this.SqlRepository.DeltaComparisonSet
                .SingleOrDefault(dc => dc.LeftId == leftDelta.Id && dc.RightId == rightDelta.Id);

            if (deltaComparison != null)
                deltaComparison.Matching = null;

            var symptoms = this.Compare(leftDelta, rightDelta, pair, token).ToList();
            if (symptoms.Any())
            {
                //var deltaComparison = this.SqlRepository.DeltaComparisonSet.SingleOrDefault(dc => dc.LeftId == leftDelta.Id && dc.RightId == rightDelta.Id);
                if (deltaComparison == null)
                {
                    deltaComparison = this.SqlRepository.DeltaComparisonSet.Create();
                    deltaComparison.LeftId = leftDelta.Id;
                    deltaComparison.RightId = rightDelta.Id;
                    this.SqlRepository.DeltaComparisonSet.Add(deltaComparison);
                }

                var xMatching = new DeltaComparison.XMatchingComparison
                {
                    Matching = symptoms
                };
                deltaComparison.XMatching = xMatching;
            }
            else
            {
                if(deltaComparison != null)
                    this.SqlRepository.DeltaComparisonSet.Remove(deltaComparison);
            }
        }

        /// <summary>
        /// Looks for symptoms of imprecision.
        /// </summary>
        /// <param name="skipThese">local criterion for determining elements that should be ignored.</param>
        /// <param name="saveChanges">Enables or disables the persistence of the changes.</param>
        public override void Recognize(Func<FileRevisionPair, bool> skipThese = null, bool saveChanges = true)
        {
            this.Recognize(this.Config, skipThese, saveChanges);
        }

        //public virtual void ConnectMatchSymptoms(Func<FileRevisionPair, bool> skipThese = null, bool saveChanges = true)
        //{
        //    this.Analyze(f => f.Principal.Deltas.Any(d => d.Approach == this.Config.Left &&
        //                                                     d.Matching != null &&
        //                                                     d.Differencing != null &&
        //                                                     d.Report == null && (d.Symptoms.OfType<LRMatchSymptom>().Any() || d.Symptoms.OfType<RLMatchSymptom>().Any())) &&
        //                         f.Principal.Deltas.Any(d => d.Approach == this.Config.Right &&
        //                                                     d.Matching != null &&
        //                                                     d.Differencing != null &&
        //                                                     d.Report == null),
        //       delegate (FileRevisionPair pair, CancellationToken token)
        //       {
        //           if (skipThese?.Invoke(pair) ?? false) return;
        //           var leftDelta = this.SqlRepository.Deltas.Single(d => d.RevisionPair.Id == pair.Principal.Id && d.Approach == this.Config.Left);
        //           var rightDelta = this.SqlRepository.Deltas.Single(d => d.RevisionPair.Id == pair.Principal.Id && d.Approach == this.Config.Right);

        //           try
        //           {
        //               ConnectMatchSymptoms(leftDelta, rightDelta, pair);
        //           }
        //           catch (OperationCanceledException)
        //           {
        //               this.Report.AppendLine($"CANCELED;{pair.Id}");
        //               throw;
        //           }
        //           catch (OutOfMemoryException)
        //           {
        //               this.Report.AppendLine($"OUTOFMEMORY;{pair.Id}");
        //               throw;
        //           }
        //       }, saveChanges, "Principal" /*"Principal.FileVersion.Content", "Principal.FromFileVersion.Content"*/);
        //}

        //private void ConnectMatchSymptoms(Delta leftDelta, Delta rightDelta, FileRevisionPair pair)
        //{
        //    //var lDelta = this.Config.LeftDeltaContainer(leftDelta, pair);
        //    var leftOriginalTree = this.Config.GetTree((leftDelta, pair, true));
        //    //var leftModifiedTree = ElementTree.Read(leftDelta.ModifiedTree, Encoding.Unicode);
        //    //var leftDetectionResult = (DetectionResult)leftDelta.DetectionResult;

        //    //var rDelta = this.Config.RightDeltaContainer(rightDelta, pair);
        //    var rightOriginalTree = this.Config.GetTree((rightDelta, pair, true));
        //    //var rightModifiedTree = ElementTree.Read(rightDelta.ModifiedTree, Encoding.Unicode);
        //    //var rightDetectionResult = (DetectionResult)rightDelta.DetectionResult;

        //    if (this.Config.Matches)
        //    {
        //        var lApproach = (int)this.Config.Left;
        //        var rApproach = (int)this.Config.Right;
        //        var lrMatchSymptoms = this.SqlRepository.Symptoms.OfType<LRMatchSymptom>().Where(s => s.Delta.Id == leftDelta.Id && 
        //                              (s.Left.Approach == lApproach && s.OriginalAtRight.Approach == rApproach && s.ModifiedAtRight.Approach == rApproach))
        //                              .ToList();
        //        var leftBfs = leftOriginalTree.BreadthFirstOrder(e => e.Children).Reverse().ToList();
        //        foreach (var item in leftBfs)
        //        {
        //            var lrMatches = lrMatchSymptoms.Where(lr => lr.Left.Original.Element.Id == item.Root.Id).ToList();
        //            if (!lrMatches.Any()) continue;
        //            if (lrMatches.Count > 1)
        //                ;

        //            foreach (var lrMatch in lrMatches)
        //            {
        //                bool fullSubtree = true;
        //                foreach (var child in item.Children)
        //                {
        //                    var lrChildMatches = lrMatchSymptoms.Where(lr => lr.Left.Original.Element.Id == child.Root.Id).ToList();
        //                    fullSubtree &= lrChildMatches.Any();
        //                    foreach (var lrChildMatch in lrChildMatches)
        //                    {
        //                        lrMatch.Symptoms.Add(lrChildMatch);
        //                    }
        //                }
        //                if (fullSubtree)
        //                    lrMatch.Notes = lrMatch.Notes == null
        //                     ? (SymptomNotes.Full | SymptomNotes.SubTree)
        //                     : lrMatch.Notes | SymptomNotes.Full | SymptomNotes.SubTree;
        //            }
        //        }

        //        if (this.Config.TwoWay)
        //        {
        //            var rlMatchSymptoms = this.SqlRepository.Symptoms.OfType<RLMatchSymptom>().Where(s => s.Delta.Id == leftDelta.Id &&
        //                                  (s.Right.Approach == rApproach && s.OriginalAtLeft.Approach == lApproach && s.ModifiedAtLeft.Approach == lApproach))
        //                                  .ToList();
        //            var rightBfs = rightOriginalTree.BreadthFirstOrder(e => e.Children).Reverse().ToList();
        //            foreach (var item in rightBfs)
        //            {
        //                var rlMatches = rlMatchSymptoms.Where(rl => rl.Right.Original.Element.Id == item.Root.Id).ToList();
        //                if (!rlMatches.Any()) continue;
        //                if (rlMatches.Count > 1)
        //                    ;

        //                foreach (var rlMatch in rlMatches)
        //                {
        //                    bool fullSubtree = true;
        //                    foreach (var child in item.Children)
        //                    {
        //                        var rlChildMatches = rlMatchSymptoms.Where(rl => rl.Right.Original.Element.Id == child.Root.Id).ToList();
        //                        fullSubtree &= rlChildMatches.Any();
        //                        foreach (var rlChildMatch in rlChildMatches)
        //                        {
        //                            rlMatch.Symptoms.Add(rlChildMatch);
        //                        }
        //                    }
        //                    if (fullSubtree)
        //                        rlMatch.Notes = rlMatch.Notes == null
        //                         ? (SymptomNotes.Full | SymptomNotes.SubTree)
        //                         : rlMatch.Notes | SymptomNotes.Full | SymptomNotes.SubTree;
        //                }
        //            }
        //        }
        //    }

        //    //if (this.Config.Actions)
        //    //{
        //    //    //foreach (var leftAction in leftDetectionResult.Actions)
        //    //    //{
        //    //    //    if (!rightDetectionResult.Actions.Any(
        //    //    //            rightAction =>
        //    //    //                this.Config.ActionCompare(leftAction, leftDetectionResult, rightAction, rightDetectionResult)))
        //    //    //    {
        //    //    //        //yield return new BetweenSymptom
        //    //    //        //{
        //    //    //        //    Id = Guid.NewGuid(),
        //    //    //        //    Pattern = $"{way}-Actions",
        //    //    //        //    Left = this.CreateBetweenPartInfo(this.Config.LeftName, Enum.GetName(typeof(ActionKind), leftAction.Action), 
        //    //    //        //                leftDetectionResult, leftOriginalTree, leftModifiedTree, leftAction),
        //    //    //        //    Right = this.CreateBetweenPartInfo(this.Config.RightName, "", null, null)
        //    //    //        //    //Right = this.CreateBetweenPartInfo(this.Config.RightName, rightDetectionResult,
        //    //    //        //    //    rightOriginalTree, rightModifiedTree, null)
        //    //    //        //};
        //    //    //    }
        //    //    //}
        //    //}
        //}

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
        /// Reports the totals of between match symptoms, as well their percentages in relation to the project corpus.
        /// </summary>
        /// <returns>numbers discriminating among LR-matches and RL-matches, and also the total of matches.</returns>
        public virtual (string Project, int TotalOfFileRevisionPairs, (int LR, int RL, int All) TotalOfSymptoms, (int LR, int RL, int All) TotalOfAffectedFileRevisionPairs, (double LR, double RL, double All) PercentageOfAffectedFileRevisionPairs) ReportBetweenMatches()
        {
            var fileRevisionPairs = ComparisonQuery().ToList();

            var totalOfFrps = fileRevisionPairs.Count;
            var affectedFrps = fileRevisionPairs.Where(frp => frp.LrDisagreementMatches > 0 || frp.RlDisagreementMatches > 0).ToList();

            var totalOfLrSymptoms = affectedFrps.Sum(d => d.LrDisagreementMatches);
            var totalOfRlSymptoms = affectedFrps.Sum(d => d.RlDisagreementMatches);

            var totalOfLrAffectedFrps = affectedFrps.Count(frp => frp.LrDisagreementMatches > 0);
            var totalOfRlAffectedFrps = affectedFrps.Count(frp => frp.RlDisagreementMatches > 0);
            var totalOfAffectedFrps = affectedFrps.Count;

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
        public virtual void ReportData(bool writeHeader = true)
        {
            var fileRevisionPairs = ComparisonQuery().ToList();
            var affectedFrps = fileRevisionPairs.Where(frp => frp.LrDisagreementMatches > 0 || frp.RlDisagreementMatches > 0);

            if (writeHeader)
                this.Report.AppendLine($"Project;Id;LrDisagreementMatches;RlDisagreementMatches");

            foreach (var frp in affectedFrps)
            {
                this.Report.AppendLine($"{this.SqlRepository.Name};{frp.Id};{frp.LrDisagreementMatches};{frp.RlDisagreementMatches}");
            }
        }

        private IEnumerable<(Guid Id, int LrDisagreementMatches, int RlDisagreementMatches)> ComparisonQuery()
        {
            var query = from f in this.SqlRepository.FileRevisionPairs.AsNoTracking()
                        where f.Principal.Deltas.Any(d => d.Approach == this.Config.Left && d.Matching != null && d.Matching != "<Matches />" && d.Differencing != null && d.Differencing != "<Actions />" && d.Report == null) &&
                              f.Principal.Deltas.Any(d => d.Approach == this.Config.Right && d.Matching != null && d.Matching != "<Matches />" && d.Differencing != null && d.Differencing != "<Actions />" && d.Report == null)
                        let fd = (from d in f.Principal.Deltas where d.Approach == this.Config.Left && d.Matching != null && d.Differencing != null && d.Report == null select d).FirstOrDefault()
                        let rd = (from d in f.Principal.Deltas where d.Approach == this.Config.Right && d.Matching != null && d.Differencing != null && d.Report == null select d).FirstOrDefault()
                        select new
                        {
                            f.Id,
                            LrDisagreementMatches = fd.Symptoms.OfType<LRMatchSymptom>().Count(lr => lr.Left.Approach == (int)this.Config.Left &&
                                                                                                     lr.OriginalAtRight.Approach == (int)this.Config.Right &&
                                                                                                     lr.ModifiedAtRight.Approach == (int)this.Config.Right),
                            RlDisagreementMatches = fd.Symptoms.OfType<RLMatchSymptom>().Count(rl => rl.Right.Approach == (int)this.Config.Right &&
                                                                                                     rl.OriginalAtLeft.Approach == (int)this.Config.Left &&
                                                                                                     rl.ModifiedAtLeft.Approach == (int)this.Config.Left)
                        };

            foreach (var element in query)
            {
                yield return (element.Id, element.LrDisagreementMatches, element.RlDisagreementMatches);
            }
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
        protected new void ConfigGumTreeVsReversedGumTree<T>(T criterion) where T : BetweenComparisonCriterion, new()
        {
            base.ConfigGumTreeVsReversedGumTree(criterion);

            criterion.MatchCompare = (s, leftMatch, leftDelta, rightMatch, rightDelta) =>
                    leftMatch.Original.Id == rightMatch.Modified.Id &&
                    leftMatch.Modified.Id == rightMatch.Original.Id;

            criterion.ActionCompare = delegate (string s, ActionDescriptor leftAction, DetectionResult leftDelta, ActionDescriptor rightAction, DetectionResult rightDelta)
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
            };

            criterion.DivergentMatchForOriginal = (s, missedMatch, leftDetection, rightDetection) => rightDetection.Matches.FirstOrDefault(m => missedMatch.Original.Id == m.Modified.Id);
            criterion.DivergentMatchForModified = (s, missedMatch, leftDetection, rightDetection) => rightDetection.Matches.FirstOrDefault(m => missedMatch.Modified.Id == m.Original.Id);
        }

        /// <summary>
        /// Returns a configuration to check for reversible changes.
        /// </summary>
        public virtual void ConfigGumTreeVsReversedGumTree()
        {
            this.Config = new BetweenComparisonCriterion();
            this.ConfigGumTreeVsReversedGumTree<BetweenComparisonCriterion>(this.Config);
        }

        /// <summary>
        /// Returns a configuration to check for reversible changes.
        /// </summary>
        /// <param name="leftName"></param>
        /// <param name="leftApproach"></param>
        /// <param name="rightApproach"></param>
        /// <param name="rightName"></param>
        public virtual void ConfigForwardVsBackward((ChangeDetectionApproaches Approach, string Name) forward, (ChangeDetectionApproaches Approach, string Name) backward)
        {
            this.Config = new BetweenComparisonCriterion
            {
                Left = forward.Approach,
                LeftName = forward.Name,
                Right = backward.Approach,
                RightName = backward.Name,
                TwoWay = true,
                MatchCompare = (s, leftMatch, leftDelta, rightMatch, rightDelta) => leftMatch.Original.Id == rightMatch.Modified.Id && leftMatch.Modified.Id == rightMatch.Original.Id,

                ActionCompare = delegate (string s , ActionDescriptor leftAction, DetectionResult leftDelta, ActionDescriptor rightAction, DetectionResult rightDelta)
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

                DivergentMatchForOriginal = (s, missedMatch, leftDetection, rightDetection) => rightDetection.Matches.FirstOrDefault(m => missedMatch.Original.Id == m.Modified.Id),
                DivergentMatchForModified = (s, missedMatch, leftDetection, rightDetection) => rightDetection.Matches.FirstOrDefault(m => missedMatch.Modified.Id == m.Original.Id)
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
            this.Config = new BetweenComparisonCriterion
            {
                Left = left.Approach,
                LeftName = left.Name,
                Right = right.Approach,
                RightName = right.Name,
                TwoWay = true,
                MatchCompare = (s, leftMatch, leftDelta, rightMatch, rightDelta) => leftMatch.Original.Id == rightMatch.Original.Id && leftMatch.Modified.Id == rightMatch.Modified.Id,
                ActionCompare = delegate (string s, ActionDescriptor leftAction, DetectionResult leftDelta, ActionDescriptor rightAction, DetectionResult rightDelta)
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
                DivergentMatchForOriginal = (s, missedMatch, leftDetection, rightDetection) => rightDetection.Matches.FirstOrDefault(m => missedMatch.Original.Id == m.Original.Id),
                DivergentMatchForModified = (s, missedMatch, leftDetection, rightDetection) => rightDetection.Matches.FirstOrDefault(m => missedMatch.Modified.Id == m.Modified.Id),
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
        public class BetweenComparisonCriterion : ImprecisionComparisonCriterion
        {
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
            public Func<string, MatchDescriptor, DetectionResult, MatchDescriptor, DetectionResult, bool> MatchCompare { get; set; }

            /// <summary>
            /// Gets or sets how to: given a match supposely not detected, know how its original was otherwise matched.
            /// </summary>
            public Func<string, MatchDescriptor, DetectionResult, DetectionResult, MatchDescriptor> DivergentMatchForOriginal { get; set; }

            /// <summary>
            /// Gets or sets how to: given a match supposely not detected, know how its modified was otherwise matched.
            /// </summary>
            public Func<string, MatchDescriptor, DetectionResult, DetectionResult, MatchDescriptor> DivergentMatchForModified { get; set; }

            /// <summary>
            /// Gets or sets how to compare two detection results.
            /// </summary>
            public Func<string, ActionDescriptor, DetectionResult, ActionDescriptor, DetectionResult, bool> ActionCompare { get; set; }

            /// <summary>
            /// Gets or sets how to compare two detection results.
            /// </summary>
            public Action<ElementTree, ElementTree, DetectionResult, bool> Align { get; set; }

            ///// <summary>
            ///// Gets or sets the delta from which to take the left ASTs (original and modified).
            ///// </summary>
            //public virtual Func<Delta, FileRevisionPair, Delta> LeftDeltaContainer { get; set; } = (d, frp) => d;

            ///// <summary>
            ///// Gets or sets the delta from which to take the right ASTs (original and modified).
            ///// </summary>
            //public virtual Func<Delta, FileRevisionPair, Delta> RightDeltaContainer { get; set; } = (d, frp) => d;
        }
    }
}