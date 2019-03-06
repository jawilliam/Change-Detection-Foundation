using Jawilliam.CDF.Actions;
using System.Collections.Generic;

namespace Jawilliam.CDF.Approach.Annotations
{
    /// <summary>
    /// Information related to a "Minimum Conforming Edit Script" generation.
    /// </summary>
    /// <typeparam name="TElement">Type of the supported elements.</typeparam>
    public interface IMcesAnnotation<TElement>
    {
        /// <summary>
        /// Gets or sets whether or not the annotated node is "in order" or not.
        /// </summary>
        bool InOrder { get; set; }

        /// <summary>
        /// Gets the actions that affect the annotated element.
        /// </summary>
        IList<EditAction<TElement>> Actions { get; }

        /// <summary>
        /// Gets or sets the children of the annotated element.
        /// </summary>
        IList<TElement> Children { get; set; }

        /// <summary>
        /// Gets or sets the parent of the annotated element.
        /// </summary>
        TElement Parent { get; set; }

        ///// <summary>
        ///// Gets or sets the label of the annotated element.
        ///// </summary>
        //int Label { get; set; }

        ///// <summary>
        ///// Gets or sets the value of the annotated element.
        ///// </summary>
        //object Value { get; set; }
    }
}
