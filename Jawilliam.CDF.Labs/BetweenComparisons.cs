using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Jawilliam.CDF.Actions;
using Jawilliam.CDF.Approach;
using Jawilliam.CDF.Approach.GumTree;
using Microsoft.CodeAnalysis.CSharp;

namespace Jawilliam.CDF.Labs
{
    public class BetweenComparisons : ImprecisionDiagnostic<MissedElement>
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
        /// <param name="token">mechanism for cancelling the analisys.</param>
        protected virtual IEnumerable<BetweenSymptom> Compare(Delta leftDelta, Delta rightDelta, CancellationToken token)
        {
            var leftOriginalTree = ElementTree.Read(leftDelta.OriginalTree, Encoding.Unicode);
            var leftModifiedTree = ElementTree.Read(leftDelta.ModifiedTree, Encoding.Unicode);
            var leftDetectionResult = (DetectionResult)leftDelta.DetectionResult;

            var rightOriginalTree = ElementTree.Read(rightDelta.OriginalTree, Encoding.Unicode);
            var rightModifiedTree = ElementTree.Read(rightDelta.ModifiedTree, Encoding.Unicode);
            var rightDetectionResult = (DetectionResult)rightDelta.DetectionResult;

            var symptoms = this.BetweenSymptoms(leftDetectionResult, rightDetectionResult,
                leftOriginalTree, leftModifiedTree, rightOriginalTree, rightModifiedTree, "LR");
            foreach (var betweenSymptom in symptoms)
                yield return betweenSymptom;

            if (this.Config.TwoWay)
            {
                symptoms = this.BetweenSymptoms(rightDetectionResult, leftDetectionResult,
                    rightOriginalTree, rightModifiedTree, leftOriginalTree, leftModifiedTree, "RL");
                foreach (var betweenSymptom in symptoms)
                    yield return betweenSymptom;
            }
        }

        private IEnumerable<BetweenSymptom> BetweenSymptoms(DetectionResult leftDetectionResult,
            DetectionResult rightDetectionResult, ElementTree leftOriginalTree, ElementTree leftModifiedTree,
            ElementTree rightOriginalTree, ElementTree rightModifiedTree, string way)
        {
            foreach (var leftMatch in leftDetectionResult.Matches)
            {
                if (!rightDetectionResult.Matches.Any(
                        rightMatch =>
                            this.Config.MatchCompare(leftMatch, leftDetectionResult, rightMatch, rightDetectionResult)))
                {
                    var leftOriginal = leftOriginalTree.PostOrder(n => n.Children).First(n => n.Root.Id == leftMatch.Original.Id);
                    var leftModified = leftModifiedTree.PostOrder(n => n.Children).First(n => n.Root.Id == leftMatch.Modified.Id);
                    //var rightOriginal = rightOriginalTree.PostOrder(n => n.Children).First(n => n.Root.Id == rightMatch.Original.Id);
                    //var rightModified = rightModifiedTree.PostOrder(n => n.Children).First(n => n.Root.Id == rightMatch.Modified.Id);
                    yield return new BetweenSymptom
                    {
                        Id = Guid.NewGuid(),
                        Pattern = $"{way}-Matches",
                        Left = this.CreateBetweenPartInfo(this.Config.LeftName, "match", leftOriginal, leftModified),
                        Right = this.CreateBetweenPartInfo(this.Config.RightName, "match", null, null)
                    };
                }
            }

            foreach (var leftAction in leftDetectionResult.Actions)
            {
                if (!rightDetectionResult.Actions.Any(
                        rightAction => 
                            this.Config.ActionCompare(leftAction, leftDetectionResult, rightAction, rightDetectionResult)))
                {
                    yield return new BetweenSymptom
                    {
                        Id = Guid.NewGuid(),
                        Pattern = $"{way}-Actions",
                        Left = this.CreateBetweenPartInfo(this.Config.LeftName, Enum.GetName(typeof(ActionKind), leftAction.Action), 
                                    leftDetectionResult, leftOriginalTree, leftModifiedTree, leftAction),
                        Right = this.CreateBetweenPartInfo(this.Config.RightName, "", null, null)
                        //Right = this.CreateBetweenPartInfo(this.Config.RightName, rightDetectionResult,
                        //    rightOriginalTree, rightModifiedTree, null)
                    };
                }
            }
        }

