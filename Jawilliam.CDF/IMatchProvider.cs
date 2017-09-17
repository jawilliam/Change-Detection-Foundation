using Jawilliam.CDF.Approach;

namespace Jawilliam.CDF
{
    /// <summary>
    /// Defines how to determine if two elements are similar or not.
    /// </summary>
    /// <typeparam name="TApproach">Type of the supported approaches.</typeparam>
    /// <typeparam name="T">Type of the comparing elements.</typeparam>
    public interface IMatchProvider<TApproach, T>
    {
        /// <summary>
        /// Determines if the given elements are or not similar.
        /// </summary>
        /// <param name="pair">the comparing elements and contextual information.</param>
        /// <param name="matchingPair">If the elements are similar it returns an structure describing the result, for example
        /// the similarity and/or a distance value. If the the elements are not similar, it returns null.</param>
        /// <returns>True if the elements are similar, otherwise it returns false.</returns>
        bool? Match(DetectionStep<TApproach, T> pair, out MatchingPair<T> matchingPair);
    }
}