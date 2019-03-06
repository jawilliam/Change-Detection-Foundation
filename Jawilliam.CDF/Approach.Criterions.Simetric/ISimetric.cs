using System.Collections.Generic;

namespace Jawilliam.CDF.Approach.Criterions.Simetric
{
    /// <summary>
    /// Defines a similarity metric, maybe also supporting a distance notion.
    /// </summary>
    /// <typeparam name="T">Type of the elements to compare.</typeparam>
    public interface ISimetric<T>
    {
        /// <summary>
        /// Computes the similarity degree among two sequences.
        /// </summary>
        /// <param name="firstSequence">first sequence to compare.</param>
        /// <param name="secondSequence">second sequence to compare.</param>
        /// <returns>a double between 0 and 1 (0 = no similarity, 1 = matching strings).</returns>
        double GetSimilarity(IEnumerable<T> firstSequence, IEnumerable<T> secondSequence);

        /// <summary>
        /// Computes the similarity degree among two sequences.
        /// </summary>
        /// <param name="firstSequence">first sequence to compare.</param>
        /// <param name="secondSequence">second sequence to compare.</param>
        /// <param name="distance">if its sopported, returns the distance degree.</param>
        /// <returns>a double between 0 and 1 (0 = no similarity, 1 = matching strings).</returns>
        double GetSimilarity(IEnumerable<T> firstSequence, IEnumerable<T> secondSequence, out double? distance);
    }
}