using System;
using System.Collections.Generic;
using System.Linq;

namespace Jawilliam.Data.Mining.Simetric
{
    /// <summary>
    /// Implements the normalized canberra distance based similarity metric.
    /// </summary>
    /// <typeparam name="T">The concrete type of the elements to be compared.</typeparam>
    [Serializable]
    public class CanberraSimetric<T> : VectorSimetric<T> where T : IEquatable<T>
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
            distance = 1;
            if (!firstSeq.Any() && !secondSeq.Any())
                return 1;

            double[] firstComponents, secondComponents;
            var uniqueTokens = this.GetComponents(firstSeq, secondSeq, this.Comparer, out firstComponents, out secondComponents);
            if (uniqueTokens.Any())
            {
                if(!firstComponents.Select((d, i) => d != 0 && secondComponents[i] != 0).Any())
                    return 0;

                distance = firstComponents.Select((d, i) => Math.Abs(d - secondComponents[i])/(Math.Abs(d) + Math.Abs(secondComponents[i]))).Sum();
                return 1 - distance.Value / firstComponents.Length;
            }

            return 0;
        }
    }
}
