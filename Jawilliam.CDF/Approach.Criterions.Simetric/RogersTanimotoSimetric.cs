using System;
using System.Collections.Generic;
using System.Linq;

namespace Jawilliam.CDF.Approach.Criterions.Simetric
{
    /// <summary>
    /// Implements the Rogers-Tanimoto based similarity.
    /// </summary>
    [Serializable]
    public class RogersTanimotoSimetric<T> : BinarySimetric<T>
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

            double a = this.A(firstSeq, secondSeq);
            double b = this.B(firstSeq, secondSeq);
            double c = this.C(firstSeq, secondSeq);
            double d = this.D(firstSeq, secondSeq);

            return (a + d) / (a + 2 * (b + c) + d);
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
            distance = Math.Sqrt(1 - similarity);
            return similarity;
        }
    }
}
