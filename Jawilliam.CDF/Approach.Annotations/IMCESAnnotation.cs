using Jawilliam.CDF.Actions;
using System.Collections.Generic;

namespace Jawilliam.CDF.Approach.Annotations
{
    /// <summary>
    /// Information related to a "Minimum Conforming Edit Script" generation.
    /// </summary>
    /// <typeparam name="TElement">Type of the supported elements.</typeparam>
    public interface IMcesAnnotation<TElement> : IHierarchicalStructureAnnotation<TElement>
    {
        /// <summary>
        /// Gets or sets whether or not the annotated node is "in order" or not.
        /// </summary>
        bool InOrder { get; set; }

        /// <summary>
        /// Gets the actions that affect the annotated element.
        /// </summary>
        IList<EditAction<TElement>> Actions { get; }
    }
}
