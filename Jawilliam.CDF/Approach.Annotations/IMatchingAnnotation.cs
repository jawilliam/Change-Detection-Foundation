using Jawilliam.CDF.Approach.Services;
using System.Collections.Generic;

namespace Jawilliam.CDF.Approach.Annotations
{
    /// <summary>
    /// Defines information related to the matching discovery.
    /// </summary>
    /// <typeparam name="TElement">Type of the supported elements.</typeparam>
    public interface IMatchingAnnotation<TElement>
    {
        /// <summary>
        /// Gets or sets the candidate matches of the extended element. 
        /// </summary>
        HashSet<MatchInfo<TElement>> Candidates { get; set; }

        /// <summary>
        /// Gets or sets the discovered match for the extended element. 
        /// </summary>
        MatchInfo<TElement> Match { get; set; }

        /// <summary>
        /// Gets the matching partner of the extended element or null if it does not have anyone yet. 
        /// </summary>
        TElement Partner { get; }
    }
}
