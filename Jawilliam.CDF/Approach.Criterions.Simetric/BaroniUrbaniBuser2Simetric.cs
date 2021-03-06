﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Jawilliam.CDF.Approach.Criterions.Simetric
{
    /// <summary>
    /// Implements the Baroni-Urbani and Buser (II) based similarity.
    /// </summary>
    [Serializable]
    public class BaroniUrbaniBuser2Simetric<T> : BinarySimetric<T>
    {
        /// <summary>
        /// Compute the similarity value between two sequences.
        /// </summary>
        /// <param name="firstSequence">the first seAquence to compare from.</param>
        /// <param name="secondSequence">the second sequence to compare to.</param>
        /// <returns>a double between 0 and 1 (0 = no similarity, 1 = matching strings).</returns>
        public override double GetSimilarity(IEnumerable<T> firstSequence, IEnumerable<T> secondSequence)
        {
            var firstSeq = firstSequence?.ToArray() ?? Array.Empty<T>();
            var secondSeq = secondSequence?.ToArray() ?? Array.Empty<T>();
            if (!firstSeq.Any() && !secondSeq.Any())
                return 1;

            double a = this.A(firstSeq, secondSeq);
            double b = this.B(firstSeq, secondSeq);
            double c = this.C(firstSeq, secondSeq);
            double d = this.D(firstSeq, secondSeq);

            return (Math.Sqrt(a * d) + a) / (Math.Sqrt(a * d) + a + b + c);
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
