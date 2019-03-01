using System.Collections.Generic;

namespace Jawilliam.CDF.Approach
{
    /// <summary>
    /// Defines an approach or algorithm for source code change detection.
    /// </summary>
    /// <typeparam name="TElement">Type of the supported elements.</typeparam>
    public interface IApproach<TElement> : IProcedure<LoadRevisionPairDelegate<TElement>, DetectionResult<TElement>>, IServiceLocator
    {
        /// <summary>
        /// Gets the heuristics to execute in the current step.
        /// </summary>
        long Step { get; }

        /// <summary>
        /// Gets the list of choices that will be executed as part of a change detection.
        /// </summary>
        IList<IChoice> Choices { get; }
    }
}
