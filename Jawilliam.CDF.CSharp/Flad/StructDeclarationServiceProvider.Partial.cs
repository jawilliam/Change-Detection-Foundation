//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.CodeAnalysis.CSharp.Syntax;

//namespace Jawilliam.CDF.CSharp.Flad
//{
//    partial class StructDeclarationServiceProvider
//    {
//        /// <summary>
//        /// Method hook for implementing logic to execute after the <see cref="TypeExactlyEqualCore(StructDeclarationSyntax, StructDeclarationSyntax)"/>.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <param name="result">Mechanism to modify the result of <see cref="TypeExactlyEqual(StructDeclarationSyntax, StructDeclarationSyntax)"/>.</param>
//        partial void TypeExactlyEqualAfter(StructDeclarationSyntax original, StructDeclarationSyntax modified, ref bool result)
//        {
//            if (!result && original != null && modified != null)
//            {
//                if (original.TypeParameterList == null && modified.TypeParameterList == null)
//                    result = true;
//            }
//        }
//    }
//}
