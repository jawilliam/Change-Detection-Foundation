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
    public class SignatureEqualityServicesTests
    {
        [TestMethod]
        public void TypeParameterListServiceProvider_SignatureExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<B, in C1, out D, [Serializable]E, [Serializable] in F> {B a1; internal static A b2 = 3; [Serializable]A c3 = 3; [Serializable]public int df = 34;}").Members[0]).TypeParameterList;
            var b = ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<B, in C, out D, [Serializable]E, [Serializable] in F> {B a1; internal static A b2 = 3; [Serializable]A c3 = 3; [Serializable]public int df = 34;}").Members[0]).TypeParameterList;
            Assert.IsFalse(flad.LanguageServiceProvider.TypeParameterListServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.TypeParameterListServiceProvider.SignatureExactlyEqual(a, (TypeParameterListSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.TypeParameterListServiceProvider.SignatureExactlyEqual(null, (TypeParameterListSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.TypeParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<B, out D, [Serializable]E, [Serializable] in F> {B a1; internal static A b2 = 3; [Serializable]A c3 = 3; [Serializable]public int df = 34;}").Members[0]).TypeParameterList;
            b = ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<B, in C, out D, [Serializable]E, [Serializable] in F> {B a1; internal static A b2 = 3; [Serializable]A c3 = 3; [Serializable]public int df = 34;}").Members[0]).TypeParameterList;
            Assert.IsFalse(flad.LanguageServiceProvider.TypeParameterListServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.TypeParameterListServiceProvider.SignatureExactlyEqual(a, (TypeParameterListSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.TypeParameterListServiceProvider.SignatureExactlyEqual(null, (TypeParameterListSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.TypeParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<B, in C, out D, [Serializable]E, [Serializable] in F> {B a1; internal static A b2 = 3; [Serializable]A c3 = 3; [Serializable]public int df = 34;}").Members[0]).TypeParameterList;
            b = ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class b<B, in C, out D, [Serializable]E, [Serializable] in F> {B a1; internal static A b2 = 3; [Serializable]A c3 = 3; [Serializable]public int df = 34;}").Members[0]).TypeParameterList;
            Assert.IsTrue(flad.LanguageServiceProvider.TypeParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<B, in C, out D, [Serializable]E, [Serializable] in F> {B a1; internal static A b2 = 3; [Serializable]A c3 = 3; [Serializable]public int df = 34;}").Members[0]).TypeParameterList;
            b = ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<B, in C, out D, [Serializable]E, [Serializable] in F> {B a1; internal static A b2 = 3; [Serializable]A c3 = 3; [Serializable]public int df = 34;}").Members[0]).TypeParameterList;
            Assert.IsTrue(flad.LanguageServiceProvider.TypeParameterListServiceProvider.SignatureExactlyEqual(a, b));
        }

        [TestMethod]
        public void TypeParameterServiceProvider_SignatureExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<B, in C1, out D, [Serializable]E, [Serializable] in F> {B a1; internal static A b2 = 3; [Serializable]A c3 = 3; [Serializable]public int df = 34;}").Members[0]).TypeParameterList.Parameters[1];
            var b = ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<B, in C, out D, [Serializable]E, [Serializable] in F> {B a1; internal static A b2 = 3; [Serializable]A c3 = 3; [Serializable]public int df = 34;}").Members[0]).TypeParameterList.Parameters[1];
            Assert.IsFalse(flad.LanguageServiceProvider.TypeParameterServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.TypeParameterServiceProvider.SignatureExactlyEqual(a, (TypeParameterSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.TypeParameterServiceProvider.SignatureExactlyEqual(null, (TypeParameterSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.TypeParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<B, in C1, out D, [Serializable]E, [Serializable] in F> {B a1; internal static A b2 = 3; [Serializable]A c3 = 3; [Serializable]public int df = 34;}").Members[0]).TypeParameterList.Parameters[1];
            b = ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<B, in C, out D, [Serializable]E, [Serializable] in F> {B a1; internal static A b2 = 3; [Serializable]A c3 = 3; [Serializable]public int df = 34;}").Members[0]).TypeParameterList.Parameters[1];
            Assert.IsFalse(flad.LanguageServiceProvider.TypeParameterServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.TypeParameterServiceProvider.SignatureExactlyEqual(a, (TypeParameterSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.TypeParameterServiceProvider.SignatureExactlyEqual(null, (TypeParameterSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.TypeParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<B, in C, out D, [Serializable]E, [Serializable] in F> {B a1; internal static A b2 = 3; [Serializable]A c3 = 3; [Serializable]public int df = 34;}").Members[0]).TypeParameterList.Parameters[1];
            b = ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class b<B, in C, out D, [Serializable]E, [Serializable] in F> {B a1; internal static A b2 = 3; [Serializable]A c3 = 3; [Serializable]public int df = 34;}").Members[0]).TypeParameterList.Parameters[1];
            Assert.IsTrue(flad.LanguageServiceProvider.TypeParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<B, in C, out D, [Serializable]E, [Serializable] in F> {B a1; internal static A b2 = 3; [Serializable]A c3 = 3; [Serializable]public int df = 34;}").Members[0]).TypeParameterList.Parameters[1];
            b = ((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<B, in C, out D, [Serializable]E, [Serializable] in F> {B a1; internal static A b2 = 3; [Serializable]A c3 = 3; [Serializable]public int df = 34;}").Members[0]).TypeParameterList.Parameters[1];
            Assert.IsTrue(flad.LanguageServiceProvider.TypeParameterServiceProvider.SignatureExactlyEqual(a, b));
        }

        [TestMethod]
        public void ParameterServiceProvider_SignatureExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = ((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int M([Serializable] ref int1 a = 0, A b){}").Members[0]).ParameterList.Parameters[0];
            var b = ((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int M([Serializable] ref int b = 0, A b){}").Members[0]).ParameterList.Parameters[0];
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterServiceProvider.SignatureExactlyEqual(a, null));
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterServiceProvider.SignatureExactlyEqual(null, null));
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = ((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int M([Serializable] ref int1 a = 0, A b){}").Members[0]).ParameterList.Parameters[0];
            b = ((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int M([Serializable] ref int a = 0, A b){}").Members[0]).ParameterList.Parameters[0];
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterServiceProvider.SignatureExactlyEqual(a, null));
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterServiceProvider.SignatureExactlyEqual(null, null));
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = ((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int M([Serializable] ref int a1 = 0, A b){}").Members[0]).ParameterList.Parameters[0];
            b = ((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int M([Serializable] ref int b = 0, A b){}").Members[0]).ParameterList.Parameters[0];
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterServiceProvider.SignatureExactlyEqual(a, null));
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterServiceProvider.SignatureExactlyEqual(null, null));
            Assert.IsTrue(flad.LanguageServiceProvider.ParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = ((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int M([Serializable] ref int a = 0, A b){}").Members[0]).ParameterList.Parameters[0];
            b = ((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int M([Serializable] ref int a = 0, A b){}").Members[0]).ParameterList.Parameters[0];
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterServiceProvider.SignatureExactlyEqual(a, null));
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterServiceProvider.SignatureExactlyEqual(null, null));
            Assert.IsTrue(flad.LanguageServiceProvider.ParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = ((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int M([Serializable] int1 a = 0, A b){}").Members[0]).ParameterList.Parameters[0];
            b = ((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int M([Serializable] int b = 0, A b){}").Members[0]).ParameterList.Parameters[0];
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterServiceProvider.SignatureExactlyEqual(a, null));
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterServiceProvider.SignatureExactlyEqual(null, null));
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = ((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int M([Serializable] int1 a = 0, A b){}").Members[0]).ParameterList.Parameters[0];
            b = ((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int M([Serializable] int a = 0, A b){}").Members[0]).ParameterList.Parameters[0];
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterServiceProvider.SignatureExactlyEqual(a, null));
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterServiceProvider.SignatureExactlyEqual(null, null));
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = ((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int M([Serializable] int a1 = 0, A b){}").Members[0]).ParameterList.Parameters[0];
            b = ((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int M([Serializable] int b = 0, A b){}").Members[0]).ParameterList.Parameters[0];
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterServiceProvider.SignatureExactlyEqual(a, null));
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterServiceProvider.SignatureExactlyEqual(null, null));
            Assert.IsTrue(flad.LanguageServiceProvider.ParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = ((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int M([Serializable] int a = 0, A b){}").Members[0]).ParameterList.Parameters[0];
            b = ((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int M([Serializable] int a = 0, A b){}").Members[0]).ParameterList.Parameters[0];
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterServiceProvider.SignatureExactlyEqual(a, null));
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterServiceProvider.SignatureExactlyEqual(null, null));
            Assert.IsTrue(flad.LanguageServiceProvider.ParameterServiceProvider.SignatureExactlyEqual(a, b));
        }

        [TestMethod]
        public void CrefParameterServiceProvider_SignatureExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            // string aliases
            var a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref string1, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            var b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref string, out string)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, null));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(null, null));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref string, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref string, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref string, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref String, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref String, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref string, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref string, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.String, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.String, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref string, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref String, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.String, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            // bool aliases
            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref bool1, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref bool, out string)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, null));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(null, null));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref bool, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref bool, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref bool, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Boolean, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Boolean, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref bool, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref bool, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.Boolean, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.Boolean, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref bool, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Boolean, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.Boolean, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.Boolean, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Boolean, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            // byte aliases
            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref byte1, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref byte, out string)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, null));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(null, null));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref byte, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref byte, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref byte, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Byte, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Byte, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref byte, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref byte, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.Byte, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.Byte, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref byte, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Byte, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.Byte, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.Byte, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Byte, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            // sbyte aliases
            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref sbyte1, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref sbyte, out string)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, null));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(null, null));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref sbyte, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref sbyte, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref sbyte, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref SByte, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref SByte, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref sbyte, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref sbyte, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.SByte, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.SByte, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref sbyte, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref SByte, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.SByte, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.SByte, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref SByte, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            // bool aliases
            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref bool1, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref bool, out string)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, null));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(null, null));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref bool, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref bool, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref bool, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Boolean, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Boolean, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref bool, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref bool, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.Boolean, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.Boolean, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref bool, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Boolean, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.Boolean, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.Boolean, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Boolean, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            // decimal aliases
            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref decimal1, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref decimal, out string)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, null));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(null, null));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref decimal, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref decimal, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref decimal, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Decimal, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Decimal, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref decimal, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref decimal, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.Decimal, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.Decimal, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref decimal, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Decimal, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.Decimal, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.Decimal, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Decimal, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            // double aliases
            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref double1, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref double, out string)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, null));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(null, null));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref double, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref double, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref double, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Double, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Double, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref double, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref double, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.Double, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.Double, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref double, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Double, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.Double, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.Double, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Double, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            // float aliases
            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref float1, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref float, out string)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, null));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(null, null));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref float, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref float, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref float, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Single, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Single, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref float, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref float, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.Single, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.Single, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref float, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Single, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.Single, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.Single, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Single, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            // int aliases
            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref int1, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref int, out string)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, null));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(null, null));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref int, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref int, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref int, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Int32, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Int32, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref int, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref int, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.Int32, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.Int32, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref int, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Int32, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.Int32, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.Int32, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Int32, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            // uint aliases
            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref uint1, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref uint, out string)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, null));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(null, null));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref uint, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref uint, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref uint, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref UInt32, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref UInt32, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref uint, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref uint, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.UInt32, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.UInt32, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref uint, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref UInt32, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.UInt32, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.UInt32, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref UInt32, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            // long aliases
            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref long1, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref long, out string)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, null));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(null, null));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref long, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref long, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref long, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Int64, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Int64, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref long, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref long, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.Int64, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.Int64, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref long, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Int64, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.Int64, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.Int64, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Int64, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            // ulong aliases
            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref ulong1, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref ulong, out string)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, null));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(null, null));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref ulong, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref ulong, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref ulong, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref UInt64, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref UInt64, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref ulong, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref ulong, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.UInt64, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.UInt64, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref ulong, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref UInt64, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.UInt64, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.UInt64, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref UInt64, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            // object aliases
            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref object1, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref object, out string)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, null));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(null, null));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref object, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref object, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref object, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Object, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Object, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref object, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref object, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.Object, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.Object, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref object, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Object, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.Object, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.Object, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Object, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            // short aliases
            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref short1, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref short, out string)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, null));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(null, null));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref short, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref short, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref short, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Int16, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Int16, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref short, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref short, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.Int16, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.Int16, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref short, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Int16, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.Int16, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.Int16, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Int16, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            // ushort aliases
            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref ushort1, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref ushort, out string)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, null));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(null, null));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref ushort, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref ushort, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref ushort, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref UInt16, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref UInt16, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref ushort, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref ushort, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.UInt16, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.UInt16, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref ushort, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref UInt16, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.UInt16, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.UInt16, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            b = (CrefParameterSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref UInt16, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters.Parameters[0];
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterServiceProvider.SignatureExactlyEqual(a, b));

        }

        [TestMethod]
        public void DelegateDeclarationServiceProvider_SignatureExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = (DelegateDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] delegate void Del<T>(string str);").Members[0];
            var b = (DelegateDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] delegate void iDel<T>(string str);").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureExactlyEqual(a, (DelegateDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureExactlyEqual(null, (DelegateDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureExactlyEqual(a, b));

            a = (DelegateDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] delegate void Del<T>(string str);").Members[0];
            b = (DelegateDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] delegate void Del<T>(string str);").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureExactlyEqual(a, (DelegateDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureExactlyEqual(null, (DelegateDeclarationSyntax)null));
            Assert.IsTrue(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureExactlyEqual(a, b));

            a = (DelegateDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] delegate void Del<T>(string str);").Members[0];
            b = (DelegateDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] delegate void Del<K>(string str);").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureExactlyEqual(a, (DelegateDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureExactlyEqual(null, (DelegateDeclarationSyntax)null));
            Assert.IsTrue(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureExactlyEqual(a, b));

            a = (DelegateDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] delegate void Del<T>(string str);").Members[0];
            b = (DelegateDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] delegate void Del<T, K>(string str);").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureExactlyEqual(a, (DelegateDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureExactlyEqual(null, (DelegateDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureExactlyEqual(a, b));

            a = (DelegateDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] delegate void Del<T>(string str);").Members[0];
            b = (DelegateDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] delegate void Del<K, T>(string str);").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureExactlyEqual(a, (DelegateDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureExactlyEqual(null, (DelegateDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureExactlyEqual(a, b));

            a = (DelegateDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] delegate void Del<T>(string1 str);").Members[0];
            b = (DelegateDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] delegate void Del<K>(string str);").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureExactlyEqual(a, (DelegateDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureExactlyEqual(null, (DelegateDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureExactlyEqual(a, b));

            a = (DelegateDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] delegate void Del<T>(string str, int i);").Members[0];
            b = (DelegateDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] delegate void Del<K>(string str);").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureExactlyEqual(a, (DelegateDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureExactlyEqual(null, (DelegateDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureExactlyEqual(a, b));

            a = (DelegateDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] delegate void Del<T>(string str, int i);").Members[0];
            b = (DelegateDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] delegate void Del<K>(string str, int t);").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureExactlyEqual(a, (DelegateDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureExactlyEqual(null, (DelegateDeclarationSyntax)null));
            Assert.IsTrue(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureExactlyEqual(a, b));

            a = (DelegateDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] delegate void Del(string str);").Members[0];
            b = (DelegateDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] delegate void iDel(string str);").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureExactlyEqual(a, (DelegateDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureExactlyEqual(null, (DelegateDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureExactlyEqual(a, b));

            a = (DelegateDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] delegate void Del(string str);").Members[0];
            b = (DelegateDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] delegate void Del(string str);").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureExactlyEqual(a, (DelegateDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureExactlyEqual(null, (DelegateDeclarationSyntax)null));
            Assert.IsTrue(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureExactlyEqual(a, b));

            a = (DelegateDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] delegate void Del(string1 str);").Members[0];
            b = (DelegateDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] delegate void Del(string str);").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureExactlyEqual(a, (DelegateDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureExactlyEqual(null, (DelegateDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureExactlyEqual(a, b));

            a = (DelegateDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] delegate void Del(string str, int i);").Members[0];
            b = (DelegateDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] delegate void Del(string str);").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureExactlyEqual(a, (DelegateDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureExactlyEqual(null, (DelegateDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureExactlyEqual(a, b));

            a = (DelegateDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] delegate void Del(string str, int i);").Members[0];
            b = (DelegateDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] delegate void Del(string str, int t);").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureExactlyEqual(a, (DelegateDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureExactlyEqual(null, (DelegateDeclarationSyntax)null));
            Assert.IsTrue(flad.LanguageServiceProvider.DelegateDeclarationServiceProvider.SignatureExactlyEqual(a, b));
        }

        [TestMethod]
        public void ClassDeclarationServiceProvider_SignatureExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public class a<T> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            var b = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public class b<T> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.ClassDeclarationServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.ClassDeclarationServiceProvider.SignatureExactlyEqual(a, (ClassDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.ClassDeclarationServiceProvider.SignatureExactlyEqual(null, (ClassDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.ClassDeclarationServiceProvider.SignatureExactlyEqual(a, b));

            a = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public class a<T> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            b = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public class a<T> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.ClassDeclarationServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.ClassDeclarationServiceProvider.SignatureExactlyEqual(a, (ClassDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.ClassDeclarationServiceProvider.SignatureExactlyEqual(null, (ClassDeclarationSyntax)null));
            Assert.IsTrue(flad.LanguageServiceProvider.ClassDeclarationServiceProvider.SignatureExactlyEqual(a, b));

            a = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public class a<T> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            b = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public class a<G> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.ClassDeclarationServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.ClassDeclarationServiceProvider.SignatureExactlyEqual(a, (ClassDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.ClassDeclarationServiceProvider.SignatureExactlyEqual(null, (ClassDeclarationSyntax)null));
            Assert.IsTrue(flad.LanguageServiceProvider.ClassDeclarationServiceProvider.SignatureExactlyEqual(a, b));

            a = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public class a<T> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            b = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public class a<T, F> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.ClassDeclarationServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.ClassDeclarationServiceProvider.SignatureExactlyEqual(a, (ClassDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.ClassDeclarationServiceProvider.SignatureExactlyEqual(null, (ClassDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.ClassDeclarationServiceProvider.SignatureExactlyEqual(a, b));

            a = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public class a<T> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            b = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public class a<T> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.ClassDeclarationServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.ClassDeclarationServiceProvider.SignatureExactlyEqual(a, (ClassDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.ClassDeclarationServiceProvider.SignatureExactlyEqual(null, (ClassDeclarationSyntax)null));
            Assert.IsTrue(flad.LanguageServiceProvider.ClassDeclarationServiceProvider.SignatureExactlyEqual(a, b));

            a = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public class a : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            b = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public class b : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.ClassDeclarationServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.ClassDeclarationServiceProvider.SignatureExactlyEqual(a, (ClassDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.ClassDeclarationServiceProvider.SignatureExactlyEqual(null, (ClassDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.ClassDeclarationServiceProvider.SignatureExactlyEqual(a, b));

            a = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public class a : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            b = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public class a : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.ClassDeclarationServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.ClassDeclarationServiceProvider.SignatureExactlyEqual(a, (ClassDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.ClassDeclarationServiceProvider.SignatureExactlyEqual(null, (ClassDeclarationSyntax)null));
            Assert.IsTrue(flad.LanguageServiceProvider.ClassDeclarationServiceProvider.SignatureExactlyEqual(a, b));
        }

        [TestMethod]
        public void StructDeclarationServiceProvider_SignatureExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = (StructDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public struct a<T> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            var b = (StructDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public struct b<T> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.StructDeclarationServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.StructDeclarationServiceProvider.SignatureExactlyEqual(a, (StructDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.StructDeclarationServiceProvider.SignatureExactlyEqual(null, (StructDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.StructDeclarationServiceProvider.SignatureExactlyEqual(a, b));

            a = (StructDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public struct a<T> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            b = (StructDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public struct a<T> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.StructDeclarationServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.StructDeclarationServiceProvider.SignatureExactlyEqual(a, (StructDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.StructDeclarationServiceProvider.SignatureExactlyEqual(null, (StructDeclarationSyntax)null));
            Assert.IsTrue(flad.LanguageServiceProvider.StructDeclarationServiceProvider.SignatureExactlyEqual(a, b));

            a = (StructDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public struct a<T> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            b = (StructDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public struct a<G> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.StructDeclarationServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.StructDeclarationServiceProvider.SignatureExactlyEqual(a, (StructDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.StructDeclarationServiceProvider.SignatureExactlyEqual(null, (StructDeclarationSyntax)null));
            Assert.IsTrue(flad.LanguageServiceProvider.StructDeclarationServiceProvider.SignatureExactlyEqual(a, b));

            a = (StructDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public struct a<T> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            b = (StructDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public struct a<T, F> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.StructDeclarationServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.StructDeclarationServiceProvider.SignatureExactlyEqual(a, (StructDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.StructDeclarationServiceProvider.SignatureExactlyEqual(null, (StructDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.StructDeclarationServiceProvider.SignatureExactlyEqual(a, b));

            a = (StructDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public struct a<T> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            b = (StructDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public struct a<T> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.StructDeclarationServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.StructDeclarationServiceProvider.SignatureExactlyEqual(a, (StructDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.StructDeclarationServiceProvider.SignatureExactlyEqual(null, (StructDeclarationSyntax)null));
            Assert.IsTrue(flad.LanguageServiceProvider.StructDeclarationServiceProvider.SignatureExactlyEqual(a, b));

            a = (StructDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public struct a : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            b = (StructDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public struct b : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.StructDeclarationServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.StructDeclarationServiceProvider.SignatureExactlyEqual(a, (StructDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.StructDeclarationServiceProvider.SignatureExactlyEqual(null, (StructDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.StructDeclarationServiceProvider.SignatureExactlyEqual(a, b));

            a = (StructDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public struct a : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            b = (StructDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public struct a : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.StructDeclarationServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.StructDeclarationServiceProvider.SignatureExactlyEqual(a, (StructDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.StructDeclarationServiceProvider.SignatureExactlyEqual(null, (StructDeclarationSyntax)null));
            Assert.IsTrue(flad.LanguageServiceProvider.StructDeclarationServiceProvider.SignatureExactlyEqual(a, b));
        }
        
        [TestMethod]
        public void InterfaceDeclarationServiceProvider_SignatureExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = (InterfaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public interface a<T> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            var b = (InterfaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public interface b<T> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.InterfaceDeclarationServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.InterfaceDeclarationServiceProvider.SignatureExactlyEqual(a, (InterfaceDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.InterfaceDeclarationServiceProvider.SignatureExactlyEqual(null, (InterfaceDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.InterfaceDeclarationServiceProvider.SignatureExactlyEqual(a, b));

            a = (InterfaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public interface a<T> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            b = (InterfaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public interface a<T> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.InterfaceDeclarationServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.InterfaceDeclarationServiceProvider.SignatureExactlyEqual(a, (InterfaceDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.InterfaceDeclarationServiceProvider.SignatureExactlyEqual(null, (InterfaceDeclarationSyntax)null));
            Assert.IsTrue(flad.LanguageServiceProvider.InterfaceDeclarationServiceProvider.SignatureExactlyEqual(a, b));

            a = (InterfaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public interface a<T> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            b = (InterfaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public interface a<G> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.InterfaceDeclarationServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.InterfaceDeclarationServiceProvider.SignatureExactlyEqual(a, (InterfaceDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.InterfaceDeclarationServiceProvider.SignatureExactlyEqual(null, (InterfaceDeclarationSyntax)null));
            Assert.IsTrue(flad.LanguageServiceProvider.InterfaceDeclarationServiceProvider.SignatureExactlyEqual(a, b));

            a = (InterfaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public interface a<T> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            b = (InterfaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public interface a<T, F> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.InterfaceDeclarationServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.InterfaceDeclarationServiceProvider.SignatureExactlyEqual(a, (InterfaceDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.InterfaceDeclarationServiceProvider.SignatureExactlyEqual(null, (InterfaceDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.InterfaceDeclarationServiceProvider.SignatureExactlyEqual(a, b));

            a = (InterfaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public interface a<T> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            b = (InterfaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public interface a<T> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.InterfaceDeclarationServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.InterfaceDeclarationServiceProvider.SignatureExactlyEqual(a, (InterfaceDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.InterfaceDeclarationServiceProvider.SignatureExactlyEqual(null, (InterfaceDeclarationSyntax)null));
            Assert.IsTrue(flad.LanguageServiceProvider.InterfaceDeclarationServiceProvider.SignatureExactlyEqual(a, b));

            a = (InterfaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public interface a : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            b = (InterfaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public interface b : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.InterfaceDeclarationServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.InterfaceDeclarationServiceProvider.SignatureExactlyEqual(a, (InterfaceDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.InterfaceDeclarationServiceProvider.SignatureExactlyEqual(null, (InterfaceDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.InterfaceDeclarationServiceProvider.SignatureExactlyEqual(a, b));

            a = (InterfaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public interface a : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            b = (InterfaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public interface a : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.InterfaceDeclarationServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.InterfaceDeclarationServiceProvider.SignatureExactlyEqual(a, (InterfaceDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.InterfaceDeclarationServiceProvider.SignatureExactlyEqual(null, (InterfaceDeclarationSyntax)null));
            Assert.IsTrue(flad.LanguageServiceProvider.InterfaceDeclarationServiceProvider.SignatureExactlyEqual(a, b));
        }

        [TestMethod]
        public void MethodDeclarationServiceProvider_SignatureExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M<T>(int a, A b)where T: class { return 5; };").Members[0];
            var b = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M1<T>(int a, A b)where T: class { return 5; };").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureExactlyEqual(a, (MethodDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureExactlyEqual(null, (MethodDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureExactlyEqual(a, b));

            a = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C1.M<T>(int a, A b)where T: class { return 5; };").Members[0];
            b = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M<T>(int a, A b)where T: class { return 5; };").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureExactlyEqual(a, (MethodDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureExactlyEqual(null, (MethodDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureExactlyEqual(a, b));

            a = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M<T>(int a, A b)where T: class { return 5; };").Members[0];
            b = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M<T>(int a, A b)where T: class { return 5; };").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureExactlyEqual(a, (MethodDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureExactlyEqual(null, (MethodDeclarationSyntax)null));
            Assert.IsTrue(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureExactlyEqual(a, b));

            a = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string M<T>(int a, A b)where T: class { return 5; };").Members[0];
            b = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string M1<T>(int a, A b)where T: class { return 5; };").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureExactlyEqual(a, (MethodDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureExactlyEqual(null, (MethodDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureExactlyEqual(a, b));

            a = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string M<T>(int a, A b)where T: class { return 5; };").Members[0];
            b = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string M<T, K>(int a, A b)where T: class { return 5; };").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureExactlyEqual(a, (MethodDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureExactlyEqual(null, (MethodDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureExactlyEqual(a, b));

            a = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string M<T>(int a, A b)where T: class { return 5; };").Members[0];
            b = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string M<T>(int a, A b)where T: class { return 5; };").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureExactlyEqual(a, (MethodDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureExactlyEqual(null, (MethodDeclarationSyntax)null));
            Assert.IsTrue(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureExactlyEqual(a, b));

            a = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string M<T>(int a)where T: class { return 5; };").Members[0];
            b = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string M<T>(int a, A b)where T: class { return 5; };").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureExactlyEqual(a, (MethodDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureExactlyEqual(null, (MethodDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureExactlyEqual(a, b));

            a = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string M<T>(int a)where T: class { return 5; };").Members[0];
            b = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string M<T>(int b)where T: class { return 5; };").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureExactlyEqual(a, (MethodDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureExactlyEqual(null, (MethodDeclarationSyntax)null));
            Assert.IsTrue(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureExactlyEqual(a, b));

            a = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string M<K>(int a)where T: class { return 5; };").Members[0];
            b = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string M<T>(int b)where T: class { return 5; };").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureExactlyEqual(a, (MethodDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureExactlyEqual(null, (MethodDeclarationSyntax)null));
            Assert.IsTrue(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureExactlyEqual(a, b));

            a = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string M(int a) { return 5; };").Members[0];
            b = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string M(int b) { return 5; };").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureExactlyEqual(a, (MethodDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureExactlyEqual(null, (MethodDeclarationSyntax)null));
            Assert.IsTrue(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureExactlyEqual(a, b));

            a = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string M() { return 5; };").Members[0];
            b = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string M() { return 5; };").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureExactlyEqual(a, (MethodDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureExactlyEqual(null, (MethodDeclarationSyntax)null));
            Assert.IsTrue(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureExactlyEqual(a, b));

            a = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string1 M() { return 5; };").Members[0];
            b = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string M() { return 5; };").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureExactlyEqual(a, (MethodDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureExactlyEqual(null, (MethodDeclarationSyntax)null));
            Assert.IsTrue(flad.LanguageServiceProvider.MethodDeclarationServiceProvider.SignatureExactlyEqual(a, b));
        }

        [TestMethod]
        public void OperatorDeclarationServiceProvider_SignatureExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string operator +(int a, A b) { return 5; };").Members[0];
            var b = (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string operator -(int a, A b) { return 5; };").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.OperatorDeclarationServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.OperatorDeclarationServiceProvider.SignatureExactlyEqual(a, (OperatorDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.OperatorDeclarationServiceProvider.SignatureExactlyEqual(null, (OperatorDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.OperatorDeclarationServiceProvider.SignatureExactlyEqual(a, b));

            a = (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string operator +(int a, A b) { return 5; };").Members[0];
            b = (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string operator +(int a, A b) { return 5; };").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.OperatorDeclarationServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.OperatorDeclarationServiceProvider.SignatureExactlyEqual(a, (OperatorDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.OperatorDeclarationServiceProvider.SignatureExactlyEqual(null, (OperatorDeclarationSyntax)null));
            Assert.IsTrue(flad.LanguageServiceProvider.OperatorDeclarationServiceProvider.SignatureExactlyEqual(a, b));

            a = (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string operator +(int a, B b) { return 5; };").Members[0];
            b = (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string operator +(int a, A b) { return 5; };").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.OperatorDeclarationServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.OperatorDeclarationServiceProvider.SignatureExactlyEqual(a, (OperatorDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.OperatorDeclarationServiceProvider.SignatureExactlyEqual(null, (OperatorDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.OperatorDeclarationServiceProvider.SignatureExactlyEqual(a, b));

            a = (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string operator +(int a, A b) { return 5; };").Members[0];
            b = (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string operator +(int a, A c) { return 5; };").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.OperatorDeclarationServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.OperatorDeclarationServiceProvider.SignatureExactlyEqual(a, (OperatorDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.OperatorDeclarationServiceProvider.SignatureExactlyEqual(null, (OperatorDeclarationSyntax)null));
            Assert.IsTrue(flad.LanguageServiceProvider.OperatorDeclarationServiceProvider.SignatureExactlyEqual(a, b));

            a = (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string operator +(int a) { return 5; };").Members[0];
            b = (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string operator +(int a, A b) { return 5; };").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.OperatorDeclarationServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.OperatorDeclarationServiceProvider.SignatureExactlyEqual(a, (OperatorDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.OperatorDeclarationServiceProvider.SignatureExactlyEqual(null, (OperatorDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.OperatorDeclarationServiceProvider.SignatureExactlyEqual(a, b));

            a = (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string operator +(int a, A b) { return 5; };").Members[0];
            b = (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string1 operator +(int a, A b) { return 5; };").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.OperatorDeclarationServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.OperatorDeclarationServiceProvider.SignatureExactlyEqual(a, (OperatorDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.OperatorDeclarationServiceProvider.SignatureExactlyEqual(null, (OperatorDeclarationSyntax)null));
            Assert.IsTrue(flad.LanguageServiceProvider.OperatorDeclarationServiceProvider.SignatureExactlyEqual(a, b));
        }

        [TestMethod]
        public void ConversionOperatorDeclarationServiceProvider_SignatureExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = (ConversionOperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public operator A1(B b) { return 5; };").Members[0];
            var b = (ConversionOperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public operator A(B b) { return 5; };").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.ConversionOperatorDeclarationServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.ConversionOperatorDeclarationServiceProvider.SignatureExactlyEqual(a, (ConversionOperatorDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.ConversionOperatorDeclarationServiceProvider.SignatureExactlyEqual(null, (ConversionOperatorDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.ConversionOperatorDeclarationServiceProvider.SignatureExactlyEqual(a, b));

            a = (ConversionOperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public operator A(B b) { return 5; };").Members[0];
            b = (ConversionOperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public operator A(B1 b) { return 5; };").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.ConversionOperatorDeclarationServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.ConversionOperatorDeclarationServiceProvider.SignatureExactlyEqual(a, (ConversionOperatorDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.ConversionOperatorDeclarationServiceProvider.SignatureExactlyEqual(null, (ConversionOperatorDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.ConversionOperatorDeclarationServiceProvider.SignatureExactlyEqual(a, b));

            a = (ConversionOperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public operator A(B b) { return 5; };").Members[0];
            b = (ConversionOperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public operator A(B b) { return 5; };").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.ConversionOperatorDeclarationServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.ConversionOperatorDeclarationServiceProvider.SignatureExactlyEqual(a, (ConversionOperatorDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.ConversionOperatorDeclarationServiceProvider.SignatureExactlyEqual(null, (ConversionOperatorDeclarationSyntax)null));
            Assert.IsTrue(flad.LanguageServiceProvider.ConversionOperatorDeclarationServiceProvider.SignatureExactlyEqual(a, b));
        }

        [TestMethod]
        public void ConstructorDeclarationServiceProvider_SignatureExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = (ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation]public A(B b) : this(b) { }; }").Members[0]).Members[0];
            var b = (ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A1 { [Documentation]public A1(B b) : this(b) { }; }").Members[0]).Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.ConstructorDeclarationServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.ConstructorDeclarationServiceProvider.SignatureExactlyEqual(a, (ConstructorDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.ConstructorDeclarationServiceProvider.SignatureExactlyEqual(null, (ConstructorDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.ConstructorDeclarationServiceProvider.SignatureExactlyEqual(a, b));

            a = (ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation]public A(B b) : this(b) { }; }").Members[0]).Members[0];
            b = (ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class C { [Documentation]public C(B b) : this(b) { }; }").Members[0]).Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.ConstructorDeclarationServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.ConstructorDeclarationServiceProvider.SignatureExactlyEqual(a, (ConstructorDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.ConstructorDeclarationServiceProvider.SignatureExactlyEqual(null, (ConstructorDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.ConstructorDeclarationServiceProvider.SignatureExactlyEqual(a, b));

            a = (ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation]public A(B b) : this(b) { }; }").Members[0]).Members[0];
            b = (ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation]public A(B1 b) : this(b) { }; }").Members[0]).Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.ConstructorDeclarationServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.ConstructorDeclarationServiceProvider.SignatureExactlyEqual(a, (ConstructorDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.ConstructorDeclarationServiceProvider.SignatureExactlyEqual(null, (ConstructorDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.ConstructorDeclarationServiceProvider.SignatureExactlyEqual(a, b));

            a = (ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation]public A(B b) : this(b) { }; }").Members[0]).Members[0];
            b = (ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation]public A(B b1) : this(b) { }; }").Members[0]).Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.ConstructorDeclarationServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.ConstructorDeclarationServiceProvider.SignatureExactlyEqual(a, (ConstructorDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.ConstructorDeclarationServiceProvider.SignatureExactlyEqual(null, (ConstructorDeclarationSyntax)null));
            Assert.IsTrue(flad.LanguageServiceProvider.ConstructorDeclarationServiceProvider.SignatureExactlyEqual(a, b));

            a = (ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation]public A() : this() { }; }").Members[0]).Members[0];
            b = (ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation]public A(B b) : this(b) { }; }").Members[0]).Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.ConstructorDeclarationServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.ConstructorDeclarationServiceProvider.SignatureExactlyEqual(a, (ConstructorDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.ConstructorDeclarationServiceProvider.SignatureExactlyEqual(null, (ConstructorDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.ConstructorDeclarationServiceProvider.SignatureExactlyEqual(a, b));

            a = (ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation]public A(B b) : this(b) { }; }").Members[0]).Members[0];
            b = (ConstructorDeclarationSyntax)((ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation]public A(B b) : this(b) { }; }").Members[0]).Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.ConstructorDeclarationServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.ConstructorDeclarationServiceProvider.SignatureExactlyEqual(a, (ConstructorDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.ConstructorDeclarationServiceProvider.SignatureExactlyEqual(null, (ConstructorDeclarationSyntax)null));
            Assert.IsTrue(flad.LanguageServiceProvider.ConstructorDeclarationServiceProvider.SignatureExactlyEqual(a, b));
        }

        //[TestMethod]
        //public void PropertyDeclarationServiceProvider_SignatureExactlyEqual_OK()
        //{
        //    var flad = new CSharpFlad();

        //    var a = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M { get{return 5;} set{this.a = 7} };").Members[0];
        //    var b = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M1 { get{return 5;} set{this.a = 7} };").Members[0];
        //    Assert.IsFalse(flad.LanguageServiceProvider.PropertyDeclarationServiceProvider.SignatureExactlyEqual(null, b));
        //    Assert.IsFalse(flad.LanguageServiceProvider.PropertyDeclarationServiceProvider.SignatureExactlyEqual(a, (PropertyDeclarationSyntax)null));
        //    Assert.IsFalse(flad.LanguageServiceProvider.PropertyDeclarationServiceProvider.SignatureExactlyEqual(null, (PropertyDeclarationSyntax)null));
        //    Assert.IsFalse(flad.LanguageServiceProvider.PropertyDeclarationServiceProvider.SignatureExactlyEqual(a, b));

        //    a = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M { get{return 5;} set{this.a = 7} };").Members[0];
        //    b = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C1.M { get{return 5;} set{this.a = 7} };").Members[0];
        //    Assert.IsFalse(flad.LanguageServiceProvider.PropertyDeclarationServiceProvider.SignatureExactlyEqual(null, b));
        //    Assert.IsFalse(flad.LanguageServiceProvider.PropertyDeclarationServiceProvider.SignatureExactlyEqual(a, (PropertyDeclarationSyntax)null));
        //    Assert.IsFalse(flad.LanguageServiceProvider.PropertyDeclarationServiceProvider.SignatureExactlyEqual(null, (PropertyDeclarationSyntax)null));
        //    Assert.IsFalse(flad.LanguageServiceProvider.PropertyDeclarationServiceProvider.SignatureExactlyEqual(a, b));

        //    a = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M { get{return 5;} set{this.a = 7} };").Members[0];
        //    b = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M { get{return 5;} set{this.a = 7} };").Members[0];
        //    Assert.IsTrue(flad.LanguageServiceProvider.PropertyDeclarationServiceProvider.SignatureExactlyEqual(a, b));

        //    a = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string M { get{return 5;} set{this.a = 7} };").Members[0];
        //    b = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string M1 { get{return 5;} set{this.a = 7} };").Members[0];
        //    Assert.IsFalse(flad.LanguageServiceProvider.PropertyDeclarationServiceProvider.SignatureExactlyEqual(null, b));
        //    Assert.IsFalse(flad.LanguageServiceProvider.PropertyDeclarationServiceProvider.SignatureExactlyEqual(a, (PropertyDeclarationSyntax)null));
        //    Assert.IsFalse(flad.LanguageServiceProvider.PropertyDeclarationServiceProvider.SignatureExactlyEqual(null, (PropertyDeclarationSyntax)null));
        //    Assert.IsFalse(flad.LanguageServiceProvider.PropertyDeclarationServiceProvider.SignatureExactlyEqual(a, b));

        //    a = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string M { get{return 5;} set{this.a = 7} };").Members[0];
        //    b = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string M { get{return 5;} set{this.a = 7} };").Members[0];
        //    Assert.IsTrue(flad.LanguageServiceProvider.PropertyDeclarationServiceProvider.SignatureExactlyEqual(a, b));
        //}

        [TestMethod]
        public void EventDeclarationServiceProvider_SignatureExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = (EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A C.M { add{this.M += value;} remove{this.M -= value} }").Members[0];
            var b = (EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A C.M1 { add{this.M += value;} remove{this.M -= value} }").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.EventDeclarationServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.EventDeclarationServiceProvider.SignatureExactlyEqual(a, (EventDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.EventDeclarationServiceProvider.SignatureExactlyEqual(null, (EventDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.EventDeclarationServiceProvider.SignatureExactlyEqual(a, b));

            a = (EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A C.M { add{this.M += value;} remove{this.M -= value} }").Members[0];
            b = (EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A C1.M { add{this.M += value;} remove{this.M -= value} }").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.EventDeclarationServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.EventDeclarationServiceProvider.SignatureExactlyEqual(a, (EventDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.EventDeclarationServiceProvider.SignatureExactlyEqual(null, (EventDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.EventDeclarationServiceProvider.SignatureExactlyEqual(a, b));

            a = (EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A C.M { add{this.M += value;} remove{this.M -= value} }").Members[0];
            b = (EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A C.M { add{this.M += value;} remove{this.M -= value} }").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.EventDeclarationServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.EventDeclarationServiceProvider.SignatureExactlyEqual(a, (EventDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.EventDeclarationServiceProvider.SignatureExactlyEqual(null, (EventDeclarationSyntax)null));
            Assert.IsTrue(flad.LanguageServiceProvider.EventDeclarationServiceProvider.SignatureExactlyEqual(a, b));

            a = (EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A M { add{this.M += value;} remove{this.M -= value} }").Members[0];
            b = (EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A M1 { add{this.M += value;} remove{this.M -= value} }").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.EventDeclarationServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.EventDeclarationServiceProvider.SignatureExactlyEqual(a, (EventDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.EventDeclarationServiceProvider.SignatureExactlyEqual(null, (EventDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.EventDeclarationServiceProvider.SignatureExactlyEqual(a, b));

            a = (EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A M { add{this.M += value;} remove{this.M -= value} }").Members[0];
            b = (EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A M { add{this.M += value;} remove{this.M -= value} }").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.EventDeclarationServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.EventDeclarationServiceProvider.SignatureExactlyEqual(a, (EventDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.EventDeclarationServiceProvider.SignatureExactlyEqual(null, (EventDeclarationSyntax)null));
            Assert.IsTrue(flad.LanguageServiceProvider.EventDeclarationServiceProvider.SignatureExactlyEqual(a, b));
        }

        [TestMethod]
        public void IndexerDeclarationServiceProvider_SignatureExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A C.this[string key] { get{return this.M[key];} set{this.M[key] = value;} } => 5;").Members[0];
            var b = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A C.this[string key] { get{return this.M[key];} set{this.M[key] = value;} } => 5;").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureExactlyEqual(a, (IndexerDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureExactlyEqual(null, (IndexerDeclarationSyntax)null));
            Assert.IsTrue(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureExactlyEqual(a, b));

            a = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A C.this[string key] { get{return this.M[key];} set{this.M[key] = value;} } => 5;").Members[0];
            b = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A C1.this[string key] { get{return this.M[key];} set{this.M[key] = value;} } => 5;").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureExactlyEqual(a, (IndexerDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureExactlyEqual(null, (IndexerDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureExactlyEqual(a, b));

            a = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A C.this[string1 key] { get{return this.M[key];} set{this.M[key] = value;} } => 5;").Members[0];
            b = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A C.this[string key] { get{return this.M[key];} set{this.M[key] = value;} } => 5;").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureExactlyEqual(a, (IndexerDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureExactlyEqual(null, (IndexerDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureExactlyEqual(a, b));

            a = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A C.this[string key] { get{return this.M[key];} set{this.M[key] = value;} } => 5;").Members[0];
            b = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A C.this[string key, int t] { get{return this.M[key];} set{this.M[key] = value;} } => 5;").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureExactlyEqual(a, (IndexerDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureExactlyEqual(null, (IndexerDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureExactlyEqual(a, b));

            a = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A C.this[string key, int r] { get{return this.M[key];} set{this.M[key] = value;} } => 5;").Members[0];
            b = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A C.this[string key, int i] { get{return this.M[key];} set{this.M[key] = value;} } => 5;").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureExactlyEqual(a, (IndexerDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureExactlyEqual(null, (IndexerDeclarationSyntax)null));
            Assert.IsTrue(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureExactlyEqual(a, b));

            a = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A this[string key] { get{return this.M[key];} set{this.M[key] = value;} } => 5;").Members[0];
            b = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A this[string key] { get{return this.M[key];} set{this.M[key] = value;} } => 5;").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureExactlyEqual(a, (IndexerDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureExactlyEqual(null, (IndexerDeclarationSyntax)null));
            Assert.IsTrue(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureExactlyEqual(a, b));

            a = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A this[string key] { get{return this.M[key];} set{this.M[key] = value;} } => 5;").Members[0];
            b = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A this[string key] { get{return this.M[key];} set{this.M[key] = value;} } => 5;").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureExactlyEqual(a, (IndexerDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureExactlyEqual(null, (IndexerDeclarationSyntax)null));
            Assert.IsTrue(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureExactlyEqual(a, b));

            a = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A this[string1 key] { get{return this.M[key];} set{this.M[key] = value;} } => 5;").Members[0];
            b = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A this[string key] { get{return this.M[key];} set{this.M[key] = value;} } => 5;").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureExactlyEqual(a, (IndexerDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureExactlyEqual(null, (IndexerDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureExactlyEqual(a, b));

            a = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A this[string key] { get{return this.M[key];} set{this.M[key] = value;} } => 5;").Members[0];
            b = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A this[string key, int t] { get{return this.M[key];} set{this.M[key] = value;} } => 5;").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureExactlyEqual(a, (IndexerDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureExactlyEqual(null, (IndexerDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureExactlyEqual(a, b));

            a = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A this[string key, int r] { get{return this.M[key];} set{this.M[key] = value;} } => 5;").Members[0];
            b = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A this[string key, int i] { get{return this.M[key];} set{this.M[key] = value;} } => 5;").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureExactlyEqual(a, (IndexerDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureExactlyEqual(null, (IndexerDeclarationSyntax)null));
            Assert.IsTrue(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureExactlyEqual(a, b));

            a = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A this[string key] { get{return this.M[key];} set{this.M[key] = value;} } => 5;").Members[0];
            b = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A this[string key] { get{return this.M[key];} set{this.M[key] = value;} } => 5;").Members[0];
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureExactlyEqual(a, (IndexerDeclarationSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureExactlyEqual(null, (IndexerDeclarationSyntax)null));
            Assert.IsTrue(flad.LanguageServiceProvider.IndexerDeclarationServiceProvider.SignatureExactlyEqual(a, b));
        }

        [TestMethod]
        public void ParameterListSyntax_SignatureExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = ((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int M([Serializable] ref int1 a = 0, A b){}").Members[0]).ParameterList;
            var b = ((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int M([Serializable] ref int a = 0, A b){}").Members[0]).ParameterList;
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterListServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterListServiceProvider.SignatureExactlyEqual(a, (ParameterListSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterListServiceProvider.SignatureExactlyEqual(null, (ParameterListSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = ((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int M([Serializable] ref int a = 0){}").Members[0]).ParameterList;
            b = ((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int M([Serializable] ref int a = 0, A b){}").Members[0]).ParameterList;
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterListServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterListServiceProvider.SignatureExactlyEqual(a, (ParameterListSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterListServiceProvider.SignatureExactlyEqual(null, (ParameterListSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = ((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int M([Serializable] ref int a = 0, A b){}").Members[0]).ParameterList;
            b = ((MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int M(A b, [Serializable] ref int a = 0){}").Members[0]).ParameterList;
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterListServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterListServiceProvider.SignatureExactlyEqual(a, (ParameterListSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterListServiceProvider.SignatureExactlyEqual(null, (ParameterListSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.ParameterListServiceProvider.SignatureExactlyEqual(a, b));
        }

        [TestMethod]
        public void BracketedParameterListSyntax_SignatureExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = ((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int this[[Serializable] ref int1 a = 0, A b]{get;set;}").Members[0]).ParameterList;
            var b = ((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int this[[Serializable] ref int a = 0, A b]{get;set;}").Members[0]).ParameterList;
            Assert.IsFalse(flad.LanguageServiceProvider.BracketedParameterListServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.BracketedParameterListServiceProvider.SignatureExactlyEqual(a, (BracketedParameterListSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.BracketedParameterListServiceProvider.SignatureExactlyEqual(null, (BracketedParameterListSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.BracketedParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = ((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int this[[Serializable] ref int a = 0]{get;set;}").Members[0]).ParameterList;
            b = ((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int this[[Serializable] ref int a = 0, A b]{get;set;}").Members[0]).ParameterList;
            Assert.IsFalse(flad.LanguageServiceProvider.BracketedParameterListServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.BracketedParameterListServiceProvider.SignatureExactlyEqual(a, (BracketedParameterListSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.BracketedParameterListServiceProvider.SignatureExactlyEqual(null, (BracketedParameterListSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.BracketedParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = ((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int this[[Serializable] ref int a = 0, A b]{get;set;}").Members[0]).ParameterList;
            b = ((IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int this[[A b, Serializable] ref int a = 0]{get;set;}").Members[0]).ParameterList;
            Assert.IsFalse(flad.LanguageServiceProvider.BracketedParameterListServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.BracketedParameterListServiceProvider.SignatureExactlyEqual(a, (BracketedParameterListSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.BracketedParameterListServiceProvider.SignatureExactlyEqual(null, (BracketedParameterListSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.BracketedParameterListServiceProvider.SignatureExactlyEqual(a, b));
        }

        [TestMethod]
        public void NameMemberCrefServiceProvider_SignatureExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"N(int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<NameMemberCrefSyntax>().Single();
            var b = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"N1(int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<NameMemberCrefSyntax>().Single();
            Assert.IsFalse(flad.LanguageServiceProvider.NameMemberCrefServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.NameMemberCrefServiceProvider.SignatureExactlyEqual(a, (NameMemberCrefSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.NameMemberCrefServiceProvider.SignatureExactlyEqual(null, (NameMemberCrefSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.NameMemberCrefServiceProvider.SignatureExactlyEqual(a, b));

            a = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"N(int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<NameMemberCrefSyntax>().Single();
            b = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"N(int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<NameMemberCrefSyntax>().Single();
            Assert.IsFalse(flad.LanguageServiceProvider.NameMemberCrefServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.NameMemberCrefServiceProvider.SignatureExactlyEqual(a, (NameMemberCrefSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.NameMemberCrefServiceProvider.SignatureExactlyEqual(null, (NameMemberCrefSyntax)null));
            Assert.IsTrue(flad.LanguageServiceProvider.NameMemberCrefServiceProvider.SignatureExactlyEqual(a, b));

            a = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"N(int, string)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<NameMemberCrefSyntax>().Single();
            b = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"N(int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<NameMemberCrefSyntax>().Single();
            Assert.IsFalse(flad.LanguageServiceProvider.NameMemberCrefServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.NameMemberCrefServiceProvider.SignatureExactlyEqual(a, (NameMemberCrefSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.NameMemberCrefServiceProvider.SignatureExactlyEqual(null, (NameMemberCrefSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.NameMemberCrefServiceProvider.SignatureExactlyEqual(a, b));

            a = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"N(int, string)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<NameMemberCrefSyntax>().Single();
            b = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"N(string, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<NameMemberCrefSyntax>().Single();
            Assert.IsFalse(flad.LanguageServiceProvider.NameMemberCrefServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.NameMemberCrefServiceProvider.SignatureExactlyEqual(a, (NameMemberCrefSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.NameMemberCrefServiceProvider.SignatureExactlyEqual(null, (NameMemberCrefSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.NameMemberCrefServiceProvider.SignatureExactlyEqual(a, b));
        }

        [TestMethod]
        public void IndexerMemberCrefServiceProvider_SignatureExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"this[int]\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<IndexerMemberCrefSyntax>().Single();
            var b = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"this[int]\"/> </summary>" + Environment.NewLine +
                       "    class A1 { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<IndexerMemberCrefSyntax>().Single();
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerMemberCrefServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerMemberCrefServiceProvider.SignatureExactlyEqual(a, (IndexerMemberCrefSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerMemberCrefServiceProvider.SignatureExactlyEqual(null, (IndexerMemberCrefSyntax)null));
            Assert.IsTrue(flad.LanguageServiceProvider.IndexerMemberCrefServiceProvider.SignatureExactlyEqual(a, b));

            a = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"this[int1]\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<IndexerMemberCrefSyntax>().Single();
            b = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"this[int]\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<IndexerMemberCrefSyntax>().Single();
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerMemberCrefServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerMemberCrefServiceProvider.SignatureExactlyEqual(a, (IndexerMemberCrefSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerMemberCrefServiceProvider.SignatureExactlyEqual(null, (IndexerMemberCrefSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerMemberCrefServiceProvider.SignatureExactlyEqual(a, b));

            a = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"this[int]\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<IndexerMemberCrefSyntax>().Single();
            b = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"this[int]\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<IndexerMemberCrefSyntax>().Single();
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerMemberCrefServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerMemberCrefServiceProvider.SignatureExactlyEqual(a, (IndexerMemberCrefSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerMemberCrefServiceProvider.SignatureExactlyEqual(null, (IndexerMemberCrefSyntax)null));
            Assert.IsTrue(flad.LanguageServiceProvider.IndexerMemberCrefServiceProvider.SignatureExactlyEqual(a, b));

            a = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"this[int, string]\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<IndexerMemberCrefSyntax>().Single();
            b = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"this[int]\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<IndexerMemberCrefSyntax>().Single();
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerMemberCrefServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerMemberCrefServiceProvider.SignatureExactlyEqual(a, (IndexerMemberCrefSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerMemberCrefServiceProvider.SignatureExactlyEqual(null, (IndexerMemberCrefSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerMemberCrefServiceProvider.SignatureExactlyEqual(a, b));

            a = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"this[int, string]\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<IndexerMemberCrefSyntax>().Single();
            b = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"this[string, int]\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<IndexerMemberCrefSyntax>().Single();
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerMemberCrefServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerMemberCrefServiceProvider.SignatureExactlyEqual(a, (IndexerMemberCrefSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerMemberCrefServiceProvider.SignatureExactlyEqual(null, (IndexerMemberCrefSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.IndexerMemberCrefServiceProvider.SignatureExactlyEqual(a, b));
        }

        [TestMethod]
        public void OperatorMemberCrefServiceProvider_SignatureExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single();
            var b = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator -(int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single();
            Assert.IsFalse(flad.LanguageServiceProvider.OperatorMemberCrefServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.OperatorMemberCrefServiceProvider.SignatureExactlyEqual(a, (OperatorMemberCrefSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.OperatorMemberCrefServiceProvider.SignatureExactlyEqual(null, (OperatorMemberCrefSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.OperatorMemberCrefServiceProvider.SignatureExactlyEqual(a, b));

            a = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single();
            b = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(int, string)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single();
            Assert.IsFalse(flad.LanguageServiceProvider.OperatorMemberCrefServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.OperatorMemberCrefServiceProvider.SignatureExactlyEqual(a, (OperatorMemberCrefSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.OperatorMemberCrefServiceProvider.SignatureExactlyEqual(null, (OperatorMemberCrefSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.OperatorMemberCrefServiceProvider.SignatureExactlyEqual(a, b));

            a = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(string, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single();
            b = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(int, string)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single();
            Assert.IsFalse(flad.LanguageServiceProvider.OperatorMemberCrefServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.OperatorMemberCrefServiceProvider.SignatureExactlyEqual(a, (OperatorMemberCrefSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.OperatorMemberCrefServiceProvider.SignatureExactlyEqual(null, (OperatorMemberCrefSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.OperatorMemberCrefServiceProvider.SignatureExactlyEqual(a, b));

            a = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single();
            b = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single();
            Assert.IsFalse(flad.LanguageServiceProvider.OperatorMemberCrefServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.OperatorMemberCrefServiceProvider.SignatureExactlyEqual(a, (OperatorMemberCrefSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.OperatorMemberCrefServiceProvider.SignatureExactlyEqual(null, (OperatorMemberCrefSyntax)null));
            Assert.IsTrue(flad.LanguageServiceProvider.OperatorMemberCrefServiceProvider.SignatureExactlyEqual(a, b));
        }

        [TestMethod]
        public void ConversionOperatorMemberCrefServiceProvider_SignatureExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"implicit operator N(int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<ConversionOperatorMemberCrefSyntax>().Single();
            var b = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"implicit operator N(int1)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<ConversionOperatorMemberCrefSyntax>().Single();
            Assert.IsFalse(flad.LanguageServiceProvider.ConversionOperatorMemberCrefServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.ConversionOperatorMemberCrefServiceProvider.SignatureExactlyEqual(a, (ConversionOperatorMemberCrefSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.ConversionOperatorMemberCrefServiceProvider.SignatureExactlyEqual(null, (ConversionOperatorMemberCrefSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.ConversionOperatorMemberCrefServiceProvider.SignatureExactlyEqual(a, b));

            a = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"implicit operator N(int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<ConversionOperatorMemberCrefSyntax>().Single();
            b = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"implicit operator N1(int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<ConversionOperatorMemberCrefSyntax>().Single();
            Assert.IsFalse(flad.LanguageServiceProvider.ConversionOperatorMemberCrefServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.ConversionOperatorMemberCrefServiceProvider.SignatureExactlyEqual(a, (ConversionOperatorMemberCrefSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.ConversionOperatorMemberCrefServiceProvider.SignatureExactlyEqual(null, (ConversionOperatorMemberCrefSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.ConversionOperatorMemberCrefServiceProvider.SignatureExactlyEqual(a, b));

            a = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"implicit operator N(int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<ConversionOperatorMemberCrefSyntax>().Single();
            b = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"implicit operator N(int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<ConversionOperatorMemberCrefSyntax>().Single();
            Assert.IsFalse(flad.LanguageServiceProvider.ConversionOperatorMemberCrefServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.ConversionOperatorMemberCrefServiceProvider.SignatureExactlyEqual(a, (ConversionOperatorMemberCrefSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.ConversionOperatorMemberCrefServiceProvider.SignatureExactlyEqual(null, (ConversionOperatorMemberCrefSyntax)null));
            Assert.IsTrue(flad.LanguageServiceProvider.ConversionOperatorMemberCrefServiceProvider.SignatureExactlyEqual(a, b));
        }

        [TestMethod]
        public void CrefParameterListListServiceProvider_SignatureExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            // string aliases
            var a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref string1, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            var b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref string, out string)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, null));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(null, null));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref string, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref string, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref string, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref String, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref String, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref string, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref string, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.String, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.String, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref string, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref String, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.String, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            // bool aliases
            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref bool1, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref bool, out string)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, null));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(null, null));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref bool, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref bool, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref bool, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Boolean, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Boolean, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref bool, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref bool, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.Boolean, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.Boolean, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref bool, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Boolean, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.Boolean, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.Boolean, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Boolean, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            // byte aliases
            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref byte1, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref byte, out string)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, null));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(null, null));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref byte, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref byte, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref byte, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Byte, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Byte, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref byte, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref byte, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.Byte, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.Byte, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref byte, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Byte, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.Byte, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.Byte, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Byte, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            // sbyte aliases
            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref sbyte1, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref sbyte, out string)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, null));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(null, null));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref sbyte, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref sbyte, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref sbyte, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref SByte, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref SByte, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref sbyte, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref sbyte, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.SByte, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.SByte, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref sbyte, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref SByte, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.SByte, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.SByte, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref SByte, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            // bool aliases
            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref bool1, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref bool, out string)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, null));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(null, null));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref bool, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref bool, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref bool, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Boolean, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Boolean, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref bool, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref bool, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.Boolean, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.Boolean, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref bool, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Boolean, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.Boolean, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.Boolean, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Boolean, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            // decimal aliases
            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref decimal1, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref decimal, out string)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, null));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(null, null));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref decimal, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref decimal, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref decimal, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Decimal, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Decimal, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref decimal, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref decimal, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.Decimal, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.Decimal, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref decimal, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Decimal, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.Decimal, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.Decimal, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Decimal, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            // double aliases
            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref double1, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref double, out string)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, null));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(null, null));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref double, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref double, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref double, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Double, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Double, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref double, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref double, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.Double, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.Double, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref double, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Double, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.Double, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.Double, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Double, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            // float aliases
            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref float1, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref float, out string)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, null));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(null, null));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref float, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref float, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref float, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Single, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Single, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref float, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref float, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.Single, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.Single, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref float, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Single, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.Single, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.Single, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Single, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            // int aliases
            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref int1, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref int, out string)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, null));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(null, null));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref int, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref int, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref int, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Int32, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Int32, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref int, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref int, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.Int32, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.Int32, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref int, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Int32, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.Int32, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.Int32, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Int32, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            // uint aliases
            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref uint1, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref uint, out string)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, null));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(null, null));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref uint, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref uint, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref uint, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref UInt32, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref UInt32, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref uint, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref uint, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.UInt32, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.UInt32, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref uint, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref UInt32, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.UInt32, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.UInt32, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref UInt32, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            // long aliases
            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref long1, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref long, out string)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, null));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(null, null));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref long, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref long, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref long, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Int64, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Int64, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref long, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref long, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.Int64, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.Int64, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref long, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Int64, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.Int64, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.Int64, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Int64, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            // ulong aliases
            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref ulong1, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref ulong, out string)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, null));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(null, null));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref ulong, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref ulong, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref ulong, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref UInt64, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref UInt64, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref ulong, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref ulong, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.UInt64, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.UInt64, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref ulong, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref UInt64, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.UInt64, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.UInt64, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref UInt64, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            // object aliases
            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref object1, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref object, out string)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, null));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(null, null));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref object, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref object, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref object, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Object, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Object, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref object, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref object, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.Object, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.Object, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref object, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Object, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.Object, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.Object, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Object, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            // short aliases
            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref short1, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref short, out string)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, null));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(null, null));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref short, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref short, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref short, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Int16, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Int16, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref short, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref short, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.Int16, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.Int16, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref short, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Int16, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.Int16, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.Int16, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref Int16, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            // ushort aliases
            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref ushort1, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref ushort, out string)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, null));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(null, null));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref ushort, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref ushort, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref ushort, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref UInt16, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref UInt16, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref ushort, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref ushort, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.UInt16, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.UInt16, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref ushort, int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref UInt16, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref System.UInt16, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.UInt16, out int)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref UInt16, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsTrue(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));


            a = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                      "    /// <summary> <see cref=\"operator +(ref System.UInt16)\"/> </summary>" + Environment.NewLine +
                      "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            b = (CrefParameterListSyntax)SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"operator +(ref UInt16, out int)\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").DescendantNodes(descendIntoTrivia: true).OfType<OperatorMemberCrefSyntax>().Single().Parameters;
            Assert.IsFalse(flad.LanguageServiceProvider.CrefParameterListServiceProvider.SignatureExactlyEqual(a, b));
        }

        [TestMethod]
        public void CrefBracketedParameterListSyntax_SignatureExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"this[int1, string]\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<IndexerMemberCrefSyntax>().Single().Parameters;
            var b = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"this[int, string]\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<IndexerMemberCrefSyntax>().Single().Parameters;
            Assert.IsFalse(flad.LanguageServiceProvider.CrefBracketedParameterListServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefBracketedParameterListServiceProvider.SignatureExactlyEqual(a, (CrefBracketedParameterListSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefBracketedParameterListServiceProvider.SignatureExactlyEqual(null, (CrefBracketedParameterListSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefBracketedParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"this[int]\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<IndexerMemberCrefSyntax>().Single().Parameters;
            b = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"this[int, string]\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<IndexerMemberCrefSyntax>().Single().Parameters;
            Assert.IsFalse(flad.LanguageServiceProvider.CrefBracketedParameterListServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefBracketedParameterListServiceProvider.SignatureExactlyEqual(a, (CrefBracketedParameterListSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefBracketedParameterListServiceProvider.SignatureExactlyEqual(null, (CrefBracketedParameterListSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefBracketedParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"this[int, string]\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<IndexerMemberCrefSyntax>().Single().Parameters;
            b = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"this[string, int]\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<IndexerMemberCrefSyntax>().Single().Parameters;
            Assert.IsFalse(flad.LanguageServiceProvider.CrefBracketedParameterListServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefBracketedParameterListServiceProvider.SignatureExactlyEqual(a, (CrefBracketedParameterListSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefBracketedParameterListServiceProvider.SignatureExactlyEqual(null, (CrefBracketedParameterListSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefBracketedParameterListServiceProvider.SignatureExactlyEqual(a, b));

            a = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                        "    /// <summary> <see cref=\"this[int, string]\"/> </summary>" + Environment.NewLine +
                        "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<IndexerMemberCrefSyntax>().Single().Parameters;
            b = SyntaxFactory.ParseCompilationUnit("namespace N { " + Environment.NewLine +
                       "    /// <summary> <see cref=\"this[int, string]\"/> </summary>" + Environment.NewLine +
                       "    class A { } }").Members[0].DescendantNodes(descendIntoTrivia: true).OfType<IndexerMemberCrefSyntax>().Single().Parameters;
            Assert.IsFalse(flad.LanguageServiceProvider.CrefBracketedParameterListServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefBracketedParameterListServiceProvider.SignatureExactlyEqual(a, (CrefBracketedParameterListSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.CrefBracketedParameterListServiceProvider.SignatureExactlyEqual(null, (CrefBracketedParameterListSyntax)null));
            Assert.IsTrue(flad.LanguageServiceProvider.CrefBracketedParameterListServiceProvider.SignatureExactlyEqual(a, b));
        }

        [TestMethod]
        public void AnonymousMethodExpressionSyntax_SignatureExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = (AnonymousMethodExpressionSyntax)SyntaxFactory.ParseExpression("async delegate { return 4; }");
            var b = (AnonymousMethodExpressionSyntax)SyntaxFactory.ParseExpression("async delegate { return 4; }");
            Assert.IsFalse(flad.LanguageServiceProvider.AnonymousMethodExpressionServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.AnonymousMethodExpressionServiceProvider.SignatureExactlyEqual(a, (AnonymousMethodExpressionSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.AnonymousMethodExpressionServiceProvider.SignatureExactlyEqual(null, (AnonymousMethodExpressionSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.AnonymousMethodExpressionServiceProvider.SignatureExactlyEqual(a, b));

            a = (AnonymousMethodExpressionSyntax)SyntaxFactory.ParseExpression("async delegate(T x) { return 4; }");
            b = (AnonymousMethodExpressionSyntax)SyntaxFactory.ParseExpression("async delegate(T x1) { return 4; }");
            Assert.IsFalse(flad.LanguageServiceProvider.AnonymousMethodExpressionServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.AnonymousMethodExpressionServiceProvider.SignatureExactlyEqual(a, (AnonymousMethodExpressionSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.AnonymousMethodExpressionServiceProvider.SignatureExactlyEqual(null, (AnonymousMethodExpressionSyntax)null));
            Assert.IsTrue(flad.LanguageServiceProvider.AnonymousMethodExpressionServiceProvider.SignatureExactlyEqual(a, b));

            a = (AnonymousMethodExpressionSyntax)SyntaxFactory.ParseExpression("async delegate(T x) { return 4; }");
            b = (AnonymousMethodExpressionSyntax)SyntaxFactory.ParseExpression("async delegate(T1 x) { return 4; }");
            Assert.IsFalse(flad.LanguageServiceProvider.AnonymousMethodExpressionServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.AnonymousMethodExpressionServiceProvider.SignatureExactlyEqual(a, (AnonymousMethodExpressionSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.AnonymousMethodExpressionServiceProvider.SignatureExactlyEqual(null, (AnonymousMethodExpressionSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.AnonymousMethodExpressionServiceProvider.SignatureExactlyEqual(a, b));

            a = (AnonymousMethodExpressionSyntax)SyntaxFactory.ParseExpression("async delegate(T x) { return 4; }");
            b = (AnonymousMethodExpressionSyntax)SyntaxFactory.ParseExpression("async delegate(T x, K y) { return 4; }");
            Assert.IsFalse(flad.LanguageServiceProvider.AnonymousMethodExpressionServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.AnonymousMethodExpressionServiceProvider.SignatureExactlyEqual(a, (AnonymousMethodExpressionSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.AnonymousMethodExpressionServiceProvider.SignatureExactlyEqual(null, (AnonymousMethodExpressionSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.AnonymousMethodExpressionServiceProvider.SignatureExactlyEqual(a, b));

            a = (AnonymousMethodExpressionSyntax)SyntaxFactory.ParseExpression("async delegate(T x, K y) { return 4; }");
            b = (AnonymousMethodExpressionSyntax)SyntaxFactory.ParseExpression("async delegate(T x, K y) { return 4; }");
            Assert.IsFalse(flad.LanguageServiceProvider.AnonymousMethodExpressionServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.AnonymousMethodExpressionServiceProvider.SignatureExactlyEqual(a, (AnonymousMethodExpressionSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.AnonymousMethodExpressionServiceProvider.SignatureExactlyEqual(null, (AnonymousMethodExpressionSyntax)null));
            Assert.IsTrue(flad.LanguageServiceProvider.AnonymousMethodExpressionServiceProvider.SignatureExactlyEqual(a, b));

            a = (AnonymousMethodExpressionSyntax)SyntaxFactory.ParseExpression("async delegate(T x, K y) { return 4; }");
            b = (AnonymousMethodExpressionSyntax)SyntaxFactory.ParseExpression("async delegate(K y, T x) { return 4; }");
            Assert.IsFalse(flad.LanguageServiceProvider.AnonymousMethodExpressionServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.AnonymousMethodExpressionServiceProvider.SignatureExactlyEqual(a, (AnonymousMethodExpressionSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.AnonymousMethodExpressionServiceProvider.SignatureExactlyEqual(null, (AnonymousMethodExpressionSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.AnonymousMethodExpressionServiceProvider.SignatureExactlyEqual(a, b));
        }

        [TestMethod]
        public void SimpleLambdaExpressionServiceProvider_SignatureExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = (SimpleLambdaExpressionSyntax)SyntaxFactory.ParseExpression("e => 4 }");
            var b = (SimpleLambdaExpressionSyntax)SyntaxFactory.ParseExpression("E => 4 }");
            Assert.IsFalse(flad.LanguageServiceProvider.SimpleLambdaExpressionServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.SimpleLambdaExpressionServiceProvider.SignatureExactlyEqual(a, (SimpleLambdaExpressionSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.SimpleLambdaExpressionServiceProvider.SignatureExactlyEqual(null, (SimpleLambdaExpressionSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.SimpleLambdaExpressionServiceProvider.SignatureExactlyEqual(a, b));

            a = (SimpleLambdaExpressionSyntax)SyntaxFactory.ParseExpression("e => 4 }");
            b = (SimpleLambdaExpressionSyntax)SyntaxFactory.ParseExpression("e => 4 }");
            Assert.IsFalse(flad.LanguageServiceProvider.SimpleLambdaExpressionServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.SimpleLambdaExpressionServiceProvider.SignatureExactlyEqual(a, (SimpleLambdaExpressionSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.SimpleLambdaExpressionServiceProvider.SignatureExactlyEqual(null, (SimpleLambdaExpressionSyntax)null));
            Assert.IsTrue(flad.LanguageServiceProvider.SimpleLambdaExpressionServiceProvider.SignatureExactlyEqual(a, b));
        }

        [TestMethod]
        public void ParenthesizedLambdaExpressionServiceProvider_SignatureExactlyEqual_OK()
        {
            var flad = new CSharpFlad();

            var a = (ParenthesizedLambdaExpressionSyntax)SyntaxFactory.ParseExpression("(E e) => 4 }");
            var b = (ParenthesizedLambdaExpressionSyntax)SyntaxFactory.ParseExpression("(E e1) => 4 }");
            Assert.IsFalse(flad.LanguageServiceProvider.ParenthesizedLambdaExpressionServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.ParenthesizedLambdaExpressionServiceProvider.SignatureExactlyEqual(a, (ParenthesizedLambdaExpressionSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.ParenthesizedLambdaExpressionServiceProvider.SignatureExactlyEqual(null, (ParenthesizedLambdaExpressionSyntax)null));
            Assert.IsTrue(flad.LanguageServiceProvider.ParenthesizedLambdaExpressionServiceProvider.SignatureExactlyEqual(a, b));

            a = (ParenthesizedLambdaExpressionSyntax)SyntaxFactory.ParseExpression("(E e) => 4 }");
            b = (ParenthesizedLambdaExpressionSyntax)SyntaxFactory.ParseExpression("(E1 e) => 4 }");
            Assert.IsFalse(flad.LanguageServiceProvider.ParenthesizedLambdaExpressionServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.ParenthesizedLambdaExpressionServiceProvider.SignatureExactlyEqual(a, (ParenthesizedLambdaExpressionSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.ParenthesizedLambdaExpressionServiceProvider.SignatureExactlyEqual(null, (ParenthesizedLambdaExpressionSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.ParenthesizedLambdaExpressionServiceProvider.SignatureExactlyEqual(a, b));

            a = (ParenthesizedLambdaExpressionSyntax)SyntaxFactory.ParseExpression("(E e) => 4 }");
            b = (ParenthesizedLambdaExpressionSyntax)SyntaxFactory.ParseExpression("(E e) => 4 }");
            Assert.IsFalse(flad.LanguageServiceProvider.ParenthesizedLambdaExpressionServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.ParenthesizedLambdaExpressionServiceProvider.SignatureExactlyEqual(a, (ParenthesizedLambdaExpressionSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.ParenthesizedLambdaExpressionServiceProvider.SignatureExactlyEqual(null, (ParenthesizedLambdaExpressionSyntax)null));
            Assert.IsTrue(flad.LanguageServiceProvider.ParenthesizedLambdaExpressionServiceProvider.SignatureExactlyEqual(a, b));

            a = (ParenthesizedLambdaExpressionSyntax)SyntaxFactory.ParseExpression("(E e, G g) => 4 }");
            b = (ParenthesizedLambdaExpressionSyntax)SyntaxFactory.ParseExpression("(E e) => 4 }");
            Assert.IsFalse(flad.LanguageServiceProvider.ParenthesizedLambdaExpressionServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.ParenthesizedLambdaExpressionServiceProvider.SignatureExactlyEqual(a, (ParenthesizedLambdaExpressionSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.ParenthesizedLambdaExpressionServiceProvider.SignatureExactlyEqual(null, (ParenthesizedLambdaExpressionSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.ParenthesizedLambdaExpressionServiceProvider.SignatureExactlyEqual(a, b));

            a = (ParenthesizedLambdaExpressionSyntax)SyntaxFactory.ParseExpression("(E e, G g) => 4 }");
            b = (ParenthesizedLambdaExpressionSyntax)SyntaxFactory.ParseExpression("(E e, G g) => 4 }");
            Assert.IsFalse(flad.LanguageServiceProvider.ParenthesizedLambdaExpressionServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.ParenthesizedLambdaExpressionServiceProvider.SignatureExactlyEqual(a, (ParenthesizedLambdaExpressionSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.ParenthesizedLambdaExpressionServiceProvider.SignatureExactlyEqual(null, (ParenthesizedLambdaExpressionSyntax)null));
            Assert.IsTrue(flad.LanguageServiceProvider.ParenthesizedLambdaExpressionServiceProvider.SignatureExactlyEqual(a, b));

            a = (ParenthesizedLambdaExpressionSyntax)SyntaxFactory.ParseExpression("(E e, G g) => 4 }");
            b = (ParenthesizedLambdaExpressionSyntax)SyntaxFactory.ParseExpression("(G g, E e) => 4 }");
            Assert.IsFalse(flad.LanguageServiceProvider.ParenthesizedLambdaExpressionServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.ParenthesizedLambdaExpressionServiceProvider.SignatureExactlyEqual(a, (ParenthesizedLambdaExpressionSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.ParenthesizedLambdaExpressionServiceProvider.SignatureExactlyEqual(null, (ParenthesizedLambdaExpressionSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.ParenthesizedLambdaExpressionServiceProvider.SignatureExactlyEqual(a, b));
        }

        [TestMethod]
        public void LocalFunctionStatementServiceProvider_SignatureExactlyEqual_OK()
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
            Assert.IsFalse(flad.LanguageServiceProvider.LocalFunctionStatementServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.LocalFunctionStatementServiceProvider.SignatureExactlyEqual(a, (LocalFunctionStatementSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.LocalFunctionStatementServiceProvider.SignatureExactlyEqual(null, (LocalFunctionStatementSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.LocalFunctionStatementServiceProvider.SignatureExactlyEqual(a, b));

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
            Assert.IsFalse(flad.LanguageServiceProvider.LocalFunctionStatementServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.LocalFunctionStatementServiceProvider.SignatureExactlyEqual(a, (LocalFunctionStatementSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.LocalFunctionStatementServiceProvider.SignatureExactlyEqual(null, (LocalFunctionStatementSyntax)null));
            Assert.IsTrue(flad.LanguageServiceProvider.LocalFunctionStatementServiceProvider.SignatureExactlyEqual(a, b));

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
            Assert.IsFalse(flad.LanguageServiceProvider.LocalFunctionStatementServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.LocalFunctionStatementServiceProvider.SignatureExactlyEqual(a, (LocalFunctionStatementSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.LocalFunctionStatementServiceProvider.SignatureExactlyEqual(null, (LocalFunctionStatementSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.LocalFunctionStatementServiceProvider.SignatureExactlyEqual(a, b));

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
            Assert.IsFalse(flad.LanguageServiceProvider.LocalFunctionStatementServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.LocalFunctionStatementServiceProvider.SignatureExactlyEqual(a, (LocalFunctionStatementSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.LocalFunctionStatementServiceProvider.SignatureExactlyEqual(null, (LocalFunctionStatementSyntax)null));
            Assert.IsTrue(flad.LanguageServiceProvider.LocalFunctionStatementServiceProvider.SignatureExactlyEqual(a, b));

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
            Assert.IsFalse(flad.LanguageServiceProvider.LocalFunctionStatementServiceProvider.SignatureExactlyEqual(null, b));
            Assert.IsFalse(flad.LanguageServiceProvider.LocalFunctionStatementServiceProvider.SignatureExactlyEqual(a, (LocalFunctionStatementSyntax)null));
            Assert.IsFalse(flad.LanguageServiceProvider.LocalFunctionStatementServiceProvider.SignatureExactlyEqual(null, (LocalFunctionStatementSyntax)null));
            Assert.IsTrue(flad.LanguageServiceProvider.LocalFunctionStatementServiceProvider.SignatureExactlyEqual(a, b));
        }
    }
}
