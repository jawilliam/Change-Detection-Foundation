using System;
using System.Collections.Generic;

namespace Jawilliam.CDF.SCCD.Base
{
    /// <summary>
    /// Defines the output of a Source Code Change Detection (SCCD) solution.
    /// </summary>
    /// <typeparam name="TElement">Type of the supported elements.</typeparam>
    public class Detection<TElement> : IDetection<TElement>
    {
        /// <summary>
        /// Gets the currently or finally discovered matches.
        /// </summary>
        public IEnumerable<IMatch> MatchingSet => throw new NotImplementedException();

        /// <summary>
        /// Gets the currently or finally discovered actions.
        /// </summary>
        /// <remarks>An edit script only describes the lower-level changes.</remarks>
        public IEnumerable<IAction> EditScript => throw new NotImplementedException();

        /// <summary>
        /// Gets the currently or finally discovered changes.
        /// </summary>
        /// <remarks>A delta describes language-aware changes.</remarks>
        public IEnumerable<IChange> Delta => throw new NotImplementedException();
    }
}
