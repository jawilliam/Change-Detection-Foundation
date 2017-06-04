using System;

namespace Jawilliam.CDF.Actions
{
    /// <summary>
    /// Base class of the representations for the basic "move" and "align" operations.
    /// </summary>
    [Serializable]
    public abstract class BaseMoveOperationDescriptor : OperationDescriptor
    {
        /// <summary>
        /// Gets or sets the k-index of the element to be inserted.
        /// </summary>
        public virtual int Position { get; set; }
    }
}
