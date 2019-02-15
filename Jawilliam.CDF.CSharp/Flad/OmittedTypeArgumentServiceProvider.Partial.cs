using Jawilliam.CDF.Approach.Flad;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jawilliam.CDF.CSharp.Flad
{
    /// <summary>
    /// Provides language-aware services regarding <see cref="OmittedTypeArgumentSyntax"/>.
    /// </summary>
    partial class OmittedTypeArgumentServiceProvider : INameEqualityCondition<OmittedTypeArgumentSyntax, OmittedTypeArgumentSyntax>
    {
        /// <summary>
        /// Determines if two <see cref="OmittedTypeArgumentSyntax"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool NameExactlyEqual(OmittedTypeArgumentSyntax original, OmittedTypeArgumentSyntax modified)
        {
            if (original == null || modified == null)
                return false;

            return true;
        }
    }
}
