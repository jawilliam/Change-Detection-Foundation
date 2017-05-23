//#region Copyright
///*
// * The original .NET implementation of the SimMetrics library is taken from the Java
// * source and converted to NET using the Microsoft Java converter.
// * It is notclear who made the initial convertion to .NET.
// * 
// * This updated version has started with the 1.0 .NET release of SimMetrics and used
// * FxCop (http://www.gotdotnet.com/team/fxcop/) to highlight areas where changes needed 
// * to be made to the converted code.
// * 
// * this version with updates Copyright (c) 2006 Chris Parkinson.
// * 
// * For any queries on the .NET version please contact me through the 
// * sourceforge web address.
// * 
// * SimMetrics - SimMetrics is a java library of Similarity or Distance
// * Metrics, e.g. Levenshtein Distance, that provide float based similarity
// * measures between string Data. All metrics return consistant measures
// * rather than unbounded similarity scores.
// *
// * Copyright (C) 2005 Sam Chapman - Open Source Release v1.1
// *
// * Please Feel free to contact me about this library, I would appreciate
// * knowing quickly what you wish to use it for and any criticisms/comments
// * upon the SimMetric library.
// *
// * email:       s.chapman@dcs.shef.ac.uk
// * www:         http://www.dcs.shef.ac.uk/~sam/
// * www:         http://www.dcs.shef.ac.uk/~sam/stringmetrics.html
// *
// * address:     Sam Chapman,
// *              Department of Computer Science,
// *              University of Sheffield,
// *              Sheffield,
// *              S. Yorks,
// *              S1 4DP
// *              United Kingdom,
// *
// * This program is free software; you can redistribute it and/or modify it
// * under the terms of the GNU General Public License as published by the
// * Free Software Foundation; either version 2 of the License, or (at your
// * option) any later version.
// *
// * This program is distributed in the hope that it will be useful, but
// * WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY
// * or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License
// * for more details.
// *
// * You should have received a copy of the GNU General Public License along
// * with this program; if not, write to the Free Software Foundation, Inc.,
// * 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA
// */

///*Modified by jawilliam (jawilliam@gmail.com) to fix current project conventions: 
// namespaces, code guidelines (naming and mode...) */
//#endregion

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using Jawilliam.Data.Mining.Simetric;

//namespace Jawilliam.Data.Simetric
//{
//    /// <summary>
//    /// Implements the smith waterman with gotoh extension using a windowed affine gap.
//    /// </summary>
//    [Serializable]
//    public class SmithWatermanGotohWindowedAffine<T> : SimpleSimetric<T> where T : IEquatable<T>
//    {
//        private const double DefaultMismatchScore = 0.0;
//        private const double DefaultPerfectScore = 1.0;
//        private const int DefaultWindowSize = 100;

//        /// <summary>
//        /// the private cost function for affine gaps.
//        /// </summary>
//        private AbstractAffineGapCost _gGapFunction;

//        /// <summary>
//        /// private field for the maximum affine gap window size.
//        /// </summary>
//        public virtual int WindowSize { get; set; } = DefaultWindowSize; 

//        /// <summary>
//        /// gets the similarity of the two strings using Smith-Waterman-Gotoh distance.
//        /// </summary>
//        /// <param name="firstWord"></param>
//        /// <param name="secondWord"></param>
//        /// <returns>a value between 0-1 of the similarity</returns>
//        public override double GetSimilarity(IEnumerable<T> firstWord, IEnumerable<T> secondWord)
//        {
//            var firstSeq = firstWord?.ToArray() ?? new T[0];
//            var secondSeq = secondWord?.ToArray() ?? new T[0];

//            if ((firstWord != null) && (secondWord != null))
//            {
//                double smithWatermanGotoh = GetDistance(firstSeq, secondSeq);
//                double maxValue = Math.Min(firstSeq.Length, secondSeq.Length);
//                if (_dCostFunction.MaxCost > -_gGapFunction.MaxCost)
//                {
//                    maxValue *= _dCostFunction.MaxCost;
//                }
//                else {
//                    maxValue *= (-_gGapFunction.MaxCost);
//                }
//                if (maxValue == DefaultMismatchScore)
//                {
//                    return DefaultPerfectScore;
//                }
//                return smithWatermanGotoh / maxValue;
//            }
//            return DefaultMismatchScore;
//        }

//        /// <summary> 
//        /// gets the un-normalised similarity measure of the metric for the given strings.</summary>
//        /// <param name="firstWord"></param>
//        /// <param name="secondWord"></param>
//        /// <returns> returns the score of the similarity measure (un-normalised)</returns>
//        public virtual double GetDistance(T[] firstWord, T[] secondWord)
//        {
//            if (firstSeq.Any() && secondSeq.Any())
//            {
//                int n = firstSeq.Length;
//                int m = secondSeq.Length;
//                // check for zero length input
//                if (n == 0) return m;
//                if (m == 0) return n;

//                double[][] d = new double[n + 1][];
//                for (int i = 0; i < n; i++)
//                {
//                    d[i] = new double[m + 1];
//                }

