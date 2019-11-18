using Jawilliam.CDF.Approach.Services;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace Jawilliam.CDF.Tests.Flad.Awareness
{
    /// <summary>
    /// Summary description for TopologyTests
    /// </summary>
    [TestClass]
    public class RoslynMLAndGumtreefyTypeBasedLabelsTests
    {
        [TestMethod]
        public void ParenthesizedExpressionServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (ParenthesizedExpressionSyntax)SyntaxFactory.ParseExpression("(3)");
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void PrefixUnaryExpressionServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (PrefixUnaryExpressionSyntax)SyntaxFactory.ParseExpression("++3");
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), (int)SyntaxKind.PointerIndirectionExpression);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, node.GetType().Name.Replace("Syntax", ""));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void AwaitExpressionServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (AwaitExpressionSyntax)SyntaxFactory.ParseExpression("await x");
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void PostfixUnaryExpressionServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (PostfixUnaryExpressionSyntax)SyntaxFactory.ParseExpression("3++");
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), (int)SyntaxKind.PostDecrementExpression);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, node.GetType().Name.Replace("Syntax", ""));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void MemberAccessExpressionServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (MemberAccessExpressionSyntax)SyntaxFactory.ParseExpression("x.r");
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), (int)SyntaxKind.PointerMemberAccessExpression);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, node.GetType().Name.Replace("Syntax", ""));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void ConditionalAccessExpressionServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (ConditionalAccessExpressionSyntax)SyntaxFactory.ParseExpression("x?.r");
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void MemberBindingExpressionServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (MemberBindingExpressionSyntax)((ConditionalAccessExpressionSyntax)SyntaxFactory.ParseExpression("m?.r")).WhenNotNull;
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void ElementBindingExpressionServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (ElementBindingExpressionSyntax)((ConditionalAccessExpressionSyntax)SyntaxFactory.ParseExpression("m?[r]")).WhenNotNull;
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void ImplicitElementAccessServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
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

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void BinaryExpressionServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (BinaryExpressionSyntax)SyntaxFactory.ParseExpression("1 * 2");
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), (int)SyntaxKind.CoalesceExpression);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, node.GetType().Name.Replace("Syntax", ""));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void AssignmentExpressionServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (AssignmentExpressionSyntax)SyntaxFactory.ParseExpression("x *= 2");
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), (int)SyntaxKind.RightShiftAssignmentExpression);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, node.GetType().Name.Replace("Syntax", ""));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void ConditionalExpressionServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (ConditionalExpressionSyntax)SyntaxFactory.ParseExpression("x ? 3 : 2");
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void ThisExpressionServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (ThisExpressionSyntax)SyntaxFactory.ParseExpression("this");
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void BaseExpressionServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (BaseExpressionSyntax)SyntaxFactory.ParseExpression("base");
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void LiteralExpressionServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (LiteralExpressionSyntax)SyntaxFactory.ParseExpression("3");
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), (int)SyntaxKind.DefaultLiteralExpression);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, node.GetType().Name.Replace("Syntax", ""));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void MakeRefExpressionServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (MakeRefExpressionSyntax)SyntaxFactory.ParseExpression("__makeref(x)");
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void RefTypeExpressionServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (RefTypeExpressionSyntax)SyntaxFactory.ParseExpression("__reftype(x)");
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void RefValueExpressionServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (RefValueExpressionSyntax)SyntaxFactory.ParseExpression("__refvalue(x, int)");
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void CheckedExpressionServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (CheckedExpressionSyntax)SyntaxFactory.ParseExpression("unchecked(y)");
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), (int)SyntaxKind.CheckedExpression);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, node.GetType().Name.Replace("Syntax", ""));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (CheckedExpressionSyntax)SyntaxFactory.ParseExpression("checked(y)");
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), (int)SyntaxKind.CheckedExpression);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, node.GetType().Name.Replace("Syntax", ""));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void DefaultExpressionServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (DefaultExpressionSyntax)SyntaxFactory.ParseExpression("default(x)");
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void TypeOfExpressionServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (TypeOfExpressionSyntax)SyntaxFactory.ParseExpression("typeof(x)");
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void SizeOfExpressionServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (SizeOfExpressionSyntax)SyntaxFactory.ParseExpression("sizeof(x)");
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void InvocationExpressionServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (InvocationExpressionSyntax)SyntaxFactory.ParseExpression("a(r,e)");
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void ElementAccessExpressionServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (ElementAccessExpressionSyntax)SyntaxFactory.ParseExpression("x[\"a\"]");
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void CastExpressionServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (CastExpressionSyntax)SyntaxFactory.ParseExpression("(int)x");
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void AnonymousMethodExpressionServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (AnonymousMethodExpressionSyntax)SyntaxFactory.ParseExpression("async delegate() { return 4; }");
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (AnonymousMethodExpressionSyntax)SyntaxFactory.ParseExpression("async delegate { return 4; }");
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void SimpleLambdaExpressionServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (SimpleLambdaExpressionSyntax)SyntaxFactory.ParseExpression("async e => 4");
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void ParenthesizedLambdaExpressionServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (ParenthesizedLambdaExpressionSyntax)SyntaxFactory.ParseExpression("async (e) => 4");
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void InitializerExpressionServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((ObjectCreationExpressionSyntax)SyntaxFactory.ParseExpression("new F { 4, 'r', \"hello world\" }")).Initializer;
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), (int)SyntaxKind.ComplexElementInitializerExpression);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, node.GetType().Name.Replace("Syntax", ""));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = ((ArrayCreationExpressionSyntax)SyntaxFactory.ParseExpression("new object[] { 4, 'r', \"hello world\" }")).Initializer;
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), (int)SyntaxKind.ComplexElementInitializerExpression);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, node.GetType().Name.Replace("Syntax", ""));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void ObjectCreationExpressionServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (ObjectCreationExpressionSyntax)SyntaxFactory.ParseExpression("new F() { 4, 'r', \"hello world\" }");
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (ObjectCreationExpressionSyntax)SyntaxFactory.ParseExpression("new F { 4, 'r', \"hello world\" }");
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void AnonymousObjectCreationExpressionServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (AnonymousObjectCreationExpressionSyntax)SyntaxFactory.ParseExpression("new { Text = 4, aText = 5 }");
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void ArrayCreationExpressionServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (ArrayCreationExpressionSyntax)SyntaxFactory.ParseExpression("new A[]{4, 6}");
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void ImplicitArrayCreationExpressionServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (ImplicitArrayCreationExpressionSyntax)SyntaxFactory.ParseExpression("new [,]{4, 6}");
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void StackAllocArrayCreationExpressionServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (StackAllocArrayCreationExpressionSyntax)SyntaxFactory.ParseExpression("stackalloc int[2]");
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void QueryExpressionServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s where f.A select f.R");
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void InterpolatedStringExpressionServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (InterpolatedStringExpressionSyntax)SyntaxFactory.ParseExpression("$\"Hello world\"");
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void InterpolatedStringTextServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (InterpolatedStringTextSyntax)((InterpolatedStringExpressionSyntax)SyntaxFactory.ParseExpression("$\"Hello world\"")).Contents[0];
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void InterpolationServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (InterpolationSyntax)((InterpolatedStringExpressionSyntax)SyntaxFactory.ParseExpression("$\"Hello world {Name, 5:N2}\"")).Contents[1];
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (InterpolationSyntax)((InterpolatedStringExpressionSyntax)SyntaxFactory.ParseExpression("$\"Hello world  {Name,5}\"")).Contents[1];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (InterpolationSyntax)((InterpolatedStringExpressionSyntax)SyntaxFactory.ParseExpression("$\"Hello world  {Name:N2}\"")).Contents[1];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (InterpolationSyntax)((InterpolatedStringExpressionSyntax)SyntaxFactory.ParseExpression("$\"Hello world {Name}\"")).Contents[1];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void InterpolationAlignmentClauseServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((InterpolationSyntax)((InterpolatedStringExpressionSyntax)SyntaxFactory.ParseExpression("$\"Hello world {Name, 5:N2}\"")).Contents[1]).AlignmentClause;
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void InterpolationFormatClauseServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((InterpolationSyntax)((InterpolatedStringExpressionSyntax)SyntaxFactory.ParseExpression("$\"Hello world {Name, 5:N2}\"")).Contents[1]).FormatClause;
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void ArgumentListServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((InvocationExpressionSyntax)SyntaxFactory.ParseExpression("x.F(x, r)")).ArgumentList;
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void BracketedArgumentListServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((ElementAccessExpressionSyntax)SyntaxFactory.ParseExpression("x.F[x, r]")).ArgumentList;
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void ArgumentServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((InvocationExpressionSyntax)SyntaxFactory.ParseExpression("x.F(x, r)")).ArgumentList.Arguments[0];
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = ((InvocationExpressionSyntax)SyntaxFactory.ParseExpression("x.F(ref x, r)")).ArgumentList.Arguments[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = ((InvocationExpressionSyntax)SyntaxFactory.ParseExpression("x.F(x, out r)")).ArgumentList.Arguments[1];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = ((InvocationExpressionSyntax)SyntaxFactory.ParseExpression("x.F(a: x, out r)")).ArgumentList.Arguments[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void NameColonServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((InvocationExpressionSyntax)SyntaxFactory.ParseExpression("x.F(a: x, r)")).ArgumentList.Arguments[0].NameColon;
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void NameEqualsServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((AnonymousObjectCreationExpressionSyntax)SyntaxFactory.ParseExpression("new { Text = 4, aText = 5 }")).Initializers[0].NameEquals;
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void AnonymousObjectMemberDeclaratorServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((AnonymousObjectCreationExpressionSyntax)SyntaxFactory.ParseExpression("new { Text = 4, aText = 5 }")).Initializers[0];
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void QueryBodyServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s where f.A select f.R")).Body;
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = ((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s where f.A select f.R into t")).Body;
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void FromClauseServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from T f in s where f.A select f.R")).FromClause;
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = ((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s where f.A select f.R")).FromClause;
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void LetClauseServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((LetClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s let y = 5 where f.A select f.R")).Body.Clauses[0]);
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void JoinClauseServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((JoinClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s join T t in F on t.L equals s.R into y")).Body.Clauses[0]);
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = ((JoinClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s join T t in F on t.L equals s.R")).Body.Clauses[0]);
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void JoinIntoClauseServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((JoinClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s join T t in F on t.L equals s.R into y")).Body.Clauses[0]).Into;
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void WhereClauseServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((WhereClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from A f in s where y = 5")).Body.Clauses[0]);
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void OrderByClauseServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((OrderByClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from A f in s orderby f.y")).Body.Clauses[0]);
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void OrderingServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((OrderByClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from A f in s orderby f.y descending")).Body.Clauses[0]).Orderings[0];
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), (int)SyntaxKind.DescendingOrdering);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, node.GetType().Name.Replace("Syntax", ""));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = ((OrderByClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from A f in s orderby f.y ascending")).Body.Clauses[0]).Orderings[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), (int)SyntaxKind.DescendingOrdering);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, node.GetType().Name.Replace("Syntax", ""));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = ((OrderByClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from A f in s orderby f.y")).Body.Clauses[0]).Orderings[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), (int)SyntaxKind.DescendingOrdering);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, node.GetType().Name.Replace("Syntax", ""));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void SelectClauseServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((SelectClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from A f in s select f")).Body.SelectOrGroup);
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void GroupClauseServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((GroupClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from A f in s group g by f.r")).Body.SelectOrGroup);
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void QueryContinuationServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from A f in s select f into g select f.r")).Body.Continuation;
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void PredefinedTypeServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (PredefinedTypeSyntax)SyntaxFactory.ParseTypeName("int");
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void ArrayTypeServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (ArrayTypeSyntax)SyntaxFactory.ParseTypeName("int[1, 2]");
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (ArrayTypeSyntax)SyntaxFactory.ParseTypeName("int[][]");
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void PointerTypeServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (PointerTypeSyntax)SyntaxFactory.ParseTypeName("int*");
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void NullableTypeServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (NullableTypeSyntax)SyntaxFactory.ParseTypeName("int?");
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void OmittedTypeArgumentServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (OmittedTypeArgumentSyntax)((GenericNameSyntax)SyntaxFactory.ParseName("a<,>")).TypeArgumentList.Arguments[0];
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void QualifiedNameServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (QualifiedNameSyntax)SyntaxFactory.ParseName("a.x");
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void AliasQualifiedNameServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (AliasQualifiedNameSyntax)SyntaxFactory.ParseName("global::c");
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void IdentifierNameServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (IdentifierNameSyntax)SyntaxFactory.ParseName("c");
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void GenericNameServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (GenericNameSyntax)SyntaxFactory.ParseName("a<,>");
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void TypeArgumentListServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((GenericNameSyntax)SyntaxFactory.ParseName("a<,>")).TypeArgumentList;
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void ArrayRankSpecifierServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((ArrayTypeSyntax)SyntaxFactory.ParseTypeName("int[1, 2]")).RankSpecifiers[0];
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = ((ArrayTypeSyntax)SyntaxFactory.ParseTypeName("int[][]")).RankSpecifiers[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void OmittedArraySizeExpressionServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (OmittedArraySizeExpressionSyntax)((ArrayTypeSyntax)SyntaxFactory.ParseTypeName("int[]")).RankSpecifiers[0].Sizes[0];
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void BlockServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (BlockSyntax)SyntaxFactory.ParseStatement("{ x = 5;x += 3; }");
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void LocalDeclarationStatementServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (LocalDeclarationStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int a() { const int a; }").Members[0]).Body.Statements[0];
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (LocalDeclarationStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int a() { int a; }").Members[0]).Body.Statements[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void ExpressionStatementServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (ExpressionStatementSyntax)SyntaxFactory.ParseStatement("3");
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void EmptyStatementServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (EmptyStatementSyntax)SyntaxFactory.ParseStatement(";");
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void LabeledStatementServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (LabeledStatementSyntax)SyntaxFactory.ParseStatement("l: 3");
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void GotoStatementServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (GotoStatementSyntax)SyntaxFactory.ParseStatement("goto l;");
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), (int)SyntaxKind.GotoStatement);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, node.GetType().Name.Replace("Syntax", ""));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (GotoStatementSyntax)SyntaxFactory.ParseStatement("goto case l;");
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), (int)SyntaxKind.GotoStatement);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, node.GetType().Name.Replace("Syntax", ""));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (GotoStatementSyntax)SyntaxFactory.ParseStatement("goto default;");
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), (int)SyntaxKind.GotoStatement);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, node.GetType().Name.Replace("Syntax", ""));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void BreakStatementServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (BreakStatementSyntax)SyntaxFactory.ParseStatement("break;");
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void ContinueStatementServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (ContinueStatementSyntax)SyntaxFactory.ParseStatement("continue;");
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void ReturnStatementServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (ReturnStatementSyntax)SyntaxFactory.ParseStatement("return 5;");
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void ThrowStatementServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (ThrowStatementSyntax)SyntaxFactory.ParseStatement("throw 5;");
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void YieldStatementServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (YieldStatementSyntax)SyntaxFactory.ParseStatement("yield return 5;");
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), (int)SyntaxKind.YieldBreakStatement);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, node.GetType().Name.Replace("Syntax", ""));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (YieldStatementSyntax)SyntaxFactory.ParseStatement("yield break;");
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), (int)SyntaxKind.YieldBreakStatement);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, node.GetType().Name.Replace("Syntax", ""));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void WhileStatementServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (WhileStatementSyntax)SyntaxFactory.ParseStatement("while (x < 0) x = 5;");
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void DoStatementServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (DoStatementSyntax)SyntaxFactory.ParseStatement("do x = 5; while (x < 0);");
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void ForStatementServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (ForStatementSyntax)SyntaxFactory.ParseStatement("for(int a = 0, b = 4; a < 0; a++, --b);");
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (ForStatementSyntax)SyntaxFactory.ParseStatement("for(a = 0, b = 4; a < 0; a++, --b);");
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (ForStatementSyntax)SyntaxFactory.ParseStatement("for(; a < 0; a++, --b);");
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (ForStatementSyntax)SyntaxFactory.ParseStatement("for(int a, b = 4; a < 0;);");
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void ForEachStatementServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (ForEachStatementSyntax)SyntaxFactory.ParseStatement("foreach(int a in ac);");
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void UsingStatementServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (UsingStatementSyntax)SyntaxFactory.ParseStatement("using(int a, b = 4);");
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (UsingStatementSyntax)SyntaxFactory.ParseStatement("using(a);");
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void FixedStatementServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (FixedStatementSyntax)SyntaxFactory.ParseStatement("fixed(int a, b = 4);");
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void CheckedStatementServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (CheckedStatementSyntax)SyntaxFactory.ParseStatement("checked { x = 5;}");
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), (int)SyntaxKind.CheckedStatement);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, node.GetType().Name.Replace("Syntax", ""));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

       [TestMethod]
        public void UnsafeStatementServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (UnsafeStatementSyntax)SyntaxFactory.ParseStatement("unsafe { x = 5;}");
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void LockStatementServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (LockStatementSyntax)SyntaxFactory.ParseStatement("lock(b = 4);");
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void IfStatementServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (IfStatementSyntax)SyntaxFactory.ParseStatement("if(b == 4);");
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void SwitchStatementServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (SwitchStatementSyntax)SyntaxFactory.ParseStatement("switch(b){ case default; }");
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (SwitchStatementSyntax)SyntaxFactory.ParseStatement("switch(b){ }");
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void TryStatementServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch(A1){a1 = \"Catch a1\";} catch(B1) when(e = 5) {b1 = \"Catch b1\";} finally{c1 = \"Finnally1\";}");
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} finally{c1 = \"Finnally1\";}");
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch(A1){a1 = \"Catch a1\";} catch(B1) when(e = 5) {b1 = \"Catch b1\";}");
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void VariableDeclarationServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((FixedStatementSyntax)SyntaxFactory.ParseStatement("fixed(int a, b = 4);")).Declaration;
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void VariableDeclaratorServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((FixedStatementSyntax)SyntaxFactory.ParseStatement("fixed(int a, b = 4);")).Declaration.Variables[0];
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = ((FixedStatementSyntax)SyntaxFactory.ParseStatement("fixed(int a = 2, b = 4);")).Declaration.Variables[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void EqualsValueClauseServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((FixedStatementSyntax)SyntaxFactory.ParseStatement("fixed(int a, b = 4);")).Declaration.Variables[1].Initializer;
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void ElseClauseServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((IfStatementSyntax)SyntaxFactory.ParseStatement("if(b == 4); else;")).Else;
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void SwitchSectionServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((SwitchStatementSyntax)SyntaxFactory.ParseStatement("switch(b){ case default:; }")).Sections[0];
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void CaseSwitchLabelServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (CaseSwitchLabelSyntax)((SwitchStatementSyntax)SyntaxFactory.ParseStatement("switch(b){ case 4: return 4; default: return 10; }")).Sections[0].Labels[0];
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void DefaultSwitchLabelServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (DefaultSwitchLabelSyntax)((SwitchStatementSyntax)SyntaxFactory.ParseStatement("switch(b){ default:; }")).Sections[0].Labels[0];
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void CatchClauseServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch(A1 a) when(e = 5) {a1 = \"Catch a1\";}")).Catches[0];
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = ((TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch(A1){a1 = \"Catch a1\";}")).Catches[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = ((TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch {b1 = \"Catch b1\";}")).Catches[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void CatchDeclarationServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch(A1 a) when(e = 5) {a1 = \"Catch a1\";}")).Catches[0].Declaration;
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = ((TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch(A1){a1 = \"Catch a1\";}")).Catches[0].Declaration;
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void CatchFilterClauseServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch(A1 a) when(e = 5) {a1 = \"Catch a1\";}")).Catches[0].Filter;
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void FinallyClauseServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} finally {a1 = \"Catch a1\";}")).Finally;
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void IncompleteMemberServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (IncompleteMemberSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public a").Members[0];
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (IncompleteMemberSyntax)SyntaxFactory.ParseCompilationUnit("public a").Members[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (IncompleteMemberSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] a").Members[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void GlobalStatementServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = Microsoft.CodeAnalysis.CSharp.SyntaxFactory.GlobalStatement(SyntaxFactory.ParseStatement("x++"));
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void DelegateDeclarationServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (DelegateDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public delegate void Del<T>(string str) where T: I;").Members[0];
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (DelegateDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public delegate void Del<T>(string str) where T: I;").Members[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (DelegateDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] delegate void Del<T>(string str) where T: I;").Members[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (DelegateDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public delegate void Del(string str) where T: I;").Members[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (DelegateDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public delegate void Del<T>(string str);").Members[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void EnumDeclarationServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (EnumDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public enum a : byte {a1, a2 = 3};").Members[0];
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (EnumDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public enum a : byte {a1, a2 = 3};").Members[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (EnumDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] enum a : byte {a1, a2 = 3};").Members[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (EnumDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public enum a {a1, a2 = 3};").Members[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (EnumDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public enum a : byte {a1, a2 = 3}").Members[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void ClassDeclarationServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public class a<T> : byte where T : int  {X a1; Y a2 = 3;};").Members[0];
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class a<T> : byte where T : int  {X a1; Y a2 = 3;};").Members[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] class a<T> : byte where T : int  {X a1; Y a2 = 3;};").Members[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public class a : byte where T : int  {X a1; Y a2 = 3;};").Members[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public class a<T> where T : int  {X a1; Y a2 = 3;};").Members[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public class a<T> : byte where T : int  {X a1; Y a2 = 3;}").Members[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void StructDeclarationServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (StructDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public struct a<T> : byte where T : int  {X a1; Y a2 = 3;};").Members[0];
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (StructDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public struct a<T> : byte where T : int  {X a1; Y a2 = 3;};").Members[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (StructDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] struct a<T> : byte where T : int  {X a1; Y a2 = 3;};").Members[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (StructDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public struct a : byte where T : int  {X a1; Y a2 = 3;};").Members[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (StructDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public struct a<T> where T : int  {X a1; Y a2 = 3;};").Members[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (StructDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public struct a<T> : byte where T : int  {X a1; Y a2 = 3;}").Members[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void InterfaceDeclarationServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (InterfaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public interface a<T> : byte where T : int  {X a1; Y a2 = 3;};").Members[0];
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (InterfaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public interface a<T> : byte where T : int  {X a1; Y a2 = 3;};").Members[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (InterfaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] interface a<T> : byte where T : int  {X a1; Y a2 = 3;};").Members[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (InterfaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public interface a : byte where T : int  {X a1; Y a2 = 3;};").Members[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (InterfaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public interface a<T> where T : int  {X a1; Y a2 = 3;};").Members[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (InterfaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public interface a<T> : byte where T : int  {X a1; Y a2 = 3;}").Members[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void EnumMemberDeclarationServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((EnumDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public enum a : byte {a1, [Serializable] a2 = 3};").Members[0]).Members[1];
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = ((EnumDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public enum a : byte {a1, a2 = 3};").Members[0]).Members[1];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = ((EnumDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public enum a : byte {a1, [Serializable] a2};").Members[0]).Members[1];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void TypeParameterListServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<B, in C> {}").Members[0]).TypeParameterList;
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void TypeParameterServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<[Serializable] in B, in C> {}").Members[0]).TypeParameterList.Parameters[0];
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<in B, in C> {}").Members[0]).TypeParameterList.Parameters[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void TypeParameterConstraintClauseServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<T> : byte where T : new(), class {};").Members[0]).ConstraintClauses[0];
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void TypeConstraintServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (TypeConstraintSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<T> : byte where T : A {};").Members[0]).ConstraintClauses[0].Constraints[0];
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void ConstructorConstraintServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (ConstructorConstraintSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<T> : byte where T : new() {};").Members[0]).ConstraintClauses[0].Constraints[0];
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void ClassOrStructConstraintServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (ClassOrStructConstraintSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<T> : byte where T : class {};").Members[0]).ConstraintClauses[0].Constraints[0];
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), (int)SyntaxKind.StructConstraint);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, node.GetType().Name.Replace("Syntax", ""));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (ClassOrStructConstraintSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<T> : byte where T : struct {};").Members[0]).ConstraintClauses[0].Constraints[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), (int)SyntaxKind.StructConstraint);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, node.GetType().Name.Replace("Syntax", ""));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void BaseListServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<T> : A, I where T : A {};").Members[0]).BaseList;
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void SimpleBaseTypeServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<T> : A, I where T : A {};").Members[0]).BaseList.Types[0];
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void FieldDeclarationServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (FieldDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a {[Serializable]public int df;}").Members[0]).Members[0];
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (FieldDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a {public int df;}").Members[0]).Members[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (FieldDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a {[Serializable] int df;}").Members[0]).Members[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void EventFieldDeclarationServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (EventFieldDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a {[Serializable]public event int df;}").Members[0]).Members[0];
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (EventFieldDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a {public event int df;}").Members[0]).Members[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (EventFieldDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a {[Serializable] event int df;}").Members[0]).Members[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void ExplicitInterfaceSpecifierServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((EventDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a {event B IA.a1{add; remove;}}").Members[0]).Members[0]).ExplicitInterfaceSpecifier;
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void MethodDeclarationServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M<T>(int a, A b)where T: class { return 5; };").Members[0];
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M<T>(int a, A b)where T: class => 5;").Members[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public virtual string C.M<T>(int a, A b)where T: class { return 5; };").Members[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public virtual string C.M<T>(int a, A b)where T: class => 5;").Members[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] virtual string C.M<T>(int a, A b)where T: class { return 5; };").Members[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public string C.M<T>(int a, A b)where T: class => 5;").Members[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string M<T>(int a, A b)where T: class { return 5; };").Members[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string M<T>(int a, A b)where T: class => 5;").Members[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M(int a, A b)where T: class { return 5; };").Members[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M(int a, A b)where T: class => 5;").Members[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M<T>(int a, A b) { return 5; };").Members[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M<T>(int a, A b) => 5;").Members[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M<T>(int a, A b)where T: class { return 5; }").Members[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void OperatorDeclarationServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string operator +(int a, A b) { return 5; };").Members[0];
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string operator +(int a, A b) => 5;").Members[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public virtual string operator +(int a, A b) { return 5; };").Members[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public virtual string operator +(int a, A b) => 5;").Members[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public string operator +(int a, A b) { return 5; };").Members[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] virtual string operator +(int a, A b) => 5;").Members[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string operator +(int a, A b) { return 5; }").Members[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void ConversionOperatorDeclarationServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (ConversionOperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual implicit operator T(A b) { return 5; };").Members[0];
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (ConversionOperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual implicit operator T(A b) => 5;").Members[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (ConversionOperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public virtual implicit operator T(A b) { return 5; };").Members[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (ConversionOperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public virtual implicit operator T(A b) => 5;").Members[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (ConversionOperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public implicit operator T(A b) { return 5; };").Members[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (ConversionOperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] virtual implicit operator T(A b) => 5;").Members[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (ConversionOperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public operator T(A b) { return 5; };").Members[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (ConversionOperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] virtual operator T(A b) => 5;").Members[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (ConversionOperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual implicit operator T(A b) { return 5; }").Members[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void ConstructorDeclarationServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation]public A(B b) : this(b) { }; }").Members[0]).Members[0];
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { public A(B b) : this(b) { }; }").Members[0]).Members[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation] A(B b) : this(b) { }; }").Members[0]).Members[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation]public A(B b) { }; }").Members[0]).Members[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation]public A(B b) : this(b) { } }").Members[0]).Members[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void ConstructorInitializerServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation]public A(B b) : this(b) { }; }").Members[0]).Members[0]).Initializer;
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, node.GetType().Name.Replace("Syntax", ""));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = ((ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation]public A(B b) : base(b) { }; }").Members[0]).Members[0]).Initializer;
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), (int)SyntaxKind.ThisConstructorInitializer);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, node.GetType().Name.Replace("Syntax", ""));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void DestructorDeclarationServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (DestructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation] internal ~A(){ }; }").Members[0]).Members[0];
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (DestructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation] ~A(){ }; }").Members[0]).Members[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (DestructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation] internal ~A(){ } }").Members[0]).Members[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void PropertyDeclarationServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M { get{return 5;} set{this.a = 7} } = 3;").Members[0];
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public virtual string C.M { get{return 5;} set{this.a = 7} } = 3;").Members[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] virtual string C.M { get{return 5;} set{this.a = 7} } = 3;").Members[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string M { get{return 5;} set{this.a = 7} } = 3;").Members[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M { get; set; }").Members[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M { get{return 5;} set{this.a = 7} } => 3;").Members[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public virtual string C.M { get{return 5;} set{this.a = 7} } => 3;").Members[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] virtual string C.M { get{return 5;} set{this.a = 7} } => 3;").Members[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string M { get{return 5;} set{this.a = 7} } => 3;").Members[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M {get; set;};").Members[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void ArrowExpressionClauseServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M { get{return 5;} set{this.a = 7} } => 3;").Members[0]).ExpressionBody;
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void EventDeclarationServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A C.M { add; remove; }").Members[0];
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public virtual event A C.M { add; remove; }").Members[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] virtual event A C.M { add; remove; }").Members[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A M { add; remove; }").Members[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void IndexerDeclarationServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A C.this[string key] { get; set; } => 5;").Members[0];
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public virtual A C.this[string key] { get; set; } => 5;").Members[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] virtual A C.this[string key] { get; set; } => 5;").Members[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A this[string key] { get; set; } => 5;").Members[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A C.this[string key] { get; set; };").Members[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A C.this[string key] { get; set; }").Members[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void AccessorListServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A C.this[string key] { get; set; } => 5;").Members[0]).AccessorList;
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void AccessorDeclarationServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A C.this[string key] { [Serializable] private get{}; set; }").Members[0]).AccessorList.Accessors[0];
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), (int)SyntaxKind.UnknownAccessorDeclaration);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, node.GetType().Name.Replace("Syntax", ""));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = ((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A C.this[string key] { private get{}; set; }").Members[0]).AccessorList.Accessors[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), (int)SyntaxKind.UnknownAccessorDeclaration);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, node.GetType().Name.Replace("Syntax", ""));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = ((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A C.this[string key] { [Serializable] get{}; set; }").Members[0]).AccessorList.Accessors[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), (int)SyntaxKind.UnknownAccessorDeclaration);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, node.GetType().Name.Replace("Syntax", ""));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = ((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A C.this[string key] { [Serializable] private get; set; }").Members[0]).AccessorList.Accessors[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), (int)SyntaxKind.UnknownAccessorDeclaration);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, node.GetType().Name.Replace("Syntax", ""));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = ((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A C.this[string key] { [Serializable] private get{} set; }").Members[0]).AccessorList.Accessors[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), (int)SyntaxKind.UnknownAccessorDeclaration);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, node.GetType().Name.Replace("Syntax", ""));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = ((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A C.this[string key] { [Serializable] private set{}; get; }").Members[0]).AccessorList.Accessors[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), (int)SyntaxKind.UnknownAccessorDeclaration);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, node.GetType().Name.Replace("Syntax", ""));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = ((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A C.this[string key] { private set{}; get; }").Members[0]).AccessorList.Accessors[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), (int)SyntaxKind.UnknownAccessorDeclaration);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, node.GetType().Name.Replace("Syntax", ""));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = ((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A C.this[string key] { [Serializable] set{}; get; }").Members[0]).AccessorList.Accessors[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), (int)SyntaxKind.UnknownAccessorDeclaration);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, node.GetType().Name.Replace("Syntax", ""));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = ((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A C.this[string key] { [Serializable] private set; get; }").Members[0]).AccessorList.Accessors[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), (int)SyntaxKind.UnknownAccessorDeclaration);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, node.GetType().Name.Replace("Syntax", ""));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = ((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A C.this[string key] { [Serializable] private set{} get; }").Members[0]).AccessorList.Accessors[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), (int)SyntaxKind.UnknownAccessorDeclaration);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, node.GetType().Name.Replace("Syntax", ""));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = ((EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A C.M { [Serializable] private add{}; remove; }").Members[0]).AccessorList.Accessors[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), (int)SyntaxKind.UnknownAccessorDeclaration);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, node.GetType().Name.Replace("Syntax", ""));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = ((EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A C.M { private add{}; remove; }").Members[0]).AccessorList.Accessors[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), (int)SyntaxKind.UnknownAccessorDeclaration);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, node.GetType().Name.Replace("Syntax", ""));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = ((EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A C.M { [Serializable] add{}; remove; }").Members[0]).AccessorList.Accessors[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), (int)SyntaxKind.UnknownAccessorDeclaration);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, node.GetType().Name.Replace("Syntax", ""));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = ((EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A C.M { [Serializable] private add; remove; }").Members[0]).AccessorList.Accessors[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), (int)SyntaxKind.UnknownAccessorDeclaration);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, node.GetType().Name.Replace("Syntax", ""));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = ((EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A C.M { [Serializable] private add{} remove; }").Members[0]).AccessorList.Accessors[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), (int)SyntaxKind.UnknownAccessorDeclaration);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, node.GetType().Name.Replace("Syntax", ""));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = ((EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A C.M { [Serializable] private remove{}; add; }").Members[0]).AccessorList.Accessors[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), (int)SyntaxKind.UnknownAccessorDeclaration);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, node.GetType().Name.Replace("Syntax", ""));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
            node = ((EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A C.M { private remove{}; add; }").Members[0]).AccessorList.Accessors[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), (int)SyntaxKind.UnknownAccessorDeclaration);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, node.GetType().Name.Replace("Syntax", ""));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = ((EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A C.M { [Serializable] remove{}; add; }").Members[0]).AccessorList.Accessors[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), (int)SyntaxKind.UnknownAccessorDeclaration);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, node.GetType().Name.Replace("Syntax", ""));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = ((EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A C.M { [Serializable] private remove; add; }").Members[0]).AccessorList.Accessors[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), (int)SyntaxKind.UnknownAccessorDeclaration);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, node.GetType().Name.Replace("Syntax", ""));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = ((EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A C.M { [Serializable] private remove{} add; }").Members[0]).AccessorList.Accessors[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), (int)SyntaxKind.UnknownAccessorDeclaration);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, node.GetType().Name.Replace("Syntax", ""));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = ((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A C.this[string key] { [Serializable] private fg{}; get; }").Members[0]).AccessorList.Accessors[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), (int)SyntaxKind.UnknownAccessorDeclaration);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, node.GetType().Name.Replace("Syntax", ""));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = ((PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public virtual int A { private set{}; get; }").Members[0]).AccessorList.Accessors[0];
            node = SyntaxFactory.AccessorDeclaration(SyntaxKind.UnknownAccessorDeclaration, node.AttributeLists, node.Modifiers, SyntaxFactory.Identifier("fg"), node.Body, node.ExpressionBody, node.SemicolonToken);
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), (int)SyntaxKind.UnknownAccessorDeclaration);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, node.GetType().Name.Replace("Syntax", ""));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = ((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A C.this[string key] { [Serializable] fg{}; get; }").Members[0]).AccessorList.Accessors[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), (int)SyntaxKind.UnknownAccessorDeclaration);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, node.GetType().Name.Replace("Syntax", ""));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = ((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A C.this[string key] { [Serializable] private fg; get; }").Members[0]).AccessorList.Accessors[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), (int)SyntaxKind.UnknownAccessorDeclaration);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, node.GetType().Name.Replace("Syntax", ""));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = ((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A C.this[string key] { [Serializable] private fg{} get; }").Members[0]).AccessorList.Accessors[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), (int)SyntaxKind.UnknownAccessorDeclaration);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, node.GetType().Name.Replace("Syntax", ""));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void ParameterListServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int M([Serializable] ref int a = 0, A b){}").Members[0]).ParameterList;
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void BracketedParameterListServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int this[[Serializable] ref int a = 0, A b]{get;set;}").Members[0]).ParameterList;
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void ParameterServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int M([Serializable] ref int a = 0, A b){}").Members[0]).ParameterList.Parameters[0];
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = ((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int M(ref int a = 0, A b){}").Members[0]).ParameterList.Parameters[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = ((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int M([Serializable] int a = 0, A b){}").Members[0]).ParameterList.Parameters[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = ((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int M([Serializable] ref int a, A b){}").Members[0]).ParameterList.Parameters[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void SkippedTokensTriviaServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.SkippedTokensTrivia(((IncompleteMemberSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual a").Members[0]).Modifiers);
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void DocumentationCommentTriviaServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<foo />").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure();
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), (int)SyntaxKind.MultiLineDocumentationCommentTrivia);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, node.GetType().Name.Replace("Syntax", ""));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree(@"/// <summary>" + Environment.NewLine +
                                                                                    "/// Method hook for implementing logic to execute after the <see cref=\"ChildrenCore(SyntaxNodeOrToken ?)\"/>." + Environment.NewLine +
                                                                                    "/// </summary>" + Environment.NewLine +
                                                                                    "/// <param name=\"node\">node of interest.</param>" + Environment.NewLine +
                                                                                    "/// <param name=\"result\">Mechanism to modify the result of <see cref=\"Children(SyntaxNodeOrToken?)\"/>.</param>")
                                                                                    .GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure();
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), (int)SyntaxKind.MultiLineDocumentationCommentTrivia);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, node.GetType().Name.Replace("Syntax", ""));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void EndIfDirectiveTriviaServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.EndIfDirectiveTrivia(true);
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void RegionDirectiveTriviaServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.RegionDirectiveTrivia(true);
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void EndRegionDirectiveTriviaServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.EndRegionDirectiveTrivia(true);
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void ErrorDirectiveTriviaServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.ErrorDirectiveTrivia(true);
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void WarningDirectiveTriviaServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.WarningDirectiveTrivia(true);
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void BadDirectiveTriviaServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.BadDirectiveTrivia(SyntaxFactory.Identifier("unknown"), true);
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void DefineDirectiveTriviaServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.DefineDirectiveTrivia(SyntaxFactory.Identifier("DEBUG"), true);
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void UndefDirectiveTriviaServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.UndefDirectiveTrivia(SyntaxFactory.Identifier("DEBUG"), true);
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void LineDirectiveTriviaServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.LineDirectiveTrivia(SyntaxFactory.Literal("200", 200), SyntaxFactory.Literal("\"Special\""), true);
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void PragmaWarningDirectiveTriviaServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var separatedSyntaxList = SyntaxFactory.SeparatedList(new ExpressionSyntax[] { SyntaxFactory.IdentifierName("warning-list"), SyntaxFactory.IdentifierName("CS3021") });
            var node = SyntaxFactory.PragmaWarningDirectiveTrivia(SyntaxFactory.Token(SyntaxKind.DisableKeyword), separatedSyntaxList, true);
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void PragmaChecksumDirectiveTriviaServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.PragmaChecksumDirectiveTrivia(SyntaxFactory.Literal("\"file.cs\""), SyntaxFactory.Literal("\"{3673e4ca-6098-4ec1-890f-8fceb2a794a2}\""), SyntaxFactory.Literal("\"{012345678AB}\""), true);
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void ReferenceDirectiveTriviaServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.ReferenceDirectiveTrivia(SyntaxFactory.Literal("DEBUG"), true);
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void LoadDirectiveTriviaServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.LoadDirectiveTrivia(SyntaxFactory.Literal("DEBUG"), true);
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void ShebangDirectiveTriviaServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.ShebangDirectiveTrivia(true);
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void ElseDirectiveTriviaServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.ElseDirectiveTrivia(true, true);
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void IfDirectiveTriviaServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (IfDirectiveTriviaSyntax)SyntaxFactory.ParseSyntaxTree("#if DEBUG Console.WriteLine(\"Debug version\"); #endif").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure();
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void ElifDirectiveTriviaServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.ElifDirectiveTrivia(SyntaxFactory.IdentifierName("VC7"), true, true, true);
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void TypeCrefServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var text = "namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"int\"/> </summary>" + Environment.NewLine +
                       "    class A { } }";
            var namespaceNode = SyntaxFactory.ParseCompilationUnit(text).Members[0];
            var node = namespaceNode.DescendantNodes(descendIntoTrivia: true).OfType<TypeCrefSyntax>().Single();
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void QualifiedCrefServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var text = "namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"N.A\"/> </summary>" + Environment.NewLine +
                       "    class A { } }";
            var namespaceNode = SyntaxFactory.ParseCompilationUnit(text).Members[0];
            var node = namespaceNode.DescendantNodes(descendIntoTrivia: true).OfType<QualifiedCrefSyntax>().Single();
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void NameMemberCrefServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var text = "namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"N(int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }";
            var namespaceNode = SyntaxFactory.ParseCompilationUnit(text).Members[0];
            var node = namespaceNode.DescendantNodes(descendIntoTrivia: true).OfType<NameMemberCrefSyntax>().Single();
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            var text3 = "namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"N\"/> </summary>" + Environment.NewLine +
                       "    class A { } }";
            namespaceNode = SyntaxFactory.ParseCompilationUnit(text3).Members[0];
            node = namespaceNode.DescendantNodes(descendIntoTrivia: true).OfType<NameMemberCrefSyntax>().Single();
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void IndexerMemberCrefServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var text = "namespace N { " + Environment.NewLine +
                        "    /// <summary> <see cref=\"this[int]\"/> </summary>" + Environment.NewLine +
                        "    class A { } }";
            var namespaceNode = SyntaxFactory.ParseCompilationUnit(text).Members[0];
            var node = namespaceNode.DescendantNodes(descendIntoTrivia: true).OfType<IndexerMemberCrefSyntax>().Single();
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            var text3 = "namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"this\"/> </summary>" + Environment.NewLine +
                       "    class A { } }";
            namespaceNode = SyntaxFactory.ParseCompilationUnit(text3).Members[0];
            node = namespaceNode.DescendantNodes(descendIntoTrivia: true).OfType<IndexerMemberCrefSyntax>().Single();
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void OperatorMemberCrefServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var text = "namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }";
            var namespaceNode = SyntaxFactory.ParseCompilationUnit(text).Members[0];
            var node = namespaceNode.DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single();
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            var text3 = "namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +\"/> </summary>" + Environment.NewLine +
                       "    class A { } }";
            namespaceNode = SyntaxFactory.ParseCompilationUnit(text3).Members[0];
            node = namespaceNode.DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single();
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void ConversionOperatorMemberCrefServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var text = "namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"implicit operator N(int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }";
            var namespaceNode = SyntaxFactory.ParseCompilationUnit(text).Members[0];
            var node = namespaceNode.DescendantNodes(descendIntoTrivia: true).OfType<ConversionOperatorMemberCrefSyntax>().Single();
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            text = "namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"explicit operator N\"/> </summary>" + Environment.NewLine +
                       "    class A { } }";
            namespaceNode = SyntaxFactory.ParseCompilationUnit(text).Members[0];
            node = namespaceNode.DescendantNodes(descendIntoTrivia: true).OfType<ConversionOperatorMemberCrefSyntax>().Single();
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void CrefParameterListServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var text = "namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(int, string)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }";
            var namespaceNode = SyntaxFactory.ParseCompilationUnit(text).Members[0];
            var node = namespaceNode.DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void CrefBracketedParameterListServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var text = "namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"this[int, string]\"/> </summary>" + Environment.NewLine +
                       "    class A { } }";
            var namespaceNode = SyntaxFactory.ParseCompilationUnit(text).Members[0];
            var node = namespaceNode.DescendantNodes(descendIntoTrivia: true).OfType<IndexerMemberCrefSyntax>().Single().Parameters;
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void CrefParameterServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var text = "namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref int, out string)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }";
            var namespaceNode = SyntaxFactory.ParseCompilationUnit(text).Members[0];
            var node = namespaceNode.DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
            text = "namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(int, string)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }";
            namespaceNode = SyntaxFactory.ParseCompilationUnit(text).Members[0];
            node = namespaceNode.DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void XmlElementServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (XmlElementSyntax)((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.Single();
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void XmlElementStartTagServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag;
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void XmlElementEndTagServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().EndTag;
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void XmlEmptyElementServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<foo id=\"3\"/>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlEmptyElementSyntax>().Single();
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<foo/>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlEmptyElementSyntax>().Single();
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void XmlNameServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<d:foo/>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlEmptyElementSyntax>().Single().Name;
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<foo/>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlEmptyElementSyntax>().Single().Name;
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void XmlPrefixServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<d:foo/>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlEmptyElementSyntax>().Single().Name.Prefix;
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void XmlTextAttributeServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (XmlTextAttributeSyntax)((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<message id=\"5 r\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag.Attributes[0];
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void XmlCrefAttributeServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (XmlCrefAttributeSyntax)((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<see cref=\"M\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag.Attributes[0];
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void XmlNameAttributeServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (XmlNameAttributeSyntax)((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<param name=\"M\"/>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlEmptyElementSyntax>().Single().Attributes[0];
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void XmlTextServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (XmlTextSyntax)((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<foo>bar</foo>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().Content[0];
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void XmlCDataSectionServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<![CDATA[this is a test of &some; cdata]]>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlCDataSectionSyntax>().Single();
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void XmlProcessingInstructionServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<?proc-inst this is a test of &some; processinginstruction?>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlProcessingInstructionSyntax>().Single();
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void XmlCommentServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<!--this is a test of &some; comment-->").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlCommentSyntax>().Single();
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void CompilationUnitServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.ParseCompilationUnit("extern alias b; using static d; [assembly: XAttribute] namespace c{};");
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = SyntaxFactory.ParseCompilationUnit("using static d; [assembly: XAttribute] namespace c{};");
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = SyntaxFactory.ParseCompilationUnit("extern alias b; [assembly: XAttribute] namespace c{};");
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = SyntaxFactory.ParseCompilationUnit("extern alias b; using static d; [assembly: XAttribute];");
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void ExternAliasDirectiveServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.ParseCompilationUnit("extern alias b; using static d; [assembly: XAttribute] namespace c{};").Externs[0];
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void UsingDirectiveServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.ParseCompilationUnit("extern alias b; using static a = d; [assembly: XAttribute] namespace c{};").Usings[0];
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = SyntaxFactory.ParseCompilationUnit("extern alias b; using a = d; [assembly: XAttribute] namespace c{};").Usings[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = SyntaxFactory.ParseCompilationUnit("extern alias b; using static d; [assembly: XAttribute] namespace c{};").Usings[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void NamespaceDeclarationServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (NamespaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("namespace a{extern alias b; using static d; namespace c{int f = 3;};};").Members[0];
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (NamespaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("namespace a{using static d; namespace c{int f = 3;};};").Members[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (NamespaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("namespace a{extern alias b; namespace c{int f = 3;};};").Members[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (NamespaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("namespace a{extern alias b; using static d;};").Members[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (NamespaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("namespace a{extern alias b; using static d; namespace c{int f = 3;};}").Members[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void AttributeListServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(\"X\"), YAttribute(Y: 3)]").AttributeLists[0];
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = ((FieldDeclarationSyntax)((NamespaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("namespace a {[XAttribute(\"X\"), YAttribute(Y: 3)]int f;}").Members[0]).Members[0]).AttributeLists[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void AttributeTargetSpecifierServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(\"X\"), YAttribute(Y: 3)]").AttributeLists[0].Target;
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void AttributeServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(\"X\")]").AttributeLists[0].Attributes[0];
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = SyntaxFactory.ParseCompilationUnit("[module: XAttribute]").AttributeLists[0].Attributes[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void AttributeArgumentListServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(\"X\", Y: 3)]").AttributeLists[0].Attributes[0].ArgumentList;
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = SyntaxFactory.ParseCompilationUnit("[module: XAttribute()]").AttributeLists[0].Attributes[0].ArgumentList;
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void AttributeArgumentServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(Y: 3)]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0];
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(Y = 3)]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(3)]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void WhenClauseServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = ((CasePatternSwitchLabelSyntax)((SwitchStatementSyntax)SyntaxFactory.ParseStatement("switch(obj){ case 'a' when obj.Lenght > 0: }")).Sections[0].Labels[0]).WhenClause;
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void TupleTypeServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (TupleTypeSyntax)SyntaxFactory.ParseTypeName("(string, int)");
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void TupleExpressionServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (TupleExpressionSyntax)SyntaxFactory.ParseExpression("(string, int)");
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void TupleElementServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var type = SyntaxFactory.ParseTypeName("(string, int)");
            var node = SyntaxFactory.TupleElement(type, SyntaxFactory.Identifier("a"));
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = SyntaxFactory.TupleElement(type);
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void ThrowExpressionServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (ThrowExpressionSyntax)SyntaxFactory.ParseExpression("throw e");
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void SingleVariableDesignationServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.SingleVariableDesignation(SyntaxFactory.Identifier("a"));
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void DiscardDesignationServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.DiscardDesignation(SyntaxFactory.Token(SyntaxKind.UnderscoreToken));
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void ParenthesizedVariableDesignationServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
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

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = SyntaxFactory.ParenthesizedVariableDesignation(SyntaxFactory.Token(SyntaxKind.OpenParenToken),
                SyntaxFactory.SeparatedList(new VariableDesignationSyntax[0]),
                SyntaxFactory.Token(SyntaxKind.CloseParenToken));
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void RefExpressionServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.RefExpression(SyntaxFactory.Token(SyntaxKind.RefKeyword), SyntaxFactory.ParseExpression("s + d"));
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void CasePatternSwitchLabelServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (CasePatternSwitchLabelSyntax)((SwitchStatementSyntax)SyntaxFactory.ParseStatement("switch(obj){ case 'a' when obj.Lenght > 0: }")).Sections[0].Labels[0];
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = SyntaxFactory.CasePatternSwitchLabel(node.Keyword, node.Pattern, null, node.ColonToken);
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void IsPatternExpressionServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (IsPatternExpressionSyntax)SyntaxFactory.ParseExpression("obj is A a");
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void DeclarationExpressionServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (DeclarationExpressionSyntax)((TupleExpressionSyntax)SyntaxFactory.ParseExpression("(int a, int b)")).Arguments[0].Expression;
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void ForEachVariableStatementServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (ForEachVariableStatementSyntax)SyntaxFactory.ParseStatement("foreach(var (a,b) in x){}");
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void DeclarationPatternServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (DeclarationPatternSyntax)((CasePatternSwitchLabelSyntax)((SwitchStatementSyntax)SyntaxFactory.ParseStatement("switch(obj){ case Shape s: }")).Sections[0].Labels[0]).Pattern;
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void ConstantPatternServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (ConstantPatternSyntax)((CasePatternSwitchLabelSyntax)((SwitchStatementSyntax)SyntaxFactory.ParseStatement("switch(obj){ case 'a' when obj.Lenght > 0: }")).Sections[0].Labels[0]).Pattern;
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }

        [TestMethod]
        public void LocalFunctionStatementServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = (LocalFunctionStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit(@"
            void m()
            {
                const int local<T>() where T: I => 0;
            }").Members[0]).Body.Statements[0];
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (LocalFunctionStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit(@"
            void m()
            {
                const int local<T>() where T: I { return 0;}
            }").Members[0]).Body.Statements[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (LocalFunctionStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit(@"
            void m()
            {
                int local<T>() where T: I => 0;
            }").Members[0]).Body.Statements[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (LocalFunctionStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit(@"
            void m()
            {
                int local<T>() where T: I { return 0;}
            }").Members[0]).Body.Statements[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (LocalFunctionStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit(@"
            void m()
            {
                const int local() where T: I => 0;
            }").Members[0]).Body.Statements[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (LocalFunctionStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit(@"
            void m()
            {
                const int local() where T: I { return 0;}
            }").Members[0]).Body.Statements[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = (LocalFunctionStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit(@"
            void m()
            {
                const int local<T>() where T: I => 0
            }").Members[0]).Body.Statements[0];
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
        }



        [TestMethod]
        public void RefTypeServiceProvider_RoslynMLAndGumtreefyTypeBasedLabels_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var selector = new CDF.CSharp.RoslynML.RoslynMLPruneSelector();

            var node = SyntaxFactory.RefType(SyntaxFactory.Token(SyntaxKind.RefKeyword), SyntaxFactory.Token(SyntaxKind.ReadOnlyKeyword), SyntaxFactory.ParseTypeName("var"));
            var xElement = converter.Visit(node);

            var xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            node = SyntaxFactory.RefType(SyntaxFactory.Token(SyntaxKind.RefKeyword), SyntaxFactory.ParseTypeName("var"));
            xElement = converter.Visit(node);

            xGumTreeElement = converter.Gumtreefy(xElement, true);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));

            xGumTreeElement = converter.Gumtreefy(xElement, false);
            Assert.AreEqual(XmlConvert.ToInt32(xGumTreeElement.Attribute("type").Value), node.RawKind);
            Assert.AreEqual(xGumTreeElement.Attribute("typeLabel").Value, Enum.GetName(typeof(SyntaxKind), node.Kind()));
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
                               where nameParts.Length == 3 && nameParts[1] == "RoslynMLAndGumtreefyTypeBasedLabels" && nameParts[2] == "OK"
                               select nameParts[0].Replace("ServiceProvider", "Syntax")).ToList();

            var a = cases.Select(info => info.Type.name).Distinct().Except(testedCases).ToArray();
            var b = testedCases.Except(cases.Select(info => info.Type.name).Distinct()).ToArray();

            Assert.AreEqual(a.Count(), 0);
            Assert.AreEqual(b.Count(), 0);
        }

        [TestMethod]
        public void RoslynMLAndGumtreefyTypeBasedLabelsPlusTrivia_RoslynMLAndGumtreefyTypeBasedLabelsPlusNoTrivia_OK()
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
            Assert.AreEqual(commentElements[0].Parent.Name.LocalName, "List_of_Statement");
            Assert.AreEqual(commentElements[0].Value, "//1111; 2222  ");
            Assert.AreEqual(commentElements[1].Parent.Name.LocalName, "SeparatedList_of_VariableDeclarator");
            Assert.AreEqual(commentElements[1].Value, "/*1111; 2222*/");

            var n1 = new CDF.CSharp.RoslynML.RoslynML().GetTree(content, path: false, includeTrivia: false);
            documentationElements = n1.DescendantNodesAndSelf().OfType<XElement>().Where(d1 => d1.Name.LocalName == "DocumentationCommentTrivia").ToArray();
            Assert.AreEqual(documentationElements.Count(), 0);
            commentElements = n1.DescendantNodesAndSelf().OfType<XElement>().Where(d1 => d1.Name.LocalName == "CommentTrivia").ToArray();
            Assert.AreEqual(commentElements.Count(), 0);
        }
    }
}
