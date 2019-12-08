using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Jawilliam.CDF.Tests.Flad.Awareness
{
    partial class RoslynMLDeltaExpanderTests
    {
        partial void ParenthesizedExpressionServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(ParenthesizedExpressionSyntax, ParenthesizedExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((ParenthesizedExpressionSyntax)SyntaxFactory.ParseExpression("(3)"), (ParenthesizedExpressionSyntax)SyntaxFactory.ParseExpression("(3)"))
            };
        }

        partial void PrefixUnaryExpressionServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(PrefixUnaryExpressionSyntax, PrefixUnaryExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((PrefixUnaryExpressionSyntax)SyntaxFactory.ParseExpression("++3"), (PrefixUnaryExpressionSyntax)SyntaxFactory.ParseExpression("++3"))
            };
        }

        partial void AwaitExpressionServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(AwaitExpressionSyntax, AwaitExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((AwaitExpressionSyntax)SyntaxFactory.ParseExpression("await x"), (AwaitExpressionSyntax)SyntaxFactory.ParseExpression("await x"))
            };
        }

        partial void PostfixUnaryExpressionServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(PostfixUnaryExpressionSyntax, PostfixUnaryExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((PostfixUnaryExpressionSyntax)SyntaxFactory.ParseExpression("3++"), (PostfixUnaryExpressionSyntax)SyntaxFactory.ParseExpression("3++"))
            };
        }

        partial void MemberAccessExpressionServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(MemberAccessExpressionSyntax, MemberAccessExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((MemberAccessExpressionSyntax)SyntaxFactory.ParseExpression("x.r"), (MemberAccessExpressionSyntax)SyntaxFactory.ParseExpression("x.r"))
            };
        }

        partial void ConditionalAccessExpressionServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(ConditionalAccessExpressionSyntax, ConditionalAccessExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((ConditionalAccessExpressionSyntax)SyntaxFactory.ParseExpression("x?.r"), (ConditionalAccessExpressionSyntax)SyntaxFactory.ParseExpression("x?.r"))
            };
        }

        partial void MemberBindingExpressionServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(MemberBindingExpressionSyntax, MemberBindingExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((MemberBindingExpressionSyntax)((ConditionalAccessExpressionSyntax)SyntaxFactory.ParseExpression("m?.r")).WhenNotNull,
                 (MemberBindingExpressionSyntax)((ConditionalAccessExpressionSyntax)SyntaxFactory.ParseExpression("m?.r")).WhenNotNull)
            };
        }

        partial void ElementBindingExpressionServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(ElementBindingExpressionSyntax, ElementBindingExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((ElementBindingExpressionSyntax)((ConditionalAccessExpressionSyntax)SyntaxFactory.ParseExpression("m?[r]")).WhenNotNull,
                 (ElementBindingExpressionSyntax)((ConditionalAccessExpressionSyntax)SyntaxFactory.ParseExpression("m?[r]")).WhenNotNull)
            };
        }

        partial void ImplicitElementAccessServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(ImplicitElementAccessSyntax, ImplicitElementAccessSyntax)> nodeRevisionPairs)
        {
            Func<string, ImplicitElementAccessSyntax> getElementBinding = delegate (string s)
            {
                var objectCreation = (ObjectCreationExpressionSyntax)SyntaxFactory.ParseExpression(s);
                var assigment = (AssignmentExpressionSyntax)objectCreation.Initializer.Expressions[0];
                return (ImplicitElementAccessSyntax)assigment.Left;
            };

            nodeRevisionPairs = new[]
            {
                (getElementBinding("new A { [\"a\"] = { a = 0} }"),
                 getElementBinding("new A { [\"a\"] = { a = 0} }"))
            };
        }

        partial void BinaryExpressionServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(BinaryExpressionSyntax, BinaryExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((BinaryExpressionSyntax)SyntaxFactory.ParseExpression("1 * 2"),
                 (BinaryExpressionSyntax)SyntaxFactory.ParseExpression("1 * 2"))
            };
        }

        partial void AssignmentExpressionServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(AssignmentExpressionSyntax, AssignmentExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((AssignmentExpressionSyntax)SyntaxFactory.ParseExpression("x *= 2"),
                 (AssignmentExpressionSyntax)SyntaxFactory.ParseExpression("x *= 2"))
            };
        }

        partial void ConditionalExpressionServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(ConditionalExpressionSyntax, ConditionalExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((ConditionalExpressionSyntax)SyntaxFactory.ParseExpression("x ? 3 : 2"),
                 (ConditionalExpressionSyntax)SyntaxFactory.ParseExpression("x ? 3 : 2"))
            };
        }

        partial void ThisExpressionServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(ThisExpressionSyntax, ThisExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((ThisExpressionSyntax)SyntaxFactory.ParseExpression("this"),
                 (ThisExpressionSyntax)SyntaxFactory.ParseExpression("this"))
            };
        }
    }
}
