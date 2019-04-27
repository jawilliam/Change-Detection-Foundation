using Jawilliam.CDF.Approach.Criterions;
using Jawilliam.CDF.Approach.Services;
using System.Collections.Generic;

namespace Jawilliam.CDF.Approach.Awareness
{
    /// <summary>
    /// Defines an element type logically suited to look for matching partners.
    /// </summary>
    /// <typeparam name="TElement">Base type of the elements supported by the solution.</typeparam>
    /// <remarks>For example, no punctuation or keyword token, would implement this logic since their matches are uniquely resolved by a pairwise change detection triggered starting from some partnership previously discovered.</remarks>
    public interface IPartnership<TElement>
    {
        /// <summary>
        /// Notifies that two comparing versions have been finally identified as a match (i.e., they are matching partners).
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        IEnumerable<MatchInfo<TElement>> Partners(TElement original, TElement modified, MatchingContext<TElement> context);
    }

    /// <summary>
    /// Defines an element type logically suited to look for matching partners.
    /// </summary>
    /// <typeparam name="TElement">Base type of the elements supported by the solution.</typeparam>
    /// <typeparam name="TOriginal">Specific type of the original element.</typeparam>
    /// <typeparam name="TModified">Specific type of the modified element.</typeparam>
    /// <remarks>For example, no punctuation or keyword token, would implement this logic since their matches are uniquely resolved by a pairwise change detection triggered starting from some partnership previously discovered.</remarks>
    public interface IPartnership<TElement, TOriginal, TModified>
    {
        /// <summary>
        /// Notifies that two comparing versions have been finally identified as a match (i.e., they are matching partners).
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        IEnumerable<MatchInfo<TElement>> Partners(TOriginal original, TModified modified, MatchingContext<TElement> context);
    }
}