        private BetweenPartInfo CreateBetweenPartInfo(string partName, string operation,
            DetectionResult detectionResult, ElementTree originalTree,
            ElementTree modifiedTree, ActionDescriptor action)
        {
            ElementTree originalOrParent, modifiedOrElement;
            switch (action.Action)
            {
                case ActionKind.Update:
                    var update = (UpdateOperationDescriptor)action;
                    var match = detectionResult.Matches.Single(m => m.Original.Id == update.Element.Id);
                    originalOrParent = originalTree.PostOrder(n => n.Children)
                        .First(n => n.Root.Id == match.Original.Id);
                    modifiedOrElement = modifiedTree.PostOrder(n => n.Children)
                        .First(n => n.Root.Id == match.Modified.Id);
                    break;
                case ActionKind.Insert:
                    var insert = (InsertOperationDescriptor)action;
                    originalOrParent = originalTree.PostOrder(n => n.Children)
                        .FirstOrDefault(n => n.Root.Id == insert.Parent.Id);
                    modifiedOrElement = modifiedTree.PostOrder(n => n.Children)
                        .First(n => n.Root.Id == insert.Element.Id);
                    break;
                case ActionKind.Delete:
                    var delete = (DeleteOperationDescriptor)action;
                    modifiedOrElement = originalTree.PostOrder(n => n.Children)
                        .First(n => n.Root.Id == delete.Element.Id);
                    originalOrParent = originalTree.PostOrder(n => n.Children)
                        .First(n => n.Root.Id == modifiedOrElement.Parent.Root.Id);
                    break;
                case ActionKind.Move:
                    var move = (MoveOperationDescriptor)action;
                    originalOrParent = originalTree.PostOrder(n => n.Children)
                        .FirstOrDefault(n => n.Root.Id == move.Parent.Id);
                    modifiedOrElement = originalTree.PostOrder(n => n.Children)
                        .First(n => n.Root.Id == move.Element.Id);
                    break;
                //case ActionKind.Align:
                //    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return this.CreateBetweenPartInfo(partName, operation, originalOrParent, modifiedOrElement);
        }

        private BetweenPartInfo CreateBetweenPartInfo(string partName, string operation, ElementTree original, ElementTree modified)
        {
            return new BetweenPartInfo
            {
                PartName = partName,
                Operation = operation,
                Parent4IDU_Original4U = new ElementContext
                {
                    Element = new ElementDescription 
                    {
                        Hint = original?.Root.Value,
                        Id = original?.Root.Id ?? "-1",
                        Type = original?.Root.Label
                    },
                    ScopeHint = original == null ? null : this.GetPath(original.Ancestors())
                },
                Element4IDM_Modified4U = new ElementContext
                {
                    Element = new ElementDescription
                    {
                        Hint = modified?.Root.Value,
                        Id = modified?.Root.Id ?? "-1",
                        Type = modified?.Root.Label
                    },
                    ScopeHint = modified == null ? null : this.GetPath(modified.Ancestors())
                }
            };
        }

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
                    var symptoms = this.Compare(leftDelta, rightDelta, token).ToList();
                    if (symptoms.Count > 0)
                        this.Rate(pair);
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
            }, saveChanges, /*"Principal"*/ "Principal.FileVersion.Content", "Principal.FromFileVersion.Content");
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
                }
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
            /// Gets or sets how to compare two matches.
            /// </summary>
            public Func<RevisionDescriptor, DetectionResult, RevisionDescriptor, DetectionResult, bool> MatchCompare { get; set; }

            /// <summary>
            /// Gets or sets how to compare two actions.
            /// </summary>
            public Func<ActionDescriptor, DetectionResult, ActionDescriptor, DetectionResult, bool> ActionCompare { get; set; }
        }
    }
}