
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Jawilliam.CDF.CSharp
{
    public partial class AttributeArgumentSyntax<TAnnotation> : CSharpSyntaxNode<TAnnotation>
    {
    	public virtual NameEqualsSyntax<TAnnotation> NameEquals { get; set; } 
    	public virtual NameColonSyntax<TAnnotation> NameColon { get; set; } 
    	public virtual ExpressionSyntax<TAnnotation> Expression { get; set; } 
    }
    public partial class NameEqualsSyntax<TAnnotation> : CSharpSyntaxNode<TAnnotation>
    {
    	public virtual IdentifierNameSyntax<TAnnotation> Name { get; set; } 
    	public virtual SyntaxToken<TAnnotation> EqualsToken { get; private set; } 
    }
    public partial class TypeParameterListSyntax<TAnnotation> : CSharpSyntaxNode<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> LessThanToken { get; private set; } 
    	public virtual SeparatedSyntaxList<TAnnotation, TypeParameterSyntax<TAnnotation>> Parameters { get; set; } 
    	public virtual SyntaxToken<TAnnotation> GreaterThanToken { get; private set; } 
    }
    public partial class TypeParameterSyntax<TAnnotation> : CSharpSyntaxNode<TAnnotation>
    {
    	public virtual SyntaxList<TAnnotation, AttributeListSyntax<TAnnotation>> AttributeLists { get; set; } 
    	public virtual SyntaxToken<TAnnotation> VarianceKeyword { get; set; } 
    	public virtual SyntaxToken<TAnnotation> Identifier { get; set; } 
    }
    public partial class BaseListSyntax<TAnnotation> : CSharpSyntaxNode<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> ColonToken { get; private set; } 
    	public virtual SeparatedSyntaxList<TAnnotation, BaseTypeSyntax<TAnnotation>> Types { get; set; } 
    }
    public partial class TypeParameterConstraintClauseSyntax<TAnnotation> : CSharpSyntaxNode<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> WhereKeyword { get; private set; } 
    	public virtual IdentifierNameSyntax<TAnnotation> Name { get; set; } 
    	public virtual SyntaxToken<TAnnotation> ColonToken { get; private set; } 
    	public virtual SeparatedSyntaxList<TAnnotation, TypeParameterConstraintSyntax<TAnnotation>> Constraints { get; set; } 
    }
    public partial class ExplicitInterfaceSpecifierSyntax<TAnnotation> : CSharpSyntaxNode<TAnnotation>
    {
    	public virtual NameSyntax<TAnnotation> Name { get; set; } 
    	public virtual SyntaxToken<TAnnotation> DotToken { get; private set; } 
    }
    public partial class ConstructorInitializerSyntax<TAnnotation> : CSharpSyntaxNode<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> ColonToken { get; private set; } 
    	public virtual SyntaxToken<TAnnotation> ThisOrBaseKeyword { get; set; } 
    	public virtual ArgumentListSyntax<TAnnotation> ArgumentList { get; set; } 
    }
    public partial class ArrowExpressionClauseSyntax<TAnnotation> : CSharpSyntaxNode<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> ArrowToken { get; private set; } 
    	public virtual ExpressionSyntax<TAnnotation> Expression { get; set; } 
    }
    public partial class AccessorListSyntax<TAnnotation> : CSharpSyntaxNode<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> OpenBraceToken { get; private set; } 
    	public virtual SyntaxList<TAnnotation, AccessorDeclarationSyntax<TAnnotation>> Accessors { get; set; } 
    	public virtual SyntaxToken<TAnnotation> CloseBraceToken { get; private set; } 
    }
    public partial class AccessorDeclarationSyntax<TAnnotation> : CSharpSyntaxNode<TAnnotation>
    {
    	public virtual SyntaxList<TAnnotation, AttributeListSyntax<TAnnotation>> AttributeLists { get; set; } 
    	public virtual SyntaxTokenList<TAnnotation> Modifiers { get; set; } 
    	public virtual SyntaxToken<TAnnotation> Keyword { get; set; } 
    	public virtual BlockSyntax<TAnnotation> Body { get; set; } 
    	public virtual SyntaxToken<TAnnotation> SemicolonToken { get; set; } 
    }
    public partial class ParameterSyntax<TAnnotation> : CSharpSyntaxNode<TAnnotation>
    {
    	public virtual SyntaxList<TAnnotation, AttributeListSyntax<TAnnotation>> AttributeLists { get; set; } 
    	public virtual SyntaxTokenList<TAnnotation> Modifiers { get; set; } 
    	public virtual TypeSyntax<TAnnotation> Type { get; set; } 
    	public virtual SyntaxToken<TAnnotation> Identifier { get; set; } 
    	public virtual EqualsValueClauseSyntax<TAnnotation> Default { get; set; } 
    }
    public partial class CrefParameterSyntax<TAnnotation> : CSharpSyntaxNode<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> RefOrOutKeyword { get; set; } 
    	public virtual TypeSyntax<TAnnotation> Type { get; set; } 
    }
    public partial class XmlElementStartTagSyntax<TAnnotation> : CSharpSyntaxNode<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> LessThanToken { get; private set; } 
    	public virtual XmlNameSyntax<TAnnotation> Name { get; set; } 
    	public virtual SyntaxList<TAnnotation, XmlAttributeSyntax<TAnnotation>> Attributes { get; set; } 
    	public virtual SyntaxToken<TAnnotation> GreaterThanToken { get; private set; } 
    }
    public partial class XmlElementEndTagSyntax<TAnnotation> : CSharpSyntaxNode<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> LessThanSlashToken { get; private set; } 
    	public virtual XmlNameSyntax<TAnnotation> Name { get; set; } 
    	public virtual SyntaxToken<TAnnotation> GreaterThanToken { get; private set; } 
    }
    public partial class XmlNameSyntax<TAnnotation> : CSharpSyntaxNode<TAnnotation>
    {
    	public virtual XmlPrefixSyntax<TAnnotation> Prefix { get; set; } 
    	public virtual SyntaxToken<TAnnotation> LocalName { get; set; } 
    }
    public partial class XmlPrefixSyntax<TAnnotation> : CSharpSyntaxNode<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> Prefix { get; set; } 
    	public virtual SyntaxToken<TAnnotation> ColonToken { get; private set; } 
    }
    public partial class TypeArgumentListSyntax<TAnnotation> : CSharpSyntaxNode<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> LessThanToken { get; private set; } 
    	public virtual SeparatedSyntaxList<TAnnotation, TypeSyntax<TAnnotation>> Arguments { get; set; } 
    	public virtual SyntaxToken<TAnnotation> GreaterThanToken { get; private set; } 
    }
    public partial class ArrayRankSpecifierSyntax<TAnnotation> : CSharpSyntaxNode<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> OpenBracketToken { get; private set; } 
    	public virtual SeparatedSyntaxList<TAnnotation, ExpressionSyntax<TAnnotation>> Sizes { get; set; } 
    	public virtual SyntaxToken<TAnnotation> CloseBracketToken { get; private set; } 
    }
    public partial class TupleElementSyntax<TAnnotation> : CSharpSyntaxNode<TAnnotation>
    {
    	public virtual TypeSyntax<TAnnotation> Type { get; set; } 
    	public virtual SyntaxToken<TAnnotation> Identifier { get; set; } 
    }
    public partial class ArgumentSyntax<TAnnotation> : CSharpSyntaxNode<TAnnotation>
    {
    	public virtual NameColonSyntax<TAnnotation> NameColon { get; set; } 
    	public virtual SyntaxToken<TAnnotation> RefOrOutKeyword { get; set; } 
    	public virtual ExpressionSyntax<TAnnotation> Expression { get; set; } 
    }
    public partial class NameColonSyntax<TAnnotation> : CSharpSyntaxNode<TAnnotation>
    {
    	public virtual IdentifierNameSyntax<TAnnotation> Name { get; set; } 
    	public virtual SyntaxToken<TAnnotation> ColonToken { get; private set; } 
    }
    public partial class AnonymousObjectMemberDeclaratorSyntax<TAnnotation> : CSharpSyntaxNode<TAnnotation>
    {
    	public virtual NameEqualsSyntax<TAnnotation> NameEquals { get; set; } 
    	public virtual ExpressionSyntax<TAnnotation> Expression { get; set; } 
    }
    public partial class QueryBodySyntax<TAnnotation> : CSharpSyntaxNode<TAnnotation>
    {
    	public virtual SyntaxList<TAnnotation, QueryClauseSyntax<TAnnotation>> Clauses { get; set; } 
    	public virtual SelectOrGroupClauseSyntax<TAnnotation> SelectOrGroup { get; set; } 
    	public virtual QueryContinuationSyntax<TAnnotation> Continuation { get; set; } 
    }
    public partial class JoinIntoClauseSyntax<TAnnotation> : CSharpSyntaxNode<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> IntoKeyword { get; private set; } 
    	public virtual SyntaxToken<TAnnotation> Identifier { get; set; } 
    }
    public partial class OrderingSyntax<TAnnotation> : CSharpSyntaxNode<TAnnotation>
    {
    	public virtual ExpressionSyntax<TAnnotation> Expression { get; set; } 
    	public virtual SyntaxToken<TAnnotation> AscendingOrDescendingKeyword { get; private set; } 
    }
    public partial class QueryContinuationSyntax<TAnnotation> : CSharpSyntaxNode<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> IntoKeyword { get; private set; } 
    	public virtual SyntaxToken<TAnnotation> Identifier { get; set; } 
    	public virtual QueryBodySyntax<TAnnotation> Body { get; set; } 
    }
    public partial class WhenClauseSyntax<TAnnotation> : CSharpSyntaxNode<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> WhenKeyword { get; private set; } 
    	public virtual ExpressionSyntax<TAnnotation> Condition { get; set; } 
    }
    public partial class InterpolationAlignmentClauseSyntax<TAnnotation> : CSharpSyntaxNode<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> CommaToken { get; private set; } 
    	public virtual ExpressionSyntax<TAnnotation> Value { get; set; } 
    }
    public partial class InterpolationFormatClauseSyntax<TAnnotation> : CSharpSyntaxNode<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> ColonToken { get; private set; } 
    	public virtual SyntaxToken<TAnnotation> FormatStringToken { get; private set; } 
    }
    public partial class VariableDeclarationSyntax<TAnnotation> : CSharpSyntaxNode<TAnnotation>
    {
    	public virtual TypeSyntax<TAnnotation> Type { get; set; } 
    	public virtual SeparatedSyntaxList<TAnnotation, VariableDeclaratorSyntax<TAnnotation>> Variables { get; set; } 
    }
    public partial class VariableDeclaratorSyntax<TAnnotation> : CSharpSyntaxNode<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> Identifier { get; set; } 
    	public virtual BracketedArgumentListSyntax<TAnnotation> ArgumentList { get; set; } 
    	public virtual EqualsValueClauseSyntax<TAnnotation> Initializer { get; set; } 
    }
    public partial class EqualsValueClauseSyntax<TAnnotation> : CSharpSyntaxNode<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> EqualsToken { get; private set; } 
    	public virtual ExpressionSyntax<TAnnotation> Value { get; set; } 
    }
    public partial class ElseClauseSyntax<TAnnotation> : CSharpSyntaxNode<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> ElseKeyword { get; private set; } 
    	public virtual StatementSyntax<TAnnotation> Statement { get; set; } 
    }
    public partial class SwitchSectionSyntax<TAnnotation> : CSharpSyntaxNode<TAnnotation>
    {
    	public virtual SyntaxList<TAnnotation, SwitchLabelSyntax<TAnnotation>> Labels { get; set; } 
    	public virtual SyntaxList<TAnnotation, StatementSyntax<TAnnotation>> Statements { get; set; } 
    }
    public partial class CatchClauseSyntax<TAnnotation> : CSharpSyntaxNode<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> CatchKeyword { get; private set; } 
    	public virtual CatchDeclarationSyntax<TAnnotation> Declaration { get; set; } 
    	public virtual CatchFilterClauseSyntax<TAnnotation> Filter { get; set; } 
    	public virtual BlockSyntax<TAnnotation> Block { get; set; } 
    }
    public partial class CatchDeclarationSyntax<TAnnotation> : CSharpSyntaxNode<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> OpenParenToken { get; private set; } 
    	public virtual TypeSyntax<TAnnotation> Type { get; set; } 
    	public virtual SyntaxToken<TAnnotation> Identifier { get; set; } 
    	public virtual SyntaxToken<TAnnotation> CloseParenToken { get; private set; } 
    }
    public partial class CatchFilterClauseSyntax<TAnnotation> : CSharpSyntaxNode<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> WhenKeyword { get; private set; } 
    	public virtual SyntaxToken<TAnnotation> OpenParenToken { get; private set; } 
    	public virtual ExpressionSyntax<TAnnotation> FilterExpression { get; set; } 
    	public virtual SyntaxToken<TAnnotation> CloseParenToken { get; private set; } 
    }
    public partial class FinallyClauseSyntax<TAnnotation> : CSharpSyntaxNode<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> FinallyKeyword { get; private set; } 
    	public virtual BlockSyntax<TAnnotation> Block { get; set; } 
    }
    public partial class CompilationUnitSyntax<TAnnotation> : CSharpSyntaxNode<TAnnotation>
    {
    	public virtual SyntaxList<TAnnotation, ExternAliasDirectiveSyntax<TAnnotation>> Externs { get; set; } 
    	public virtual SyntaxList<TAnnotation, UsingDirectiveSyntax<TAnnotation>> Usings { get; set; } 
    	public virtual SyntaxList<TAnnotation, AttributeListSyntax<TAnnotation>> AttributeLists { get; set; } 
    	public virtual SyntaxList<TAnnotation, MemberDeclarationSyntax<TAnnotation>> Members { get; set; } 
    	public virtual SyntaxToken<TAnnotation> EndOfFileToken { get; private set; } 
    }
    public partial class ExternAliasDirectiveSyntax<TAnnotation> : CSharpSyntaxNode<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> ExternKeyword { get; private set; } 
    	public virtual SyntaxToken<TAnnotation> AliasKeyword { get; private set; } 
    	public virtual SyntaxToken<TAnnotation> Identifier { get; set; } 
    	public virtual SyntaxToken<TAnnotation> SemicolonToken { get; private set; } 
    }
    public partial class UsingDirectiveSyntax<TAnnotation> : CSharpSyntaxNode<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> UsingKeyword { get; private set; } 
    	public virtual SyntaxToken<TAnnotation> StaticKeyword { get; set; } 
    	public virtual NameEqualsSyntax<TAnnotation> Alias { get; set; } 
    	public virtual NameSyntax<TAnnotation> Name { get; set; } 
    	public virtual SyntaxToken<TAnnotation> SemicolonToken { get; private set; } 
    }
    public partial class AttributeListSyntax<TAnnotation> : CSharpSyntaxNode<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> OpenBracketToken { get; private set; } 
    	public virtual AttributeTargetSpecifierSyntax<TAnnotation> Target { get; set; } 
    	public virtual SeparatedSyntaxList<TAnnotation, AttributeSyntax<TAnnotation>> Attributes { get; set; } 
    	public virtual SyntaxToken<TAnnotation> CloseBracketToken { get; private set; } 
    }
    public partial class AttributeTargetSpecifierSyntax<TAnnotation> : CSharpSyntaxNode<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> Identifier { get; set; } 
    	public virtual SyntaxToken<TAnnotation> ColonToken { get; private set; } 
    }
    public partial class AttributeSyntax<TAnnotation> : CSharpSyntaxNode<TAnnotation>
    {
    	public virtual NameSyntax<TAnnotation> Name { get; set; } 
    	public virtual AttributeArgumentListSyntax<TAnnotation> ArgumentList { get; set; } 
    }
    public partial class AttributeArgumentListSyntax<TAnnotation> : CSharpSyntaxNode<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> OpenParenToken { get; private set; } 
    	public virtual SeparatedSyntaxList<TAnnotation, AttributeArgumentSyntax<TAnnotation>> Arguments { get; set; } 
    	public virtual SyntaxToken<TAnnotation> CloseParenToken { get; private set; } 
    }
    public partial class DelegateDeclarationSyntax<TAnnotation> : MemberDeclarationSyntax<TAnnotation>
    {
    	public virtual SyntaxList<TAnnotation, AttributeListSyntax<TAnnotation>> AttributeLists { get; set; } 
    	public virtual SyntaxTokenList<TAnnotation> Modifiers { get; set; } 
    	public virtual SyntaxToken<TAnnotation> DelegateKeyword { get; private set; } 
    	public virtual TypeSyntax<TAnnotation> ReturnType { get; set; } 
    	public virtual SyntaxToken<TAnnotation> Identifier { get; set; } 
    	public virtual TypeParameterListSyntax<TAnnotation> TypeParameterList { get; set; } 
    	public virtual ParameterListSyntax<TAnnotation> ParameterList { get; set; } 
    	public virtual SyntaxList<TAnnotation, TypeParameterConstraintClauseSyntax<TAnnotation>> ConstraintClauses { get; set; } 
    	public virtual SyntaxToken<TAnnotation> SemicolonToken { get; private set; } 
    }
    public partial class EnumMemberDeclarationSyntax<TAnnotation> : MemberDeclarationSyntax<TAnnotation>
    {
    	public virtual SyntaxList<TAnnotation, AttributeListSyntax<TAnnotation>> AttributeLists { get; set; } 
    	public virtual SyntaxToken<TAnnotation> Identifier { get; set; } 
    	public virtual EqualsValueClauseSyntax<TAnnotation> EqualsValue { get; set; } 
    }
    public partial class IncompleteMemberSyntax<TAnnotation> : MemberDeclarationSyntax<TAnnotation>
    {
    	public virtual SyntaxList<TAnnotation, AttributeListSyntax<TAnnotation>> AttributeLists { get; set; } 
    	public virtual SyntaxTokenList<TAnnotation> Modifiers { get; set; } 
    	public virtual TypeSyntax<TAnnotation> Type { get; set; } 
    }
    public partial class GlobalStatementSyntax<TAnnotation> : MemberDeclarationSyntax<TAnnotation>
    {
    	public virtual StatementSyntax<TAnnotation> Statement { get; set; } 
    }
    public partial class NamespaceDeclarationSyntax<TAnnotation> : MemberDeclarationSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> NamespaceKeyword { get; private set; } 
    	public virtual NameSyntax<TAnnotation> Name { get; set; } 
    	public virtual SyntaxToken<TAnnotation> OpenBraceToken { get; private set; } 
    	public virtual SyntaxList<TAnnotation, ExternAliasDirectiveSyntax<TAnnotation>> Externs { get; set; } 
    	public virtual SyntaxList<TAnnotation, UsingDirectiveSyntax<TAnnotation>> Usings { get; set; } 
    	public virtual SyntaxList<TAnnotation, MemberDeclarationSyntax<TAnnotation>> Members { get; set; } 
    	public virtual SyntaxToken<TAnnotation> CloseBraceToken { get; private set; } 
    	public virtual SyntaxToken<TAnnotation> SemicolonToken { get; set; } 
    }
    public partial class EnumDeclarationSyntax<TAnnotation> : BaseTypeDeclarationSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> EnumKeyword { get; private set; } 
    	public virtual SeparatedSyntaxList<TAnnotation, EnumMemberDeclarationSyntax<TAnnotation>> Members { get; set; } 
    }
    public partial class ClassDeclarationSyntax<TAnnotation> : TypeDeclarationSyntax<TAnnotation>
    {
    }
    public partial class StructDeclarationSyntax<TAnnotation> : TypeDeclarationSyntax<TAnnotation>
    {
    }
    public partial class InterfaceDeclarationSyntax<TAnnotation> : TypeDeclarationSyntax<TAnnotation>
    {
    }
    public abstract partial class TypeDeclarationSyntax<TAnnotation> : BaseTypeDeclarationSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> Keyword { get; private set; } 
    	public virtual TypeParameterListSyntax<TAnnotation> TypeParameterList { get; set; } 
    	public virtual SyntaxList<TAnnotation, TypeParameterConstraintClauseSyntax<TAnnotation>> ConstraintClauses { get; set; } 
    	public virtual SyntaxList<TAnnotation, MemberDeclarationSyntax<TAnnotation>> Members { get; set; } 
    }
    public abstract partial class BaseTypeDeclarationSyntax<TAnnotation> : MemberDeclarationSyntax<TAnnotation>
    {
    	public virtual SyntaxList<TAnnotation, AttributeListSyntax<TAnnotation>> AttributeLists { get; set; } 
    	public virtual SyntaxTokenList<TAnnotation> Modifiers { get; set; } 
    	public virtual SyntaxToken<TAnnotation> Identifier { get; set; } 
    	public virtual BaseListSyntax<TAnnotation> BaseList { get; set; } 
    	public virtual SyntaxToken<TAnnotation> OpenBraceToken { get; private set; } 
    	public virtual SyntaxToken<TAnnotation> CloseBraceToken { get; private set; } 
    	public virtual SyntaxToken<TAnnotation> SemicolonToken { get; set; } 
    }
    public partial class FieldDeclarationSyntax<TAnnotation> : BaseFieldDeclarationSyntax<TAnnotation>
    {
    }
    public partial class EventFieldDeclarationSyntax<TAnnotation> : BaseFieldDeclarationSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> EventKeyword { get; private set; } 
    }
    public abstract partial class BaseFieldDeclarationSyntax<TAnnotation> : MemberDeclarationSyntax<TAnnotation>
    {
    	public virtual SyntaxList<TAnnotation, AttributeListSyntax<TAnnotation>> AttributeLists { get; set; } 
    	public virtual SyntaxTokenList<TAnnotation> Modifiers { get; set; } 
    	public virtual VariableDeclarationSyntax<TAnnotation> Declaration { get; set; } 
    	public virtual SyntaxToken<TAnnotation> SemicolonToken { get; private set; } 
    }
    public partial class MethodDeclarationSyntax<TAnnotation> : BaseMethodDeclarationSyntax<TAnnotation>
    {
    	public virtual TypeSyntax<TAnnotation> ReturnType { get; set; } 
    	public virtual ExplicitInterfaceSpecifierSyntax<TAnnotation> ExplicitInterfaceSpecifier { get; set; } 
    	public virtual SyntaxToken<TAnnotation> Identifier { get; set; } 
    	public virtual TypeParameterListSyntax<TAnnotation> TypeParameterList { get; set; } 
    	public virtual SyntaxList<TAnnotation, TypeParameterConstraintClauseSyntax<TAnnotation>> ConstraintClauses { get; set; } 
    	public virtual ArrowExpressionClauseSyntax<TAnnotation> ExpressionBody { get; set; } 
    }
    public partial class OperatorDeclarationSyntax<TAnnotation> : BaseMethodDeclarationSyntax<TAnnotation>
    {
    	public virtual TypeSyntax<TAnnotation> ReturnType { get; set; } 
    	public virtual SyntaxToken<TAnnotation> OperatorKeyword { get; private set; } 
    	public virtual SyntaxToken<TAnnotation> OperatorToken { get; set; } 
    	public virtual ArrowExpressionClauseSyntax<TAnnotation> ExpressionBody { get; set; } 
    }
    public partial class ConversionOperatorDeclarationSyntax<TAnnotation> : BaseMethodDeclarationSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> ImplicitOrExplicitKeyword { get; set; } 
    	public virtual SyntaxToken<TAnnotation> OperatorKeyword { get; private set; } 
    	public virtual TypeSyntax<TAnnotation> Type { get; set; } 
    	public virtual ArrowExpressionClauseSyntax<TAnnotation> ExpressionBody { get; set; } 
    }
    public partial class ConstructorDeclarationSyntax<TAnnotation> : BaseMethodDeclarationSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> Identifier { get; set; } 
    	public virtual ConstructorInitializerSyntax<TAnnotation> Initializer { get; set; } 
    }
    public partial class DestructorDeclarationSyntax<TAnnotation> : BaseMethodDeclarationSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> TildeToken { get; private set; } 
    	public virtual SyntaxToken<TAnnotation> Identifier { get; set; } 
    }
    public abstract partial class BaseMethodDeclarationSyntax<TAnnotation> : MemberDeclarationSyntax<TAnnotation>
    {
    	public virtual SyntaxList<TAnnotation, AttributeListSyntax<TAnnotation>> AttributeLists { get; set; } 
    	public virtual SyntaxTokenList<TAnnotation> Modifiers { get; set; } 
    	public virtual ParameterListSyntax<TAnnotation> ParameterList { get; set; } 
    	public virtual BlockSyntax<TAnnotation> Body { get; set; } 
    	public virtual SyntaxToken<TAnnotation> SemicolonToken { get; set; } 
    }
    public partial class PropertyDeclarationSyntax<TAnnotation> : BasePropertyDeclarationSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> Identifier { get; set; } 
    	public virtual ArrowExpressionClauseSyntax<TAnnotation> ExpressionBody { get; set; } 
    	public virtual EqualsValueClauseSyntax<TAnnotation> Initializer { get; set; } 
    	public virtual SyntaxToken<TAnnotation> SemicolonToken { get; set; } 
    }
    public partial class EventDeclarationSyntax<TAnnotation> : BasePropertyDeclarationSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> EventKeyword { get; private set; } 
    	public virtual SyntaxToken<TAnnotation> Identifier { get; set; } 
    }
    public partial class IndexerDeclarationSyntax<TAnnotation> : BasePropertyDeclarationSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> ThisKeyword { get; private set; } 
    	public virtual BracketedParameterListSyntax<TAnnotation> ParameterList { get; set; } 
    	public virtual ArrowExpressionClauseSyntax<TAnnotation> ExpressionBody { get; set; } 
    	public virtual SyntaxToken<TAnnotation> SemicolonToken { get; set; } 
    }
    public abstract partial class BasePropertyDeclarationSyntax<TAnnotation> : MemberDeclarationSyntax<TAnnotation>
    {
    	public virtual SyntaxList<TAnnotation, AttributeListSyntax<TAnnotation>> AttributeLists { get; set; } 
    	public virtual SyntaxTokenList<TAnnotation> Modifiers { get; set; } 
    	public virtual TypeSyntax<TAnnotation> Type { get; set; } 
    	public virtual ExplicitInterfaceSpecifierSyntax<TAnnotation> ExplicitInterfaceSpecifier { get; set; } 
    	public virtual AccessorListSyntax<TAnnotation> AccessorList { get; set; } 
    }
    public abstract partial class MemberDeclarationSyntax<TAnnotation> : CSharpSyntaxNode<TAnnotation>
    {
    }
    public partial class SimpleBaseTypeSyntax<TAnnotation> : BaseTypeSyntax<TAnnotation>
    {
    }
    public abstract partial class BaseTypeSyntax<TAnnotation> : CSharpSyntaxNode<TAnnotation>
    {
    	public virtual TypeSyntax<TAnnotation> Type { get; set; } 
    }
    public partial class ConstructorConstraintSyntax<TAnnotation> : TypeParameterConstraintSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> NewKeyword { get; private set; } 
    	public virtual SyntaxToken<TAnnotation> OpenParenToken { get; private set; } 
    	public virtual SyntaxToken<TAnnotation> CloseParenToken { get; private set; } 
    }
    public partial class ClassOrStructConstraintSyntax<TAnnotation> : TypeParameterConstraintSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> ClassOrStructKeyword { get; set; } 
    }
    public partial class TypeConstraintSyntax<TAnnotation> : TypeParameterConstraintSyntax<TAnnotation>
    {
    	public virtual TypeSyntax<TAnnotation> Type { get; set; } 
    }
    public abstract partial class TypeParameterConstraintSyntax<TAnnotation> : CSharpSyntaxNode<TAnnotation>
    {
    }
    public partial class ParameterListSyntax<TAnnotation> : BaseParameterListSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> OpenParenToken { get; private set; } 
    	public virtual SyntaxToken<TAnnotation> CloseParenToken { get; private set; } 
    }
    public partial class BracketedParameterListSyntax<TAnnotation> : BaseParameterListSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> OpenBracketToken { get; private set; } 
    	public virtual SyntaxToken<TAnnotation> CloseBracketToken { get; private set; } 
    }
    public abstract partial class BaseParameterListSyntax<TAnnotation> : CSharpSyntaxNode<TAnnotation>
    {
    	public virtual SeparatedSyntaxList<TAnnotation, ParameterSyntax<TAnnotation>> Parameters { get; set; } 
    }
    public partial class SkippedTokensTriviaSyntax<TAnnotation> : StructuredTriviaSyntax<TAnnotation>
    {
    	public virtual SyntaxTokenList<TAnnotation> Tokens { get; set; } 
    }
    public partial class DocumentationCommentTriviaSyntax<TAnnotation> : StructuredTriviaSyntax<TAnnotation>
    {
    	public virtual SyntaxList<TAnnotation, XmlNodeSyntax<TAnnotation>> Content { get; set; } 
    	public virtual SyntaxToken<TAnnotation> EndOfComment { get; private set; } 
    }
    public partial class EndIfDirectiveTriviaSyntax<TAnnotation> : DirectiveTriviaSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> EndIfKeyword { get; private set; } 
    }
    public partial class RegionDirectiveTriviaSyntax<TAnnotation> : DirectiveTriviaSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> RegionKeyword { get; private set; } 
    }
    public partial class EndRegionDirectiveTriviaSyntax<TAnnotation> : DirectiveTriviaSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> EndRegionKeyword { get; private set; } 
    }
    public partial class ErrorDirectiveTriviaSyntax<TAnnotation> : DirectiveTriviaSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> ErrorKeyword { get; private set; } 
    }
    public partial class WarningDirectiveTriviaSyntax<TAnnotation> : DirectiveTriviaSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> WarningKeyword { get; private set; } 
    }
    public partial class BadDirectiveTriviaSyntax<TAnnotation> : DirectiveTriviaSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> Identifier { get; set; } 
    }
    public partial class DefineDirectiveTriviaSyntax<TAnnotation> : DirectiveTriviaSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> DefineKeyword { get; private set; } 
    	public virtual SyntaxToken<TAnnotation> Name { get; set; } 
    }
    public partial class UndefDirectiveTriviaSyntax<TAnnotation> : DirectiveTriviaSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> UndefKeyword { get; private set; } 
    	public virtual SyntaxToken<TAnnotation> Name { get; set; } 
    }
    public partial class LineDirectiveTriviaSyntax<TAnnotation> : DirectiveTriviaSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> LineKeyword { get; private set; } 
    	public virtual SyntaxToken<TAnnotation> Line { get; set; } 
    	public virtual SyntaxToken<TAnnotation> File { get; set; } 
    }
    public partial class PragmaWarningDirectiveTriviaSyntax<TAnnotation> : DirectiveTriviaSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> PragmaKeyword { get; private set; } 
    	public virtual SyntaxToken<TAnnotation> WarningKeyword { get; private set; } 
    	public virtual SyntaxToken<TAnnotation> DisableOrRestoreKeyword { get; set; } 
    	public virtual SeparatedSyntaxList<TAnnotation, ExpressionSyntax<TAnnotation>> ErrorCodes { get; set; } 
    }
    public partial class PragmaChecksumDirectiveTriviaSyntax<TAnnotation> : DirectiveTriviaSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> PragmaKeyword { get; private set; } 
    	public virtual SyntaxToken<TAnnotation> ChecksumKeyword { get; private set; } 
    	public virtual SyntaxToken<TAnnotation> File { get; set; } 
    	public virtual SyntaxToken<TAnnotation> Guid { get; set; } 
    	public virtual SyntaxToken<TAnnotation> Bytes { get; set; } 
    }
    public partial class ReferenceDirectiveTriviaSyntax<TAnnotation> : DirectiveTriviaSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> ReferenceKeyword { get; private set; } 
    	public virtual SyntaxToken<TAnnotation> File { get; set; } 
    }
    public partial class LoadDirectiveTriviaSyntax<TAnnotation> : DirectiveTriviaSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> LoadKeyword { get; private set; } 
    	public virtual SyntaxToken<TAnnotation> File { get; set; } 
    }
    public partial class ShebangDirectiveTriviaSyntax<TAnnotation> : DirectiveTriviaSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> ExclamationToken { get; private set; } 
    }
    public partial class ElseDirectiveTriviaSyntax<TAnnotation> : BranchingDirectiveTriviaSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> ElseKeyword { get; private set; } 
    }
    public partial class IfDirectiveTriviaSyntax<TAnnotation> : ConditionalDirectiveTriviaSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> IfKeyword { get; private set; } 
    }
    public partial class ElifDirectiveTriviaSyntax<TAnnotation> : ConditionalDirectiveTriviaSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> ElifKeyword { get; private set; } 
    }
    public abstract partial class ConditionalDirectiveTriviaSyntax<TAnnotation> : BranchingDirectiveTriviaSyntax<TAnnotation>
    {
    	public virtual ExpressionSyntax<TAnnotation> Condition { get; set; } 
    }
    public abstract partial class BranchingDirectiveTriviaSyntax<TAnnotation> : DirectiveTriviaSyntax<TAnnotation>
    {
    }
    public abstract partial class DirectiveTriviaSyntax<TAnnotation> : StructuredTriviaSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> HashToken { get; private set; } 
    	public virtual SyntaxToken<TAnnotation> EndOfDirectiveToken { get; private set; } 
    }
    public abstract partial class StructuredTriviaSyntax<TAnnotation> : CSharpSyntaxNode<TAnnotation>
    {
    }
    public partial class TypeCrefSyntax<TAnnotation> : CrefSyntax<TAnnotation>
    {
    	public virtual TypeSyntax<TAnnotation> Type { get; set; } 
    }
    public partial class QualifiedCrefSyntax<TAnnotation> : CrefSyntax<TAnnotation>
    {
    	public virtual TypeSyntax<TAnnotation> Container { get; set; } 
    	public virtual SyntaxToken<TAnnotation> DotToken { get; private set; } 
    	public virtual MemberCrefSyntax<TAnnotation> Member { get; set; } 
    }
    public partial class NameMemberCrefSyntax<TAnnotation> : MemberCrefSyntax<TAnnotation>
    {
    	public virtual TypeSyntax<TAnnotation> Name { get; set; } 
    	public virtual CrefParameterListSyntax<TAnnotation> Parameters { get; set; } 
    }
    public partial class IndexerMemberCrefSyntax<TAnnotation> : MemberCrefSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> ThisKeyword { get; private set; } 
    	public virtual CrefBracketedParameterListSyntax<TAnnotation> Parameters { get; set; } 
    }
    public partial class OperatorMemberCrefSyntax<TAnnotation> : MemberCrefSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> OperatorKeyword { get; private set; } 
    	public virtual SyntaxToken<TAnnotation> OperatorToken { get; set; } 
    	public virtual CrefParameterListSyntax<TAnnotation> Parameters { get; set; } 
    }
    public partial class ConversionOperatorMemberCrefSyntax<TAnnotation> : MemberCrefSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> ImplicitOrExplicitKeyword { get; set; } 
    	public virtual SyntaxToken<TAnnotation> OperatorKeyword { get; private set; } 
    	public virtual TypeSyntax<TAnnotation> Type { get; set; } 
    	public virtual CrefParameterListSyntax<TAnnotation> Parameters { get; set; } 
    }
    public abstract partial class MemberCrefSyntax<TAnnotation> : CrefSyntax<TAnnotation>
    {
    }
    public abstract partial class CrefSyntax<TAnnotation> : CSharpSyntaxNode<TAnnotation>
    {
    }
    public partial class CrefParameterListSyntax<TAnnotation> : BaseCrefParameterListSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> OpenParenToken { get; private set; } 
    	public virtual SyntaxToken<TAnnotation> CloseParenToken { get; private set; } 
    }
    public partial class CrefBracketedParameterListSyntax<TAnnotation> : BaseCrefParameterListSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> OpenBracketToken { get; private set; } 
    	public virtual SyntaxToken<TAnnotation> CloseBracketToken { get; private set; } 
    }
    public abstract partial class BaseCrefParameterListSyntax<TAnnotation> : CSharpSyntaxNode<TAnnotation>
    {
    	public virtual SeparatedSyntaxList<TAnnotation, CrefParameterSyntax<TAnnotation>> Parameters { get; set; } 
    }
    public partial class XmlElementSyntax<TAnnotation> : XmlNodeSyntax<TAnnotation>
    {
    	public virtual XmlElementStartTagSyntax<TAnnotation> StartTag { get; set; } 
    	public virtual SyntaxList<TAnnotation, XmlNodeSyntax<TAnnotation>> Content { get; set; } 
    	public virtual XmlElementEndTagSyntax<TAnnotation> EndTag { get; set; } 
    }
    public partial class XmlEmptyElementSyntax<TAnnotation> : XmlNodeSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> LessThanToken { get; private set; } 
    	public virtual XmlNameSyntax<TAnnotation> Name { get; set; } 
    	public virtual SyntaxList<TAnnotation, XmlAttributeSyntax<TAnnotation>> Attributes { get; set; } 
    	public virtual SyntaxToken<TAnnotation> SlashGreaterThanToken { get; private set; } 
    }
    public partial class XmlTextSyntax<TAnnotation> : XmlNodeSyntax<TAnnotation>
    {
    	public virtual SyntaxTokenList<TAnnotation> TextTokens { get; set; } 
    }
    public partial class XmlCDataSectionSyntax<TAnnotation> : XmlNodeSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> StartCDataToken { get; private set; } 
    	public virtual SyntaxTokenList<TAnnotation> TextTokens { get; set; } 
    	public virtual SyntaxToken<TAnnotation> EndCDataToken { get; private set; } 
    }
    public partial class XmlProcessingInstructionSyntax<TAnnotation> : XmlNodeSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> StartProcessingInstructionToken { get; private set; } 
    	public virtual XmlNameSyntax<TAnnotation> Name { get; set; } 
    	public virtual SyntaxTokenList<TAnnotation> TextTokens { get; set; } 
    	public virtual SyntaxToken<TAnnotation> EndProcessingInstructionToken { get; private set; } 
    }
    public partial class XmlCommentSyntax<TAnnotation> : XmlNodeSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> LessThanExclamationMinusMinusToken { get; private set; } 
    	public virtual SyntaxTokenList<TAnnotation> TextTokens { get; set; } 
    	public virtual SyntaxToken<TAnnotation> MinusMinusGreaterThanToken { get; private set; } 
    }
    public abstract partial class XmlNodeSyntax<TAnnotation> : CSharpSyntaxNode<TAnnotation>
    {
    }
    public partial class XmlTextAttributeSyntax<TAnnotation> : XmlAttributeSyntax<TAnnotation>
    {
    	public virtual SyntaxTokenList<TAnnotation> TextTokens { get; set; } 
    }
    public partial class XmlCrefAttributeSyntax<TAnnotation> : XmlAttributeSyntax<TAnnotation>
    {
    	public virtual CrefSyntax<TAnnotation> Cref { get; set; } 
    }
    public partial class XmlNameAttributeSyntax<TAnnotation> : XmlAttributeSyntax<TAnnotation>
    {
    	public virtual IdentifierNameSyntax<TAnnotation> Identifier { get; set; } 
    }
    public abstract partial class XmlAttributeSyntax<TAnnotation> : CSharpSyntaxNode<TAnnotation>
    {
    	public virtual XmlNameSyntax<TAnnotation> Name { get; set; } 
    	public virtual SyntaxToken<TAnnotation> EqualsToken { get; private set; } 
    	public virtual SyntaxToken<TAnnotation> StartQuoteToken { get; private set; } 
    	public virtual SyntaxToken<TAnnotation> EndQuoteToken { get; private set; } 
    }
    public partial class ParenthesizedExpressionSyntax<TAnnotation> : ExpressionSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> OpenParenToken { get; private set; } 
    	public virtual ExpressionSyntax<TAnnotation> Expression { get; set; } 
    	public virtual SyntaxToken<TAnnotation> CloseParenToken { get; private set; } 
    }
    public partial class TupleExpressionSyntax<TAnnotation> : ExpressionSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> OpenParenToken { get; private set; } 
    	public virtual SeparatedSyntaxList<TAnnotation, ArgumentSyntax<TAnnotation>> Arguments { get; set; } 
    	public virtual SyntaxToken<TAnnotation> CloseParenToken { get; private set; } 
    }
    public partial class PrefixUnaryExpressionSyntax<TAnnotation> : ExpressionSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> OperatorToken { get; set; } 
    	public virtual ExpressionSyntax<TAnnotation> Operand { get; set; } 
    }
    public partial class AwaitExpressionSyntax<TAnnotation> : ExpressionSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> AwaitKeyword { get; private set; } 
    	public virtual ExpressionSyntax<TAnnotation> Expression { get; set; } 
    }
    public partial class PostfixUnaryExpressionSyntax<TAnnotation> : ExpressionSyntax<TAnnotation>
    {
    	public virtual ExpressionSyntax<TAnnotation> Operand { get; set; } 
    	public virtual SyntaxToken<TAnnotation> OperatorToken { get; set; } 
    }
    public partial class MemberAccessExpressionSyntax<TAnnotation> : ExpressionSyntax<TAnnotation>
    {
    	public virtual ExpressionSyntax<TAnnotation> Expression { get; set; } 
    	public virtual SyntaxToken<TAnnotation> OperatorToken { get; private set; } 
    	public virtual SimpleNameSyntax<TAnnotation> Name { get; set; } 
    }
    public partial class ConditionalAccessExpressionSyntax<TAnnotation> : ExpressionSyntax<TAnnotation>
    {
    	public virtual ExpressionSyntax<TAnnotation> Expression { get; set; } 
    	public virtual SyntaxToken<TAnnotation> OperatorToken { get; private set; } 
    	public virtual ExpressionSyntax<TAnnotation> WhenNotNull { get; set; } 
    }
    public partial class MemberBindingExpressionSyntax<TAnnotation> : ExpressionSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> OperatorToken { get; private set; } 
    	public virtual SimpleNameSyntax<TAnnotation> Name { get; set; } 
    }
    public partial class ElementBindingExpressionSyntax<TAnnotation> : ExpressionSyntax<TAnnotation>
    {
    	public virtual BracketedArgumentListSyntax<TAnnotation> ArgumentList { get; set; } 
    }
    public partial class ImplicitElementAccessSyntax<TAnnotation> : ExpressionSyntax<TAnnotation>
    {
    	public virtual BracketedArgumentListSyntax<TAnnotation> ArgumentList { get; set; } 
    }
    public partial class BinaryExpressionSyntax<TAnnotation> : ExpressionSyntax<TAnnotation>
    {
    	public virtual ExpressionSyntax<TAnnotation> Left { get; set; } 
    	public virtual SyntaxToken<TAnnotation> OperatorToken { get; set; } 
    	public virtual ExpressionSyntax<TAnnotation> Right { get; set; } 
    }
    public partial class AssignmentExpressionSyntax<TAnnotation> : ExpressionSyntax<TAnnotation>
    {
    	public virtual ExpressionSyntax<TAnnotation> Left { get; set; } 
    	public virtual SyntaxToken<TAnnotation> OperatorToken { get; set; } 
    	public virtual ExpressionSyntax<TAnnotation> Right { get; set; } 
    }
    public partial class ConditionalExpressionSyntax<TAnnotation> : ExpressionSyntax<TAnnotation>
    {
    	public virtual ExpressionSyntax<TAnnotation> Condition { get; set; } 
    	public virtual SyntaxToken<TAnnotation> QuestionToken { get; private set; } 
    	public virtual ExpressionSyntax<TAnnotation> WhenTrue { get; set; } 
    	public virtual SyntaxToken<TAnnotation> ColonToken { get; private set; } 
    	public virtual ExpressionSyntax<TAnnotation> WhenFalse { get; set; } 
    }
    public partial class LiteralExpressionSyntax<TAnnotation> : ExpressionSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> Token { get; set; } 
    }
    public partial class MakeRefExpressionSyntax<TAnnotation> : ExpressionSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> Keyword { get; private set; } 
    	public virtual SyntaxToken<TAnnotation> OpenParenToken { get; private set; } 
    	public virtual ExpressionSyntax<TAnnotation> Expression { get; set; } 
    	public virtual SyntaxToken<TAnnotation> CloseParenToken { get; private set; } 
    }
    public partial class RefTypeExpressionSyntax<TAnnotation> : ExpressionSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> Keyword { get; private set; } 
    	public virtual SyntaxToken<TAnnotation> OpenParenToken { get; private set; } 
    	public virtual ExpressionSyntax<TAnnotation> Expression { get; set; } 
    	public virtual SyntaxToken<TAnnotation> CloseParenToken { get; private set; } 
    }
    public partial class RefValueExpressionSyntax<TAnnotation> : ExpressionSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> Keyword { get; private set; } 
    	public virtual SyntaxToken<TAnnotation> OpenParenToken { get; private set; } 
    	public virtual ExpressionSyntax<TAnnotation> Expression { get; set; } 
    	public virtual SyntaxToken<TAnnotation> Comma { get; private set; } 
    	public virtual TypeSyntax<TAnnotation> Type { get; set; } 
    	public virtual SyntaxToken<TAnnotation> CloseParenToken { get; private set; } 
    }
    public partial class CheckedExpressionSyntax<TAnnotation> : ExpressionSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> Keyword { get; private set; } 
    	public virtual SyntaxToken<TAnnotation> OpenParenToken { get; private set; } 
    	public virtual ExpressionSyntax<TAnnotation> Expression { get; set; } 
    	public virtual SyntaxToken<TAnnotation> CloseParenToken { get; private set; } 
    }
    public partial class DefaultExpressionSyntax<TAnnotation> : ExpressionSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> Keyword { get; private set; } 
    	public virtual SyntaxToken<TAnnotation> OpenParenToken { get; private set; } 
    	public virtual TypeSyntax<TAnnotation> Type { get; set; } 
    	public virtual SyntaxToken<TAnnotation> CloseParenToken { get; private set; } 
    }
    public partial class TypeOfExpressionSyntax<TAnnotation> : ExpressionSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> Keyword { get; private set; } 
    	public virtual SyntaxToken<TAnnotation> OpenParenToken { get; private set; } 
    	public virtual TypeSyntax<TAnnotation> Type { get; set; } 
    	public virtual SyntaxToken<TAnnotation> CloseParenToken { get; private set; } 
    }
    public partial class SizeOfExpressionSyntax<TAnnotation> : ExpressionSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> Keyword { get; private set; } 
    	public virtual SyntaxToken<TAnnotation> OpenParenToken { get; private set; } 
    	public virtual TypeSyntax<TAnnotation> Type { get; set; } 
    	public virtual SyntaxToken<TAnnotation> CloseParenToken { get; private set; } 
    }
    public partial class InvocationExpressionSyntax<TAnnotation> : ExpressionSyntax<TAnnotation>
    {
    	public virtual ExpressionSyntax<TAnnotation> Expression { get; set; } 
    	public virtual ArgumentListSyntax<TAnnotation> ArgumentList { get; set; } 
    }
    public partial class ElementAccessExpressionSyntax<TAnnotation> : ExpressionSyntax<TAnnotation>
    {
    	public virtual ExpressionSyntax<TAnnotation> Expression { get; set; } 
    	public virtual BracketedArgumentListSyntax<TAnnotation> ArgumentList { get; set; } 
    }
    public partial class DeclarationExpressionSyntax<TAnnotation> : ExpressionSyntax<TAnnotation>
    {
    	public virtual TypeSyntax<TAnnotation> Type { get; set; } 
    	public virtual VariableDesignationSyntax<TAnnotation> Designation { get; set; } 
    }
    public partial class CastExpressionSyntax<TAnnotation> : ExpressionSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> OpenParenToken { get; private set; } 
    	public virtual TypeSyntax<TAnnotation> Type { get; set; } 
    	public virtual SyntaxToken<TAnnotation> CloseParenToken { get; private set; } 
    	public virtual ExpressionSyntax<TAnnotation> Expression { get; set; } 
    }
    public partial class RefExpressionSyntax<TAnnotation> : ExpressionSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> RefKeyword { get; private set; } 
    	public virtual ExpressionSyntax<TAnnotation> Expression { get; set; } 
    }
    public partial class InitializerExpressionSyntax<TAnnotation> : ExpressionSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> OpenBraceToken { get; private set; } 
    	public virtual SeparatedSyntaxList<TAnnotation, ExpressionSyntax<TAnnotation>> Expressions { get; set; } 
    	public virtual SyntaxToken<TAnnotation> CloseBraceToken { get; private set; } 
    }
    public partial class ObjectCreationExpressionSyntax<TAnnotation> : ExpressionSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> NewKeyword { get; private set; } 
    	public virtual TypeSyntax<TAnnotation> Type { get; set; } 
    	public virtual ArgumentListSyntax<TAnnotation> ArgumentList { get; set; } 
    	public virtual InitializerExpressionSyntax<TAnnotation> Initializer { get; set; } 
    }
    public partial class AnonymousObjectCreationExpressionSyntax<TAnnotation> : ExpressionSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> NewKeyword { get; private set; } 
    	public virtual SyntaxToken<TAnnotation> OpenBraceToken { get; private set; } 
    	public virtual SeparatedSyntaxList<TAnnotation, AnonymousObjectMemberDeclaratorSyntax<TAnnotation>> Initializers { get; set; } 
    	public virtual SyntaxToken<TAnnotation> CloseBraceToken { get; private set; } 
    }
    public partial class ArrayCreationExpressionSyntax<TAnnotation> : ExpressionSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> NewKeyword { get; private set; } 
    	public virtual ArrayTypeSyntax<TAnnotation> Type { get; set; } 
    	public virtual InitializerExpressionSyntax<TAnnotation> Initializer { get; set; } 
    }
    public partial class ImplicitArrayCreationExpressionSyntax<TAnnotation> : ExpressionSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> NewKeyword { get; private set; } 
    	public virtual SyntaxToken<TAnnotation> OpenBracketToken { get; private set; } 
    	public virtual SyntaxTokenList<TAnnotation> Commas { get; set; } 
    	public virtual SyntaxToken<TAnnotation> CloseBracketToken { get; private set; } 
    	public virtual InitializerExpressionSyntax<TAnnotation> Initializer { get; set; } 
    }
    public partial class StackAllocArrayCreationExpressionSyntax<TAnnotation> : ExpressionSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> StackAllocKeyword { get; private set; } 
    	public virtual TypeSyntax<TAnnotation> Type { get; set; } 
    }
    public partial class QueryExpressionSyntax<TAnnotation> : ExpressionSyntax<TAnnotation>
    {
    	public virtual FromClauseSyntax<TAnnotation> FromClause { get; set; } 
    	public virtual QueryBodySyntax<TAnnotation> Body { get; set; } 
    }
    public partial class OmittedArraySizeExpressionSyntax<TAnnotation> : ExpressionSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> OmittedArraySizeExpressionToken { get; private set; } 
    }
    public partial class InterpolatedStringExpressionSyntax<TAnnotation> : ExpressionSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> StringStartToken { get; private set; } 
    	public virtual SyntaxList<TAnnotation, InterpolatedStringContentSyntax<TAnnotation>> Contents { get; set; } 
    	public virtual SyntaxToken<TAnnotation> StringEndToken { get; private set; } 
    }
    public partial class IsPatternExpressionSyntax<TAnnotation> : ExpressionSyntax<TAnnotation>
    {
    	public virtual ExpressionSyntax<TAnnotation> Expression { get; set; } 
    	public virtual SyntaxToken<TAnnotation> IsKeyword { get; private set; } 
    	public virtual PatternSyntax<TAnnotation> Pattern { get; set; } 
    }
    public partial class ThrowExpressionSyntax<TAnnotation> : ExpressionSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> ThrowKeyword { get; private set; } 
    	public virtual ExpressionSyntax<TAnnotation> Expression { get; set; } 
    }
    public partial class PredefinedTypeSyntax<TAnnotation> : TypeSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> Keyword { get; set; } 
    }
    public partial class ArrayTypeSyntax<TAnnotation> : TypeSyntax<TAnnotation>
    {
    	public virtual TypeSyntax<TAnnotation> ElementType { get; set; } 
    	public virtual SyntaxList<TAnnotation, ArrayRankSpecifierSyntax<TAnnotation>> RankSpecifiers { get; set; } 
    }
    public partial class PointerTypeSyntax<TAnnotation> : TypeSyntax<TAnnotation>
    {
    	public virtual TypeSyntax<TAnnotation> ElementType { get; set; } 
    	public virtual SyntaxToken<TAnnotation> AsteriskToken { get; private set; } 
    }
    public partial class NullableTypeSyntax<TAnnotation> : TypeSyntax<TAnnotation>
    {
    	public virtual TypeSyntax<TAnnotation> ElementType { get; set; } 
    	public virtual SyntaxToken<TAnnotation> QuestionToken { get; private set; } 
    }
    public partial class TupleTypeSyntax<TAnnotation> : TypeSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> OpenParenToken { get; private set; } 
    	public virtual SeparatedSyntaxList<TAnnotation, TupleElementSyntax<TAnnotation>> Elements { get; set; } 
    	public virtual SyntaxToken<TAnnotation> CloseParenToken { get; private set; } 
    }
    public partial class OmittedTypeArgumentSyntax<TAnnotation> : TypeSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> OmittedTypeArgumentToken { get; private set; } 
    }
    public partial class RefTypeSyntax<TAnnotation> : TypeSyntax<TAnnotation>
    {
    	public virtual TypeSyntax<TAnnotation> Type { get; set; } 
    }
    public partial class QualifiedNameSyntax<TAnnotation> : NameSyntax<TAnnotation>
    {
    	public virtual NameSyntax<TAnnotation> Left { get; set; } 
    	public virtual SyntaxToken<TAnnotation> DotToken { get; private set; } 
    	public virtual SimpleNameSyntax<TAnnotation> Right { get; set; } 
    }
    public partial class AliasQualifiedNameSyntax<TAnnotation> : NameSyntax<TAnnotation>
    {
    	public virtual IdentifierNameSyntax<TAnnotation> Alias { get; set; } 
    	public virtual SyntaxToken<TAnnotation> ColonColonToken { get; private set; } 
    	public virtual SimpleNameSyntax<TAnnotation> Name { get; set; } 
    }
    public partial class IdentifierNameSyntax<TAnnotation> : SimpleNameSyntax<TAnnotation>
    {
    }
    public partial class GenericNameSyntax<TAnnotation> : SimpleNameSyntax<TAnnotation>
    {
    	public virtual TypeArgumentListSyntax<TAnnotation> TypeArgumentList { get; set; } 
    }
    public abstract partial class SimpleNameSyntax<TAnnotation> : NameSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> Identifier { get; set; } 
    }
    public abstract partial class NameSyntax<TAnnotation> : TypeSyntax<TAnnotation>
    {
    }
    public abstract partial class TypeSyntax<TAnnotation> : ExpressionSyntax<TAnnotation>
    {
    }
    public partial class ThisExpressionSyntax<TAnnotation> : InstanceExpressionSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> Token { get; private set; } 
    }
    public partial class BaseExpressionSyntax<TAnnotation> : InstanceExpressionSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> Token { get; private set; } 
    }
    public abstract partial class InstanceExpressionSyntax<TAnnotation> : ExpressionSyntax<TAnnotation>
    {
    }
    public partial class AnonymousMethodExpressionSyntax<TAnnotation> : AnonymousFunctionExpressionSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> DelegateKeyword { get; private set; } 
    	public virtual ParameterListSyntax<TAnnotation> ParameterList { get; set; } 
    }
    public partial class SimpleLambdaExpressionSyntax<TAnnotation> : LambdaExpressionSyntax<TAnnotation>
    {
    	public virtual ParameterSyntax<TAnnotation> Parameter { get; set; } 
    }
    public partial class ParenthesizedLambdaExpressionSyntax<TAnnotation> : LambdaExpressionSyntax<TAnnotation>
    {
    	public virtual ParameterListSyntax<TAnnotation> ParameterList { get; set; } 
    }
    public abstract partial class LambdaExpressionSyntax<TAnnotation> : AnonymousFunctionExpressionSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> ArrowToken { get; private set; } 
    }
    public abstract partial class AnonymousFunctionExpressionSyntax<TAnnotation> : ExpressionSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> AsyncKeyword { get; set; } 
    	public virtual CSharpSyntaxNode<TAnnotation> Body { get; set; } 
    }
    public abstract partial class ExpressionSyntax<TAnnotation> : CSharpSyntaxNode<TAnnotation>
    {
    }
    public partial class ArgumentListSyntax<TAnnotation> : BaseArgumentListSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> OpenParenToken { get; private set; } 
    	public virtual SyntaxToken<TAnnotation> CloseParenToken { get; private set; } 
    }
    public partial class BracketedArgumentListSyntax<TAnnotation> : BaseArgumentListSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> OpenBracketToken { get; private set; } 
    	public virtual SyntaxToken<TAnnotation> CloseBracketToken { get; private set; } 
    }
    public abstract partial class BaseArgumentListSyntax<TAnnotation> : CSharpSyntaxNode<TAnnotation>
    {
    	public virtual SeparatedSyntaxList<TAnnotation, ArgumentSyntax<TAnnotation>> Arguments { get; set; } 
    }
    public partial class FromClauseSyntax<TAnnotation> : QueryClauseSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> FromKeyword { get; private set; } 
    	public virtual TypeSyntax<TAnnotation> Type { get; set; } 
    	public virtual SyntaxToken<TAnnotation> Identifier { get; set; } 
    	public virtual SyntaxToken<TAnnotation> InKeyword { get; private set; } 
    	public virtual ExpressionSyntax<TAnnotation> Expression { get; set; } 
    }
    public partial class LetClauseSyntax<TAnnotation> : QueryClauseSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> LetKeyword { get; private set; } 
    	public virtual SyntaxToken<TAnnotation> Identifier { get; set; } 
    	public virtual SyntaxToken<TAnnotation> EqualsToken { get; private set; } 
    	public virtual ExpressionSyntax<TAnnotation> Expression { get; set; } 
    }
    public partial class JoinClauseSyntax<TAnnotation> : QueryClauseSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> JoinKeyword { get; private set; } 
    	public virtual TypeSyntax<TAnnotation> Type { get; set; } 
    	public virtual SyntaxToken<TAnnotation> Identifier { get; set; } 
    	public virtual SyntaxToken<TAnnotation> InKeyword { get; private set; } 
    	public virtual ExpressionSyntax<TAnnotation> InExpression { get; set; } 
    	public virtual SyntaxToken<TAnnotation> OnKeyword { get; private set; } 
    	public virtual ExpressionSyntax<TAnnotation> LeftExpression { get; set; } 
    	public virtual SyntaxToken<TAnnotation> EqualsKeyword { get; private set; } 
    	public virtual ExpressionSyntax<TAnnotation> RightExpression { get; set; } 
    	public virtual JoinIntoClauseSyntax<TAnnotation> Into { get; set; } 
    }
    public partial class WhereClauseSyntax<TAnnotation> : QueryClauseSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> WhereKeyword { get; private set; } 
    	public virtual ExpressionSyntax<TAnnotation> Condition { get; set; } 
    }
    public partial class OrderByClauseSyntax<TAnnotation> : QueryClauseSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> OrderByKeyword { get; private set; } 
    	public virtual SeparatedSyntaxList<TAnnotation, OrderingSyntax<TAnnotation>> Orderings { get; set; } 
    }
    public abstract partial class QueryClauseSyntax<TAnnotation> : CSharpSyntaxNode<TAnnotation>
    {
    }
    public partial class SelectClauseSyntax<TAnnotation> : SelectOrGroupClauseSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> SelectKeyword { get; private set; } 
    	public virtual ExpressionSyntax<TAnnotation> Expression { get; set; } 
    }
    public partial class GroupClauseSyntax<TAnnotation> : SelectOrGroupClauseSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> GroupKeyword { get; private set; } 
    	public virtual ExpressionSyntax<TAnnotation> GroupExpression { get; set; } 
    	public virtual SyntaxToken<TAnnotation> ByKeyword { get; private set; } 
    	public virtual ExpressionSyntax<TAnnotation> ByExpression { get; set; } 
    }
    public abstract partial class SelectOrGroupClauseSyntax<TAnnotation> : CSharpSyntaxNode<TAnnotation>
    {
    }
    public partial class DeclarationPatternSyntax<TAnnotation> : PatternSyntax<TAnnotation>
    {
    	public virtual TypeSyntax<TAnnotation> Type { get; set; } 
    	public virtual VariableDesignationSyntax<TAnnotation> Designation { get; set; } 
    }
    public partial class ConstantPatternSyntax<TAnnotation> : PatternSyntax<TAnnotation>
    {
    	public virtual ExpressionSyntax<TAnnotation> Expression { get; set; } 
    }
    public abstract partial class PatternSyntax<TAnnotation> : CSharpSyntaxNode<TAnnotation>
    {
    }
    public partial class InterpolatedStringTextSyntax<TAnnotation> : InterpolatedStringContentSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> TextToken { get; set; } 
    }
    public partial class InterpolationSyntax<TAnnotation> : InterpolatedStringContentSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> OpenBraceToken { get; private set; } 
    	public virtual ExpressionSyntax<TAnnotation> Expression { get; set; } 
    	public virtual InterpolationAlignmentClauseSyntax<TAnnotation> AlignmentClause { get; set; } 
    	public virtual InterpolationFormatClauseSyntax<TAnnotation> FormatClause { get; set; } 
    	public virtual SyntaxToken<TAnnotation> CloseBraceToken { get; private set; } 
    }
    public abstract partial class InterpolatedStringContentSyntax<TAnnotation> : CSharpSyntaxNode<TAnnotation>
    {
    }
    public partial class BlockSyntax<TAnnotation> : StatementSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> OpenBraceToken { get; private set; } 
    	public virtual SyntaxList<TAnnotation, StatementSyntax<TAnnotation>> Statements { get; set; } 
    	public virtual SyntaxToken<TAnnotation> CloseBraceToken { get; private set; } 
    }
    public partial class LocalFunctionStatementSyntax<TAnnotation> : StatementSyntax<TAnnotation>
    {
    	public virtual SyntaxTokenList<TAnnotation> Modifiers { get; set; } 
    	public virtual TypeSyntax<TAnnotation> ReturnType { get; set; } 
    	public virtual SyntaxToken<TAnnotation> Identifier { get; set; } 
    	public virtual TypeParameterListSyntax<TAnnotation> TypeParameterList { get; set; } 
    	public virtual ParameterListSyntax<TAnnotation> ParameterList { get; set; } 
    	public virtual SyntaxList<TAnnotation, TypeParameterConstraintClauseSyntax<TAnnotation>> ConstraintClauses { get; set; } 
    	public virtual ArrowExpressionClauseSyntax<TAnnotation> ExpressionBody { get; set; } 
    	public virtual SyntaxToken<TAnnotation> SemicolonToken { get; private set; } 
    }
    public partial class LocalDeclarationStatementSyntax<TAnnotation> : StatementSyntax<TAnnotation>
    {
    	public virtual SyntaxTokenList<TAnnotation> Modifiers { get; set; } 
    	public virtual VariableDeclarationSyntax<TAnnotation> Declaration { get; set; } 
    	public virtual SyntaxToken<TAnnotation> SemicolonToken { get; private set; } 
    }
    public partial class ExpressionStatementSyntax<TAnnotation> : StatementSyntax<TAnnotation>
    {
    	public virtual ExpressionSyntax<TAnnotation> Expression { get; set; } 
    	public virtual SyntaxToken<TAnnotation> SemicolonToken { get; private set; } 
    }
    public partial class EmptyStatementSyntax<TAnnotation> : StatementSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> SemicolonToken { get; private set; } 
    }
    public partial class LabeledStatementSyntax<TAnnotation> : StatementSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> Identifier { get; set; } 
    	public virtual SyntaxToken<TAnnotation> ColonToken { get; private set; } 
    	public virtual StatementSyntax<TAnnotation> Statement { get; set; } 
    }
    public partial class GotoStatementSyntax<TAnnotation> : StatementSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> GotoKeyword { get; private set; } 
    	public virtual SyntaxToken<TAnnotation> CaseOrDefaultKeyword { get; set; } 
    	public virtual ExpressionSyntax<TAnnotation> Expression { get; set; } 
    	public virtual SyntaxToken<TAnnotation> SemicolonToken { get; private set; } 
    }
    public partial class BreakStatementSyntax<TAnnotation> : StatementSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> BreakKeyword { get; private set; } 
    	public virtual SyntaxToken<TAnnotation> SemicolonToken { get; private set; } 
    }
    public partial class ContinueStatementSyntax<TAnnotation> : StatementSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> ContinueKeyword { get; private set; } 
    	public virtual SyntaxToken<TAnnotation> SemicolonToken { get; private set; } 
    }
    public partial class ReturnStatementSyntax<TAnnotation> : StatementSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> ReturnKeyword { get; private set; } 
    	public virtual ExpressionSyntax<TAnnotation> Expression { get; set; } 
    	public virtual SyntaxToken<TAnnotation> SemicolonToken { get; private set; } 
    }
    public partial class ThrowStatementSyntax<TAnnotation> : StatementSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> ThrowKeyword { get; private set; } 
    	public virtual ExpressionSyntax<TAnnotation> Expression { get; set; } 
    	public virtual SyntaxToken<TAnnotation> SemicolonToken { get; private set; } 
    }
    public partial class YieldStatementSyntax<TAnnotation> : StatementSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> YieldKeyword { get; private set; } 
    	public virtual SyntaxToken<TAnnotation> ReturnOrBreakKeyword { get; set; } 
    	public virtual ExpressionSyntax<TAnnotation> Expression { get; set; } 
    	public virtual SyntaxToken<TAnnotation> SemicolonToken { get; private set; } 
    }
    public partial class WhileStatementSyntax<TAnnotation> : StatementSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> WhileKeyword { get; private set; } 
    	public virtual SyntaxToken<TAnnotation> OpenParenToken { get; private set; } 
    	public virtual ExpressionSyntax<TAnnotation> Condition { get; set; } 
    	public virtual SyntaxToken<TAnnotation> CloseParenToken { get; private set; } 
    	public virtual StatementSyntax<TAnnotation> Statement { get; set; } 
    }
    public partial class DoStatementSyntax<TAnnotation> : StatementSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> DoKeyword { get; private set; } 
    	public virtual StatementSyntax<TAnnotation> Statement { get; set; } 
    	public virtual SyntaxToken<TAnnotation> WhileKeyword { get; private set; } 
    	public virtual SyntaxToken<TAnnotation> OpenParenToken { get; private set; } 
    	public virtual ExpressionSyntax<TAnnotation> Condition { get; set; } 
    	public virtual SyntaxToken<TAnnotation> CloseParenToken { get; private set; } 
    	public virtual SyntaxToken<TAnnotation> SemicolonToken { get; private set; } 
    }
    public partial class ForStatementSyntax<TAnnotation> : StatementSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> ForKeyword { get; private set; } 
    	public virtual SyntaxToken<TAnnotation> OpenParenToken { get; private set; } 
    	public virtual VariableDeclarationSyntax<TAnnotation> Declaration { get; set; } 
    	public virtual SeparatedSyntaxList<TAnnotation, ExpressionSyntax<TAnnotation>> Initializers { get; set; } 
    	public virtual SyntaxToken<TAnnotation> FirstSemicolonToken { get; private set; } 
    	public virtual ExpressionSyntax<TAnnotation> Condition { get; set; } 
    	public virtual SyntaxToken<TAnnotation> SecondSemicolonToken { get; private set; } 
    	public virtual SeparatedSyntaxList<TAnnotation, ExpressionSyntax<TAnnotation>> Incrementors { get; set; } 
    	public virtual SyntaxToken<TAnnotation> CloseParenToken { get; private set; } 
    	public virtual StatementSyntax<TAnnotation> Statement { get; set; } 
    }
    public partial class UsingStatementSyntax<TAnnotation> : StatementSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> UsingKeyword { get; private set; } 
    	public virtual SyntaxToken<TAnnotation> OpenParenToken { get; private set; } 
    	public virtual VariableDeclarationSyntax<TAnnotation> Declaration { get; set; } 
    	public virtual ExpressionSyntax<TAnnotation> Expression { get; set; } 
    	public virtual SyntaxToken<TAnnotation> CloseParenToken { get; private set; } 
    	public virtual StatementSyntax<TAnnotation> Statement { get; set; } 
    }
    public partial class FixedStatementSyntax<TAnnotation> : StatementSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> FixedKeyword { get; private set; } 
    	public virtual SyntaxToken<TAnnotation> OpenParenToken { get; private set; } 
    	public virtual VariableDeclarationSyntax<TAnnotation> Declaration { get; set; } 
    	public virtual SyntaxToken<TAnnotation> CloseParenToken { get; private set; } 
    	public virtual StatementSyntax<TAnnotation> Statement { get; set; } 
    }
    public partial class CheckedStatementSyntax<TAnnotation> : StatementSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> Keyword { get; private set; } 
    	public virtual BlockSyntax<TAnnotation> Block { get; set; } 
    }
    public partial class UnsafeStatementSyntax<TAnnotation> : StatementSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> UnsafeKeyword { get; private set; } 
    	public virtual BlockSyntax<TAnnotation> Block { get; set; } 
    }
    public partial class LockStatementSyntax<TAnnotation> : StatementSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> LockKeyword { get; private set; } 
    	public virtual SyntaxToken<TAnnotation> OpenParenToken { get; private set; } 
    	public virtual ExpressionSyntax<TAnnotation> Expression { get; set; } 
    	public virtual SyntaxToken<TAnnotation> CloseParenToken { get; private set; } 
    	public virtual StatementSyntax<TAnnotation> Statement { get; set; } 
    }
    public partial class IfStatementSyntax<TAnnotation> : StatementSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> IfKeyword { get; private set; } 
    	public virtual SyntaxToken<TAnnotation> OpenParenToken { get; private set; } 
    	public virtual ExpressionSyntax<TAnnotation> Condition { get; set; } 
    	public virtual SyntaxToken<TAnnotation> CloseParenToken { get; private set; } 
    	public virtual StatementSyntax<TAnnotation> Statement { get; set; } 
    	public virtual ElseClauseSyntax<TAnnotation> Else { get; set; } 
    }
    public partial class SwitchStatementSyntax<TAnnotation> : StatementSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> SwitchKeyword { get; private set; } 
    	public virtual SyntaxToken<TAnnotation> OpenParenToken { get; private set; } 
    	public virtual ExpressionSyntax<TAnnotation> Expression { get; set; } 
    	public virtual SyntaxToken<TAnnotation> CloseParenToken { get; private set; } 
    	public virtual SyntaxToken<TAnnotation> OpenBraceToken { get; private set; } 
    	public virtual SyntaxList<TAnnotation, SwitchSectionSyntax<TAnnotation>> Sections { get; set; } 
    	public virtual SyntaxToken<TAnnotation> CloseBraceToken { get; private set; } 
    }
    public partial class TryStatementSyntax<TAnnotation> : StatementSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> TryKeyword { get; private set; } 
    	public virtual BlockSyntax<TAnnotation> Block { get; set; } 
    	public virtual SyntaxList<TAnnotation, CatchClauseSyntax<TAnnotation>> Catches { get; set; } 
    	public virtual FinallyClauseSyntax<TAnnotation> Finally { get; set; } 
    }
    public partial class ForEachStatementSyntax<TAnnotation> : CommonForEachStatementSyntax<TAnnotation>
    {
    	public virtual TypeSyntax<TAnnotation> Type { get; set; } 
    	public virtual SyntaxToken<TAnnotation> Identifier { get; set; } 
    }
    public partial class ForEachVariableStatementSyntax<TAnnotation> : CommonForEachStatementSyntax<TAnnotation>
    {
    	public virtual ExpressionSyntax<TAnnotation> Variable { get; set; } 
    }
    public abstract partial class CommonForEachStatementSyntax<TAnnotation> : StatementSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> OpenParenToken { get; private set; } 
    	public virtual ExpressionSyntax<TAnnotation> Expression { get; set; } 
    	public virtual SyntaxToken<TAnnotation> CloseParenToken { get; private set; } 
    	public virtual StatementSyntax<TAnnotation> Statement { get; set; } 
    }
    public abstract partial class StatementSyntax<TAnnotation> : CSharpSyntaxNode<TAnnotation>
    {
    }
    public partial class SingleVariableDesignationSyntax<TAnnotation> : VariableDesignationSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> Identifier { get; set; } 
    }
    public partial class DiscardDesignationSyntax<TAnnotation> : VariableDesignationSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> UnderscoreToken { get; private set; } 
    }
    public partial class ParenthesizedVariableDesignationSyntax<TAnnotation> : VariableDesignationSyntax<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> OpenParenToken { get; private set; } 
    	public virtual SeparatedSyntaxList<TAnnotation, VariableDesignationSyntax<TAnnotation>> Variables { get; set; } 
    	public virtual SyntaxToken<TAnnotation> CloseParenToken { get; private set; } 
    }
    public abstract partial class VariableDesignationSyntax<TAnnotation> : CSharpSyntaxNode<TAnnotation>
    {
    }
    public partial class CasePatternSwitchLabelSyntax<TAnnotation> : SwitchLabelSyntax<TAnnotation>
    {
    	public virtual PatternSyntax<TAnnotation> Pattern { get; set; } 
    	public virtual WhenClauseSyntax<TAnnotation> WhenClause { get; set; } 
    }
    public partial class CaseSwitchLabelSyntax<TAnnotation> : SwitchLabelSyntax<TAnnotation>
    {
    	public virtual ExpressionSyntax<TAnnotation> Value { get; set; } 
    }
    public partial class DefaultSwitchLabelSyntax<TAnnotation> : SwitchLabelSyntax<TAnnotation>
    {
    }
    public abstract partial class SwitchLabelSyntax<TAnnotation> : CSharpSyntaxNode<TAnnotation>
    {
    	public virtual SyntaxToken<TAnnotation> Keyword { get; private set; } 
    	public virtual SyntaxToken<TAnnotation> ColonToken { get; private set; } 
    }
}
// Generated helper templates
// Generated items
