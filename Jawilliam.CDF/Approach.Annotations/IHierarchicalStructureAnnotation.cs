using System.Collections.Generic;

namespace Jawilliam.CDF.Approach.Annotations
{
    /// <summary>
    /// Defines information hierarchically structured.
    /// </summary>
    /// <typeparam name="TElement">Type of the supported elements.</typeparam>
    public interface IHierarchicalStructureAnnotation<TElement>
    {
        /// <summary>
        /// Gets or sets the children of the annotated element.
        /// </summary>
        IList<TElement> Children { get; set; }

        /// <summary>
        /// Gets or sets the parent of the annotated element.
        /// </summary>
        TElement Parent { get; set; }
    }
}