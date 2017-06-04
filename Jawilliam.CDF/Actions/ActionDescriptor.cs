using System;
using System.Runtime.Serialization;

namespace Jawilliam.CDF.Actions
{
    /// <summary>
    /// Describes a basic result of a change detection differencing or report.
    /// </summary>
    [Serializable]
    [KnownType(typeof(InsertOperationDescriptor))]
    [KnownType(typeof(DeleteOperationDescriptor))]
    [KnownType(typeof(UpdateOperationDescriptor))]
    [KnownType(typeof(MoveOperationDescriptor))]
    [KnownType(typeof(AlignOperationDescriptor))]
    public abstract class ActionDescriptor
    {
        /// <summary>
        /// Gets the current action.
        /// </summary>
        public abstract ActionKind Action { get; }
    }
}