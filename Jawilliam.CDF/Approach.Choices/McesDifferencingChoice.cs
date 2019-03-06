using Jawilliam.CDF.Approach.Annotations;
using Jawilliam.CDF.Approach.Impl;
using Jawilliam.CDF.Approach.Services;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Jawilliam.CDF.Approach.Choices
{
    /// <summary>
    /// Implements a differencing computing according to the Minimum Conforming Edit Script of Chawathe et al.
    /// </summary>
    /// <typeparam name="TElement">Type of the supported elements.</typeparam>
    /// <typeparam name="TAnnotation">Type of the information to store for each element.</typeparam>
    public class McesDifferencingChoice<TElement, TAnnotation> : Choice<TElement> where TAnnotation : IElementAnnotation<TElement>, IMatchingAnnotation<TElement>, IMcesAnnotation<TElement>, new()
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="approach">the solution wherein the current choice will be called</param>
        /// <param name="criterion">the matching criterion.</param>
        public McesDifferencingChoice(IApproach<TElement> approach) : base(approach)
        {
        }

        /// <summary>
        /// Gets the steps wherein the current choice will be actively executed.
        /// </summary>
        protected override IList<long> SupportedSteps => new List<long>
        {
            (long)(StepInfo.DifferencingPhase | StepInfo.Subtree)
        };

        internal bool LCSEqual(TElement original, TElement modified)
        {
            return object.Equals(this.Approach.Original<TElement, TAnnotation>(original).Partner, modified) && modified != null;
        }

        /// <summary>
        /// Computes a longest common subsequence among two sequences. 
        /// </summary>
        /// <param name="originals">sequence of original elements.</param>
        /// <param name="modifieds">sequence of modified elements.</param>
        /// <returns>the longest common subsequence among th given sequences.</returns>
        /// <remarks>Default implementation returns the output of <see cref="MyersLCS{TSymbol}"/>.</remarks>
        protected virtual IEnumerable<MyersLCS<TElement>.Command> LCS(IEnumerable<TElement> originals, IEnumerable<TElement> modifieds)
        {
            var lcs = new MyersLCS<TElement> { Equal = this.LCSEqual };
            return lcs.Run(originals, modifieds);
        }

        /// <summary>
        /// The initial matching set.
        /// </summary>
        protected List<(TElement Original, TElement Modified)> PartialMatchingSet;

        /// <summary>
        /// Core implementation of <see cref="OnStep"/>.
        /// </summary>
        /// <remarks>By default, it implements a customizable MTDiff's "IdenticalSubtree" optimization.</remarks>
        protected override void CoreOnStep()
        {
            var editScript = this.Approach.EditScript();
            try
            {
                editScript.Begin();
                var matchingSet = this.Approach.MatchingSet();

                this.PartialMatchingSet = this.Approach.Originals<TElement, TAnnotation>().Annotations.Values
                    .Where(o => !matchingSet.UnmatchedOriginal(o.Element))
                    .Select(o => (Original: o.Element, Modified: o.Partner))
                    .ToList();

                foreach (var modified in this.Approach.Result.Modified.BreadthFirstOrder(editScript.ModifiedsHierarchicalAbstraction.Children))
                {
                    var mAnnotation = this.Approach.Modified<TElement, TAnnotation>(modified);
                    if (matchingSet.UnmatchedModified(modified)) // x has not partner in M
                    {
                        var kPosition = this.FindPosition(modified);
                        var mParent = this.Approach.Modified<TElement, TAnnotation>(editScript.ModifiedsHierarchicalAbstraction.Parent(modified)).Partner;
                        editScript.Insert(modified, kPosition, mParent);

                        var oAnnotation = this.Approach.Original<TElement, TAnnotation>(mAnnotation.Partner);
                        Debug.Assert(mAnnotation.Partner != null);
                        Debug.Assert(oAnnotation != null);
                        oAnnotation.InOrder = true;
                        mAnnotation.InOrder = true;
                    }
                    else
                    {
                        var modifiedParent = editScript.ModifiedsHierarchicalAbstraction.Parent(modified);
                        if (modifiedParent != null) // x is not the root
                        {
                            var original = mAnnotation.Partner;
                            var originalValue = editScript.OriginalsHierarchicalAbstraction.Value(original);
                            var modifiedValue = editScript.ModifiedsHierarchicalAbstraction.Value(modified);

                            if (!object.Equals(originalValue != null ? this.RemoveControlAndWhitespaceChars(originalValue.ToString()) : null,
                                               modifiedValue != null ? this.RemoveControlAndWhitespaceChars(modifiedValue.ToString()) : null)) // v(x) != v(y)
                            {
                                editScript.Update(original, modified);
                            }

                            if (!object.Equals(this.Approach.Original<TElement, TAnnotation>(editScript.OriginalsHierarchicalAbstraction.Parent(original)).Partner, modifiedParent)) // <p(x),p(y)> doesn't belong to M
                            {
                                var kPosition = this.FindPosition(modified);
                                editScript.Move(original, kPosition, this.Approach.Modified<TElement, TAnnotation>(modifiedParent).Partner);

                                var oAnnotation = this.Approach.Original<TElement, TAnnotation>(original);
                                oAnnotation.InOrder = true;
                                mAnnotation.InOrder = true;
                            }
                        }
                    }
                    this.AlignChildren(mAnnotation.Partner, modified);
                }

                foreach (var original in this.Approach.Result.Original.PostOrder(editScript.OriginalsHierarchicalAbstraction.Children).Where(matchingSet.UnmatchedOriginal).ToList())
                {
                    editScript.Delete(original);
                }
            }
            finally
            {
                editScript.End();
            }
        }

        private string RemoveControlAndWhitespaceChars(string source)
        {
            var sb = new StringBuilder(source.Length);
            foreach (var c in source.ToArray().Where(c => !char.IsControl(c) && !char.IsWhiteSpace(c)))
            {
                sb.Append(c);
            }

            return sb.ToString();
        }

        /// <summary>
        /// Aligns the children of <paramref name="originalParent"/> with the children of <paramref name="modifiedParent"/>.
        /// </summary>
        /// <param name="originalParent">the previous version of the <paramref name="modifiedParent"/> parent.</param>
        /// <param name="modifiedParent">the next version of the <paramref name="originalParent"/> parent.</param>
        private void AlignChildren(TElement originalParent, TElement modifiedParent)
        {
            var editScript = this.Approach.EditScript();

            // mark all children of w and of x as "out of order".
            var originalChildren = editScript.OriginalsHierarchicalAbstraction.Children(originalParent).ToList();
            foreach (var child in originalChildren)
            {
                this.Approach.Original<TElement, TAnnotation>(child).InOrder = false;
            }

            // mark all children of w and of x as "out of order".
            var modifiedChildren = editScript.ModifiedsHierarchicalAbstraction.Children(modifiedParent).ToList();
            foreach (var child in modifiedChildren)
            {
                this.Approach.Modified<TElement, TAnnotation>(child).InOrder = false;
            }

            // let S1 be the sequence of children of w whose partners are children of x.
            var s1 = (from oChild in originalChildren
                      let oChildAnnotation = this.Approach.Original<TElement, TAnnotation>(oChild)
                      where oChildAnnotation.Partner != null && object.Equals(editScript.ModifiedsHierarchicalAbstraction.Parent(oChildAnnotation.Partner), modifiedParent)
                      select oChild).ToList();
            // let S2 be the sequence of children of x whose partners are children of w.
            var s2 = (from mChild in modifiedChildren
                      let mChildAnnotation = this.Approach.Modified<TElement, TAnnotation>(mChild)
                      where mChildAnnotation.Partner != null && object.Equals(editScript.OriginalsHierarchicalAbstraction.Parent(mChildAnnotation.Partner), originalParent)
                      select mChild).ToList();
            var s = (from match in this.LCS(s1, s2)
                     where match.Kind == MyersLCS<TElement>.CommandKind.Match
                     select new { Original = s1[match.AIndex], Modified = s2[match.BIndex] }).ToArray();

            // foreach a,b in S mark nodes a and b "in order".
            foreach (var lcsPair in s)
            {
                this.Approach.Original<TElement, TAnnotation>(lcsPair.Original).InOrder = true;
                this.Approach.Modified<TElement, TAnnotation>(lcsPair.Modified).InOrder = true;
            }

            // foreach a in S1, b in S2 such that a,b in M, but a,b not in S.
            var pairsToMove = from a in s1
                              from b in s2
                              where this.PartialMatchingSet.Any(ms => object.ReferenceEquals(ms.Original, a) && object.ReferenceEquals(ms.Modified, b))
                                    && !s.Any(ms => object.ReferenceEquals(ms.Original, a) && object.ReferenceEquals(ms.Modified, b))
                              select new { a, b };

            foreach (var pairToMove in pairsToMove)
            {
                var kPosition = this.FindPosition(pairToMove.b);
                editScript.Align(pairToMove.a, kPosition);
                this.Approach.Original<TElement, TAnnotation>(pairToMove.a).InOrder = true;
                this.Approach.Modified<TElement, TAnnotation>(pairToMove.b).InOrder = true;
            }
        }

        /// <summary>
        /// Finds the position where to insert or to move a node.
        /// </summary>
        /// <param name="modifiedNode">the next version of the original parent.</param>
        /// <returns>The K position to insert or to move the node.</returns>
        private int FindPosition(TElement modifiedNode)
        {
            var editScript = this.Approach.EditScript();

            // if x is the leftmost child "in order" return 1.
            // Let v the rightmost sibling of x at the left of x and marked "in order".
            var rightMostInOrder = editScript.ModifiedsHierarchicalAbstraction.Children(editScript.ModifiedsHierarchicalAbstraction.Parent(modifiedNode))
                .TakeWhile(t => !object.Equals(t, modifiedNode))
                .LastOrDefault(s => this.Approach.Modified<TElement, TAnnotation>(s).InOrder);
            if (rightMostInOrder == null)
                return 0;

            var partnerOfRightMostInOrder = this.Approach.Modified<TElement, TAnnotation>(rightMostInOrder).Partner;

            // the ith child of the parent of u (from left to right) that is marked "in order".
            return editScript.OriginalsHierarchicalAbstraction.Children(editScript.OriginalsHierarchicalAbstraction.Parent(partnerOfRightMostInOrder))
                .Where(t => this.Approach.Original<TElement, TAnnotation>(t).InOrder).ToList()
                .IndexOf(partnerOfRightMostInOrder) + 1;
        }
    }
}
