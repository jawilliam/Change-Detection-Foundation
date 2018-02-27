using System.Linq;
using System.Xml.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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
            Assert.AreEqual("<IdentifierName Name=\"true\" TypeSyntax=\"true\">" +
                                "<Token kind=\"IdentifierToken\" part=\"Identifier\">var</Token>" +
                            "</IdentifierName>", xElement.ToString(SaveOptions.DisableFormatting));
        }

        [TestMethod]
        public void TypeSyntax_QualifiedNameSyntax_Mutable_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var node = SyntaxFactory.ParseName("a.b.c");
            var xElement = converter.Visit(node);
            Assert.AreEqual("<QualifiedName Name=\"true\" TypeSyntax=\"true\">" +
                                "<QualifiedName Name=\"true\" TypeSyntax=\"true\" part=\"Left\">" +
                                    "<IdentifierName Name=\"true\" TypeSyntax=\"true\" part=\"Left\">" +
                                        "<Token kind=\"IdentifierToken\" part=\"Identifier\">a</Token>" +
                                    "</IdentifierName>" +
                                    "<Token kind=\"DotToken\" Operator=\"true\" part=\"DotToken\">.</Token>" +
                                    "<IdentifierName Name=\"true\" TypeSyntax=\"true\" part=\"Right\">" +
                                        "<Token kind=\"IdentifierToken\" part=\"Identifier\">b</Token>" +
                                    "</IdentifierName>" +
                                "</QualifiedName>" +
                                "<Token kind=\"DotToken\" Operator=\"true\" part=\"DotToken\">.</Token>" +
                                "<IdentifierName Name=\"true\" TypeSyntax=\"true\" part=\"Right\">" +
                                    "<Token kind=\"IdentifierToken\" part=\"Identifier\">c</Token>" +
                                "</IdentifierName>" +
                            "</QualifiedName>", 
                            xElement.ToString(SaveOptions.DisableFormatting));
                              

            node = SyntaxFactory.ParseName("x.y");
            xElement = converter.Visit(node);
            Assert.AreEqual("<QualifiedName Name=\"true\" TypeSyntax=\"true\">" +
                                "<IdentifierName Name=\"true\" TypeSyntax=\"true\" part=\"Left\">" +
                                    "<Token kind=\"IdentifierToken\" part=\"Identifier\">x</Token>" +
                                "</IdentifierName>" +
                                "<Token kind=\"DotToken\" Operator=\"true\" part=\"DotToken\">.</Token>" +
                                "<IdentifierName Name=\"true\" TypeSyntax=\"true\" part=\"Right\">" +
                                    "<Token kind=\"IdentifierToken\" part=\"Identifier\">y</Token>" +
                                "</IdentifierName>" +
                            "</QualifiedName>", xElement.ToString(SaveOptions.DisableFormatting));
        }

        [TestMethod]
        public void TypeSyntax_GenericNameSyntax_Mutable_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();

            var node = SyntaxFactory.ParseName("a<,>");
            var xElement = converter.Visit(node);
            Assert.AreEqual("<GenericName Name=\"true\" TypeSyntax=\"true\">" +
                                "<Token kind=\"IdentifierToken\" part=\"Identifier\">a</Token>" +
                                "<TypeArgumentList part=\"TypeArgumentList\">" +
                                    "<Token kind=\"LessThanToken\" Punctuation=\"true\" Language=\"true\" part=\"LessThanToken\">&lt;</Token>" +
                                    "<SeparatedList_of_Type part=\"Arguments\">" +
                                        "<OmittedTypeArgument>" +
                                            "<Token kind=\"OmittedTypeArgumentToken\" part=\"OmittedTypeArgumentToken\"></Token>" +
                                        "</OmittedTypeArgument>" +
                                        "<OmittedTypeArgument>" +
                                            "<Token kind=\"OmittedTypeArgumentToken\" part=\"OmittedTypeArgumentToken\"></Token>" +
                                        "</OmittedTypeArgument>" +
                                    "</SeparatedList_of_Type>" +
                                    "<Token kind=\"GreaterThanToken\" Punctuation=\"true\" Language=\"true\" part=\"GreaterThanToken\">&gt;</Token>" +
                                "</TypeArgumentList>" +
                            "</GenericName>", xElement.ToString(SaveOptions.DisableFormatting));

            node = SyntaxFactory.ParseName("a<x,t>");
            xElement = converter.Visit(node);
            Assert.AreEqual("<GenericName Name=\"true\" TypeSyntax=\"true\">" +
                                "<Token kind=\"IdentifierToken\" part=\"Identifier\">a</Token>" +
                                "<TypeArgumentList part=\"TypeArgumentList\">" +
                                    "<Token kind=\"LessThanToken\" Punctuation=\"true\" Language=\"true\" part=\"LessThanToken\">&lt;</Token>" +
                                    "<SeparatedList_of_Type part=\"Arguments\">" +
                                        "<IdentifierName Name=\"true\" TypeSyntax=\"true\">" +
                                            "<Token kind=\"IdentifierToken\" part=\"Identifier\">x</Token>" +
                                        "</IdentifierName>" +
                                        "<IdentifierName Name=\"true\" TypeSyntax=\"true\">" +
                                            "<Token kind=\"IdentifierToken\" part=\"Identifier\">t</Token>" +
                                        "</IdentifierName>" +
                                    "</SeparatedList_of_Type>" +
                                    "<Token kind=\"GreaterThanToken\" Punctuation=\"true\" Language=\"true\" part=\"GreaterThanToken\">&gt;</Token>" +
                                "</TypeArgumentList>" +
                            "</GenericName>", xElement.ToString(SaveOptions.DisableFormatting));

            node = SyntaxFactory.ParseName("a<x,>");
            xElement = converter.Visit(node);
            Assert.AreEqual("<GenericName Name=\"true\" TypeSyntax=\"true\">" +
                                "<Token kind=\"IdentifierToken\" part=\"Identifier\">a</Token>" +
                                "<TypeArgumentList part=\"TypeArgumentList\">" +
                                    "<Token kind=\"LessThanToken\" Punctuation=\"true\" Language=\"true\" part=\"LessThanToken\">&lt;</Token>" +
                                    "<SeparatedList_of_Type part=\"Arguments\">" +
                                        "<IdentifierName Name=\"true\" TypeSyntax=\"true\">" +
                                            "<Token kind=\"IdentifierToken\" part=\"Identifier\">x</Token>" +
                                        "</IdentifierName>" +
                                        "<IdentifierName Name=\"true\" TypeSyntax=\"true\">" +
                                            "<Token kind=\"IdentifierToken\" part=\"Identifier\"></Token>" +
                                        "</IdentifierName>" +
                                    "</SeparatedList_of_Type>" +
                                    "<Token kind=\"GreaterThanToken\" Punctuation=\"true\" Language=\"true\" part=\"GreaterThanToken\">&gt;</Token>" +
                                "</TypeArgumentList>" +
                            "</GenericName>", xElement.ToString(SaveOptions.DisableFormatting));
        }



        [TestMethod]
        public void TypeSyntax_AliasQualifiedNameSyntax_Mutable_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var node = SyntaxFactory.ParseExpression("global::c)");
            var xElement = converter.Visit(node);
            Assert.AreEqual("<AliasQualifiedName Name=\"true\" TypeSyntax=\"true\">" +
                                "<IdentifierName Name=\"true\" TypeSyntax=\"true\" part=\"Alias\">" +
                                    "<Token kind=\"GlobalKeyword\" Keyword=\"true\" Contextual=\"true\" part=\"Identifier\">global</Token>" +
                                "</IdentifierName>" +
                                "<Token kind=\"ColonColonToken\" Operator=\"true\" part=\"ColonColonToken\">::</Token>" +
                                "<IdentifierName Name=\"true\" TypeSyntax=\"true\" part=\"Name\">" +
                                    "<Token kind=\"IdentifierToken\" part=\"Identifier\">c</Token>" +
                                "</IdentifierName>" +
                            "</AliasQualifiedName>", xElement.ToString(SaveOptions.DisableFormatting));
        }

        [TestMethod]
        public void TypeSyntax_PredefinedTypeSyntax_Mutable_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var node = SyntaxFactory.ParseTypeName("int");
            var xElement = converter.Visit(node);
            Assert.AreEqual("<PredefinedType TypeSyntax=\"true\">" +
                                "<Token kind=\"IntKeyword\" Keyword=\"true\" part=\"Keyword\">int</Token>" +
                            "</PredefinedType>", xElement.ToString(SaveOptions.DisableFormatting));


            node = SyntaxFactory.ParseTypeName("byte");
            xElement = converter.Visit(node);
            Assert.AreEqual("<PredefinedType TypeSyntax=\"true\">" +
                                "<Token kind=\"ByteKeyword\" Keyword=\"true\" part=\"Keyword\">byte</Token>" +
                            "</PredefinedType>", xElement.ToString(SaveOptions.DisableFormatting));
        }

        [TestMethod]
        public void TypeSyntax_ArrayTypeSyntax_Mutable_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();

            var node = SyntaxFactory.ParseTypeName("int[1, 2]");
            var xElement = converter.Visit(node);
            Assert.AreEqual("<ArrayType TypeSyntax=\"true\">" +
                                "<PredefinedType TypeSyntax=\"true\" part=\"ElementType\">" +
                                    "<Token kind=\"IntKeyword\" Keyword=\"true\" part=\"Keyword\">int</Token>" +
                                "</PredefinedType>" +
                                "<List_of_ArrayRankSpecifier part=\"RankSpecifiers\">" +
                                    "<ArrayRankSpecifier>" +
                                        "<Token kind=\"OpenBracketToken\" Punctuation=\"true\" Language=\"true\" part=\"OpenBracketToken\">[</Token>" +
                                            "<SeparatedList_of_Expression part=\"Sizes\">" +
                                                "<LiteralExpression kind=\"NumericLiteralExpression\">" +
                                                    "<Token kind=\"NumericLiteralToken\" part=\"Token\">1</Token>" +
                                                "</LiteralExpression>" +
                                                "<LiteralExpression kind=\"NumericLiteralExpression\">" +
                                                    "<Token kind=\"NumericLiteralToken\" part=\"Token\">2</Token>" +
                                                "</LiteralExpression>" +
                                            "</SeparatedList_of_Expression>" +
                                        "<Token kind=\"CloseBracketToken\" Punctuation=\"true\" Language=\"true\" part=\"CloseBracketToken\">]</Token>" +
                                    "</ArrayRankSpecifier>" +
                                "</List_of_ArrayRankSpecifier>" +
                            "</ArrayType>", xElement.ToString(SaveOptions.DisableFormatting));

            node = SyntaxFactory.ParseTypeName("int[1][2]");
            xElement = converter.Visit(node);
            Assert.AreEqual("<ArrayType TypeSyntax=\"true\">" +
                                "<PredefinedType TypeSyntax=\"true\" part=\"ElementType\">" +
                                    "<Token kind=\"IntKeyword\" Keyword=\"true\" part=\"Keyword\">int</Token>" +
                                "</PredefinedType>" +
                                "<List_of_ArrayRankSpecifier part=\"RankSpecifiers\">" +
                                    "<ArrayRankSpecifier>" +
                                        "<Token kind=\"OpenBracketToken\" Punctuation=\"true\" Language=\"true\" part=\"OpenBracketToken\">[</Token>" +
                                            "<SeparatedList_of_Expression part=\"Sizes\">" +
                                                "<LiteralExpression kind=\"NumericLiteralExpression\">" +
                                                    "<Token kind=\"NumericLiteralToken\" part=\"Token\">1</Token>" +
                                                "</LiteralExpression>" +
                                            "</SeparatedList_of_Expression>" + 
                                        "<Token kind=\"CloseBracketToken\" Punctuation=\"true\" Language=\"true\" part=\"CloseBracketToken\">]</Token>" +
                                    "</ArrayRankSpecifier>" +
                                    "<ArrayRankSpecifier>" +
                                        "<Token kind=\"OpenBracketToken\" Punctuation=\"true\" Language=\"true\" part=\"OpenBracketToken\">[</Token>" +
                                            "<SeparatedList_of_Expression part=\"Sizes\">" +
                                                "<LiteralExpression kind=\"NumericLiteralExpression\">" +
                                                    "<Token kind=\"NumericLiteralToken\" part=\"Token\">2</Token>" +
                                                "</LiteralExpression>" +
                                            "</SeparatedList_of_Expression>" +
                                        "<Token kind=\"CloseBracketToken\" Punctuation=\"true\" Language=\"true\" part=\"CloseBracketToken\">]</Token>" +
                                    "</ArrayRankSpecifier>" +
                                "</List_of_ArrayRankSpecifier>" +
                            "</ArrayType>", xElement.ToString(SaveOptions.DisableFormatting));
        }

        [TestMethod]
        public void TypeSyntax_PointerTypeSyntax_Mutable_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var node = SyntaxFactory.ParseTypeName("int*");
            var xElement = converter.Visit(node);
            Assert.AreEqual("<PointerType TypeSyntax=\"true\">" +
                                "<PredefinedType TypeSyntax=\"true\" part=\"ElementType\">" +
                                    "<Token kind=\"IntKeyword\" Keyword=\"true\" part=\"Keyword\">int</Token>" +
                                "</PredefinedType>" +
                                "<Token kind=\"AsteriskToken\" Operator=\"true\" part=\"AsteriskToken\">*</Token>" +
                            "</PointerType>", xElement.ToString(SaveOptions.DisableFormatting));
        }

        [TestMethod]
        public void TypeSyntax_NullableTypeSyntax_Mutable_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var node = SyntaxFactory.ParseTypeName("int?");
            var xElement = converter.Visit(node);
            Assert.AreEqual("<NullableType TypeSyntax=\"true\">" +
                                "<PredefinedType TypeSyntax=\"true\" part=\"ElementType\">" +
                                    "<Token kind=\"IntKeyword\" Keyword=\"true\" part=\"Keyword\">int</Token>" +
                                "</PredefinedType>" +
                                "<Token kind=\"QuestionToken\" Operator=\"true\" part=\"QuestionToken\">?</Token>" +
                            "</NullableType>", xElement.ToString(SaveOptions.DisableFormatting));
        }
    }
}
