using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Jawilliam.CDF.CSharp.Flad
{
    partial class MemberAccessExpressionServiceProvider
    {
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="NameExactlyEqualCore(MemberAccessExpressionSyntax, MemberAccessExpressionSyntax)"/>.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="NameExactlyEqual(MemberAccessExpressionSyntax, MemberAccessExpressionSyntax)"/>.</param>
        partial void NameExactlyEqualAfter(MemberAccessExpressionSyntax original, MemberAccessExpressionSyntax modified, ref bool result)
        {
            if (!result && original != null && modified != null)
            {
                if (original.Expression != null && modified.Expression != null && 
                    original.Expression.ToString().Trim() == modified.Expression.ToString().Trim() &&
                    this.LanguageServiceProvider.NameExactlyEqual(original.Name, modified.Name))
                {
                    result = true;
                    return;
                }
            }
        }
    }
}
