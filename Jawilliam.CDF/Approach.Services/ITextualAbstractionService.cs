using System.Collections.Generic;

namespace Jawilliam.CDF.Approach.Services
{
    /// <summary>
    /// Defines the textual abstraction level of a node element.
    /// </summary>
    /// <typeparam name="TElement">Type of the supported elements.</typeparam>
    public interface ITextualAbstractionService<TElement> : IService
    {
        /// <summary>
        /// Access the textual representation of a full node.
        /// </summary>
        /// <param name="element">root node.</param>
        /// <returns>a textual representation</returns>
        string FullText(TElement element);
    }
}
