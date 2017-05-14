using System.IO;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Text;

namespace Jawilliam.CDF.Labs
{
    /// <summary>
    /// Represents count of lines metric matching specific criteria.
    /// </summary>
    public class CountOfLinesMetric : SourceCodeMetric
    {
        /// <summary>
        /// Initializes the instance over the source code contained inside the file idetified with the given path.
        /// </summary>
        /// <param name="path">path to identify the file containing the source code.</param>
        public CountOfLinesMetric(string path) : base(path)
        {
        }

        /// <summary>
        /// Initializes the instance over the source code contained inside the given stream.
        /// </summary>
        /// <param name="source">stream to identify the channel of source code.</param>
        public CountOfLinesMetric(TextReader source) : base(source)
        {
        }

        /// <summary>
        /// Gets count of lines in blank.
        /// </summary>
        public virtual long InBlank
        {
            get { return this.Lines.Count(l => string.IsNullOrWhiteSpace(l.ToString().Trim())); }
        }

        /// <summary>
        /// Gets count of lines being just an open or close brace.
        /// </summary>
        public virtual long Braces
        {
            get
            {
                return this.Lines.Count(delegate (TextLine l)
                {
                    string lineText = l.ToString().Trim();
                    return lineText == "{" || lineText == "}";
                });
            }
        }

        /// <summary>
        /// Gets count of comments lines.
        /// </summary>        
        public virtual long Comments
        {
            get
            {
                var commentTrivia = from s in this.SourceCode.DescendantTrivia()
                    where s.RawKind == (int) SyntaxKind.SingleLineCommentTrivia ||
                          s.RawKind == (int) SyntaxKind.MultiLineCommentTrivia ||
                          s.RawKind == (int) SyntaxKind.SingleLineDocumentationCommentTrivia ||
                          s.RawKind == (int) SyntaxKind.MultiLineDocumentationCommentTrivia
                    select s;

                return commentTrivia.Sum(delegate(SyntaxTrivia comment)
                {
                    var lineSpan = this.SourceCode.SyntaxTree.GetLineSpan(comment.Span);
                    switch (comment.RawKind)
                    {
                        case (int)SyntaxKind.MultiLineDocumentationCommentTrivia:
                        case (int)SyntaxKind.MultiLineCommentTrivia:
                            return (lineSpan.EndLinePosition.Line - lineSpan.StartLinePosition.Line) + 1;
                        default:
                            return (lineSpan.EndLinePosition.Line - lineSpan.StartLinePosition.Line);
                    }
                });
            }
        }

        /// <summary>
        /// Gets count of code lines.
        /// </summary>
        public virtual long Code 
        {
            get { return this.Lines.Count() - (this.InBlank + this.Comments); }
        }
        
        /// <summary>
        /// Gets count of code statement lines.
        /// </summary>
        public virtual long Statements
        {
            get { return this.Code - this.Braces; }
        }
    }
}
