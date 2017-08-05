using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Jawilliam.CDF.Approach.Matching.CSharp
{
    /// <summary>
    /// Supports the matching services for C#.
    /// </summary>
    public class MatchingProvider
    {
        /// <summary>
        /// Performs a pairwise comparison in terms of specified components. 
        /// </summary>
        /// <param name="original">older version</param>
        /// <param name="modified">newer version</param>
        /// <param name="options">specification of the components to consider in the comparison.</param>
        /// <returns>the components where the given versions match.</returns>
        public virtual MethodDeclarationMatchingOptions Match(MethodDeclarationSyntax original, MethodDeclarationSyntax modified, MethodDeclarationMatchingOptions options)
        {
            var result = MethodDeclarationMatchingOptions.None;
            if (options.HasFlag(MethodDeclarationMatchingOptions.Path))
            {
                Func<MethodDeclarationSyntax, string> getPath = syntax => syntax.Ancestors()
                    .Where(a => a.Kind() == SyntaxKind.NamespaceDeclaration ||
                                a.Kind() == SyntaxKind.ClassDeclaration ||
                                a.Kind() == SyntaxKind.StructDeclaration ||
                                a.Kind() == SyntaxKind.InterfaceDeclaration)
                    .Aggregate("", (s, a) => s + (s == "" ? "" : ".") + (a.Kind() == SyntaxKind.NamespaceDeclaration
                        ? ((NamespaceDeclarationSyntax)a).Name.ToFullString()
                        : ((TypeDeclarationSyntax)a).Identifier.ValueText +
                          ((TypeDeclarationSyntax)a).TypeParameterList?.ToFullString() ?? "")).Replace("\r\n", "");

                var originalPath = getPath(original);
                var modifiedPath = getPath(modified);

                if (originalPath == modifiedPath)
                    result |= MethodDeclarationMatchingOptions.Path;
            }

            if (options.HasFlag(MethodDeclarationMatchingOptions.DeclaringTypeName))
            {
                Func<MethodDeclarationSyntax, string> getDeclaringPath = syntax => syntax.Ancestors()
                    .Where(a => a.Kind() == SyntaxKind.NamespaceDeclaration ||
                                a.Kind() == SyntaxKind.ClassDeclaration ||
                                a.Kind() == SyntaxKind.StructDeclaration ||
                                a.Kind() == SyntaxKind.InterfaceDeclaration)
                    .Select(a => a.Kind() == SyntaxKind.NamespaceDeclaration
                        ? ((NamespaceDeclarationSyntax)a).Name.ToFullString()
                        : ((BaseTypeDeclarationSyntax)a).Identifier.ValueText)
                    .FirstOrDefault()?.Replace("\r\n", "") ?? "";

                var originalPath = getDeclaringPath(original);
                var modifiedPath = getDeclaringPath(modified);

                if (originalPath == modifiedPath)
                    result |= MethodDeclarationMatchingOptions.DeclaringTypeName;
            }

            if (options.HasFlag(MethodDeclarationMatchingOptions.ExplicitInterfaceSpecifier))
            {
                if (original.ExplicitInterfaceSpecifier?.ToFullString() == modified.ExplicitInterfaceSpecifier?.ToFullString())
                    result |= MethodDeclarationMatchingOptions.ExplicitInterfaceSpecifier;
            }

            if (options.HasFlag(MethodDeclarationMatchingOptions.TypeParameters))
            {
                if (original.TypeParameterList?.ToFullString() == modified.TypeParameterList?.ToFullString())
                    result |= MethodDeclarationMatchingOptions.TypeParameters;
            }

            if (options.HasFlag(MethodDeclarationMatchingOptions.Name))
            {
                if (original.Identifier.ValueText == modified.Identifier.ValueText)
                    result |= MethodDeclarationMatchingOptions.Name;
            }

            if (options.HasFlag(MethodDeclarationMatchingOptions.Parameters))
            {
                if (original.ParameterList.ToFullString() == modified.ParameterList.ToFullString())
                    result |= MethodDeclarationMatchingOptions.Parameters;
            }

            return result;
        }
    }
}
