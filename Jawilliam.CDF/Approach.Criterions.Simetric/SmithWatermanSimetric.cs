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
using Jawilliam.CDF.Approach.Criterions.Simetric;

namespace Jawilliam.CDF.Approach.Criterions.Simetric
{
    /// <summary>
    /// implements the Smith-Waterman edit distance function
    /// </summary>
    [Serializable]
    public class SmithWatermanSimetric<T> : SimpleSimetric<T> where T : IEquatable<T>
    {
        private ISubstitutionCost<T> _dCostFunction;

        /// <summary>
        /// Gets or sets the private cost function used in the levenshtein distance.
        /// </summary>
        public ISubstitutionCost<T> DCostFunction
        {
            get { return this._dCostFunction ?? (this._dCostFunction = new SubCostRange1ToMinus2<T> { AreEqual = (t1, t2) => this.AreEqual(t1, t2) }); }
            set { this._dCostFunction = value; }
        }

        /// <summary>
        /// the gap cost for the distance function.
        /// </summary>
        public virtual double GapCost { get; set; } = 0.5;

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

            double smithWaterman = this.GetSimilarity(firstSeq, secondSeq);
            double maxValue = Math.Min(firstSeq.Length, secondSeq.Length) * Math.Max(DCostFunction.MaxCost, - this.GapCost);
            distance = maxValue == 0 ? smithWaterman : maxValue - smithWaterman;

            return maxValue == 0 ? 0 : smithWaterman / maxValue;
        }

        private double GetSimilarity(T[] firstSequence, T[] secondSequence)
        {
            if (firstSequence.Any() && secondSequence.Any())
            {
                var d = new double[firstSequence.Length + 1][];
                for (var i = 0; i < firstSequence.Length + 1; i++)
                {
                    d[i] = new double[secondSequence.Length + 1];
                }

                double maxSoFar = 0;
                for (var i = 0; i < firstSequence.Length + 1; i++) d[i][0] = 0;
                for (var j = 0; j < secondSequence.Length + 1; j++) d[0][j] = 0;

                for (var i = 1; i <= firstSequence.Length; i++)
                {
                    for (var j = 1; j <= secondSequence.Length; j++)
                    {
                        var similarity = DCostFunction.GetCost(firstSequence, i - 1, secondSequence, j - 1);

                        d[i][j] = Math.Max(0, 
                            Math.Max(d[i - 1][j] - this.GapCost, 
                            Math.Max(d[i][j - 1] - this.GapCost, 
                            d[i - 1][j - 1] + similarity)));

                        if (d[i][j] > maxSoFar)
                            maxSoFar = d[i][j];
                    }
                }

                return maxSoFar;
            }

            if (firstSequence.Any() || secondSequence.Any())
            {
                if (firstSequence.Length == 0) return secondSequence.Length;
                if (secondSequence.Length == 0) return firstSequence.Length;
            }

            return 0.0;
        }
    }
}