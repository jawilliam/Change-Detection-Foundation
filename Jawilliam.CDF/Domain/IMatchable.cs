using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jawilliam.CDF.Domain
{
    /// <summary>
    /// Defines the 
    /// </summary>
    public interface IMatchable
    {
        /// <summary>
        /// Determines if the current element is similar to another.
        /// </summary>
        /// <param name="other">the element with which comparing the current one.</param>
        /// <param name="similarity">a measure of how similar the two elements are [0...1].</param>
        /// <returns>TRUE if both elements are similar, otherwise FALSE.</returns>
        bool Match(IElementType other, out double similarity);
    }
}
