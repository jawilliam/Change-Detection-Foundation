//#region Copyright
///* This new class in the .NET version holds utility functions for use with the
// * various Collection<T> token collections.
// * 
// * (c) Chris Parkinson 2006.
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
//using System.Collections.ObjectModel;
//using System.Linq;

//namespace Jawilliam.CDF.Approach.Criterions.Simetric
//{
//    /// <summary>
//    /// Class containing utility functions for the tokenisers to use. These are in two main version
//    /// collections or sets a collection can contain the same value multiple times ad set can only have the value once.
//    /// </summary>
//    /// <typeparam name="T">type for token collection</typeparam>
//    [Serializable]
//    public class TokeniserUtilities<T> where T : IEquatable<T> {
//        /// <summary>
//        /// constructor
//        /// </summary>
//        public TokeniserUtilities() {
//            MergedTokens = new Collection<T>();
//            TokenSet = new Collection<T>();
//        }

//        /// <summary>
//        /// returns the number of common tokens from the two supplied token sets
//        /// </summary>
//        /// <returns></returns>
//        public int CommonSetTerms() {
//            return FirstSetTokenCount + SecondSetTokenCount - TokenSet.Count;
//        }

//        /// <summary>
//        /// returns number of common tokens from the two supplied token collections
//        /// </summary>
//        /// <returns></returns>
//        public int CommonTerms() {
//            return FirstTokenCount + SecondTokenCount - MergedTokens.Count;
//        }

//        /// <summary>
//        ///  method to merge two token lists to keep all tokens
//        /// </summary>
//        /// <param name="firstTokens">first token list</param>
//        /// <param name="secondTokens">second token list</param>
//        /// <returns>list of all tokens</returns>
//        public Collection<T> CreateMergedList(Collection<T> firstTokens, Collection<T> secondTokens) {
//            MergedTokens.Clear();
//            FirstTokenCount = firstTokens.Count;
//            SecondTokenCount = secondTokens.Count;
//            MergeLists(firstTokens);
//            MergeLists(secondTokens);
//            return MergedTokens;
//        }

//        /// <summary>
//        ///  method to merge two token lists to keep only unique tokens
//        /// </summary>
//        /// <param name="firstTokens">first token list</param>
//        /// <param name="secondTokens">second token list</param>
//        /// <returns>list of unique tokens</returns>
//        public Collection<T> CreateMergedSet(Collection<T> firstTokens, Collection<T> secondTokens) {
//            TokenSet.Clear();
//            FirstSetTokenCount = firstTokens.Distinct().Count();
//            SecondSetTokenCount = secondTokens.Distinct().Count();
//            MergeIntoSet(firstTokens);
//            MergeIntoSet(secondTokens);
//            return TokenSet;
//        }

//        /// <summary>
//        ///  method to create a single token list of unique tokens
//        /// </summary>
//        /// <param name="tokenList">token list to use</param>
//        /// <returns>unique token list - sorted</returns>
//        public Collection<T> CreateSet(Collection<T> tokenList) {
//            TokenSet.Clear();
//            AddUniqueTokens(tokenList);
//            FirstTokenCount = TokenSet.Count;
//            SecondTokenCount = 0;
//            return TokenSet;
//        }

//        /// <summary>
//        /// method for merging extra token lists into the set
//        /// </summary>
//        /// <param name="firstTokens">token list to merge</param>
//        public void MergeIntoSet(Collection<T> firstTokens) {
//            AddUniqueTokens(firstTokens);
//        }

//        /// <summary>
//        /// method for merging into the list
//        /// </summary>
//        /// <param name="firstTokens">token list to merge</param>
//        public void MergeLists(Collection<T> firstTokens) {
//            AddTokens(firstTokens);
//        }

//        void AddTokens(Collection<T> tokenList) {
//            foreach (var token in tokenList) {
//                MergedTokens.Add(token);
//            }
//        }

//        void AddUniqueTokens(Collection<T> tokenList)
//        {
//            foreach (var token in tokenList.Where(token => !TokenSet.Contains(token)))
//            {
//                TokenSet.Add(token);
//            }
//        }

//        //int CalculateUniqueTokensCount(Collection<T> tokenList) {
//        //    var myList = new Collection<T>();
//        //    foreach (var token in tokenList.Where(token => !myList.Contains(token)))
//        //    {
//        //        myList.Add(token);
//        //    }
//        //    return myList.Count;
//        //}

//        /// <summary>
//        /// token count from first token list
//        /// </summary>
//        public int FirstSetTokenCount { get; private set; }

//        /// <summary>
//        /// token count from first token list
//        /// </summary>
//        public int FirstTokenCount { get; private set; }

//        /// <summary>
//        /// merged token List. unique tokens only
//        /// </summary>
//        public Collection<T> MergedTokens { get; }

//        /// <summary>
//        /// token count from second token list
//        /// </summary>
//        public int SecondSetTokenCount { get; private set; }

//        /// <summary>
//        /// token count from second token list
//        /// </summary>
//        public int SecondTokenCount { get; private set; }

//        /// <summary>
//        /// merged token List. unique tokens only
//        /// </summary>
//        public Collection<T> TokenSet { get; }
//    }
//}