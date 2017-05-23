using System;
using System.Collections.Generic;
using System.Linq;

namespace Jawilliam.CDF.Similarity.Metrics
{
    /// <summary>
    /// Implements the similarity function defined in matching criterion 2 of "Change Detection in Hierarchically Structured Information".
    /// </summary>
    public class ChawatheMatchingCriterion2Simetric<T> : SimpleSimetric<T>
    {
        /// <summary>
        /// Compute the similarity value between two sequences.
        /// </summary>
        /// <param name="firstSequence">the first sequence to compare from.</param>
        /// <param name="secondSequence">the second sequence to compare to.</param>
        /// <param name="distance">if its sopported, returns the distance metric.</param>
        /// <returns>a double between 0 and 1 (0 = no similarity, 1 = matching strings).</returns>
        public override double GetSimilarity(IEnumerable<T> firstSequence, IEnumerable<T> secondSequence, out double? distance)
        {
            var firstSeq = firstSequence?.ToArray() ?? new T[0];
            var secondSeq = secondSequence?.ToArray() ?? new T[0];
            distance = null;
            if (!firstSeq.Any() && !secondSeq.Any())
                return 1;

            var uniqueNGrams = firstSeq.Union(secondSeq, this.Comparer).ToArray();

            double[] firstFrequencies, secondFrequencies;
            VectorComponents.ByTermFrequency(firstSeq, secondSeq, this.Comparer, out firstFrequencies, out secondFrequencies);
            if (uniqueNGrams.Length > 0)
            {
                distance = firstFrequencies.Select((t, i) => Math.Min(t, secondFrequencies[i])).Sum();
                double similarity = distance.Value / Math.Max(firstSeq.Length, secondSeq.Length);
                distance = 1 - similarity;
                return similarity;
            }

            return 0;
        }
    }
}
