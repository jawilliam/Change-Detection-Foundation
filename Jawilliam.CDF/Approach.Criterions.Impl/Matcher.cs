using Jawilliam.CDF.Approach.Services;
using System.Collections.Generic;
using System.Linq;

namespace Jawilliam.CDF.Approach.Criterions.Impl
{
    /// <summary>
    /// Base class for implementating <see cref="IMatcher{TElement}"/>.
    /// </summary>
    /// <typeparam name="TElement">Type of the supported elements.</typeparam>
    public abstract class Matcher<TElement> : IMatcher<TElement>
    {
        /// <summary>
        /// Discovers the candidate matches of a given node.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="originalContext">the original context (e.g., the root of the original AST).</param>
        /// <param name="modifiedContext">the modified context (e.g., the root of the modified AST).</param>
        /// <returns>candidate matches for the given node.</returns>
        public abstract IEnumerable<MatchInfo<TElement>> Matches(TElement original, TElement originalContext, TElement modifiedContext);

        /// <summary>
        /// Tries to identify a best match among multiple candidate matches. 
        /// </summary>
        /// <param name="candidates">candidate matches.</param>
        /// <param name="originalContext">the original context (e.g., the root of the original AST).</param>
        /// <param name="modifiedContext">the modified context (e.g., the root of the modified AST).</param>
        /// <returns>the best match if it was possible to identify some one, null otherwise.</returns>
        public virtual MatchInfo<TElement> TieBreak(IEnumerable<MatchInfo<TElement>> candidates, TElement originalContext, TElement modifiedContext)
        {
            return candidates?.Count() == 1 ? candidates.Single() : null;
        }

        /// <summary>
        /// Notifies that two comparing versions have been finally identified as a match (i.e., they are matching partners).
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="originalContext">the original context (e.g., the root of the original AST).</param>
        /// <param name="modifiedContext">the modified context (e.g., the root of the modified AST).</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        public virtual IEnumerable<MatchInfo<TElement>> Partners(TElement original, TElement modified, TElement originalContext, TElement modifiedContext)
        {
            yield break;
        }

        /// <summary>
        /// Notifies that two identical versions have been finally identified as a match (i.e., they are matching partners).
        /// </summary>
        /// <param name="hierarchicalAbstraction">the hierarchical abstractions service.</param>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="originalContext">the original context (e.g., the root of the original AST).</param>
        /// <param name="modifiedContext">the modified context (e.g., the root of the modified AST).</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        protected virtual IEnumerable<MatchInfo<TElement>> IdenticalSubtrees(IHierarchicalAbstractionService<TElement> hierarchicalAbstraction, TElement original, TElement modified, TElement originalContext, TElement modifiedContext)
        {
            var oChildren = hierarchicalAbstraction.Children(original).ToArray();
            var mChildren = hierarchicalAbstraction.Children(modified).ToArray();
            for (int i = 0; i < oChildren.Count() ; i++)
            {
                var oChild = oChildren[i];
                var mChild = mChildren[i];

                yield return new MatchInfo<TElement>((int)MatchingCriterionIds.PairwiseIdenticalSubtree) { Original = oChild, Modified = mChild };
                foreach (var pairwiseMatch in this.IdenticalSubtrees(hierarchicalAbstraction, oChild, mChild, originalContext, modifiedContext) ?? new MatchInfo<TElement>[0])
                {
                    yield return pairwiseMatch;
                }
            }
        }
    }
}
