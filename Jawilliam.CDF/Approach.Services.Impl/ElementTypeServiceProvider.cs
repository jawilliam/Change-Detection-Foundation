using System.Collections.Generic;

namespace Jawilliam.CDF.Approach.Services.Impl
{
    /// <summary>
    /// Base class for implementations of <see cref="IElementTypeServiceProvider"/>. 
    /// </summary>
    public abstract class ElementTypeServiceProvider : IElementTypeServiceProvider
    {
        /// <summary>
        /// Gets all the subexpressions of the current element type.
        /// </summary>
        public virtual IEnumerable<string> SubExpressions { get { yield break; } } 

        /// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns>string names of the resulting subexpressions.</returns>
        public virtual IEnumerable<string> SyntacticalStopwords { get { yield break; } }

        /// <summary>
        /// Gets the key subexpression names in case it has any.
        /// </summary>
        public virtual IEnumerable<string> Keys { get { yield break; } }
    }
}
