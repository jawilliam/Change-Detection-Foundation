using Jawilliam.CDF.Approach.Services;
using Jawilliam.CDF.Approach.Services.Impl;
using Microsoft.CodeAnalysis;

namespace Jawilliam.CDF.CSharp.Flad
{
    /// <summary>
    /// Implements the textual abstraction level of a <see cref="SyntaxNode"/> element.
    /// </summary>
    public class TextualSyntaxNodeService : Service, ITextualAbstractionService<SyntaxNode>
    {
        /// <summary>
        /// Access the textual representation of a full node.
        /// </summary>
        /// <param name="element">root node.</param>
        /// <returns>a textual representation</returns>
        public virtual string FullText(SyntaxNode element)
        {
            return element.ToString();
        }
    }
}
