using System;
using System.Linq;
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
    public class SignatureEqualityServicesTests
    {
        [TestMethod]
        public void TypeParameterListServiceProvider_SignatureEqualityMatch_OK()
        {
            var flad = new CSharpFlad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<B, in C1, out D, [Serializable]E, [Serializable] in F> {B a1; internal static A b2 = 3; [Serializable]A c3 = 3; [Serializable]public int df = 34;}").Members[0]).TypeParameterList;
            var b = ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<B, in C, out D, [Serializable]E, [Serializable] in F> {B a1; internal static A b2 = 3; [Serializable]A c3 = 3; [Serializable]public int df = 34;}").Members[0]).TypeParameterList;
            Assert.IsFalse(flad.LanguageServiceProvider.TypeParameterListServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.TypeParameterListServiceProvider.SignatureEqualityMatch(a, (TypeParameterListSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.TypeParameterListServiceProvider.SignatureEqualityMatch(null, (TypeParameterListSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.TypeParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<B, out D, [Serializable]E, [Serializable] in F> {B a1; internal static A b2 = 3; [Serializable]A c3 = 3; [Serializable]public int df = 34;}").Members[0]).TypeParameterList;
            b = ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<B, in C, out D, [Serializable]E, [Serializable] in F> {B a1; internal static A b2 = 3; [Serializable]A c3 = 3; [Serializable]public int df = 34;}").Members[0]).TypeParameterList;
            Assert.IsFalse(flad.LanguageServiceProvider.TypeParameterListServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.TypeParameterListServiceProvider.SignatureEqualityMatch(a, (TypeParameterListSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.TypeParameterListServiceProvider.SignatureEqualityMatch(null, (TypeParameterListSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.TypeParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<B, in C, out D, [Serializable]E, [Serializable] in F> {B a1; internal static A b2 = 3; [Serializable]A c3 = 3; [Serializable]public int df = 34;}").Members[0]).TypeParameterList;
            b = ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class b<B, in C, out D, [Serializable]E, [Serializable] in F> {B a1; internal static A b2 = 3; [Serializable]A c3 = 3; [Serializable]public int df = 34;}").Members[0]).TypeParameterList;
            Assert.IsTrue(flad.LanguageServiceProvider.TypeParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<B, in C, out D, [Serializable]E, [Serializable] in F> {B a1; internal static A b2 = 3; [Serializable]A c3 = 3; [Serializable]public int df = 34;}").Members[0]).TypeParameterList;
            b = ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<B, in C, out D, [Serializable]E, [Serializable] in F> {B a1; internal static A b2 = 3; [Serializable]A c3 = 3; [Serializable]public int df = 34;}").Members[0]).TypeParameterList;
            Assert.IsTrue(flad.LanguageServiceProvider.TypeParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));
        }

        [TestMethod]
        public void TypeParameterServiceProvider_SignatureEqualityMatch_OK()
        {
            var flad = new CSharpFlad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<B, in C1, out D, [Serializable]E, [Serializable] in F> {B a1; internal static A b2 = 3; [Serializable]A c3 = 3; [Serializable]public int df = 34;}").Members[0]).TypeParameterList.Parameters[1];
            var b = ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<B, in C, out D, [Serializable]E, [Serializable] in F> {B a1; internal static A b2 = 3; [Serializable]A c3 = 3; [Serializable]public int df = 34;}").Members[0]).TypeParameterList.Parameters[1];
            Assert.IsFalse(flad.LanguageServiceProvider.TypeParameterServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.TypeParameterServiceProvider.SignatureEqualityMatch(a, (TypeParameterSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.TypeParameterServiceProvider.SignatureEqualityMatch(null, (TypeParameterSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.TypeParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<B, in C1, out D, [Serializable]E, [Serializable] in F> {B a1; internal static A b2 = 3; [Serializable]A c3 = 3; [Serializable]public int df = 34;}").Members[0]).TypeParameterList.Parameters[1];
            b = ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<B, in C, out D, [Serializable]E, [Serializable] in F> {B a1; internal static A b2 = 3; [Serializable]A c3 = 3; [Serializable]public int df = 34;}").Members[0]).TypeParameterList.Parameters[1];
            Assert.IsFalse(flad.LanguageServiceProvider.TypeParameterServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.TypeParameterServiceProvider.SignatureEqualityMatch(a, (TypeParameterSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.TypeParameterServiceProvider.SignatureEqualityMatch(null, (TypeParameterSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.TypeParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<B, in C, out D, [Serializable]E, [Serializable] in F> {B a1; internal static A b2 = 3; [Serializable]A c3 = 3; [Serializable]public int df = 34;}").Members[0]).TypeParameterList.Parameters[1];
            b = ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class b<B, in C, out D, [Serializable]E, [Serializable] in F> {B a1; internal static A b2 = 3; [Serializable]A c3 = 3; [Serializable]public int df = 34;}").Members[0]).TypeParameterList.Parameters[1];
            Assert.IsTrue(flad.LanguageServiceProvider.TypeParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<B, in C, out D, [Serializable]E, [Serializable] in F> {B a1; internal static A b2 = 3; [Serializable]A c3 = 3; [Serializable]public int df = 34;}").Members[0]).TypeParameterList.Parameters[1];
            b = ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<B, in C, out D, [Serializable]E, [Serializable] in F> {B a1; internal static A b2 = 3; [Serializable]A c3 = 3; [Serializable]public int df = 34;}").Members[0]).TypeParameterList.Parameters[1];
            Assert.IsTrue(flad.LanguageServiceProvider.TypeParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));
        }

        [TestMethod]
        public void ParameterServiceProvider_SignatureEqualityMatch_OK()
        {
            var flad = new CSharpFlad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = ((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int M([Serializable] ref int1 a = 0, A b){}").Members[0]).ParameterList.Parameters[0];
            var b = ((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int M([Serializable] ref int b = 0, A b){}").Members[0]).ParameterList.Parameters[0];
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterServiceProvider.SignatureEqualityMatch(a, null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterServiceProvider.SignatureEqualityMatch(null, null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = ((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int M([Serializable] ref int1 a = 0, A b){}").Members[0]).ParameterList.Parameters[0];
            b = ((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int M([Serializable] ref int a = 0, A b){}").Members[0]).ParameterList.Parameters[0];
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterServiceProvider.SignatureEqualityMatch(a, null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterServiceProvider.SignatureEqualityMatch(null, null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = ((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int M([Serializable] ref int a1 = 0, A b){}").Members[0]).ParameterList.Parameters[0];
            b = ((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int M([Serializable] ref int b = 0, A b){}").Members[0]).ParameterList.Parameters[0];
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterServiceProvider.SignatureEqualityMatch(a, null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterServiceProvider.SignatureEqualityMatch(null, null, matchingContext, out matchInfo));
            Assert.IsTrue(flad.LanguageServiceProvider.ParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = ((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int M([Serializable] ref int a = 0, A b){}").Members[0]).ParameterList.Parameters[0];
            b = ((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int M([Serializable] ref int a = 0, A b){}").Members[0]).ParameterList.Parameters[0];
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterServiceProvider.SignatureEqualityMatch(a, null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterServiceProvider.SignatureEqualityMatch(null, null, matchingContext, out matchInfo));
            Assert.IsTrue(flad.LanguageServiceProvider.ParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = ((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int M([Serializable] int1 a = 0, A b){}").Members[0]).ParameterList.Parameters[0];
            b = ((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int M([Serializable] int b = 0, A b){}").Members[0]).ParameterList.Parameters[0];
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterServiceProvider.SignatureEqualityMatch(a, null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterServiceProvider.SignatureEqualityMatch(null, null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = ((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int M([Serializable] int1 a = 0, A b){}").Members[0]).ParameterList.Parameters[0];
            b = ((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int M([Serializable] int a = 0, A b){}").Members[0]).ParameterList.Parameters[0];
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterServiceProvider.SignatureEqualityMatch(a, null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterServiceProvider.SignatureEqualityMatch(null, null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = ((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int M([Serializable] int a1 = 0, A b){}").Members[0]).ParameterList.Parameters[0];
            b = ((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int M([Serializable] int b = 0, A b){}").Members[0]).ParameterList.Parameters[0];
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterServiceProvider.SignatureEqualityMatch(a, null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterServiceProvider.SignatureEqualityMatch(null, null, matchingContext, out matchInfo));
            Assert.IsTrue(flad.LanguageServiceProvider.ParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = ((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int M([Serializable] int a = 0, A b){}").Members[0]).ParameterList.Parameters[0];
            b = ((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int M([Serializable] int a = 0, A b){}").Members[0]).ParameterList.Parameters[0];
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterServiceProvider.SignatureEqualityMatch(a, null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterServiceProvider.SignatureEqualityMatch(null, null, matchingContext, out matchInfo));
            Assert.IsTrue(flad.LanguageServiceProvider.ParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));
        }

        [TestMethod]
        public void CrefParameterServiceProvider_SignatureEqualityMatch_OK()
        {
            var flad = new CSharpFlad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            // string aliases
            var a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref string1, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            var b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref string, out string)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(null, null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref string, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref string, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref string, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref String, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref String, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref string, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref string, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.String, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.String, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref string, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref String, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.String, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            // bool aliases
            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref bool1, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref bool, out string)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(null, null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref bool, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref bool, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref bool, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Boolean, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Boolean, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref bool, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref bool, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.Boolean, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.Boolean, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref bool, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Boolean, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.Boolean, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.Boolean, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Boolean, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            // byte aliases
            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref byte1, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref byte, out string)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(null, null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref byte, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref byte, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref byte, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Byte, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Byte, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref byte, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref byte, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.Byte, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.Byte, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref byte, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Byte, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.Byte, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.Byte, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Byte, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            // sbyte aliases
            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref sbyte1, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref sbyte, out string)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(null, null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref sbyte, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref sbyte, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref sbyte, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref SByte, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref SByte, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref sbyte, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref sbyte, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.SByte, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.SByte, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref sbyte, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref SByte, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.SByte, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.SByte, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref SByte, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            // bool aliases
            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref bool1, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref bool, out string)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(null, null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref bool, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref bool, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref bool, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Boolean, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Boolean, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref bool, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref bool, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.Boolean, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.Boolean, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref bool, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Boolean, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.Boolean, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.Boolean, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Boolean, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            // decimal aliases
            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref decimal1, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref decimal, out string)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(null, null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref decimal, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref decimal, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref decimal, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Decimal, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Decimal, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref decimal, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref decimal, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.Decimal, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.Decimal, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref decimal, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Decimal, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.Decimal, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.Decimal, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Decimal, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            // double aliases
            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref double1, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref double, out string)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(null, null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref double, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref double, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref double, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Double, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Double, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref double, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref double, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.Double, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.Double, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref double, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Double, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.Double, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.Double, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Double, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            // float aliases
            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref float1, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref float, out string)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(null, null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref float, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref float, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref float, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Single, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Single, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref float, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref float, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.Single, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.Single, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref float, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Single, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.Single, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.Single, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Single, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            // int aliases
            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref int1, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref int, out string)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(null, null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref int, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref int, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref int, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Int32, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Int32, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref int, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref int, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.Int32, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.Int32, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref int, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Int32, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.Int32, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.Int32, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Int32, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            // uint aliases
            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref uint1, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref uint, out string)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(null, null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref uint, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref uint, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref uint, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref UInt32, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref UInt32, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref uint, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref uint, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.UInt32, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.UInt32, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref uint, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref UInt32, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.UInt32, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.UInt32, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref UInt32, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            // long aliases
            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref long1, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref long, out string)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(null, null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref long, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref long, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref long, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Int64, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Int64, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref long, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref long, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.Int64, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.Int64, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref long, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Int64, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.Int64, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.Int64, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Int64, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            // ulong aliases
            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref ulong1, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref ulong, out string)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(null, null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref ulong, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref ulong, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref ulong, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref UInt64, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref UInt64, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref ulong, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref ulong, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.UInt64, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.UInt64, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref ulong, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref UInt64, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.UInt64, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.UInt64, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref UInt64, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            // object aliases
            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref object1, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref object, out string)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(null, null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref object, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref object, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref object, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Object, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Object, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref object, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref object, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.Object, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.Object, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref object, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Object, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.Object, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.Object, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Object, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            // short aliases
            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref short1, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref short, out string)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(null, null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref short, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref short, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref short, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Int16, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Int16, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref short, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref short, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.Int16, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.Int16, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref short, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Int16, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.Int16, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.Int16, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Int16, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            // ushort aliases
            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref ushort1, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref ushort, out string)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(null, null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref ushort, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref ushort, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref ushort, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref UInt16, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref UInt16, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref ushort, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref ushort, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.UInt16, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.UInt16, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref ushort, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref UInt16, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.UInt16, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.UInt16, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref UInt16, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

        }

        [TestMethod]
        public void DelegateDeclarationServiceProvider_SignatureEqualityMatch_OK()
        {
            var flad = new CSharpFlad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = (DelegateDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] delegate void Del<T>(string str);").Members[0];
            var b = (DelegateDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] delegate void iDel<T>(string str);").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureEqualityMatch(a, (DelegateDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureEqualityMatch(null, (DelegateDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (DelegateDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] delegate void Del<T>(string str);").Members[0];
            b = (DelegateDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] delegate void Del<T>(string str);").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureEqualityMatch(a, (DelegateDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureEqualityMatch(null, (DelegateDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsTrue(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (DelegateDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] delegate void Del<T>(string str);").Members[0];
            b = (DelegateDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] delegate void Del<K>(string str);").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureEqualityMatch(a, (DelegateDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureEqualityMatch(null, (DelegateDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsTrue(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (DelegateDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] delegate void Del<T>(string str);").Members[0];
            b = (DelegateDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] delegate void Del<T, K>(string str);").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureEqualityMatch(a, (DelegateDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureEqualityMatch(null, (DelegateDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (DelegateDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] delegate void Del<T>(string str);").Members[0];
            b = (DelegateDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] delegate void Del<K, T>(string str);").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureEqualityMatch(a, (DelegateDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureEqualityMatch(null, (DelegateDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (DelegateDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] delegate void Del<T>(string1 str);").Members[0];
            b = (DelegateDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] delegate void Del<K>(string str);").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureEqualityMatch(a, (DelegateDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureEqualityMatch(null, (DelegateDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (DelegateDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] delegate void Del<T>(string str, int i);").Members[0];
            b = (DelegateDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] delegate void Del<K>(string str);").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureEqualityMatch(a, (DelegateDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureEqualityMatch(null, (DelegateDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (DelegateDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] delegate void Del<T>(string str, int i);").Members[0];
            b = (DelegateDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] delegate void Del<K>(string str, int t);").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureEqualityMatch(a, (DelegateDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureEqualityMatch(null, (DelegateDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsTrue(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (DelegateDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] delegate void Del(string str);").Members[0];
            b = (DelegateDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] delegate void iDel(string str);").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureEqualityMatch(a, (DelegateDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureEqualityMatch(null, (DelegateDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (DelegateDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] delegate void Del(string str);").Members[0];
            b = (DelegateDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] delegate void Del(string str);").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureEqualityMatch(a, (DelegateDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureEqualityMatch(null, (DelegateDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsTrue(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (DelegateDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] delegate void Del(string1 str);").Members[0];
            b = (DelegateDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] delegate void Del(string str);").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureEqualityMatch(a, (DelegateDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureEqualityMatch(null, (DelegateDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (DelegateDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] delegate void Del(string str, int i);").Members[0];
            b = (DelegateDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] delegate void Del(string str);").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureEqualityMatch(a, (DelegateDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureEqualityMatch(null, (DelegateDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (DelegateDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] delegate void Del(string str, int i);").Members[0];
            b = (DelegateDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] delegate void Del(string str, int t);").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureEqualityMatch(a, (DelegateDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureEqualityMatch(null, (DelegateDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsTrue(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));
        }

        [TestMethod]
        public void ClassDeclarationServiceProvider_SignatureEqualityMatch_OK()
        {
            var flad = new CSharpFlad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public class a<T> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            var b = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public class b<T> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.ClassDeclarationServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ClassDeclarationServiceProvider.SignatureEqualityMatch(a, (ClassDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ClassDeclarationServiceProvider.SignatureEqualityMatch(null, (ClassDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ClassDeclarationServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public class a<T> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            b = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public class a<T> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.ClassDeclarationServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ClassDeclarationServiceProvider.SignatureEqualityMatch(a, (ClassDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ClassDeclarationServiceProvider.SignatureEqualityMatch(null, (ClassDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsTrue(flad.LanguageServiceProvider.ClassDeclarationServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public class a<T> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            b = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public class a<G> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.ClassDeclarationServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ClassDeclarationServiceProvider.SignatureEqualityMatch(a, (ClassDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ClassDeclarationServiceProvider.SignatureEqualityMatch(null, (ClassDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsTrue(flad.LanguageServiceProvider.ClassDeclarationServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public class a<T> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            b = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public class a<T, F> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.ClassDeclarationServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ClassDeclarationServiceProvider.SignatureEqualityMatch(a, (ClassDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ClassDeclarationServiceProvider.SignatureEqualityMatch(null, (ClassDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ClassDeclarationServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public class a<T> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            b = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public class a<T> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.ClassDeclarationServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ClassDeclarationServiceProvider.SignatureEqualityMatch(a, (ClassDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ClassDeclarationServiceProvider.SignatureEqualityMatch(null, (ClassDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsTrue(flad.LanguageServiceProvider.ClassDeclarationServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public class a : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            b = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public class b : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.ClassDeclarationServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ClassDeclarationServiceProvider.SignatureEqualityMatch(a, (ClassDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ClassDeclarationServiceProvider.SignatureEqualityMatch(null, (ClassDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ClassDeclarationServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public class a : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            b = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public class a : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.ClassDeclarationServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ClassDeclarationServiceProvider.SignatureEqualityMatch(a, (ClassDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ClassDeclarationServiceProvider.SignatureEqualityMatch(null, (ClassDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsTrue(flad.LanguageServiceProvider.ClassDeclarationServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));
        }

        [TestMethod]
        public void StructDeclarationServiceProvider_SignatureEqualityMatch_OK()
        {
            var flad = new CSharpFlad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = (StructDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public struct a<T> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            var b = (StructDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public struct b<T> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.StructDeclarationServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.StructDeclarationServiceProvider.SignatureEqualityMatch(a, (StructDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.StructDeclarationServiceProvider.SignatureEqualityMatch(null, (StructDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.StructDeclarationServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (StructDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public struct a<T> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            b = (StructDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public struct a<T> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.StructDeclarationServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.StructDeclarationServiceProvider.SignatureEqualityMatch(a, (StructDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.StructDeclarationServiceProvider.SignatureEqualityMatch(null, (StructDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsTrue(flad.LanguageServiceProvider.StructDeclarationServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (StructDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public struct a<T> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            b = (StructDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public struct a<G> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.StructDeclarationServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.StructDeclarationServiceProvider.SignatureEqualityMatch(a, (StructDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.StructDeclarationServiceProvider.SignatureEqualityMatch(null, (StructDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsTrue(flad.LanguageServiceProvider.StructDeclarationServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (StructDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public struct a<T> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            b = (StructDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public struct a<T, F> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.StructDeclarationServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.StructDeclarationServiceProvider.SignatureEqualityMatch(a, (StructDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.StructDeclarationServiceProvider.SignatureEqualityMatch(null, (StructDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.StructDeclarationServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (StructDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public struct a<T> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            b = (StructDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public struct a<T> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.StructDeclarationServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.StructDeclarationServiceProvider.SignatureEqualityMatch(a, (StructDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.StructDeclarationServiceProvider.SignatureEqualityMatch(null, (StructDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsTrue(flad.LanguageServiceProvider.StructDeclarationServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (StructDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public struct a : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            b = (StructDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public struct b : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.StructDeclarationServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.StructDeclarationServiceProvider.SignatureEqualityMatch(a, (StructDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.StructDeclarationServiceProvider.SignatureEqualityMatch(null, (StructDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.StructDeclarationServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (StructDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public struct a : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            b = (StructDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public struct a : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.StructDeclarationServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.StructDeclarationServiceProvider.SignatureEqualityMatch(a, (StructDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.StructDeclarationServiceProvider.SignatureEqualityMatch(null, (StructDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsTrue(flad.LanguageServiceProvider.StructDeclarationServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));
        }

        [TestMethod]
        public void InterfaceDeclarationServiceProvider_SignatureEqualityMatch_OK()
        {
            var flad = new CSharpFlad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = (InterfaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public interface a<T> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            var b = (InterfaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public interface b<T> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.InterfaceDeclarationServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.InterfaceDeclarationServiceProvider.SignatureEqualityMatch(a, (InterfaceDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.InterfaceDeclarationServiceProvider.SignatureEqualityMatch(null, (InterfaceDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.InterfaceDeclarationServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (InterfaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public interface a<T> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            b = (InterfaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public interface a<T> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.InterfaceDeclarationServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.InterfaceDeclarationServiceProvider.SignatureEqualityMatch(a, (InterfaceDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.InterfaceDeclarationServiceProvider.SignatureEqualityMatch(null, (InterfaceDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsTrue(flad.LanguageServiceProvider.InterfaceDeclarationServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (InterfaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public interface a<T> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            b = (InterfaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public interface a<G> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.InterfaceDeclarationServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.InterfaceDeclarationServiceProvider.SignatureEqualityMatch(a, (InterfaceDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.InterfaceDeclarationServiceProvider.SignatureEqualityMatch(null, (InterfaceDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsTrue(flad.LanguageServiceProvider.InterfaceDeclarationServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (InterfaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public interface a<T> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            b = (InterfaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public interface a<T, F> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.InterfaceDeclarationServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.InterfaceDeclarationServiceProvider.SignatureEqualityMatch(a, (InterfaceDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.InterfaceDeclarationServiceProvider.SignatureEqualityMatch(null, (InterfaceDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.InterfaceDeclarationServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (InterfaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public interface a<T> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            b = (InterfaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public interface a<T> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.InterfaceDeclarationServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.InterfaceDeclarationServiceProvider.SignatureEqualityMatch(a, (InterfaceDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.InterfaceDeclarationServiceProvider.SignatureEqualityMatch(null, (InterfaceDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsTrue(flad.LanguageServiceProvider.InterfaceDeclarationServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (InterfaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public interface a : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            b = (InterfaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public interface b : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.InterfaceDeclarationServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.InterfaceDeclarationServiceProvider.SignatureEqualityMatch(a, (InterfaceDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.InterfaceDeclarationServiceProvider.SignatureEqualityMatch(null, (InterfaceDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.InterfaceDeclarationServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (InterfaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public interface a : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            b = (InterfaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public interface a : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.InterfaceDeclarationServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.InterfaceDeclarationServiceProvider.SignatureEqualityMatch(a, (InterfaceDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.InterfaceDeclarationServiceProvider.SignatureEqualityMatch(null, (InterfaceDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsTrue(flad.LanguageServiceProvider.InterfaceDeclarationServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));
        }

        [TestMethod]
        public void MethodDeclarationServiceProvider_SignatureEqualityMatch_OK()
        {
            var flad = new CSharpFlad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M<T>(int a, A b)where T: class { return 5; };").Members[0];
            var b = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M1<T>(int a, A b)where T: class { return 5; };").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureEqualityMatch(a, (MethodDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureEqualityMatch(null, (MethodDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C1.M<T>(int a, A b)where T: class { return 5; };").Members[0];
            b = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M<T>(int a, A b)where T: class { return 5; };").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureEqualityMatch(a, (MethodDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureEqualityMatch(null, (MethodDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M<T>(int a, A b)where T: class { return 5; };").Members[0];
            b = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M<T>(int a, A b)where T: class { return 5; };").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureEqualityMatch(a, (MethodDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureEqualityMatch(null, (MethodDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsTrue(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string M<T>(int a, A b)where T: class { return 5; };").Members[0];
            b = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string M1<T>(int a, A b)where T: class { return 5; };").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureEqualityMatch(a, (MethodDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureEqualityMatch(null, (MethodDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string M<T>(int a, A b)where T: class { return 5; };").Members[0];
            b = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string M<T, K>(int a, A b)where T: class { return 5; };").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureEqualityMatch(a, (MethodDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureEqualityMatch(null, (MethodDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string M<T>(int a, A b)where T: class { return 5; };").Members[0];
            b = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string M<T>(int a, A b)where T: class { return 5; };").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureEqualityMatch(a, (MethodDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureEqualityMatch(null, (MethodDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsTrue(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string M<T>(int a)where T: class { return 5; };").Members[0];
            b = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string M<T>(int a, A b)where T: class { return 5; };").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureEqualityMatch(a, (MethodDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureEqualityMatch(null, (MethodDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string M<T>(int a)where T: class { return 5; };").Members[0];
            b = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string M<T>(int b)where T: class { return 5; };").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureEqualityMatch(a, (MethodDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureEqualityMatch(null, (MethodDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsTrue(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string M<K>(int a)where T: class { return 5; };").Members[0];
            b = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string M<T>(int b)where T: class { return 5; };").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureEqualityMatch(a, (MethodDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureEqualityMatch(null, (MethodDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsTrue(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string M(int a) { return 5; };").Members[0];
            b = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string M(int b) { return 5; };").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureEqualityMatch(a, (MethodDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureEqualityMatch(null, (MethodDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsTrue(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string M() { return 5; };").Members[0];
            b = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string M() { return 5; };").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureEqualityMatch(a, (MethodDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureEqualityMatch(null, (MethodDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsTrue(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string1 M() { return 5; };").Members[0];
            b = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string M() { return 5; };").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureEqualityMatch(a, (MethodDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureEqualityMatch(null, (MethodDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsTrue(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));
        }

        [TestMethod]
        public void OperatorDeclarationServiceProvider_SignatureEqualityMatch_OK()
        {
            var flad = new CSharpFlad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string operator +(int a, A b) { return 5; };").Members[0];
            var b = (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string operator -(int a, A b) { return 5; };").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.OperatorDeclarationServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.OperatorDeclarationServiceProvider.SignatureEqualityMatch(a, (OperatorDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.OperatorDeclarationServiceProvider.SignatureEqualityMatch(null, (OperatorDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.OperatorDeclarationServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string operator +(int a, A b) { return 5; };").Members[0];
            b = (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string operator +(int a, A b) { return 5; };").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.OperatorDeclarationServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.OperatorDeclarationServiceProvider.SignatureEqualityMatch(a, (OperatorDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.OperatorDeclarationServiceProvider.SignatureEqualityMatch(null, (OperatorDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsTrue(flad.LanguageServiceProvider.OperatorDeclarationServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string operator +(int a, B b) { return 5; };").Members[0];
            b = (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string operator +(int a, A b) { return 5; };").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.OperatorDeclarationServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.OperatorDeclarationServiceProvider.SignatureEqualityMatch(a, (OperatorDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.OperatorDeclarationServiceProvider.SignatureEqualityMatch(null, (OperatorDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.OperatorDeclarationServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string operator +(int a, A b) { return 5; };").Members[0];
            b = (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string operator +(int a, A c) { return 5; };").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.OperatorDeclarationServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.OperatorDeclarationServiceProvider.SignatureEqualityMatch(a, (OperatorDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.OperatorDeclarationServiceProvider.SignatureEqualityMatch(null, (OperatorDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsTrue(flad.LanguageServiceProvider.OperatorDeclarationServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string operator +(int a) { return 5; };").Members[0];
            b = (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string operator +(int a, A b) { return 5; };").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.OperatorDeclarationServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.OperatorDeclarationServiceProvider.SignatureEqualityMatch(a, (OperatorDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.OperatorDeclarationServiceProvider.SignatureEqualityMatch(null, (OperatorDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.OperatorDeclarationServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string operator +(int a, A b) { return 5; };").Members[0];
            b = (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string1 operator +(int a, A b) { return 5; };").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.OperatorDeclarationServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.OperatorDeclarationServiceProvider.SignatureEqualityMatch(a, (OperatorDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.OperatorDeclarationServiceProvider.SignatureEqualityMatch(null, (OperatorDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsTrue(flad.LanguageServiceProvider.OperatorDeclarationServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));
        }

        [TestMethod]
        public void ConversionOperatorDeclarationServiceProvider_SignatureEqualityMatch_OK()
        {
            var flad = new CSharpFlad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = (ConversionOperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public operator A1(B b) { return 5; };").Members[0];
            var b = (ConversionOperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public operator A(B b) { return 5; };").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.ConversionOperatorDeclarationServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ConversionOperatorDeclarationServiceProvider.SignatureEqualityMatch(a, (ConversionOperatorDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ConversionOperatorDeclarationServiceProvider.SignatureEqualityMatch(null, (ConversionOperatorDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ConversionOperatorDeclarationServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (ConversionOperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public operator A(B b) { return 5; };").Members[0];
            b = (ConversionOperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public operator A(B1 b) { return 5; };").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.ConversionOperatorDeclarationServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ConversionOperatorDeclarationServiceProvider.SignatureEqualityMatch(a, (ConversionOperatorDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ConversionOperatorDeclarationServiceProvider.SignatureEqualityMatch(null, (ConversionOperatorDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ConversionOperatorDeclarationServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (ConversionOperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public operator A(B b) { return 5; };").Members[0];
            b = (ConversionOperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public operator A(B b) { return 5; };").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.ConversionOperatorDeclarationServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ConversionOperatorDeclarationServiceProvider.SignatureEqualityMatch(a, (ConversionOperatorDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ConversionOperatorDeclarationServiceProvider.SignatureEqualityMatch(null, (ConversionOperatorDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsTrue(flad.LanguageServiceProvider.ConversionOperatorDeclarationServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));
        }

        [TestMethod]
        public void ConstructorDeclarationServiceProvider_SignatureEqualityMatch_OK()
        {
            var flad = new CSharpFlad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = (ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation]public A(B b) : this(b) { }; }").Members[0]).Members[0];
            var b = (ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A1 { [Documentation]public A1(B b) : this(b) { }; }").Members[0]).Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.ConstructorDeclarationServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ConstructorDeclarationServiceProvider.SignatureEqualityMatch(a, (ConstructorDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ConstructorDeclarationServiceProvider.SignatureEqualityMatch(null, (ConstructorDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ConstructorDeclarationServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation]public A(B b) : this(b) { }; }").Members[0]).Members[0];
            b = (ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class C { [Documentation]public C(B b) : this(b) { }; }").Members[0]).Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.ConstructorDeclarationServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ConstructorDeclarationServiceProvider.SignatureEqualityMatch(a, (ConstructorDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ConstructorDeclarationServiceProvider.SignatureEqualityMatch(null, (ConstructorDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ConstructorDeclarationServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation]public A(B b) : this(b) { }; }").Members[0]).Members[0];
            b = (ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation]public A(B1 b) : this(b) { }; }").Members[0]).Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.ConstructorDeclarationServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ConstructorDeclarationServiceProvider.SignatureEqualityMatch(a, (ConstructorDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ConstructorDeclarationServiceProvider.SignatureEqualityMatch(null, (ConstructorDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ConstructorDeclarationServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation]public A(B b) : this(b) { }; }").Members[0]).Members[0];
            b = (ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation]public A(B b1) : this(b) { }; }").Members[0]).Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.ConstructorDeclarationServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ConstructorDeclarationServiceProvider.SignatureEqualityMatch(a, (ConstructorDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ConstructorDeclarationServiceProvider.SignatureEqualityMatch(null, (ConstructorDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsTrue(flad.LanguageServiceProvider.ConstructorDeclarationServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation]public A() : this() { }; }").Members[0]).Members[0];
            b = (ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation]public A(B b) : this(b) { }; }").Members[0]).Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.ConstructorDeclarationServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ConstructorDeclarationServiceProvider.SignatureEqualityMatch(a, (ConstructorDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ConstructorDeclarationServiceProvider.SignatureEqualityMatch(null, (ConstructorDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ConstructorDeclarationServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation]public A(B b) : this(b) { }; }").Members[0]).Members[0];
            b = (ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation]public A(B b) : this(b) { }; }").Members[0]).Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.ConstructorDeclarationServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ConstructorDeclarationServiceProvider.SignatureEqualityMatch(a, (ConstructorDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ConstructorDeclarationServiceProvider.SignatureEqualityMatch(null, (ConstructorDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsTrue(flad.LanguageServiceProvider.ConstructorDeclarationServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));
        }

        //[TestMethod]
        //public void PropertyDeclarationServiceProvider_SignatureEqualityMatch_OK()
        //{
        //    var flad = new CSharpFlad();
        //    var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
        //    MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

        //    var a = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M { get{return 5;} set{this.a = 7} };").Members[0];
        //    var b = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M1 { get{return 5;} set{this.a = 7} };").Members[0];
        //    Assert.IsFalse(flad.LanguageServiceProvider.PropertyDeclarationServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
        //    Assert.IsFalse(flad.LanguageServiceProvider.PropertyDeclarationServiceProvider.SignatureEqualityMatch(a, (PropertyDeclarationSyntax)null, matchingContext, out matchInfo));
        //    Assert.IsFalse(flad.LanguageServiceProvider.PropertyDeclarationServiceProvider.SignatureEqualityMatch(null, (PropertyDeclarationSyntax)null, matchingContext, out matchInfo));
        //    Assert.IsFalse(flad.LanguageServiceProvider.PropertyDeclarationServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

        //    a = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M { get{return 5;} set{this.a = 7} };").Members[0];
        //    b = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C1.M { get{return 5;} set{this.a = 7} };").Members[0];
        //    Assert.IsFalse(flad.LanguageServiceProvider.PropertyDeclarationServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
        //    Assert.IsFalse(flad.LanguageServiceProvider.PropertyDeclarationServiceProvider.SignatureEqualityMatch(a, (PropertyDeclarationSyntax)null, matchingContext, out matchInfo));
        //    Assert.IsFalse(flad.LanguageServiceProvider.PropertyDeclarationServiceProvider.SignatureEqualityMatch(null, (PropertyDeclarationSyntax)null, matchingContext, out matchInfo));
        //    Assert.IsFalse(flad.LanguageServiceProvider.PropertyDeclarationServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

        //    a = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M { get{return 5;} set{this.a = 7} };").Members[0];
        //    b = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M { get{return 5;} set{this.a = 7} };").Members[0];
        //    Assert.IsTrue(flad.LanguageServiceProvider.PropertyDeclarationServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

        //    a = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string M { get{return 5;} set{this.a = 7} };").Members[0];
        //    b = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string M1 { get{return 5;} set{this.a = 7} };").Members[0];
        //    Assert.IsFalse(flad.LanguageServiceProvider.PropertyDeclarationServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
        //    Assert.IsFalse(flad.LanguageServiceProvider.PropertyDeclarationServiceProvider.SignatureEqualityMatch(a, (PropertyDeclarationSyntax)null, matchingContext, out matchInfo));
        //    Assert.IsFalse(flad.LanguageServiceProvider.PropertyDeclarationServiceProvider.SignatureEqualityMatch(null, (PropertyDeclarationSyntax)null, matchingContext, out matchInfo));
        //    Assert.IsFalse(flad.LanguageServiceProvider.PropertyDeclarationServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

        //    a = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string M { get{return 5;} set{this.a = 7} };").Members[0];
        //    b = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string M { get{return 5;} set{this.a = 7} };").Members[0];
        //    Assert.IsTrue(flad.LanguageServiceProvider.PropertyDeclarationServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));
        //}

        [TestMethod]
        public void EventDeclarationServiceProvider_SignatureEqualityMatch_OK()
        {
            var flad = new CSharpFlad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = (EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A C.M { add{this.M += value;} remove{this.M -= value} }").Members[0];
            var b = (EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A C.M1 { add{this.M += value;} remove{this.M -= value} }").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.EventDeclarationServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.EventDeclarationServiceProvider.SignatureEqualityMatch(a, (EventDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.EventDeclarationServiceProvider.SignatureEqualityMatch(null, (EventDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.EventDeclarationServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A C.M { add{this.M += value;} remove{this.M -= value} }").Members[0];
            b = (EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A C1.M { add{this.M += value;} remove{this.M -= value} }").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.EventDeclarationServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.EventDeclarationServiceProvider.SignatureEqualityMatch(a, (EventDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.EventDeclarationServiceProvider.SignatureEqualityMatch(null, (EventDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.EventDeclarationServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A C.M { add{this.M += value;} remove{this.M -= value} }").Members[0];
            b = (EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A C.M { add{this.M += value;} remove{this.M -= value} }").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.EventDeclarationServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.EventDeclarationServiceProvider.SignatureEqualityMatch(a, (EventDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.EventDeclarationServiceProvider.SignatureEqualityMatch(null, (EventDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsTrue(flad.LanguageServiceProvider.EventDeclarationServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A M { add{this.M += value;} remove{this.M -= value} }").Members[0];
            b = (EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A M1 { add{this.M += value;} remove{this.M -= value} }").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.EventDeclarationServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.EventDeclarationServiceProvider.SignatureEqualityMatch(a, (EventDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.EventDeclarationServiceProvider.SignatureEqualityMatch(null, (EventDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.EventDeclarationServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A M { add{this.M += value;} remove{this.M -= value} }").Members[0];
            b = (EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A M { add{this.M += value;} remove{this.M -= value} }").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.EventDeclarationServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.EventDeclarationServiceProvider.SignatureEqualityMatch(a, (EventDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.EventDeclarationServiceProvider.SignatureEqualityMatch(null, (EventDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsTrue(flad.LanguageServiceProvider.EventDeclarationServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));
        }

        [TestMethod]
        public void IndexerDeclarationServiceProvider_SignatureEqualityMatch_OK()
        {
            var flad = new CSharpFlad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A C.this[string key] { get{return this.M[key];} set{this.M[key] = value;} } => 5;").Members[0];
            var b = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A C.this[string key] { get{return this.M[key];} set{this.M[key] = value;} } => 5;").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureEqualityMatch(a, (IndexerDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureEqualityMatch(null, (IndexerDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsTrue(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A C.this[string key] { get{return this.M[key];} set{this.M[key] = value;} } => 5;").Members[0];
            b = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A C1.this[string key] { get{return this.M[key];} set{this.M[key] = value;} } => 5;").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureEqualityMatch(a, (IndexerDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureEqualityMatch(null, (IndexerDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A C.this[string1 key] { get{return this.M[key];} set{this.M[key] = value;} } => 5;").Members[0];
            b = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A C.this[string key] { get{return this.M[key];} set{this.M[key] = value;} } => 5;").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureEqualityMatch(a, (IndexerDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureEqualityMatch(null, (IndexerDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A C.this[string key] { get{return this.M[key];} set{this.M[key] = value;} } => 5;").Members[0];
            b = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A C.this[string key, int t] { get{return this.M[key];} set{this.M[key] = value;} } => 5;").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureEqualityMatch(a, (IndexerDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureEqualityMatch(null, (IndexerDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A C.this[string key, int r] { get{return this.M[key];} set{this.M[key] = value;} } => 5;").Members[0];
            b = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A C.this[string key, int i] { get{return this.M[key];} set{this.M[key] = value;} } => 5;").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureEqualityMatch(a, (IndexerDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureEqualityMatch(null, (IndexerDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsTrue(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A this[string key] { get{return this.M[key];} set{this.M[key] = value;} } => 5;").Members[0];
            b = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A this[string key] { get{return this.M[key];} set{this.M[key] = value;} } => 5;").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureEqualityMatch(a, (IndexerDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureEqualityMatch(null, (IndexerDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsTrue(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A this[string key] { get{return this.M[key];} set{this.M[key] = value;} } => 5;").Members[0];
            b = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A this[string key] { get{return this.M[key];} set{this.M[key] = value;} } => 5;").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureEqualityMatch(a, (IndexerDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureEqualityMatch(null, (IndexerDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsTrue(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A this[string1 key] { get{return this.M[key];} set{this.M[key] = value;} } => 5;").Members[0];
            b = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A this[string key] { get{return this.M[key];} set{this.M[key] = value;} } => 5;").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureEqualityMatch(a, (IndexerDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureEqualityMatch(null, (IndexerDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A this[string key] { get{return this.M[key];} set{this.M[key] = value;} } => 5;").Members[0];
            b = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A this[string key, int t] { get{return this.M[key];} set{this.M[key] = value;} } => 5;").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureEqualityMatch(a, (IndexerDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureEqualityMatch(null, (IndexerDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A this[string key, int r] { get{return this.M[key];} set{this.M[key] = value;} } => 5;").Members[0];
            b = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A this[string key, int i] { get{return this.M[key];} set{this.M[key] = value;} } => 5;").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureEqualityMatch(a, (IndexerDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureEqualityMatch(null, (IndexerDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsTrue(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A this[string key] { get{return this.M[key];} set{this.M[key] = value;} } => 5;").Members[0];
            b = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A this[string key] { get{return this.M[key];} set{this.M[key] = value;} } => 5;").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureEqualityMatch(a, (IndexerDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureEqualityMatch(null, (IndexerDeclarationSyntax)null, matchingContext, out matchInfo));
            Assert.IsTrue(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));
        }

        [TestMethod]
        public void ParameterListSyntax_SignatureEqualityMatch_OK()
        {
            var flad = new CSharpFlad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = ((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int M([Serializable] ref int1 a = 0, A b){}").Members[0]).ParameterList;
            var b = ((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int M([Serializable] ref int a = 0, A b){}").Members[0]).ParameterList;
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterListServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterListServiceProvider.SignatureEqualityMatch(a, (ParameterListSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterListServiceProvider.SignatureEqualityMatch(null, (ParameterListSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = ((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int M([Serializable] ref int a = 0){}").Members[0]).ParameterList;
            b = ((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int M([Serializable] ref int a = 0, A b){}").Members[0]).ParameterList;
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterListServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterListServiceProvider.SignatureEqualityMatch(a, (ParameterListSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterListServiceProvider.SignatureEqualityMatch(null, (ParameterListSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = ((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int M([Serializable] ref int a = 0, A b){}").Members[0]).ParameterList;
            b = ((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int M(A b, [Serializable] ref int a = 0){}").Members[0]).ParameterList;
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterListServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterListServiceProvider.SignatureEqualityMatch(a, (ParameterListSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterListServiceProvider.SignatureEqualityMatch(null, (ParameterListSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));
        }

        [TestMethod]
        public void BracketedParameterListSyntax_SignatureEqualityMatch_OK()
        {
            var flad = new CSharpFlad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = ((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int this[[Serializable] ref int1 a = 0, A b]{get;set;}").Members[0]).ParameterList;
            var b = ((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int this[[Serializable] ref int a = 0, A b]{get;set;}").Members[0]).ParameterList;
            Assert.IsFalse(flad.LanguageServiceProvider.BracketedParameterListServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.BracketedParameterListServiceProvider.SignatureEqualityMatch(a, (BracketedParameterListSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.BracketedParameterListServiceProvider.SignatureEqualityMatch(null, (BracketedParameterListSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.BracketedParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = ((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int this[[Serializable] ref int a = 0]{get;set;}").Members[0]).ParameterList;
            b = ((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int this[[Serializable] ref int a = 0, A b]{get;set;}").Members[0]).ParameterList;
            Assert.IsFalse(flad.LanguageServiceProvider.BracketedParameterListServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.BracketedParameterListServiceProvider.SignatureEqualityMatch(a, (BracketedParameterListSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.BracketedParameterListServiceProvider.SignatureEqualityMatch(null, (BracketedParameterListSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.BracketedParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = ((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int this[[Serializable] ref int a = 0, A b]{get;set;}").Members[0]).ParameterList;
            b = ((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int this[[A b, Serializable] ref int a = 0]{get;set;}").Members[0]).ParameterList;
            Assert.IsFalse(flad.LanguageServiceProvider.BracketedParameterListServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.BracketedParameterListServiceProvider.SignatureEqualityMatch(a, (BracketedParameterListSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.BracketedParameterListServiceProvider.SignatureEqualityMatch(null, (BracketedParameterListSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.BracketedParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));
        }

        [TestMethod]
        public void NameMemberCrefServiceProvider_SignatureEqualityMatch_OK()
        {
            var flad = new CSharpFlad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"N(int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<NameMemberCrefSyntax>().Single();
            var b = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"N1(int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<NameMemberCrefSyntax>().Single();
            Assert.IsFalse(flad.LanguageServiceProvider.NameMemberCrefServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.NameMemberCrefServiceProvider.SignatureEqualityMatch(a, (NameMemberCrefSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.NameMemberCrefServiceProvider.SignatureEqualityMatch(null, (NameMemberCrefSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.NameMemberCrefServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"N(int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<NameMemberCrefSyntax>().Single();
            b = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"N(int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<NameMemberCrefSyntax>().Single();
            Assert.IsFalse(flad.LanguageServiceProvider.NameMemberCrefServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.NameMemberCrefServiceProvider.SignatureEqualityMatch(a, (NameMemberCrefSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.NameMemberCrefServiceProvider.SignatureEqualityMatch(null, (NameMemberCrefSyntax)null, matchingContext, out matchInfo));
            Assert.IsTrue(flad.LanguageServiceProvider.NameMemberCrefServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"N(int, string)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<NameMemberCrefSyntax>().Single();
            b = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"N(int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<NameMemberCrefSyntax>().Single();
            Assert.IsFalse(flad.LanguageServiceProvider.NameMemberCrefServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.NameMemberCrefServiceProvider.SignatureEqualityMatch(a, (NameMemberCrefSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.NameMemberCrefServiceProvider.SignatureEqualityMatch(null, (NameMemberCrefSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.NameMemberCrefServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"N(int, string)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<NameMemberCrefSyntax>().Single();
            b = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"N(string, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<NameMemberCrefSyntax>().Single();
            Assert.IsFalse(flad.LanguageServiceProvider.NameMemberCrefServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.NameMemberCrefServiceProvider.SignatureEqualityMatch(a, (NameMemberCrefSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.NameMemberCrefServiceProvider.SignatureEqualityMatch(null, (NameMemberCrefSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.NameMemberCrefServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));
        }

        [TestMethod]
        public void IndexerMemberCrefServiceProvider_SignatureEqualityMatch_OK()
        {
            var flad = new CSharpFlad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"this[int]\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<IndexerMemberCrefSyntax>().Single();
            var b = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"this[int]\"/> </summary>" + Environment.NewLine +
                       "    class A1 { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<IndexerMemberCrefSyntax>().Single();
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerMemberCrefServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerMemberCrefServiceProvider.SignatureEqualityMatch(a, (IndexerMemberCrefSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerMemberCrefServiceProvider.SignatureEqualityMatch(null, (IndexerMemberCrefSyntax)null, matchingContext, out matchInfo));
            Assert.IsTrue(flad.LanguageServiceProvider.IndexerMemberCrefServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"this[int1]\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<IndexerMemberCrefSyntax>().Single();
            b = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"this[int]\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<IndexerMemberCrefSyntax>().Single();
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerMemberCrefServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerMemberCrefServiceProvider.SignatureEqualityMatch(a, (IndexerMemberCrefSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerMemberCrefServiceProvider.SignatureEqualityMatch(null, (IndexerMemberCrefSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerMemberCrefServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"this[int]\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<IndexerMemberCrefSyntax>().Single();
            b = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"this[int]\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<IndexerMemberCrefSyntax>().Single();
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerMemberCrefServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerMemberCrefServiceProvider.SignatureEqualityMatch(a, (IndexerMemberCrefSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerMemberCrefServiceProvider.SignatureEqualityMatch(null, (IndexerMemberCrefSyntax)null, matchingContext, out matchInfo));
            Assert.IsTrue(flad.LanguageServiceProvider.IndexerMemberCrefServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"this[int, string]\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<IndexerMemberCrefSyntax>().Single();
            b = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"this[int]\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<IndexerMemberCrefSyntax>().Single();
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerMemberCrefServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerMemberCrefServiceProvider.SignatureEqualityMatch(a, (IndexerMemberCrefSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerMemberCrefServiceProvider.SignatureEqualityMatch(null, (IndexerMemberCrefSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerMemberCrefServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"this[int, string]\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<IndexerMemberCrefSyntax>().Single();
            b = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"this[string, int]\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<IndexerMemberCrefSyntax>().Single();
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerMemberCrefServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerMemberCrefServiceProvider.SignatureEqualityMatch(a, (IndexerMemberCrefSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerMemberCrefServiceProvider.SignatureEqualityMatch(null, (IndexerMemberCrefSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerMemberCrefServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));
        }

        [TestMethod]
        public void OperatorMemberCrefServiceProvider_SignatureEqualityMatch_OK()
        {
            var flad = new CSharpFlad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single();
            var b = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator -(int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single();
            Assert.IsFalse(flad.LanguageServiceProvider.OperatorMemberCrefServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.OperatorMemberCrefServiceProvider.SignatureEqualityMatch(a, (OperatorMemberCrefSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.OperatorMemberCrefServiceProvider.SignatureEqualityMatch(null, (OperatorMemberCrefSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.OperatorMemberCrefServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single();
            b = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(int, string)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single();
            Assert.IsFalse(flad.LanguageServiceProvider.OperatorMemberCrefServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.OperatorMemberCrefServiceProvider.SignatureEqualityMatch(a, (OperatorMemberCrefSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.OperatorMemberCrefServiceProvider.SignatureEqualityMatch(null, (OperatorMemberCrefSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.OperatorMemberCrefServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(string, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single();
            b = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(int, string)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single();
            Assert.IsFalse(flad.LanguageServiceProvider.OperatorMemberCrefServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.OperatorMemberCrefServiceProvider.SignatureEqualityMatch(a, (OperatorMemberCrefSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.OperatorMemberCrefServiceProvider.SignatureEqualityMatch(null, (OperatorMemberCrefSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.OperatorMemberCrefServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single();
            b = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single();
            Assert.IsFalse(flad.LanguageServiceProvider.OperatorMemberCrefServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.OperatorMemberCrefServiceProvider.SignatureEqualityMatch(a, (OperatorMemberCrefSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.OperatorMemberCrefServiceProvider.SignatureEqualityMatch(null, (OperatorMemberCrefSyntax)null, matchingContext, out matchInfo));
            Assert.IsTrue(flad.LanguageServiceProvider.OperatorMemberCrefServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));
        }

        [TestMethod]
        public void ConversionOperatorMemberCrefServiceProvider_SignatureEqualityMatch_OK()
        {
            var flad = new CSharpFlad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"implicit operator N(int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<ConversionOperatorMemberCrefSyntax>().Single();
            var b = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"implicit operator N(int1)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<ConversionOperatorMemberCrefSyntax>().Single();
            Assert.IsFalse(flad.LanguageServiceProvider.ConversionOperatorMemberCrefServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ConversionOperatorMemberCrefServiceProvider.SignatureEqualityMatch(a, (ConversionOperatorMemberCrefSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ConversionOperatorMemberCrefServiceProvider.SignatureEqualityMatch(null, (ConversionOperatorMemberCrefSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ConversionOperatorMemberCrefServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"implicit operator N(int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<ConversionOperatorMemberCrefSyntax>().Single();
            b = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"implicit operator N1(int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<ConversionOperatorMemberCrefSyntax>().Single();
            Assert.IsFalse(flad.LanguageServiceProvider.ConversionOperatorMemberCrefServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ConversionOperatorMemberCrefServiceProvider.SignatureEqualityMatch(a, (ConversionOperatorMemberCrefSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ConversionOperatorMemberCrefServiceProvider.SignatureEqualityMatch(null, (ConversionOperatorMemberCrefSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ConversionOperatorMemberCrefServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"implicit operator N(int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<ConversionOperatorMemberCrefSyntax>().Single();
            b = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"implicit operator N(int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<ConversionOperatorMemberCrefSyntax>().Single();
            Assert.IsFalse(flad.LanguageServiceProvider.ConversionOperatorMemberCrefServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ConversionOperatorMemberCrefServiceProvider.SignatureEqualityMatch(a, (ConversionOperatorMemberCrefSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ConversionOperatorMemberCrefServiceProvider.SignatureEqualityMatch(null, (ConversionOperatorMemberCrefSyntax)null, matchingContext, out matchInfo));
            Assert.IsTrue(flad.LanguageServiceProvider.ConversionOperatorMemberCrefServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));
        }

        [TestMethod]
        public void CrefParameterListListServiceProvider_SignatureEqualityMatch_OK()
        {
            var flad = new CSharpFlad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            // string aliases
            var a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref string1, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            var b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref string, out string)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(null, null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref string, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref string, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref string, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref String, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref String, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref string, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref string, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.String, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.String, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref string, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref String, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.String, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            // bool aliases
            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref bool1, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref bool, out string)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(null, null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref bool, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref bool, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref bool, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Boolean, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Boolean, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref bool, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref bool, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.Boolean, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.Boolean, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref bool, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Boolean, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.Boolean, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.Boolean, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Boolean, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            // byte aliases
            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref byte1, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref byte, out string)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(null, null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref byte, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref byte, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref byte, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Byte, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Byte, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref byte, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref byte, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.Byte, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.Byte, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref byte, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Byte, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.Byte, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.Byte, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Byte, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            // sbyte aliases
            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref sbyte1, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref sbyte, out string)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(null, null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref sbyte, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref sbyte, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref sbyte, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref SByte, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref SByte, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref sbyte, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref sbyte, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.SByte, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.SByte, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref sbyte, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref SByte, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.SByte, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.SByte, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref SByte, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            // bool aliases
            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref bool1, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref bool, out string)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(null, null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref bool, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref bool, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref bool, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Boolean, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Boolean, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref bool, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref bool, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.Boolean, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.Boolean, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref bool, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Boolean, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.Boolean, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.Boolean, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Boolean, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            // decimal aliases
            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref decimal1, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref decimal, out string)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(null, null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref decimal, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref decimal, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref decimal, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Decimal, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Decimal, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref decimal, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref decimal, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.Decimal, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.Decimal, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref decimal, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Decimal, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.Decimal, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.Decimal, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Decimal, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            // double aliases
            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref double1, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref double, out string)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(null, null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref double, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref double, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref double, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Double, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Double, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref double, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref double, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.Double, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.Double, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref double, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Double, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.Double, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.Double, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Double, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            // float aliases
            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref float1, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref float, out string)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(null, null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref float, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref float, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref float, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Single, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Single, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref float, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref float, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.Single, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.Single, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref float, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Single, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.Single, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.Single, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Single, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            // int aliases
            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref int1, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref int, out string)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(null, null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref int, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref int, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref int, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Int32, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Int32, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref int, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref int, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.Int32, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.Int32, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref int, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Int32, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.Int32, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.Int32, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Int32, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            // uint aliases
            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref uint1, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref uint, out string)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(null, null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref uint, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref uint, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref uint, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref UInt32, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref UInt32, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref uint, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref uint, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.UInt32, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.UInt32, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref uint, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref UInt32, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.UInt32, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.UInt32, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref UInt32, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            // long aliases
            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref long1, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref long, out string)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(null, null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref long, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref long, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref long, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Int64, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Int64, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref long, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref long, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.Int64, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.Int64, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref long, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Int64, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.Int64, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.Int64, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Int64, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            // ulong aliases
            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref ulong1, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref ulong, out string)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(null, null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref ulong, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref ulong, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref ulong, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref UInt64, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref UInt64, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref ulong, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref ulong, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.UInt64, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.UInt64, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref ulong, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref UInt64, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.UInt64, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.UInt64, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref UInt64, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            // object aliases
            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref object1, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref object, out string)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(null, null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref object, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref object, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref object, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Object, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Object, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref object, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref object, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.Object, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.Object, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref object, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Object, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.Object, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.Object, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Object, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            // short aliases
            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref short1, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref short, out string)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(null, null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref short, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref short, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref short, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Int16, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Int16, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref short, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref short, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.Int16, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.Int16, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref short, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Int16, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.Int16, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.Int16, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Int16, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            // ushort aliases
            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref ushort1, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref ushort, out string)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(null, null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref ushort, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref ushort, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref ushort, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref UInt16, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref UInt16, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref ushort, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref ushort, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.UInt16, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.UInt16, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref ushort, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref UInt16, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.UInt16, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.UInt16, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref UInt16, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));


            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.UInt16)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref UInt16, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));
        }

        [TestMethod]
        public void CrefBracketedParameterListSyntax_SignatureEqualityMatch_OK()
        {
            var flad = new CSharpFlad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"this[int1, string]\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<IndexerMemberCrefSyntax>().Single().Parameters;
            var b = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"this[int, string]\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<IndexerMemberCrefSyntax>().Single().Parameters;
            Assert.IsFalse(flad.LanguageServiceProvider.CrefBracketedParameterListServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefBracketedParameterListServiceProvider.SignatureEqualityMatch(a, (CrefBracketedParameterListSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefBracketedParameterListServiceProvider.SignatureEqualityMatch(null, (CrefBracketedParameterListSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefBracketedParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"this[int]\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<IndexerMemberCrefSyntax>().Single().Parameters;
            b = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"this[int, string]\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<IndexerMemberCrefSyntax>().Single().Parameters;
            Assert.IsFalse(flad.LanguageServiceProvider.CrefBracketedParameterListServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefBracketedParameterListServiceProvider.SignatureEqualityMatch(a, (CrefBracketedParameterListSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefBracketedParameterListServiceProvider.SignatureEqualityMatch(null, (CrefBracketedParameterListSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefBracketedParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"this[int, string]\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<IndexerMemberCrefSyntax>().Single().Parameters;
            b = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"this[string, int]\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<IndexerMemberCrefSyntax>().Single().Parameters;
            Assert.IsFalse(flad.LanguageServiceProvider.CrefBracketedParameterListServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefBracketedParameterListServiceProvider.SignatureEqualityMatch(a, (CrefBracketedParameterListSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefBracketedParameterListServiceProvider.SignatureEqualityMatch(null, (CrefBracketedParameterListSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefBracketedParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                        "    /// <summary> <see cref=\"this[int, string]\"/> </summary>" + Environment.NewLine +
                        "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<IndexerMemberCrefSyntax>().Single().Parameters;
            b = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"this[int, string]\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<IndexerMemberCrefSyntax>().Single().Parameters;
            Assert.IsFalse(flad.LanguageServiceProvider.CrefBracketedParameterListServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefBracketedParameterListServiceProvider.SignatureEqualityMatch(a, (CrefBracketedParameterListSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefBracketedParameterListServiceProvider.SignatureEqualityMatch(null, (CrefBracketedParameterListSyntax)null, matchingContext, out matchInfo));
            Assert.IsTrue(flad.LanguageServiceProvider.CrefBracketedParameterListServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));
        }

        [TestMethod]
        public void AnonymousMethodExpressionSyntax_SignatureEqualityMatch_OK()
        {
            var flad = new CSharpFlad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = (AnonymousMethodExpressionSyntax)SyntaxFactory.ParseExpression("async delegate { return 4; }");
            var b = (AnonymousMethodExpressionSyntax)SyntaxFactory.ParseExpression("async delegate { return 4; }");
            Assert.IsFalse(flad.LanguageServiceProvider.AnonymousMethodExpressionServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.AnonymousMethodExpressionServiceProvider.SignatureEqualityMatch(a, (AnonymousMethodExpressionSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.AnonymousMethodExpressionServiceProvider.SignatureEqualityMatch(null, (AnonymousMethodExpressionSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.AnonymousMethodExpressionServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (AnonymousMethodExpressionSyntax)SyntaxFactory.ParseExpression("async delegate(T x) { return 4; }");
            b = (AnonymousMethodExpressionSyntax)SyntaxFactory.ParseExpression("async delegate(T x1) { return 4; }");
            Assert.IsFalse(flad.LanguageServiceProvider.AnonymousMethodExpressionServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.AnonymousMethodExpressionServiceProvider.SignatureEqualityMatch(a, (AnonymousMethodExpressionSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.AnonymousMethodExpressionServiceProvider.SignatureEqualityMatch(null, (AnonymousMethodExpressionSyntax)null, matchingContext, out matchInfo));
            Assert.IsTrue(flad.LanguageServiceProvider.AnonymousMethodExpressionServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (AnonymousMethodExpressionSyntax)SyntaxFactory.ParseExpression("async delegate(T x) { return 4; }");
            b = (AnonymousMethodExpressionSyntax)SyntaxFactory.ParseExpression("async delegate(T1 x) { return 4; }");
            Assert.IsFalse(flad.LanguageServiceProvider.AnonymousMethodExpressionServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.AnonymousMethodExpressionServiceProvider.SignatureEqualityMatch(a, (AnonymousMethodExpressionSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.AnonymousMethodExpressionServiceProvider.SignatureEqualityMatch(null, (AnonymousMethodExpressionSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.AnonymousMethodExpressionServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (AnonymousMethodExpressionSyntax)SyntaxFactory.ParseExpression("async delegate(T x) { return 4; }");
            b = (AnonymousMethodExpressionSyntax)SyntaxFactory.ParseExpression("async delegate(T x, K y) { return 4; }");
            Assert.IsFalse(flad.LanguageServiceProvider.AnonymousMethodExpressionServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.AnonymousMethodExpressionServiceProvider.SignatureEqualityMatch(a, (AnonymousMethodExpressionSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.AnonymousMethodExpressionServiceProvider.SignatureEqualityMatch(null, (AnonymousMethodExpressionSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.AnonymousMethodExpressionServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (AnonymousMethodExpressionSyntax)SyntaxFactory.ParseExpression("async delegate(T x, K y) { return 4; }");
            b = (AnonymousMethodExpressionSyntax)SyntaxFactory.ParseExpression("async delegate(T x, K y) { return 4; }");
            Assert.IsFalse(flad.LanguageServiceProvider.AnonymousMethodExpressionServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.AnonymousMethodExpressionServiceProvider.SignatureEqualityMatch(a, (AnonymousMethodExpressionSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.AnonymousMethodExpressionServiceProvider.SignatureEqualityMatch(null, (AnonymousMethodExpressionSyntax)null, matchingContext, out matchInfo));
            Assert.IsTrue(flad.LanguageServiceProvider.AnonymousMethodExpressionServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (AnonymousMethodExpressionSyntax)SyntaxFactory.ParseExpression("async delegate(T x, K y) { return 4; }");
            b = (AnonymousMethodExpressionSyntax)SyntaxFactory.ParseExpression("async delegate(K y, T x) { return 4; }");
            Assert.IsFalse(flad.LanguageServiceProvider.AnonymousMethodExpressionServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.AnonymousMethodExpressionServiceProvider.SignatureEqualityMatch(a, (AnonymousMethodExpressionSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.AnonymousMethodExpressionServiceProvider.SignatureEqualityMatch(null, (AnonymousMethodExpressionSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.AnonymousMethodExpressionServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));
        }

        [TestMethod]
        public void SimpleLambdaExpressionServiceProvider_SignatureEqualityMatch_OK()
        {
            var flad = new CSharpFlad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = (SimpleLambdaExpressionSyntax)SyntaxFactory.ParseExpression("e => 4 }");
            var b = (SimpleLambdaExpressionSyntax)SyntaxFactory.ParseExpression("E => 4 }");
            Assert.IsFalse(flad.LanguageServiceProvider.SimpleLambdaExpressionServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.SimpleLambdaExpressionServiceProvider.SignatureEqualityMatch(a, (SimpleLambdaExpressionSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.SimpleLambdaExpressionServiceProvider.SignatureEqualityMatch(null, (SimpleLambdaExpressionSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.SimpleLambdaExpressionServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (SimpleLambdaExpressionSyntax)SyntaxFactory.ParseExpression("e => 4 }");
            b = (SimpleLambdaExpressionSyntax)SyntaxFactory.ParseExpression("e => 4 }");
            Assert.IsFalse(flad.LanguageServiceProvider.SimpleLambdaExpressionServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.SimpleLambdaExpressionServiceProvider.SignatureEqualityMatch(a, (SimpleLambdaExpressionSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.SimpleLambdaExpressionServiceProvider.SignatureEqualityMatch(null, (SimpleLambdaExpressionSyntax)null, matchingContext, out matchInfo));
            Assert.IsTrue(flad.LanguageServiceProvider.SimpleLambdaExpressionServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));
        }

        [TestMethod]
        public void ParenthesizedLambdaExpressionServiceProvider_SignatureEqualityMatch_OK()
        {
            var flad = new CSharpFlad();
            var matchingContext = new MatchingContext<SyntaxNodeOrToken?>(flad);
            MatchInfo<SyntaxNodeOrToken?> matchInfo = null;

            var a = (ParenthesizedLambdaExpressionSyntax)SyntaxFactory.ParseExpression("(E e) => 4 }");
            var b = (ParenthesizedLambdaExpressionSyntax)SyntaxFactory.ParseExpression("(E e1) => 4 }");
            Assert.IsFalse(flad.LanguageServiceProvider.ParenthesizedLambdaExpressionServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ParenthesizedLambdaExpressionServiceProvider.SignatureEqualityMatch(a, (ParenthesizedLambdaExpressionSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ParenthesizedLambdaExpressionServiceProvider.SignatureEqualityMatch(null, (ParenthesizedLambdaExpressionSyntax)null, matchingContext, out matchInfo));
            Assert.IsTrue(flad.LanguageServiceProvider.ParenthesizedLambdaExpressionServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (ParenthesizedLambdaExpressionSyntax)SyntaxFactory.ParseExpression("(E e) => 4 }");
            b = (ParenthesizedLambdaExpressionSyntax)SyntaxFactory.ParseExpression("(E1 e) => 4 }");
            Assert.IsFalse(flad.LanguageServiceProvider.ParenthesizedLambdaExpressionServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ParenthesizedLambdaExpressionServiceProvider.SignatureEqualityMatch(a, (ParenthesizedLambdaExpressionSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ParenthesizedLambdaExpressionServiceProvider.SignatureEqualityMatch(null, (ParenthesizedLambdaExpressionSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ParenthesizedLambdaExpressionServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (ParenthesizedLambdaExpressionSyntax)SyntaxFactory.ParseExpression("(E e) => 4 }");
            b = (ParenthesizedLambdaExpressionSyntax)SyntaxFactory.ParseExpression("(E e) => 4 }");
            Assert.IsFalse(flad.LanguageServiceProvider.ParenthesizedLambdaExpressionServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ParenthesizedLambdaExpressionServiceProvider.SignatureEqualityMatch(a, (ParenthesizedLambdaExpressionSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ParenthesizedLambdaExpressionServiceProvider.SignatureEqualityMatch(null, (ParenthesizedLambdaExpressionSyntax)null, matchingContext, out matchInfo));
            Assert.IsTrue(flad.LanguageServiceProvider.ParenthesizedLambdaExpressionServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (ParenthesizedLambdaExpressionSyntax)SyntaxFactory.ParseExpression("(E e, G g) => 4 }");
            b = (ParenthesizedLambdaExpressionSyntax)SyntaxFactory.ParseExpression("(E e) => 4 }");
            Assert.IsFalse(flad.LanguageServiceProvider.ParenthesizedLambdaExpressionServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ParenthesizedLambdaExpressionServiceProvider.SignatureEqualityMatch(a, (ParenthesizedLambdaExpressionSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ParenthesizedLambdaExpressionServiceProvider.SignatureEqualityMatch(null, (ParenthesizedLambdaExpressionSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ParenthesizedLambdaExpressionServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (ParenthesizedLambdaExpressionSyntax)SyntaxFactory.ParseExpression("(E e, G g) => 4 }");
            b = (ParenthesizedLambdaExpressionSyntax)SyntaxFactory.ParseExpression("(E e, G g) => 4 }");
            Assert.IsFalse(flad.LanguageServiceProvider.ParenthesizedLambdaExpressionServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ParenthesizedLambdaExpressionServiceProvider.SignatureEqualityMatch(a, (ParenthesizedLambdaExpressionSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ParenthesizedLambdaExpressionServiceProvider.SignatureEqualityMatch(null, (ParenthesizedLambdaExpressionSyntax)null, matchingContext, out matchInfo));
            Assert.IsTrue(flad.LanguageServiceProvider.ParenthesizedLambdaExpressionServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (ParenthesizedLambdaExpressionSyntax)SyntaxFactory.ParseExpression("(E e, G g) => 4 }");
            b = (ParenthesizedLambdaExpressionSyntax)SyntaxFactory.ParseExpression("(G g, E e) => 4 }");
            Assert.IsFalse(flad.LanguageServiceProvider.ParenthesizedLambdaExpressionServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ParenthesizedLambdaExpressionServiceProvider.SignatureEqualityMatch(a, (ParenthesizedLambdaExpressionSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ParenthesizedLambdaExpressionServiceProvider.SignatureEqualityMatch(null, (ParenthesizedLambdaExpressionSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.ParenthesizedLambdaExpressionServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));
        }

        [TestMethod]
        public void LocalFunctionStatementServiceProvider_SignatureEqualityMatch_OK()
        {
            var flad = new CSharpFlad();
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
            Assert.IsFalse(flad.LanguageServiceProvider.LocalFunctionStatementServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.LocalFunctionStatementServiceProvider.SignatureEqualityMatch(a, (LocalFunctionStatementSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.LocalFunctionStatementServiceProvider.SignatureEqualityMatch(null, (LocalFunctionStatementSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.LocalFunctionStatementServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

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
            Assert.IsFalse(flad.LanguageServiceProvider.LocalFunctionStatementServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.LocalFunctionStatementServiceProvider.SignatureEqualityMatch(a, (LocalFunctionStatementSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.LocalFunctionStatementServiceProvider.SignatureEqualityMatch(null, (LocalFunctionStatementSyntax)null, matchingContext, out matchInfo));
            Assert.IsTrue(flad.LanguageServiceProvider.LocalFunctionStatementServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (LocalFunctionStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit(@"
                    void m()
                    {
                        int local() => 0;
                    }").Members[0]).Body.Statements[0];
            b = (LocalFunctionStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit(@"
                    void m()
                    {
                        int local(int i) => 0;
                    }").Members[0]).Body.Statements[0];
            Assert.IsFalse(flad.LanguageServiceProvider.LocalFunctionStatementServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.LocalFunctionStatementServiceProvider.SignatureEqualityMatch(a, (LocalFunctionStatementSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.LocalFunctionStatementServiceProvider.SignatureEqualityMatch(null, (LocalFunctionStatementSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.LocalFunctionStatementServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (LocalFunctionStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit(@"
                    void m()
                    {
                        int local(double l) => 0;
                    }").Members[0]).Body.Statements[0];
            b = (LocalFunctionStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit(@"
                    void m()
                    {
                        int local(double l) => 0;
                    }").Members[0]).Body.Statements[0];
            Assert.IsFalse(flad.LanguageServiceProvider.LocalFunctionStatementServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.LocalFunctionStatementServiceProvider.SignatureEqualityMatch(a, (LocalFunctionStatementSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.LocalFunctionStatementServiceProvider.SignatureEqualityMatch(null, (LocalFunctionStatementSyntax)null, matchingContext, out matchInfo));
            Assert.IsTrue(flad.LanguageServiceProvider.LocalFunctionStatementServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));

            a = (LocalFunctionStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit(@"
                    void m()
                    {
                        int local(double l) => 0;
                    }").Members[0]).Body.Statements[0];
            b = (LocalFunctionStatementSyntax)((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit(@"
                    void m()
                    {
                        int local(double w) => 0;
                    }").Members[0]).Body.Statements[0];
            Assert.IsFalse(flad.LanguageServiceProvider.LocalFunctionStatementServiceProvider.SignatureEqualityMatch(null, b, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.LocalFunctionStatementServiceProvider.SignatureEqualityMatch(a, (LocalFunctionStatementSyntax)null, matchingContext, out matchInfo));
            Assert.IsFalse(flad.LanguageServiceProvider.LocalFunctionStatementServiceProvider.SignatureEqualityMatch(null, (LocalFunctionStatementSyntax)null, matchingContext, out matchInfo));
            Assert.IsTrue(flad.LanguageServiceProvider.LocalFunctionStatementServiceProvider.SignatureEqualityMatch(a, b, matchingContext, out matchInfo));
        }

        [TestMethod]
        public void AllElementTypeSuitableFor_SignatureEqualityMatch_IsTested()
        {
            var rdsl = CDF.XObjects.RDSL.Syntax.Load(@"..\..\..\Jawilliam.CDF.CSharp\RDSL.xml");
            var concreteTypes = rdsl.Nodes.Type.Where(n => !n.@abstract).ToArray();

            var cases = (from t in concreteTypes
                         where t.Properties?.Property.Any(p => p.Rules?.Signature?.Any(n => n.equality && n.absolute) ?? false) ?? false
                         select t.name).ToList();

            var testedCases = (from m in this.GetType().GetMethods()
                               let nameParts = m.Name.Split(new[] { '_' }, StringSplitOptions.RemoveEmptyEntries)
                               where nameParts.Length == 3 && nameParts[1] == "SignatureEqualityMatch" && nameParts[2] == "OK"
                               select nameParts[0].Replace("ServiceProvider", "Syntax")).ToList();

            var a = cases.Except(testedCases).ToArray();
            var b = testedCases.Except(cases).ToArray();

            Assert.AreEqual(a.Count(), 0);
            Assert.AreEqual(b.Count(), 0);
        }
    }
}
