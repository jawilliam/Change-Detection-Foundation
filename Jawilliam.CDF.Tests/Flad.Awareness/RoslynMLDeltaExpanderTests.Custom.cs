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

        partial void BaseExpressionServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(BaseExpressionSyntax, BaseExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((BaseExpressionSyntax)SyntaxFactory.ParseExpression("base"),
                 (BaseExpressionSyntax)SyntaxFactory.ParseExpression("base"))
            };
        }

        partial void LiteralExpressionServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(LiteralExpressionSyntax, LiteralExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((LiteralExpressionSyntax)SyntaxFactory.ParseExpression("3"),
                 (LiteralExpressionSyntax)SyntaxFactory.ParseExpression("3"))
            };
        }

        partial void MakeRefExpressionServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(MakeRefExpressionSyntax, MakeRefExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((MakeRefExpressionSyntax)SyntaxFactory.ParseExpression("__makeref(x)"),
                 (MakeRefExpressionSyntax)SyntaxFactory.ParseExpression("__makeref(x)"))
            };
        }

        partial void RefTypeExpressionServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(RefTypeExpressionSyntax, RefTypeExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((RefTypeExpressionSyntax)SyntaxFactory.ParseExpression("__reftype(x)"),
                 (RefTypeExpressionSyntax)SyntaxFactory.ParseExpression("__reftype(x)"))
            };
        }

        partial void RefValueExpressionServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(RefValueExpressionSyntax, RefValueExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((RefValueExpressionSyntax)SyntaxFactory.ParseExpression("__refvalue(x, int)"),
                 (RefValueExpressionSyntax)SyntaxFactory.ParseExpression("__refvalue(x, int)"))
            };
        }

        partial void CheckedExpressionServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(CheckedExpressionSyntax, CheckedExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((CheckedExpressionSyntax)SyntaxFactory.ParseExpression("unchecked(y)"),
                 (CheckedExpressionSyntax)SyntaxFactory.ParseExpression("unchecked(y)")),
                ((CheckedExpressionSyntax)SyntaxFactory.ParseExpression("checked(y)"),
                 (CheckedExpressionSyntax)SyntaxFactory.ParseExpression("checked(y)"))
            };
        }

        partial void DefaultExpressionServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(DefaultExpressionSyntax, DefaultExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((DefaultExpressionSyntax)SyntaxFactory.ParseExpression("default(x)"),
                 (DefaultExpressionSyntax)SyntaxFactory.ParseExpression("default(x)"))
            };
        }

        partial void TypeOfExpressionServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(TypeOfExpressionSyntax, TypeOfExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((TypeOfExpressionSyntax)SyntaxFactory.ParseExpression("typeof(x)"),
                 (TypeOfExpressionSyntax)SyntaxFactory.ParseExpression("typeof(x)"))
            };
        }

        partial void SizeOfExpressionServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(SizeOfExpressionSyntax, SizeOfExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((SizeOfExpressionSyntax)SyntaxFactory.ParseExpression("sizeof(x)"),
                 (SizeOfExpressionSyntax)SyntaxFactory.ParseExpression("sizeof(x)"))
            };
        }

        partial void InvocationExpressionServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(InvocationExpressionSyntax, InvocationExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((InvocationExpressionSyntax)SyntaxFactory.ParseExpression("a(r,e)"),
                 (InvocationExpressionSyntax)SyntaxFactory.ParseExpression("a(r,e)"))
            };
        }

        partial void ElementAccessExpressionServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(ElementAccessExpressionSyntax, ElementAccessExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((ElementAccessExpressionSyntax)SyntaxFactory.ParseExpression("x[\"a\"]"),
                 (ElementAccessExpressionSyntax)SyntaxFactory.ParseExpression("x[\"a\"]"))
            };
        }

        partial void CastExpressionServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(CastExpressionSyntax, CastExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((CastExpressionSyntax)SyntaxFactory.ParseExpression("(int)x"),
                 (CastExpressionSyntax)SyntaxFactory.ParseExpression("(int)x"))
            };
        }

        partial void AnonymousMethodExpressionServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(AnonymousMethodExpressionSyntax, AnonymousMethodExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((AnonymousMethodExpressionSyntax)SyntaxFactory.ParseExpression("async delegate() { return 4; }"),
                 (AnonymousMethodExpressionSyntax)SyntaxFactory.ParseExpression("async delegate() { return 4; }")),
                ((AnonymousMethodExpressionSyntax)SyntaxFactory.ParseExpression("async delegate { return 4; }"),
                 (AnonymousMethodExpressionSyntax)SyntaxFactory.ParseExpression("async delegate { return 4; }")),
                ((AnonymousMethodExpressionSyntax)SyntaxFactory.ParseExpression("delegate { return 4; }"),
                 (AnonymousMethodExpressionSyntax)SyntaxFactory.ParseExpression("async delegate { return 4; }")),
                ((AnonymousMethodExpressionSyntax)SyntaxFactory.ParseExpression("async delegate { return 4; }"),
                 (AnonymousMethodExpressionSyntax)SyntaxFactory.ParseExpression("delegate { return 4; }"))
            };
        }

        partial void SimpleLambdaExpressionServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(SimpleLambdaExpressionSyntax, SimpleLambdaExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((SimpleLambdaExpressionSyntax)SyntaxFactory.ParseExpression("async e => 4"),
                 (SimpleLambdaExpressionSyntax)SyntaxFactory.ParseExpression("async e => 4")),
                ((SimpleLambdaExpressionSyntax)SyntaxFactory.ParseExpression("e => 4"),
                 (SimpleLambdaExpressionSyntax)SyntaxFactory.ParseExpression("e => 4")),
                ((SimpleLambdaExpressionSyntax)SyntaxFactory.ParseExpression("e => 4"),
                 (SimpleLambdaExpressionSyntax)SyntaxFactory.ParseExpression("async e => 4")),
                ((SimpleLambdaExpressionSyntax)SyntaxFactory.ParseExpression("async e => 4"),
                 (SimpleLambdaExpressionSyntax)SyntaxFactory.ParseExpression("e => 4"))
            };
        }

        partial void ParenthesizedLambdaExpressionServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(ParenthesizedLambdaExpressionSyntax, ParenthesizedLambdaExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                ((ParenthesizedLambdaExpressionSyntax)SyntaxFactory.ParseExpression("async (e) => 4"),
                 (ParenthesizedLambdaExpressionSyntax)SyntaxFactory.ParseExpression("async (e) => 4")),
                ((ParenthesizedLambdaExpressionSyntax)SyntaxFactory.ParseExpression("(e) => 4"),
                 (ParenthesizedLambdaExpressionSyntax)SyntaxFactory.ParseExpression("(e) => 4")),
                ((ParenthesizedLambdaExpressionSyntax)SyntaxFactory.ParseExpression("(e) => 4"),
                 (ParenthesizedLambdaExpressionSyntax)SyntaxFactory.ParseExpression("async (e) => 4")),
                ((ParenthesizedLambdaExpressionSyntax)SyntaxFactory.ParseExpression("async (e) => 4"),
                 (ParenthesizedLambdaExpressionSyntax)SyntaxFactory.ParseExpression("(e) => 4"))
            };
        }

        partial void InitializerExpressionServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(InitializerExpressionSyntax, InitializerExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 (((ObjectCreationExpressionSyntax)SyntaxFactory.ParseExpression("new F { 4, 'r', \"hello world\" }")).Initializer,
                  ((ObjectCreationExpressionSyntax)SyntaxFactory.ParseExpression("new F { 4, 'r', \"hello world\" }")).Initializer),
                 (((ArrayCreationExpressionSyntax)SyntaxFactory.ParseExpression("new object[] { 4, 'r', \"hello world\" }")).Initializer,
                  ((ArrayCreationExpressionSyntax)SyntaxFactory.ParseExpression("new object[] { 4, 'r', \"hello world\" }")).Initializer),
                 (((ObjectCreationExpressionSyntax)SyntaxFactory.ParseExpression("new F { 4, 'r', \"hello world\" }")).Initializer,
                  ((ArrayCreationExpressionSyntax)SyntaxFactory.ParseExpression("new object[] { 4, 'r', \"hello world\" }")).Initializer),
                 (((ArrayCreationExpressionSyntax)SyntaxFactory.ParseExpression("new object[] { 4, 'r', \"hello world\" }")).Initializer,
                  ((ObjectCreationExpressionSyntax)SyntaxFactory.ParseExpression("new F { 4, 'r', \"hello world\" }")).Initializer)
            };
        }

        partial void ObjectCreationExpressionServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(ObjectCreationExpressionSyntax, ObjectCreationExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((ObjectCreationExpressionSyntax)SyntaxFactory.ParseExpression("new F() { 4, 'r', \"hello world\" }"),
                  (ObjectCreationExpressionSyntax)SyntaxFactory.ParseExpression("new F() { 4, 'r', \"hello world\" }")),
                 ((ObjectCreationExpressionSyntax)SyntaxFactory.ParseExpression("new F { 4, 'r', \"hello world\" }"),
                  (ObjectCreationExpressionSyntax)SyntaxFactory.ParseExpression("new F { 4, 'r', \"hello world\" }")),
                 ((ObjectCreationExpressionSyntax)SyntaxFactory.ParseExpression("new F() { 4, 'r', \"hello world\" }"),
                  (ObjectCreationExpressionSyntax)SyntaxFactory.ParseExpression("new F { 4, 'r', \"hello world\" }")),
                 ((ObjectCreationExpressionSyntax)SyntaxFactory.ParseExpression("new F { 4, 'r', \"hello world\" }"),
                  (ObjectCreationExpressionSyntax)SyntaxFactory.ParseExpression("new F() { 4, 'r', \"hello world\" }"))
            };
        }

        partial void AnonymousObjectCreationExpressionServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(AnonymousObjectCreationExpressionSyntax, AnonymousObjectCreationExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((AnonymousObjectCreationExpressionSyntax)SyntaxFactory.ParseExpression("new { Text = 4, aText = 5 }"),
                  (AnonymousObjectCreationExpressionSyntax)SyntaxFactory.ParseExpression("new { Text = 4, aText = 5 }"))
            };
        }

        partial void ArrayCreationExpressionServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(ArrayCreationExpressionSyntax, ArrayCreationExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((ArrayCreationExpressionSyntax)SyntaxFactory.ParseExpression("new A[]{4, 6}"),
                  (ArrayCreationExpressionSyntax)SyntaxFactory.ParseExpression("new A[]{4, 6}"))
            };
        }

        partial void ImplicitArrayCreationExpressionServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(ImplicitArrayCreationExpressionSyntax, ImplicitArrayCreationExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((ImplicitArrayCreationExpressionSyntax)SyntaxFactory.ParseExpression("new [,]{4, 6}"),
                  (ImplicitArrayCreationExpressionSyntax)SyntaxFactory.ParseExpression("new [,]{4, 6}"))
            };
        }

        partial void StackAllocArrayCreationExpressionServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(StackAllocArrayCreationExpressionSyntax, StackAllocArrayCreationExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((StackAllocArrayCreationExpressionSyntax)SyntaxFactory.ParseExpression("stackalloc int[2]"),
                  (StackAllocArrayCreationExpressionSyntax)SyntaxFactory.ParseExpression("stackalloc int[2]"))
            };
        }

        partial void QueryExpressionServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(QueryExpressionSyntax, QueryExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s where f.A select f.R"),
                  (QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s where f.A select f.R"))
            };
        }

        partial void InterpolatedStringExpressionServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(InterpolatedStringExpressionSyntax, InterpolatedStringExpressionSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((InterpolatedStringExpressionSyntax)SyntaxFactory.ParseExpression("$\"Hello world\""),
                  (InterpolatedStringExpressionSyntax)SyntaxFactory.ParseExpression("$\"Hello world\""))
            };
        }

        partial void InterpolatedStringTextServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(InterpolatedStringTextSyntax, InterpolatedStringTextSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((InterpolatedStringTextSyntax)((InterpolatedStringExpressionSyntax)SyntaxFactory.ParseExpression("$\"Hello world\"")).Contents[0],
                  (InterpolatedStringTextSyntax)((InterpolatedStringExpressionSyntax)SyntaxFactory.ParseExpression("$\"Hello world\"")).Contents[0])
            };
        }

        partial void InterpolationServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(InterpolationSyntax, InterpolationSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 ((InterpolationSyntax)((InterpolatedStringExpressionSyntax)SyntaxFactory.ParseExpression("$\"Hello world {Name, 5:N2}\"")).Contents[1],
                  (InterpolationSyntax)((InterpolatedStringExpressionSyntax)SyntaxFactory.ParseExpression("$\"Hello world {Name, 5:N2}\"")).Contents[1]),
                 ((InterpolationSyntax)((InterpolatedStringExpressionSyntax)SyntaxFactory.ParseExpression("$\"Hello world {Name}\"")).Contents[1],
                  (InterpolationSyntax)((InterpolatedStringExpressionSyntax)SyntaxFactory.ParseExpression("$\"Hello world {Name}\"")).Contents[1]),
                 ((InterpolationSyntax)((InterpolatedStringExpressionSyntax)SyntaxFactory.ParseExpression("$\"Hello world {Name, 5:N2}\"")).Contents[1],
                  (InterpolationSyntax)((InterpolatedStringExpressionSyntax)SyntaxFactory.ParseExpression("$\"Hello world {Name}\"")).Contents[1]),
                 ((InterpolationSyntax)((InterpolatedStringExpressionSyntax)SyntaxFactory.ParseExpression("$\"Hello world {Name}\"")).Contents[1],
                  (InterpolationSyntax)((InterpolatedStringExpressionSyntax)SyntaxFactory.ParseExpression("$\"Hello world {Name, 5:N2}\"")).Contents[1])
            };
        }

        partial void InterpolationAlignmentClauseServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(InterpolationAlignmentClauseSyntax, InterpolationAlignmentClauseSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 (((InterpolationSyntax)((InterpolatedStringExpressionSyntax)SyntaxFactory.ParseExpression("$\"Hello world {Name, 5:N2}\"")).Contents[1]).AlignmentClause,
                  ((InterpolationSyntax)((InterpolatedStringExpressionSyntax)SyntaxFactory.ParseExpression("$\"Hello world {Name, 5:N2}\"")).Contents[1]).AlignmentClause)
            };
        }

        partial void InterpolationFormatClauseServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(InterpolationFormatClauseSyntax, InterpolationFormatClauseSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 (((InterpolationSyntax)((InterpolatedStringExpressionSyntax)SyntaxFactory.ParseExpression("$\"Hello world {Name, 5:N2}\"")).Contents[1]).FormatClause,
                  ((InterpolationSyntax)((InterpolatedStringExpressionSyntax)SyntaxFactory.ParseExpression("$\"Hello world {Name, 5:N2}\"")).Contents[1]).FormatClause)
            };
        }

        partial void ArgumentListServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(ArgumentListSyntax, ArgumentListSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 (((InvocationExpressionSyntax)SyntaxFactory.ParseExpression("x.F(x, r)")).ArgumentList,
                  ((InvocationExpressionSyntax)SyntaxFactory.ParseExpression("x.F(x, r)")).ArgumentList)
            };
        }

        partial void BracketedArgumentListServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(BracketedArgumentListSyntax, BracketedArgumentListSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 (((ElementAccessExpressionSyntax)SyntaxFactory.ParseExpression("x.F[x, r]")).ArgumentList,
                  ((ElementAccessExpressionSyntax)SyntaxFactory.ParseExpression("x.F[x, r]")).ArgumentList)
            };
        }

        partial void ArgumentServiceProvider_RoslynMLDefoliatedTopologicalAbstraction_DataToTest(ref IEnumerable<(ArgumentSyntax, ArgumentSyntax)> nodeRevisionPairs)
        {
            nodeRevisionPairs = new[]
            {
                 (((InvocationExpressionSyntax)SyntaxFactory.ParseExpression("x.F(x, r)")).ArgumentList.Arguments[0],
                  ((InvocationExpressionSyntax)SyntaxFactory.ParseExpression("x.F(x, r)")).ArgumentList.Arguments[0]),
                 (((InvocationExpressionSyntax)SyntaxFactory.ParseExpression("x.F(ref x, r)")).ArgumentList.Arguments[0],
                  ((InvocationExpressionSyntax)SyntaxFactory.ParseExpression("x.F(ref x, r)")).ArgumentList.Arguments[0]),
                 (((InvocationExpressionSyntax)SyntaxFactory.ParseExpression("x.F(out x, r)")).ArgumentList.Arguments[0],
                  ((InvocationExpressionSyntax)SyntaxFactory.ParseExpression("x.F(x, r)")).ArgumentList.Arguments[0]),
                 (((InvocationExpressionSyntax)SyntaxFactory.ParseExpression("x.F(x, r)")).ArgumentList.Arguments[0],
                  ((InvocationExpressionSyntax)SyntaxFactory.ParseExpression("x.F(out x, r)")).ArgumentList.Arguments[0])
            };
        }
    }
}
