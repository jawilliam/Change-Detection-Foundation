using System;
using System.Collections.Generic;
using System.Linq;

namespace Jawilliam.Data.Mining.Simetric
{
    /// <summary>
    /// Implements the Soergel distance based similarity.
    /// </summary>
    /// <typeparam name="T">The concrete type of the elements to be compared.</typeparam>
    [Serializable]
    public class SoergelDistanceSimetric<T> : VectorSimetric<T> where T : IEquatable<T>
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

            double[] firstComponents, secondComponents;
            this.GetComponents(firstSeq, secondSeq, this.Comparer, out firstComponents, out secondComponents);

            var absSum = firstComponents.Select((t, i) => Math.Abs(t - secondComponents[i])).Sum();
            var maxSum = firstComponents.Select((t, i) => Math.Max(t, secondComponents[i])).Sum();
            distance = absSum/maxSum;
            
            return 1 - distance.Value;
        }
    }
}
