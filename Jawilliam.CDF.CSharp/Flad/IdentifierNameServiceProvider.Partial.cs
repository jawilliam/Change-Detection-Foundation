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
        /// Determines if two elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(IdentifierNameSyntax, PredefinedTypeSyntax)"/>.</remarks>
        public virtual bool ExactlyEqual(IdentifierNameSyntax original, PredefinedTypeSyntax modified)
        {
            return this.LanguageServiceProvider.ExactlyEqual(modified, original);
        }

        /// <summary>
        /// Determines if two elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="ExactlyEqual(IdentifierNameSyntax, QualifiedNameSyntax)"/>.</remarks>
        public virtual bool ExactlyEqual(IdentifierNameSyntax original, QualifiedNameSyntax modified)
        {
            if (original == null || modified == null)
                return false;

            var systemQualifier = modified.Left as IdentifierNameSyntax;
            var qualifiedName = modified.Right as IdentifierNameSyntax;

            if (original.Identifier != null && systemQualifier?.Identifier.ValueText == "System" && qualifiedName?.Identifier != null &&
                this.LanguageServiceProvider.PredefinedTypeServiceProvider.Aliases.Any(alias => alias.CSharpType == original.Identifier.ValueText && alias.NetType == qualifiedName.Identifier.ValueText))
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
            return this.LanguageServiceProvider.ExactlyEqual(original, modified);
        }

        /// <summary>
        /// Determines if two elements are type-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool TypeExactlyEqual(IdentifierNameSyntax original, QualifiedNameSyntax modified)
        {
            return this.LanguageServiceProvider.ExactlyEqual(original, modified);
        }
    }
}
