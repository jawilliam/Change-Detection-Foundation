using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jawilliam.Data.Mining.Simetric
{
    /// <summary>
    /// Implements a similarity metric based on the one-complemented Sorensen distance.
    /// </summary>
    /// <typeparam name="T">The concrete type of the elements being compared.</typeparam>
    public class SorensenSimetric<T> : VectorSimetric<T> where T : IEquatable<T>
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

            double total = firstComponents.Select((t, i) => t + secondComponents[i]).Sum();
            distance = firstComponents.Select((t, i) => Math.Abs(t - secondComponents[i])).Sum();

            return 1 - distance.Value / total;
        }
    }
}
