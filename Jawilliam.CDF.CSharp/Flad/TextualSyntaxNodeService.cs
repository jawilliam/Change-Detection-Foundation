using Jawilliam.CDF.Approach.Services;
using Jawilliam.CDF.Approach.Services.Impl;
using Microsoft.CodeAnalysis;

namespace Jawilliam.CDF.CSharp.Flad
{
    /// <summary>
    /// Implements the textual abstraction level of a <see cref="SyntaxNodeOrToken"/> element.
    /// </summary>
    public class TextualSyntaxNodeService : Service, ITextualAbstractionService<SyntaxNodeOrToken?>
    {
        /// <summary>
        /// Access the textual representation of a full node.
        /// </summary>
        /// <param name="element">root node.</param>
        /// <returns>a textual representation</returns>
        public virtual string FullText(SyntaxNodeOrToken? element)
        {
            return element != null && element.Value.IsToken ? element?.AsToken().ValueText : element?.AsNode().ToString();
        }
    }
}
