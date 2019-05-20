using Jawilliam.CDF.Approach.Services;
using System.Collections.Generic;

namespace Jawilliam.CDF.Approach.Criterions
{
    /// <summary>
    /// Defines a matching criterion.
    /// </summary>
    /// <typeparam name="TElement">Type of the supported elements.</typeparam>
    public interface IMatcher<TElement>
    {
        /// <summary>
        /// Discovers the candidate matches of a given node.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>candidate matches for the given node.</returns>
        IEnumerable<MatchInfo<TElement>> Matches(TElement original, MatchingContext<TElement> context);

        /// <summary>
        /// Tries to identify a best match among multiple candidate matches. 
        /// </summary>
        /// <param name="candidates">candidate matches.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>the best match if it was possible to identify some one, null otherwise.</returns>
        MatchInfo<TElement> TieBreak(IEnumerable<MatchInfo<TElement>> candidates, MatchingContext<TElement> context);

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
    /// Defines a matching criterion.
    /// </summary>
    /// <typeparam name="TElement">Base type of the elements supported by the solution.</typeparam>
    /// <typeparam name="TOriginal">Specific type of the original element.</typeparam>
    /// <typeparam name="TModified">Specific type of the modified element.</typeparam>
    public interface IMatcher<TElement, TOriginal, TModified> where TOriginal : TElement where TModified : TElement
    {
        /// <summary>
        /// Discovers the candidate matches of a given node.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>candidate matches for the given node.</returns>
        IEnumerable<MatchInfo<TElement>> Matches(TOriginal original, MatchingContext<TElement> context);

        /// <summary>
        /// Tries to identify a best match among multiple candidate matches. 
        /// </summary>
        /// <param name="candidates">candidate matches.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>the best match if it was possible to identify some one, null otherwise.</returns>
        MatchInfo<TElement> TieBreak(IEnumerable<MatchInfo<TElement>> candidates, MatchingContext<TElement> context);

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
