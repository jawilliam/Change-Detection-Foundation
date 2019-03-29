using Jawilliam.CDF.Approach.Annotations;
using Jawilliam.CDF.Approach.Criterions.Simetric;
using Jawilliam.CDF.Approach.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Jawilliam.CDF.Approach.Criterions.Impl
{
    /// <summary>
    /// Implements a <see cref="IMatcher{TElement}"/> as follows: let multiple candidate matches, it matches the more similar pair.
    /// </summary>
    /// <typeparam name="TElement">Type of the supported elements.</typeparam>
    /// <typeparam name="TAnnotation">Type of the information to store for each element.</typeparam>
    public class TieBreakingMatcher<TElement, TAnnotation> : Matcher<TElement, IApproach<TElement>>
        where TAnnotation : IMatchingAnnotation<TElement>, IElementAnnotation<TElement>, IHierarchicalAbstractionAnnotation, new()
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="serviceLocator">the mechanism for dynamically loading a typed service.</param>
        public TieBreakingMatcher(IApproach<TElement> serviceLocator) : base(serviceLocator)
        {
        }

        /// <summary>
        /// Stores the value of <see cref="Criterion"/>.
        /// </summary>
        private ISimetric<TElement> _criterion;

        /// <summary>
        /// Gets the tie-breaking criterion.
        /// </summary>
        public ISimetric<TElement> Criterion
        {
            get => this._criterion ?? (this._criterion = new DiceCoefficientSimetric<TElement>
            {
                AreEqual = this.ServiceLocator.MatchEquality<TElement, TAnnotation>,
                GetComponents = this.ServiceLocator._ByTermExistence<TElement, TAnnotation>
            });
            private set { this._criterion = value ?? throw new ArgumentNullException(nameof(value)); }
        }

        /// <summary>
        /// Discovers the candidate matches of a given node.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="originalContext">the original context (e.g., the root of the original AST).</param>
        /// <param name="modifiedContext">the modified context (e.g., the root of the modified AST).</param>
        /// <returns>candidate matches for the given node.</returns>
        public override IEnumerable<MatchInfo<TElement>> Matches(TElement original, TElement originalContext, TElement modifiedContext)
        {
            //if (this.ServiceLocator.HierarchicalAbstraction().IsLeaf(original))
            //    yield break;
            if (object.Equals(original, originalContext))
            {
                foreach (var o in original.BreadthFirstOrder(this.ServiceLocator.HierarchicalAbstraction().Children))
                {
                    var oAnnotation = this.ServiceLocator.Original<TElement, TAnnotation>(o);
                    if (oAnnotation.Candidates?.Count > 1)
                    {
                        foreach (var c in oAnnotation.Candidates)
                        {
                            yield return c;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Tries to identify a best match among multiple candidate matches. 
        /// </summary>
        /// <param name="candidates">candidate matches.</param>
        /// <param name="originalContext">the original context (e.g., the root of the original AST).</param>
        /// <param name="modifiedContext">the modified context (e.g., the root of the modified AST).</param>
        /// <returns>the best match if it was possible to identify some one, null otherwise.</returns>
        public override MatchInfo<TElement> TieBreak(IEnumerable<MatchInfo<TElement>> candidates, TElement originalContext, TElement modifiedContext)
        {
            if (candidates?.Count() == 1)
                return candidates.Single();

            var matchingSet = this.ServiceLocator.MatchingSet();
            var hierarchicalAbstraction = this.ServiceLocator.HierarchicalAbstraction();

            var candidateSimilarities = from c in candidates.Where(c => c.Criterion == (int)MatchInfoCriterions.IdenticalFullHash)
                                        let pOriginalAnnotation = this.ServiceLocator.Original<TElement, TAnnotation>(hierarchicalAbstraction.Parent(c.Original))
                                        let pModifiedAnnotation = this.ServiceLocator.Modified<TElement, TAnnotation>(hierarchicalAbstraction.Parent(c.Modified))
                                        select new
                                        {
                                            Candidate = c,
                                            Similarity = this.Criterion.GetSimilarity(pOriginalAnnotation.Element.Leaves(hierarchicalAbstraction.Children, hierarchicalAbstraction.IsLeaf),
                                                                                      pModifiedAnnotation.Element.Leaves(hierarchicalAbstraction.Children, hierarchicalAbstraction.IsLeaf)),
                                            pModifiedAnnotation.Size
                                        };

            return candidateSimilarities/*.Where(c => c.Similarity > 0.5)*/.OrderByDescending(c => c.Similarity).ThenByDescending(c => c.Size).FirstOrDefault()?.Candidate;
            //return new SimilarityMatchInfo<TElement>((int)MatchInfoId.Similarity) { Original = higherMatch.Candidate.Original, Modified = higherMatch.Candidate.Modified, Value = higherMatch.Similarity };
        }

        ///// <summary>
        ///// Discovers the candidate matches of a given node.
        ///// </summary>
        ///// <param name="original">the original version.</param>
        ///// <param name="originalContext">the original context (e.g., the root of the original AST).</param>
        ///// <param name="modifiedContext">the modified context (e.g., the root of the modified AST).</param>
        ///// <returns>candidate matches for the given node.</returns>
        //public override IEnumerable<MatchInfo<TElement>> Matches(TElement original, TElement originalContext, TElement modifiedContext)
        //{
        //    //if (this.ServiceLocator.HierarchicalAbstraction().IsLeaf(original))
        //    //    yield break;

        //    var oAnnotation = this.ServiceLocator.Original<TElement, TAnnotation>(original);
        //    if (oAnnotation.Candidates.All(c => c.Criterion == (int)MatchInfoCriterions.IdenticalFullHash))
        //    {
        //        foreach (var c in oAnnotation.Candidates)
        //        {
        //            yield return c;
        //        }
        //    }
        //}

        ///// <summary>
        ///// Tries to identify a best match among multiple candidate matches. 
        ///// </summary>
        ///// <param name="candidates">candidate matches.</param>
        ///// <param name="originalContext">the original context (e.g., the root of the original AST).</param>
        ///// <param name="modifiedContext">the modified context (e.g., the root of the modified AST).</param>
        ///// <returns>the best match if it was possible to identify some one, null otherwise.</returns>
        //public override MatchInfo<TElement> TieBreak(IEnumerable<MatchInfo<TElement>> candidates, TElement originalContext, TElement modifiedContext)
        //{
        //    if (candidates?.Count() == 1)
        //        return candidates.Single();

        //    var matchingSet = this.ServiceLocator.MatchingSet();
        //    var hierarchicalAbstraction = this.ServiceLocator.HierarchicalAbstraction();

        //    var candidateSimilarities = from c in candidates.Where(c => c.Criterion == (int)MatchInfoCriterions.IdenticalFullHash)
        //                                let pOriginalAnnotation = this.ServiceLocator.Original<TElement, TAnnotation>(hierarchicalAbstraction.Parent(c.Original))
        //                                let pModifiedAnnotation = this.ServiceLocator.Modified<TElement, TAnnotation>(hierarchicalAbstraction.Parent(c.Modified))
        //                                select new
        //                                {
        //                                    Candidate = c,
        //                                    Similarity = this.Criterion.GetSimilarity(pOriginalAnnotation.Element.Leaves(hierarchicalAbstraction.Children, hierarchicalAbstraction.IsLeaf),
        //                                                                              pModifiedAnnotation.Element.Leaves(hierarchicalAbstraction.Children, hierarchicalAbstraction.IsLeaf)),
        //                                    pModifiedAnnotation.Size
        //                                };

        //    return candidateSimilarities/*.Where(c => c.Similarity > 0.5)*/.OrderByDescending(c => c.Similarity).ThenByDescending(c => c.Size).FirstOrDefault()?.Candidate;
        //    //return new SimilarityMatchInfo<TElement>((int)MatchInfoId.Similarity) { Original = higherMatch.Candidate.Original, Modified = higherMatch.Candidate.Modified, Value = higherMatch.Similarity };
        //}

        /// <summary>
        /// Notifies that two comparing versions have been finally identified as a match (i.e., they are matching partners).
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="originalContext">the original context (e.g., the root of the original AST).</param>
        /// <param name="modifiedContext">the modified context (e.g., the root of the modified AST).</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        public override IEnumerable<MatchInfo<TElement>> Partners(TElement original, TElement modified, TElement originalContext, TElement modifiedContext)
        {
            var hierarchicalAbstraction = this.ServiceLocator.GetServiceOrThrowsException<IHierarchicalAbstractionService<TElement>>((int)ServiceId.HierarchicalAbstraction);
            return this.IdenticalSubtreePartners(original, modified, originalContext, modifiedContext);
        }
    }
}
