
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Jawilliam.CDF.CSharp
{
    /// <summary>
    /// Provides C#-specific information for source code change detection. 
    /// </summary>
    public partial class LanguageFormatInfo : Jawilliam.CDF.Domain.ILanguageFormatInfo
    {
    	/// <summary>
        /// Gets the <see cref="IElementTypeFormatInfo"/> to provide information for the requested element type.
        /// </summary>
        /// <param name="type">requested element type.</param>
        /// <param name="kind">optionally the element type can be refined to an specific subtype.</param>
        /// <returns><see cref="IElementTypeFormatInfo"/> implementation intended to provide information for the requested element type.</returns>
        public virtual Jawilliam.CDF.Domain.IElementTypeFormatInfo GetElementTypeFormatInfo(string type, string subtype = null)
    	{
    		switch(type)
    		{
    			case "AttributeArgumentList": return this.AttributeArgumentListFormatInfo;
    			case "AttributeArgument": return this.AttributeArgumentFormatInfo;
    			case "NameEquals": return this.NameEqualsFormatInfo;
    			case "TypeParameterList": return this.TypeParameterListFormatInfo;
    			case "TypeParameter": return this.TypeParameterFormatInfo;
    			case "BaseList": return this.BaseListFormatInfo;
    			case "TypeParameterConstraintClause": return this.TypeParameterConstraintClauseFormatInfo;
    			case "ExplicitInterfaceSpecifier": return this.ExplicitInterfaceSpecifierFormatInfo;
    			case "ConstructorInitializer": return this.ConstructorInitializerFormatInfo;
    			case "ArrowExpressionClause": return this.ArrowExpressionClauseFormatInfo;
    			case "AccessorList": return this.AccessorListFormatInfo;
    			case "AccessorDeclaration": return this.AccessorDeclarationFormatInfo;
    			case "Parameter": return this.ParameterFormatInfo;
    			case "CrefParameter": return this.CrefParameterFormatInfo;
    			case "XmlElementStartTag": return this.XmlElementStartTagFormatInfo;
    			case "XmlElementEndTag": return this.XmlElementEndTagFormatInfo;
    			case "XmlName": return this.XmlNameFormatInfo;
    			case "XmlPrefix": return this.XmlPrefixFormatInfo;
    			case "TypeArgumentList": return this.TypeArgumentListFormatInfo;
    			case "ArrayRankSpecifier": return this.ArrayRankSpecifierFormatInfo;
    			case "TupleElement": return this.TupleElementFormatInfo;
    			case "Argument": return this.ArgumentFormatInfo;
    			case "NameColon": return this.NameColonFormatInfo;
    			case "AnonymousObjectMemberDeclarator": return this.AnonymousObjectMemberDeclaratorFormatInfo;
    			case "QueryBody": return this.QueryBodyFormatInfo;
    			case "JoinIntoClause": return this.JoinIntoClauseFormatInfo;
    			case "Ordering": return this.OrderingFormatInfo;
    			case "QueryContinuation": return this.QueryContinuationFormatInfo;
    			case "WhenClause": return this.WhenClauseFormatInfo;
    			case "InterpolationAlignmentClause": return this.InterpolationAlignmentClauseFormatInfo;
    			case "InterpolationFormatClause": return this.InterpolationFormatClauseFormatInfo;
    			case "VariableDeclaration": return this.VariableDeclarationFormatInfo;
    			case "VariableDeclarator": return this.VariableDeclaratorFormatInfo;
    			case "EqualsValueClause": return this.EqualsValueClauseFormatInfo;
    			case "ElseClause": return this.ElseClauseFormatInfo;
    			case "SwitchSection": return this.SwitchSectionFormatInfo;
    			case "CatchClause": return this.CatchClauseFormatInfo;
    			case "CatchDeclaration": return this.CatchDeclarationFormatInfo;
    			case "CatchFilterClause": return this.CatchFilterClauseFormatInfo;
    			case "FinallyClause": return this.FinallyClauseFormatInfo;
    			case "CompilationUnit": return this.CompilationUnitFormatInfo;
    			case "ExternAliasDirective": return this.ExternAliasDirectiveFormatInfo;
    			case "UsingDirective": return this.UsingDirectiveFormatInfo;
    			case "AttributeList": return this.AttributeListFormatInfo;
    			case "AttributeTargetSpecifier": return this.AttributeTargetSpecifierFormatInfo;
    			case "Attribute": return this.AttributeFormatInfo;
    			case "DelegateDeclaration": return this.DelegateDeclarationFormatInfo;
    			case "EnumMemberDeclaration": return this.EnumMemberDeclarationFormatInfo;
    			case "IncompleteMember": return this.IncompleteMemberFormatInfo;
    			case "GlobalStatement": return this.GlobalStatementFormatInfo;
    			case "NamespaceDeclaration": return this.NamespaceDeclarationFormatInfo;
    			case "EnumDeclaration": return this.EnumDeclarationFormatInfo;
    			case "ClassDeclaration": return this.ClassDeclarationFormatInfo;
    			case "StructDeclaration": return this.StructDeclarationFormatInfo;
    			case "InterfaceDeclaration": return this.InterfaceDeclarationFormatInfo;
    			case "FieldDeclaration": return this.FieldDeclarationFormatInfo;
    			case "EventFieldDeclaration": return this.EventFieldDeclarationFormatInfo;
    			case "MethodDeclaration": return this.MethodDeclarationFormatInfo;
    			case "OperatorDeclaration": return this.OperatorDeclarationFormatInfo;
    			case "ConversionOperatorDeclaration": return this.ConversionOperatorDeclarationFormatInfo;
    			case "ConstructorDeclaration": return this.ConstructorDeclarationFormatInfo;
    			case "DestructorDeclaration": return this.DestructorDeclarationFormatInfo;
    			case "PropertyDeclaration": return this.PropertyDeclarationFormatInfo;
    			case "EventDeclaration": return this.EventDeclarationFormatInfo;
    			case "IndexerDeclaration": return this.IndexerDeclarationFormatInfo;
    			case "SimpleBaseType": return this.SimpleBaseTypeFormatInfo;
    			case "ConstructorConstraint": return this.ConstructorConstraintFormatInfo;
    			case "ClassOrStructConstraint": return this.ClassOrStructConstraintFormatInfo;
    			case "TypeConstraint": return this.TypeConstraintFormatInfo;
    			case "ParameterList": return this.ParameterListFormatInfo;
    			case "BracketedParameterList": return this.BracketedParameterListFormatInfo;
    			case "SkippedTokensTrivia": return this.SkippedTokensTriviaFormatInfo;
    			case "DocumentationCommentTrivia": return this.DocumentationCommentTriviaFormatInfo;
    			case "EndIfDirectiveTrivia": return this.EndIfDirectiveTriviaFormatInfo;
    			case "RegionDirectiveTrivia": return this.RegionDirectiveTriviaFormatInfo;
    			case "EndRegionDirectiveTrivia": return this.EndRegionDirectiveTriviaFormatInfo;
    			case "ErrorDirectiveTrivia": return this.ErrorDirectiveTriviaFormatInfo;
    			case "WarningDirectiveTrivia": return this.WarningDirectiveTriviaFormatInfo;
    			case "BadDirectiveTrivia": return this.BadDirectiveTriviaFormatInfo;
    			case "DefineDirectiveTrivia": return this.DefineDirectiveTriviaFormatInfo;
    			case "UndefDirectiveTrivia": return this.UndefDirectiveTriviaFormatInfo;
    			case "LineDirectiveTrivia": return this.LineDirectiveTriviaFormatInfo;
    			case "PragmaWarningDirectiveTrivia": return this.PragmaWarningDirectiveTriviaFormatInfo;
    			case "PragmaChecksumDirectiveTrivia": return this.PragmaChecksumDirectiveTriviaFormatInfo;
    			case "ReferenceDirectiveTrivia": return this.ReferenceDirectiveTriviaFormatInfo;
    			case "LoadDirectiveTrivia": return this.LoadDirectiveTriviaFormatInfo;
    			case "ShebangDirectiveTrivia": return this.ShebangDirectiveTriviaFormatInfo;
    			case "ElseDirectiveTrivia": return this.ElseDirectiveTriviaFormatInfo;
    			case "IfDirectiveTrivia": return this.IfDirectiveTriviaFormatInfo;
    			case "ElifDirectiveTrivia": return this.ElifDirectiveTriviaFormatInfo;
    			case "TypeCref": return this.TypeCrefFormatInfo;
    			case "QualifiedCref": return this.QualifiedCrefFormatInfo;
    			case "NameMemberCref": return this.NameMemberCrefFormatInfo;
    			case "IndexerMemberCref": return this.IndexerMemberCrefFormatInfo;
    			case "OperatorMemberCref": return this.OperatorMemberCrefFormatInfo;
    			case "ConversionOperatorMemberCref": return this.ConversionOperatorMemberCrefFormatInfo;
    			case "CrefParameterList": return this.CrefParameterListFormatInfo;
    			case "CrefBracketedParameterList": return this.CrefBracketedParameterListFormatInfo;
    			case "XmlElement": return this.XmlElementFormatInfo;
    			case "XmlEmptyElement": return this.XmlEmptyElementFormatInfo;
    			case "XmlText": return this.XmlTextFormatInfo;
    			case "XmlCDataSection": return this.XmlCDataSectionFormatInfo;
    			case "XmlProcessingInstruction": return this.XmlProcessingInstructionFormatInfo;
    			case "XmlComment": return this.XmlCommentFormatInfo;
    			case "XmlTextAttribute": return this.XmlTextAttributeFormatInfo;
    			case "XmlCrefAttribute": return this.XmlCrefAttributeFormatInfo;
    			case "XmlNameAttribute": return this.XmlNameAttributeFormatInfo;
    			case "ParenthesizedExpression": return this.ParenthesizedExpressionFormatInfo;
    			case "TupleExpression": return this.TupleExpressionFormatInfo;
    			case "PrefixUnaryExpression": return this.PrefixUnaryExpressionFormatInfo;
    			case "AwaitExpression": return this.AwaitExpressionFormatInfo;
    			case "PostfixUnaryExpression": return this.PostfixUnaryExpressionFormatInfo;
    			case "MemberAccessExpression": return this.MemberAccessExpressionFormatInfo;
    			case "ConditionalAccessExpression": return this.ConditionalAccessExpressionFormatInfo;
    			case "MemberBindingExpression": return this.MemberBindingExpressionFormatInfo;
    			case "ElementBindingExpression": return this.ElementBindingExpressionFormatInfo;
    			case "ImplicitElementAccess": return this.ImplicitElementAccessFormatInfo;
    			case "BinaryExpression": return this.BinaryExpressionFormatInfo;
    			case "AssignmentExpression": return this.AssignmentExpressionFormatInfo;
    			case "ConditionalExpression": return this.ConditionalExpressionFormatInfo;
    			case "LiteralExpression": return this.LiteralExpressionFormatInfo;
    			case "MakeRefExpression": return this.MakeRefExpressionFormatInfo;
    			case "RefTypeExpression": return this.RefTypeExpressionFormatInfo;
    			case "RefValueExpression": return this.RefValueExpressionFormatInfo;
    			case "CheckedExpression": return this.CheckedExpressionFormatInfo;
    			case "DefaultExpression": return this.DefaultExpressionFormatInfo;
    			case "TypeOfExpression": return this.TypeOfExpressionFormatInfo;
    			case "SizeOfExpression": return this.SizeOfExpressionFormatInfo;
    			case "InvocationExpression": return this.InvocationExpressionFormatInfo;
    			case "ElementAccessExpression": return this.ElementAccessExpressionFormatInfo;
    			case "DeclarationExpression": return this.DeclarationExpressionFormatInfo;
    			case "CastExpression": return this.CastExpressionFormatInfo;
    			case "RefExpression": return this.RefExpressionFormatInfo;
    			case "InitializerExpression": return this.InitializerExpressionFormatInfo;
    			case "ObjectCreationExpression": return this.ObjectCreationExpressionFormatInfo;
    			case "AnonymousObjectCreationExpression": return this.AnonymousObjectCreationExpressionFormatInfo;
    			case "ArrayCreationExpression": return this.ArrayCreationExpressionFormatInfo;
    			case "ImplicitArrayCreationExpression": return this.ImplicitArrayCreationExpressionFormatInfo;
    			case "StackAllocArrayCreationExpression": return this.StackAllocArrayCreationExpressionFormatInfo;
    			case "QueryExpression": return this.QueryExpressionFormatInfo;
    			case "OmittedArraySizeExpression": return this.OmittedArraySizeExpressionFormatInfo;
    			case "InterpolatedStringExpression": return this.InterpolatedStringExpressionFormatInfo;
    			case "IsPatternExpression": return this.IsPatternExpressionFormatInfo;
    			case "ThrowExpression": return this.ThrowExpressionFormatInfo;
    			case "PredefinedType": return this.PredefinedTypeFormatInfo;
    			case "ArrayType": return this.ArrayTypeFormatInfo;
    			case "PointerType": return this.PointerTypeFormatInfo;
    			case "NullableType": return this.NullableTypeFormatInfo;
    			case "TupleType": return this.TupleTypeFormatInfo;
    			case "OmittedTypeArgument": return this.OmittedTypeArgumentFormatInfo;
    			case "RefType": return this.RefTypeFormatInfo;
    			case "QualifiedName": return this.QualifiedNameFormatInfo;
    			case "AliasQualifiedName": return this.AliasQualifiedNameFormatInfo;
    			case "IdentifierName": return this.IdentifierNameFormatInfo;
    			case "GenericName": return this.GenericNameFormatInfo;
    			case "ThisExpression": return this.ThisExpressionFormatInfo;
    			case "BaseExpression": return this.BaseExpressionFormatInfo;
    			case "AnonymousMethodExpression": return this.AnonymousMethodExpressionFormatInfo;
    			case "SimpleLambdaExpression": return this.SimpleLambdaExpressionFormatInfo;
    			case "ParenthesizedLambdaExpression": return this.ParenthesizedLambdaExpressionFormatInfo;
    			case "ArgumentList": return this.ArgumentListFormatInfo;
    			case "BracketedArgumentList": return this.BracketedArgumentListFormatInfo;
    			case "FromClause": return this.FromClauseFormatInfo;
    			case "LetClause": return this.LetClauseFormatInfo;
    			case "JoinClause": return this.JoinClauseFormatInfo;
    			case "WhereClause": return this.WhereClauseFormatInfo;
    			case "OrderByClause": return this.OrderByClauseFormatInfo;
    			case "SelectClause": return this.SelectClauseFormatInfo;
    			case "GroupClause": return this.GroupClauseFormatInfo;
    			case "DeclarationPattern": return this.DeclarationPatternFormatInfo;
    			case "ConstantPattern": return this.ConstantPatternFormatInfo;
    			case "InterpolatedStringText": return this.InterpolatedStringTextFormatInfo;
    			case "Interpolation": return this.InterpolationFormatInfo;
    			case "Block": return this.BlockFormatInfo;
    			case "LocalFunctionStatement": return this.LocalFunctionStatementFormatInfo;
    			case "LocalDeclarationStatement": return this.LocalDeclarationStatementFormatInfo;
    			case "ExpressionStatement": return this.ExpressionStatementFormatInfo;
    			case "EmptyStatement": return this.EmptyStatementFormatInfo;
    			case "LabeledStatement": return this.LabeledStatementFormatInfo;
    			case "GotoStatement": return this.GotoStatementFormatInfo;
    			case "BreakStatement": return this.BreakStatementFormatInfo;
    			case "ContinueStatement": return this.ContinueStatementFormatInfo;
    			case "ReturnStatement": return this.ReturnStatementFormatInfo;
    			case "ThrowStatement": return this.ThrowStatementFormatInfo;
    			case "YieldStatement": return this.YieldStatementFormatInfo;
    			case "WhileStatement": return this.WhileStatementFormatInfo;
    			case "DoStatement": return this.DoStatementFormatInfo;
    			case "ForStatement": return this.ForStatementFormatInfo;
    			case "UsingStatement": return this.UsingStatementFormatInfo;
    			case "FixedStatement": return this.FixedStatementFormatInfo;
    			case "CheckedStatement": return this.CheckedStatementFormatInfo;
    			case "UnsafeStatement": return this.UnsafeStatementFormatInfo;
    			case "LockStatement": return this.LockStatementFormatInfo;
    			case "IfStatement": return this.IfStatementFormatInfo;
    			case "SwitchStatement": return this.SwitchStatementFormatInfo;
    			case "TryStatement": return this.TryStatementFormatInfo;
    			case "ForEachStatement": return this.ForEachStatementFormatInfo;
    			case "ForEachVariableStatement": return this.ForEachVariableStatementFormatInfo;
    			case "SingleVariableDesignation": return this.SingleVariableDesignationFormatInfo;
    			case "DiscardDesignation": return this.DiscardDesignationFormatInfo;
    			case "ParenthesizedVariableDesignation": return this.ParenthesizedVariableDesignationFormatInfo;
    			case "CasePatternSwitchLabel": return this.CasePatternSwitchLabelFormatInfo;
    			case "CaseSwitchLabel": return this.CaseSwitchLabelFormatInfo;
    			case "DefaultSwitchLabel": return this.DefaultSwitchLabelFormatInfo;
    			default: throw new ArgumentException(nameof(type));
    		}
    	}
    	/// <summary>
        /// Provides language-specific information about the "AttributeArgumentList" type.
        /// </summary>
    	public virtual AttributeArgumentListFormatInfo AttributeArgumentListFormatInfo
    	{
    		get => _attributeArgumentListFormatInfo ?? (_attributeArgumentListFormatInfo = new AttributeArgumentListFormatInfo());
    		set => _attributeArgumentListFormatInfo = value;
    	}
    	private AttributeArgumentListFormatInfo _attributeArgumentListFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "AttributeArgument" type.
        /// </summary>
    	public virtual AttributeArgumentFormatInfo AttributeArgumentFormatInfo
    	{
    		get => _attributeArgumentFormatInfo ?? (_attributeArgumentFormatInfo = new AttributeArgumentFormatInfo());
    		set => _attributeArgumentFormatInfo = value;
    	}
    	private AttributeArgumentFormatInfo _attributeArgumentFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "NameEquals" type.
        /// </summary>
    	public virtual NameEqualsFormatInfo NameEqualsFormatInfo
    	{
    		get => _nameEqualsFormatInfo ?? (_nameEqualsFormatInfo = new NameEqualsFormatInfo());
    		set => _nameEqualsFormatInfo = value;
    	}
    	private NameEqualsFormatInfo _nameEqualsFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "TypeParameterList" type.
        /// </summary>
    	public virtual TypeParameterListFormatInfo TypeParameterListFormatInfo
    	{
    		get => _typeParameterListFormatInfo ?? (_typeParameterListFormatInfo = new TypeParameterListFormatInfo());
    		set => _typeParameterListFormatInfo = value;
    	}
    	private TypeParameterListFormatInfo _typeParameterListFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "TypeParameter" type.
        /// </summary>
    	public virtual TypeParameterFormatInfo TypeParameterFormatInfo
    	{
    		get => _typeParameterFormatInfo ?? (_typeParameterFormatInfo = new TypeParameterFormatInfo());
    		set => _typeParameterFormatInfo = value;
    	}
    	private TypeParameterFormatInfo _typeParameterFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "BaseList" type.
        /// </summary>
    	public virtual BaseListFormatInfo BaseListFormatInfo
    	{
    		get => _baseListFormatInfo ?? (_baseListFormatInfo = new BaseListFormatInfo());
    		set => _baseListFormatInfo = value;
    	}
    	private BaseListFormatInfo _baseListFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "TypeParameterConstraintClause" type.
        /// </summary>
    	public virtual TypeParameterConstraintClauseFormatInfo TypeParameterConstraintClauseFormatInfo
    	{
    		get => _typeParameterConstraintClauseFormatInfo ?? (_typeParameterConstraintClauseFormatInfo = new TypeParameterConstraintClauseFormatInfo());
    		set => _typeParameterConstraintClauseFormatInfo = value;
    	}
    	private TypeParameterConstraintClauseFormatInfo _typeParameterConstraintClauseFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "ExplicitInterfaceSpecifier" type.
        /// </summary>
    	public virtual ExplicitInterfaceSpecifierFormatInfo ExplicitInterfaceSpecifierFormatInfo
    	{
    		get => _explicitInterfaceSpecifierFormatInfo ?? (_explicitInterfaceSpecifierFormatInfo = new ExplicitInterfaceSpecifierFormatInfo());
    		set => _explicitInterfaceSpecifierFormatInfo = value;
    	}
    	private ExplicitInterfaceSpecifierFormatInfo _explicitInterfaceSpecifierFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "ConstructorInitializer" type.
        /// </summary>
    	public virtual ConstructorInitializerFormatInfo ConstructorInitializerFormatInfo
    	{
    		get => _constructorInitializerFormatInfo ?? (_constructorInitializerFormatInfo = new ConstructorInitializerFormatInfo());
    		set => _constructorInitializerFormatInfo = value;
    	}
    	private ConstructorInitializerFormatInfo _constructorInitializerFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "ArrowExpressionClause" type.
        /// </summary>
    	public virtual ArrowExpressionClauseFormatInfo ArrowExpressionClauseFormatInfo
    	{
    		get => _arrowExpressionClauseFormatInfo ?? (_arrowExpressionClauseFormatInfo = new ArrowExpressionClauseFormatInfo());
    		set => _arrowExpressionClauseFormatInfo = value;
    	}
    	private ArrowExpressionClauseFormatInfo _arrowExpressionClauseFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "AccessorList" type.
        /// </summary>
    	public virtual AccessorListFormatInfo AccessorListFormatInfo
    	{
    		get => _accessorListFormatInfo ?? (_accessorListFormatInfo = new AccessorListFormatInfo());
    		set => _accessorListFormatInfo = value;
    	}
    	private AccessorListFormatInfo _accessorListFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "AccessorDeclaration" type.
        /// </summary>
    	public virtual AccessorDeclarationFormatInfo AccessorDeclarationFormatInfo
    	{
    		get => _accessorDeclarationFormatInfo ?? (_accessorDeclarationFormatInfo = new AccessorDeclarationFormatInfo());
    		set => _accessorDeclarationFormatInfo = value;
    	}
    	private AccessorDeclarationFormatInfo _accessorDeclarationFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "Parameter" type.
        /// </summary>
    	public virtual ParameterFormatInfo ParameterFormatInfo
    	{
    		get => _parameterFormatInfo ?? (_parameterFormatInfo = new ParameterFormatInfo());
    		set => _parameterFormatInfo = value;
    	}
    	private ParameterFormatInfo _parameterFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "CrefParameter" type.
        /// </summary>
    	public virtual CrefParameterFormatInfo CrefParameterFormatInfo
    	{
    		get => _crefParameterFormatInfo ?? (_crefParameterFormatInfo = new CrefParameterFormatInfo());
    		set => _crefParameterFormatInfo = value;
    	}
    	private CrefParameterFormatInfo _crefParameterFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "XmlElementStartTag" type.
        /// </summary>
    	public virtual XmlElementStartTagFormatInfo XmlElementStartTagFormatInfo
    	{
    		get => _xmlElementStartTagFormatInfo ?? (_xmlElementStartTagFormatInfo = new XmlElementStartTagFormatInfo());
    		set => _xmlElementStartTagFormatInfo = value;
    	}
    	private XmlElementStartTagFormatInfo _xmlElementStartTagFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "XmlElementEndTag" type.
        /// </summary>
    	public virtual XmlElementEndTagFormatInfo XmlElementEndTagFormatInfo
    	{
    		get => _xmlElementEndTagFormatInfo ?? (_xmlElementEndTagFormatInfo = new XmlElementEndTagFormatInfo());
    		set => _xmlElementEndTagFormatInfo = value;
    	}
    	private XmlElementEndTagFormatInfo _xmlElementEndTagFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "XmlName" type.
        /// </summary>
    	public virtual XmlNameFormatInfo XmlNameFormatInfo
    	{
    		get => _xmlNameFormatInfo ?? (_xmlNameFormatInfo = new XmlNameFormatInfo());
    		set => _xmlNameFormatInfo = value;
    	}
    	private XmlNameFormatInfo _xmlNameFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "XmlPrefix" type.
        /// </summary>
    	public virtual XmlPrefixFormatInfo XmlPrefixFormatInfo
    	{
    		get => _xmlPrefixFormatInfo ?? (_xmlPrefixFormatInfo = new XmlPrefixFormatInfo());
    		set => _xmlPrefixFormatInfo = value;
    	}
    	private XmlPrefixFormatInfo _xmlPrefixFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "TypeArgumentList" type.
        /// </summary>
    	public virtual TypeArgumentListFormatInfo TypeArgumentListFormatInfo
    	{
    		get => _typeArgumentListFormatInfo ?? (_typeArgumentListFormatInfo = new TypeArgumentListFormatInfo());
    		set => _typeArgumentListFormatInfo = value;
    	}
    	private TypeArgumentListFormatInfo _typeArgumentListFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "ArrayRankSpecifier" type.
        /// </summary>
    	public virtual ArrayRankSpecifierFormatInfo ArrayRankSpecifierFormatInfo
    	{
    		get => _arrayRankSpecifierFormatInfo ?? (_arrayRankSpecifierFormatInfo = new ArrayRankSpecifierFormatInfo());
    		set => _arrayRankSpecifierFormatInfo = value;
    	}
    	private ArrayRankSpecifierFormatInfo _arrayRankSpecifierFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "TupleElement" type.
        /// </summary>
    	public virtual TupleElementFormatInfo TupleElementFormatInfo
    	{
    		get => _tupleElementFormatInfo ?? (_tupleElementFormatInfo = new TupleElementFormatInfo());
    		set => _tupleElementFormatInfo = value;
    	}
    	private TupleElementFormatInfo _tupleElementFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "Argument" type.
        /// </summary>
    	public virtual ArgumentFormatInfo ArgumentFormatInfo
    	{
    		get => _argumentFormatInfo ?? (_argumentFormatInfo = new ArgumentFormatInfo());
    		set => _argumentFormatInfo = value;
    	}
    	private ArgumentFormatInfo _argumentFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "NameColon" type.
        /// </summary>
    	public virtual NameColonFormatInfo NameColonFormatInfo
    	{
    		get => _nameColonFormatInfo ?? (_nameColonFormatInfo = new NameColonFormatInfo());
    		set => _nameColonFormatInfo = value;
    	}
    	private NameColonFormatInfo _nameColonFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "AnonymousObjectMemberDeclarator" type.
        /// </summary>
    	public virtual AnonymousObjectMemberDeclaratorFormatInfo AnonymousObjectMemberDeclaratorFormatInfo
    	{
    		get => _anonymousObjectMemberDeclaratorFormatInfo ?? (_anonymousObjectMemberDeclaratorFormatInfo = new AnonymousObjectMemberDeclaratorFormatInfo());
    		set => _anonymousObjectMemberDeclaratorFormatInfo = value;
    	}
    	private AnonymousObjectMemberDeclaratorFormatInfo _anonymousObjectMemberDeclaratorFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "QueryBody" type.
        /// </summary>
    	public virtual QueryBodyFormatInfo QueryBodyFormatInfo
    	{
    		get => _queryBodyFormatInfo ?? (_queryBodyFormatInfo = new QueryBodyFormatInfo());
    		set => _queryBodyFormatInfo = value;
    	}
    	private QueryBodyFormatInfo _queryBodyFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "JoinIntoClause" type.
        /// </summary>
    	public virtual JoinIntoClauseFormatInfo JoinIntoClauseFormatInfo
    	{
    		get => _joinIntoClauseFormatInfo ?? (_joinIntoClauseFormatInfo = new JoinIntoClauseFormatInfo());
    		set => _joinIntoClauseFormatInfo = value;
    	}
    	private JoinIntoClauseFormatInfo _joinIntoClauseFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "Ordering" type.
        /// </summary>
    	public virtual OrderingFormatInfo OrderingFormatInfo
    	{
    		get => _orderingFormatInfo ?? (_orderingFormatInfo = new OrderingFormatInfo());
    		set => _orderingFormatInfo = value;
    	}
    	private OrderingFormatInfo _orderingFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "QueryContinuation" type.
        /// </summary>
    	public virtual QueryContinuationFormatInfo QueryContinuationFormatInfo
    	{
    		get => _queryContinuationFormatInfo ?? (_queryContinuationFormatInfo = new QueryContinuationFormatInfo());
    		set => _queryContinuationFormatInfo = value;
    	}
    	private QueryContinuationFormatInfo _queryContinuationFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "WhenClause" type.
        /// </summary>
    	public virtual WhenClauseFormatInfo WhenClauseFormatInfo
    	{
    		get => _whenClauseFormatInfo ?? (_whenClauseFormatInfo = new WhenClauseFormatInfo());
    		set => _whenClauseFormatInfo = value;
    	}
    	private WhenClauseFormatInfo _whenClauseFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "InterpolationAlignmentClause" type.
        /// </summary>
    	public virtual InterpolationAlignmentClauseFormatInfo InterpolationAlignmentClauseFormatInfo
    	{
    		get => _interpolationAlignmentClauseFormatInfo ?? (_interpolationAlignmentClauseFormatInfo = new InterpolationAlignmentClauseFormatInfo());
    		set => _interpolationAlignmentClauseFormatInfo = value;
    	}
    	private InterpolationAlignmentClauseFormatInfo _interpolationAlignmentClauseFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "InterpolationFormatClause" type.
        /// </summary>
    	public virtual InterpolationFormatClauseFormatInfo InterpolationFormatClauseFormatInfo
    	{
    		get => _interpolationFormatClauseFormatInfo ?? (_interpolationFormatClauseFormatInfo = new InterpolationFormatClauseFormatInfo());
    		set => _interpolationFormatClauseFormatInfo = value;
    	}
    	private InterpolationFormatClauseFormatInfo _interpolationFormatClauseFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "VariableDeclaration" type.
        /// </summary>
    	public virtual VariableDeclarationFormatInfo VariableDeclarationFormatInfo
    	{
    		get => _variableDeclarationFormatInfo ?? (_variableDeclarationFormatInfo = new VariableDeclarationFormatInfo());
    		set => _variableDeclarationFormatInfo = value;
    	}
    	private VariableDeclarationFormatInfo _variableDeclarationFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "VariableDeclarator" type.
        /// </summary>
    	public virtual VariableDeclaratorFormatInfo VariableDeclaratorFormatInfo
    	{
    		get => _variableDeclaratorFormatInfo ?? (_variableDeclaratorFormatInfo = new VariableDeclaratorFormatInfo());
    		set => _variableDeclaratorFormatInfo = value;
    	}
    	private VariableDeclaratorFormatInfo _variableDeclaratorFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "EqualsValueClause" type.
        /// </summary>
    	public virtual EqualsValueClauseFormatInfo EqualsValueClauseFormatInfo
    	{
    		get => _equalsValueClauseFormatInfo ?? (_equalsValueClauseFormatInfo = new EqualsValueClauseFormatInfo());
    		set => _equalsValueClauseFormatInfo = value;
    	}
    	private EqualsValueClauseFormatInfo _equalsValueClauseFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "ElseClause" type.
        /// </summary>
    	public virtual ElseClauseFormatInfo ElseClauseFormatInfo
    	{
    		get => _elseClauseFormatInfo ?? (_elseClauseFormatInfo = new ElseClauseFormatInfo());
    		set => _elseClauseFormatInfo = value;
    	}
    	private ElseClauseFormatInfo _elseClauseFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "SwitchSection" type.
        /// </summary>
    	public virtual SwitchSectionFormatInfo SwitchSectionFormatInfo
    	{
    		get => _switchSectionFormatInfo ?? (_switchSectionFormatInfo = new SwitchSectionFormatInfo());
    		set => _switchSectionFormatInfo = value;
    	}
    	private SwitchSectionFormatInfo _switchSectionFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "CatchClause" type.
        /// </summary>
    	public virtual CatchClauseFormatInfo CatchClauseFormatInfo
    	{
    		get => _catchClauseFormatInfo ?? (_catchClauseFormatInfo = new CatchClauseFormatInfo());
    		set => _catchClauseFormatInfo = value;
    	}
    	private CatchClauseFormatInfo _catchClauseFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "CatchDeclaration" type.
        /// </summary>
    	public virtual CatchDeclarationFormatInfo CatchDeclarationFormatInfo
    	{
    		get => _catchDeclarationFormatInfo ?? (_catchDeclarationFormatInfo = new CatchDeclarationFormatInfo());
    		set => _catchDeclarationFormatInfo = value;
    	}
    	private CatchDeclarationFormatInfo _catchDeclarationFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "CatchFilterClause" type.
        /// </summary>
    	public virtual CatchFilterClauseFormatInfo CatchFilterClauseFormatInfo
    	{
    		get => _catchFilterClauseFormatInfo ?? (_catchFilterClauseFormatInfo = new CatchFilterClauseFormatInfo());
    		set => _catchFilterClauseFormatInfo = value;
    	}
    	private CatchFilterClauseFormatInfo _catchFilterClauseFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "FinallyClause" type.
        /// </summary>
    	public virtual FinallyClauseFormatInfo FinallyClauseFormatInfo
    	{
    		get => _finallyClauseFormatInfo ?? (_finallyClauseFormatInfo = new FinallyClauseFormatInfo());
    		set => _finallyClauseFormatInfo = value;
    	}
    	private FinallyClauseFormatInfo _finallyClauseFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "CompilationUnit" type.
        /// </summary>
    	public virtual CompilationUnitFormatInfo CompilationUnitFormatInfo
    	{
    		get => _compilationUnitFormatInfo ?? (_compilationUnitFormatInfo = new CompilationUnitFormatInfo());
    		set => _compilationUnitFormatInfo = value;
    	}
    	private CompilationUnitFormatInfo _compilationUnitFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "ExternAliasDirective" type.
        /// </summary>
    	public virtual ExternAliasDirectiveFormatInfo ExternAliasDirectiveFormatInfo
    	{
    		get => _externAliasDirectiveFormatInfo ?? (_externAliasDirectiveFormatInfo = new ExternAliasDirectiveFormatInfo());
    		set => _externAliasDirectiveFormatInfo = value;
    	}
    	private ExternAliasDirectiveFormatInfo _externAliasDirectiveFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "UsingDirective" type.
        /// </summary>
    	public virtual UsingDirectiveFormatInfo UsingDirectiveFormatInfo
    	{
    		get => _usingDirectiveFormatInfo ?? (_usingDirectiveFormatInfo = new UsingDirectiveFormatInfo());
    		set => _usingDirectiveFormatInfo = value;
    	}
    	private UsingDirectiveFormatInfo _usingDirectiveFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "AttributeList" type.
        /// </summary>
    	public virtual AttributeListFormatInfo AttributeListFormatInfo
    	{
    		get => _attributeListFormatInfo ?? (_attributeListFormatInfo = new AttributeListFormatInfo());
    		set => _attributeListFormatInfo = value;
    	}
    	private AttributeListFormatInfo _attributeListFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "AttributeTargetSpecifier" type.
        /// </summary>
    	public virtual AttributeTargetSpecifierFormatInfo AttributeTargetSpecifierFormatInfo
    	{
    		get => _attributeTargetSpecifierFormatInfo ?? (_attributeTargetSpecifierFormatInfo = new AttributeTargetSpecifierFormatInfo());
    		set => _attributeTargetSpecifierFormatInfo = value;
    	}
    	private AttributeTargetSpecifierFormatInfo _attributeTargetSpecifierFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "Attribute" type.
        /// </summary>
    	public virtual AttributeFormatInfo AttributeFormatInfo
    	{
    		get => _attributeFormatInfo ?? (_attributeFormatInfo = new AttributeFormatInfo());
    		set => _attributeFormatInfo = value;
    	}
    	private AttributeFormatInfo _attributeFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "DelegateDeclaration" type.
        /// </summary>
    	public virtual DelegateDeclarationFormatInfo DelegateDeclarationFormatInfo
    	{
    		get => _delegateDeclarationFormatInfo ?? (_delegateDeclarationFormatInfo = new DelegateDeclarationFormatInfo());
    		set => _delegateDeclarationFormatInfo = value;
    	}
    	private DelegateDeclarationFormatInfo _delegateDeclarationFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "EnumMemberDeclaration" type.
        /// </summary>
    	public virtual EnumMemberDeclarationFormatInfo EnumMemberDeclarationFormatInfo
    	{
    		get => _enumMemberDeclarationFormatInfo ?? (_enumMemberDeclarationFormatInfo = new EnumMemberDeclarationFormatInfo());
    		set => _enumMemberDeclarationFormatInfo = value;
    	}
    	private EnumMemberDeclarationFormatInfo _enumMemberDeclarationFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "IncompleteMember" type.
        /// </summary>
    	public virtual IncompleteMemberFormatInfo IncompleteMemberFormatInfo
    	{
    		get => _incompleteMemberFormatInfo ?? (_incompleteMemberFormatInfo = new IncompleteMemberFormatInfo());
    		set => _incompleteMemberFormatInfo = value;
    	}
    	private IncompleteMemberFormatInfo _incompleteMemberFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "GlobalStatement" type.
        /// </summary>
    	public virtual GlobalStatementFormatInfo GlobalStatementFormatInfo
    	{
    		get => _globalStatementFormatInfo ?? (_globalStatementFormatInfo = new GlobalStatementFormatInfo());
    		set => _globalStatementFormatInfo = value;
    	}
    	private GlobalStatementFormatInfo _globalStatementFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "NamespaceDeclaration" type.
        /// </summary>
    	public virtual NamespaceDeclarationFormatInfo NamespaceDeclarationFormatInfo
    	{
    		get => _namespaceDeclarationFormatInfo ?? (_namespaceDeclarationFormatInfo = new NamespaceDeclarationFormatInfo());
    		set => _namespaceDeclarationFormatInfo = value;
    	}
    	private NamespaceDeclarationFormatInfo _namespaceDeclarationFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "EnumDeclaration" type.
        /// </summary>
    	public virtual EnumDeclarationFormatInfo EnumDeclarationFormatInfo
    	{
    		get => _enumDeclarationFormatInfo ?? (_enumDeclarationFormatInfo = new EnumDeclarationFormatInfo());
    		set => _enumDeclarationFormatInfo = value;
    	}
    	private EnumDeclarationFormatInfo _enumDeclarationFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "ClassDeclaration" type.
        /// </summary>
    	public virtual ClassDeclarationFormatInfo ClassDeclarationFormatInfo
    	{
    		get => _classDeclarationFormatInfo ?? (_classDeclarationFormatInfo = new ClassDeclarationFormatInfo());
    		set => _classDeclarationFormatInfo = value;
    	}
    	private ClassDeclarationFormatInfo _classDeclarationFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "StructDeclaration" type.
        /// </summary>
    	public virtual StructDeclarationFormatInfo StructDeclarationFormatInfo
    	{
    		get => _structDeclarationFormatInfo ?? (_structDeclarationFormatInfo = new StructDeclarationFormatInfo());
    		set => _structDeclarationFormatInfo = value;
    	}
    	private StructDeclarationFormatInfo _structDeclarationFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "InterfaceDeclaration" type.
        /// </summary>
    	public virtual InterfaceDeclarationFormatInfo InterfaceDeclarationFormatInfo
    	{
    		get => _interfaceDeclarationFormatInfo ?? (_interfaceDeclarationFormatInfo = new InterfaceDeclarationFormatInfo());
    		set => _interfaceDeclarationFormatInfo = value;
    	}
    	private InterfaceDeclarationFormatInfo _interfaceDeclarationFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "FieldDeclaration" type.
        /// </summary>
    	public virtual FieldDeclarationFormatInfo FieldDeclarationFormatInfo
    	{
    		get => _fieldDeclarationFormatInfo ?? (_fieldDeclarationFormatInfo = new FieldDeclarationFormatInfo());
    		set => _fieldDeclarationFormatInfo = value;
    	}
    	private FieldDeclarationFormatInfo _fieldDeclarationFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "EventFieldDeclaration" type.
        /// </summary>
    	public virtual EventFieldDeclarationFormatInfo EventFieldDeclarationFormatInfo
    	{
    		get => _eventFieldDeclarationFormatInfo ?? (_eventFieldDeclarationFormatInfo = new EventFieldDeclarationFormatInfo());
    		set => _eventFieldDeclarationFormatInfo = value;
    	}
    	private EventFieldDeclarationFormatInfo _eventFieldDeclarationFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "MethodDeclaration" type.
        /// </summary>
    	public virtual MethodDeclarationFormatInfo MethodDeclarationFormatInfo
    	{
    		get => _methodDeclarationFormatInfo ?? (_methodDeclarationFormatInfo = new MethodDeclarationFormatInfo());
    		set => _methodDeclarationFormatInfo = value;
    	}
    	private MethodDeclarationFormatInfo _methodDeclarationFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "OperatorDeclaration" type.
        /// </summary>
    	public virtual OperatorDeclarationFormatInfo OperatorDeclarationFormatInfo
    	{
    		get => _operatorDeclarationFormatInfo ?? (_operatorDeclarationFormatInfo = new OperatorDeclarationFormatInfo());
    		set => _operatorDeclarationFormatInfo = value;
    	}
    	private OperatorDeclarationFormatInfo _operatorDeclarationFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "ConversionOperatorDeclaration" type.
        /// </summary>
    	public virtual ConversionOperatorDeclarationFormatInfo ConversionOperatorDeclarationFormatInfo
    	{
    		get => _conversionOperatorDeclarationFormatInfo ?? (_conversionOperatorDeclarationFormatInfo = new ConversionOperatorDeclarationFormatInfo());
    		set => _conversionOperatorDeclarationFormatInfo = value;
    	}
    	private ConversionOperatorDeclarationFormatInfo _conversionOperatorDeclarationFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "ConstructorDeclaration" type.
        /// </summary>
    	public virtual ConstructorDeclarationFormatInfo ConstructorDeclarationFormatInfo
    	{
    		get => _constructorDeclarationFormatInfo ?? (_constructorDeclarationFormatInfo = new ConstructorDeclarationFormatInfo());
    		set => _constructorDeclarationFormatInfo = value;
    	}
    	private ConstructorDeclarationFormatInfo _constructorDeclarationFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "DestructorDeclaration" type.
        /// </summary>
    	public virtual DestructorDeclarationFormatInfo DestructorDeclarationFormatInfo
    	{
    		get => _destructorDeclarationFormatInfo ?? (_destructorDeclarationFormatInfo = new DestructorDeclarationFormatInfo());
    		set => _destructorDeclarationFormatInfo = value;
    	}
    	private DestructorDeclarationFormatInfo _destructorDeclarationFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "PropertyDeclaration" type.
        /// </summary>
    	public virtual PropertyDeclarationFormatInfo PropertyDeclarationFormatInfo
    	{
    		get => _propertyDeclarationFormatInfo ?? (_propertyDeclarationFormatInfo = new PropertyDeclarationFormatInfo());
    		set => _propertyDeclarationFormatInfo = value;
    	}
    	private PropertyDeclarationFormatInfo _propertyDeclarationFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "EventDeclaration" type.
        /// </summary>
    	public virtual EventDeclarationFormatInfo EventDeclarationFormatInfo
    	{
    		get => _eventDeclarationFormatInfo ?? (_eventDeclarationFormatInfo = new EventDeclarationFormatInfo());
    		set => _eventDeclarationFormatInfo = value;
    	}
    	private EventDeclarationFormatInfo _eventDeclarationFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "IndexerDeclaration" type.
        /// </summary>
    	public virtual IndexerDeclarationFormatInfo IndexerDeclarationFormatInfo
    	{
    		get => _indexerDeclarationFormatInfo ?? (_indexerDeclarationFormatInfo = new IndexerDeclarationFormatInfo());
    		set => _indexerDeclarationFormatInfo = value;
    	}
    	private IndexerDeclarationFormatInfo _indexerDeclarationFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "SimpleBaseType" type.
        /// </summary>
    	public virtual SimpleBaseTypeFormatInfo SimpleBaseTypeFormatInfo
    	{
    		get => _simpleBaseTypeFormatInfo ?? (_simpleBaseTypeFormatInfo = new SimpleBaseTypeFormatInfo());
    		set => _simpleBaseTypeFormatInfo = value;
    	}
    	private SimpleBaseTypeFormatInfo _simpleBaseTypeFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "ConstructorConstraint" type.
        /// </summary>
    	public virtual ConstructorConstraintFormatInfo ConstructorConstraintFormatInfo
    	{
    		get => _constructorConstraintFormatInfo ?? (_constructorConstraintFormatInfo = new ConstructorConstraintFormatInfo());
    		set => _constructorConstraintFormatInfo = value;
    	}
    	private ConstructorConstraintFormatInfo _constructorConstraintFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "ClassOrStructConstraint" type.
        /// </summary>
    	public virtual ClassOrStructConstraintFormatInfo ClassOrStructConstraintFormatInfo
    	{
    		get => _classOrStructConstraintFormatInfo ?? (_classOrStructConstraintFormatInfo = new ClassOrStructConstraintFormatInfo());
    		set => _classOrStructConstraintFormatInfo = value;
    	}
    	private ClassOrStructConstraintFormatInfo _classOrStructConstraintFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "TypeConstraint" type.
        /// </summary>
    	public virtual TypeConstraintFormatInfo TypeConstraintFormatInfo
    	{
    		get => _typeConstraintFormatInfo ?? (_typeConstraintFormatInfo = new TypeConstraintFormatInfo());
    		set => _typeConstraintFormatInfo = value;
    	}
    	private TypeConstraintFormatInfo _typeConstraintFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "ParameterList" type.
        /// </summary>
    	public virtual ParameterListFormatInfo ParameterListFormatInfo
    	{
    		get => _parameterListFormatInfo ?? (_parameterListFormatInfo = new ParameterListFormatInfo());
    		set => _parameterListFormatInfo = value;
    	}
    	private ParameterListFormatInfo _parameterListFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "BracketedParameterList" type.
        /// </summary>
    	public virtual BracketedParameterListFormatInfo BracketedParameterListFormatInfo
    	{
    		get => _bracketedParameterListFormatInfo ?? (_bracketedParameterListFormatInfo = new BracketedParameterListFormatInfo());
    		set => _bracketedParameterListFormatInfo = value;
    	}
    	private BracketedParameterListFormatInfo _bracketedParameterListFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "SkippedTokensTrivia" type.
        /// </summary>
    	public virtual SkippedTokensTriviaFormatInfo SkippedTokensTriviaFormatInfo
    	{
    		get => _skippedTokensTriviaFormatInfo ?? (_skippedTokensTriviaFormatInfo = new SkippedTokensTriviaFormatInfo());
    		set => _skippedTokensTriviaFormatInfo = value;
    	}
    	private SkippedTokensTriviaFormatInfo _skippedTokensTriviaFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "DocumentationCommentTrivia" type.
        /// </summary>
    	public virtual DocumentationCommentTriviaFormatInfo DocumentationCommentTriviaFormatInfo
    	{
    		get => _documentationCommentTriviaFormatInfo ?? (_documentationCommentTriviaFormatInfo = new DocumentationCommentTriviaFormatInfo());
    		set => _documentationCommentTriviaFormatInfo = value;
    	}
    	private DocumentationCommentTriviaFormatInfo _documentationCommentTriviaFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "EndIfDirectiveTrivia" type.
        /// </summary>
    	public virtual EndIfDirectiveTriviaFormatInfo EndIfDirectiveTriviaFormatInfo
    	{
    		get => _endIfDirectiveTriviaFormatInfo ?? (_endIfDirectiveTriviaFormatInfo = new EndIfDirectiveTriviaFormatInfo());
    		set => _endIfDirectiveTriviaFormatInfo = value;
    	}
    	private EndIfDirectiveTriviaFormatInfo _endIfDirectiveTriviaFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "RegionDirectiveTrivia" type.
        /// </summary>
    	public virtual RegionDirectiveTriviaFormatInfo RegionDirectiveTriviaFormatInfo
    	{
    		get => _regionDirectiveTriviaFormatInfo ?? (_regionDirectiveTriviaFormatInfo = new RegionDirectiveTriviaFormatInfo());
    		set => _regionDirectiveTriviaFormatInfo = value;
    	}
    	private RegionDirectiveTriviaFormatInfo _regionDirectiveTriviaFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "EndRegionDirectiveTrivia" type.
        /// </summary>
    	public virtual EndRegionDirectiveTriviaFormatInfo EndRegionDirectiveTriviaFormatInfo
    	{
    		get => _endRegionDirectiveTriviaFormatInfo ?? (_endRegionDirectiveTriviaFormatInfo = new EndRegionDirectiveTriviaFormatInfo());
    		set => _endRegionDirectiveTriviaFormatInfo = value;
    	}
    	private EndRegionDirectiveTriviaFormatInfo _endRegionDirectiveTriviaFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "ErrorDirectiveTrivia" type.
        /// </summary>
    	public virtual ErrorDirectiveTriviaFormatInfo ErrorDirectiveTriviaFormatInfo
    	{
    		get => _errorDirectiveTriviaFormatInfo ?? (_errorDirectiveTriviaFormatInfo = new ErrorDirectiveTriviaFormatInfo());
    		set => _errorDirectiveTriviaFormatInfo = value;
    	}
    	private ErrorDirectiveTriviaFormatInfo _errorDirectiveTriviaFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "WarningDirectiveTrivia" type.
        /// </summary>
    	public virtual WarningDirectiveTriviaFormatInfo WarningDirectiveTriviaFormatInfo
    	{
    		get => _warningDirectiveTriviaFormatInfo ?? (_warningDirectiveTriviaFormatInfo = new WarningDirectiveTriviaFormatInfo());
    		set => _warningDirectiveTriviaFormatInfo = value;
    	}
    	private WarningDirectiveTriviaFormatInfo _warningDirectiveTriviaFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "BadDirectiveTrivia" type.
        /// </summary>
    	public virtual BadDirectiveTriviaFormatInfo BadDirectiveTriviaFormatInfo
    	{
    		get => _badDirectiveTriviaFormatInfo ?? (_badDirectiveTriviaFormatInfo = new BadDirectiveTriviaFormatInfo());
    		set => _badDirectiveTriviaFormatInfo = value;
    	}
    	private BadDirectiveTriviaFormatInfo _badDirectiveTriviaFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "DefineDirectiveTrivia" type.
        /// </summary>
    	public virtual DefineDirectiveTriviaFormatInfo DefineDirectiveTriviaFormatInfo
    	{
    		get => _defineDirectiveTriviaFormatInfo ?? (_defineDirectiveTriviaFormatInfo = new DefineDirectiveTriviaFormatInfo());
    		set => _defineDirectiveTriviaFormatInfo = value;
    	}
    	private DefineDirectiveTriviaFormatInfo _defineDirectiveTriviaFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "UndefDirectiveTrivia" type.
        /// </summary>
    	public virtual UndefDirectiveTriviaFormatInfo UndefDirectiveTriviaFormatInfo
    	{
    		get => _undefDirectiveTriviaFormatInfo ?? (_undefDirectiveTriviaFormatInfo = new UndefDirectiveTriviaFormatInfo());
    		set => _undefDirectiveTriviaFormatInfo = value;
    	}
    	private UndefDirectiveTriviaFormatInfo _undefDirectiveTriviaFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "LineDirectiveTrivia" type.
        /// </summary>
    	public virtual LineDirectiveTriviaFormatInfo LineDirectiveTriviaFormatInfo
    	{
    		get => _lineDirectiveTriviaFormatInfo ?? (_lineDirectiveTriviaFormatInfo = new LineDirectiveTriviaFormatInfo());
    		set => _lineDirectiveTriviaFormatInfo = value;
    	}
    	private LineDirectiveTriviaFormatInfo _lineDirectiveTriviaFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "PragmaWarningDirectiveTrivia" type.
        /// </summary>
    	public virtual PragmaWarningDirectiveTriviaFormatInfo PragmaWarningDirectiveTriviaFormatInfo
    	{
    		get => _pragmaWarningDirectiveTriviaFormatInfo ?? (_pragmaWarningDirectiveTriviaFormatInfo = new PragmaWarningDirectiveTriviaFormatInfo());
    		set => _pragmaWarningDirectiveTriviaFormatInfo = value;
    	}
    	private PragmaWarningDirectiveTriviaFormatInfo _pragmaWarningDirectiveTriviaFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "PragmaChecksumDirectiveTrivia" type.
        /// </summary>
    	public virtual PragmaChecksumDirectiveTriviaFormatInfo PragmaChecksumDirectiveTriviaFormatInfo
    	{
    		get => _pragmaChecksumDirectiveTriviaFormatInfo ?? (_pragmaChecksumDirectiveTriviaFormatInfo = new PragmaChecksumDirectiveTriviaFormatInfo());
    		set => _pragmaChecksumDirectiveTriviaFormatInfo = value;
    	}
    	private PragmaChecksumDirectiveTriviaFormatInfo _pragmaChecksumDirectiveTriviaFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "ReferenceDirectiveTrivia" type.
        /// </summary>
    	public virtual ReferenceDirectiveTriviaFormatInfo ReferenceDirectiveTriviaFormatInfo
    	{
    		get => _referenceDirectiveTriviaFormatInfo ?? (_referenceDirectiveTriviaFormatInfo = new ReferenceDirectiveTriviaFormatInfo());
    		set => _referenceDirectiveTriviaFormatInfo = value;
    	}
    	private ReferenceDirectiveTriviaFormatInfo _referenceDirectiveTriviaFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "LoadDirectiveTrivia" type.
        /// </summary>
    	public virtual LoadDirectiveTriviaFormatInfo LoadDirectiveTriviaFormatInfo
    	{
    		get => _loadDirectiveTriviaFormatInfo ?? (_loadDirectiveTriviaFormatInfo = new LoadDirectiveTriviaFormatInfo());
    		set => _loadDirectiveTriviaFormatInfo = value;
    	}
    	private LoadDirectiveTriviaFormatInfo _loadDirectiveTriviaFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "ShebangDirectiveTrivia" type.
        /// </summary>
    	public virtual ShebangDirectiveTriviaFormatInfo ShebangDirectiveTriviaFormatInfo
    	{
    		get => _shebangDirectiveTriviaFormatInfo ?? (_shebangDirectiveTriviaFormatInfo = new ShebangDirectiveTriviaFormatInfo());
    		set => _shebangDirectiveTriviaFormatInfo = value;
    	}
    	private ShebangDirectiveTriviaFormatInfo _shebangDirectiveTriviaFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "ElseDirectiveTrivia" type.
        /// </summary>
    	public virtual ElseDirectiveTriviaFormatInfo ElseDirectiveTriviaFormatInfo
    	{
    		get => _elseDirectiveTriviaFormatInfo ?? (_elseDirectiveTriviaFormatInfo = new ElseDirectiveTriviaFormatInfo());
    		set => _elseDirectiveTriviaFormatInfo = value;
    	}
    	private ElseDirectiveTriviaFormatInfo _elseDirectiveTriviaFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "IfDirectiveTrivia" type.
        /// </summary>
    	public virtual IfDirectiveTriviaFormatInfo IfDirectiveTriviaFormatInfo
    	{
    		get => _ifDirectiveTriviaFormatInfo ?? (_ifDirectiveTriviaFormatInfo = new IfDirectiveTriviaFormatInfo());
    		set => _ifDirectiveTriviaFormatInfo = value;
    	}
    	private IfDirectiveTriviaFormatInfo _ifDirectiveTriviaFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "ElifDirectiveTrivia" type.
        /// </summary>
    	public virtual ElifDirectiveTriviaFormatInfo ElifDirectiveTriviaFormatInfo
    	{
    		get => _elifDirectiveTriviaFormatInfo ?? (_elifDirectiveTriviaFormatInfo = new ElifDirectiveTriviaFormatInfo());
    		set => _elifDirectiveTriviaFormatInfo = value;
    	}
    	private ElifDirectiveTriviaFormatInfo _elifDirectiveTriviaFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "TypeCref" type.
        /// </summary>
    	public virtual TypeCrefFormatInfo TypeCrefFormatInfo
    	{
    		get => _typeCrefFormatInfo ?? (_typeCrefFormatInfo = new TypeCrefFormatInfo());
    		set => _typeCrefFormatInfo = value;
    	}
    	private TypeCrefFormatInfo _typeCrefFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "QualifiedCref" type.
        /// </summary>
    	public virtual QualifiedCrefFormatInfo QualifiedCrefFormatInfo
    	{
    		get => _qualifiedCrefFormatInfo ?? (_qualifiedCrefFormatInfo = new QualifiedCrefFormatInfo());
    		set => _qualifiedCrefFormatInfo = value;
    	}
    	private QualifiedCrefFormatInfo _qualifiedCrefFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "NameMemberCref" type.
        /// </summary>
    	public virtual NameMemberCrefFormatInfo NameMemberCrefFormatInfo
    	{
    		get => _nameMemberCrefFormatInfo ?? (_nameMemberCrefFormatInfo = new NameMemberCrefFormatInfo());
    		set => _nameMemberCrefFormatInfo = value;
    	}
    	private NameMemberCrefFormatInfo _nameMemberCrefFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "IndexerMemberCref" type.
        /// </summary>
    	public virtual IndexerMemberCrefFormatInfo IndexerMemberCrefFormatInfo
    	{
    		get => _indexerMemberCrefFormatInfo ?? (_indexerMemberCrefFormatInfo = new IndexerMemberCrefFormatInfo());
    		set => _indexerMemberCrefFormatInfo = value;
    	}
    	private IndexerMemberCrefFormatInfo _indexerMemberCrefFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "OperatorMemberCref" type.
        /// </summary>
    	public virtual OperatorMemberCrefFormatInfo OperatorMemberCrefFormatInfo
    	{
    		get => _operatorMemberCrefFormatInfo ?? (_operatorMemberCrefFormatInfo = new OperatorMemberCrefFormatInfo());
    		set => _operatorMemberCrefFormatInfo = value;
    	}
    	private OperatorMemberCrefFormatInfo _operatorMemberCrefFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "ConversionOperatorMemberCref" type.
        /// </summary>
    	public virtual ConversionOperatorMemberCrefFormatInfo ConversionOperatorMemberCrefFormatInfo
    	{
    		get => _conversionOperatorMemberCrefFormatInfo ?? (_conversionOperatorMemberCrefFormatInfo = new ConversionOperatorMemberCrefFormatInfo());
    		set => _conversionOperatorMemberCrefFormatInfo = value;
    	}
    	private ConversionOperatorMemberCrefFormatInfo _conversionOperatorMemberCrefFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "CrefParameterList" type.
        /// </summary>
    	public virtual CrefParameterListFormatInfo CrefParameterListFormatInfo
    	{
    		get => _crefParameterListFormatInfo ?? (_crefParameterListFormatInfo = new CrefParameterListFormatInfo());
    		set => _crefParameterListFormatInfo = value;
    	}
    	private CrefParameterListFormatInfo _crefParameterListFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "CrefBracketedParameterList" type.
        /// </summary>
    	public virtual CrefBracketedParameterListFormatInfo CrefBracketedParameterListFormatInfo
    	{
    		get => _crefBracketedParameterListFormatInfo ?? (_crefBracketedParameterListFormatInfo = new CrefBracketedParameterListFormatInfo());
    		set => _crefBracketedParameterListFormatInfo = value;
    	}
    	private CrefBracketedParameterListFormatInfo _crefBracketedParameterListFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "XmlElement" type.
        /// </summary>
    	public virtual XmlElementFormatInfo XmlElementFormatInfo
    	{
    		get => _xmlElementFormatInfo ?? (_xmlElementFormatInfo = new XmlElementFormatInfo());
    		set => _xmlElementFormatInfo = value;
    	}
    	private XmlElementFormatInfo _xmlElementFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "XmlEmptyElement" type.
        /// </summary>
    	public virtual XmlEmptyElementFormatInfo XmlEmptyElementFormatInfo
    	{
    		get => _xmlEmptyElementFormatInfo ?? (_xmlEmptyElementFormatInfo = new XmlEmptyElementFormatInfo());
    		set => _xmlEmptyElementFormatInfo = value;
    	}
    	private XmlEmptyElementFormatInfo _xmlEmptyElementFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "XmlText" type.
        /// </summary>
    	public virtual XmlTextFormatInfo XmlTextFormatInfo
    	{
    		get => _xmlTextFormatInfo ?? (_xmlTextFormatInfo = new XmlTextFormatInfo());
    		set => _xmlTextFormatInfo = value;
    	}
    	private XmlTextFormatInfo _xmlTextFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "XmlCDataSection" type.
        /// </summary>
    	public virtual XmlCDataSectionFormatInfo XmlCDataSectionFormatInfo
    	{
    		get => _xmlCDataSectionFormatInfo ?? (_xmlCDataSectionFormatInfo = new XmlCDataSectionFormatInfo());
    		set => _xmlCDataSectionFormatInfo = value;
    	}
    	private XmlCDataSectionFormatInfo _xmlCDataSectionFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "XmlProcessingInstruction" type.
        /// </summary>
    	public virtual XmlProcessingInstructionFormatInfo XmlProcessingInstructionFormatInfo
    	{
    		get => _xmlProcessingInstructionFormatInfo ?? (_xmlProcessingInstructionFormatInfo = new XmlProcessingInstructionFormatInfo());
    		set => _xmlProcessingInstructionFormatInfo = value;
    	}
    	private XmlProcessingInstructionFormatInfo _xmlProcessingInstructionFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "XmlComment" type.
        /// </summary>
    	public virtual XmlCommentFormatInfo XmlCommentFormatInfo
    	{
    		get => _xmlCommentFormatInfo ?? (_xmlCommentFormatInfo = new XmlCommentFormatInfo());
    		set => _xmlCommentFormatInfo = value;
    	}
    	private XmlCommentFormatInfo _xmlCommentFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "XmlTextAttribute" type.
        /// </summary>
    	public virtual XmlTextAttributeFormatInfo XmlTextAttributeFormatInfo
    	{
    		get => _xmlTextAttributeFormatInfo ?? (_xmlTextAttributeFormatInfo = new XmlTextAttributeFormatInfo());
    		set => _xmlTextAttributeFormatInfo = value;
    	}
    	private XmlTextAttributeFormatInfo _xmlTextAttributeFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "XmlCrefAttribute" type.
        /// </summary>
    	public virtual XmlCrefAttributeFormatInfo XmlCrefAttributeFormatInfo
    	{
    		get => _xmlCrefAttributeFormatInfo ?? (_xmlCrefAttributeFormatInfo = new XmlCrefAttributeFormatInfo());
    		set => _xmlCrefAttributeFormatInfo = value;
    	}
    	private XmlCrefAttributeFormatInfo _xmlCrefAttributeFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "XmlNameAttribute" type.
        /// </summary>
    	public virtual XmlNameAttributeFormatInfo XmlNameAttributeFormatInfo
    	{
    		get => _xmlNameAttributeFormatInfo ?? (_xmlNameAttributeFormatInfo = new XmlNameAttributeFormatInfo());
    		set => _xmlNameAttributeFormatInfo = value;
    	}
    	private XmlNameAttributeFormatInfo _xmlNameAttributeFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "ParenthesizedExpression" type.
        /// </summary>
    	public virtual ParenthesizedExpressionFormatInfo ParenthesizedExpressionFormatInfo
    	{
    		get => _parenthesizedExpressionFormatInfo ?? (_parenthesizedExpressionFormatInfo = new ParenthesizedExpressionFormatInfo());
    		set => _parenthesizedExpressionFormatInfo = value;
    	}
    	private ParenthesizedExpressionFormatInfo _parenthesizedExpressionFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "TupleExpression" type.
        /// </summary>
    	public virtual TupleExpressionFormatInfo TupleExpressionFormatInfo
    	{
    		get => _tupleExpressionFormatInfo ?? (_tupleExpressionFormatInfo = new TupleExpressionFormatInfo());
    		set => _tupleExpressionFormatInfo = value;
    	}
    	private TupleExpressionFormatInfo _tupleExpressionFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "PrefixUnaryExpression" type.
        /// </summary>
    	public virtual PrefixUnaryExpressionFormatInfo PrefixUnaryExpressionFormatInfo
    	{
    		get => _prefixUnaryExpressionFormatInfo ?? (_prefixUnaryExpressionFormatInfo = new PrefixUnaryExpressionFormatInfo());
    		set => _prefixUnaryExpressionFormatInfo = value;
    	}
    	private PrefixUnaryExpressionFormatInfo _prefixUnaryExpressionFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "AwaitExpression" type.
        /// </summary>
    	public virtual AwaitExpressionFormatInfo AwaitExpressionFormatInfo
    	{
    		get => _awaitExpressionFormatInfo ?? (_awaitExpressionFormatInfo = new AwaitExpressionFormatInfo());
    		set => _awaitExpressionFormatInfo = value;
    	}
    	private AwaitExpressionFormatInfo _awaitExpressionFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "PostfixUnaryExpression" type.
        /// </summary>
    	public virtual PostfixUnaryExpressionFormatInfo PostfixUnaryExpressionFormatInfo
    	{
    		get => _postfixUnaryExpressionFormatInfo ?? (_postfixUnaryExpressionFormatInfo = new PostfixUnaryExpressionFormatInfo());
    		set => _postfixUnaryExpressionFormatInfo = value;
    	}
    	private PostfixUnaryExpressionFormatInfo _postfixUnaryExpressionFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "MemberAccessExpression" type.
        /// </summary>
    	public virtual MemberAccessExpressionFormatInfo MemberAccessExpressionFormatInfo
    	{
    		get => _memberAccessExpressionFormatInfo ?? (_memberAccessExpressionFormatInfo = new MemberAccessExpressionFormatInfo());
    		set => _memberAccessExpressionFormatInfo = value;
    	}
    	private MemberAccessExpressionFormatInfo _memberAccessExpressionFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "ConditionalAccessExpression" type.
        /// </summary>
    	public virtual ConditionalAccessExpressionFormatInfo ConditionalAccessExpressionFormatInfo
    	{
    		get => _conditionalAccessExpressionFormatInfo ?? (_conditionalAccessExpressionFormatInfo = new ConditionalAccessExpressionFormatInfo());
    		set => _conditionalAccessExpressionFormatInfo = value;
    	}
    	private ConditionalAccessExpressionFormatInfo _conditionalAccessExpressionFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "MemberBindingExpression" type.
        /// </summary>
    	public virtual MemberBindingExpressionFormatInfo MemberBindingExpressionFormatInfo
    	{
    		get => _memberBindingExpressionFormatInfo ?? (_memberBindingExpressionFormatInfo = new MemberBindingExpressionFormatInfo());
    		set => _memberBindingExpressionFormatInfo = value;
    	}
    	private MemberBindingExpressionFormatInfo _memberBindingExpressionFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "ElementBindingExpression" type.
        /// </summary>
    	public virtual ElementBindingExpressionFormatInfo ElementBindingExpressionFormatInfo
    	{
    		get => _elementBindingExpressionFormatInfo ?? (_elementBindingExpressionFormatInfo = new ElementBindingExpressionFormatInfo());
    		set => _elementBindingExpressionFormatInfo = value;
    	}
    	private ElementBindingExpressionFormatInfo _elementBindingExpressionFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "ImplicitElementAccess" type.
        /// </summary>
    	public virtual ImplicitElementAccessFormatInfo ImplicitElementAccessFormatInfo
    	{
    		get => _implicitElementAccessFormatInfo ?? (_implicitElementAccessFormatInfo = new ImplicitElementAccessFormatInfo());
    		set => _implicitElementAccessFormatInfo = value;
    	}
    	private ImplicitElementAccessFormatInfo _implicitElementAccessFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "BinaryExpression" type.
        /// </summary>
    	public virtual BinaryExpressionFormatInfo BinaryExpressionFormatInfo
    	{
    		get => _binaryExpressionFormatInfo ?? (_binaryExpressionFormatInfo = new BinaryExpressionFormatInfo());
    		set => _binaryExpressionFormatInfo = value;
    	}
    	private BinaryExpressionFormatInfo _binaryExpressionFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "AssignmentExpression" type.
        /// </summary>
    	public virtual AssignmentExpressionFormatInfo AssignmentExpressionFormatInfo
    	{
    		get => _assignmentExpressionFormatInfo ?? (_assignmentExpressionFormatInfo = new AssignmentExpressionFormatInfo());
    		set => _assignmentExpressionFormatInfo = value;
    	}
    	private AssignmentExpressionFormatInfo _assignmentExpressionFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "ConditionalExpression" type.
        /// </summary>
    	public virtual ConditionalExpressionFormatInfo ConditionalExpressionFormatInfo
    	{
    		get => _conditionalExpressionFormatInfo ?? (_conditionalExpressionFormatInfo = new ConditionalExpressionFormatInfo());
    		set => _conditionalExpressionFormatInfo = value;
    	}
    	private ConditionalExpressionFormatInfo _conditionalExpressionFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "LiteralExpression" type.
        /// </summary>
    	public virtual LiteralExpressionFormatInfo LiteralExpressionFormatInfo
    	{
    		get => _literalExpressionFormatInfo ?? (_literalExpressionFormatInfo = new LiteralExpressionFormatInfo());
    		set => _literalExpressionFormatInfo = value;
    	}
    	private LiteralExpressionFormatInfo _literalExpressionFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "MakeRefExpression" type.
        /// </summary>
    	public virtual MakeRefExpressionFormatInfo MakeRefExpressionFormatInfo
    	{
    		get => _makeRefExpressionFormatInfo ?? (_makeRefExpressionFormatInfo = new MakeRefExpressionFormatInfo());
    		set => _makeRefExpressionFormatInfo = value;
    	}
    	private MakeRefExpressionFormatInfo _makeRefExpressionFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "RefTypeExpression" type.
        /// </summary>
    	public virtual RefTypeExpressionFormatInfo RefTypeExpressionFormatInfo
    	{
    		get => _refTypeExpressionFormatInfo ?? (_refTypeExpressionFormatInfo = new RefTypeExpressionFormatInfo());
    		set => _refTypeExpressionFormatInfo = value;
    	}
    	private RefTypeExpressionFormatInfo _refTypeExpressionFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "RefValueExpression" type.
        /// </summary>
    	public virtual RefValueExpressionFormatInfo RefValueExpressionFormatInfo
    	{
    		get => _refValueExpressionFormatInfo ?? (_refValueExpressionFormatInfo = new RefValueExpressionFormatInfo());
    		set => _refValueExpressionFormatInfo = value;
    	}
    	private RefValueExpressionFormatInfo _refValueExpressionFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "CheckedExpression" type.
        /// </summary>
    	public virtual CheckedExpressionFormatInfo CheckedExpressionFormatInfo
    	{
    		get => _checkedExpressionFormatInfo ?? (_checkedExpressionFormatInfo = new CheckedExpressionFormatInfo());
    		set => _checkedExpressionFormatInfo = value;
    	}
    	private CheckedExpressionFormatInfo _checkedExpressionFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "DefaultExpression" type.
        /// </summary>
    	public virtual DefaultExpressionFormatInfo DefaultExpressionFormatInfo
    	{
    		get => _defaultExpressionFormatInfo ?? (_defaultExpressionFormatInfo = new DefaultExpressionFormatInfo());
    		set => _defaultExpressionFormatInfo = value;
    	}
    	private DefaultExpressionFormatInfo _defaultExpressionFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "TypeOfExpression" type.
        /// </summary>
    	public virtual TypeOfExpressionFormatInfo TypeOfExpressionFormatInfo
    	{
    		get => _typeOfExpressionFormatInfo ?? (_typeOfExpressionFormatInfo = new TypeOfExpressionFormatInfo());
    		set => _typeOfExpressionFormatInfo = value;
    	}
    	private TypeOfExpressionFormatInfo _typeOfExpressionFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "SizeOfExpression" type.
        /// </summary>
    	public virtual SizeOfExpressionFormatInfo SizeOfExpressionFormatInfo
    	{
    		get => _sizeOfExpressionFormatInfo ?? (_sizeOfExpressionFormatInfo = new SizeOfExpressionFormatInfo());
    		set => _sizeOfExpressionFormatInfo = value;
    	}
    	private SizeOfExpressionFormatInfo _sizeOfExpressionFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "InvocationExpression" type.
        /// </summary>
    	public virtual InvocationExpressionFormatInfo InvocationExpressionFormatInfo
    	{
    		get => _invocationExpressionFormatInfo ?? (_invocationExpressionFormatInfo = new InvocationExpressionFormatInfo());
    		set => _invocationExpressionFormatInfo = value;
    	}
    	private InvocationExpressionFormatInfo _invocationExpressionFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "ElementAccessExpression" type.
        /// </summary>
    	public virtual ElementAccessExpressionFormatInfo ElementAccessExpressionFormatInfo
    	{
    		get => _elementAccessExpressionFormatInfo ?? (_elementAccessExpressionFormatInfo = new ElementAccessExpressionFormatInfo());
    		set => _elementAccessExpressionFormatInfo = value;
    	}
    	private ElementAccessExpressionFormatInfo _elementAccessExpressionFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "DeclarationExpression" type.
        /// </summary>
    	public virtual DeclarationExpressionFormatInfo DeclarationExpressionFormatInfo
    	{
    		get => _declarationExpressionFormatInfo ?? (_declarationExpressionFormatInfo = new DeclarationExpressionFormatInfo());
    		set => _declarationExpressionFormatInfo = value;
    	}
    	private DeclarationExpressionFormatInfo _declarationExpressionFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "CastExpression" type.
        /// </summary>
    	public virtual CastExpressionFormatInfo CastExpressionFormatInfo
    	{
    		get => _castExpressionFormatInfo ?? (_castExpressionFormatInfo = new CastExpressionFormatInfo());
    		set => _castExpressionFormatInfo = value;
    	}
    	private CastExpressionFormatInfo _castExpressionFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "RefExpression" type.
        /// </summary>
    	public virtual RefExpressionFormatInfo RefExpressionFormatInfo
    	{
    		get => _refExpressionFormatInfo ?? (_refExpressionFormatInfo = new RefExpressionFormatInfo());
    		set => _refExpressionFormatInfo = value;
    	}
    	private RefExpressionFormatInfo _refExpressionFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "InitializerExpression" type.
        /// </summary>
    	public virtual InitializerExpressionFormatInfo InitializerExpressionFormatInfo
    	{
    		get => _initializerExpressionFormatInfo ?? (_initializerExpressionFormatInfo = new InitializerExpressionFormatInfo());
    		set => _initializerExpressionFormatInfo = value;
    	}
    	private InitializerExpressionFormatInfo _initializerExpressionFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "ObjectCreationExpression" type.
        /// </summary>
    	public virtual ObjectCreationExpressionFormatInfo ObjectCreationExpressionFormatInfo
    	{
    		get => _objectCreationExpressionFormatInfo ?? (_objectCreationExpressionFormatInfo = new ObjectCreationExpressionFormatInfo());
    		set => _objectCreationExpressionFormatInfo = value;
    	}
    	private ObjectCreationExpressionFormatInfo _objectCreationExpressionFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "AnonymousObjectCreationExpression" type.
        /// </summary>
    	public virtual AnonymousObjectCreationExpressionFormatInfo AnonymousObjectCreationExpressionFormatInfo
    	{
    		get => _anonymousObjectCreationExpressionFormatInfo ?? (_anonymousObjectCreationExpressionFormatInfo = new AnonymousObjectCreationExpressionFormatInfo());
    		set => _anonymousObjectCreationExpressionFormatInfo = value;
    	}
    	private AnonymousObjectCreationExpressionFormatInfo _anonymousObjectCreationExpressionFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "ArrayCreationExpression" type.
        /// </summary>
    	public virtual ArrayCreationExpressionFormatInfo ArrayCreationExpressionFormatInfo
    	{
    		get => _arrayCreationExpressionFormatInfo ?? (_arrayCreationExpressionFormatInfo = new ArrayCreationExpressionFormatInfo());
    		set => _arrayCreationExpressionFormatInfo = value;
    	}
    	private ArrayCreationExpressionFormatInfo _arrayCreationExpressionFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "ImplicitArrayCreationExpression" type.
        /// </summary>
    	public virtual ImplicitArrayCreationExpressionFormatInfo ImplicitArrayCreationExpressionFormatInfo
    	{
    		get => _implicitArrayCreationExpressionFormatInfo ?? (_implicitArrayCreationExpressionFormatInfo = new ImplicitArrayCreationExpressionFormatInfo());
    		set => _implicitArrayCreationExpressionFormatInfo = value;
    	}
    	private ImplicitArrayCreationExpressionFormatInfo _implicitArrayCreationExpressionFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "StackAllocArrayCreationExpression" type.
        /// </summary>
    	public virtual StackAllocArrayCreationExpressionFormatInfo StackAllocArrayCreationExpressionFormatInfo
    	{
    		get => _stackAllocArrayCreationExpressionFormatInfo ?? (_stackAllocArrayCreationExpressionFormatInfo = new StackAllocArrayCreationExpressionFormatInfo());
    		set => _stackAllocArrayCreationExpressionFormatInfo = value;
    	}
    	private StackAllocArrayCreationExpressionFormatInfo _stackAllocArrayCreationExpressionFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "QueryExpression" type.
        /// </summary>
    	public virtual QueryExpressionFormatInfo QueryExpressionFormatInfo
    	{
    		get => _queryExpressionFormatInfo ?? (_queryExpressionFormatInfo = new QueryExpressionFormatInfo());
    		set => _queryExpressionFormatInfo = value;
    	}
    	private QueryExpressionFormatInfo _queryExpressionFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "OmittedArraySizeExpression" type.
        /// </summary>
    	public virtual OmittedArraySizeExpressionFormatInfo OmittedArraySizeExpressionFormatInfo
    	{
    		get => _omittedArraySizeExpressionFormatInfo ?? (_omittedArraySizeExpressionFormatInfo = new OmittedArraySizeExpressionFormatInfo());
    		set => _omittedArraySizeExpressionFormatInfo = value;
    	}
    	private OmittedArraySizeExpressionFormatInfo _omittedArraySizeExpressionFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "InterpolatedStringExpression" type.
        /// </summary>
    	public virtual InterpolatedStringExpressionFormatInfo InterpolatedStringExpressionFormatInfo
    	{
    		get => _interpolatedStringExpressionFormatInfo ?? (_interpolatedStringExpressionFormatInfo = new InterpolatedStringExpressionFormatInfo());
    		set => _interpolatedStringExpressionFormatInfo = value;
    	}
    	private InterpolatedStringExpressionFormatInfo _interpolatedStringExpressionFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "IsPatternExpression" type.
        /// </summary>
    	public virtual IsPatternExpressionFormatInfo IsPatternExpressionFormatInfo
    	{
    		get => _isPatternExpressionFormatInfo ?? (_isPatternExpressionFormatInfo = new IsPatternExpressionFormatInfo());
    		set => _isPatternExpressionFormatInfo = value;
    	}
    	private IsPatternExpressionFormatInfo _isPatternExpressionFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "ThrowExpression" type.
        /// </summary>
    	public virtual ThrowExpressionFormatInfo ThrowExpressionFormatInfo
    	{
    		get => _throwExpressionFormatInfo ?? (_throwExpressionFormatInfo = new ThrowExpressionFormatInfo());
    		set => _throwExpressionFormatInfo = value;
    	}
    	private ThrowExpressionFormatInfo _throwExpressionFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "PredefinedType" type.
        /// </summary>
    	public virtual PredefinedTypeFormatInfo PredefinedTypeFormatInfo
    	{
    		get => _predefinedTypeFormatInfo ?? (_predefinedTypeFormatInfo = new PredefinedTypeFormatInfo());
    		set => _predefinedTypeFormatInfo = value;
    	}
    	private PredefinedTypeFormatInfo _predefinedTypeFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "ArrayType" type.
        /// </summary>
    	public virtual ArrayTypeFormatInfo ArrayTypeFormatInfo
    	{
    		get => _arrayTypeFormatInfo ?? (_arrayTypeFormatInfo = new ArrayTypeFormatInfo());
    		set => _arrayTypeFormatInfo = value;
    	}
    	private ArrayTypeFormatInfo _arrayTypeFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "PointerType" type.
        /// </summary>
    	public virtual PointerTypeFormatInfo PointerTypeFormatInfo
    	{
    		get => _pointerTypeFormatInfo ?? (_pointerTypeFormatInfo = new PointerTypeFormatInfo());
    		set => _pointerTypeFormatInfo = value;
    	}
    	private PointerTypeFormatInfo _pointerTypeFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "NullableType" type.
        /// </summary>
    	public virtual NullableTypeFormatInfo NullableTypeFormatInfo
    	{
    		get => _nullableTypeFormatInfo ?? (_nullableTypeFormatInfo = new NullableTypeFormatInfo());
    		set => _nullableTypeFormatInfo = value;
    	}
    	private NullableTypeFormatInfo _nullableTypeFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "TupleType" type.
        /// </summary>
    	public virtual TupleTypeFormatInfo TupleTypeFormatInfo
    	{
    		get => _tupleTypeFormatInfo ?? (_tupleTypeFormatInfo = new TupleTypeFormatInfo());
    		set => _tupleTypeFormatInfo = value;
    	}
    	private TupleTypeFormatInfo _tupleTypeFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "OmittedTypeArgument" type.
        /// </summary>
    	public virtual OmittedTypeArgumentFormatInfo OmittedTypeArgumentFormatInfo
    	{
    		get => _omittedTypeArgumentFormatInfo ?? (_omittedTypeArgumentFormatInfo = new OmittedTypeArgumentFormatInfo());
    		set => _omittedTypeArgumentFormatInfo = value;
    	}
    	private OmittedTypeArgumentFormatInfo _omittedTypeArgumentFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "RefType" type.
        /// </summary>
    	public virtual RefTypeFormatInfo RefTypeFormatInfo
    	{
    		get => _refTypeFormatInfo ?? (_refTypeFormatInfo = new RefTypeFormatInfo());
    		set => _refTypeFormatInfo = value;
    	}
    	private RefTypeFormatInfo _refTypeFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "QualifiedName" type.
        /// </summary>
    	public virtual QualifiedNameFormatInfo QualifiedNameFormatInfo
    	{
    		get => _qualifiedNameFormatInfo ?? (_qualifiedNameFormatInfo = new QualifiedNameFormatInfo());
    		set => _qualifiedNameFormatInfo = value;
    	}
    	private QualifiedNameFormatInfo _qualifiedNameFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "AliasQualifiedName" type.
        /// </summary>
    	public virtual AliasQualifiedNameFormatInfo AliasQualifiedNameFormatInfo
    	{
    		get => _aliasQualifiedNameFormatInfo ?? (_aliasQualifiedNameFormatInfo = new AliasQualifiedNameFormatInfo());
    		set => _aliasQualifiedNameFormatInfo = value;
    	}
    	private AliasQualifiedNameFormatInfo _aliasQualifiedNameFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "IdentifierName" type.
        /// </summary>
    	public virtual IdentifierNameFormatInfo IdentifierNameFormatInfo
    	{
    		get => _identifierNameFormatInfo ?? (_identifierNameFormatInfo = new IdentifierNameFormatInfo());
    		set => _identifierNameFormatInfo = value;
    	}
    	private IdentifierNameFormatInfo _identifierNameFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "GenericName" type.
        /// </summary>
    	public virtual GenericNameFormatInfo GenericNameFormatInfo
    	{
    		get => _genericNameFormatInfo ?? (_genericNameFormatInfo = new GenericNameFormatInfo());
    		set => _genericNameFormatInfo = value;
    	}
    	private GenericNameFormatInfo _genericNameFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "ThisExpression" type.
        /// </summary>
    	public virtual ThisExpressionFormatInfo ThisExpressionFormatInfo
    	{
    		get => _thisExpressionFormatInfo ?? (_thisExpressionFormatInfo = new ThisExpressionFormatInfo());
    		set => _thisExpressionFormatInfo = value;
    	}
    	private ThisExpressionFormatInfo _thisExpressionFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "BaseExpression" type.
        /// </summary>
    	public virtual BaseExpressionFormatInfo BaseExpressionFormatInfo
    	{
    		get => _baseExpressionFormatInfo ?? (_baseExpressionFormatInfo = new BaseExpressionFormatInfo());
    		set => _baseExpressionFormatInfo = value;
    	}
    	private BaseExpressionFormatInfo _baseExpressionFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "AnonymousMethodExpression" type.
        /// </summary>
    	public virtual AnonymousMethodExpressionFormatInfo AnonymousMethodExpressionFormatInfo
    	{
    		get => _anonymousMethodExpressionFormatInfo ?? (_anonymousMethodExpressionFormatInfo = new AnonymousMethodExpressionFormatInfo());
    		set => _anonymousMethodExpressionFormatInfo = value;
    	}
    	private AnonymousMethodExpressionFormatInfo _anonymousMethodExpressionFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "SimpleLambdaExpression" type.
        /// </summary>
    	public virtual SimpleLambdaExpressionFormatInfo SimpleLambdaExpressionFormatInfo
    	{
    		get => _simpleLambdaExpressionFormatInfo ?? (_simpleLambdaExpressionFormatInfo = new SimpleLambdaExpressionFormatInfo());
    		set => _simpleLambdaExpressionFormatInfo = value;
    	}
    	private SimpleLambdaExpressionFormatInfo _simpleLambdaExpressionFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "ParenthesizedLambdaExpression" type.
        /// </summary>
    	public virtual ParenthesizedLambdaExpressionFormatInfo ParenthesizedLambdaExpressionFormatInfo
    	{
    		get => _parenthesizedLambdaExpressionFormatInfo ?? (_parenthesizedLambdaExpressionFormatInfo = new ParenthesizedLambdaExpressionFormatInfo());
    		set => _parenthesizedLambdaExpressionFormatInfo = value;
    	}
    	private ParenthesizedLambdaExpressionFormatInfo _parenthesizedLambdaExpressionFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "ArgumentList" type.
        /// </summary>
    	public virtual ArgumentListFormatInfo ArgumentListFormatInfo
    	{
    		get => _argumentListFormatInfo ?? (_argumentListFormatInfo = new ArgumentListFormatInfo());
    		set => _argumentListFormatInfo = value;
    	}
    	private ArgumentListFormatInfo _argumentListFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "BracketedArgumentList" type.
        /// </summary>
    	public virtual BracketedArgumentListFormatInfo BracketedArgumentListFormatInfo
    	{
    		get => _bracketedArgumentListFormatInfo ?? (_bracketedArgumentListFormatInfo = new BracketedArgumentListFormatInfo());
    		set => _bracketedArgumentListFormatInfo = value;
    	}
    	private BracketedArgumentListFormatInfo _bracketedArgumentListFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "FromClause" type.
        /// </summary>
    	public virtual FromClauseFormatInfo FromClauseFormatInfo
    	{
    		get => _fromClauseFormatInfo ?? (_fromClauseFormatInfo = new FromClauseFormatInfo());
    		set => _fromClauseFormatInfo = value;
    	}
    	private FromClauseFormatInfo _fromClauseFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "LetClause" type.
        /// </summary>
    	public virtual LetClauseFormatInfo LetClauseFormatInfo
    	{
    		get => _letClauseFormatInfo ?? (_letClauseFormatInfo = new LetClauseFormatInfo());
    		set => _letClauseFormatInfo = value;
    	}
    	private LetClauseFormatInfo _letClauseFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "JoinClause" type.
        /// </summary>
    	public virtual JoinClauseFormatInfo JoinClauseFormatInfo
    	{
    		get => _joinClauseFormatInfo ?? (_joinClauseFormatInfo = new JoinClauseFormatInfo());
    		set => _joinClauseFormatInfo = value;
    	}
    	private JoinClauseFormatInfo _joinClauseFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "WhereClause" type.
        /// </summary>
    	public virtual WhereClauseFormatInfo WhereClauseFormatInfo
    	{
    		get => _whereClauseFormatInfo ?? (_whereClauseFormatInfo = new WhereClauseFormatInfo());
    		set => _whereClauseFormatInfo = value;
    	}
    	private WhereClauseFormatInfo _whereClauseFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "OrderByClause" type.
        /// </summary>
    	public virtual OrderByClauseFormatInfo OrderByClauseFormatInfo
    	{
    		get => _orderByClauseFormatInfo ?? (_orderByClauseFormatInfo = new OrderByClauseFormatInfo());
    		set => _orderByClauseFormatInfo = value;
    	}
    	private OrderByClauseFormatInfo _orderByClauseFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "SelectClause" type.
        /// </summary>
    	public virtual SelectClauseFormatInfo SelectClauseFormatInfo
    	{
    		get => _selectClauseFormatInfo ?? (_selectClauseFormatInfo = new SelectClauseFormatInfo());
    		set => _selectClauseFormatInfo = value;
    	}
    	private SelectClauseFormatInfo _selectClauseFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "GroupClause" type.
        /// </summary>
    	public virtual GroupClauseFormatInfo GroupClauseFormatInfo
    	{
    		get => _groupClauseFormatInfo ?? (_groupClauseFormatInfo = new GroupClauseFormatInfo());
    		set => _groupClauseFormatInfo = value;
    	}
    	private GroupClauseFormatInfo _groupClauseFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "DeclarationPattern" type.
        /// </summary>
    	public virtual DeclarationPatternFormatInfo DeclarationPatternFormatInfo
    	{
    		get => _declarationPatternFormatInfo ?? (_declarationPatternFormatInfo = new DeclarationPatternFormatInfo());
    		set => _declarationPatternFormatInfo = value;
    	}
    	private DeclarationPatternFormatInfo _declarationPatternFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "ConstantPattern" type.
        /// </summary>
    	public virtual ConstantPatternFormatInfo ConstantPatternFormatInfo
    	{
    		get => _constantPatternFormatInfo ?? (_constantPatternFormatInfo = new ConstantPatternFormatInfo());
    		set => _constantPatternFormatInfo = value;
    	}
    	private ConstantPatternFormatInfo _constantPatternFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "InterpolatedStringText" type.
        /// </summary>
    	public virtual InterpolatedStringTextFormatInfo InterpolatedStringTextFormatInfo
    	{
    		get => _interpolatedStringTextFormatInfo ?? (_interpolatedStringTextFormatInfo = new InterpolatedStringTextFormatInfo());
    		set => _interpolatedStringTextFormatInfo = value;
    	}
    	private InterpolatedStringTextFormatInfo _interpolatedStringTextFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "Interpolation" type.
        /// </summary>
    	public virtual InterpolationFormatInfo InterpolationFormatInfo
    	{
    		get => _interpolationFormatInfo ?? (_interpolationFormatInfo = new InterpolationFormatInfo());
    		set => _interpolationFormatInfo = value;
    	}
    	private InterpolationFormatInfo _interpolationFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "Block" type.
        /// </summary>
    	public virtual BlockFormatInfo BlockFormatInfo
    	{
    		get => _blockFormatInfo ?? (_blockFormatInfo = new BlockFormatInfo());
    		set => _blockFormatInfo = value;
    	}
    	private BlockFormatInfo _blockFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "LocalFunctionStatement" type.
        /// </summary>
    	public virtual LocalFunctionStatementFormatInfo LocalFunctionStatementFormatInfo
    	{
    		get => _localFunctionStatementFormatInfo ?? (_localFunctionStatementFormatInfo = new LocalFunctionStatementFormatInfo());
    		set => _localFunctionStatementFormatInfo = value;
    	}
    	private LocalFunctionStatementFormatInfo _localFunctionStatementFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "LocalDeclarationStatement" type.
        /// </summary>
    	public virtual LocalDeclarationStatementFormatInfo LocalDeclarationStatementFormatInfo
    	{
    		get => _localDeclarationStatementFormatInfo ?? (_localDeclarationStatementFormatInfo = new LocalDeclarationStatementFormatInfo());
    		set => _localDeclarationStatementFormatInfo = value;
    	}
    	private LocalDeclarationStatementFormatInfo _localDeclarationStatementFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "ExpressionStatement" type.
        /// </summary>
    	public virtual ExpressionStatementFormatInfo ExpressionStatementFormatInfo
    	{
    		get => _expressionStatementFormatInfo ?? (_expressionStatementFormatInfo = new ExpressionStatementFormatInfo());
    		set => _expressionStatementFormatInfo = value;
    	}
    	private ExpressionStatementFormatInfo _expressionStatementFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "EmptyStatement" type.
        /// </summary>
    	public virtual EmptyStatementFormatInfo EmptyStatementFormatInfo
    	{
    		get => _emptyStatementFormatInfo ?? (_emptyStatementFormatInfo = new EmptyStatementFormatInfo());
    		set => _emptyStatementFormatInfo = value;
    	}
    	private EmptyStatementFormatInfo _emptyStatementFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "LabeledStatement" type.
        /// </summary>
    	public virtual LabeledStatementFormatInfo LabeledStatementFormatInfo
    	{
    		get => _labeledStatementFormatInfo ?? (_labeledStatementFormatInfo = new LabeledStatementFormatInfo());
    		set => _labeledStatementFormatInfo = value;
    	}
    	private LabeledStatementFormatInfo _labeledStatementFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "GotoStatement" type.
        /// </summary>
    	public virtual GotoStatementFormatInfo GotoStatementFormatInfo
    	{
    		get => _gotoStatementFormatInfo ?? (_gotoStatementFormatInfo = new GotoStatementFormatInfo());
    		set => _gotoStatementFormatInfo = value;
    	}
    	private GotoStatementFormatInfo _gotoStatementFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "BreakStatement" type.
        /// </summary>
    	public virtual BreakStatementFormatInfo BreakStatementFormatInfo
    	{
    		get => _breakStatementFormatInfo ?? (_breakStatementFormatInfo = new BreakStatementFormatInfo());
    		set => _breakStatementFormatInfo = value;
    	}
    	private BreakStatementFormatInfo _breakStatementFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "ContinueStatement" type.
        /// </summary>
    	public virtual ContinueStatementFormatInfo ContinueStatementFormatInfo
    	{
    		get => _continueStatementFormatInfo ?? (_continueStatementFormatInfo = new ContinueStatementFormatInfo());
    		set => _continueStatementFormatInfo = value;
    	}
    	private ContinueStatementFormatInfo _continueStatementFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "ReturnStatement" type.
        /// </summary>
    	public virtual ReturnStatementFormatInfo ReturnStatementFormatInfo
    	{
    		get => _returnStatementFormatInfo ?? (_returnStatementFormatInfo = new ReturnStatementFormatInfo());
    		set => _returnStatementFormatInfo = value;
    	}
    	private ReturnStatementFormatInfo _returnStatementFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "ThrowStatement" type.
        /// </summary>
    	public virtual ThrowStatementFormatInfo ThrowStatementFormatInfo
    	{
    		get => _throwStatementFormatInfo ?? (_throwStatementFormatInfo = new ThrowStatementFormatInfo());
    		set => _throwStatementFormatInfo = value;
    	}
    	private ThrowStatementFormatInfo _throwStatementFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "YieldStatement" type.
        /// </summary>
    	public virtual YieldStatementFormatInfo YieldStatementFormatInfo
    	{
    		get => _yieldStatementFormatInfo ?? (_yieldStatementFormatInfo = new YieldStatementFormatInfo());
    		set => _yieldStatementFormatInfo = value;
    	}
    	private YieldStatementFormatInfo _yieldStatementFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "WhileStatement" type.
        /// </summary>
    	public virtual WhileStatementFormatInfo WhileStatementFormatInfo
    	{
    		get => _whileStatementFormatInfo ?? (_whileStatementFormatInfo = new WhileStatementFormatInfo());
    		set => _whileStatementFormatInfo = value;
    	}
    	private WhileStatementFormatInfo _whileStatementFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "DoStatement" type.
        /// </summary>
    	public virtual DoStatementFormatInfo DoStatementFormatInfo
    	{
    		get => _doStatementFormatInfo ?? (_doStatementFormatInfo = new DoStatementFormatInfo());
    		set => _doStatementFormatInfo = value;
    	}
    	private DoStatementFormatInfo _doStatementFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "ForStatement" type.
        /// </summary>
    	public virtual ForStatementFormatInfo ForStatementFormatInfo
    	{
    		get => _forStatementFormatInfo ?? (_forStatementFormatInfo = new ForStatementFormatInfo());
    		set => _forStatementFormatInfo = value;
    	}
    	private ForStatementFormatInfo _forStatementFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "UsingStatement" type.
        /// </summary>
    	public virtual UsingStatementFormatInfo UsingStatementFormatInfo
    	{
    		get => _usingStatementFormatInfo ?? (_usingStatementFormatInfo = new UsingStatementFormatInfo());
    		set => _usingStatementFormatInfo = value;
    	}
    	private UsingStatementFormatInfo _usingStatementFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "FixedStatement" type.
        /// </summary>
    	public virtual FixedStatementFormatInfo FixedStatementFormatInfo
    	{
    		get => _fixedStatementFormatInfo ?? (_fixedStatementFormatInfo = new FixedStatementFormatInfo());
    		set => _fixedStatementFormatInfo = value;
    	}
    	private FixedStatementFormatInfo _fixedStatementFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "CheckedStatement" type.
        /// </summary>
    	public virtual CheckedStatementFormatInfo CheckedStatementFormatInfo
    	{
    		get => _checkedStatementFormatInfo ?? (_checkedStatementFormatInfo = new CheckedStatementFormatInfo());
    		set => _checkedStatementFormatInfo = value;
    	}
    	private CheckedStatementFormatInfo _checkedStatementFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "UnsafeStatement" type.
        /// </summary>
    	public virtual UnsafeStatementFormatInfo UnsafeStatementFormatInfo
    	{
    		get => _unsafeStatementFormatInfo ?? (_unsafeStatementFormatInfo = new UnsafeStatementFormatInfo());
    		set => _unsafeStatementFormatInfo = value;
    	}
    	private UnsafeStatementFormatInfo _unsafeStatementFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "LockStatement" type.
        /// </summary>
    	public virtual LockStatementFormatInfo LockStatementFormatInfo
    	{
    		get => _lockStatementFormatInfo ?? (_lockStatementFormatInfo = new LockStatementFormatInfo());
    		set => _lockStatementFormatInfo = value;
    	}
    	private LockStatementFormatInfo _lockStatementFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "IfStatement" type.
        /// </summary>
    	public virtual IfStatementFormatInfo IfStatementFormatInfo
    	{
    		get => _ifStatementFormatInfo ?? (_ifStatementFormatInfo = new IfStatementFormatInfo());
    		set => _ifStatementFormatInfo = value;
    	}
    	private IfStatementFormatInfo _ifStatementFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "SwitchStatement" type.
        /// </summary>
    	public virtual SwitchStatementFormatInfo SwitchStatementFormatInfo
    	{
    		get => _switchStatementFormatInfo ?? (_switchStatementFormatInfo = new SwitchStatementFormatInfo());
    		set => _switchStatementFormatInfo = value;
    	}
    	private SwitchStatementFormatInfo _switchStatementFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "TryStatement" type.
        /// </summary>
    	public virtual TryStatementFormatInfo TryStatementFormatInfo
    	{
    		get => _tryStatementFormatInfo ?? (_tryStatementFormatInfo = new TryStatementFormatInfo());
    		set => _tryStatementFormatInfo = value;
    	}
    	private TryStatementFormatInfo _tryStatementFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "ForEachStatement" type.
        /// </summary>
    	public virtual ForEachStatementFormatInfo ForEachStatementFormatInfo
    	{
    		get => _forEachStatementFormatInfo ?? (_forEachStatementFormatInfo = new ForEachStatementFormatInfo());
    		set => _forEachStatementFormatInfo = value;
    	}
    	private ForEachStatementFormatInfo _forEachStatementFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "ForEachVariableStatement" type.
        /// </summary>
    	public virtual ForEachVariableStatementFormatInfo ForEachVariableStatementFormatInfo
    	{
    		get => _forEachVariableStatementFormatInfo ?? (_forEachVariableStatementFormatInfo = new ForEachVariableStatementFormatInfo());
    		set => _forEachVariableStatementFormatInfo = value;
    	}
    	private ForEachVariableStatementFormatInfo _forEachVariableStatementFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "SingleVariableDesignation" type.
        /// </summary>
    	public virtual SingleVariableDesignationFormatInfo SingleVariableDesignationFormatInfo
    	{
    		get => _singleVariableDesignationFormatInfo ?? (_singleVariableDesignationFormatInfo = new SingleVariableDesignationFormatInfo());
    		set => _singleVariableDesignationFormatInfo = value;
    	}
    	private SingleVariableDesignationFormatInfo _singleVariableDesignationFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "DiscardDesignation" type.
        /// </summary>
    	public virtual DiscardDesignationFormatInfo DiscardDesignationFormatInfo
    	{
    		get => _discardDesignationFormatInfo ?? (_discardDesignationFormatInfo = new DiscardDesignationFormatInfo());
    		set => _discardDesignationFormatInfo = value;
    	}
    	private DiscardDesignationFormatInfo _discardDesignationFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "ParenthesizedVariableDesignation" type.
        /// </summary>
    	public virtual ParenthesizedVariableDesignationFormatInfo ParenthesizedVariableDesignationFormatInfo
    	{
    		get => _parenthesizedVariableDesignationFormatInfo ?? (_parenthesizedVariableDesignationFormatInfo = new ParenthesizedVariableDesignationFormatInfo());
    		set => _parenthesizedVariableDesignationFormatInfo = value;
    	}
    	private ParenthesizedVariableDesignationFormatInfo _parenthesizedVariableDesignationFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "CasePatternSwitchLabel" type.
        /// </summary>
    	public virtual CasePatternSwitchLabelFormatInfo CasePatternSwitchLabelFormatInfo
    	{
    		get => _casePatternSwitchLabelFormatInfo ?? (_casePatternSwitchLabelFormatInfo = new CasePatternSwitchLabelFormatInfo());
    		set => _casePatternSwitchLabelFormatInfo = value;
    	}
    	private CasePatternSwitchLabelFormatInfo _casePatternSwitchLabelFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "CaseSwitchLabel" type.
        /// </summary>
    	public virtual CaseSwitchLabelFormatInfo CaseSwitchLabelFormatInfo
    	{
    		get => _caseSwitchLabelFormatInfo ?? (_caseSwitchLabelFormatInfo = new CaseSwitchLabelFormatInfo());
    		set => _caseSwitchLabelFormatInfo = value;
    	}
    	private CaseSwitchLabelFormatInfo _caseSwitchLabelFormatInfo;
    
    	/// <summary>
        /// Provides language-specific information about the "DefaultSwitchLabel" type.
        /// </summary>
    	public virtual DefaultSwitchLabelFormatInfo DefaultSwitchLabelFormatInfo
    	{
    		get => _defaultSwitchLabelFormatInfo ?? (_defaultSwitchLabelFormatInfo = new DefaultSwitchLabelFormatInfo());
    		set => _defaultSwitchLabelFormatInfo = value;
    	}
    	private DefaultSwitchLabelFormatInfo _defaultSwitchLabelFormatInfo;
    
    }
}
// Generated helper templates
// Generated items
