using System.Linq;
using System.Xml.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jawilliam.CDF.Tests.CSharp
{
    [TestClass]
    public partial class RoslynMLTests
    {
        [TestMethod]
        public void TypeSyntax_IdentifierNameSyntax_Mutable_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var node = SyntaxFactory.ParseName("var");
            var xElement = converter.Visit(node);
            Assert.AreEqual("<IdentifierName>var</IdentifierName>", xElement.ToString());
        }

        [TestMethod]
        public void TypeSyntax_QualifiedNameSyntax_Mutable_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var node = SyntaxFactory.ParseName("a.b.c");
            var xElement = converter.Visit(node);
            Assert.AreEqual("<QualifiedName>" +
                            "<QualifiedName part=\"Left\">" +
                            "<IdentifierName part=\"Left\">a</IdentifierName>" +
                            "." +
                            "<IdentifierName part=\"Right\">b</IdentifierName>" +
                            "</QualifiedName>" +
                            "." +
                            "<IdentifierName part=\"Right\">c</IdentifierName>" +
                            "</QualifiedName>", xElement.ToString(SaveOptions.DisableFormatting));

            node = SyntaxFactory.ParseName("x.y");
            xElement = converter.Visit(node);
            Assert.AreEqual("<QualifiedName>" +
                            "<IdentifierName part=\"Left\">x</IdentifierName>" +
                            "." +
                            "<IdentifierName part=\"Right\">y</IdentifierName>" +
                            "</QualifiedName>", xElement.ToString(SaveOptions.DisableFormatting));
        }

        [TestMethod]
        public void TypeSyntax_GenericNameSyntax_Mutable_OK()
        {
            var tt = typeof (Microsoft.CodeAnalysis.CSharp.CSharpSyntaxNode)
                .Assembly.GetTypes();

            var c = tt.Where(t => t.Name == "ClassificationHelpers").ToList();

            var currentType = typeof(Microsoft.CodeAnalysis.CSharp.CSharpSyntaxNode)
                .Assembly
                .GetType("Microsoft.CodeAnalysis.CSharp.Classification.ClassificationHelpers");


            var converter = new CDF.CSharp.RoslynML.RoslynML();

            var node = SyntaxFactory.ParseName("a<,>");
            var xElement = converter.Visit(node);

            node = SyntaxFactory.ParseName("a<x,t>");
            xElement = converter.Visit(node);

            node = SyntaxFactory.ParseName("a<x,>");
            xElement = converter.Visit(node);
        }



        //[TestMethod]
        //public void TypeSyntax_AliasQualifiedNameSyntax_Mutable_OK()
        //{
        //    var converter = new CDF.CSharp.RoslynML.RoslynML();
        //    var node = SyntaxFactory.ParseExpression("global::c)");

        //    var mutableNode = (AliasQualifiedNameSyntax<object>)converter.Visit(node);
        //    Assert.AreEqual(mutableNode.Kind, SyntaxKind.AliasQualifiedName);
        //    Assert.AreEqual(mutableNode.GetFullText(), "global::c");
        //    //Assert.AreEqual(mutableNode.Arity, 0);
        //    Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 1);
        //    Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.ColonColonToken);
        //    Assert.AreEqual(mutableNode.GetFullChildren().Count(), 3);
        //    Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.Alias);
        //    Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.ColonColonToken);
        //    Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[2], mutableNode.Name);

        //    var clonedMutableNode = (AliasQualifiedNameSyntax<object>)mutableNode.Clone();
        //    Assert.AreEqual(clonedMutableNode.GetFullText(), "global::c");
        //    //Assert.AreEqual(clonedMutableNode.Arity, 0);
        //    Assert.AreNotSame(clonedMutableNode.Alias, mutableNode.Alias);
        //    Assert.AreEqual(clonedMutableNode.Alias.GetFullText(), mutableNode.Alias.GetFullText());
        //    Assert.AreNotSame(clonedMutableNode.ColonColonToken, mutableNode.ColonColonToken);
        //    Assert.AreEqual(clonedMutableNode.ColonColonToken.Text, mutableNode.ColonColonToken.Text);
        //    Assert.AreNotSame(clonedMutableNode.Name, mutableNode.Name);
        //    Assert.AreEqual(clonedMutableNode.Name.GetFullText(), mutableNode.Name.GetFullText());

        //    node = SyntaxFactory.ParseName("global::x");
        //    mutableNode = (AliasQualifiedNameSyntax<object>)converter.Visit(node);
        //    mutableNode.Insert(converter.Visit(SyntaxFactory.ParseName("otherglobal")), 0, EntryExtensions.FullRepresentationFormatInfo);
        //    Assert.AreEqual(mutableNode.GetFullText(), "otherglobal::x");
        //    mutableNode.Insert(converter.Visit(SyntaxFactory.ParseName("otherglobal1")), 0, EntryExtensions.FullRepresentationFormatInfo);
        //    Assert.AreEqual(mutableNode.GetFullText(), "otherglobal1::x");
        //    mutableNode.Insert(converter.Visit(SyntaxFactory.ParseName("e")), 1, EntryExtensions.FullRepresentationFormatInfo);
        //    Assert.AreEqual(mutableNode.GetFullText(), "otherglobal1::e");
        //    mutableNode.Insert(converter.Visit(SyntaxFactory.ParseName("f")), 1, EntryExtensions.FullRepresentationFormatInfo);
        //    Assert.AreEqual(mutableNode.GetFullText(), "otherglobal1::f");

        //    node = SyntaxFactory.ParseName("global::x");
        //    mutableNode = (AliasQualifiedNameSyntax<object>)converter.Visit(node);
        //    Assert.AreEqual(mutableNode.GetFullText(), "global::x");
        //    mutableNode.Delete(mutableNode.Alias);
        //    Assert.AreEqual(mutableNode.GetFullText(), "::x");
        //    mutableNode.Delete(mutableNode.ColonColonToken);
        //    Assert.AreEqual(mutableNode.GetFullText(), "::x");
        //    mutableNode.Delete(mutableNode.Name);
        //    Assert.AreEqual(mutableNode.GetFullText(), "::");

        //    node = SyntaxFactory.ParseName("globalz::xz");
        //    var mutableNode2 = (AliasQualifiedNameSyntax<object>)converter.Visit(node);
        //    mutableNode.Update(mutableNode2);
        //    Assert.AreEqual(mutableNode.GetFullText(), "globalz::xz");
        //}

        //[TestMethod]
        //public void TypeSyntax_PredefinedTypeSyntax_Mutable_OK()
        //{
        //    var converter = new CDF.CSharp.RoslynML.RoslynML();
        //    var node = SyntaxFactory.ParseTypeName("int");

        //    var mutableNode = (PredefinedTypeSyntax<object>) converter.Visit(node);
        //    Assert.AreEqual(mutableNode.Kind, SyntaxKind.PredefinedType);
        //    Assert.AreEqual(mutableNode.GetFullText(), "int");
        //    Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.Keyword);
        //    Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.Keyword);

        //    var mutableNode2 = (PredefinedTypeSyntax<object>)mutableNode.Clone();
        //    Assert.AreEqual(mutableNode2.GetFullText(), "int");

        //    mutableNode2.Insert(new SyntaxToken<object>(SyntaxFactory.ParseToken("SByte").Kind()) { Text = SyntaxFactory.ParseToken("SByte").Text }, 0, EntryExtensions.FullRepresentationFormatInfo);
        //    Assert.AreEqual(mutableNode2.GetFullText(), "SByte");

        //    mutableNode2.Insert(new SyntaxToken<object>(SyntaxFactory.ParseToken("sbyte").Kind()) { Text = SyntaxFactory.ParseToken("sbyte").Text }, 0, EntryExtensions.TokensRepresentationFormatInfo);
        //    Assert.AreEqual(mutableNode2.GetFullText(), "sbyte");

        //    Assert.AreEqual(mutableNode.GetFullText(), "int");
        //    mutableNode.Update(mutableNode2);
        //    Assert.AreEqual(mutableNode.GetFullText(), "sbyte");
        //    mutableNode.Delete(mutableNode.Keyword);
        //    Assert.AreEqual(mutableNode.GetFullText(), "");
        //}

        //[TestMethod]
        //public void TypeSyntax_ArrayTypeSyntax_Mutable_OK()
        //{
        //    var converter = new CDF.CSharp.RoslynML.RoslynML();

        //    var node = SyntaxFactory.ParseTypeName("int[1]");

        //    var mutableNode = (ArrayTypeSyntax<object>)converter.Visit(node);
        //    Assert.AreEqual(mutableNode.Kind, SyntaxKind.ArrayType);
        //    Assert.AreEqual(mutableNode.GetFullText(), "int[1]");
        //    Assert.AreEqual(mutableNode.GetTokensChildren().Any(), false);
        //    Assert.AreEqual(mutableNode.GetFullChildren().Count(), 2);
        //    Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.ElementType);
        //    Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.RankSpecifiers);

        //    var mutableNode2 = (ArrayTypeSyntax<object>)mutableNode.Clone();
        //    Assert.AreEqual(mutableNode2.GetFullText(), "int[1]");
        //    mutableNode2.Insert(converter.Visit(SyntaxFactory.ParseTypeName("A")), 0, EntryExtensions.FullRepresentationFormatInfo);
        //    Assert.AreEqual(mutableNode2.GetFullText(), "A[1]");
        //    mutableNode2.Insert(((ArrayTypeSyntax<object>)converter.Visit(SyntaxFactory.ParseTypeName("h[3,4,5]"))).RankSpecifiers, 1, EntryExtensions.FullRepresentationFormatInfo);
        //    Assert.AreEqual(mutableNode2.GetFullText(), "A[3,4,5]");
        //    mutableNode2.RankSpecifiers.List[0].Sizes.Delete(mutableNode2.RankSpecifiers.List[0].Sizes.List[1]);
        //    Assert.AreEqual(mutableNode2.GetFullText(), "A[3,5]");
        //    mutableNode2.RankSpecifiers.List[0].Sizes.Delete(mutableNode2.RankSpecifiers.List[0].Sizes.List[1]);
        //    Assert.AreEqual(mutableNode2.GetFullText(), "A[3]");
        //    mutableNode2.RankSpecifiers.List[0].Sizes.Delete(mutableNode2.RankSpecifiers.List[0].Sizes.List[0]);
        //    Assert.AreEqual(mutableNode2.GetFullText(), "A[]");
        //    mutableNode2.RankSpecifiers.List[0].Sizes.Insert(((ArrayTypeSyntax<object>)converter.Visit(SyntaxFactory.ParseTypeName("h[3,4,5]"))).RankSpecifiers.List[0].Sizes.List[2], 0, EntryExtensions.FullRepresentationFormatInfo);
        //    Assert.AreEqual(mutableNode2.GetFullText(), "A[5]");
        //    mutableNode2.RankSpecifiers.List[0].Sizes.Insert(((ArrayTypeSyntax<object>)converter.Visit(SyntaxFactory.ParseTypeName("h[3,4,5]"))).RankSpecifiers.List[0].Sizes.List[0], 1, EntryExtensions.FullRepresentationFormatInfo);
        //    Assert.AreEqual(mutableNode2.GetFullText(), "A[5,3]");
        //    mutableNode2.RankSpecifiers.List[0].Sizes.Insert(((ArrayTypeSyntax<object>)converter.Visit(SyntaxFactory.ParseTypeName("h[3,4,5]"))).RankSpecifiers.List[0].Sizes.List[1], 1, EntryExtensions.FullRepresentationFormatInfo);
        //    Assert.AreEqual(mutableNode2.GetFullText(), "A[5,4,3]");
        //    mutableNode2.Delete(mutableNode2.RankSpecifiers);
        //    Assert.AreEqual(mutableNode2.GetFullText(), "A");

        //    //mutableNode2.Update(mutableNode);
        //    //Assert.AreEqual(mutableNode2.GetFullText(), "int[1]");
        //    //mutableNode2 = (ArrayTypeSyntax<object>)mutableNode.Clone();
        //    //Assert.AreEqual(mutableNode2.GetFullText(), "int[1]");
        //    //mutableNode2.Insert(converter.Visit(SyntaxFactory.ParseName("A")), 0, EntryExtensions.FineRepresentationFormatInfo);
        //    //Assert.AreEqual(mutableNode2.GetFullText(), "A[1]");
        //    //mutableNode2.Insert(((ArrayTypeSyntax<object>)converter.Visit(SyntaxFactory.ParseTypeName("h[3,4,5]"))).RankSpecifiers, 1, EntryExtensions.FineRepresentationFormatInfo);
        //    //Assert.AreEqual(mutableNode2.GetFullText(), "A[3,4,5]");

        //    mutableNode2.Update(mutableNode);
        //    Assert.AreEqual(mutableNode2.GetFullText(), "int[1]");
        //    mutableNode2 = (ArrayTypeSyntax<object>)mutableNode.Clone();
        //    Assert.AreEqual(mutableNode2.GetFullText(), "int[1]");
        //    mutableNode2.Insert(converter.Visit(SyntaxFactory.ParseName("A")), 0, EntryExtensions.FullRepresentationFormatInfo);
        //    Assert.AreEqual(mutableNode2.GetFullText(), "A[1]");
        //    mutableNode2.Insert(((ArrayTypeSyntax<object>)converter.Visit(SyntaxFactory.ParseTypeName("h[3,4,5]"))).RankSpecifiers, 1, EntryExtensions.FullRepresentationFormatInfo);
        //    Assert.AreEqual(mutableNode2.GetFullText(), "A[3,4,5]");
        //}

        //[TestMethod]
        //public void TypeSyntax_PointerTypeSyntax_Mutable_OK()
        //{
        //    var converter = new CDF.CSharp.RoslynML.RoslynML();
        //    var node = SyntaxFactory.ParseTypeName("int*");

        //    var mutableNode = (PointerTypeSyntax<object>)converter.Visit(node);
        //    Assert.AreEqual(mutableNode.Kind, SyntaxKind.PointerType);
        //    Assert.AreEqual(mutableNode.GetFullText(), "int*");
        //    Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 1);
        //    Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.AsteriskToken);
        //    Assert.AreEqual(mutableNode.GetFullChildren().Count(), 2);
        //    Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.ElementType);
        //    Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.AsteriskToken);

        //    var mutableNode2 = (PointerTypeSyntax<object>)mutableNode.Clone();
        //    Assert.AreEqual(mutableNode2.GetFullText(), "int*");

        //    mutableNode2.Insert(converter.Visit(SyntaxFactory.ParseName("SByte")), 0, EntryExtensions.FullRepresentationFormatInfo);
        //    Assert.AreEqual(mutableNode2.GetFullText(), "SByte*");

        //    Assert.AreEqual(mutableNode.GetFullText(), "int*");
        //    mutableNode.Update(mutableNode2);
        //    Assert.AreEqual(mutableNode.GetFullText(), "SByte*");
        //    mutableNode.Delete(mutableNode.AsteriskToken);
        //    Assert.AreEqual(mutableNode.GetFullText(), "SByte*");
        //    mutableNode.Delete(mutableNode.ElementType);
        //    Assert.AreEqual(mutableNode.GetFullText(), "*");
        //}

        //[TestMethod]
        //public void TypeSyntax_NullableTypeSyntax_Mutable_OK()
        //{
        //    var converter = new CDF.CSharp.RoslynML.RoslynML();
        //    var node = SyntaxFactory.ParseTypeName("int?");

        //    var mutableNode = (NullableTypeSyntax<object>)converter.Visit(node);
        //    Assert.AreEqual(mutableNode.Kind, SyntaxKind.NullableType);
        //    Assert.AreEqual(mutableNode.GetFullText(), "int?");
        //    Assert.AreEqual(mutableNode.GetTokensChildren().Count(), 1);
        //    Assert.AreEqual(mutableNode.GetTokensChildren().ToArray()[0], mutableNode.QuestionToken);
        //    Assert.AreEqual(mutableNode.GetFullChildren().Count(), 2);
        //    Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[0], mutableNode.ElementType);
        //    Assert.AreEqual(mutableNode.GetFullChildren().ToArray()[1], mutableNode.QuestionToken);

        //    var mutableNode2 = (NullableTypeSyntax<object>)mutableNode.Clone();
        //    Assert.AreEqual(mutableNode2.GetFullText(), "int?");

        //    mutableNode2.Insert(converter.Visit(SyntaxFactory.ParseName("SByte")), 0, EntryExtensions.FullRepresentationFormatInfo);
        //    Assert.AreEqual(mutableNode2.GetFullText(), "SByte?");

        //    Assert.AreEqual(mutableNode.GetFullText(), "int?");
        //    mutableNode.Update(mutableNode2);
        //    Assert.AreEqual(mutableNode.GetFullText(), "SByte?");
        //    mutableNode.Delete(mutableNode.ElementType);
        //    Assert.AreEqual(mutableNode.GetFullText(), "?");
        //}

        //[TestMethod]
        //public virtual void TypeSyntax_NonEssentialChanges()
        //{
        //    // Predefined name modes
        //    var node = SyntaxFactory.ParseTypeName("Int32");
        //    Assert.AreEqual(node.Kind(), SyntaxKind.IdentifierName);
        //    node = SyntaxFactory.ParseTypeName("System.Int32");
        //    Assert.AreEqual(node.Kind(), SyntaxKind.QualifiedName);
        //    node = SyntaxFactory.ParseTypeName("int");
        //    Assert.AreEqual(node.Kind(), SyntaxKind.PredefinedType);

        //    // Nullable notation variants
        //    node = SyntaxFactory.ParseTypeName("Nullable<int>");
        //    Assert.AreEqual(node.Kind(), SyntaxKind.GenericName);
        //    node = SyntaxFactory.ParseTypeName("System.Nullable<int>");
        //    Assert.AreEqual(node.Kind(), SyntaxKind.QualifiedName);
        //    node = SyntaxFactory.ParseTypeName("int?");
        //    Assert.AreEqual(node.Kind(), SyntaxKind.NullableType);
        //}
    }
}
