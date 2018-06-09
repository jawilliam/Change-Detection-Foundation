
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
        /// Provides language-specific information about the "AttributeArgument" type.
        /// </summary>
    	public virtual AttributeArgumentFormatInfo AttributeArgument
    	{
    		get => _attributeArgument ?? (_attributeArgument = new AttributeArgumentFormatInfo());
    		set => _attributeArgument = value;
    	}
    	AttributeArgumentFormatInfo _attributeArgument;
    
    	/// <summary>
        /// Provides language-specific information about the "NameEquals" type.
        /// </summary>
    	public virtual NameEqualsFormatInfo NameEquals
    	{
    		get => _nameEquals ?? (_nameEquals = new NameEqualsFormatInfo());
    		set => _nameEquals = value;
    	}
    	NameEqualsFormatInfo _nameEquals;
    
    	/// <summary>
        /// Provides language-specific information about the "TypeParameterList" type.
        /// </summary>
    	public virtual TypeParameterListFormatInfo TypeParameterList
    	{
    		get => _typeParameterList ?? (_typeParameterList = new TypeParameterListFormatInfo());
    		set => _typeParameterList = value;
    	}
    	TypeParameterListFormatInfo _typeParameterList;
    
    	/// <summary>
        /// Provides language-specific information about the "TypeParameter" type.
        /// </summary>
    	public virtual TypeParameterFormatInfo TypeParameter
    	{
    		get => _typeParameter ?? (_typeParameter = new TypeParameterFormatInfo());
    		set => _typeParameter = value;
    	}
    	TypeParameterFormatInfo _typeParameter;
    
    	/// <summary>
        /// Provides language-specific information about the "BaseList" type.
        /// </summary>
    	public virtual BaseListFormatInfo BaseList
    	{
    		get => _baseList ?? (_baseList = new BaseListFormatInfo());
    		set => _baseList = value;
    	}
    	BaseListFormatInfo _baseList;
    
    	/// <summary>
        /// Provides language-specific information about the "TypeParameterConstraintClause" type.
        /// </summary>
    	public virtual TypeParameterConstraintClauseFormatInfo TypeParameterConstraintClause
    	{
    		get => _typeParameterConstraintClause ?? (_typeParameterConstraintClause = new TypeParameterConstraintClauseFormatInfo());
    		set => _typeParameterConstraintClause = value;
    	}
    	TypeParameterConstraintClauseFormatInfo _typeParameterConstraintClause;
    
    	/// <summary>
        /// Provides language-specific information about the "ExplicitInterfaceSpecifier" type.
        /// </summary>
    	public virtual ExplicitInterfaceSpecifierFormatInfo ExplicitInterfaceSpecifier
    	{
    		get => _explicitInterfaceSpecifier ?? (_explicitInterfaceSpecifier = new ExplicitInterfaceSpecifierFormatInfo());
    		set => _explicitInterfaceSpecifier = value;
    	}
    	ExplicitInterfaceSpecifierFormatInfo _explicitInterfaceSpecifier;
    
    	/// <summary>
        /// Provides language-specific information about the "ConstructorInitializer" type.
        /// </summary>
    	public virtual ConstructorInitializerFormatInfo ConstructorInitializer
    	{
    		get => _constructorInitializer ?? (_constructorInitializer = new ConstructorInitializerFormatInfo());
    		set => _constructorInitializer = value;
    	}
    	ConstructorInitializerFormatInfo _constructorInitializer;
    
    	/// <summary>
        /// Provides language-specific information about the "ArrowExpressionClause" type.
        /// </summary>
    	public virtual ArrowExpressionClauseFormatInfo ArrowExpressionClause
    	{
    		get => _arrowExpressionClause ?? (_arrowExpressionClause = new ArrowExpressionClauseFormatInfo());
    		set => _arrowExpressionClause = value;
    	}
    	ArrowExpressionClauseFormatInfo _arrowExpressionClause;
    
    	/// <summary>
        /// Provides language-specific information about the "AccessorList" type.
        /// </summary>
    	public virtual AccessorListFormatInfo AccessorList
    	{
    		get => _accessorList ?? (_accessorList = new AccessorListFormatInfo());
    		set => _accessorList = value;
    	}
    	AccessorListFormatInfo _accessorList;
    
    	/// <summary>
        /// Provides language-specific information about the "AccessorDeclaration" type.
        /// </summary>
    	public virtual AccessorDeclarationFormatInfo AccessorDeclaration
    	{
    		get => _accessorDeclaration ?? (_accessorDeclaration = new AccessorDeclarationFormatInfo());
    		set => _accessorDeclaration = value;
    	}
    	AccessorDeclarationFormatInfo _accessorDeclaration;
    
    	/// <summary>
        /// Provides language-specific information about the "Parameter" type.
        /// </summary>
    	public virtual ParameterFormatInfo Parameter
    	{
    		get => _parameter ?? (_parameter = new ParameterFormatInfo());
    		set => _parameter = value;
    	}
    	ParameterFormatInfo _parameter;
    
    	/// <summary>
        /// Provides language-specific information about the "CrefParameter" type.
        /// </summary>
    	public virtual CrefParameterFormatInfo CrefParameter
    	{
    		get => _crefParameter ?? (_crefParameter = new CrefParameterFormatInfo());
    		set => _crefParameter = value;
    	}
    	CrefParameterFormatInfo _crefParameter;
    
    	/// <summary>
        /// Provides language-specific information about the "XmlElementStartTag" type.
        /// </summary>
    	public virtual XmlElementStartTagFormatInfo XmlElementStartTag
    	{
    		get => _xmlElementStartTag ?? (_xmlElementStartTag = new XmlElementStartTagFormatInfo());
    		set => _xmlElementStartTag = value;
    	}
    	XmlElementStartTagFormatInfo _xmlElementStartTag;
    
    	/// <summary>
        /// Provides language-specific information about the "XmlElementEndTag" type.
        /// </summary>
    	public virtual XmlElementEndTagFormatInfo XmlElementEndTag
    	{
    		get => _xmlElementEndTag ?? (_xmlElementEndTag = new XmlElementEndTagFormatInfo());
    		set => _xmlElementEndTag = value;
    	}
    	XmlElementEndTagFormatInfo _xmlElementEndTag;
    
    	/// <summary>
        /// Provides language-specific information about the "XmlName" type.
        /// </summary>
    	public virtual XmlNameFormatInfo XmlName
    	{
    		get => _xmlName ?? (_xmlName = new XmlNameFormatInfo());
    		set => _xmlName = value;
    	}
    	XmlNameFormatInfo _xmlName;
    
    	/// <summary>
        /// Provides language-specific information about the "XmlPrefix" type.
        /// </summary>
    	public virtual XmlPrefixFormatInfo XmlPrefix
    	{
    		get => _xmlPrefix ?? (_xmlPrefix = new XmlPrefixFormatInfo());
    		set => _xmlPrefix = value;
    	}
    	XmlPrefixFormatInfo _xmlPrefix;
    
    	/// <summary>
        /// Provides language-specific information about the "TypeArgumentList" type.
        /// </summary>
    	public virtual TypeArgumentListFormatInfo TypeArgumentList
    	{
    		get => _typeArgumentList ?? (_typeArgumentList = new TypeArgumentListFormatInfo());
    		set => _typeArgumentList = value;
    	}
    	TypeArgumentListFormatInfo _typeArgumentList;
    
    	/// <summary>
        /// Provides language-specific information about the "ArrayRankSpecifier" type.
        /// </summary>
    	public virtual ArrayRankSpecifierFormatInfo ArrayRankSpecifier
    	{
    		get => _arrayRankSpecifier ?? (_arrayRankSpecifier = new ArrayRankSpecifierFormatInfo());
    		set => _arrayRankSpecifier = value;
    	}
    	ArrayRankSpecifierFormatInfo _arrayRankSpecifier;
    
    	/// <summary>
        /// Provides language-specific information about the "TupleElement" type.
        /// </summary>
    	public virtual TupleElementFormatInfo TupleElement
    	{
    		get => _tupleElement ?? (_tupleElement = new TupleElementFormatInfo());
    		set => _tupleElement = value;
    	}
    	TupleElementFormatInfo _tupleElement;
    
    	/// <summary>
        /// Provides language-specific information about the "Argument" type.
        /// </summary>
    	public virtual ArgumentFormatInfo Argument
    	{
    		get => _argument ?? (_argument = new ArgumentFormatInfo());
    		set => _argument = value;
    	}
    	ArgumentFormatInfo _argument;
    
    	/// <summary>
        /// Provides language-specific information about the "NameColon" type.
        /// </summary>
    	public virtual NameColonFormatInfo NameColon
    	{
    		get => _nameColon ?? (_nameColon = new NameColonFormatInfo());
    		set => _nameColon = value;
    	}
    	NameColonFormatInfo _nameColon;
    
    	/// <summary>
        /// Provides language-specific information about the "AnonymousObjectMemberDeclarator" type.
        /// </summary>
    	public virtual AnonymousObjectMemberDeclaratorFormatInfo AnonymousObjectMemberDeclarator
    	{
    		get => _anonymousObjectMemberDeclarator ?? (_anonymousObjectMemberDeclarator = new AnonymousObjectMemberDeclaratorFormatInfo());
    		set => _anonymousObjectMemberDeclarator = value;
    	}
    	AnonymousObjectMemberDeclaratorFormatInfo _anonymousObjectMemberDeclarator;
    
    	/// <summary>
        /// Provides language-specific information about the "QueryBody" type.
        /// </summary>
    	public virtual QueryBodyFormatInfo QueryBody
    	{
    		get => _queryBody ?? (_queryBody = new QueryBodyFormatInfo());
    		set => _queryBody = value;
    	}
    	QueryBodyFormatInfo _queryBody;
    
    	/// <summary>
        /// Provides language-specific information about the "JoinIntoClause" type.
        /// </summary>
    	public virtual JoinIntoClauseFormatInfo JoinIntoClause
    	{
    		get => _joinIntoClause ?? (_joinIntoClause = new JoinIntoClauseFormatInfo());
    		set => _joinIntoClause = value;
    	}
    	JoinIntoClauseFormatInfo _joinIntoClause;
    
    	/// <summary>
        /// Provides language-specific information about the "Ordering" type.
        /// </summary>
    	public virtual OrderingFormatInfo Ordering
    	{
    		get => _ordering ?? (_ordering = new OrderingFormatInfo());
    		set => _ordering = value;
    	}
    	OrderingFormatInfo _ordering;
    
    	/// <summary>
        /// Provides language-specific information about the "QueryContinuation" type.
        /// </summary>
    	public virtual QueryContinuationFormatInfo QueryContinuation
    	{
    		get => _queryContinuation ?? (_queryContinuation = new QueryContinuationFormatInfo());
    		set => _queryContinuation = value;
    	}
    	QueryContinuationFormatInfo _queryContinuation;
    
    	/// <summary>
        /// Provides language-specific information about the "WhenClause" type.
        /// </summary>
    	public virtual WhenClauseFormatInfo WhenClause
    	{
    		get => _whenClause ?? (_whenClause = new WhenClauseFormatInfo());
    		set => _whenClause = value;
    	}
    	WhenClauseFormatInfo _whenClause;
    
    	/// <summary>
        /// Provides language-specific information about the "InterpolationAlignmentClause" type.
        /// </summary>
    	public virtual InterpolationAlignmentClauseFormatInfo InterpolationAlignmentClause
    	{
    		get => _interpolationAlignmentClause ?? (_interpolationAlignmentClause = new InterpolationAlignmentClauseFormatInfo());
    		set => _interpolationAlignmentClause = value;
    	}
    	InterpolationAlignmentClauseFormatInfo _interpolationAlignmentClause;
    
    	/// <summary>
        /// Provides language-specific information about the "InterpolationFormatClause" type.
        /// </summary>
    	public virtual InterpolationFormatClauseFormatInfo InterpolationFormatClause
    	{
    		get => _interpolationFormatClause ?? (_interpolationFormatClause = new InterpolationFormatClauseFormatInfo());
    		set => _interpolationFormatClause = value;
    	}
    	InterpolationFormatClauseFormatInfo _interpolationFormatClause;
    
    	/// <summary>
        /// Provides language-specific information about the "VariableDeclaration" type.
        /// </summary>
    	public virtual VariableDeclarationFormatInfo VariableDeclaration
    	{
    		get => _variableDeclaration ?? (_variableDeclaration = new VariableDeclarationFormatInfo());
    		set => _variableDeclaration = value;
    	}
    	VariableDeclarationFormatInfo _variableDeclaration;
    
    	/// <summary>
        /// Provides language-specific information about the "VariableDeclarator" type.
        /// </summary>
    	public virtual VariableDeclaratorFormatInfo VariableDeclarator
    	{
    		get => _variableDeclarator ?? (_variableDeclarator = new VariableDeclaratorFormatInfo());
    		set => _variableDeclarator = value;
    	}
    	VariableDeclaratorFormatInfo _variableDeclarator;
    
    	/// <summary>
        /// Provides language-specific information about the "EqualsValueClause" type.
        /// </summary>
    	public virtual EqualsValueClauseFormatInfo EqualsValueClause
    	{
    		get => _equalsValueClause ?? (_equalsValueClause = new EqualsValueClauseFormatInfo());
    		set => _equalsValueClause = value;
    	}
    	EqualsValueClauseFormatInfo _equalsValueClause;
    
    	/// <summary>
        /// Provides language-specific information about the "ElseClause" type.
        /// </summary>
    	public virtual ElseClauseFormatInfo ElseClause
    	{
    		get => _elseClause ?? (_elseClause = new ElseClauseFormatInfo());
    		set => _elseClause = value;
    	}
    	ElseClauseFormatInfo _elseClause;
    
    	/// <summary>
        /// Provides language-specific information about the "SwitchSection" type.
        /// </summary>
    	public virtual SwitchSectionFormatInfo SwitchSection
    	{
    		get => _switchSection ?? (_switchSection = new SwitchSectionFormatInfo());
    		set => _switchSection = value;
    	}
    	SwitchSectionFormatInfo _switchSection;
    
    	/// <summary>
        /// Provides language-specific information about the "CatchClause" type.
        /// </summary>
    	public virtual CatchClauseFormatInfo CatchClause
    	{
    		get => _catchClause ?? (_catchClause = new CatchClauseFormatInfo());
    		set => _catchClause = value;
    	}
    	CatchClauseFormatInfo _catchClause;
    
    	/// <summary>
        /// Provides language-specific information about the "CatchDeclaration" type.
        /// </summary>
    	public virtual CatchDeclarationFormatInfo CatchDeclaration
    	{
    		get => _catchDeclaration ?? (_catchDeclaration = new CatchDeclarationFormatInfo());
    		set => _catchDeclaration = value;
    	}
    	CatchDeclarationFormatInfo _catchDeclaration;
    
    	/// <summary>
        /// Provides language-specific information about the "CatchFilterClause" type.
        /// </summary>
    	public virtual CatchFilterClauseFormatInfo CatchFilterClause
    	{
    		get => _catchFilterClause ?? (_catchFilterClause = new CatchFilterClauseFormatInfo());
    		set => _catchFilterClause = value;
    	}
    	CatchFilterClauseFormatInfo _catchFilterClause;
    
    	/// <summary>
        /// Provides language-specific information about the "FinallyClause" type.
        /// </summary>
    	public virtual FinallyClauseFormatInfo FinallyClause
    	{
    		get => _finallyClause ?? (_finallyClause = new FinallyClauseFormatInfo());
    		set => _finallyClause = value;
    	}
    	FinallyClauseFormatInfo _finallyClause;
    
    	/// <summary>
        /// Provides language-specific information about the "CompilationUnit" type.
        /// </summary>
    	public virtual CompilationUnitFormatInfo CompilationUnit
    	{
    		get => _compilationUnit ?? (_compilationUnit = new CompilationUnitFormatInfo());
    		set => _compilationUnit = value;
    	}
    	CompilationUnitFormatInfo _compilationUnit;
    
    	/// <summary>
        /// Provides language-specific information about the "ExternAliasDirective" type.
        /// </summary>
    	public virtual ExternAliasDirectiveFormatInfo ExternAliasDirective
    	{
    		get => _externAliasDirective ?? (_externAliasDirective = new ExternAliasDirectiveFormatInfo());
    		set => _externAliasDirective = value;
    	}
    	ExternAliasDirectiveFormatInfo _externAliasDirective;
    
    	/// <summary>
        /// Provides language-specific information about the "UsingDirective" type.
        /// </summary>
    	public virtual UsingDirectiveFormatInfo UsingDirective
    	{
    		get => _usingDirective ?? (_usingDirective = new UsingDirectiveFormatInfo());
    		set => _usingDirective = value;
    	}
    	UsingDirectiveFormatInfo _usingDirective;
    
    	/// <summary>
        /// Provides language-specific information about the "AttributeList" type.
        /// </summary>
    	public virtual AttributeListFormatInfo AttributeList
    	{
    		get => _attributeList ?? (_attributeList = new AttributeListFormatInfo());
    		set => _attributeList = value;
    	}
    	AttributeListFormatInfo _attributeList;
    
    	/// <summary>
        /// Provides language-specific information about the "AttributeTargetSpecifier" type.
        /// </summary>
    	public virtual AttributeTargetSpecifierFormatInfo AttributeTargetSpecifier
    	{
    		get => _attributeTargetSpecifier ?? (_attributeTargetSpecifier = new AttributeTargetSpecifierFormatInfo());
    		set => _attributeTargetSpecifier = value;
    	}
    	AttributeTargetSpecifierFormatInfo _attributeTargetSpecifier;
    
    	/// <summary>
        /// Provides language-specific information about the "Attribute" type.
        /// </summary>
    	public virtual AttributeFormatInfo Attribute
    	{
    		get => _attribute ?? (_attribute = new AttributeFormatInfo());
    		set => _attribute = value;
    	}
    	AttributeFormatInfo _attribute;
    
    	/// <summary>
        /// Provides language-specific information about the "AttributeArgumentList" type.
        /// </summary>
    	public virtual AttributeArgumentListFormatInfo AttributeArgumentList
    	{
    		get => _attributeArgumentList ?? (_attributeArgumentList = new AttributeArgumentListFormatInfo());
    		set => _attributeArgumentList = value;
    	}
    	AttributeArgumentListFormatInfo _attributeArgumentList;
    
    	/// <summary>
        /// Provides language-specific information about the "DelegateDeclaration" type.
        /// </summary>
    	public virtual DelegateDeclarationFormatInfo DelegateDeclaration
    	{
    		get => _delegateDeclaration ?? (_delegateDeclaration = new DelegateDeclarationFormatInfo());
    		set => _delegateDeclaration = value;
    	}
    	DelegateDeclarationFormatInfo _delegateDeclaration;
    
    	/// <summary>
        /// Provides language-specific information about the "EnumMemberDeclaration" type.
        /// </summary>
    	public virtual EnumMemberDeclarationFormatInfo EnumMemberDeclaration
    	{
    		get => _enumMemberDeclaration ?? (_enumMemberDeclaration = new EnumMemberDeclarationFormatInfo());
    		set => _enumMemberDeclaration = value;
    	}
    	EnumMemberDeclarationFormatInfo _enumMemberDeclaration;
    
    	/// <summary>
        /// Provides language-specific information about the "IncompleteMember" type.
        /// </summary>
    	public virtual IncompleteMemberFormatInfo IncompleteMember
    	{
    		get => _incompleteMember ?? (_incompleteMember = new IncompleteMemberFormatInfo());
    		set => _incompleteMember = value;
    	}
    	IncompleteMemberFormatInfo _incompleteMember;
    
    	/// <summary>
        /// Provides language-specific information about the "GlobalStatement" type.
        /// </summary>
    	public virtual GlobalStatementFormatInfo GlobalStatement
    	{
    		get => _globalStatement ?? (_globalStatement = new GlobalStatementFormatInfo());
    		set => _globalStatement = value;
    	}
    	GlobalStatementFormatInfo _globalStatement;
    
    	/// <summary>
        /// Provides language-specific information about the "NamespaceDeclaration" type.
        /// </summary>
    	public virtual NamespaceDeclarationFormatInfo NamespaceDeclaration
    	{
    		get => _namespaceDeclaration ?? (_namespaceDeclaration = new NamespaceDeclarationFormatInfo());
    		set => _namespaceDeclaration = value;
    	}
    	NamespaceDeclarationFormatInfo _namespaceDeclaration;
    
    	/// <summary>
        /// Provides language-specific information about the "EnumDeclaration" type.
        /// </summary>
    	public virtual EnumDeclarationFormatInfo EnumDeclaration
    	{
    		get => _enumDeclaration ?? (_enumDeclaration = new EnumDeclarationFormatInfo());
    		set => _enumDeclaration = value;
    	}
    	EnumDeclarationFormatInfo _enumDeclaration;
    
    	/// <summary>
        /// Provides language-specific information about the "ClassDeclaration" type.
        /// </summary>
    	public virtual ClassDeclarationFormatInfo ClassDeclaration
    	{
    		get => _classDeclaration ?? (_classDeclaration = new ClassDeclarationFormatInfo());
    		set => _classDeclaration = value;
    	}
    	ClassDeclarationFormatInfo _classDeclaration;
    
    	/// <summary>
        /// Provides language-specific information about the "StructDeclaration" type.
        /// </summary>
    	public virtual StructDeclarationFormatInfo StructDeclaration
    	{
    		get => _structDeclaration ?? (_structDeclaration = new StructDeclarationFormatInfo());
    		set => _structDeclaration = value;
    	}
    	StructDeclarationFormatInfo _structDeclaration;
    
    	/// <summary>
        /// Provides language-specific information about the "InterfaceDeclaration" type.
        /// </summary>
    	public virtual InterfaceDeclarationFormatInfo InterfaceDeclaration
    	{
    		get => _interfaceDeclaration ?? (_interfaceDeclaration = new InterfaceDeclarationFormatInfo());
    		set => _interfaceDeclaration = value;
    	}
    	InterfaceDeclarationFormatInfo _interfaceDeclaration;
    
    	/// <summary>
        /// Provides language-specific information about the "FieldDeclaration" type.
        /// </summary>
    	public virtual FieldDeclarationFormatInfo FieldDeclaration
    	{
    		get => _fieldDeclaration ?? (_fieldDeclaration = new FieldDeclarationFormatInfo());
    		set => _fieldDeclaration = value;
    	}
    	FieldDeclarationFormatInfo _fieldDeclaration;
    
    	/// <summary>
        /// Provides language-specific information about the "EventFieldDeclaration" type.
        /// </summary>
    	public virtual EventFieldDeclarationFormatInfo EventFieldDeclaration
    	{
    		get => _eventFieldDeclaration ?? (_eventFieldDeclaration = new EventFieldDeclarationFormatInfo());
    		set => _eventFieldDeclaration = value;
    	}
    	EventFieldDeclarationFormatInfo _eventFieldDeclaration;
    
    	/// <summary>
        /// Provides language-specific information about the "MethodDeclaration" type.
        /// </summary>
    	public virtual MethodDeclarationFormatInfo MethodDeclaration
    	{
    		get => _methodDeclaration ?? (_methodDeclaration = new MethodDeclarationFormatInfo());
    		set => _methodDeclaration = value;
    	}
    	MethodDeclarationFormatInfo _methodDeclaration;
    
    	/// <summary>
        /// Provides language-specific information about the "OperatorDeclaration" type.
        /// </summary>
    	public virtual OperatorDeclarationFormatInfo OperatorDeclaration
    	{
    		get => _operatorDeclaration ?? (_operatorDeclaration = new OperatorDeclarationFormatInfo());
    		set => _operatorDeclaration = value;
    	}
    	OperatorDeclarationFormatInfo _operatorDeclaration;
    
    	/// <summary>
        /// Provides language-specific information about the "ConversionOperatorDeclaration" type.
        /// </summary>
    	public virtual ConversionOperatorDeclarationFormatInfo ConversionOperatorDeclaration
    	{
    		get => _conversionOperatorDeclaration ?? (_conversionOperatorDeclaration = new ConversionOperatorDeclarationFormatInfo());
    		set => _conversionOperatorDeclaration = value;
    	}
    	ConversionOperatorDeclarationFormatInfo _conversionOperatorDeclaration;
    
    	/// <summary>
        /// Provides language-specific information about the "ConstructorDeclaration" type.
        /// </summary>
    	public virtual ConstructorDeclarationFormatInfo ConstructorDeclaration
    	{
    		get => _constructorDeclaration ?? (_constructorDeclaration = new ConstructorDeclarationFormatInfo());
    		set => _constructorDeclaration = value;
    	}
    	ConstructorDeclarationFormatInfo _constructorDeclaration;
    
    	/// <summary>
        /// Provides language-specific information about the "DestructorDeclaration" type.
        /// </summary>
    	public virtual DestructorDeclarationFormatInfo DestructorDeclaration
    	{
    		get => _destructorDeclaration ?? (_destructorDeclaration = new DestructorDeclarationFormatInfo());
    		set => _destructorDeclaration = value;
    	}
    	DestructorDeclarationFormatInfo _destructorDeclaration;
    
    	/// <summary>
        /// Provides language-specific information about the "PropertyDeclaration" type.
        /// </summary>
    	public virtual PropertyDeclarationFormatInfo PropertyDeclaration
    	{
    		get => _propertyDeclaration ?? (_propertyDeclaration = new PropertyDeclarationFormatInfo());
    		set => _propertyDeclaration = value;
    	}
    	PropertyDeclarationFormatInfo _propertyDeclaration;
    
    	/// <summary>
        /// Provides language-specific information about the "EventDeclaration" type.
        /// </summary>
    	public virtual EventDeclarationFormatInfo EventDeclaration
    	{
    		get => _eventDeclaration ?? (_eventDeclaration = new EventDeclarationFormatInfo());
    		set => _eventDeclaration = value;
    	}
    	EventDeclarationFormatInfo _eventDeclaration;
    
    	/// <summary>
        /// Provides language-specific information about the "IndexerDeclaration" type.
        /// </summary>
    	public virtual IndexerDeclarationFormatInfo IndexerDeclaration
    	{
    		get => _indexerDeclaration ?? (_indexerDeclaration = new IndexerDeclarationFormatInfo());
    		set => _indexerDeclaration = value;
    	}
    	IndexerDeclarationFormatInfo _indexerDeclaration;
    
    	/// <summary>
        /// Provides language-specific information about the "SimpleBaseType" type.
        /// </summary>
    	public virtual SimpleBaseTypeFormatInfo SimpleBaseType
    	{
    		get => _simpleBaseType ?? (_simpleBaseType = new SimpleBaseTypeFormatInfo());
    		set => _simpleBaseType = value;
    	}
    	SimpleBaseTypeFormatInfo _simpleBaseType;
    
    	/// <summary>
        /// Provides language-specific information about the "ConstructorConstraint" type.
        /// </summary>
    	public virtual ConstructorConstraintFormatInfo ConstructorConstraint
    	{
    		get => _constructorConstraint ?? (_constructorConstraint = new ConstructorConstraintFormatInfo());
    		set => _constructorConstraint = value;
    	}
    	ConstructorConstraintFormatInfo _constructorConstraint;
    
    	/// <summary>
        /// Provides language-specific information about the "ClassOrStructConstraint" type.
        /// </summary>
    	public virtual ClassOrStructConstraintFormatInfo ClassOrStructConstraint
    	{
    		get => _classOrStructConstraint ?? (_classOrStructConstraint = new ClassOrStructConstraintFormatInfo());
    		set => _classOrStructConstraint = value;
    	}
    	ClassOrStructConstraintFormatInfo _classOrStructConstraint;
    
    	/// <summary>
        /// Provides language-specific information about the "TypeConstraint" type.
        /// </summary>
    	public virtual TypeConstraintFormatInfo TypeConstraint
    	{
    		get => _typeConstraint ?? (_typeConstraint = new TypeConstraintFormatInfo());
    		set => _typeConstraint = value;
    	}
    	TypeConstraintFormatInfo _typeConstraint;
    
    	/// <summary>
        /// Provides language-specific information about the "ParameterList" type.
        /// </summary>
    	public virtual ParameterListFormatInfo ParameterList
    	{
    		get => _parameterList ?? (_parameterList = new ParameterListFormatInfo());
    		set => _parameterList = value;
    	}
    	ParameterListFormatInfo _parameterList;
    
    	/// <summary>
        /// Provides language-specific information about the "BracketedParameterList" type.
        /// </summary>
    	public virtual BracketedParameterListFormatInfo BracketedParameterList
    	{
    		get => _bracketedParameterList ?? (_bracketedParameterList = new BracketedParameterListFormatInfo());
    		set => _bracketedParameterList = value;
    	}
    	BracketedParameterListFormatInfo _bracketedParameterList;
    
    	/// <summary>
        /// Provides language-specific information about the "SkippedTokensTrivia" type.
        /// </summary>
    	public virtual SkippedTokensTriviaFormatInfo SkippedTokensTrivia
    	{
    		get => _skippedTokensTrivia ?? (_skippedTokensTrivia = new SkippedTokensTriviaFormatInfo());
    		set => _skippedTokensTrivia = value;
    	}
    	SkippedTokensTriviaFormatInfo _skippedTokensTrivia;
    
    	/// <summary>
        /// Provides language-specific information about the "DocumentationCommentTrivia" type.
        /// </summary>
    	public virtual DocumentationCommentTriviaFormatInfo DocumentationCommentTrivia
    	{
    		get => _documentationCommentTrivia ?? (_documentationCommentTrivia = new DocumentationCommentTriviaFormatInfo());
    		set => _documentationCommentTrivia = value;
    	}
    	DocumentationCommentTriviaFormatInfo _documentationCommentTrivia;
    
    	/// <summary>
        /// Provides language-specific information about the "EndIfDirectiveTrivia" type.
        /// </summary>
    	public virtual EndIfDirectiveTriviaFormatInfo EndIfDirectiveTrivia
    	{
    		get => _endIfDirectiveTrivia ?? (_endIfDirectiveTrivia = new EndIfDirectiveTriviaFormatInfo());
    		set => _endIfDirectiveTrivia = value;
    	}
    	EndIfDirectiveTriviaFormatInfo _endIfDirectiveTrivia;
    
    	/// <summary>
        /// Provides language-specific information about the "RegionDirectiveTrivia" type.
        /// </summary>
    	public virtual RegionDirectiveTriviaFormatInfo RegionDirectiveTrivia
    	{
    		get => _regionDirectiveTrivia ?? (_regionDirectiveTrivia = new RegionDirectiveTriviaFormatInfo());
    		set => _regionDirectiveTrivia = value;
    	}
    	RegionDirectiveTriviaFormatInfo _regionDirectiveTrivia;
    
    	/// <summary>
        /// Provides language-specific information about the "EndRegionDirectiveTrivia" type.
        /// </summary>
    	public virtual EndRegionDirectiveTriviaFormatInfo EndRegionDirectiveTrivia
    	{
    		get => _endRegionDirectiveTrivia ?? (_endRegionDirectiveTrivia = new EndRegionDirectiveTriviaFormatInfo());
    		set => _endRegionDirectiveTrivia = value;
    	}
    	EndRegionDirectiveTriviaFormatInfo _endRegionDirectiveTrivia;
    
    	/// <summary>
        /// Provides language-specific information about the "ErrorDirectiveTrivia" type.
        /// </summary>
    	public virtual ErrorDirectiveTriviaFormatInfo ErrorDirectiveTrivia
    	{
    		get => _errorDirectiveTrivia ?? (_errorDirectiveTrivia = new ErrorDirectiveTriviaFormatInfo());
    		set => _errorDirectiveTrivia = value;
    	}
    	ErrorDirectiveTriviaFormatInfo _errorDirectiveTrivia;
    
    	/// <summary>
        /// Provides language-specific information about the "WarningDirectiveTrivia" type.
        /// </summary>
    	public virtual WarningDirectiveTriviaFormatInfo WarningDirectiveTrivia
    	{
    		get => _warningDirectiveTrivia ?? (_warningDirectiveTrivia = new WarningDirectiveTriviaFormatInfo());
    		set => _warningDirectiveTrivia = value;
    	}
    	WarningDirectiveTriviaFormatInfo _warningDirectiveTrivia;
    
    	/// <summary>
        /// Provides language-specific information about the "BadDirectiveTrivia" type.
        /// </summary>
    	public virtual BadDirectiveTriviaFormatInfo BadDirectiveTrivia
    	{
    		get => _badDirectiveTrivia ?? (_badDirectiveTrivia = new BadDirectiveTriviaFormatInfo());
    		set => _badDirectiveTrivia = value;
    	}
    	BadDirectiveTriviaFormatInfo _badDirectiveTrivia;
    
    	/// <summary>
        /// Provides language-specific information about the "DefineDirectiveTrivia" type.
        /// </summary>
    	public virtual DefineDirectiveTriviaFormatInfo DefineDirectiveTrivia
    	{
    		get => _defineDirectiveTrivia ?? (_defineDirectiveTrivia = new DefineDirectiveTriviaFormatInfo());
    		set => _defineDirectiveTrivia = value;
    	}
    	DefineDirectiveTriviaFormatInfo _defineDirectiveTrivia;
    
    	/// <summary>
        /// Provides language-specific information about the "UndefDirectiveTrivia" type.
        /// </summary>
    	public virtual UndefDirectiveTriviaFormatInfo UndefDirectiveTrivia
    	{
    		get => _undefDirectiveTrivia ?? (_undefDirectiveTrivia = new UndefDirectiveTriviaFormatInfo());
    		set => _undefDirectiveTrivia = value;
    	}
    	UndefDirectiveTriviaFormatInfo _undefDirectiveTrivia;
    
    	/// <summary>
        /// Provides language-specific information about the "LineDirectiveTrivia" type.
        /// </summary>
    	public virtual LineDirectiveTriviaFormatInfo LineDirectiveTrivia
    	{
    		get => _lineDirectiveTrivia ?? (_lineDirectiveTrivia = new LineDirectiveTriviaFormatInfo());
    		set => _lineDirectiveTrivia = value;
    	}
    	LineDirectiveTriviaFormatInfo _lineDirectiveTrivia;
    
    	/// <summary>
        /// Provides language-specific information about the "PragmaWarningDirectiveTrivia" type.
        /// </summary>
    	public virtual PragmaWarningDirectiveTriviaFormatInfo PragmaWarningDirectiveTrivia
    	{
    		get => _pragmaWarningDirectiveTrivia ?? (_pragmaWarningDirectiveTrivia = new PragmaWarningDirectiveTriviaFormatInfo());
    		set => _pragmaWarningDirectiveTrivia = value;
    	}
    	PragmaWarningDirectiveTriviaFormatInfo _pragmaWarningDirectiveTrivia;
    
    	/// <summary>
        /// Provides language-specific information about the "PragmaChecksumDirectiveTrivia" type.
        /// </summary>
    	public virtual PragmaChecksumDirectiveTriviaFormatInfo PragmaChecksumDirectiveTrivia
    	{
    		get => _pragmaChecksumDirectiveTrivia ?? (_pragmaChecksumDirectiveTrivia = new PragmaChecksumDirectiveTriviaFormatInfo());
    		set => _pragmaChecksumDirectiveTrivia = value;
    	}
    	PragmaChecksumDirectiveTriviaFormatInfo _pragmaChecksumDirectiveTrivia;
    
    	/// <summary>
        /// Provides language-specific information about the "ReferenceDirectiveTrivia" type.
        /// </summary>
    	public virtual ReferenceDirectiveTriviaFormatInfo ReferenceDirectiveTrivia
    	{
    		get => _referenceDirectiveTrivia ?? (_referenceDirectiveTrivia = new ReferenceDirectiveTriviaFormatInfo());
    		set => _referenceDirectiveTrivia = value;
    	}
    	ReferenceDirectiveTriviaFormatInfo _referenceDirectiveTrivia;
    
    	/// <summary>
        /// Provides language-specific information about the "LoadDirectiveTrivia" type.
        /// </summary>
    	public virtual LoadDirectiveTriviaFormatInfo LoadDirectiveTrivia
    	{
    		get => _loadDirectiveTrivia ?? (_loadDirectiveTrivia = new LoadDirectiveTriviaFormatInfo());
    		set => _loadDirectiveTrivia = value;
    	}
    	LoadDirectiveTriviaFormatInfo _loadDirectiveTrivia;
    
    	/// <summary>
        /// Provides language-specific information about the "ShebangDirectiveTrivia" type.
        /// </summary>
    	public virtual ShebangDirectiveTriviaFormatInfo ShebangDirectiveTrivia
    	{
    		get => _shebangDirectiveTrivia ?? (_shebangDirectiveTrivia = new ShebangDirectiveTriviaFormatInfo());
    		set => _shebangDirectiveTrivia = value;
    	}
    	ShebangDirectiveTriviaFormatInfo _shebangDirectiveTrivia;
    
    	/// <summary>
        /// Provides language-specific information about the "ElseDirectiveTrivia" type.
        /// </summary>
    	public virtual ElseDirectiveTriviaFormatInfo ElseDirectiveTrivia
    	{
    		get => _elseDirectiveTrivia ?? (_elseDirectiveTrivia = new ElseDirectiveTriviaFormatInfo());
    		set => _elseDirectiveTrivia = value;
    	}
    	ElseDirectiveTriviaFormatInfo _elseDirectiveTrivia;
    
    	/// <summary>
        /// Provides language-specific information about the "IfDirectiveTrivia" type.
        /// </summary>
    	public virtual IfDirectiveTriviaFormatInfo IfDirectiveTrivia
    	{
    		get => _ifDirectiveTrivia ?? (_ifDirectiveTrivia = new IfDirectiveTriviaFormatInfo());
    		set => _ifDirectiveTrivia = value;
    	}
    	IfDirectiveTriviaFormatInfo _ifDirectiveTrivia;
    
    	/// <summary>
        /// Provides language-specific information about the "ElifDirectiveTrivia" type.
        /// </summary>
    	public virtual ElifDirectiveTriviaFormatInfo ElifDirectiveTrivia
    	{
    		get => _elifDirectiveTrivia ?? (_elifDirectiveTrivia = new ElifDirectiveTriviaFormatInfo());
    		set => _elifDirectiveTrivia = value;
    	}
    	ElifDirectiveTriviaFormatInfo _elifDirectiveTrivia;
    
    	/// <summary>
        /// Provides language-specific information about the "TypeCref" type.
        /// </summary>
    	public virtual TypeCrefFormatInfo TypeCref
    	{
    		get => _typeCref ?? (_typeCref = new TypeCrefFormatInfo());
    		set => _typeCref = value;
    	}
    	TypeCrefFormatInfo _typeCref;
    
    	/// <summary>
        /// Provides language-specific information about the "QualifiedCref" type.
        /// </summary>
    	public virtual QualifiedCrefFormatInfo QualifiedCref
    	{
    		get => _qualifiedCref ?? (_qualifiedCref = new QualifiedCrefFormatInfo());
    		set => _qualifiedCref = value;
    	}
    	QualifiedCrefFormatInfo _qualifiedCref;
    
    	/// <summary>
        /// Provides language-specific information about the "NameMemberCref" type.
        /// </summary>
    	public virtual NameMemberCrefFormatInfo NameMemberCref
    	{
    		get => _nameMemberCref ?? (_nameMemberCref = new NameMemberCrefFormatInfo());
    		set => _nameMemberCref = value;
    	}
    	NameMemberCrefFormatInfo _nameMemberCref;
    
    	/// <summary>
        /// Provides language-specific information about the "IndexerMemberCref" type.
        /// </summary>
    	public virtual IndexerMemberCrefFormatInfo IndexerMemberCref
    	{
    		get => _indexerMemberCref ?? (_indexerMemberCref = new IndexerMemberCrefFormatInfo());
    		set => _indexerMemberCref = value;
    	}
    	IndexerMemberCrefFormatInfo _indexerMemberCref;
    
    	/// <summary>
        /// Provides language-specific information about the "OperatorMemberCref" type.
        /// </summary>
    	public virtual OperatorMemberCrefFormatInfo OperatorMemberCref
    	{
    		get => _operatorMemberCref ?? (_operatorMemberCref = new OperatorMemberCrefFormatInfo());
    		set => _operatorMemberCref = value;
    	}
    	OperatorMemberCrefFormatInfo _operatorMemberCref;
    
    	/// <summary>
        /// Provides language-specific information about the "ConversionOperatorMemberCref" type.
        /// </summary>
    	public virtual ConversionOperatorMemberCrefFormatInfo ConversionOperatorMemberCref
    	{
    		get => _conversionOperatorMemberCref ?? (_conversionOperatorMemberCref = new ConversionOperatorMemberCrefFormatInfo());
    		set => _conversionOperatorMemberCref = value;
    	}
    	ConversionOperatorMemberCrefFormatInfo _conversionOperatorMemberCref;
    
    	/// <summary>
        /// Provides language-specific information about the "CrefParameterList" type.
        /// </summary>
    	public virtual CrefParameterListFormatInfo CrefParameterList
    	{
    		get => _crefParameterList ?? (_crefParameterList = new CrefParameterListFormatInfo());
    		set => _crefParameterList = value;
    	}
    	CrefParameterListFormatInfo _crefParameterList;
    
    	/// <summary>
        /// Provides language-specific information about the "CrefBracketedParameterList" type.
        /// </summary>
    	public virtual CrefBracketedParameterListFormatInfo CrefBracketedParameterList
    	{
    		get => _crefBracketedParameterList ?? (_crefBracketedParameterList = new CrefBracketedParameterListFormatInfo());
    		set => _crefBracketedParameterList = value;
    	}
    	CrefBracketedParameterListFormatInfo _crefBracketedParameterList;
    
    	/// <summary>
        /// Provides language-specific information about the "XmlElement" type.
        /// </summary>
    	public virtual XmlElementFormatInfo XmlElement
    	{
    		get => _xmlElement ?? (_xmlElement = new XmlElementFormatInfo());
    		set => _xmlElement = value;
    	}
    	XmlElementFormatInfo _xmlElement;
    
    	/// <summary>
        /// Provides language-specific information about the "XmlEmptyElement" type.
        /// </summary>
    	public virtual XmlEmptyElementFormatInfo XmlEmptyElement
    	{
    		get => _xmlEmptyElement ?? (_xmlEmptyElement = new XmlEmptyElementFormatInfo());
    		set => _xmlEmptyElement = value;
    	}
    	XmlEmptyElementFormatInfo _xmlEmptyElement;
    
    	/// <summary>
        /// Provides language-specific information about the "XmlText" type.
        /// </summary>
    	public virtual XmlTextFormatInfo XmlText
    	{
    		get => _xmlText ?? (_xmlText = new XmlTextFormatInfo());
    		set => _xmlText = value;
    	}
    	XmlTextFormatInfo _xmlText;
    
    	/// <summary>
        /// Provides language-specific information about the "XmlCDataSection" type.
        /// </summary>
    	public virtual XmlCDataSectionFormatInfo XmlCDataSection
    	{
    		get => _xmlCDataSection ?? (_xmlCDataSection = new XmlCDataSectionFormatInfo());
    		set => _xmlCDataSection = value;
    	}
    	XmlCDataSectionFormatInfo _xmlCDataSection;
    
    	/// <summary>
        /// Provides language-specific information about the "XmlProcessingInstruction" type.
        /// </summary>
    	public virtual XmlProcessingInstructionFormatInfo XmlProcessingInstruction
    	{
    		get => _xmlProcessingInstruction ?? (_xmlProcessingInstruction = new XmlProcessingInstructionFormatInfo());
    		set => _xmlProcessingInstruction = value;
    	}
    	XmlProcessingInstructionFormatInfo _xmlProcessingInstruction;
    
    	/// <summary>
        /// Provides language-specific information about the "XmlComment" type.
        /// </summary>
    	public virtual XmlCommentFormatInfo XmlComment
    	{
    		get => _xmlComment ?? (_xmlComment = new XmlCommentFormatInfo());
    		set => _xmlComment = value;
    	}
    	XmlCommentFormatInfo _xmlComment;
    
    	/// <summary>
        /// Provides language-specific information about the "XmlTextAttribute" type.
        /// </summary>
    	public virtual XmlTextAttributeFormatInfo XmlTextAttribute
    	{
    		get => _xmlTextAttribute ?? (_xmlTextAttribute = new XmlTextAttributeFormatInfo());
    		set => _xmlTextAttribute = value;
    	}
    	XmlTextAttributeFormatInfo _xmlTextAttribute;
    
    	/// <summary>
        /// Provides language-specific information about the "XmlCrefAttribute" type.
        /// </summary>
    	public virtual XmlCrefAttributeFormatInfo XmlCrefAttribute
    	{
    		get => _xmlCrefAttribute ?? (_xmlCrefAttribute = new XmlCrefAttributeFormatInfo());
    		set => _xmlCrefAttribute = value;
    	}
    	XmlCrefAttributeFormatInfo _xmlCrefAttribute;
    
    	/// <summary>
        /// Provides language-specific information about the "XmlNameAttribute" type.
        /// </summary>
    	public virtual XmlNameAttributeFormatInfo XmlNameAttribute
    	{
    		get => _xmlNameAttribute ?? (_xmlNameAttribute = new XmlNameAttributeFormatInfo());
    		set => _xmlNameAttribute = value;
    	}
    	XmlNameAttributeFormatInfo _xmlNameAttribute;
    
    	/// <summary>
        /// Provides language-specific information about the "ParenthesizedExpression" type.
        /// </summary>
    	public virtual ParenthesizedExpressionFormatInfo ParenthesizedExpression
    	{
    		get => _parenthesizedExpression ?? (_parenthesizedExpression = new ParenthesizedExpressionFormatInfo());
    		set => _parenthesizedExpression = value;
    	}
    	ParenthesizedExpressionFormatInfo _parenthesizedExpression;
    
    	/// <summary>
        /// Provides language-specific information about the "TupleExpression" type.
        /// </summary>
    	public virtual TupleExpressionFormatInfo TupleExpression
    	{
    		get => _tupleExpression ?? (_tupleExpression = new TupleExpressionFormatInfo());
    		set => _tupleExpression = value;
    	}
    	TupleExpressionFormatInfo _tupleExpression;
    
    	/// <summary>
        /// Provides language-specific information about the "PrefixUnaryExpression" type.
        /// </summary>
    	public virtual PrefixUnaryExpressionFormatInfo PrefixUnaryExpression
    	{
    		get => _prefixUnaryExpression ?? (_prefixUnaryExpression = new PrefixUnaryExpressionFormatInfo());
    		set => _prefixUnaryExpression = value;
    	}
    	PrefixUnaryExpressionFormatInfo _prefixUnaryExpression;
    
    	/// <summary>
        /// Provides language-specific information about the "AwaitExpression" type.
        /// </summary>
    	public virtual AwaitExpressionFormatInfo AwaitExpression
    	{
    		get => _awaitExpression ?? (_awaitExpression = new AwaitExpressionFormatInfo());
    		set => _awaitExpression = value;
    	}
    	AwaitExpressionFormatInfo _awaitExpression;
    
    	/// <summary>
        /// Provides language-specific information about the "PostfixUnaryExpression" type.
        /// </summary>
    	public virtual PostfixUnaryExpressionFormatInfo PostfixUnaryExpression
    	{
    		get => _postfixUnaryExpression ?? (_postfixUnaryExpression = new PostfixUnaryExpressionFormatInfo());
    		set => _postfixUnaryExpression = value;
    	}
    	PostfixUnaryExpressionFormatInfo _postfixUnaryExpression;
    
    	/// <summary>
        /// Provides language-specific information about the "MemberAccessExpression" type.
        /// </summary>
    	public virtual MemberAccessExpressionFormatInfo MemberAccessExpression
    	{
    		get => _memberAccessExpression ?? (_memberAccessExpression = new MemberAccessExpressionFormatInfo());
    		set => _memberAccessExpression = value;
    	}
    	MemberAccessExpressionFormatInfo _memberAccessExpression;
    
    	/// <summary>
        /// Provides language-specific information about the "ConditionalAccessExpression" type.
        /// </summary>
    	public virtual ConditionalAccessExpressionFormatInfo ConditionalAccessExpression
    	{
    		get => _conditionalAccessExpression ?? (_conditionalAccessExpression = new ConditionalAccessExpressionFormatInfo());
    		set => _conditionalAccessExpression = value;
    	}
    	ConditionalAccessExpressionFormatInfo _conditionalAccessExpression;
    
    	/// <summary>
        /// Provides language-specific information about the "MemberBindingExpression" type.
        /// </summary>
    	public virtual MemberBindingExpressionFormatInfo MemberBindingExpression
    	{
    		get => _memberBindingExpression ?? (_memberBindingExpression = new MemberBindingExpressionFormatInfo());
    		set => _memberBindingExpression = value;
    	}
    	MemberBindingExpressionFormatInfo _memberBindingExpression;
    
    	/// <summary>
        /// Provides language-specific information about the "ElementBindingExpression" type.
        /// </summary>
    	public virtual ElementBindingExpressionFormatInfo ElementBindingExpression
    	{
    		get => _elementBindingExpression ?? (_elementBindingExpression = new ElementBindingExpressionFormatInfo());
    		set => _elementBindingExpression = value;
    	}
    	ElementBindingExpressionFormatInfo _elementBindingExpression;
    
    	/// <summary>
        /// Provides language-specific information about the "ImplicitElementAccess" type.
        /// </summary>
    	public virtual ImplicitElementAccessFormatInfo ImplicitElementAccess
    	{
    		get => _implicitElementAccess ?? (_implicitElementAccess = new ImplicitElementAccessFormatInfo());
    		set => _implicitElementAccess = value;
    	}
    	ImplicitElementAccessFormatInfo _implicitElementAccess;
    
    	/// <summary>
        /// Provides language-specific information about the "BinaryExpression" type.
        /// </summary>
    	public virtual BinaryExpressionFormatInfo BinaryExpression
    	{
    		get => _binaryExpression ?? (_binaryExpression = new BinaryExpressionFormatInfo());
    		set => _binaryExpression = value;
    	}
    	BinaryExpressionFormatInfo _binaryExpression;
    
    	/// <summary>
        /// Provides language-specific information about the "AssignmentExpression" type.
        /// </summary>
    	public virtual AssignmentExpressionFormatInfo AssignmentExpression
    	{
    		get => _assignmentExpression ?? (_assignmentExpression = new AssignmentExpressionFormatInfo());
    		set => _assignmentExpression = value;
    	}
    	AssignmentExpressionFormatInfo _assignmentExpression;
    
    	/// <summary>
        /// Provides language-specific information about the "ConditionalExpression" type.
        /// </summary>
    	public virtual ConditionalExpressionFormatInfo ConditionalExpression
    	{
    		get => _conditionalExpression ?? (_conditionalExpression = new ConditionalExpressionFormatInfo());
    		set => _conditionalExpression = value;
    	}
    	ConditionalExpressionFormatInfo _conditionalExpression;
    
    	/// <summary>
        /// Provides language-specific information about the "LiteralExpression" type.
        /// </summary>
    	public virtual LiteralExpressionFormatInfo LiteralExpression
    	{
    		get => _literalExpression ?? (_literalExpression = new LiteralExpressionFormatInfo());
    		set => _literalExpression = value;
    	}
    	LiteralExpressionFormatInfo _literalExpression;
    
    	/// <summary>
        /// Provides language-specific information about the "MakeRefExpression" type.
        /// </summary>
    	public virtual MakeRefExpressionFormatInfo MakeRefExpression
    	{
    		get => _makeRefExpression ?? (_makeRefExpression = new MakeRefExpressionFormatInfo());
    		set => _makeRefExpression = value;
    	}
    	MakeRefExpressionFormatInfo _makeRefExpression;
    
    	/// <summary>
        /// Provides language-specific information about the "RefTypeExpression" type.
        /// </summary>
    	public virtual RefTypeExpressionFormatInfo RefTypeExpression
    	{
    		get => _refTypeExpression ?? (_refTypeExpression = new RefTypeExpressionFormatInfo());
    		set => _refTypeExpression = value;
    	}
    	RefTypeExpressionFormatInfo _refTypeExpression;
    
    	/// <summary>
        /// Provides language-specific information about the "RefValueExpression" type.
        /// </summary>
    	public virtual RefValueExpressionFormatInfo RefValueExpression
    	{
    		get => _refValueExpression ?? (_refValueExpression = new RefValueExpressionFormatInfo());
    		set => _refValueExpression = value;
    	}
    	RefValueExpressionFormatInfo _refValueExpression;
    
    	/// <summary>
        /// Provides language-specific information about the "CheckedExpression" type.
        /// </summary>
    	public virtual CheckedExpressionFormatInfo CheckedExpression
    	{
    		get => _checkedExpression ?? (_checkedExpression = new CheckedExpressionFormatInfo());
    		set => _checkedExpression = value;
    	}
    	CheckedExpressionFormatInfo _checkedExpression;
    
    	/// <summary>
        /// Provides language-specific information about the "DefaultExpression" type.
        /// </summary>
    	public virtual DefaultExpressionFormatInfo DefaultExpression
    	{
    		get => _defaultExpression ?? (_defaultExpression = new DefaultExpressionFormatInfo());
    		set => _defaultExpression = value;
    	}
    	DefaultExpressionFormatInfo _defaultExpression;
    
    	/// <summary>
        /// Provides language-specific information about the "TypeOfExpression" type.
        /// </summary>
    	public virtual TypeOfExpressionFormatInfo TypeOfExpression
    	{
    		get => _typeOfExpression ?? (_typeOfExpression = new TypeOfExpressionFormatInfo());
    		set => _typeOfExpression = value;
    	}
    	TypeOfExpressionFormatInfo _typeOfExpression;
    
    	/// <summary>
        /// Provides language-specific information about the "SizeOfExpression" type.
        /// </summary>
    	public virtual SizeOfExpressionFormatInfo SizeOfExpression
    	{
    		get => _sizeOfExpression ?? (_sizeOfExpression = new SizeOfExpressionFormatInfo());
    		set => _sizeOfExpression = value;
    	}
    	SizeOfExpressionFormatInfo _sizeOfExpression;
    
    	/// <summary>
        /// Provides language-specific information about the "InvocationExpression" type.
        /// </summary>
    	public virtual InvocationExpressionFormatInfo InvocationExpression
    	{
    		get => _invocationExpression ?? (_invocationExpression = new InvocationExpressionFormatInfo());
    		set => _invocationExpression = value;
    	}
    	InvocationExpressionFormatInfo _invocationExpression;
    
    	/// <summary>
        /// Provides language-specific information about the "ElementAccessExpression" type.
        /// </summary>
    	public virtual ElementAccessExpressionFormatInfo ElementAccessExpression
    	{
    		get => _elementAccessExpression ?? (_elementAccessExpression = new ElementAccessExpressionFormatInfo());
    		set => _elementAccessExpression = value;
    	}
    	ElementAccessExpressionFormatInfo _elementAccessExpression;
    
    	/// <summary>
        /// Provides language-specific information about the "DeclarationExpression" type.
        /// </summary>
    	public virtual DeclarationExpressionFormatInfo DeclarationExpression
    	{
    		get => _declarationExpression ?? (_declarationExpression = new DeclarationExpressionFormatInfo());
    		set => _declarationExpression = value;
    	}
    	DeclarationExpressionFormatInfo _declarationExpression;
    
    	/// <summary>
        /// Provides language-specific information about the "CastExpression" type.
        /// </summary>
    	public virtual CastExpressionFormatInfo CastExpression
    	{
    		get => _castExpression ?? (_castExpression = new CastExpressionFormatInfo());
    		set => _castExpression = value;
    	}
    	CastExpressionFormatInfo _castExpression;
    
    	/// <summary>
        /// Provides language-specific information about the "RefExpression" type.
        /// </summary>
    	public virtual RefExpressionFormatInfo RefExpression
    	{
    		get => _refExpression ?? (_refExpression = new RefExpressionFormatInfo());
    		set => _refExpression = value;
    	}
    	RefExpressionFormatInfo _refExpression;
    
    	/// <summary>
        /// Provides language-specific information about the "InitializerExpression" type.
        /// </summary>
    	public virtual InitializerExpressionFormatInfo InitializerExpression
    	{
    		get => _initializerExpression ?? (_initializerExpression = new InitializerExpressionFormatInfo());
    		set => _initializerExpression = value;
    	}
    	InitializerExpressionFormatInfo _initializerExpression;
    
    	/// <summary>
        /// Provides language-specific information about the "ObjectCreationExpression" type.
        /// </summary>
    	public virtual ObjectCreationExpressionFormatInfo ObjectCreationExpression
    	{
    		get => _objectCreationExpression ?? (_objectCreationExpression = new ObjectCreationExpressionFormatInfo());
    		set => _objectCreationExpression = value;
    	}
    	ObjectCreationExpressionFormatInfo _objectCreationExpression;
    
    	/// <summary>
        /// Provides language-specific information about the "AnonymousObjectCreationExpression" type.
        /// </summary>
    	public virtual AnonymousObjectCreationExpressionFormatInfo AnonymousObjectCreationExpression
    	{
    		get => _anonymousObjectCreationExpression ?? (_anonymousObjectCreationExpression = new AnonymousObjectCreationExpressionFormatInfo());
    		set => _anonymousObjectCreationExpression = value;
    	}
    	AnonymousObjectCreationExpressionFormatInfo _anonymousObjectCreationExpression;
    
    	/// <summary>
        /// Provides language-specific information about the "ArrayCreationExpression" type.
        /// </summary>
    	public virtual ArrayCreationExpressionFormatInfo ArrayCreationExpression
    	{
    		get => _arrayCreationExpression ?? (_arrayCreationExpression = new ArrayCreationExpressionFormatInfo());
    		set => _arrayCreationExpression = value;
    	}
    	ArrayCreationExpressionFormatInfo _arrayCreationExpression;
    
    	/// <summary>
        /// Provides language-specific information about the "ImplicitArrayCreationExpression" type.
        /// </summary>
    	public virtual ImplicitArrayCreationExpressionFormatInfo ImplicitArrayCreationExpression
    	{
    		get => _implicitArrayCreationExpression ?? (_implicitArrayCreationExpression = new ImplicitArrayCreationExpressionFormatInfo());
    		set => _implicitArrayCreationExpression = value;
    	}
    	ImplicitArrayCreationExpressionFormatInfo _implicitArrayCreationExpression;
    
    	/// <summary>
        /// Provides language-specific information about the "StackAllocArrayCreationExpression" type.
        /// </summary>
    	public virtual StackAllocArrayCreationExpressionFormatInfo StackAllocArrayCreationExpression
    	{
    		get => _stackAllocArrayCreationExpression ?? (_stackAllocArrayCreationExpression = new StackAllocArrayCreationExpressionFormatInfo());
    		set => _stackAllocArrayCreationExpression = value;
    	}
    	StackAllocArrayCreationExpressionFormatInfo _stackAllocArrayCreationExpression;
    
    	/// <summary>
        /// Provides language-specific information about the "QueryExpression" type.
        /// </summary>
    	public virtual QueryExpressionFormatInfo QueryExpression
    	{
    		get => _queryExpression ?? (_queryExpression = new QueryExpressionFormatInfo());
    		set => _queryExpression = value;
    	}
    	QueryExpressionFormatInfo _queryExpression;
    
    	/// <summary>
        /// Provides language-specific information about the "OmittedArraySizeExpression" type.
        /// </summary>
    	public virtual OmittedArraySizeExpressionFormatInfo OmittedArraySizeExpression
    	{
    		get => _omittedArraySizeExpression ?? (_omittedArraySizeExpression = new OmittedArraySizeExpressionFormatInfo());
    		set => _omittedArraySizeExpression = value;
    	}
    	OmittedArraySizeExpressionFormatInfo _omittedArraySizeExpression;
    
    	/// <summary>
        /// Provides language-specific information about the "InterpolatedStringExpression" type.
        /// </summary>
    	public virtual InterpolatedStringExpressionFormatInfo InterpolatedStringExpression
    	{
    		get => _interpolatedStringExpression ?? (_interpolatedStringExpression = new InterpolatedStringExpressionFormatInfo());
    		set => _interpolatedStringExpression = value;
    	}
    	InterpolatedStringExpressionFormatInfo _interpolatedStringExpression;
    
    	/// <summary>
        /// Provides language-specific information about the "IsPatternExpression" type.
        /// </summary>
    	public virtual IsPatternExpressionFormatInfo IsPatternExpression
    	{
    		get => _isPatternExpression ?? (_isPatternExpression = new IsPatternExpressionFormatInfo());
    		set => _isPatternExpression = value;
    	}
    	IsPatternExpressionFormatInfo _isPatternExpression;
    
    	/// <summary>
        /// Provides language-specific information about the "ThrowExpression" type.
        /// </summary>
    	public virtual ThrowExpressionFormatInfo ThrowExpression
    	{
    		get => _throwExpression ?? (_throwExpression = new ThrowExpressionFormatInfo());
    		set => _throwExpression = value;
    	}
    	ThrowExpressionFormatInfo _throwExpression;
    
    	/// <summary>
        /// Provides language-specific information about the "PredefinedType" type.
        /// </summary>
    	public virtual PredefinedTypeFormatInfo PredefinedType
    	{
    		get => _predefinedType ?? (_predefinedType = new PredefinedTypeFormatInfo());
    		set => _predefinedType = value;
    	}
    	PredefinedTypeFormatInfo _predefinedType;
    
    	/// <summary>
        /// Provides language-specific information about the "ArrayType" type.
        /// </summary>
    	public virtual ArrayTypeFormatInfo ArrayType
    	{
    		get => _arrayType ?? (_arrayType = new ArrayTypeFormatInfo());
    		set => _arrayType = value;
    	}
    	ArrayTypeFormatInfo _arrayType;
    
    	/// <summary>
        /// Provides language-specific information about the "PointerType" type.
        /// </summary>
    	public virtual PointerTypeFormatInfo PointerType
    	{
    		get => _pointerType ?? (_pointerType = new PointerTypeFormatInfo());
    		set => _pointerType = value;
    	}
    	PointerTypeFormatInfo _pointerType;
    
    	/// <summary>
        /// Provides language-specific information about the "NullableType" type.
        /// </summary>
    	public virtual NullableTypeFormatInfo NullableType
    	{
    		get => _nullableType ?? (_nullableType = new NullableTypeFormatInfo());
    		set => _nullableType = value;
    	}
    	NullableTypeFormatInfo _nullableType;
    
    	/// <summary>
        /// Provides language-specific information about the "TupleType" type.
        /// </summary>
    	public virtual TupleTypeFormatInfo TupleType
    	{
    		get => _tupleType ?? (_tupleType = new TupleTypeFormatInfo());
    		set => _tupleType = value;
    	}
    	TupleTypeFormatInfo _tupleType;
    
    	/// <summary>
        /// Provides language-specific information about the "OmittedTypeArgument" type.
        /// </summary>
    	public virtual OmittedTypeArgumentFormatInfo OmittedTypeArgument
    	{
    		get => _omittedTypeArgument ?? (_omittedTypeArgument = new OmittedTypeArgumentFormatInfo());
    		set => _omittedTypeArgument = value;
    	}
    	OmittedTypeArgumentFormatInfo _omittedTypeArgument;
    
    	/// <summary>
        /// Provides language-specific information about the "RefType" type.
        /// </summary>
    	public virtual RefTypeFormatInfo RefType
    	{
    		get => _refType ?? (_refType = new RefTypeFormatInfo());
    		set => _refType = value;
    	}
    	RefTypeFormatInfo _refType;
    
    	/// <summary>
        /// Provides language-specific information about the "QualifiedName" type.
        /// </summary>
    	public virtual QualifiedNameFormatInfo QualifiedName
    	{
    		get => _qualifiedName ?? (_qualifiedName = new QualifiedNameFormatInfo());
    		set => _qualifiedName = value;
    	}
    	QualifiedNameFormatInfo _qualifiedName;
    
    	/// <summary>
        /// Provides language-specific information about the "AliasQualifiedName" type.
        /// </summary>
    	public virtual AliasQualifiedNameFormatInfo AliasQualifiedName
    	{
    		get => _aliasQualifiedName ?? (_aliasQualifiedName = new AliasQualifiedNameFormatInfo());
    		set => _aliasQualifiedName = value;
    	}
    	AliasQualifiedNameFormatInfo _aliasQualifiedName;
    
    	/// <summary>
        /// Provides language-specific information about the "IdentifierName" type.
        /// </summary>
    	public virtual IdentifierNameFormatInfo IdentifierName
    	{
    		get => _identifierName ?? (_identifierName = new IdentifierNameFormatInfo());
    		set => _identifierName = value;
    	}
    	IdentifierNameFormatInfo _identifierName;
    
    	/// <summary>
        /// Provides language-specific information about the "GenericName" type.
        /// </summary>
    	public virtual GenericNameFormatInfo GenericName
    	{
    		get => _genericName ?? (_genericName = new GenericNameFormatInfo());
    		set => _genericName = value;
    	}
    	GenericNameFormatInfo _genericName;
    
    	/// <summary>
        /// Provides language-specific information about the "ThisExpression" type.
        /// </summary>
    	public virtual ThisExpressionFormatInfo ThisExpression
    	{
    		get => _thisExpression ?? (_thisExpression = new ThisExpressionFormatInfo());
    		set => _thisExpression = value;
    	}
    	ThisExpressionFormatInfo _thisExpression;
    
    	/// <summary>
        /// Provides language-specific information about the "BaseExpression" type.
        /// </summary>
    	public virtual BaseExpressionFormatInfo BaseExpression
    	{
    		get => _baseExpression ?? (_baseExpression = new BaseExpressionFormatInfo());
    		set => _baseExpression = value;
    	}
    	BaseExpressionFormatInfo _baseExpression;
    
    	/// <summary>
        /// Provides language-specific information about the "AnonymousMethodExpression" type.
        /// </summary>
    	public virtual AnonymousMethodExpressionFormatInfo AnonymousMethodExpression
    	{
    		get => _anonymousMethodExpression ?? (_anonymousMethodExpression = new AnonymousMethodExpressionFormatInfo());
    		set => _anonymousMethodExpression = value;
    	}
    	AnonymousMethodExpressionFormatInfo _anonymousMethodExpression;
    
    	/// <summary>
        /// Provides language-specific information about the "SimpleLambdaExpression" type.
        /// </summary>
    	public virtual SimpleLambdaExpressionFormatInfo SimpleLambdaExpression
    	{
    		get => _simpleLambdaExpression ?? (_simpleLambdaExpression = new SimpleLambdaExpressionFormatInfo());
    		set => _simpleLambdaExpression = value;
    	}
    	SimpleLambdaExpressionFormatInfo _simpleLambdaExpression;
    
    	/// <summary>
        /// Provides language-specific information about the "ParenthesizedLambdaExpression" type.
        /// </summary>
    	public virtual ParenthesizedLambdaExpressionFormatInfo ParenthesizedLambdaExpression
    	{
    		get => _parenthesizedLambdaExpression ?? (_parenthesizedLambdaExpression = new ParenthesizedLambdaExpressionFormatInfo());
    		set => _parenthesizedLambdaExpression = value;
    	}
    	ParenthesizedLambdaExpressionFormatInfo _parenthesizedLambdaExpression;
    
    	/// <summary>
        /// Provides language-specific information about the "ArgumentList" type.
        /// </summary>
    	public virtual ArgumentListFormatInfo ArgumentList
    	{
    		get => _argumentList ?? (_argumentList = new ArgumentListFormatInfo());
    		set => _argumentList = value;
    	}
    	ArgumentListFormatInfo _argumentList;
    
    	/// <summary>
        /// Provides language-specific information about the "BracketedArgumentList" type.
        /// </summary>
    	public virtual BracketedArgumentListFormatInfo BracketedArgumentList
    	{
    		get => _bracketedArgumentList ?? (_bracketedArgumentList = new BracketedArgumentListFormatInfo());
    		set => _bracketedArgumentList = value;
    	}
    	BracketedArgumentListFormatInfo _bracketedArgumentList;
    
    	/// <summary>
        /// Provides language-specific information about the "FromClause" type.
        /// </summary>
    	public virtual FromClauseFormatInfo FromClause
    	{
    		get => _fromClause ?? (_fromClause = new FromClauseFormatInfo());
    		set => _fromClause = value;
    	}
    	FromClauseFormatInfo _fromClause;
    
    	/// <summary>
        /// Provides language-specific information about the "LetClause" type.
        /// </summary>
    	public virtual LetClauseFormatInfo LetClause
    	{
    		get => _letClause ?? (_letClause = new LetClauseFormatInfo());
    		set => _letClause = value;
    	}
    	LetClauseFormatInfo _letClause;
    
    	/// <summary>
        /// Provides language-specific information about the "JoinClause" type.
        /// </summary>
    	public virtual JoinClauseFormatInfo JoinClause
    	{
    		get => _joinClause ?? (_joinClause = new JoinClauseFormatInfo());
    		set => _joinClause = value;
    	}
    	JoinClauseFormatInfo _joinClause;
    
    	/// <summary>
        /// Provides language-specific information about the "WhereClause" type.
        /// </summary>
    	public virtual WhereClauseFormatInfo WhereClause
    	{
    		get => _whereClause ?? (_whereClause = new WhereClauseFormatInfo());
    		set => _whereClause = value;
    	}
    	WhereClauseFormatInfo _whereClause;
    
    	/// <summary>
        /// Provides language-specific information about the "OrderByClause" type.
        /// </summary>
    	public virtual OrderByClauseFormatInfo OrderByClause
    	{
    		get => _orderByClause ?? (_orderByClause = new OrderByClauseFormatInfo());
    		set => _orderByClause = value;
    	}
    	OrderByClauseFormatInfo _orderByClause;
    
    	/// <summary>
        /// Provides language-specific information about the "SelectClause" type.
        /// </summary>
    	public virtual SelectClauseFormatInfo SelectClause
    	{
    		get => _selectClause ?? (_selectClause = new SelectClauseFormatInfo());
    		set => _selectClause = value;
    	}
    	SelectClauseFormatInfo _selectClause;
    
    	/// <summary>
        /// Provides language-specific information about the "GroupClause" type.
        /// </summary>
    	public virtual GroupClauseFormatInfo GroupClause
    	{
    		get => _groupClause ?? (_groupClause = new GroupClauseFormatInfo());
    		set => _groupClause = value;
    	}
    	GroupClauseFormatInfo _groupClause;
    
    	/// <summary>
        /// Provides language-specific information about the "DeclarationPattern" type.
        /// </summary>
    	public virtual DeclarationPatternFormatInfo DeclarationPattern
    	{
    		get => _declarationPattern ?? (_declarationPattern = new DeclarationPatternFormatInfo());
    		set => _declarationPattern = value;
    	}
    	DeclarationPatternFormatInfo _declarationPattern;
    
    	/// <summary>
        /// Provides language-specific information about the "ConstantPattern" type.
        /// </summary>
    	public virtual ConstantPatternFormatInfo ConstantPattern
    	{
    		get => _constantPattern ?? (_constantPattern = new ConstantPatternFormatInfo());
    		set => _constantPattern = value;
    	}
    	ConstantPatternFormatInfo _constantPattern;
    
    	/// <summary>
        /// Provides language-specific information about the "InterpolatedStringText" type.
        /// </summary>
    	public virtual InterpolatedStringTextFormatInfo InterpolatedStringText
    	{
    		get => _interpolatedStringText ?? (_interpolatedStringText = new InterpolatedStringTextFormatInfo());
    		set => _interpolatedStringText = value;
    	}
    	InterpolatedStringTextFormatInfo _interpolatedStringText;
    
    	/// <summary>
        /// Provides language-specific information about the "Interpolation" type.
        /// </summary>
    	public virtual InterpolationFormatInfo Interpolation
    	{
    		get => _interpolation ?? (_interpolation = new InterpolationFormatInfo());
    		set => _interpolation = value;
    	}
    	InterpolationFormatInfo _interpolation;
    
    	/// <summary>
        /// Provides language-specific information about the "Block" type.
        /// </summary>
    	public virtual BlockFormatInfo Block
    	{
    		get => _block ?? (_block = new BlockFormatInfo());
    		set => _block = value;
    	}
    	BlockFormatInfo _block;
    
    	/// <summary>
        /// Provides language-specific information about the "LocalFunctionStatement" type.
        /// </summary>
    	public virtual LocalFunctionStatementFormatInfo LocalFunctionStatement
    	{
    		get => _localFunctionStatement ?? (_localFunctionStatement = new LocalFunctionStatementFormatInfo());
    		set => _localFunctionStatement = value;
    	}
    	LocalFunctionStatementFormatInfo _localFunctionStatement;
    
    	/// <summary>
        /// Provides language-specific information about the "LocalDeclarationStatement" type.
        /// </summary>
    	public virtual LocalDeclarationStatementFormatInfo LocalDeclarationStatement
    	{
    		get => _localDeclarationStatement ?? (_localDeclarationStatement = new LocalDeclarationStatementFormatInfo());
    		set => _localDeclarationStatement = value;
    	}
    	LocalDeclarationStatementFormatInfo _localDeclarationStatement;
    
    	/// <summary>
        /// Provides language-specific information about the "ExpressionStatement" type.
        /// </summary>
    	public virtual ExpressionStatementFormatInfo ExpressionStatement
    	{
    		get => _expressionStatement ?? (_expressionStatement = new ExpressionStatementFormatInfo());
    		set => _expressionStatement = value;
    	}
    	ExpressionStatementFormatInfo _expressionStatement;
    
    	/// <summary>
        /// Provides language-specific information about the "EmptyStatement" type.
        /// </summary>
    	public virtual EmptyStatementFormatInfo EmptyStatement
    	{
    		get => _emptyStatement ?? (_emptyStatement = new EmptyStatementFormatInfo());
    		set => _emptyStatement = value;
    	}
    	EmptyStatementFormatInfo _emptyStatement;
    
    	/// <summary>
        /// Provides language-specific information about the "LabeledStatement" type.
        /// </summary>
    	public virtual LabeledStatementFormatInfo LabeledStatement
    	{
    		get => _labeledStatement ?? (_labeledStatement = new LabeledStatementFormatInfo());
    		set => _labeledStatement = value;
    	}
    	LabeledStatementFormatInfo _labeledStatement;
    
    	/// <summary>
        /// Provides language-specific information about the "GotoStatement" type.
        /// </summary>
    	public virtual GotoStatementFormatInfo GotoStatement
    	{
    		get => _gotoStatement ?? (_gotoStatement = new GotoStatementFormatInfo());
    		set => _gotoStatement = value;
    	}
    	GotoStatementFormatInfo _gotoStatement;
    
    	/// <summary>
        /// Provides language-specific information about the "BreakStatement" type.
        /// </summary>
    	public virtual BreakStatementFormatInfo BreakStatement
    	{
    		get => _breakStatement ?? (_breakStatement = new BreakStatementFormatInfo());
    		set => _breakStatement = value;
    	}
    	BreakStatementFormatInfo _breakStatement;
    
    	/// <summary>
        /// Provides language-specific information about the "ContinueStatement" type.
        /// </summary>
    	public virtual ContinueStatementFormatInfo ContinueStatement
    	{
    		get => _continueStatement ?? (_continueStatement = new ContinueStatementFormatInfo());
    		set => _continueStatement = value;
    	}
    	ContinueStatementFormatInfo _continueStatement;
    
    	/// <summary>
        /// Provides language-specific information about the "ReturnStatement" type.
        /// </summary>
    	public virtual ReturnStatementFormatInfo ReturnStatement
    	{
    		get => _returnStatement ?? (_returnStatement = new ReturnStatementFormatInfo());
    		set => _returnStatement = value;
    	}
    	ReturnStatementFormatInfo _returnStatement;
    
    	/// <summary>
        /// Provides language-specific information about the "ThrowStatement" type.
        /// </summary>
    	public virtual ThrowStatementFormatInfo ThrowStatement
    	{
    		get => _throwStatement ?? (_throwStatement = new ThrowStatementFormatInfo());
    		set => _throwStatement = value;
    	}
    	ThrowStatementFormatInfo _throwStatement;
    
    	/// <summary>
        /// Provides language-specific information about the "YieldStatement" type.
        /// </summary>
    	public virtual YieldStatementFormatInfo YieldStatement
    	{
    		get => _yieldStatement ?? (_yieldStatement = new YieldStatementFormatInfo());
    		set => _yieldStatement = value;
    	}
    	YieldStatementFormatInfo _yieldStatement;
    
    	/// <summary>
        /// Provides language-specific information about the "WhileStatement" type.
        /// </summary>
    	public virtual WhileStatementFormatInfo WhileStatement
    	{
    		get => _whileStatement ?? (_whileStatement = new WhileStatementFormatInfo());
    		set => _whileStatement = value;
    	}
    	WhileStatementFormatInfo _whileStatement;
    
    	/// <summary>
        /// Provides language-specific information about the "DoStatement" type.
        /// </summary>
    	public virtual DoStatementFormatInfo DoStatement
    	{
    		get => _doStatement ?? (_doStatement = new DoStatementFormatInfo());
    		set => _doStatement = value;
    	}
    	DoStatementFormatInfo _doStatement;
    
    	/// <summary>
        /// Provides language-specific information about the "ForStatement" type.
        /// </summary>
    	public virtual ForStatementFormatInfo ForStatement
    	{
    		get => _forStatement ?? (_forStatement = new ForStatementFormatInfo());
    		set => _forStatement = value;
    	}
    	ForStatementFormatInfo _forStatement;
    
    	/// <summary>
        /// Provides language-specific information about the "UsingStatement" type.
        /// </summary>
    	public virtual UsingStatementFormatInfo UsingStatement
    	{
    		get => _usingStatement ?? (_usingStatement = new UsingStatementFormatInfo());
    		set => _usingStatement = value;
    	}
    	UsingStatementFormatInfo _usingStatement;
    
    	/// <summary>
        /// Provides language-specific information about the "FixedStatement" type.
        /// </summary>
    	public virtual FixedStatementFormatInfo FixedStatement
    	{
    		get => _fixedStatement ?? (_fixedStatement = new FixedStatementFormatInfo());
    		set => _fixedStatement = value;
    	}
    	FixedStatementFormatInfo _fixedStatement;
    
    	/// <summary>
        /// Provides language-specific information about the "CheckedStatement" type.
        /// </summary>
    	public virtual CheckedStatementFormatInfo CheckedStatement
    	{
    		get => _checkedStatement ?? (_checkedStatement = new CheckedStatementFormatInfo());
    		set => _checkedStatement = value;
    	}
    	CheckedStatementFormatInfo _checkedStatement;
    
    	/// <summary>
        /// Provides language-specific information about the "UnsafeStatement" type.
        /// </summary>
    	public virtual UnsafeStatementFormatInfo UnsafeStatement
    	{
    		get => _unsafeStatement ?? (_unsafeStatement = new UnsafeStatementFormatInfo());
    		set => _unsafeStatement = value;
    	}
    	UnsafeStatementFormatInfo _unsafeStatement;
    
    	/// <summary>
        /// Provides language-specific information about the "LockStatement" type.
        /// </summary>
    	public virtual LockStatementFormatInfo LockStatement
    	{
    		get => _lockStatement ?? (_lockStatement = new LockStatementFormatInfo());
    		set => _lockStatement = value;
    	}
    	LockStatementFormatInfo _lockStatement;
    
    	/// <summary>
        /// Provides language-specific information about the "IfStatement" type.
        /// </summary>
    	public virtual IfStatementFormatInfo IfStatement
    	{
    		get => _ifStatement ?? (_ifStatement = new IfStatementFormatInfo());
    		set => _ifStatement = value;
    	}
    	IfStatementFormatInfo _ifStatement;
    
    	/// <summary>
        /// Provides language-specific information about the "SwitchStatement" type.
        /// </summary>
    	public virtual SwitchStatementFormatInfo SwitchStatement
    	{
    		get => _switchStatement ?? (_switchStatement = new SwitchStatementFormatInfo());
    		set => _switchStatement = value;
    	}
    	SwitchStatementFormatInfo _switchStatement;
    
    	/// <summary>
        /// Provides language-specific information about the "TryStatement" type.
        /// </summary>
    	public virtual TryStatementFormatInfo TryStatement
    	{
    		get => _tryStatement ?? (_tryStatement = new TryStatementFormatInfo());
    		set => _tryStatement = value;
    	}
    	TryStatementFormatInfo _tryStatement;
    
    	/// <summary>
        /// Provides language-specific information about the "ForEachStatement" type.
        /// </summary>
    	public virtual ForEachStatementFormatInfo ForEachStatement
    	{
    		get => _forEachStatement ?? (_forEachStatement = new ForEachStatementFormatInfo());
    		set => _forEachStatement = value;
    	}
    	ForEachStatementFormatInfo _forEachStatement;
    
    	/// <summary>
        /// Provides language-specific information about the "ForEachVariableStatement" type.
        /// </summary>
    	public virtual ForEachVariableStatementFormatInfo ForEachVariableStatement
    	{
    		get => _forEachVariableStatement ?? (_forEachVariableStatement = new ForEachVariableStatementFormatInfo());
    		set => _forEachVariableStatement = value;
    	}
    	ForEachVariableStatementFormatInfo _forEachVariableStatement;
    
    	/// <summary>
        /// Provides language-specific information about the "SingleVariableDesignation" type.
        /// </summary>
    	public virtual SingleVariableDesignationFormatInfo SingleVariableDesignation
    	{
    		get => _singleVariableDesignation ?? (_singleVariableDesignation = new SingleVariableDesignationFormatInfo());
    		set => _singleVariableDesignation = value;
    	}
    	SingleVariableDesignationFormatInfo _singleVariableDesignation;
    
    	/// <summary>
        /// Provides language-specific information about the "DiscardDesignation" type.
        /// </summary>
    	public virtual DiscardDesignationFormatInfo DiscardDesignation
    	{
    		get => _discardDesignation ?? (_discardDesignation = new DiscardDesignationFormatInfo());
    		set => _discardDesignation = value;
    	}
    	DiscardDesignationFormatInfo _discardDesignation;
    
    	/// <summary>
        /// Provides language-specific information about the "ParenthesizedVariableDesignation" type.
        /// </summary>
    	public virtual ParenthesizedVariableDesignationFormatInfo ParenthesizedVariableDesignation
    	{
    		get => _parenthesizedVariableDesignation ?? (_parenthesizedVariableDesignation = new ParenthesizedVariableDesignationFormatInfo());
    		set => _parenthesizedVariableDesignation = value;
    	}
    	ParenthesizedVariableDesignationFormatInfo _parenthesizedVariableDesignation;
    
    	/// <summary>
        /// Provides language-specific information about the "CasePatternSwitchLabel" type.
        /// </summary>
    	public virtual CasePatternSwitchLabelFormatInfo CasePatternSwitchLabel
    	{
    		get => _casePatternSwitchLabel ?? (_casePatternSwitchLabel = new CasePatternSwitchLabelFormatInfo());
    		set => _casePatternSwitchLabel = value;
    	}
    	CasePatternSwitchLabelFormatInfo _casePatternSwitchLabel;
    
    	/// <summary>
        /// Provides language-specific information about the "CaseSwitchLabel" type.
        /// </summary>
    	public virtual CaseSwitchLabelFormatInfo CaseSwitchLabel
    	{
    		get => _caseSwitchLabel ?? (_caseSwitchLabel = new CaseSwitchLabelFormatInfo());
    		set => _caseSwitchLabel = value;
    	}
    	CaseSwitchLabelFormatInfo _caseSwitchLabel;
    
    	/// <summary>
        /// Provides language-specific information about the "DefaultSwitchLabel" type.
        /// </summary>
    	public virtual DefaultSwitchLabelFormatInfo DefaultSwitchLabel
    	{
    		get => _defaultSwitchLabel ?? (_defaultSwitchLabel = new DefaultSwitchLabelFormatInfo());
    		set => _defaultSwitchLabel = value;
    	}
    	DefaultSwitchLabelFormatInfo _defaultSwitchLabel;
    
    }
}
// Generated helper templates
// Generated items
