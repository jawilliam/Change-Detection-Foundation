using Jawilliam.CDF.Approach.Annotations;
using Jawilliam.CDF.Approach.Criterions.Simetric;
using Jawilliam.CDF.Approach.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Jawilliam.CDF.Approach.Criterions.Impl
{
    /// <summary>
    /// Base class for implementating <see cref="IMatcher{TElement}"/>.
    /// </summary>
    /// <typeparam name="TElement">Type of the supported elements.</typeparam>
    public abstract class Matcher<TElement, TServiceLocator> : IMatcher<TElement> where TServiceLocator : IServiceLocator
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="serviceLocator">the service locator to internally use.</param>
        public Matcher(TServiceLocator serviceLocator)
        {
            this.ServiceLocator = !object.Equals(serviceLocator, default(TServiceLocator)) ? serviceLocator : throw new ArgumentNullException(nameof(serviceLocator));
        }

        /// <summary>
        /// Allows to dynamically load a typed service.
        /// </summary>
        public TServiceLocator ServiceLocator { get; private set; }

        /// <summary>
        /// Discovers the candidate matches of a given node.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>candidate matches for the given node.</returns>
        public abstract IEnumerable<MatchInfo<TElement>> Matches(TElement original, MatchingContext<TElement> context);

        /// <summary>
        /// Tries to identify a best match among multiple candidate matches. 
        /// </summary>
        /// <param name="candidates">candidate matches.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>the best match if it was possible to identify some one, null otherwise.</returns>
        public virtual MatchInfo<TElement> TieBreak(IEnumerable<MatchInfo<TElement>> candidates, MatchingContext<TElement> context)
        {
            return candidates?.Count() == 1 ? candidates.Single() : null;
        }

        /// <summary>
        /// Notifies that two comparing versions have been finally identified as a match (i.e., they are matching partners).
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        public virtual IEnumerable<MatchInfo<TElement>> Partners(TElement original, TElement modified, MatchingContext<TElement> context)
        {
            yield break;
        }

        ///// <summary>
        ///// Discovers the candidate matches of a given node.
        ///// </summary>
        ///// <param name="original">the original version.</param>
        ///// <param name="originalContext">the original context (e.g., the root of the original AST).</param>
        ///// <param name="modifiedContext">the modified context (e.g., the root of the modified AST).</param>
        ///// <returns>candidate matches for the given node.</returns>
        //public abstract IEnumerable<MatchInfo<TElement>> Matches(TElement original, TElement originalContext, TElement modifiedContext);

        ///// <summary>
        ///// Tries to identify a best match among multiple candidate matches. 
        ///// </summary>
        ///// <param name="candidates">candidate matches.</param>
        ///// <param name="originalContext">the original context (e.g., the root of the original AST).</param>
        ///// <param name="modifiedContext">the modified context (e.g., the root of the modified AST).</param>
        ///// <returns>the best match if it was possible to identify some one, null otherwise.</returns>
        //public virtual MatchInfo<TElement> TieBreak(IEnumerable<MatchInfo<TElement>> candidates, TElement originalContext, TElement modifiedContext)
        //{
        //    return candidates?.Count() == 1 ? candidates.Single() : null;
        //}

        ///// <summary>
        ///// Notifies that two comparing versions have been finally identified as a match (i.e., they are matching partners).
        ///// </summary>
        ///// <param name="original">the original version.</param>
        ///// <param name="modified">the modified version.</param>
        ///// <param name="originalContext">the original context (e.g., the root of the original AST).</param>
        ///// <param name="modifiedContext">the modified context (e.g., the root of the modified AST).</param>
        ///// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        //public virtual IEnumerable<MatchInfo<TElement>> Partners(TElement original, TElement modified, TElement originalContext, TElement modifiedContext)
        //{
        //    yield break;
        //}

        /// <summary>
        /// Notifies that two identical versions have been finally identified as a match (i.e., they are matching partners).
        /// </summary>
        /// <param name="hierarchicalAbstraction">the hierarchical abstractions service.</param>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        protected virtual IEnumerable<MatchInfo<TElement>> IdenticalSubtreePartners(TElement original, TElement modified, MatchingContext<TElement> context)
        {
            var hierarchicalAbstraction = this.ServiceLocator.HierarchicalAbstraction<TElement>();
            var oChildren = hierarchicalAbstraction.Children(original).ToArray();
            var mChildren = hierarchicalAbstraction.Children(modified).ToArray();
            var matchingSet = this.ServiceLocator.MatchingSet<TElement>();

            for (int i = 0; i < oChildren.Count(); i++)
            {
                var oChild = oChildren[i];

                if (i < mChildren.Length)
                {
                    var mChild = mChildren[i];
                    if (matchingSet.Originals.Unmatched(oChild) && matchingSet.Modifieds.Unmatched(mChild) && !matchingSet.Paired(oChild, mChild))
                        yield return new MatchInfo<TElement>((int)MatchInfoCriterions.PairwiseIdenticalSubtree) { Original = oChild, Modified = mChild };

                    var lOriginal = context.LScope.Original;
                    var lModified = context.LScope.Modified;
                    try
                    {
                        context.LScope.Original = original;
                        context.LScope.Modified = modified;
                        foreach (var pairwiseMatch in this.Partners(oChild, mChild, context) ?? new MatchInfo<TElement>[0])
                        {
                            yield return pairwiseMatch;
                        }
                    }
                    finally
                    {
                        context.LScope.Original = lOriginal;
                        context.LScope.Modified = lModified;
                    }
                }
            }
        }

        /// <summary>
        /// Notifies that two similar versions have been finally identified as a match (i.e., they are matching partners).
        /// </summary>
        /// <param name="hierarchicalAbstraction">the hierarchical abstractions service.</param>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        protected virtual IEnumerable<MatchInfo<TElement>> SimilarSubtreePartners(TElement original, TElement modified, MatchingContext<TElement> context)
        {
            var hierarchicalAbstraction = this.ServiceLocator.HierarchicalAbstraction<TElement>();
            var oChildren = hierarchicalAbstraction.Children(original).ToArray();
            var mChildren = hierarchicalAbstraction.Children(modified).ToArray();
            var matchingSet = this.ServiceLocator.MatchingSet<TElement>();

            for (int i = 0; i < oChildren.Count(); i++)
            {
                var oChild = oChildren[i];

                if (i < mChildren.Length)
                {
                    var mChild = mChildren[i];
                    if (matchingSet.Originals.Unmatched(oChild) && matchingSet.Modifieds.Unmatched(mChild) && !matchingSet.Paired(oChild, mChild))
                        yield return new MatchInfo<TElement>((int)MatchInfoCriterions.PairwiseIdenticalSubtree) { Original = oChild, Modified = mChild };

                    var lOriginal = context.LScope.Original;
                    var lModified = context.LScope.Modified;
                    try
                    {
                        context.LScope.Original = original;
                        context.LScope.Modified = modified;
                        foreach (var pairwiseMatch in this.Partners(oChild, mChild, context) ?? new MatchInfo<TElement>[0])
                        {
                            yield return pairwiseMatch;
                        }
                    }
                    finally
                    {
                        context.LScope.Original = lOriginal;
                        context.LScope.Modified = lModified;
                    }                    
                }
            }
        }

        ///// <summary>
        ///// Notifies that two identical versions have been finally identified as a match (i.e., they are matching partners).
        ///// </summary>
        ///// <param name="hierarchicalAbstraction">the hierarchical abstractions service.</param>
        ///// <param name="original">the original version.</param>
        ///// <param name="modified">the modified version.</param>
        ///// <param name="originalContext">the original context (e.g., the root of the original AST).</param>
        ///// <param name="modifiedContext">the modified context (e.g., the root of the modified AST).</param>
        ///// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        //protected virtual IEnumerable<MatchInfo<TElement>> IdenticalSubtreePartners(TElement original, TElement modified, TElement originalContext, TElement modifiedContext)
        //{
        //    var hierarchicalAbstraction = this.ServiceLocator.HierarchicalAbstraction<TElement>();
        //    var oChildren = hierarchicalAbstraction.Children(original).ToArray();
        //    var mChildren = hierarchicalAbstraction.Children(modified).ToArray();
        //    var matchingSet = this.ServiceLocator.MatchingSet<TElement>();

        //    for (int i = 0; i < oChildren.Count() ; i++)
        //    {
        //        var oChild = oChildren[i];

        //        if (i < mChildren.Length)
        //        {
        //            var mChild = mChildren[i];
        //            if(matchingSet.Originals.Unmatched(oChild) && matchingSet.Modifieds.Unmatched(mChild) && !matchingSet.Paired(oChild, mChild))
        //                yield return new MatchInfo<TElement>((int)MatchInfoCriterions.PairwiseIdenticalSubtree) { Original = oChild, Modified = mChild };

        //            foreach (var pairwiseMatch in this.Partners(oChild, mChild, originalContext, modifiedContext) ?? new MatchInfo<TElement>[0])
        //            {
        //                yield return pairwiseMatch;
        //            }
        //        }
        //    }
        //}

        ///// <summary>
        ///// Notifies that two similar versions have been finally identified as a match (i.e., they are matching partners).
        ///// </summary>
        ///// <param name="hierarchicalAbstraction">the hierarchical abstractions service.</param>
        ///// <param name="original">the original version.</param>
        ///// <param name="modified">the modified version.</param>
        ///// <param name="originalContext">the original context (e.g., the root of the original AST).</param>
        ///// <param name="modifiedContext">the modified context (e.g., the root of the modified AST).</param>
        ///// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        //protected virtual IEnumerable<MatchInfo<TElement>> SimilarSubtreePartners(TElement original, TElement modified, TElement originalContext, TElement modifiedContext)
        //{
        //    var hierarchicalAbstraction = this.ServiceLocator.HierarchicalAbstraction<TElement>();
        //    var oChildren = hierarchicalAbstraction.Children(original).ToArray();
        //    var mChildren = hierarchicalAbstraction.Children(modified).ToArray();
        //    var matchingSet = this.ServiceLocator.MatchingSet<TElement>();

        //    for (int i = 0; i < oChildren.Count(); i++)
        //    {
        //        var oChild = oChildren[i];

        //        if (i < mChildren.Length)
        //        {
        //            var mChild = mChildren[i];
        //            if (matchingSet.Originals.Unmatched(oChild) && matchingSet.Modifieds.Unmatched(mChild) && !matchingSet.Paired(oChild, mChild))
        //                yield return new MatchInfo<TElement>((int)MatchInfoCriterions.PairwiseIdenticalSubtree) { Original = oChild, Modified = mChild };

        //            foreach (var pairwiseMatch in this.Partners(oChild, mChild, originalContext, modifiedContext) ?? new MatchInfo<TElement>[0])
        //            {
        //                yield return pairwiseMatch;
        //            }
        //        }
        //    }
        //}

        /// <summary>
        /// Determines if two comparing versions can match.
        /// </summary>
        /// <param name="original">original version.</param>
        /// <param name="modified">modified version.</param>
        /// <returns>true if they can match, false otherwise.</returns>
        protected virtual bool Compatible(TElement original, TElement modified)
        {
            var hierarchicalAbstraction = this.ServiceLocator.HierarchicalAbstraction<TElement>();
            return hierarchicalAbstraction.Label(original) == hierarchicalAbstraction.Label(modified);
        }
    }
}
