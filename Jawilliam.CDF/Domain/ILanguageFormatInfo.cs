using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jawilliam.CDF.Domain
{
    /// <summary>
    /// Provides language-specific information for the source code change detection.
    /// </summary>
    public interface ILanguageFormatInfo
    {
        /// <summary>
        /// Gets the <see cref="IElementTypeFormatInfo"/> to provide information for the requested element type.
        /// </summary>
        /// <param name="type">requested element type.</param>
        /// <param name="kind">optionally the element type can be refined to an specific subtype.</param>
        /// <returns><see cref="IElementTypeFormatInfo"/> implementation intended to provide information for the requested element type.</returns>
        IElementTypeFormatInfo GetElementTypeFormatInfo(string type, string subtype = null);
    }
}
