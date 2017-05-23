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
 namespaces, code guidelines (naming and mode...). Estimation of time has been remmoved and
 the logic has been abstracted to not text sequences too.*/
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using Jawilliam.Data.Simetric;

namespace Jawilliam.Data.Mining.Simetric
{
    /// <summary>
    /// Implements the Levenshtein similarity metric.
    /// </summary>
    /// <typeparam name="T">The concrete type of the elements to be compared.</typeparam>
    public class LevenshteinSimetric<T> : SimpleSimetric<T> where T : IEquatable<T>
    {
        private ISubstitutionCost<T> _dCostFunction;

        /// <summary>
        /// Gets or sets the private cost function used in the levenshtein distance.
        /// </summary>
        public ISubstitutionCost<T> DCostFunction
        {
            get { return this._dCostFunction ?? (this._dCostFunction = new SubCostRange0To1<T> { AreEqual = (t1, t2) => this.Comparer.Equals(t1, t2)}); }
            set { this._dCostFunction = value; }
        }

        /// <summary>
        /// Computes the Levenshtein distance value between two sequences.
        /// </summary>
        /// <param name="firstSequence">the first sequence to compare from.</param>
        /// <param name="secondSequence">the second sequence to compare to.</param>
        /// <returns>a double between 0 and 1 (0 = no similarity, 1 = matching strings).</returns>
        /// <remarks>
        /// <p/>
        /// Copy character from string1 over to string2 (cost 0)
        /// Delete a character in string1 (cost 1)
        /// Insert a character in string2 (cost 1)
        /// Substitute one character for another (cost 1)
        /// <p/>
        /// D(i-1,j-1) + d(si,tj) //subst/copy
        /// D(i,j) = min D(i-1,j)+1 //insert
        /// D(i,j-1)+1 //delete
        /// <p/>
        /// d(i,j) is a function whereby d(c,d)=0 if c=d, 1 else.
        /// </remarks>
        public virtual double GetDistance(IList<T> firstSequence, IList<T> secondSequence)
        {
            if (firstSequence != null && firstSequence.Any() && secondSequence != null && secondSequence.Any())
            {
                // Step 1
                var n = firstSequence.Count;
                var m = secondSequence.Count;
                if (n == 0) return m;
                if (m == 0) return n;

                if (firstSequence.Count > secondSequence.Count)
                {
                    var temp = secondSequence;
                    secondSequence = firstSequence;
                    firstSequence = temp;

                    n = firstSequence.Count;
                    m = secondSequence.Count;
                }

                var distance = new double[2, m + 1];
                
                // Initialize the distance 'matrix'
                for (var j = 1; j <= m; j++) distance[0, j] = j;

                var currentRow = 0;
                for (var i = 1; i <= n; ++i)
                {
                    currentRow = i & 1;
                    distance[currentRow, 0] = i;
                    var previousRow = currentRow ^ 1;
                    for (var j = 1; j <= m; j++)
                    {
                        var cost = DCostFunction.GetCost(firstSequence, i - 1, secondSequence, j - 1); // Step 5
                        distance[currentRow, j] = Math.Min(Math.Min(distance[previousRow, j] + 1, distance[currentRow, j - 1] + 1), distance[previousRow, j - 1] + cost);
                    }
                }
                return distance[currentRow, m];
            }

            if (firstSequence != null && firstSequence.Any())
                return firstSequence.Count;

            if (secondSequence != null && secondSequence.Any())
                return secondSequence.Count;

            return 0.0;
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

            distance = this.GetDistance(firstSeq, secondSeq);
            if (!firstSeq.Any() && !secondSeq.Any())
                return 1;

            var length = Math.Max(firstSeq.Length, secondSeq.Length);
            return 1 - distance.Value / length;
        }
    }
}