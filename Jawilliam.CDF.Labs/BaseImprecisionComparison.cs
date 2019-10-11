using Jawilliam.CDF.Labs.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Jawilliam.CDF.Labs
{
    /// <summary>
    /// Base logic for the imprecision diagnostic by comparing two solutions.
    /// </summary>
    /// <typeparam name="TSymptom">type of the recognized symptoms.</typeparam>
    public abstract class BaseImprecisionComparison<TSymptom> : ImprecisionDiagnostic<TSymptom>
    {
        ///// <summary>
        ///// Looks for symptoms of imprecision.
        ///// </summary>
        ///// <param name="leftDelta">left delta.</param> 
        ///// <param name="rightDelta">right delta.</param>
        ///// <param name="pair">file revision pair being analized.</param>
        ///// <param name="token">mechanism for cancelling the analisys.</param>
        //public abstract IEnumerable<TSymptom> Compare(Delta leftDelta, Delta rightDelta, FileRevisionPair pair, CancellationToken token);

        /// <summary>
        /// Looks for symptoms of imprecision.
        /// </summary>
        /// <param name="skipThese">local criterion for determining elements that should be ignored.</param>
        /// <param name="saveChanges">Enables or disables the persistence of the changes.</param>
        protected virtual void Recognize(ImprecisionComparisonCriterion criterion, Func<FileRevisionPair, bool> skipThese, bool saveChanges = true)
        {
            this.Analyze(f => f.Principal.Deltas.Any(d => d.Approach == criterion.Left &&
                                                          d.Matching != null &&
                                                          d.Differencing != null &&
                                                          d.Report == null) &&
                              f.Principal.Deltas.Any(d => d.Approach == criterion.Right &&
                                                          d.Matching != null &&
                                                          d.Differencing != null &&
                                                          d.Report == null),
            delegate (FileRevisionPair pair, CancellationToken token)
            {
                if (skipThese?.Invoke(pair) ?? false) return;
                var leftDelta = this.SqlRepository.Deltas.Single(d => d.RevisionPair.Id == pair.Principal.Id && d.Approach == criterion.Left);
                var rightDelta = this.SqlRepository.Deltas.Single(d => d.RevisionPair.Id == pair.Principal.Id && d.Approach == criterion.Right);

                if (!leftDelta.Differencing.Any() || !rightDelta.Differencing.Any())
                    return;

                try
                {
                    RecognizeCore(saveChanges, pair, leftDelta, rightDelta, token);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="saveChanges"></param>
        /// <param name="pair"></param>
        /// <param name="leftDelta"></param>
        /// <param name="rightDelta"></param>
        /// <param name="token"></param>
        protected abstract void RecognizeCore(bool saveChanges, FileRevisionPair pair, Delta leftDelta, Delta rightDelta, CancellationToken token);

        ///// <summary>
        ///// Gets imprecision symptoms.
        ///// </summary>
        //public abstract IEnumerable<TSymptom> Symptoms { get; }

        /// <summary>
        /// Returns a configuration to check for reversible changes.
        /// </summary>
        protected virtual void ConfigGumTreeVsReversedGumTree<T>(T criterion) where T: ImprecisionComparisonCriterion, new()
        {
            criterion.Left = ChangeDetectionApproaches.NativeGumTree;
            criterion.LeftName = "GumTree";
            criterion.Right = ChangeDetectionApproaches.InverseOfNativeGumTree;
            criterion.RightName = "ReversedGumTree";
            criterion.TwoWay = true;
        }
    }

    /// <summary>
    /// Implements placeholders to configure the between comparison.
    /// </summary>
    public class ImprecisionComparisonCriterion
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
        /// Gets or sets the how to get the original (or modified) tree of the left (or right) comparing delta.
        /// </summary>
        public virtual Func<(Delta Delta, FileRevisionPair Pair, bool TrueForOriginalOtherwiseModified), ElementTree> GetTree { get; set; }
            = (a) => a.TrueForOriginalOtherwiseModified
            ? ElementTree.Read(a.Delta.OriginalTree, Encoding.Unicode)
            : ElementTree.Read(a.Delta.ModifiedTree, Encoding.Unicode);
    }
}