using System.Collections.Generic;

namespace Jawilliam.CDF.Metrics.Similarity
{
    /// <summary>
    /// Defines a distance (perhaps also supporting similarity) metric.
    /// </summary>
    /// <typeparam name="T">The concrete type of the elements to be compared.</typeparam>
    public interface IDismetric<in T>
    {
        /// <summary>
        /// Compute the distance value between two sequences.
        /// </summary>
        /// <param name="firstSequence">the first seAquence to compare from.</param>
        /// <param name="secondSequence">the second sequence to compare to.</param>
        /// <returns>a double value.</returns>
        double GetDistance(IEnumerable<T> firstSequence, IEnumerable<T> secondSequence);

        /// <summary>
        /// Compute the distance value between two sequences.
        /// </summary>
        /// <param name="firstSequence">the first sequence to compare from.</param>
        /// <param name="secondSequence">the second sequence to compare to.</param>
        /// <param name="similarity">if its sopported, returns the similarity metric.</param>
        /// <returns>a double value.</returns>
        double GetDistance(IEnumerable<T> firstSequence, IEnumerable<T> secondSequence, out double? similarity);
    }
}
