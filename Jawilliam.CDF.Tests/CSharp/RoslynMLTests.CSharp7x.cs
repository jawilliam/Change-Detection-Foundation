using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Linq;

namespace Jawilliam.CDF.Tests.CSharp
{
    partial class RoslynMLTests
    {
        [TestMethod]
        public void CasePatternSwitchLabelSyntax_Mutable_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var node = (SwitchStatementSyntax)SyntaxFactory.ParseStatement("switch(obj){ case 'a' when obj.Lenght > 0: }");
            var xElement = converter.Visit(((CasePatternSwitchLabelSyntax)node.Sections[0].Labels[0]));
            Assert.AreEqual("<CasePatternSwitchLabel startLine=\"1\" startColumn=\"14\" endLine=\"1\" endColumn=\"42\"><Token kind=\"CaseKeyword\" Keyword=\"true\" startLine=\"1\" startColumn=\"14\" endLine=\"1\" endColumn=\"17\" part=\"Keyword\">case</Token><ConstantPattern startLine=\"1\" startColumn=\"19\" endLine=\"1\" endColumn=\"21\" part=\"Pattern\"><LiteralExpression kind=\"CharacterLiteralExpression\" startLine=\"1\" startColumn=\"19\" endLine=\"1\" endColumn=\"21\" part=\"Expression\"><Token kind=\"CharacterLiteralToken\" startLine=\"1\" startColumn=\"19\" endLine=\"1\" endColumn=\"21\" part=\"Token\">a</Token></LiteralExpression></ConstantPattern><WhenClause startLine=\"1\" startColumn=\"23\" endLine=\"1\" endColumn=\"41\" part=\"WhenClause\"><Token kind=\"WhenKeyword\" Keyword=\"true\" Contextual=\"true\" startLine=\"1\" startColumn=\"23\" endLine=\"1\" endColumn=\"26\" part=\"WhenKeyword\">when</Token><BinaryExpression kind=\"GreaterThanExpression\" startLine=\"1\" startColumn=\"28\" endLine=\"1\" endColumn=\"41\" part=\"Condition\"><MemberAccessExpression kind=\"SimpleMemberAccessExpression\" startLine=\"1\" startColumn=\"28\" endLine=\"1\" endColumn=\"37\" part=\"Left\"><IdentifierName Name=\"true\" TypeSyntax=\"true\" startLine=\"1\" startColumn=\"28\" endLine=\"1\" endColumn=\"30\" part=\"Expression\"><Token kind=\"IdentifierToken\" startLine=\"1\" startColumn=\"28\" endLine=\"1\" endColumn=\"30\" part=\"Identifier\">obj</Token></IdentifierName><Token kind=\"DotToken\" Operator=\"true\" startLine=\"1\" startColumn=\"31\" endLine=\"1\" endColumn=\"31\" part=\"OperatorToken\">.</Token><IdentifierName Name=\"true\" TypeSyntax=\"true\" startLine=\"1\" startColumn=\"32\" endLine=\"1\" endColumn=\"37\" part=\"Name\"><Token kind=\"IdentifierToken\" startLine=\"1\" startColumn=\"32\" endLine=\"1\" endColumn=\"37\" part=\"Identifier\">Lenght</Token></IdentifierName></MemberAccessExpression><Token kind=\"GreaterThanToken\" startLine=\"1\" startColumn=\"39\" endLine=\"1\" endColumn=\"39\" part=\"OperatorToken\">&gt;</Token><LiteralExpression kind=\"NumericLiteralExpression\" startLine=\"1\" startColumn=\"41\" endLine=\"1\" endColumn=\"41\" part=\"Right\"><Token kind=\"NumericLiteralToken\" startLine=\"1\" startColumn=\"41\" endLine=\"1\" endColumn=\"41\" part=\"Token\">0</Token></LiteralExpression></BinaryExpression></WhenClause><Token kind=\"ColonToken\" Punctuation=\"true\" Language=\"true\" startLine=\"1\" startColumn=\"42\" endLine=\"1\" endColumn=\"42\" part=\"ColonToken\">:</Token></CasePatternSwitchLabel>", xElement.ToString(SaveOptions.DisableFormatting));
        }

        [TestMethod]
        public void WhenClauseSyntax_Mutable_OK()
        {
            var converter = new CDF.CSharp.RoslynML.RoslynML();
            var node = (SwitchStatementSyntax)SyntaxFactory.ParseStatement("switch(obj){ case 'a' when obj.Lenght > 0: }");
            var xElement = converter.Visit(((CasePatternSwitchLabelSyntax)node.Sections[0].Labels[0]).WhenClause);
            Assert.AreEqual("<WhenClause startLine=\"1\" startColumn=\"23\" endLine=\"1\" endColumn=\"41\" part=\"WhenClause\"><Token kind=\"WhenKeyword\" Keyword=\"true\" Contextual=\"true\" startLine=\"1\" startColumn=\"23\" endLine=\"1\" endColumn=\"26\" part=\"WhenKeyword\">when</Token><BinaryExpression kind=\"GreaterThanExpression\" startLine=\"1\" startColumn=\"28\" endLine=\"1\" endColumn=\"41\" part=\"Condition\"><MemberAccessExpression kind=\"SimpleMemberAccessExpression\" startLine=\"1\" startColumn=\"28\" endLine=\"1\" endColumn=\"37\" part=\"Left\"><IdentifierName Name=\"true\" TypeSyntax=\"true\" startLine=\"1\" startColumn=\"28\" endLine=\"1\" endColumn=\"30\" part=\"Expression\"><Token kind=\"IdentifierToken\" startLine=\"1\" startColumn=\"28\" endLine=\"1\" endColumn=\"30\" part=\"Identifier\">obj</Token></IdentifierName><Token kind=\"DotToken\" Operator=\"true\" startLine=\"1\" startColumn=\"31\" endLine=\"1\" endColumn=\"31\" part=\"OperatorToken\">.</Token><IdentifierName Name=\"true\" TypeSyntax=\"true\" startLine=\"1\" startColumn=\"32\" endLine=\"1\" endColumn=\"37\" part=\"Name\"><Token kind=\"IdentifierToken\" startLine=\"1\" startColumn=\"32\" endLine=\"1\" endColumn=\"37\" part=\"Identifier\">Lenght</Token></IdentifierName></MemberAccessExpression><Token kind=\"GreaterThanToken\" startLine=\"1\" startColumn=\"39\" endLine=\"1\" endColumn=\"39\" part=\"OperatorToken\">&gt;</Token><LiteralExpression kind=\"NumericLiteralExpression\" startLine=\"1\" startColumn=\"41\" endLine=\"1\" endColumn=\"41\" part=\"Right\"><Token kind=\"NumericLiteralToken\" startLine=\"1\" startColumn=\"41\" endLine=\"1\" endColumn=\"41\" part=\"Token\">0</Token></LiteralExpression></BinaryExpression></WhenClause>", xElement.ToString(SaveOptions.DisableFormatting));
        }
    }
}
