using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jawilliam.CDF.CSharp.Flad
{
    partial class QualifiedNameServiceProvider
    {
        /// <summary>
        /// Determines if two elements are equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="Equal(QualifiedNameSyntax, PredefinedTypeSyntax)"/>.</remarks>
        public virtual bool Equal(QualifiedNameSyntax original, PredefinedTypeSyntax modified)
        {
            return this.LanguageServiceProvider.Equal(modified, original);
        }

        /// <summary>
        /// Determines if two elements are equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="Equal(QualifiedNameSyntax, IdentifierNameSyntax)"/>.</remarks>
        public virtual bool Equal(QualifiedNameSyntax original, IdentifierNameSyntax modified)
        {
            return this.LanguageServiceProvider.Equal(modified, original);
        }

        /// <summary>
        /// Determines if two elements are type-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool TypeExactlyEqual(QualifiedNameSyntax original, PredefinedTypeSyntax modified)
        {
            return this.LanguageServiceProvider.TypeExactlyEqual(modified, original);
        }

        /// <summary>
        /// Determines if two elements are type-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool TypeExactlyEqual(QualifiedNameSyntax original, IdentifierNameSyntax modified)
        {
            return this.LanguageServiceProvider.TypeExactlyEqual(modified, original);
        }
    }
}
