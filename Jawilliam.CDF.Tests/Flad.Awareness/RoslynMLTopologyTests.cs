using Jawilliam.CDF.Approach.Services;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Jawilliam.CDF.Tests.Flad.Awareness
{
    /// <summary>
    /// Summary description for TopologyTests
    /// </summary>
    [TestClass]
    public class RoslynMLTopologyTests
    {
        [TestMethod]
        public void ParenthesizedExpressionServiceProvider_RoslynMLTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynMLPruner();

            var node = (ParenthesizedExpressionSyntax)SyntaxFactory.ParseExpression("(3)");
            var xElement = converter.Visit(node);
            converter.Prune(xElement);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Expression).Name.LocalName);
        }

        [TestMethod]
        public void PrefixUnaryExpressionServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (PrefixUnaryExpressionSyntax)SyntaxFactory.ParseExpression("++3");

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 2);
            Assert.IsTrue(hierarchicalChildren.Contains(node.OperatorToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Operand));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Operand));
        }

        [TestMethod]
        public void AwaitExpressionServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (AwaitExpressionSyntax)SyntaxFactory.ParseExpression("await x");

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 2);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AwaitKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Expression));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Expression));
        }

        [TestMethod]
        public void PostfixUnaryExpressionServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (PostfixUnaryExpressionSyntax)SyntaxFactory.ParseExpression("3++");

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 2);
            Assert.IsTrue(hierarchicalChildren.Contains(node.OperatorToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Operand));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Operand));
        }

        [TestMethod]
        public void MemberAccessExpressionServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (MemberAccessExpressionSyntax)SyntaxFactory.ParseExpression("x.r");

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 3);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Expression));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OperatorToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Name));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.Expression));
            Assert.IsTrue(topologicalChildren.Contains(node.Name));
        }

        [TestMethod]
        public void ConditionalAccessExpressionServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (ConditionalAccessExpressionSyntax)SyntaxFactory.ParseExpression("x?.r");

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 3);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Expression));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OperatorToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.WhenNotNull));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.Expression));
            Assert.IsTrue(topologicalChildren.Contains(node.WhenNotNull));
        }

        [TestMethod]
        public void MemberBindingExpressionServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (MemberBindingExpressionSyntax)((ConditionalAccessExpressionSyntax)SyntaxFactory.ParseExpression("m?.r")).WhenNotNull;

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 2);
            Assert.IsTrue(hierarchicalChildren.Contains(node.OperatorToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Name));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Name));
        }

        [TestMethod]
        public void ElementBindingExpressionServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (ElementBindingExpressionSyntax)((ConditionalAccessExpressionSyntax)SyntaxFactory.ParseExpression("m?[r]")).WhenNotNull;

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 1);
            Assert.IsTrue(hierarchicalChildren.Contains(node.ArgumentList));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.ArgumentList));
        }

        [TestMethod]
        public void ImplicitElementAccessServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();
            Func<string, ImplicitElementAccessSyntax> getElementBinding = delegate (string s)
            {
                var objectCreation = (ObjectCreationExpressionSyntax)SyntaxFactory.ParseExpression(s);
                var assigment = (AssignmentExpressionSyntax)objectCreation.Initializer.Expressions[0];
                return (ImplicitElementAccessSyntax)assigment.Left;
            };

            var node = getElementBinding("new A { [\"a\"] = { a = 0} }");

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 1);
            Assert.IsTrue(hierarchicalChildren.Contains(node.ArgumentList));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.ArgumentList));
        }

        [TestMethod]
        public void BinaryExpressionServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (BinaryExpressionSyntax)SyntaxFactory.ParseExpression("1 * 2");

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 3);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Left));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OperatorToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Right));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.Left));
            Assert.IsTrue(topologicalChildren.Contains(node.Right));
        }

        [TestMethod]
        public void AssignmentExpressionServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (AssignmentExpressionSyntax)SyntaxFactory.ParseExpression("x *= 2");

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 3);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Left));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OperatorToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Right));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.Left));
            Assert.IsTrue(topologicalChildren.Contains(node.Right));
        }

        [TestMethod]
        public void ConditionalExpressionServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (ConditionalExpressionSyntax)SyntaxFactory.ParseExpression("x ? 3 : 2");

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 5);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Condition));
            Assert.IsTrue(hierarchicalChildren.Contains(node.QuestionToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.WhenTrue));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ColonToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.WhenFalse));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(topologicalChildren.Contains(node.Condition));
            Assert.IsTrue(topologicalChildren.Contains(node.WhenTrue));
            Assert.IsTrue(topologicalChildren.Contains(node.WhenFalse));
        }

        [TestMethod]
        public void ThisExpressionServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (ThisExpressionSyntax)SyntaxFactory.ParseExpression("this");

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 1);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Token));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 0);
        }

        [TestMethod]
        public void BaseExpressionServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (BaseExpressionSyntax)SyntaxFactory.ParseExpression("base");

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 1);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Token));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 0);
        }

        [TestMethod]
        public void LiteralExpressionServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (LiteralExpressionSyntax)SyntaxFactory.ParseExpression("3");

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 1);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Token));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Token));
        }

        [TestMethod]
        public void MakeRefExpressionServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (MakeRefExpressionSyntax)SyntaxFactory.ParseExpression("__makeref(x)");

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 4);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Keyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenParenToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Expression));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseParenToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Expression));
        }

        [TestMethod]
        public void RefTypeExpressionServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (RefTypeExpressionSyntax)SyntaxFactory.ParseExpression("__reftype(x)");

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 4);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Keyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenParenToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Expression));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseParenToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Expression));
        }

        [TestMethod]
        public void RefValueExpressionServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (RefValueExpressionSyntax)SyntaxFactory.ParseExpression("__refvalue(x, int)");

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 6);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Keyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenParenToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Expression));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Comma));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Type));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseParenToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.Expression));
            Assert.IsTrue(topologicalChildren.Contains(node.Type));
        }

        [TestMethod]
        public void CheckedExpressionServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (CheckedExpressionSyntax)SyntaxFactory.ParseExpression("unchecked(y)");

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 4);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Keyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenParenToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Expression));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseParenToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Expression));

            node = (CheckedExpressionSyntax)SyntaxFactory.ParseExpression("checked(y)");

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 4);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Keyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenParenToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Expression));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseParenToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Expression));
        }

        [TestMethod]
        public void DefaultExpressionServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (DefaultExpressionSyntax)SyntaxFactory.ParseExpression("default(x)");

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 4);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Keyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenParenToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Type));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseParenToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Type));
        }

        [TestMethod]
        public void TypeOfExpressionServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (TypeOfExpressionSyntax)SyntaxFactory.ParseExpression("typeof(x)");

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 4);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Keyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenParenToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Type));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseParenToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Type));
        }

        [TestMethod]
        public void SizeOfExpressionServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (SizeOfExpressionSyntax)SyntaxFactory.ParseExpression("sizeof(x)");

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 4);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Keyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenParenToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Type));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseParenToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Type));
        }

        [TestMethod]
        public void InvocationExpressionServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (InvocationExpressionSyntax)SyntaxFactory.ParseExpression("a(r,e)");

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 2);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Expression));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ArgumentList));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.Expression));
            Assert.IsTrue(topologicalChildren.Contains(node.ArgumentList));
        }

        [TestMethod]
        public void ElementAccessExpressionServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (ElementAccessExpressionSyntax)SyntaxFactory.ParseExpression("x[\"a\"]");

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 2);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Expression));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ArgumentList));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.Expression));
            Assert.IsTrue(topologicalChildren.Contains(node.ArgumentList));
        }

        [TestMethod]
        public void CastExpressionServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (CastExpressionSyntax)SyntaxFactory.ParseExpression("(int)x");

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 4);
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenParenToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Type));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseParenToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Expression));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.Type));
            Assert.IsTrue(topologicalChildren.Contains(node.Expression));
        }

        [TestMethod]
        public void AnonymousMethodExpressionServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (AnonymousMethodExpressionSyntax)SyntaxFactory.ParseExpression("async delegate() { return 4; }");

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 4);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AsyncKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.DelegateKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Body));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.Body));

            node = (AnonymousMethodExpressionSyntax)SyntaxFactory.ParseExpression("async delegate { return 4; }");

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 3);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AsyncKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.DelegateKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Body));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Body));
        }

        [TestMethod]
        public void SimpleLambdaExpressionServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (SimpleLambdaExpressionSyntax)SyntaxFactory.ParseExpression("async e => 4");

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 4);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AsyncKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Parameter));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ArrowToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Body));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.Parameter));
            Assert.IsTrue(topologicalChildren.Contains(node.Body));
        }

        [TestMethod]
        public void ParenthesizedLambdaExpressionServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (ParenthesizedLambdaExpressionSyntax)SyntaxFactory.ParseExpression("async (e) => 4");

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 4);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AsyncKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ArrowToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Body));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.Body));
        }

        [TestMethod]
        public void InitializerExpressionServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = ((ObjectCreationExpressionSyntax)SyntaxFactory.ParseExpression("new F { 4, 'r', \"hello world\" }")).Initializer;

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 7);
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenBraceToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Expressions[0]));
            Assert.IsTrue(hierarchicalChildren[2].Value.AsToken().Kind() == SyntaxKind.CommaToken);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Expressions[1]));
            Assert.IsTrue(hierarchicalChildren[4].Value.AsToken().Kind() == SyntaxKind.CommaToken);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Expressions[2]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseBraceToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(topologicalChildren.Contains(node.Expressions[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Expressions[1]));
            Assert.IsTrue(topologicalChildren.Contains(node.Expressions[2]));

            node = ((ArrayCreationExpressionSyntax)SyntaxFactory.ParseExpression("new object[] { 4, 'r', \"hello world\" }")).Initializer;

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 7);
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenBraceToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Expressions[0]));
            Assert.IsTrue(hierarchicalChildren[2].Value.AsToken().Kind() == SyntaxKind.CommaToken);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Expressions[1]));
            Assert.IsTrue(hierarchicalChildren[4].Value.AsToken().Kind() == SyntaxKind.CommaToken);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Expressions[2]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseBraceToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(topologicalChildren.Contains(node.Expressions[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Expressions[1]));
            Assert.IsTrue(topologicalChildren.Contains(node.Expressions[2]));
        }

        [TestMethod]
        public void ObjectCreationExpressionServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (ObjectCreationExpressionSyntax)SyntaxFactory.ParseExpression("new F() { 4, 'r', \"hello world\" }");

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 4);
            Assert.IsTrue(hierarchicalChildren.Contains(node.NewKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Type));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ArgumentList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Initializer));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(topologicalChildren.Contains(node.Type));
            Assert.IsTrue(topologicalChildren.Contains(node.ArgumentList));
            Assert.IsTrue(topologicalChildren.Contains(node.Initializer));

            node = (ObjectCreationExpressionSyntax)SyntaxFactory.ParseExpression("new F { 4, 'r', \"hello world\" }");

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 3);
            Assert.IsTrue(hierarchicalChildren.Contains(node.NewKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Type));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Initializer));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.Type));
            Assert.IsTrue(topologicalChildren.Contains(node.Initializer));
        }

        [TestMethod]
        public void AnonymousObjectCreationExpressionServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (AnonymousObjectCreationExpressionSyntax)SyntaxFactory.ParseExpression("new { Text = 4, aText = 5 }");

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 6);
            Assert.IsTrue(hierarchicalChildren.Contains(node.NewKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenBraceToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Initializers[0]));
            Assert.IsTrue(hierarchicalChildren[3].Value.AsToken().Kind() == SyntaxKind.CommaToken);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Initializers[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseBraceToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.Initializers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Initializers[1]));
        }

        [TestMethod]
        public void ArrayCreationExpressionServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (ArrayCreationExpressionSyntax)SyntaxFactory.ParseExpression("new A[]{4, 6}");

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 3);
            Assert.IsTrue(hierarchicalChildren.Contains(node.NewKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Type));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Initializer));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.Type));
            Assert.IsTrue(topologicalChildren.Contains(node.Initializer));
        }

        [TestMethod]
        public void ImplicitArrayCreationExpressionServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (ImplicitArrayCreationExpressionSyntax)SyntaxFactory.ParseExpression("new [,]{4, 6}");

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 5);
            Assert.IsTrue(hierarchicalChildren.Contains(node.NewKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenBracketToken));
            Assert.IsTrue(hierarchicalChildren[2].Value.AsToken().Kind() == SyntaxKind.CommaToken);
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseBracketToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Initializer));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2); ;
            Assert.IsTrue(topologicalChildren[0].Value.AsToken().Kind() == SyntaxKind.CommaToken);
            Assert.IsTrue(topologicalChildren.Contains(node.Initializer));
        }

        [TestMethod]
        public void StackAllocArrayCreationExpressionServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (StackAllocArrayCreationExpressionSyntax)SyntaxFactory.ParseExpression("stackalloc int[2]");

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 2);
            Assert.IsTrue(hierarchicalChildren.Contains(node.StackAllocKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Type));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Type));
        }

        [TestMethod]
        public void QueryExpressionServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s where f.A select f.R");

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 2);
            Assert.IsTrue(hierarchicalChildren.Contains(node.FromClause));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Body));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.FromClause));
            Assert.IsTrue(topologicalChildren.Contains(node.Body));
        }

        [TestMethod]
        public void InterpolatedStringExpressionServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (InterpolatedStringExpressionSyntax)SyntaxFactory.ParseExpression("$\"Hello world\"");

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 3);
            Assert.IsTrue(hierarchicalChildren.Contains(node.StringStartToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Contents[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.StringEndToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Contents[0]));
        }

        [TestMethod]
        public void InterpolatedStringTextServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (InterpolatedStringTextSyntax)((InterpolatedStringExpressionSyntax)SyntaxFactory.ParseExpression("$\"Hello world\"")).Contents[0];

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 1);
            Assert.IsTrue(hierarchicalChildren.Contains(node.TextToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.TextToken));
        }

        [TestMethod]
        public void InterpolationServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (InterpolationSyntax)((InterpolatedStringExpressionSyntax)SyntaxFactory.ParseExpression("$\"Hello world {Name, 5:N2}\"")).Contents[1];

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 5);
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenBraceToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Expression));
            Assert.IsTrue(hierarchicalChildren.Contains(node.AlignmentClause));
            Assert.IsTrue(hierarchicalChildren.Contains(node.FormatClause));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseBraceToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(topologicalChildren.Contains(node.Expression));
            Assert.IsTrue(topologicalChildren.Contains(node.AlignmentClause));
            Assert.IsTrue(topologicalChildren.Contains(node.FormatClause));

            node = (InterpolationSyntax)((InterpolatedStringExpressionSyntax)SyntaxFactory.ParseExpression("$\"Hello world  {Name,5}\"")).Contents[1];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 4);
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenBraceToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Expression));
            Assert.IsTrue(hierarchicalChildren.Contains(node.AlignmentClause));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseBraceToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.Expression));
            Assert.IsTrue(topologicalChildren.Contains(node.AlignmentClause));

            node = (InterpolationSyntax)((InterpolatedStringExpressionSyntax)SyntaxFactory.ParseExpression("$\"Hello world  {Name:N2}\"")).Contents[1];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 4);
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenBraceToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Expression));
            Assert.IsTrue(hierarchicalChildren.Contains(node.FormatClause));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseBraceToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.Expression));
            Assert.IsTrue(topologicalChildren.Contains(node.FormatClause));

            node = (InterpolationSyntax)((InterpolatedStringExpressionSyntax)SyntaxFactory.ParseExpression("$\"Hello world {Name}\"")).Contents[1];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 3);
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenBraceToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Expression));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseBraceToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Expression));
        }

        [TestMethod]
        public void InterpolationAlignmentClauseServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = ((InterpolationSyntax)((InterpolatedStringExpressionSyntax)SyntaxFactory.ParseExpression("$\"Hello world {Name, 5:N2}\"")).Contents[1]).AlignmentClause;
            
            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 2);
            Assert.IsTrue(hierarchicalChildren.Contains(node.CommaToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Value));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Value));
        }

        [TestMethod]
        public void InterpolationFormatClauseServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = ((InterpolationSyntax)((InterpolatedStringExpressionSyntax)SyntaxFactory.ParseExpression("$\"Hello world {Name, 5:N2}\"")).Contents[1]).FormatClause;

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 2);
            Assert.IsTrue(hierarchicalChildren.Contains(node.ColonToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.FormatStringToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.FormatStringToken));
        }

        [TestMethod]
        public void ArgumentListServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = ((InvocationExpressionSyntax)SyntaxFactory.ParseExpression("x.F(x, r)")).ArgumentList;

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 5);
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenParenToken));
            Assert.IsTrue(hierarchicalChildren.Contains(hierarchicalChildren[1]));
            Assert.IsTrue(hierarchicalChildren[2].Value.AsToken().Kind() == SyntaxKind.CommaToken);
            Assert.IsTrue(hierarchicalChildren.Contains(hierarchicalChildren[3]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseParenToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(hierarchicalChildren[1]));
            Assert.IsTrue(topologicalChildren.Contains(hierarchicalChildren[3]));
        }

        [TestMethod]
        public void BracketedArgumentListServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = ((ElementAccessExpressionSyntax)SyntaxFactory.ParseExpression("x.F[x, r]")).ArgumentList;

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 5);
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenBracketToken));
            Assert.IsTrue(hierarchicalChildren.Contains(hierarchicalChildren[1]));
            Assert.IsTrue(hierarchicalChildren[2].Value.AsToken().Kind() == SyntaxKind.CommaToken);
            Assert.IsTrue(hierarchicalChildren.Contains(hierarchicalChildren[3]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseBracketToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(hierarchicalChildren[1]));
            Assert.IsTrue(topologicalChildren.Contains(hierarchicalChildren[3]));
        }

        [TestMethod]
        public void ArgumentServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = ((InvocationExpressionSyntax)SyntaxFactory.ParseExpression("x.F(x, r)")).ArgumentList.Arguments[0];

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 1);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Expression));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Expression));

            node = ((InvocationExpressionSyntax)SyntaxFactory.ParseExpression("x.F(ref x, r)")).ArgumentList.Arguments[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 2);
            Assert.IsTrue(hierarchicalChildren.Contains(node.RefKindKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Expression));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Expression));

            node = ((InvocationExpressionSyntax)SyntaxFactory.ParseExpression("x.F(x, out r)")).ArgumentList.Arguments[1];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 2);
            Assert.IsTrue(hierarchicalChildren.Contains(node.RefKindKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Expression));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Expression));

            node = ((InvocationExpressionSyntax)SyntaxFactory.ParseExpression("x.F(a: x, out r)")).ArgumentList.Arguments[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 2);
            Assert.IsTrue(hierarchicalChildren.Contains(node.NameColon));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Expression));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.NameColon));
            Assert.IsTrue(topologicalChildren.Contains(node.Expression));
        }

        [TestMethod]
        public void NameColonServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = ((InvocationExpressionSyntax)SyntaxFactory.ParseExpression("x.F(a: x, r)")).ArgumentList.Arguments[0].NameColon;

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 2);
            Assert.IsTrue(hierarchicalChildren.Contains(node.ColonToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Name));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Name));
        }

        [TestMethod]
        public void NameEqualsServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = ((AnonymousObjectCreationExpressionSyntax)SyntaxFactory.ParseExpression("new { Text = 4, aText = 5 }")).Initializers[0].NameEquals;

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 2);
            Assert.IsTrue(hierarchicalChildren.Contains(node.EqualsToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Name));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Name));
        }

        [TestMethod]
        public void AnonymousObjectMemberDeclaratorServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = ((AnonymousObjectCreationExpressionSyntax)SyntaxFactory.ParseExpression("new { Text = 4, aText = 5 }")).Initializers[0];

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 2);
            Assert.IsTrue(hierarchicalChildren.Contains(node.NameEquals));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Expression));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.NameEquals));
            Assert.IsTrue(topologicalChildren.Contains(node.Expression));
        }

        [TestMethod]
        public void QueryBodyServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = ((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s where f.A select f.R")).Body;

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 2);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Clauses[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SelectOrGroup));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.Clauses[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.SelectOrGroup));

            node = ((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s where f.A select f.R into t")).Body;

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 3);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Clauses[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SelectOrGroup));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Continuation));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(topologicalChildren.Contains(node.Clauses[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.SelectOrGroup));
            Assert.IsTrue(topologicalChildren.Contains(node.Continuation));
        }

        [TestMethod]
        public void FromClauseServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = ((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from T f in s where f.A select f.R")).FromClause;

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 5);
            Assert.IsTrue(hierarchicalChildren.Contains(node.FromKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Type));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.InKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Expression));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(topologicalChildren.Contains(node.Type));
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));
            Assert.IsTrue(topologicalChildren.Contains(node.Expression));

            node = ((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s where f.A select f.R")).FromClause;

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 4);
            Assert.IsTrue(hierarchicalChildren.Contains(node.FromKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.InKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Expression));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));
            Assert.IsTrue(topologicalChildren.Contains(node.Expression));
        }

        [TestMethod]
        public void LetClauseServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = ((LetClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s let y = 5 where f.A select f.R")).Body.Clauses[0]);

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 4);
            Assert.IsTrue(hierarchicalChildren.Contains(node.LetKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.EqualsToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Expression));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));
            Assert.IsTrue(topologicalChildren.Contains(node.Expression));
        }

        [TestMethod]
        public void JoinClauseServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = ((JoinClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s join T t in F on t.L equals s.R into y")).Body.Clauses[0]);

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 10);
            Assert.IsTrue(hierarchicalChildren.Contains(node.JoinKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Type));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.InKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.InExpression));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OnKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.LeftExpression));
            Assert.IsTrue(hierarchicalChildren.Contains(node.EqualsKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.RightExpression));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Into));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 6);
            Assert.IsTrue(topologicalChildren.Contains(node.Type));
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));
            Assert.IsTrue(topologicalChildren.Contains(node.InExpression));
            Assert.IsTrue(topologicalChildren.Contains(node.LeftExpression));
            Assert.IsTrue(topologicalChildren.Contains(node.RightExpression));
            Assert.IsTrue(topologicalChildren.Contains(node.Into));

            node = ((JoinClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s join T t in F on t.L equals s.R")).Body.Clauses[0]);

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 9);
            Assert.IsTrue(hierarchicalChildren.Contains(node.JoinKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Type));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.InKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.InExpression));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OnKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.LeftExpression));
            Assert.IsTrue(hierarchicalChildren.Contains(node.EqualsKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.RightExpression));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 5);
            Assert.IsTrue(topologicalChildren.Contains(node.Type));
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));
            Assert.IsTrue(topologicalChildren.Contains(node.InExpression));
            Assert.IsTrue(topologicalChildren.Contains(node.LeftExpression));
            Assert.IsTrue(topologicalChildren.Contains(node.RightExpression));
        }

        [TestMethod]
        public void JoinIntoClauseServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = ((JoinClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s join T t in F on t.L equals s.R into y")).Body.Clauses[0]).Into;

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 2);
            Assert.IsTrue(hierarchicalChildren.Contains(node.IntoKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));
        }

        [TestMethod]
        public void WhereClauseServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = ((WhereClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from A f in s where y = 5")).Body.Clauses[0]);

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 2);
            Assert.IsTrue(hierarchicalChildren.Contains(node.WhereKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Condition));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Condition));
        }

        [TestMethod]
        public void OrderByClauseServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = ((OrderByClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from A f in s orderby f.y")).Body.Clauses[0]);

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 2);
            Assert.IsTrue(hierarchicalChildren.Contains(node.OrderByKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Orderings[0]));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Orderings[0]));
        }

        [TestMethod]
        public void OrderingServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = ((OrderByClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from A f in s orderby f.y descending")).Body.Clauses[0]).Orderings[0];

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 2);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AscendingOrDescendingKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Expression));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Expression));

            node = ((OrderByClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from A f in s orderby f.y ascending")).Body.Clauses[0]).Orderings[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 2);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AscendingOrDescendingKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Expression));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Expression));

            node = ((OrderByClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from A f in s orderby f.y")).Body.Clauses[0]).Orderings[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 1);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Expression));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Expression));
        }

        [TestMethod]
        public void SelectClauseServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = ((SelectClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from A f in s select f")).Body.SelectOrGroup);

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 2);
            Assert.IsTrue(hierarchicalChildren.Contains(node.SelectKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Expression));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Expression));
        }

        [TestMethod]
        public void GroupClauseServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = ((GroupClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from A f in s group g by f.r")).Body.SelectOrGroup);

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 4);
            Assert.IsTrue(hierarchicalChildren.Contains(node.GroupKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.GroupExpression));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ByKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ByExpression));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.GroupExpression));
            Assert.IsTrue(topologicalChildren.Contains(node.ByExpression));
        }

        [TestMethod]
        public void QueryContinuationServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = ((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from A f in s select f into g select f.r")).Body.Continuation;

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 3);
            Assert.IsTrue(hierarchicalChildren.Contains(node.IntoKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Body));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));
            Assert.IsTrue(topologicalChildren.Contains(node.Body));
        }

        [TestMethod]
        public void PredefinedTypeServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (PredefinedTypeSyntax)SyntaxFactory.ParseTypeName("int");

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 1);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Keyword));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 0);
        }

        [TestMethod]
        public void ArrayTypeServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (ArrayTypeSyntax)SyntaxFactory.ParseTypeName("int[1, 2]");

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 2);
            Assert.IsTrue(hierarchicalChildren.Contains(node.ElementType));
            Assert.IsTrue(hierarchicalChildren.Contains(node.RankSpecifiers[0]));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.ElementType));
            Assert.IsTrue(topologicalChildren.Contains(node.RankSpecifiers[0]));

            node = (ArrayTypeSyntax)SyntaxFactory.ParseTypeName("int[][]");

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 3);
            Assert.IsTrue(hierarchicalChildren.Contains(node.ElementType));
            Assert.IsTrue(hierarchicalChildren.Contains(node.RankSpecifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.RankSpecifiers[1]));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(topologicalChildren.Contains(node.ElementType));
            Assert.IsTrue(topologicalChildren.Contains(node.RankSpecifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.RankSpecifiers[1]));
        }

        [TestMethod]
        public void PointerTypeServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (PointerTypeSyntax)SyntaxFactory.ParseTypeName("int*");

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 2);
            Assert.IsTrue(hierarchicalChildren.Contains(node.ElementType));
            Assert.IsTrue(hierarchicalChildren.Contains(node.AsteriskToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.ElementType));
        }

        [TestMethod]
        public void NullableTypeServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (NullableTypeSyntax)SyntaxFactory.ParseTypeName("int?");

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 2);
            Assert.IsTrue(hierarchicalChildren.Contains(node.ElementType));
            Assert.IsTrue(hierarchicalChildren.Contains(node.QuestionToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.ElementType));
        }

        [TestMethod]
        public void OmittedTypeArgumentServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (OmittedTypeArgumentSyntax)((GenericNameSyntax)SyntaxFactory.ParseName("a<,>")).TypeArgumentList.Arguments[0];

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 1);
            Assert.IsTrue(hierarchicalChildren.Contains(node.OmittedTypeArgumentToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 0);
        }

        [TestMethod]
        public void QualifiedNameServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (QualifiedNameSyntax)SyntaxFactory.ParseName("a.x");

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 3);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Left));
            Assert.IsTrue(hierarchicalChildren.Contains(node.DotToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Right));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.Left));
            Assert.IsTrue(topologicalChildren.Contains(node.Right));
        }

        [TestMethod]
        public void AliasQualifiedNameServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (AliasQualifiedNameSyntax)SyntaxFactory.ParseName("global::c");

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 3);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Alias));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ColonColonToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Name));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.Alias));
            Assert.IsTrue(topologicalChildren.Contains(node.Name));
        }

        [TestMethod]
        public void IdentifierNameServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (IdentifierNameSyntax)SyntaxFactory.ParseName("c");

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 1);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));
        }

        [TestMethod]
        public void GenericNameServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (GenericNameSyntax)SyntaxFactory.ParseName("a<,>");

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 2);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.TypeArgumentList));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));
            Assert.IsTrue(topologicalChildren.Contains(node.TypeArgumentList));
        }

        [TestMethod]
        public void TypeArgumentListServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = ((GenericNameSyntax)SyntaxFactory.ParseName("a<,>")).TypeArgumentList;

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 5);
            Assert.IsTrue(hierarchicalChildren.Contains(node.LessThanToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Arguments[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(hierarchicalChildren[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Arguments[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.GreaterThanToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.Arguments[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Arguments[1]));
        }

        [TestMethod]
        public void ArrayRankSpecifierServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = ((ArrayTypeSyntax)SyntaxFactory.ParseTypeName("int[1, 2]")).RankSpecifiers[0];

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 5);
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenBracketToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Sizes[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(hierarchicalChildren[2]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Sizes[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseBracketToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.Sizes[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Sizes[1]));

            node = ((ArrayTypeSyntax)SyntaxFactory.ParseTypeName("int[][]")).RankSpecifiers[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 3);
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenBracketToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Sizes[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseBracketToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Sizes[0]));
        }

        [TestMethod]
        public void OmittedArraySizeExpressionServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (OmittedArraySizeExpressionSyntax)((ArrayTypeSyntax)SyntaxFactory.ParseTypeName("int[]")).RankSpecifiers[0].Sizes[0];

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 1);
            Assert.IsTrue(hierarchicalChildren.Contains(node.OmittedArraySizeExpressionToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 0);
        }

        [TestMethod]
        public void BlockServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (BlockSyntax)SyntaxFactory.ParseStatement("{ x = 5;x += 3; }");

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 4);
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenBraceToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Statements[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Statements[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseBraceToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.Statements[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Statements[1]));
        }

        [TestMethod]
        public void LocalDeclarationStatementServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (LocalDeclarationStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int a() { const int a; }").Members[0]).Body.Statements[0];

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 3);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Declaration));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Declaration));

            node = (LocalDeclarationStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int a() { int a; }").Members[0]).Body.Statements[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 2);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Declaration));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Declaration));
        }

        [TestMethod]
        public void ExpressionStatementServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (ExpressionStatementSyntax)SyntaxFactory.ParseStatement("3");

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 2);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Expression));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Expression));
        }

        [TestMethod]
        public void EmptyStatementServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (EmptyStatementSyntax)SyntaxFactory.ParseStatement(";");

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 1);
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 0);
        }

        [TestMethod]
        public void LabeledStatementServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (LabeledStatementSyntax)SyntaxFactory.ParseStatement("l: 3");

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 3);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ColonToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Statement));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));
            Assert.IsTrue(topologicalChildren.Contains(node.Statement));
        }

        [TestMethod]
        public void GotoStatementServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (GotoStatementSyntax)SyntaxFactory.ParseStatement("goto l;");

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 3);
            Assert.IsTrue(hierarchicalChildren.Contains(node.GotoKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Expression));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Expression));

            node = (GotoStatementSyntax)SyntaxFactory.ParseStatement("goto case l;");

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 4);
            Assert.IsTrue(hierarchicalChildren.Contains(node.GotoKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CaseOrDefaultKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Expression));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Expression));

            node = (GotoStatementSyntax)SyntaxFactory.ParseStatement("goto default;");

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 3);
            Assert.IsTrue(hierarchicalChildren.Contains(node.GotoKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CaseOrDefaultKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 0);
        }

        [TestMethod]
        public void BreakStatementServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (BreakStatementSyntax)SyntaxFactory.ParseStatement("break;");

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 2);
            Assert.IsTrue(hierarchicalChildren.Contains(node.BreakKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 0);
        }

        [TestMethod]
        public void ContinueStatementServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (ContinueStatementSyntax)SyntaxFactory.ParseStatement("continue;");

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 2);
            Assert.IsTrue(hierarchicalChildren.Contains(node.ContinueKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 0);
        }

        [TestMethod]
        public void ReturnStatementServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (ReturnStatementSyntax)SyntaxFactory.ParseStatement("return 5;");

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 3);
            Assert.IsTrue(hierarchicalChildren.Contains(node.ReturnKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Expression));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Expression));
        }

        [TestMethod]
        public void ThrowStatementServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (ThrowStatementSyntax)SyntaxFactory.ParseStatement("throw 5;");

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 3);
            Assert.IsTrue(hierarchicalChildren.Contains(node.ThrowKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Expression));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Expression));
        }

        [TestMethod]
        public void YieldStatementServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (YieldStatementSyntax)SyntaxFactory.ParseStatement("yield return 5;");

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 4);
            Assert.IsTrue(hierarchicalChildren.Contains(node.YieldKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ReturnOrBreakKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Expression));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Expression));

            node = (YieldStatementSyntax)SyntaxFactory.ParseStatement("yield break;");

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 3);
            Assert.IsTrue(hierarchicalChildren.Contains(node.YieldKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ReturnOrBreakKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 0);
        }

        [TestMethod]
        public void WhileStatementServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (WhileStatementSyntax)SyntaxFactory.ParseStatement("while (x < 0) x = 5;");

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 5);
            Assert.IsTrue(hierarchicalChildren.Contains(node.WhileKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenParenToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Condition));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseParenToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Statement));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.Condition));
            Assert.IsTrue(topologicalChildren.Contains(node.Statement));
        }

        [TestMethod]
        public void DoStatementServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (DoStatementSyntax)SyntaxFactory.ParseStatement("do x = 5; while (x < 0);");

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 7);
            Assert.IsTrue(hierarchicalChildren.Contains(node.DoKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Statement));
            Assert.IsTrue(hierarchicalChildren.Contains(node.WhileKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenParenToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Condition));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseParenToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.Statement));
            Assert.IsTrue(topologicalChildren.Contains(node.Condition));
        }

        [TestMethod]
        public void ForStatementServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (ForStatementSyntax)SyntaxFactory.ParseStatement("for(int a = 0, b = 4; a < 0; a++, --b);");

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 11);
            Assert.IsTrue(hierarchicalChildren.Contains(node.ForKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenParenToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Declaration));
            Assert.IsTrue(hierarchicalChildren.Contains(node.FirstSemicolonToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Condition));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SecondSemicolonToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Incrementors[0]));
            Assert.IsTrue(hierarchicalChildren[7].Value.AsToken().Kind() == SyntaxKind.CommaToken);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Incrementors[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseParenToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Statement));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 5);
            Assert.IsTrue(topologicalChildren.Contains(node.Declaration));
            Assert.IsTrue(topologicalChildren.Contains(node.Condition));
            Assert.IsTrue(topologicalChildren.Contains(node.Incrementors[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Incrementors[1]));
            Assert.IsTrue(topologicalChildren.Contains(node.Statement));

            node = (ForStatementSyntax)SyntaxFactory.ParseStatement("for(a = 0, b = 4; a < 0; a++, --b);");

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 13);
            Assert.IsTrue(hierarchicalChildren.Contains(node.ForKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenParenToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Initializers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Initializers[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.FirstSemicolonToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Condition));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SecondSemicolonToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Incrementors[0]));
            Assert.IsTrue(hierarchicalChildren[9].Value.AsToken().Kind() == SyntaxKind.CommaToken);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Incrementors[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseParenToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Statement));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 6);
            Assert.IsTrue(topologicalChildren.Contains(node.Initializers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Initializers[1]));
            Assert.IsTrue(topologicalChildren.Contains(node.Condition));
            Assert.IsTrue(topologicalChildren.Contains(node.Incrementors[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Incrementors[1]));
            Assert.IsTrue(topologicalChildren.Contains(node.Statement));

            node = (ForStatementSyntax)SyntaxFactory.ParseStatement("for(; a < 0; a++, --b);");

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 10);
            Assert.IsTrue(hierarchicalChildren.Contains(node.ForKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenParenToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.FirstSemicolonToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Condition));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SecondSemicolonToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Incrementors[0]));
            Assert.IsTrue(hierarchicalChildren[6].Value.AsToken().Kind() == SyntaxKind.CommaToken);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Incrementors[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseParenToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Statement));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 4);
            Assert.IsTrue(topologicalChildren.Contains(node.Condition));
            Assert.IsTrue(topologicalChildren.Contains(node.Incrementors[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Incrementors[1]));
            Assert.IsTrue(topologicalChildren.Contains(node.Statement));

            node = (ForStatementSyntax)SyntaxFactory.ParseStatement("for(int a, b = 4; a < 0;);");

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 8);
            Assert.IsTrue(hierarchicalChildren.Contains(node.ForKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenParenToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Declaration));
            Assert.IsTrue(hierarchicalChildren.Contains(node.FirstSemicolonToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Condition));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SecondSemicolonToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseParenToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Statement));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(topologicalChildren.Contains(node.Declaration));
            Assert.IsTrue(topologicalChildren.Contains(node.Condition));
            Assert.IsTrue(topologicalChildren.Contains(node.Statement));
        }

        [TestMethod]
        public void ForEachStatementServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (ForEachStatementSyntax)SyntaxFactory.ParseStatement("foreach(int a in ac);");

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 8);
            Assert.IsTrue(hierarchicalChildren.Contains(node.ForEachKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenParenToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Type));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.InKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Expression));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseParenToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Statement));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 4);
            Assert.IsTrue(topologicalChildren.Contains(node.Type));
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));
            Assert.IsTrue(topologicalChildren.Contains(node.Expression));
            Assert.IsTrue(topologicalChildren.Contains(node.Statement));
        }

        [TestMethod]
        public void UsingStatementServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (UsingStatementSyntax)SyntaxFactory.ParseStatement("using(int a, b = 4);");

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 5);
            Assert.IsTrue(hierarchicalChildren.Contains(node.UsingKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenParenToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Declaration));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseParenToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Statement));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.Declaration));
            Assert.IsTrue(topologicalChildren.Contains(node.Statement));

            node = (UsingStatementSyntax)SyntaxFactory.ParseStatement("using(a);");

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 5);
            Assert.IsTrue(hierarchicalChildren.Contains(node.UsingKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenParenToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Expression));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseParenToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Statement));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.Expression));
            Assert.IsTrue(topologicalChildren.Contains(node.Statement));
        }

        [TestMethod]
        public void FixedStatementServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (FixedStatementSyntax)SyntaxFactory.ParseStatement("fixed(int a, b = 4);");

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 5);
            Assert.IsTrue(hierarchicalChildren.Contains(node.FixedKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenParenToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Declaration));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseParenToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Statement));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.Declaration));
            Assert.IsTrue(topologicalChildren.Contains(node.Statement));
        }

        [TestMethod]
        public void CheckedStatementServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (CheckedStatementSyntax)SyntaxFactory.ParseStatement("checked { x = 5;}");

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 2);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Keyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Block));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Block));
        }

       [TestMethod]
        public void UnsafeStatementServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (UnsafeStatementSyntax)SyntaxFactory.ParseStatement("unsafe { x = 5;}");

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 2);
            Assert.IsTrue(hierarchicalChildren.Contains(node.UnsafeKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Block));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Block));
        }

        [TestMethod]
        public void LockStatementServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (LockStatementSyntax)SyntaxFactory.ParseStatement("lock(b = 4);");

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 5);
            Assert.IsTrue(hierarchicalChildren.Contains(node.LockKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenParenToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Expression));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseParenToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Statement));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.Expression));
            Assert.IsTrue(topologicalChildren.Contains(node.Statement));
        }

        [TestMethod]
        public void IfStatementServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (IfStatementSyntax)SyntaxFactory.ParseStatement("if(b == 4);");

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 5);
            Assert.IsTrue(hierarchicalChildren.Contains(node.IfKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenParenToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Condition));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseParenToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Statement));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.Condition));
            Assert.IsTrue(topologicalChildren.Contains(node.Statement));
        }

        [TestMethod]
        public void SwitchStatementServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (SwitchStatementSyntax)SyntaxFactory.ParseStatement("switch(b){ case default; }");

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 7);
            Assert.IsTrue(hierarchicalChildren.Contains(node.SwitchKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenParenToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Expression));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseParenToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenBraceToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Sections[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseBraceToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.Expression));
            Assert.IsTrue(topologicalChildren.Contains(node.Sections[0]));

            node = (SwitchStatementSyntax)SyntaxFactory.ParseStatement("switch(b){ }");

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 6);
            Assert.IsTrue(hierarchicalChildren.Contains(node.SwitchKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenParenToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Expression));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseParenToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenBraceToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseBraceToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Expression));
        }

        [TestMethod]
        public void TryStatementServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch(A1){a1 = \"Catch a1\";} catch(B1) when(e = 5) {b1 = \"Catch b1\";} finally{c1 = \"Finnally1\";}");

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 5);
            Assert.IsTrue(hierarchicalChildren.Contains(node.TryKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Block));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Catches[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Catches[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Finally));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 4);
            Assert.IsTrue(topologicalChildren.Contains(node.Block));
            Assert.IsTrue(topologicalChildren.Contains(node.Catches[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Catches[1]));
            Assert.IsTrue(topologicalChildren.Contains(node.Finally));

            node = (TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} finally{c1 = \"Finnally1\";}");

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 3);
            Assert.IsTrue(hierarchicalChildren.Contains(node.TryKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Block));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Finally));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.Block));
            Assert.IsTrue(topologicalChildren.Contains(node.Finally));

            node = (TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch(A1){a1 = \"Catch a1\";} catch(B1) when(e = 5) {b1 = \"Catch b1\";}");

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 4);
            Assert.IsTrue(hierarchicalChildren.Contains(node.TryKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Block));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Catches[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Catches[1]));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(topologicalChildren.Contains(node.Block));
            Assert.IsTrue(topologicalChildren.Contains(node.Catches[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Catches[1]));
        }

        [TestMethod]
        public void VariableDeclarationServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = ((FixedStatementSyntax)SyntaxFactory.ParseStatement("fixed(int a, b = 4);")).Declaration;

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 4);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Type));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Variables[0]));
            Assert.IsTrue(hierarchicalChildren[2].Value.AsToken().Kind() == SyntaxKind.CommaToken);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Variables[1]));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(topologicalChildren.Contains(node.Type));
            Assert.IsTrue(topologicalChildren.Contains(node.Variables[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Variables[1]));
        }

        [TestMethod]
        public void VariableDeclaratorServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = ((FixedStatementSyntax)SyntaxFactory.ParseStatement("fixed(int a, b = 4);")).Declaration.Variables[0];

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 1);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));

            node = ((FixedStatementSyntax)SyntaxFactory.ParseStatement("fixed(int a = 2, b = 4);")).Declaration.Variables[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 2);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Initializer));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));
            Assert.IsTrue(topologicalChildren.Contains(node.Initializer));
        }

        [TestMethod]
        public void EqualsValueClauseServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = ((FixedStatementSyntax)SyntaxFactory.ParseStatement("fixed(int a, b = 4);")).Declaration.Variables[1].Initializer;

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 2);
            Assert.IsTrue(hierarchicalChildren.Contains(node.EqualsToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Value));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Value));
        }

        [TestMethod]
        public void ElseClauseServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = ((IfStatementSyntax)SyntaxFactory.ParseStatement("if(b == 4); else;")).Else;

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 2);
            Assert.IsTrue(hierarchicalChildren.Contains(node.ElseKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Statement));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Statement));
        }

        [TestMethod]
        public void SwitchSectionServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = ((SwitchStatementSyntax)SyntaxFactory.ParseStatement("switch(b){ case default:; }")).Sections[0];

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 2);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Labels[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Statements[0]));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.Labels[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Statements[0]));
        }

        [TestMethod]
        public void CaseSwitchLabelServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (CaseSwitchLabelSyntax)((SwitchStatementSyntax)SyntaxFactory.ParseStatement("switch(b){ case 4: return 4; default: return 10; }")).Sections[0].Labels[0];

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 3);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Keyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Value));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ColonToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Value));
        }

        [TestMethod]
        public void DefaultSwitchLabelServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (DefaultSwitchLabelSyntax)((SwitchStatementSyntax)SyntaxFactory.ParseStatement("switch(b){ default:; }")).Sections[0].Labels[0];

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 2);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Keyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ColonToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 0);
        }

        [TestMethod]
        public void CatchClauseServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = ((TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch(A1 a) when(e = 5) {a1 = \"Catch a1\";}")).Catches[0];

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 4);
            Assert.IsTrue(hierarchicalChildren.Contains(node.CatchKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Declaration));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Filter));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Block));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(topologicalChildren.Contains(node.Declaration));
            Assert.IsTrue(topologicalChildren.Contains(node.Filter));
            Assert.IsTrue(topologicalChildren.Contains(node.Block));

            node = ((TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch(A1){a1 = \"Catch a1\";}")).Catches[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 3);
            Assert.IsTrue(hierarchicalChildren.Contains(node.CatchKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Declaration));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Block));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.Declaration));
            Assert.IsTrue(topologicalChildren.Contains(node.Block));

            node = ((TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch {b1 = \"Catch b1\";}")).Catches[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 2);
            Assert.IsTrue(hierarchicalChildren.Contains(node.CatchKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Block));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Block));
        }

        [TestMethod]
        public void CatchDeclarationServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = ((TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch(A1 a) when(e = 5) {a1 = \"Catch a1\";}")).Catches[0].Declaration;

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 4);
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenParenToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Type));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseParenToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.Type));
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));

            node = ((TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch(A1){a1 = \"Catch a1\";}")).Catches[0].Declaration;

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 3);
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenParenToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Type));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseParenToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Type));
        }

        [TestMethod]
        public void CatchFilterClauseServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = ((TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch(A1 a) when(e = 5) {a1 = \"Catch a1\";}")).Catches[0].Filter;

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 4);
            Assert.IsTrue(hierarchicalChildren.Contains(node.WhenKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenParenToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.FilterExpression));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseParenToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.FilterExpression));
        }

        [TestMethod]
        public void FinallyClauseServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = ((TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} finally {a1 = \"Catch a1\";}")).Finally;

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 2);
            Assert.IsTrue(hierarchicalChildren.Contains(node.FinallyKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Block));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Block));
        }

        [TestMethod]
        public void IncompleteMemberServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (IncompleteMemberSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public a").Members[0];

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 3);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Type));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Type));

            node = (IncompleteMemberSyntax)SyntaxFactory.ParseCompilationUnit("public a").Members[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 2);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Type));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Type));

            node = (IncompleteMemberSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] a").Members[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 2);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Type));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Type));
        }

        [TestMethod]
        public void GlobalStatementServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = Microsoft.CodeAnalysis.CSharp.SyntaxFactory.GlobalStatement(SyntaxFactory.ParseStatement("x++"));

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 1);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Statement));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Statement));
        }

        [TestMethod]
        public void DelegateDeclarationServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (DelegateDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public delegate void Del<T>(string str) where T: I;").Members[0];

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 9);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.DelegateKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ReturnType));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.TypeParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ConstraintClauses[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 7);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ReturnType));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.TypeParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ConstraintClauses[0]));

            node = (DelegateDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public delegate void Del<T>(string str) where T: I;").Members[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 8);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.DelegateKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ReturnType));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.TypeParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ConstraintClauses[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 6);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ReturnType));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.TypeParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ConstraintClauses[0]));

            node = (DelegateDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] delegate void Del<T>(string str) where T: I;").Members[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 8);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.DelegateKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ReturnType));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.TypeParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ConstraintClauses[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 6);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ReturnType));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.TypeParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ConstraintClauses[0]));

            node = (DelegateDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public delegate void Del(string str) where T: I;").Members[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 8);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.DelegateKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ReturnType));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ConstraintClauses[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 6);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ReturnType));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ConstraintClauses[0]));

            node = (DelegateDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public delegate void Del<T>(string str);").Members[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 8);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.DelegateKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ReturnType));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.TypeParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 6);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ReturnType));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.TypeParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ParameterList));
        }

        [TestMethod]
        public void EnumDeclarationServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (EnumDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public enum a : byte {a1, a2 = 3};").Members[0];

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 11);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.EnumKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.BaseList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenBraceToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Members[0]));
            Assert.IsTrue(hierarchicalChildren[7].Value.AsToken().Kind() == SyntaxKind.CommaToken);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Members[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseBraceToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 6);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.BaseList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Members[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Members[1]));

            node = (EnumDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public enum a : byte {a1, a2 = 3};").Members[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 10);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.EnumKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.BaseList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenBraceToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Members[0]));
            Assert.IsTrue(hierarchicalChildren[6].Value.AsToken().Kind() == SyntaxKind.CommaToken);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Members[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseBraceToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 5);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.BaseList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Members[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Members[1]));

            node = (EnumDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] enum a : byte {a1, a2 = 3};").Members[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 10);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.EnumKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.BaseList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenBraceToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Members[0]));
            Assert.IsTrue(hierarchicalChildren[6].Value.AsToken().Kind() == SyntaxKind.CommaToken);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Members[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseBraceToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 5);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.BaseList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Members[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Members[1]));

            node = (EnumDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public enum a {a1, a2 = 3};").Members[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 10);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.EnumKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenBraceToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Members[0]));
            Assert.IsTrue(hierarchicalChildren[6].Value.AsToken().Kind() == SyntaxKind.CommaToken);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Members[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseBraceToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 5);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Members[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Members[1]));

            node = (EnumDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public enum a : byte {a1, a2 = 3}").Members[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 10);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.EnumKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.BaseList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenBraceToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Members[0]));
            Assert.IsTrue(hierarchicalChildren[7].Value.AsToken().Kind() == SyntaxKind.CommaToken);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Members[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseBraceToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 6);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.BaseList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Members[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Members[1]));
        }

        [TestMethod]
        public void ClassDeclarationServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public class a<T> : byte where T : int  {X a1; Y a2 = 3;};").Members[0];

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 12);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Keyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.TypeParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.BaseList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ConstraintClauses[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenBraceToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Members[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Members[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseBraceToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 8);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));
            Assert.IsTrue(topologicalChildren.Contains(node.TypeParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.BaseList));
            Assert.IsTrue(topologicalChildren.Contains(node.ConstraintClauses[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Members[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Members[1]));

            node = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class a<T> : byte where T : int  {X a1; Y a2 = 3;};").Members[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 11);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Keyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.TypeParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.BaseList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ConstraintClauses[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenBraceToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Members[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Members[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseBraceToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 7);
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));
            Assert.IsTrue(topologicalChildren.Contains(node.TypeParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.BaseList));
            Assert.IsTrue(topologicalChildren.Contains(node.ConstraintClauses[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Members[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Members[1]));

            node = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] class a<T> : byte where T : int  {X a1; Y a2 = 3;};").Members[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 11);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Keyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.TypeParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.BaseList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ConstraintClauses[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenBraceToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Members[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Members[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseBraceToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 7);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));
            Assert.IsTrue(topologicalChildren.Contains(node.TypeParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.BaseList));
            Assert.IsTrue(topologicalChildren.Contains(node.ConstraintClauses[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Members[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Members[1]));

            node = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public class a : byte where T : int  {X a1; Y a2 = 3;};").Members[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 11);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Keyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.BaseList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ConstraintClauses[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenBraceToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Members[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Members[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseBraceToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 7);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));
            Assert.IsTrue(topologicalChildren.Contains(node.BaseList));
            Assert.IsTrue(topologicalChildren.Contains(node.ConstraintClauses[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Members[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Members[1]));

            node = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public class a<T> where T : int  {X a1; Y a2 = 3;};").Members[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 11);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Keyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.TypeParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ConstraintClauses[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenBraceToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Members[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Members[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseBraceToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 7);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));
            Assert.IsTrue(topologicalChildren.Contains(node.TypeParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.ConstraintClauses[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Members[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Members[1]));

            node = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public class a<T> : byte where T : int  {X a1; Y a2 = 3;}").Members[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 11);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Keyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.TypeParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.BaseList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ConstraintClauses[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenBraceToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Members[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Members[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseBraceToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 8);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));
            Assert.IsTrue(topologicalChildren.Contains(node.TypeParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.BaseList));
            Assert.IsTrue(topologicalChildren.Contains(node.ConstraintClauses[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Members[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Members[1]));
        }

        [TestMethod]
        public void StructDeclarationServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (StructDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public struct a<T> : byte where T : int  {X a1; Y a2 = 3;};").Members[0];

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 12);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Keyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.TypeParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.BaseList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ConstraintClauses[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenBraceToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Members[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Members[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseBraceToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 8);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));
            Assert.IsTrue(topologicalChildren.Contains(node.TypeParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.BaseList));
            Assert.IsTrue(topologicalChildren.Contains(node.ConstraintClauses[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Members[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Members[1]));

            node = (StructDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public struct a<T> : byte where T : int  {X a1; Y a2 = 3;};").Members[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 11);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Keyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.TypeParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.BaseList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ConstraintClauses[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenBraceToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Members[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Members[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseBraceToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 7);
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));
            Assert.IsTrue(topologicalChildren.Contains(node.TypeParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.BaseList));
            Assert.IsTrue(topologicalChildren.Contains(node.ConstraintClauses[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Members[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Members[1]));

            node = (StructDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] struct a<T> : byte where T : int  {X a1; Y a2 = 3;};").Members[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 11);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Keyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.TypeParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.BaseList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ConstraintClauses[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenBraceToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Members[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Members[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseBraceToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 7);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));
            Assert.IsTrue(topologicalChildren.Contains(node.TypeParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.BaseList));
            Assert.IsTrue(topologicalChildren.Contains(node.ConstraintClauses[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Members[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Members[1]));

            node = (StructDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public struct a : byte where T : int  {X a1; Y a2 = 3;};").Members[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 11);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Keyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.BaseList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ConstraintClauses[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenBraceToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Members[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Members[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseBraceToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 7);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));
            Assert.IsTrue(topologicalChildren.Contains(node.BaseList));
            Assert.IsTrue(topologicalChildren.Contains(node.ConstraintClauses[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Members[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Members[1]));

            node = (StructDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public struct a<T> where T : int  {X a1; Y a2 = 3;};").Members[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 11);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Keyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.TypeParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ConstraintClauses[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenBraceToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Members[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Members[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseBraceToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 7);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));
            Assert.IsTrue(topologicalChildren.Contains(node.TypeParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.ConstraintClauses[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Members[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Members[1]));

            node = (StructDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public struct a<T> : byte where T : int  {X a1; Y a2 = 3;}").Members[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 11);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Keyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.TypeParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.BaseList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ConstraintClauses[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenBraceToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Members[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Members[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseBraceToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 8);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));
            Assert.IsTrue(topologicalChildren.Contains(node.TypeParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.BaseList));
            Assert.IsTrue(topologicalChildren.Contains(node.ConstraintClauses[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Members[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Members[1]));
        }

        [TestMethod]
        public void InterfaceDeclarationServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (InterfaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public interface a<T> : byte where T : int  {X a1; Y a2 = 3;};").Members[0];

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 12);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Keyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.TypeParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.BaseList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ConstraintClauses[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenBraceToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Members[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Members[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseBraceToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 8);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));
            Assert.IsTrue(topologicalChildren.Contains(node.TypeParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.BaseList));
            Assert.IsTrue(topologicalChildren.Contains(node.ConstraintClauses[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Members[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Members[1]));

            node = (InterfaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public interface a<T> : byte where T : int  {X a1; Y a2 = 3;};").Members[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 11);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Keyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.TypeParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.BaseList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ConstraintClauses[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenBraceToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Members[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Members[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseBraceToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 7);
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));
            Assert.IsTrue(topologicalChildren.Contains(node.TypeParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.BaseList));
            Assert.IsTrue(topologicalChildren.Contains(node.ConstraintClauses[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Members[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Members[1]));

            node = (InterfaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] interface a<T> : byte where T : int  {X a1; Y a2 = 3;};").Members[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 11);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Keyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.TypeParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.BaseList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ConstraintClauses[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenBraceToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Members[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Members[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseBraceToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 7);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));
            Assert.IsTrue(topologicalChildren.Contains(node.TypeParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.BaseList));
            Assert.IsTrue(topologicalChildren.Contains(node.ConstraintClauses[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Members[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Members[1]));

            node = (InterfaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public interface a : byte where T : int  {X a1; Y a2 = 3;};").Members[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 11);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Keyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.BaseList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ConstraintClauses[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenBraceToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Members[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Members[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseBraceToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 7);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));
            Assert.IsTrue(topologicalChildren.Contains(node.BaseList));
            Assert.IsTrue(topologicalChildren.Contains(node.ConstraintClauses[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Members[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Members[1]));

            node = (InterfaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public interface a<T> where T : int  {X a1; Y a2 = 3;};").Members[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 11);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Keyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.TypeParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ConstraintClauses[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenBraceToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Members[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Members[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseBraceToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 7);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));
            Assert.IsTrue(topologicalChildren.Contains(node.TypeParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.ConstraintClauses[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Members[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Members[1]));

            node = (InterfaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public interface a<T> : byte where T : int  {X a1; Y a2 = 3;}").Members[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 11);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Keyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.TypeParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.BaseList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ConstraintClauses[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenBraceToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Members[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Members[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseBraceToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 8);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));
            Assert.IsTrue(topologicalChildren.Contains(node.TypeParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.BaseList));
            Assert.IsTrue(topologicalChildren.Contains(node.ConstraintClauses[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Members[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Members[1]));
        }

        [TestMethod]
        public void EnumMemberDeclarationServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = ((EnumDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public enum a : byte {a1, [Serializable] a2 = 3};").Members[0]).Members[1];

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 3);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.EqualsValue));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.EqualsValue));

            node = ((EnumDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public enum a : byte {a1, a2 = 3};").Members[0]).Members[1];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 2);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.EqualsValue));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.EqualsValue));

            node = ((EnumDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public enum a : byte {a1, [Serializable] a2};").Members[0]).Members[1];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 2);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
        }

        [TestMethod]
        public void TypeParameterListServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<B, in C> {}").Members[0]).TypeParameterList;

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 5);
            Assert.IsTrue(hierarchicalChildren.Contains(node.LessThanToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Parameters[0]));
            Assert.IsTrue(hierarchicalChildren[2].Value.AsToken().Kind() == SyntaxKind.CommaToken);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Parameters[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.GreaterThanToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.Parameters[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Parameters[1]));
        }

        [TestMethod]
        public void TypeParameterServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<[Serializable] in B, in C> {}").Members[0]).TypeParameterList.Parameters[0];

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 3);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.VarianceKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));

            node = ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<in B, in C> {}").Members[0]).TypeParameterList.Parameters[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 2);
            Assert.IsTrue(hierarchicalChildren.Contains(node.VarianceKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));
        }

        [TestMethod]
        public void TypeParameterConstraintClauseServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<T> : byte where T : new(), class {};").Members[0]).ConstraintClauses[0];

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 6);
            Assert.IsTrue(hierarchicalChildren.Contains(node.WhereKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Name));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ColonToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Constraints[0]));
            Assert.IsTrue(hierarchicalChildren[4].Value.AsToken().Kind() == SyntaxKind.CommaToken);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Constraints[1]));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(topologicalChildren.Contains(node.Name));
            Assert.IsTrue(topologicalChildren.Contains(node.Constraints[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Constraints[1]));
        }

        [TestMethod]
        public void TypeConstraintServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (TypeConstraintSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<T> : byte where T : A {};").Members[0]).ConstraintClauses[0].Constraints[0];

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 1);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Type));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Type));
        }

        [TestMethod]
        public void ConstructorConstraintServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (ConstructorConstraintSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<T> : byte where T : new() {};").Members[0]).ConstraintClauses[0].Constraints[0];

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 3);
            Assert.IsTrue(hierarchicalChildren.Contains(node.NewKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenParenToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseParenToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 0);
        }

        [TestMethod]
        public void ClassOrStructConstraintServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (ClassOrStructConstraintSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<T> : byte where T : class {};").Members[0]).ConstraintClauses[0].Constraints[0];

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 1);
            Assert.IsTrue(hierarchicalChildren.Contains(node.ClassOrStructKeyword));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 0);

            node = (ClassOrStructConstraintSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<T> : byte where T : struct {};").Members[0]).ConstraintClauses[0].Constraints[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 1);
            Assert.IsTrue(hierarchicalChildren.Contains(node.ClassOrStructKeyword));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 0);
        }

        [TestMethod]
        public void BaseListServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<T> : A, I where T : A {};").Members[0]).BaseList;

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 4);
            Assert.IsTrue(hierarchicalChildren.Contains(node.ColonToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Types[0]));
            Assert.IsTrue(hierarchicalChildren[2].Value.AsToken().Kind() == SyntaxKind.CommaToken);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Types[1]));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.Types[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Types[1]));
        }

        [TestMethod]
        public void SimpleBaseTypeServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<T> : A, I where T : A {};").Members[0]).BaseList.Types[0];

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 1);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Type));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Type));
        }

        [TestMethod]
        public void FieldDeclarationServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (FieldDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a {[Serializable]public int df;}").Members[0]).Members[0];

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 4);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Declaration));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Declaration));

            node = (FieldDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a {public int df;}").Members[0]).Members[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 3);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Declaration));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Declaration));

            node = (FieldDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a {[Serializable] int df;}").Members[0]).Members[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 3);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Declaration));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Declaration));
        }

        [TestMethod]
        public void EventFieldDeclarationServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (EventFieldDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a {[Serializable]public event int df;}").Members[0]).Members[0];

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 5);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.EventKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Declaration));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Declaration));

            node = (EventFieldDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a {public event int df;}").Members[0]).Members[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 4);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.EventKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Declaration));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Declaration));

            node = (EventFieldDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a {[Serializable] event int df;}").Members[0]).Members[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 4);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.EventKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Declaration));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Declaration));
        }

        [TestMethod]
        public void ExplicitInterfaceSpecifierServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = ((EventDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a {event B IA.a1{add; remove;}}").Members[0]).Members[0]).ExplicitInterfaceSpecifier;

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 2);
            Assert.IsTrue(hierarchicalChildren.Contains(node.DotToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Name));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Name));
        }

        [TestMethod]
        public void MethodDeclarationServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M<T>(int a, A b)where T: class { return 5; };").Members[0];

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 11);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ReturnType));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ExplicitInterfaceSpecifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.TypeParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ConstraintClauses[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Body));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 10);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[1]));
            Assert.IsTrue(topologicalChildren.Contains(node.ReturnType));
            Assert.IsTrue(topologicalChildren.Contains(node.ExplicitInterfaceSpecifier));
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));
            Assert.IsTrue(topologicalChildren.Contains(node.TypeParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.ConstraintClauses[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Body));

            node = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M<T>(int a, A b)where T: class => 5;").Members[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 11);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ReturnType));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ExplicitInterfaceSpecifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.TypeParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ConstraintClauses[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ExpressionBody));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 10);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[1]));
            Assert.IsTrue(topologicalChildren.Contains(node.ReturnType));
            Assert.IsTrue(topologicalChildren.Contains(node.ExplicitInterfaceSpecifier));
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));
            Assert.IsTrue(topologicalChildren.Contains(node.TypeParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.ConstraintClauses[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.ExpressionBody));

            node = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public virtual string C.M<T>(int a, A b)where T: class { return 5; };").Members[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 10);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ReturnType));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ExplicitInterfaceSpecifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.TypeParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ConstraintClauses[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Body));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 9);
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[1]));
            Assert.IsTrue(topologicalChildren.Contains(node.ReturnType));
            Assert.IsTrue(topologicalChildren.Contains(node.ExplicitInterfaceSpecifier));
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));
            Assert.IsTrue(topologicalChildren.Contains(node.TypeParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.ConstraintClauses[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Body));

            node = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public virtual string C.M<T>(int a, A b)where T: class => 5;").Members[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 10);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ReturnType));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ExplicitInterfaceSpecifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.TypeParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ConstraintClauses[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ExpressionBody));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 9);
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[1]));
            Assert.IsTrue(topologicalChildren.Contains(node.ReturnType));
            Assert.IsTrue(topologicalChildren.Contains(node.ExplicitInterfaceSpecifier));
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));
            Assert.IsTrue(topologicalChildren.Contains(node.TypeParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.ConstraintClauses[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.ExpressionBody));

            node = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] virtual string C.M<T>(int a, A b)where T: class { return 5; };").Members[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 10);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ReturnType));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ExplicitInterfaceSpecifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.TypeParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ConstraintClauses[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Body));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 9);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.ReturnType));
            Assert.IsTrue(topologicalChildren.Contains(node.ExplicitInterfaceSpecifier));
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));
            Assert.IsTrue(topologicalChildren.Contains(node.TypeParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.ConstraintClauses[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Body));

            node = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public string C.M<T>(int a, A b)where T: class => 5;").Members[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 10);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ReturnType));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ExplicitInterfaceSpecifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.TypeParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ConstraintClauses[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ExpressionBody));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 9);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.ReturnType));
            Assert.IsTrue(topologicalChildren.Contains(node.ExplicitInterfaceSpecifier));
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));
            Assert.IsTrue(topologicalChildren.Contains(node.TypeParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.ConstraintClauses[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.ExpressionBody));

            node = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string M<T>(int a, A b)where T: class { return 5; };").Members[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 10);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ReturnType));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.TypeParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ConstraintClauses[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Body));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 9);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[1]));
            Assert.IsTrue(topologicalChildren.Contains(node.ReturnType));
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));
            Assert.IsTrue(topologicalChildren.Contains(node.TypeParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.ConstraintClauses[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Body));

            node = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string M<T>(int a, A b)where T: class => 5;").Members[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 10);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ReturnType));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.TypeParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ConstraintClauses[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ExpressionBody));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 9);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[1]));
            Assert.IsTrue(topologicalChildren.Contains(node.ReturnType));
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));
            Assert.IsTrue(topologicalChildren.Contains(node.TypeParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.ConstraintClauses[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.ExpressionBody));

            node = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M(int a, A b)where T: class { return 5; };").Members[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 10);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ReturnType));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ExplicitInterfaceSpecifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ConstraintClauses[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Body));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 9);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[1]));
            Assert.IsTrue(topologicalChildren.Contains(node.ReturnType));
            Assert.IsTrue(topologicalChildren.Contains(node.ExplicitInterfaceSpecifier));
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));
            Assert.IsTrue(topologicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.ConstraintClauses[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Body));

            node = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M(int a, A b)where T: class => 5;").Members[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 10);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ReturnType));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ExplicitInterfaceSpecifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ConstraintClauses[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ExpressionBody));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 9);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[1]));
            Assert.IsTrue(topologicalChildren.Contains(node.ReturnType));
            Assert.IsTrue(topologicalChildren.Contains(node.ExplicitInterfaceSpecifier));
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));
            Assert.IsTrue(topologicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.ConstraintClauses[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.ExpressionBody));

            node = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M<T>(int a, A b) { return 5; };").Members[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 10);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ReturnType));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ExplicitInterfaceSpecifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.TypeParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Body));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 9);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[1]));
            Assert.IsTrue(topologicalChildren.Contains(node.ReturnType));
            Assert.IsTrue(topologicalChildren.Contains(node.ExplicitInterfaceSpecifier));
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));
            Assert.IsTrue(topologicalChildren.Contains(node.TypeParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.Body));

            node = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M<T>(int a, A b) => 5;").Members[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 10);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ReturnType));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ExplicitInterfaceSpecifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.TypeParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ExpressionBody));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 9);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[1]));
            Assert.IsTrue(topologicalChildren.Contains(node.ReturnType));
            Assert.IsTrue(topologicalChildren.Contains(node.ExplicitInterfaceSpecifier));
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));
            Assert.IsTrue(topologicalChildren.Contains(node.TypeParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.ExpressionBody));

            node = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M<T>(int a, A b)where T: class { return 5; }").Members[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 10);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ReturnType));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ExplicitInterfaceSpecifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.TypeParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ConstraintClauses[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Body));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 10);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[1]));
            Assert.IsTrue(topologicalChildren.Contains(node.ReturnType));
            Assert.IsTrue(topologicalChildren.Contains(node.ExplicitInterfaceSpecifier));
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));
            Assert.IsTrue(topologicalChildren.Contains(node.TypeParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.ConstraintClauses[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Body));
        }

        [TestMethod]
        public void OperatorDeclarationServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string operator +(int a, A b) { return 5; };").Members[0];

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 9);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ReturnType));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OperatorKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OperatorToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Body));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 7);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[1]));
            Assert.IsTrue(topologicalChildren.Contains(node.ReturnType));
            Assert.IsTrue(topologicalChildren.Contains(node.OperatorToken));
            Assert.IsTrue(topologicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.Body));

            node = (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string operator +(int a, A b) => 5;").Members[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 9);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ReturnType));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OperatorKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OperatorToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ExpressionBody));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 7);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[1]));
            Assert.IsTrue(topologicalChildren.Contains(node.ReturnType));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OperatorToken));
            Assert.IsTrue(topologicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.ExpressionBody));

            node = (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public virtual string operator +(int a, A b) { return 5; };").Members[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 8);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ReturnType));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OperatorKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OperatorToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Body));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 6);
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[1]));
            Assert.IsTrue(topologicalChildren.Contains(node.ReturnType));
            Assert.IsTrue(topologicalChildren.Contains(node.OperatorToken));
            Assert.IsTrue(topologicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.Body));

            node = (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public virtual string operator +(int a, A b) => 5;").Members[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 8);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ReturnType));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OperatorKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OperatorToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ExpressionBody));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 6);
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[1]));
            Assert.IsTrue(topologicalChildren.Contains(node.ReturnType));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OperatorToken));
            Assert.IsTrue(topologicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.ExpressionBody));

            node = (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public string operator +(int a, A b) { return 5; };").Members[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 8);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ReturnType));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OperatorKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OperatorToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Body));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 6);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.ReturnType));
            Assert.IsTrue(topologicalChildren.Contains(node.OperatorToken));
            Assert.IsTrue(topologicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.Body));

            node = (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] virtual string operator +(int a, A b) => 5;").Members[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 8);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ReturnType));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OperatorKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OperatorToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ExpressionBody));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 6);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.ReturnType));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OperatorToken));
            Assert.IsTrue(topologicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.ExpressionBody));

            node = (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string operator +(int a, A b) { return 5; }").Members[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 8);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ReturnType));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OperatorKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OperatorToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Body));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 7);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[1]));
            Assert.IsTrue(topologicalChildren.Contains(node.ReturnType));
            Assert.IsTrue(topologicalChildren.Contains(node.OperatorToken));
            Assert.IsTrue(topologicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.Body));
        }

        [TestMethod]
        public void ConversionOperatorDeclarationServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (ConversionOperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual implicit operator T(A b) { return 5; };").Members[0];

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 9);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ImplicitOrExplicitKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OperatorKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Type));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Body));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 6);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[1]));
            Assert.IsTrue(topologicalChildren.Contains(node.Type));
            Assert.IsTrue(topologicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.Body));

            node = (ConversionOperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual implicit operator T(A b) => 5;").Members[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 9);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ImplicitOrExplicitKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OperatorKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Type));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ExpressionBody));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 6);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Type));
            Assert.IsTrue(topologicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.ExpressionBody));

            node = (ConversionOperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public virtual implicit operator T(A b) { return 5; };").Members[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 8);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ImplicitOrExplicitKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OperatorKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Type));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Body));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 5);
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[1]));
            Assert.IsTrue(topologicalChildren.Contains(node.Type));
            Assert.IsTrue(topologicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.Body));

            node = (ConversionOperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public virtual implicit operator T(A b) => 5;").Members[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 8);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ImplicitOrExplicitKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OperatorKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Type));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ExpressionBody));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 5);
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Type));
            Assert.IsTrue(topologicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.ExpressionBody));

            node = (ConversionOperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public implicit operator T(A b) { return 5; };").Members[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 8);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ImplicitOrExplicitKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OperatorKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Type));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Body));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 5);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Type));
            Assert.IsTrue(topologicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.Body));

            node = (ConversionOperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] virtual implicit operator T(A b) => 5;").Members[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 8);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ImplicitOrExplicitKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OperatorKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Type));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ExpressionBody));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 5);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Type));
            Assert.IsTrue(topologicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.ExpressionBody));

            node = (ConversionOperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public operator T(A b) { return 5; };").Members[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 8);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ImplicitOrExplicitKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OperatorKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Type));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Body));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 5);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Type));
            Assert.IsTrue(topologicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.Body));

            node = (ConversionOperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] virtual operator T(A b) => 5;").Members[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 8);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ImplicitOrExplicitKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OperatorKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Type));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ExpressionBody));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 5);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Type));
            Assert.IsTrue(topologicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.ExpressionBody));

            node = (ConversionOperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual implicit operator T(A b) { return 5; }").Members[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 8);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ImplicitOrExplicitKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OperatorKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Type));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Body));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 6);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[1]));
            Assert.IsTrue(topologicalChildren.Contains(node.Type));
            Assert.IsTrue(topologicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.Body));
        }

        [TestMethod]
        public void ConstructorDeclarationServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation]public A(B b) : this(b) { }; }").Members[0]).Members[0];

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 7);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Initializer));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Body));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 6);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));
            Assert.IsTrue(topologicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.Initializer));
            Assert.IsTrue(topologicalChildren.Contains(node.Body));

            node = (ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { public A(B b) : this(b) { }; }").Members[0]).Members[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 6);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Initializer));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Body));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 5);
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));
            Assert.IsTrue(topologicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.Initializer));
            Assert.IsTrue(topologicalChildren.Contains(node.Body));

            node = (ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation] A(B b) : this(b) { }; }").Members[0]).Members[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 6);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Initializer));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Body));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 5);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));
            Assert.IsTrue(topologicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.Initializer));
            Assert.IsTrue(topologicalChildren.Contains(node.Body));

            node = (ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation]public A(B b) { }; }").Members[0]).Members[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 6);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Body));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 5);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));
            Assert.IsTrue(topologicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.Body));

            node = (ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation]public A(B b) : this(b) { } }").Members[0]).Members[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 6);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Initializer));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Body));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 6);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));
            Assert.IsTrue(topologicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.Initializer));
            Assert.IsTrue(topologicalChildren.Contains(node.Body));
        }

        [TestMethod]
        public void ConstructorInitializerServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = ((ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation]public A(B b) : this(b) { }; }").Members[0]).Members[0]).Initializer;

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 3);
            Assert.IsTrue(hierarchicalChildren.Contains(node.ColonToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ThisOrBaseKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ArgumentList));


            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.ArgumentList));
        }

        [TestMethod]
        public void DestructorDeclarationServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (DestructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation] internal ~A(){ }; }").Members[0]).Members[0];

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 7);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.TildeToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Body));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 5);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));
            Assert.IsTrue(topologicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.Body));

            node = (DestructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation] ~A(){ }; }").Members[0]).Members[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 6);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.TildeToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Body));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 4);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));
            Assert.IsTrue(topologicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.Body));

            node = (DestructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation] internal ~A(){ } }").Members[0]).Members[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 6);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.TildeToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Body));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 5);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));
            Assert.IsTrue(topologicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.Body));
        }

        [TestMethod]
        public void PropertyDeclarationServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M { get{return 5;} set{this.a = 7} } = 3;").Members[0];

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 9);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Type));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ExplicitInterfaceSpecifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.AccessorList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Initializer));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 8);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[1]));
            Assert.IsTrue(topologicalChildren.Contains(node.Type));
            Assert.IsTrue(topologicalChildren.Contains(node.ExplicitInterfaceSpecifier));
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));
            Assert.IsTrue(topologicalChildren.Contains(node.AccessorList));
            Assert.IsTrue(topologicalChildren.Contains(node.Initializer));

            node = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public virtual string C.M { get{return 5;} set{this.a = 7} } = 3;").Members[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 8);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Type));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ExplicitInterfaceSpecifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.AccessorList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Initializer));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 7);
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[1]));
            Assert.IsTrue(topologicalChildren.Contains(node.Type));
            Assert.IsTrue(topologicalChildren.Contains(node.ExplicitInterfaceSpecifier));
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));
            Assert.IsTrue(topologicalChildren.Contains(node.AccessorList));
            Assert.IsTrue(topologicalChildren.Contains(node.Initializer));

            node = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] virtual string C.M { get{return 5;} set{this.a = 7} } = 3;").Members[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 8);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Type));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ExplicitInterfaceSpecifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.AccessorList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Initializer));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 7);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Type));
            Assert.IsTrue(topologicalChildren.Contains(node.ExplicitInterfaceSpecifier));
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));
            Assert.IsTrue(topologicalChildren.Contains(node.AccessorList));
            Assert.IsTrue(topologicalChildren.Contains(node.Initializer));

            node = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string M { get{return 5;} set{this.a = 7} } = 3;").Members[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 8);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Type));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.AccessorList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Initializer));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 7);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[1]));
            Assert.IsTrue(topologicalChildren.Contains(node.Type));
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));
            Assert.IsTrue(topologicalChildren.Contains(node.AccessorList));
            Assert.IsTrue(topologicalChildren.Contains(node.Initializer));

            node = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M { get; set; }").Members[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 7);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Type));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ExplicitInterfaceSpecifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.AccessorList));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 7);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[1]));
            Assert.IsTrue(topologicalChildren.Contains(node.Type));
            Assert.IsTrue(topologicalChildren.Contains(node.ExplicitInterfaceSpecifier));
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));
            Assert.IsTrue(topologicalChildren.Contains(node.AccessorList));
            
            node = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M { get{return 5;} set{this.a = 7} } => 3;").Members[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 9);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Type));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ExplicitInterfaceSpecifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.AccessorList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ExpressionBody));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 8);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[1]));
            Assert.IsTrue(topologicalChildren.Contains(node.Type));
            Assert.IsTrue(topologicalChildren.Contains(node.ExplicitInterfaceSpecifier));
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));
            Assert.IsTrue(topologicalChildren.Contains(node.AccessorList));
            Assert.IsTrue(topologicalChildren.Contains(node.ExpressionBody));

            node = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public virtual string C.M { get{return 5;} set{this.a = 7} } => 3;").Members[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 8);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Type));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ExplicitInterfaceSpecifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.AccessorList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ExpressionBody));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 7);
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[1]));
            Assert.IsTrue(topologicalChildren.Contains(node.Type));
            Assert.IsTrue(topologicalChildren.Contains(node.ExplicitInterfaceSpecifier));
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));
            Assert.IsTrue(topologicalChildren.Contains(node.AccessorList));
            Assert.IsTrue(topologicalChildren.Contains(node.ExpressionBody));

            node = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] virtual string C.M { get{return 5;} set{this.a = 7} } => 3;").Members[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 8);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Type));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ExplicitInterfaceSpecifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.AccessorList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ExpressionBody));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 7);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Type));
            Assert.IsTrue(topologicalChildren.Contains(node.ExplicitInterfaceSpecifier));
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));
            Assert.IsTrue(topologicalChildren.Contains(node.AccessorList));
            Assert.IsTrue(topologicalChildren.Contains(node.ExpressionBody));

            node = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string M { get{return 5;} set{this.a = 7} } => 3;").Members[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 8);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Type));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.AccessorList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ExpressionBody));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 7);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[1]));
            Assert.IsTrue(topologicalChildren.Contains(node.Type));
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));
            Assert.IsTrue(topologicalChildren.Contains(node.AccessorList));
            Assert.IsTrue(topologicalChildren.Contains(node.ExpressionBody));

            node = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M {get; set;};").Members[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 8);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Type));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ExplicitInterfaceSpecifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.AccessorList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 7);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[1]));
            Assert.IsTrue(topologicalChildren.Contains(node.Type));
            Assert.IsTrue(topologicalChildren.Contains(node.ExplicitInterfaceSpecifier));
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));
            Assert.IsTrue(topologicalChildren.Contains(node.AccessorList));
        }

        [TestMethod]
        public void ArrowExpressionClauseServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = ((PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M { get{return 5;} set{this.a = 7} } => 3;").Members[0]).ExpressionBody;

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 2);
            Assert.IsTrue(hierarchicalChildren.Contains(node.ArrowToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Expression));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Expression));
        }

        [TestMethod]
        public void EventDeclarationServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A C.M { add; remove; }").Members[0];

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 8);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Type));
            Assert.IsTrue(hierarchicalChildren.Contains(node.EventKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ExplicitInterfaceSpecifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.AccessorList));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 7);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[1]));
            Assert.IsTrue(topologicalChildren.Contains(node.Type));
            Assert.IsTrue(topologicalChildren.Contains(node.ExplicitInterfaceSpecifier));
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));
            Assert.IsTrue(topologicalChildren.Contains(node.AccessorList));

            node = (EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public virtual event A C.M { add; remove; }").Members[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 7);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Type));
            Assert.IsTrue(hierarchicalChildren.Contains(node.EventKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ExplicitInterfaceSpecifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.AccessorList));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 6);
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[1]));
            Assert.IsTrue(topologicalChildren.Contains(node.Type));
            Assert.IsTrue(topologicalChildren.Contains(node.ExplicitInterfaceSpecifier));
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));
            Assert.IsTrue(topologicalChildren.Contains(node.AccessorList));

            node = (EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] virtual event A C.M { add; remove; }").Members[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 7);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Type));
            Assert.IsTrue(hierarchicalChildren.Contains(node.EventKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ExplicitInterfaceSpecifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.AccessorList));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 6);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Type));
            Assert.IsTrue(topologicalChildren.Contains(node.ExplicitInterfaceSpecifier));
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));
            Assert.IsTrue(topologicalChildren.Contains(node.AccessorList));

            node = (EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A M { add; remove; }").Members[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 7);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Type));
            Assert.IsTrue(hierarchicalChildren.Contains(node.EventKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.AccessorList));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 6);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[1]));
            Assert.IsTrue(topologicalChildren.Contains(node.Type));
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));
            Assert.IsTrue(topologicalChildren.Contains(node.AccessorList));
        }

        [TestMethod]
        public void IndexerDeclarationServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A C.this[string key] { get; set; } => 5;").Members[0];

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 10);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Type));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ExplicitInterfaceSpecifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ThisKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.AccessorList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ExpressionBody));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 8);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[1]));
            Assert.IsTrue(topologicalChildren.Contains(node.Type));
            Assert.IsTrue(topologicalChildren.Contains(node.ExplicitInterfaceSpecifier));
            Assert.IsTrue(topologicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.AccessorList));
            Assert.IsTrue(topologicalChildren.Contains(node.ExpressionBody));

            node = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public virtual A C.this[string key] { get; set; } => 5;").Members[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 9);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Type));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ExplicitInterfaceSpecifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ThisKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.AccessorList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ExpressionBody));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 7);
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[1]));
            Assert.IsTrue(topologicalChildren.Contains(node.Type));
            Assert.IsTrue(topologicalChildren.Contains(node.ExplicitInterfaceSpecifier));
            Assert.IsTrue(topologicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.AccessorList));
            Assert.IsTrue(topologicalChildren.Contains(node.ExpressionBody));

            node = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] virtual A C.this[string key] { get; set; } => 5;").Members[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 9);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Type));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ExplicitInterfaceSpecifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ThisKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.AccessorList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ExpressionBody));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 7);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Type));
            Assert.IsTrue(topologicalChildren.Contains(node.ExplicitInterfaceSpecifier));
            Assert.IsTrue(topologicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.AccessorList));
            Assert.IsTrue(topologicalChildren.Contains(node.ExpressionBody));

            node = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A this[string key] { get; set; } => 5;").Members[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 9);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Type));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ThisKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.AccessorList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ExpressionBody));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 7);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[1]));
            Assert.IsTrue(topologicalChildren.Contains(node.Type));
            Assert.IsTrue(topologicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.AccessorList));
            Assert.IsTrue(topologicalChildren.Contains(node.ExpressionBody));

            node = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A C.this[string key] { get; set; };").Members[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 9);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Type));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ExplicitInterfaceSpecifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ThisKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.AccessorList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 7);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[1]));
            Assert.IsTrue(topologicalChildren.Contains(node.Type));
            Assert.IsTrue(topologicalChildren.Contains(node.ExplicitInterfaceSpecifier));
            Assert.IsTrue(topologicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.AccessorList));

            node = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A C.this[string key] { get; set; }").Members[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 8);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Type));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ExplicitInterfaceSpecifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ThisKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.AccessorList));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 7);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[1]));
            Assert.IsTrue(topologicalChildren.Contains(node.Type));
            Assert.IsTrue(topologicalChildren.Contains(node.ExplicitInterfaceSpecifier));
            Assert.IsTrue(topologicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.AccessorList));
        }

        [TestMethod]
        public void AccessorListServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = ((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A C.this[string key] { get; set; } => 5;").Members[0]).AccessorList;

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 4);
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenBraceToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Accessors[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Accessors[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseBraceToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.Accessors[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Accessors[1]));
        }

        [TestMethod]
        public void AccessorDeclarationServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = ((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A C.this[string key] { [Serializable] private get{}; set; }").Members[0]).AccessorList.Accessors[0];

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 5);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Keyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Body));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Body));

            node = ((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A C.this[string key] { private get{}; set; }").Members[0]).AccessorList.Accessors[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 4);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Keyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Body));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Body));

            node = ((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A C.this[string key] { [Serializable] get{}; set; }").Members[0]).AccessorList.Accessors[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 4);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Keyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Body));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Body));

            node = ((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A C.this[string key] { [Serializable] private get; set; }").Members[0]).AccessorList.Accessors[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 4);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Keyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));

            node = ((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A C.this[string key] { [Serializable] private get{} set; }").Members[0]).AccessorList.Accessors[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 4);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Keyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Body));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Body));

            node = ((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A C.this[string key] { [Serializable] private set{}; get; }").Members[0]).AccessorList.Accessors[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 5);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Keyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Body));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Body));

            node = ((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A C.this[string key] { private set{}; get; }").Members[0]).AccessorList.Accessors[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 4);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Keyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Body));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Body));

            node = ((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A C.this[string key] { [Serializable] set{}; get; }").Members[0]).AccessorList.Accessors[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 4);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Keyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Body));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Body));

            node = ((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A C.this[string key] { [Serializable] private set; get; }").Members[0]).AccessorList.Accessors[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 4);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Keyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));

            node = ((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A C.this[string key] { [Serializable] private set{} get; }").Members[0]).AccessorList.Accessors[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 4);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Keyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Body));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Body));

            node = ((EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A C.M { [Serializable] private add{}; remove; }").Members[0]).AccessorList.Accessors[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 5);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Keyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Body));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Body));

            node = ((EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A C.M { private add{}; remove; }").Members[0]).AccessorList.Accessors[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 4);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Keyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Body));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Body));

            node = ((EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A C.M { [Serializable] add{}; remove; }").Members[0]).AccessorList.Accessors[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 4);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Keyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Body));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Body));

            node = ((EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A C.M { [Serializable] private add; remove; }").Members[0]).AccessorList.Accessors[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 4);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Keyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));

            node = ((EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A C.M { [Serializable] private add{} remove; }").Members[0]).AccessorList.Accessors[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 4);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Keyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Body));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Body));

            node = ((EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A C.M { [Serializable] private remove{}; add; }").Members[0]).AccessorList.Accessors[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 5);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Keyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Body));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Body));

            node = ((EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A C.M { private remove{}; add; }").Members[0]).AccessorList.Accessors[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 4);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Keyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Body));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Body));

            node = ((EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A C.M { [Serializable] remove{}; add; }").Members[0]).AccessorList.Accessors[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 4);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Keyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Body));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Body));

            node = ((EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A C.M { [Serializable] private remove; add; }").Members[0]).AccessorList.Accessors[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 4);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Keyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));

            node = ((EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A C.M { [Serializable] private remove{} add; }").Members[0]).AccessorList.Accessors[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 4);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Keyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Body));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Body));

            node = ((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A C.this[string key] { [Serializable] private fg{}; get; }").Members[0]).AccessorList.Accessors[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 5);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Keyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Body));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 4);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Keyword));
            Assert.IsTrue(topologicalChildren.Contains(node.Body));

            node = ((PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public virtual int A { private set{}; get; }").Members[0]).AccessorList.Accessors[0];
            node = SyntaxFactory.AccessorDeclaration(SyntaxKind.UnknownAccessorDeclaration, node.AttributeLists, node.Modifiers, SyntaxFactory.Identifier("fg"), node.Body, node.ExpressionBody, node.SemicolonToken);

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 4);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Keyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Body));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Keyword));
            Assert.IsTrue(topologicalChildren.Contains(node.Body));

            node = ((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A C.this[string key] { [Serializable] fg{}; get; }").Members[0]).AccessorList.Accessors[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 4);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Keyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Body));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Body));
            Assert.IsTrue(topologicalChildren.Contains(node.Keyword));

            node = ((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A C.this[string key] { [Serializable] private fg; get; }").Members[0]).AccessorList.Accessors[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 4);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Keyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Keyword));

            node = ((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A C.this[string key] { [Serializable] private fg{} get; }").Members[0]).AccessorList.Accessors[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 4);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Keyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Body));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 4);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Keyword));
            Assert.IsTrue(topologicalChildren.Contains(node.Body));
        }

        [TestMethod]
        public void ParameterListServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = ((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int M([Serializable] ref int a = 0, A b){}").Members[0]).ParameterList;

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 5);
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenParenToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Parameters[0]));
            Assert.IsTrue(hierarchicalChildren[2].Value.Kind() == SyntaxKind.CommaToken);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Parameters[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseParenToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.Parameters[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Parameters[1]));
        }

        [TestMethod]
        public void BracketedParameterListServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = ((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int this[[Serializable] ref int a = 0, A b]{get;set;}").Members[0]).ParameterList;

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 5);
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenBracketToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Parameters[0]));
            Assert.IsTrue(hierarchicalChildren[2].Value.Kind() == SyntaxKind.CommaToken);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Parameters[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseBracketToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.Parameters[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Parameters[1]));
        }

        [TestMethod]
        public void ParameterServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = ((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int M([Serializable] ref int a = 0, A b){}").Members[0]).ParameterList.Parameters[0];

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 5);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Type));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Default));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 5);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Type));
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));
            Assert.IsTrue(topologicalChildren.Contains(node.Default));

            node = ((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int M(ref int a = 0, A b){}").Members[0]).ParameterList.Parameters[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 4);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Type));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Default));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 4);
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Type));
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));
            Assert.IsTrue(topologicalChildren.Contains(node.Default));

            node = ((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int M([Serializable] int a = 0, A b){}").Members[0]).ParameterList.Parameters[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 4);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Type));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Default));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 4);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Type));
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));
            Assert.IsTrue(topologicalChildren.Contains(node.Default));

            node = ((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int M([Serializable] ref int a, A b){}").Members[0]).ParameterList.Parameters[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 4);
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Type));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 4);
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Type));
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));
        }

        [TestMethod]
        public void SkippedTokensTriviaServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = SyntaxFactory.SkippedTokensTrivia(((IncompleteMemberSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual a").Members[0]).Modifiers);

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 2);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Tokens[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Tokens[1]));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.Tokens[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Tokens[1]));
        }

        [TestMethod]
        public void DocumentationCommentTriviaServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<foo />").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure();

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 2);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Content[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.EndOfComment));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Content[0]));

            node = (DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree(@"/// <summary>" + 
                                                                                    "/// Method hook for implementing logic to execute after the <see cref=\"ChildrenCore(SyntaxNodeOrToken ?)\"/>." + 
                                                                                    "/// </summary>" + 
                                                                                    "/// <param name=\"node\">node of interest.</param>" +
                                                                                    "/// <param name=\"result\">Mechanism to modify the result of <see cref=\"Children(SyntaxNodeOrToken?)\"/>.</param>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure();

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 7);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Content[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Content[1]));
            Assert.IsTrue(((XmlElementSyntax)node.Content[1]).StartTag.Name.LocalName.ValueText == "summary");
            Assert.IsTrue(hierarchicalChildren.Contains(node.Content[2]));
            Assert.IsTrue(((XmlTextSyntax)node.Content[2]).TextTokens[0].ValueText == "/// ");
            Assert.IsTrue(hierarchicalChildren.Contains(node.Content[3]));
            Assert.IsTrue(((XmlElementSyntax)node.Content[3]).StartTag.Name.LocalName.ValueText == "param");
            Assert.IsTrue(hierarchicalChildren.Contains(node.Content[4]));
            Assert.IsTrue(((XmlTextSyntax)node.Content[4]).TextTokens[0].ValueText == "/// ");
            Assert.IsTrue(hierarchicalChildren.Contains(node.Content[5]));
            Assert.IsTrue(((XmlElementSyntax)node.Content[5]).StartTag.Name.LocalName.ValueText == "param");
            Assert.IsTrue(hierarchicalChildren.Contains(node.EndOfComment));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(topologicalChildren.Contains(node.Content[1]));
            Assert.IsTrue(topologicalChildren.Contains(node.Content[3]));
            Assert.IsTrue(topologicalChildren.Contains(node.Content[5]));
        }

        [TestMethod]
        public void EndIfDirectiveTriviaServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = SyntaxFactory.EndIfDirectiveTrivia(true);

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 3);
            Assert.IsTrue(hierarchicalChildren.Contains(node.HashToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.EndIfKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.EndOfDirectiveToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 0);
        }

        [TestMethod]
        public void RegionDirectiveTriviaServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = SyntaxFactory.RegionDirectiveTrivia(true);

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 3);
            Assert.IsTrue(hierarchicalChildren.Contains(node.HashToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.RegionKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.EndOfDirectiveToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 0);
        }

        [TestMethod]
        public void EndRegionDirectiveTriviaServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = SyntaxFactory.EndRegionDirectiveTrivia(true);

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 3);
            Assert.IsTrue(hierarchicalChildren.Contains(node.HashToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.EndRegionKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.EndOfDirectiveToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 0);
        }

        [TestMethod]
        public void ErrorDirectiveTriviaServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = SyntaxFactory.ErrorDirectiveTrivia(true);

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 3);
            Assert.IsTrue(hierarchicalChildren.Contains(node.HashToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ErrorKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.EndOfDirectiveToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 0);
        }

        [TestMethod]
        public void WarningDirectiveTriviaServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = SyntaxFactory.WarningDirectiveTrivia(true);

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 3);
            Assert.IsTrue(hierarchicalChildren.Contains(node.HashToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.WarningKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.EndOfDirectiveToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 0);
        }

        [TestMethod]
        public void BadDirectiveTriviaServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = SyntaxFactory.BadDirectiveTrivia(SyntaxFactory.Identifier("unknown"), true);

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 3);
            Assert.IsTrue(hierarchicalChildren.Contains(node.HashToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.EndOfDirectiveToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));
        }

        [TestMethod]
        public void DefineDirectiveTriviaServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = SyntaxFactory.DefineDirectiveTrivia(SyntaxFactory.Identifier("DEBUG"), true);

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 4);
            Assert.IsTrue(hierarchicalChildren.Contains(node.HashToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.DefineKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Name));
            Assert.IsTrue(hierarchicalChildren.Contains(node.EndOfDirectiveToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Name));
        }

        [TestMethod]
        public void UndefDirectiveTriviaServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = SyntaxFactory.UndefDirectiveTrivia(SyntaxFactory.Identifier("DEBUG"), true);

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 4);
            Assert.IsTrue(hierarchicalChildren.Contains(node.HashToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.UndefKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Name));
            Assert.IsTrue(hierarchicalChildren.Contains(node.EndOfDirectiveToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Name));
        }

        [TestMethod]
        public void LineDirectiveTriviaServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = SyntaxFactory.LineDirectiveTrivia(SyntaxFactory.Literal("200", 200), SyntaxFactory.Literal("\"Special\""), true);

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 5);
            Assert.IsTrue(hierarchicalChildren.Contains(node.HashToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.LineKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Line));
            Assert.IsTrue(hierarchicalChildren.Contains(node.File));
            Assert.IsTrue(hierarchicalChildren.Contains(node.EndOfDirectiveToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.Line));
            Assert.IsTrue(topologicalChildren.Contains(node.File));
        }

        [TestMethod]
        public void PragmaWarningDirectiveTriviaServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var separatedSyntaxList = SyntaxFactory.SeparatedList(new ExpressionSyntax[] { SyntaxFactory.IdentifierName("warning-list"), SyntaxFactory.IdentifierName("CS3021") });
            var node = SyntaxFactory.PragmaWarningDirectiveTrivia(SyntaxFactory.Token(SyntaxKind.DisableKeyword), separatedSyntaxList, true);

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 8);
            Assert.IsTrue(hierarchicalChildren.Contains(node.HashToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.PragmaKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.WarningKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.DisableOrRestoreKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ErrorCodes[0]));
            Assert.IsTrue(hierarchicalChildren[5].Value.Kind() == SyntaxKind.CommaToken);
            Assert.IsTrue(hierarchicalChildren.Contains(node.ErrorCodes[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.EndOfDirectiveToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(topologicalChildren.Contains(node.DisableOrRestoreKeyword));
            Assert.IsTrue(topologicalChildren.Contains(node.ErrorCodes[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.ErrorCodes[1]));
        }

        [TestMethod]
        public void PragmaChecksumDirectiveTriviaServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = SyntaxFactory.PragmaChecksumDirectiveTrivia(SyntaxFactory.Literal("\"file.cs\""), SyntaxFactory.Literal("\"{3673e4ca-6098-4ec1-890f-8fceb2a794a2}\""), SyntaxFactory.Literal("\"{012345678AB}\""), true);

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 7);
            Assert.IsTrue(hierarchicalChildren.Contains(node.HashToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.PragmaKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ChecksumKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.File));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Guid));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Bytes));
            Assert.IsTrue(hierarchicalChildren.Contains(node.EndOfDirectiveToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(topologicalChildren.Contains(node.File));
            Assert.IsTrue(topologicalChildren.Contains(node.Guid));
            Assert.IsTrue(topologicalChildren.Contains(node.Bytes));
        }

        [TestMethod]
        public void ReferenceDirectiveTriviaServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = SyntaxFactory.ReferenceDirectiveTrivia(SyntaxFactory.Literal("DEBUG"), true);

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 4);
            Assert.IsTrue(hierarchicalChildren.Contains(node.HashToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ReferenceKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.File));
            Assert.IsTrue(hierarchicalChildren.Contains(node.EndOfDirectiveToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.File));
        }

        [TestMethod]
        public void LoadDirectiveTriviaServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = SyntaxFactory.LoadDirectiveTrivia(SyntaxFactory.Literal("DEBUG"), true);

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 4);
            Assert.IsTrue(hierarchicalChildren.Contains(node.HashToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.LoadKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.File));
            Assert.IsTrue(hierarchicalChildren.Contains(node.EndOfDirectiveToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.File));
        }

        [TestMethod]
        public void ShebangDirectiveTriviaServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = SyntaxFactory.ShebangDirectiveTrivia(true);

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 3);
            Assert.IsTrue(hierarchicalChildren.Contains(node.HashToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ExclamationToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.EndOfDirectiveToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 0);
        }

        [TestMethod]
        public void ElseDirectiveTriviaServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = SyntaxFactory.ElseDirectiveTrivia(true, true);

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 3);
            Assert.IsTrue(hierarchicalChildren.Contains(node.HashToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ElseKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.EndOfDirectiveToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 0);
        }

        [TestMethod]
        public void IfDirectiveTriviaServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (IfDirectiveTriviaSyntax)SyntaxFactory.ParseSyntaxTree("#if DEBUG Console.WriteLine(\"Debug version\"); #endif").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure();

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 4);
            Assert.IsTrue(hierarchicalChildren.Contains(node.HashToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.IfKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Condition));
            Assert.IsTrue(hierarchicalChildren.Contains(node.EndOfDirectiveToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Condition));
        }

        [TestMethod]
        public void ElifDirectiveTriviaServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = SyntaxFactory.ElifDirectiveTrivia(SyntaxFactory.IdentifierName("VC7"), true, true, true);

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 4);
            Assert.IsTrue(hierarchicalChildren.Contains(node.HashToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ElifKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Condition));
            Assert.IsTrue(hierarchicalChildren.Contains(node.EndOfDirectiveToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Condition));
        }

        [TestMethod]
        public void TypeCrefServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var text = "namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"int\"/> </summary>" + Environment.NewLine +
                       "    class A { } }";
            var namespaceNode = SyntaxFactory.ParseCompilationUnit(text).Members[0];
            var node = namespaceNode.DescendantNodes(descendIntoTrivia: true).OfType<TypeCrefSyntax>().Single();

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 1);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Type));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Type));
        }

        [TestMethod]
        public void QualifiedCrefServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var text = "namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"N.A\"/> </summary>" + Environment.NewLine +
                       "    class A { } }";
            var namespaceNode = SyntaxFactory.ParseCompilationUnit(text).Members[0];
            var node = namespaceNode.DescendantNodes(descendIntoTrivia: true).OfType<QualifiedCrefSyntax>().Single();

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 3);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Container));
            Assert.IsTrue(hierarchicalChildren.Contains(node.DotToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Member));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.Container));
            Assert.IsTrue(topologicalChildren.Contains(node.Member));
        }

        [TestMethod]
        public void NameMemberCrefServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var text = "namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"N(int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }";
            var namespaceNode = SyntaxFactory.ParseCompilationUnit(text).Members[0];
            var node = namespaceNode.DescendantNodes(descendIntoTrivia: true).OfType<NameMemberCrefSyntax>().Single();

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 2);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Name));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Parameters));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.Name));
            Assert.IsTrue(topologicalChildren.Contains(node.Parameters));
            
            var text3 = "namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"N\"/> </summary>" + Environment.NewLine +
                       "    class A { } }";
            namespaceNode = SyntaxFactory.ParseCompilationUnit(text3).Members[0];
            node = namespaceNode.DescendantNodes(descendIntoTrivia: true).OfType<NameMemberCrefSyntax>().Single();

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 1);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Name));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Name));
        }

        [TestMethod]
        public void IndexerMemberCrefServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var text = "namespace N { " + Environment.NewLine +
                        "    /// <summary> <see cref=\"this[int]\"/> </summary>" + Environment.NewLine +
                        "    class A { } }";
            var namespaceNode = SyntaxFactory.ParseCompilationUnit(text).Members[0];
            var node = namespaceNode.DescendantNodes(descendIntoTrivia: true).OfType<IndexerMemberCrefSyntax>().Single();

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 2);
            Assert.IsTrue(hierarchicalChildren.Contains(node.ThisKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Parameters));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Parameters));

            var text3 = "namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"this\"/> </summary>" + Environment.NewLine +
                       "    class A { } }";
            namespaceNode = SyntaxFactory.ParseCompilationUnit(text3).Members[0];
            node = namespaceNode.DescendantNodes(descendIntoTrivia: true).OfType<IndexerMemberCrefSyntax>().Single();

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 1);
            Assert.IsTrue(hierarchicalChildren.Contains(node.ThisKeyword));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 0);
        }

        [TestMethod]
        public void OperatorMemberCrefServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var text = "namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }";
            var namespaceNode = SyntaxFactory.ParseCompilationUnit(text).Members[0];
            var node = namespaceNode.DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single();

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 3);
            Assert.IsTrue(hierarchicalChildren.Contains(node.OperatorKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OperatorToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Parameters));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.OperatorToken));
            Assert.IsTrue(topologicalChildren.Contains(node.Parameters));

            var text3 = "namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +\"/> </summary>" + Environment.NewLine +
                       "    class A { } }";
            namespaceNode = SyntaxFactory.ParseCompilationUnit(text3).Members[0];
            node = namespaceNode.DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single();

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 2);
            Assert.IsTrue(hierarchicalChildren.Contains(node.OperatorKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OperatorToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.OperatorToken));
        }

        [TestMethod]
        public void ConversionOperatorMemberCrefServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var text = "namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"implicit operator N(int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }";
            var namespaceNode = SyntaxFactory.ParseCompilationUnit(text).Members[0];
            var node = namespaceNode.DescendantNodes(descendIntoTrivia: true).OfType<ConversionOperatorMemberCrefSyntax>().Single();

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 4);
            Assert.IsTrue(hierarchicalChildren.Contains(node.ImplicitOrExplicitKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OperatorKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Type));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Parameters));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.Type));
            Assert.IsTrue(topologicalChildren.Contains(node.Parameters));

            text = "namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"explicit operator N\"/> </summary>" + Environment.NewLine +
                       "    class A { } }";
            namespaceNode = SyntaxFactory.ParseCompilationUnit(text).Members[0];
            node = namespaceNode.DescendantNodes(descendIntoTrivia: true).OfType<ConversionOperatorMemberCrefSyntax>().Single();

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 3);
            Assert.IsTrue(hierarchicalChildren.Contains(node.ImplicitOrExplicitKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OperatorKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Type));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Type));
        }

        [TestMethod]
        public void CrefParameterListServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var text = "namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(int, string)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }";
            var namespaceNode = SyntaxFactory.ParseCompilationUnit(text).Members[0];
            var node = namespaceNode.DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 5);
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenParenToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Parameters[0]));
            Assert.IsTrue(hierarchicalChildren[2].Value.Kind() == SyntaxKind.CommaToken);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Parameters[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseParenToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.Parameters[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Parameters[1]));
        }

        [TestMethod]
        public void CrefBracketedParameterListServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var text = "namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"this[int, string]\"/> </summary>" + Environment.NewLine +
                       "    class A { } }";
            var namespaceNode = SyntaxFactory.ParseCompilationUnit(text).Members[0];
            var node = namespaceNode.DescendantNodes(descendIntoTrivia: true).OfType<IndexerMemberCrefSyntax>().Single().Parameters;

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 5);
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenBracketToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Parameters[0]));
            Assert.IsTrue(hierarchicalChildren[2].Value.Kind() == SyntaxKind.CommaToken);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Parameters[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseBracketToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.Parameters[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Parameters[1]));
        }

        [TestMethod]
        public void CrefParameterServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var text = "namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref int, out string)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }";
            var namespaceNode = SyntaxFactory.ParseCompilationUnit(text).Members[0];
            var node = namespaceNode.DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 2);
            Assert.IsTrue(hierarchicalChildren.Contains(node.RefKindKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Type));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Type));

            text = "namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(int, string)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }";
            namespaceNode = SyntaxFactory.ParseCompilationUnit(text).Members[0];
            node = namespaceNode.DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 1);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Type));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Type));
        }

        [TestMethod]
        public void XmlElementServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (XmlElementSyntax)((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.Single();

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 3);
            Assert.IsTrue(hierarchicalChildren.Contains(node.StartTag));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Content[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.EndTag));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(topologicalChildren.Contains(node.StartTag));
            Assert.IsTrue(topologicalChildren.Contains(node.Content[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.EndTag));
        }

        [TestMethod]
        public void XmlElementStartTagServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag;

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 5);
            Assert.IsTrue(hierarchicalChildren.Contains(node.LessThanToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Name));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Attributes[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Attributes[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.GreaterThanToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(topologicalChildren.Contains(node.Name));
            Assert.IsTrue(topologicalChildren.Contains(node.Attributes[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Attributes[1]));
        }

        [TestMethod]
        public void XmlElementEndTagServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().EndTag;

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 3);
            Assert.IsTrue(hierarchicalChildren.Contains(node.LessThanSlashToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Name));
            Assert.IsTrue(hierarchicalChildren.Contains(node.GreaterThanToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Name));
        }

        [TestMethod]
        public void XmlEmptyElementServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<foo id=\"3\"/>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlEmptyElementSyntax>().Single();

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 4);
            Assert.IsTrue(hierarchicalChildren.Contains(node.LessThanToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Name));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Attributes[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SlashGreaterThanToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.Name));
            Assert.IsTrue(topologicalChildren.Contains(node.Attributes[0]));

            node = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<foo/>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlEmptyElementSyntax>().Single();

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 3);
            Assert.IsTrue(hierarchicalChildren.Contains(node.LessThanToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Name));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SlashGreaterThanToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Name));
        }

        [TestMethod]
        public void XmlNameServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<d:foo/>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlEmptyElementSyntax>().Single().Name;

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 2);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Prefix));
            Assert.IsTrue(hierarchicalChildren.Contains(node.LocalName));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.Prefix));
            Assert.IsTrue(topologicalChildren.Contains(node.LocalName));

            node = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<foo/>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlEmptyElementSyntax>().Single().Name;

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 1);
            Assert.IsTrue(hierarchicalChildren.Contains(node.LocalName));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.LocalName));
        }

        [TestMethod]
        public void XmlPrefixServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<d:foo/>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlEmptyElementSyntax>().Single().Name.Prefix;

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 2);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Prefix));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ColonToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Prefix));
        }

        [TestMethod]
        public void XmlTextAttributeServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (XmlTextAttributeSyntax)((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<message id=\"5 r\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag.Attributes[0];

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 5);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Name));
            Assert.IsTrue(hierarchicalChildren.Contains(node.EqualsToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.StartQuoteToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.TextTokens[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.EndQuoteToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.Name));
            Assert.IsTrue(topologicalChildren.Contains(node.TextTokens[0]));
        }

        [TestMethod]
        public void XmlCrefAttributeServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (XmlCrefAttributeSyntax)((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<see cref=\"M\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag.Attributes[0];

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 5);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Name));
            Assert.IsTrue(hierarchicalChildren.Contains(node.EqualsToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.StartQuoteToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Cref));
            Assert.IsTrue(hierarchicalChildren.Contains(node.EndQuoteToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Cref));
        }

        [TestMethod]
        public void XmlNameAttributeServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (XmlNameAttributeSyntax)((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<param name=\"M\"/>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlEmptyElementSyntax>().Single().Attributes[0];

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 5);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Name));
            Assert.IsTrue(hierarchicalChildren.Contains(node.EqualsToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.StartQuoteToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.EndQuoteToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));
        }

        [TestMethod]
        public void XmlTextServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (XmlTextSyntax)((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<foo>bar</foo>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().Content[0];

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 1);
            Assert.IsTrue(hierarchicalChildren.Contains(node.TextTokens[0]));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.TextTokens[0]));
        }

        [TestMethod]
        public void XmlCDataSectionServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<![CDATA[this is a test of &some; cdata]]>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlCDataSectionSyntax>().Single();

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 3);
            Assert.IsTrue(hierarchicalChildren.Contains(node.StartCDataToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.TextTokens[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.EndCDataToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.TextTokens[0]));
        }

        [TestMethod]
        public void XmlProcessingInstructionServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<?proc-inst this is a test of &some; processinginstruction?>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlProcessingInstructionSyntax>().Single();

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 4);
            Assert.IsTrue(hierarchicalChildren.Contains(node.StartProcessingInstructionToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Name));
            Assert.IsTrue(hierarchicalChildren.Contains(node.TextTokens[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.EndProcessingInstructionToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.Name));
            Assert.IsTrue(topologicalChildren.Contains(node.TextTokens[0]));
        }

        [TestMethod]
        public void XmlCommentServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<!--this is a test of &some; comment-->").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlCommentSyntax>().Single();

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 3);
            Assert.IsTrue(hierarchicalChildren.Contains(node.LessThanExclamationMinusMinusToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.TextTokens[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.MinusMinusGreaterThanToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.TextTokens[0]));
        }

        [TestMethod]
        public void CompilationUnitServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = SyntaxFactory.ParseCompilationUnit("extern alias b; using static d; [assembly: XAttribute] namespace c{};");

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 5);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Externs[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Usings[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Members[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.EndOfFileToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 4);
            Assert.IsTrue(topologicalChildren.Contains(node.Externs[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Usings[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Members[0]));

            node = SyntaxFactory.ParseCompilationUnit("using static d; [assembly: XAttribute] namespace c{};");

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 4);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Usings[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Members[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.EndOfFileToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(topologicalChildren.Contains(node.Usings[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Members[0]));

            node = SyntaxFactory.ParseCompilationUnit("extern alias b; [assembly: XAttribute] namespace c{};");

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 4);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Externs[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Members[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.EndOfFileToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(topologicalChildren.Contains(node.Externs[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Members[0]));

            node = SyntaxFactory.ParseCompilationUnit("extern alias b; using static d; [assembly: XAttribute];");

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 4);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Externs[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Usings[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.AttributeLists[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.EndOfFileToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(topologicalChildren.Contains(node.Externs[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Usings[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.AttributeLists[0]));
        }

        [TestMethod]
        public void ExternAliasDirectiveServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = SyntaxFactory.ParseCompilationUnit("extern alias b; using static d; [assembly: XAttribute] namespace c{};").Externs[0];

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 4);
            Assert.IsTrue(hierarchicalChildren.Contains(node.ExternKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.AliasKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));
        }

        [TestMethod]
        public void UsingDirectiveServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = SyntaxFactory.ParseCompilationUnit("extern alias b; using static a = d; [assembly: XAttribute] namespace c{};").Usings[0];

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 5);
            Assert.IsTrue(hierarchicalChildren.Contains(node.UsingKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.StaticKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Alias));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Name));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.Alias));
            Assert.IsTrue(topologicalChildren.Contains(node.Name));

            node = SyntaxFactory.ParseCompilationUnit("extern alias b; using a = d; [assembly: XAttribute] namespace c{};").Usings[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 4);
            Assert.IsTrue(hierarchicalChildren.Contains(node.UsingKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Alias));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Name));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.Alias));
            Assert.IsTrue(topologicalChildren.Contains(node.Name));

            node = SyntaxFactory.ParseCompilationUnit("extern alias b; using static d; [assembly: XAttribute] namespace c{};").Usings[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 4);
            Assert.IsTrue(hierarchicalChildren.Contains(node.UsingKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.StaticKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Name));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Name));
        }

        [TestMethod]
        public void NamespaceDeclarationServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (NamespaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("namespace a{extern alias b; using static d; namespace c{int f = 3;};};").Members[0];

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 8);
            Assert.IsTrue(hierarchicalChildren.Contains(node.NamespaceKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Name));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenBraceToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Externs[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Usings[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Members[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseBraceToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 4);
            Assert.IsTrue(topologicalChildren.Contains(node.Name));
            Assert.IsTrue(topologicalChildren.Contains(node.Externs[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Usings[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Members[0]));

            node = (NamespaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("namespace a{using static d; namespace c{int f = 3;};};").Members[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 7);
            Assert.IsTrue(hierarchicalChildren.Contains(node.NamespaceKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Name));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenBraceToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Usings[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Members[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseBraceToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(topologicalChildren.Contains(node.Name));
            Assert.IsTrue(topologicalChildren.Contains(node.Usings[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Members[0]));

            node = (NamespaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("namespace a{extern alias b; namespace c{int f = 3;};};").Members[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 7);
            Assert.IsTrue(hierarchicalChildren.Contains(node.NamespaceKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Name));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenBraceToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Externs[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Members[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseBraceToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(topologicalChildren.Contains(node.Name));
            Assert.IsTrue(topologicalChildren.Contains(node.Externs[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Members[0]));

            node = (NamespaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("namespace a{extern alias b; using static d;};").Members[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 7);
            Assert.IsTrue(hierarchicalChildren.Contains(node.NamespaceKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Name));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenBraceToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Externs[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Usings[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseBraceToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(topologicalChildren.Contains(node.Name));
            Assert.IsTrue(topologicalChildren.Contains(node.Externs[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Usings[0]));

            node = (NamespaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("namespace a{extern alias b; using static d; namespace c{int f = 3;};}").Members[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 7);
            Assert.IsTrue(hierarchicalChildren.Contains(node.NamespaceKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Name));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenBraceToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Externs[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Usings[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Members[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseBraceToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 4);
            Assert.IsTrue(topologicalChildren.Contains(node.Name));
            Assert.IsTrue(topologicalChildren.Contains(node.Externs[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Usings[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Members[0]));
        }

        [TestMethod]
        public void AttributeListServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(\"X\"), YAttribute(Y: 3)]").AttributeLists[0];

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 6);
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenBracketToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Target));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Attributes[0]));
            Assert.IsTrue(hierarchicalChildren[3].Value.Kind() == SyntaxKind.CommaToken);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Attributes[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseBracketToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(topologicalChildren.Contains(node.Target));
            Assert.IsTrue(topologicalChildren.Contains(node.Attributes[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Attributes[1]));

            node = ((FieldDeclarationSyntax)((NamespaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("namespace a {[XAttribute(\"X\"), YAttribute(Y: 3)]int f;}").Members[0]).Members[0]).AttributeLists[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 5);
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenBracketToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Attributes[0]));
            Assert.IsTrue(hierarchicalChildren[2].Value.Kind() == SyntaxKind.CommaToken);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Attributes[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseBracketToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.Attributes[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Attributes[1]));
        }

        [TestMethod]
        public void AttributeTargetSpecifierServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(\"X\"), YAttribute(Y: 3)]").AttributeLists[0].Target;

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 2);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ColonToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));
        }

        [TestMethod]
        public void AttributeServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(\"X\")]").AttributeLists[0].Attributes[0];

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 2);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Name));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ArgumentList));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.Name));
            Assert.IsTrue(topologicalChildren.Contains(node.ArgumentList));

            node = SyntaxFactory.ParseCompilationUnit("[module: XAttribute]").AttributeLists[0].Attributes[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 1);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Name));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Name));
        }

        [TestMethod]
        public void AttributeArgumentListServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(\"X\", Y: 3)]").AttributeLists[0].Attributes[0].ArgumentList;

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 5);
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenParenToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Arguments[0]));
            Assert.IsTrue(hierarchicalChildren[2].Value.Kind() == SyntaxKind.CommaToken);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Arguments[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseParenToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.Arguments[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Arguments[1]));

            node = SyntaxFactory.ParseCompilationUnit("[module: XAttribute()]").AttributeLists[0].Attributes[0].ArgumentList;

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 2);
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenParenToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseParenToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 0);
        }

        [TestMethod]
        public void AttributeArgumentServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(Y: 3)]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0];

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 2);
            Assert.IsTrue(hierarchicalChildren.Contains(node.NameColon));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Expression));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.NameColon));
            Assert.IsTrue(topologicalChildren.Contains(node.Expression));

            node = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(Y = 3)]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 2);
            Assert.IsTrue(hierarchicalChildren.Contains(node.NameEquals));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Expression));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.NameEquals));
            Assert.IsTrue(topologicalChildren.Contains(node.Expression));

            node = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(3)]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 1);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Expression));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Expression));
        }

        [TestMethod]
        public void WhenClauseServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = ((CasePatternSwitchLabelSyntax)((SwitchStatementSyntax)SyntaxFactory.ParseStatement("switch(obj){ case 'a' when obj.Lenght > 0: }")).Sections[0].Labels[0]).WhenClause;

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 2);
            Assert.IsTrue(hierarchicalChildren.Contains(node.WhenKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Condition));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Condition));
        }

        [TestMethod]
        public void TupleTypeServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (TupleTypeSyntax)SyntaxFactory.ParseTypeName("(string, int)");

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 5);
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenParenToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Elements[0]));
            Assert.IsTrue(hierarchicalChildren[2].Value.Kind() == SyntaxKind.CommaToken);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Elements[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseParenToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.Elements[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Elements[1]));
        }

        [TestMethod]
        public void TupleExpressionServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (TupleExpressionSyntax)SyntaxFactory.ParseExpression("(string, int)");

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 5);
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenParenToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Arguments[0]));
            Assert.IsTrue(hierarchicalChildren[2].Value.Kind() == SyntaxKind.CommaToken);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Arguments[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseParenToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.Arguments[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Arguments[1]));
        }

        [TestMethod]
        public void TupleElementServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var type = SyntaxFactory.ParseTypeName("(string, int)");
            var node = SyntaxFactory.TupleElement(type, SyntaxFactory.Identifier("a"));

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 2);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Type));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.Type));
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));

            node = SyntaxFactory.TupleElement(type);

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 1);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Type));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Type));
        }

        [TestMethod]
        public void ThrowExpressionServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (ThrowExpressionSyntax)SyntaxFactory.ParseExpression("throw e");

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 2);
            Assert.IsTrue(hierarchicalChildren.Contains(node.ThrowKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Expression));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Expression));
        }

        [TestMethod]
        public void SingleVariableDesignationServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = SyntaxFactory.SingleVariableDesignation(SyntaxFactory.Identifier("a"));

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 1);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));
        }

        [TestMethod]
        public void DiscardDesignationServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = SyntaxFactory.DiscardDesignation(SyntaxFactory.Token(SyntaxKind.UnderscoreToken));

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 1);
            Assert.IsTrue(hierarchicalChildren.Contains(node.UnderscoreToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 0);
        }

        [TestMethod]
        public void ParenthesizedVariableDesignationServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = SyntaxFactory.ParenthesizedVariableDesignation(SyntaxFactory.Token(SyntaxKind.OpenParenToken),
                SyntaxFactory.SeparatedList(new VariableDesignationSyntax[]
                {
                    SyntaxFactory.SingleVariableDesignation(SyntaxFactory.Identifier("a")),
                     SyntaxFactory.DiscardDesignation(SyntaxFactory.Token(SyntaxKind.UnderscoreToken))
                }),
                SyntaxFactory.Token(SyntaxKind.CloseParenToken));

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 5);
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenParenToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Variables[0]));
            Assert.IsTrue(hierarchicalChildren[2].Value.Kind() == SyntaxKind.CommaToken);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Variables[1]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseParenToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.Variables[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Variables[1]));

            node = SyntaxFactory.ParenthesizedVariableDesignation(SyntaxFactory.Token(SyntaxKind.OpenParenToken),
                SyntaxFactory.SeparatedList(new VariableDesignationSyntax[0]),
                SyntaxFactory.Token(SyntaxKind.CloseParenToken));

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 2);
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenParenToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseParenToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 0);
        }

        [TestMethod]
        public void RefExpressionServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = SyntaxFactory.RefExpression(SyntaxFactory.Token(SyntaxKind.RefKeyword), SyntaxFactory.ParseExpression("s + d"));

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 2);
            Assert.IsTrue(hierarchicalChildren.Contains(node.RefKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Expression));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Expression));
        }

        [TestMethod]
        public void CasePatternSwitchLabelServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (CasePatternSwitchLabelSyntax)((SwitchStatementSyntax)SyntaxFactory.ParseStatement("switch(obj){ case 'a' when obj.Lenght > 0: }")).Sections[0].Labels[0];

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 4);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Keyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Pattern));
            Assert.IsTrue(hierarchicalChildren.Contains(node.WhenClause));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ColonToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.Pattern));
            Assert.IsTrue(topologicalChildren.Contains(node.WhenClause));

            node = SyntaxFactory.CasePatternSwitchLabel(node.Keyword, node.Pattern, null, node.ColonToken);

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 3);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Keyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Pattern));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ColonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Pattern));
        }

        [TestMethod]
        public void IsPatternExpressionServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (IsPatternExpressionSyntax)SyntaxFactory.ParseExpression("obj is A a");

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 3);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Expression));
            Assert.IsTrue(hierarchicalChildren.Contains(node.IsKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Pattern));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.Expression));
            Assert.IsTrue(topologicalChildren.Contains(node.Pattern));
        }

        [TestMethod]
        public void DeclarationExpressionServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (DeclarationExpressionSyntax)((TupleExpressionSyntax)SyntaxFactory.ParseExpression("(int a, int b)")).Arguments[0].Expression;

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 2);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Type));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Designation));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.Type));
            Assert.IsTrue(topologicalChildren.Contains(node.Designation));
        }

        [TestMethod]
        public void ForEachVariableStatementServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (ForEachVariableStatementSyntax)SyntaxFactory.ParseStatement("foreach(var (a,b) in x){}");

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 7);
            Assert.IsTrue(hierarchicalChildren.Contains(node.ForEachKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenParenToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Variable));
            Assert.IsTrue(hierarchicalChildren.Contains(node.InKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Expression));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseParenToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Statement));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(topologicalChildren.Contains(node.Variable));
            Assert.IsTrue(topologicalChildren.Contains(node.Expression));
            Assert.IsTrue(topologicalChildren.Contains(node.Statement));
        }

        [TestMethod]
        public void DeclarationPatternServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (DeclarationPatternSyntax)((CasePatternSwitchLabelSyntax)((SwitchStatementSyntax)SyntaxFactory.ParseStatement("switch(obj){ case Shape s: }")).Sections[0].Labels[0]).Pattern;

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 2);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Type));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Designation));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren.Contains(node.Type));
            Assert.IsTrue(topologicalChildren.Contains(node.Designation));
        }

        [TestMethod]
        public void ConstantPatternServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (ConstantPatternSyntax)((CasePatternSwitchLabelSyntax)((SwitchStatementSyntax)SyntaxFactory.ParseStatement("switch(obj){ case 'a' when obj.Lenght > 0: }")).Sections[0].Labels[0]).Pattern;

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 1);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Expression));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Expression));
        }

        [TestMethod]
        public void LocalFunctionStatementServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (LocalFunctionStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit(@"
            void m()
            {
                const int local<T>() where T: I => 0;
            }").Members[0]).Body.Statements[0];

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 8);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ReturnType));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.TypeParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ConstraintClauses[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ExpressionBody));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 7);
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.ReturnType));
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));
            Assert.IsTrue(topologicalChildren.Contains(node.TypeParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.ConstraintClauses[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.ExpressionBody));

            node = (LocalFunctionStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit(@"
            void m()
            {
                const int local<T>() where T: I { return 0;}
            }").Members[0]).Body.Statements[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 7);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ReturnType));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.TypeParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ConstraintClauses[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Body));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 7);
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.ReturnType));
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));
            Assert.IsTrue(topologicalChildren.Contains(node.TypeParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.ConstraintClauses[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Body));

            node = (LocalFunctionStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit(@"
            void m()
            {
                int local<T>() where T: I => 0;
            }").Members[0]).Body.Statements[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 7);
            Assert.IsTrue(hierarchicalChildren.Contains(node.ReturnType));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.TypeParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ConstraintClauses[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ExpressionBody));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 6);
            Assert.IsTrue(topologicalChildren.Contains(node.ReturnType));
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));
            Assert.IsTrue(topologicalChildren.Contains(node.TypeParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.ConstraintClauses[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.ExpressionBody));

            node = (LocalFunctionStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit(@"
            void m()
            {
                int local<T>() where T: I { return 0;}
            }").Members[0]).Body.Statements[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 6);
            Assert.IsTrue(hierarchicalChildren.Contains(node.ReturnType));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.TypeParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ConstraintClauses[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Body));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 6);
            Assert.IsTrue(topologicalChildren.Contains(node.ReturnType));
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));
            Assert.IsTrue(topologicalChildren.Contains(node.TypeParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.ConstraintClauses[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Body));

            node = (LocalFunctionStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit(@"
            void m()
            {
                const int local() where T: I => 0;
            }").Members[0]).Body.Statements[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 7);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ReturnType));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ConstraintClauses[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ExpressionBody));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 6);
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.ReturnType));
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));
            Assert.IsTrue(topologicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.ConstraintClauses[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.ExpressionBody));

            node = (LocalFunctionStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit(@"
            void m()
            {
                const int local() where T: I { return 0;}
            }").Members[0]).Body.Statements[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 6);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ReturnType));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ConstraintClauses[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Body));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 6);
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.ReturnType));
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));
            Assert.IsTrue(topologicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.ConstraintClauses[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.Body));

            node = (LocalFunctionStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit(@"
            void m()
            {
                const int local<T>() where T: I => 0
            }").Members[0]).Body.Statements[0];

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 8);
            Assert.IsTrue(hierarchicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ReturnType));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Identifier));
            Assert.IsTrue(hierarchicalChildren.Contains(node.TypeParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ConstraintClauses[0]));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ExpressionBody));
            Assert.IsTrue(hierarchicalChildren.Contains(node.SemicolonToken));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 7);
            Assert.IsTrue(topologicalChildren.Contains(node.Modifiers[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.ReturnType));
            Assert.IsTrue(topologicalChildren.Contains(node.Identifier));
            Assert.IsTrue(topologicalChildren.Contains(node.TypeParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.ParameterList));
            Assert.IsTrue(topologicalChildren.Contains(node.ConstraintClauses[0]));
            Assert.IsTrue(topologicalChildren.Contains(node.ExpressionBody));
        }



        [TestMethod]
        public void RefTypeServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = SyntaxFactory.RefType(SyntaxFactory.Token(SyntaxKind.RefKeyword), SyntaxFactory.Token(SyntaxKind.ReadOnlyKeyword), SyntaxFactory.ParseTypeName("var"));

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 3);
            Assert.IsTrue(hierarchicalChildren.Contains(node.RefKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.ReadOnlyKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Type));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Type));

            node = SyntaxFactory.RefType(SyntaxFactory.Token(SyntaxKind.RefKeyword), SyntaxFactory.ParseTypeName("var"));

            hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 2);
            Assert.IsTrue(hierarchicalChildren.Contains(node.RefKeyword));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Type));

            topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Type));
        }

        [TestMethod]
        public void AllElementTypeSuitableFor_NameEqualityMatch_IsTested()
        {
            var rdsl = CDF.XObjects.RDSL.Syntax.Load(@"..\..\..\Jawilliam.CDF.CSharp\RDSL.xml");
            var concreteTypes = rdsl.Nodes.Type.Where(n => !n.@abstract).ToArray();

            var cases = (from t in concreteTypes
                         from p in t.Properties?.Property
                         //where p.Rules?.Topology?.relevant ?? false
                         select new { Type = t, Property = p }).ToList();

            var testedCases = (from m in this.GetType().GetMethods()
                               let nameParts = m.Name.Split(new[] { '_' }, StringSplitOptions.RemoveEmptyEntries)
                               where nameParts.Length == 3 && nameParts[1] == "TopologicalAbstraction" && nameParts[2] == "OK"
                               select nameParts[0].Replace("ServiceProvider", "Syntax")).ToList();

            var a = cases.Select(info => info.Type.name).Distinct().Except(testedCases).ToArray();
            var b = testedCases.Except(cases.Select(info => info.Type.name).Distinct()).ToArray();

            Assert.AreEqual(a.Count(), 0);
            Assert.AreEqual(b.Count(), 0);
        }
    }
}
