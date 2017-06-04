using System;

namespace Jawilliam.CDF.Actions
{
    /// <summary>
    /// Represents a basic "delete" operation.
    /// </summary>
    [Serializable]
    public class DeleteOperationDescriptor : OperationDescriptor
    {
        /// <summary>
        /// Gets the current action.
        /// </summary>
        public override ActionKind Action => ActionKind.Delete;
    }
}