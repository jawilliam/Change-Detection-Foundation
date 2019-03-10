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
                AreEqual = this._AreEqual<TAnnotation>,
                GetComponents = this.ByTermExistence<TAnnotation>
            });
            private set { this._criterion = value ?? throw new ArgumentNullException(nameof(value)); }
        }

        ///// <summary>
        ///// Computes the existence of each unique term.
        ///// </summary>
        ///// <typeparam name="T">Concrete type of each term.</typeparam>
        ///// <param name="firstSequence">First sequence where to compute the components over.</param>
        ///// <param name="secondSequence">First sequence where to compute the components over.</param>
        ///// <param name="comparer">the logic to support comparisons of objects for equality.</param>
        ///// <param name="firstResult">Returns the computed components related to the first sequence.</param>
        ///// <param name="secondResult">Returns the computed components related to the second sequence.</param>
        ///// <param name="termSelector">Function to compute the terms.</param>
        ///// <returns>The unique terms that the existences was computed for.</returns>
        //public static IEnumerable<T> ByTermExistence<T>(T[] firstSequence, T[] secondSequence, IEqualityComparer<T> comparer, out double[] firstResult, out double[] secondResult, Func<IEnumerable<T>, IEnumerable<T>, IEqualityComparer<T>, IEnumerable<T>> termSelector = null)
        //{
        //    if (firstSequence == null) throw new ArgumentNullException(nameof(firstSequence));
        //    if (secondSequence == null) throw new ArgumentNullException(nameof(secondSequence));

        //    var terms = 

        //    var terms = termSelector?.Invoke(firstSequence, secondSequence, comparer).ToArray() ?? firstSequence.Union(secondSequence, comparer).ToArray();

        //    firstResult = terms.Select(t => firstSequence.Any(ts => comparer.Equals(ts, t)) ? 1d : 0d).ToArray();
        //    secondResult = terms.Select(t => secondSequence.Any(ts => comparer.Equals(t, ts)) ? 1d : 0d).ToArray();

        //    return terms;
        //}

        /// <summary>
        /// Discovers the candidate matches of a given node.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="originalContext">the original context (e.g., the root of the original AST).</param>
        /// <param name="modifiedContext">the modified context (e.g., the root of the modified AST).</param>
        /// <returns>candidate matches for the given node.</returns>
        public override IEnumerable<MatchInfo<TElement>> Matches(TElement original, TElement originalContext, TElement modifiedContext)
        {
            var matchingSet = this.ServiceLocator.MatchingSet();
            if (!matchingSet.UnmatchedOriginal(original) /*|| this.ServiceLocator.HierarchicalAbstraction().IsLeaf(original)*/)
                yield break;

            var hierarchicalAbstraction = this.ServiceLocator.HierarchicalAbstraction();
            var candidateSimilarities = from m in modifiedContext.PostOrder(hierarchicalAbstraction.Children)
                                        where matchingSet.UnmatchedModified(m) && this.Compatible(original, m)
                                        //where !hierarchicalAbstraction.IsLeaf(m) && this.Compatible(original, m)
                                        select new
                                        {
                                            Candidate = m,
                                            Similarity = this.Criterion.GetSimilarity(original.PostOrder(hierarchicalAbstraction.Children),
                                                                                      m.PostOrder(hierarchicalAbstraction.Children))
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
                oAnnotation.Candidates.All(c => c.Criterion == (int)MatchInfoCriterions.Similarity) &&
                candidates.All(c => object.Equals(c.Original, original)) &&
                candidates.All(c => c.Criterion == (int)MatchInfoCriterions.Similarity))
            {
                return candidates.Cast<SimilarityMatchInfo<TElement>>().OrderByDescending(c => c.Value).First();
            }
            else return base.TieBreak(candidates, originalContext, modifiedContext);
        }

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
            return base.Partners(original, modified, originalContext, modifiedContext);
        }
    }
}
