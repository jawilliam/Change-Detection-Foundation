using System.Collections.Generic;

namespace Jawilliam.CDF.Approach.Services
{
    /// <summary>
    /// Provides language-aware services regarding certain element type.
    /// </summary>
    public interface IElementTypeServiceProvider
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
}
