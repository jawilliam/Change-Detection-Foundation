#region Copyright
/*
 * The original .NET implementation of the SimMetrics library is taken from the Java
 * source and converted to NET using the Microsoft Java converter.
 * It is not clear who made the initial convertion to .NET.
 * 
 * This updated version has started with the 1.0 .NET release of SimMetrics and used
 * FxCop (http://www.gotdotnet.com/team/fxcop/) to highlight areas where changes needed 
 * to be made to the converted code.
 * 
 * this version with updates Copyright (c) 2006 Chris Parkinson.
 * 
 * For any queries on the .NET version please contact me through the 
 * sourceforge web address.
 * 
 * SimMetrics - SimMetrics is a java library of Similarity or Distance
 * Metrics, e.g. Levenshtein Distance, that provide float based similarity
 * measures between string Data. All metrics return consistant measures
 * rather than unbounded similarity scores.
 *
 * Copyright (C) 2005 Sam Chapman - Open Source Release v1.1
 *
 * Please Feel free to contact me about this library, I would appreciate
 * knowing quickly what you wish to use it for and any criticisms/comments
 * upon the SimMetric library.
 *
 * email:       s.chapman@dcs.shef.ac.uk
 * www:         http://www.dcs.shef.ac.uk/~sam/
 * www:         http://www.dcs.shef.ac.uk/~sam/stringmetrics.html
 *
 * address:     Sam Chapman,
 *              Department of Computer Science,
 *              University of Sheffield,
 *              Sheffield,
 *              S. Yorks,
 *              S1 4DP
 *              United Kingdom,
 *
 * This program is free software; you can redistribute it and/or modify it
 * under the terms of the GNU General Public License as published by the
 * Free Software Foundation; either version 2 of the License, or (at your
 * option) any later version.
 *
 * This program is distributed in the hope that it will be useful, but
 * WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY
 * or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License
 * for more details.
 *
 * You should have received a copy of the GNU General Public License along
 * with this program; if not, write to the Free Software Foundation, Inc.,
 * 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA
 */

