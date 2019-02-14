using System.Collections.Generic;

namespace Jawilliam.CDF.Approach.Flad
{
    /// <summary>
    /// Base class for implementations of <see cref="IElementTypeServiceProvider"/>. 
    /// </summary>
    public abstract class ElementTypeServiceProvider : IElementTypeServiceProvider
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
