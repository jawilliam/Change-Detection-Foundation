using System.Collections.Generic;

namespace Jawilliam.CDF.UniDM
{
    /// <summary>
    /// Defines a set of elements and relations between elements.
    /// </summary>
    /// <typeparam name="TElement">Type of the elements.</typeparam>
    /// <typeparam name="TRelation">Type of the relations.</typeparam>
    public interface IDocument<TElement, TRelation>
    {
        /// <summary>
        /// Gets the elements.
        /// </summary>
        IEnumerable<TElement> Elements { get; }

        /// <summary>
        /// Gets the relation among elements.
        /// </summary>
        IList<TRelation> Relations { get; }

        /// <summary>
        /// Gets the elements that are not encapsulated in any other element.
        /// </summary>
        IEnumerable<IElement> TopElements { get; }

        /// <summary>
        /// Gets the sum of the population property of all changes.
        /// </summary>
        IEnumerable<IElement> Population { get; }

        /// <summary>
        /// Gets the sum of the touched elements of all changes.
        /// </summary>
        IEnumerable<IElement> TouchedElements { get; }

        /// <summary>
        /// Gets the minimum number of distinct pieces of information that must be modifed in order to turn the original document into the modifed one.
        /// </summary>
        IEnumerable<IElement> ModifiedElements { get; }
    }
}
