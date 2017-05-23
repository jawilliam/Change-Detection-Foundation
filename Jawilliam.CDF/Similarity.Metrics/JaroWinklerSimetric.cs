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
    /// Implements the Jaro-Winkler similarity metric
    /// </summary>
    [Serializable]
    public class JaroWinklerSimetric<T> : JaroSimetric<T> where T : IEquatable<T>
    {
        /// <summary>
        /// maximum prefix length to use.
        /// </summary>
        /// <remarks>changed from the original 6 to 4 to match the original definition of JaroWinklerSimetric Chris Parkinson .NET 2.0 implementation only</remarks>
        private const int MinPrefixTestLength = 4;

        /// <summary>
        /// Gets or sets the prefix adjustment scale.
        /// </summary>
        public virtual double PrefixAdjustmentScale { get; set; } = 0.1;

        /// <summary>
        /// gets the prefix length found of common characters at the begining of the strings.
        /// </summary>
        /// <param name="firstSeq"></param>
        /// <param name="secondSeq"></param>
        /// <returns>the prefix length found of common characters at the begining of the strings</returns>
        protected virtual int GetPrefixLength(T[] firstSeq, T[] secondSeq)
        {
            if (firstSeq.Any() && secondSeq.Any())
            {
                int n = Math.Min(MinPrefixTestLength, Math.Min(firstSeq.Length, secondSeq.Length));
                for (int i = 0; i < n; i++)
                {
                    if (!this.Comparer.Equals(firstSeq[i], secondSeq[i]))
                        return i;
                }

                return n;
            }
            return MinPrefixTestLength;
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

            if (firstSeq.Any() && secondSeq.Any())
            {
                var jaroSimilarity = base.GetSimilarity(firstSeq, secondSeq);
                var prefixLength = this.GetPrefixLength(firstSeq, secondSeq);

                return jaroSimilarity + prefixLength * PrefixAdjustmentScale * (1.0 - jaroSimilarity);
            }

            return 0.0;
        }
    }
}