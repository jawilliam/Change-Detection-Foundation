using System;
using System.Collections.Generic;
using System.Threading;

namespace Jawilliam.CDF.Similarity.Metrics
{
    /// <summary>
    /// Preferred base class for the <see cref="ISimetric{T}"/> implementations.
    /// </summary>
    public abstract class BaseSimetric<T> : ISimetric<T>
    {
        /// <summary>
        /// Gets or sets a token for receiving cancellation notifications and answering to them.
        /// </summary>
        public CancellationToken CancellationToken { get; set; }

        /// <summary>
        /// Gets the logic to support comparisons of objects for equality.
        /// </summary>
        public abstract IEqualityComparer<T> Comparer { get; set; }

        /// <summary>
        /// Compute the similarity value between two sequences.
        /// </summary>
        /// <param name="firstSequence">the first seAquence to compare from.</param>
        /// <param name="secondSequence">the second sequence to compare to.</param>
        /// <returns>a double between 0 and 1 (0 = no similarity, 1 = matching strings).</returns>
        public virtual double GetSimilarity(IEnumerable<T> firstSequence, IEnumerable<T> secondSequence)
        {
            double? distance;
            var similarity = this.GetSimilarity(firstSequence, secondSequence, out distance);
            return similarity;
        }

        /// <summary>
        /// Compute the similarity value between two sequences.
        /// </summary>
        /// <param name="firstSequence">the first sequence to compare from.</param>
        /// <param name="secondSequence">the second sequence to compare to.</param>
        /// <param name="distance">if its sopported, returns the distance metric.</param>
        /// <returns>a double between 0 and 1 (0 = no similarity, 1 = matching strings).</returns>
        public abstract double GetSimilarity(IEnumerable<T> firstSequence, IEnumerable<T> secondSequence, out double? distance);
    }
}
