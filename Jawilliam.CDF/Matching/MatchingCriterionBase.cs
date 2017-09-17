using Jawilliam.CDF.Approach;

namespace Jawilliam.CDF.Matching
{
    /// <summary>
    /// Implements a logic for determining if two elements match or not.
    /// </summary>
    /// <typeparam name="TApproach">the type of the supporting approach.</typeparam>
    /// <typeparam name="T">Type of the comparing elements.</typeparam>
    public abstract class MatchingCriterionBase<TApproach, T> : IMatchProvider<TApproach, T>
    {
        /// <summary>
        /// Gets or sets a transformation to apply before the matching occurs.
        /// </summary>
        public virtual IMatchingTransformation<TApproach, T> Transform { get; set; }

        /// <summary>
        /// Determines if the given elements are or not similar.
        /// </summary>
        /// <param name="pair">the comparing elements and contextual information.</param>
        /// <param name="matchingPair">If the elements are similar it returns an structure describing the result, for example
        /// the similarity and/or a distance value. If the the elements are not similar, it returns null.</param>
        /// <returns>True if the elements are similar, otherwise it returns false.</returns>
        public bool? Match(DetectionStep<TApproach, T> pair, out MatchingPair<T> matchingPair)
        {
            matchingPair = null;
            T original = pair.Original, modified = pair.Modified;
            try
            {
                T transformedOriginal = original, transformedModified = modified;
                this.Transform?.Transform(pair, out transformedOriginal, out transformedModified);
                pair.Original = transformedOriginal;
                pair.Modified = transformedModified;
                return this.CoreMatch(pair, out matchingPair);
            }
            finally
            {
                pair.Original = original;
                pair.Modified = modified;

                if (matchingPair != null)
                {
                    matchingPair.Original = original;
                    matchingPair.Modified = modified;
                }
            }
        }

        /// <summary>
        /// The core implementation for <see cref="Match"/>.
        /// </summary>
        /// <param name="pair">the comparing elements and contextual information.</param>
        /// <param name="matchingPair">If the elements are comparable it returns an structure describing the result, for example
        /// the similarity and/or a distance value. Otherwise, it returns null.</param>
        /// <returns>True if the elements are similar, otherwise it returns false.</returns>
        protected abstract bool? CoreMatch(DetectionStep<TApproach, T> pair, out MatchingPair<T> matchingPair);
    }
}
