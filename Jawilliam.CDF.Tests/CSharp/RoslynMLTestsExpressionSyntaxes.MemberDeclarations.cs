using System.Linq;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Linq;

namespace Jawilliam.CDF.Tests.CSharp
{
    partial class RoslynMLTests
    {
        [TestMethod]
        public void MemberDeclaration_NamespaceDeclarationSyntax_Mutable_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var node = SyntaxFactory.ParseCompilationUnit("namespace a{extern alias b; using static d; namespace c{};};").Members[0];
            var xElement = converter.Visit(node);
            Assert.AreEqual("", xElement.ToString(SaveOptions.DisableFormatting));
        }

        [TestMethod]
        public void TypeParameterSyntax_Mutable_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();

            var node = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<B, in C, out D, [Serializable]E, [Serializable] in F> {B a1; internal static A b2 = 3; [Serializable]A c3 = 3; [Serializable]public int df = 34;}").Members[0];
            var xElement = converter.Visit(node.TypeParameterList.Parameters[0]);
            Assert.AreEqual("", xElement.ToString(SaveOptions.DisableFormatting));

            xElement = converter.Visit(node.TypeParameterList.Parameters[1]);
            Assert.AreEqual("", xElement.ToString(SaveOptions.DisableFormatting));

            xElement = converter.Visit(node.TypeParameterList.Parameters[2]);
            Assert.AreEqual("", xElement.ToString(SaveOptions.DisableFormatting));

            xElement = converter.Visit(node.TypeParameterList.Parameters[3]);
            Assert.AreEqual("", xElement.ToString(SaveOptions.DisableFormatting));

