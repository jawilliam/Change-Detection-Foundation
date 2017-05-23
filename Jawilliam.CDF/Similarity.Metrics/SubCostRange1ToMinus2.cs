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

namespace Jawilliam.Data.Simetric
{
    /// <summary>
    /// Implements a substitution cost function where d(i,j) = 1 if i does not equal j, -2 if i equals j.
    /// </summary>
    /// <typeparam name="T">The concrete type of the elements to be compared.</typeparam>
    [Serializable]
    public class SubCostRange1ToMinus2<T> : ISubstitutionCost<T> where T: IEquatable<T>
    {
        private const int CharExactMatchScore = 1;
        private const int CharMismatchMatchScore = -2;

        /// <summary>
        /// Gets or sets the function to indicate whether or not the two given objects are equals.
        /// </summary>
        public virtual Func<T, T, bool> AreEqual { get; set; }

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
            if ((firstSequence != null) && (secondSequence != null))
            {
                if (firstSequence.Count <= firstSequenceIndex || firstSequenceIndex < 0)
                    return CharMismatchMatchScore;
                
                if (secondSequence.Count <= secondSequenceIndex || secondSequenceIndex < 0)
                    return CharMismatchMatchScore;
                
                return !areEqual(firstSequence[firstSequenceIndex], secondSequence[secondSequenceIndex])
                    ? CharMismatchMatchScore 
                    : CharExactMatchScore;
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