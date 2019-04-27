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

    ///// <summary>
    ///// Defines a matching criterion.
    ///// </summary>
    ///// <typeparam name="TElement">Type of the supported elements.</typeparam>
    //public interface IMatcher<TElement>
    //{
    //    /// <summary>
    //    /// Discovers the candidate matches of a given node.
    //    /// </summary>
    //    /// <param name="original">the original version.</param>
    //    /// <param name="originalContext">the original context (e.g., the root of the original AST).</param>
    //    /// <param name="modifiedContext">the modified context (e.g., the root of the modified AST).</param>
    //    /// <returns>candidate matches for the given node.</returns>
    //    IEnumerable<MatchInfo<TElement>> Matches(TElement original, TElement originalContext, TElement modifiedContext);

    //    /// <summary>
    //    /// Tries to identify a best match among multiple candidate matches. 
    //    /// </summary>
    //    /// <param name="candidates">candidate matches.</param>
    //    /// <param name="originalContext">the original context (e.g., the root of the original AST).</param>
    //    /// <param name="modifiedContext">the modified context (e.g., the root of the modified AST).</param>
    //    /// <returns>the best match if it was possible to identify some one, null otherwise.</returns>
    //    MatchInfo<TElement> TieBreak(IEnumerable<MatchInfo<TElement>> candidates, TElement originalContext, TElement modifiedContext);

    //    /// <summary>
    //    /// Notifies that two comparing versions have been finally identified as a match (i.e., they are matching partners).
    //    /// </summary>
    //    /// <param name="original">the original version.</param>
    //    /// <param name="modified">the modified version.</param>
    //    /// <param name="originalContext">the original context (e.g., the root of the original AST).</param>
    //    /// <param name="modifiedContext">the modified context (e.g., the root of the modified AST).</param>
    //    /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
    //    IEnumerable<MatchInfo<TElement>> Partners(TElement original, TElement modified, TElement originalContext, TElement modifiedContext);
    //}
}
