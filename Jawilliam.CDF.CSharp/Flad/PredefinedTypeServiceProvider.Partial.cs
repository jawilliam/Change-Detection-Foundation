using Jawilliam.CDF.Approach.Flad;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jawilliam.CDF.CSharp.Flad
{
    partial class PredefinedTypeServiceProvider : IEqualityCondition<PredefinedTypeSyntax, PredefinedTypeSyntax>
    {
        /// <summary>
        /// Gets the keywords for built-in C# types, which are aliases of predefined types in the System namespace <see cref="https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/built-in-types-table"/>.
        /// </summary>
        public virtual IEnumerable<(string CSharpType, string NetType)> Aliases
        {
            get
            {
                yield return ("bool", "Boolean");
                yield return ("byte", "Byte");
                yield return ("sbyte", "SByte");
                yield return ("char", "Char");
                yield return ("decimal", "Decimal");
                yield return ("double", "Double");
                yield return ("float", "Single");
                yield return ("int", "Int32");
                yield return ("uint", "UInt32");
                yield return ("long", "Int64");
                yield return ("ulong", "UInt64");
                yield return ("object", "Object");
                yield return ("short", "Int16");
                yield return ("ushort", "UInt16");
                yield return ("string", "String");
            }
        }

        /// <summary>
        /// Determines if two elements are equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="Equal(PredefinedTypeSyntax, IdentifierNameSyntax)"/>.</remarks>
        public virtual bool Equal(PredefinedTypeSyntax original, IdentifierNameSyntax modified)
        {
            if (original == null || modified == null)
                return false;

            if (original.Keyword != null && modified.Identifier != null && 
                this.Aliases.Any(alias => alias.CSharpType == original.Keyword.ValueText && alias.NetType == modified.Identifier.ValueText))
                return true;

            return false;
        }

        /// <summary>
        /// Determines if two elements are equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are equal, otherwise returns false.</returns>
        /// <remarks>This is the default implementation for <see cref="Equal(PredefinedTypeSyntax, QualifiedNameSyntax)"/>.</remarks>
        public virtual bool Equal(PredefinedTypeSyntax original, QualifiedNameSyntax modified)
        {
            if (original == null || modified == null)
                return false;

            var systemQualifier = modified.Left as IdentifierNameSyntax;
            var qualifiedName = modified.Right as IdentifierNameSyntax;

            if (original.Keyword != null && systemQualifier?.Identifier.ValueText == "System" && qualifiedName?.Identifier != null &&
                this.Aliases.Any(alias => alias.CSharpType == original.Keyword.ValueText && alias.NetType == qualifiedName.Identifier.ValueText))
                return true;

            return false;
        }

        /// <summary>
        /// Determines if two elements are type-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool TypeExactlyEqual(PredefinedTypeSyntax original, IdentifierNameSyntax modified)
        {
            return this.LanguageServiceProvider.Equal(original, modified);
        }

        /// <summary>
        /// Determines if two elements are type-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool TypeExactlyEqual(PredefinedTypeSyntax original, QualifiedNameSyntax modified)
        {
            return this.LanguageServiceProvider.Equal(original, modified);
        }
    }
}
