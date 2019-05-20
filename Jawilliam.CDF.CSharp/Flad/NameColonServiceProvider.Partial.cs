//using Microsoft.CodeAnalysis.CSharp.Syntax;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Jawilliam.CDF.CSharp.Flad
//{
//    partial class NameColonServiceProvider
//    {
//        /// <summary>
//        /// Determines if two <see cref="NameColonSyntax"/> elements are name-based exactly equal.
//        /// </summary>
//        /// <param name="original">the original version.</param>
//        /// <param name="modified">the modified version.</param>
//        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
//        public virtual bool NameExactlyEqual(NameColonSyntax original, NameEqualsSyntax modified)
//        {
//            if (original == null || modified == null)
//                return false;

//            if (this.LanguageServiceProvider.IdentifierNameServiceProvider.NameExactlyEqual(original.Name, modified.Name))
//                return true;

//            return false;
//        }
//    }
//}
