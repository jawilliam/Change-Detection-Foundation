
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
    
    public partial class NameEqualsFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class ArgumentFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class NameColonFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class DelegateDeclarationFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class EnumMemberDeclarationFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class IncompleteMemberFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class GlobalStatementFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class NamespaceDeclarationFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class EnumDeclarationFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class ClassDeclarationFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class StructDeclarationFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class InterfaceDeclarationFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class FieldDeclarationFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class EventFieldDeclarationFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class MethodDeclarationFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class OperatorDeclarationFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class ConversionOperatorDeclarationFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class ConstructorDeclarationFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class DestructorDeclarationFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class PropertyDeclarationFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class EventDeclarationFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class IndexerDeclarationFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class SimpleBaseTypeFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class ConstructorConstraintFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class ClassOrStructConstraintFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class TypeConstraintFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class ParameterListFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class BracketedParameterListFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class SkippedTokensTriviaFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class DocumentationCommentTriviaFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class EndIfDirectiveTriviaFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class RegionDirectiveTriviaFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class EndRegionDirectiveTriviaFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class ErrorDirectiveTriviaFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class WarningDirectiveTriviaFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class BadDirectiveTriviaFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class DefineDirectiveTriviaFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class UndefDirectiveTriviaFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class LineDirectiveTriviaFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class PragmaWarningDirectiveTriviaFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class PragmaChecksumDirectiveTriviaFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class ReferenceDirectiveTriviaFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class LoadDirectiveTriviaFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class ShebangDirectiveTriviaFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class ElseDirectiveTriviaFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class IfDirectiveTriviaFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class ElifDirectiveTriviaFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class TypeCrefFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class QualifiedCrefFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class NameMemberCrefFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class IndexerMemberCrefFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class OperatorMemberCrefFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class ConversionOperatorMemberCrefFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class CrefParameterListFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class CrefBracketedParameterListFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class XmlElementFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class XmlEmptyElementFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class XmlTextFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class XmlCDataSectionFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class XmlProcessingInstructionFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class XmlCommentFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class XmlTextAttributeFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class XmlCrefAttributeFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class XmlNameAttributeFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class ParenthesizedExpressionFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class TupleExpressionFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class PrefixUnaryExpressionFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class AwaitExpressionFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class PostfixUnaryExpressionFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class MemberAccessExpressionFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class ConditionalAccessExpressionFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class MemberBindingExpressionFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class ElementBindingExpressionFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class ImplicitElementAccessFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class BinaryExpressionFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class AssignmentExpressionFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class ConditionalExpressionFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class LiteralExpressionFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class MakeRefExpressionFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class RefTypeExpressionFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class RefValueExpressionFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class CheckedExpressionFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class DefaultExpressionFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class TypeOfExpressionFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class SizeOfExpressionFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class InvocationExpressionFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class ElementAccessExpressionFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class DeclarationExpressionFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class CastExpressionFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class RefExpressionFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class InitializerExpressionFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class ObjectCreationExpressionFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class AnonymousObjectCreationExpressionFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class ArrayCreationExpressionFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class ImplicitArrayCreationExpressionFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class StackAllocArrayCreationExpressionFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class QueryExpressionFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class OmittedArraySizeExpressionFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class InterpolatedStringExpressionFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class IsPatternExpressionFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class ThrowExpressionFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class PredefinedTypeFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class ArrayTypeFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class PointerTypeFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class NullableTypeFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class TupleTypeFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class OmittedTypeArgumentFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class RefTypeFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class QualifiedNameFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class AliasQualifiedNameFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class IdentifierNameFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class GenericNameFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class ThisExpressionFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class BaseExpressionFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class AnonymousMethodExpressionFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class SimpleLambdaExpressionFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class ParenthesizedLambdaExpressionFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class ArgumentListFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class BracketedArgumentListFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class FromClauseFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class LetClauseFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class JoinClauseFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class WhereClauseFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class OrderByClauseFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class SelectClauseFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class GroupClauseFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class DeclarationPatternFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class ConstantPatternFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class InterpolatedStringTextFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class InterpolationFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class BlockFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class LocalFunctionStatementFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class LocalDeclarationStatementFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class ExpressionStatementFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class EmptyStatementFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class LabeledStatementFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class GotoStatementFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class BreakStatementFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class ContinueStatementFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class ReturnStatementFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class ThrowStatementFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class YieldStatementFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class WhileStatementFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class DoStatementFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class ForStatementFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class UsingStatementFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class FixedStatementFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class CheckedStatementFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class UnsafeStatementFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class LockStatementFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class IfStatementFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class SwitchStatementFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class TryStatementFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class ForEachStatementFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class ForEachVariableStatementFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class SingleVariableDesignationFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class DiscardDesignationFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class ParenthesizedVariableDesignationFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class CasePatternSwitchLabelFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class CaseSwitchLabelFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
    
    public partial class DefaultSwitchLabelFormatInfo : Jawilliam.CDF.Domain.ElementTypeFormatInfo
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
