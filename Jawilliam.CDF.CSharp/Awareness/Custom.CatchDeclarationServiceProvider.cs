using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Jawilliam.CDF.CSharp.Awareness
{
    //partial class CatchDeclarationServiceProvider
    //{
    //    /// <summary>
    //    /// Method hook for implementing logic to execute after the <see cref="ChildrenCore(SyntaxNodeOrToken?)"/>.
    //    /// </summary>
    //    /// <param name="node">node of interest.</param>
    //    /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
    //    partial void ChildrenAfter(SyntaxNodeOrToken? node, ref IEnumerable<SyntaxNodeOrToken?> result)
    //    {
    //        var n = node != null ? (CatchDeclarationSyntax)node : throw new ArgumentNullException(nameof(node));
    //        if (n.Identifier.ValueText == null)
    //            result = result != null ? result.Where(c => c != n.Identifier) : result; 
    //    }
    //}
}
