using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jawilliam.CDF.UniDM
{
    /// <summary>
    /// Defines a document element.
    /// </summary>
    public interface IElement
    {
        /// <summary>
        /// Gets elements of which a element is composed of, including itself and the recursive closure of the encapsulated elements.
        /// </summary>
        IEnumerable<IElement> Population { get; }

        /// <summary>
        /// Gets the length of the longest path from the element to an atomic element, in the graph of its encapsulated elements.
        /// </summary>
        IEnumerable<IElement> Depth { get; }

        /// <summary>
        /// Gets the number of distinct elements encapsulated directly inside the element.
        /// </summary>
        IEnumerable<IElement> Width { get; }

        /// <summary>
        /// Gets the number of distinct elements of the input documents that are mentioned in the current element or in its encapsulated elements.
        /// </summary>
        /// <remarks>Each element might include not only the elements it has actually modifed but also some other elements, which provide contextual information (for instance, the lines 
        /// before/afer a modifed line in a line-by-line source diff)</remarks>
        IEnumerable<IElement> TouchedElements { get; }

        /// <summary>
        /// Gets the minimum number of elements that must be modified by the element to fulfill its purpose.
        /// </summary>
        /// <remarks>In other words, the number of elements included in the element since they were actually modified; the set of modified elements is then 
        /// a subset of the touched elements, which does not include those elements added just to provide contextual information.</remarks>
        IEnumerable<IElement> ModifiedElements { get; }
    }
}
