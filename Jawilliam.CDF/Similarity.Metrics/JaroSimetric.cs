#region Copyright
/*
 * The original .NET implementation of the SimMetrics library is taken from the Java
 * source and converted to NET using the Microsoft Java converter.
 * It is notclear who made the initial convertion to .NET.
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

namespace Jawilliam.CDF.Similarity.Metrics
{
    /// <summary>
    /// implements the JaroSimetric string Metric.
    /// </summary>
    [Serializable]
    public class JaroSimetric<T> : SimpleSimetric<T> where T : IEquatable<T>
    {
        /// <summary>
        /// returns a string buffer of characters from string1 within string2 if they are of a given
        /// distance seperation from the position in string1.
        /// </summary>
        /// <param name="firstSeq">string one</param>
        /// <param name="secondSeq">string two</param>
        /// <param name="distanceSep">separation distance</param>
        /// <returns>a string buffer of characters from string1 within string2 if they are of a given
        /// distance seperation from the position in string1</returns>
        protected virtual IEnumerable<T> GetCommonFrom(T[] firstSeq, T[] secondSeq, int distanceSep)
        {
            if (!firstSeq.Any() && !secondSeq.Any())
                return new T[0];

            var commons = new List<T>(firstSeq.Length);
            var copy = new T[secondSeq.Length];
            var matched = new bool[secondSeq.Length];
            secondSeq.CopyTo(copy, 0);
            for (var i = 0; i < firstSeq.Length; i++)
            {
                T ch = firstSeq[i];
                for (var j = Math.Max(0, i - distanceSep); j <= Math.Min(i + distanceSep, copy.Length - 1); j++)
                {
                    if (this.Comparer.Equals(copy[j], ch) && !matched[j])
                    {
                        commons.Add(ch);
                        matched[j] = true;
                        break;
                    }
                }
            }

            return commons;
        }

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

            //get half the length of the string rounded up - (this is the distance used for acceptable transpositions)
            int halflen = Math.Max(0, Math.Max(firstSeq.Length, secondSeq.Length) / 2 - 1);
            //get common characters
            var commonFromFirstToSecond = this.GetCommonFrom(firstSeq, secondSeq, halflen).ToArray();
            //check for zero in common
            if (commonFromFirstToSecond.Length == 0)
            {
                return 0;
            }
            var commonFromSecondToFirst = this.GetCommonFrom(secondSeq, firstSeq, halflen).ToArray();
            //check for same length common strings returning 0.0f is not the same
            if (commonFromFirstToSecond.Length != commonFromSecondToFirst.Length)
            {
                return 0;
            }
            //get the number of transpositions
            int transpositions = commonFromFirstToSecond.Where((t, i) => !this.Comparer.Equals(t, commonFromSecondToFirst[i])).Count();

            //calculate jaro metric
            transpositions /= 2;
            double oneNorm = (double)commonFromFirstToSecond.Length / firstSeq.Length;
            var twoNorm = (double)commonFromFirstToSecond.Length / secondSeq.Length;
            var transNorm = ((double)commonFromFirstToSecond.Length - transpositions) / commonFromFirstToSecond.Length;
            return 1 / 3.0 * (oneNorm + twoNorm + transNorm);
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
            distance = 1 - similarity;
            return similarity;
        }
    }
}