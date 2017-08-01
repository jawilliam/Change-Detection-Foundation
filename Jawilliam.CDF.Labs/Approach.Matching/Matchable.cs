using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Jawilliam.CDF.Labs.Approach.Matching
{
    public class Matchable
    {
        /// <summary>
        /// Performs a pairwise comparison in terms of specified components. 
        /// </summary>
        /// <param name="original">older version</param>
        /// <param name="modified">newer version</param>
        /// <param name="options">specification of the components to consider in the comparison.</param>
        /// <returns>the components where the given versions match.</returns>
        public static MethodDeclarationMatchingOptions Match(MethodDeclarationSyntax original, MethodDeclarationSyntax modified, MethodDeclarationMatchingOptions options)
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
                        ? ((NamespaceDeclarationSyntax) a).Name.ToFullString()
                        : ((BaseTypeDeclarationSyntax) a).Identifier.ValueText));

                var originalPath = getPath(original);
                var modifiedPath = getPath(modified);

                if(originalPath == modifiedPath)
                    result |= MethodDeclarationMatchingOptions.Path;
            }

            if (options.HasFlag(MethodDeclarationMatchingOptions.ExplicitInterfaceSpecifier))
            {
                if (original.ExplicitInterfaceSpecifier.ToFullString() == modified.ExplicitInterfaceSpecifier.ToFullString())
                    result |= MethodDeclarationMatchingOptions.ExplicitInterfaceSpecifier;
            }

            if (options.HasFlag(MethodDeclarationMatchingOptions.TypeParameters))
            {
                if (original.TypeParameterList.ToFullString() == modified.TypeParameterList.ToFullString())
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

    /// <summary>
    /// Contains options to match two method declarations. 
    /// </summary>
    [Flags]
    public enum MethodDeclarationMatchingOptions
    {
        None = 0,

        /// <summary>
        /// The path of the full name, i.e., namespace and container types.
        /// </summary>
        Path = 1, 

        /// <summary>
        /// The name of the element, i.e., the name of the method.
        /// </summary>
        Name = 2,

        /// <summary>
        /// Whether or not the explicit name must be assumed, e.g., the one including the explicit interface specifier.
        /// </summary>
        ExplicitInterfaceSpecifier = 4,

        /// <summary>
        /// Whether or not taking the type parameters into consideration.
        /// </summary>
        TypeParameters = 8,

        /// <summary>
        /// Whether or not taking the parameter list into consideration.
        /// </summary>
        Parameters = 16,


        //,Name, Signature, Type, Global, Explicit,  
    }
}
