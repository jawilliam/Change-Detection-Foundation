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
 * measures between String Data. All metrics return consistant measures
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
using System.Collections.ObjectModel;
using System.Linq;

namespace Jawilliam.CDF.Similarity.Metrics
{
    /// <summary>
    /// Implements a cost function as used in Monge Elkan where by an exact match
    /// no match or an approximate match whereby a set of characters are in an approximate range.
    /// for pairings in {dt} {gj} {lr} {mn} {bpv} {aeiou} {,.}
    /// </summary>
    /// <typeparam name="T">The concrete type of the elements to be compared.</typeparam>
    [Serializable]
    public class SubCostRange5ToMinus3<T> : ISubstitutionCost<T> where T: IEquatable<T>
    {
        private const int CharApproximateMatchScore = 3;
        private const int CharExactMatchScore = 5;
        private const int CharMismatchMatchScore = -3;

        /// <summary>
        /// Gets or sets the function to indicate whether or not the two given objects are equals.
        /// </summary>
        public virtual Func<T, T, bool> AreEqual { get; set; }

        /// <summary>
        /// Initializes the instance by setting up the matching sets
        /// approximate match = +3, for pairings in {dt} {gj} {lr} {mn} {bpv} {aeiou} {,.}.
        /// </summary>
        public SubCostRange5ToMinus3()
        {
            _approx = new Collection<string>[7];
            _approx[0] = new Collection<string> { "d", "t" };
            _approx[1] = new Collection<string> { "g", "j" };
            _approx[2] = new Collection<string> { "l", "r" };
            _approx[3] = new Collection<string> { "m", "n" };
            _approx[4] = new Collection<string> { "b", "p", "v" };
            _approx[5] = new Collection<string> { "a", "e", "i", "o", "u" };
            _approx[6] = new Collection<string> { ",", "." };
        }

        /// <summary>
        /// approximate character set.
        /// </summary>
        private readonly Collection<string>[] _approx;

        /// <summary>
        /// Gets the cost between elements.
        /// </summary>
        /// <param name="firstSequence">the first sequence to evaluate the cost.</param>
        /// <param name="firstSequenceIndex">the index within the first sequence to test</param>
        /// <param name="secondSequence">the second sequence to evaluate the cost</param>
        /// <param name="secondSequenceIndex">the index within the second sequence to test</param>
        /// <returns>the cost between the elements at the given indexes of the given sequences.</returns>
        public virtual double GetCost(IList<T> firstSequence, int firstSequenceIndex, IList<T> secondSequence, int secondSequenceIndex)
        {
            var areEqual = this.AreEqual ?? ((t1, t2) => object.Equals(t1, t2));
            if (firstSequence.Count != 0 && secondSequence.Count != 0)
            {
                if (firstSequence.Count <= firstSequenceIndex || firstSequenceIndex < 0)
                    return CharMismatchMatchScore;
                
                if (secondSequence.Count <= secondSequenceIndex || secondSequenceIndex < 0)
                    return CharMismatchMatchScore;
                
                if (areEqual(firstSequence[firstSequenceIndex], secondSequence[secondSequenceIndex]))
                    return CharExactMatchScore;

                /// TODO: Tener en cuenta en los elementos a comparar la capacidad de redefinir el ToString segun convenga.
                /// TODO: Valorar en esos casos cuál seria el mejor comportamiento: "Value" o "Signature".
                var si = firstSequence[firstSequenceIndex].ToString().ToLowerInvariant();
                var ti = secondSequence[secondSequenceIndex].ToString().ToLowerInvariant();
                if (_approx.Any(t => t.Contains(si) && t.Contains(ti)))
                    return CharApproximateMatchScore;
            }
            return CharMismatchMatchScore;
        }

        /// <summary>
        /// Gets the maximum possible cost.
        /// </summary>
        public double MaxCost => CharExactMatchScore;

        /// <summary>
        /// Gets the minimum possible cost.
        /// </summary>
        public double MinCost => CharMismatchMatchScore;
    }
}