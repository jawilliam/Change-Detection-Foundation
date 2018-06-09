using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jawilliam.CDF.Domain
{
    /// <summary>
    /// Provides language-specific information about one specific element type.
    /// </summary>
    public interface IElementTypeFormatInfo
    {
        /// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        IEnumerable<string> GetStructuralStopwords();
    }
}
