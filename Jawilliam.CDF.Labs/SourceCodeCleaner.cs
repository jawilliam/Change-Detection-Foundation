using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Jawilliam.CDF.Labs
{
    /// <summary>
    /// Implements logic to clean the source code.
    /// </summary>
    public class SourceCodeCleaner : CSharpSyntaxRewriter
    {
        /// <summary>
        /// Gets or sets the indentation string.
        /// </summary>
        public virtual string Indentation { get; set; }

        /// <summary>
        /// Gets or sets the new line string.
        /// </summary>
        public virtual string NewLine { get; set; }

        /// <summary>
        /// Whether or not the whitespaces will be normalized.
        /// </summary>
        public virtual bool Normalize { get; set; } = false;

        /// <summary>
        /// Whether or not the comments will be removed.
        /// </summary>
        public virtual bool RemoveComments { get; set; } = false;

        /// <summary>
        /// Cleans the given node.
        /// </summary>
        /// <param name="node">the node to be processed.</param>
        /// <returns>the processed node.</returns>
        public virtual SyntaxNode Clean(SyntaxNode node)
        {
            SyntaxNode result = node;
            result = this.RemoveComments ? this.Visit(result) : result;
            result = this.Normalize ? result.NormalizeWhitespace(this.Indentation, this.NewLine) : result;
            return result;
        }

        public override SyntaxTrivia VisitTrivia(SyntaxTrivia trivia)
        {
            if (this.RemoveComments)
            {
                if (trivia.IsKind(SyntaxKind.MultiLineCommentTrivia) ||
                    trivia.IsKind(SyntaxKind.SingleLineCommentTrivia) ||
                    trivia.IsKind(SyntaxKind.MultiLineDocumentationCommentTrivia) ||
                    trivia.IsKind(SyntaxKind.SingleLineDocumentationCommentTrivia))
                    return default(SyntaxTrivia);
            }
            return trivia;
        }
    }
}
