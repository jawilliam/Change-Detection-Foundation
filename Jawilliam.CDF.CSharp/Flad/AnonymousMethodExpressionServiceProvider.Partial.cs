using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Jawilliam.CDF.CSharp.Flad
{
    partial class AnonymousMethodExpressionServiceProvider
    {
        ///// <summary>
        ///// Method hook for implementing logic to execute after the <see cref="TypeExactlyEqualCore(AnonymousMethodExpressionSyntax, AnonymousMethodExpressionSyntax)"/>.
        ///// </summary>
        ///// <param name="original">the original version.</param>
        ///// <param name="modified">the modified version.</param>
        ///// <param name="result">Mechanism to modify the result of <see cref="TypeExactlyEqual(AnonymousMethodExpressionSyntax, AnonymousMethodExpressionSyntax)"/>.</param>
        //partial void TypeExactlyEqualAfter(AnonymousMethodExpressionSyntax original, AnonymousMethodExpressionSyntax modified, ref bool result)
        //{
        //    if (!result && original != null && modified != null)
        //    {
        //        if (original.ParameterList == null && modified.ParameterList == null)
        //            result = true;
        //    }
        //}
    }
}