            xElement = converter.Visit(node.TypeParameterList.Parameters[4]);
            Assert.AreEqual("", xElement.ToString(SaveOptions.DisableFormatting));
        }

        [TestMethod]
        public void TypeParameterListSyntax_Mutable_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();

            var node = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<B, in C, out D, [Serializable]E, [Serializable] in F> {B a1; internal static A b2 = 3; [Serializable]A c3 = 3; [Serializable]public int df = 34;}").Members[0];
            var xElement = converter.Visit(node.TypeParameterList);
            Assert.AreEqual("", xElement.ToString(SaveOptions.DisableFormatting));
        }

        [TestMethod]
        public void MemberDeclaration_ClassDeclarationSyntax_Mutable_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();

            var node = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public class a<T> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            var xElement = converter.Visit(node);
            Assert.AreEqual("", xElement.ToString(SaveOptions.DisableFormatting));

            node = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public class a : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            xElement = converter.Visit(node);
            Assert.AreEqual("", xElement.ToString(SaveOptions.DisableFormatting));
        }

        [TestMethod]
        public void MemberDeclaration_StructDeclarationSyntax_Mutable_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();

            var node = (StructDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public struct a<T> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            var xElement = converter.Visit(node);
            Assert.AreEqual("", xElement.ToString(SaveOptions.DisableFormatting));

            node = (StructDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public struct a : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            xElement = converter.Visit(node);
            Assert.AreEqual("", xElement.ToString(SaveOptions.DisableFormatting));
        }

        [TestMethod]
        public void MemberDeclaration_InterfaceDeclarationSyntax_Mutable_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();

            var node = (InterfaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public interface a<T> : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            var xElement = converter.Visit(node);
            Assert.AreEqual("", xElement.ToString(SaveOptions.DisableFormatting));

            node = (InterfaceDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public interface a : byte where T : int  {X a1; Y a2 = 3; Z bf = 34};").Members[0];
            xElement = converter.Visit(node);
            Assert.AreEqual("", xElement.ToString(SaveOptions.DisableFormatting));
        }

        [TestMethod]
        public void BaseListSyntax_Mutable_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var node = (EnumDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public enum a : byte {a1, a2 = 3, bf = 34};").Members[0];
            var xElement = converter.Visit(node);
            Assert.AreEqual("", xElement.ToString(SaveOptions.DisableFormatting));
        }

        [TestMethod]
        public void SimpleBaseTypeSyntax_Mutable_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var node = (EnumDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public enum a : byte {a1, a2 = 3, bf = 34};").Members[0];
            var xElement = converter.Visit(node.BaseList.Types[0]);
            Assert.AreEqual("", xElement.ToString(SaveOptions.DisableFormatting));
        }

        [TestMethod]
        public void MemberDeclaration_EnumMemberDeclarationSyntax_Mutable_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var node = (EnumDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("enum a {a1, a2 = 3, [Serializable]bf = 34};").Members[0];

            var xElement = converter.Visit(node.Members[0]);
            Assert.AreEqual("", xElement.ToString(SaveOptions.DisableFormatting));

            xElement = converter.Visit(node.Members[1]);
            Assert.AreEqual("", xElement.ToString(SaveOptions.DisableFormatting));

            xElement = converter.Visit(node.Members[2]);
            Assert.AreEqual("", xElement.ToString(SaveOptions.DisableFormatting));
        }

        [TestMethod]
        public void MemberDeclaration_EnumDeclarationSyntax_Mutable_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var node = (EnumDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public enum a : byte {a1, a2 = 3, bf = 34};").Members[0];
            var xElement = converter.Visit(node);
            Assert.AreEqual("", xElement.ToString(SaveOptions.DisableFormatting));
        }

        [TestMethod]
        public void TypeParameterConstraintClauseSyntax_Mutable_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();

            var node = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<T> : byte where T : new(), class, A{};").Members[0];
            var xElement = converter.Visit(node.ConstraintClauses[0]);
            Assert.AreEqual("", xElement.ToString(SaveOptions.DisableFormatting));
        }

        [TestMethod]
        public void TypeParameterConstraint_ConstructorConstraintSyntax_Mutable_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();

            var node = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<T> : byte where T : new(), class, A{};").Members[0];
            var xElement = converter.Visit(node.ConstraintClauses[0].Constraints[0]);
            Assert.AreEqual("", xElement.ToString(SaveOptions.DisableFormatting));
        }

        [TestMethod]
        public void TypeParameterConstraint_ClassOrStructConstraintSyntax_Mutable_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();

            var node = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<T> : byte where T : new(), class, struct, A{};").Members[0];
            var xElement = converter.Visit(node.ConstraintClauses[0].Constraints[1]);
            Assert.AreEqual("", xElement.ToString(SaveOptions.DisableFormatting));

            xElement = converter.Visit(node.ConstraintClauses[0].Constraints[2]);
            Assert.AreEqual("", xElement.ToString(SaveOptions.DisableFormatting));
        }

        [TestMethod]
        public void TypeParameterConstraint_TypeConstraintSyntax_Mutable_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();

            var node = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a<T> : byte where T : A{};").Members[0];
            var xElement = converter.Visit(node.ConstraintClauses[0].Constraints[0]);
            Assert.AreEqual("", xElement.ToString(SaveOptions.DisableFormatting));
        }

        [TestMethod]
        public void MemberDeclaration_FieldDeclarationSyntax_Mutable_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var node = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a {B a1; internal static A b2 = 3; [Serializable]A c3 = 3; [Serializable]public int df = 34;}").Members[0];

            var xElement = converter.Visit(node.Members[0]);
            Assert.AreEqual("", xElement.ToString(SaveOptions.DisableFormatting));

            xElement = converter.Visit(node.Members[1]);
            Assert.AreEqual("", xElement.ToString(SaveOptions.DisableFormatting));

            xElement = converter.Visit(node.Members[2]);
            Assert.AreEqual("", xElement.ToString(SaveOptions.DisableFormatting));

            xElement = converter.Visit(node.Members[3]);
            Assert.AreEqual("", xElement.ToString(SaveOptions.DisableFormatting));
        }

        [TestMethod]
        public void MemberDeclaration_EventFieldDeclarationSyntax_Mutable_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var node = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a {event B a1; internal static event A b2 = 3; [Serializable]event A c3 = 3; [Serializable]public event int df = 34;}").Members[0];

            var xElement = converter.Visit(node.Members[0]);
            Assert.AreEqual("", xElement.ToString(SaveOptions.DisableFormatting));

            xElement = converter.Visit(node.Members[1]);
            Assert.AreEqual("", xElement.ToString(SaveOptions.DisableFormatting));

            xElement = converter.Visit(node.Members[2]);
            Assert.AreEqual("", xElement.ToString(SaveOptions.DisableFormatting));

            xElement = converter.Visit(node.Members[3]);
            Assert.AreEqual("", xElement.ToString(SaveOptions.DisableFormatting));
        }

        [TestMethod]
        public void ExplicitInterfaceSpecifierSyntax_Mutable_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var node = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("class a {event B IA.a1{add; remove;}}").Members[0];

            var xElement = converter.Visit(((EventDeclarationSyntax)node.Members[0]).ExplicitInterfaceSpecifier);
            Assert.AreEqual("", xElement.ToString(SaveOptions.DisableFormatting));
        }

        [TestMethod]
        public void MemberDeclaration_MethodDeclarationSyntax_Mutable_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();

            var node = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M<T>(int a, A b)where T: class { return 5; };").Members[0];
            var xElement = converter.Visit(node);
            Assert.AreEqual("", xElement.ToString(SaveOptions.DisableFormatting));

            node = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public virtual string C.M<T>(int a, A b)where T: class { return 5; };").Members[0];
            xElement = converter.Visit(node);
            Assert.AreEqual("", xElement.ToString(SaveOptions.DisableFormatting));

            node = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string M<T>(int a, A b)where T: class { return 5; };").Members[0];
            xElement = converter.Visit(node);
            Assert.AreEqual("", xElement.ToString(SaveOptions.DisableFormatting));

            node = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M<T>(int a, A b) { return 5; };").Members[0];
            xElement = converter.Visit(node);
            Assert.AreEqual("", xElement.ToString(SaveOptions.DisableFormatting));

            node = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M<T>(int a, A b)where T: class => 5").Members[0];
            xElement = converter.Visit(node);
            Assert.AreEqual("", xElement.ToString(SaveOptions.DisableFormatting));

            node = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable]string M(){}").Members[0];
            xElement = converter.Visit(node);
            Assert.AreEqual("", xElement.ToString(SaveOptions.DisableFormatting));

            node = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("private string M(){}").Members[0];
            xElement = converter.Visit(node);
            Assert.AreEqual("", xElement.ToString(SaveOptions.DisableFormatting));

            node = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("float M(){}").Members[0];
            xElement = converter.Visit(node);
            Assert.AreEqual("", xElement.ToString(SaveOptions.DisableFormatting));
        }

        [TestMethod]
        public void MemberDeclaration_OperatorDeclarationSyntax_Mutable_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();

            var node = (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string operator +(int a, A b) { return 5; };").Members[0];
            var mutableNode = (OperatorDeclarationSyntax<object>)converter.Visit(node);
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.OperatorDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serializable]public virtual string operator +(int a,A b){return 5;};");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 3);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.OperatorKeyword);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.OperatorToken);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[2], mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 8);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.ReturnType);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.OperatorKeyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.OperatorToken);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.ParameterList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[6], mutableNode.Body);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[7], mutableNode.SemicolonToken);
            mutableNode = (OperatorDeclarationSyntax<object>)mutableNode.Clone();
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.OperatorDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serializable]public virtual string operator +(int a,A b){return 5;};");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 3);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.OperatorKeyword);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.OperatorToken);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[2], mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 8);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.ReturnType);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.OperatorKeyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.OperatorToken);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.ParameterList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[6], mutableNode.Body);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[7], mutableNode.SemicolonToken);

            node = (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public virtual string operator +(int a, A b) { return 5; };").Members[0];
            mutableNode = (OperatorDeclarationSyntax<object>)converter.Visit(node);
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.OperatorDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "public virtual string operator +(int a,A b){return 5;};");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 3);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.OperatorKeyword);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.OperatorToken);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[2], mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 8);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.ReturnType);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.OperatorKeyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.OperatorToken);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.ParameterList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[6], mutableNode.Body);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[7], mutableNode.SemicolonToken);
            mutableNode = (OperatorDeclarationSyntax<object>)mutableNode.Clone();
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.OperatorDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "public virtual string operator +(int a,A b){return 5;};");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 3);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.OperatorKeyword);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.OperatorToken);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[2], mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 8);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.ReturnType);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.OperatorKeyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.OperatorToken);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.ParameterList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[6], mutableNode.Body);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[7], mutableNode.SemicolonToken);

            node = (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] string operator +(int a, A b) { return 5; };").Members[0];
            mutableNode = (OperatorDeclarationSyntax<object>)converter.Visit(node);
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.OperatorDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serializable]string operator +(int a,A b){return 5;};");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 3);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.OperatorKeyword);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.OperatorToken);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[2], mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 8);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.ReturnType);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.OperatorKeyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.OperatorToken);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.ParameterList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[6], mutableNode.Body);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[7], mutableNode.SemicolonToken);
            mutableNode = (OperatorDeclarationSyntax<object>)mutableNode.Clone();
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.OperatorDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serializable]string operator +(int a,A b){return 5;};");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 3);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.OperatorKeyword);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.OperatorToken);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[2], mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 8);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.ReturnType);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.OperatorKeyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.OperatorToken);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.ParameterList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[6], mutableNode.Body);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[7], mutableNode.SemicolonToken);

            node = (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string operator +() { return 5; };").Members[0];
            mutableNode = (OperatorDeclarationSyntax<object>)converter.Visit(node);
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.OperatorDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serializable]public virtual string operator +(){return 5;};");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 3);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.OperatorKeyword);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.OperatorToken);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[2], mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 8);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.ReturnType);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.OperatorKeyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.OperatorToken);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.ParameterList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[6], mutableNode.Body);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[7], mutableNode.SemicolonToken);
            mutableNode = (OperatorDeclarationSyntax<object>)mutableNode.Clone();
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.OperatorDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serializable]public virtual string operator +(){return 5;};");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 3);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.OperatorKeyword);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.OperatorToken);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[2], mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 8);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.ReturnType);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.OperatorKeyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.OperatorToken);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.ParameterList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[6], mutableNode.Body);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[7], mutableNode.SemicolonToken);

            node = (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string operator +(int a, A b) {};").Members[0];
            mutableNode = (OperatorDeclarationSyntax<object>)converter.Visit(node);
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.OperatorDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serializable]public virtual string operator +(int a,A b){};");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 3);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.OperatorKeyword);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.OperatorToken);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[2], mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 8);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.ReturnType);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.OperatorKeyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.OperatorToken);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.ParameterList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[6], mutableNode.Body);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[7], mutableNode.SemicolonToken);
            mutableNode = (OperatorDeclarationSyntax<object>)mutableNode.Clone();
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.OperatorDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serializable]public virtual string operator +(int a,A b){};");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 3);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.OperatorKeyword);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.OperatorToken);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[2], mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 8);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.ReturnType);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.OperatorKeyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.OperatorToken);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.ParameterList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[6], mutableNode.Body);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[7], mutableNode.SemicolonToken);

            node = (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string operator +(int a, A b) => 5;").Members[0];
            mutableNode = (OperatorDeclarationSyntax<object>)converter.Visit(node);
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.OperatorDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serializable]public virtual string operator +(int a,A b)=>5;");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 3);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.OperatorKeyword);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.OperatorToken);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[2], mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 8);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.ReturnType);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.OperatorKeyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.OperatorToken);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.ParameterList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[6], mutableNode.ExpressionBody);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[7], mutableNode.SemicolonToken);
            mutableNode = (OperatorDeclarationSyntax<object>)mutableNode.Clone();
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.OperatorDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serializable]public virtual string operator +(int a,A b)=>5;");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 3);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.OperatorKeyword);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.OperatorToken);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[2], mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 8);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.ReturnType);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.OperatorKeyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.OperatorToken);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.ParameterList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[6], mutableNode.ExpressionBody);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[7], mutableNode.SemicolonToken);

            node = (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string operator +(int a, A b) { return 5; }").Members[0];
            mutableNode = (OperatorDeclarationSyntax<object>)converter.Visit(node);
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.OperatorDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serializable]public virtual string operator +(int a,A b){return 5;}");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 2);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.OperatorKeyword);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.OperatorToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 7);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.ReturnType);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.OperatorKeyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.OperatorToken);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.ParameterList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[6], mutableNode.Body);
            mutableNode = (OperatorDeclarationSyntax<object>)mutableNode.Clone();
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.OperatorDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serializable]public virtual string operator +(int a,A b){return 5;}");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 2);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.OperatorKeyword);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.OperatorToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 7);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.ReturnType);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.OperatorKeyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.OperatorToken);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.ParameterList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[6], mutableNode.Body);

            node = (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string operator +(int a, A b) => 5").Members[0];
            mutableNode = (OperatorDeclarationSyntax<object>)converter.Visit(node);
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.OperatorDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serializable]public virtual string operator +(int a,A b)=>5");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 3);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.OperatorKeyword);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.OperatorToken);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[2], mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 8);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.ReturnType);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.OperatorKeyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.OperatorToken);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.ParameterList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[6], mutableNode.ExpressionBody);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[7], mutableNode.SemicolonToken);
            mutableNode = (OperatorDeclarationSyntax<object>)mutableNode.Clone();
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.OperatorDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serializable]public virtual string operator +(int a,A b)=>5");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 3);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.OperatorKeyword);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.OperatorToken);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[2], mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 8);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.ReturnType);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.OperatorKeyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.OperatorToken);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.ParameterList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[6], mutableNode.ExpressionBody);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[7], mutableNode.SemicolonToken);

            var node2 = (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable]string operator +(int a,A b){}").Members[0];
            node = (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Documentation]string operator +(int a,A b){}").Members[0];
            var mutableNode2 = (OperatorDeclarationSyntax<object>)converter.Visit(node2);
            mutableNode.Update(converter.Visit(node));
            Assert.AreEqual(mutableNode.GetFullText(), "[Documentation]string operator +(int a,A b){}");
            mutableNode.Delete(mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullText(), "string operator +(int a,A b){}");
            mutableNode.Insert(mutableNode2.AttributeLists, 0, EntryExtensions.FullRepresentationFormatInfo);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serializable]string operator +(int a,A b){}");

            node2 = (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public string operator +(int a,A b){}").Members[0];
            node = (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("private string operator +(int a,A b){}").Members[0];
            mutableNode2 = (OperatorDeclarationSyntax<object>)converter.Visit(node2);
            mutableNode.Update(converter.Visit(node));
            Assert.AreEqual(mutableNode.GetFullText(), "private string operator +(int a,A b){}");
            mutableNode.Delete(mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullText(), "string operator +(int a,A b){}");
            mutableNode.Insert(mutableNode2.Modifiers, 1, EntryExtensions.FullRepresentationFormatInfo);
            Assert.AreEqual(mutableNode.GetFullText(), "public string operator +(int a,A b){}");

            node2 = (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int operator +(int a,A b){}").Members[0];
            node = (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("float operator +(int a,A b){}").Members[0];
            mutableNode2 = (OperatorDeclarationSyntax<object>)converter.Visit(node2);
            mutableNode.Update(converter.Visit(node));
            Assert.AreEqual(mutableNode.GetFullText(), "float operator +(int a,A b){}");
            mutableNode.Delete(mutableNode.ReturnType);
            Assert.AreEqual(mutableNode.GetFullText(), "operator +(int a,A b){}");
            mutableNode.Insert(mutableNode2.ReturnType, 2, EntryExtensions.FullRepresentationFormatInfo);
            Assert.AreEqual(mutableNode.GetFullText(), "int operator +(int a,A b){}");

            node2 = (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("string operator -(int a,A b){}").Members[0];
            node = (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("string operator +(int a,A b){}").Members[0];
            mutableNode2 = (OperatorDeclarationSyntax<object>)converter.Visit(node2);
            mutableNode.Update(converter.Visit(node));
            Assert.AreEqual(mutableNode.GetFullText(), "string operator +(int a,A b){}");
            mutableNode.Delete(mutableNode.OperatorToken);
            Assert.AreEqual(mutableNode.GetFullText(), "string operator (int a,A b){}");
            mutableNode.Insert(mutableNode2.OperatorToken, 3, EntryExtensions.FullRepresentationFormatInfo);
            Assert.AreEqual(mutableNode.GetFullText(), "string operator -(int a,A b){}");

            node2 = (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("string operator +(int a){}").Members[0];
            node = (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("string operator +(float b){}").Members[0];
            mutableNode2 = (OperatorDeclarationSyntax<object>)converter.Visit(node2);
            mutableNode.Update(converter.Visit(node));
            Assert.AreEqual(mutableNode.GetFullText(), "string operator +(float b){}");
            mutableNode.Delete(mutableNode.ParameterList);
            Assert.AreEqual(mutableNode.GetFullText(), "string operator +{}");
            mutableNode.Insert(mutableNode2.ParameterList, 4, EntryExtensions.FullRepresentationFormatInfo);
            Assert.AreEqual(mutableNode.GetFullText(), "string operator +(int a){}");

            node2 = (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("string operator +(int a,A b){ return 5;}").Members[0];
            node = (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("string operator +(int a,A b){ int a = 7; }").Members[0];
            mutableNode2 = (OperatorDeclarationSyntax<object>)converter.Visit(node2);
            mutableNode.Update(converter.Visit(node));
            Assert.AreEqual(mutableNode.GetFullText(), "string operator +(int a,A b){int a=7;}");
            mutableNode.Delete(mutableNode.Body);
            Assert.AreEqual(mutableNode.GetFullText(), "string operator +(int a,A b)");
            mutableNode.Insert(mutableNode2.Body, 5, EntryExtensions.FullRepresentationFormatInfo);
            Assert.AreEqual(mutableNode.GetFullText(), "string operator +(int a,A b){return 5;}");

            node2 = (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("string operator +(int a,A b) => 5").Members[0];
            node = (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("string operator +(int a,A b) => 7").Members[0];
            mutableNode2 = (OperatorDeclarationSyntax<object>)converter.Visit(node2);
            mutableNode.Update(converter.Visit(node));
            Assert.AreEqual(mutableNode.GetFullText(), "string operator +(int a,A b)=>7");
            mutableNode.Delete(mutableNode.ExpressionBody);
            Assert.AreEqual(mutableNode.GetFullText(), "string operator +(int a,A b)");
            mutableNode.Insert(mutableNode2.ExpressionBody, 6, EntryExtensions.FullRepresentationFormatInfo);
            Assert.AreEqual(mutableNode.GetFullText(), "string operator +(int a,A b)=>5");

            node2 = (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("string operator +(int a,A b){ return 5;}").Members[0];
            node = (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("string operator +(int a,A b) => 7").Members[0];
            mutableNode2 = (OperatorDeclarationSyntax<object>)converter.Visit(node2);
            mutableNode.Update(converter.Visit(node));
            Assert.AreEqual(mutableNode.GetFullText(), "string operator +(int a,A b)=>7");
            mutableNode.Delete(mutableNode.ExpressionBody);
            Assert.AreEqual(mutableNode.GetFullText(), "string operator +(int a,A b)");
            mutableNode.Insert(mutableNode2.Body, 5, EntryExtensions.FullRepresentationFormatInfo);
            Assert.AreEqual(mutableNode.GetFullText(), "string operator +(int a,A b){return 5;}");

            node2 = (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("string operator +(int a,A b) => 7").Members[0];
            node = (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("string operator +(int a,A b) { return 5;}").Members[0];
            mutableNode2 = (OperatorDeclarationSyntax<object>)converter.Visit(node2);
            mutableNode.Update(converter.Visit(node));
            Assert.AreEqual(mutableNode.GetFullText(), "string operator +(int a,A b){return 5;}");
            mutableNode.Delete(mutableNode.Body);
            Assert.AreEqual(mutableNode.GetFullText(), "string operator +(int a,A b)");
            mutableNode.Insert(mutableNode2.ExpressionBody, 6, EntryExtensions.FullRepresentationFormatInfo);
            Assert.AreEqual(mutableNode.GetFullText(), "string operator +(int a,A b)=>7");

            node2 = (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("string operator +(int a,A b){};").Members[0];
            node = (OperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("string operator +(int a,A b){};").Members[0];
            mutableNode2 = (OperatorDeclarationSyntax<object>)converter.Visit(node2);
            mutableNode.Update(converter.Visit(node));
            Assert.AreEqual(mutableNode.GetFullText(), "string operator +(int a,A b){};");
            mutableNode.Delete(mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullText(), "string operator +(int a,A b){}");
            mutableNode.Insert(mutableNode2.SemicolonToken, 7, EntryExtensions.FullRepresentationFormatInfo);
            Assert.AreEqual(mutableNode.GetFullText(), "string operator +(int a,A b){};");
        }

        [TestMethod]
        public void MemberDeclaration_ConversionOperatorDeclarationSyntax_Mutable_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();

            var node = (ConversionOperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public static implicit operator T(A b) { return 5; };").Members[0];
            var mutableNode = (ConversionOperatorDeclarationSyntax<object>)converter.Visit(node);
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.ConversionOperatorDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serializable]public static implicit operator T(A b){return 5;};");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 3);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.ImplicitOrExplicitKeyword);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.OperatorKeyword);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[2], mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 8);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.ImplicitOrExplicitKeyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.OperatorKeyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.Type);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.ParameterList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[6], mutableNode.Body);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[7], mutableNode.SemicolonToken);
            mutableNode = (ConversionOperatorDeclarationSyntax<object>)mutableNode.Clone();
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.ConversionOperatorDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serializable]public static implicit operator T(A b){return 5;};");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 3);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.ImplicitOrExplicitKeyword);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.OperatorKeyword);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[2], mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 8);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.ImplicitOrExplicitKeyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.OperatorKeyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.Type);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.ParameterList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[6], mutableNode.Body);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[7], mutableNode.SemicolonToken);

            node = (ConversionOperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public static implicit operator T(A b) { return 5; };").Members[0];
            mutableNode = (ConversionOperatorDeclarationSyntax<object>)converter.Visit(node);
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.ConversionOperatorDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "public static implicit operator T(A b){return 5;};");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 3);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.ImplicitOrExplicitKeyword);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.OperatorKeyword);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[2], mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 8);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.ImplicitOrExplicitKeyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.OperatorKeyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.Type);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.ParameterList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[6], mutableNode.Body);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[7], mutableNode.SemicolonToken);
            mutableNode = (ConversionOperatorDeclarationSyntax<object>)mutableNode.Clone();
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.ConversionOperatorDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "public static implicit operator T(A b){return 5;};");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 3);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.ImplicitOrExplicitKeyword);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.OperatorKeyword);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[2], mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 8);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.ImplicitOrExplicitKeyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.OperatorKeyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.Type);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.ParameterList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[6], mutableNode.Body);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[7], mutableNode.SemicolonToken);

            node = (ConversionOperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable]static implicit operator T(A b) { return 5; };").Members[0];
            mutableNode = (ConversionOperatorDeclarationSyntax<object>)converter.Visit(node);
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.ConversionOperatorDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serializable]static implicit operator T(A b){return 5;};");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 3);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.ImplicitOrExplicitKeyword);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.OperatorKeyword);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[2], mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 8);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.ImplicitOrExplicitKeyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.OperatorKeyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.Type);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.ParameterList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[6], mutableNode.Body);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[7], mutableNode.SemicolonToken);
            mutableNode = (ConversionOperatorDeclarationSyntax<object>)mutableNode.Clone();
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.ConversionOperatorDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serializable]static implicit operator T(A b){return 5;};");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 3);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.ImplicitOrExplicitKeyword);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.OperatorKeyword);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[2], mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 8);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.ImplicitOrExplicitKeyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.OperatorKeyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.Type);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.ParameterList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[6], mutableNode.Body);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[7], mutableNode.SemicolonToken);

            node = (ConversionOperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public static implicit operator T() { return 5; };").Members[0];
            mutableNode = (ConversionOperatorDeclarationSyntax<object>)converter.Visit(node);
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.ConversionOperatorDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serializable]public static implicit operator T(){return 5;};");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 3);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.ImplicitOrExplicitKeyword);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.OperatorKeyword);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[2], mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 8);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.ImplicitOrExplicitKeyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.OperatorKeyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.Type);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.ParameterList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[6], mutableNode.Body);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[7], mutableNode.SemicolonToken);
            mutableNode = (ConversionOperatorDeclarationSyntax<object>)mutableNode.Clone();
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.ConversionOperatorDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serializable]public static implicit operator T(){return 5;};");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 3);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.ImplicitOrExplicitKeyword);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.OperatorKeyword);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[2], mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 8);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.ImplicitOrExplicitKeyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.OperatorKeyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.Type);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.ParameterList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[6], mutableNode.Body);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[7], mutableNode.SemicolonToken);

            node = (ConversionOperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public static implicit operator T(A b) {};").Members[0];
            mutableNode = (ConversionOperatorDeclarationSyntax<object>)converter.Visit(node);
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.ConversionOperatorDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serializable]public static implicit operator T(A b){};");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 3);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.ImplicitOrExplicitKeyword);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.OperatorKeyword);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[2], mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 8);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.ImplicitOrExplicitKeyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.OperatorKeyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.Type);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.ParameterList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[6], mutableNode.Body);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[7], mutableNode.SemicolonToken);
            mutableNode = (ConversionOperatorDeclarationSyntax<object>)mutableNode.Clone();
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.ConversionOperatorDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serializable]public static implicit operator T(A b){};");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 3);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.ImplicitOrExplicitKeyword);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.OperatorKeyword);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[2], mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 8);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.ImplicitOrExplicitKeyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.OperatorKeyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.Type);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.ParameterList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[6], mutableNode.Body);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[7], mutableNode.SemicolonToken);

            node = (ConversionOperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public static implicit operator T(A b) => 5;").Members[0];
            mutableNode = (ConversionOperatorDeclarationSyntax<object>)converter.Visit(node);
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.ConversionOperatorDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serializable]public static implicit operator T(A b)=>5;");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 3);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.ImplicitOrExplicitKeyword);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.OperatorKeyword);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[2], mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 8);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.ImplicitOrExplicitKeyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.OperatorKeyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.Type);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.ParameterList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[6], mutableNode.ExpressionBody);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[7], mutableNode.SemicolonToken);
            mutableNode = (ConversionOperatorDeclarationSyntax<object>)mutableNode.Clone();
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.ConversionOperatorDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serializable]public static implicit operator T(A b)=>5;");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 3);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.ImplicitOrExplicitKeyword);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.OperatorKeyword);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[2], mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 8);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.ImplicitOrExplicitKeyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.OperatorKeyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.Type);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.ParameterList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[6], mutableNode.ExpressionBody);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[7], mutableNode.SemicolonToken);

            node = (ConversionOperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public static implicit operator T(A b) { return 5; }").Members[0];
            mutableNode = (ConversionOperatorDeclarationSyntax<object>)converter.Visit(node);
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.ConversionOperatorDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serializable]public static implicit operator T(A b){return 5;}");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 2);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.ImplicitOrExplicitKeyword);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.OperatorKeyword);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 7);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.ImplicitOrExplicitKeyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.OperatorKeyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.Type);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.ParameterList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[6], mutableNode.Body);
            mutableNode = (ConversionOperatorDeclarationSyntax<object>)mutableNode.Clone();
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.ConversionOperatorDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serializable]public static implicit operator T(A b){return 5;}");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 2);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.ImplicitOrExplicitKeyword);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.OperatorKeyword);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 7);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.ImplicitOrExplicitKeyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.OperatorKeyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.Type);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.ParameterList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[6], mutableNode.Body);

            node = (ConversionOperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public static implicit operator T(A b) => 5").Members[0];
            mutableNode = (ConversionOperatorDeclarationSyntax<object>)converter.Visit(node);
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.ConversionOperatorDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serializable]public static implicit operator T(A b)=>5");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 3);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.ImplicitOrExplicitKeyword);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.OperatorKeyword);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[2], mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 8);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.ImplicitOrExplicitKeyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.OperatorKeyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.Type);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.ParameterList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[6], mutableNode.ExpressionBody);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[7], mutableNode.SemicolonToken);
            mutableNode = (ConversionOperatorDeclarationSyntax<object>)mutableNode.Clone();
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.ConversionOperatorDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serializable]public static implicit operator T(A b)=>5");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 3);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.ImplicitOrExplicitKeyword);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.OperatorKeyword);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[2], mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 8);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.ImplicitOrExplicitKeyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.OperatorKeyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.Type);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.ParameterList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[6], mutableNode.ExpressionBody);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[7], mutableNode.SemicolonToken);
            
            var node2 = (ConversionOperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable]public static operator T(A b){}").Members[0];
            node = (ConversionOperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Documentation]public static operator T(A b){}").Members[0];
            var mutableNode2 = (ConversionOperatorDeclarationSyntax<object>)converter.Visit(node2);
            mutableNode.Update(converter.Visit(node));
            Assert.AreEqual(mutableNode.GetFullText(), "[Documentation]public static operator T(A b){}");
            mutableNode.Delete(mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullText(), "public static operator T(A b){}");
            mutableNode.Insert(mutableNode2.AttributeLists, 0, EntryExtensions.FullRepresentationFormatInfo);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serializable]public static operator T(A b){}");

            node2 = (ConversionOperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public static operator T(A b){}").Members[0];
            node = (ConversionOperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("private static operator T(A b){}").Members[0];
            mutableNode2 = (ConversionOperatorDeclarationSyntax<object>)converter.Visit(node2);
            mutableNode.Update(converter.Visit(node));
            Assert.AreEqual(mutableNode.GetFullText(), "private static operator T(A b){}");
            mutableNode.Delete(mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullText(), "operator T(A b){}");
            mutableNode.Insert(mutableNode2.Modifiers, 1, EntryExtensions.FullRepresentationFormatInfo);
            Assert.AreEqual(mutableNode.GetFullText(), "public static operator T(A b){}");

            node2 = (ConversionOperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public static implicit operator T(A b){}").Members[0];
            node = (ConversionOperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("private static explicit operator T(A b){}").Members[0];
            mutableNode2 = (ConversionOperatorDeclarationSyntax<object>)converter.Visit(node2);
            mutableNode.Update(converter.Visit(node));
            Assert.AreEqual(mutableNode.GetFullText(), "private static explicit operator T(A b){}");
            mutableNode.Delete(mutableNode.ImplicitOrExplicitKeyword);
            Assert.AreEqual(mutableNode.GetFullText(), "private static operator T(A b){}");
            mutableNode.Insert(mutableNode2.ImplicitOrExplicitKeyword, 2, EntryExtensions.FullRepresentationFormatInfo);
            Assert.AreEqual(mutableNode.GetFullText(), "private static implicit operator T(A b){}");

            node2 = (ConversionOperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("static operator K(A b){}").Members[0];
            node = (ConversionOperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("static operator T(A b){}").Members[0];
            mutableNode2 = (ConversionOperatorDeclarationSyntax<object>)converter.Visit(node2);
            mutableNode.Update(converter.Visit(node));
            Assert.AreEqual(mutableNode.GetFullText(), "static operator T(A b){}");
            mutableNode.Delete(mutableNode.Type);
            Assert.AreEqual(mutableNode.GetFullText(), "static operator(A b){}");
            mutableNode.Insert(mutableNode2.Type, 3, EntryExtensions.FullRepresentationFormatInfo);
            Assert.AreEqual(mutableNode.GetFullText(), "static operator K(A b){}");

            node2 = (ConversionOperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("static operator T(int a){}").Members[0];
            node = (ConversionOperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("static operator T(float b){}").Members[0];
            mutableNode2 = (ConversionOperatorDeclarationSyntax<object>)converter.Visit(node2);
            mutableNode.Update(converter.Visit(node));
            Assert.AreEqual(mutableNode.GetFullText(), "static operator T(float b){}");
            mutableNode.Delete(mutableNode.ParameterList);
            Assert.AreEqual(mutableNode.GetFullText(), "static operator T{}");
            mutableNode.Insert(mutableNode2.ParameterList, 4, EntryExtensions.FullRepresentationFormatInfo);
            Assert.AreEqual(mutableNode.GetFullText(), "static operator T(int a){}");

            node2 = (ConversionOperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("static operator T(A b){ return 5;}").Members[0];
            node = (ConversionOperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("static operator T(A b){ int a = 7; }").Members[0];
            mutableNode2 = (ConversionOperatorDeclarationSyntax<object>)converter.Visit(node2);
            mutableNode.Update(converter.Visit(node));
            Assert.AreEqual(mutableNode.GetFullText(), "static operator T(A b){int a=7;}");
            mutableNode.Delete(mutableNode.Body);
            Assert.AreEqual(mutableNode.GetFullText(), "static operator T(A b)");
            mutableNode.Insert(mutableNode2.Body, 5, EntryExtensions.FullRepresentationFormatInfo);
            Assert.AreEqual(mutableNode.GetFullText(), "static operator T(A b){return 5;}");

            node2 = (ConversionOperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("static operator T(A b) => 5").Members[0];
            node = (ConversionOperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("static operator T(A b) => 7").Members[0];
            mutableNode2 = (ConversionOperatorDeclarationSyntax<object>)converter.Visit(node2);
            mutableNode.Update(converter.Visit(node));
            Assert.AreEqual(mutableNode.GetFullText(), "static operator T(A b)=>7");
            mutableNode.Delete(mutableNode.ExpressionBody);
            Assert.AreEqual(mutableNode.GetFullText(), "static operator T(A b)");
            mutableNode.Insert(mutableNode2.ExpressionBody, 6, EntryExtensions.FullRepresentationFormatInfo);
            Assert.AreEqual(mutableNode.GetFullText(), "static operator T(A b)=>5");

            node2 = (ConversionOperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("static operator T(A b){ return 5;}").Members[0];
            node = (ConversionOperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("static operator T(A b) => 7").Members[0];
            mutableNode2 = (ConversionOperatorDeclarationSyntax<object>)converter.Visit(node2);
            mutableNode.Update(converter.Visit(node));
            Assert.AreEqual(mutableNode.GetFullText(), "static operator T(A b)=>7");
            mutableNode.Delete(mutableNode.ExpressionBody);
            Assert.AreEqual(mutableNode.GetFullText(), "static operator T(A b)");
            mutableNode.Insert(mutableNode2.Body, 5, EntryExtensions.FullRepresentationFormatInfo);
            Assert.AreEqual(mutableNode.GetFullText(), "static operator T(A b){return 5;}");

            node2 = (ConversionOperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("static operator T(A b) => 7").Members[0];
            node = (ConversionOperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("static operator T(A b) { return 5;}").Members[0];
            mutableNode2 = (ConversionOperatorDeclarationSyntax<object>)converter.Visit(node2);
            mutableNode.Update(converter.Visit(node));
            Assert.AreEqual(mutableNode.GetFullText(), "static operator T(A b){return 5;}");
            mutableNode.Delete(mutableNode.Body);
            Assert.AreEqual(mutableNode.GetFullText(), "static operator T(A b)");
            mutableNode.Insert(mutableNode2.ExpressionBody, 6, EntryExtensions.FullRepresentationFormatInfo);
            Assert.AreEqual(mutableNode.GetFullText(), "static operator T(A b)=>7");

            node2 = (ConversionOperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("static operator T(A b){};").Members[0];
            node = (ConversionOperatorDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("static operator T(A b){};").Members[0];
            mutableNode2 = (ConversionOperatorDeclarationSyntax<object>)converter.Visit(node2);
            mutableNode.Update(converter.Visit(node));
            Assert.AreEqual(mutableNode.GetFullText(), "static operator T(A b){};");
            mutableNode.Delete(mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullText(), "static operator T(A b){}");
            mutableNode.Insert(mutableNode2.SemicolonToken, 7, EntryExtensions.FullRepresentationFormatInfo);
            Assert.AreEqual(mutableNode.GetFullText(), "static operator T(A b){};");
        }

        [TestMethod]
        public void MemberDeclaration_ConstructorDeclarationSyntax_Mutable_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();

            var node = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation]public A(B b) : this(b) { }; }").Members[0];
            var mutableNode = (ConstructorDeclarationSyntax<object>)converter.Visit(node.Members[0]);
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.ConstructorDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Documentation]public A(B b):this(b){};");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 2);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 7);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.ParameterList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.Initializer);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.Body);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[6], mutableNode.SemicolonToken);
            mutableNode = (ConstructorDeclarationSyntax<object>)mutableNode.Clone();
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.ConstructorDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Documentation]public A(B b):this(b){};");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 2);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 7);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.ParameterList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.Initializer);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.Body);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[6], mutableNode.SemicolonToken);

            node = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { public A(B b) : this(b) { }; }").Members[0];
            mutableNode = (ConstructorDeclarationSyntax<object>)converter.Visit(node.Members[0]);
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.ConstructorDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "public A(B b):this(b){};");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 2);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 7);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.ParameterList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.Initializer);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.Body);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[6], mutableNode.SemicolonToken);
            mutableNode = (ConstructorDeclarationSyntax<object>)mutableNode.Clone();
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.ConstructorDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "public A(B b):this(b){};");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 2);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 7);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.ParameterList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.Initializer);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.Body);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[6], mutableNode.SemicolonToken);

            node = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation] A(B b) : this(b) { }; }").Members[0];
            mutableNode = (ConstructorDeclarationSyntax<object>)converter.Visit(node.Members[0]);
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.ConstructorDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Documentation]A(B b):this(b){};");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 2);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 7);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.ParameterList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.Initializer);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.Body);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[6], mutableNode.SemicolonToken);
            mutableNode = (ConstructorDeclarationSyntax<object>)mutableNode.Clone();
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.ConstructorDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Documentation]A(B b):this(b){};");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 2);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 7);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.ParameterList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.Initializer);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.Body);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[6], mutableNode.SemicolonToken);

            node = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation]public A(B b) { }; }").Members[0];
            mutableNode = (ConstructorDeclarationSyntax<object>)converter.Visit(node.Members[0]);
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.ConstructorDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Documentation]public A(B b){};");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 2);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 6);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.ParameterList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.Body);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.SemicolonToken);
            mutableNode = (ConstructorDeclarationSyntax<object>)mutableNode.Clone();
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.ConstructorDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Documentation]public A(B b){};");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 2);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 6);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.ParameterList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.Body);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.SemicolonToken);

            node = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation]public A(B b) : this(b); }").Members[0];
            mutableNode = (ConstructorDeclarationSyntax<object>)converter.Visit(node.Members[0]);
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.ConstructorDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Documentation]public A(B b):this(b);");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 2);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 6);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.ParameterList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.Initializer);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.SemicolonToken);
            mutableNode = (ConstructorDeclarationSyntax<object>)mutableNode.Clone();
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.ConstructorDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Documentation]public A(B b):this(b);");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 2);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 6);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.ParameterList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.Initializer);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.SemicolonToken);

            node = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation]public A(B b) : this(b) { } }").Members[0];
            mutableNode = (ConstructorDeclarationSyntax<object>)converter.Visit(node.Members[0]);
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.ConstructorDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Documentation]public A(B b):this(b){}");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 1);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 6);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.ParameterList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.Initializer);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.Body);
            mutableNode = (ConstructorDeclarationSyntax<object>)mutableNode.Clone();
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.ConstructorDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Documentation]public A(B b):this(b){}");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 1);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 6);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.ParameterList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.Initializer);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.Body);

            var node2 = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Serializable]A(B b) }").Members[0];
            node = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation]A(B b) }").Members[0];
            var mutableNode2 = (ConstructorDeclarationSyntax<object>)converter.Visit(node2.Members[0]);
            mutableNode.Update(converter.Visit(node.Members[0]));
            Assert.AreEqual(mutableNode.GetFullText(), "[Documentation]A(B b)");
            mutableNode.Delete(mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullText(), "A(B b)");
            mutableNode.Insert(mutableNode2.AttributeLists, 0, EntryExtensions.FullRepresentationFormatInfo);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serializable]A(B b)");

            node2 = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { private A(B b) }").Members[0];
            node = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { public A(B b) }").Members[0];
            mutableNode2 = (ConstructorDeclarationSyntax<object>)converter.Visit(node2.Members[0]);
            mutableNode.Update(converter.Visit(node.Members[0]));
            Assert.AreEqual(mutableNode.GetFullText(), "public A(B b)");
            mutableNode.Delete(mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullText(), "A(B b)");
            mutableNode.Insert(mutableNode2.Modifiers, 1, EntryExtensions.FullRepresentationFormatInfo);
            Assert.AreEqual(mutableNode.GetFullText(), "private A(B b)");

            node2 = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class B { B(B b) }").Members[0];
            node = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { A(B b) }").Members[0];
            mutableNode2 = (ConstructorDeclarationSyntax<object>)converter.Visit(node2.Members[0]);
            mutableNode.Update(converter.Visit(node.Members[0]));
            Assert.AreEqual(mutableNode.GetFullText(), "A(B b)");
            mutableNode.Delete(mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetFullText(), "(B b)");
            mutableNode.Insert(mutableNode2.Identifier, 2, EntryExtensions.FullRepresentationFormatInfo);
            Assert.AreEqual(mutableNode.GetFullText(), "B(B b)");

            node2 = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { A(C c) }").Members[0];
            node = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { A(B b) }").Members[0];
            mutableNode2 = (ConstructorDeclarationSyntax<object>)converter.Visit(node2.Members[0]);
            mutableNode.Update(converter.Visit(node.Members[0]));
            Assert.AreEqual(mutableNode.GetFullText(), "A(B b)");
            mutableNode.Delete(mutableNode.ParameterList);
            Assert.AreEqual(mutableNode.GetFullText(), "A");
            mutableNode.Insert(mutableNode2.ParameterList, 3, EntryExtensions.FullRepresentationFormatInfo);
            Assert.AreEqual(mutableNode.GetFullText(), "A(C c)");

            node2 = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { A(B b) : base() }").Members[0];
            node = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { A(B b) : this() }").Members[0];
            mutableNode2 = (ConstructorDeclarationSyntax<object>)converter.Visit(node2.Members[0]);
            mutableNode.Update(converter.Visit(node.Members[0]));
            Assert.AreEqual(mutableNode.GetFullText(), "A(B b):this()");
            mutableNode.Delete(mutableNode.Initializer);
            Assert.AreEqual(mutableNode.GetFullText(), "A(B b)");
            mutableNode.Insert(mutableNode2.Initializer, 4, EntryExtensions.FullRepresentationFormatInfo);
            Assert.AreEqual(mutableNode.GetFullText(), "A(B b):base()");

            node2 = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { A(B b){float y = 5;} }").Members[0];
            node = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { A(B b){int a = 6;} }").Members[0];
            mutableNode2 = (ConstructorDeclarationSyntax<object>)converter.Visit(node2.Members[0]);
            mutableNode.Update(converter.Visit(node.Members[0]));
            Assert.AreEqual(mutableNode.GetFullText(), "A(B b){int a=6;}");
            mutableNode.Delete(mutableNode.Body);
            Assert.AreEqual(mutableNode.GetFullText(), "A(B b)");
            mutableNode.Insert(mutableNode2.Body, 5, EntryExtensions.FullRepresentationFormatInfo);
            Assert.AreEqual(mutableNode.GetFullText(), "A(B b){float y=5;}");

            node2 = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { A(B b); }").Members[0];
            node = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { A(B b); }").Members[0];
            mutableNode2 = (ConstructorDeclarationSyntax<object>)converter.Visit(node2.Members[0]);
            mutableNode.Update(converter.Visit(node.Members[0]));
            Assert.AreEqual(mutableNode.GetFullText(), "A(B b);");
            mutableNode.Delete(mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullText(), "A(B b)");
            mutableNode.Insert(mutableNode2.SemicolonToken, 6, EntryExtensions.FullRepresentationFormatInfo);
            Assert.AreEqual(mutableNode.GetFullText(), "A(B b);");
        }

        [TestMethod]
        public void ConstructorInitializerSyntax_Mutable_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();

            var node = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { public A(B b) : this(b) { } }").Members[0];
            var mutableNode = (ConstructorInitializerSyntax<object>)converter.Visit(((ConstructorDeclarationSyntax)node.Members[0]).Initializer);
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.ThisConstructorInitializer);
            Assert.AreEqual(mutableNode.GetFullText(), ":this(b)");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 2);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.ColonToken);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.ThisOrBaseKeyword);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 3);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.ColonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.ThisOrBaseKeyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.ArgumentList);
            mutableNode = (ConstructorInitializerSyntax<object>)mutableNode.Clone();
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.ThisConstructorInitializer);
            Assert.AreEqual(mutableNode.GetFullText(), ":this(b)");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 2);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.ColonToken);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.ThisOrBaseKeyword);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 3);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.ColonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.ThisOrBaseKeyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.ArgumentList);

            node = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { public A(B b) : base(b) { } }").Members[0];
            mutableNode = (ConstructorInitializerSyntax<object>)converter.Visit(((ConstructorDeclarationSyntax)node.Members[0]).Initializer);
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.BaseConstructorInitializer);
            Assert.AreEqual(mutableNode.GetFullText(), ":base(b)");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 2);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.ColonToken);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.ThisOrBaseKeyword);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 3);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.ColonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.ThisOrBaseKeyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.ArgumentList);
            mutableNode = (ConstructorInitializerSyntax<object>)mutableNode.Clone();
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.BaseConstructorInitializer);
            Assert.AreEqual(mutableNode.GetFullText(), ":base(b)");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 2);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.ColonToken);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.ThisOrBaseKeyword);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 3);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.ColonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.ThisOrBaseKeyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.ArgumentList);
            
            var node2 = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { public A(B b) : this(b) { } }").Members[0];
            node = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { public A(B b) : base(a) { } }").Members[0];
            var mutableNode2 = (ConstructorInitializerSyntax<object>)converter.Visit(((ConstructorDeclarationSyntax)node2.Members[0]).Initializer);
            mutableNode.Update(converter.Visit(((ConstructorDeclarationSyntax)node.Members[0]).Initializer));
            Assert.AreEqual(mutableNode.GetFullText(), ":base(a)");
            mutableNode.Delete(mutableNode.ThisOrBaseKeyword);
            Assert.AreEqual(mutableNode.GetFullText(), ":(a)");
            mutableNode.Insert(mutableNode2.ThisOrBaseKeyword, 0, EntryExtensions.FullRepresentationFormatInfo);
            Assert.AreEqual(mutableNode.GetFullText(), ":this(a)");

            node2 = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { public A(B b) : this(b) { } }").Members[0];
            node = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { public A(B b) : base(a) { } }").Members[0];
            mutableNode2 = (ConstructorInitializerSyntax<object>)converter.Visit(((ConstructorDeclarationSyntax)node2.Members[0]).Initializer);
            mutableNode.Update(converter.Visit(((ConstructorDeclarationSyntax)node.Members[0]).Initializer));
            Assert.AreEqual(mutableNode.GetFullText(), ":base(a)");
            mutableNode.Delete(mutableNode.ArgumentList);
            Assert.AreEqual(mutableNode.GetFullText(), ":base");
            mutableNode.Insert(mutableNode2.ArgumentList, 1, EntryExtensions.FullRepresentationFormatInfo);
            Assert.AreEqual(mutableNode.GetFullText(), ":base(b)");
        }

        [TestMethod]
        public void MemberDeclaration_DestructorDeclarationSyntax_Mutable_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();

            var node = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation] ~A(){ }; }").Members[0];
            var mutableNode = (DestructorDeclarationSyntax<object>)converter.Visit(node.Members[0]);
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.DestructorDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Documentation]~A(){};");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 3);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.TildeToken);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[2], mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 7);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.TildeToken);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.ParameterList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.Body);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[6], mutableNode.SemicolonToken);
            mutableNode = (DestructorDeclarationSyntax<object>)mutableNode.Clone();
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.DestructorDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Documentation]~A(){};");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 3);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.TildeToken);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[2], mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 7);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.TildeToken);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.ParameterList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.Body);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[6], mutableNode.SemicolonToken);

            node = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation] ~A(); }").Members[0];
            mutableNode = (DestructorDeclarationSyntax<object>)converter.Visit(node.Members[0]);
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.DestructorDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Documentation]~A();");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 3);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.TildeToken);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[2], mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 6);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.TildeToken);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.ParameterList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.SemicolonToken);
            mutableNode = (DestructorDeclarationSyntax<object>)mutableNode.Clone();
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.DestructorDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Documentation]~A();");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 3);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.TildeToken);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[2], mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 6);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.TildeToken);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.ParameterList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.SemicolonToken);

            node = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation] ~A(){} }").Members[0];
            mutableNode = (DestructorDeclarationSyntax<object>)converter.Visit(node.Members[0]);
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.DestructorDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Documentation]~A(){}");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 2);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.TildeToken);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 6);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.TildeToken);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.ParameterList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.Body);
            mutableNode = (DestructorDeclarationSyntax<object>)mutableNode.Clone();
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.DestructorDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Documentation]~A(){}");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 2);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.TildeToken);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 6);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.TildeToken);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.ParameterList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.Body);

            var node2 = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Serializable]~A() }").Members[0];
            node = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { [Documentation]~A() }").Members[0];
            var mutableNode2 = (DestructorDeclarationSyntax<object>)converter.Visit(node2.Members[0]);
            mutableNode.Update(converter.Visit(node.Members[0]));
            Assert.AreEqual(mutableNode.GetFullText(), "[Documentation]~A()");
            mutableNode.Delete(mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullText(), "~A()");
            mutableNode.Insert(mutableNode2.AttributeLists, 0, EntryExtensions.FullRepresentationFormatInfo);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serializable]~A()");

            node2 = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class B { ~B() }").Members[0];
            node = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { ~A() }").Members[0];
            mutableNode2 = (DestructorDeclarationSyntax<object>)converter.Visit(node2.Members[0]);
            mutableNode.Update(converter.Visit(node.Members[0]));
            Assert.AreEqual(mutableNode.GetFullText(), "~A()");
            mutableNode.Delete(mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetFullText(), "~()");
            mutableNode.Insert(mutableNode2.Identifier, 1, EntryExtensions.FullRepresentationFormatInfo);
            Assert.AreEqual(mutableNode.GetFullText(), "~B()");

            node2 = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { ~A(){float y = 5;} }").Members[0];
            node = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { ~A(){int a = 6;} }").Members[0];
            mutableNode2 = (DestructorDeclarationSyntax<object>)converter.Visit(node2.Members[0]);
            mutableNode.Update(converter.Visit(node.Members[0]));
            Assert.AreEqual(mutableNode.GetFullText(), "~A(){int a=6;}");
            mutableNode.Delete(mutableNode.Body);
            Assert.AreEqual(mutableNode.GetFullText(), "~A()");
            mutableNode.Insert(mutableNode2.Body, 2, EntryExtensions.FullRepresentationFormatInfo);
            Assert.AreEqual(mutableNode.GetFullText(), "~A(){float y=5;}");

            node2 = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { ~A(); }").Members[0];
            node = (ClassDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public class A { ~A(); }").Members[0];
            mutableNode2 = (DestructorDeclarationSyntax<object>)converter.Visit(node2.Members[0]);
            mutableNode.Update(converter.Visit(node.Members[0]));
            Assert.AreEqual(mutableNode.GetFullText(), "~A();");
            mutableNode.Delete(mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullText(), "~A()");
            mutableNode.Insert(mutableNode2.SemicolonToken, 3, EntryExtensions.FullRepresentationFormatInfo);
            Assert.AreEqual(mutableNode.GetFullText(), "~A();");
        }

        [TestMethod]
        public void MemberDeclaration_PropertyDeclarationSyntax_Mutable_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();

            var node = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M { get{return 5;} set{this.a = 7} };").Members[0];
            var mutableNode = (PropertyDeclarationSyntax<object>)converter.Visit(node);
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.PropertyDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serializable]public virtual string C.M{get{return 5;}set{this.a=7}};");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 2);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 7);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.Type);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.ExplicitInterfaceSpecifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.AccessorList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[6], mutableNode.SemicolonToken);
            mutableNode = (PropertyDeclarationSyntax<object>)mutableNode.Clone();
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.PropertyDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serializable]public virtual string C.M{get{return 5;}set{this.a=7}};");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 2);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 7);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.Type);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.ExplicitInterfaceSpecifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.AccessorList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[6], mutableNode.SemicolonToken);

            node = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public virtual string C.M { get{return 5;} set{this.a = 7} };").Members[0];
            mutableNode = (PropertyDeclarationSyntax<object>)converter.Visit(node);
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.PropertyDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "public virtual string C.M{get{return 5;}set{this.a=7}};");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 2);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 7);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.Type);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.ExplicitInterfaceSpecifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.AccessorList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[6], mutableNode.SemicolonToken);
            mutableNode = (PropertyDeclarationSyntax<object>)mutableNode.Clone();
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.PropertyDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "public virtual string C.M{get{return 5;}set{this.a=7}};");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 2);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 7);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.Type);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.ExplicitInterfaceSpecifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.AccessorList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[6], mutableNode.SemicolonToken);

            node = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] string C.M { get{return 5;} set{this.a = 7} };").Members[0];
            mutableNode = (PropertyDeclarationSyntax<object>)converter.Visit(node);
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.PropertyDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serializable]string C.M{get{return 5;}set{this.a=7}};");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 2);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 7);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.Type);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.ExplicitInterfaceSpecifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.AccessorList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[6], mutableNode.SemicolonToken);
            mutableNode = (PropertyDeclarationSyntax<object>)mutableNode.Clone();
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.PropertyDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serializable]string C.M{get{return 5;}set{this.a=7}};");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 2);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 7);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.Type);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.ExplicitInterfaceSpecifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.AccessorList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[6], mutableNode.SemicolonToken);

            node = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string M { get{return 5;} set{this.a = 7} };").Members[0];
            mutableNode = (PropertyDeclarationSyntax<object>)converter.Visit(node);
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.PropertyDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serializable]public virtual string M{get{return 5;}set{this.a=7}};");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 2);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 6);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.Type);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.AccessorList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.SemicolonToken);
            mutableNode = (PropertyDeclarationSyntax<object>)mutableNode.Clone();
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.PropertyDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serializable]public virtual string M{get{return 5;}set{this.a=7}};");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 2);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 6);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.Type);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.AccessorList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.SemicolonToken);

            node = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M => 5").Members[0];
            mutableNode = (PropertyDeclarationSyntax<object>)converter.Visit(node);
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.PropertyDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serializable]public virtual string C.M=>5");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 2);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 7);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.Type);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.ExplicitInterfaceSpecifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.ExpressionBody);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[6], mutableNode.SemicolonToken);
            mutableNode = (PropertyDeclarationSyntax<object>)mutableNode.Clone();
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.PropertyDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serializable]public virtual string C.M=>5");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 2);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 7);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.Type);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.ExplicitInterfaceSpecifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.ExpressionBody);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[6], mutableNode.SemicolonToken);

            node = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M => 5;").Members[0];
            mutableNode = (PropertyDeclarationSyntax<object>)converter.Visit(node);
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.PropertyDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serializable]public virtual string C.M=>5;");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 2);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 7);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.Type);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.ExplicitInterfaceSpecifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.ExpressionBody);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[6], mutableNode.SemicolonToken);
            mutableNode = (PropertyDeclarationSyntax<object>)mutableNode.Clone();
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.PropertyDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serializable]public virtual string C.M=>5;");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 2);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 7);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.Type);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.ExplicitInterfaceSpecifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.ExpressionBody);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[6], mutableNode.SemicolonToken);

            node = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M{set;} = 7;").Members[0];
            mutableNode = (PropertyDeclarationSyntax<object>)converter.Visit(node);
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.PropertyDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serializable]public virtual string C.M{set;}=7;");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 2);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 8);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.Type);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.ExplicitInterfaceSpecifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.AccessorList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[6], mutableNode.Initializer);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[7], mutableNode.SemicolonToken);
            mutableNode = (PropertyDeclarationSyntax<object>)mutableNode.Clone();
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.PropertyDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serializable]public virtual string C.M{set;}=7;");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 2);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 8);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.Type);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.ExplicitInterfaceSpecifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.AccessorList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[6], mutableNode.Initializer);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[7], mutableNode.SemicolonToken);

            node = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M {set;} = 7").Members[0];
            mutableNode = (PropertyDeclarationSyntax<object>)converter.Visit(node);
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.PropertyDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serializable]public virtual string C.M{set;}=7");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 2);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 8);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.Type);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.ExplicitInterfaceSpecifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.AccessorList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[6], mutableNode.Initializer);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[7], mutableNode.SemicolonToken);
            mutableNode = (PropertyDeclarationSyntax<object>)mutableNode.Clone();
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.PropertyDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serializable]public virtual string C.M{set;}=7");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 2);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 8);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.Type);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.ExplicitInterfaceSpecifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.AccessorList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[6], mutableNode.Initializer);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[7], mutableNode.SemicolonToken);

            node = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual string C.M { get{return 5;} set{this.a = 7} }").Members[0];
            mutableNode = (PropertyDeclarationSyntax<object>)converter.Visit(node);
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.PropertyDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serializable]public virtual string C.M{get{return 5;}set{this.a=7}}");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 1);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 6);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.Type);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.ExplicitInterfaceSpecifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.AccessorList);
            mutableNode = (PropertyDeclarationSyntax<object>)mutableNode.Clone();
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.PropertyDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serializable]public virtual string C.M{get{return 5;}set{this.a=7}}");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 1);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 6);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.Type);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.ExplicitInterfaceSpecifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.AccessorList);

            var node2 = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable]string M{get; set;}").Members[0];
            node = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Documentation]string M{get; set;}").Members[0];
            var mutableNode2 = (PropertyDeclarationSyntax<object>)converter.Visit(node2);
            mutableNode.Update(converter.Visit(node));
            Assert.AreEqual(mutableNode.GetFullText(), "[Documentation]string M{get;set;}");
            mutableNode.Delete(mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullText(), "string M{get;set;}");
            mutableNode.Insert(mutableNode2.AttributeLists, 0, EntryExtensions.FullRepresentationFormatInfo);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serializable]string M{get;set;}");

            node2 = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public string M{get; set;}").Members[0];
            node = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("private string M{get; set;}").Members[0];
            mutableNode2 = (PropertyDeclarationSyntax<object>)converter.Visit(node2);
            mutableNode.Update(converter.Visit(node));
            Assert.AreEqual(mutableNode.GetFullText(), "private string M{get;set;}");
            mutableNode.Delete(mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullText(), "string M{get;set;}");
            mutableNode.Insert(mutableNode2.Modifiers, 1, EntryExtensions.FullRepresentationFormatInfo);
            Assert.AreEqual(mutableNode.GetFullText(), "public string M{get;set;}");

            node2 = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int M{get;set;}").Members[0];
            node = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("float M{get;set;}").Members[0];
            mutableNode2 = (PropertyDeclarationSyntax<object>)converter.Visit(node2);
            mutableNode.Update(converter.Visit(node));
            Assert.AreEqual(mutableNode.GetFullText(), "float M{get;set;}");
            mutableNode.Delete(mutableNode.Type);
            Assert.AreEqual(mutableNode.GetFullText(), "M{get;set;}");
            mutableNode.Insert(mutableNode2.Type, 2, EntryExtensions.FullRepresentationFormatInfo);
            Assert.AreEqual(mutableNode.GetFullText(), "int M{get;set;}");

            node2 = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("string A.M{get;set;}").Members[0];
            node = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("string B.M{get;set;}").Members[0];
            mutableNode2 = (PropertyDeclarationSyntax<object>)converter.Visit(node2);
            mutableNode.Update(converter.Visit(node));
            Assert.AreEqual(mutableNode.GetFullText(), "string B.M{get;set;}");
            mutableNode.Delete(mutableNode.ExplicitInterfaceSpecifier);
            Assert.AreEqual(mutableNode.GetFullText(), "string M{get;set;}");
            mutableNode.Insert(mutableNode2.ExplicitInterfaceSpecifier, 3, EntryExtensions.FullRepresentationFormatInfo);
            Assert.AreEqual(mutableNode.GetFullText(), "string A.M{get;set;}");

            node2 = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("string A{get;set;}").Members[0];
            node = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("string B{get;set;}").Members[0];
            mutableNode2 = (PropertyDeclarationSyntax<object>)converter.Visit(node2);
            mutableNode.Update(converter.Visit(node));
            Assert.AreEqual(mutableNode.GetFullText(), "string B{get;set;}");
            mutableNode.Delete(mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetFullText(), "string {get;set;}");
            mutableNode.Insert(mutableNode2.Identifier, 4, EntryExtensions.FullRepresentationFormatInfo);
            Assert.AreEqual(mutableNode.GetFullText(), "string A{get;set;}");

            node2 = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("string M{set;get;}").Members[0];
            node = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("string M{get;set;}").Members[0];
            mutableNode2 = (PropertyDeclarationSyntax<object>)converter.Visit(node2);
            mutableNode.Update(converter.Visit(node));
            Assert.AreEqual(mutableNode.GetFullText(), "string M{get;set;}");
            mutableNode.Delete(mutableNode.AccessorList);
            Assert.AreEqual(mutableNode.GetFullText(), "string M");
            mutableNode.Insert(mutableNode2.AccessorList, 5, EntryExtensions.FullRepresentationFormatInfo);
            Assert.AreEqual(mutableNode.GetFullText(), "string M{set;get;}");

            node2 = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("string M {get;set;} => 5").Members[0];
            node = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("string M {get;set;} => 7").Members[0];
            mutableNode2 = (PropertyDeclarationSyntax<object>)converter.Visit(node2);
            mutableNode.Update(converter.Visit(node));
            Assert.AreEqual(mutableNode.GetFullText(), "string M{get;set;}=>7");
            mutableNode.Delete(mutableNode.ExpressionBody);
            Assert.AreEqual(mutableNode.GetFullText(), "string M{get;set;}");
            mutableNode.Insert(mutableNode2.ExpressionBody, 6, EntryExtensions.FullRepresentationFormatInfo);
            Assert.AreEqual(mutableNode.GetFullText(), "string M{get;set;}=>5");

            node2 = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("string M {get;set;} = 5").Members[0];
            node = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("string M {get;set;} = 7").Members[0];
            mutableNode2 = (PropertyDeclarationSyntax<object>)converter.Visit(node2);
            mutableNode.Update(converter.Visit(node));
            Assert.AreEqual(mutableNode.GetFullText(), "string M{get;set;}=7");
            mutableNode.Delete(mutableNode.Initializer);
            Assert.AreEqual(mutableNode.GetFullText(), "string M{get;set;}");
            mutableNode.Insert(mutableNode2.Initializer, 7, EntryExtensions.FullRepresentationFormatInfo);
            Assert.AreEqual(mutableNode.GetFullText(), "string M{get;set;}=5");

            node2 = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("string M {get;set;} => 5").Members[0];
            node = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("string M {get;set;} = 7").Members[0];
            mutableNode2 = (PropertyDeclarationSyntax<object>)converter.Visit(node2);
            mutableNode.Update(converter.Visit(node));
            Assert.AreEqual(mutableNode.GetFullText(), "string M{get;set;}=7");
            mutableNode.Delete(mutableNode.Initializer);
            Assert.AreEqual(mutableNode.GetFullText(), "string M{get;set;}");
            mutableNode.Insert(mutableNode2.ExpressionBody, 6, EntryExtensions.FullRepresentationFormatInfo);
            Assert.AreEqual(mutableNode.GetFullText(), "string M{get;set;}=>5");

            node2 = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("string M {get;set;} = 5").Members[0];
            node = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("string M {get;set;} => 7").Members[0];
            mutableNode2 = (PropertyDeclarationSyntax<object>)converter.Visit(node2);
            mutableNode.Update(converter.Visit(node));
            Assert.AreEqual(mutableNode.GetFullText(), "string M{get;set;}=>7");
            mutableNode.Delete(mutableNode.ExpressionBody);
            Assert.AreEqual(mutableNode.GetFullText(), "string M{get;set;}");
            mutableNode.Insert(mutableNode2.Initializer, 7, EntryExtensions.FullRepresentationFormatInfo);
            Assert.AreEqual(mutableNode.GetFullText(), "string M{get;set;}=5");

            node2 = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("string M{get;set;};").Members[0];
            node = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("string M{get;set;};").Members[0];
            mutableNode2 = (PropertyDeclarationSyntax<object>)converter.Visit(node2);
            mutableNode.Update(converter.Visit(node));
            Assert.AreEqual(mutableNode.GetFullText(), "string M{get;set;};");
            mutableNode.Delete(mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullText(), "string M{get;set;}");
            mutableNode.Insert(mutableNode2.SemicolonToken, 8, EntryExtensions.FullRepresentationFormatInfo);
            Assert.AreEqual(mutableNode.GetFullText(), "string M{get;set;};");
        }

        [TestMethod]
        public void MemberDeclaration_ArrowExpressionClauseSyntax_Mutable_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();

            var node = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("string C.M => 7;").Members[0];
            var mutableNode = (ArrowExpressionClauseSyntax<object>)converter.Visit(node.ExpressionBody);
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.ArrowExpressionClause);
            Assert.AreEqual(mutableNode.GetFullText(), "=>7");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 1);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.ArrowToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 2);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.ArrowToken);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Expression);
            mutableNode = (ArrowExpressionClauseSyntax<object>)mutableNode.Clone();
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.ArrowExpressionClause);
            Assert.AreEqual(mutableNode.GetFullText(), "=>7");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 1);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.ArrowToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 2);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.ArrowToken);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Expression);

            var node2 = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("string M => 7").Members[0];
            node = (PropertyDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("string M => 5").Members[0];
            var mutableNode2 = (ArrowExpressionClauseSyntax<object>)converter.Visit(node2.ExpressionBody);
            mutableNode.Update(converter.Visit(node.ExpressionBody));
            Assert.AreEqual(mutableNode.GetFullText(), "=>5");
            mutableNode.Delete(mutableNode.Expression);
            Assert.AreEqual(mutableNode.GetFullText(), "=>");
            mutableNode.Insert(mutableNode2.Expression, 0, EntryExtensions.FullRepresentationFormatInfo);
            Assert.AreEqual(mutableNode.GetFullText(), "=>7");
        }

        [TestMethod]
        public void MemberDeclaration_EventDeclarationSyntax_Mutable_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();

            var node = (EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A C.M { add{this.M += value;} remove{this.M -= value} }").Members[0];
            var mutableNode = (EventDeclarationSyntax<object>)converter.Visit(node);
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.EventDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serializable]public virtual event A C.M{add{this.M+=value;}remove{this.M-=value}}");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 2);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.EventKeyword);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 7);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.EventKeyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.Type);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.ExplicitInterfaceSpecifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[6], mutableNode.AccessorList);
            mutableNode = (EventDeclarationSyntax<object>)mutableNode.Clone();
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.EventDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serializable]public virtual event A C.M{add{this.M+=value;}remove{this.M-=value}}");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 2);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.EventKeyword);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 7);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.EventKeyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.Type);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.ExplicitInterfaceSpecifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[6], mutableNode.AccessorList);

            node = (EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public virtual event A C.M { add{this.M += value;} remove{this.M -= value} }").Members[0];
            mutableNode = (EventDeclarationSyntax<object>)converter.Visit(node);
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.EventDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "public virtual event A C.M{add{this.M+=value;}remove{this.M-=value}}");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 2);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.EventKeyword);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 7);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.EventKeyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.Type);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.ExplicitInterfaceSpecifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[6], mutableNode.AccessorList);
            mutableNode = (EventDeclarationSyntax<object>)mutableNode.Clone();
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.EventDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "public virtual event A C.M{add{this.M+=value;}remove{this.M-=value}}");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 2);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.EventKeyword);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 7);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.EventKeyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.Type);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.ExplicitInterfaceSpecifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[6], mutableNode.AccessorList);

            node = (EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] event A C.M { add{this.M += value;} remove{this.M -= value} }").Members[0];
            mutableNode = (EventDeclarationSyntax<object>)converter.Visit(node);
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.EventDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serializable]event A C.M{add{this.M+=value;}remove{this.M-=value}}");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 2);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.EventKeyword);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 7);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.EventKeyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.Type);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.ExplicitInterfaceSpecifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[6], mutableNode.AccessorList);
            mutableNode = (EventDeclarationSyntax<object>)mutableNode.Clone();
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.EventDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serializable]event A C.M{add{this.M+=value;}remove{this.M-=value}}");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 2);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.EventKeyword);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 7);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.EventKeyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.Type);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.ExplicitInterfaceSpecifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[6], mutableNode.AccessorList);

            node = (EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual event A M { add{this.M += value;} remove{this.M -= value} }").Members[0];
            mutableNode = (EventDeclarationSyntax<object>)converter.Visit(node);
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.EventDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serializable]public virtual event A M{add{this.M+=value;}remove{this.M-=value}}");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 2);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.EventKeyword);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 6);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.EventKeyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.Type);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.AccessorList);
            mutableNode = (EventDeclarationSyntax<object>)mutableNode.Clone();
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.EventDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serializable]public virtual event A M{add{this.M+=value;}remove{this.M-=value}}");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 2);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.EventKeyword);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 6);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.EventKeyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.Type);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.AccessorList);

            var node2 = (EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Documentation]event A M{ add{this.M += value;} remove{this.M -= value} }").Members[0];
            node = (EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable]event A M{ add{this.M+=value;}remove{this.M-=value}").Members[0];
            var mutableNode2 = (EventDeclarationSyntax<object>)converter.Visit(node2);
            mutableNode.Update(converter.Visit(node));
            Assert.AreEqual(mutableNode.GetFullText(), "[Serializable]event A M{add{this.M+=value;}remove{this.M-=value}");
            mutableNode.Delete(mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullText(), "event A M{add{this.M+=value;}remove{this.M-=value}");
            mutableNode.Insert(mutableNode2.AttributeLists, 0, EntryExtensions.FullRepresentationFormatInfo);
            Assert.AreEqual(mutableNode.GetFullText(), "[Documentation]event A M{add{this.M+=value;}remove{this.M-=value}");

            node2 = (EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public event A M { add{this.M += value;} remove{this.M -= value} }").Members[0];
            node = (EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("private event A M{ add{this.M+=value;}remove{this.M-=value}").Members[0];
            mutableNode2 = (EventDeclarationSyntax<object>)converter.Visit(node2);
            mutableNode.Update(converter.Visit(node));
            Assert.AreEqual(mutableNode.GetFullText(), "private event A M{add{this.M+=value;}remove{this.M-=value}");
            mutableNode.Delete(mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullText(), "event A M{add{this.M+=value;}remove{this.M-=value}");
            mutableNode.Insert(mutableNode2.Modifiers, 1, EntryExtensions.FullRepresentationFormatInfo);
            Assert.AreEqual(mutableNode.GetFullText(), "public event A M{add{this.M+=value;}remove{this.M-=value}");

            node2 = (EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("event A M { add{this.M += value;} remove{this.M -= value} }").Members[0];
            node = (EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("event B M{ add{this.M+=value;}remove{this.M-=value}").Members[0];
            mutableNode2 = (EventDeclarationSyntax<object>)converter.Visit(node2);
            mutableNode.Update(converter.Visit(node));
            Assert.AreEqual(mutableNode.GetFullText(), "event B M{add{this.M+=value;}remove{this.M-=value}");
            mutableNode.Delete(mutableNode.Type);
            Assert.AreEqual(mutableNode.GetFullText(), "eventM{add{this.M+=value;}remove{this.M-=value}");
            mutableNode.Insert(mutableNode2.Type, 2, EntryExtensions.FullRepresentationFormatInfo);
            Assert.AreEqual(mutableNode.GetFullText(), "event A M{add{this.M+=value;}remove{this.M-=value}");

            node2 = (EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("event A C.M { add{this.M += value;} remove{this.M -= value} }").Members[0];
            node = (EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("event A B.M{ add{this.M+=value;}remove{this.M-=value}").Members[0];
            mutableNode2 = (EventDeclarationSyntax<object>)converter.Visit(node2);
            mutableNode.Update(converter.Visit(node));
            Assert.AreEqual(mutableNode.GetFullText(), "event A B.M{add{this.M+=value;}remove{this.M-=value}");
            mutableNode.Delete(mutableNode.ExplicitInterfaceSpecifier);
            Assert.AreEqual(mutableNode.GetFullText(), "event A M{add{this.M+=value;}remove{this.M-=value}");
            mutableNode.Insert(mutableNode2.ExplicitInterfaceSpecifier, 3, EntryExtensions.FullRepresentationFormatInfo);
            Assert.AreEqual(mutableNode.GetFullText(), "event A C.M{add{this.M+=value;}remove{this.M-=value}");

            node2 = (EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("event A F { add{this.M += value;} remove{this.M -= value} }").Members[0];
            node = (EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("event A M{ add{this.M+=value;}remove{this.M-=value}").Members[0];
            mutableNode2 = (EventDeclarationSyntax<object>)converter.Visit(node2);
            mutableNode.Update(converter.Visit(node));
            Assert.AreEqual(mutableNode.GetFullText(), "event A M{add{this.M+=value;}remove{this.M-=value}");
            mutableNode.Delete(mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetFullText(), "event A {add{this.M+=value;}remove{this.M-=value}");
            mutableNode.Insert(mutableNode2.Identifier, 4, EntryExtensions.FullRepresentationFormatInfo);
            Assert.AreEqual(mutableNode.GetFullText(), "event A F{add{this.M+=value;}remove{this.M-=value}");

            node2 = (EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("event A M { remove; add; }").Members[0];
            node = (EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("event A M{ add{this.M+=value;}remove{this.M-=value}").Members[0];
            mutableNode2 = (EventDeclarationSyntax<object>)converter.Visit(node2);
            mutableNode.Update(converter.Visit(node));
            Assert.AreEqual(mutableNode.GetFullText(), "event A M{add{this.M+=value;}remove{this.M-=value}");
            mutableNode.Delete(mutableNode.AccessorList);
            Assert.AreEqual(mutableNode.GetFullText(), "event A M");
            mutableNode.Insert(mutableNode2.AccessorList, 5, EntryExtensions.FullRepresentationFormatInfo);
            Assert.AreEqual(mutableNode.GetFullText(), "event A M{remove;add;}");
        }

        [TestMethod]
        public void MemberDeclaration_IndexerDeclarationSyntax_Mutable_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();

            var node = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A C.this[string key] { get{return this.M[key];} set{this.M[key] = value;} } => 5;").Members[0];
            var mutableNode = (IndexerDeclarationSyntax<object>)converter.Visit(node);
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.IndexerDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serializable]public virtual A C.this[string key]{get{return this.M[key];}set{this.M[key]=value;}}=>5;");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 2);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.ThisKeyword);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 9);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.Type);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.ExplicitInterfaceSpecifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.ThisKeyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.ParameterList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[6], mutableNode.AccessorList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[7], mutableNode.ExpressionBody);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[8], mutableNode.SemicolonToken);
            mutableNode = (IndexerDeclarationSyntax<object>)mutableNode.Clone();
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.IndexerDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serializable]public virtual A C.this[string key]{get{return this.M[key];}set{this.M[key]=value;}}=>5;");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 2);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.ThisKeyword);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 9);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.Type);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.ExplicitInterfaceSpecifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.ThisKeyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.ParameterList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[6], mutableNode.AccessorList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[7], mutableNode.ExpressionBody);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[8], mutableNode.SemicolonToken);

            node = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public virtual A C.this[string key] { get{return this.M[key];} set{this.M[key] = value;} } => 5;").Members[0];
            mutableNode = (IndexerDeclarationSyntax<object>)converter.Visit(node);
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.IndexerDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "public virtual A C.this[string key]{get{return this.M[key];}set{this.M[key]=value;}}=>5;");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 2);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.ThisKeyword);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 9);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.Type);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.ExplicitInterfaceSpecifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.ThisKeyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.ParameterList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[6], mutableNode.AccessorList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[7], mutableNode.ExpressionBody);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[8], mutableNode.SemicolonToken);
            mutableNode = (IndexerDeclarationSyntax<object>)mutableNode.Clone();
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.IndexerDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "public virtual A C.this[string key]{get{return this.M[key];}set{this.M[key]=value;}}=>5;");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 2);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.ThisKeyword);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 9);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.Type);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.ExplicitInterfaceSpecifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.ThisKeyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.ParameterList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[6], mutableNode.AccessorList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[7], mutableNode.ExpressionBody);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[8], mutableNode.SemicolonToken);

            node = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] A C.this[string key] { get{return this.M[key];} set{this.M[key] = value;} } => 5;").Members[0];
            mutableNode = (IndexerDeclarationSyntax<object>)converter.Visit(node);
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.IndexerDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serializable]A C.this[string key]{get{return this.M[key];}set{this.M[key]=value;}}=>5;");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 2);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.ThisKeyword);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 9);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.Type);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.ExplicitInterfaceSpecifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.ThisKeyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.ParameterList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[6], mutableNode.AccessorList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[7], mutableNode.ExpressionBody);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[8], mutableNode.SemicolonToken);
            mutableNode = (IndexerDeclarationSyntax<object>)mutableNode.Clone();
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.IndexerDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serializable]A C.this[string key]{get{return this.M[key];}set{this.M[key]=value;}}=>5;");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 2);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.ThisKeyword);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 9);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.Type);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.ExplicitInterfaceSpecifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.ThisKeyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.ParameterList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[6], mutableNode.AccessorList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[7], mutableNode.ExpressionBody);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[8], mutableNode.SemicolonToken);

            node = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A this[string key] { get{return this.M[key];} set{this.M[key] = value;} } => 5;").Members[0];
            mutableNode = (IndexerDeclarationSyntax<object>)converter.Visit(node);
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.IndexerDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serializable]public virtual A this[string key]{get{return this.M[key];}set{this.M[key]=value;}}=>5;");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 2);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.ThisKeyword);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 8);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.Type);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.ThisKeyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.ParameterList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.AccessorList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[6], mutableNode.ExpressionBody);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[7], mutableNode.SemicolonToken);
            mutableNode = (IndexerDeclarationSyntax<object>)mutableNode.Clone();
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.IndexerDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serializable]public virtual A this[string key]{get{return this.M[key];}set{this.M[key]=value;}}=>5;");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 2);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.ThisKeyword);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 8);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.Type);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.ThisKeyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.ParameterList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.AccessorList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[6], mutableNode.ExpressionBody);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[7], mutableNode.SemicolonToken);

            node = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A C.this[string key] => 5;").Members[0];
            mutableNode = (IndexerDeclarationSyntax<object>)converter.Visit(node);
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.IndexerDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serializable]public virtual A C.this[string key]=>5;");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 2);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.ThisKeyword);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 8);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.Type);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.ExplicitInterfaceSpecifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.ThisKeyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.ParameterList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[6], mutableNode.ExpressionBody);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[7], mutableNode.SemicolonToken);
            mutableNode = (IndexerDeclarationSyntax<object>)mutableNode.Clone();
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.IndexerDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serializable]public virtual A C.this[string key]=>5;");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 2);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.ThisKeyword);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 8);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.Type);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.ExplicitInterfaceSpecifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.ThisKeyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.ParameterList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[6], mutableNode.ExpressionBody);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[7], mutableNode.SemicolonToken);

            node = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A C.this[string key] { get{return this.M[key];} set{this.M[key] = value;} };").Members[0];
            mutableNode = (IndexerDeclarationSyntax<object>)converter.Visit(node);
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.IndexerDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serializable]public virtual A C.this[string key]{get{return this.M[key];}set{this.M[key]=value;}};");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 2);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.ThisKeyword);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 8);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.Type);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.ExplicitInterfaceSpecifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.ThisKeyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.ParameterList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[6], mutableNode.AccessorList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[7], mutableNode.SemicolonToken);
            mutableNode = (IndexerDeclarationSyntax<object>)mutableNode.Clone();
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.IndexerDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serializable]public virtual A C.this[string key]{get{return this.M[key];}set{this.M[key]=value;}};");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 2);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.ThisKeyword);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 8);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.Type);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.ExplicitInterfaceSpecifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.ThisKeyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.ParameterList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[6], mutableNode.AccessorList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[7], mutableNode.SemicolonToken);

            node = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable] public virtual A C.this[string key] { get{return this.M[key];} set{this.M[key] = value;} } => 5").Members[0];
            mutableNode = (IndexerDeclarationSyntax<object>)converter.Visit(node);
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.IndexerDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serializable]public virtual A C.this[string key]{get{return this.M[key];}set{this.M[key]=value;}}=>5");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 2);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.ThisKeyword);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 9);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.Type);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.ExplicitInterfaceSpecifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.ThisKeyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.ParameterList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[6], mutableNode.AccessorList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[7], mutableNode.ExpressionBody);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[8], mutableNode.SemicolonToken);
            mutableNode = (IndexerDeclarationSyntax<object>)mutableNode.Clone();
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.IndexerDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serializable]public virtual A C.this[string key]{get{return this.M[key];}set{this.M[key]=value;}}=>5");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 2);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.ThisKeyword);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 9);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.Type);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.ExplicitInterfaceSpecifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.ThisKeyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[5], mutableNode.ParameterList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[6], mutableNode.AccessorList);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[7], mutableNode.ExpressionBody);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[8], mutableNode.SemicolonToken);
            
            var node2 = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Documentation]A this[string key] { get{return this.M[key];} set{this.M[key] = value;} }").Members[0];
            node = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("[Serializable]A this[string key] { get{return this.M[key];} set{this.M[key] = value;} }").Members[0];
            var mutableNode2 = (IndexerDeclarationSyntax<object>)converter.Visit(node2);
            mutableNode.Update(converter.Visit(node));
            Assert.AreEqual(mutableNode.GetFullText(), "[Serializable]A this[string key]{get{return this.M[key];}set{this.M[key]=value;}}");
            mutableNode.Delete(mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullText(), "A this[string key]{get{return this.M[key];}set{this.M[key]=value;}}");
            mutableNode.Insert(mutableNode2.AttributeLists, 0, EntryExtensions.FullRepresentationFormatInfo);
            Assert.AreEqual(mutableNode.GetFullText(), "[Documentation]A this[string key]{get{return this.M[key];}set{this.M[key]=value;}}");

            node2 = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("public A this[string key] { get{return this.M[key];} set{this.M[key] = value;} }").Members[0];
            node = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("private A this[string key] { get{return this.M[key];} set{this.M[key] = value;} }").Members[0];
            mutableNode2 = (IndexerDeclarationSyntax<object>)converter.Visit(node2);
            mutableNode.Update(converter.Visit(node));
            Assert.AreEqual(mutableNode.GetFullText(), "private A this[string key]{get{return this.M[key];}set{this.M[key]=value;}}");
            mutableNode.Delete(mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullText(), "A this[string key]{get{return this.M[key];}set{this.M[key]=value;}}");
            mutableNode.Insert(mutableNode2.Modifiers, 1, EntryExtensions.FullRepresentationFormatInfo);
            Assert.AreEqual(mutableNode.GetFullText(), "public A this[string key]{get{return this.M[key];}set{this.M[key]=value;}}");

            node2 = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("B this[string key] { get{return this.M[key];} set{this.M[key] = value;} }").Members[0];
            node = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A this[string key] { get{return this.M[key];} set{this.M[key] = value;} }").Members[0];
            mutableNode2 = (IndexerDeclarationSyntax<object>)converter.Visit(node2);
            mutableNode.Update(converter.Visit(node));
            Assert.AreEqual(mutableNode.GetFullText(), "A this[string key]{get{return this.M[key];}set{this.M[key]=value;}}");
            mutableNode.Delete(mutableNode.Type);
            Assert.AreEqual(mutableNode.GetFullText(), "this[string key]{get{return this.M[key];}set{this.M[key]=value;}}");
            mutableNode.Insert(mutableNode2.Type, 2, EntryExtensions.FullRepresentationFormatInfo);
            Assert.AreEqual(mutableNode.GetFullText(), "B this[string key]{get{return this.M[key];}set{this.M[key]=value;}}");

            node2 = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A C.this[string key] { get{return this.M[key];} set{this.M[key] = value;} }").Members[0];
            node = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A B.this[string key] { get{return this.M[key];} set{this.M[key] = value;} }").Members[0];
            mutableNode2 = (IndexerDeclarationSyntax<object>)converter.Visit(node2);
            mutableNode.Update(converter.Visit(node));
            Assert.AreEqual(mutableNode.GetFullText(), "A B.this[string key]{get{return this.M[key];}set{this.M[key]=value;}}");
            mutableNode.Delete(mutableNode.ExplicitInterfaceSpecifier);
            Assert.AreEqual(mutableNode.GetFullText(), "A this[string key]{get{return this.M[key];}set{this.M[key]=value;}}");
            mutableNode.Insert(mutableNode2.ExplicitInterfaceSpecifier, 3, EntryExtensions.FullRepresentationFormatInfo);
            Assert.AreEqual(mutableNode.GetFullText(), "A C.this[string key]{get{return this.M[key];}set{this.M[key]=value;}}");

            node2 = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A this[int id] { get{return this.M[key];} set{this.M[key] = value;} }").Members[0];
            node = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A this[string key] { get{return this.M[key];} set{this.M[key] = value;} }").Members[0];
            mutableNode2 = (IndexerDeclarationSyntax<object>)converter.Visit(node2);
            mutableNode.Update(converter.Visit(node));
            Assert.AreEqual(mutableNode.GetFullText(), "A this[string key]{get{return this.M[key];}set{this.M[key]=value;}}");
            mutableNode.Delete(mutableNode.ParameterList);
            Assert.AreEqual(mutableNode.GetFullText(), "A this{get{return this.M[key];}set{this.M[key]=value;}}");
            mutableNode.Insert(mutableNode2.ParameterList, 4, EntryExtensions.FullRepresentationFormatInfo);
            Assert.AreEqual(mutableNode.GetFullText(), "A this[int id]{get{return this.M[key];}set{this.M[key]=value;}}");

            node2 = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A this[string key] { set; get; }").Members[0];
            node = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A this[string key] { get{return this.M[key];} set{this.M[key] = value;} }").Members[0];
            mutableNode2 = (IndexerDeclarationSyntax<object>)converter.Visit(node2);
            mutableNode.Update(converter.Visit(node));
            Assert.AreEqual(mutableNode.GetFullText(), "A this[string key]{get{return this.M[key];}set{this.M[key]=value;}}");
            mutableNode.Delete(mutableNode.AccessorList);
            Assert.AreEqual(mutableNode.GetFullText(), "A this[string key]");
            mutableNode.Insert(mutableNode2.AccessorList, 5, EntryExtensions.FullRepresentationFormatInfo);
            Assert.AreEqual(mutableNode.GetFullText(), "A this[string key]{set;get;}");

            node2 = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A this[string key] { get{return this.M[key];} set{this.M[key] = value;} } => 7").Members[0];
            node = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A this[string key] { get{return this.M[key];} set{this.M[key] = value;} } => 5").Members[0];
            mutableNode2 = (IndexerDeclarationSyntax<object>)converter.Visit(node2);
            mutableNode.Update(converter.Visit(node));
            Assert.AreEqual(mutableNode.GetFullText(), "A this[string key]{get{return this.M[key];}set{this.M[key]=value;}}=>5");
            mutableNode.Delete(mutableNode.ExpressionBody);
            Assert.AreEqual(mutableNode.GetFullText(), "A this[string key]{get{return this.M[key];}set{this.M[key]=value;}}");
            mutableNode.Insert(mutableNode2.ExpressionBody, 6, EntryExtensions.FullRepresentationFormatInfo);
            Assert.AreEqual(mutableNode.GetFullText(), "A this[string key]{get{return this.M[key];}set{this.M[key]=value;}}=>7");

            node2 = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A this[string key] { get{return this.M[key];} set{this.M[key] = value;} };").Members[0];
            node = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A this[string key] { get{return this.M[key];} set{this.M[key] = value;} };").Members[0];
            mutableNode2 = (IndexerDeclarationSyntax<object>)converter.Visit(node2);
            mutableNode.Update(converter.Visit(node));
            Assert.AreEqual(mutableNode.GetFullText(), "A this[string key]{get{return this.M[key];}set{this.M[key]=value;}};");
            mutableNode.Delete(mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullText(), "A this[string key]{get{return this.M[key];}set{this.M[key]=value;}}");
            mutableNode.Insert(mutableNode2.SemicolonToken, 7, EntryExtensions.FullRepresentationFormatInfo);
            Assert.AreEqual(mutableNode.GetFullText(), "A this[string key]{get{return this.M[key];}set{this.M[key]=value;}};");
        }
 
        [TestMethod]
        public void AccessorListSyntax_Mutable_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();

            var node = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A C.this[string key] { get{return this.M[key];} set{this.M[key] = value;} }").Members[0];
            var mutableNode = (AccessorListSyntax<object>)converter.Visit(node.AccessorList);
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.AccessorList);
            Assert.AreEqual(mutableNode.GetFullText(), "{get{return this.M[key];}set{this.M[key]=value;}}");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 2);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.OpenBraceToken);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.CloseBraceToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 3);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.OpenBraceToken);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Accessors);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.CloseBraceToken);
            mutableNode = (AccessorListSyntax<object>)mutableNode.Clone();
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.AccessorList);
            Assert.AreEqual(mutableNode.GetFullText(), "{get{return this.M[key];}set{this.M[key]=value;}}");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 2);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.OpenBraceToken);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.CloseBraceToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 3);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.OpenBraceToken);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Accessors);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.CloseBraceToken);

            var node2 = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A C.this[string key] { set; get; }").Members[0];
            node = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A C.this[string key] { get{return this.M[key];} set{this.M[key] = value;} }").Members[0];
            var mutableNode2 = (AccessorListSyntax<object>)converter.Visit(node2.AccessorList);
            mutableNode.Update(converter.Visit(node.AccessorList));
            Assert.AreEqual(mutableNode.GetFullText(), "{get{return this.M[key];}set{this.M[key]=value;}}");
            mutableNode.Delete(mutableNode.Accessors);
            Assert.AreEqual(mutableNode.GetFullText(), "{}");
            mutableNode.Insert(mutableNode2.Accessors, 0, EntryExtensions.FullRepresentationFormatInfo);
            Assert.AreEqual(mutableNode.GetFullText(), "{set;get;}");
        }

        [TestMethod]
        public void AccessorDeclarationSyntax_Mutable_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();

            var node = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A C.this[string key] { [Documentation] public get{return this.M[key];} [Serialization] public set{this.M[key] = value;} }").Members[0];
            var mutableNode = (AccessorDeclarationSyntax<object>)converter.Visit(node.AccessorList.Accessors[0]);
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.GetAccessorDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Documentation]public get{return this.M[key];}");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 1);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.Keyword);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 4);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.Keyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.Body);
            mutableNode = (AccessorDeclarationSyntax<object>)mutableNode.Clone();
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.GetAccessorDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Documentation]public get{return this.M[key];}");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 1);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.Keyword);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 4);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.Keyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.Body);

            mutableNode = (AccessorDeclarationSyntax<object>)converter.Visit(node.AccessorList.Accessors[1]);
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.SetAccessorDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serialization]public set{this.M[key]=value;}");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 1);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.Keyword);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 4);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.Keyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.Body);
            mutableNode = (AccessorDeclarationSyntax<object>)mutableNode.Clone();
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.SetAccessorDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serialization]public set{this.M[key]=value;}");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 1);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.Keyword);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 4);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.Keyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.Body);

            node = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A C.this[string key] { [Documentation] public get; [Serialization] public set; }").Members[0];
            mutableNode = (AccessorDeclarationSyntax<object>)converter.Visit(node.AccessorList.Accessors[0]);
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.GetAccessorDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Documentation]public get;");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 2);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.Keyword);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 4);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.Keyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.SemicolonToken);
            mutableNode = (AccessorDeclarationSyntax<object>)mutableNode.Clone();
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.GetAccessorDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Documentation]public get;");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 2);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.Keyword);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 4);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.Keyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.SemicolonToken);

            mutableNode = (AccessorDeclarationSyntax<object>)converter.Visit(node.AccessorList.Accessors[1]);
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.SetAccessorDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serialization]public set;");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 2);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.Keyword);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 4);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.Keyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.SemicolonToken);
            mutableNode = (AccessorDeclarationSyntax<object>)mutableNode.Clone();
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.SetAccessorDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serialization]public set;");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 2);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.Keyword);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 4);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.Keyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.SemicolonToken);

            var node3 = (EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("event A C { [Documentation] public add{this.M += value;} [Serialization] public remove{this.M -= value;} }").Members[0];
            mutableNode = (AccessorDeclarationSyntax<object>)converter.Visit(node3.AccessorList.Accessors[0]);
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.AddAccessorDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Documentation]public add{this.M+=value;}");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 1);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.Keyword);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 4);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.Keyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.Body);
            mutableNode = (AccessorDeclarationSyntax<object>)mutableNode.Clone();
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.AddAccessorDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Documentation]public add{this.M+=value;}");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 1);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.Keyword);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 4);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.Keyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.Body);

            mutableNode = (AccessorDeclarationSyntax<object>)converter.Visit(node3.AccessorList.Accessors[1]);
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.RemoveAccessorDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serialization]public remove{this.M-=value;}");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 1);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.Keyword);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 4);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.Keyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.Body);
            mutableNode = (AccessorDeclarationSyntax<object>)mutableNode.Clone();
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.RemoveAccessorDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serialization]public remove{this.M-=value;}");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 1);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.Keyword);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 4);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.Keyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.Body);

            node3 = (EventDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("event A C { [Documentation] public add; [Serialization] public remove; }").Members[0];
            mutableNode = (AccessorDeclarationSyntax<object>)converter.Visit(node3.AccessorList.Accessors[0]);
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.AddAccessorDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Documentation]public add;");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 2);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.Keyword);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 4);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.Keyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.SemicolonToken);
            mutableNode = (AccessorDeclarationSyntax<object>)mutableNode.Clone();
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.AddAccessorDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Documentation]public add;");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 2);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.Keyword);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 4);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.Keyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.SemicolonToken);

            mutableNode = (AccessorDeclarationSyntax<object>)converter.Visit(node3.AccessorList.Accessors[1]);
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.RemoveAccessorDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serialization]public remove;");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 2);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.Keyword);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 4);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.Keyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.SemicolonToken);
            mutableNode = (AccessorDeclarationSyntax<object>)mutableNode.Clone();
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.RemoveAccessorDeclaration);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serialization]public remove;");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 2);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.Keyword);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 4);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.Keyword);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.SemicolonToken);

            var node2 = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A this[string key] {[Serialization] get{return this.M[key];} set{this.M[key] = value;} };").Members[0];
            node = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A this[string key] {[Documentation] get{return this.M[key];} set{this.M[key] = value;} };").Members[0];
            var mutableNode2 = (AccessorDeclarationSyntax<object>)converter.Visit(node2.AccessorList.Accessors[0]);
            mutableNode.Update(converter.Visit(node.AccessorList.Accessors[0]));
            Assert.AreEqual(mutableNode.GetFullText(), "[Documentation]get{return this.M[key];}");
            mutableNode.Delete(mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullText(), "get{return this.M[key];}");
            mutableNode.Insert(mutableNode2.AttributeLists, 0, EntryExtensions.FullRepresentationFormatInfo);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serialization]get{return this.M[key];}");

            node2 = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A this[string key] {protected get{return this.M[key];} set{this.M[key] = value;} };").Members[0];
            node = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A this[string key] {public get{return this.M[key];} set{this.M[key] = value;} };").Members[0];
            mutableNode2 = (AccessorDeclarationSyntax<object>)converter.Visit(node2.AccessorList.Accessors[0]);
            mutableNode.Update(converter.Visit(node.AccessorList.Accessors[0]));
            Assert.AreEqual(mutableNode.GetFullText(), "public get{return this.M[key];}");
            mutableNode.Delete(mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullText(), "get{return this.M[key];}");
            mutableNode.Insert(mutableNode2.Modifiers, 1, EntryExtensions.FullRepresentationFormatInfo);
            Assert.AreEqual(mutableNode.GetFullText(), "protected get{return this.M[key];}");

            node2 = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A this[string key] { get; set; };").Members[0];
            node = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A this[string key] { l; set{this.M[key] = value;} };").Members[0];
            mutableNode2 = (AccessorDeclarationSyntax<object>)converter.Visit(node2.AccessorList.Accessors[0]);
            mutableNode.Update(converter.Visit(node.AccessorList.Accessors[0]));
            Assert.AreEqual(mutableNode.GetFullText(), "l;");
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.UnknownAccessorDeclaration);
            mutableNode.Delete(mutableNode.Keyword);
            Assert.AreEqual(mutableNode.GetFullText(), ";");
            mutableNode.Insert(mutableNode2.Keyword, 2, EntryExtensions.FullRepresentationFormatInfo);
            Assert.AreEqual(mutableNode.GetFullText(), "get;");
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.GetAccessorDeclaration);

            node2 = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A this[string key] { set; get; };").Members[0];
            node = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A this[string key] { l; set{this.M[key] = value;} };").Members[0];
            mutableNode2 = (AccessorDeclarationSyntax<object>)converter.Visit(node2.AccessorList.Accessors[0]);
            mutableNode.Update(converter.Visit(node.AccessorList.Accessors[0]));
            Assert.AreEqual(mutableNode.GetFullText(), "l;");
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.UnknownAccessorDeclaration);
            mutableNode.Delete(mutableNode.Keyword);
            Assert.AreEqual(mutableNode.GetFullText(), ";");
            mutableNode.Insert(mutableNode2.Keyword, 2, EntryExtensions.FullRepresentationFormatInfo);
            Assert.AreEqual(mutableNode.GetFullText(), "set;");
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.SetAccessorDeclaration);

            node2 = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A this[string key] { add; set; };").Members[0];
            node = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A this[string key] { l; set{this.M[key] = value;} };").Members[0];
            mutableNode2 = (AccessorDeclarationSyntax<object>)converter.Visit(node2.AccessorList.Accessors[0]);
            mutableNode.Update(converter.Visit(node.AccessorList.Accessors[0]));
            Assert.AreEqual(mutableNode.GetFullText(), "l;");
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.UnknownAccessorDeclaration);
            mutableNode.Delete(mutableNode.Keyword);
            Assert.AreEqual(mutableNode.GetFullText(), ";");
            mutableNode.Insert(mutableNode2.Keyword, 2, EntryExtensions.FullRepresentationFormatInfo);
            Assert.AreEqual(mutableNode.GetFullText(), "add;");
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.AddAccessorDeclaration);

            node2 = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A this[string key] { remove; set; };").Members[0];
            node = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A this[string key] { l; set{this.M[key] = value;} };").Members[0];
            mutableNode2 = (AccessorDeclarationSyntax<object>)converter.Visit(node2.AccessorList.Accessors[0]);
            mutableNode.Update(converter.Visit(node.AccessorList.Accessors[0]));
            Assert.AreEqual(mutableNode.GetFullText(), "l;");
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.UnknownAccessorDeclaration);
            mutableNode.Delete(mutableNode.Keyword);
            Assert.AreEqual(mutableNode.GetFullText(), ";");
            mutableNode.Insert(mutableNode2.Keyword, 2, EntryExtensions.FullRepresentationFormatInfo);
            Assert.AreEqual(mutableNode.GetFullText(), "remove;");
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.RemoveAccessorDeclaration);

            node2 = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A this[string key] { l; set; };").Members[0];
            node = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A this[string key] { get; set{this.M[key] = value;} };").Members[0];
            mutableNode2 = (AccessorDeclarationSyntax<object>)converter.Visit(node2.AccessorList.Accessors[0]);
            mutableNode.Update(converter.Visit(node.AccessorList.Accessors[0]));
            Assert.AreEqual(mutableNode.GetFullText(), "get;");
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.GetAccessorDeclaration);
            mutableNode.Delete(mutableNode.Keyword);
            Assert.AreEqual(mutableNode.GetFullText(), ";");
            mutableNode.Insert(mutableNode2.Keyword, 2, EntryExtensions.FullRepresentationFormatInfo);
            Assert.AreEqual(mutableNode.GetFullText(), "l;");
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.UnknownAccessorDeclaration);

            node2 = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A this[string key] { get{return 5;} set; };").Members[0];
            node = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A this[string key] { get{return 3;}; set{this.M[key] = value;} };").Members[0];
            mutableNode2 = (AccessorDeclarationSyntax<object>)converter.Visit(node2.AccessorList.Accessors[0]);
            mutableNode.Update(converter.Visit(node.AccessorList.Accessors[0]));
            Assert.AreEqual(mutableNode.GetFullText(), "get{return 3;}");
            mutableNode.Delete(mutableNode.Body);
            Assert.AreEqual(mutableNode.GetFullText(), "get");
            mutableNode.Insert(mutableNode2.Body, 3, EntryExtensions.FullRepresentationFormatInfo);
            Assert.AreEqual(mutableNode.GetFullText(), "get{return 5;}");

            node2 = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A this[string key] { get; set; };").Members[0];
            node = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("A this[string key] { get; set{this.M[key] = value;} };").Members[0];
            mutableNode2 = (AccessorDeclarationSyntax<object>)converter.Visit(node2.AccessorList.Accessors[0]);
            mutableNode.Update(converter.Visit(node.AccessorList.Accessors[0]));
            Assert.AreEqual(mutableNode.GetFullText(), "get;");
            mutableNode.Delete(mutableNode.SemicolonToken);
            Assert.AreEqual(mutableNode.GetFullText(), "get");
            mutableNode.Insert(mutableNode2.SemicolonToken, 4, EntryExtensions.FullRepresentationFormatInfo);
            Assert.AreEqual(mutableNode.GetFullText(), "get;");
        }

        [TestMethod]
        public void ParameterListSyntax_Mutable_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();

            var node = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("M([Serializable] ref int a = 0, A b){}").Members[0];
            var mutableNode = (ParameterListSyntax<object>)converter.Visit(node.ParameterList);
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.ParameterList);
            Assert.AreEqual(mutableNode.GetFullText(), "([Serializable]ref int a=0,A b)");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 2);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.OpenParenToken);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.CloseParenToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 3);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.OpenParenToken);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Parameters);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.CloseParenToken);
            mutableNode = (ParameterListSyntax<object>)mutableNode.Clone();
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.ParameterList);
            Assert.AreEqual(mutableNode.GetFullText(), "([Serializable]ref int a=0,A b)");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 2);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.OpenParenToken);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.CloseParenToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 3);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.OpenParenToken);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Parameters);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.CloseParenToken);
            
            var node2 = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("M(int a, A b){}").Members[0];
            node = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("M(string[] ids){}").Members[0];
            var mutableNode2 = (ParameterListSyntax<object>)converter.Visit(node2.ParameterList);
            mutableNode.Update(converter.Visit(node.ParameterList));
            Assert.AreEqual(mutableNode.GetFullText(), "(string[] ids)");
            mutableNode.Delete(mutableNode.Parameters);
            Assert.AreEqual(mutableNode.GetFullText(), "()");
            mutableNode.Insert(mutableNode2.Parameters, 0, EntryExtensions.FullRepresentationFormatInfo);
            Assert.AreEqual(mutableNode.GetFullText(), "(int a,A b)");
        }

        [TestMethod]
        public void BracketedParameterListSyntax_Mutable_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();

            var node = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int this[[Serializable] ref int a = 0, A b]{get;set;}").Members[0];
            var mutableNode = (BracketedParameterListSyntax<object>)converter.Visit(node.ParameterList);
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.BracketedParameterList);
            Assert.AreEqual(mutableNode.GetFullText(), "[[Serializable]ref int a=0,A b]");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 2);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.OpenBracketToken);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.CloseBracketToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 3);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.OpenBracketToken);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Parameters);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.CloseBracketToken);
            mutableNode = (BracketedParameterListSyntax<object>)mutableNode.Clone();
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.BracketedParameterList);
            Assert.AreEqual(mutableNode.GetFullText(), "[[Serializable]ref int a=0,A b]");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 2);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.OpenBracketToken);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[1], mutableNode.CloseBracketToken);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 3);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.OpenBracketToken);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Parameters);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.CloseBracketToken);

            var node2 = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int this[(int a, A b]{get;set;}").Members[0];
            node = (IndexerDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("int this[(string[] ids]{get;set;}").Members[0];
            var mutableNode2 = (BracketedParameterListSyntax<object>)converter.Visit(node2.ParameterList);
            mutableNode.Update(converter.Visit(node.ParameterList));
            Assert.AreEqual(mutableNode.GetFullText(), "[string[] ids]");
            mutableNode.Delete(mutableNode.Parameters);
            Assert.AreEqual(mutableNode.GetFullText(), "[]");
            mutableNode.Insert(mutableNode2.Parameters, 0, EntryExtensions.FullRepresentationFormatInfo);
            Assert.AreEqual(mutableNode.GetFullText(), "[int a,A b]");
        }

        [TestMethod]
        public void ParameterSyntax_Mutable_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();

            var node = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("M([Serializable] ref int a = 0, A b){}").Members[0];
            var mutableNode = (ParameterSyntax<object>)converter.Visit(node.ParameterList.Parameters[0]);
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.Parameter);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serializable]ref int a=0");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 1);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 5);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.Type);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.Default);
            mutableNode = (ParameterSyntax<object>)mutableNode.Clone();
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.Parameter);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serializable]ref int a=0");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 1);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 5);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.Type);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.Default);

            node = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("M([Serializable] out int a = 0, A b){}").Members[0];
            mutableNode = (ParameterSyntax<object>)converter.Visit(node.ParameterList.Parameters[0]);
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.Parameter);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serializable]out int a=0");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 1);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 5);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.Type);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.Default);
            mutableNode = (ParameterSyntax<object>)mutableNode.Clone();
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.Parameter);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serializable]out int a=0");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 1);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 5);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.Type);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.Default);

            node = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("M([Serializable] params int[] a = 0, A b){}").Members[0];
            mutableNode = (ParameterSyntax<object>)converter.Visit(node.ParameterList.Parameters[0]);
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.Parameter);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serializable]params int[] a=0");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 1);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 5);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.Type);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.Default);
            mutableNode = (ParameterSyntax<object>)mutableNode.Clone();
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.Parameter);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serializable]params int[] a=0");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 1);
            Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 5);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.Type);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[3], mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[4], mutableNode.Default);

            var node2 = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("M([Documentation]  int[] a){}").Members[0];
            node = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("M([Serializable] int[] a){}").Members[0];
            var mutableNode2 = (ParameterSyntax<object>)converter.Visit(node2.ParameterList.Parameters[0]);
            mutableNode.Update(converter.Visit(node.ParameterList.Parameters[0]));
            Assert.AreEqual(mutableNode.GetFullText(), "[Serializable]int[] a");
            mutableNode.Delete(mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullText(), "int[] a");
            mutableNode.Insert(mutableNode2.AttributeLists, 0, EntryExtensions.FullRepresentationFormatInfo);
            Assert.AreEqual(mutableNode.GetFullText(), "[Documentation]int[] a");

            node2 = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("M(ref int a){}").Members[0];
            node = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("M(out int a){}").Members[0];
            mutableNode2 = (ParameterSyntax<object>)converter.Visit(node2.ParameterList.Parameters[0]);
            mutableNode.Update(converter.Visit(node.ParameterList.Parameters[0]));
            Assert.AreEqual(mutableNode.GetFullText(), "out int a");
            mutableNode.Delete(mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullText(), "int a");
            mutableNode.Insert(mutableNode2.Modifiers, 1, EntryExtensions.FullRepresentationFormatInfo);
            Assert.AreEqual(mutableNode.GetFullText(), "ref int a");

            node2 = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("M(float a){}").Members[0];
            node = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("M(int a){}").Members[0];
            mutableNode2 = (ParameterSyntax<object>)converter.Visit(node2.ParameterList.Parameters[0]);
            mutableNode.Update(converter.Visit(node.ParameterList.Parameters[0]));
            Assert.AreEqual(mutableNode.GetFullText(), "int a");
            mutableNode.Delete(mutableNode.Type);
            Assert.AreEqual(mutableNode.GetFullText(), "a");
            mutableNode.Insert(mutableNode2.Type, 2, EntryExtensions.FullRepresentationFormatInfo);
            Assert.AreEqual(mutableNode.GetFullText(), "float a");

            node2 = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("M(float b){}").Members[0];
            node = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("M(int a){}").Members[0];
            mutableNode2 = (ParameterSyntax<object>)converter.Visit(node2.ParameterList.Parameters[0]);
            mutableNode.Update(converter.Visit(node.ParameterList.Parameters[0]));
            Assert.AreEqual(mutableNode.GetFullText(), "int a");
            mutableNode.Delete(mutableNode.Identifier);
            Assert.AreEqual(mutableNode.GetFullText(), "int ");
            mutableNode.Insert(mutableNode2.Identifier, 3, EntryExtensions.FullRepresentationFormatInfo);
            Assert.AreEqual(mutableNode.GetFullText(), "int b");

            node2 = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("M(float a = 7){}").Members[0];
            node = (MethodDeclarationSyntax)SyntaxFactory.ParseCompilationUnit("M(int a = 5){}").Members[0];
            mutableNode2 = (ParameterSyntax<object>)converter.Visit(node2.ParameterList.Parameters[0]);
            mutableNode.Update(converter.Visit(node.ParameterList.Parameters[0]));
            Assert.AreEqual(mutableNode.GetFullText(), "int a=5");
            mutableNode.Delete(mutableNode.Default);
            Assert.AreEqual(mutableNode.GetFullText(), "int a");
            mutableNode.Insert(mutableNode2.Default, 4, EntryExtensions.FullRepresentationFormatInfo);
            Assert.AreEqual(mutableNode.GetFullText(), "int a=7");
        }

        [TestMethod]
        public void IncompleteMemberSyntax_Mutable_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();

            var node = SyntaxFactory.ParseCompilationUnit("[Serializable] public a").Members[0];
            var mutableNode = (IncompleteMemberSyntax<object>)converter.Visit(node);
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.IncompleteMember);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serializable]public a");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 0);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 3);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.Type);
            mutableNode = (IncompleteMemberSyntax<object>)mutableNode.Clone();
            Assert.AreEqual(mutableNode.Kind, SyntaxKind.IncompleteMember);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serializable]public a");
            Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 0);
            Assert.AreEqual(mutableNode.GetFullChildren().Count(), 3);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.Type);

            var node2 = SyntaxFactory.ParseCompilationUnit("[Serializable] public a").Members[0];
            node = SyntaxFactory.ParseCompilationUnit("[Documentation] private b").Members[0];
            var mutableNode2 = (IncompleteMemberSyntax<object>)converter.Visit(node2);
            mutableNode.Update(converter.Visit(node));
            Assert.AreEqual(mutableNode.GetFullText(), "[Documentation]private b");
            mutableNode.Delete(mutableNode.AttributeLists);
            Assert.AreEqual(mutableNode.GetFullText(), "private b");
            mutableNode.Insert(mutableNode2.AttributeLists, 0, EntryExtensions.FullRepresentationFormatInfo);
            Assert.AreEqual(mutableNode.GetFullText(), "[Serializable]private b");

            node2 = SyntaxFactory.ParseCompilationUnit("[Serializable] public a").Members[0];
            node = SyntaxFactory.ParseCompilationUnit("[Documentation] private b").Members[0];
            mutableNode2 = (IncompleteMemberSyntax<object>)converter.Visit(node2);
            mutableNode.Update(converter.Visit(node));
            Assert.AreEqual(mutableNode.GetFullText(), "[Documentation]private b");
            mutableNode.Delete(mutableNode.Modifiers);
            Assert.AreEqual(mutableNode.GetFullText(), "[Documentation]b");
            mutableNode.Insert(mutableNode2.Modifiers, 1, EntryExtensions.FullRepresentationFormatInfo);
            Assert.AreEqual(mutableNode.GetFullText(), "[Documentation]public b");

            node2 = SyntaxFactory.ParseCompilationUnit("[Serializable] public a").Members[0];
            node = SyntaxFactory.ParseCompilationUnit("[Documentation] private b").Members[0];
            mutableNode2 = (IncompleteMemberSyntax<object>)converter.Visit(node2);
            mutableNode.Update(converter.Visit(node));
            Assert.AreEqual(mutableNode.GetFullText(), "[Documentation]private b");
            mutableNode.Delete(mutableNode.Type);
            Assert.AreEqual(mutableNode.GetFullText(), "[Documentation]private ");
            mutableNode.Insert(mutableNode2.Type, 2, EntryExtensions.FullRepresentationFormatInfo);
            Assert.AreEqual(mutableNode.GetFullText(), "[Documentation]private a");
        }
    }
}
