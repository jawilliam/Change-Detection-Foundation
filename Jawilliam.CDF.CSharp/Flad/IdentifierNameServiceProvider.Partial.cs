using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jawilliam.CDF.CSharp.Flad
{
    partial class IdentifierNameServiceProvider
    {
        /// <summary>
        /// Determines if two elements are equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="Equal(IdentifierNameSyntax, PredefinedTypeSyntax)"/>.</remarks>
        public virtual bool Equal(IdentifierNameSyntax original, PredefinedTypeSyntax modified)
        {
            return this.LanguageServiceProvider.Equal(modified, original);
        }

        /// <summary>
        /// Determines if two elements are equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="Equal(IdentifierNameSyntax, QualifiedNameSyntax)"/>.</remarks>
        public virtual bool Equal(IdentifierNameSyntax original, QualifiedNameSyntax modified)
        {
            if (original == null || modified == null)
                return false;

            var systemQualifier = modified.Left as IdentifierNameSyntax;
            var qualifiedName = modified.Right as IdentifierNameSyntax;

            if (original.Identifier != null && systemQualifier?.Identifier.ValueText == "System" && qualifiedName?.Identifier != null &&
                this.LanguageServiceProvider.PredefinedTypeServiceProvider.Aliases.Any(alias => alias.NetType == original.Identifier.ValueText && alias.NetType == qualifiedName.Identifier.ValueText))
                return true;

            return false;
        }

        /// <summary>
        /// Determines if two elements are type-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool TypeExactlyEqual(IdentifierNameSyntax original, PredefinedTypeSyntax modified)
        {
            return this.LanguageServiceProvider.Equal(original, modified);
        }

        /// <summary>
        /// Determines if two elements are type-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool TypeExactlyEqual(IdentifierNameSyntax original, QualifiedNameSyntax modified)
        {
            return this.LanguageServiceProvider.Equal(original, modified);
        }
    }
}
