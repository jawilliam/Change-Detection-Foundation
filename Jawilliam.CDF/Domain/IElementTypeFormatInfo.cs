using System.Collections.Generic;
using Microsoft.SqlServer.Server;

namespace Jawilliam.CDF.Domain
{
    /// <summary>
    /// Provides language-specific information about one specific element type.
    /// </summary>
    public interface IElementTypeFormatInfo
    {
        /// <summary>
        /// Gets all the subexpressions of the current element type.
        /// </summary>
        IEnumerable<string> SubExpressions { get; }

        /// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns>string names of the resulting subexpressions.</returns>
        IEnumerable<string> SyntacticalStopwords { get; }

        /// <summary>
        /// Gets the key subexpression names in case it has any.
        /// </summary>
        IEnumerable<string> Keys { get; }
    }

    /// <summary>
    /// Base class for implementations of <see cref="IElementTypeFormatInfo"/>. 
    /// </summary>
    public abstract class ElementTypeFormatInfo : IElementTypeFormatInfo
    {
        /// <summary>
        /// Gets all the subexpressions of the current element type.
        /// </summary>
        public abstract IEnumerable<string> SubExpressions { get; }

        /// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns>string names of the resulting subexpressions.</returns>
        public abstract IEnumerable<string> SyntacticalStopwords { get; }

        /// <summary>
        /// Gets the key subexpression names in case it has any.
        /// </summary>
        public virtual IEnumerable<string> Keys => null;
    }
}
