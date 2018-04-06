using Microsoft.CodeAnalysis.CSharp;
using System.Xml.Linq;

namespace Jawilliam.CDF.CSharp.RoslynML
{
    partial class RoslynML
    {
        /// <summary>
        /// Loads the content given as a full path or a textual content.
        /// </summary>
        /// <param name="pathOrContent">full path or textual content</param>
        /// <param name="path">informs if the content is given as a full path or textual content.</param>
        /// <returns>XML-like representation of the Roslyn-based AST.</returns>
        public virtual XElement Load(string pathOrContent, bool path = true)
        {
            string content = path ? System.IO.File.ReadAllText(pathOrContent) : pathOrContent;
            var ast = SyntaxFactory.ParseCompilationUnit(content).SyntaxTree.GetRoot();
            return this.Visit(ast);
        }
    }
}
