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
using System.Collections.ObjectModel;

namespace Jawilliam.CDF.Metrics.Similarity
{
    ///// <summary>
    ///// implements a simple whitespace tokeniser. 
    ///// </summary>
    //[Serializable]
    //public class TokenizerWhitespace : ITokenizer<T>
    //{
    //    /// <summary>
    //    /// default constructor
    //    /// </summary>
    //    public TokenizerWhitespace() {
    //        _stopWordHandler = new DummyStopTermHandler();
    //        _tokenUtilities = new TokeniserUtilities<string>();
    //    }

    //    /// <summary>
    //    /// private delimiters for white space within a string.
    //    /// </summary>
    //    private const string _delimiters = "\r\n\t \x00A0";

    //    /// <summary>
    //    /// stopWordHandler used by the tokenisation.
    //    /// </summary>
    //    private ITermHandler _stopWordHandler;

    //    /// <summary>
    //    /// private utilities for token manipulation
    //    /// </summary>
    //    private readonly TokeniserUtilities<string> _tokenUtilities;

    //    /// <summary>
    //    /// Return tokenized version of a string.
    //    /// </summary>
    //    /// <param name="word">word to tokenize</param>
    //    /// <returns>tokenized version of a string</returns>
    //    public Collection<string> Tokenize(string word) {
    //        var returnVect = new Collection<string>();
    //        if (word != null) {
    //            int nextGapPos;
    //            for (int curPos = 0; curPos < word.Length; curPos = nextGapPos) {
    //                char ch = word[curPos];
    //                if (Char.IsWhiteSpace(ch)) {
    //                    curPos++;
    //                }
    //                nextGapPos = word.Length;
    //                for (int i = 0; i < _delimiters.Length; i++) {
    //                    int testPos = word.IndexOf(_delimiters[i], curPos);
    //                    if (testPos < nextGapPos && testPos != -1) {
    //                        nextGapPos = testPos;
    //                    }
    //                }

    //                string term = word.Substring(curPos, (nextGapPos) - (curPos));
    //                if (!_stopWordHandler.IsWord(term)) {
    //                    returnVect.Add(term);
    //                }
    //            }
    //        }
    //        return returnVect;
    //    }

    //    /// <summary>
    //    /// Return tokenized set of a string.
    //    /// </summary>
    //    /// <param name="word">input</param>
    //    /// <returns>tokenized set of a string</returns>
    //    public Collection<string> TokenizeToSet(string word)
    //    {
    //        return word != null ? _tokenUtilities.CreateSet(Tokenize(word)) : null;
    //    }

    //    /// <summary>
    //    /// displays the delimiters used.
    //    /// </summary>
    //    public string Delimiters => _delimiters;

    //    /// <summary>
    //    /// gets the stop word handler used.
    //    /// </summary>
    //    public ITermHandler StopWordHandler { get { return _stopWordHandler; } set { _stopWordHandler = value; } }
    //}
}