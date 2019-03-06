using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * #%L
 * Simmetrics Core
 * %%
 * Copyright (C) 2014 - 2016 Simmetrics Authors
 * %%
 * Licensed under the Apache License, Version 2.0 (the "License"); you may not
 * use this file except in compliance with the License. You may obtain a copy of
 * the License at
 * 
 * http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS, WITHOUT
 * WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the
 * License for the specific language governing permissions and limitations under
 * the License.
 * #L%
 */
namespace Jawilliam.CDF.Approach.Criterions.Simetric
{
    /// <summary>
    /// Implements the Longest Common Subsequence similarity metric.
    /// </summary>
    /// <typeparam name="T">The concrete type of the elements to be compared.</typeparam>
    public class LongestCommonSubsequenceSimetric<T> : SimpleSimetric<T> where T : IEquatable<T>
    {
        /// <summary>
        /// Computes the LCS distance value between two sequences.
        /// </summary>
        /// <param name="firstSequence">the first sequence to compare from.</param>
        /// <param name="secondSequence">the second sequence to compare to.</param>
        /// <returns></returns>
        public virtual double GetDistance(IList<T> firstSequence, IList<T> secondSequence)
        {
            int n = firstSequence.Count;
            int m = secondSequence.Count;

            // We're only interested in the actual longest common subsequence This
            // means we don't have to backtrack through the n-by-m matrix and can
            // safe some space by reusing v0 for row i-1.
            int[] v0 = new int[m + 1];
            int[] v1 = new int[m + 1];

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    v1[j] = this.AreEqual(firstSequence[i - 1], secondSequence[j - 1]) ? v0[j - 1] + 1 : Math.Max(v1[j - 1], v0[j]);
                }
                int[] swap = v0; v0 = v1; v1 = swap;
            }

            // Because we swapped the results are in v0.
            return v0[m];
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
            var firstSeq = firstSequence?.ToArray() ?? new T[0];
            var secondSeq = secondSequence?.ToArray() ?? new T[0];

            distance = null;
            if (!firstSeq.Any() && !secondSeq.Any())
                return 1;

            double lcs = !firstSeq.Any() || !secondSeq.Any() ? 0 : this.GetDistance(firstSeq, secondSeq);
            distance = firstSeq.Length + secondSeq.Length - 2 * lcs;
            return 1 - distance.Value / (firstSeq.Length + secondSeq.Length);
        }
    }
}
