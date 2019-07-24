using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp;
using Jawilliam.CDF.Approach.Services;
using Jawilliam.CDF.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Jawilliam.CDF.Tests.Flad.Awareness
{
    /// <summary>
    /// Summary description for TopologyTests
    /// </summary>
    [TestClass]
    public class TopologyTests
    {
        [TestMethod]
        public void ParenthesizedExpressionServiceProvider_TopologicalAbstraction_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();

            var node = (ParenthesizedExpressionSyntax)SyntaxFactory.ParseExpression("(3)");

            var hierarchicalChildren = flad.HierarchicalAbstraction(full: true).Children(node).ToArray();
            Assert.AreEqual(hierarchicalChildren.Count(), 3);
            Assert.IsTrue(hierarchicalChildren.Contains(node.OpenParenToken));
            Assert.IsTrue(hierarchicalChildren.Contains(node.Expression));
            Assert.IsTrue(hierarchicalChildren.Contains(node.CloseParenToken));

            var topologicalChildren = flad.HierarchicalAbstraction(full: false).Children(node).ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren.Contains(node.Expression));
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
        public void InterpolationSyntaxServiceProvider_TopologicalAbstraction_OK()
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
        public void BracketedArgumentServiceProvider_TopologicalAbstraction_OK()
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
        public void AllElementTypeSuitableFor_NameEqualityMatch_IsTested()
        {
            var rdsl = CDF.XObjects.RDSL.Syntax.Load(@"..\..\..\Jawilliam.CDF.CSharp\RDSL.xml");
            var concreteTypes = rdsl.Nodes.Type.Where(n => !n.@abstract).ToArray();

            var cases = (from t in concreteTypes
                         from p in t.Properties?.Property
                         where p.Rules?.Topology?.relevant ?? false
                         select new { Type = t, Property = p }).ToList();

            var testedCases = (from m in this.GetType().GetMethods()
                               let nameParts = m.Name.Split(new[] { '_' }, StringSplitOptions.RemoveEmptyEntries)
                               where nameParts.Length == 3 && nameParts[1] == "TopologicalAbstraction" && nameParts[2] == "OK"
                               select nameParts[0].Replace("ServiceProvider", "Syntax")).ToList();

            var a = cases.Select(info => info.Type.name).Except(testedCases).ToArray();
            var b = testedCases.Except(cases.Select(info => info.Type.name)).ToArray();

            Assert.AreEqual(a.Count(), 0);
            Assert.AreEqual(b.Count(), 0);
        }
    }
}
