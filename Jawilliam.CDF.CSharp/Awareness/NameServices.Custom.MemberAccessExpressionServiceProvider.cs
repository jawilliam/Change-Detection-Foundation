using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jawilliam.CDF.Approach.Awareness;
using Jawilliam.CDF.Approach.Criterions;
using Jawilliam.CDF.Approach.Services;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Jawilliam.CDF.CSharp.Awareness
{
    partial class MemberAccessExpressionServiceProvider
    {
        partial void NameEqualityMatchAfter(MemberAccessExpressionSyntax original, MemberAccessExpressionSyntax modified, MatchingContext<SyntaxNodeOrToken?> context, ref MatchInfo<SyntaxNodeOrToken?> matchingDescription, ref bool result)
        {
            if (!result && original != null && modified != null)
            {
                if ((this.LanguageServiceProvider.MatchBy(typeof(IEqualityCriterion<,,>), "Equality", original.Expression, modified.Expression, context)) &&
                    (this.LanguageServiceProvider.MatchBy(typeof(INameEqualityCriterion<,,>), "NameEquality", original.Name, modified.Name, context)))
                {
                    matchingDescription = new MatchInfo<SyntaxNodeOrToken?>((int)MatchInfoCriterions.NameEquality) { Original = original, Modified = modified };
                    result = true;
                }
            }
        }
    }
}