//                //process first row and column first as no need to consider previous rows/columns
//                double maxSoFar = 0.0;
//                for (int i = 0; i < n; i++)
//                {
//                    // get the substution cost
//                    double cost = _dCostFunction.GetCost(firstSeq, i, secondSeq, 0);
//                    if (i == 0)
//                    {
//                        d[0][0] = Math.Max(DefaultMismatchScore, cost);
//                    }
//                    else
//                    {
//                        double maxGapCost = DefaultMismatchScore;
//                        int windowStart = i - WindowSize;
//                        if (windowStart < 1)
//                        {
//                            windowStart = 1;
//                        }
//                        for (int k = windowStart; k < i; k++)
//                        {
//                            maxGapCost = Math.Max(maxGapCost, d[i - k][0] - _gGapFunction.GetCost(firstSeq, i - k, i));
//                        }

//                        d[i][0] = MathFunctions.MaxOf3(DefaultMismatchScore, maxGapCost, cost);
//                    }
//                    //update max possible if available
//                    if (d[i][0] > maxSoFar)
//                    {
//                        maxSoFar = d[i][0];
//                    }
//                }

//                for (int j = 0; j < m; j++)
//                {
//                    // get the substution cost
//                    double cost = _dCostFunction.GetCost(firstSeq, 0, secondSeq, j);
//                    if (j == 0)
//                    {
//                        d[0][0] = Math.Max(DefaultMismatchScore, cost);
//                    }
//                    else {
//                        double maxGapCost = DefaultMismatchScore;
//                        int windowStart = j - WindowSize;
//                        if (windowStart < 1)
//                        {
//                            windowStart = 1;
//                        }
//                        for (int k = windowStart; k < j; k++)
//                        {
//                            maxGapCost = Math.Max(maxGapCost, d[0][j - k] - _gGapFunction.GetCost(secondWord, j - k, j));
//                        }

//                        d[0][j] = MathFunctions.MaxOf3(DefaultMismatchScore, maxGapCost, cost);
//                    }
//                    //update max possible if available
//                    if (d[0][j] > maxSoFar)
//                    {
//                        maxSoFar = d[0][j];
//                    }
//                }

//                // cycle through rest of table filling values from the lowest cost value of the three part cost function
//                for (int i = 1; i < n; i++)
//                {
//                    for (int j = 1; j < m; j++)
//                    {
//                        // get the substution cost
//                        double cost = _dCostFunction.GetCost(firstSeq, i, secondSeq, j);
//                        // find lowest cost at point from three possible
//                        double maxGapCost1 = DefaultMismatchScore;
//                        double maxGapCost2 = DefaultMismatchScore;
//                        int windowStart = i - WindowSize;
//                        if (windowStart < 1)
//                        {
//                            windowStart = 1;
//                        }
//                        for (int k = windowStart; k < i; k++)
//                        {
//                            maxGapCost1 = Math.Max(maxGapCost1, d[i - k][j] - _gGapFunction.GetCost(firstWord, i - k, i));
//                        }

//                        windowStart = j - WindowSize;
//                        if (windowStart < 1)
//                        {
//                            windowStart = 1;
//                        }
//                        for (int k = windowStart; k < j; k++)
//                        {
//                            maxGapCost2 = Math.Max(maxGapCost2, d[i][j - k] - _gGapFunction.GetCost(secondWord, j - k, j));
//                        }

//                        d[i][j] = MathFunctions.MaxOf4(DefaultMismatchScore, maxGapCost1, maxGapCost2, d[i - 1][j - 1] + cost);
//                        if (d[i][j] > maxSoFar)
//                        {
//                            maxSoFar = d[i][j];
//                        }
//                    }
//                }

//                // return max value within matrix as holds the maximum edit score
//                return maxSoFar;
//            }
//            return 0.0;
//        }

//        private ISubstitutionCost<T> _dCostFunction;

//        /// <summary>
//        /// Gets or sets the private cost function used in the levenshtein distance.
//        /// </summary>
//        public ISubstitutionCost<T> DCostFunction
//        {
//            get { return this._dCostFunction ?? (this._dCostFunction = new SubCostRange5ToMinus3<T> { AreEqual = (t1, t2) => this.Comparer.Equals(t1, t2) }); }
//            set { this._dCostFunction = value; }
//        }

//        /// <summary>
//        /// get the g gap cost function.
//        /// </summary>
//        public AbstractAffineGapCost GGapFunction { get { return _gGapFunction; } set { _gGapFunction = value; } }

//        /// <summary>
//        /// Compute the similarity value between two sequences.
//        /// </summary>
//        /// <param name="firstSequence">the first sequence to compare from.</param>
//        /// <param name="secondSequence">the second sequence to compare to.</param>
//        /// <param name="distance">if its sopported, returns the distance metric.</param>
//        /// <returns>a double between 0 and 1 (0 = no similarity, 1 = matching strings).</returns>
//        public override double GetSimilarity(IEnumerable<T> firstSequence, IEnumerable<T> secondSequence, out double? distance)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}