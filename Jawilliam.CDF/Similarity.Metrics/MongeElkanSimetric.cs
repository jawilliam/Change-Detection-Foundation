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

namespace Jawilliam.Data.Mining.Simetric
{
    /// <summary>
    /// Implements the monge-elkan similarity algorithm whereby vector space block distance is used to determine a similarity".
    /// </summary>
    /// <typeparam name="T">The concrete type of the elements to be compared.</typeparam>
    public class MongeElkanSimetric<T> : ISimetric<T> where T : IEquatable<T>
    {
        /// <summary>
        /// Internal similarity.
        /// </summary>
        private Func<T, T, double> _internalSimetric;

        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="internalSimetric">internal similarity metric.</param>
        public MongeElkanSimetric(Func<T, T, double> internalSimetric = null)
        {
            //if (internalSimetric == null)
            //    throw new ArgumentNullException(nameof(internalSimetric));

            this._internalSimetric = internalSimetric;
        }

        /// <summary>
        /// Gets or sets the internal simiarity metric.
        /// </summary>
        public virtual Func<T, T, double> InternalSimetric
        {
            get { return this._internalSimetric ?? (this._internalSimetric = (arg1, arg2) => EqualityComparer<T>.Default.Equals(arg1, arg2) ? 1 : 0); }
            set
            {
                if(value == null)
                    throw new ArgumentNullException();

                this._internalSimetric = value;
            }
        }

        /// <summary>
        /// Compute the similarity value between two sequences.
        /// </summary>
        /// <param name="firstSequence">the first seAquence to compare from.</param>
        /// <param name="secondSequence">the second sequence to compare to.</param>
        /// <returns>a double between 0 and 1 (0 = no similarity, 1 = matching strings).</returns>
        public virtual double GetSimilarity(IEnumerable<T> firstSequence, IEnumerable<T> secondSequence)
        {
            double? distance;
            var similarity = this.GetSimilarity(firstSequence, secondSequence, out distance);
            return similarity;
        }

        /// <summary>
        /// Compute the similarity value between two sequences.
        /// </summary>
        /// <param name="firstSequence">the first sequence to compare from.</param>
        /// <param name="secondSequence">the second sequence to compare to.</param>
        /// <param name="distance">if its sopported, returns the distance metric.</param>
        /// <returns>a double between 0 and 1 (0 = no similarity, 1 = matching strings).</returns>
        public virtual double GetSimilarity(IEnumerable<T> firstSequence, IEnumerable<T> secondSequence, out double? distance)
        {
            distance = null;
            var firstSeq = firstSequence?.ToArray() ?? new T[0];
            var secondSeq = secondSequence?.ToArray() ?? new T[0];
            if (firstSeq.Any() && secondSeq.Any())
            {
                return this.GetOrderedSimilarity(firstSeq, secondSeq);
            }
            return 0;
        }

        private double GetOrderedSimilarity(T[] firstSeq, T[] secondSeq)
        {
            double sumMatches = firstSeq.Sum(fToken => secondSeq.Max(sToken => this.InternalSimetric(fToken, sToken)));
            return sumMatches/firstSeq.Length;
        }
    }

    /// <summary>
    /// Implements the monge-elkan similarity algorithm whereby vector space block distance is used to determine a similarity.
    /// </summary>
    /// <typeparam name="T">The concrete type of the elements to be compared.</typeparam>
    public class MongeElkanMaxSimetric<T> : MongeElkanSimetric<T> where T : IEquatable<T>
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
            var first = firstSequence as T[] ?? firstSequence.ToArray();
            var second = secondSequence as T[] ?? secondSequence.ToArray();
            return Math.Max(base.GetSimilarity(first, second, out distance), 
                            base.GetSimilarity(second, first, out distance));
        }
    }

    /// <summary>
    /// Implements the monge-elkan similarity algorithm whereby vector space block distance is used to determine a similarity.
    /// </summary>
    /// <typeparam name="T">The concrete type of the elements to be compared.</typeparam>
    public class MongeElkanAvgSimetric<T> : MongeElkanSimetric<T> where T : IEquatable<T>
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
            var first = firstSequence as T[] ?? firstSequence.ToArray();
            var second = secondSequence as T[] ?? secondSequence.ToArray();
            return (base.GetSimilarity(first, second, out distance) +
                    base.GetSimilarity(second, first, out distance)) / 2;
        }
    }
}