/*Modified by jawilliam (jawilliam@gmail.com) to fix current project conventions: 
 namespaces, code guidelines (naming and mode...) */
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jawilliam.CDF.Approach.Criterions.Simetric
{
    /// <summary>
    /// Implements a N-Grams based similarity metric.
    /// </summary>
    [Serializable]
    public class NGramsSimetric<T> : IntegratedSimetric<T, NGram<T>> where T : IEquatable<T>
    {
        /// <summary>
        /// Gets or sets the size of grams (the "N" of the "N-Grams").
        /// </summary>
        public int N { get; }

        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="n">the size of grams (the "N" of the "N-Grams")</param>
        public NGramsSimetric(int n)
        {
            if(n <= 0)
                throw new ArgumentException(nameof(n));

            this.N = n;
        }

        /// <summary>
        /// Stores the value of <see cref="Comparer"/> property.
        /// </summary>
        private IEqualityComparer<T> _comparer;

        /// <summary>
        /// Gets the logic to support comparisons of objects for equality.
        /// </summary>
        public virtual IEqualityComparer<T> Comparer
        {
            get { return this._comparer ?? (this._comparer = EqualityComparer<T>.Default); }
            set { this._comparer = value; }
        }

        /// <summary>
        /// Computes n-grams for the given text.
        /// </summary>
        /// <param name="text">The text to get the n-grams from.</param>
        /// <returns>The enumeration of n-grams.</returns>
        public virtual IEnumerable<NGram<T>> NGrams(IEnumerable<T> text)
        {
            var chars = text.ToArray();
            for (var i = 0; i + this.N - 1 < chars.Length; i++)
            {
                IList<T> ngram = new List<T>(this.N);
                for (var j = 0; j < this.N; j++)
                {
                    ngram.Add(chars[i + j]);
                }
                yield return new NGram<T> { Elements = ngram.ToArray(), Comparer = this.Comparer };
            }
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

            var firstNGrams = firstSeq.Length >= this.N 
                ? this.NGrams(firstSeq).ToArray() 
                : new[] { new NGram<T> { Elements = firstSeq.ToArray(), Comparer = this.Comparer }};
            var secondNGrams = secondSeq.Length >= this.N
                ? this.NGrams(secondSeq).ToArray()
                : new[] { new NGram<T> { Elements = secondSeq.ToArray(), Comparer = this.Comparer } };

            return this.InternalSimetric.GetSimilarity(firstNGrams, secondNGrams, out distance);
        }

        /// <summary>
        /// Gets or sets the similarity metric internally used.
        /// </summary>
        public override ISimetric<NGram<T>> InternalSimetric
        {
            get { return this._internalSimetric ?? (this._internalSimetric = new DefaultSimetric()); }
            set { this._internalSimetric = value; }
        }

        public class DefaultSimetric : SimpleSimetric<NGram<T>>
        {
            /// <summary>
            /// Compute the similarity value between two sequences.
            /// </summary>
            /// <param name="firstSequence">the first sequence to compare from.</param>
            /// <param name="secondSequence">the second sequence to compare to.</param>
            /// <param name="distance">if its sopported, returns the distance metric.</param>
            /// <returns>a double between 0 and 1 (0 = no similarity, 1 = matching strings).</returns>
            public override double GetSimilarity(IEnumerable<NGram<T>> firstSequence, IEnumerable<NGram<T>> secondSequence, out double? distance)
            {
                var firstSeq = firstSequence?.ToArray() ?? new NGram<T>[0];
                var secondSeq = secondSequence?.ToArray() ?? new NGram<T>[0];
                distance = null;
                if (!firstSeq.Any() && !secondSeq.Any())
                    return 1;

                var uniqueNGrams = firstSeq.Union(secondSeq, this.Comparer).ToArray();

                var firstFrequencies = uniqueNGrams.Select(t => firstSeq.Count(ts => ts.Equals(t))).ToArray();
                var secondFrequencies = uniqueNGrams.Select(t => secondSeq.Count(ts => ts.Equals(t))).ToArray();
                if (uniqueNGrams.Length > 0)
                {
                    distance = firstFrequencies.Select((t, i) => Math.Abs(t - secondFrequencies[i])).Sum();
                    double total = firstSeq.Length + secondSeq.Length;
                    return 1 - distance.Value / total;
                }

                return 0;
            }
        }
    }

    /// <summary>
    /// Represents a gram.
    /// </summary>
    public class NGram<T> : IEquatable<NGram<T>>
    {
        /// <summary>
        /// Stores the value of <see cref="Comparer"/> property.
        /// </summary>
        private IEqualityComparer<T> _comparer;

        /// <summary>
        /// Gets the logic to support comparisons of objects for equality.
        /// </summary>
        public virtual IEqualityComparer<T> Comparer
        {
            get { return this._comparer ?? (this._comparer = EqualityComparer<T>.Default); }
            set { this._comparer = value; }
        }

        /// <summary>
        /// Stores the value of the <see cref="Elements"/> property.
        /// </summary>
        private T[] _elements;

        /// <summary>
        /// Gets or sets the elements composing the N-Grams.
        /// </summary>
        public virtual T[] Elements
        {
            get { return this._elements ?? (this._elements = new T[0]);}
            set { this._elements = value; }
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public virtual bool Equals(NGram<T> other)
        {
            if(other.Elements.Length != this.Elements.Length)
                return false;

            return !this.Elements.Where((t, i) => !this.Comparer.Equals(t, other.Elements[i])).Any();
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            StringBuilder text = new StringBuilder(this.Elements.Length);
            foreach (var element in Elements)
            {
                text.Append(element);
            }

            return text.ToString();
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <returns>
        /// true if the specified object  is equal to the current object; otherwise, false.
        /// </returns>
        /// <param name="obj">The object to compare with the current object. </param><filterpriority>2</filterpriority>
        public override bool Equals(object obj)
        {
            if (obj == null || this.GetType() != obj.GetType()) return false;
            return this.Equals((NGram<T>)obj);
        }

        /// <summary>
        /// Serves as the default hash function. 
        /// </summary>
        /// <returns>
        /// A hash code for the current object.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override int GetHashCode()
        {
            const int b = 378551;
            int a = 63689;
            int hash = 0;

            // If it overflows then just wrap around
            unchecked
            {
                foreach (T t in this.Elements)
                {
                    if (!this.Comparer.Equals(t, default(T)))
                    {
                        hash = hash * a + this.Comparer.GetHashCode(t);
                        a = a * b;
                    }
                }
            }

            return hash;
        }
    }
}