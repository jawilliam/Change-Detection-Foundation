using System.Collections.Generic;

namespace Jawilliam.CDF.Approach
{
    ///// <summary>
    ///// Defines an approach or algorithm of change detection.
    ///// </summary>
    ///// <typeparam name="TArgs">Concrete type of the arguments.</typeparam>
    //public interface IApproach<TArgs> : IProcedure<TArgs, DetectionResult>
    //{
    //}

    /// <summary>
    /// Defines an approach or algorithm for source code change detection.
    /// </summary>
    /// <typeparam name="TElement">Type of the supported elements.</typeparam>
    /// <typeparam name="TRevision">Type of the comparing versions.</typeparam>
    public interface IApproach<TElement, TRevision> : IProcedure<LoadRevisionPairDelegate<TRevision>, DetectionResult<TRevision>>
    {
        /// <summary>
        /// Gets the heuristics to execute in the current step.
        /// </summary>
        long Step { get; }

        /// <summary>
        /// Gets the list of choices that will be executed as part of a change detection.
        /// </summary>
        IList<IChoice<TElement, TRevision>> Choices { get; }

        /// <summary>
        /// Gets the structure to store the matches.
        /// </summary>
        MatchingInfo<TElement> MatchingInfo { get; }

        /// <summary>
        /// Gets a typed service in case some one exists.
        /// </summary>
        /// <typeparam name="TService">the type of the requested service.</typeparam>
        /// <returns>a typed service in case some one exists, otherwise returns null</returns>
        TService GetService<TService>();

        /// <summary>
        /// Gets a typed service in case some one exists.
        /// </summary>
        /// <typeparam name="TService">the type of the requested service.</typeparam>
        /// <returns>a typed service in case some one exists, otherwise throws an exception.</returns>
        TService GetServiceOrThrowsException<TService>();
    }
}
