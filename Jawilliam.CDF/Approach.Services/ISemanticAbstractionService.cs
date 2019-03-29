using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jawilliam.CDF.Approach.Services
{
    /// <summary>
    /// Defines the semantic abstraction level of a node element.
    /// </summary>
    /// <typeparam name="TElement">Type of the supported elements.</typeparam>
    public interface ISemanticAbstractionService<TElement> : IService
    {
        /// <summary>
        /// Determines if one element is a relevant piece of the source code content. 
        /// </summary>
        /// <param name="element">element to characterize.</param>
        /// <returns>true if the element is an essential part; otherwise false.</returns>
        bool IsEssential(TElement element);
    }
}
