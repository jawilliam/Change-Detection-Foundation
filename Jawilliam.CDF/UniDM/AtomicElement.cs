using System.Collections.Generic;

namespace Jawilliam.CDF.UniDM
{
    /// <summary>
    /// Represents an element that does not encapsulate any other element.
    /// </summary>
    public class AtomicElement : IElement
    {
        /// <summary>
        /// Gets elements of which a element is composed of, including itself and the recursive closure of the encapsulated elements.
        /// </summary>
        public virtual IEnumerable<IElement> Population => new[] { this };

        /// <summary>
        /// Gets the length of the longest path from the element to an atomic element, in the graph of its encapsulated elements.
        /// </summary>
        public virtual IEnumerable<IElement> Depth => new IElement[0];

        /// <summary>
        /// Gets the number of distinct elements encapsulated directly inside the element.
        /// </summary>
        public virtual IEnumerable<IElement> Width => new IElement[0];

        /// <summary>
        /// Gets the number of distinct elements of the input documents that are mentioned in the current element or in its encapsulated elements.
        /// </summary>
        /// <remarks>Each element might include not only the elements it has actually modifed but also some other elements, which provide contextual information (for instance, the lines 
        /// before/afer a modifed line in a line-by-line source diff)</remarks>
        public virtual IEnumerable<IElement> TouchedElements => new[] { this };

        /// <summary>
        /// Gets the minimum number of elements that must be modified by the element to fulfill its purpose.
        /// </summary>
        /// <remarks>In other words, the number of elements included in the element since they were actually modified; the set of modified elements is then 
        /// a subset of the touched elements, which does not include those elements added just to provide contextual information.</remarks>
        public virtual IEnumerable<IElement> ModifiedElements => new[] { this };
    }
}
