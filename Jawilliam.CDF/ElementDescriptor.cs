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

        /// <summary>
        /// Gets or sets an value identifying the current element.
        /// </summary>
        public virtual string Value { get; set; }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return $"{Label}({Id})";
        }
    }
}