﻿using System;
using System.Linq;
using System.Reflection;
using Jawilliam.CDF.Approach.Awareness;
using Jawilliam.CDF.Approach.Criterions;
using Jawilliam.CDF.Approach.Services;
using Jawilliam.CDF.CSharp;
using Jawilliam.CDF.CSharp.Flad;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jawilliam.CDF.Tests.CSharp
{
    [TestClass]
    public class NameEqualityServicesTests
    {
        [TestMethod]
        public void AttributeArgumentServiceProvider_NameEqualityMatch_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(\"X\")]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0];
            var b = SyntaxFactory.ParseCompilationUnit("[module: YAttribute(\"Y\")]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0];
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AttributeArgumentServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AttributeArgumentServiceProvider.NameEqualityMatch(a, null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AttributeArgumentServiceProvider.NameEqualityMatch(null, null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AttributeArgumentServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(x = \"X\")]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0];
            b = SyntaxFactory.ParseCompilationUnit("[module: YAttribute(\"Y\")]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0];
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AttributeArgumentServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(\"X\")]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0];
            b = SyntaxFactory.ParseCompilationUnit("[module: YAttribute(x = \"Y\")]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0];
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AttributeArgumentServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(x = \"X\")]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0];
            b = SyntaxFactory.ParseCompilationUnit("[module: YAttribute(y = \"Y\")]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0];
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AttributeArgumentServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(x = \"X\")]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0];
            b = SyntaxFactory.ParseCompilationUnit("[module: YAttribute(x = \"Y\")]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0];
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AttributeArgumentServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);

            a = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(x: \"X\")]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0];
            b = SyntaxFactory.ParseCompilationUnit("[module: YAttribute(\"Y\")]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0];
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AttributeArgumentServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(\"X\")]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0];
            b = SyntaxFactory.ParseCompilationUnit("[module: YAttribute(x: \"Y\")]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0];
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AttributeArgumentServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(x: \"X\")]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0];
            b = SyntaxFactory.ParseCompilationUnit("[module: YAttribute(y: \"Y\")]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0];
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AttributeArgumentServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(x: \"X\")]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0];
            b = SyntaxFactory.ParseCompilationUnit("[module: YAttribute(x: \"Y\")]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0];
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AttributeArgumentServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);

            a = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(x= \"X\")]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0];
            b = SyntaxFactory.ParseCompilationUnit("[module: YAttribute(y: \"Y\")]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0];
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AttributeArgumentServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(x: \"X\")]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0];
            b = SyntaxFactory.ParseCompilationUnit("[module: YAttribute(y= \"Y\")]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0];
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AttributeArgumentServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(x: \"X\")]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0];
            b = SyntaxFactory.ParseCompilationUnit("[module: YAttribute(x= \"Y\")]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0];
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AttributeArgumentServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);

            a = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(x= \"X\")]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0];
            b = SyntaxFactory.ParseCompilationUnit("[module: YAttribute(x: \"Y\")]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0];
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AttributeArgumentServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);
        }

        [TestMethod]
        public void NameEqualsServiceProvider_NameEqualityMatch_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(\"X\")]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0].NameEquals;
            var b = SyntaxFactory.ParseCompilationUnit("[module: YAttribute(\"Y\")]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0].NameEquals;
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().NameEqualsServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().NameEqualsServiceProvider.NameEqualityMatch(a, (NameEqualsSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().NameEqualsServiceProvider.NameEqualityMatch(null, (NameEqualsSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().NameEqualsServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(x = \"X\")]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0].NameEquals;
            b = SyntaxFactory.ParseCompilationUnit("[module: YAttribute(y = \"Y\")]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0].NameEquals;
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().NameEqualsServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(x = \"X\")]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0].NameEquals;
            b = SyntaxFactory.ParseCompilationUnit("[module: YAttribute(x = \"Y\")]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0].NameEquals;
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().NameEqualsServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);
        }

        [TestMethod]
        public void TypeParameterServiceProvider_NameEqualityMatch_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<B> {}").Members[0]).TypeParameterList.Parameters[0];
            var b = ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<C> {}").Members[0]).TypeParameterList.Parameters[0];
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().TypeParameterServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().TypeParameterServiceProvider.NameEqualityMatch(a, null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().TypeParameterServiceProvider.NameEqualityMatch(null, null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().TypeParameterServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<B> {}").Members[0]).TypeParameterList.Parameters[0];
            b = ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class b<B> {}").Members[0]).TypeParameterList.Parameters[0];
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().TypeParameterServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);
        }

        [TestMethod]
        public void TypeParameterConstraintClauseServiceProvider_NameEqualityMatch_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<T> : byte where T : new(), class, struct, A{};").Members[0]).ConstraintClauses[0];
            var b = ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<T> : byte where K : new(), class, struct, A{};").Members[0]).ConstraintClauses[0];
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().TypeParameterConstraintClauseServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().TypeParameterConstraintClauseServiceProvider.NameEqualityMatch(a, null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().TypeParameterConstraintClauseServiceProvider.NameEqualityMatch(null, null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().TypeParameterConstraintClauseServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<T> : byte where T : new(), class, struct, A{};").Members[0]).ConstraintClauses[0];
            b = ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<T> : byte where T : new(), class, struct, A{};").Members[0]).ConstraintClauses[0];
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().TypeParameterConstraintClauseServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);
        }

        [TestMethod]
        public void ExplicitInterfaceSpecifierServiceProvider_NameEqualityMatch_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = ((EventDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a {event B IA.a1{add; remove;}}").Members[0]).Members[0]).ExplicitInterfaceSpecifier;
            var b = ((EventDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a {event B IB.a1{add; remove;}}").Members[0]).Members[0]).ExplicitInterfaceSpecifier;
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().ExplicitInterfaceSpecifierServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().ExplicitInterfaceSpecifierServiceProvider.NameEqualityMatch(a, null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().ExplicitInterfaceSpecifierServiceProvider.NameEqualityMatch(null, null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().ExplicitInterfaceSpecifierServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = ((EventDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a {event B IA.a1{add; remove;}}").Members[0]).Members[0]).ExplicitInterfaceSpecifier;
            b = ((EventDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a {event B IA.a1{add; remove;}}").Members[0]).Members[0]).ExplicitInterfaceSpecifier;
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().ExplicitInterfaceSpecifierServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);
        }

        [TestMethod]
        public void ParameterServiceProvider_NameEqualityMatch_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = ((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int M([Serializable] ref int a = 0, A b){}").Members[0]).ParameterList.Parameters[0];
            var b = ((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int M([Serializable] ref int b = 0, A b){}").Members[0]).ParameterList.Parameters[0];
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().ParameterServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().ParameterServiceProvider.NameEqualityMatch(a, null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().ParameterServiceProvider.NameEqualityMatch(null, null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().ParameterServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = ((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int M([Serializable] ref int a = 0, A b){}").Members[0]).ParameterList.Parameters[0];
            b = ((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int M([Serializable] ref int a = 0, A c){}").Members[0]).ParameterList.Parameters[0];
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().ParameterServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);
        }

        [TestMethod]
        public void XmlElementStartTagServiceProvider_NameEqualityMatch_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag;
            var b = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<Message id=\"5\" oid=\"3\">Hello World</Message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag;
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlElementStartTagServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlElementStartTagServiceProvider.NameEqualityMatch(a, null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlElementStartTagServiceProvider.NameEqualityMatch(null, null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlElementStartTagServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag;
            b = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag;
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlElementStartTagServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);

            a = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<i:message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag;
            b = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<i:Message id=\"5\" oid=\"3\">Hello World</Message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag;
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlElementStartTagServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlElementStartTagServiceProvider.NameEqualityMatch(a, null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlElementStartTagServiceProvider.NameEqualityMatch(null, null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlElementStartTagServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<i:message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag;
            b = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<j:message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag;
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlElementStartTagServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<i:message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag;
            b = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<i:message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag;
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlElementStartTagServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);
        }

        [TestMethod]
        public void XmlElementEndTagServiceProvider_NameEqualityMatch_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().EndTag;
            var b = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<Message id=\"5\" oid=\"3\">Hello World</Message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().EndTag;
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlElementEndTagServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlElementEndTagServiceProvider.NameEqualityMatch(a, null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlElementEndTagServiceProvider.NameEqualityMatch(null, null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlElementEndTagServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().EndTag;
            b = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().EndTag;
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlElementEndTagServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);

            a = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<i:message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().EndTag;
            b = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<i:Message id=\"5\" oid=\"3\">Hello World</Message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().EndTag;
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlElementEndTagServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlElementEndTagServiceProvider.NameEqualityMatch(a, null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlElementEndTagServiceProvider.NameEqualityMatch(null, null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlElementEndTagServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<i:message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().EndTag;
            b = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<j:message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().EndTag;
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlElementEndTagServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);

            a = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<i:message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().EndTag;
            b = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<i:message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().EndTag;
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlElementEndTagServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);
        }

        [TestMethod]
        public void XmlNameServiceProvider_NameEqualityMatch_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag.Name;
            var b = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<Message id=\"5\" oid=\"3\">Hello World</Message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag.Name;
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlNameServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlNameServiceProvider.NameEqualityMatch(a, null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlNameServiceProvider.NameEqualityMatch(null, null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlNameServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag.Name;
            b = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag.Name;
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlNameServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);

            a = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<i:message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag.Name;
            b = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<i:Message id=\"5\" oid=\"3\">Hello World</Message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag.Name;
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlNameServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlNameServiceProvider.NameEqualityMatch(a, null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlNameServiceProvider.NameEqualityMatch(null, null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlNameServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<i:message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag.Name;
            b = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<j:message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag.Name;
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlNameServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<i:message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag.Name;
            b = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<i:message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag.Name;
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlNameServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);
        }

        [TestMethod]
        public void XmlPrefixServiceProvider_NameEqualityMatch_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag.Name.Prefix;
            var b = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<Message id=\"5\" oid=\"3\">Hello World</Message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag.Name.Prefix;
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlPrefixServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlPrefixServiceProvider.NameEqualityMatch(a, null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlPrefixServiceProvider.NameEqualityMatch(null, null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlPrefixServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag.Name.Prefix;
            b = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag.Name.Prefix;
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlPrefixServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<i:message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag.Name.Prefix;
            b = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<i:Message id=\"5\" oid=\"3\">Hello World</Message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag.Name.Prefix;
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlPrefixServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlPrefixServiceProvider.NameEqualityMatch(a, null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlPrefixServiceProvider.NameEqualityMatch(null, null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlPrefixServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);

            a = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<i:message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag.Name.Prefix;
            b = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<j:message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag.Name.Prefix;
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlPrefixServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<i:message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag.Name.Prefix;
            b = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<i:message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag.Name.Prefix;
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlPrefixServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);
        }

        [TestMethod]
        public void TupleElementServiceProvider_NameEqualityMatch_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = SyntaxFactory.TupleElement(SyntaxFactory.ParseTypeName("(string, int)"), SyntaxFactory.Identifier("a"));
            var b = SyntaxFactory.TupleElement(SyntaxFactory.ParseTypeName("(string, int)"), SyntaxFactory.Identifier("b"));
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().TupleElementServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().TupleElementServiceProvider.NameEqualityMatch(a, null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().TupleElementServiceProvider.NameEqualityMatch(null, null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().TupleElementServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = SyntaxFactory.TupleElement(SyntaxFactory.ParseTypeName("(string, int)"));
            b = SyntaxFactory.TupleElement(SyntaxFactory.ParseTypeName("(string, int)"));
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().TupleElementServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().TupleElementServiceProvider.NameEqualityMatch(a, null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().TupleElementServiceProvider.NameEqualityMatch(null, null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().TupleElementServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = SyntaxFactory.TupleElement(SyntaxFactory.ParseTypeName("(string, int)"), SyntaxFactory.Identifier("a"));
            b = SyntaxFactory.TupleElement(SyntaxFactory.ParseTypeName("(string, int)"), SyntaxFactory.Identifier("a"));
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().TupleElementServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);
        }

        [TestMethod]
        public void ArgumentServiceProvider_NameEqualityMatch_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = ((InvocationExpressionSyntax)SyntaxFactory.ParseExpression("f(3)")).ArgumentList.Arguments[0];
            var b = ((InvocationExpressionSyntax)SyntaxFactory.ParseExpression("f(3)")).ArgumentList.Arguments[0];
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().ArgumentServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().ArgumentServiceProvider.NameEqualityMatch(a, null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().ArgumentServiceProvider.NameEqualityMatch(null, null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().ArgumentServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = ((InvocationExpressionSyntax)SyntaxFactory.ParseExpression("f(arg1: 3)")).ArgumentList.Arguments[0];
            b = ((InvocationExpressionSyntax)SyntaxFactory.ParseExpression("f(arg2: 3)")).ArgumentList.Arguments[0];
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().ArgumentServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().ArgumentServiceProvider.NameEqualityMatch(a, null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().ArgumentServiceProvider.NameEqualityMatch(null, null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().ArgumentServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = ((InvocationExpressionSyntax)SyntaxFactory.ParseExpression("f(arg: 3)")).ArgumentList.Arguments[0];
            b = ((InvocationExpressionSyntax)SyntaxFactory.ParseExpression("f(arg: 3)")).ArgumentList.Arguments[0];
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().ArgumentServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);
        }

        [TestMethod]
        public void NameColonServiceProvider_NameEqualityMatch_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(\"X\")]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0].NameColon;
            var b = SyntaxFactory.ParseCompilationUnit("[module: YAttribute(\"Y\")]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0].NameColon;
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().NameColonServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().NameColonServiceProvider.NameEqualityMatch(a, (NameColonSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().NameColonServiceProvider.NameEqualityMatch(null, (NameColonSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().NameColonServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(x : \"X\")]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0].NameColon;
            b = SyntaxFactory.ParseCompilationUnit("[module: YAttribute(y : \"Y\")]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0].NameColon;
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().NameColonServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(x : \"X\")]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0].NameColon;
            b = SyntaxFactory.ParseCompilationUnit("[module: YAttribute(x : \"Y\")]").AttributeLists[0].Attributes[0].ArgumentList.Arguments[0].NameColon;
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().NameColonServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);
        }

        [TestMethod]
        public void AnonymousObjectMemberDeclaratorServiceProvider_NameEqualityMatch_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = ((AnonymousObjectCreationExpressionSyntax)SyntaxFactory.ParseExpression("new { x.Text }")).Initializers[0];
            var b = ((AnonymousObjectCreationExpressionSyntax)SyntaxFactory.ParseExpression("new { x.Text }")).Initializers[0];
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AnonymousObjectMemberDeclaratorServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AnonymousObjectMemberDeclaratorServiceProvider.NameEqualityMatch(a, (AnonymousObjectMemberDeclaratorSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AnonymousObjectMemberDeclaratorServiceProvider.NameEqualityMatch(null, (AnonymousObjectMemberDeclaratorSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AnonymousObjectMemberDeclaratorServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = ((AnonymousObjectCreationExpressionSyntax)SyntaxFactory.ParseExpression("new { Text = x.Text }")).Initializers[0];
            b = ((AnonymousObjectCreationExpressionSyntax)SyntaxFactory.ParseExpression("new { iText = x.Text }")).Initializers[0];
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AnonymousObjectMemberDeclaratorServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AnonymousObjectMemberDeclaratorServiceProvider.NameEqualityMatch(a, (AnonymousObjectMemberDeclaratorSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AnonymousObjectMemberDeclaratorServiceProvider.NameEqualityMatch(null, (AnonymousObjectMemberDeclaratorSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AnonymousObjectMemberDeclaratorServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = ((AnonymousObjectCreationExpressionSyntax)SyntaxFactory.ParseExpression("new { Text = 4 }")).Initializers[0];
            b = ((AnonymousObjectCreationExpressionSyntax)SyntaxFactory.ParseExpression("new { Text = 4 }")).Initializers[0];
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AnonymousObjectMemberDeclaratorServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);
        }

        [TestMethod]
        public void QueryBodyServiceProvider_NameEqualityMatch_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = ((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s let y = 5 where f.A select f.R")).Body;
            var b = ((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s let y = 5 where f.A select f.R")).Body;
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().QueryBodyServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().QueryBodyServiceProvider.NameEqualityMatch(a, (QueryBodySyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().QueryBodyServiceProvider.NameEqualityMatch(null, (QueryBodySyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().QueryBodyServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = ((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s let y = 5 where f.A select f.R into f")).Body;
            b = ((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s let y = 5 where f.A select f.R into g")).Body;
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().QueryBodyServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().QueryBodyServiceProvider.NameEqualityMatch(a, (QueryBodySyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().QueryBodyServiceProvider.NameEqualityMatch(null, (QueryBodySyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().QueryBodyServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = ((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s let y = 5 where f.A select f.R into f")).Body;
            b = ((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s let y = 5 where f.A select f.R into f")).Body;
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().QueryBodyServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);
        }

        [TestMethod]
        public void JoinIntoClauseServiceProvider_NameEqualityMatch_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = ((JoinClauseSyntax)(((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s join prod in products on category.ID equals prod.CategoryID into f")).Body.Clauses[0])).Into;
            var b = ((JoinClauseSyntax)(((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s join prod in products on category.ID equals prod.CategoryID into g")).Body.Clauses[0])).Into;
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().JoinIntoClauseServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().JoinIntoClauseServiceProvider.NameEqualityMatch(a, (JoinIntoClauseSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().JoinIntoClauseServiceProvider.NameEqualityMatch(null, (JoinIntoClauseSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().JoinIntoClauseServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = ((JoinClauseSyntax)(((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s join prod in products on category.ID equals prod.CategoryID into f")).Body.Clauses[0])).Into;
            b = ((JoinClauseSyntax)(((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s join prod in products on category.ID equals prod.CategoryID into f")).Body.Clauses[0])).Into;
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().JoinIntoClauseServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);
        }

        [TestMethod]
        public void QueryContinuationServiceProvider_NameEqualityMatch_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = ((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s let y = 5 where f.A select f.R into f")).Body.Continuation;
            var b = ((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s let y = 5 where f.A select f.R into g")).Body.Continuation;
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().QueryContinuationServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().QueryContinuationServiceProvider.NameEqualityMatch(a, (QueryContinuationSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().QueryContinuationServiceProvider.NameEqualityMatch(null, (QueryContinuationSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().QueryContinuationServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = ((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s let y = 5 where f.A select f.R into f")).Body.Continuation;
            b = ((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s let y = 5 where f.A select f.R into f")).Body.Continuation;
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().QueryContinuationServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);
        }

        [TestMethod]
        public void VariableDeclarationServiceProvider_NameEqualityMatch_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = ((LocalDeclarationStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int v() { const int a = 4, b = 3; }").Members[0]).Body.Statements[0]).Declaration;
            var b = ((LocalDeclarationStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int v() { const int b = 4, b = 3; }").Members[0]).Body.Statements[0]).Declaration;
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().VariableDeclarationServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().VariableDeclarationServiceProvider.NameEqualityMatch(a, (VariableDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().VariableDeclarationServiceProvider.NameEqualityMatch(null, (VariableDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().VariableDeclarationServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = ((LocalDeclarationStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int v() { const int a = 4, b = 3; }").Members[0]).Body.Statements[0]).Declaration;
            b = ((LocalDeclarationStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int v() { const int a = 4, b = 3; }").Members[0]).Body.Statements[0]).Declaration;
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().VariableDeclarationServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);
        }

        [TestMethod]
        public void VariableDeclaratorServiceProvider_NameEqualityMatch_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = ((LocalDeclarationStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int v() { const int a = 4, b = 3; }").Members[0]).Body.Statements[0]).Declaration.Variables[0];
            var b = ((LocalDeclarationStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int v() { const int b = 4, b = 3; }").Members[0]).Body.Statements[0]).Declaration.Variables[0];
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().VariableDeclaratorServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().VariableDeclaratorServiceProvider.NameEqualityMatch(a, (VariableDeclaratorSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().VariableDeclaratorServiceProvider.NameEqualityMatch(null, (VariableDeclaratorSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().VariableDeclaratorServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = ((LocalDeclarationStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int v() { const int a = 4, b = 3; }").Members[0]).Body.Statements[0]).Declaration.Variables[0];
            b = ((LocalDeclarationStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int v() { const int a = 4, b = 3; }").Members[0]).Body.Statements[0]).Declaration.Variables[0];
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().VariableDeclaratorServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);
        }

        [TestMethod]
        public void CatchClauseServiceProvider_NameEqualityMatch_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = ((TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch(A1){a1 = \"Catch a1\";} catch(B1) when(e = 5) {b1 = \"Catch b1\";} finally{c1 = \"Finnally1\";}")).Catches[0];
            var b = ((TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch(A1){a1 = \"Catch a1\";} catch(B1) when(e = 5) {b1 = \"Catch b1\";} finally{c1 = \"Finnally1\";}")).Catches[0];
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().CatchClauseServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().CatchClauseServiceProvider.NameEqualityMatch(a, (CatchClauseSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().CatchClauseServiceProvider.NameEqualityMatch(null, (CatchClauseSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().CatchClauseServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = ((TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch(A1 e1){a1 = \"Catch a1\";} catch(B1) when(e = 5) {b1 = \"Catch b1\";} finally{c1 = \"Finnally1\";}")).Catches[0];
            b = ((TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch(A1 e2){a1 = \"Catch a1\";} catch(B1) when(e = 5) {b1 = \"Catch b1\";} finally{c1 = \"Finnally1\";}")).Catches[0];
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().CatchClauseServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().CatchClauseServiceProvider.NameEqualityMatch(a, (CatchClauseSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().CatchClauseServiceProvider.NameEqualityMatch(null, (CatchClauseSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().CatchClauseServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = ((TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch(A1 e1){a1 = \"Catch a1\";} catch(B1) when(e = 5) {b1 = \"Catch b1\";} finally{c1 = \"Finnally1\";}")).Catches[0];
            b = ((TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch(A1 e1){a1 = \"Catch a1\";} catch(B1) when(e = 5) {b1 = \"Catch b1\";} finally{c1 = \"Finnally1\";}")).Catches[0];
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().CatchClauseServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);
        }

        [TestMethod]
        public void CatchDeclarationServiceProvider_NameEqualityMatch_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = ((TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch(A1){a1 = \"Catch a1\";} catch(B1) when(e = 5) {b1 = \"Catch b1\";} finally{c1 = \"Finnally1\";}")).Catches[0].Declaration;
            var b = ((TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch(A1){a1 = \"Catch a1\";} catch(B1) when(e = 5) {b1 = \"Catch b1\";} finally{c1 = \"Finnally1\";}")).Catches[0].Declaration;
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().CatchDeclarationServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().CatchDeclarationServiceProvider.NameEqualityMatch(a, (CatchDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().CatchDeclarationServiceProvider.NameEqualityMatch(null, (CatchDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().CatchDeclarationServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = ((TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch(A1 e1){a1 = \"Catch a1\";} catch(B1) when(e = 5) {b1 = \"Catch b1\";} finally{c1 = \"Finnally1\";}")).Catches[0].Declaration;
            b = ((TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch(A1 e2){a1 = \"Catch a1\";} catch(B1) when(e = 5) {b1 = \"Catch b1\";} finally{c1 = \"Finnally1\";}")).Catches[0].Declaration;
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().CatchDeclarationServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().CatchDeclarationServiceProvider.NameEqualityMatch(a, (CatchDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().CatchDeclarationServiceProvider.NameEqualityMatch(null, (CatchDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().CatchDeclarationServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = ((TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch(A1 e1){a1 = \"Catch a1\";} catch(B1) when(e = 5) {b1 = \"Catch b1\";} finally{c1 = \"Finnally1\";}")).Catches[0].Declaration;
            b = ((TryStatementSyntax)SyntaxFactory.ParseStatement("try{a + 5} catch(A1 e1){a1 = \"Catch a1\";} catch(B1) when(e = 5) {b1 = \"Catch b1\";} finally{c1 = \"Finnally1\";}")).Catches[0].Declaration;
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().CatchDeclarationServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);
        }

        [TestMethod]
        public void ExternAliasDirectiveServiceProvider_NameEqualityMatch_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = SyntaxFactory.ParseCompilationUnit("extern alias a;").Externs[0];
            var b = SyntaxFactory.ParseCompilationUnit("extern alias b;").Externs[0];
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().ExternAliasDirectiveServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().ExternAliasDirectiveServiceProvider.NameEqualityMatch(a, (ExternAliasDirectiveSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().ExternAliasDirectiveServiceProvider.NameEqualityMatch(null, (ExternAliasDirectiveSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().ExternAliasDirectiveServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = SyntaxFactory.ParseCompilationUnit("extern alias a;").Externs[0];
            b = SyntaxFactory.ParseCompilationUnit("extern alias a;").Externs[0];
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().ExternAliasDirectiveServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);
        }

        [TestMethod]
        public void UsingDirectiveServiceProvider_NameEqualityMatch_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = SyntaxFactory.ParseCompilationUnit("using static a;").Usings[0];
            var b = SyntaxFactory.ParseCompilationUnit("using static b;").Usings[0];
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().UsingDirectiveServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().UsingDirectiveServiceProvider.NameEqualityMatch(a, (UsingDirectiveSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().UsingDirectiveServiceProvider.NameEqualityMatch(null, (UsingDirectiveSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().UsingDirectiveServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = SyntaxFactory.ParseCompilationUnit("using static a;").Usings[0];
            b = SyntaxFactory.ParseCompilationUnit("using static a;").Usings[0];
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().UsingDirectiveServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);

            a = SyntaxFactory.ParseCompilationUnit("using static c = a;").Usings[0];
            b = SyntaxFactory.ParseCompilationUnit("using static c1 = a;").Usings[0];
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().UsingDirectiveServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().UsingDirectiveServiceProvider.NameEqualityMatch(a, (UsingDirectiveSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().UsingDirectiveServiceProvider.NameEqualityMatch(null, (UsingDirectiveSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().UsingDirectiveServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = SyntaxFactory.ParseCompilationUnit("using static c = a;").Usings[0];
            b = SyntaxFactory.ParseCompilationUnit("using static c1 = b;").Usings[0];
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().UsingDirectiveServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().UsingDirectiveServiceProvider.NameEqualityMatch(a, (UsingDirectiveSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().UsingDirectiveServiceProvider.NameEqualityMatch(null, (UsingDirectiveSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().UsingDirectiveServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = SyntaxFactory.ParseCompilationUnit("using static c = a;").Usings[0];
            b = SyntaxFactory.ParseCompilationUnit("using static c = a;").Usings[0];
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().UsingDirectiveServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);
        }

        //[TestMethod]
        //public void AttributeListServiceProvider_NameEqualityMatch_OK()
        //{
        //    var flad = new CSharpFlad();
        //    var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
        //    MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

        //    var a = ((ClassDeclarationSyntax)(SyntaxFactory.ParseCompilationUnit("[XAttribute(\"X\"), YAttribute(Y: 3), ZAttribute(Z= 4)]class A{};").Members[0])).AttributeLists[0];
        //    var b = ((ClassDeclarationSyntax)(SyntaxFactory.ParseCompilationUnit("[XAttribute(\"X\"), YAttribute(Y: 3), ZAttribute(Z= 4)]class A{};").Members[0])).AttributeLists[0];
        //    Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AttributeListServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
        //    Assert.IsNull(matchInfo);
        //    Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AttributeListServiceProvider.NameEqualityMatch(a, (AttributeListSyntax)null, matchingContext, out matchInfo));
        //    Assert.IsNull(matchInfo);
        //    Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AttributeListServiceProvider.NameEqualityMatch(null, (AttributeListSyntax)null, matchingContext, out matchInfo));
        //    Assert.IsNull(matchInfo);
        //    Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AttributeListServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
        //    Assert.IsNotNull(matchInfo);
        //    Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
        //    Assert.AreEqual(matchInfo.Original, a);
        //    Assert.AreEqual(matchInfo.Modified, b);

        //    a = ((ClassDeclarationSyntax)(SyntaxFactory.ParseCompilationUnit("[[module: XAttribute(\"X\"), YAttribute(Y: 3), ZAttribute(Z= 4)]class A{};").Members[0])).AttributeLists[0];
        //    b = ((ClassDeclarationSyntax)(SyntaxFactory.ParseCompilationUnit("[XAttribute(\"X\"), YAttribute(Y: 3), ZAttribute(Z= 4)]class A{};").Members[0])).AttributeLists[0];
        //    Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AttributeListServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
        //    Assert.IsNull(matchInfo);
        //    Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AttributeListServiceProvider.NameEqualityMatch(a, (AttributeListSyntax)null, matchingContext, out matchInfo));
        //    Assert.IsNull(matchInfo);
        //    Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AttributeListServiceProvider.NameEqualityMatch(null, (AttributeListSyntax)null, matchingContext, out matchInfo));
        //    Assert.IsNull(matchInfo);
        //    Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AttributeListServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
        //    Assert.IsNull(matchInfo);

        //    a = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(\"X\"), YAttribute(Y: 3), ZAttribute(Z= 4)]").AttributeLists[0];
        //    b = SyntaxFactory.ParseCompilationUnit("[assembly: XAttribute(\"X\"), YAttribute(Y: 3), ZAttribute(Z= 4)]").AttributeLists[0];
        //    Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AttributeListServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
        //    Assert.IsNull(matchInfo);
        //    Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AttributeListServiceProvider.NameEqualityMatch(a, (AttributeListSyntax)null, matchingContext, out matchInfo));
        //    Assert.IsNull(matchInfo);
        //    Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AttributeListServiceProvider.NameEqualityMatch(null, (AttributeListSyntax)null, matchingContext, out matchInfo));
        //    Assert.IsNull(matchInfo);
        //    Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AttributeListServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
        //    Assert.IsNull(matchInfo);

        //    a = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(\"X\"), YAttribute(Y: 3), ZAttribute(Z= 4)]").AttributeLists[0];
        //    b = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(\"X\"), YAttribute(Y: 3), ZAttribute(Z= 4)]").AttributeLists[0];
        //    Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AttributeListServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
        //    Assert.IsNotNull(matchInfo);
        //    Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
        //    Assert.AreEqual(matchInfo.Original, a);
        //    Assert.AreEqual(matchInfo.Modified, b);
        //}

        //[TestMethod]
        //public void AttributeTargetSpecifierServiceProvider_NameEqualityMatch_OK()
        //{
        //    var flad = new CSharpFlad();
        //    var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
        //    MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

        //    var a = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(\"X\"), YAttribute(Y: 3), ZAttribute(Z= 4)]").AttributeLists[0].Target;
        //    var b = SyntaxFactory.ParseCompilationUnit("[assembly: XAttribute(\"X\"), YAttribute(Y: 3), ZAttribute(Z= 4)]").AttributeLists[0].Target;
        //    Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AttributeTargetSpecifierServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
        //    Assert.IsNull(matchInfo);
        //    Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AttributeTargetSpecifierServiceProvider.NameEqualityMatch(a, (AttributeTargetSpecifierSyntax)null, matchingContext, out matchInfo));
        //    Assert.IsNull(matchInfo);
        //    Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AttributeTargetSpecifierServiceProvider.NameEqualityMatch(null, (AttributeTargetSpecifierSyntax)null, matchingContext, out matchInfo));
        //    Assert.IsNull(matchInfo);
        //    Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AttributeTargetSpecifierServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
        //    Assert.IsNull(matchInfo);

        //    a = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(\"X\"), YAttribute(Y: 3), ZAttribute(Z= 4)]").AttributeLists[0].Target;
        //    b = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(\"X\"), YAttribute(Y: 3), ZAttribute(Z= 4)]").AttributeLists[0].Target;
        //    Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AttributeTargetSpecifierServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
        //    Assert.IsNotNull(matchInfo);
        //    Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
        //    Assert.AreEqual(matchInfo.Original, a);
        //    Assert.AreEqual(matchInfo.Modified, b);
        //}

        [TestMethod]
        public void AttributeServiceProvider_NameEqualityMatch_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(\"X\"), YAttribute(Y: 3), ZAttribute(Z= 4)]").AttributeLists[0].Attributes[0];
            var b = SyntaxFactory.ParseCompilationUnit("[assembly: Y1Attribute(\"X\"), YAttribute(Y: 3), ZAttribute(Z= 4)]").AttributeLists[0].Attributes[0];
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AttributeServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AttributeServiceProvider.NameEqualityMatch(a, (AttributeSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AttributeServiceProvider.NameEqualityMatch(null, (AttributeSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AttributeServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(\"X\"), YAttribute(Y: 3), ZAttribute(Z= 4)]").AttributeLists[0].Attributes[0];
            b = SyntaxFactory.ParseCompilationUnit("[module: XAttribute(\"X\"), YAttribute(Y: 3), ZAttribute(Z= 4)]").AttributeLists[0].Attributes[0];
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AttributeServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);
        }

        [TestMethod]
        public void DelegateDeclarationServiceProvider_NameEqualityMatch_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = (DelegateDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] delegate void Del<T>(string str);").Members[0];
            var b = (DelegateDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] delegate void iDel<T>(string str);").Members[0];
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().DelegateDeclarationServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().DelegateDeclarationServiceProvider.NameEqualityMatch(a, (DelegateDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().DelegateDeclarationServiceProvider.NameEqualityMatch(null, (DelegateDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().DelegateDeclarationServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = (DelegateDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] delegate void Del<T>(string str);").Members[0];
            b = (DelegateDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] delegate void Del<T>(string str);").Members[0];
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().DelegateDeclarationServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);
        }

        [TestMethod]
        public void EnumMemberDeclarationServiceProvider_NameEqualityMatch_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = ((EnumDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("enum a {a1, a2 = 3, [Serializable]bf = 34};").Members[0]).Members[0];
            var b = ((EnumDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("enum a {b1, a2 = 3, [Serializable]bf = 34};").Members[0]).Members[0];
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().EnumMemberDeclarationServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().EnumMemberDeclarationServiceProvider.NameEqualityMatch(a, (EnumMemberDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().EnumMemberDeclarationServiceProvider.NameEqualityMatch(null, (EnumMemberDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().EnumMemberDeclarationServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = ((EnumDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("enum a {a1, a2 = 3, [Serializable]bf = 34};").Members[0]).Members[0];
            b = ((EnumDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("enum a {a1, a2 = 3, [Serializable]bf = 34};").Members[0]).Members[0];
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().EnumMemberDeclarationServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);
        }

        [TestMethod]
        public void NamespaceDeclarationServiceProvider_NameEqualityMatch_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = (NamespaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("namespace a{extern alias b; using static d; namespace c{};};").Members[0];
            var b = (NamespaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("namespace b{extern alias b; using static d; namespace c{};};").Members[0];
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().NamespaceDeclarationServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().NamespaceDeclarationServiceProvider.NameEqualityMatch(a, (NamespaceDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().NamespaceDeclarationServiceProvider.NameEqualityMatch(null, (NamespaceDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().NamespaceDeclarationServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = (NamespaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("namespace a{extern alias b; using static d; namespace c{};};").Members[0];
            b = (NamespaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("namespace a{extern alias b; using static d; namespace c{};};").Members[0];
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().NamespaceDeclarationServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);
        }

        [TestMethod]
        public void EnumDeclarationServiceProvider_NameEqualityMatch_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = (EnumDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public enum a : byte {a1, a2 = 3, bf = 34};").Members[0];
            var b = (EnumDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public enum b : byte {a1, a2 = 3, bf = 34};").Members[0];
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().EnumDeclarationServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().EnumDeclarationServiceProvider.NameEqualityMatch(a, (EnumDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().EnumDeclarationServiceProvider.NameEqualityMatch(null, (EnumDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().EnumDeclarationServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = (EnumDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public enum a : byte {a1, a2 = 3, bf = 34};").Members[0];
            b = (EnumDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public enum a : byte {a1, a2 = 3, bf = 34};").Members[0];
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().EnumDeclarationServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);
        }

        [TestMethod]
        public void ClassDeclarationServiceProvider_NameEqualityMatch_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public class a<T> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            var b = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public class b<T> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().ClassDeclarationServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().ClassDeclarationServiceProvider.NameEqualityMatch(a, (ClassDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().ClassDeclarationServiceProvider.NameEqualityMatch(null, (ClassDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().ClassDeclarationServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public class a<T> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            b = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public class a<T> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().ClassDeclarationServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);
        }

        [TestMethod]
        public void StructDeclarationServiceProvider_NameEqualityMatch_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = (StructDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public struct a<T> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            var b = (StructDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public struct b<T> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().StructDeclarationServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().StructDeclarationServiceProvider.NameEqualityMatch(a, (StructDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().StructDeclarationServiceProvider.NameEqualityMatch(null, (StructDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().StructDeclarationServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = (StructDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public struct a<T> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            b = (StructDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public struct a<T> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().StructDeclarationServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);
        }

        [TestMethod]
        public void InterfaceDeclarationServiceProvider_NameEqualityMatch_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = (InterfaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public interface a<T> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            var b = (InterfaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public interface b<T> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().InterfaceDeclarationServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().InterfaceDeclarationServiceProvider.NameEqualityMatch(a, (InterfaceDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().InterfaceDeclarationServiceProvider.NameEqualityMatch(null, (InterfaceDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().InterfaceDeclarationServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = (InterfaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public interface a<T> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            b = (InterfaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public interface a<T> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().InterfaceDeclarationServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);
        }

        [TestMethod]
        public void FieldDeclarationServiceProvider_NameEqualityMatch_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = (FieldDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a {B a1; internal static A b2 = 3; [Serializable]A c3 = 3; [Serializable]public int df = 34;}").Members[0]).Members[0];
            var b = (FieldDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a {B a11; internal static A b2 = 3; [Serializable]A c3 = 3; [Serializable]public int df = 34;}").Members[0]).Members[0];
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().FieldDeclarationServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().FieldDeclarationServiceProvider.NameEqualityMatch(a, (FieldDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().FieldDeclarationServiceProvider.NameEqualityMatch(null, (FieldDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().FieldDeclarationServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = (FieldDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a {B a1; internal static A b2 = 3; [Serializable]A c3 = 3; [Serializable]public int df = 34;}").Members[0]).Members[0];
            b = (FieldDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a {B a1; internal static A b2 = 3; [Serializable]A c3 = 3; [Serializable]public int df = 34;}").Members[0]).Members[0];
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().FieldDeclarationServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);
        }

        [TestMethod]
        public void EventFieldDeclarationServiceProvider_NameEqualityMatch_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = (EventFieldDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a {event B a1; internal static event A b2 = 3; [Serializable]event A c3 = 3; [Serializable]public event int df = 34;}").Members[0]).Members[0];
            var b = (EventFieldDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a {event B a11; internal static event A b2 = 3; [Serializable]event A c3 = 3; [Serializable]public event int df = 34;}").Members[0]).Members[0];
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().EventFieldDeclarationServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().EventFieldDeclarationServiceProvider.NameEqualityMatch(a, (EventFieldDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().EventFieldDeclarationServiceProvider.NameEqualityMatch(null, (EventFieldDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().EventFieldDeclarationServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = (EventFieldDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a {event B a1; internal static event A b2 = 3; [Serializable]event A c3 = 3; [Serializable]public event int df = 34;}").Members[0]).Members[0];
            b = (EventFieldDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a {event B a1; internal static event A b2 = 3; [Serializable]event A c3 = 3; [Serializable]public event int df = 34;}").Members[0]).Members[0];
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().EventFieldDeclarationServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);
        }

        [TestMethod]
        public void MethodDeclarationServiceProvider_NameEqualityMatch_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M<T>(int a, A b)where T: class { return 5; };").Members[0];
            var b = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M1<T>(int a, A b)where T: class { return 5; };").Members[0];
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().MethodDeclarationServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().MethodDeclarationServiceProvider.NameEqualityMatch(a, (MethodDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().MethodDeclarationServiceProvider.NameEqualityMatch(null, (MethodDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().MethodDeclarationServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C1.M<T>(int a, A b)where T: class { return 5; };").Members[0];
            b = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M<T>(int a, A b)where T: class { return 5; };").Members[0];
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().MethodDeclarationServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().MethodDeclarationServiceProvider.NameEqualityMatch(a, (MethodDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().MethodDeclarationServiceProvider.NameEqualityMatch(null, (MethodDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().MethodDeclarationServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M<T>(int a, A b)where T: class { return 5; };").Members[0];
            b = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M<T>(int a, A b)where T: class { return 5; };").Members[0];
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().MethodDeclarationServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);

            a = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string M<T>(int a, A b)where T: class { return 5; };").Members[0];
            b = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string M1<T>(int a, A b)where T: class { return 5; };").Members[0];
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().MethodDeclarationServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string M<T>(int a, A b)where T: class { return 5; };").Members[0];
            b = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string M<T>(int a, A b)where T: class { return 5; };").Members[0];
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().MethodDeclarationServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);
        }

        [TestMethod]
        public void OperatorDeclarationServiceProvider_NameEqualityMatch_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string operator +(int a, A b) { return 5; };").Members[0];
            var b = (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string operator -(int a, A b) { return 5; };").Members[0];
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().OperatorDeclarationServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().OperatorDeclarationServiceProvider.NameEqualityMatch(a, (OperatorDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().OperatorDeclarationServiceProvider.NameEqualityMatch(null, (OperatorDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().OperatorDeclarationServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string operator +(int a, A b) { return 5; };").Members[0];
            b = (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string operator +(int a, A b) { return 5; };").Members[0];
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().OperatorDeclarationServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);
        }


        //[TestMethod]
        //public void ConversionOperatorDeclarationServiceProvider_NameEqualityMatch_OK()
        //{
        //    var flad = new CSharpFlad();
        //    var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
        //    MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

        //    var a = (ConversionOperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public operator A1(B b) { return 5; };").Members[0];
        //    var b = (ConversionOperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public operator A(B b) { return 5; };").Members[0];
        //    Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().ConversionOperatorDeclarationServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
        //    Assert.IsNull(matchInfo);
        //    Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().ConversionOperatorDeclarationServiceProvider.NameEqualityMatch(a, (ConversionOperatorDeclarationSyntax)null, matchingContext, out matchInfo));
        //    Assert.IsNull(matchInfo);
        //    Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().ConversionOperatorDeclarationServiceProvider.NameEqualityMatch(null, (ConversionOperatorDeclarationSyntax)null, matchingContext, out matchInfo));
        //    Assert.IsNull(matchInfo);
        //    Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().ConversionOperatorDeclarationServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
        //    Assert.IsNull(matchInfo);

        //    a = (ConversionOperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public operator A(B b) { return 5; };").Members[0];
        //    b = (ConversionOperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public operator A(B1 b) { return 5; };").Members[0];
        //    Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().ConversionOperatorDeclarationServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
        //    Assert.IsNull(matchInfo);
        //    Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().ConversionOperatorDeclarationServiceProvider.NameEqualityMatch(a, (ConversionOperatorDeclarationSyntax)null, matchingContext, out matchInfo));
        //    Assert.IsNull(matchInfo);
        //    Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().ConversionOperatorDeclarationServiceProvider.NameEqualityMatch(null, (ConversionOperatorDeclarationSyntax)null, matchingContext, out matchInfo));
        //    Assert.IsNull(matchInfo);
        //    Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().ConversionOperatorDeclarationServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
        //    Assert.IsNotNull(matchInfo);
        //    Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
        //    Assert.AreEqual(matchInfo.Original, a);
        //    Assert.AreEqual(matchInfo.Modified, b);

        //    a = (ConversionOperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public operator A(B b) { return 5; };").Members[0];
        //    b = (ConversionOperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public operator A(B b) { return 5; };").Members[0];
        //    Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().ConversionOperatorDeclarationServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
        //    Assert.IsNull(matchInfo);
        //    Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().ConversionOperatorDeclarationServiceProvider.NameEqualityMatch(a, (ConversionOperatorDeclarationSyntax)null, matchingContext, out matchInfo));
        //    Assert.IsNull(matchInfo);
        //    Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().ConversionOperatorDeclarationServiceProvider.NameEqualityMatch(null, (ConversionOperatorDeclarationSyntax)null, matchingContext, out matchInfo));
        //    Assert.IsNull(matchInfo);
        //    Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().ConversionOperatorDeclarationServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
        //    Assert.IsNotNull(matchInfo);
        //    Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
        //    Assert.AreEqual(matchInfo.Original, a);
        //    Assert.AreEqual(matchInfo.Modified, b);
        //}

        [TestMethod]
        public void ConstructorDeclarationServiceProvider_NameEqualityMatch_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = (ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation]public A(B b) : this(b) { }; }").Members[0]).Members[0];
            var b = (ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A1 { [Documentation]public A1(B b) : this(b) { }; }").Members[0]).Members[0];
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().ConstructorDeclarationServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().ConstructorDeclarationServiceProvider.NameEqualityMatch(a, (ConstructorDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().ConstructorDeclarationServiceProvider.NameEqualityMatch(null, (ConstructorDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().ConstructorDeclarationServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = (ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation]public A(B b) : this(b) { }; }").Members[0]).Members[0];
            b = (ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation]public A(B b) : this(b) { }; }").Members[0]).Members[0];
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().ConstructorDeclarationServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);
        }

        [TestMethod]
        public void DestructorDeclarationServiceProvider_NameEqualityMatch_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = (DestructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation] ~A(){ }; }").Members[0]).Members[0];
            var b = (DestructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A1 { [Documentation] ~A1(){ }; }").Members[0]).Members[0];
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().DestructorDeclarationServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().DestructorDeclarationServiceProvider.NameEqualityMatch(a, (DestructorDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().DestructorDeclarationServiceProvider.NameEqualityMatch(null, (DestructorDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().DestructorDeclarationServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = (DestructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation] ~A(){ }; }").Members[0]).Members[0];
            b = (DestructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation] ~A(){ }; }").Members[0]).Members[0];
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().DestructorDeclarationServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);
        }

        [TestMethod]
        public void PropertyDeclarationServiceProvider_NameEqualityMatch_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M { get{return 5;} set{this.a = 7} };").Members[0];
            var b = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M1 { get{return 5;} set{this.a = 7} };").Members[0];
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().PropertyDeclarationServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().PropertyDeclarationServiceProvider.NameEqualityMatch(a, (PropertyDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().PropertyDeclarationServiceProvider.NameEqualityMatch(null, (PropertyDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().PropertyDeclarationServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M { get{return 5;} set{this.a = 7} };").Members[0];
            b = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C1.M { get{return 5;} set{this.a = 7} };").Members[0];
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().PropertyDeclarationServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().PropertyDeclarationServiceProvider.NameEqualityMatch(a, (PropertyDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().PropertyDeclarationServiceProvider.NameEqualityMatch(null, (PropertyDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().PropertyDeclarationServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M { get{return 5;} set{this.a = 7} };").Members[0];
            b = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M { get{return 5;} set{this.a = 7} };").Members[0];
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().PropertyDeclarationServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);

            a = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string M { get{return 5;} set{this.a = 7} };").Members[0];
            b = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string M1 { get{return 5;} set{this.a = 7} };").Members[0];
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().PropertyDeclarationServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().PropertyDeclarationServiceProvider.NameEqualityMatch(a, (PropertyDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().PropertyDeclarationServiceProvider.NameEqualityMatch(null, (PropertyDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().PropertyDeclarationServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string M { get{return 5;} set{this.a = 7} };").Members[0];
            b = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string M { get{return 5;} set{this.a = 7} };").Members[0];
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().PropertyDeclarationServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);
        }

        [TestMethod]
        public void EventDeclarationServiceProvider_NameEqualityMatch_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = (EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A C.M { add{this.M += value;} remove{this.M -= value} }").Members[0];
            var b = (EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A C.M1 { add{this.M += value;} remove{this.M -= value} }").Members[0];
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().EventDeclarationServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().EventDeclarationServiceProvider.NameEqualityMatch(a, (EventDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().EventDeclarationServiceProvider.NameEqualityMatch(null, (EventDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().EventDeclarationServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = (EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A C.M { add{this.M += value;} remove{this.M -= value} }").Members[0];
            b = (EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A C1.M { add{this.M += value;} remove{this.M -= value} }").Members[0];
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().EventDeclarationServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().EventDeclarationServiceProvider.NameEqualityMatch(a, (EventDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().EventDeclarationServiceProvider.NameEqualityMatch(null, (EventDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().EventDeclarationServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = (EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A C.M { add{this.M += value;} remove{this.M -= value} }").Members[0];
            b = (EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A C.M { add{this.M += value;} remove{this.M -= value} }").Members[0];
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().EventDeclarationServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);

            a = (EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A M { add{this.M += value;} remove{this.M -= value} }").Members[0];
            b = (EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A M1 { add{this.M += value;} remove{this.M -= value} }").Members[0];
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().EventDeclarationServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().EventDeclarationServiceProvider.NameEqualityMatch(a, (EventDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().EventDeclarationServiceProvider.NameEqualityMatch(null, (EventDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().EventDeclarationServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = (EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A M { add{this.M += value;} remove{this.M -= value} }").Members[0];
            b = (EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A M { add{this.M += value;} remove{this.M -= value} }").Members[0];
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().EventDeclarationServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);
        }

        [TestMethod]
        public void IndexerDeclarationServiceProvider_NameEqualityMatch_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A C.this[string key] { get{return this.M[key];} set{this.M[key] = value;} } => 5;").Members[0];
            var b = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A C.this[string key] { get{return this.M[key];} set{this.M[key] = value;} } => 5;").Members[0];
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().IndexerDeclarationServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().IndexerDeclarationServiceProvider.NameEqualityMatch(a, (IndexerDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().IndexerDeclarationServiceProvider.NameEqualityMatch(null, (IndexerDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().IndexerDeclarationServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);

            a = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A C.this[string key] { get{return this.M[key];} set{this.M[key] = value;} } => 5;").Members[0];
            b = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A C1.this[string key] { get{return this.M[key];} set{this.M[key] = value;} } => 5;").Members[0];
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().IndexerDeclarationServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A this[string key] { get{return this.M[key];} set{this.M[key] = value;} } => 5;").Members[0];
            b = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A this[string key] { get{return this.M[key];} set{this.M[key] = value;} } => 5;").Members[0];
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().IndexerDeclarationServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);
        }

        [TestMethod]
        public void BadDirectiveTriviaServiceProvider_NameEqualityMatch_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = SyntaxFactory.BadDirectiveTrivia(SyntaxFactory.Identifier("unknown"), true);
            var b = SyntaxFactory.BadDirectiveTrivia(SyntaxFactory.Identifier("unknownY"), true);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().BadDirectiveTriviaServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().BadDirectiveTriviaServiceProvider.NameEqualityMatch(a, (BadDirectiveTriviaSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().BadDirectiveTriviaServiceProvider.NameEqualityMatch(null, (BadDirectiveTriviaSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().BadDirectiveTriviaServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = SyntaxFactory.BadDirectiveTrivia(SyntaxFactory.Identifier("unknown"), true);
            b = SyntaxFactory.BadDirectiveTrivia(SyntaxFactory.Identifier("unknown"), true);
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().BadDirectiveTriviaServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);
        }

        [TestMethod]
        public void DefineDirectiveTriviaServiceProvider_NameEqualityMatch_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = SyntaxFactory.DefineDirectiveTrivia(SyntaxFactory.Identifier("DEBUG"), true);
            var b = SyntaxFactory.DefineDirectiveTrivia(SyntaxFactory.Identifier("iDEBUG"), true);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().DefineDirectiveTriviaServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().DefineDirectiveTriviaServiceProvider.NameEqualityMatch(a, (DefineDirectiveTriviaSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().DefineDirectiveTriviaServiceProvider.NameEqualityMatch(null, (DefineDirectiveTriviaSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().DefineDirectiveTriviaServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = SyntaxFactory.DefineDirectiveTrivia(SyntaxFactory.Identifier("DEBUG"), true);
            b = SyntaxFactory.DefineDirectiveTrivia(SyntaxFactory.Identifier("DEBUG"), true);
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().DefineDirectiveTriviaServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);
        }

        [TestMethod]
        public void UndefDirectiveTriviaServiceProvider_NameEqualityMatch_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = SyntaxFactory.UndefDirectiveTrivia(SyntaxFactory.Identifier("DEBUG"), true);
            var b = SyntaxFactory.UndefDirectiveTrivia(SyntaxFactory.Identifier("iDEBUG"), true);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().UndefDirectiveTriviaServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().UndefDirectiveTriviaServiceProvider.NameEqualityMatch(a, (UndefDirectiveTriviaSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().UndefDirectiveTriviaServiceProvider.NameEqualityMatch(null, (UndefDirectiveTriviaSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().UndefDirectiveTriviaServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = SyntaxFactory.UndefDirectiveTrivia(SyntaxFactory.Identifier("DEBUG"), true);
            b = SyntaxFactory.UndefDirectiveTrivia(SyntaxFactory.Identifier("DEBUG"), true);
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().UndefDirectiveTriviaServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);
        }

        [TestMethod]
        public void NameMemberCrefServiceProvider_NameEqualityMatch_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"N(int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<NameMemberCrefSyntax>().Single();
            var b = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"N1(int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<NameMemberCrefSyntax>().Single();
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().NameMemberCrefServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().NameMemberCrefServiceProvider.NameEqualityMatch(a, (NameMemberCrefSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().NameMemberCrefServiceProvider.NameEqualityMatch(null, (NameMemberCrefSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().NameMemberCrefServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"N(int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<NameMemberCrefSyntax>().Single();
            b = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"N(int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<NameMemberCrefSyntax>().Single();
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().NameMemberCrefServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);
        }

        [TestMethod]
        public void IndexerMemberCrefServiceProvider_NameEqualityMatch_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"this[int]\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<IndexerMemberCrefSyntax>().Single();
            var b = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"this[int]\"/> </summary>" + Environment.NewLine +
                       "    class A1 { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<IndexerMemberCrefSyntax>().Single();
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().IndexerMemberCrefServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().IndexerMemberCrefServiceProvider.NameEqualityMatch(a, (IndexerMemberCrefSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().IndexerMemberCrefServiceProvider.NameEqualityMatch(null, (IndexerMemberCrefSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().IndexerMemberCrefServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);

            a = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"this[int]\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<IndexerMemberCrefSyntax>().Single();
            b = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"this[int]\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<IndexerMemberCrefSyntax>().Single();
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().IndexerMemberCrefServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);
        }

        [TestMethod]
        public void OperatorMemberCrefServiceProvider_NameEqualityMatch_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single();
            var b = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator -(int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single();
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().OperatorMemberCrefServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().OperatorMemberCrefServiceProvider.NameEqualityMatch(a, (OperatorMemberCrefSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().OperatorMemberCrefServiceProvider.NameEqualityMatch(null, (OperatorMemberCrefSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().OperatorMemberCrefServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single();
            b = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single();
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().OperatorMemberCrefServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);
        }

        [TestMethod]
        public void XmlElementServiceProvider_NameEqualityMatch_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single();
            var b = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<Message id=\"5\" oid=\"3\">Hello World</Message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single();
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlElementServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlElementServiceProvider.NameEqualityMatch(a, null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlElementServiceProvider.NameEqualityMatch(null, null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlElementServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single();
            b = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single();
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlElementServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);

            a = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<i:message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single();
            b = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<i:Message id=\"5\" oid=\"3\">Hello World</Message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single();
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlElementServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlElementServiceProvider.NameEqualityMatch(a, null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlElementServiceProvider.NameEqualityMatch(null, null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlElementServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<i:message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single();
            b = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<j:message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single();
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlElementServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<i:message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single();
            b = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<i:message id=\"5\" oid=\"3\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single();
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlElementServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);
        }

        [TestMethod]
        public void XmlEmptyElementServiceProvider_NameEqualityMatch_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<foo id=\"3\"/>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlEmptyElementSyntax>().Single();
            var b = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<ifoo id=\"3\"/>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlEmptyElementSyntax>().Single();
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlEmptyElementServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlEmptyElementServiceProvider.NameEqualityMatch(a, null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlEmptyElementServiceProvider.NameEqualityMatch(null, null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlEmptyElementServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<foo id=\"3\"/>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlEmptyElementSyntax>().Single();
            b = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<foo id=\"3\"/>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlEmptyElementSyntax>().Single();
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlEmptyElementServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);

            a = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<i:foo id=\"3\"/>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlEmptyElementSyntax>().Single();
            b = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<i:Foo id=\"3\"/>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlEmptyElementSyntax>().Single();
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlEmptyElementServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlEmptyElementServiceProvider.NameEqualityMatch(a, null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlEmptyElementServiceProvider.NameEqualityMatch(null, null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlEmptyElementServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<i:foo id=\"3\"/>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlEmptyElementSyntax>().Single();
            b = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<j:foo id=\"3\"/>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlEmptyElementSyntax>().Single();
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlEmptyElementServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<i:foo id=\"3\"/>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlEmptyElementSyntax>().Single();
            b = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<i:foo id=\"3\"/>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlEmptyElementSyntax>().Single();
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlEmptyElementServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);
        }

        [TestMethod]
        public void XmlProcessingInstructionServiceProvider_NameEqualityMatch_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<?proc-inst1 this is a test of &some; processinginstruction?>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlProcessingInstructionSyntax>().Single();
            var b = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<?proc-inst this is a test of &some; processinginstruction?>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlProcessingInstructionSyntax>().Single();
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlProcessingInstructionServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlProcessingInstructionServiceProvider.NameEqualityMatch(a, (XmlProcessingInstructionSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlProcessingInstructionServiceProvider.NameEqualityMatch(null, (XmlProcessingInstructionSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlProcessingInstructionServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<?proc-inst this is a test of &some; processinginstruction?>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlProcessingInstructionSyntax>().Single();
            b = ((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<?proc-inst this is a test of &some; processinginstruction?>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlProcessingInstructionSyntax>().Single();
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlProcessingInstructionServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);
        }

        [TestMethod]
        public void XmlTextAttributeServiceProvider_NameEqualityMatch_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = (XmlTextAttributeSyntax)((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<message id=\"5 r\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag.Attributes[0];
            var b = (XmlTextAttributeSyntax)((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<message id1=\"5 r\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag.Attributes[0];
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlTextAttributeServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlTextAttributeServiceProvider.NameEqualityMatch(a, (XmlTextAttributeSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlTextAttributeServiceProvider.NameEqualityMatch(null, (XmlTextAttributeSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlTextAttributeServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = (XmlTextAttributeSyntax)((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<message id=\"5 r\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag.Attributes[0];
            b = (XmlTextAttributeSyntax)((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<message id=\"5 r\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag.Attributes[0];
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlTextAttributeServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);
        }

        [TestMethod]
        public void XmlCrefAttributeServiceProvider_NameEqualityMatch_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = (XmlCrefAttributeSyntax)((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<see cref=\"M2\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag.Attributes[0];
            var b = (XmlCrefAttributeSyntax)((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<see cref=\"M\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag.Attributes[0];
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlCrefAttributeServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlCrefAttributeServiceProvider.NameEqualityMatch(a, (XmlCrefAttributeSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlCrefAttributeServiceProvider.NameEqualityMatch(null, (XmlCrefAttributeSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlCrefAttributeServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = (XmlCrefAttributeSyntax)((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<see cref=\"M\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag.Attributes[0];
            b = (XmlCrefAttributeSyntax)((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<see cref=\"M\">Hello World</message>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlElementSyntax>().Single().StartTag.Attributes[0];
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlCrefAttributeServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);
        }

        [TestMethod]
        public void XmlNameAttributeServiceProvider_NameEqualityMatch_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = (XmlNameAttributeSyntax)((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<param name=\"M1\"/>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlEmptyElementSyntax>().Single().Attributes[0];
            var b = (XmlNameAttributeSyntax)((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<param name=\"M\"/>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlEmptyElementSyntax>().Single().Attributes[0];
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlNameAttributeServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlNameAttributeServiceProvider.NameEqualityMatch(a, (XmlNameAttributeSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlNameAttributeServiceProvider.NameEqualityMatch(null, (XmlNameAttributeSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlNameAttributeServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = (XmlNameAttributeSyntax)((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<param name=\"M\"/>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlEmptyElementSyntax>().Single().Attributes[0];
            b = (XmlNameAttributeSyntax)((DocumentationCommentTriviaSyntax)SyntaxFactory.ParseSyntaxTree("///<param name=\"M\"/>").GetCompilationUnitRoot().EndOfFileToken.LeadingTrivia.Single().GetStructure()).Content.OfType<XmlEmptyElementSyntax>().Single().Attributes[0];
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().XmlNameAttributeServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);
        }

        [TestMethod]
        public void MemberAccessExpressionServiceProvider_NameEqualityMatch_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = (MemberAccessExpressionSyntax)SyntaxFactory.ParseExpression("x.r");
            var b = (MemberAccessExpressionSyntax)SyntaxFactory.ParseExpression("x.R");
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().MemberAccessExpressionServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().MemberAccessExpressionServiceProvider.NameEqualityMatch(a, (MemberAccessExpressionSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().MemberAccessExpressionServiceProvider.NameEqualityMatch(null, (MemberAccessExpressionSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().MemberAccessExpressionServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = (MemberAccessExpressionSyntax)SyntaxFactory.ParseExpression("x.r");
            b = (MemberAccessExpressionSyntax)SyntaxFactory.ParseExpression("y.r");
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().MemberAccessExpressionServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().MemberAccessExpressionServiceProvider.NameEqualityMatch(a, (MemberAccessExpressionSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().MemberAccessExpressionServiceProvider.NameEqualityMatch(null, (MemberAccessExpressionSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().MemberAccessExpressionServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = (MemberAccessExpressionSyntax)SyntaxFactory.ParseExpression("x.r");
            b = (MemberAccessExpressionSyntax)SyntaxFactory.ParseExpression("x.r");
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().MemberAccessExpressionServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);

            a = (MemberAccessExpressionSyntax)SyntaxFactory.ParseExpression("5.r");
            b = (MemberAccessExpressionSyntax)SyntaxFactory.ParseExpression("6.r");
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().MemberAccessExpressionServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = (MemberAccessExpressionSyntax)SyntaxFactory.ParseExpression("5.r");
            b = (MemberAccessExpressionSyntax)SyntaxFactory.ParseExpression("5.r");
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().MemberAccessExpressionServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);
        }

        [TestMethod]
        public void MemberBindingExpressionServiceProvider_NameEqualityMatch_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = (MemberBindingExpressionSyntax)((ConditionalAccessExpressionSyntax)Microsoft.CodeAnalysis.CSharp.SyntaxFactory.ParseExpression("m?.r")).WhenNotNull;
            var b = (MemberBindingExpressionSyntax)((ConditionalAccessExpressionSyntax)Microsoft.CodeAnalysis.CSharp.SyntaxFactory.ParseExpression("m?.R")).WhenNotNull;
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().MemberBindingExpressionServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().MemberBindingExpressionServiceProvider.NameEqualityMatch(a, (MemberBindingExpressionSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().MemberBindingExpressionServiceProvider.NameEqualityMatch(null, (MemberBindingExpressionSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().MemberBindingExpressionServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = (MemberBindingExpressionSyntax)((ConditionalAccessExpressionSyntax)Microsoft.CodeAnalysis.CSharp.SyntaxFactory.ParseExpression("m?.r")).WhenNotNull;
            b = (MemberBindingExpressionSyntax)((ConditionalAccessExpressionSyntax)Microsoft.CodeAnalysis.CSharp.SyntaxFactory.ParseExpression("m?.r")).WhenNotNull;
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().MemberBindingExpressionServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);
        }

        [TestMethod]
        public void QueryExpressionServiceProvider_NameEqualityMatch_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = (QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s where f.A select f.R");
            var b = (QueryExpressionSyntax)SyntaxFactory.ParseExpression("from F in s where f.A select f.R");
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().QueryExpressionServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().QueryExpressionServiceProvider.NameEqualityMatch(a, (QueryExpressionSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().QueryExpressionServiceProvider.NameEqualityMatch(null, (QueryExpressionSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().QueryExpressionServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = (QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s where f.A select f.R");
            b = (QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s where f.A select f.R");
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().QueryExpressionServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);
        }

        [TestMethod]
        public void AliasQualifiedNameServiceProvider_NameEqualityMatch_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = (AliasQualifiedNameSyntax)SyntaxFactory.ParseExpression("global::c");
            var b = (AliasQualifiedNameSyntax)SyntaxFactory.ParseExpression("global::C");
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AliasQualifiedNameServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AliasQualifiedNameServiceProvider.NameEqualityMatch(a, (AliasQualifiedNameSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AliasQualifiedNameServiceProvider.NameEqualityMatch(null, (AliasQualifiedNameSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AliasQualifiedNameServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = (AliasQualifiedNameSyntax)SyntaxFactory.ParseExpression("global::C");
            b = (AliasQualifiedNameSyntax)SyntaxFactory.ParseExpression("global::c");
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AliasQualifiedNameServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AliasQualifiedNameServiceProvider.NameEqualityMatch(a, (AliasQualifiedNameSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AliasQualifiedNameServiceProvider.NameEqualityMatch(null, (AliasQualifiedNameSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AliasQualifiedNameServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = (AliasQualifiedNameSyntax)SyntaxFactory.ParseExpression("globalx::c");
            b = (AliasQualifiedNameSyntax)SyntaxFactory.ParseExpression("global::c");
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AliasQualifiedNameServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AliasQualifiedNameServiceProvider.NameEqualityMatch(a, (AliasQualifiedNameSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AliasQualifiedNameServiceProvider.NameEqualityMatch(null, (AliasQualifiedNameSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AliasQualifiedNameServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = (AliasQualifiedNameSyntax)SyntaxFactory.ParseExpression("global::c");
            b = (AliasQualifiedNameSyntax)SyntaxFactory.ParseExpression("globalx::c");
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AliasQualifiedNameServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AliasQualifiedNameServiceProvider.NameEqualityMatch(a, (AliasQualifiedNameSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AliasQualifiedNameServiceProvider.NameEqualityMatch(null, (AliasQualifiedNameSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AliasQualifiedNameServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = (AliasQualifiedNameSyntax)SyntaxFactory.ParseExpression("global::c");
            b = (AliasQualifiedNameSyntax)SyntaxFactory.ParseExpression("global::c");
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AliasQualifiedNameServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);
        }

        [TestMethod]
        public void IdentifierNameServiceProvider_NameEqualityMatch_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = (IdentifierNameSyntax)SyntaxFactory.ParseName("varx");
            var b = (IdentifierNameSyntax)SyntaxFactory.ParseName("var");
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().IdentifierNameServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().IdentifierNameServiceProvider.NameEqualityMatch(a, (IdentifierNameSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().IdentifierNameServiceProvider.NameEqualityMatch(null, (IdentifierNameSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().IdentifierNameServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = (IdentifierNameSyntax)SyntaxFactory.ParseName("var");
            b = (IdentifierNameSyntax)SyntaxFactory.ParseName("var");
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().IdentifierNameServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);
        }

        [TestMethod]
        public void GenericNameServiceProvider_NameEqualityMatch_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = (GenericNameSyntax)SyntaxFactory.ParseName("a<,>");
            var b = (GenericNameSyntax)SyntaxFactory.ParseName("a<T>");
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().GenericNameServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().GenericNameServiceProvider.NameEqualityMatch(a, (GenericNameSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().GenericNameServiceProvider.NameEqualityMatch(null, (GenericNameSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().GenericNameServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);

            a = (GenericNameSyntax)SyntaxFactory.ParseName("a<T>");
            b = (GenericNameSyntax)SyntaxFactory.ParseName("a<,>");
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().GenericNameServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().GenericNameServiceProvider.NameEqualityMatch(a, (GenericNameSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().GenericNameServiceProvider.NameEqualityMatch(null, (GenericNameSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().GenericNameServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);

            a = (GenericNameSyntax)SyntaxFactory.ParseName("a<,>");
            b = (GenericNameSyntax)SyntaxFactory.ParseName("a<,>");
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().GenericNameServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().GenericNameServiceProvider.NameEqualityMatch(a, (GenericNameSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().GenericNameServiceProvider.NameEqualityMatch(null, (GenericNameSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().GenericNameServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);

            a = (GenericNameSyntax)SyntaxFactory.ParseName("a<T>");
            b = (GenericNameSyntax)SyntaxFactory.ParseName("a<K>");
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().GenericNameServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().GenericNameServiceProvider.NameEqualityMatch(a, (GenericNameSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().GenericNameServiceProvider.NameEqualityMatch(null, (GenericNameSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().GenericNameServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);

            a = (GenericNameSyntax)SyntaxFactory.ParseName("b<T>");
            b = (GenericNameSyntax)SyntaxFactory.ParseName("a<T>");
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().GenericNameServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = (GenericNameSyntax)SyntaxFactory.ParseName("a<T>");
            b = (GenericNameSyntax)SyntaxFactory.ParseName("a<T>");
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().GenericNameServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);
        }

        [TestMethod]
        public void SimpleLambdaExpressionServiceProvider_NameEqualityMatch_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = (SimpleLambdaExpressionSyntax)SyntaxFactory.ParseExpression("e => 4 }");
            var b = (SimpleLambdaExpressionSyntax)SyntaxFactory.ParseExpression("E => 4 }");
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().SimpleLambdaExpressionServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().SimpleLambdaExpressionServiceProvider.NameEqualityMatch(a, (SimpleLambdaExpressionSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().SimpleLambdaExpressionServiceProvider.NameEqualityMatch(null, (SimpleLambdaExpressionSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().SimpleLambdaExpressionServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = (SimpleLambdaExpressionSyntax)SyntaxFactory.ParseExpression("e => 4 }");
            b = (SimpleLambdaExpressionSyntax)SyntaxFactory.ParseExpression("e => 4 }");
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().SimpleLambdaExpressionServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);
        }

        [TestMethod]
        public void FromClauseServiceProvider_NameEqualityMatch_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = ((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s where f.A select f.R")).FromClause;
            var b = ((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from F in s where f.A select f.R")).FromClause;
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().FromClauseServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().FromClauseServiceProvider.NameEqualityMatch(a, (FromClauseSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().FromClauseServiceProvider.NameEqualityMatch(null, (FromClauseSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().FromClauseServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = ((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s where f.A select f.R")).FromClause;
            b = ((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s where f.A select f.R")).FromClause;
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().FromClauseServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);
        }

        [TestMethod]
        public void LetClauseServiceProvider_NameEqualityMatch_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = (LetClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from A f in s let y = 5")).Body.Clauses[0];
            var b = (LetClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from A f in s let Y = 5")).Body.Clauses[0];
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().LetClauseServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().LetClauseServiceProvider.NameEqualityMatch(a, (LetClauseSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().LetClauseServiceProvider.NameEqualityMatch(null, (LetClauseSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().LetClauseServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = (LetClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from A f in s let y = 5")).Body.Clauses[0];
            b = (LetClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from A f in s let y = 5")).Body.Clauses[0];
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().LetClauseServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);
        }

        [TestMethod]
        public void JoinClauseServiceProvider_NameEqualityMatch_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = (JoinClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s join T t in F on t.L equals s.R into y")).Body.Clauses[0];
            var b = (JoinClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s join T s in F on t.L equals s.R into y")).Body.Clauses[0];
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().JoinClauseServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().JoinClauseServiceProvider.NameEqualityMatch(a, (JoinClauseSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().JoinClauseServiceProvider.NameEqualityMatch(null, (JoinClauseSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().JoinClauseServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = (JoinClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s join T t in F on t.L equals s.R into y")).Body.Clauses[0];
            b = (JoinClauseSyntax)((QueryExpressionSyntax)SyntaxFactory.ParseExpression("from f in s join T t in F on t.L equals s.R into y")).Body.Clauses[0];
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().JoinClauseServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);
        }

        [TestMethod]
        public void LocalFunctionStatementServiceProvider_NameEqualityMatch_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

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
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().LocalFunctionStatementServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().LocalFunctionStatementServiceProvider.NameEqualityMatch(a, (LocalFunctionStatementSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().LocalFunctionStatementServiceProvider.NameEqualityMatch(null, (LocalFunctionStatementSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().LocalFunctionStatementServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

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
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().LocalFunctionStatementServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);
        }

        [TestMethod]
        public void LocalDeclarationStatementServiceProvider_NameEqualityMatch_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = (LocalDeclarationStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int a() { const int a; }").Members[0]).Body.Statements[0];
            var b = (LocalDeclarationStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int a() { const int A; }").Members[0]).Body.Statements[0];
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().LocalDeclarationStatementServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().LocalDeclarationStatementServiceProvider.NameEqualityMatch(a, (LocalDeclarationStatementSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().LocalDeclarationStatementServiceProvider.NameEqualityMatch(null, (LocalDeclarationStatementSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().LocalDeclarationStatementServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = (LocalDeclarationStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int a() { const int a; }").Members[0]).Body.Statements[0];
            b = (LocalDeclarationStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int a() { const int a; }").Members[0]).Body.Statements[0];
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().LocalDeclarationStatementServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);
        }

        [TestMethod]
        public void LabeledStatementServiceProvider_NameEqualityMatch_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = (LabeledStatementSyntax)SyntaxFactory.ParseStatement("l: 3");
            var b = (LabeledStatementSyntax)SyntaxFactory.ParseStatement("L: 3");
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().LabeledStatementServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().LabeledStatementServiceProvider.NameEqualityMatch(a, (LabeledStatementSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().LabeledStatementServiceProvider.NameEqualityMatch(null, (LabeledStatementSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().LabeledStatementServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = (LabeledStatementSyntax)SyntaxFactory.ParseStatement("l: 3");
            b = (LabeledStatementSyntax)SyntaxFactory.ParseStatement("l: 3");
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().LabeledStatementServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);
        }

        [TestMethod]
        public void ForStatementServiceProvider_NameEqualityMatch_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = (ForStatementSyntax)SyntaxFactory.ParseStatement("for(int A, b = 4; a < 0; a++, --b);");
            var b = (ForStatementSyntax)SyntaxFactory.ParseStatement("for(int a, b = 4; a < 0; a++, --b);");
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().ForStatementServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().ForStatementServiceProvider.NameEqualityMatch(a, (ForStatementSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().ForStatementServiceProvider.NameEqualityMatch(null, (ForStatementSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().ForStatementServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = (ForStatementSyntax)SyntaxFactory.ParseStatement("for(int a = 4; a < 0; --b);");
            b = (ForStatementSyntax)SyntaxFactory.ParseStatement("for(int b = 4; a < 0; --b);");
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().ForStatementServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().ForStatementServiceProvider.NameEqualityMatch(a, (ForStatementSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().ForStatementServiceProvider.NameEqualityMatch(null, (ForStatementSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().ForStatementServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = (ForStatementSyntax)SyntaxFactory.ParseStatement("for(int a, b = 4; a < 0; a++, --b);");
            b = (ForStatementSyntax)SyntaxFactory.ParseStatement("for(int a, b = 4; a < 0; a++, --b);");
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().ForStatementServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);

            a = (ForStatementSyntax)SyntaxFactory.ParseStatement("for(int a = 4; a < 0; --b);");
            b = (ForStatementSyntax)SyntaxFactory.ParseStatement("for(int a = 4; a < 0; --b);");
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().ForStatementServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);
        }

        [TestMethod]
        public void UsingStatementServiceProvider_NameEqualityMatch_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = (UsingStatementSyntax)SyntaxFactory.ParseStatement("using(int A, b = 4);");
            var b = (UsingStatementSyntax)SyntaxFactory.ParseStatement("using(int a, b = 4);");
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().UsingStatementServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().UsingStatementServiceProvider.NameEqualityMatch(a, (UsingStatementSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().UsingStatementServiceProvider.NameEqualityMatch(null, (UsingStatementSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().UsingStatementServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = (UsingStatementSyntax)SyntaxFactory.ParseStatement("using(int a = 4);");
            b = (UsingStatementSyntax)SyntaxFactory.ParseStatement("using(int b = 4);");
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().UsingStatementServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().UsingStatementServiceProvider.NameEqualityMatch(a, (UsingStatementSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().UsingStatementServiceProvider.NameEqualityMatch(null, (UsingStatementSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().UsingStatementServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = (UsingStatementSyntax)SyntaxFactory.ParseStatement("using(int a, b = 4);");
            b = (UsingStatementSyntax)SyntaxFactory.ParseStatement("using(int a, b = 4);");
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().UsingStatementServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);

            a = (UsingStatementSyntax)SyntaxFactory.ParseStatement("using(int a = 4);");
            b = (UsingStatementSyntax)SyntaxFactory.ParseStatement("using(int a = 4);");
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().UsingStatementServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);
        }

        [TestMethod]
        public void FixedStatementServiceProvider_NameEqualityMatch_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = (FixedStatementSyntax)SyntaxFactory.ParseStatement("fixed(int A, b = 4);");
            var b = (FixedStatementSyntax)SyntaxFactory.ParseStatement("fixed(int a, b = 4);");
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().FixedStatementServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().FixedStatementServiceProvider.NameEqualityMatch(a, (FixedStatementSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().FixedStatementServiceProvider.NameEqualityMatch(null, (FixedStatementSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().FixedStatementServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = (FixedStatementSyntax)SyntaxFactory.ParseStatement("fixed(int a = 4);");
            b = (FixedStatementSyntax)SyntaxFactory.ParseStatement("fixed(int b = 4);");
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().FixedStatementServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().FixedStatementServiceProvider.NameEqualityMatch(a, (FixedStatementSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().FixedStatementServiceProvider.NameEqualityMatch(null, (FixedStatementSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().FixedStatementServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = (FixedStatementSyntax)SyntaxFactory.ParseStatement("fixed(int a, b = 4);");
            b = (FixedStatementSyntax)SyntaxFactory.ParseStatement("fixed(int a, b = 4);");
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().FixedStatementServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);

            a = (FixedStatementSyntax)SyntaxFactory.ParseStatement("fixed(int a = 4);");
            b = (FixedStatementSyntax)SyntaxFactory.ParseStatement("fixed(int a = 4);");
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().FixedStatementServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);
        }

        [TestMethod]
        public void ForEachStatementServiceProvider_NameEqualityMatch_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = (ForEachStatementSyntax)SyntaxFactory.ParseStatement("foreach(int b in ac);");
            var b = (ForEachStatementSyntax)SyntaxFactory.ParseStatement("foreach(int a in ac);");
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().ForEachStatementServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().ForEachStatementServiceProvider.NameEqualityMatch(a, (ForEachStatementSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().ForEachStatementServiceProvider.NameEqualityMatch(null, (ForEachStatementSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().ForEachStatementServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = (ForEachStatementSyntax)SyntaxFactory.ParseStatement("foreach(int a in ac);");
            b = (ForEachStatementSyntax)SyntaxFactory.ParseStatement("foreach(int a in ac);");
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().ForEachStatementServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);
        }

        [TestMethod]
        public void SingleVariableDesignationServiceProvider_NameEqualityMatch_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = (SingleVariableDesignationSyntax)SyntaxFactory.SingleVariableDesignation(SyntaxFactory.Identifier("a"));
            var b = (SingleVariableDesignationSyntax)SyntaxFactory.SingleVariableDesignation(SyntaxFactory.Identifier("b"));
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().SingleVariableDesignationServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().SingleVariableDesignationServiceProvider.NameEqualityMatch(a, (SingleVariableDesignationSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().SingleVariableDesignationServiceProvider.NameEqualityMatch(null, (SingleVariableDesignationSyntax)null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().SingleVariableDesignationServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = (SingleVariableDesignationSyntax)SyntaxFactory.SingleVariableDesignation(SyntaxFactory.Identifier("a"));
            b = (SingleVariableDesignationSyntax)SyntaxFactory.SingleVariableDesignation(SyntaxFactory.Identifier("a"));
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().SingleVariableDesignationServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);
        }

        //[TestMethod]
        //public void TypeParameterListServiceProvider_NameEqualityMatch_OK()
        //{
        //    var flad = new CSharpFlad();
        //    var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
        //    MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

        //    var a = ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<B, out D, [Serializable]E, [Serializable] in F> {}").Members[0]).TypeParameterList;
        //    var b = ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<B, in C, out D, [Serializable]E, [Serializable] in F> {}").Members[0]).TypeParameterList;
        //    Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().TypeParameterListServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
        //    Assert.IsNull(matchInfo);
        //    Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().TypeParameterListServiceProvider.NameEqualityMatch(a, null, matchingContext, out matchInfo));
        //    Assert.IsNull(matchInfo);
        //    Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().TypeParameterListServiceProvider.NameEqualityMatch(null, null, matchingContext, out matchInfo));
        //    Assert.IsNull(matchInfo);
        //    Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().TypeParameterListServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
        //    Assert.IsNull(matchInfo);

        //    a = ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<B, C1, out D, [Serializable]E, [Serializable] in F> {}").Members[0]).TypeParameterList;
        //    b = ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<B, in C, out D, [Serializable]E, [Serializable] in F> {}").Members[0]).TypeParameterList;
        //    Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().TypeParameterListServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
        //    Assert.IsNull(matchInfo);

        //    a = ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<B, in C, out D, [Serializable]E, [Serializable] in F> {}").Members[0]).TypeParameterList;
        //    b = ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<B, in C, out D, [Serializable]E, [Serializable] in F> {}").Members[0]).TypeParameterList;
        //    Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().TypeParameterListServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
        //    Assert.IsNotNull(matchInfo);
        //    Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
        //    Assert.AreEqual(matchInfo.Original, a);
        //    Assert.AreEqual(matchInfo.Modified, b);
        //}

        //[TestMethod]
        //public void TypeArgumentListServiceProvider_NameEqualityMatch_OK()
        //{
        //    var flad = new CSharpFlad();
        //    var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
        //    MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

        //    var a = ((GenericNameSyntax)SyntaxFactory.ParseName("a<c,b>")).TypeArgumentList;
        //    var b = ((GenericNameSyntax)SyntaxFactory.ParseName("a<c1,b>")).TypeArgumentList;
        //    Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().TypeArgumentListServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
        //    Assert.IsNull(matchInfo);
        //    Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().TypeArgumentListServiceProvider.NameEqualityMatch(a, null, matchingContext, out matchInfo));
        //    Assert.IsNull(matchInfo);
        //    Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().TypeArgumentListServiceProvider.NameEqualityMatch(null, null, matchingContext, out matchInfo));
        //    Assert.IsNull(matchInfo);
        //    Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().TypeArgumentListServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
        //    Assert.IsNull(matchInfo);

        //    a = ((GenericNameSyntax)SyntaxFactory.ParseName("a<c,b>")).TypeArgumentList;
        //    b = ((GenericNameSyntax)SyntaxFactory.ParseName("a<b>")).TypeArgumentList;
        //    Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().TypeArgumentListServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
        //    Assert.IsNull(matchInfo);

        //    a = ((GenericNameSyntax)SyntaxFactory.ParseName("a<c,b>")).TypeArgumentList;
        //    b = ((GenericNameSyntax)SyntaxFactory.ParseName("a<c,b>")).TypeArgumentList;
        //    Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().TypeArgumentListServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
        //    Assert.IsNotNull(matchInfo);
        //    Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
        //    Assert.AreEqual(matchInfo.Original, a);
        //    Assert.AreEqual(matchInfo.Modified, b);

        //    a = ((GenericNameSyntax)SyntaxFactory.ParseName("a<,>")).TypeArgumentList;
        //    b = ((GenericNameSyntax)SyntaxFactory.ParseName("a<,>")).TypeArgumentList;
        //    Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().TypeArgumentListServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
        //    Assert.IsNotNull(matchInfo);
        //    Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
        //    Assert.AreEqual(matchInfo.Original, a);
        //    Assert.AreEqual(matchInfo.Modified, b);
        //}

        //[TestMethod]
        //public void ConstructorInitializerServiceProvider_NameEqualityMatch_OK()
        //{
        //    var flad = new CSharpFlad();
        //    var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
        //    MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

        //    var a = ((ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { public A(B b) : this(b) { } }").Members[0]).Members[0]).Initializer;
        //    var b = ((ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { public A(B b) : this() { } }").Members[0]).Members[0]).Initializer;
        //    Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().ConstructorInitializerServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
        //    Assert.IsNull(matchInfo);
        //    Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().ConstructorInitializerServiceProvider.NameEqualityMatch(a, null, matchingContext, out matchInfo));
        //    Assert.IsNull(matchInfo);
        //    Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().ConstructorInitializerServiceProvider.NameEqualityMatch(null, null, matchingContext, out matchInfo));
        //    Assert.IsNull(matchInfo);
        //    Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().ConstructorInitializerServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
        //    Assert.IsNotNull(matchInfo);
        //    Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
        //    Assert.AreEqual(matchInfo.Original, a);
        //    Assert.AreEqual(matchInfo.Modified, b);

        //    a = ((ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { public A(B b) : this(b) { } }").Members[0]).Members[0]).Initializer;
        //    b = ((ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { public A(B b) : this(c) { } }").Members[0]).Members[0]).Initializer;
        //    Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().ConstructorInitializerServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
        //    Assert.IsNotNull(matchInfo);
        //    Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
        //    Assert.AreEqual(matchInfo.Original, a);
        //    Assert.AreEqual(matchInfo.Modified, b);

        //    a = ((ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { public A(B b) : this(b) { } }").Members[0]).Members[0]).Initializer;
        //    b = ((ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { public A(B b) : this(b) { } }").Members[0]).Members[0]).Initializer;
        //    Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().ConstructorInitializerServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
        //    Assert.IsNotNull(matchInfo);
        //    Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
        //    Assert.AreEqual(matchInfo.Original, a);
        //    Assert.AreEqual(matchInfo.Modified, b);

        //    a = ((ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { public A(B b) : this() { } }").Members[0]).Members[0]).Initializer;
        //    b = ((ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { public A(B b) : this() { } }").Members[0]).Members[0]).Initializer;
        //    Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().ConstructorInitializerServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
        //    Assert.IsNotNull(matchInfo);
        //    Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
        //    Assert.AreEqual(matchInfo.Original, a);
        //    Assert.AreEqual(matchInfo.Modified, b);



        //    a = ((ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { public A(B b) : base(b) { } }").Members[0]).Members[0]).Initializer;
        //    b = ((ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { public A(B b) : base() { } }").Members[0]).Members[0]).Initializer;
        //    Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().ConstructorInitializerServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
        //    Assert.IsNull(matchInfo);
        //    Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().ConstructorInitializerServiceProvider.NameEqualityMatch(a, null, matchingContext, out matchInfo));
        //    Assert.IsNull(matchInfo);
        //    Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().ConstructorInitializerServiceProvider.NameEqualityMatch(null, null, matchingContext, out matchInfo));
        //    Assert.IsNull(matchInfo);
        //    Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().ConstructorInitializerServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
        //    Assert.IsNotNull(matchInfo);
        //    Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
        //    Assert.AreEqual(matchInfo.Original, a);
        //    Assert.AreEqual(matchInfo.Modified, b);

        //    a = ((ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { public A(B b) : base(b) { } }").Members[0]).Members[0]).Initializer;
        //    b = ((ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { public A(B b) : base(c) { } }").Members[0]).Members[0]).Initializer;
        //    Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().ConstructorInitializerServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
        //    Assert.IsNotNull(matchInfo);
        //    Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
        //    Assert.AreEqual(matchInfo.Original, a);
        //    Assert.AreEqual(matchInfo.Modified, b);

        //    a = ((ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { public A(B b) : base(b) { } }").Members[0]).Members[0]).Initializer;
        //    b = ((ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { public A(B b) : base(b) { } }").Members[0]).Members[0]).Initializer;
        //    Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().ConstructorInitializerServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
        //    Assert.IsNotNull(matchInfo);
        //    Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
        //    Assert.AreEqual(matchInfo.Original, a);
        //    Assert.AreEqual(matchInfo.Modified, b);

        //    a = ((ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { public A(B b) : base() { } }").Members[0]).Members[0]).Initializer;
        //    b = ((ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { public A(B b) : base() { } }").Members[0]).Members[0]).Initializer;
        //    Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().ConstructorInitializerServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
        //    Assert.IsNotNull(matchInfo);
        //    Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
        //    Assert.AreEqual(matchInfo.Original, a);
        //    Assert.AreEqual(matchInfo.Modified, b);

        //    a = ((ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { public A(B b) : this() { } }").Members[0]).Members[0]).Initializer;
        //    b = ((ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { public A(B b) : base() { } }").Members[0]).Members[0]).Initializer;
        //    Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().ConstructorInitializerServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
        //    Assert.IsNull(matchInfo);
        //}

        //[TestMethod]
        //public void AccessorDeclarationServiceProvider_NameEqualityMatch_OK()
        //{
        //    var flad = new CSharpFlad();
        //    var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
        //    MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

        //    var get = ((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A C.this[string key] { [Documentation] public get{return this.M[key];} [Serialization] public set{this.M[key] = value;} }").Members[0]).AccessorList.Accessors[0];
        //    var set = ((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A C.this[string key] { [Documentation] public get{return this.M[key];} [Serialization] public set{this.M[key] = value;} }").Members[0]).AccessorList.Accessors[1];
        //    var add = ((EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("event A C { [Documentation] public add{this.M += value;} [Serialization] public remove{this.M -= value;} }").Members[0]).AccessorList.Accessors[0];
        //    var remove = ((EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("event A C { [Documentation] public add{this.M += value;} [Serialization] public remove{this.M -= value;} }").Members[0]).AccessorList.Accessors[1];

        //    var get1 = ((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A C.this[string key] { [Documentation] public get{return this.M[key];} [Serialization] public set{this.M[key] = value;} }").Members[0]).AccessorList.Accessors[0];
        //    var set1 = ((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A C.this[string key] { [Documentation] public get{return this.M[key];} [Serialization] public set{this.M[key] = value;} }").Members[0]).AccessorList.Accessors[1];
        //    var add1 = ((EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("event A C { [Documentation] public add{this.M += value;} [Serialization] public remove{this.M -= value;} }").Members[0]).AccessorList.Accessors[0];
        //    var remove1 = ((EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("event A C { [Documentation] public add{this.M += value;} [Serialization] public remove{this.M -= value;} }").Members[0]).AccessorList.Accessors[1];

        //    Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AccessorDeclarationServiceProvider.NameEqualityMatch(null, get, matchingContext, out matchInfo));
        //    Assert.IsNull(matchInfo);
        //    Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AccessorDeclarationServiceProvider.NameEqualityMatch(get, null, matchingContext, out matchInfo));
        //    Assert.IsNull(matchInfo);
        //    Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AccessorDeclarationServiceProvider.NameEqualityMatch(null, null, matchingContext, out matchInfo));
        //    Assert.IsNull(matchInfo);
        //    Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AccessorDeclarationServiceProvider.NameEqualityMatch(get, set, matchingContext, out matchInfo));
        //    Assert.IsNull(matchInfo);
        //    Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AccessorDeclarationServiceProvider.NameEqualityMatch(get, add, matchingContext, out matchInfo));
        //    Assert.IsNull(matchInfo);
        //    Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AccessorDeclarationServiceProvider.NameEqualityMatch(get, remove, matchingContext, out matchInfo));
        //    Assert.IsNull(matchInfo);
        //    Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AccessorDeclarationServiceProvider.NameEqualityMatch(get, get1, matchingContext, out matchInfo));
        //    Assert.IsNotNull(matchInfo);
        //    Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
        //    Assert.AreEqual(matchInfo.Original, get);
        //    Assert.AreEqual(matchInfo.Modified, get1);

        //    Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AccessorDeclarationServiceProvider.NameEqualityMatch(null, set, matchingContext, out matchInfo));
        //    Assert.IsNull(matchInfo);
        //    Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AccessorDeclarationServiceProvider.NameEqualityMatch(set, null, matchingContext, out matchInfo));
        //    Assert.IsNull(matchInfo);
        //    Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AccessorDeclarationServiceProvider.NameEqualityMatch(null, null, matchingContext, out matchInfo));
        //    Assert.IsNull(matchInfo);
        //    Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AccessorDeclarationServiceProvider.NameEqualityMatch(set, add, matchingContext, out matchInfo));
        //    Assert.IsNull(matchInfo);
        //    Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AccessorDeclarationServiceProvider.NameEqualityMatch(set, remove, matchingContext, out matchInfo));
        //    Assert.IsNull(matchInfo);
        //    Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AccessorDeclarationServiceProvider.NameEqualityMatch(set, set1, matchingContext, out matchInfo));
        //    Assert.IsNotNull(matchInfo);
        //    Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
        //    Assert.AreEqual(matchInfo.Original, set);
        //    Assert.AreEqual(matchInfo.Modified, set1);

        //    Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AccessorDeclarationServiceProvider.NameEqualityMatch(null, add, matchingContext, out matchInfo));
        //    Assert.IsNull(matchInfo);
        //    Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AccessorDeclarationServiceProvider.NameEqualityMatch(add, null, matchingContext, out matchInfo));
        //    Assert.IsNull(matchInfo);
        //    Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AccessorDeclarationServiceProvider.NameEqualityMatch(null, null, matchingContext, out matchInfo));
        //    Assert.IsNull(matchInfo);
        //    Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AccessorDeclarationServiceProvider.NameEqualityMatch(add, remove, matchingContext, out matchInfo));
        //    Assert.IsNull(matchInfo);
        //    Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AccessorDeclarationServiceProvider.NameEqualityMatch(add, add1, matchingContext, out matchInfo));
        //    Assert.IsNotNull(matchInfo);
        //    Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
        //    Assert.AreEqual(matchInfo.Original, add);
        //    Assert.AreEqual(matchInfo.Modified, add1);

        //    Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AccessorDeclarationServiceProvider.NameEqualityMatch(null, remove, matchingContext, out matchInfo));
        //    Assert.IsNull(matchInfo);
        //    Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AccessorDeclarationServiceProvider.NameEqualityMatch(remove, null, matchingContext, out matchInfo));
        //    Assert.IsNull(matchInfo);
        //    Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AccessorDeclarationServiceProvider.NameEqualityMatch(null, null, matchingContext, out matchInfo));
        //    Assert.IsNull(matchInfo);
        //    Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().AccessorDeclarationServiceProvider.NameEqualityMatch(remove, remove1, matchingContext, out matchInfo));
        //    Assert.IsNotNull(matchInfo);
        //    Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
        //    Assert.AreEqual(matchInfo.Original, remove);
        //    Assert.AreEqual(matchInfo.Modified, remove1);
        //}

        [TestMethod]
        public void QualifiedNameServiceProvider_NameEqualityMatch_OK()
        {
            var flad = new Jawilliam.CDF.CSharp.Awareness.Flad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var node = SyntaxFactory.ParseName("a.b.c");
            var a = (QualifiedNameSyntax)SyntaxFactory.ParseName("a.b.c");
            var b = (QualifiedNameSyntax)SyntaxFactory.ParseName("a.b.c");
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().QualifiedNameServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().QualifiedNameServiceProvider.NameEqualityMatch(a, null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().QualifiedNameServiceProvider.NameEqualityMatch(null, null, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
            Assert.IsTrue(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().QualifiedNameServiceProvider.NameEqualityMatch(a, b, matchingContext, out matchInfo));
            Assert.IsNotNull(matchInfo);
            Assert.AreEqual(matchInfo.Criterion, (int)MatchInfoCriterions.NameEquality);
            Assert.AreEqual(matchInfo.Original, a);
            Assert.AreEqual(matchInfo.Modified, b);

            a = (QualifiedNameSyntax)SyntaxFactory.ParseName("a.b1.c");
            b = (QualifiedNameSyntax)SyntaxFactory.ParseName("a.b.c");
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().QualifiedNameServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = (QualifiedNameSyntax)SyntaxFactory.ParseName("a1.b.c");
            b = (QualifiedNameSyntax)SyntaxFactory.ParseName("a.b.c");
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().QualifiedNameServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);

            a = (QualifiedNameSyntax)SyntaxFactory.ParseName("a.b.c1");
            b = (QualifiedNameSyntax)SyntaxFactory.ParseName("a.b.c");
            Assert.IsFalse(flad.LanguageProvider<Jawilliam.CDF.CSharp.Awareness.LanguageServiceProvider>().QualifiedNameServiceProvider.NameEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsNull(matchInfo);
        }

        [TestMethod]
        public void DefinitionOfNameBasedSuitableProperty()
        {
            var rdsl = CDF.XObjects.RDSL.Syntax.Load(@"..\..\..\Jawilliam.CDF.CSharp\RDSL.xml");
            var concreteTypes = rdsl.Nodes.Type.Where(n => !n.@abstract).ToArray();

            var suitableProperties = (from t in concreteTypes
                                      from p in t.Properties?.Property
                                      where p.Rules?.Name?.Count > 0
                                      select new { Type = t, Property = p }).ToArray();

            var identifierProperties = (from t in concreteTypes
                                        from p in t.Properties?.Property
                                        where p.name == "Identifier" && t.name != "AttributeTargetSpecifierSyntax"
                                        select new { Type = t, Property = p }).ToArray();
            Assert.AreEqual(identifierProperties.Except(suitableProperties).ToArray().Length, 0);

            var nameProperties = (from t in concreteTypes
                                  from p in t.Properties?.Property
                                  where p.name == "Name" && !p.readOnly //t.name != "XmlCrefAttributeSyntax" && t.name != "XmlNameAttributeSyntax"
                                  select new { Type = t, Property = p }).ToArray();
            Assert.AreEqual(nameProperties.Except(suitableProperties).ToArray().Length, 0);

            var thisKeywordProperties = (from t in concreteTypes
                                         from p in t.Properties?.Property
                                         where p.name == "ThisKeyword"
                                         select new { Type = t, Property = p }).ToArray();
            Assert.AreEqual(thisKeywordProperties.Except(suitableProperties).ToArray().Length, 0);

            var operatorTokenProperties = (from t in concreteTypes
                                           from p in t.Properties?.Property
                                           where p.name == "OperatorToken" && t.name.Contains("Operator")
                                           select new { Type = t, Property = p }).ToArray();
            Assert.AreEqual(operatorTokenProperties.Except(suitableProperties).ToArray().Length, 0);

            var prefixProperties = (from t in concreteTypes
                                    from p in t.Properties?.Property
                                    where p.name == "Prefix"
                                    select new { Type = t, Property = p }).ToArray();
            Assert.AreEqual(prefixProperties.Except(suitableProperties).ToArray().Length, 0);

            var specialCases = (from t in concreteTypes
                                from p in t.Properties?.Property
                                where (p.name == "LocalName" && t.name == "XmlNameSyntax") ||
                                      (p.name == "Variables" && t.name == "VariableDeclarationSyntax") ||
                                      (p.name == "Cref" && t.name == "XmlCrefAttributeSyntax") ||
                                      (p.name == "Expression" && t.name == "MemberAccessExpressionSyntax")
                                select new { Type = t, Property = p }).ToArray();
            Assert.AreEqual(specialCases.Except(suitableProperties).ToArray().Length, 0);

            var propertiesSuitableSoFar = identifierProperties
                .Union(nameProperties)
                .Union(thisKeywordProperties)
                .Union(operatorTokenProperties)
                .Union(prefixProperties)
                .Union(specialCases)
            .ToArray();

            var typeInfos = concreteTypes.Select(t => new
            {
                Class = typeof(CSharpSyntaxNode).Assembly.GetType("Microsoft.CodeAnalysis.CSharp.Syntax." + t.name),
                Type = t
            })
            .ToDictionary(m => m.Type.name);

            var propertyTypeIsSuitableProperties = (from t in concreteTypes
                                                    from p in t.Properties?.Property
                                                    let typeInfo = typeInfos.Any(ti => ti.Value.Type == t) ? typeInfos.Single(ti => ti.Value.Type == t).Value.Class : null
                                                    let propertyInfo = typeInfo?.GetProperty(p.name)
                                                    let propertyGenericTypeInfo = propertyInfo?.PropertyType.IsGenericType ?? false
                                                        ? propertyInfo.PropertyType.GetGenericTypeDefinition()
                                                        : null
                                                    let collectionOf = propertyGenericTypeInfo == typeof(SyntaxList<>) || propertyGenericTypeInfo == typeof(SeparatedSyntaxList<>)
                                                        ? propertyInfo.PropertyType.GetGenericArguments().Single()
                                                        : null
                                                    let collectionOfType = collectionOf != null && typeInfos.Any(ti => ti.Value.Class == collectionOf)
                                                        ? typeInfos.Single(ti => ti.Value.Class == collectionOf).Value.Type
                                                        : null
                                                    let propertyElementType = typeInfos.Any(ti => ti.Value.Class == propertyInfo.PropertyType)
                                                        ? typeInfos.Single(ti => ti.Value.Class == propertyInfo.PropertyType).Value.Type
                                                        : null
                                                    where !p.readOnly && 
                                                          (typeof(NameSyntax).IsAssignableFrom(propertyInfo?.PropertyType) ||
                                                          (propertyElementType != null && propertiesSuitableSoFar.Any(psf => psf.Type == propertyElementType)))                                                       
                                                    select new { Type = t, Property = p }).ToArray();

            var a = propertyTypeIsSuitableProperties.Except(suitableProperties).ToArray();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            int i = 0;
            foreach (var prop in suitableProperties)
            {
                
                sb.AppendLine($"#{++i} {prop.Property.name} in {prop.Type.name}");

            }
            System.IO.File.WriteAllText(@"D:\Reports\Temp.txt", sb.ToString());
            //var b1 = suitableProperties.Except(propertiesSuitableSoFar.Union(propertyTypeIsSuitableProperties)).ToArray();
            //var b2 = propertiesSuitableSoFar.Union(propertyTypeIsSuitableProperties).Except(suitableProperties).ToArray();
            //var b3 = suitableProperties.Except(propertyTypeIsSuitableProperties).ToArray();
            //var b4 = propertyTypeIsSuitableProperties.Except(suitableProperties).ToArray();
            var r = propertyTypeIsSuitableProperties.Except(suitableProperties).ToArray();
            Assert.AreEqual(propertyTypeIsSuitableProperties.Except(suitableProperties).ToArray().Length, 0);
            //Assert.AreEqual(suitableProperties.Except(propertyTypeIsSuitableProperties).ToArray().Length, 0);
            Assert.AreEqual(suitableProperties.Except(propertiesSuitableSoFar.Union(propertyTypeIsSuitableProperties)).ToArray().Length, 0);
            Assert.AreEqual(propertiesSuitableSoFar.Union(propertyTypeIsSuitableProperties).Except(suitableProperties).ToArray().Length, 0);
        }

        //[TestMethod]
        //public void DefinitionOfNameBasedSuitableProperty2()
        //{
        //    var rdsl = CDF.XObjects.RDSL.Syntax.Load(@"..\..\..\Jawilliam.CDF.CSharp\RDSL.xml");
        //    var concreteTypes = rdsl.Nodes.Type.Where(n => !n.@abstract).ToArray();

        //    var suitableProperties = (from t in concreteTypes
        //                              from p in t.Properties?.Property
        //                              where p.Rules?.Name?.Count > 0
        //                              select new { Type = t, Property = p }).ToArray();

        //    var identifierProperties = (from t in concreteTypes
        //                                from p in t.Properties?.Property
        //                                where p.hashtags.Contains("#IDENTIFIER")
        //                                select new { Type = t, Property = p }).ToArray();
        //    Assert.AreEqual(identifierProperties.Except(suitableProperties).ToArray().Length, 0);

        //    var nameProperties = (from t in concreteTypes
        //                          from p in t.Properties?.Property
        //                          where p.name == "Name" && !p.readOnly //t.name != "XmlCrefAttributeSyntax" && t.name != "XmlNameAttributeSyntax"
        //                          select new { Type = t, Property = p }).ToArray();
        //    Assert.AreEqual(nameProperties.Except(suitableProperties).ToArray().Length, 0);

        //    var thisKeywordProperties = (from t in concreteTypes
        //                                 from p in t.Properties?.Property
        //                                 where p.name == "ThisKeyword"
        //                                 select new { Type = t, Property = p }).ToArray();
        //    Assert.AreEqual(thisKeywordProperties.Except(suitableProperties).ToArray().Length, 0);

        //    var operatorTokenProperties = (from t in concreteTypes
        //                                   from p in t.Properties?.Property
        //                                   where p.name == "OperatorToken" && t.name.Contains("Operator")
        //                                   select new { Type = t, Property = p }).ToArray();
        //    Assert.AreEqual(operatorTokenProperties.Except(suitableProperties).ToArray().Length, 0);

        //    var prefixProperties = (from t in concreteTypes
        //                            from p in t.Properties?.Property
        //                            where p.name == "Prefix"
        //                            select new { Type = t, Property = p }).ToArray();
        //    Assert.AreEqual(prefixProperties.Except(suitableProperties).ToArray().Length, 0);

        //    var specialCases = (from t in concreteTypes
        //                        from p in t.Properties?.Property
        //                        where (p.name == "LocalName" && t.name == "XmlNameSyntax") ||
        //                              (p.name == "Variables" && t.name == "VariableDeclarationSyntax") ||
        //                              (p.name == "Cref" && t.name == "XmlCrefAttributeSyntax") ||
        //                              (p.name == "Expression" && t.name == "MemberAccessExpressionSyntax")
        //                        select new { Type = t, Property = p }).ToArray();
        //    Assert.AreEqual(specialCases.Except(suitableProperties).ToArray().Length, 0);

        //    var propertiesSuitableSoFar = identifierProperties
        //        .Union(nameProperties)
        //        .Union(thisKeywordProperties)
        //        .Union(operatorTokenProperties)
        //        .Union(prefixProperties)
        //        .Union(specialCases)
        //    .ToArray();

        //    var typeInfos = concreteTypes.Select(t => new
        //    {
        //        Class = typeof(CSharpSyntaxNode).Assembly.GetType("Microsoft.CodeAnalysis.CSharp.Syntax." + t.name),
        //        Type = t
        //    })
        //    .ToDictionary(m => m.Type.name);

        //    var propertyTypeIsSuitableProperties = (from t in concreteTypes
        //                                            from p in t.Properties?.Property
        //                                            let typeInfo = typeInfos.Any(ti => ti.Value.Type == t) ? typeInfos.Single(ti => ti.Value.Type == t).Value.Class : null
        //                                            let propertyInfo = typeInfo?.GetProperty(p.name)
        //                                            let propertyGenericTypeInfo = propertyInfo?.PropertyType.IsGenericType ?? false
        //                                                ? propertyInfo.PropertyType.GetGenericTypeDefinition()
        //                                                : null
        //                                            let collectionOf = propertyGenericTypeInfo == typeof(SyntaxList<>) || propertyGenericTypeInfo == typeof(SeparatedSyntaxList<>)
        //                                                ? propertyInfo.PropertyType.GetGenericArguments().Single()
        //                                                : null
        //                                            let collectionOfType = collectionOf != null && typeInfos.Any(ti => ti.Value.Class == collectionOf)
        //                                                ? typeInfos.Single(ti => ti.Value.Class == collectionOf).Value.Type
        //                                                : null
        //                                            let propertyElementType = typeInfos.Any(ti => ti.Value.Class == propertyInfo.PropertyType)
        //                                                ? typeInfos.Single(ti => ti.Value.Class == propertyInfo.PropertyType).Value.Type
        //                                                : null
        //                                            where !p.readOnly &&
        //                                                  (typeof(NameSyntax).IsAssignableFrom(propertyInfo?.PropertyType) ||
        //                                                  (propertyElementType != null && propertiesSuitableSoFar.Any(psf => psf.Type == propertyElementType)))
        //                                            select new { Type = t, Property = p }).ToArray();

        //    var a = propertyTypeIsSuitableProperties.Except(suitableProperties).ToArray();
        //    //System.Text.StringBuilder sb = new System.Text.StringBuilder();
        //    //foreach (var prop in a)
        //    //{
        //    //    int i = 0;
        //    //    sb.AppendLine($"#{++i} {prop.Property.name} in {prop.Type.name}");

        //    //}
        //    //System.IO.File.WriteAllText(@"D:\Reports\Temp.txt", sb.ToString());
        //    var b = suitableProperties.Except(propertiesSuitableSoFar.Union(propertyTypeIsSuitableProperties)).ToArray();
        //    Assert.AreEqual(propertyTypeIsSuitableProperties.Except(suitableProperties).ToArray().Length, 0);
        //    Assert.AreEqual(suitableProperties.Except(propertyTypeIsSuitableProperties).ToArray().Length, 0);
        //}

        [TestMethod]
        public void AllElementTypeSuitableFor_NameEqualityMatch_IsTested()
        {
            var rdsl = CDF.XObjects.RDSL.Syntax.Load(@"..\..\..\Jawilliam.CDF.CSharp\RDSL.xml");
            var concreteTypes = rdsl.Nodes.Type.Where(n => !n.@abstract).ToArray();

            var cases = (from t in concreteTypes
                         where t.Properties?.Property.Any(p => p.Rules?.Name?.Any(n => n.equality && n.absolute) ?? false) ?? false
                         select t.name).ToList();

            var testedCases = (from m in this.GetType().GetMethods()
                              let nameParts = m.Name.Split(new[] { '_' }, StringSplitOptions.RemoveEmptyEntries)
                              where nameParts.Length == 3 && nameParts[1] == "NameEqualityMatch" && nameParts[2] == "OK"
                              select nameParts[0].Replace("ServiceProvider", "Syntax")).ToList();

            var a = cases.Except(testedCases).ToArray();
            var b = testedCases.Except(cases).ToArray();

            Assert.AreEqual(a.Count(), 0);
            Assert.AreEqual(b.Count(), 0);
        }
    }
}
