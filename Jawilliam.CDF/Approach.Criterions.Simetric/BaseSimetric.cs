using System;
using System.Collections;
using System.Collections.Generic;

namespace Jawilliam.CDF.Approach.Criterions.Simetric
{
    /// <summary>
    /// Tentative base class for <see cref="ISimetric{T}"/> implementations.
    /// </summary>
    public abstract class BaseSimetric<T> : ISimetric<T>
    {
        /// <summary>
        /// Gets or sets the equality notion among two comparing elements.
        /// </summary>
        public abstract Func<T, T, bool> AreEqual { get; set; }

        /// <summary>
        /// Computes the similarity degree among two sequences.
        /// </summary>
        /// <param name="firstSequence">first sequence to compare.</param>
        /// <param name="secondSequence">second sequence to compare.</param>
        /// <returns>a double between 0 and 1 (0 = no similarity, 1 = matching strings).</returns>
        public virtual double GetSimilarity(IEnumerable<T> firstSequence, IEnumerable<T> secondSequence)
        {
            return this.GetSimilarity(firstSequence, secondSequence, out double? distance);
        }

        /// <summary>
        /// Computes the similarity degree among two sequences.
        /// </summary>
        /// <param name="firstSequence">first sequence to compare.</param>
        /// <param name="secondSequence">second sequence to compare.</param>
        /// <param name="distance">if its sopported, returns the distance degree.</param>
        /// <returns>a double between 0 and 1 (0 = no similarity, 1 = matching strings).</returns>
        public abstract double GetSimilarity(IEnumerable<T> firstSequence, IEnumerable<T> secondSequence, out double? distance);

        /// <summary>
        /// Stores the value of <see cref="Comparer"/>.
        /// </summary>
        private EqualityComparer _equalityComparer;

        /// <summary>
        /// Gets or sets an <see cref="IEqualityComparer{T}"/> implementation, based on <see cref="BaseSimetric{T}.AreEqual"/>
        /// </summary>
        protected virtual EqualityComparer Comparer
        {
            get => this._equalityComparer ?? (this._equalityComparer = new EqualityComparer(this));
            set => this._equalityComparer = value;
        }

        /// <summary>
        /// Defines methods to support the comparison of objects for equality, based on <see cref="BaseSimetric{T}.AreEqual"/>.
        /// </summary>
        public class EqualityComparer : IEqualityComparer<T>
        {
            /// <summary>
            /// Initializes the instance.
            /// </summary>
            /// <param name="baseSimetric"></param>
            public EqualityComparer(BaseSimetric<T> baseSimetric)
            {
                this.BaseSimetric = baseSimetric ?? throw new ArgumentNullException(nameof(baseSimetric));
            }

            /// <summary>
            /// References the corresponding <see cref="BaseSimetric{T}"/>.
            /// </summary>
            public virtual BaseSimetric<T> BaseSimetric { get; private set; }

            /// <summary>
            /// Determines whether the specified objects are equal.
            /// </summary>
            /// <param name="x">The first object of type T to compare.</param>
            /// <param name="y">The second object of type T to compare.</param>
            /// <returns>true if the specified objects are equal; otherwise, false.</returns>
            public virtual bool Equals(T x, T y)
            {
                return this.BaseSimetric.AreEqual(x, y);
            }

            /// <summary>
            /// Returns a hash code for the specified object.
            /// </summary>
            /// <param name="obj">The Object for which a hash code is to be returned.</param>
            /// <returns>A hash code for the specified object.</returns>
            public int GetHashCode(T obj)
            {
                return obj == null ? 0 : obj.GetHashCode();
            }
        }
    }
}
