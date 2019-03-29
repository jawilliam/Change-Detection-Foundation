using Jawilliam.CDF.Approach.Annotations;
using Jawilliam.CDF.Approach.Criterions.Simetric;
using Jawilliam.CDF.Approach.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jawilliam.CDF.Approach.Criterions.Impl
{
    /// <summary>
    /// Implements a <see cref="IMatcher{TElement}"/> which matches the more similar pair.
    /// </summary>
    /// <typeparam name="TElement">Type of the supported elements.</typeparam>
    /// <typeparam name="TAnnotation">Type of the information to store for each element.</typeparam>
    public class SimilarityMatcher<TElement, TAnnotation> : Matcher<TElement, IApproach<TElement>> where TAnnotation : IMatchingAnnotation<TElement>, new()
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="serviceLocator">the mechanism for dynamically loading a typed service.</param>
        public SimilarityMatcher(IApproach<TElement> serviceLocator) : base(serviceLocator)
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
            var semanticAbstraction = this.ServiceLocator.SemanticAbstraction();
            var matchingSet = this.ServiceLocator.MatchingSet();
            if (!matchingSet.UnmatchedOriginal(original) || this.ServiceLocator.HierarchicalAbstraction().IsLeaf(original))
                yield break;

            var hierarchicalAbstraction = this.ServiceLocator.HierarchicalAbstraction();
            var candidateSimilarities = from m in modifiedContext.PostOrder(hierarchicalAbstraction.Children)
                                        where matchingSet.UnmatchedModified(m) && this.Compatible(original, m) && !hierarchicalAbstraction.IsLeaf(m)
                                        //where !hierarchicalAbstraction.IsLeaf(m) && this.Compatible(original, m)
                                        select new
                                        {
                                            Candidate = m,
                                            Similarity = this.Criterion.GetSimilarity(original.Leaves(hierarchicalAbstraction.Children, hierarchicalAbstraction.IsLeaf).Where(semanticAbstraction.IsEssential),
                                                                                      m.Leaves(hierarchicalAbstraction.Children, hierarchicalAbstraction.IsLeaf).Where(semanticAbstraction.IsEssential))
                                        };

            foreach (var c in candidateSimilarities.Where(cs => cs.Similarity > 0.5))
            {
                yield return new SimilarityMatchInfo<TElement>((int)MatchInfoCriterions.Similarity)
                {
                    Original = original,
                    Modified = c.Candidate,
                    Value = c.Similarity
                };
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
            var matchingSet = this.ServiceLocator.MatchingSet();
            var hierarchicalAbstraction = this.ServiceLocator.HierarchicalAbstraction();

            var original = candidates.First().Original;
            var oAnnotation = this.ServiceLocator.Original<TElement, TAnnotation>(original);

            if (candidates.Count() > 1 && 
                /*oAnnotation.Candidates.All(c => c.Criterion == (int)MatchInfoCriterions.Similarity) &&*/
                candidates.All(c => object.Equals(c.Original, original)) /*&&
                candidates.All(c => c.Criterion == (int)MatchInfoCriterions.Similarity)*/)
            {
                return candidates.Cast<SimilarityMatchInfo<TElement>>().OrderByDescending(c => c.Value).First();
            }
            else return base.TieBreak(candidates, originalContext, modifiedContext);
        }
    }
}
