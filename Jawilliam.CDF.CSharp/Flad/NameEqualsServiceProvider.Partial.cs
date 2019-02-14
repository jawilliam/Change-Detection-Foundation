using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jawilliam.CDF.CSharp.Flad
{
    partial class NameEqualsServiceProvider
    {
        /// <summary>
        /// Determines if two <see cref="NameEqualsSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public bool NameExactlyEqual(NameEqualsSyntax original, NameColonSyntax modified)
        {
            if (original == null || modified == null)
                return false;

            if (this.LanguageServiceProvider.IdentifierNameServiceProvider.NameExactlyEqual(original.Name, modified.Name))
                return true;

            return false;
        }
    }
}
