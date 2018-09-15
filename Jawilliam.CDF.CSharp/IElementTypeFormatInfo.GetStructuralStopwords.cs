
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Jawilliam.CDF.CSharp
{
    public partial class AttributeArgumentFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "NameEquals";
    			yield return "NameColon";
    			yield return "Expression";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    }
    
    public partial class NameEqualsFormatInfo : ExpressionFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Name";
    			yield return "EqualsToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "EqualsToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Name";
    		}
    	}
    }
    
    public partial class TypeParameterListFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "LessThanToken";
    			yield return "Parameters";
    			yield return "GreaterThanToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "LessThanToken";
    			yield return "GreaterThanToken";
    		}
    	}
    
    }
    
    public partial class TypeParameterFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "AttributeLists";
    			yield return "VarianceKeyword";
    			yield return "Identifier";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Identifier";
    		}
    	}
    }
    
    public partial class BaseListFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "ColonToken";
    			yield return "Types";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "ColonToken";
    		}
    	}
    
    }
    
    public partial class TypeParameterConstraintClauseFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "WhereKeyword";
    			yield return "Name";
    			yield return "ColonToken";
    			yield return "Constraints";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "WhereKeyword";
    			yield return "ColonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Name";
    		}
    	}
    }
    
    public partial class ExplicitInterfaceSpecifierFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Name";
    			yield return "DotToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "DotToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Name";
    		}
    	}
    }
    
    public partial class ConstructorInitializerFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "ColonToken";
    			yield return "ThisOrBaseKeyword";
    			yield return "ArgumentList";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "ColonToken";
    		}
    	}
    
    }
    
    public partial class ArrowExpressionClauseFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "ArrowToken";
    			yield return "Expression";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "ArrowToken";
    		}
    	}
    
    }
    
    public partial class AccessorListFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "OpenBraceToken";
    			yield return "Accessors";
    			yield return "CloseBraceToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "OpenBraceToken";
    			yield return "CloseBraceToken";
    		}
    	}
    
    }
    
    public partial class AccessorDeclarationFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "AttributeLists";
    			yield return "Modifiers";
    			yield return "Keyword";
    			yield return "Body";
    			yield return "SemicolonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    }
    
    public partial class ParameterFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "AttributeLists";
    			yield return "Modifiers";
    			yield return "Type";
    			yield return "Identifier";
    			yield return "Default";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Identifier";
    		}
    	}
    }
    
    public partial class CrefParameterFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "RefOrOutKeyword";
    			yield return "Type";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    }
    
    public partial class XmlElementStartTagFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "LessThanToken";
    			yield return "Name";
    			yield return "Attributes";
    			yield return "GreaterThanToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "LessThanToken";
    			yield return "GreaterThanToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Name";
    		}
    	}
    }
    
    public partial class XmlElementEndTagFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "LessThanSlashToken";
    			yield return "Name";
    			yield return "GreaterThanToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "LessThanSlashToken";
    			yield return "GreaterThanToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Name";
    		}
    	}
    }
    
    public partial class XmlNameFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Prefix";
    			yield return "LocalName";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    }
    
    public partial class XmlPrefixFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Prefix";
    			yield return "ColonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "ColonToken";
    		}
    	}
    
    }
    
    public partial class TypeArgumentListFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "LessThanToken";
    			yield return "Arguments";
    			yield return "GreaterThanToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "LessThanToken";
    			yield return "GreaterThanToken";
    		}
    	}
    
    }
    
    public partial class ArrayRankSpecifierFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "OpenBracketToken";
    			yield return "Sizes";
    			yield return "CloseBracketToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "OpenBracketToken";
    			yield return "CloseBracketToken";
    		}
    	}
    
    }
    
    public partial class TupleElementFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Type";
    			yield return "Identifier";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Identifier";
    		}
    	}
    }
    
    public partial class ArgumentFormatInfo : ExpressionFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "NameColon";
    			yield return "RefOrOutKeyword";
    			yield return "Expression";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    }
    
    public partial class NameColonFormatInfo : ExpressionFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Name";
    			yield return "ColonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "ColonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Name";
    		}
    	}
    }
    
    public partial class AnonymousObjectMemberDeclaratorFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "NameEquals";
    			yield return "Expression";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    }
    
    public partial class QueryBodyFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Clauses";
    			yield return "SelectOrGroup";
    			yield return "Continuation";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    }
    
    public partial class JoinIntoClauseFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "IntoKeyword";
    			yield return "Identifier";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "IntoKeyword";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Identifier";
    		}
    	}
    }
    
    public partial class OrderingFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Expression";
    			yield return "AscendingOrDescendingKeyword";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "AscendingOrDescendingKeyword";
    		}
    	}
    
    }
    
    public partial class QueryContinuationFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "IntoKeyword";
    			yield return "Identifier";
    			yield return "Body";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "IntoKeyword";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Identifier";
    		}
    	}
    }
    
    public partial class WhenClauseFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "WhenKeyword";
    			yield return "Condition";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "WhenKeyword";
    		}
    	}
    
    }
    
    public partial class InterpolationAlignmentClauseFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "CommaToken";
    			yield return "Value";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "CommaToken";
    		}
    	}
    
    }
    
    public partial class InterpolationFormatClauseFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "ColonToken";
    			yield return "FormatStringToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "ColonToken";
    		}
    	}
    
    }
    
    public partial class VariableDeclarationFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Type";
    			yield return "Variables";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    }
    
    public partial class VariableDeclaratorFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Identifier";
    			yield return "ArgumentList";
    			yield return "Initializer";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Identifier";
    		}
    	}
    }
    
    public partial class EqualsValueClauseFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "EqualsToken";
    			yield return "Value";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "EqualsToken";
    		}
    	}
    
    }
    
    public partial class ElseClauseFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "ElseKeyword";
    			yield return "Statement";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "ElseKeyword";
    		}
    	}
    
    }
    
    public partial class SwitchSectionFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Labels";
    			yield return "Statements";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    }
    
    public partial class CatchClauseFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "CatchKeyword";
    			yield return "Declaration";
    			yield return "Filter";
    			yield return "Block";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "CatchKeyword";
    		}
    	}
    
    }
    
    public partial class CatchDeclarationFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "OpenParenToken";
    			yield return "Type";
    			yield return "Identifier";
    			yield return "CloseParenToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "OpenParenToken";
    			yield return "CloseParenToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Identifier";
    		}
    	}
    }
    
    public partial class CatchFilterClauseFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "WhenKeyword";
    			yield return "OpenParenToken";
    			yield return "FilterExpression";
    			yield return "CloseParenToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "WhenKeyword";
    			yield return "OpenParenToken";
    			yield return "CloseParenToken";
    		}
    	}
    
    }
    
    public partial class FinallyClauseFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "FinallyKeyword";
    			yield return "Block";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "FinallyKeyword";
    		}
    	}
    
    }
    
    public partial class CompilationUnitFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Externs";
    			yield return "Usings";
    			yield return "AttributeLists";
    			yield return "Members";
    			yield return "EndOfFileToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "EndOfFileToken";
    		}
    	}
    
    }
    
    public partial class ExternAliasDirectiveFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "ExternKeyword";
    			yield return "AliasKeyword";
    			yield return "Identifier";
    			yield return "SemicolonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "ExternKeyword";
    			yield return "AliasKeyword";
    			yield return "SemicolonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Identifier";
    		}
    	}
    }
    
    public partial class UsingDirectiveFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "UsingKeyword";
    			yield return "StaticKeyword";
    			yield return "Alias";
    			yield return "Name";
    			yield return "SemicolonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "UsingKeyword";
    			yield return "SemicolonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Name";
    		}
    	}
    }
    
    public partial class AttributeListFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "OpenBracketToken";
    			yield return "Target";
    			yield return "Attributes";
    			yield return "CloseBracketToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "OpenBracketToken";
    			yield return "CloseBracketToken";
    		}
    	}
    
    }
    
    public partial class AttributeTargetSpecifierFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Identifier";
    			yield return "ColonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "ColonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Identifier";
    		}
    	}
    }
    
    public partial class AttributeFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Name";
    			yield return "ArgumentList";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Name";
    		}
    	}
    }
    
    public partial class AttributeArgumentListFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "OpenParenToken";
    			yield return "Arguments";
    			yield return "CloseParenToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "OpenParenToken";
    			yield return "CloseParenToken";
    		}
    	}
    
    }
    
    public partial class DelegateDeclarationFormatInfo : MemberDeclarationFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "AttributeLists";
    			yield return "Modifiers";
    			yield return "DelegateKeyword";
    			yield return "ReturnType";
    			yield return "Identifier";
    			yield return "TypeParameterList";
    			yield return "ParameterList";
    			yield return "ConstraintClauses";
    			yield return "SemicolonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "DelegateKeyword";
    			yield return "SemicolonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Identifier";
    		}
    	}
    }
    
    public partial class EnumMemberDeclarationFormatInfo : MemberDeclarationFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "AttributeLists";
    			yield return "Identifier";
    			yield return "EqualsValue";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Identifier";
    		}
    	}
    }
    
    public partial class IncompleteMemberFormatInfo : MemberDeclarationFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "AttributeLists";
    			yield return "Modifiers";
    			yield return "Type";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    }
    
    public partial class GlobalStatementFormatInfo : MemberDeclarationFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Statement";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    }
    
    public partial class NamespaceDeclarationFormatInfo : MemberDeclarationFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "NamespaceKeyword";
    			yield return "Name";
    			yield return "OpenBraceToken";
    			yield return "Externs";
    			yield return "Usings";
    			yield return "Members";
    			yield return "CloseBraceToken";
    			yield return "SemicolonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "NamespaceKeyword";
    			yield return "OpenBraceToken";
    			yield return "CloseBraceToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Name";
    		}
    	}
    }
    
    public partial class EnumDeclarationFormatInfo : BaseTypeDeclarationFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "AttributeLists";
    			yield return "Modifiers";
    			yield return "EnumKeyword";
    			yield return "Identifier";
    			yield return "BaseList";
    			yield return "OpenBraceToken";
    			yield return "Members";
    			yield return "CloseBraceToken";
    			yield return "SemicolonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "EnumKeyword";
    			yield return "OpenBraceToken";
    			yield return "CloseBraceToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Identifier";
    		}
    	}
    }
    
    public partial class ClassDeclarationFormatInfo : TypeDeclarationFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "AttributeLists";
    			yield return "Modifiers";
    			yield return "Keyword";
    			yield return "Identifier";
    			yield return "TypeParameterList";
    			yield return "BaseList";
    			yield return "ConstraintClauses";
    			yield return "OpenBraceToken";
    			yield return "Members";
    			yield return "CloseBraceToken";
    			yield return "SemicolonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "Keyword";
    			yield return "OpenBraceToken";
    			yield return "CloseBraceToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Identifier";
    		}
    	}
    }
    
    public partial class StructDeclarationFormatInfo : TypeDeclarationFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "AttributeLists";
    			yield return "Modifiers";
    			yield return "Keyword";
    			yield return "Identifier";
    			yield return "TypeParameterList";
    			yield return "BaseList";
    			yield return "ConstraintClauses";
    			yield return "OpenBraceToken";
    			yield return "Members";
    			yield return "CloseBraceToken";
    			yield return "SemicolonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "Keyword";
    			yield return "OpenBraceToken";
    			yield return "CloseBraceToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Identifier";
    		}
    	}
    }
    
    public partial class InterfaceDeclarationFormatInfo : TypeDeclarationFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "AttributeLists";
    			yield return "Modifiers";
    			yield return "Keyword";
    			yield return "Identifier";
    			yield return "TypeParameterList";
    			yield return "BaseList";
    			yield return "ConstraintClauses";
    			yield return "OpenBraceToken";
    			yield return "Members";
    			yield return "CloseBraceToken";
    			yield return "SemicolonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "Keyword";
    			yield return "OpenBraceToken";
    			yield return "CloseBraceToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Identifier";
    		}
    	}
    }
    
    public abstract partial class TypeDeclarationFormatInfo : BaseTypeDeclarationFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Keyword";
    			yield return "TypeParameterList";
    			yield return "ConstraintClauses";
    			yield return "Members";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "Keyword";
    		}
    	}
    
    }
    
    public abstract partial class BaseTypeDeclarationFormatInfo : MemberDeclarationFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "AttributeLists";
    			yield return "Modifiers";
    			yield return "Identifier";
    			yield return "BaseList";
    			yield return "OpenBraceToken";
    			yield return "CloseBraceToken";
    			yield return "SemicolonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "OpenBraceToken";
    			yield return "CloseBraceToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Identifier";
    		}
    	}
    }
    
    public partial class FieldDeclarationFormatInfo : BaseFieldDeclarationFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "AttributeLists";
    			yield return "Modifiers";
    			yield return "Declaration";
    			yield return "SemicolonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "SemicolonToken";
    		}
    	}
    
    }
    
    public partial class EventFieldDeclarationFormatInfo : BaseFieldDeclarationFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "AttributeLists";
    			yield return "Modifiers";
    			yield return "EventKeyword";
    			yield return "Declaration";
    			yield return "SemicolonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "EventKeyword";
    			yield return "SemicolonToken";
    		}
    	}
    
    }
    
    public abstract partial class BaseFieldDeclarationFormatInfo : MemberDeclarationFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "AttributeLists";
    			yield return "Modifiers";
    			yield return "Declaration";
    			yield return "SemicolonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "SemicolonToken";
    		}
    	}
    
    }
    
    public partial class MethodDeclarationFormatInfo : BaseMethodDeclarationFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "AttributeLists";
    			yield return "Modifiers";
    			yield return "ReturnType";
    			yield return "ExplicitInterfaceSpecifier";
    			yield return "Identifier";
    			yield return "TypeParameterList";
    			yield return "ParameterList";
    			yield return "ConstraintClauses";
    			yield return "Body";
    			yield return "ExpressionBody";
    			yield return "SemicolonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Identifier";
    		}
    	}
    }
    
    public partial class OperatorDeclarationFormatInfo : BaseMethodDeclarationFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "AttributeLists";
    			yield return "Modifiers";
    			yield return "ReturnType";
    			yield return "OperatorKeyword";
    			yield return "OperatorToken";
    			yield return "ParameterList";
    			yield return "Body";
    			yield return "ExpressionBody";
    			yield return "SemicolonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "OperatorKeyword";
    		}
    	}
    
    }
    
    public partial class ConversionOperatorDeclarationFormatInfo : BaseMethodDeclarationFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "AttributeLists";
    			yield return "Modifiers";
    			yield return "ImplicitOrExplicitKeyword";
    			yield return "OperatorKeyword";
    			yield return "Type";
    			yield return "ParameterList";
    			yield return "Body";
    			yield return "ExpressionBody";
    			yield return "SemicolonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "OperatorKeyword";
    		}
    	}
    
    }
    
    public partial class ConstructorDeclarationFormatInfo : BaseMethodDeclarationFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "AttributeLists";
    			yield return "Modifiers";
    			yield return "Identifier";
    			yield return "ParameterList";
    			yield return "Initializer";
    			yield return "Body";
    			yield return "SemicolonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Identifier";
    		}
    	}
    }
    
    public partial class DestructorDeclarationFormatInfo : BaseMethodDeclarationFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "AttributeLists";
    			yield return "Modifiers";
    			yield return "TildeToken";
    			yield return "Identifier";
    			yield return "ParameterList";
    			yield return "Body";
    			yield return "SemicolonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "Modifiers";
    			yield return "TildeToken";
    			yield return "ParameterList";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Identifier";
    		}
    	}
    }
    
    public abstract partial class BaseMethodDeclarationFormatInfo : MemberDeclarationFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "AttributeLists";
    			yield return "Modifiers";
    			yield return "ParameterList";
    			yield return "Body";
    			yield return "SemicolonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    }
    
    public partial class PropertyDeclarationFormatInfo : BasePropertyDeclarationFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "AttributeLists";
    			yield return "Modifiers";
    			yield return "Type";
    			yield return "ExplicitInterfaceSpecifier";
    			yield return "Identifier";
    			yield return "AccessorList";
    			yield return "ExpressionBody";
    			yield return "Initializer";
    			yield return "SemicolonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Identifier";
    		}
    	}
    }
    
    public partial class EventDeclarationFormatInfo : BasePropertyDeclarationFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "AttributeLists";
    			yield return "Modifiers";
    			yield return "EventKeyword";
    			yield return "Type";
    			yield return "ExplicitInterfaceSpecifier";
    			yield return "Identifier";
    			yield return "AccessorList";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "EventKeyword";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Identifier";
    		}
    	}
    }
    
    public partial class IndexerDeclarationFormatInfo : BasePropertyDeclarationFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "AttributeLists";
    			yield return "Modifiers";
    			yield return "Type";
    			yield return "ExplicitInterfaceSpecifier";
    			yield return "ThisKeyword";
    			yield return "ParameterList";
    			yield return "AccessorList";
    			yield return "ExpressionBody";
    			yield return "SemicolonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "ThisKeyword";
    		}
    	}
    
    }
    
    public abstract partial class BasePropertyDeclarationFormatInfo : MemberDeclarationFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "AttributeLists";
    			yield return "Modifiers";
    			yield return "Type";
    			yield return "ExplicitInterfaceSpecifier";
    			yield return "AccessorList";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    }
    
    public abstract partial class MemberDeclarationFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    }
    
    public partial class SimpleBaseTypeFormatInfo : BaseTypeFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Type";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    }
    
    public abstract partial class BaseTypeFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Type";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    }
    
    public partial class ConstructorConstraintFormatInfo : TypeParameterConstraintFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "NewKeyword";
    			yield return "OpenParenToken";
    			yield return "CloseParenToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "NewKeyword";
    			yield return "OpenParenToken";
    			yield return "CloseParenToken";
    		}
    	}
    
    }
    
    public partial class ClassOrStructConstraintFormatInfo : TypeParameterConstraintFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "ClassOrStructKeyword";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    }
    
    public partial class TypeConstraintFormatInfo : TypeParameterConstraintFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Type";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    }
    
    public abstract partial class TypeParameterConstraintFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    }
    
    public partial class ParameterListFormatInfo : BaseParameterListFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "OpenParenToken";
    			yield return "Parameters";
    			yield return "CloseParenToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "OpenParenToken";
    			yield return "CloseParenToken";
    		}
    	}
    
    }
    
    public partial class BracketedParameterListFormatInfo : BaseParameterListFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "OpenBracketToken";
    			yield return "Parameters";
    			yield return "CloseBracketToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "OpenBracketToken";
    			yield return "CloseBracketToken";
    		}
    	}
    
    }
    
    public abstract partial class BaseParameterListFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Parameters";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    }
    
    public partial class SkippedTokensTriviaFormatInfo : StructuredTriviaFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Tokens";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    }
    
    public partial class DocumentationCommentTriviaFormatInfo : StructuredTriviaFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Content";
    			yield return "EndOfComment";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "EndOfComment";
    		}
    	}
    
    }
    
    public partial class EndIfDirectiveTriviaFormatInfo : DirectiveTriviaFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "HashToken";
    			yield return "EndIfKeyword";
    			yield return "EndOfDirectiveToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "HashToken";
    			yield return "EndIfKeyword";
    			yield return "EndOfDirectiveToken";
    		}
    	}
    
    }
    
    public partial class RegionDirectiveTriviaFormatInfo : DirectiveTriviaFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "HashToken";
    			yield return "RegionKeyword";
    			yield return "EndOfDirectiveToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "HashToken";
    			yield return "RegionKeyword";
    			yield return "EndOfDirectiveToken";
    		}
    	}
    
    }
    
    public partial class EndRegionDirectiveTriviaFormatInfo : DirectiveTriviaFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "HashToken";
    			yield return "EndRegionKeyword";
    			yield return "EndOfDirectiveToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "HashToken";
    			yield return "EndRegionKeyword";
    			yield return "EndOfDirectiveToken";
    		}
    	}
    
    }
    
    public partial class ErrorDirectiveTriviaFormatInfo : DirectiveTriviaFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "HashToken";
    			yield return "ErrorKeyword";
    			yield return "EndOfDirectiveToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "HashToken";
    			yield return "ErrorKeyword";
    			yield return "EndOfDirectiveToken";
    		}
    	}
    
    }
    
    public partial class WarningDirectiveTriviaFormatInfo : DirectiveTriviaFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "HashToken";
    			yield return "WarningKeyword";
    			yield return "EndOfDirectiveToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "HashToken";
    			yield return "WarningKeyword";
    			yield return "EndOfDirectiveToken";
    		}
    	}
    
    }
    
    public partial class BadDirectiveTriviaFormatInfo : DirectiveTriviaFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "HashToken";
    			yield return "Identifier";
    			yield return "EndOfDirectiveToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "HashToken";
    			yield return "EndOfDirectiveToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Identifier";
    		}
    	}
    }
    
    public partial class DefineDirectiveTriviaFormatInfo : DirectiveTriviaFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "HashToken";
    			yield return "DefineKeyword";
    			yield return "Name";
    			yield return "EndOfDirectiveToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "HashToken";
    			yield return "DefineKeyword";
    			yield return "EndOfDirectiveToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Name";
    		}
    	}
    }
    
    public partial class UndefDirectiveTriviaFormatInfo : DirectiveTriviaFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "HashToken";
    			yield return "UndefKeyword";
    			yield return "Name";
    			yield return "EndOfDirectiveToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "HashToken";
    			yield return "UndefKeyword";
    			yield return "EndOfDirectiveToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Name";
    		}
    	}
    }
    
    public partial class LineDirectiveTriviaFormatInfo : DirectiveTriviaFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "HashToken";
    			yield return "LineKeyword";
    			yield return "Line";
    			yield return "File";
    			yield return "EndOfDirectiveToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "HashToken";
    			yield return "LineKeyword";
    			yield return "EndOfDirectiveToken";
    		}
    	}
    
    }
    
    public partial class PragmaWarningDirectiveTriviaFormatInfo : DirectiveTriviaFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "HashToken";
    			yield return "PragmaKeyword";
    			yield return "WarningKeyword";
    			yield return "DisableOrRestoreKeyword";
    			yield return "ErrorCodes";
    			yield return "EndOfDirectiveToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "HashToken";
    			yield return "PragmaKeyword";
    			yield return "WarningKeyword";
    			yield return "EndOfDirectiveToken";
    		}
    	}
    
    }
    
    public partial class PragmaChecksumDirectiveTriviaFormatInfo : DirectiveTriviaFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "HashToken";
    			yield return "PragmaKeyword";
    			yield return "ChecksumKeyword";
    			yield return "File";
    			yield return "Guid";
    			yield return "Bytes";
    			yield return "EndOfDirectiveToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "HashToken";
    			yield return "PragmaKeyword";
    			yield return "ChecksumKeyword";
    			yield return "EndOfDirectiveToken";
    		}
    	}
    
    }
    
    public partial class ReferenceDirectiveTriviaFormatInfo : DirectiveTriviaFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "HashToken";
    			yield return "ReferenceKeyword";
    			yield return "File";
    			yield return "EndOfDirectiveToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "HashToken";
    			yield return "ReferenceKeyword";
    			yield return "EndOfDirectiveToken";
    		}
    	}
    
    }
    
    public partial class LoadDirectiveTriviaFormatInfo : DirectiveTriviaFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "HashToken";
    			yield return "LoadKeyword";
    			yield return "File";
    			yield return "EndOfDirectiveToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "HashToken";
    			yield return "LoadKeyword";
    			yield return "EndOfDirectiveToken";
    		}
    	}
    
    }
    
    public partial class ShebangDirectiveTriviaFormatInfo : DirectiveTriviaFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "HashToken";
    			yield return "ExclamationToken";
    			yield return "EndOfDirectiveToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "HashToken";
    			yield return "ExclamationToken";
    			yield return "EndOfDirectiveToken";
    		}
    	}
    
    }
    
    public partial class ElseDirectiveTriviaFormatInfo : BranchingDirectiveTriviaFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "HashToken";
    			yield return "ElseKeyword";
    			yield return "EndOfDirectiveToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "HashToken";
    			yield return "ElseKeyword";
    			yield return "EndOfDirectiveToken";
    		}
    	}
    
    }
    
    public partial class IfDirectiveTriviaFormatInfo : ConditionalDirectiveTriviaFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "HashToken";
    			yield return "IfKeyword";
    			yield return "Condition";
    			yield return "EndOfDirectiveToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "HashToken";
    			yield return "IfKeyword";
    			yield return "EndOfDirectiveToken";
    		}
    	}
    
    }
    
    public partial class ElifDirectiveTriviaFormatInfo : ConditionalDirectiveTriviaFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "HashToken";
    			yield return "ElifKeyword";
    			yield return "Condition";
    			yield return "EndOfDirectiveToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "HashToken";
    			yield return "ElifKeyword";
    			yield return "EndOfDirectiveToken";
    		}
    	}
    
    }
    
    public abstract partial class ConditionalDirectiveTriviaFormatInfo : BranchingDirectiveTriviaFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Condition";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    }
    
    public abstract partial class BranchingDirectiveTriviaFormatInfo : DirectiveTriviaFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    }
    
    public abstract partial class DirectiveTriviaFormatInfo : StructuredTriviaFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "HashToken";
    			yield return "EndOfDirectiveToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "HashToken";
    			yield return "EndOfDirectiveToken";
    		}
    	}
    
    }
    
    public abstract partial class StructuredTriviaFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    }
    
    public partial class TypeCrefFormatInfo : CrefFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Type";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    }
    
    public partial class QualifiedCrefFormatInfo : CrefFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Container";
    			yield return "DotToken";
    			yield return "Member";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "DotToken";
    		}
    	}
    
    }
    
    public partial class NameMemberCrefFormatInfo : MemberCrefFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Name";
    			yield return "Parameters";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Name";
    		}
    	}
    }
    
    public partial class IndexerMemberCrefFormatInfo : MemberCrefFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "ThisKeyword";
    			yield return "Parameters";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "ThisKeyword";
    		}
    	}
    
    }
    
    public partial class OperatorMemberCrefFormatInfo : MemberCrefFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "OperatorKeyword";
    			yield return "OperatorToken";
    			yield return "Parameters";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "OperatorKeyword";
    		}
    	}
    
    }
    
    public partial class ConversionOperatorMemberCrefFormatInfo : MemberCrefFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "ImplicitOrExplicitKeyword";
    			yield return "OperatorKeyword";
    			yield return "Type";
    			yield return "Parameters";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "OperatorKeyword";
    		}
    	}
    
    }
    
    public abstract partial class MemberCrefFormatInfo : CrefFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    }
    
    public abstract partial class CrefFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    }
    
    public partial class CrefParameterListFormatInfo : BaseCrefParameterListFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "OpenParenToken";
    			yield return "Parameters";
    			yield return "CloseParenToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "OpenParenToken";
    			yield return "CloseParenToken";
    		}
    	}
    
    }
    
    public partial class CrefBracketedParameterListFormatInfo : BaseCrefParameterListFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "OpenBracketToken";
    			yield return "Parameters";
    			yield return "CloseBracketToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "OpenBracketToken";
    			yield return "CloseBracketToken";
    		}
    	}
    
    }
    
    public abstract partial class BaseCrefParameterListFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Parameters";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    }
    
    public partial class XmlElementFormatInfo : XmlNodeFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "StartTag";
    			yield return "Content";
    			yield return "EndTag";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    }
    
    public partial class XmlEmptyElementFormatInfo : XmlNodeFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "LessThanToken";
    			yield return "Name";
    			yield return "Attributes";
    			yield return "SlashGreaterThanToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "LessThanToken";
    			yield return "SlashGreaterThanToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Name";
    		}
    	}
    }
    
    public partial class XmlTextFormatInfo : XmlNodeFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "TextTokens";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    }
    
    public partial class XmlCDataSectionFormatInfo : XmlNodeFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "StartCDataToken";
    			yield return "TextTokens";
    			yield return "EndCDataToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "StartCDataToken";
    			yield return "EndCDataToken";
    		}
    	}
    
    }
    
    public partial class XmlProcessingInstructionFormatInfo : XmlNodeFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "StartProcessingInstructionToken";
    			yield return "Name";
    			yield return "TextTokens";
    			yield return "EndProcessingInstructionToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "StartProcessingInstructionToken";
    			yield return "EndProcessingInstructionToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Name";
    		}
    	}
    }
    
    public partial class XmlCommentFormatInfo : XmlNodeFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "LessThanExclamationMinusMinusToken";
    			yield return "TextTokens";
    			yield return "MinusMinusGreaterThanToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "LessThanExclamationMinusMinusToken";
    			yield return "MinusMinusGreaterThanToken";
    		}
    	}
    
    }
    
    public abstract partial class XmlNodeFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    }
    
    public partial class XmlTextAttributeFormatInfo : XmlAttributeFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Name";
    			yield return "EqualsToken";
    			yield return "StartQuoteToken";
    			yield return "TextTokens";
    			yield return "EndQuoteToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "EqualsToken";
    			yield return "StartQuoteToken";
    			yield return "EndQuoteToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Name";
    		}
    	}
    }
    
    public partial class XmlCrefAttributeFormatInfo : XmlAttributeFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Name";
    			yield return "EqualsToken";
    			yield return "StartQuoteToken";
    			yield return "Cref";
    			yield return "EndQuoteToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "Name";
    			yield return "EqualsToken";
    			yield return "StartQuoteToken";
    			yield return "EndQuoteToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Name";
    		}
    	}
    }
    
    public partial class XmlNameAttributeFormatInfo : XmlAttributeFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Name";
    			yield return "EqualsToken";
    			yield return "StartQuoteToken";
    			yield return "Identifier";
    			yield return "EndQuoteToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "Name";
    			yield return "EqualsToken";
    			yield return "StartQuoteToken";
    			yield return "EndQuoteToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Name";
    			yield return "Identifier";
    		}
    	}
    }
    
    public abstract partial class XmlAttributeFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Name";
    			yield return "EqualsToken";
    			yield return "StartQuoteToken";
    			yield return "EndQuoteToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "EqualsToken";
    			yield return "StartQuoteToken";
    			yield return "EndQuoteToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Name";
    		}
    	}
    }
    
    public partial class ParenthesizedExpressionFormatInfo : ExpressionFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "OpenParenToken";
    			yield return "Expression";
    			yield return "CloseParenToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "OpenParenToken";
    			yield return "CloseParenToken";
    		}
    	}
    
    }
    
    public partial class TupleExpressionFormatInfo : ExpressionFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "OpenParenToken";
    			yield return "Arguments";
    			yield return "CloseParenToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "OpenParenToken";
    			yield return "CloseParenToken";
    		}
    	}
    
    }
    
    public partial class PrefixUnaryExpressionFormatInfo : ExpressionFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "OperatorToken";
    			yield return "Operand";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    }
    
    public partial class AwaitExpressionFormatInfo : ExpressionFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "AwaitKeyword";
    			yield return "Expression";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "AwaitKeyword";
    		}
    	}
    
    }
    
    public partial class PostfixUnaryExpressionFormatInfo : ExpressionFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Operand";
    			yield return "OperatorToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    }
    
    public partial class MemberAccessExpressionFormatInfo : ExpressionFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Expression";
    			yield return "OperatorToken";
    			yield return "Name";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Name";
    		}
    	}
    }
    
    public partial class ConditionalAccessExpressionFormatInfo : ExpressionFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Expression";
    			yield return "OperatorToken";
    			yield return "WhenNotNull";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "OperatorToken";
    		}
    	}
    
    }
    
    public partial class MemberBindingExpressionFormatInfo : ExpressionFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "OperatorToken";
    			yield return "Name";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "OperatorToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Name";
    		}
    	}
    }
    
    public partial class ElementBindingExpressionFormatInfo : ExpressionFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "ArgumentList";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    }
    
    public partial class ImplicitElementAccessFormatInfo : ExpressionFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "ArgumentList";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    }
    
    public partial class BinaryExpressionFormatInfo : ExpressionFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Left";
    			yield return "OperatorToken";
    			yield return "Right";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    }
    
    public partial class AssignmentExpressionFormatInfo : ExpressionFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Left";
    			yield return "OperatorToken";
    			yield return "Right";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    }
    
    public partial class ConditionalExpressionFormatInfo : ExpressionFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Condition";
    			yield return "QuestionToken";
    			yield return "WhenTrue";
    			yield return "ColonToken";
    			yield return "WhenFalse";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "QuestionToken";
    			yield return "ColonToken";
    		}
    	}
    
    }
    
    public partial class LiteralExpressionFormatInfo : ExpressionFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Token";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    }
    
    public partial class MakeRefExpressionFormatInfo : ExpressionFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Keyword";
    			yield return "OpenParenToken";
    			yield return "Expression";
    			yield return "CloseParenToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "Keyword";
    			yield return "OpenParenToken";
    			yield return "CloseParenToken";
    		}
    	}
    
    }
    
    public partial class RefTypeExpressionFormatInfo : ExpressionFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Keyword";
    			yield return "OpenParenToken";
    			yield return "Expression";
    			yield return "CloseParenToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "Keyword";
    			yield return "OpenParenToken";
    			yield return "CloseParenToken";
    		}
    	}
    
    }
    
    public partial class RefValueExpressionFormatInfo : ExpressionFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Keyword";
    			yield return "OpenParenToken";
    			yield return "Expression";
    			yield return "Comma";
    			yield return "Type";
    			yield return "CloseParenToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "Keyword";
    			yield return "OpenParenToken";
    			yield return "Comma";
    			yield return "CloseParenToken";
    		}
    	}
    
    }
    
    public partial class CheckedExpressionFormatInfo : ExpressionFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Keyword";
    			yield return "OpenParenToken";
    			yield return "Expression";
    			yield return "CloseParenToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "OpenParenToken";
    			yield return "CloseParenToken";
    		}
    	}
    
    }
    
    public partial class DefaultExpressionFormatInfo : ExpressionFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Keyword";
    			yield return "OpenParenToken";
    			yield return "Type";
    			yield return "CloseParenToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "Keyword";
    			yield return "OpenParenToken";
    			yield return "CloseParenToken";
    		}
    	}
    
    }
    
    public partial class TypeOfExpressionFormatInfo : ExpressionFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Keyword";
    			yield return "OpenParenToken";
    			yield return "Type";
    			yield return "CloseParenToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "Keyword";
    			yield return "OpenParenToken";
    			yield return "CloseParenToken";
    		}
    	}
    
    }
    
    public partial class SizeOfExpressionFormatInfo : ExpressionFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Keyword";
    			yield return "OpenParenToken";
    			yield return "Type";
    			yield return "CloseParenToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "Keyword";
    			yield return "OpenParenToken";
    			yield return "CloseParenToken";
    		}
    	}
    
    }
    
    public partial class InvocationExpressionFormatInfo : ExpressionFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Expression";
    			yield return "ArgumentList";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    }
    
    public partial class ElementAccessExpressionFormatInfo : ExpressionFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Expression";
    			yield return "ArgumentList";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    }
    
    public partial class DeclarationExpressionFormatInfo : ExpressionFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Type";
    			yield return "Designation";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    }
    
    public partial class CastExpressionFormatInfo : ExpressionFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "OpenParenToken";
    			yield return "Type";
    			yield return "CloseParenToken";
    			yield return "Expression";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "OpenParenToken";
    			yield return "CloseParenToken";
    		}
    	}
    
    }
    
    public partial class RefExpressionFormatInfo : ExpressionFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "RefKeyword";
    			yield return "Expression";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "RefKeyword";
    		}
    	}
    
    }
    
    public partial class InitializerExpressionFormatInfo : ExpressionFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "OpenBraceToken";
    			yield return "Expressions";
    			yield return "CloseBraceToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "OpenBraceToken";
    			yield return "CloseBraceToken";
    		}
    	}
    
    }
    
    public partial class ObjectCreationExpressionFormatInfo : ExpressionFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "NewKeyword";
    			yield return "Type";
    			yield return "ArgumentList";
    			yield return "Initializer";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "NewKeyword";
    		}
    	}
    
    }
    
    public partial class AnonymousObjectCreationExpressionFormatInfo : ExpressionFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "NewKeyword";
    			yield return "OpenBraceToken";
    			yield return "Initializers";
    			yield return "CloseBraceToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "NewKeyword";
    			yield return "OpenBraceToken";
    			yield return "CloseBraceToken";
    		}
    	}
    
    }
    
    public partial class ArrayCreationExpressionFormatInfo : ExpressionFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "NewKeyword";
    			yield return "Type";
    			yield return "Initializer";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "NewKeyword";
    		}
    	}
    
    }
    
    public partial class ImplicitArrayCreationExpressionFormatInfo : ExpressionFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "NewKeyword";
    			yield return "OpenBracketToken";
    			yield return "Commas";
    			yield return "CloseBracketToken";
    			yield return "Initializer";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "NewKeyword";
    			yield return "OpenBracketToken";
    			yield return "CloseBracketToken";
    		}
    	}
    
    }
    
    public partial class StackAllocArrayCreationExpressionFormatInfo : ExpressionFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "StackAllocKeyword";
    			yield return "Type";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "StackAllocKeyword";
    		}
    	}
    
    }
    
    public partial class QueryExpressionFormatInfo : ExpressionFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "FromClause";
    			yield return "Body";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    }
    
    public partial class OmittedArraySizeExpressionFormatInfo : ExpressionFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "OmittedArraySizeExpressionToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "OmittedArraySizeExpressionToken";
    		}
    	}
    
    }
    
    public partial class InterpolatedStringExpressionFormatInfo : ExpressionFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "StringStartToken";
    			yield return "Contents";
    			yield return "StringEndToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "StringStartToken";
    			yield return "StringEndToken";
    		}
    	}
    
    }
    
    public partial class IsPatternExpressionFormatInfo : ExpressionFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Expression";
    			yield return "IsKeyword";
    			yield return "Pattern";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "IsKeyword";
    		}
    	}
    
    }
    
    public partial class ThrowExpressionFormatInfo : ExpressionFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "ThrowKeyword";
    			yield return "Expression";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "ThrowKeyword";
    		}
    	}
    
    }
    
    public partial class PredefinedTypeFormatInfo : TypeFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Keyword";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    }
    
    public partial class ArrayTypeFormatInfo : TypeFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "ElementType";
    			yield return "RankSpecifiers";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    }
    
    public partial class PointerTypeFormatInfo : TypeFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "ElementType";
    			yield return "AsteriskToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "AsteriskToken";
    		}
    	}
    
    }
    
    public partial class NullableTypeFormatInfo : TypeFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "ElementType";
    			yield return "QuestionToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "QuestionToken";
    		}
    	}
    
    }
    
    public partial class TupleTypeFormatInfo : TypeFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "OpenParenToken";
    			yield return "Elements";
    			yield return "CloseParenToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "OpenParenToken";
    			yield return "CloseParenToken";
    		}
    	}
    
    }
    
    public partial class OmittedTypeArgumentFormatInfo : TypeFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "OmittedTypeArgumentToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "OmittedTypeArgumentToken";
    		}
    	}
    
    }
    
    public partial class RefTypeFormatInfo : TypeFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "RefKeyword";
    			yield return "ReadOnlyKeyword";
    			yield return "Type";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "RefKeyword";
    			yield return "ReadOnlyKeyword";
    		}
    	}
    
    }
    
    public partial class QualifiedNameFormatInfo : NameFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Left";
    			yield return "DotToken";
    			yield return "Right";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "DotToken";
    		}
    	}
    
    }
    
    public partial class AliasQualifiedNameFormatInfo : NameFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Alias";
    			yield return "ColonColonToken";
    			yield return "Name";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "ColonColonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Name";
    		}
    	}
    }
    
    public partial class IdentifierNameFormatInfo : SimpleNameFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Identifier";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Identifier";
    		}
    	}
    }
    
    public partial class GenericNameFormatInfo : SimpleNameFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Identifier";
    			yield return "TypeArgumentList";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Identifier";
    		}
    	}
    }
    
    public abstract partial class SimpleNameFormatInfo : NameFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Identifier";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Identifier";
    		}
    	}
    }
    
    public abstract partial class NameFormatInfo : TypeFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    }
    
    public abstract partial class TypeFormatInfo : ExpressionFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    }
    
    public partial class ThisExpressionFormatInfo : InstanceExpressionFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Token";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "Token";
    		}
    	}
    
    }
    
    public partial class BaseExpressionFormatInfo : InstanceExpressionFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Token";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "Token";
    		}
    	}
    
    }
    
    public abstract partial class InstanceExpressionFormatInfo : ExpressionFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    }
    
    public partial class AnonymousMethodExpressionFormatInfo : AnonymousFunctionExpressionFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "AsyncKeyword";
    			yield return "DelegateKeyword";
    			yield return "ParameterList";
    			yield return "Body";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "DelegateKeyword";
    		}
    	}
    
    }
    
    public partial class SimpleLambdaExpressionFormatInfo : LambdaExpressionFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "AsyncKeyword";
    			yield return "Parameter";
    			yield return "ArrowToken";
    			yield return "Body";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "ArrowToken";
    		}
    	}
    
    }
    
    public partial class ParenthesizedLambdaExpressionFormatInfo : LambdaExpressionFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "AsyncKeyword";
    			yield return "ParameterList";
    			yield return "ArrowToken";
    			yield return "Body";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "ArrowToken";
    		}
    	}
    
    }
    
    public abstract partial class LambdaExpressionFormatInfo : AnonymousFunctionExpressionFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "ArrowToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "ArrowToken";
    		}
    	}
    
    }
    
    public abstract partial class AnonymousFunctionExpressionFormatInfo : ExpressionFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "AsyncKeyword";
    			yield return "Body";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    }
    
    public abstract partial class ExpressionFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    }
    
    public partial class ArgumentListFormatInfo : BaseArgumentListFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "OpenParenToken";
    			yield return "Arguments";
    			yield return "CloseParenToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "OpenParenToken";
    			yield return "CloseParenToken";
    		}
    	}
    
    }
    
    public partial class BracketedArgumentListFormatInfo : BaseArgumentListFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "OpenBracketToken";
    			yield return "Arguments";
    			yield return "CloseBracketToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "OpenBracketToken";
    			yield return "CloseBracketToken";
    		}
    	}
    
    }
    
    public abstract partial class BaseArgumentListFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Arguments";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    }
    
    public partial class FromClauseFormatInfo : QueryClauseFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "FromKeyword";
    			yield return "Type";
    			yield return "Identifier";
    			yield return "InKeyword";
    			yield return "Expression";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "FromKeyword";
    			yield return "InKeyword";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Identifier";
    		}
    	}
    }
    
    public partial class LetClauseFormatInfo : QueryClauseFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "LetKeyword";
    			yield return "Identifier";
    			yield return "EqualsToken";
    			yield return "Expression";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "LetKeyword";
    			yield return "EqualsToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Identifier";
    		}
    	}
    }
    
    public partial class JoinClauseFormatInfo : QueryClauseFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "JoinKeyword";
    			yield return "Type";
    			yield return "Identifier";
    			yield return "InKeyword";
    			yield return "InExpression";
    			yield return "OnKeyword";
    			yield return "LeftExpression";
    			yield return "EqualsKeyword";
    			yield return "RightExpression";
    			yield return "Into";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "JoinKeyword";
    			yield return "InKeyword";
    			yield return "OnKeyword";
    			yield return "EqualsKeyword";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Identifier";
    		}
    	}
    }
    
    public partial class WhereClauseFormatInfo : QueryClauseFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "WhereKeyword";
    			yield return "Condition";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "WhereKeyword";
    		}
    	}
    
    }
    
    public partial class OrderByClauseFormatInfo : QueryClauseFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "OrderByKeyword";
    			yield return "Orderings";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "OrderByKeyword";
    		}
    	}
    
    }
    
    public abstract partial class QueryClauseFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    }
    
    public partial class SelectClauseFormatInfo : SelectOrGroupClauseFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "SelectKeyword";
    			yield return "Expression";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "SelectKeyword";
    		}
    	}
    
    }
    
    public partial class GroupClauseFormatInfo : SelectOrGroupClauseFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "GroupKeyword";
    			yield return "GroupExpression";
    			yield return "ByKeyword";
    			yield return "ByExpression";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "GroupKeyword";
    			yield return "ByKeyword";
    		}
    	}
    
    }
    
    public abstract partial class SelectOrGroupClauseFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    }
    
    public partial class DeclarationPatternFormatInfo : PatternFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Type";
    			yield return "Designation";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    }
    
    public partial class ConstantPatternFormatInfo : PatternFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Expression";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    }
    
    public abstract partial class PatternFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    }
    
    public partial class InterpolatedStringTextFormatInfo : InterpolatedStringContentFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "TextToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    }
    
    public partial class InterpolationFormatInfo : InterpolatedStringContentFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "OpenBraceToken";
    			yield return "Expression";
    			yield return "AlignmentClause";
    			yield return "FormatClause";
    			yield return "CloseBraceToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "OpenBraceToken";
    			yield return "CloseBraceToken";
    		}
    	}
    
    }
    
    public abstract partial class InterpolatedStringContentFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    }
    
    public partial class BlockFormatInfo : StatementFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "OpenBraceToken";
    			yield return "Statements";
    			yield return "CloseBraceToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "OpenBraceToken";
    			yield return "CloseBraceToken";
    		}
    	}
    
    }
    
    public partial class LocalFunctionStatementFormatInfo : StatementFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Modifiers";
    			yield return "ReturnType";
    			yield return "Identifier";
    			yield return "TypeParameterList";
    			yield return "ParameterList";
    			yield return "ConstraintClauses";
    			yield return "Body";
    			yield return "ExpressionBody";
    			yield return "SemicolonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "SemicolonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Identifier";
    		}
    	}
    }
    
    public partial class LocalDeclarationStatementFormatInfo : StatementFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Modifiers";
    			yield return "Declaration";
    			yield return "SemicolonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "SemicolonToken";
    		}
    	}
    
    }
    
    public partial class ExpressionStatementFormatInfo : StatementFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Expression";
    			yield return "SemicolonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "SemicolonToken";
    		}
    	}
    
    }
    
    public partial class EmptyStatementFormatInfo : StatementFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "SemicolonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "SemicolonToken";
    		}
    	}
    
    }
    
    public partial class LabeledStatementFormatInfo : StatementFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Identifier";
    			yield return "ColonToken";
    			yield return "Statement";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "ColonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Identifier";
    		}
    	}
    }
    
    public partial class GotoStatementFormatInfo : StatementFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "GotoKeyword";
    			yield return "CaseOrDefaultKeyword";
    			yield return "Expression";
    			yield return "SemicolonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "GotoKeyword";
    			yield return "SemicolonToken";
    		}
    	}
    
    }
    
    public partial class BreakStatementFormatInfo : StatementFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "BreakKeyword";
    			yield return "SemicolonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "BreakKeyword";
    			yield return "SemicolonToken";
    		}
    	}
    
    }
    
    public partial class ContinueStatementFormatInfo : StatementFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "ContinueKeyword";
    			yield return "SemicolonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "ContinueKeyword";
    			yield return "SemicolonToken";
    		}
    	}
    
    }
    
    public partial class ReturnStatementFormatInfo : StatementFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "ReturnKeyword";
    			yield return "Expression";
    			yield return "SemicolonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "ReturnKeyword";
    			yield return "SemicolonToken";
    		}
    	}
    
    }
    
    public partial class ThrowStatementFormatInfo : StatementFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "ThrowKeyword";
    			yield return "Expression";
    			yield return "SemicolonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "ThrowKeyword";
    			yield return "SemicolonToken";
    		}
    	}
    
    }
    
    public partial class YieldStatementFormatInfo : StatementFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "YieldKeyword";
    			yield return "ReturnOrBreakKeyword";
    			yield return "Expression";
    			yield return "SemicolonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "YieldKeyword";
    			yield return "SemicolonToken";
    		}
    	}
    
    }
    
    public partial class WhileStatementFormatInfo : StatementFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "WhileKeyword";
    			yield return "OpenParenToken";
    			yield return "Condition";
    			yield return "CloseParenToken";
    			yield return "Statement";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "WhileKeyword";
    			yield return "OpenParenToken";
    			yield return "CloseParenToken";
    		}
    	}
    
    }
    
    public partial class DoStatementFormatInfo : StatementFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "DoKeyword";
    			yield return "Statement";
    			yield return "WhileKeyword";
    			yield return "OpenParenToken";
    			yield return "Condition";
    			yield return "CloseParenToken";
    			yield return "SemicolonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "DoKeyword";
    			yield return "WhileKeyword";
    			yield return "OpenParenToken";
    			yield return "CloseParenToken";
    			yield return "SemicolonToken";
    		}
    	}
    
    }
    
    public partial class ForStatementFormatInfo : StatementFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "ForKeyword";
    			yield return "OpenParenToken";
    			yield return "Declaration";
    			yield return "Initializers";
    			yield return "FirstSemicolonToken";
    			yield return "Condition";
    			yield return "SecondSemicolonToken";
    			yield return "Incrementors";
    			yield return "CloseParenToken";
    			yield return "Statement";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "ForKeyword";
    			yield return "OpenParenToken";
    			yield return "FirstSemicolonToken";
    			yield return "SecondSemicolonToken";
    			yield return "CloseParenToken";
    		}
    	}
    
    }
    
    public partial class UsingStatementFormatInfo : StatementFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "UsingKeyword";
    			yield return "OpenParenToken";
    			yield return "Declaration";
    			yield return "Expression";
    			yield return "CloseParenToken";
    			yield return "Statement";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "UsingKeyword";
    			yield return "OpenParenToken";
    			yield return "CloseParenToken";
    		}
    	}
    
    }
    
    public partial class FixedStatementFormatInfo : StatementFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "FixedKeyword";
    			yield return "OpenParenToken";
    			yield return "Declaration";
    			yield return "CloseParenToken";
    			yield return "Statement";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "FixedKeyword";
    			yield return "OpenParenToken";
    			yield return "CloseParenToken";
    		}
    	}
    
    }
    
    public partial class CheckedStatementFormatInfo : StatementFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Keyword";
    			yield return "Block";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "Keyword";
    		}
    	}
    
    }
    
    public partial class UnsafeStatementFormatInfo : StatementFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "UnsafeKeyword";
    			yield return "Block";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "UnsafeKeyword";
    		}
    	}
    
    }
    
    public partial class LockStatementFormatInfo : StatementFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "LockKeyword";
    			yield return "OpenParenToken";
    			yield return "Expression";
    			yield return "CloseParenToken";
    			yield return "Statement";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "LockKeyword";
    			yield return "OpenParenToken";
    			yield return "CloseParenToken";
    		}
    	}
    
    }
    
    public partial class IfStatementFormatInfo : StatementFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "IfKeyword";
    			yield return "OpenParenToken";
    			yield return "Condition";
    			yield return "CloseParenToken";
    			yield return "Statement";
    			yield return "Else";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "IfKeyword";
    			yield return "OpenParenToken";
    			yield return "CloseParenToken";
    		}
    	}
    
    }
    
    public partial class SwitchStatementFormatInfo : StatementFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "SwitchKeyword";
    			yield return "OpenParenToken";
    			yield return "Expression";
    			yield return "CloseParenToken";
    			yield return "OpenBraceToken";
    			yield return "Sections";
    			yield return "CloseBraceToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "SwitchKeyword";
    			yield return "OpenParenToken";
    			yield return "CloseParenToken";
    			yield return "OpenBraceToken";
    			yield return "CloseBraceToken";
    		}
    	}
    
    }
    
    public partial class TryStatementFormatInfo : StatementFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "TryKeyword";
    			yield return "Block";
    			yield return "Catches";
    			yield return "Finally";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "TryKeyword";
    		}
    	}
    
    }
    
    public partial class ForEachStatementFormatInfo : StatementFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "ForEachKeyword";
    			yield return "OpenParenToken";
    			yield return "Type";
    			yield return "Identifier";
    			yield return "InKeyword";
    			yield return "Expression";
    			yield return "CloseParenToken";
    			yield return "Statement";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "ForEachKeyword";
    			yield return "OpenParenToken";
    			yield return "InKeyword";
    			yield return "CloseParenToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Identifier";
    		}
    	}
    }
    
    public partial class ForEachVariableStatementFormatInfo : CommonForEachStatementFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "ForEachKeyword";
    			yield return "OpenParenToken";
    			yield return "Variable";
    			yield return "InKeyword";
    			yield return "Expression";
    			yield return "CloseParenToken";
    			yield return "Statement";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "ForEachKeyword";
    			yield return "OpenParenToken";
    			yield return "InKeyword";
    			yield return "CloseParenToken";
    		}
    	}
    
    }
    
    public abstract partial class CommonForEachStatementFormatInfo : StatementFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "ForEachKeyword";
    			yield return "OpenParenToken";
    			yield return "InKeyword";
    			yield return "Expression";
    			yield return "CloseParenToken";
    			yield return "Statement";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "ForEachKeyword";
    			yield return "OpenParenToken";
    			yield return "InKeyword";
    			yield return "CloseParenToken";
    		}
    	}
    
    }
    
    public abstract partial class StatementFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    }
    
    public partial class SingleVariableDesignationFormatInfo : VariableDesignationFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Identifier";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> Keys
    	{
    		get
    		{
    			yield return "Identifier";
    		}
    	}
    }
    
    public partial class DiscardDesignationFormatInfo : VariableDesignationFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "UnderscoreToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "UnderscoreToken";
    		}
    	}
    
    }
    
    public partial class ParenthesizedVariableDesignationFormatInfo : VariableDesignationFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "OpenParenToken";
    			yield return "Variables";
    			yield return "CloseParenToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "OpenParenToken";
    			yield return "CloseParenToken";
    		}
    	}
    
    }
    
    public abstract partial class VariableDesignationFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield break;
    		}
    	}
    
    }
    
    public partial class CasePatternSwitchLabelFormatInfo : SwitchLabelFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Keyword";
    			yield return "Pattern";
    			yield return "WhenClause";
    			yield return "ColonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "Keyword";
    			yield return "ColonToken";
    		}
    	}
    
    }
    
    public partial class CaseSwitchLabelFormatInfo : SwitchLabelFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Keyword";
    			yield return "Value";
    			yield return "ColonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "Keyword";
    			yield return "ColonToken";
    		}
    	}
    
    }
    
    public partial class DefaultSwitchLabelFormatInfo : SwitchLabelFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Keyword";
    			yield return "ColonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "Keyword";
    			yield return "ColonToken";
    		}
    	}
    
    }
    
    public abstract partial class SwitchLabelFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
    {
    	/// <inheritdoc />
        public override IEnumerable<string> SubExpressions 
    	{
    		get
    		{
    			yield return "Keyword";
    			yield return "ColonToken";
    		}
    	}
    
    	/// <inheritdoc />
        public override IEnumerable<string> SyntacticalStopwords
    	{
    		get
    		{
    			yield return "Keyword";
    			yield return "ColonToken";
    		}
    	}
    
    }
    
}
// Generated helper templates
// Generated items
