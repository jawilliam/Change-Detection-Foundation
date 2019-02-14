using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jawilliam.CDF.Approach.Flad
{
    /// <summary>
    /// Provides language-specific information for the source code change detection.
    /// </summary>
    public interface ILanguageServiceProvider
    {
        /// <summary>
        /// Gets the <see cref="IElementTypeServiceProvider"/> to provide information for the requested element type.
        /// </summary>
        /// <param name="type">requested element type.</param>
        /// <param name="kind">optionally the element type can be refined to an specific subtype.</param>
        /// <returns><see cref="IElementTypeServiceProvider"/> implementation intended to provide information for the requested element type.</returns>
        IElementTypeServiceProvider GetElementTypeServiceProvider(string type, string subtype = null);
    }
}
