using System;
using System.Collections.Generic;
using System.Linq;

namespace Jawilliam.CDF.Metrics.Similarity
{
    /// <summary>
    /// Implements the Motyka based similarity.
    /// </summary>
    [Serializable]
    public class MotykaSimetric<T> : VectorSimetric<T> where T : IEquatable<T>
    {
        /// <summary>
        /// Compute the similarity value between two sequences.
        /// </summary>
        /// <param name="firstSequence">the first seAquence to compare from.</param>
        /// <param name="secondSequence">the second sequence to compare to.</param>
        /// <returns>a double between 0 and 1 (0 = no similarity, 1 = matching strings).</returns>
        public override double GetSimilarity(IEnumerable<T> firstSequence, IEnumerable<T> secondSequence)
        {
            var firstSeq = firstSequence?.ToArray() ?? new T[0];
            var secondSeq = secondSequence?.ToArray() ?? new T[0];
            if (!firstSeq.Any() && !secondSeq.Any())
                return 1;

            double[] firstComponents, secondComponents;
            var uniqueTokens = this.GetComponents(firstSeq, secondSeq, this.Comparer, out firstComponents, out secondComponents);
            if (uniqueTokens.Any())
            {
                var min = firstComponents.Select((d, i) => Math.Min(d, secondComponents[i])).Sum();
                var sum = firstComponents.Select((d, i) => d + secondComponents[i]).Sum();

                return min / sum;
            }

            return 0;
        }

        /// <summary>
        /// Compute the similarity value between two sequences.
        /// </summary>
        /// <param name="firstSequence">the first sequence to compare from.</param>
        /// <param name="secondSequence">the second sequence to compare to.</param>
        /// <param name="distance">if its sopported, returns the distance metric.</param>
        /// <returns>a double between 0 and 1 (0 = no similarity, 1 = matching strings).</returns>
        public override double GetSimilarity(IEnumerable<T> firstSequence, IEnumerable<T> secondSequence, out double? distance)
        {
            var similarity = this.GetSimilarity(firstSequence, secondSequence);
            distance = 1 - similarity;
            return similarity;
        }
    }
}
