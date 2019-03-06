using System;
using System.Collections.Generic;

namespace Jawilliam.CDF.Approach.Criterions.Simetric
{
    /// <summary>
    /// Preferred base class of similarity metric that are implemented based on another internally used similarity metric.
    /// </summary>
    [Serializable]
    public abstract class IntegratedSimetric<T, TK> : ISimetric<T> where TK : IEquatable<TK>
    {
        /// <summary>
        /// Stores the value of the <see cref="InternalSimetric"/> property.
        /// </summary>
        // ReSharper disable once InconsistentNaming
        internal ISimetric<TK> _internalSimetric;
        // ReSharper enable once InconsistentNaming

        /// <summary>
        /// Gets or sets the similarity metric internally used.
        /// </summary>
        public virtual ISimetric<TK> InternalSimetric
        {
            get { return this._internalSimetric ?? (this._internalSimetric = new BlockDistanceSimetric<TK>()); }
            set { this._internalSimetric = value; }
        }

        /// <summary>
        /// Compute the similarity value between two sequences.
        /// </summary>
        /// <param name="firstSequence">the first seAquence to compare from.</param>
        /// <param name="secondSequence">the second sequence to compare to.</param>
        /// <returns>a double between 0 and 1 (0 = no similarity, 1 = matching strings).</returns>
        public virtual double GetSimilarity(IEnumerable<T> firstSequence, IEnumerable<T> secondSequence)
        {
            var similarity = this.GetSimilarity(firstSequence, secondSequence, out double? distance);
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
