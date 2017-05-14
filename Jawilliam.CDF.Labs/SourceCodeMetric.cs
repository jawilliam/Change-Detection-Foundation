using System.Collections.Generic;
using System.IO;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

namespace Jawilliam.CDF.Labs
{
    /// <summary>
    /// Base class of source code metrics.
    /// </summary>
    public abstract class SourceCodeMetric
    {
        /// <summary>
        /// Stores the value of <see cref="SourceCode"/>.
        /// </summary>
        private readonly CompilationUnitSyntax _sourceCode;

        /// <summary>
        /// Initializes the instance over the source code contained inside the file idetified with the given path.
        /// </summary>
        /// <param name="path">path to identify the file containing the source code.</param>
        protected SourceCodeMetric(string path) : this(System.IO.File.OpenText(path))
        {
        }

        /// <summary>
        /// Initializes the instance over the source code contained inside the given stream.
        /// </summary>
        /// <param name="source">stream to identify the channel of source code.</param>
        protected SourceCodeMetric(TextReader source)
        {
            this._sourceCode = SyntaxFactory.ParseCompilationUnit(source.ReadToEnd());
        }

        /// <summary>
        /// Gets the collection of source code line.
        /// </summary>
        public virtual IEnumerable<TextLine> Lines
        {
            get { return this.SourceCode.GetText().Lines; }
        }

        /// <summary>
        /// Gets the representation of source code.
        /// </summary>
        public virtual CompilationUnitSyntax SourceCode
        {
            get { return this._sourceCode; }
        }
    }
}
