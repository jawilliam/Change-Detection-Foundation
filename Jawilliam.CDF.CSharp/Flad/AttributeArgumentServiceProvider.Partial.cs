using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Jawilliam.CDF.CSharp.Flad
{
    partial class AttributeArgumentServiceProvider
    {
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameExactlyEqualCore(AttributeArgumentSyntax, AttributeArgumentSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(AttributeArgumentSyntax, AttributeArgumentSyntax)"/>.</param>
        partial void NameExactlyEqualAfter(AttributeArgumentSyntax original, AttributeArgumentSyntax modified, ref bool result)
        {
            if (!result && original != null && modified != null)
            {
                if (original.NameEquals != null && modified.NameColon != null && this.LanguageServiceProvider.NameExactlyEqual(original.NameEquals, modified.NameColon))
                {
                    result = true;
                    return;
                }

                if (original.NameColon != null && modified.NameEquals != null && this.LanguageServiceProvider.NameExactlyEqual(original.NameColon, modified.NameEquals))
                    result = true;
            }
        }
    }
}
