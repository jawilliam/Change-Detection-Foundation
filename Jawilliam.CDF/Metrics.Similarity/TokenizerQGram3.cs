//#region Copyright
///* This new class in the .NET version holds a Bigram implementation.
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

//using System.Collections.ObjectModel;

//namespace Jawilliam.CDF.Metrics.Similarity
//{
//    /// <summary>
//    /// implementaton of the Bigram tokeniser
//    /// </summary>
//    public class TokenizerQGram3 : AbstractTokenizerQGramN
//    {
//        /// <summary>
//        /// constructor
//        /// </summary>
//        public TokenizerQGram3() {
//            StopWordHandler = new DummyStopTermHandler();
//            TokenUtilities = new TokeniserUtilities<string>();
//            CharacterCombinationIndex = 0;
//            QGramLength = 3;
//        }

//        /// <summary>
//        /// Return tokenized version of a string.
//        /// </summary>
//        /// <param name="word">input</param>
//        /// <returns>tokenized version of a string</returns>
//        public override Collection<string> Tokenize(string word) {
//            return Tokenize(word, false, QGramLength, CharacterCombinationIndex);
//        }
//    }
//}