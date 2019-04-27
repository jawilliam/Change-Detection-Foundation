using Jawilliam.CDF.Approach.Criterions;
using Jawilliam.CDF.Approach.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Jawilliam.CDF.Approach.Choices
{
    /// <summary>
    /// Base class for implementing matching discovery choices based on a <see cref="IMatcher{TElement}"/>.
    /// </summary>
    /// <typeparam name="TElement">Type of the supported elements.</typeparam>
    public partial class MatchingDiscoveryChoice<TElement> : Choice<TElement>
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="approach">the solution wherein the current choice will be called</param>
        public MatchingDiscoveryChoice(IApproach<TElement> approach) : base(approach)
        {
        }

        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="approach">the solution wherein the current choice will be called</param>
        /// <param name="criterion">the matching criterion.</param>
        public MatchingDiscoveryChoice(IApproach<TElement> approach, IMatcher<TElement> criterion) : base(approach)
        {
            this.Criterion = criterion;
        }

        /// <summary>
        /// Stores the value of <see cref="Criterion"/>.
        /// </summary>
        private IMatcher<TElement> _criterion;

        /// <summary>
        /// Gets the matching criterion.
        /// </summary>
        public IMatcher<TElement> Criterion
        {
            get => this._criterion;
            private set { this._criterion = value ?? throw new ArgumentNullException(nameof(value)); }
        }

        /// <summary>
        /// Stores the value of <see cref="Traverse"/>.
        /// </summary>
        private Func<TElement, IEnumerable<TElement>> _traverse;

        /// <summary>
        /// Gets the strategy to traverse the original AST.
        /// </summary>
        public Func<TElement, IEnumerable<TElement>> Traverse
        {
            get => this._traverse ?? (this._traverse = o => o.BreadthFirstOrder(this.Approach.HierarchicalAbstraction().Children));
            set { this._traverse = value ?? throw new ArgumentNullException(nameof(value)); }
        }

        /// <summary>
        /// Gets the steps wherein the current choice will be actively executed.
        /// </summary>
        protected override IList<long> SupportedSteps => new List<long>
        {
            (long)(StepInfo.Equality | StepInfo.Subtree)
        };

        ///// <summary>
        ///// Core implementation of <see cref="OnStep"/>.
        ///// </summary>
        ///// <remarks>By default, it implements a customizable MTDiff's "IdenticalSubtree" optimization.</remarks>
        //protected override void CoreOnStep()
        //{
        //    this.CoreOnStep(this.Approach.Result.Original, this.Approach.Result.Modified, this.NewList());
        //}

        /// <summary>
        /// Core implementation of <see cref="OnStep"/>.
        /// </summary>
        /// <remarks>By default, it implements a customizable MTDiff's "IdenticalSubtree" optimization.</remarks>
        protected override void CoreOnStep()
        {
            this.CoreOnStep(this.Approach.Result.Original, this.Approach.Result.Modified);
        }

        /// <summary>
        /// Core implementation of <see cref="OnStep"/>.
        /// </summary>
        /// <param name="originalRoot">the original root.</param>
        /// <param name="modifiedRoot">the modified root.</param>
        /// <param name="list">list of the elements to process.</param>
        /// <remarks>By default, it implements a customizable variant of the MTDiff's "IdenticalSubtree" optimization.</remarks>
        protected virtual void CoreOnStep(TElement originalRoot, TElement modifiedRoot)
        {
            var matchingSet = this.Approach.MatchingSet();

            var context = new MatchingContext<TElement>(this.Approach);
            context.LScope.Original = originalRoot;
            context.LScope.Modified = modifiedRoot;

            foreach (var o in this.Traverse(originalRoot))
            {
                var matches = matchingSet.Originals.Unmatched(o) ? this.Criterion.Matches(o, context)?.ToList() : null;
                if (matches?.Count > 0)
                {
                    MatchInfo<TElement> bestMatch = matches.Count == 1 ? matches.Single() : this.Criterion.TieBreak(matches, context);
                    if (bestMatch != null) // if the match is unique (either originally discovered or otherwise resolved by tie break), notify it.
                    {
                        matchingSet.Partners(bestMatch);
                        foreach (var pairwiseMatch in this.Criterion.Partners(bestMatch.Original, bestMatch.Modified, context))
                        {
                            matchingSet.Partners(pairwiseMatch);
                        }
                    }
                    else // notify all the discovered candidate matches.
                    {
                        foreach (var candidate in matches)
                        {
                            matchingSet.Pair(candidate);
                        }
                    }
                }
            }
        }

        ///// <summary>
        ///// Core implementation of <see cref="OnStep"/>.
        ///// </summary>
        ///// <param name="originalRoot">the original root.</param>
        ///// <param name="modifiedRoot">the modified root.</param>
        ///// <param name="list">list of the elements to process.</param>
        ///// <remarks>By default, it implements a customizable variant of the MTDiff's "IdenticalSubtree" optimization.</remarks>
        //protected virtual void CoreOnStep(TElement originalRoot, TElement modifiedRoot, object list)
        //{
        //    var matchingSet = this.Approach.MatchingSet();

        //    this.AddToList(originalRoot, list);

        //    while (!this.EmptyList(list))
        //    {
        //        var o = this.ListHead(list);
        //        var matches = matchingSet.UnmatchedOriginal(o) ? this.Criterion.Matches(o, originalRoot, modifiedRoot)?.ToList() : null;
        //        if (matches?.Count > 0)
        //        {
        //            MatchInfo<TElement> bestMatch = matches.Count == 1 ? matches.Single() : this.Criterion.TieBreak(matches, originalRoot, modifiedRoot);
        //            if (bestMatch != null) // if the match is unique (either originally discovered or otherwise resolved by tie break), notify it.
        //            {
        //                matchingSet.Partners(bestMatch);
        //                foreach (var pairwiseMatch in this.Criterion.Partners(bestMatch.Original, bestMatch.Modified, originalRoot, modifiedRoot))
        //                {
        //                    matchingSet.Partners(pairwiseMatch);
        //                }
        //            }
        //            else // notify all the discovered candidate matches.
        //            {
        //                foreach (var candidate in matches)
        //                {
        //                    matchingSet.Pair(candidate);
        //                }
        //            }
        //        }
        //        else
        //        {
        //            var hierarchicalAbstraction = this.Approach.HierarchicalAbstraction();
        //            foreach (var c in hierarchicalAbstraction.Children(o))
        //            {
        //                //if(!this.IsLeaf(c))
        //                //    this.AddToList(c, list);
        //                this.AddToList(c, list);
        //            }
        //        }
        //    }
        //}

        ///// <summary>
        ///// Creates and initializes the list of elements to process.
        ///// </summary>
        ///// <returns>an empty list wherein storing the elements to process.</returns>
        //protected virtual object NewList()
        //{
        //    return new Queue<TElement>();
        //}

        ///// <summary>
        ///// Adds a new element to be processed.
        ///// </summary>
        ///// <param name="original">element to add.</param>
        ///// <param name="list">list of elements to process</param>
        //protected virtual void AddToList(TElement original, object list)
        //{
        //    ((Queue<TElement>)list).Enqueue(original);
        //}

        ///// <summary>
        ///// Informs if the list of elements to process is empty.
        ///// </summary>
        ///// <param name="list">list of elements to process</param>
        ///// <returns>true if it is empty, false otherwise</returns>
        //protected virtual bool EmptyList(object list)
        //{
        //    return ((Queue<TElement>)list).Count == 0;
        //}

        ///// <summary>
        ///// Returns the next element to process.
        ///// </summary>
        ///// <param name="list">list of elements to process</param>
        ///// <returns>the next element to process</returns>
        //protected virtual TElement ListHead(object list)
        //{
        //    return ((Queue<TElement>)list).Dequeue();
        //}

        /////// <summary>
        /////// Informs if a node is leaf.
        /////// </summary>
        /////// <param name="c">node of interest.</param>
        /////// <returns>true if it is leaf, false otherwise.</returns>
        ////protected virtual bool IsLeaf(TElement c)
        ////{
        ////    return (this.Approach.HierarchicalAbstraction().Children(c)?.Count() ?? 0) == 0;
        ////}
    }
}
