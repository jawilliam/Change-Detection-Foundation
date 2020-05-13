using System.Collections.Generic;

namespace Jawilliam.CDF.SCCD
{
    /// <summary>
    /// Defines the output of a Source Code Change Detection (SCCD) solution.
    /// </summary>
    /// <typeparam name="TElement">Type of the supported elements.</typeparam>
    public interface IDetection<TElement>
    {
        /// <summary>
        /// Gets the currently or finally discovered matches.
        /// </summary>
        IEnumerable<IMatch> MatchingSet { get; }

        /// <summary>
        /// Gets the currently or finally discovered actions.
        /// </summary>
        /// <remarks>An edit script only describes the lower-level changes.</remarks>
        IEnumerable<IAction> EditScript { get; }

        /// <summary>
        /// Gets the currently or finally discovered changes.
        /// </summary>
        /// <remarks>A delta describes language-aware changes.</remarks>
        IEnumerable<IChange> Delta { get; }
    }
}
