using System.Collections.Generic;

namespace Jawilliam.Data.Mining.Simetric
{
    /// <summary>
    /// Defines a similarity (perhaps also supporting distance metric).
    /// </summary>
    /// <typeparam name="T">The concrete type of the elements to be compared.</typeparam>
    public interface ISimetric<T>
    {
        ///// <summary>
        ///// Gets the logic to support comparisons of objects for equality.
        ///// </summary>
        //IEqualityComparer<T> Comparer { get; set; }

        /// <summary>
        /// Compute the similarity value between two sequences.
        /// </summary>
        /// <param name="firstSequence">the first seAquence to compare from.</param>
        /// <param name="secondSequence">the second sequence to compare to.</param>
        /// <returns>a double between 0 and 1 (0 = no similarity, 1 = matching strings).</returns>
        double GetSimilarity(IEnumerable<T> firstSequence, IEnumerable<T> secondSequence);

        /// <summary>
        /// Compute the similarity value between two sequences.
        /// </summary>
        /// <param name="firstSequence">the first sequence to compare from.</param>
        /// <param name="secondSequence">the second sequence to compare to.</param>
        /// <param name="distance">if its sopported, returns the distance metric.</param>
        /// <returns>a double between 0 and 1 (0 = no similarity, 1 = matching strings).</returns>
        double GetSimilarity(IEnumerable<T> firstSequence, IEnumerable<T> secondSequence, out double? distance);
    }
}