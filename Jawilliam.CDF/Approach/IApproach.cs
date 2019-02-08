using System.Collections.Generic;
using System.IO;

namespace Jawilliam.CDF.Approach
{
    /// <summary>
    /// Defines an approach or algorithm of change detection.
    /// </summary>
    /// <typeparam name="TArgs">Concrete type of the arguments.</typeparam>
    public interface IApproach<TArgs> : IProcedure<TArgs, DetectionResult>
    {
    }

    /// <summary>
    /// Defines an approach or algorithm of change detection.
    /// </summary>
    /// <typeparam name="T">Type of the supported elements.</typeparam>
    public interface IFrameworkApproach<T> : IApproach<RevisionPair<TextReader>>
    {
        /// <summary>
        /// Gets the heuristics to execute in the current step.
        /// </summary>
        long Step { get; }

        /// <summary>
        /// Gets the list of choices that will be executed as part of a change detection.
        /// </summary>
        IList<IChoice<T>> Choices { get; }

        /// <summary>
        /// Gets the structure to store the matches.
        /// </summary>
        MatchingInfo<T> MatchingInfo { get; }
    }
}
