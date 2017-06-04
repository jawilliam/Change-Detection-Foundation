using System;

namespace Jawilliam.CDF.Actions
{
    /// <summary>
    /// Describes a basic result of a change detection differencing or report.
    /// </summary>
    [Serializable]
    public abstract class ActionDescriptor
    {
        /// <summary>
        /// Gets the current action.
        /// </summary>
        public abstract ActionKind Action { get; }
    }
}