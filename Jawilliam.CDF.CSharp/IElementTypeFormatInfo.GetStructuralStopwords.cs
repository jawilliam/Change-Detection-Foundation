
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Jawilliam.CDF.CSharp
{
    public partial class AttributeArgumentFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield break;
    	}
    }
    
    public partial class NameEqualsFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "EqualsToken";
    	}
    }
    
    public partial class TypeParameterListFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "LessThanToken";
    		yield return "GreaterThanToken";
    	}
    }
    
    public partial class TypeParameterFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield break;
    	}
    }
    
    public partial class BaseListFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "ColonToken";
    	}
    }
    
    public partial class TypeParameterConstraintClauseFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "WhereKeyword";
    		yield return "ColonToken";
    	}
    }
    
    public partial class ExplicitInterfaceSpecifierFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "DotToken";
    	}
    }
    
    public partial class ConstructorInitializerFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "ColonToken";
    	}
    }
    
    public partial class ArrowExpressionClauseFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "ArrowToken";
    	}
    }
    
    public partial class AccessorListFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "OpenBraceToken";
    		yield return "CloseBraceToken";
    	}
    }
    
    public partial class AccessorDeclarationFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield break;
    	}
    }
    
    public partial class ParameterFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield break;
    	}
    }
    
    public partial class CrefParameterFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield break;
    	}
    }
    
    public partial class XmlElementStartTagFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "LessThanToken";
    		yield return "GreaterThanToken";
    	}
    }
    
    public partial class XmlElementEndTagFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "LessThanSlashToken";
    		yield return "GreaterThanToken";
    	}
    }
    
    public partial class XmlNameFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield break;
    	}
    }
    
    public partial class XmlPrefixFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "ColonToken";
    	}
    }
    
    public partial class TypeArgumentListFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "LessThanToken";
    		yield return "GreaterThanToken";
    	}
    }
    
    public partial class ArrayRankSpecifierFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "OpenBracketToken";
    		yield return "CloseBracketToken";
    	}
    }
    
    public partial class TupleElementFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield break;
    	}
    }
    
    public partial class ArgumentFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield break;
    	}
    }
    
    public partial class NameColonFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "ColonToken";
    	}
    }
    
    public partial class AnonymousObjectMemberDeclaratorFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield break;
    	}
    }
    
    public partial class QueryBodyFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield break;
    	}
    }
    
    public partial class JoinIntoClauseFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "IntoKeyword";
    	}
    }
    
    public partial class OrderingFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "AscendingOrDescendingKeyword";
    	}
    }
    
    public partial class QueryContinuationFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "IntoKeyword";
    	}
    }
    
    public partial class WhenClauseFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "WhenKeyword";
    	}
    }
    
    public partial class InterpolationAlignmentClauseFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "CommaToken";
    	}
    }
    
    public partial class InterpolationFormatClauseFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "ColonToken";
    	}
    }
    
    public partial class VariableDeclarationFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield break;
    	}
    }
    
    public partial class VariableDeclaratorFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield break;
    	}
    }
    
    public partial class EqualsValueClauseFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "EqualsToken";
    	}
    }
    
    public partial class ElseClauseFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "ElseKeyword";
    	}
    }
    
    public partial class SwitchSectionFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield break;
    	}
    }
    
    public partial class CatchClauseFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "CatchKeyword";
    	}
    }
    
    public partial class CatchDeclarationFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "OpenParenToken";
    		yield return "CloseParenToken";
    	}
    }
    
    public partial class CatchFilterClauseFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "WhenKeyword";
    		yield return "OpenParenToken";
    		yield return "CloseParenToken";
    	}
    }
    
    public partial class FinallyClauseFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "FinallyKeyword";
    	}
    }
    
    public partial class CompilationUnitFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "EndOfFileToken";
    	}
    }
    
    public partial class ExternAliasDirectiveFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "ExternKeyword";
    		yield return "AliasKeyword";
    		yield return "SemicolonToken";
    	}
    }
    
    public partial class UsingDirectiveFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "UsingKeyword";
    		yield return "SemicolonToken";
    	}
    }
    
    public partial class AttributeListFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "OpenBracketToken";
    		yield return "CloseBracketToken";
    	}
    }
    
    public partial class AttributeTargetSpecifierFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "ColonToken";
    	}
    }
    
    public partial class AttributeFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield break;
    	}
    }
    
    public partial class AttributeArgumentListFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "OpenParenToken";
    		yield return "CloseParenToken";
    	}
    }
    
    public partial class DelegateDeclarationFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "DelegateKeyword";
    		yield return "SemicolonToken";
    	}
    }
    
    public partial class EnumMemberDeclarationFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield break;
    	}
    }
    
    public partial class IncompleteMemberFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield break;
    	}
    }
    
    public partial class GlobalStatementFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield break;
    	}
    }
    
    public partial class NamespaceDeclarationFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "NamespaceKeyword";
    		yield return "OpenBraceToken";
    		yield return "CloseBraceToken";
    	}
    }
    
    public partial class EnumDeclarationFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "EnumKeyword";
    		yield return "OpenBraceToken";
    		yield return "CloseBraceToken";
    	}
    }
    
    public partial class ClassDeclarationFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "Keyword";
    		yield return "OpenBraceToken";
    		yield return "CloseBraceToken";
    	}
    }
    
    public partial class StructDeclarationFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "Keyword";
    		yield return "OpenBraceToken";
    		yield return "CloseBraceToken";
    	}
    }
    
    public partial class InterfaceDeclarationFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "Keyword";
    		yield return "OpenBraceToken";
    		yield return "CloseBraceToken";
    	}
    }
    
    public partial class FieldDeclarationFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "SemicolonToken";
    	}
    }
    
    public partial class EventFieldDeclarationFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "EventKeyword";
    		yield return "SemicolonToken";
    	}
    }
    
    public partial class MethodDeclarationFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield break;
    	}
    }
    
    public partial class OperatorDeclarationFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "OperatorKeyword";
    	}
    }
    
    public partial class ConversionOperatorDeclarationFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "OperatorKeyword";
    	}
    }
    
    public partial class ConstructorDeclarationFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield break;
    	}
    }
    
    public partial class DestructorDeclarationFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "Modifiers";
    		yield return "TildeToken";
    		yield return "ParameterList";
    	}
    }
    
    public partial class PropertyDeclarationFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield break;
    	}
    }
    
    public partial class EventDeclarationFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "EventKeyword";
    	}
    }
    
    public partial class IndexerDeclarationFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "ThisKeyword";
    	}
    }
    
    public partial class SimpleBaseTypeFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield break;
    	}
    }
    
    public partial class ConstructorConstraintFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "NewKeyword";
    		yield return "OpenParenToken";
    		yield return "CloseParenToken";
    	}
    }
    
    public partial class ClassOrStructConstraintFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield break;
    	}
    }
    
    public partial class TypeConstraintFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield break;
    	}
    }
    
    public partial class ParameterListFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "OpenParenToken";
    		yield return "CloseParenToken";
    	}
    }
    
    public partial class BracketedParameterListFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "OpenBracketToken";
    		yield return "CloseBracketToken";
    	}
    }
    
    public partial class SkippedTokensTriviaFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield break;
    	}
    }
    
    public partial class DocumentationCommentTriviaFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "EndOfComment";
    	}
    }
    
    public partial class EndIfDirectiveTriviaFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "HashToken";
    		yield return "EndIfKeyword";
    		yield return "EndOfDirectiveToken";
    	}
    }
    
    public partial class RegionDirectiveTriviaFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "HashToken";
    		yield return "RegionKeyword";
    		yield return "EndOfDirectiveToken";
    	}
    }
    
    public partial class EndRegionDirectiveTriviaFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "HashToken";
    		yield return "EndRegionKeyword";
    		yield return "EndOfDirectiveToken";
    	}
    }
    
    public partial class ErrorDirectiveTriviaFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "HashToken";
    		yield return "ErrorKeyword";
    		yield return "EndOfDirectiveToken";
    	}
    }
    
    public partial class WarningDirectiveTriviaFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "HashToken";
    		yield return "WarningKeyword";
    		yield return "EndOfDirectiveToken";
    	}
    }
    
    public partial class BadDirectiveTriviaFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "HashToken";
    		yield return "EndOfDirectiveToken";
    	}
    }
    
    public partial class DefineDirectiveTriviaFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "HashToken";
    		yield return "DefineKeyword";
    		yield return "EndOfDirectiveToken";
    	}
    }
    
    public partial class UndefDirectiveTriviaFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "HashToken";
    		yield return "UndefKeyword";
    		yield return "EndOfDirectiveToken";
    	}
    }
    
    public partial class LineDirectiveTriviaFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "HashToken";
    		yield return "LineKeyword";
    		yield return "EndOfDirectiveToken";
    	}
    }
    
    public partial class PragmaWarningDirectiveTriviaFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "HashToken";
    		yield return "PragmaKeyword";
    		yield return "WarningKeyword";
    		yield return "EndOfDirectiveToken";
    	}
    }
    
    public partial class PragmaChecksumDirectiveTriviaFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "HashToken";
    		yield return "PragmaKeyword";
    		yield return "ChecksumKeyword";
    		yield return "EndOfDirectiveToken";
    	}
    }
    
    public partial class ReferenceDirectiveTriviaFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "HashToken";
    		yield return "ReferenceKeyword";
    		yield return "EndOfDirectiveToken";
    	}
    }
    
    public partial class LoadDirectiveTriviaFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "HashToken";
    		yield return "LoadKeyword";
    		yield return "EndOfDirectiveToken";
    	}
    }
    
    public partial class ShebangDirectiveTriviaFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "HashToken";
    		yield return "ExclamationToken";
    		yield return "EndOfDirectiveToken";
    	}
    }
    
    public partial class ElseDirectiveTriviaFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "HashToken";
    		yield return "ElseKeyword";
    		yield return "EndOfDirectiveToken";
    	}
    }
    
    public partial class IfDirectiveTriviaFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "HashToken";
    		yield return "IfKeyword";
    		yield return "EndOfDirectiveToken";
    	}
    }
    
    public partial class ElifDirectiveTriviaFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "HashToken";
    		yield return "ElifKeyword";
    		yield return "EndOfDirectiveToken";
    	}
    }
    
    public partial class TypeCrefFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield break;
    	}
    }
    
    public partial class QualifiedCrefFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "DotToken";
    	}
    }
    
    public partial class NameMemberCrefFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield break;
    	}
    }
    
    public partial class IndexerMemberCrefFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "ThisKeyword";
    	}
    }
    
    public partial class OperatorMemberCrefFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "OperatorKeyword";
    	}
    }
    
    public partial class ConversionOperatorMemberCrefFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "OperatorKeyword";
    	}
    }
    
    public partial class CrefParameterListFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "OpenParenToken";
    		yield return "CloseParenToken";
    	}
    }
    
    public partial class CrefBracketedParameterListFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "OpenBracketToken";
    		yield return "CloseBracketToken";
    	}
    }
    
    public partial class XmlElementFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield break;
    	}
    }
    
    public partial class XmlEmptyElementFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "LessThanToken";
    		yield return "SlashGreaterThanToken";
    	}
    }
    
    public partial class XmlTextFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield break;
    	}
    }
    
    public partial class XmlCDataSectionFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "StartCDataToken";
    		yield return "EndCDataToken";
    	}
    }
    
    public partial class XmlProcessingInstructionFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "StartProcessingInstructionToken";
    		yield return "EndProcessingInstructionToken";
    	}
    }
    
    public partial class XmlCommentFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "LessThanExclamationMinusMinusToken";
    		yield return "MinusMinusGreaterThanToken";
    	}
    }
    
    public partial class XmlTextAttributeFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "EqualsToken";
    		yield return "StartQuoteToken";
    		yield return "EndQuoteToken";
    	}
    }
    
    public partial class XmlCrefAttributeFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "Name";
    		yield return "EqualsToken";
    		yield return "StartQuoteToken";
    		yield return "EndQuoteToken";
    	}
    }
    
    public partial class XmlNameAttributeFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "Name";
    		yield return "EqualsToken";
    		yield return "StartQuoteToken";
    		yield return "EndQuoteToken";
    	}
    }
    
    public partial class ParenthesizedExpressionFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "OpenParenToken";
    		yield return "CloseParenToken";
    	}
    }
    
    public partial class TupleExpressionFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "OpenParenToken";
    		yield return "CloseParenToken";
    	}
    }
    
    public partial class PrefixUnaryExpressionFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield break;
    	}
    }
    
    public partial class AwaitExpressionFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "AwaitKeyword";
    	}
    }
    
    public partial class PostfixUnaryExpressionFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield break;
    	}
    }
    
    public partial class MemberAccessExpressionFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield break;
    	}
    }
    
    public partial class ConditionalAccessExpressionFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "OperatorToken";
    	}
    }
    
    public partial class MemberBindingExpressionFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "OperatorToken";
    	}
    }
    
    public partial class ElementBindingExpressionFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield break;
    	}
    }
    
    public partial class ImplicitElementAccessFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield break;
    	}
    }
    
    public partial class BinaryExpressionFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield break;
    	}
    }
    
    public partial class AssignmentExpressionFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield break;
    	}
    }
    
    public partial class ConditionalExpressionFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "QuestionToken";
    		yield return "ColonToken";
    	}
    }
    
    public partial class LiteralExpressionFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield break;
    	}
    }
    
    public partial class MakeRefExpressionFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "Keyword";
    		yield return "OpenParenToken";
    		yield return "CloseParenToken";
    	}
    }
    
    public partial class RefTypeExpressionFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "Keyword";
    		yield return "OpenParenToken";
    		yield return "CloseParenToken";
    	}
    }
    
    public partial class RefValueExpressionFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "Keyword";
    		yield return "OpenParenToken";
    		yield return "Comma";
    		yield return "CloseParenToken";
    	}
    }
    
    public partial class CheckedExpressionFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "OpenParenToken";
    		yield return "CloseParenToken";
    	}
    }
    
    public partial class DefaultExpressionFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "Keyword";
    		yield return "OpenParenToken";
    		yield return "CloseParenToken";
    	}
    }
    
    public partial class TypeOfExpressionFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "Keyword";
    		yield return "OpenParenToken";
    		yield return "CloseParenToken";
    	}
    }
    
    public partial class SizeOfExpressionFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "Keyword";
    		yield return "OpenParenToken";
    		yield return "CloseParenToken";
    	}
    }
    
    public partial class InvocationExpressionFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield break;
    	}
    }
    
    public partial class ElementAccessExpressionFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield break;
    	}
    }
    
    public partial class DeclarationExpressionFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield break;
    	}
    }
    
    public partial class CastExpressionFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "OpenParenToken";
    		yield return "CloseParenToken";
    	}
    }
    
    public partial class RefExpressionFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "RefKeyword";
    	}
    }
    
    public partial class InitializerExpressionFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "OpenBraceToken";
    		yield return "CloseBraceToken";
    	}
    }
    
    public partial class ObjectCreationExpressionFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "NewKeyword";
    	}
    }
    
    public partial class AnonymousObjectCreationExpressionFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "NewKeyword";
    		yield return "OpenBraceToken";
    		yield return "CloseBraceToken";
    	}
    }
    
    public partial class ArrayCreationExpressionFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "NewKeyword";
    	}
    }
    
    public partial class ImplicitArrayCreationExpressionFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "NewKeyword";
    		yield return "OpenBracketToken";
    		yield return "CloseBracketToken";
    	}
    }
    
    public partial class StackAllocArrayCreationExpressionFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "StackAllocKeyword";
    	}
    }
    
    public partial class QueryExpressionFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield break;
    	}
    }
    
    public partial class OmittedArraySizeExpressionFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "OmittedArraySizeExpressionToken";
    	}
    }
    
    public partial class InterpolatedStringExpressionFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "StringStartToken";
    		yield return "StringEndToken";
    	}
    }
    
    public partial class IsPatternExpressionFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "IsKeyword";
    	}
    }
    
    public partial class ThrowExpressionFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "ThrowKeyword";
    	}
    }
    
    public partial class PredefinedTypeFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield break;
    	}
    }
    
    public partial class ArrayTypeFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield break;
    	}
    }
    
    public partial class PointerTypeFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "AsteriskToken";
    	}
    }
    
    public partial class NullableTypeFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "QuestionToken";
    	}
    }
    
    public partial class TupleTypeFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "OpenParenToken";
    		yield return "CloseParenToken";
    	}
    }
    
    public partial class OmittedTypeArgumentFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "OmittedTypeArgumentToken";
    	}
    }
    
    public partial class RefTypeFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "RefKeyword";
    		yield return "ReadOnlyKeyword";
    	}
    }
    
    public partial class QualifiedNameFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "DotToken";
    	}
    }
    
    public partial class AliasQualifiedNameFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "ColonColonToken";
    	}
    }
    
    public partial class IdentifierNameFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield break;
    	}
    }
    
    public partial class GenericNameFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield break;
    	}
    }
    
    public partial class ThisExpressionFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "Token";
    	}
    }
    
    public partial class BaseExpressionFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "Token";
    	}
    }
    
    public partial class AnonymousMethodExpressionFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "DelegateKeyword";
    	}
    }
    
    public partial class SimpleLambdaExpressionFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "ArrowToken";
    	}
    }
    
    public partial class ParenthesizedLambdaExpressionFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "ArrowToken";
    	}
    }
    
    public partial class ArgumentListFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "OpenParenToken";
    		yield return "CloseParenToken";
    	}
    }
    
    public partial class BracketedArgumentListFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "OpenBracketToken";
    		yield return "CloseBracketToken";
    	}
    }
    
    public partial class FromClauseFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "FromKeyword";
    		yield return "InKeyword";
    	}
    }
    
    public partial class LetClauseFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "LetKeyword";
    		yield return "EqualsToken";
    	}
    }
    
    public partial class JoinClauseFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "JoinKeyword";
    		yield return "InKeyword";
    		yield return "OnKeyword";
    		yield return "EqualsKeyword";
    	}
    }
    
    public partial class WhereClauseFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "WhereKeyword";
    	}
    }
    
    public partial class OrderByClauseFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "OrderByKeyword";
    	}
    }
    
    public partial class SelectClauseFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "SelectKeyword";
    	}
    }
    
    public partial class GroupClauseFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "GroupKeyword";
    		yield return "ByKeyword";
    	}
    }
    
    public partial class DeclarationPatternFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield break;
    	}
    }
    
    public partial class ConstantPatternFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield break;
    	}
    }
    
    public partial class InterpolatedStringTextFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield break;
    	}
    }
    
    public partial class InterpolationFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "OpenBraceToken";
    		yield return "CloseBraceToken";
    	}
    }
    
    public partial class BlockFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "OpenBraceToken";
    		yield return "CloseBraceToken";
    	}
    }
    
    public partial class LocalFunctionStatementFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "SemicolonToken";
    	}
    }
    
    public partial class LocalDeclarationStatementFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "SemicolonToken";
    	}
    }
    
    public partial class ExpressionStatementFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "SemicolonToken";
    	}
    }
    
    public partial class EmptyStatementFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "SemicolonToken";
    	}
    }
    
    public partial class LabeledStatementFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "ColonToken";
    	}
    }
    
    public partial class GotoStatementFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "GotoKeyword";
    		yield return "SemicolonToken";
    	}
    }
    
    public partial class BreakStatementFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "BreakKeyword";
    		yield return "SemicolonToken";
    	}
    }
    
    public partial class ContinueStatementFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "ContinueKeyword";
    		yield return "SemicolonToken";
    	}
    }
    
    public partial class ReturnStatementFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "ReturnKeyword";
    		yield return "SemicolonToken";
    	}
    }
    
    public partial class ThrowStatementFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "ThrowKeyword";
    		yield return "SemicolonToken";
    	}
    }
    
    public partial class YieldStatementFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "YieldKeyword";
    		yield return "SemicolonToken";
    	}
    }
    
    public partial class WhileStatementFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "WhileKeyword";
    		yield return "OpenParenToken";
    		yield return "CloseParenToken";
    	}
    }
    
    public partial class DoStatementFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "DoKeyword";
    		yield return "WhileKeyword";
    		yield return "OpenParenToken";
    		yield return "CloseParenToken";
    		yield return "SemicolonToken";
    	}
    }
    
    public partial class ForStatementFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "ForKeyword";
    		yield return "OpenParenToken";
    		yield return "FirstSemicolonToken";
    		yield return "SecondSemicolonToken";
    		yield return "CloseParenToken";
    	}
    }
    
    public partial class UsingStatementFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "UsingKeyword";
    		yield return "OpenParenToken";
    		yield return "CloseParenToken";
    	}
    }
    
    public partial class FixedStatementFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "FixedKeyword";
    		yield return "OpenParenToken";
    		yield return "CloseParenToken";
    	}
    }
    
    public partial class CheckedStatementFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "Keyword";
    	}
    }
    
    public partial class UnsafeStatementFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "UnsafeKeyword";
    	}
    }
    
    public partial class LockStatementFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "LockKeyword";
    		yield return "OpenParenToken";
    		yield return "CloseParenToken";
    	}
    }
    
    public partial class IfStatementFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "IfKeyword";
    		yield return "OpenParenToken";
    		yield return "CloseParenToken";
    	}
    }
    
    public partial class SwitchStatementFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "SwitchKeyword";
    		yield return "OpenParenToken";
    		yield return "CloseParenToken";
    		yield return "OpenBraceToken";
    		yield return "CloseBraceToken";
    	}
    }
    
    public partial class TryStatementFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "TryKeyword";
    	}
    }
    
    public partial class ForEachStatementFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "ForEachKeyword";
    		yield return "OpenParenToken";
    		yield return "InKeyword";
    		yield return "CloseParenToken";
    	}
    }
    
    public partial class ForEachVariableStatementFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "ForEachKeyword";
    		yield return "OpenParenToken";
    		yield return "InKeyword";
    		yield return "CloseParenToken";
    	}
    }
    
    public partial class SingleVariableDesignationFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield break;
    	}
    }
    
    public partial class DiscardDesignationFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "UnderscoreToken";
    	}
    }
    
    public partial class ParenthesizedVariableDesignationFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "OpenParenToken";
    		yield return "CloseParenToken";
    	}
    }
    
    public partial class CasePatternSwitchLabelFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "Keyword";
    		yield return "ColonToken";
    	}
    }
    
    public partial class CaseSwitchLabelFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "Keyword";
    		yield return "ColonToken";
    	}
    }
    
    public partial class DefaultSwitchLabelFormatInfo : Jawilliam.CDF.Domain.IElementTypeFormatInfo
    {
    	/// <summary>
        /// Gets the subexpressions considered stopwords according to structural concerns.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetStructuralStopwords()
    	{
    		yield return "Keyword";
    		yield return "ColonToken";
    	}
    }
    
}
// Generated helper templates
// Generated items
