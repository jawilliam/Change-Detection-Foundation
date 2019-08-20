using Jawilliam.CDF.Approach.Criterions;
using Jawilliam.CDF.Approach.Services;
using System.Collections.Generic;

namespace Jawilliam.CDF.Approach.Awareness
{
    ///// <summary>
    ///// Defines logic for pairwise change detection, i.e., considering that two elements have been already matched, which matches among their descendants can be taken for granted.
    ///// </summary>
    ///// <typeparam name="TElement">Base type of the elements supported by the solution.</typeparam>
    //public interface IPairwisable<TElement>
    //{
    //    ///// <summary>
    //    ///// Notifies that two given elements have been definitively matched.
    //    ///// </summary>
    //    ///// <param name="original">original element.</param>
    //    ///// <param name="modified">modified element.</param>
    //    ///// <param name="approach">solution being executed.</param>
    //    //void Partners(IApproach<TElement> approach, TElement original, TElement modified);

    //    ///// <summary>
    //    ///// Notifies that two comparing versions have been finally identified as a match (i.e., they are matching partners).
    //    ///// </summary>
    //    ///// <param name="original">the original version.</param>
    //    ///// <param name="modified">the modified version.</param>
    //    ///// <param name="context">the context wherein certain matching criterion is currently running.</param>
    //    ///// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
    //    //IEnumerable<MatchInfo<TElement>> Partners(TElement original, TElement modified, MatchingContext<TElement> context);
    //}

    /// <summary>
    /// Defines logic for pairwise change detection, i.e., considering that two especifically typed elements have been already matched, which matches among their descendants can be taken for granted.
    /// </summary>
    /// <typeparam name="TElement">Base type of the elements supported by the solution.</typeparam>
    /// <typeparam name="TOriginal">Specific type of the original element.</typeparam>
    /// <typeparam name="TModified">Specific type of the modified element.</typeparam>
    public interface IPairwisable<TElement, TOriginal, TModified>
    {
        /// <summary>
        /// Notifies that two given versions have been definitively matched.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        /// <param name="context">the context wherein the matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        IEnumerable<MatchInfo<TElement>> Partners(MatchingContext<TElement> context, TOriginal original, TModified modified);
    }
}
