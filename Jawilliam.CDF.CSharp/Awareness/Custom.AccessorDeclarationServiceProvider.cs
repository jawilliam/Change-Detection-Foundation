using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Jawilliam.CDF.CSharp.Awareness
{
    //partial class AccessorDeclarationServiceProvider
    //{
    //    partial void ChildrenAfter(SyntaxNodeOrToken? node, ref IEnumerable<SyntaxNodeOrToken?> result)
    //    {
    //        var n = node != null ? (AccessorDeclarationSyntax)node : throw new ArgumentNullException(nameof(node));
    //        if (n.Kind() == SyntaxKind.UnknownAccessorDeclaration)
    //            result = (result ?? new SyntaxNodeOrToken?[0]).Union(new SyntaxNodeOrToken?[] { n.Keyword });
    //    }
    //}
}
