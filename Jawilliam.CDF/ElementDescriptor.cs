using System;

namespace Jawilliam.CDF
{
    /// <summary>
    /// Describes an element inside a matching description.
    /// </summary>
    [Serializable]
    public class ElementDescriptor
    {
        /// <summary>
        /// Gets or sets an value identifying the current element.
        /// </summary>
        public virtual string Id { get; set; }

        /// <summary>
        /// Gets or sets an value identifying the current element.
        /// </summary>
        public virtual string Label { get; set; }
    }
}