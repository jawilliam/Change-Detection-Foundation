using Jawilliam.CDF.Approach.Services;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Xml.Linq;

namespace Jawilliam.CDF.Tests.Flad.Awareness
{
    /// <summary>
    /// Summary description for TopologyTests
    /// </summary>
    [TestClass]
    public class RoslynMLPruneSelectorTests
    {
        [TestMethod]
        public void ParenthesizedExpressionServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (ParenthesizedExpressionSyntax)SyntaxFactory.ParseExpression("(3)");
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Expression).Name.LocalName);
        }

        [TestMethod]
        public void PrefixUnaryExpressionServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (PrefixUnaryExpressionSyntax)SyntaxFactory.ParseExpression("++3");
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Operand).Name.LocalName);
        }

        [TestMethod]
        public void AwaitExpressionServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (AwaitExpressionSyntax)SyntaxFactory.ParseExpression("await x");
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Expression).Name.LocalName);
        }

        [TestMethod]
        public void PostfixUnaryExpressionServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (PostfixUnaryExpressionSyntax)SyntaxFactory.ParseExpression("3++");
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Operand).Name.LocalName);
        }

        [TestMethod]
        public void MemberAccessExpressionServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (MemberAccessExpressionSyntax)SyntaxFactory.ParseExpression("x.r");
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Expression).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Name).Name.LocalName);
        }

        [TestMethod]
        public void ConditionalAccessExpressionServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (ConditionalAccessExpressionSyntax)SyntaxFactory.ParseExpression("x?.r");
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Expression).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.WhenNotNull).Name.LocalName);
        }

        [TestMethod]
        public void MemberBindingExpressionServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (MemberBindingExpressionSyntax)((ConditionalAccessExpressionSyntax)SyntaxFactory.ParseExpression("m?.r")).WhenNotNull;
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Name).Name.LocalName);
        }

        [TestMethod]
        public void ElementBindingExpressionServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (ElementBindingExpressionSyntax)((ConditionalAccessExpressionSyntax)SyntaxFactory.ParseExpression("m?[r]")).WhenNotNull;
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.ArgumentList).Name.LocalName);
        }

        [TestMethod]
        public void ImplicitElementAccessServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();
            Func<string, ImplicitElementAccessSyntax> getElementBinding = delegate (string s)
            {
                var objectCreation = (ObjectCreationExpressionSyntax)SyntaxFactory.ParseExpression(s);
                var assigment = (AssignmentExpressionSyntax)objectCreation.Initializer.Expressions[0];
                return (ImplicitElementAccessSyntax)assigment.Left;
            };

            var node = getElementBinding("new A { [\"a\"] = { a = 0} }");
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.ArgumentList).Name.LocalName);
        }

        [TestMethod]
        public void BinaryExpressionServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (BinaryExpressionSyntax)SyntaxFactory.ParseExpression("1 * 2");
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Left).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Right).Name.LocalName);
        }

        [TestMethod]
        public void AssignmentExpressionServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (AssignmentExpressionSyntax)SyntaxFactory.ParseExpression("x *= 2");
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Left).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Right).Name.LocalName);
        }

        [TestMethod]
        public void ConditionalExpressionServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (ConditionalExpressionSyntax)SyntaxFactory.ParseExpression("x ? 3 : 2");
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Condition).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.WhenTrue).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.WhenFalse).Name.LocalName);
        }

        [TestMethod]
        public void ThisExpressionServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (ThisExpressionSyntax)SyntaxFactory.ParseExpression("this");
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 0);
        }

        [TestMethod]
        public void BaseExpressionServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (BaseExpressionSyntax)SyntaxFactory.ParseExpression("base");
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 0);
        }

        [TestMethod]
        public void LiteralExpressionServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (LiteralExpressionSyntax)SyntaxFactory.ParseExpression("3");
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Token).Name.LocalName);
        }

        [TestMethod]
        public void MakeRefExpressionServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (MakeRefExpressionSyntax)SyntaxFactory.ParseExpression("__makeref(x)");
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Expression).Name.LocalName);
        }

        [TestMethod]
        public void RefTypeExpressionServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (RefTypeExpressionSyntax)SyntaxFactory.ParseExpression("__reftype(x)");
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Expression).Name.LocalName);
        }

        [TestMethod]
        public void RefValueExpressionServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (RefValueExpressionSyntax)SyntaxFactory.ParseExpression("__refvalue(x, int)");
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Expression).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Type).Name.LocalName);
        }

        [TestMethod]
        public void CheckedExpressionServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (CheckedExpressionSyntax)SyntaxFactory.ParseExpression("unchecked(y)");
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Expression).Name.LocalName);

            node = (CheckedExpressionSyntax)SyntaxFactory.ParseExpression("checked(y)");

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Expression).Name.LocalName);
        }

        [TestMethod]
        public void DefaultExpressionServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (DefaultExpressionSyntax)SyntaxFactory.ParseExpression("default(x)");
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Type).Name.LocalName);
        }

        [TestMethod]
        public void TypeOfExpressionServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (TypeOfExpressionSyntax)SyntaxFactory.ParseExpression("typeof(x)");
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Type).Name.LocalName);
        }

        [TestMethod]
        public void SizeOfExpressionServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (SizeOfExpressionSyntax)SyntaxFactory.ParseExpression("sizeof(x)");
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Type).Name.LocalName);
        }

        [TestMethod]
        public void InvocationExpressionServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (InvocationExpressionSyntax)SyntaxFactory.ParseExpression("a(r,e)");
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Expression).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.ArgumentList).Name.LocalName);
        }

        [TestMethod]
        public void ElementAccessExpressionServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (ElementAccessExpressionSyntax)SyntaxFactory.ParseExpression("x[\"a\"]");
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Expression).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.ArgumentList).Name.LocalName);
        }

        [TestMethod]
        public void CastExpressionServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (CastExpressionSyntax)SyntaxFactory.ParseExpression("(int)x");
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Type).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Expression).Name.LocalName);
        }

        [TestMethod]
        public void AnonymousMethodExpressionServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (AnonymousMethodExpressionSyntax)SyntaxFactory.ParseExpression("async delegate() { return 4; }");
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.ParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Body).Name.LocalName);

            node = (AnonymousMethodExpressionSyntax)SyntaxFactory.ParseExpression("async delegate { return 4; }");
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Body).Name.LocalName);
        }

        [TestMethod]
        public void SimpleLambdaExpressionServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (SimpleLambdaExpressionSyntax)SyntaxFactory.ParseExpression("async e => 4");
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Parameter).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Body).Name.LocalName);
        }

        [TestMethod]
        public void ParenthesizedLambdaExpressionServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (ParenthesizedLambdaExpressionSyntax)SyntaxFactory.ParseExpression("async (e) => 4");
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.ParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Body).Name.LocalName);
        }

        [TestMethod]
        public void InitializerExpressionServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((ObjectCreationExpressionSyntax)SyntaxFactory.ParseExpression("new F { 4, 'r', \"hello world\" }")).Initializer;
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Expressions[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Expressions[1]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[2].Name.LocalName == converter.Visit(node.Expressions[2]).Name.LocalName);

            node = ((ArrayCreationExpressionSyntax)SyntaxFactory.ParseExpression("new object[] { 4, 'r', \"hello world\" }")).Initializer;
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Expressions[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Expressions[1]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[2].Name.LocalName == converter.Visit(node.Expressions[2]).Name.LocalName);
        }

        [TestMethod]
        public void ObjectCreationExpressionServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (ObjectCreationExpressionSyntax)SyntaxFactory.ParseExpression("new F() { 4, 'r', \"hello world\" }");
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Type).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.ArgumentList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Initializer).Name.LocalName);

            node = (ObjectCreationExpressionSyntax)SyntaxFactory.ParseExpression("new F { 4, 'r', \"hello world\" }");
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Type).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Initializer).Name.LocalName);
        }

        [TestMethod]
        public void AnonymousObjectCreationExpressionServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (AnonymousObjectCreationExpressionSyntax)SyntaxFactory.ParseExpression("new { Text = 4, aText = 5 }");
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Initializers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Initializers[1]).Name.LocalName);
        }

        [TestMethod]
        public void ArrayCreationExpressionServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (ArrayCreationExpressionSyntax)SyntaxFactory.ParseExpression("new A[]{4, 6}");
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Type).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Initializer).Name.LocalName);
        }

        [TestMethod]
        public void ImplicitArrayCreationExpressionServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (ImplicitArrayCreationExpressionSyntax)SyntaxFactory.ParseExpression("new [,]{4, 6}");
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2); ;
            Assert.IsTrue(topologicalChildren[0].Value == ",");
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Initializer).Name.LocalName);
        }

        [TestMethod]
        public void StackAllocArrayCreationExpressionServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (StackAllocArrayCreationExpressionSyntax)SyntaxFactory.ParseExpression("stackalloc int[2]");
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Type).Name.LocalName);
        }

        [TestMethod]
        public void QueryExpressionServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s where f.A select f.R");
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.FromClause).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Body).Name.LocalName);
        }

        [TestMethod]
        public void InterpolatedStringExpressionServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (InterpolatedStringExpressionSyntax)SyntaxFactory.ParseExpression("$\"Hello world\"");
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Contents[0]).Name.LocalName);
        }

        [TestMethod]
        public void InterpolatedStringTextServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (InterpolatedStringTextSyntax)((InterpolatedStringExpressionSyntax)SyntaxFactory.ParseExpression("$\"Hello world\"")).Contents[0];
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.TextToken).Name.LocalName);
        }

        [TestMethod]
        public void InterpolationServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (InterpolationSyntax)((InterpolatedStringExpressionSyntax)SyntaxFactory.ParseExpression("$\"Hello world {Name, 5:N2}\"")).Contents[1];
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Expression).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.AlignmentClause).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.FormatClause).Name.LocalName);

            node = (InterpolationSyntax)((InterpolatedStringExpressionSyntax)SyntaxFactory.ParseExpression("$\"Hello world  {Name,5}\"")).Contents[1];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Expression).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.AlignmentClause).Name.LocalName);

            node = (InterpolationSyntax)((InterpolatedStringExpressionSyntax)SyntaxFactory.ParseExpression("$\"Hello world  {Name:N2}\"")).Contents[1];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Expression).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.FormatClause).Name.LocalName);

            node = (InterpolationSyntax)((InterpolatedStringExpressionSyntax)SyntaxFactory.ParseExpression("$\"Hello world {Name}\"")).Contents[1];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Expression).Name.LocalName);
        }

        [TestMethod]
        public void InterpolationAlignmentClauseServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((InterpolationSyntax)((InterpolatedStringExpressionSyntax)SyntaxFactory.ParseExpression("$\"Hello world {Name, 5:N2}\"")).Contents[1]).AlignmentClause;
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Value).Name.LocalName);
        }

        [TestMethod]
        public void InterpolationFormatClauseServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((InterpolationSyntax)((InterpolatedStringExpressionSyntax)SyntaxFactory.ParseExpression("$\"Hello world {Name, 5:N2}\"")).Contents[1]).FormatClause;
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.FormatStringToken).Name.LocalName);
        }

        [TestMethod]
        public void ArgumentListServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((InvocationExpressionSyntax)SyntaxFactory.ParseExpression("x.F(x, r)")).ArgumentList;
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Arguments[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Arguments[1]).Name.LocalName);
        }

        [TestMethod]
        public void BracketedArgumentListServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((ElementAccessExpressionSyntax)SyntaxFactory.ParseExpression("x.F[x, r]")).ArgumentList;
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Arguments[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Arguments[1]).Name.LocalName);
        }

        [TestMethod]
        public void ArgumentServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((InvocationExpressionSyntax)SyntaxFactory.ParseExpression("x.F(x, r)")).ArgumentList.Arguments[0];
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Expression).Name.LocalName);

            node = ((InvocationExpressionSyntax)SyntaxFactory.ParseExpression("x.F(ref x, r)")).ArgumentList.Arguments[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Expression).Name.LocalName);

            node = ((InvocationExpressionSyntax)SyntaxFactory.ParseExpression("x.F(x, out r)")).ArgumentList.Arguments[1];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Expression).Name.LocalName);

            node = ((InvocationExpressionSyntax)SyntaxFactory.ParseExpression("x.F(a: x, out r)")).ArgumentList.Arguments[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.NameColon).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Expression).Name.LocalName);
        }

        [TestMethod]
        public void NameColonServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((InvocationExpressionSyntax)SyntaxFactory.ParseExpression("x.F(a: x, r)")).ArgumentList.Arguments[0].NameColon;
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Name).Name.LocalName);
        }

        [TestMethod]
        public void NameEqualsServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((AnonymousObjectCreationExpressionSyntax)SyntaxFactory.ParseExpression("new { Text = 4, aText = 5 }")).Initializers[0].NameEquals;
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Name).Name.LocalName);
        }

        [TestMethod]
        public void AnonymousObjectMemberDeclaratorServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((AnonymousObjectCreationExpressionSyntax)SyntaxFactory.ParseExpression("new { Text = 4, aText = 5 }")).Initializers[0];
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.NameEquals).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Expression).Name.LocalName);
        }

        [TestMethod]
        public void QueryBodyServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s where f.A select f.R")).Body;
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Clauses[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.SelectOrGroup).Name.LocalName);

            node = ((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s where f.A select f.R into t")).Body;
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Clauses[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.SelectOrGroup).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Continuation).Name.LocalName);
        }

        [TestMethod]
        public void FromClauseServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from T f in s where f.A select f.R")).FromClause;
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Type).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Expression).Name.LocalName);

            node = ((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s where f.A select f.R")).FromClause;
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Expression).Name.LocalName);
        }

        [TestMethod]
        public void LetClauseServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((LetClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s let y = 5 where f.A select f.R")).Body.Clauses[0]);
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Expression).Name.LocalName);
        }

        [TestMethod]
        public void JoinClauseServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((JoinClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s join T t in F on t.L equals s.R into y")).Body.Clauses[0]);
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 6);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Type).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.InExpression).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.LeftExpression).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Name.LocalName == converter.Visit(node.RightExpression).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Name.LocalName == converter.Visit(node.Into).Name.LocalName);

            node = ((JoinClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s join T t in F on t.L equals s.R")).Body.Clauses[0]);
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 5);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Type).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.InExpression).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.LeftExpression).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Name.LocalName == converter.Visit(node.RightExpression).Name.LocalName);
        }

        [TestMethod]
        public void JoinIntoClauseServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((JoinClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s join T t in F on t.L equals s.R into y")).Body.Clauses[0]).Into;
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
        }

        [TestMethod]
        public void WhereClauseServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((WhereClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from A f in s where y = 5")).Body.Clauses[0]);
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Condition).Name.LocalName);
        }

        [TestMethod]
        public void OrderByClauseServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((OrderByClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from A f in s orderby f.y")).Body.Clauses[0]);
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Orderings[0]).Name.LocalName);
        }

        [TestMethod]
        public void OrderingServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((OrderByClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from A f in s orderby f.y descending")).Body.Clauses[0]).Orderings[0];
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Expression).Name.LocalName);

            node = ((OrderByClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from A f in s orderby f.y ascending")).Body.Clauses[0]).Orderings[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Expression).Name.LocalName);

            node = ((OrderByClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from A f in s orderby f.y")).Body.Clauses[0]).Orderings[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Expression).Name.LocalName);
        }

        [TestMethod]
        public void SelectClauseServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((SelectClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from A f in s select f")).Body.SelectOrGroup);
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Expression).Name.LocalName);
        }

        [TestMethod]
        public void GroupClauseServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((GroupClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from A f in s group g by f.r")).Body.SelectOrGroup);
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.GroupExpression).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.ByExpression).Name.LocalName);
        }

        [TestMethod]
        public void QueryContinuationServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from A f in s select f into g select f.r")).Body.Continuation;
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Body).Name.LocalName);
        }

        [TestMethod]
        public void PredefinedTypeServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (PredefinedTypeSyntax)SyntaxFactory.ParseTypeName("int");
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 0);
        }

        [TestMethod]
        public void ArrayTypeServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (ArrayTypeSyntax)SyntaxFactory.ParseTypeName("int[1, 2]");
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.ElementType).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.RankSpecifiers[0]).Name.LocalName);

            node = (ArrayTypeSyntax)SyntaxFactory.ParseTypeName("int[][]");
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.ElementType).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.RankSpecifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.RankSpecifiers[1]).Name.LocalName);
        }

        [TestMethod]
        public void PointerTypeServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (PointerTypeSyntax)SyntaxFactory.ParseTypeName("int*");
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.ElementType).Name.LocalName);
        }

        [TestMethod]
        public void NullableTypeServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (NullableTypeSyntax)SyntaxFactory.ParseTypeName("int?");
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.ElementType).Name.LocalName);
        }

        [TestMethod]
        public void OmittedTypeArgumentServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (OmittedTypeArgumentSyntax)((GenericNameSyntax)SyntaxFactory.ParseName("a<,>")).TypeArgumentList.Arguments[0];
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 0);
        }

        [TestMethod]
        public void QualifiedNameServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (QualifiedNameSyntax)SyntaxFactory.ParseName("a.x");
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Left).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Right).Name.LocalName);
        }

        [TestMethod]
        public void AliasQualifiedNameServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (AliasQualifiedNameSyntax)SyntaxFactory.ParseName("global::c");
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Alias).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Name).Name.LocalName);
        }

        [TestMethod]
        public void IdentifierNameServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (IdentifierNameSyntax)SyntaxFactory.ParseName("c");
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
        }

        [TestMethod]
        public void GenericNameServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (GenericNameSyntax)SyntaxFactory.ParseName("a<,>");
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.TypeArgumentList).Name.LocalName);
        }

        [TestMethod]
        public void TypeArgumentListServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((GenericNameSyntax)SyntaxFactory.ParseName("a<,>")).TypeArgumentList;
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Arguments[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Arguments[1]).Name.LocalName);
        }

        [TestMethod]
        public void ArrayRankSpecifierServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((ArrayTypeSyntax)SyntaxFactory.ParseTypeName("int[1, 2]")).RankSpecifiers[0];
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Sizes[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Sizes[1]).Name.LocalName);

            node = ((ArrayTypeSyntax)SyntaxFactory.ParseTypeName("int[][]")).RankSpecifiers[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Sizes[0]).Name.LocalName);
        }

        [TestMethod]
        public void OmittedArraySizeExpressionServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (OmittedArraySizeExpressionSyntax)((ArrayTypeSyntax)SyntaxFactory.ParseTypeName("int[]")).RankSpecifiers[0].Sizes[0];
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 0);
        }

        [TestMethod]
        public void BlockServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (BlockSyntax)SyntaxFactory.ParseStatement("{ x = 5;x += 3; }");
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Statements[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Statements[1]).Name.LocalName);
        }

        [TestMethod]
        public void LocalDeclarationStatementServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (LocalDeclarationStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int a() { const int a; }").Members[0]).Body.Statements[0];
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Declaration).Name.LocalName);

            node = (LocalDeclarationStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int a() { int a; }").Members[0]).Body.Statements[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Declaration).Name.LocalName);
        }

        [TestMethod]
        public void ExpressionStatementServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (ExpressionStatementSyntax)SyntaxFactory.ParseStatement("3");
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Expression).Name.LocalName);
        }

        [TestMethod]
        public void EmptyStatementServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (EmptyStatementSyntax)SyntaxFactory.ParseStatement(";");
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 0);
        }

        [TestMethod]
        public void LabeledStatementServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (LabeledStatementSyntax)SyntaxFactory.ParseStatement("l: 3");
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Statement).Name.LocalName);
        }

        [TestMethod]
        public void GotoStatementServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (GotoStatementSyntax)SyntaxFactory.ParseStatement("goto l;");
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Expression).Name.LocalName);

            node = (GotoStatementSyntax)SyntaxFactory.ParseStatement("goto case l;");
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Expression).Name.LocalName);

            node = (GotoStatementSyntax)SyntaxFactory.ParseStatement("goto default;");
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 0);
        }

        [TestMethod]
        public void BreakStatementServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (BreakStatementSyntax)SyntaxFactory.ParseStatement("break;");
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 0);
        }

        [TestMethod]
        public void ContinueStatementServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (ContinueStatementSyntax)SyntaxFactory.ParseStatement("continue;");
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 0);
        }

        [TestMethod]
        public void ReturnStatementServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (ReturnStatementSyntax)SyntaxFactory.ParseStatement("return 5;");
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Expression).Name.LocalName);
        }

        [TestMethod]
        public void ThrowStatementServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (ThrowStatementSyntax)SyntaxFactory.ParseStatement("throw 5;");
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Expression).Name.LocalName);
        }

        [TestMethod]
        public void YieldStatementServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (YieldStatementSyntax)SyntaxFactory.ParseStatement("yield return 5;");
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Expression).Name.LocalName);

            node = (YieldStatementSyntax)SyntaxFactory.ParseStatement("yield break;");
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 0);
        }

        [TestMethod]
        public void WhileStatementServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (WhileStatementSyntax)SyntaxFactory.ParseStatement("while (x < 0) x = 5;");
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Condition).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Statement).Name.LocalName);
        }

        [TestMethod]
        public void DoStatementServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (DoStatementSyntax)SyntaxFactory.ParseStatement("do x = 5; while (x < 0);");
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Statement).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Condition).Name.LocalName);
        }

        [TestMethod]
        public void ForStatementServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (ForStatementSyntax)SyntaxFactory.ParseStatement("for(int a = 0, b = 4; a < 0; a++, --b);");
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 4);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Declaration).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Condition).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Incrementors[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Incrementors[1]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.Statement).Name.LocalName);

            node = (ForStatementSyntax)SyntaxFactory.ParseStatement("for(a = 0, b = 4; a < 0; a++, --b);");
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 4);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Initializers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Initializers[1]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Condition).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Incrementors[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Incrementors[1]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.Statement).Name.LocalName);

            node = (ForStatementSyntax)SyntaxFactory.ParseStatement("for(; a < 0; a++, --b);");
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Condition).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Incrementors[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Incrementors[1]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Statement).Name.LocalName);

            node = (ForStatementSyntax)SyntaxFactory.ParseStatement("for(int a, b = 4; a < 0;);");
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Declaration).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Condition).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Statement).Name.LocalName);
        }

        [TestMethod]
        public void ForEachStatementServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (ForEachStatementSyntax)SyntaxFactory.ParseStatement("foreach(int a in ac);");
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 4);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Type).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Expression).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.Statement).Name.LocalName);
        }

        [TestMethod]
        public void UsingStatementServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (UsingStatementSyntax)SyntaxFactory.ParseStatement("using(int a, b = 4);");
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Declaration).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Statement).Name.LocalName);

            node = (UsingStatementSyntax)SyntaxFactory.ParseStatement("using(a);");
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Expression).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Statement).Name.LocalName);
        }

        [TestMethod]
        public void FixedStatementServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (FixedStatementSyntax)SyntaxFactory.ParseStatement("fixed(int a, b = 4);");
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Declaration).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Statement).Name.LocalName);
        }

        [TestMethod]
        public void CheckedStatementServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (CheckedStatementSyntax)SyntaxFactory.ParseStatement("checked { x = 5;}");
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Block).Name.LocalName);
        }

       [TestMethod]
        public void UnsafeStatementServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (UnsafeStatementSyntax)SyntaxFactory.ParseStatement("unsafe { x = 5;}");
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Block).Name.LocalName);
        }

        [TestMethod]
        public void LockStatementServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (LockStatementSyntax)SyntaxFactory.ParseStatement("lock(b = 4);");
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Expression).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Statement).Name.LocalName);
        }

        [TestMethod]
        public void IfStatementServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (IfStatementSyntax)SyntaxFactory.ParseStatement("if(b == 4);");
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Condition).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Statement).Name.LocalName);
        }

        [TestMethod]
        public void SwitchStatementServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (SwitchStatementSyntax)SyntaxFactory.ParseStatement("switch(b){ case default; }");
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Expression).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Sections[0]).Name.LocalName);

            node = (SwitchStatementSyntax)SyntaxFactory.ParseStatement("switch(b){ }");
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Expression).Name.LocalName);
        }

        [TestMethod]
        public void TryStatementServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch(A1){a1 = \"Catch a1\";} catch(B1) when(e = 5) {b1 = \"Catch b1\";} finally{c1 = \"Finnally1\";}");
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Block).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Catches[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Catches[1]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Finally).Name.LocalName);

            node = (TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} finally{c1 = \"Finnally1\";}");
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Block).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Finally).Name.LocalName);

            node = (TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch(A1){a1 = \"Catch a1\";} catch(B1) when(e = 5) {b1 = \"Catch b1\";}");
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Block).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Catches[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Catches[1]).Name.LocalName);
        }

        [TestMethod]
        public void VariableDeclarationServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((FixedStatementSyntax)SyntaxFactory.ParseStatement("fixed(int a, b = 4);")).Declaration;
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Type).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Variables[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Variables[1]).Name.LocalName);
        }

        [TestMethod]
        public void VariableDeclaratorServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((FixedStatementSyntax)SyntaxFactory.ParseStatement("fixed(int a, b = 4);")).Declaration.Variables[0];
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);

            node = ((FixedStatementSyntax)SyntaxFactory.ParseStatement("fixed(int a = 2, b = 4);")).Declaration.Variables[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Initializer).Name.LocalName);
        }

        [TestMethod]
        public void EqualsValueClauseServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((FixedStatementSyntax)SyntaxFactory.ParseStatement("fixed(int a, b = 4);")).Declaration.Variables[1].Initializer;
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Value).Name.LocalName);
        }

        [TestMethod]
        public void ElseClauseServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((IfStatementSyntax)SyntaxFactory.ParseStatement("if(b == 4); else;")).Else;
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Statement).Name.LocalName);
        }

        [TestMethod]
        public void SwitchSectionServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((SwitchStatementSyntax)SyntaxFactory.ParseStatement("switch(b){ case default:; }")).Sections[0];
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Labels[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Statements[0]).Name.LocalName);
        }

        [TestMethod]
        public void CaseSwitchLabelServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (CaseSwitchLabelSyntax)((SwitchStatementSyntax)SyntaxFactory.ParseStatement("switch(b){ case 4: return 4; default: return 10; }")).Sections[0].Labels[0];
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Value).Name.LocalName);
        }

        [TestMethod]
        public void DefaultSwitchLabelServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (DefaultSwitchLabelSyntax)((SwitchStatementSyntax)SyntaxFactory.ParseStatement("switch(b){ default:; }")).Sections[0].Labels[0];
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 0);
        }

        [TestMethod]
        public void CatchClauseServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch(A1 a) when(e = 5) {a1 = \"Catch a1\";}")).Catches[0];
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Declaration).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Filter).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Block).Name.LocalName);

            node = ((TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch(A1){a1 = \"Catch a1\";}")).Catches[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Declaration).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Block).Name.LocalName);

            node = ((TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch {b1 = \"Catch b1\";}")).Catches[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Block).Name.LocalName);
        }

        [TestMethod]
        public void CatchDeclarationServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch(A1 a) when(e = 5) {a1 = \"Catch a1\";}")).Catches[0].Declaration;
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Type).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);

            node = ((TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch(A1){a1 = \"Catch a1\";}")).Catches[0].Declaration;
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Type).Name.LocalName);
        }

        [TestMethod]
        public void CatchFilterClauseServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch(A1 a) when(e = 5) {a1 = \"Catch a1\";}")).Catches[0].Filter;
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.FilterExpression).Name.LocalName);
        }

        [TestMethod]
        public void FinallyClauseServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} finally {a1 = \"Catch a1\";}")).Finally;
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Block).Name.LocalName);
        }

        [TestMethod]
        public void IncompleteMemberServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (IncompleteMemberSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public a").Members[0];
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Type).Name.LocalName);

            node = (IncompleteMemberSyntax)SyntaxFactory.ParseCompilationUnit("public a").Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Type).Name.LocalName);

            node = (IncompleteMemberSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] a").Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Type).Name.LocalName);
        }

        [TestMethod]
        public void GlobalStatementServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = Microsoft.CodeAnalysis.CSharp.SyntaxFactory.GlobalStatement(SyntaxFactory.ParseStatement("x++"));
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Statement).Name.LocalName);
        }

        [TestMethod]
        public void DelegateDeclarationServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (DelegateDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public delegate void Del<T>(string str) where T: I;").Members[0];
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 7);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.ReturnType).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Name.LocalName == converter.Visit(node.TypeParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Name.LocalName == converter.Visit(node.ParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[6].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.ConstraintClauses[0]).Name.LocalName);

            node = (DelegateDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public delegate void Del<T>(string str) where T: I;").Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 6);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.ReturnType).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.TypeParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Name.LocalName == converter.Visit(node.ParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.ConstraintClauses[0]).Name.LocalName);

            node = (DelegateDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] delegate void Del<T>(string str) where T: I;").Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 6);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.ReturnType).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.TypeParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Name.LocalName == converter.Visit(node.ParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.ConstraintClauses[0]).Name.LocalName);

            node = (DelegateDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public delegate void Del(string str) where T: I;").Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 6);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.ReturnType).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Name.LocalName == converter.Visit(node.ParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.ConstraintClauses[0]).Name.LocalName);

            node = (DelegateDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public delegate void Del<T>(string str);").Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 6);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.ReturnType).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Name.LocalName == converter.Visit(node.TypeParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Name.LocalName == converter.Visit(node.ParameterList).Name.LocalName);
        }

        [TestMethod]
        public void EnumDeclarationServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (EnumDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public enum a : byte {a1, a2 = 3};").Members[0];
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 5);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.BaseList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Members[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Members[1]).Name.LocalName);

            node = (EnumDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public enum a : byte {a1, a2 = 3};").Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 4);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.BaseList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Members[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Members[1]).Name.LocalName);
                                              
            node = (EnumDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] enum a : byte {a1, a2 = 3};").Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 4);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.BaseList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Members[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Members[1]).Name.LocalName);

            node = (EnumDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public enum a {a1, a2 = 3};").Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 4);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Members[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Members[1]).Name.LocalName);

            node = (EnumDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public enum a : byte {a1, a2 = 3}").Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 5);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.BaseList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Members[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Members[1]).Name.LocalName);
        }

        [TestMethod]
        public void ClassDeclarationServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public class a<T> : byte where T : int  {X a1; Y a2 = 3;};").Members[0];
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 7);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.TypeParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Name.LocalName == converter.Visit(node.BaseList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.ConstraintClauses[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[6].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Members[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[6].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Members[1]).Name.LocalName);

            node = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class a<T> : byte where T : int  {X a1; Y a2 = 3;};").Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 6);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.TypeParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.BaseList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.ConstraintClauses[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Members[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Members[1]).Name.LocalName);

            node = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] class a<T> : byte where T : int  {X a1; Y a2 = 3;};").Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 6);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.TypeParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.BaseList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.ConstraintClauses[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Members[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Members[1]).Name.LocalName);

            node = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public class a : byte where T : int  {X a1; Y a2 = 3;};").Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 6);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.BaseList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.ConstraintClauses[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Members[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Members[1]).Name.LocalName);

            node = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public class a<T> where T : int  {X a1; Y a2 = 3;};").Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 6);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.TypeParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.ConstraintClauses[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Members[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Members[1]).Name.LocalName);

            node = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public class a<T> : byte where T : int  {X a1; Y a2 = 3;}").Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 7);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.TypeParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Name.LocalName == converter.Visit(node.BaseList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.ConstraintClauses[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[6].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Members[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[6].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Members[1]).Name.LocalName);
        }

        [TestMethod]
        public void StructDeclarationServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (StructDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public struct a<T> : byte where T : int  {X a1; Y a2 = 3;};").Members[0];
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 7);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.TypeParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Name.LocalName == converter.Visit(node.BaseList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.ConstraintClauses[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[6].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Members[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[6].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Members[1]).Name.LocalName);

            node = (StructDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public struct a<T> : byte where T : int  {X a1; Y a2 = 3;};").Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 6);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.TypeParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.BaseList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.ConstraintClauses[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Members[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Members[1]).Name.LocalName);
                                              
            node = (StructDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] struct a<T> : byte where T : int  {X a1; Y a2 = 3;};").Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 6);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.TypeParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.BaseList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.ConstraintClauses[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Members[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Members[1]).Name.LocalName);

            node = (StructDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public struct a : byte where T : int  {X a1; Y a2 = 3;};").Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 6);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.BaseList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.ConstraintClauses[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Members[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Members[1]).Name.LocalName);

            node = (StructDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public struct a<T> where T : int  {X a1; Y a2 = 3;};").Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 6);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.TypeParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.ConstraintClauses[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Members[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Members[1]).Name.LocalName);

            node = (StructDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public struct a<T> : byte where T : int  {X a1; Y a2 = 3;}").Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 7);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.TypeParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Name.LocalName == converter.Visit(node.BaseList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.ConstraintClauses[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[6].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Members[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[6].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Members[1]).Name.LocalName);
        }

        [TestMethod]
        public void InterfaceDeclarationServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (InterfaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public interface a<T> : byte where T : int  {X a1; Y a2 = 3;};").Members[0];
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 7);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.TypeParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Name.LocalName == converter.Visit(node.BaseList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.ConstraintClauses[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[6].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Members[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[6].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Members[1]).Name.LocalName);

            node = (InterfaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public interface a<T> : byte where T : int  {X a1; Y a2 = 3;};").Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 6);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.TypeParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.BaseList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.ConstraintClauses[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Members[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Members[1]).Name.LocalName);
                                              
            node = (InterfaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] interface a<T> : byte where T : int  {X a1; Y a2 = 3;};").Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 6);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.TypeParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.BaseList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.ConstraintClauses[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Members[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Members[1]).Name.LocalName);
                                              
            node = (InterfaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public interface a : byte where T : int  {X a1; Y a2 = 3;};").Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 6);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.BaseList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.ConstraintClauses[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Members[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Members[1]).Name.LocalName);

            node = (InterfaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public interface a<T> where T : int  {X a1; Y a2 = 3;};").Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 6);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.TypeParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.ConstraintClauses[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Members[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Members[1]).Name.LocalName);

            node = (InterfaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public interface a<T> : byte where T : int  {X a1; Y a2 = 3;}").Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 7);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.TypeParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Name.LocalName == converter.Visit(node.BaseList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.ConstraintClauses[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[6].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Members[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[6].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Members[1]).Name.LocalName);
        }

        [TestMethod]
        public void EnumMemberDeclarationServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((EnumDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public enum a : byte {a1, [Serializable] a2 = 3};").Members[0]).Members[1];
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.EqualsValue).Name.LocalName);

            node = ((EnumDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public enum a : byte {a1, a2 = 3};").Members[0]).Members[1];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.EqualsValue).Name.LocalName);

            node = ((EnumDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public enum a : byte {a1, [Serializable] a2};").Members[0]).Members[1];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
        }

        [TestMethod]
        public void TypeParameterListServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<B, in C> {}").Members[0]).TypeParameterList;
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Parameters[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Parameters[1]).Name.LocalName);
        }

        [TestMethod]
        public void TypeParameterServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<[Serializable] in B, in C> {}").Members[0]).TypeParameterList.Parameters[0];
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);

            node = ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<in B, in C> {}").Members[0]).TypeParameterList.Parameters[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
        }

        [TestMethod]
        public void TypeParameterConstraintClauseServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<T> : byte where T : new(), class {};").Members[0]).ConstraintClauses[0];
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Name).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Constraints[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Constraints[1]).Name.LocalName);
        }

        [TestMethod]
        public void TypeConstraintServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (TypeConstraintSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<T> : byte where T : A {};").Members[0]).ConstraintClauses[0].Constraints[0];
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Type).Name.LocalName);
        }

        [TestMethod]
        public void ConstructorConstraintServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (ConstructorConstraintSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<T> : byte where T : new() {};").Members[0]).ConstraintClauses[0].Constraints[0];
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 0);
        }

        [TestMethod]
        public void ClassOrStructConstraintServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (ClassOrStructConstraintSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<T> : byte where T : class {};").Members[0]).ConstraintClauses[0].Constraints[0];
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 0);

            node = (ClassOrStructConstraintSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<T> : byte where T : struct {};").Members[0]).ConstraintClauses[0].Constraints[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 0);
        }

        [TestMethod]
        public void BaseListServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<T> : A, I where T : A {};").Members[0]).BaseList;
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Types[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Types[1]).Name.LocalName);
        }

        [TestMethod]
        public void SimpleBaseTypeServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<T> : A, I where T : A {};").Members[0]).BaseList.Types[0];
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Type).Name.LocalName);
        }

        [TestMethod]
        public void FieldDeclarationServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (FieldDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a {[Serializable]public int df;}").Members[0]).Members[0];
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Declaration).Name.LocalName);

            node = (FieldDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a {public int df;}").Members[0]).Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Declaration).Name.LocalName);

            node = (FieldDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a {[Serializable] int df;}").Members[0]).Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Declaration).Name.LocalName);
        }

        [TestMethod]
        public void EventFieldDeclarationServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (EventFieldDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a {[Serializable]public event int df;}").Members[0]).Members[0];
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Declaration).Name.LocalName);

            node = (EventFieldDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a {public event int df;}").Members[0]).Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Declaration).Name.LocalName);

            node = (EventFieldDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a {[Serializable] event int df;}").Members[0]).Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Declaration).Name.LocalName);
        }

        [TestMethod]
        public void ExplicitInterfaceSpecifierServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((EventDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a {event B IA.a1{add; remove;}}").Members[0]).Members[0]).ExplicitInterfaceSpecifier;
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Name).Name.LocalName);
        }

        [TestMethod]
        public void MethodDeclarationServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M<T>(int a, A b)where T: class { return 5; };").Members[0];
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 9);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Modifiers[1]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.ReturnType).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.ExplicitInterfaceSpecifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Name.LocalName == converter.Visit(node.TypeParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[6].Name.LocalName == converter.Visit(node.ParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[7].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.ConstraintClauses[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[8].Name.LocalName == converter.Visit(node.Body).Name.LocalName);

            node = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M<T>(int a, A b)where T: class => 5;").Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 9);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Modifiers[1]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.ReturnType).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.ExplicitInterfaceSpecifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Name.LocalName == converter.Visit(node.TypeParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[6].Name.LocalName == converter.Visit(node.ParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[7].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.ConstraintClauses[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[8].Name.LocalName == converter.Visit(node.ExpressionBody).Name.LocalName);

            node = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public virtual string C.M<T>(int a, A b)where T: class { return 5; };").Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 8);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Modifiers[1]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.ReturnType).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.ExplicitInterfaceSpecifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Name.LocalName == converter.Visit(node.TypeParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Name.LocalName == converter.Visit(node.ParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[6].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.ConstraintClauses[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[7].Name.LocalName == converter.Visit(node.Body).Name.LocalName);
                                              
            node = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public virtual string C.M<T>(int a, A b)where T: class => 5;").Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 8);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[1]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.ReturnType).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.ExplicitInterfaceSpecifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Name.LocalName == converter.Visit(node.TypeParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Name.LocalName == converter.Visit(node.ParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[6].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.ConstraintClauses[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[7].Name.LocalName == converter.Visit(node.ExpressionBody).Name.LocalName);
                                              
            node = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] virtual string C.M<T>(int a, A b)where T: class { return 5; };").Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 9);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.ReturnType).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.ExplicitInterfaceSpecifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Name.LocalName == converter.Visit(node.TypeParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[6].Name.LocalName == converter.Visit(node.ParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[7].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.ConstraintClauses[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[8].Name.LocalName == converter.Visit(node.Body).Name.LocalName);
                                              
            node = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public string C.M<T>(int a, A b)where T: class => 5;").Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 9);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.ReturnType).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.ExplicitInterfaceSpecifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Name.LocalName == converter.Visit(node.TypeParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[6].Name.LocalName == converter.Visit(node.ParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[7].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.ConstraintClauses[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[8].Name.LocalName == converter.Visit(node.ExpressionBody).Name.LocalName);
                                              
            node = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string M<T>(int a, A b)where T: class { return 5; };").Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 8);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Modifiers[1]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.ReturnType).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Name.LocalName == converter.Visit(node.TypeParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Name.LocalName == converter.Visit(node.ParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[6].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.ConstraintClauses[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[7].Name.LocalName == converter.Visit(node.Body).Name.LocalName);

            node = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string M<T>(int a, A b)where T: class => 5;").Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 8);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Modifiers[1]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.ReturnType).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Name.LocalName == converter.Visit(node.TypeParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Name.LocalName == converter.Visit(node.ParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[6].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.ConstraintClauses[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[7].Name.LocalName == converter.Visit(node.ExpressionBody).Name.LocalName);

            node = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M(int a, A b)where T: class { return 5; };").Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 8);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Modifiers[1]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.ReturnType).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.ExplicitInterfaceSpecifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Name.LocalName == converter.Visit(node.ParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[6].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.ConstraintClauses[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[7].Name.LocalName == converter.Visit(node.Body).Name.LocalName);

            node = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M(int a, A b)where T: class => 5;").Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 8);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Modifiers[1]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.ReturnType).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.ExplicitInterfaceSpecifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Name.LocalName == converter.Visit(node.ParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[6].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.ConstraintClauses[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[7].Name.LocalName == converter.Visit(node.ExpressionBody).Name.LocalName);

            node = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M<T>(int a, A b) { return 5; };").Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 8);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Modifiers[1]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.ReturnType).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.ExplicitInterfaceSpecifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Name.LocalName == converter.Visit(node.TypeParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[6].Name.LocalName == converter.Visit(node.ParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[7].Name.LocalName == converter.Visit(node.Body).Name.LocalName);

            node = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M<T>(int a, A b) => 5;").Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 8);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Modifiers[1]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.ReturnType).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.ExplicitInterfaceSpecifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Name.LocalName == converter.Visit(node.TypeParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[6].Name.LocalName == converter.Visit(node.ParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[7].Name.LocalName == converter.Visit(node.ExpressionBody).Name.LocalName);

            node = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M<T>(int a, A b)where T: class { return 5; }").Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 9);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Modifiers[1]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.ReturnType).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.ExplicitInterfaceSpecifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Name.LocalName == converter.Visit(node.TypeParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[6].Name.LocalName == converter.Visit(node.ParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[7].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.ConstraintClauses[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[8].Name.LocalName == converter.Visit(node.Body).Name.LocalName);
        }

        [TestMethod]
        public void OperatorDeclarationServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string operator +(int a, A b) { return 5; };").Members[0];
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 6);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Modifiers[1]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.ReturnType).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.OperatorToken).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Name.LocalName == converter.Visit(node.ParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Name.LocalName == converter.Visit(node.Body).Name.LocalName);

            node = (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string operator +(int a, A b) => 5;").Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 6);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Modifiers[1]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.ReturnType).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.OperatorToken).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Name.LocalName == converter.Visit(node.ParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Name.LocalName == converter.Visit(node.ExpressionBody).Name.LocalName);

            node = (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public virtual string operator +(int a, A b) { return 5; };").Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 5);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Modifiers[1]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.ReturnType).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.OperatorToken).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.ParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Name.LocalName == converter.Visit(node.Body).Name.LocalName);
                                              
            node = (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public virtual string operator +(int a, A b) => 5;").Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 5);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Modifiers[1]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.ReturnType).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.OperatorToken).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.ParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Name.LocalName == converter.Visit(node.ExpressionBody).Name.LocalName);

            node = (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public string operator +(int a, A b) { return 5; };").Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 6);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.ReturnType).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.OperatorToken).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Name.LocalName == converter.Visit(node.ParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Name.LocalName == converter.Visit(node.Body).Name.LocalName);

            node = (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] virtual string operator +(int a, A b) => 5;").Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 6);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.ReturnType).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.OperatorToken).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Name.LocalName == converter.Visit(node.ParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Name.LocalName == converter.Visit(node.ExpressionBody).Name.LocalName);

            node = (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string operator +(int a, A b) { return 5; }").Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 6);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Modifiers[1]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.ReturnType).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.OperatorToken).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Name.LocalName == converter.Visit(node.ParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Name.LocalName == converter.Visit(node.Body).Name.LocalName);
        }

        [TestMethod]
        public void ConversionOperatorDeclarationServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (ConversionOperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual implicit operator T(A b) { return 5; };").Members[0];
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 5);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Modifiers[1]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Type).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.ParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Name.LocalName == converter.Visit(node.Body).Name.LocalName);

            node = (ConversionOperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual implicit operator T(A b) => 5;").Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 5);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Modifiers[1]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Type).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.ParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Name.LocalName == converter.Visit(node.ExpressionBody).Name.LocalName);

            node = (ConversionOperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public virtual implicit operator T(A b) { return 5; };").Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 4);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Modifiers[1]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Type).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.ParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.Body).Name.LocalName);
                                              
            node = (ConversionOperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public virtual implicit operator T(A b) => 5;").Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 4);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Modifiers[1]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Type).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.ParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.ExpressionBody).Name.LocalName);

            node = (ConversionOperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public implicit operator T(A b) { return 5; };").Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 5);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Type).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.ParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Name.LocalName == converter.Visit(node.Body).Name.LocalName);

            node = (ConversionOperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] virtual implicit operator T(A b) => 5;").Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 5);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Type).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.ParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Name.LocalName == converter.Visit(node.ExpressionBody).Name.LocalName);

            node = (ConversionOperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public operator T(A b) { return 5; };").Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 5);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Type).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.ParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Name.LocalName == converter.Visit(node.Body).Name.LocalName);

            node = (ConversionOperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] virtual operator T(A b) => 5;").Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 5);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Type).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.ParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Name.LocalName == converter.Visit(node.ExpressionBody).Name.LocalName);

            node = (ConversionOperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual implicit operator T(A b) { return 5; }").Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 5);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Modifiers[1]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Type).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.ParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Name.LocalName == converter.Visit(node.Body).Name.LocalName);
        }

        [TestMethod]
        public void ConstructorDeclarationServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation]public A(B b) : this(b) { }; }").Members[0]).Members[0];
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 6);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.ParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Name.LocalName == converter.Visit(node.Initializer).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Name.LocalName == converter.Visit(node.Body).Name.LocalName);

            node = (ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { public A(B b) : this(b) { }; }").Members[0]).Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 5);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.ParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.Initializer).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Name.LocalName == converter.Visit(node.Body).Name.LocalName);
                                              
            node = (ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation] A(B b) : this(b) { }; }").Members[0]).Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 5);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.ParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.Initializer).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Name.LocalName == converter.Visit(node.Body).Name.LocalName);

            node = (ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation]public A(B b) { }; }").Members[0]).Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 5);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.ParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Name.LocalName == converter.Visit(node.Body).Name.LocalName);

            node = (ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation]public A(B b) : this(b) { } }").Members[0]).Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 6);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.ParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Name.LocalName == converter.Visit(node.Initializer).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Name.LocalName == converter.Visit(node.Body).Name.LocalName);
        }

        [TestMethod]
        public void ConstructorInitializerServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation]public A(B b) : this(b) { }; }").Members[0]).Members[0]).Initializer;
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.ArgumentList.Arguments[0]).Name.LocalName);
        }

        [TestMethod]
        public void DestructorDeclarationServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (DestructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation] internal ~A(){ }; }").Members[0]).Members[0];
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 5);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.ParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Name.LocalName == converter.Visit(node.Body).Name.LocalName);

            node = (DestructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation] ~A(){ }; }").Members[0]).Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 4);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.ParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.Body).Name.LocalName);
                                              
            node = (DestructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation] internal ~A(){ } }").Members[0]).Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 5);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.ParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Name.LocalName == converter.Visit(node.Body).Name.LocalName);
        }

        [TestMethod]
        public void PropertyDeclarationServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M { get{return 5;} set{this.a = 7} } = 3;").Members[0];
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 7);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Modifiers[1]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Type).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.ExplicitInterfaceSpecifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Name.LocalName == converter.Visit(node.AccessorList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[6].Name.LocalName == converter.Visit(node.Initializer).Name.LocalName);

            node = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public virtual string C.M { get{return 5;} set{this.a = 7} } = 3;").Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 6);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Modifiers[1]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Type).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.ExplicitInterfaceSpecifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Name.LocalName == converter.Visit(node.AccessorList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Name.LocalName == converter.Visit(node.Initializer).Name.LocalName);
                                              
            node = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] virtual string C.M { get{return 5;} set{this.a = 7} } = 3;").Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 7);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Type).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.ExplicitInterfaceSpecifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Name.LocalName == converter.Visit(node.AccessorList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[6].Name.LocalName == converter.Visit(node.Initializer).Name.LocalName);

            node = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string M { get{return 5;} set{this.a = 7} } = 3;").Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 6);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[1]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Type).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Name.LocalName == converter.Visit(node.AccessorList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Name.LocalName == converter.Visit(node.Initializer).Name.LocalName);

            node = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M { get; set; }").Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 6);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Modifiers[1]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Type).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.ExplicitInterfaceSpecifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Name.LocalName == converter.Visit(node.AccessorList).Name.LocalName);
            
            node = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M { get{return 5;} set{this.a = 7} } => 3;").Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 7);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Modifiers[1]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Type).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.ExplicitInterfaceSpecifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Name.LocalName == converter.Visit(node.AccessorList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[6].Name.LocalName == converter.Visit(node.ExpressionBody).Name.LocalName);

            node = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public virtual string C.M { get{return 5;} set{this.a = 7} } => 3;").Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 6);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Modifiers[1]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Type).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.ExplicitInterfaceSpecifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Name.LocalName == converter.Visit(node.AccessorList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Name.LocalName == converter.Visit(node.ExpressionBody).Name.LocalName);

            node = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] virtual string C.M { get{return 5;} set{this.a = 7} } => 3;").Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 7);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Type).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.ExplicitInterfaceSpecifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Name.LocalName == converter.Visit(node.AccessorList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[6].Name.LocalName == converter.Visit(node.ExpressionBody).Name.LocalName);

            node = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string M { get{return 5;} set{this.a = 7} } => 3;").Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 6);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Modifiers[1]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Type).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Name.LocalName == converter.Visit(node.AccessorList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Name.LocalName == converter.Visit(node.ExpressionBody).Name.LocalName);

            node = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M {get; set;};").Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 6);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Modifiers[1]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Type).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.ExplicitInterfaceSpecifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Name.LocalName == converter.Visit(node.AccessorList).Name.LocalName);
        }

        [TestMethod]
        public void ArrowExpressionClauseServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M { get{return 5;} set{this.a = 7} } => 3;").Members[0]).ExpressionBody;
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Expression).Name.LocalName);
        }

        [TestMethod]
        public void EventDeclarationServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A C.M { add; remove; }").Members[0];
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 6);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Modifiers[1]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Type).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.ExplicitInterfaceSpecifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Name.LocalName == converter.Visit(node.AccessorList).Name.LocalName);

            node = (EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public virtual event A C.M { add; remove; }").Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 5);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Modifiers[1]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Type).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.ExplicitInterfaceSpecifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Name.LocalName == converter.Visit(node.AccessorList).Name.LocalName);
                                              
            node = (EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] virtual event A C.M { add; remove; }").Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 6);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Type).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.ExplicitInterfaceSpecifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Name.LocalName == converter.Visit(node.AccessorList).Name.LocalName);

            node = (EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A M { add; remove; }").Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 5);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Modifiers[1]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Type).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Name.LocalName == converter.Visit(node.AccessorList).Name.LocalName);
        }

        [TestMethod]
        public void IndexerDeclarationServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A C.this[string key] { get; set; } => 5;").Members[0];
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 7);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Modifiers[1]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Type).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.ExplicitInterfaceSpecifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Name.LocalName == converter.Visit(node.ParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Name.LocalName == converter.Visit(node.AccessorList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[6].Name.LocalName == converter.Visit(node.ExpressionBody).Name.LocalName);

            node = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public virtual A C.this[string key] { get; set; } => 5;").Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 6);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Modifiers[1]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Type).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.ExplicitInterfaceSpecifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.ParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Name.LocalName == converter.Visit(node.AccessorList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Name.LocalName == converter.Visit(node.ExpressionBody).Name.LocalName);

            node = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] virtual A C.this[string key] { get; set; } => 5;").Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 7);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Type).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.ExplicitInterfaceSpecifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Name.LocalName == converter.Visit(node.ParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Name.LocalName == converter.Visit(node.AccessorList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[6].Name.LocalName == converter.Visit(node.ExpressionBody).Name.LocalName);

            node = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A this[string key] { get; set; } => 5;").Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 6);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Modifiers[1]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Type).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.ParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Name.LocalName == converter.Visit(node.AccessorList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Name.LocalName == converter.Visit(node.ExpressionBody).Name.LocalName);

            node = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A C.this[string key] { get; set; };").Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 6);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Modifiers[1]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Type).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.ExplicitInterfaceSpecifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Name.LocalName == converter.Visit(node.ParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Name.LocalName == converter.Visit(node.AccessorList).Name.LocalName);

            node = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A C.this[string key] { get; set; }").Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 6);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Modifiers[1]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Type).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.ExplicitInterfaceSpecifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Name.LocalName == converter.Visit(node.ParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Name.LocalName == converter.Visit(node.AccessorList).Name.LocalName);
        }

        [TestMethod]
        public void AccessorListServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A C.this[string key] { get; set; } => 5;").Members[0]).AccessorList;
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Accessors[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Accessors[1]).Name.LocalName);
        }

        [TestMethod]
        public void AccessorDeclarationServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A C.this[string key] { [Serializable] private get{}; set; }").Members[0]).AccessorList.Accessors[0];
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Body).Name.LocalName);

            node = ((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A C.this[string key] { private get{}; set; }").Members[0]).AccessorList.Accessors[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Body).Name.LocalName);

            node = ((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A C.this[string key] { [Serializable] get{}; set; }").Members[0]).AccessorList.Accessors[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Body).Name.LocalName);

            node = ((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A C.this[string key] { [Serializable] private get; set; }").Members[0]).AccessorList.Accessors[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);

            node = ((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A C.this[string key] { [Serializable] private get{} set; }").Members[0]).AccessorList.Accessors[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Body).Name.LocalName);

            node = ((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A C.this[string key] { [Serializable] private set{}; get; }").Members[0]).AccessorList.Accessors[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Body).Name.LocalName);

            node = ((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A C.this[string key] { private set{}; get; }").Members[0]).AccessorList.Accessors[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Body).Name.LocalName);

            node = ((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A C.this[string key] { [Serializable] set{}; get; }").Members[0]).AccessorList.Accessors[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Body).Name.LocalName);

            node = ((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A C.this[string key] { [Serializable] private set; get; }").Members[0]).AccessorList.Accessors[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);

            node = ((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A C.this[string key] { [Serializable] private set{} get; }").Members[0]).AccessorList.Accessors[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Body).Name.LocalName);

            node = ((EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A C.M { [Serializable] private add{}; remove; }").Members[0]).AccessorList.Accessors[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Body).Name.LocalName);

            node = ((EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A C.M { private add{}; remove; }").Members[0]).AccessorList.Accessors[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Body).Name.LocalName);

            node = ((EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A C.M { [Serializable] add{}; remove; }").Members[0]).AccessorList.Accessors[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Body).Name.LocalName);

            node = ((EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A C.M { [Serializable] private add; remove; }").Members[0]).AccessorList.Accessors[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);

            node = ((EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A C.M { [Serializable] private add{} remove; }").Members[0]).AccessorList.Accessors[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Body).Name.LocalName);

            node = ((EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A C.M { [Serializable] private remove{}; add; }").Members[0]).AccessorList.Accessors[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Body).Name.LocalName);

            node = ((EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A C.M { private remove{}; add; }").Members[0]).AccessorList.Accessors[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Body).Name.LocalName);

            node = ((EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A C.M { [Serializable] remove{}; add; }").Members[0]).AccessorList.Accessors[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Body).Name.LocalName);

            node = ((EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A C.M { [Serializable] private remove; add; }").Members[0]).AccessorList.Accessors[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);

            node = ((EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A C.M { [Serializable] private remove{} add; }").Members[0]).AccessorList.Accessors[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Body).Name.LocalName);

            node = ((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A C.this[string key] { [Serializable] private fg{}; get; }").Members[0]).AccessorList.Accessors[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 4);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Keyword).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.Body).Name.LocalName);

            node = ((PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public virtual int A { private set{}; get; }").Members[0]).AccessorList.Accessors[0];
            node = SyntaxFactory.AccessorDeclaration(SyntaxKind.UnknownAccessorDeclaration, node.AttributeLists, node.Modifiers, SyntaxFactory.Identifier("fg"), node.Body, node.ExpressionBody, node.SemicolonToken);
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Keyword).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Body).Name.LocalName);

            node = ((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A C.this[string key] { [Serializable] fg{}; get; }").Members[0]).AccessorList.Accessors[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Keyword).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Body).Name.LocalName);
            
            node = ((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A C.this[string key] { [Serializable] private fg; get; }").Members[0]).AccessorList.Accessors[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Keyword).Name.LocalName);

            node = ((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A C.this[string key] { [Serializable] private fg{} get; }").Members[0]).AccessorList.Accessors[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 4);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Keyword).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.Body).Name.LocalName);
        }

        [TestMethod]
        public void ParameterListServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int M([Serializable] ref int a = 0, A b){}").Members[0]).ParameterList;
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Parameters[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Parameters[1]).Name.LocalName);
        }

        [TestMethod]
        public void BracketedParameterListServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int this[[Serializable] ref int a = 0, A b]{get;set;}").Members[0]).ParameterList;
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Parameters[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Parameters[1]).Name.LocalName);
        }

        [TestMethod]
        public void ParameterServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int M([Serializable] ref int a = 0, A b){}").Members[0]).ParameterList.Parameters[0];
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 5);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Type).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Name.LocalName == converter.Visit(node.Default).Name.LocalName);

            node = ((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int M(ref int a = 0, A b){}").Members[0]).ParameterList.Parameters[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 4);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Type).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.Default).Name.LocalName);

            node = ((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int M([Serializable] int a = 0, A b){}").Members[0]).ParameterList.Parameters[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 4);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Type).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.Default).Name.LocalName);

            node = ((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int M([Serializable] ref int a, A b){}").Members[0]).ParameterList.Parameters[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 4);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Type).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
        }

        [TestMethod]
        public void SkippedTokensTriviaServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.SkippedTokensTrivia(((IncompleteMemberSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual a").Members[0]).Modifiers);
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Tokens[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Tokens[1]).Name.LocalName);
        }

        [TestMethod]
        public void DocumentationCommentTriviaServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<foo />").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure();
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Content[0]).Name.LocalName);

            node = (DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree(@"/// <summary>" + 
                                                                                    "/// Method hook for implementing logic to execute after the <see cref=\"ChildrenCore(SyntaxNodeOrToken ?)\"/>." + 
                                                                                    "/// </summary>" + 
                                                                                    "/// <param name=\"node\">node of interest.</param>" +
                                                                                    "/// <param name=\"result\">Mechanism to modify the result of <see cref=\"Children(SyntaxNodeOrToken?)\"/>.</param>")
                                                                                    .GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure();
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Content[1]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Content[3]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[2].Name.LocalName == converter.Visit(node.Content[5]).Name.LocalName);
        }

        [TestMethod]
        public void EndIfDirectiveTriviaServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.EndIfDirectiveTrivia(true);
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 0);
        }

        [TestMethod]
        public void RegionDirectiveTriviaServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.RegionDirectiveTrivia(true);
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 0);
        }

        [TestMethod]
        public void EndRegionDirectiveTriviaServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.EndRegionDirectiveTrivia(true);
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 0);
        }

        [TestMethod]
        public void ErrorDirectiveTriviaServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.ErrorDirectiveTrivia(true);
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 0);
        }

        [TestMethod]
        public void WarningDirectiveTriviaServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.WarningDirectiveTrivia(true);
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 0);
        }

        [TestMethod]
        public void BadDirectiveTriviaServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.BadDirectiveTrivia(SyntaxFactory.Identifier("unknown"), true);
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
        }

        [TestMethod]
        public void DefineDirectiveTriviaServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.DefineDirectiveTrivia(SyntaxFactory.Identifier("DEBUG"), true);
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Name).Name.LocalName);
        }

        [TestMethod]
        public void UndefDirectiveTriviaServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.UndefDirectiveTrivia(SyntaxFactory.Identifier("DEBUG"), true);
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Name).Name.LocalName);
        }

        [TestMethod]
        public void LineDirectiveTriviaServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.LineDirectiveTrivia(SyntaxFactory.Literal("200", 200), SyntaxFactory.Literal("\"Special\""), true);
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Line).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.File).Name.LocalName);
        }

        [TestMethod]
        public void PragmaWarningDirectiveTriviaServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var separatedSyntaxList = SyntaxFactory.SeparatedList(new ExpressionSyntax[] { SyntaxFactory.IdentifierName("warning-list"), SyntaxFactory.IdentifierName("CS3021") });
            var node = SyntaxFactory.PragmaWarningDirectiveTrivia(SyntaxFactory.Token(SyntaxKind.DisableKeyword), separatedSyntaxList, true);
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.DisableOrRestoreKeyword).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.ErrorCodes[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.ErrorCodes[1]).Name.LocalName);
        }

        [TestMethod]
        public void PragmaChecksumDirectiveTriviaServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.PragmaChecksumDirectiveTrivia(SyntaxFactory.Literal("\"file.cs\""), SyntaxFactory.Literal("\"{3673e4ca-6098-4ec1-890f-8fceb2a794a2}\""), SyntaxFactory.Literal("\"{012345678AB}\""), true);
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.File).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Guid).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Bytes).Name.LocalName);
        }

        [TestMethod]
        public void ReferenceDirectiveTriviaServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.ReferenceDirectiveTrivia(SyntaxFactory.Literal("DEBUG"), true);
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.File).Name.LocalName);
        }

        [TestMethod]
        public void LoadDirectiveTriviaServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.LoadDirectiveTrivia(SyntaxFactory.Literal("DEBUG"), true);
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.File).Name.LocalName);
        }

        [TestMethod]
        public void ShebangDirectiveTriviaServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.ShebangDirectiveTrivia(true);
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 0);
        }

        [TestMethod]
        public void ElseDirectiveTriviaServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.ElseDirectiveTrivia(true, true);
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 0);
        }

        [TestMethod]
        public void IfDirectiveTriviaServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (IfDirectiveTriviaSyntax)SyntaxFactory.ParseSyntaxTree("#if DEBUG Console.WriteLine(\"Debug version\"); #endif").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure();
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Condition).Name.LocalName);
        }

        [TestMethod]
        public void ElifDirectiveTriviaServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.ElifDirectiveTrivia(SyntaxFactory.IdentifierName("VC7"), true, true, true);
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Condition).Name.LocalName);
        }

        [TestMethod]
        public void TypeCrefServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var text = "namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"int\"/> </summary>" + Environment.NewLine +
                       "    class A { } }";
            var namespaceNode = SyntaxFactory.ParseCompilationUnit(text).Members[0];
            var node = namespaceNode.DescendantNodes(descendIntoTrivia: true).OfType<TypeCrefSyntax>().Single();
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Type).Name.LocalName);
        }

        [TestMethod]
        public void QualifiedCrefServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var text = "namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"N.A\"/> </summary>" + Environment.NewLine +
                       "    class A { } }";
            var namespaceNode = SyntaxFactory.ParseCompilationUnit(text).Members[0];
            var node = namespaceNode.DescendantNodes(descendIntoTrivia: true).OfType<QualifiedCrefSyntax>().Single();
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Container).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Member).Name.LocalName);
        }

        [TestMethod]
        public void NameMemberCrefServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var text = "namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"N(int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }";
            var namespaceNode = SyntaxFactory.ParseCompilationUnit(text).Members[0];
            var node = namespaceNode.DescendantNodes(descendIntoTrivia: true).OfType<NameMemberCrefSyntax>().Single();
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Name).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Parameters).Name.LocalName);
            
            var text3 = "namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"N\"/> </summary>" + Environment.NewLine +
                       "    class A { } }";
            namespaceNode = SyntaxFactory.ParseCompilationUnit(text3).Members[0];
            node = namespaceNode.DescendantNodes(descendIntoTrivia: true).OfType<NameMemberCrefSyntax>().Single();
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Name).Name.LocalName);
        }

        [TestMethod]
        public void IndexerMemberCrefServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var text = "namespace N { " + Environment.NewLine +
                        "    /// <summary> <see cref=\"this[int]\"/> </summary>" + Environment.NewLine +
                        "    class A { } }";
            var namespaceNode = SyntaxFactory.ParseCompilationUnit(text).Members[0];
            var node = namespaceNode.DescendantNodes(descendIntoTrivia: true).OfType<IndexerMemberCrefSyntax>().Single();
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Parameters).Name.LocalName);

            var text3 = "namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"this\"/> </summary>" + Environment.NewLine +
                       "    class A { } }";
            namespaceNode = SyntaxFactory.ParseCompilationUnit(text3).Members[0];
            node = namespaceNode.DescendantNodes(descendIntoTrivia: true).OfType<IndexerMemberCrefSyntax>().Single();
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 0);
        }

        [TestMethod]
        public void OperatorMemberCrefServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var text = "namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }";
            var namespaceNode = SyntaxFactory.ParseCompilationUnit(text).Members[0];
            var node = namespaceNode.DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single();
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.OperatorToken).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Parameters).Name.LocalName);

            var text3 = "namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +\"/> </summary>" + Environment.NewLine +
                       "    class A { } }";
            namespaceNode = SyntaxFactory.ParseCompilationUnit(text3).Members[0];
            node = namespaceNode.DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single();
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.OperatorToken).Name.LocalName);
        }

        [TestMethod]
        public void ConversionOperatorMemberCrefServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var text = "namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"implicit operator N(int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }";
            var namespaceNode = SyntaxFactory.ParseCompilationUnit(text).Members[0];
            var node = namespaceNode.DescendantNodes(descendIntoTrivia: true).OfType<ConversionOperatorMemberCrefSyntax>().Single();
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Type).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Parameters).Name.LocalName);

            text = "namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"explicit operator N\"/> </summary>" + Environment.NewLine +
                       "    class A { } }";
            namespaceNode = SyntaxFactory.ParseCompilationUnit(text).Members[0];
            node = namespaceNode.DescendantNodes(descendIntoTrivia: true).OfType<ConversionOperatorMemberCrefSyntax>().Single();
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Type).Name.LocalName);
        }

        [TestMethod]
        public void CrefParameterListServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var text = "namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(int, string)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }";
            var namespaceNode = SyntaxFactory.ParseCompilationUnit(text).Members[0];
            var node = namespaceNode.DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Parameters[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Parameters[1]).Name.LocalName);
        }

        [TestMethod]
        public void CrefBracketedParameterListServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var text = "namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"this[int, string]\"/> </summary>" + Environment.NewLine +
                       "    class A { } }";
            var namespaceNode = SyntaxFactory.ParseCompilationUnit(text).Members[0];
            var node = namespaceNode.DescendantNodes(descendIntoTrivia: true).OfType<IndexerMemberCrefSyntax>().Single().Parameters;
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Parameters[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Parameters[1]).Name.LocalName);
        }

        [TestMethod]
        public void CrefParameterServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var text = "namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref int, out string)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }";
            var namespaceNode = SyntaxFactory.ParseCompilationUnit(text).Members[0];
            var node = namespaceNode.DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Type).Name.LocalName);

            text = "namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(int, string)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }";
            namespaceNode = SyntaxFactory.ParseCompilationUnit(text).Members[0];
            node = namespaceNode.DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Type).Name.LocalName);
        }

        [TestMethod]
        public void XmlElementServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (XmlElementSyntax)((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.Single();
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.StartTag).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Content[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.EndTag).Name.LocalName);
        }

        [TestMethod]
        public void XmlElementStartTagServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag;
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Name).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Attributes[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Attributes[1]).Name.LocalName);
        }

        [TestMethod]
        public void XmlElementEndTagServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().EndTag;
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Name).Name.LocalName);
        }

        [TestMethod]
        public void XmlEmptyElementServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<foo id=\"3\"/>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlEmptyElementSyntax>().Single();
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Name).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Attributes[0]).Name.LocalName);

            node = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<foo/>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlEmptyElementSyntax>().Single();
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Name).Name.LocalName);
        }

        [TestMethod]
        public void XmlNameServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<d:foo/>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlEmptyElementSyntax>().Single().Name;
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Prefix).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.LocalName).Name.LocalName);

            node = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<foo/>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlEmptyElementSyntax>().Single().Name;
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.LocalName).Name.LocalName);
        }

        [TestMethod]
        public void XmlPrefixServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<d:foo/>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlEmptyElementSyntax>().Single().Name.Prefix;
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Prefix).Name.LocalName);
        }

        [TestMethod]
        public void XmlTextAttributeServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (XmlTextAttributeSyntax)((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<message id=\"5 r\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag.Attributes[0];
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Name).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.TextTokens[0]).Name.LocalName);
        }

        [TestMethod]
        public void XmlCrefAttributeServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (XmlCrefAttributeSyntax)((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<see cref=\"M\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag.Attributes[0];
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Cref).Name.LocalName);
        }

        [TestMethod]
        public void XmlNameAttributeServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (XmlNameAttributeSyntax)((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<param name=\"M\"/>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlEmptyElementSyntax>().Single().Attributes[0];
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
        }

        [TestMethod]
        public void XmlTextServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (XmlTextSyntax)((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<foo>bar</foo>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().Content[0];
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.TextTokens[0]).Name.LocalName);
        }

        [TestMethod]
        public void XmlCDataSectionServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<![CDATA[this is a test of &some; cdata]]>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlCDataSectionSyntax>().Single();
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.TextTokens[0]).Name.LocalName);
        }

        [TestMethod]
        public void XmlProcessingInstructionServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<?proc-inst this is a test of &some; processinginstruction?>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlProcessingInstructionSyntax>().Single();
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Name).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.TextTokens[0]).Name.LocalName);
        }

        [TestMethod]
        public void XmlCommentServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<!--this is a test of &some; comment-->").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlCommentSyntax>().Single();
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.TextTokens[0]).Name.LocalName);
        }

        [TestMethod]
        public void CompilationUnitServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.ParseCompilationUnit("extern alias b; using static d; [assembly: XAttribute] namespace c{};");
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 4);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Externs[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Usings[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Members[0]).Name.LocalName);

            node = SyntaxFactory.ParseCompilationUnit("using static d; [assembly: XAttribute] namespace c{};");
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Usings[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Members[0]).Name.LocalName);

            node = SyntaxFactory.ParseCompilationUnit("extern alias b; [assembly: XAttribute] namespace c{};");
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Externs[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Members[0]).Name.LocalName);

            node = SyntaxFactory.ParseCompilationUnit("extern alias b; using static d; [assembly: XAttribute];");
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Externs[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Usings[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.AttributeLists[0]).Name.LocalName);
        }

        [TestMethod]
        public void ExternAliasDirectiveServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.ParseCompilationUnit("extern alias b; using static d; [assembly: XAttribute] namespace c{};").Externs[0];
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
        }

        [TestMethod]
        public void UsingDirectiveServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.ParseCompilationUnit("extern alias b; using static a = d; [assembly: XAttribute] namespace c{};").Usings[0];
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Alias).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Name).Name.LocalName);

            node = SyntaxFactory.ParseCompilationUnit("extern alias b; using a = d; [assembly: XAttribute] namespace c{};").Usings[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Alias).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Name).Name.LocalName);

            node = SyntaxFactory.ParseCompilationUnit("extern alias b; using static d; [assembly: XAttribute] namespace c{};").Usings[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Name).Name.LocalName);
        }

        [TestMethod]
        public void NamespaceDeclarationServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (NamespaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("namespace a{extern alias b; using static d; namespace c{int f = 3;};};").Members[0];
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 4);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Name).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Externs[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Usings[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Members[0]).Name.LocalName);

            node = (NamespaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("namespace a{using static d; namespace c{int f = 3;};};").Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Name).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Usings[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Members[0]).Name.LocalName);

            node = (NamespaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("namespace a{extern alias b; namespace c{int f = 3;};};").Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Name).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Externs[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Members[0]).Name.LocalName);

            node = (NamespaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("namespace a{extern alias b; using static d;};").Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Name).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Externs[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Usings[0]).Name.LocalName);

            node = (NamespaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("namespace a{extern alias b; using static d; namespace c{int f = 3;};}").Members[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 4);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Name).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Externs[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Usings[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Members[0]).Name.LocalName);
        }

        [TestMethod]
        public void AttributeListServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(\"X\"), YAttribute(Y: 3)]").AttributeLists[0];
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Target).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Attributes[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Attributes[1]).Name.LocalName);

            node = ((FieldDeclarationSyntax)((NamespaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("namespace a {[XAttribute(\"X\"), YAttribute(Y: 3)]int f;}").Members[0]).Members[0]).AttributeLists[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Attributes[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Attributes[1]).Name.LocalName);
        }

        [TestMethod]
        public void AttributeTargetSpecifierServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(\"X\"), YAttribute(Y: 3)]").AttributeLists[0].Target;
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
        }

        [TestMethod]
        public void AttributeServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(\"X\")]").AttributeLists[0].Attributes[0];
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Name).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.ArgumentList).Name.LocalName);

            node = SyntaxFactory.ParseCompilationUnit("[module: XAttribute]").AttributeLists[0].Attributes[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Name).Name.LocalName);
        }

        [TestMethod]
        public void AttributeArgumentListServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(\"X\", Y: 3)]").AttributeLists[0].Attributes[0].ArgumentList;
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Arguments[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Arguments[1]).Name.LocalName);

            node = SyntaxFactory.ParseCompilationUnit("[module: XAttribute()]").AttributeLists[0].Attributes[0].ArgumentList;
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 0);
        }

        [TestMethod]
        public void AttributeArgumentServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(Y: 3)]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0];
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.NameColon).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Expression).Name.LocalName);

            node = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(Y = 3)]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.NameEquals).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Expression).Name.LocalName);

            node = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(3)]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Expression).Name.LocalName);
        }

        [TestMethod]
        public void WhenClauseServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((CasePatternSwitchLabelSyntax)((SwitchStatementSyntax)SyntaxFactory.ParseStatement("switch(obj){ case 'a' when obj.Lenght > 0: }")).Sections[0].Labels[0]).WhenClause;
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Condition).Name.LocalName);
        }

        [TestMethod]
        public void TupleTypeServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (TupleTypeSyntax)SyntaxFactory.ParseTypeName("(string, int)");
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Elements[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Elements[1]).Name.LocalName);
        }

        [TestMethod]
        public void TupleExpressionServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (TupleExpressionSyntax)SyntaxFactory.ParseExpression("(string, int)");
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Arguments[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Arguments[1]).Name.LocalName);
        }

        [TestMethod]
        public void TupleElementServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var type = SyntaxFactory.ParseTypeName("(string, int)");
            var node = SyntaxFactory.TupleElement(type, SyntaxFactory.Identifier("a"));
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Type).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);

            node = SyntaxFactory.TupleElement(type);
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Type).Name.LocalName);
        }

        [TestMethod]
        public void ThrowExpressionServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (ThrowExpressionSyntax)SyntaxFactory.ParseExpression("throw e");
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Expression).Name.LocalName);
        }

        [TestMethod]
        public void SingleVariableDesignationServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.SingleVariableDesignation(SyntaxFactory.Identifier("a"));
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
        }

        [TestMethod]
        public void DiscardDesignationServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.DiscardDesignation(SyntaxFactory.Token(SyntaxKind.UnderscoreToken));
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 0);
        }

        [TestMethod]
        public void ParenthesizedVariableDesignationServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.ParenthesizedVariableDesignation(SyntaxFactory.Token(SyntaxKind.OpenParenToken),
                SyntaxFactory.SeparatedList(new VariableDesignationSyntax[]
                {
                    SyntaxFactory.SingleVariableDesignation(SyntaxFactory.Identifier("a")),
                     SyntaxFactory.DiscardDesignation(SyntaxFactory.Token(SyntaxKind.UnderscoreToken))
                }),
                SyntaxFactory.Token(SyntaxKind.CloseParenToken));
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Variables[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[1].Name.LocalName == converter.Visit(node.Variables[1]).Name.LocalName);

            node = SyntaxFactory.ParenthesizedVariableDesignation(SyntaxFactory.Token(SyntaxKind.OpenParenToken),
                SyntaxFactory.SeparatedList(new VariableDesignationSyntax[0]),
                SyntaxFactory.Token(SyntaxKind.CloseParenToken));
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 0);
        }

        [TestMethod]
        public void RefExpressionServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.RefExpression(SyntaxFactory.Token(SyntaxKind.RefKeyword), SyntaxFactory.ParseExpression("s + d"));
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Expression).Name.LocalName);
        }

        [TestMethod]
        public void CasePatternSwitchLabelServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (CasePatternSwitchLabelSyntax)((SwitchStatementSyntax)SyntaxFactory.ParseStatement("switch(obj){ case 'a' when obj.Lenght > 0: }")).Sections[0].Labels[0];
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Pattern).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.WhenClause).Name.LocalName);

            node = SyntaxFactory.CasePatternSwitchLabel(node.Keyword, node.Pattern, null, node.ColonToken);
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Pattern).Name.LocalName);
        }

        [TestMethod]
        public void IsPatternExpressionServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (IsPatternExpressionSyntax)SyntaxFactory.ParseExpression("obj is A a");
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Expression).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Pattern).Name.LocalName);
        }

        [TestMethod]
        public void DeclarationExpressionServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (DeclarationExpressionSyntax)((TupleExpressionSyntax)SyntaxFactory.ParseExpression("(int a, int b)")).Arguments[0].Expression;
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Type).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Designation).Name.LocalName);
        }

        [TestMethod]
        public void ForEachVariableStatementServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (ForEachVariableStatementSyntax)SyntaxFactory.ParseStatement("foreach(var (a,b) in x){}");
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 3);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Variable).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Expression).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Statement).Name.LocalName);
        }

        [TestMethod]
        public void DeclarationPatternServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (DeclarationPatternSyntax)((CasePatternSwitchLabelSyntax)((SwitchStatementSyntax)SyntaxFactory.ParseStatement("switch(obj){ case Shape s: }")).Sections[0].Labels[0]).Pattern;
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 2);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Type).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Designation).Name.LocalName);
        }

        [TestMethod]
        public void ConstantPatternServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (ConstantPatternSyntax)((CasePatternSwitchLabelSyntax)((SwitchStatementSyntax)SyntaxFactory.ParseStatement("switch(obj){ case 'a' when obj.Lenght > 0: }")).Sections[0].Labels[0]).Pattern;
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Expression).Name.LocalName);
        }

        [TestMethod]
        public void LocalFunctionStatementServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (LocalFunctionStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit(@"
            void m()
            {
                const int local<T>() where T: I => 0;
            }").Members[0]).Body.Statements[0];
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 7);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.ReturnType).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.TypeParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Name.LocalName == converter.Visit(node.ParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.ConstraintClauses[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[6].Name.LocalName == converter.Visit(node.ExpressionBody).Name.LocalName);

            node = (LocalFunctionStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit(@"
            void m()
            {
                const int local<T>() where T: I { return 0;}
            }").Members[0]).Body.Statements[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 7);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.ReturnType).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.TypeParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Name.LocalName == converter.Visit(node.ParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.ConstraintClauses[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[6].Name.LocalName == converter.Visit(node.Body).Name.LocalName);

            node = (LocalFunctionStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit(@"
            void m()
            {
                int local<T>() where T: I => 0;
            }").Members[0]).Body.Statements[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 6);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.ReturnType).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.TypeParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.ParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.ConstraintClauses[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Name.LocalName == converter.Visit(node.ExpressionBody).Name.LocalName);
                                              
            node = (LocalFunctionStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit(@"
            void m()
            {
                int local<T>() where T: I { return 0;}
            }").Members[0]).Body.Statements[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 6);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.ReturnType).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.TypeParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.ParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.ConstraintClauses[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Name.LocalName == converter.Visit(node.Body).Name.LocalName);

            node = (LocalFunctionStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit(@"
            void m()
            {
                const int local() where T: I => 0;
            }").Members[0]).Body.Statements[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 6);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.ReturnType).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.ParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.ConstraintClauses[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Name.LocalName == converter.Visit(node.ExpressionBody).Name.LocalName);

            node = (LocalFunctionStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit(@"
            void m()
            {
                const int local() where T: I { return 0;}
            }").Members[0]).Body.Statements[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 6);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.ReturnType).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.ParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.ConstraintClauses[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Name.LocalName == converter.Visit(node.Body).Name.LocalName);

            node = (LocalFunctionStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit(@"
            void m()
            {
                const int local<T>() where T: I => 0
            }").Members[0]).Body.Statements[0];
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 7);
            Assert.IsTrue(topologicalChildren[0].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.Modifiers[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[1].Name.LocalName == converter.Visit(node.ReturnType).Name.LocalName);
            Assert.IsTrue(topologicalChildren[2].Name.LocalName == converter.Visit(node.Identifier).Name.LocalName);
            Assert.IsTrue(topologicalChildren[3].Name.LocalName == converter.Visit(node.TypeParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[4].Name.LocalName == converter.Visit(node.ParameterList).Name.LocalName);
            Assert.IsTrue(topologicalChildren[5].Elements().ToArray()[0].Name.LocalName == converter.Visit(node.ConstraintClauses[0]).Name.LocalName);
            Assert.IsTrue(topologicalChildren[6].Name.LocalName == converter.Visit(node.ExpressionBody).Name.LocalName);
        }



        [TestMethod]
        public void RefTypeServiceProvider_RoslynMLBasicTopologicalAbstraction_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.RefType(SyntaxFactory.Token(SyntaxKind.RefKeyword), SyntaxFactory.Token(SyntaxKind.ReadOnlyKeyword), SyntaxFactory.ParseTypeName("var"));
            var xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            var topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Type).Name.LocalName);

            node = SyntaxFactory.RefType(SyntaxFactory.Token(SyntaxKind.RefKeyword), SyntaxFactory.ParseTypeName("var"));
            xElement = converter.Visit(node);
            converter.Prune(xElement, selector.PruneSelector);
            Assert.AreEqual(xElement.Attribute("kind")?.Value, null);

            topologicalChildren = xElement.Elements().ToArray();
            Assert.AreEqual(topologicalChildren.Count(), 1);
            Assert.IsTrue(topologicalChildren[0].Name.LocalName == converter.Visit(node.Type).Name.LocalName);
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
                               where nameParts.Length == 3 && nameParts[1] == "RoslynMLBasicTopologicalAbstraction" && nameParts[2] == "OK"
                               select nameParts[0].Replace("ServiceProvider", "Syntax")).ToList();

            var a = cases.Select(info => info.Type.name).Distinct().Except(testedCases).ToArray();
            var b = testedCases.Except(cases.Select(info => info.Type.name).Distinct()).ToArray();

            Assert.AreEqual(a.Count(), 0);
            Assert.AreEqual(b.Count(), 0);
        }

        [TestMethod]
        public void fddf()
        {
            var d = CSharpParseOptions.Default;
            //d = d.WithDocumentationMode(Microsoft.CodeAnalysis.DocumentationMode.Diagnose);
            var content = "namespace{" + System.Environment.NewLine +
                          " /// <summary>" + System.Environment.NewLine +
                          " /// Class Doc." + System.Environment.NewLine +
                          " /// </summary>" + System.Environment.NewLine +
                          " [Serializable]" + System.Environment.NewLine +
                          " private class A {" + System.Environment.NewLine +
                          "   /// <summary>" + System.Environment.NewLine +
                          "   /// Method Doc." + System.Environment.NewLine +
                          "   /// </summary>" + System.Environment.NewLine +
                          "   [Serializable]public virtual void F(){" + System.Environment.NewLine +
                          "    //1111; 2222  " + System.Environment.NewLine +
                          "    int /*1111; 2222*/a;" + System.Environment.NewLine +
                          "   }" + System.Environment.NewLine +
                          " }" + System.Environment.NewLine +
                          "}";

            var n = new CDF.CSharp.RoslynML.RoslynML().GetTree(content, path: false, includeTrivia: true);
            var documentationElements = n.DescendantNodesAndSelf().OfType<XElement>().Where(d1 => d1.Name.LocalName == "DocumentationCommentTrivia").ToArray();
            Assert.AreEqual(documentationElements.Count(), 2);
            Assert.AreEqual(documentationElements[0].Parent.Name.LocalName, "ClassDeclaration");
            Assert.AreEqual(documentationElements[1].Parent.Name.LocalName, "MethodDeclaration");

            var commentElements = n.DescendantNodesAndSelf().OfType<XElement>().Where(d1 => d1.Name.LocalName == "CommentTrivia").ToArray();
            Assert.AreEqual(commentElements.Count(), 2);
            Assert.AreEqual(commentElements[0].Parent.Name.LocalName, "Block");
            Assert.AreEqual(commentElements[0].Value, "//1111; 2222  ");
            Assert.AreEqual(commentElements[1].Parent.Name.LocalName, "Block");
            Assert.AreEqual(commentElements[1].Value, "/*1111; 2222*/");

            var n1 = new CDF.CSharp.RoslynML.RoslynML().GetTree(content, path: false, includeTrivia: false);
            documentationElements = n1.DescendantNodesAndSelf().OfType<XElement>().Where(d1 => d1.Name.LocalName == "DocumentationCommentTrivia").ToArray();
            Assert.AreEqual(documentationElements.Count(), 0);
            commentElements = n1.DescendantNodesAndSelf().OfType<XElement>().Where(d1 => d1.Name.LocalName == "CommentTrivia").ToArray();
            Assert.AreEqual(commentElements.Count(), 0);
        }
    }
}
