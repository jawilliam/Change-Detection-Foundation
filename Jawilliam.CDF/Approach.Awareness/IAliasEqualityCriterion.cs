using Jawilliam.CDF.Approach.Criterions;
using Jawilliam.CDF.Approach.Services;

namespace Jawilliam.CDF.Approach.Awareness
{
    /// <summary>
    /// Defines a same alias-based matching criterion. 
    /// </summary>
    /// <typeparam name="TElement">Base type of the elements supported by the solution.</typeparam>
    /// <typeparam name="TOriginal">Specific type of the original element.</typeparam>
    /// <typeparam name="TModified">Specific type of the modified element.</typeparam>
    public interface IAliasEqualityCriterion<TElement, TOriginal, TModified>
    {
        /// <summary>
        /// Determines if two elements are alias-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>true if the given elements are alias-based exactly equal, otherwise returns false.</returns>
        /// <param name="matchingDescription">in case the given elements are alias-based exactly equal, this parameter will contain the corresponding matching description.</param>
        bool AliasEqualityMatch(TOriginal original, TModified modified, MatchingContext<TElement> context, out MatchInfo<TElement> matchingDescription);
    }
}
