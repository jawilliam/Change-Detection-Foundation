using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Jawilliam.CDF.Approach.Matching.CSharp;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jawilliam.CDF.Tests.Approach.Matching.CSharp
{
    /// <summary>
    /// Summary description for MatchingProvider
    /// </summary>
    [TestClass]
    public class MatchingProvider
    {
        public MatchingProvider()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void MatchMethodDeclarations()
        {
            var matcher = new Jawilliam.CDF.Approach.Matching.CSharp.MatchingProvider();

            var original = SyntaxFactory.ParseCompilationUnit("namespace B { class A { string C.M<T>(int a){ return \"\"; };").DescendantNodes().OfType<MethodDeclarationSyntax>().Single();
            var modified = SyntaxFactory.ParseCompilationUnit("namespace B { class A { string C.M<T>(int a){ return \"\"; };").DescendantNodes().OfType<MethodDeclarationSyntax>().Single();
            var result = matcher.Match(original, modified, MethodDeclarationMatchingOptions.GlobalKey);
            Assert.IsTrue(result.HasFlag(MethodDeclarationMatchingOptions.Path));
            Assert.IsTrue(result.HasFlag(MethodDeclarationMatchingOptions.DeclaringTypeName));
            Assert.IsTrue(result.HasFlag(MethodDeclarationMatchingOptions.ExplicitInterfaceSpecifier));
            Assert.IsTrue(result.HasFlag(MethodDeclarationMatchingOptions.TypeParameters));
            Assert.IsTrue(result.HasFlag(MethodDeclarationMatchingOptions.Name));
            Assert.IsTrue(result.HasFlag(MethodDeclarationMatchingOptions.Parameters));
            Assert.IsTrue(result.HasFlag(MethodDeclarationMatchingOptions.GlobalKey));
            Assert.IsTrue(result.HasFlag(MethodDeclarationMatchingOptions.RelativeKey));
            Assert.IsTrue(result.HasFlag(MethodDeclarationMatchingOptions.LocalKey));

            original = SyntaxFactory.ParseCompilationUnit("namespace B1 { class A { string C.M<T>(int a){ return \"\"; };").DescendantNodes().OfType<MethodDeclarationSyntax>().Single();
            modified = SyntaxFactory.ParseCompilationUnit("namespace B { class A { string C.M<T>(int a){ return \"\"; };").DescendantNodes().OfType<MethodDeclarationSyntax>().Single();
            result = matcher.Match(original, modified, MethodDeclarationMatchingOptions.GlobalKey);
            Assert.IsFalse(result.HasFlag(MethodDeclarationMatchingOptions.Path));
            Assert.IsTrue(result.HasFlag(MethodDeclarationMatchingOptions.DeclaringTypeName));
            Assert.IsTrue(result.HasFlag(MethodDeclarationMatchingOptions.ExplicitInterfaceSpecifier));
            Assert.IsTrue(result.HasFlag(MethodDeclarationMatchingOptions.TypeParameters));
            Assert.IsTrue(result.HasFlag(MethodDeclarationMatchingOptions.Name));
            Assert.IsTrue(result.HasFlag(MethodDeclarationMatchingOptions.Parameters));
            Assert.IsFalse(result.HasFlag(MethodDeclarationMatchingOptions.GlobalKey));
            Assert.IsTrue(result.HasFlag(MethodDeclarationMatchingOptions.RelativeKey));
            Assert.IsTrue(result.HasFlag(MethodDeclarationMatchingOptions.LocalKey));

            original = SyntaxFactory.ParseCompilationUnit("namespace B { class A1 { string C.M<T>(int a){ return \"\"; };").DescendantNodes().OfType<MethodDeclarationSyntax>().Single();
            modified = SyntaxFactory.ParseCompilationUnit("namespace B { class A { string C.M<T>(int a){ return \"\"; };").DescendantNodes().OfType<MethodDeclarationSyntax>().Single();
            result = matcher.Match(original, modified, MethodDeclarationMatchingOptions.GlobalKey);
            Assert.IsFalse(result.HasFlag(MethodDeclarationMatchingOptions.Path));
            Assert.IsFalse(result.HasFlag(MethodDeclarationMatchingOptions.DeclaringTypeName));
            Assert.IsTrue(result.HasFlag(MethodDeclarationMatchingOptions.ExplicitInterfaceSpecifier));
            Assert.IsTrue(result.HasFlag(MethodDeclarationMatchingOptions.TypeParameters));
            Assert.IsTrue(result.HasFlag(MethodDeclarationMatchingOptions.Name));
            Assert.IsTrue(result.HasFlag(MethodDeclarationMatchingOptions.Parameters));
            Assert.IsFalse(result.HasFlag(MethodDeclarationMatchingOptions.GlobalKey));
            Assert.IsFalse(result.HasFlag(MethodDeclarationMatchingOptions.RelativeKey));
            Assert.IsTrue(result.HasFlag(MethodDeclarationMatchingOptions.LocalKey));

            original = SyntaxFactory.ParseCompilationUnit("namespace B { class A { string C1.M<T>(int a){ return \"\"; };").DescendantNodes().OfType<MethodDeclarationSyntax>().Single();
            modified = SyntaxFactory.ParseCompilationUnit("namespace B { class A { string C.M<T>(int a){ return \"\"; };").DescendantNodes().OfType<MethodDeclarationSyntax>().Single();
            result = matcher.Match(original, modified, MethodDeclarationMatchingOptions.GlobalKey);
            Assert.IsTrue(result.HasFlag(MethodDeclarationMatchingOptions.Path));
            Assert.IsTrue(result.HasFlag(MethodDeclarationMatchingOptions.DeclaringTypeName));
            Assert.IsFalse(result.HasFlag(MethodDeclarationMatchingOptions.ExplicitInterfaceSpecifier));
            Assert.IsTrue(result.HasFlag(MethodDeclarationMatchingOptions.TypeParameters));
            Assert.IsTrue(result.HasFlag(MethodDeclarationMatchingOptions.Name));
            Assert.IsTrue(result.HasFlag(MethodDeclarationMatchingOptions.Parameters));
            Assert.IsFalse(result.HasFlag(MethodDeclarationMatchingOptions.GlobalKey));
            Assert.IsFalse(result.HasFlag(MethodDeclarationMatchingOptions.RelativeKey));
            Assert.IsFalse(result.HasFlag(MethodDeclarationMatchingOptions.LocalKey));

            original = SyntaxFactory.ParseCompilationUnit("namespace B { class A { string C.M<T1>(int a){ return \"\"; };").DescendantNodes().OfType<MethodDeclarationSyntax>().Single();
            modified = SyntaxFactory.ParseCompilationUnit("namespace B { class A { string C.M<T>(int a){ return \"\"; };").DescendantNodes().OfType<MethodDeclarationSyntax>().Single();
            result = matcher.Match(original, modified, MethodDeclarationMatchingOptions.GlobalKey);
            Assert.IsTrue(result.HasFlag(MethodDeclarationMatchingOptions.Path));
            Assert.IsTrue(result.HasFlag(MethodDeclarationMatchingOptions.DeclaringTypeName));
            Assert.IsTrue(result.HasFlag(MethodDeclarationMatchingOptions.ExplicitInterfaceSpecifier));
            Assert.IsFalse(result.HasFlag(MethodDeclarationMatchingOptions.TypeParameters));
            Assert.IsTrue(result.HasFlag(MethodDeclarationMatchingOptions.Name));
            Assert.IsTrue(result.HasFlag(MethodDeclarationMatchingOptions.Parameters));
            Assert.IsFalse(result.HasFlag(MethodDeclarationMatchingOptions.GlobalKey));
            Assert.IsFalse(result.HasFlag(MethodDeclarationMatchingOptions.RelativeKey));
            Assert.IsFalse(result.HasFlag(MethodDeclarationMatchingOptions.LocalKey));

            original = SyntaxFactory.ParseCompilationUnit("namespace B { class A { string C.M<T>(int a){ return \"\"; };").DescendantNodes().OfType<MethodDeclarationSyntax>().Single();
            modified = SyntaxFactory.ParseCompilationUnit("namespace B { class A { string C.M1<T>(int a){ return \"\"; };").DescendantNodes().OfType<MethodDeclarationSyntax>().Single();
            result = matcher.Match(original, modified, MethodDeclarationMatchingOptions.GlobalKey);
            Assert.IsTrue(result.HasFlag(MethodDeclarationMatchingOptions.Path));
            Assert.IsTrue(result.HasFlag(MethodDeclarationMatchingOptions.DeclaringTypeName));
            Assert.IsTrue(result.HasFlag(MethodDeclarationMatchingOptions.ExplicitInterfaceSpecifier));
            Assert.IsTrue(result.HasFlag(MethodDeclarationMatchingOptions.TypeParameters));
            Assert.IsFalse(result.HasFlag(MethodDeclarationMatchingOptions.Name));
            Assert.IsTrue(result.HasFlag(MethodDeclarationMatchingOptions.Parameters));
            Assert.IsFalse(result.HasFlag(MethodDeclarationMatchingOptions.GlobalKey));
            Assert.IsFalse(result.HasFlag(MethodDeclarationMatchingOptions.RelativeKey));
            Assert.IsFalse(result.HasFlag(MethodDeclarationMatchingOptions.LocalKey));

            original = SyntaxFactory.ParseCompilationUnit("namespace B { class A { string C.M<T>(int a){ return \"\"; };").DescendantNodes().OfType<MethodDeclarationSyntax>().Single();
            modified = SyntaxFactory.ParseCompilationUnit("namespace B { class A { string C.M<T>(int a1){ return \"\"; };").DescendantNodes().OfType<MethodDeclarationSyntax>().Single();
            result = matcher.Match(original, modified, MethodDeclarationMatchingOptions.GlobalKey);
            Assert.IsTrue(result.HasFlag(MethodDeclarationMatchingOptions.Path));
            Assert.IsTrue(result.HasFlag(MethodDeclarationMatchingOptions.DeclaringTypeName));
            Assert.IsTrue(result.HasFlag(MethodDeclarationMatchingOptions.ExplicitInterfaceSpecifier));
            Assert.IsTrue(result.HasFlag(MethodDeclarationMatchingOptions.TypeParameters));
            Assert.IsTrue(result.HasFlag(MethodDeclarationMatchingOptions.Name));
            Assert.IsFalse(result.HasFlag(MethodDeclarationMatchingOptions.Parameters));
            Assert.IsFalse(result.HasFlag(MethodDeclarationMatchingOptions.GlobalKey));
            Assert.IsFalse(result.HasFlag(MethodDeclarationMatchingOptions.RelativeKey));
            Assert.IsFalse(result.HasFlag(MethodDeclarationMatchingOptions.LocalKey));

            original = SyntaxFactory.ParseCompilationUnit("namespace B { class A { string C.M<T1>(int a){ return \"\"; };").DescendantNodes().OfType<MethodDeclarationSyntax>().Single();
            modified = SyntaxFactory.ParseCompilationUnit("namespace B { class A { string C2.M<T>(int a){ return \"\"; };").DescendantNodes().OfType<MethodDeclarationSyntax>().Single();
            result = matcher.Match(original, modified, MethodDeclarationMatchingOptions.GlobalKey);
            Assert.IsTrue(result.HasFlag(MethodDeclarationMatchingOptions.Path));
            Assert.IsTrue(result.HasFlag(MethodDeclarationMatchingOptions.DeclaringTypeName));
            Assert.IsFalse(result.HasFlag(MethodDeclarationMatchingOptions.ExplicitInterfaceSpecifier));
            Assert.IsFalse(result.HasFlag(MethodDeclarationMatchingOptions.TypeParameters));
            Assert.IsTrue(result.HasFlag(MethodDeclarationMatchingOptions.Name));
            Assert.IsTrue(result.HasFlag(MethodDeclarationMatchingOptions.Parameters));
            Assert.IsFalse(result.HasFlag(MethodDeclarationMatchingOptions.GlobalKey));
            Assert.IsFalse(result.HasFlag(MethodDeclarationMatchingOptions.RelativeKey));
            Assert.IsFalse(result.HasFlag(MethodDeclarationMatchingOptions.LocalKey));

            original = SyntaxFactory.ParseCompilationUnit("namespace Ba { class Aa { string Ca.M<T1>(int aa){ return \"\"; };").DescendantNodes().OfType<MethodDeclarationSyntax>().Single();
            modified = SyntaxFactory.ParseCompilationUnit("namespace B { class A { string C2.M<T>(int a){ return \"\"; };").DescendantNodes().OfType<MethodDeclarationSyntax>().Single();
            result = matcher.Match(original, modified, MethodDeclarationMatchingOptions.GlobalKey);
            Assert.IsFalse(result.HasFlag(MethodDeclarationMatchingOptions.Path));
            Assert.IsFalse(result.HasFlag(MethodDeclarationMatchingOptions.DeclaringTypeName));
            Assert.IsFalse(result.HasFlag(MethodDeclarationMatchingOptions.ExplicitInterfaceSpecifier));
            Assert.IsFalse(result.HasFlag(MethodDeclarationMatchingOptions.TypeParameters));
            Assert.IsTrue(result.HasFlag(MethodDeclarationMatchingOptions.Name));
            Assert.IsFalse(result.HasFlag(MethodDeclarationMatchingOptions.Parameters));
            Assert.IsFalse(result.HasFlag(MethodDeclarationMatchingOptions.GlobalKey));
            Assert.IsFalse(result.HasFlag(MethodDeclarationMatchingOptions.RelativeKey));
            Assert.IsFalse(result.HasFlag(MethodDeclarationMatchingOptions.LocalKey));
        }
    }
}
