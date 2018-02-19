using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Jawilliam.CDF.Domain
{
    /// <summary>
    /// Defines a (sub)category of the elements. 
    /// </summary>
    public interface IElementType
    {
        /// <summary>
        /// Gets the type of the current element.
        /// </summary>
        int Label { get; }

        /// <summary>
        /// Gets the value of the current element.
        /// </summary>
        object Value { get; }
    }
}
