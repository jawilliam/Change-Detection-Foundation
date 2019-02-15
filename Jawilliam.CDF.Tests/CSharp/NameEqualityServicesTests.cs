using System;
using System.Linq;
using Jawilliam.CDF.CSharp;
using Jawilliam.CDF.CSharp.Flad;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jawilliam.CDF.Tests.CSharp
{
    [TestClass]
    public class NameEqualityServicesTests
    {
        [TestMethod]
        public void AttributeArgumentServiceProvider_NameExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(\"X\")]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0];
            var b = SyntaxFactory.ParseCompilationUnit("[module: YAttribute(\"Y\")]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0];
            Assert.IsFalse(flad.LanguageServiceProvider.AttributeArgumentServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.AttributeArgumentServiceProvider.NameExactlyEqual(a, null));
            Assert.IsFalse(flad.LanguageServiceProvider.AttributeArgumentServiceProvider.NameExactlyEqual(null, null));
            Assert.IsFalse(flad.LanguageServiceProvider.AttributeArgumentServiceProvider.NameExactlyEqual(a, b));

            a = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(x = \"X\")]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0];
            b = SyntaxFactory.ParseCompilationUnit("[module: YAttribute(\"Y\")]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0];
            Assert.IsFalse(flad.LanguageServiceProvider.AttributeArgumentServiceProvider.NameExactlyEqual(a, b));

            a = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(\"X\")]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0];
            b = SyntaxFactory.ParseCompilationUnit("[module: YAttribute(x = \"Y\")]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0];
            Assert.IsFalse(flad.LanguageServiceProvider.AttributeArgumentServiceProvider.NameExactlyEqual(a, b));

            a = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(x = \"X\")]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0];
            b = SyntaxFactory.ParseCompilationUnit("[module: YAttribute(y = \"Y\")]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0];
            Assert.IsFalse(flad.LanguageServiceProvider.AttributeArgumentServiceProvider.NameExactlyEqual(a, b));

            a = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(x = \"X\")]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0];
            b = SyntaxFactory.ParseCompilationUnit("[module: YAttribute(x = \"Y\")]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0];
            Assert.IsTrue(flad.LanguageServiceProvider.AttributeArgumentServiceProvider.NameExactlyEqual(a, b));

            a = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(x: \"X\")]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0];
            b = SyntaxFactory.ParseCompilationUnit("[module: YAttribute(\"Y\")]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0];
            Assert.IsFalse(flad.LanguageServiceProvider.AttributeArgumentServiceProvider.NameExactlyEqual(a, b));

            a = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(\"X\")]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0];
            b = SyntaxFactory.ParseCompilationUnit("[module: YAttribute(x: \"Y\")]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0];
            Assert.IsFalse(flad.LanguageServiceProvider.AttributeArgumentServiceProvider.NameExactlyEqual(a, b));

            a = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(x: \"X\")]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0];
            b = SyntaxFactory.ParseCompilationUnit("[module: YAttribute(y: \"Y\")]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0];
            Assert.IsFalse(flad.LanguageServiceProvider.AttributeArgumentServiceProvider.NameExactlyEqual(a, b));

            a = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(x: \"X\")]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0];
            b = SyntaxFactory.ParseCompilationUnit("[module: YAttribute(x: \"Y\")]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0];
            Assert.IsTrue(flad.LanguageServiceProvider.AttributeArgumentServiceProvider.NameExactlyEqual(a, b));

            a = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(x= \"X\")]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0];
            b = SyntaxFactory.ParseCompilationUnit("[module: YAttribute(y: \"Y\")]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0];
            Assert.IsFalse(flad.LanguageServiceProvider.AttributeArgumentServiceProvider.NameExactlyEqual(a, b));

            a = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(x: \"X\")]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0];
            b = SyntaxFactory.ParseCompilationUnit("[module: YAttribute(y= \"Y\")]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0];
            Assert.IsFalse(flad.LanguageServiceProvider.AttributeArgumentServiceProvider.NameExactlyEqual(a, b));

            a = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(x: \"X\")]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0];
            b = SyntaxFactory.ParseCompilationUnit("[module: YAttribute(x= \"Y\")]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0];
            Assert.IsTrue(flad.LanguageServiceProvider.AttributeArgumentServiceProvider.NameExactlyEqual(a, b));

            a = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(x= \"X\")]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0];
            b = SyntaxFactory.ParseCompilationUnit("[module: YAttribute(x: \"Y\")]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0];
            Assert.IsTrue(flad.LanguageServiceProvider.AttributeArgumentServiceProvider.NameExactlyEqual(a, b));
        }

        [TestMethod]
        public void NameEqualsServiceProvider_NameExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(\"X\")]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0].NameEquals;
            var b = SyntaxFactory.ParseCompilationUnit("[module: YAttribute(\"Y\")]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0].NameEquals;
            Assert.IsFalse(flad.LanguageServiceProvider.NameEqualsServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.NameEqualsServiceProvider.NameExactlyEqual(a, (NameEqualsSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.NameEqualsServiceProvider.NameExactlyEqual(null, (NameEqualsSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.NameEqualsServiceProvider.NameExactlyEqual(a, b));

            a = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(x = \"X\")]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0].NameEquals;
            b = SyntaxFactory.ParseCompilationUnit("[module: YAttribute(y = \"Y\")]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0].NameEquals;
            Assert.IsFalse(flad.LanguageServiceProvider.NameEqualsServiceProvider.NameExactlyEqual(a, b));

            a = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(x = \"X\")]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0].NameEquals;
            b = SyntaxFactory.ParseCompilationUnit("[module: YAttribute(x = \"Y\")]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0].NameEquals;
            Assert.IsTrue(flad.LanguageServiceProvider.NameEqualsServiceProvider.NameExactlyEqual(a, b));
        }

        [TestMethod]
        public void TypeParameterServiceProvider_NameExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<B> {}").Members[0]).TypeParameterList.Parameters[0];
            var b = ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<C> {}").Members[0]).TypeParameterList.Parameters[0];
            Assert.IsFalse(flad.LanguageServiceProvider.TypeParameterServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.TypeParameterServiceProvider.NameExactlyEqual(a, null));
            Assert.IsFalse(flad.LanguageServiceProvider.TypeParameterServiceProvider.NameExactlyEqual(null, null));
            Assert.IsFalse(flad.LanguageServiceProvider.TypeParameterServiceProvider.NameExactlyEqual(a, b));

            a = ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<B> {}").Members[0]).TypeParameterList.Parameters[0];
            b = ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class b<B> {}").Members[0]).TypeParameterList.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.TypeParameterServiceProvider.NameExactlyEqual(a, b));
        }

        [TestMethod]
        public void TypeParameterConstraintClauseServiceProvider_NameExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<T> : byte where T : new(), class, struct, A{};").Members[0]).ConstraintClauses[0];
            var b = ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<T> : byte where K : new(), class, struct, A{};").Members[0]).ConstraintClauses[0];
            Assert.IsFalse(flad.LanguageServiceProvider.TypeParameterConstraintClauseServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.TypeParameterConstraintClauseServiceProvider.NameExactlyEqual(a, null));
            Assert.IsFalse(flad.LanguageServiceProvider.TypeParameterConstraintClauseServiceProvider.NameExactlyEqual(null, null));
            Assert.IsFalse(flad.LanguageServiceProvider.TypeParameterConstraintClauseServiceProvider.NameExactlyEqual(a, b));

            a = ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<T> : byte where T : new(), class, struct, A{};").Members[0]).ConstraintClauses[0];
            b = ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<T> : byte where T : new(), class, struct, A{};").Members[0]).ConstraintClauses[0];
            Assert.IsTrue(flad.LanguageServiceProvider.TypeParameterConstraintClauseServiceProvider.NameExactlyEqual(a, b));
        }

        [TestMethod]
        public void ExplicitInterfaceSpecifierServiceProvider_NameExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = ((EventDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a {event B IA.a1{add; remove;}}").Members[0]).Members[0]).ExplicitInterfaceSpecifier;
            var b = ((EventDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a {event B IB.a1{add; remove;}}").Members[0]).Members[0]).ExplicitInterfaceSpecifier;
            Assert.IsFalse(flad.LanguageServiceProvider.ExplicitInterfaceSpecifierServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.ExplicitInterfaceSpecifierServiceProvider.NameExactlyEqual(a, null));
            Assert.IsFalse(flad.LanguageServiceProvider.ExplicitInterfaceSpecifierServiceProvider.NameExactlyEqual(null, null));
            Assert.IsFalse(flad.LanguageServiceProvider.ExplicitInterfaceSpecifierServiceProvider.NameExactlyEqual(a, b));

            a = ((EventDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a {event B IA.a1{add; remove;}}").Members[0]).Members[0]).ExplicitInterfaceSpecifier;
            b = ((EventDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a {event B IA.a1{add; remove;}}").Members[0]).Members[0]).ExplicitInterfaceSpecifier;
            Assert.IsTrue(flad.LanguageServiceProvider.ExplicitInterfaceSpecifierServiceProvider.NameExactlyEqual(a, b));
        }

        [TestMethod]
        public void ParameterServiceProvider_NameExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = ((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int M([Serializable] ref int a = 0, A b){}").Members[0]).ParameterList.Parameters[0];
            var b = ((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int M([Serializable] ref int b = 0, A b){}").Members[0]).ParameterList.Parameters[0];
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterServiceProvider.NameExactlyEqual(a, null));
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterServiceProvider.NameExactlyEqual(null, null));
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterServiceProvider.NameExactlyEqual(a, b));

            a = ((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int M([Serializable] ref int a = 0, A b){}").Members[0]).ParameterList.Parameters[0];
            b = ((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int M([Serializable] ref int a = 0, A c){}").Members[0]).ParameterList.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.ParameterServiceProvider.NameExactlyEqual(a, b));
        }

        [TestMethod]
        public void XmlElementStartTagServiceProvider_NameExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag;
            var b = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<Message id=\"5\" oid=\"3\">Hello World</Message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag;
            Assert.IsFalse(flad.LanguageServiceProvider.XmlElementStartTagServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.XmlElementStartTagServiceProvider.NameExactlyEqual(a, null));
            Assert.IsFalse(flad.LanguageServiceProvider.XmlElementStartTagServiceProvider.NameExactlyEqual(null, null));
            Assert.IsFalse(flad.LanguageServiceProvider.XmlElementStartTagServiceProvider.NameExactlyEqual(a, b));

            a = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag;
            b = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag;
            Assert.IsTrue(flad.LanguageServiceProvider.XmlElementStartTagServiceProvider.NameExactlyEqual(a, b));

            a = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<i:message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag;
            b = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<i:Message id=\"5\" oid=\"3\">Hello World</Message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag;
            Assert.IsFalse(flad.LanguageServiceProvider.XmlElementStartTagServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.XmlElementStartTagServiceProvider.NameExactlyEqual(a, null));
            Assert.IsFalse(flad.LanguageServiceProvider.XmlElementStartTagServiceProvider.NameExactlyEqual(null, null));
            Assert.IsFalse(flad.LanguageServiceProvider.XmlElementStartTagServiceProvider.NameExactlyEqual(a, b));

            a = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<i:message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag;
            b = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<j:message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag;
            Assert.IsFalse(flad.LanguageServiceProvider.XmlElementStartTagServiceProvider.NameExactlyEqual(a, b));

            a = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<i:message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag;
            b = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<i:message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag;
            Assert.IsTrue(flad.LanguageServiceProvider.XmlElementStartTagServiceProvider.NameExactlyEqual(a, b));
        }

        [TestMethod]
        public void XmlElementEndTagServiceProvider_NameExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().EndTag;
            var b = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<Message id=\"5\" oid=\"3\">Hello World</Message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().EndTag;
            Assert.IsFalse(flad.LanguageServiceProvider.XmlElementEndTagServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.XmlElementEndTagServiceProvider.NameExactlyEqual(a, null));
            Assert.IsFalse(flad.LanguageServiceProvider.XmlElementEndTagServiceProvider.NameExactlyEqual(null, null));
            Assert.IsFalse(flad.LanguageServiceProvider.XmlElementEndTagServiceProvider.NameExactlyEqual(a, b));

            a = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().EndTag;
            b = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().EndTag;
            Assert.IsTrue(flad.LanguageServiceProvider.XmlElementEndTagServiceProvider.NameExactlyEqual(a, b));

            a = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<i:message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().EndTag;
            b = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<i:Message id=\"5\" oid=\"3\">Hello World</Message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().EndTag;
            Assert.IsFalse(flad.LanguageServiceProvider.XmlElementEndTagServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.XmlElementEndTagServiceProvider.NameExactlyEqual(a, null));
            Assert.IsFalse(flad.LanguageServiceProvider.XmlElementEndTagServiceProvider.NameExactlyEqual(null, null));
            Assert.IsFalse(flad.LanguageServiceProvider.XmlElementEndTagServiceProvider.NameExactlyEqual(a, b));

            a = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<i:message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().EndTag;
            b = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<j:message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().EndTag;
            Assert.IsTrue(flad.LanguageServiceProvider.XmlElementEndTagServiceProvider.NameExactlyEqual(a, b));

            a = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<i:message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().EndTag;
            b = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<i:message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().EndTag;
            Assert.IsTrue(flad.LanguageServiceProvider.XmlElementEndTagServiceProvider.NameExactlyEqual(a, b));
        }

        [TestMethod]
        public void XmlNameServiceProvider_NameExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag.Name;
            var b = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<Message id=\"5\" oid=\"3\">Hello World</Message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag.Name;
            Assert.IsFalse(flad.LanguageServiceProvider.XmlNameServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.XmlNameServiceProvider.NameExactlyEqual(a, null));
            Assert.IsFalse(flad.LanguageServiceProvider.XmlNameServiceProvider.NameExactlyEqual(null, null));
            Assert.IsFalse(flad.LanguageServiceProvider.XmlNameServiceProvider.NameExactlyEqual(a, b));

            a = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag.Name;
            b = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag.Name;
            Assert.IsTrue(flad.LanguageServiceProvider.XmlNameServiceProvider.NameExactlyEqual(a, b));

            a = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<i:message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag.Name;
            b = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<i:Message id=\"5\" oid=\"3\">Hello World</Message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag.Name;
            Assert.IsFalse(flad.LanguageServiceProvider.XmlNameServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.XmlNameServiceProvider.NameExactlyEqual(a, null));
            Assert.IsFalse(flad.LanguageServiceProvider.XmlNameServiceProvider.NameExactlyEqual(null, null));
            Assert.IsFalse(flad.LanguageServiceProvider.XmlNameServiceProvider.NameExactlyEqual(a, b));

            a = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<i:message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag.Name;
            b = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<j:message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag.Name;
            Assert.IsFalse(flad.LanguageServiceProvider.XmlNameServiceProvider.NameExactlyEqual(a, b));

            a = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<i:message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag.Name;
            b = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<i:message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag.Name;
            Assert.IsTrue(flad.LanguageServiceProvider.XmlNameServiceProvider.NameExactlyEqual(a, b));
        }

        [TestMethod]
        public void XmlPrefixServiceProvider_NameExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag.Name.Prefix;
            var b = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<Message id=\"5\" oid=\"3\">Hello World</Message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag.Name.Prefix;
            Assert.IsFalse(flad.LanguageServiceProvider.XmlPrefixServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.XmlPrefixServiceProvider.NameExactlyEqual(a, null));
            Assert.IsFalse(flad.LanguageServiceProvider.XmlPrefixServiceProvider.NameExactlyEqual(null, null));
            Assert.IsFalse(flad.LanguageServiceProvider.XmlPrefixServiceProvider.NameExactlyEqual(a, b));

            a = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag.Name.Prefix;
            b = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag.Name.Prefix;
            Assert.IsFalse(flad.LanguageServiceProvider.XmlPrefixServiceProvider.NameExactlyEqual(a, b));

            a = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<i:message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag.Name.Prefix;
            b = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<i:Message id=\"5\" oid=\"3\">Hello World</Message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag.Name.Prefix;
            Assert.IsFalse(flad.LanguageServiceProvider.XmlPrefixServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.XmlPrefixServiceProvider.NameExactlyEqual(a, null));
            Assert.IsFalse(flad.LanguageServiceProvider.XmlPrefixServiceProvider.NameExactlyEqual(null, null));
            Assert.IsTrue(flad.LanguageServiceProvider.XmlPrefixServiceProvider.NameExactlyEqual(a, b));

            a = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<i:message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag.Name.Prefix;
            b = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<j:message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag.Name.Prefix;
            Assert.IsFalse(flad.LanguageServiceProvider.XmlPrefixServiceProvider.NameExactlyEqual(a, b));

            a = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<i:message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag.Name.Prefix;
            b = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<i:message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag.Name.Prefix;
            Assert.IsTrue(flad.LanguageServiceProvider.XmlPrefixServiceProvider.NameExactlyEqual(a, b));
        }

        [TestMethod]
        public void TupleElementServiceProvider_NameExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = SyntaxFactory.TupleElement(SyntaxFactory.ParseTypeName("(string, int)"), SyntaxFactory.Identifier("a"));
            var b = SyntaxFactory.TupleElement(SyntaxFactory.ParseTypeName("(string, int)"), SyntaxFactory.Identifier("b"));
            Assert.IsFalse(flad.LanguageServiceProvider.TupleElementServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.TupleElementServiceProvider.NameExactlyEqual(a, null));
            Assert.IsFalse(flad.LanguageServiceProvider.TupleElementServiceProvider.NameExactlyEqual(null, null));
            Assert.IsFalse(flad.LanguageServiceProvider.TupleElementServiceProvider.NameExactlyEqual(a, b));

            a = SyntaxFactory.TupleElement(SyntaxFactory.ParseTypeName("(string, int)"));
            b = SyntaxFactory.TupleElement(SyntaxFactory.ParseTypeName("(string, int)"));
            Assert.IsFalse(flad.LanguageServiceProvider.TupleElementServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.TupleElementServiceProvider.NameExactlyEqual(a, null));
            Assert.IsFalse(flad.LanguageServiceProvider.TupleElementServiceProvider.NameExactlyEqual(null, null));
            Assert.IsFalse(flad.LanguageServiceProvider.TupleElementServiceProvider.NameExactlyEqual(a, b));

            a = SyntaxFactory.TupleElement(SyntaxFactory.ParseTypeName("(string, int)"), SyntaxFactory.Identifier("a"));
            b = SyntaxFactory.TupleElement(SyntaxFactory.ParseTypeName("(string, int)"), SyntaxFactory.Identifier("a"));
            Assert.IsTrue(flad.LanguageServiceProvider.TupleElementServiceProvider.NameExactlyEqual(a, b));
        }

        [TestMethod]
        public void ArgumentServiceProvider_NameExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = ((InvocationExpressionSyntax)SyntaxFactory.ParseExpression("f(3)")).ArgumentList.Arguments[0];
            var b = ((InvocationExpressionSyntax)SyntaxFactory.ParseExpression("f(3)")).ArgumentList.Arguments[0];
            Assert.IsFalse(flad.LanguageServiceProvider.ArgumentServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.ArgumentServiceProvider.NameExactlyEqual(a, null));
            Assert.IsFalse(flad.LanguageServiceProvider.ArgumentServiceProvider.NameExactlyEqual(null, null));
            Assert.IsFalse(flad.LanguageServiceProvider.ArgumentServiceProvider.NameExactlyEqual(a, b));

            a = ((InvocationExpressionSyntax)SyntaxFactory.ParseExpression("f(arg1: 3)")).ArgumentList.Arguments[0];
            b = ((InvocationExpressionSyntax)SyntaxFactory.ParseExpression("f(arg2: 3)")).ArgumentList.Arguments[0];
            Assert.IsFalse(flad.LanguageServiceProvider.ArgumentServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.ArgumentServiceProvider.NameExactlyEqual(a, null));
            Assert.IsFalse(flad.LanguageServiceProvider.ArgumentServiceProvider.NameExactlyEqual(null, null));
            Assert.IsFalse(flad.LanguageServiceProvider.ArgumentServiceProvider.NameExactlyEqual(a, b));

            a = ((InvocationExpressionSyntax)SyntaxFactory.ParseExpression("f(arg: 3)")).ArgumentList.Arguments[0];
            b = ((InvocationExpressionSyntax)SyntaxFactory.ParseExpression("f(arg: 3)")).ArgumentList.Arguments[0];
            Assert.IsTrue(flad.LanguageServiceProvider.ArgumentServiceProvider.NameExactlyEqual(a, b));
        }

        [TestMethod]
        public void NameColonServiceProvider_NameExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(\"X\")]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0].NameColon;
            var b = SyntaxFactory.ParseCompilationUnit("[module: YAttribute(\"Y\")]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0].NameColon;
            Assert.IsFalse(flad.LanguageServiceProvider.NameColonServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.NameColonServiceProvider.NameExactlyEqual(a, (NameColonSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.NameColonServiceProvider.NameExactlyEqual(null, (NameColonSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.NameColonServiceProvider.NameExactlyEqual(a, b));

            a = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(x : \"X\")]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0].NameColon;
            b = SyntaxFactory.ParseCompilationUnit("[module: YAttribute(y : \"Y\")]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0].NameColon;
            Assert.IsFalse(flad.LanguageServiceProvider.NameColonServiceProvider.NameExactlyEqual(a, b));

            a = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(x : \"X\")]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0].NameColon;
            b = SyntaxFactory.ParseCompilationUnit("[module: YAttribute(x : \"Y\")]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0].NameColon;
            Assert.IsTrue(flad.LanguageServiceProvider.NameColonServiceProvider.NameExactlyEqual(a, b));
        }

        [TestMethod]
        public void AnonymousObjectMemberDeclaratorServiceProvider_NameExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = ((AnonymousObjectCreationExpressionSyntax)SyntaxFactory.ParseExpression("new { x.Text }")).Initializers[0];
            var b = ((AnonymousObjectCreationExpressionSyntax)SyntaxFactory.ParseExpression("new { x.Text }")).Initializers[0];
            Assert.IsFalse(flad.LanguageServiceProvider.AnonymousObjectMemberDeclaratorServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.AnonymousObjectMemberDeclaratorServiceProvider.NameExactlyEqual(a, (AnonymousObjectMemberDeclaratorSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.AnonymousObjectMemberDeclaratorServiceProvider.NameExactlyEqual(null, (AnonymousObjectMemberDeclaratorSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.AnonymousObjectMemberDeclaratorServiceProvider.NameExactlyEqual(a, b));

            a = ((AnonymousObjectCreationExpressionSyntax)SyntaxFactory.ParseExpression("new { Text = x.Text }")).Initializers[0];
            b = ((AnonymousObjectCreationExpressionSyntax)SyntaxFactory.ParseExpression("new { iText = x.Text }")).Initializers[0];
            Assert.IsFalse(flad.LanguageServiceProvider.AnonymousObjectMemberDeclaratorServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.AnonymousObjectMemberDeclaratorServiceProvider.NameExactlyEqual(a, (AnonymousObjectMemberDeclaratorSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.AnonymousObjectMemberDeclaratorServiceProvider.NameExactlyEqual(null, (AnonymousObjectMemberDeclaratorSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.AnonymousObjectMemberDeclaratorServiceProvider.NameExactlyEqual(a, b));

            a = ((AnonymousObjectCreationExpressionSyntax)SyntaxFactory.ParseExpression("new { Text = 4 }")).Initializers[0];
            b = ((AnonymousObjectCreationExpressionSyntax)SyntaxFactory.ParseExpression("new { Text = 4 }")).Initializers[0];
            Assert.IsTrue(flad.LanguageServiceProvider.AnonymousObjectMemberDeclaratorServiceProvider.NameExactlyEqual(a, b));
        }

        [TestMethod]
        public void QueryBodyServiceProvider_NameExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = ((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s let y = 5 where f.A select f.R")).Body;
            var b = ((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s let y = 5 where f.A select f.R")).Body;
            Assert.IsFalse(flad.LanguageServiceProvider.QueryBodyServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.QueryBodyServiceProvider.NameExactlyEqual(a, (QueryBodySyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.QueryBodyServiceProvider.NameExactlyEqual(null, (QueryBodySyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.QueryBodyServiceProvider.NameExactlyEqual(a, b));

            a = ((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s let y = 5 where f.A select f.R into f")).Body;
            b = ((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s let y = 5 where f.A select f.R into g")).Body;
            Assert.IsFalse(flad.LanguageServiceProvider.QueryBodyServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.QueryBodyServiceProvider.NameExactlyEqual(a, (QueryBodySyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.QueryBodyServiceProvider.NameExactlyEqual(null, (QueryBodySyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.QueryBodyServiceProvider.NameExactlyEqual(a, b));

            a = ((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s let y = 5 where f.A select f.R into f")).Body;
            b = ((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s let y = 5 where f.A select f.R into f")).Body;
            Assert.IsTrue(flad.LanguageServiceProvider.QueryBodyServiceProvider.NameExactlyEqual(a, b));
        }

        [TestMethod]
        public void JoinIntoClauseServiceProvider_NameExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = ((JoinClauseSyntax)(((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s join prod in products on category.ID equals prod.CategoryID into f")).Body.Clauses[0])).Into;
            var b = ((JoinClauseSyntax)(((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s join prod in products on category.ID equals prod.CategoryID into g")).Body.Clauses[0])).Into;
            Assert.IsFalse(flad.LanguageServiceProvider.JoinIntoClauseServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.JoinIntoClauseServiceProvider.NameExactlyEqual(a, (JoinIntoClauseSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.JoinIntoClauseServiceProvider.NameExactlyEqual(null, (JoinIntoClauseSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.JoinIntoClauseServiceProvider.NameExactlyEqual(a, b));

            a = ((JoinClauseSyntax)(((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s join prod in products on category.ID equals prod.CategoryID into f")).Body.Clauses[0])).Into;
            b = ((JoinClauseSyntax)(((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s join prod in products on category.ID equals prod.CategoryID into f")).Body.Clauses[0])).Into;
            Assert.IsTrue(flad.LanguageServiceProvider.JoinIntoClauseServiceProvider.NameExactlyEqual(a, b));
        }

        [TestMethod]
        public void QueryContinuationServiceProvider_NameExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = ((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s let y = 5 where f.A select f.R into f")).Body.Continuation;
            var b = ((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s let y = 5 where f.A select f.R into g")).Body.Continuation;
            Assert.IsFalse(flad.LanguageServiceProvider.QueryContinuationServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.QueryContinuationServiceProvider.NameExactlyEqual(a, (QueryContinuationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.QueryContinuationServiceProvider.NameExactlyEqual(null, (QueryContinuationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.QueryContinuationServiceProvider.NameExactlyEqual(a, b));

            a = ((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s let y = 5 where f.A select f.R into f")).Body.Continuation;
            b = ((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s let y = 5 where f.A select f.R into f")).Body.Continuation;
            Assert.IsTrue(flad.LanguageServiceProvider.QueryContinuationServiceProvider.NameExactlyEqual(a, b));
        }

        [TestMethod]
        public void VariableDeclarationServiceProvider_NameExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = ((LocalDeclarationStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int v() { const int a = 4, b = 3; }").Members[0]).Body.Statements[0]).Declaration;
            var b = ((LocalDeclarationStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int v() { const int b = 4, b = 3; }").Members[0]).Body.Statements[0]).Declaration;
            Assert.IsFalse(flad.LanguageServiceProvider.VariableDeclarationServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.VariableDeclarationServiceProvider.NameExactlyEqual(a, (VariableDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.VariableDeclarationServiceProvider.NameExactlyEqual(null, (VariableDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.VariableDeclarationServiceProvider.NameExactlyEqual(a, b));

            a = ((LocalDeclarationStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int v() { const int a = 4, b = 3; }").Members[0]).Body.Statements[0]).Declaration;
            b = ((LocalDeclarationStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int v() { const int a = 4, b = 3; }").Members[0]).Body.Statements[0]).Declaration;
            Assert.IsTrue(flad.LanguageServiceProvider.VariableDeclarationServiceProvider.NameExactlyEqual(a, b));
        }

        [TestMethod]
        public void VariableDeclaratorServiceProvider_NameExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = ((LocalDeclarationStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int v() { const int a = 4, b = 3; }").Members[0]).Body.Statements[0]).Declaration.Variables[0];
            var b = ((LocalDeclarationStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int v() { const int b = 4, b = 3; }").Members[0]).Body.Statements[0]).Declaration.Variables[0];
            Assert.IsFalse(flad.LanguageServiceProvider.VariableDeclaratorServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.VariableDeclaratorServiceProvider.NameExactlyEqual(a, (VariableDeclaratorSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.VariableDeclaratorServiceProvider.NameExactlyEqual(null, (VariableDeclaratorSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.VariableDeclaratorServiceProvider.NameExactlyEqual(a, b));

            a = ((LocalDeclarationStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int v() { const int a = 4, b = 3; }").Members[0]).Body.Statements[0]).Declaration.Variables[0];
            b = ((LocalDeclarationStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int v() { const int a = 4, b = 3; }").Members[0]).Body.Statements[0]).Declaration.Variables[0];
            Assert.IsTrue(flad.LanguageServiceProvider.VariableDeclaratorServiceProvider.NameExactlyEqual(a, b));
        }

        [TestMethod]
        public void CatchClauseServiceProvider_NameExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = ((TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch(A1){a1 = \"Catch a1\";} catch(B1) when(e = 5) {b1 = \"Catch b1\";} finally{c1 = \"Finnally1\";}")).Catches[0];
            var b = ((TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch(A1){a1 = \"Catch a1\";} catch(B1) when(e = 5) {b1 = \"Catch b1\";} finally{c1 = \"Finnally1\";}")).Catches[0];
            Assert.IsFalse(flad.LanguageServiceProvider.CatchClauseServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.CatchClauseServiceProvider.NameExactlyEqual(a, (CatchClauseSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.CatchClauseServiceProvider.NameExactlyEqual(null, (CatchClauseSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.CatchClauseServiceProvider.NameExactlyEqual(a, b));

            a = ((TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch(A1 e1){a1 = \"Catch a1\";} catch(B1) when(e = 5) {b1 = \"Catch b1\";} finally{c1 = \"Finnally1\";}")).Catches[0];
            b = ((TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch(A1 e2){a1 = \"Catch a1\";} catch(B1) when(e = 5) {b1 = \"Catch b1\";} finally{c1 = \"Finnally1\";}")).Catches[0];
            Assert.IsFalse(flad.LanguageServiceProvider.CatchClauseServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.CatchClauseServiceProvider.NameExactlyEqual(a, (CatchClauseSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.CatchClauseServiceProvider.NameExactlyEqual(null, (CatchClauseSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.CatchClauseServiceProvider.NameExactlyEqual(a, b));

            a = ((TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch(A1 e1){a1 = \"Catch a1\";} catch(B1) when(e = 5) {b1 = \"Catch b1\";} finally{c1 = \"Finnally1\";}")).Catches[0];
            b = ((TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch(A1 e1){a1 = \"Catch a1\";} catch(B1) when(e = 5) {b1 = \"Catch b1\";} finally{c1 = \"Finnally1\";}")).Catches[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CatchClauseServiceProvider.NameExactlyEqual(a, b));
        }

        [TestMethod]
        public void CatchDeclarationServiceProvider_NameExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = ((TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch(A1){a1 = \"Catch a1\";} catch(B1) when(e = 5) {b1 = \"Catch b1\";} finally{c1 = \"Finnally1\";}")).Catches[0].Declaration;
            var b = ((TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch(A1){a1 = \"Catch a1\";} catch(B1) when(e = 5) {b1 = \"Catch b1\";} finally{c1 = \"Finnally1\";}")).Catches[0].Declaration;
            Assert.IsFalse(flad.LanguageServiceProvider.CatchDeclarationServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.CatchDeclarationServiceProvider.NameExactlyEqual(a, (CatchDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.CatchDeclarationServiceProvider.NameExactlyEqual(null, (CatchDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.CatchDeclarationServiceProvider.NameExactlyEqual(a, b));

            a = ((TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch(A1 e1){a1 = \"Catch a1\";} catch(B1) when(e = 5) {b1 = \"Catch b1\";} finally{c1 = \"Finnally1\";}")).Catches[0].Declaration;
            b = ((TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch(A1 e2){a1 = \"Catch a1\";} catch(B1) when(e = 5) {b1 = \"Catch b1\";} finally{c1 = \"Finnally1\";}")).Catches[0].Declaration;
            Assert.IsFalse(flad.LanguageServiceProvider.CatchDeclarationServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.CatchDeclarationServiceProvider.NameExactlyEqual(a, (CatchDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.CatchDeclarationServiceProvider.NameExactlyEqual(null, (CatchDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.CatchDeclarationServiceProvider.NameExactlyEqual(a, b));

            a = ((TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch(A1 e1){a1 = \"Catch a1\";} catch(B1) when(e = 5) {b1 = \"Catch b1\";} finally{c1 = \"Finnally1\";}")).Catches[0].Declaration;
            b = ((TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch(A1 e1){a1 = \"Catch a1\";} catch(B1) when(e = 5) {b1 = \"Catch b1\";} finally{c1 = \"Finnally1\";}")).Catches[0].Declaration;
            Assert.IsTrue(flad.LanguageServiceProvider.CatchDeclarationServiceProvider.NameExactlyEqual(a, b));
        }

        [TestMethod]
        public void ExternAliasDirectiveServiceProvider_NameExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = SyntaxFactory.ParseCompilationUnit("extern alias a;").Externs[0];
            var b = SyntaxFactory.ParseCompilationUnit("extern alias b;").Externs[0];
            Assert.IsFalse(flad.LanguageServiceProvider.ExternAliasDirectiveServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.ExternAliasDirectiveServiceProvider.NameExactlyEqual(a, (ExternAliasDirectiveSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.ExternAliasDirectiveServiceProvider.NameExactlyEqual(null, (ExternAliasDirectiveSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.ExternAliasDirectiveServiceProvider.NameExactlyEqual(a, b));

            a = SyntaxFactory.ParseCompilationUnit("extern alias a;").Externs[0];
            b = SyntaxFactory.ParseCompilationUnit("extern alias a;").Externs[0];
            Assert.IsTrue(flad.LanguageServiceProvider.ExternAliasDirectiveServiceProvider.NameExactlyEqual(a, b));
        }

        [TestMethod]
        public void UsingDirectiveServiceProvider_NameExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = SyntaxFactory.ParseCompilationUnit("using static a;").Usings[0];
            var b = SyntaxFactory.ParseCompilationUnit("using static b;").Usings[0];
            Assert.IsFalse(flad.LanguageServiceProvider.UsingDirectiveServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.UsingDirectiveServiceProvider.NameExactlyEqual(a, (UsingDirectiveSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.UsingDirectiveServiceProvider.NameExactlyEqual(null, (UsingDirectiveSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.UsingDirectiveServiceProvider.NameExactlyEqual(a, b));

            a = SyntaxFactory.ParseCompilationUnit("using static a;").Usings[0];
            b = SyntaxFactory.ParseCompilationUnit("using static a;").Usings[0];
            Assert.IsTrue(flad.LanguageServiceProvider.UsingDirectiveServiceProvider.NameExactlyEqual(a, b));

            a = SyntaxFactory.ParseCompilationUnit("using static c = a;").Usings[0];
            b = SyntaxFactory.ParseCompilationUnit("using static c1 = a;").Usings[0];
            Assert.IsFalse(flad.LanguageServiceProvider.UsingDirectiveServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.UsingDirectiveServiceProvider.NameExactlyEqual(a, (UsingDirectiveSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.UsingDirectiveServiceProvider.NameExactlyEqual(null, (UsingDirectiveSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.UsingDirectiveServiceProvider.NameExactlyEqual(a, b));

            a = SyntaxFactory.ParseCompilationUnit("using static c = a;").Usings[0];
            b = SyntaxFactory.ParseCompilationUnit("using static c1 = b;").Usings[0];
            Assert.IsFalse(flad.LanguageServiceProvider.UsingDirectiveServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.UsingDirectiveServiceProvider.NameExactlyEqual(a, (UsingDirectiveSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.UsingDirectiveServiceProvider.NameExactlyEqual(null, (UsingDirectiveSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.UsingDirectiveServiceProvider.NameExactlyEqual(a, b));

            a = SyntaxFactory.ParseCompilationUnit("using static c = a;").Usings[0];
            b = SyntaxFactory.ParseCompilationUnit("using static c = a;").Usings[0];
            Assert.IsTrue(flad.LanguageServiceProvider.UsingDirectiveServiceProvider.NameExactlyEqual(a, b));
        }

        [TestMethod]
        public void AttributeListServiceProvider_NameExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = ((ClassDeclarationSyntax)(SyntaxFactory.ParseCompilationUnit("[XAttribute(\"X\"), YAttribute(Y: 3), ZAttribute(Z= 4)]class A{};").Members[0])).AttributeLists[0];
            var b = ((ClassDeclarationSyntax)(SyntaxFactory.ParseCompilationUnit("[XAttribute(\"X\"), YAttribute(Y: 3), ZAttribute(Z= 4)]class A{};").Members[0])).AttributeLists[0];
            Assert.IsFalse(flad.LanguageServiceProvider.AttributeListServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.AttributeListServiceProvider.NameExactlyEqual(a, (AttributeListSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.AttributeListServiceProvider.NameExactlyEqual(null, (AttributeListSyntax)null));
            Assert.IsTrue(flad.LanguageServiceProvider.AttributeListServiceProvider.NameExactlyEqual(a, b));

            a = ((ClassDeclarationSyntax)(SyntaxFactory.ParseCompilationUnit("[[module: XAttribute(\"X\"), YAttribute(Y: 3), ZAttribute(Z= 4)]class A{};").Members[0])).AttributeLists[0];
            b = ((ClassDeclarationSyntax)(SyntaxFactory.ParseCompilationUnit("[XAttribute(\"X\"), YAttribute(Y: 3), ZAttribute(Z= 4)]class A{};").Members[0])).AttributeLists[0];
            Assert.IsFalse(flad.LanguageServiceProvider.AttributeListServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.AttributeListServiceProvider.NameExactlyEqual(a, (AttributeListSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.AttributeListServiceProvider.NameExactlyEqual(null, (AttributeListSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.AttributeListServiceProvider.NameExactlyEqual(a, b));

            a = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(\"X\"), YAttribute(Y: 3), ZAttribute(Z= 4)]").AttributeLists[0];
            b = SyntaxFactory.ParseCompilationUnit("[assembly: XAttribute(\"X\"), YAttribute(Y: 3), ZAttribute(Z= 4)]").AttributeLists[0];
            Assert.IsFalse(flad.LanguageServiceProvider.AttributeListServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.AttributeListServiceProvider.NameExactlyEqual(a, (AttributeListSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.AttributeListServiceProvider.NameExactlyEqual(null, (AttributeListSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.AttributeListServiceProvider.NameExactlyEqual(a, b));

            a = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(\"X\"), YAttribute(Y: 3), ZAttribute(Z= 4)]").AttributeLists[0];
            b = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(\"X\"), YAttribute(Y: 3), ZAttribute(Z= 4)]").AttributeLists[0];
            Assert.IsTrue(flad.LanguageServiceProvider.AttributeListServiceProvider.NameExactlyEqual(a, b));
        }

        [TestMethod]
        public void AttributeTargetSpecifierServiceProvider_NameExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(\"X\"), YAttribute(Y: 3), ZAttribute(Z= 4)]").AttributeLists[0].Target;
            var b = SyntaxFactory.ParseCompilationUnit("[assembly: XAttribute(\"X\"), YAttribute(Y: 3), ZAttribute(Z= 4)]").AttributeLists[0].Target;
            Assert.IsFalse(flad.LanguageServiceProvider.AttributeTargetSpecifierServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.AttributeTargetSpecifierServiceProvider.NameExactlyEqual(a, (AttributeTargetSpecifierSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.AttributeTargetSpecifierServiceProvider.NameExactlyEqual(null, (AttributeTargetSpecifierSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.AttributeTargetSpecifierServiceProvider.NameExactlyEqual(a, b));

            a = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(\"X\"), YAttribute(Y: 3), ZAttribute(Z= 4)]").AttributeLists[0].Target;
            b = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(\"X\"), YAttribute(Y: 3), ZAttribute(Z= 4)]").AttributeLists[0].Target;
            Assert.IsTrue(flad.LanguageServiceProvider.AttributeTargetSpecifierServiceProvider.NameExactlyEqual(a, b));
        }

        [TestMethod]
        public void AttributeServiceProvider_NameExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(\"X\"), YAttribute(Y: 3), ZAttribute(Z= 4)]").AttributeLists[0].Attributes[0];
            var b = SyntaxFactory.ParseCompilationUnit("[assembly: YAttribute(\"X\"), YAttribute(Y: 3), ZAttribute(Z= 4)]").AttributeLists[0].Attributes[0];
            Assert.IsFalse(flad.LanguageServiceProvider.AttributeServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.AttributeServiceProvider.NameExactlyEqual(a, (AttributeSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.AttributeServiceProvider.NameExactlyEqual(null, (AttributeSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.AttributeServiceProvider.NameExactlyEqual(a, b));

            a = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(\"X\"), YAttribute(Y: 3), ZAttribute(Z= 4)]").AttributeLists[0].Attributes[0];
            b = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(\"X\"), YAttribute(Y: 3), ZAttribute(Z= 4)]").AttributeLists[0].Attributes[0];
            Assert.IsTrue(flad.LanguageServiceProvider.AttributeServiceProvider.NameExactlyEqual(a, b));
        }

        [TestMethod]
        public void DelegateDeclarationServiceProvider_NameExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = (DelegateDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] delegate void Del<T>(string str);").Members[0];
            var b = (DelegateDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] delegate void iDel<T>(string str);").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.NameExactlyEqual(a, (DelegateDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.NameExactlyEqual(null, (DelegateDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.NameExactlyEqual(a, b));

            a = (DelegateDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] delegate void Del<T>(string str);").Members[0];
            b = (DelegateDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] delegate void Del<T>(string str);").Members[0];
            Assert.IsTrue(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.NameExactlyEqual(a, b));
        }

        [TestMethod]
        public void EnumMemberDeclarationServiceProvider_NameExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = ((EnumDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("enum a {a1, a2 = 3, [Serializable]bf = 34};").Members[0]).Members[0];
            var b = ((EnumDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("enum a {b1, a2 = 3, [Serializable]bf = 34};").Members[0]).Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.EnumMemberDeclarationServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.EnumMemberDeclarationServiceProvider.NameExactlyEqual(a, (EnumMemberDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.EnumMemberDeclarationServiceProvider.NameExactlyEqual(null, (EnumMemberDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.EnumMemberDeclarationServiceProvider.NameExactlyEqual(a, b));

            a = ((EnumDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("enum a {a1, a2 = 3, [Serializable]bf = 34};").Members[0]).Members[0];
            b = ((EnumDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("enum a {a1, a2 = 3, [Serializable]bf = 34};").Members[0]).Members[0];
            Assert.IsTrue(flad.LanguageServiceProvider.EnumMemberDeclarationServiceProvider.NameExactlyEqual(a, b));
        }

        [TestMethod]
        public void NamespaceDeclarationServiceProvider_NameExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = (NamespaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("namespace a{extern alias b; using static d; namespace c{};};").Members[0];
            var b = (NamespaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("namespace b{extern alias b; using static d; namespace c{};};").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.NamespaceDeclarationServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.NamespaceDeclarationServiceProvider.NameExactlyEqual(a, (NamespaceDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.NamespaceDeclarationServiceProvider.NameExactlyEqual(null, (NamespaceDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.NamespaceDeclarationServiceProvider.NameExactlyEqual(a, b));

            a = (NamespaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("namespace a{extern alias b; using static d; namespace c{};};").Members[0];
            b = (NamespaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("namespace a{extern alias b; using static d; namespace c{};};").Members[0];
            Assert.IsTrue(flad.LanguageServiceProvider.NamespaceDeclarationServiceProvider.NameExactlyEqual(a, b));
        }

        [TestMethod]
        public void EnumDeclarationServiceProvider_NameExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = (EnumDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public enum a : byte {a1, a2 = 3, bf = 34};").Members[0];
            var b = (EnumDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public enum b : byte {a1, a2 = 3, bf = 34};").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.EnumDeclarationServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.EnumDeclarationServiceProvider.NameExactlyEqual(a, (EnumDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.EnumDeclarationServiceProvider.NameExactlyEqual(null, (EnumDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.EnumDeclarationServiceProvider.NameExactlyEqual(a, b));

            a = (EnumDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public enum a : byte {a1, a2 = 3, bf = 34};").Members[0];
            b = (EnumDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public enum a : byte {a1, a2 = 3, bf = 34};").Members[0];
            Assert.IsTrue(flad.LanguageServiceProvider.EnumDeclarationServiceProvider.NameExactlyEqual(a, b));
        }

        [TestMethod]
        public void ClassDeclarationServiceProvider_NameExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public class a<T> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            var b = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public class b<T> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.ClassDeclarationServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.ClassDeclarationServiceProvider.NameExactlyEqual(a, (ClassDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.ClassDeclarationServiceProvider.NameExactlyEqual(null, (ClassDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.ClassDeclarationServiceProvider.NameExactlyEqual(a, b));

            a = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public class a<T> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            b = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public class a<T> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            Assert.IsTrue(flad.LanguageServiceProvider.ClassDeclarationServiceProvider.NameExactlyEqual(a, b));
        }

        [TestMethod]
        public void StructDeclarationServiceProvider_NameExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = (StructDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public struct a<T> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            var b = (StructDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public struct b<T> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.StructDeclarationServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.StructDeclarationServiceProvider.NameExactlyEqual(a, (StructDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.StructDeclarationServiceProvider.NameExactlyEqual(null, (StructDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.StructDeclarationServiceProvider.NameExactlyEqual(a, b));

            a = (StructDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public struct a<T> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            b = (StructDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public struct a<T> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            Assert.IsTrue(flad.LanguageServiceProvider.StructDeclarationServiceProvider.NameExactlyEqual(a, b));
        }
        
        [TestMethod]
        public void InterfaceDeclarationServiceProvider_NameExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = (InterfaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public interface a<T> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            var b = (InterfaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public interface b<T> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.InterfaceDeclarationServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.InterfaceDeclarationServiceProvider.NameExactlyEqual(a, (InterfaceDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.InterfaceDeclarationServiceProvider.NameExactlyEqual(null, (InterfaceDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.InterfaceDeclarationServiceProvider.NameExactlyEqual(a, b));

            a = (InterfaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public interface a<T> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            b = (InterfaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public interface a<T> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            Assert.IsTrue(flad.LanguageServiceProvider.InterfaceDeclarationServiceProvider.NameExactlyEqual(a, b));
        }

        [TestMethod]
        public void FieldDeclarationServiceProvider_NameExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = (FieldDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a {B a1; internal static A b2 = 3; [Serializable]A c3 = 3; [Serializable]public int df = 34;}").Members[0]).Members[0];
            var b = (FieldDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a {B a11; internal static A b2 = 3; [Serializable]A c3 = 3; [Serializable]public int df = 34;}").Members[0]).Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.FieldDeclarationServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.FieldDeclarationServiceProvider.NameExactlyEqual(a, (FieldDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.FieldDeclarationServiceProvider.NameExactlyEqual(null, (FieldDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.FieldDeclarationServiceProvider.NameExactlyEqual(a, b));

            a = (FieldDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a {B a1; internal static A b2 = 3; [Serializable]A c3 = 3; [Serializable]public int df = 34;}").Members[0]).Members[0];
            b = (FieldDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a {B a1; internal static A b2 = 3; [Serializable]A c3 = 3; [Serializable]public int df = 34;}").Members[0]).Members[0];
            Assert.IsTrue(flad.LanguageServiceProvider.FieldDeclarationServiceProvider.NameExactlyEqual(a, b));
        }

        [TestMethod]
        public void EventFieldDeclarationServiceProvider_NameExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = (EventFieldDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a {event B a1; internal static event A b2 = 3; [Serializable]event A c3 = 3; [Serializable]public event int df = 34;}").Members[0]).Members[0];
            var b = (EventFieldDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a {event B a11; internal static event A b2 = 3; [Serializable]event A c3 = 3; [Serializable]public event int df = 34;}").Members[0]).Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.EventFieldDeclarationServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.EventFieldDeclarationServiceProvider.NameExactlyEqual(a, (EventFieldDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.EventFieldDeclarationServiceProvider.NameExactlyEqual(null, (EventFieldDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.EventFieldDeclarationServiceProvider.NameExactlyEqual(a, b));

            a = (EventFieldDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a {event B a1; internal static event A b2 = 3; [Serializable]event A c3 = 3; [Serializable]public event int df = 34;}").Members[0]).Members[0];
            b = (EventFieldDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a {event B a1; internal static event A b2 = 3; [Serializable]event A c3 = 3; [Serializable]public event int df = 34;}").Members[0]).Members[0];
            Assert.IsTrue(flad.LanguageServiceProvider.EventFieldDeclarationServiceProvider.NameExactlyEqual(a, b));
        }

        [TestMethod]
        public void MethodDeclarationServiceProvider_NameExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M<T>(int a, A b)where T: class { return 5; };").Members[0];
            var b = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M1<T>(int a, A b)where T: class { return 5; };").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.NameExactlyEqual(a, (MethodDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.NameExactlyEqual(null, (MethodDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.NameExactlyEqual(a, b));

            a = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C1.M<T>(int a, A b)where T: class { return 5; };").Members[0];
            b = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M<T>(int a, A b)where T: class { return 5; };").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.NameExactlyEqual(a, (MethodDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.NameExactlyEqual(null, (MethodDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.NameExactlyEqual(a, b));

            a = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M<T>(int a, A b)where T: class { return 5; };").Members[0];
            b = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M<T>(int a, A b)where T: class { return 5; };").Members[0];
            Assert.IsTrue(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.NameExactlyEqual(a, b));

            a = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string M<T>(int a, A b)where T: class { return 5; };").Members[0];
            b = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string M1<T>(int a, A b)where T: class { return 5; };").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.NameExactlyEqual(a, b));

            a = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string M<T>(int a, A b)where T: class { return 5; };").Members[0];
            b = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string M<T>(int a, A b)where T: class { return 5; };").Members[0];
            Assert.IsTrue(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.NameExactlyEqual(a, b));
        }

        [TestMethod]
        public void OperatorDeclarationServiceProvider_NameExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string operator +(int a, A b) { return 5; };").Members[0];
            var b = (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string operator -(int a, A b) { return 5; };").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.OperatorDeclarationServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.OperatorDeclarationServiceProvider.NameExactlyEqual(a, (OperatorDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.OperatorDeclarationServiceProvider.NameExactlyEqual(null, (OperatorDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.OperatorDeclarationServiceProvider.NameExactlyEqual(a, b));

            a = (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string operator +(int a, A b) { return 5; };").Members[0];
            b = (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string operator +(int a, A b) { return 5; };").Members[0];
            Assert.IsTrue(flad.LanguageServiceProvider.OperatorDeclarationServiceProvider.NameExactlyEqual(a, b));
        }

        [TestMethod]
        public void ConstructorDeclarationServiceProvider_NameExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = (ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation]public A(B b) : this(b) { }; }").Members[0]).Members[0];
            var b = (ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A1 { [Documentation]public A1(B b) : this(b) { }; }").Members[0]).Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.ConstructorDeclarationServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.ConstructorDeclarationServiceProvider.NameExactlyEqual(a, (ConstructorDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.ConstructorDeclarationServiceProvider.NameExactlyEqual(null, (ConstructorDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.ConstructorDeclarationServiceProvider.NameExactlyEqual(a, b));

            a = (ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation]public A(B b) : this(b) { }; }").Members[0]).Members[0];
            b = (ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation]public A(B b) : this(b) { }; }").Members[0]).Members[0];
            Assert.IsTrue(flad.LanguageServiceProvider.ConstructorDeclarationServiceProvider.NameExactlyEqual(a, b));
        }

        [TestMethod]
        public void DestructorDeclarationServiceProvider_NameExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = (DestructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation] ~A(){ }; }").Members[0]).Members[0];
            var b = (DestructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A1 { [Documentation] ~A1(){ }; }").Members[0]).Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.DestructorDeclarationServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.DestructorDeclarationServiceProvider.NameExactlyEqual(a, (DestructorDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.DestructorDeclarationServiceProvider.NameExactlyEqual(null, (DestructorDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.DestructorDeclarationServiceProvider.NameExactlyEqual(a, b));

            a = (DestructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation] ~A(){ }; }").Members[0]).Members[0];
            b = (DestructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation] ~A(){ }; }").Members[0]).Members[0];
            Assert.IsTrue(flad.LanguageServiceProvider.DestructorDeclarationServiceProvider.NameExactlyEqual(a, b));
        }

        [TestMethod]
        public void PropertyDeclarationServiceProvider_NameExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M { get{return 5;} set{this.a = 7} };").Members[0];
            var b = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M1 { get{return 5;} set{this.a = 7} };").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.PropertyDeclarationServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.PropertyDeclarationServiceProvider.NameExactlyEqual(a, (PropertyDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.PropertyDeclarationServiceProvider.NameExactlyEqual(null, (PropertyDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.PropertyDeclarationServiceProvider.NameExactlyEqual(a, b));

            a = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M { get{return 5;} set{this.a = 7} };").Members[0];
            b = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C1.M { get{return 5;} set{this.a = 7} };").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.PropertyDeclarationServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.PropertyDeclarationServiceProvider.NameExactlyEqual(a, (PropertyDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.PropertyDeclarationServiceProvider.NameExactlyEqual(null, (PropertyDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.PropertyDeclarationServiceProvider.NameExactlyEqual(a, b));

            a = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M { get{return 5;} set{this.a = 7} };").Members[0];
            b = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M { get{return 5;} set{this.a = 7} };").Members[0];
            Assert.IsTrue(flad.LanguageServiceProvider.PropertyDeclarationServiceProvider.NameExactlyEqual(a, b));

            a = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string M { get{return 5;} set{this.a = 7} };").Members[0];
            b = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string M1 { get{return 5;} set{this.a = 7} };").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.PropertyDeclarationServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.PropertyDeclarationServiceProvider.NameExactlyEqual(a, (PropertyDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.PropertyDeclarationServiceProvider.NameExactlyEqual(null, (PropertyDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.PropertyDeclarationServiceProvider.NameExactlyEqual(a, b));

            a = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string M { get{return 5;} set{this.a = 7} };").Members[0];
            b = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string M { get{return 5;} set{this.a = 7} };").Members[0];
            Assert.IsTrue(flad.LanguageServiceProvider.PropertyDeclarationServiceProvider.NameExactlyEqual(a, b));
        }

        [TestMethod]
        public void EventDeclarationServiceProvider_NameExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = (EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A C.M { add{this.M += value;} remove{this.M -= value} }").Members[0];
            var b = (EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A C.M1 { add{this.M += value;} remove{this.M -= value} }").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.EventDeclarationServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.EventDeclarationServiceProvider.NameExactlyEqual(a, (EventDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.EventDeclarationServiceProvider.NameExactlyEqual(null, (EventDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.EventDeclarationServiceProvider.NameExactlyEqual(a, b));

            a = (EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A C.M { add{this.M += value;} remove{this.M -= value} }").Members[0];
            b = (EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A C1.M { add{this.M += value;} remove{this.M -= value} }").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.EventDeclarationServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.EventDeclarationServiceProvider.NameExactlyEqual(a, (EventDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.EventDeclarationServiceProvider.NameExactlyEqual(null, (EventDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.EventDeclarationServiceProvider.NameExactlyEqual(a, b));

            a = (EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A C.M { add{this.M += value;} remove{this.M -= value} }").Members[0];
            b = (EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A C.M { add{this.M += value;} remove{this.M -= value} }").Members[0];
            Assert.IsTrue(flad.LanguageServiceProvider.EventDeclarationServiceProvider.NameExactlyEqual(a, b));

            a = (EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A M { add{this.M += value;} remove{this.M -= value} }").Members[0];
            b = (EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A M1 { add{this.M += value;} remove{this.M -= value} }").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.EventDeclarationServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.EventDeclarationServiceProvider.NameExactlyEqual(a, (EventDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.EventDeclarationServiceProvider.NameExactlyEqual(null, (EventDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.EventDeclarationServiceProvider.NameExactlyEqual(a, b));

            a = (EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A M { add{this.M += value;} remove{this.M -= value} }").Members[0];
            b = (EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A M { add{this.M += value;} remove{this.M -= value} }").Members[0];
            Assert.IsTrue(flad.LanguageServiceProvider.EventDeclarationServiceProvider.NameExactlyEqual(a, b));
        }

        [TestMethod]
        public void IndexerDeclarationServiceProvider_NameExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A C.this[string key] { get{return this.M[key];} set{this.M[key] = value;} } => 5;").Members[0];
            var b = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A C.this[string key] { get{return this.M[key];} set{this.M[key] = value;} } => 5;").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.NameExactlyEqual(a, (IndexerDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.NameExactlyEqual(null, (IndexerDeclarationSyntax)null));
            Assert.IsTrue(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.NameExactlyEqual(a, b));

            a = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A C.this[string key] { get{return this.M[key];} set{this.M[key] = value;} } => 5;").Members[0];
            b = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A C1.this[string key] { get{return this.M[key];} set{this.M[key] = value;} } => 5;").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.NameExactlyEqual(a, b));

            a = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A this[string key] { get{return this.M[key];} set{this.M[key] = value;} } => 5;").Members[0];
            b = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A this[string key] { get{return this.M[key];} set{this.M[key] = value;} } => 5;").Members[0];
            Assert.IsTrue(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.NameExactlyEqual(a, b));
        }

        [TestMethod]
        public void BadDirectiveTriviaServiceProvider_NameExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = SyntaxFactory.BadDirectiveTrivia(SyntaxFactory.Identifier("unknown"), true);
            var b = SyntaxFactory.BadDirectiveTrivia(SyntaxFactory.Identifier("unknownY"), true);
            Assert.IsFalse(flad.LanguageServiceProvider.BadDirectiveTriviaServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.BadDirectiveTriviaServiceProvider.NameExactlyEqual(a, (BadDirectiveTriviaSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.BadDirectiveTriviaServiceProvider.NameExactlyEqual(null, (BadDirectiveTriviaSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.BadDirectiveTriviaServiceProvider.NameExactlyEqual(a, b));

            a = SyntaxFactory.BadDirectiveTrivia(SyntaxFactory.Identifier("unknown"), true);
            b = SyntaxFactory.BadDirectiveTrivia(SyntaxFactory.Identifier("unknown"), true);
            Assert.IsTrue(flad.LanguageServiceProvider.BadDirectiveTriviaServiceProvider.NameExactlyEqual(a, b));
        }

        [TestMethod]
        public void DefineDirectiveTriviaServiceProvider_NameExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = SyntaxFactory.DefineDirectiveTrivia(SyntaxFactory.Identifier("DEBUG"), true);
            var b = SyntaxFactory.DefineDirectiveTrivia(SyntaxFactory.Identifier("iDEBUG"), true);
            Assert.IsFalse(flad.LanguageServiceProvider.DefineDirectiveTriviaServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.DefineDirectiveTriviaServiceProvider.NameExactlyEqual(a, (DefineDirectiveTriviaSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.DefineDirectiveTriviaServiceProvider.NameExactlyEqual(null, (DefineDirectiveTriviaSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.DefineDirectiveTriviaServiceProvider.NameExactlyEqual(a, b));

            a = SyntaxFactory.DefineDirectiveTrivia(SyntaxFactory.Identifier("DEBUG"), true);
            b = SyntaxFactory.DefineDirectiveTrivia(SyntaxFactory.Identifier("DEBUG"), true);
            Assert.IsTrue(flad.LanguageServiceProvider.DefineDirectiveTriviaServiceProvider.NameExactlyEqual(a, b));
        }

        [TestMethod]
        public void UndefDirectiveTriviaServiceProvider_NameExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = SyntaxFactory.UndefDirectiveTrivia(SyntaxFactory.Identifier("DEBUG"), true);
            var b = SyntaxFactory.UndefDirectiveTrivia(SyntaxFactory.Identifier("iDEBUG"), true);
            Assert.IsFalse(flad.LanguageServiceProvider.UndefDirectiveTriviaServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.UndefDirectiveTriviaServiceProvider.NameExactlyEqual(a, (UndefDirectiveTriviaSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.UndefDirectiveTriviaServiceProvider.NameExactlyEqual(null, (UndefDirectiveTriviaSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.UndefDirectiveTriviaServiceProvider.NameExactlyEqual(a, b));

            a = SyntaxFactory.UndefDirectiveTrivia(SyntaxFactory.Identifier("DEBUG"), true);
            b = SyntaxFactory.UndefDirectiveTrivia(SyntaxFactory.Identifier("DEBUG"), true);
            Assert.IsTrue(flad.LanguageServiceProvider.UndefDirectiveTriviaServiceProvider.NameExactlyEqual(a, b));
        }

        [TestMethod]
        public void NameMemberCrefServiceProvider_NameExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"N(int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<NameMemberCrefSyntax>().Single();
            var b = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"N1(int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<NameMemberCrefSyntax>().Single();
            Assert.IsFalse(flad.LanguageServiceProvider.NameMemberCrefServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.NameMemberCrefServiceProvider.NameExactlyEqual(a, (NameMemberCrefSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.NameMemberCrefServiceProvider.NameExactlyEqual(null, (NameMemberCrefSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.NameMemberCrefServiceProvider.NameExactlyEqual(a, b));

            a = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"N(int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<NameMemberCrefSyntax>().Single();
            b = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"N(int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<NameMemberCrefSyntax>().Single();
            Assert.IsTrue(flad.LanguageServiceProvider.NameMemberCrefServiceProvider.NameExactlyEqual(a, b));
        }

        [TestMethod]
        public void IndexerMemberCrefServiceProvider_NameExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"this[int]\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<IndexerMemberCrefSyntax>().Single();
            var b = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"this[int]\"/> </summary>" + Environment.NewLine +
                       "    class A1 { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<IndexerMemberCrefSyntax>().Single();
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerMemberCrefServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerMemberCrefServiceProvider.NameExactlyEqual(a, (IndexerMemberCrefSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerMemberCrefServiceProvider.NameExactlyEqual(null, (IndexerMemberCrefSyntax)null));
            Assert.IsTrue(flad.LanguageServiceProvider.IndexerMemberCrefServiceProvider.NameExactlyEqual(a, b));

            a = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"this[int]\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<IndexerMemberCrefSyntax>().Single();
            b = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"this[int]\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<IndexerMemberCrefSyntax>().Single();
            Assert.IsTrue(flad.LanguageServiceProvider.IndexerMemberCrefServiceProvider.NameExactlyEqual(a, b));
        }

        [TestMethod]
        public void OperatorMemberCrefServiceProvider_NameExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single();
            var b = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator -(int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single();
            Assert.IsFalse(flad.LanguageServiceProvider.OperatorMemberCrefServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.OperatorMemberCrefServiceProvider.NameExactlyEqual(a, (OperatorMemberCrefSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.OperatorMemberCrefServiceProvider.NameExactlyEqual(null, (OperatorMemberCrefSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.OperatorMemberCrefServiceProvider.NameExactlyEqual(a, b));

            a = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single();
            b = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single();
            Assert.IsTrue(flad.LanguageServiceProvider.OperatorMemberCrefServiceProvider.NameExactlyEqual(a, b));
        }

        [TestMethod]
        public void XmlElementServiceProvider_NameExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single();
            var b = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<Message id=\"5\" oid=\"3\">Hello World</Message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single();
            Assert.IsFalse(flad.LanguageServiceProvider.XmlElementServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.XmlElementServiceProvider.NameExactlyEqual(a, null));
            Assert.IsFalse(flad.LanguageServiceProvider.XmlElementServiceProvider.NameExactlyEqual(null, null));
            Assert.IsFalse(flad.LanguageServiceProvider.XmlElementServiceProvider.NameExactlyEqual(a, b));

            a = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single();
            b = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single();
            Assert.IsTrue(flad.LanguageServiceProvider.XmlElementServiceProvider.NameExactlyEqual(a, b));

            a = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<i:message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single();
            b = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<i:Message id=\"5\" oid=\"3\">Hello World</Message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single();
            Assert.IsFalse(flad.LanguageServiceProvider.XmlElementServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.XmlElementServiceProvider.NameExactlyEqual(a, null));
            Assert.IsFalse(flad.LanguageServiceProvider.XmlElementServiceProvider.NameExactlyEqual(null, null));
            Assert.IsFalse(flad.LanguageServiceProvider.XmlElementServiceProvider.NameExactlyEqual(a, b));

            a = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<i:message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single();
            b = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<j:message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single();
            Assert.IsFalse(flad.LanguageServiceProvider.XmlElementServiceProvider.NameExactlyEqual(a, b));

            a = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<i:message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single();
            b = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<i:message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single();
            Assert.IsTrue(flad.LanguageServiceProvider.XmlElementServiceProvider.NameExactlyEqual(a, b));
        }

        [TestMethod]
        public void XmlEmptyElementServiceProvider_NameExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<foo id=\"3\"/>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlEmptyElementSyntax>().Single();
            var b = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<ifoo id=\"3\"/>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlEmptyElementSyntax>().Single();
            Assert.IsFalse(flad.LanguageServiceProvider.XmlEmptyElementServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.XmlEmptyElementServiceProvider.NameExactlyEqual(a, null));
            Assert.IsFalse(flad.LanguageServiceProvider.XmlEmptyElementServiceProvider.NameExactlyEqual(null, null));
            Assert.IsFalse(flad.LanguageServiceProvider.XmlEmptyElementServiceProvider.NameExactlyEqual(a, b));

            a = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<foo id=\"3\"/>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlEmptyElementSyntax>().Single();
            b = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<foo id=\"3\"/>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlEmptyElementSyntax>().Single();
            Assert.IsTrue(flad.LanguageServiceProvider.XmlEmptyElementServiceProvider.NameExactlyEqual(a, b));

            a = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<i:foo id=\"3\"/>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlEmptyElementSyntax>().Single();
            b = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<i:Foo id=\"3\"/>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlEmptyElementSyntax>().Single();
            Assert.IsFalse(flad.LanguageServiceProvider.XmlEmptyElementServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.XmlEmptyElementServiceProvider.NameExactlyEqual(a, null));
            Assert.IsFalse(flad.LanguageServiceProvider.XmlEmptyElementServiceProvider.NameExactlyEqual(null, null));
            Assert.IsFalse(flad.LanguageServiceProvider.XmlEmptyElementServiceProvider.NameExactlyEqual(a, b));

            a = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<i:foo id=\"3\"/>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlEmptyElementSyntax>().Single();
            b = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<j:foo id=\"3\"/>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlEmptyElementSyntax>().Single();
            Assert.IsFalse(flad.LanguageServiceProvider.XmlEmptyElementServiceProvider.NameExactlyEqual(a, b));

            a = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<i:foo id=\"3\"/>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlEmptyElementSyntax>().Single();
            b = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<i:foo id=\"3\"/>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlEmptyElementSyntax>().Single();
            Assert.IsTrue(flad.LanguageServiceProvider.XmlEmptyElementServiceProvider.NameExactlyEqual(a, b));
        }

        [TestMethod]
        public void XmlProcessingInstructionServiceProvider_NameExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<?proc-inst1 this is a test of &some; processinginstruction?>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlProcessingInstructionSyntax>().Single();
            var b = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<?proc-inst this is a test of &some; processinginstruction?>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlProcessingInstructionSyntax>().Single();
            Assert.IsFalse(flad.LanguageServiceProvider.XmlProcessingInstructionServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.XmlProcessingInstructionServiceProvider.NameExactlyEqual(a, (XmlProcessingInstructionSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.XmlProcessingInstructionServiceProvider.NameExactlyEqual(null, (XmlProcessingInstructionSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.XmlProcessingInstructionServiceProvider.NameExactlyEqual(a, b));

            a = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<?proc-inst this is a test of &some; processinginstruction?>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlProcessingInstructionSyntax>().Single();
            b = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<?proc-inst this is a test of &some; processinginstruction?>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlProcessingInstructionSyntax>().Single();
            Assert.IsTrue(flad.LanguageServiceProvider.XmlProcessingInstructionServiceProvider.NameExactlyEqual(a, b));
        }

        [TestMethod]
        public void XmlTextAttributeServiceProvider_NameExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = (XmlTextAttributeSyntax)((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<message id=\"5 r\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag.Attributes[0];
            var b = (XmlTextAttributeSyntax)((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<message id1=\"5 r\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag.Attributes[0];
            Assert.IsFalse(flad.LanguageServiceProvider.XmlTextAttributeServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.XmlTextAttributeServiceProvider.NameExactlyEqual(a, (XmlTextAttributeSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.XmlTextAttributeServiceProvider.NameExactlyEqual(null, (XmlTextAttributeSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.XmlTextAttributeServiceProvider.NameExactlyEqual(a, b));

            a = (XmlTextAttributeSyntax)((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<message id=\"5 r\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag.Attributes[0];
            b = (XmlTextAttributeSyntax)((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<message id=\"5 r\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag.Attributes[0];
            Assert.IsTrue(flad.LanguageServiceProvider.XmlTextAttributeServiceProvider.NameExactlyEqual(a, b));
        }

        [TestMethod]
        public void XmlCrefAttributeServiceProvider_NameExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = (XmlCrefAttributeSyntax)((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<see cref=\"M2\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag.Attributes[0];
            var b = (XmlCrefAttributeSyntax)((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<see cref=\"M\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag.Attributes[0];
            Assert.IsFalse(flad.LanguageServiceProvider.XmlCrefAttributeServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.XmlCrefAttributeServiceProvider.NameExactlyEqual(a, (XmlCrefAttributeSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.XmlCrefAttributeServiceProvider.NameExactlyEqual(null, (XmlCrefAttributeSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.XmlCrefAttributeServiceProvider.NameExactlyEqual(a, b));

            a = (XmlCrefAttributeSyntax)((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<see cref=\"M\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag.Attributes[0];
            b = (XmlCrefAttributeSyntax)((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<see cref=\"M\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag.Attributes[0];
            Assert.IsTrue(flad.LanguageServiceProvider.XmlCrefAttributeServiceProvider.NameExactlyEqual(a, b));
        }

        [TestMethod]
        public void XmlNameAttributeServiceProvider_NameExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = (XmlNameAttributeSyntax)((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<param name=\"M1\"/>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlEmptyElementSyntax>().Single().Attributes[0];
            var b = (XmlNameAttributeSyntax)((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<param name=\"M\"/>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlEmptyElementSyntax>().Single().Attributes[0];
            Assert.IsFalse(flad.LanguageServiceProvider.XmlNameAttributeServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.XmlNameAttributeServiceProvider.NameExactlyEqual(a, (XmlNameAttributeSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.XmlNameAttributeServiceProvider.NameExactlyEqual(null, (XmlNameAttributeSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.XmlNameAttributeServiceProvider.NameExactlyEqual(a, b));

            a = (XmlNameAttributeSyntax)((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<param name=\"M\"/>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlEmptyElementSyntax>().Single().Attributes[0];
            b = (XmlNameAttributeSyntax)((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<param name=\"M\"/>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlEmptyElementSyntax>().Single().Attributes[0];
            Assert.IsTrue(flad.LanguageServiceProvider.XmlNameAttributeServiceProvider.NameExactlyEqual(a, b));
        }

        [TestMethod]
        public void MemberAccessExpressionServiceProvider_NameExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = (MemberAccessExpressionSyntax)SyntaxFactory.ParseExpression("x.r");
            var b = (MemberAccessExpressionSyntax)SyntaxFactory.ParseExpression("x.R");
            Assert.IsFalse(flad.LanguageServiceProvider.MemberAccessExpressionServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.MemberAccessExpressionServiceProvider.NameExactlyEqual(a, (MemberAccessExpressionSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.MemberAccessExpressionServiceProvider.NameExactlyEqual(null, (MemberAccessExpressionSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.MemberAccessExpressionServiceProvider.NameExactlyEqual(a, b));

            a = (MemberAccessExpressionSyntax)SyntaxFactory.ParseExpression("x.r");
            b = (MemberAccessExpressionSyntax)SyntaxFactory.ParseExpression("x.r");
            Assert.IsTrue(flad.LanguageServiceProvider.MemberAccessExpressionServiceProvider.NameExactlyEqual(a, b));

            a = (MemberAccessExpressionSyntax)SyntaxFactory.ParseExpression("5.r");
            b = (MemberAccessExpressionSyntax)SyntaxFactory.ParseExpression("6.r");
            Assert.IsFalse(flad.LanguageServiceProvider.MemberAccessExpressionServiceProvider.NameExactlyEqual(a, b));

            a = (MemberAccessExpressionSyntax)SyntaxFactory.ParseExpression("5.r");
            b = (MemberAccessExpressionSyntax)SyntaxFactory.ParseExpression("5.r");
            Assert.IsTrue(flad.LanguageServiceProvider.MemberAccessExpressionServiceProvider.NameExactlyEqual(a, b));
        }

        [TestMethod]
        public void MemberBindingExpressionServiceProvider_NameExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = (MemberBindingExpressionSyntax)((ConditionalAccessExpressionSyntax)Microsoft.CodeAnalysis.CSharp.SyntaxFactory.ParseExpression("m?.r")).WhenNotNull;
            var b = (MemberBindingExpressionSyntax)((ConditionalAccessExpressionSyntax)Microsoft.CodeAnalysis.CSharp.SyntaxFactory.ParseExpression("m?.R")).WhenNotNull;
            Assert.IsFalse(flad.LanguageServiceProvider.MemberBindingExpressionServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.MemberBindingExpressionServiceProvider.NameExactlyEqual(a, (MemberBindingExpressionSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.MemberBindingExpressionServiceProvider.NameExactlyEqual(null, (MemberBindingExpressionSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.MemberBindingExpressionServiceProvider.NameExactlyEqual(a, b));

            a = (MemberBindingExpressionSyntax)((ConditionalAccessExpressionSyntax)Microsoft.CodeAnalysis.CSharp.SyntaxFactory.ParseExpression("m?.r")).WhenNotNull;
            b = (MemberBindingExpressionSyntax)((ConditionalAccessExpressionSyntax)Microsoft.CodeAnalysis.CSharp.SyntaxFactory.ParseExpression("m?.r")).WhenNotNull;
            Assert.IsTrue(flad.LanguageServiceProvider.MemberBindingExpressionServiceProvider.NameExactlyEqual(a, b));
        }

        [TestMethod]
        public void QueryExpressionServiceProvider_NameExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = (QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s where f.A select f.R");
            var b = (QueryExpressionSyntax)SyntaxFactory.ParseExpression("from F in s where f.A select f.R");
            Assert.IsFalse(flad.LanguageServiceProvider.QueryExpressionServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.QueryExpressionServiceProvider.NameExactlyEqual(a, (QueryExpressionSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.QueryExpressionServiceProvider.NameExactlyEqual(null, (QueryExpressionSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.QueryExpressionServiceProvider.NameExactlyEqual(a, b));

            a = (QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s where f.A select f.R");
            b = (QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s where f.A select f.R");
            Assert.IsTrue(flad.LanguageServiceProvider.QueryExpressionServiceProvider.NameExactlyEqual(a, b));
        }

        [TestMethod]
        public void AliasQualifiedNameServiceProvider_NameExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = (AliasQualifiedNameSyntax)SyntaxFactory.ParseExpression("global::c");
            var b = (AliasQualifiedNameSyntax)SyntaxFactory.ParseExpression("global::C");
            Assert.IsFalse(flad.LanguageServiceProvider.AliasQualifiedNameServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.AliasQualifiedNameServiceProvider.NameExactlyEqual(a, (AliasQualifiedNameSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.AliasQualifiedNameServiceProvider.NameExactlyEqual(null, (AliasQualifiedNameSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.AliasQualifiedNameServiceProvider.NameExactlyEqual(a, b));

            a = (AliasQualifiedNameSyntax)SyntaxFactory.ParseExpression("global::C");
            b = (AliasQualifiedNameSyntax)SyntaxFactory.ParseExpression("global::c");
            Assert.IsFalse(flad.LanguageServiceProvider.AliasQualifiedNameServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.AliasQualifiedNameServiceProvider.NameExactlyEqual(a, (AliasQualifiedNameSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.AliasQualifiedNameServiceProvider.NameExactlyEqual(null, (AliasQualifiedNameSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.AliasQualifiedNameServiceProvider.NameExactlyEqual(a, b));

            a = (AliasQualifiedNameSyntax)SyntaxFactory.ParseExpression("globalx::c");
            b = (AliasQualifiedNameSyntax)SyntaxFactory.ParseExpression("global::c");
            Assert.IsFalse(flad.LanguageServiceProvider.AliasQualifiedNameServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.AliasQualifiedNameServiceProvider.NameExactlyEqual(a, (AliasQualifiedNameSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.AliasQualifiedNameServiceProvider.NameExactlyEqual(null, (AliasQualifiedNameSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.AliasQualifiedNameServiceProvider.NameExactlyEqual(a, b));

            a = (AliasQualifiedNameSyntax)SyntaxFactory.ParseExpression("global::c");
            b = (AliasQualifiedNameSyntax)SyntaxFactory.ParseExpression("globalx::c");
            Assert.IsFalse(flad.LanguageServiceProvider.AliasQualifiedNameServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.AliasQualifiedNameServiceProvider.NameExactlyEqual(a, (AliasQualifiedNameSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.AliasQualifiedNameServiceProvider.NameExactlyEqual(null, (AliasQualifiedNameSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.AliasQualifiedNameServiceProvider.NameExactlyEqual(a, b));

            a = (AliasQualifiedNameSyntax)SyntaxFactory.ParseExpression("global::c");
            b = (AliasQualifiedNameSyntax)SyntaxFactory.ParseExpression("global::c");
            Assert.IsTrue(flad.LanguageServiceProvider.AliasQualifiedNameServiceProvider.NameExactlyEqual(a, b));
        }

        [TestMethod]
        public void IdentifierNameServiceProvider_NameExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = (IdentifierNameSyntax)SyntaxFactory.ParseName("varx");
            var b = (IdentifierNameSyntax)SyntaxFactory.ParseName("var");
            Assert.IsFalse(flad.LanguageServiceProvider.IdentifierNameServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.IdentifierNameServiceProvider.NameExactlyEqual(a, (IdentifierNameSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.IdentifierNameServiceProvider.NameExactlyEqual(null, (IdentifierNameSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.IdentifierNameServiceProvider.NameExactlyEqual(a, b));

            a = (IdentifierNameSyntax)SyntaxFactory.ParseName("var");
            b = (IdentifierNameSyntax)SyntaxFactory.ParseName("var");
            Assert.IsTrue(flad.LanguageServiceProvider.IdentifierNameServiceProvider.NameExactlyEqual(a, b));
        }

        [TestMethod]
        public void GenericNameServiceProvider_NameExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = (GenericNameSyntax)SyntaxFactory.ParseName("a<,>");
            var b = (GenericNameSyntax)SyntaxFactory.ParseName("a<T>");
            Assert.IsFalse(flad.LanguageServiceProvider.GenericNameServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.GenericNameServiceProvider.NameExactlyEqual(a, (GenericNameSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.GenericNameServiceProvider.NameExactlyEqual(null, (GenericNameSyntax)null));
            Assert.IsTrue(flad.LanguageServiceProvider.GenericNameServiceProvider.NameExactlyEqual(a, b));

            a = (GenericNameSyntax)SyntaxFactory.ParseName("a<T>");
            b = (GenericNameSyntax)SyntaxFactory.ParseName("a<,>");
            Assert.IsFalse(flad.LanguageServiceProvider.GenericNameServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.GenericNameServiceProvider.NameExactlyEqual(a, (GenericNameSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.GenericNameServiceProvider.NameExactlyEqual(null, (GenericNameSyntax)null));
            Assert.IsTrue(flad.LanguageServiceProvider.GenericNameServiceProvider.NameExactlyEqual(a, b));

            a = (GenericNameSyntax)SyntaxFactory.ParseName("a<,>");
            b = (GenericNameSyntax)SyntaxFactory.ParseName("a<,>");
            Assert.IsFalse(flad.LanguageServiceProvider.GenericNameServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.GenericNameServiceProvider.NameExactlyEqual(a, (GenericNameSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.GenericNameServiceProvider.NameExactlyEqual(null, (GenericNameSyntax)null));
            Assert.IsTrue(flad.LanguageServiceProvider.GenericNameServiceProvider.NameExactlyEqual(a, b));

            a = (GenericNameSyntax)SyntaxFactory.ParseName("a<T>");
            b = (GenericNameSyntax)SyntaxFactory.ParseName("a<K>");
            Assert.IsFalse(flad.LanguageServiceProvider.GenericNameServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.GenericNameServiceProvider.NameExactlyEqual(a, (GenericNameSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.GenericNameServiceProvider.NameExactlyEqual(null, (GenericNameSyntax)null));
            Assert.IsTrue(flad.LanguageServiceProvider.GenericNameServiceProvider.NameExactlyEqual(a, b));

            a = (GenericNameSyntax)SyntaxFactory.ParseName("b<T>");
            b = (GenericNameSyntax)SyntaxFactory.ParseName("a<T>");
            Assert.IsFalse(flad.LanguageServiceProvider.GenericNameServiceProvider.NameExactlyEqual(a, b));

            a = (GenericNameSyntax)SyntaxFactory.ParseName("a<T>");
            b = (GenericNameSyntax)SyntaxFactory.ParseName("a<T>");
            Assert.IsTrue(flad.LanguageServiceProvider.GenericNameServiceProvider.NameExactlyEqual(a, b));
        }

        [TestMethod]
        public void SimpleLambdaExpressionServiceProvider_NameExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = (SimpleLambdaExpressionSyntax)SyntaxFactory.ParseExpression("e => 4 }");
            var b = (SimpleLambdaExpressionSyntax)SyntaxFactory.ParseExpression("E => 4 }");
            Assert.IsFalse(flad.LanguageServiceProvider.SimpleLambdaExpressionServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.SimpleLambdaExpressionServiceProvider.NameExactlyEqual(a, (SimpleLambdaExpressionSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.SimpleLambdaExpressionServiceProvider.NameExactlyEqual(null, (SimpleLambdaExpressionSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.SimpleLambdaExpressionServiceProvider.NameExactlyEqual(a, b));

            a = (SimpleLambdaExpressionSyntax)SyntaxFactory.ParseExpression("e => 4 }");
            b = (SimpleLambdaExpressionSyntax)SyntaxFactory.ParseExpression("e => 4 }");
            Assert.IsTrue(flad.LanguageServiceProvider.SimpleLambdaExpressionServiceProvider.NameExactlyEqual(a, b));
        }

        [TestMethod]
        public void FromClauseServiceProvider_NameExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = ((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s where f.A select f.R")).FromClause;
            var b = ((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from F in s where f.A select f.R")).FromClause;
            Assert.IsFalse(flad.LanguageServiceProvider.FromClauseServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.FromClauseServiceProvider.NameExactlyEqual(a, (FromClauseSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.FromClauseServiceProvider.NameExactlyEqual(null, (FromClauseSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.FromClauseServiceProvider.NameExactlyEqual(a, b));

            a = ((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s where f.A select f.R")).FromClause;
            b = ((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s where f.A select f.R")).FromClause;
            Assert.IsTrue(flad.LanguageServiceProvider.FromClauseServiceProvider.NameExactlyEqual(a, b));
        }

        [TestMethod]
        public void LetClauseServiceProvider_NameExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = (LetClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from A f in s let y = 5")).Body.Clauses[0];
            var b = (LetClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from A f in s let Y = 5")).Body.Clauses[0];
            Assert.IsFalse(flad.LanguageServiceProvider.LetClauseServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.LetClauseServiceProvider.NameExactlyEqual(a, (LetClauseSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.LetClauseServiceProvider.NameExactlyEqual(null, (LetClauseSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.LetClauseServiceProvider.NameExactlyEqual(a, b));

            a = (LetClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from A f in s let y = 5")).Body.Clauses[0];
            b = (LetClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from A f in s let y = 5")).Body.Clauses[0];
            Assert.IsTrue(flad.LanguageServiceProvider.LetClauseServiceProvider.NameExactlyEqual(a, b));
        }

        [TestMethod]
        public void JoinClauseServiceProvider_NameExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = (JoinClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s join T t in F on t.L equals s.R into y")).Body.Clauses[0];
            var b = (JoinClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s join T s in F on t.L equals s.R into y")).Body.Clauses[0];
            Assert.IsFalse(flad.LanguageServiceProvider.JoinClauseServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.JoinClauseServiceProvider.NameExactlyEqual(a, (JoinClauseSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.JoinClauseServiceProvider.NameExactlyEqual(null, (JoinClauseSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.JoinClauseServiceProvider.NameExactlyEqual(a, b));

            a = (JoinClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s join T t in F on t.L equals s.R into y")).Body.Clauses[0];
            b = (JoinClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s join T t in F on t.L equals s.R into y")).Body.Clauses[0];
            Assert.IsTrue(flad.LanguageServiceProvider.JoinClauseServiceProvider.NameExactlyEqual(a, b));
        }

        [TestMethod]
        public void LocalFunctionStatementServiceProvider_NameExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = (LocalFunctionStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit(@"
            void m()
            {
                int Local() => 0;
            }").Members[0]).Body.Statements[0];
            var b = (LocalFunctionStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit(@"
            void m()
            {
                int local() => 0;
            }").Members[0]).Body.Statements[0];
            Assert.IsFalse(flad.LanguageServiceProvider.LocalFunctionStatementServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.LocalFunctionStatementServiceProvider.NameExactlyEqual(a, (LocalFunctionStatementSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.LocalFunctionStatementServiceProvider.NameExactlyEqual(null, (LocalFunctionStatementSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.LocalFunctionStatementServiceProvider.NameExactlyEqual(a, b));

            a = (LocalFunctionStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit(@"
            void m()
            {
                int local() => 0;
            }").Members[0]).Body.Statements[0];
            b = (LocalFunctionStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit(@"
            void m()
            {
                int local() => 0;
            }").Members[0]).Body.Statements[0];
            Assert.IsTrue(flad.LanguageServiceProvider.LocalFunctionStatementServiceProvider.NameExactlyEqual(a, b));
        }

        [TestMethod]
        public void LocalDeclarationStatementServiceProvider_NameExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = (LocalDeclarationStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int a() { const int a; }").Members[0]).Body.Statements[0];
            var b = (LocalDeclarationStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int a() { const int A; }").Members[0]).Body.Statements[0];
            Assert.IsFalse(flad.LanguageServiceProvider.LocalDeclarationStatementServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.LocalDeclarationStatementServiceProvider.NameExactlyEqual(a, (LocalDeclarationStatementSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.LocalDeclarationStatementServiceProvider.NameExactlyEqual(null, (LocalDeclarationStatementSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.LocalDeclarationStatementServiceProvider.NameExactlyEqual(a, b));

            a = (LocalDeclarationStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int a() { const int a; }").Members[0]).Body.Statements[0];
            b = (LocalDeclarationStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int a() { const int a; }").Members[0]).Body.Statements[0];
            Assert.IsTrue(flad.LanguageServiceProvider.LocalDeclarationStatementServiceProvider.NameExactlyEqual(a, b));
        }

        [TestMethod]
        public void LabeledStatementServiceProvider_NameExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = (LabeledStatementSyntax)SyntaxFactory.ParseStatement("l: 3");
            var b = (LabeledStatementSyntax)SyntaxFactory.ParseStatement("L: 3");
            Assert.IsFalse(flad.LanguageServiceProvider.LabeledStatementServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.LabeledStatementServiceProvider.NameExactlyEqual(a, (LabeledStatementSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.LabeledStatementServiceProvider.NameExactlyEqual(null, (LabeledStatementSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.LabeledStatementServiceProvider.NameExactlyEqual(a, b));

            a = (LabeledStatementSyntax)SyntaxFactory.ParseStatement("l: 3");
            b = (LabeledStatementSyntax)SyntaxFactory.ParseStatement("l: 3");
            Assert.IsTrue(flad.LanguageServiceProvider.LabeledStatementServiceProvider.NameExactlyEqual(a, b));
        }

        [TestMethod]
        public void ForStatementServiceProvider_NameExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = (ForStatementSyntax)SyntaxFactory.ParseStatement("for(int A, b = 4; a < 0; a++, --b);");
            var b = (ForStatementSyntax)SyntaxFactory.ParseStatement("for(int a, b = 4; a < 0; a++, --b);");
            Assert.IsFalse(flad.LanguageServiceProvider.ForStatementServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.ForStatementServiceProvider.NameExactlyEqual(a, (ForStatementSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.ForStatementServiceProvider.NameExactlyEqual(null, (ForStatementSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.ForStatementServiceProvider.NameExactlyEqual(a, b));

            a = (ForStatementSyntax)SyntaxFactory.ParseStatement("for(int a = 4; a < 0; --b);");
            b = (ForStatementSyntax)SyntaxFactory.ParseStatement("for(int b = 4; a < 0; --b);");
            Assert.IsFalse(flad.LanguageServiceProvider.ForStatementServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.ForStatementServiceProvider.NameExactlyEqual(a, (ForStatementSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.ForStatementServiceProvider.NameExactlyEqual(null, (ForStatementSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.ForStatementServiceProvider.NameExactlyEqual(a, b));

            a = (ForStatementSyntax)SyntaxFactory.ParseStatement("for(int a, b = 4; a < 0; a++, --b);");
            b = (ForStatementSyntax)SyntaxFactory.ParseStatement("for(int a, b = 4; a < 0; a++, --b);");
            Assert.IsTrue(flad.LanguageServiceProvider.ForStatementServiceProvider.NameExactlyEqual(a, b));

            a = (ForStatementSyntax)SyntaxFactory.ParseStatement("for(int a = 4; a < 0; --b);");
            b = (ForStatementSyntax)SyntaxFactory.ParseStatement("for(int a = 4; a < 0; --b);");
            Assert.IsTrue(flad.LanguageServiceProvider.ForStatementServiceProvider.NameExactlyEqual(a, b));
        }

        [TestMethod]
        public void UsingStatementServiceProvider_NameExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = (UsingStatementSyntax)SyntaxFactory.ParseStatement("using(int A, b = 4);");
            var b = (UsingStatementSyntax)SyntaxFactory.ParseStatement("using(int a, b = 4);");
            Assert.IsFalse(flad.LanguageServiceProvider.UsingStatementServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.UsingStatementServiceProvider.NameExactlyEqual(a, (UsingStatementSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.UsingStatementServiceProvider.NameExactlyEqual(null, (UsingStatementSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.UsingStatementServiceProvider.NameExactlyEqual(a, b));

            a = (UsingStatementSyntax)SyntaxFactory.ParseStatement("using(int a = 4);");
            b = (UsingStatementSyntax)SyntaxFactory.ParseStatement("using(int b = 4);");
            Assert.IsFalse(flad.LanguageServiceProvider.UsingStatementServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.UsingStatementServiceProvider.NameExactlyEqual(a, (UsingStatementSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.UsingStatementServiceProvider.NameExactlyEqual(null, (UsingStatementSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.UsingStatementServiceProvider.NameExactlyEqual(a, b));

            a = (UsingStatementSyntax)SyntaxFactory.ParseStatement("using(int a, b = 4);");
            b = (UsingStatementSyntax)SyntaxFactory.ParseStatement("using(int a, b = 4);");
            Assert.IsTrue(flad.LanguageServiceProvider.UsingStatementServiceProvider.NameExactlyEqual(a, b));

            a = (UsingStatementSyntax)SyntaxFactory.ParseStatement("using(int a = 4);");
            b = (UsingStatementSyntax)SyntaxFactory.ParseStatement("using(int a = 4);");
            Assert.IsTrue(flad.LanguageServiceProvider.UsingStatementServiceProvider.NameExactlyEqual(a, b));
        }

        [TestMethod]
        public void FixedStatementServiceProvider_NameExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = (FixedStatementSyntax)SyntaxFactory.ParseStatement("fixed(int A, b = 4);");
            var b = (FixedStatementSyntax)SyntaxFactory.ParseStatement("fixed(int a, b = 4);");
            Assert.IsFalse(flad.LanguageServiceProvider.FixedStatementServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.FixedStatementServiceProvider.NameExactlyEqual(a, (FixedStatementSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.FixedStatementServiceProvider.NameExactlyEqual(null, (FixedStatementSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.FixedStatementServiceProvider.NameExactlyEqual(a, b));

            a = (FixedStatementSyntax)SyntaxFactory.ParseStatement("fixed(int a = 4);");
            b = (FixedStatementSyntax)SyntaxFactory.ParseStatement("fixed(int b = 4);");
            Assert.IsFalse(flad.LanguageServiceProvider.FixedStatementServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.FixedStatementServiceProvider.NameExactlyEqual(a, (FixedStatementSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.FixedStatementServiceProvider.NameExactlyEqual(null, (FixedStatementSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.FixedStatementServiceProvider.NameExactlyEqual(a, b));

            a = (FixedStatementSyntax)SyntaxFactory.ParseStatement("fixed(int a, b = 4);");
            b = (FixedStatementSyntax)SyntaxFactory.ParseStatement("fixed(int a, b = 4);");
            Assert.IsTrue(flad.LanguageServiceProvider.FixedStatementServiceProvider.NameExactlyEqual(a, b));

            a = (FixedStatementSyntax)SyntaxFactory.ParseStatement("fixed(int a = 4);");
            b = (FixedStatementSyntax)SyntaxFactory.ParseStatement("fixed(int a = 4);");
            Assert.IsTrue(flad.LanguageServiceProvider.FixedStatementServiceProvider.NameExactlyEqual(a, b));
        }

        [TestMethod]
        public void ForEachStatementServiceProvider_NameExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = (ForEachStatementSyntax)SyntaxFactory.ParseStatement("foreach(int b in ac);");
            var b = (ForEachStatementSyntax)SyntaxFactory.ParseStatement("foreach(int a in ac);");
            Assert.IsFalse(flad.LanguageServiceProvider.ForEachStatementServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.ForEachStatementServiceProvider.NameExactlyEqual(a, (ForEachStatementSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.ForEachStatementServiceProvider.NameExactlyEqual(null, (ForEachStatementSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.ForEachStatementServiceProvider.NameExactlyEqual(a, b));

            a = (ForEachStatementSyntax)SyntaxFactory.ParseStatement("foreach(int a in ac);");
            b = (ForEachStatementSyntax)SyntaxFactory.ParseStatement("foreach(int a in ac);");
            Assert.IsTrue(flad.LanguageServiceProvider.ForEachStatementServiceProvider.NameExactlyEqual(a, b));
        }

        [TestMethod]
        public void SingleVariableDesignationServiceProvider_NameExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = (SingleVariableDesignationSyntax)SyntaxFactory.SingleVariableDesignation(SyntaxFactory.Identifier("a"));
            var b = (SingleVariableDesignationSyntax)SyntaxFactory.SingleVariableDesignation(SyntaxFactory.Identifier("b"));
            Assert.IsFalse(flad.LanguageServiceProvider.SingleVariableDesignationServiceProvider.NameExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.SingleVariableDesignationServiceProvider.NameExactlyEqual(a, (SingleVariableDesignationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.SingleVariableDesignationServiceProvider.NameExactlyEqual(null, (SingleVariableDesignationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.SingleVariableDesignationServiceProvider.NameExactlyEqual(a, b));

            a = (SingleVariableDesignationSyntax)SyntaxFactory.SingleVariableDesignation(SyntaxFactory.Identifier("a"));
            b = (SingleVariableDesignationSyntax)SyntaxFactory.SingleVariableDesignation(SyntaxFactory.Identifier("a"));
            Assert.IsTrue(flad.LanguageServiceProvider.SingleVariableDesignationServiceProvider.NameExactlyEqual(a, b));
        }
    }
}
