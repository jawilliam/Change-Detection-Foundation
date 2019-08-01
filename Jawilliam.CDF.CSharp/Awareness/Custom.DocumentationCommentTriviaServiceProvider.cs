using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jawilliam.CDF.CSharp.Awareness
{
    //partial class DocumentationCommentTriviaServiceProvider
    //{
    //    /// <summary>
    //    /// Method hook for implementing logic to execute after the <see cref="ChildrenCore(SyntaxNodeOrToken?)"/>.
    //    /// </summary>
    //    /// <param name="node">node of interest.</param>
    //    /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
    //    partial void ChildrenAfter(SyntaxNodeOrToken? node, ref IEnumerable<SyntaxNodeOrToken?> result)
    //    {
    //        var n = node != null ? (DocumentationCommentTriviaSyntax)node : throw new ArgumentNullException(nameof(node));
    //        var filterOut = n.Content.Where(delegate (XmlNodeSyntax c)
    //        {
    //            if (c is XmlTextSyntax text && (string.IsNullOrEmpty(text.ToFullString()) ||
    //                                            string.IsNullOrWhiteSpace(text.ToFullString()) ||
    //                                            text.ToFullString().Trim(' ') == "///"))
    //                return true;

    //            return false;
    //        }).ToArray() ?? new XmlNodeSyntax[0];

    //        result = result != null ? result.Where(c => c != null && !filterOut.Contains(c.Value.AsNode())) : result;
    //    }
    //}
}
