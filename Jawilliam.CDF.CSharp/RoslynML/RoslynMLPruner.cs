
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Jawilliam.CDF.CSharp.RoslynML
{
    public partial class RoslynMLPruner : RoslynML
    {
    	/// <summary>
        /// Gets the <see cref="IElementTypeServiceProvider"/> to provide information for the requested element type.
        /// </summary>
        /// <param name="type">requested element type.</param>
        /// <param name="kind">optionally the element type can be refined to an specific subtype.</param>
        /// <returns><see cref="IElementTypeServiceProvider"/> implementation intended to provide information for the requested element type.</returns>
        public virtual void PruneSelector(XElement source)
    	{
    		switch(source.Name.LocalName)
    		{
    			case "AttributeArgument": this.PruneAttributeArgumentSelector(source); break;
    			case "NameEquals": this.PruneNameEqualsSelector(source); break;
    			case "TypeParameterList": this.PruneTypeParameterListSelector(source); break;
    			case "TypeParameter": this.PruneTypeParameterSelector(source); break;
    			case "BaseList": this.PruneBaseListSelector(source); break;
    			case "TypeParameterConstraintClause": this.PruneTypeParameterConstraintClauseSelector(source); break;
    			case "ExplicitInterfaceSpecifier": this.PruneExplicitInterfaceSpecifierSelector(source); break;
    			case "ConstructorInitializer": this.PruneConstructorInitializerSelector(source); break;
    			case "ArrowExpressionClause": this.PruneArrowExpressionClauseSelector(source); break;
    			case "AccessorList": this.PruneAccessorListSelector(source); break;
    			case "AccessorDeclaration": this.PruneAccessorDeclarationSelector(source); break;
    			case "Parameter": this.PruneParameterSelector(source); break;
    			case "CrefParameter": this.PruneCrefParameterSelector(source); break;
    			case "XmlElementStartTag": this.PruneXmlElementStartTagSelector(source); break;
    			case "XmlElementEndTag": this.PruneXmlElementEndTagSelector(source); break;
    			case "XmlName": this.PruneXmlNameSelector(source); break;
    			case "XmlPrefix": this.PruneXmlPrefixSelector(source); break;
    			case "TypeArgumentList": this.PruneTypeArgumentListSelector(source); break;
    			case "ArrayRankSpecifier": this.PruneArrayRankSpecifierSelector(source); break;
    			case "TupleElement": this.PruneTupleElementSelector(source); break;
    			case "Argument": this.PruneArgumentSelector(source); break;
    			case "NameColon": this.PruneNameColonSelector(source); break;
    			case "AnonymousObjectMemberDeclarator": this.PruneAnonymousObjectMemberDeclaratorSelector(source); break;
    			case "QueryBody": this.PruneQueryBodySelector(source); break;
    			case "JoinIntoClause": this.PruneJoinIntoClauseSelector(source); break;
    			case "Ordering": this.PruneOrderingSelector(source); break;
    			case "QueryContinuation": this.PruneQueryContinuationSelector(source); break;
    			case "WhenClause": this.PruneWhenClauseSelector(source); break;
    			case "InterpolationAlignmentClause": this.PruneInterpolationAlignmentClauseSelector(source); break;
    			case "InterpolationFormatClause": this.PruneInterpolationFormatClauseSelector(source); break;
    			case "VariableDeclaration": this.PruneVariableDeclarationSelector(source); break;
    			case "VariableDeclarator": this.PruneVariableDeclaratorSelector(source); break;
    			case "EqualsValueClause": this.PruneEqualsValueClauseSelector(source); break;
    			case "ElseClause": this.PruneElseClauseSelector(source); break;
    			case "SwitchSection": this.PruneSwitchSectionSelector(source); break;
    			case "CatchClause": this.PruneCatchClauseSelector(source); break;
    			case "CatchDeclaration": this.PruneCatchDeclarationSelector(source); break;
    			case "CatchFilterClause": this.PruneCatchFilterClauseSelector(source); break;
    			case "FinallyClause": this.PruneFinallyClauseSelector(source); break;
    			case "CompilationUnit": this.PruneCompilationUnitSelector(source); break;
    			case "ExternAliasDirective": this.PruneExternAliasDirectiveSelector(source); break;
    			case "UsingDirective": this.PruneUsingDirectiveSelector(source); break;
    			case "AttributeList": this.PruneAttributeListSelector(source); break;
    			case "AttributeTargetSpecifier": this.PruneAttributeTargetSpecifierSelector(source); break;
    			case "Attribute": this.PruneAttributeSelector(source); break;
    			case "AttributeArgumentList": this.PruneAttributeArgumentListSelector(source); break;
    			case "DelegateDeclaration": this.PruneDelegateDeclarationSelector(source); break;
    			case "EnumMemberDeclaration": this.PruneEnumMemberDeclarationSelector(source); break;
    			case "IncompleteMember": this.PruneIncompleteMemberSelector(source); break;
    			case "GlobalStatement": this.PruneGlobalStatementSelector(source); break;
    			case "NamespaceDeclaration": this.PruneNamespaceDeclarationSelector(source); break;
    			case "EnumDeclaration": this.PruneEnumDeclarationSelector(source); break;
    			case "ClassDeclaration": this.PruneClassDeclarationSelector(source); break;
    			case "StructDeclaration": this.PruneStructDeclarationSelector(source); break;
    			case "InterfaceDeclaration": this.PruneInterfaceDeclarationSelector(source); break;
    			case "FieldDeclaration": this.PruneFieldDeclarationSelector(source); break;
    			case "EventFieldDeclaration": this.PruneEventFieldDeclarationSelector(source); break;
    			case "MethodDeclaration": this.PruneMethodDeclarationSelector(source); break;
    			case "OperatorDeclaration": this.PruneOperatorDeclarationSelector(source); break;
    			case "ConversionOperatorDeclaration": this.PruneConversionOperatorDeclarationSelector(source); break;
    			case "ConstructorDeclaration": this.PruneConstructorDeclarationSelector(source); break;
    			case "DestructorDeclaration": this.PruneDestructorDeclarationSelector(source); break;
    			case "PropertyDeclaration": this.PrunePropertyDeclarationSelector(source); break;
    			case "EventDeclaration": this.PruneEventDeclarationSelector(source); break;
    			case "IndexerDeclaration": this.PruneIndexerDeclarationSelector(source); break;
    			case "SimpleBaseType": this.PruneSimpleBaseTypeSelector(source); break;
    			case "ConstructorConstraint": this.PruneConstructorConstraintSelector(source); break;
    			case "ClassOrStructConstraint": this.PruneClassOrStructConstraintSelector(source); break;
    			case "TypeConstraint": this.PruneTypeConstraintSelector(source); break;
    			case "ParameterList": this.PruneParameterListSelector(source); break;
    			case "BracketedParameterList": this.PruneBracketedParameterListSelector(source); break;
    			case "SkippedTokensTrivia": this.PruneSkippedTokensTriviaSelector(source); break;
    			case "DocumentationCommentTrivia": this.PruneDocumentationCommentTriviaSelector(source); break;
    			case "EndIfDirectiveTrivia": this.PruneEndIfDirectiveTriviaSelector(source); break;
    			case "RegionDirectiveTrivia": this.PruneRegionDirectiveTriviaSelector(source); break;
    			case "EndRegionDirectiveTrivia": this.PruneEndRegionDirectiveTriviaSelector(source); break;
    			case "ErrorDirectiveTrivia": this.PruneErrorDirectiveTriviaSelector(source); break;
    			case "WarningDirectiveTrivia": this.PruneWarningDirectiveTriviaSelector(source); break;
    			case "BadDirectiveTrivia": this.PruneBadDirectiveTriviaSelector(source); break;
    			case "DefineDirectiveTrivia": this.PruneDefineDirectiveTriviaSelector(source); break;
    			case "UndefDirectiveTrivia": this.PruneUndefDirectiveTriviaSelector(source); break;
    			case "LineDirectiveTrivia": this.PruneLineDirectiveTriviaSelector(source); break;
    			case "PragmaWarningDirectiveTrivia": this.PrunePragmaWarningDirectiveTriviaSelector(source); break;
    			case "PragmaChecksumDirectiveTrivia": this.PrunePragmaChecksumDirectiveTriviaSelector(source); break;
    			case "ReferenceDirectiveTrivia": this.PruneReferenceDirectiveTriviaSelector(source); break;
    			case "LoadDirectiveTrivia": this.PruneLoadDirectiveTriviaSelector(source); break;
    			case "ShebangDirectiveTrivia": this.PruneShebangDirectiveTriviaSelector(source); break;
    			case "ElseDirectiveTrivia": this.PruneElseDirectiveTriviaSelector(source); break;
    			case "IfDirectiveTrivia": this.PruneIfDirectiveTriviaSelector(source); break;
    			case "ElifDirectiveTrivia": this.PruneElifDirectiveTriviaSelector(source); break;
    			case "TypeCref": this.PruneTypeCrefSelector(source); break;
    			case "QualifiedCref": this.PruneQualifiedCrefSelector(source); break;
    			case "NameMemberCref": this.PruneNameMemberCrefSelector(source); break;
    			case "IndexerMemberCref": this.PruneIndexerMemberCrefSelector(source); break;
    			case "OperatorMemberCref": this.PruneOperatorMemberCrefSelector(source); break;
    			case "ConversionOperatorMemberCref": this.PruneConversionOperatorMemberCrefSelector(source); break;
    			case "CrefParameterList": this.PruneCrefParameterListSelector(source); break;
    			case "CrefBracketedParameterList": this.PruneCrefBracketedParameterListSelector(source); break;
    			case "XmlElement": this.PruneXmlElementSelector(source); break;
    			case "XmlEmptyElement": this.PruneXmlEmptyElementSelector(source); break;
    			case "XmlText": this.PruneXmlTextSelector(source); break;
    			case "XmlCDataSection": this.PruneXmlCDataSectionSelector(source); break;
    			case "XmlProcessingInstruction": this.PruneXmlProcessingInstructionSelector(source); break;
    			case "XmlComment": this.PruneXmlCommentSelector(source); break;
    			case "XmlTextAttribute": this.PruneXmlTextAttributeSelector(source); break;
    			case "XmlCrefAttribute": this.PruneXmlCrefAttributeSelector(source); break;
    			case "XmlNameAttribute": this.PruneXmlNameAttributeSelector(source); break;
    			case "ParenthesizedExpression": this.PruneParenthesizedExpressionSelector(source); break;
    			case "TupleExpression": this.PruneTupleExpressionSelector(source); break;
    			case "PrefixUnaryExpression": this.PrunePrefixUnaryExpressionSelector(source); break;
    			case "AwaitExpression": this.PruneAwaitExpressionSelector(source); break;
    			case "PostfixUnaryExpression": this.PrunePostfixUnaryExpressionSelector(source); break;
    			case "MemberAccessExpression": this.PruneMemberAccessExpressionSelector(source); break;
    			case "ConditionalAccessExpression": this.PruneConditionalAccessExpressionSelector(source); break;
    			case "MemberBindingExpression": this.PruneMemberBindingExpressionSelector(source); break;
    			case "ElementBindingExpression": this.PruneElementBindingExpressionSelector(source); break;
    			case "ImplicitElementAccess": this.PruneImplicitElementAccessSelector(source); break;
    			case "BinaryExpression": this.PruneBinaryExpressionSelector(source); break;
    			case "AssignmentExpression": this.PruneAssignmentExpressionSelector(source); break;
    			case "ConditionalExpression": this.PruneConditionalExpressionSelector(source); break;
    			case "LiteralExpression": this.PruneLiteralExpressionSelector(source); break;
    			case "MakeRefExpression": this.PruneMakeRefExpressionSelector(source); break;
    			case "RefTypeExpression": this.PruneRefTypeExpressionSelector(source); break;
    			case "RefValueExpression": this.PruneRefValueExpressionSelector(source); break;
    			case "CheckedExpression": this.PruneCheckedExpressionSelector(source); break;
    			case "DefaultExpression": this.PruneDefaultExpressionSelector(source); break;
    			case "TypeOfExpression": this.PruneTypeOfExpressionSelector(source); break;
    			case "SizeOfExpression": this.PruneSizeOfExpressionSelector(source); break;
    			case "InvocationExpression": this.PruneInvocationExpressionSelector(source); break;
    			case "ElementAccessExpression": this.PruneElementAccessExpressionSelector(source); break;
    			case "DeclarationExpression": this.PruneDeclarationExpressionSelector(source); break;
    			case "CastExpression": this.PruneCastExpressionSelector(source); break;
    			case "RefExpression": this.PruneRefExpressionSelector(source); break;
    			case "InitializerExpression": this.PruneInitializerExpressionSelector(source); break;
    			case "ObjectCreationExpression": this.PruneObjectCreationExpressionSelector(source); break;
    			case "AnonymousObjectCreationExpression": this.PruneAnonymousObjectCreationExpressionSelector(source); break;
    			case "ArrayCreationExpression": this.PruneArrayCreationExpressionSelector(source); break;
    			case "ImplicitArrayCreationExpression": this.PruneImplicitArrayCreationExpressionSelector(source); break;
    			case "StackAllocArrayCreationExpression": this.PruneStackAllocArrayCreationExpressionSelector(source); break;
    			case "QueryExpression": this.PruneQueryExpressionSelector(source); break;
    			case "OmittedArraySizeExpression": this.PruneOmittedArraySizeExpressionSelector(source); break;
    			case "InterpolatedStringExpression": this.PruneInterpolatedStringExpressionSelector(source); break;
    			case "IsPatternExpression": this.PruneIsPatternExpressionSelector(source); break;
    			case "ThrowExpression": this.PruneThrowExpressionSelector(source); break;
    			case "PredefinedType": this.PrunePredefinedTypeSelector(source); break;
    			case "ArrayType": this.PruneArrayTypeSelector(source); break;
    			case "PointerType": this.PrunePointerTypeSelector(source); break;
    			case "NullableType": this.PruneNullableTypeSelector(source); break;
    			case "TupleType": this.PruneTupleTypeSelector(source); break;
    			case "OmittedTypeArgument": this.PruneOmittedTypeArgumentSelector(source); break;
    			case "RefType": this.PruneRefTypeSelector(source); break;
    			case "QualifiedName": this.PruneQualifiedNameSelector(source); break;
    			case "AliasQualifiedName": this.PruneAliasQualifiedNameSelector(source); break;
    			case "IdentifierName": this.PruneIdentifierNameSelector(source); break;
    			case "GenericName": this.PruneGenericNameSelector(source); break;
    			case "ThisExpression": this.PruneThisExpressionSelector(source); break;
    			case "BaseExpression": this.PruneBaseExpressionSelector(source); break;
    			case "AnonymousMethodExpression": this.PruneAnonymousMethodExpressionSelector(source); break;
    			case "SimpleLambdaExpression": this.PruneSimpleLambdaExpressionSelector(source); break;
    			case "ParenthesizedLambdaExpression": this.PruneParenthesizedLambdaExpressionSelector(source); break;
    			case "ArgumentList": this.PruneArgumentListSelector(source); break;
    			case "BracketedArgumentList": this.PruneBracketedArgumentListSelector(source); break;
    			case "FromClause": this.PruneFromClauseSelector(source); break;
    			case "LetClause": this.PruneLetClauseSelector(source); break;
    			case "JoinClause": this.PruneJoinClauseSelector(source); break;
    			case "WhereClause": this.PruneWhereClauseSelector(source); break;
    			case "OrderByClause": this.PruneOrderByClauseSelector(source); break;
    			case "SelectClause": this.PruneSelectClauseSelector(source); break;
    			case "GroupClause": this.PruneGroupClauseSelector(source); break;
    			case "DeclarationPattern": this.PruneDeclarationPatternSelector(source); break;
    			case "ConstantPattern": this.PruneConstantPatternSelector(source); break;
    			case "InterpolatedStringText": this.PruneInterpolatedStringTextSelector(source); break;
    			case "Interpolation": this.PruneInterpolationSelector(source); break;
    			case "Block": this.PruneBlockSelector(source); break;
    			case "LocalFunctionStatement": this.PruneLocalFunctionStatementSelector(source); break;
    			case "LocalDeclarationStatement": this.PruneLocalDeclarationStatementSelector(source); break;
    			case "ExpressionStatement": this.PruneExpressionStatementSelector(source); break;
    			case "EmptyStatement": this.PruneEmptyStatementSelector(source); break;
    			case "LabeledStatement": this.PruneLabeledStatementSelector(source); break;
    			case "GotoStatement": this.PruneGotoStatementSelector(source); break;
    			case "BreakStatement": this.PruneBreakStatementSelector(source); break;
    			case "ContinueStatement": this.PruneContinueStatementSelector(source); break;
    			case "ReturnStatement": this.PruneReturnStatementSelector(source); break;
    			case "ThrowStatement": this.PruneThrowStatementSelector(source); break;
    			case "YieldStatement": this.PruneYieldStatementSelector(source); break;
    			case "WhileStatement": this.PruneWhileStatementSelector(source); break;
    			case "DoStatement": this.PruneDoStatementSelector(source); break;
    			case "ForStatement": this.PruneForStatementSelector(source); break;
    			case "UsingStatement": this.PruneUsingStatementSelector(source); break;
    			case "FixedStatement": this.PruneFixedStatementSelector(source); break;
    			case "CheckedStatement": this.PruneCheckedStatementSelector(source); break;
    			case "UnsafeStatement": this.PruneUnsafeStatementSelector(source); break;
    			case "LockStatement": this.PruneLockStatementSelector(source); break;
    			case "IfStatement": this.PruneIfStatementSelector(source); break;
    			case "SwitchStatement": this.PruneSwitchStatementSelector(source); break;
    			case "TryStatement": this.PruneTryStatementSelector(source); break;
    			case "ForEachStatement": this.PruneForEachStatementSelector(source); break;
    			case "ForEachVariableStatement": this.PruneForEachVariableStatementSelector(source); break;
    			case "SingleVariableDesignation": this.PruneSingleVariableDesignationSelector(source); break;
    			case "DiscardDesignation": this.PruneDiscardDesignationSelector(source); break;
    			case "ParenthesizedVariableDesignation": this.PruneParenthesizedVariableDesignationSelector(source); break;
    			case "CasePatternSwitchLabel": this.PruneCasePatternSwitchLabelSelector(source); break;
    			case "CaseSwitchLabel": this.PruneCaseSwitchLabelSelector(source); break;
    			case "DefaultSwitchLabel": this.PruneDefaultSwitchLabelSelector(source); break;
    			default: throw new ArgumentException(source.Name.LocalName);
    		}
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneAttributeArgumentSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreAttributeArgumentSelector(XElement)"/> is not executed and <see cref="PruneAttributeArgumentSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeAttributeArgumentSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreAttributeArgumentSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterAttributeArgumentSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneAttributeArgumentSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreAttributeArgumentSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneAttributeArgumentSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeAttributeArgumentSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreAttributeArgumentSelector(source);
    		PruneAfterAttributeArgumentSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneNameEqualsSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreNameEqualsSelector(XElement)"/> is not executed and <see cref="PruneNameEqualsSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeNameEqualsSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreNameEqualsSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterNameEqualsSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneNameEqualsSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreNameEqualsSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "EqualsToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneNameEqualsSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeNameEqualsSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreNameEqualsSelector(source);
    		PruneAfterNameEqualsSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneTypeParameterListSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreTypeParameterListSelector(XElement)"/> is not executed and <see cref="PruneTypeParameterListSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeTypeParameterListSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreTypeParameterListSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterTypeParameterListSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneTypeParameterListSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreTypeParameterListSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "LessThanToken")
    			return false;
    		if(source.Name.LocalName == "GreaterThanToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneTypeParameterListSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeTypeParameterListSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreTypeParameterListSelector(source);
    		PruneAfterTypeParameterListSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneTypeParameterSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreTypeParameterSelector(XElement)"/> is not executed and <see cref="PruneTypeParameterSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeTypeParameterSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreTypeParameterSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterTypeParameterSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneTypeParameterSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreTypeParameterSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "VarianceKeyword")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneTypeParameterSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeTypeParameterSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreTypeParameterSelector(source);
    		PruneAfterTypeParameterSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneBaseListSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreBaseListSelector(XElement)"/> is not executed and <see cref="PruneBaseListSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeBaseListSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreBaseListSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterBaseListSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneBaseListSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreBaseListSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "ColonToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneBaseListSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeBaseListSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreBaseListSelector(source);
    		PruneAfterBaseListSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneTypeParameterConstraintClauseSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreTypeParameterConstraintClauseSelector(XElement)"/> is not executed and <see cref="PruneTypeParameterConstraintClauseSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeTypeParameterConstraintClauseSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreTypeParameterConstraintClauseSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterTypeParameterConstraintClauseSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneTypeParameterConstraintClauseSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreTypeParameterConstraintClauseSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "WhereKeyword")
    			return false;
    		if(source.Name.LocalName == "ColonToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneTypeParameterConstraintClauseSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeTypeParameterConstraintClauseSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreTypeParameterConstraintClauseSelector(source);
    		PruneAfterTypeParameterConstraintClauseSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneExplicitInterfaceSpecifierSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreExplicitInterfaceSpecifierSelector(XElement)"/> is not executed and <see cref="PruneExplicitInterfaceSpecifierSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeExplicitInterfaceSpecifierSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreExplicitInterfaceSpecifierSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterExplicitInterfaceSpecifierSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneExplicitInterfaceSpecifierSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreExplicitInterfaceSpecifierSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "DotToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneExplicitInterfaceSpecifierSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeExplicitInterfaceSpecifierSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreExplicitInterfaceSpecifierSelector(source);
    		PruneAfterExplicitInterfaceSpecifierSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneConstructorInitializerSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreConstructorInitializerSelector(XElement)"/> is not executed and <see cref="PruneConstructorInitializerSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeConstructorInitializerSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreConstructorInitializerSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterConstructorInitializerSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneConstructorInitializerSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreConstructorInitializerSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "ColonToken")
    			return false;
    		if(source.Name.LocalName == "ThisOrBaseKeyword")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneConstructorInitializerSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeConstructorInitializerSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreConstructorInitializerSelector(source);
    		PruneAfterConstructorInitializerSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneArrowExpressionClauseSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreArrowExpressionClauseSelector(XElement)"/> is not executed and <see cref="PruneArrowExpressionClauseSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeArrowExpressionClauseSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreArrowExpressionClauseSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterArrowExpressionClauseSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneArrowExpressionClauseSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreArrowExpressionClauseSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "ArrowToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneArrowExpressionClauseSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeArrowExpressionClauseSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreArrowExpressionClauseSelector(source);
    		PruneAfterArrowExpressionClauseSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneAccessorListSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreAccessorListSelector(XElement)"/> is not executed and <see cref="PruneAccessorListSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeAccessorListSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreAccessorListSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterAccessorListSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneAccessorListSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreAccessorListSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "OpenBraceToken")
    			return false;
    		if(source.Name.LocalName == "CloseBraceToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneAccessorListSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeAccessorListSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreAccessorListSelector(source);
    		PruneAfterAccessorListSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneAccessorDeclarationSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreAccessorDeclarationSelector(XElement)"/> is not executed and <see cref="PruneAccessorDeclarationSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeAccessorDeclarationSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreAccessorDeclarationSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterAccessorDeclarationSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneAccessorDeclarationSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreAccessorDeclarationSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "SemicolonToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneAccessorDeclarationSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeAccessorDeclarationSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreAccessorDeclarationSelector(source);
    		PruneAfterAccessorDeclarationSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneParameterSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreParameterSelector(XElement)"/> is not executed and <see cref="PruneParameterSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeParameterSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreParameterSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterParameterSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneParameterSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreParameterSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneParameterSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeParameterSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreParameterSelector(source);
    		PruneAfterParameterSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneCrefParameterSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreCrefParameterSelector(XElement)"/> is not executed and <see cref="PruneCrefParameterSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeCrefParameterSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreCrefParameterSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterCrefParameterSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneCrefParameterSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreCrefParameterSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "RefKindKeyword")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneCrefParameterSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeCrefParameterSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreCrefParameterSelector(source);
    		PruneAfterCrefParameterSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneXmlElementStartTagSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreXmlElementStartTagSelector(XElement)"/> is not executed and <see cref="PruneXmlElementStartTagSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeXmlElementStartTagSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreXmlElementStartTagSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterXmlElementStartTagSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneXmlElementStartTagSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreXmlElementStartTagSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "LessThanToken")
    			return false;
    		if(source.Name.LocalName == "GreaterThanToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneXmlElementStartTagSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeXmlElementStartTagSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreXmlElementStartTagSelector(source);
    		PruneAfterXmlElementStartTagSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneXmlElementEndTagSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreXmlElementEndTagSelector(XElement)"/> is not executed and <see cref="PruneXmlElementEndTagSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeXmlElementEndTagSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreXmlElementEndTagSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterXmlElementEndTagSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneXmlElementEndTagSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreXmlElementEndTagSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "LessThanSlashToken")
    			return false;
    		if(source.Name.LocalName == "GreaterThanToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneXmlElementEndTagSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeXmlElementEndTagSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreXmlElementEndTagSelector(source);
    		PruneAfterXmlElementEndTagSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneXmlNameSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreXmlNameSelector(XElement)"/> is not executed and <see cref="PruneXmlNameSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeXmlNameSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreXmlNameSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterXmlNameSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneXmlNameSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreXmlNameSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneXmlNameSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeXmlNameSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreXmlNameSelector(source);
    		PruneAfterXmlNameSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneXmlPrefixSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreXmlPrefixSelector(XElement)"/> is not executed and <see cref="PruneXmlPrefixSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeXmlPrefixSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreXmlPrefixSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterXmlPrefixSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneXmlPrefixSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreXmlPrefixSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "ColonToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneXmlPrefixSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeXmlPrefixSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreXmlPrefixSelector(source);
    		PruneAfterXmlPrefixSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneTypeArgumentListSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreTypeArgumentListSelector(XElement)"/> is not executed and <see cref="PruneTypeArgumentListSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeTypeArgumentListSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreTypeArgumentListSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterTypeArgumentListSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneTypeArgumentListSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreTypeArgumentListSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "LessThanToken")
    			return false;
    		if(source.Name.LocalName == "GreaterThanToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneTypeArgumentListSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeTypeArgumentListSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreTypeArgumentListSelector(source);
    		PruneAfterTypeArgumentListSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneArrayRankSpecifierSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreArrayRankSpecifierSelector(XElement)"/> is not executed and <see cref="PruneArrayRankSpecifierSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeArrayRankSpecifierSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreArrayRankSpecifierSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterArrayRankSpecifierSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneArrayRankSpecifierSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreArrayRankSpecifierSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "OpenBracketToken")
    			return false;
    		if(source.Name.LocalName == "CloseBracketToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneArrayRankSpecifierSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeArrayRankSpecifierSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreArrayRankSpecifierSelector(source);
    		PruneAfterArrayRankSpecifierSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneTupleElementSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreTupleElementSelector(XElement)"/> is not executed and <see cref="PruneTupleElementSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeTupleElementSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreTupleElementSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterTupleElementSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneTupleElementSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreTupleElementSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneTupleElementSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeTupleElementSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreTupleElementSelector(source);
    		PruneAfterTupleElementSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneArgumentSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreArgumentSelector(XElement)"/> is not executed and <see cref="PruneArgumentSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeArgumentSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreArgumentSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterArgumentSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneArgumentSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreArgumentSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "RefKindKeyword")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneArgumentSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeArgumentSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreArgumentSelector(source);
    		PruneAfterArgumentSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneNameColonSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreNameColonSelector(XElement)"/> is not executed and <see cref="PruneNameColonSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeNameColonSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreNameColonSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterNameColonSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneNameColonSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreNameColonSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "ColonToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneNameColonSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeNameColonSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreNameColonSelector(source);
    		PruneAfterNameColonSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneAnonymousObjectMemberDeclaratorSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreAnonymousObjectMemberDeclaratorSelector(XElement)"/> is not executed and <see cref="PruneAnonymousObjectMemberDeclaratorSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeAnonymousObjectMemberDeclaratorSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreAnonymousObjectMemberDeclaratorSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterAnonymousObjectMemberDeclaratorSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneAnonymousObjectMemberDeclaratorSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreAnonymousObjectMemberDeclaratorSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneAnonymousObjectMemberDeclaratorSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeAnonymousObjectMemberDeclaratorSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreAnonymousObjectMemberDeclaratorSelector(source);
    		PruneAfterAnonymousObjectMemberDeclaratorSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneQueryBodySelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreQueryBodySelector(XElement)"/> is not executed and <see cref="PruneQueryBodySelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeQueryBodySelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreQueryBodySelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterQueryBodySelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneQueryBodySelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreQueryBodySelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneQueryBodySelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeQueryBodySelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreQueryBodySelector(source);
    		PruneAfterQueryBodySelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneJoinIntoClauseSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreJoinIntoClauseSelector(XElement)"/> is not executed and <see cref="PruneJoinIntoClauseSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeJoinIntoClauseSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreJoinIntoClauseSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterJoinIntoClauseSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneJoinIntoClauseSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreJoinIntoClauseSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "IntoKeyword")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneJoinIntoClauseSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeJoinIntoClauseSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreJoinIntoClauseSelector(source);
    		PruneAfterJoinIntoClauseSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneOrderingSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreOrderingSelector(XElement)"/> is not executed and <see cref="PruneOrderingSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeOrderingSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreOrderingSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterOrderingSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneOrderingSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreOrderingSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "AscendingOrDescendingKeyword")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneOrderingSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeOrderingSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreOrderingSelector(source);
    		PruneAfterOrderingSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneQueryContinuationSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreQueryContinuationSelector(XElement)"/> is not executed and <see cref="PruneQueryContinuationSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeQueryContinuationSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreQueryContinuationSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterQueryContinuationSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneQueryContinuationSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreQueryContinuationSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "IntoKeyword")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneQueryContinuationSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeQueryContinuationSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreQueryContinuationSelector(source);
    		PruneAfterQueryContinuationSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneWhenClauseSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreWhenClauseSelector(XElement)"/> is not executed and <see cref="PruneWhenClauseSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeWhenClauseSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreWhenClauseSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterWhenClauseSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneWhenClauseSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreWhenClauseSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "WhenKeyword")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneWhenClauseSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeWhenClauseSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreWhenClauseSelector(source);
    		PruneAfterWhenClauseSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneInterpolationAlignmentClauseSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreInterpolationAlignmentClauseSelector(XElement)"/> is not executed and <see cref="PruneInterpolationAlignmentClauseSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeInterpolationAlignmentClauseSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreInterpolationAlignmentClauseSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterInterpolationAlignmentClauseSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneInterpolationAlignmentClauseSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreInterpolationAlignmentClauseSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "CommaToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneInterpolationAlignmentClauseSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeInterpolationAlignmentClauseSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreInterpolationAlignmentClauseSelector(source);
    		PruneAfterInterpolationAlignmentClauseSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneInterpolationFormatClauseSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreInterpolationFormatClauseSelector(XElement)"/> is not executed and <see cref="PruneInterpolationFormatClauseSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeInterpolationFormatClauseSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreInterpolationFormatClauseSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterInterpolationFormatClauseSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneInterpolationFormatClauseSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreInterpolationFormatClauseSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "ColonToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneInterpolationFormatClauseSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeInterpolationFormatClauseSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreInterpolationFormatClauseSelector(source);
    		PruneAfterInterpolationFormatClauseSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneVariableDeclarationSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreVariableDeclarationSelector(XElement)"/> is not executed and <see cref="PruneVariableDeclarationSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeVariableDeclarationSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreVariableDeclarationSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterVariableDeclarationSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneVariableDeclarationSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreVariableDeclarationSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneVariableDeclarationSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeVariableDeclarationSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreVariableDeclarationSelector(source);
    		PruneAfterVariableDeclarationSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneVariableDeclaratorSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreVariableDeclaratorSelector(XElement)"/> is not executed and <see cref="PruneVariableDeclaratorSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeVariableDeclaratorSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreVariableDeclaratorSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterVariableDeclaratorSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneVariableDeclaratorSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreVariableDeclaratorSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneVariableDeclaratorSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeVariableDeclaratorSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreVariableDeclaratorSelector(source);
    		PruneAfterVariableDeclaratorSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneEqualsValueClauseSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreEqualsValueClauseSelector(XElement)"/> is not executed and <see cref="PruneEqualsValueClauseSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeEqualsValueClauseSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreEqualsValueClauseSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterEqualsValueClauseSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneEqualsValueClauseSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreEqualsValueClauseSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "EqualsToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneEqualsValueClauseSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeEqualsValueClauseSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreEqualsValueClauseSelector(source);
    		PruneAfterEqualsValueClauseSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneElseClauseSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreElseClauseSelector(XElement)"/> is not executed and <see cref="PruneElseClauseSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeElseClauseSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreElseClauseSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterElseClauseSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneElseClauseSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreElseClauseSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "ElseKeyword")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneElseClauseSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeElseClauseSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreElseClauseSelector(source);
    		PruneAfterElseClauseSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneSwitchSectionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreSwitchSectionSelector(XElement)"/> is not executed and <see cref="PruneSwitchSectionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeSwitchSectionSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreSwitchSectionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterSwitchSectionSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneSwitchSectionSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreSwitchSectionSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneSwitchSectionSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeSwitchSectionSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreSwitchSectionSelector(source);
    		PruneAfterSwitchSectionSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneCatchClauseSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreCatchClauseSelector(XElement)"/> is not executed and <see cref="PruneCatchClauseSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeCatchClauseSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreCatchClauseSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterCatchClauseSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneCatchClauseSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreCatchClauseSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "CatchKeyword")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneCatchClauseSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeCatchClauseSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreCatchClauseSelector(source);
    		PruneAfterCatchClauseSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneCatchDeclarationSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreCatchDeclarationSelector(XElement)"/> is not executed and <see cref="PruneCatchDeclarationSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeCatchDeclarationSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreCatchDeclarationSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterCatchDeclarationSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneCatchDeclarationSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreCatchDeclarationSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "OpenParenToken")
    			return false;
    		if(source.Name.LocalName == "CloseParenToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneCatchDeclarationSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeCatchDeclarationSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreCatchDeclarationSelector(source);
    		PruneAfterCatchDeclarationSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneCatchFilterClauseSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreCatchFilterClauseSelector(XElement)"/> is not executed and <see cref="PruneCatchFilterClauseSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeCatchFilterClauseSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreCatchFilterClauseSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterCatchFilterClauseSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneCatchFilterClauseSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreCatchFilterClauseSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "WhenKeyword")
    			return false;
    		if(source.Name.LocalName == "OpenParenToken")
    			return false;
    		if(source.Name.LocalName == "CloseParenToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneCatchFilterClauseSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeCatchFilterClauseSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreCatchFilterClauseSelector(source);
    		PruneAfterCatchFilterClauseSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneFinallyClauseSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreFinallyClauseSelector(XElement)"/> is not executed and <see cref="PruneFinallyClauseSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeFinallyClauseSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreFinallyClauseSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterFinallyClauseSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneFinallyClauseSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreFinallyClauseSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "FinallyKeyword")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneFinallyClauseSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeFinallyClauseSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreFinallyClauseSelector(source);
    		PruneAfterFinallyClauseSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneCompilationUnitSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreCompilationUnitSelector(XElement)"/> is not executed and <see cref="PruneCompilationUnitSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeCompilationUnitSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreCompilationUnitSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterCompilationUnitSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneCompilationUnitSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreCompilationUnitSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "EndOfFileToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneCompilationUnitSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeCompilationUnitSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreCompilationUnitSelector(source);
    		PruneAfterCompilationUnitSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneExternAliasDirectiveSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreExternAliasDirectiveSelector(XElement)"/> is not executed and <see cref="PruneExternAliasDirectiveSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeExternAliasDirectiveSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreExternAliasDirectiveSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterExternAliasDirectiveSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneExternAliasDirectiveSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreExternAliasDirectiveSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "ExternKeyword")
    			return false;
    		if(source.Name.LocalName == "AliasKeyword")
    			return false;
    		if(source.Name.LocalName == "SemicolonToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneExternAliasDirectiveSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeExternAliasDirectiveSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreExternAliasDirectiveSelector(source);
    		PruneAfterExternAliasDirectiveSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneUsingDirectiveSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreUsingDirectiveSelector(XElement)"/> is not executed and <see cref="PruneUsingDirectiveSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeUsingDirectiveSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreUsingDirectiveSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterUsingDirectiveSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneUsingDirectiveSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreUsingDirectiveSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "UsingKeyword")
    			return false;
    		if(source.Name.LocalName == "StaticKeyword")
    			return false;
    		if(source.Name.LocalName == "SemicolonToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneUsingDirectiveSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeUsingDirectiveSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreUsingDirectiveSelector(source);
    		PruneAfterUsingDirectiveSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneAttributeListSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreAttributeListSelector(XElement)"/> is not executed and <see cref="PruneAttributeListSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeAttributeListSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreAttributeListSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterAttributeListSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneAttributeListSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreAttributeListSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "OpenBracketToken")
    			return false;
    		if(source.Name.LocalName == "CloseBracketToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneAttributeListSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeAttributeListSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreAttributeListSelector(source);
    		PruneAfterAttributeListSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneAttributeTargetSpecifierSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreAttributeTargetSpecifierSelector(XElement)"/> is not executed and <see cref="PruneAttributeTargetSpecifierSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeAttributeTargetSpecifierSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreAttributeTargetSpecifierSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterAttributeTargetSpecifierSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneAttributeTargetSpecifierSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreAttributeTargetSpecifierSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "ColonToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneAttributeTargetSpecifierSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeAttributeTargetSpecifierSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreAttributeTargetSpecifierSelector(source);
    		PruneAfterAttributeTargetSpecifierSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneAttributeSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreAttributeSelector(XElement)"/> is not executed and <see cref="PruneAttributeSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeAttributeSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreAttributeSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterAttributeSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneAttributeSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreAttributeSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneAttributeSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeAttributeSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreAttributeSelector(source);
    		PruneAfterAttributeSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneAttributeArgumentListSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreAttributeArgumentListSelector(XElement)"/> is not executed and <see cref="PruneAttributeArgumentListSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeAttributeArgumentListSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreAttributeArgumentListSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterAttributeArgumentListSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneAttributeArgumentListSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreAttributeArgumentListSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "OpenParenToken")
    			return false;
    		if(source.Name.LocalName == "CloseParenToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneAttributeArgumentListSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeAttributeArgumentListSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreAttributeArgumentListSelector(source);
    		PruneAfterAttributeArgumentListSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneDelegateDeclarationSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreDelegateDeclarationSelector(XElement)"/> is not executed and <see cref="PruneDelegateDeclarationSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeDelegateDeclarationSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreDelegateDeclarationSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterDelegateDeclarationSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneDelegateDeclarationSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreDelegateDeclarationSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "DelegateKeyword")
    			return false;
    		if(source.Name.LocalName == "SemicolonToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneDelegateDeclarationSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeDelegateDeclarationSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreDelegateDeclarationSelector(source);
    		PruneAfterDelegateDeclarationSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneEnumMemberDeclarationSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreEnumMemberDeclarationSelector(XElement)"/> is not executed and <see cref="PruneEnumMemberDeclarationSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeEnumMemberDeclarationSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreEnumMemberDeclarationSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterEnumMemberDeclarationSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneEnumMemberDeclarationSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreEnumMemberDeclarationSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneEnumMemberDeclarationSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeEnumMemberDeclarationSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreEnumMemberDeclarationSelector(source);
    		PruneAfterEnumMemberDeclarationSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneIncompleteMemberSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreIncompleteMemberSelector(XElement)"/> is not executed and <see cref="PruneIncompleteMemberSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeIncompleteMemberSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreIncompleteMemberSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterIncompleteMemberSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneIncompleteMemberSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreIncompleteMemberSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneIncompleteMemberSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeIncompleteMemberSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreIncompleteMemberSelector(source);
    		PruneAfterIncompleteMemberSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneGlobalStatementSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreGlobalStatementSelector(XElement)"/> is not executed and <see cref="PruneGlobalStatementSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeGlobalStatementSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreGlobalStatementSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterGlobalStatementSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneGlobalStatementSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreGlobalStatementSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneGlobalStatementSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeGlobalStatementSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreGlobalStatementSelector(source);
    		PruneAfterGlobalStatementSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneNamespaceDeclarationSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreNamespaceDeclarationSelector(XElement)"/> is not executed and <see cref="PruneNamespaceDeclarationSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeNamespaceDeclarationSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreNamespaceDeclarationSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterNamespaceDeclarationSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneNamespaceDeclarationSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreNamespaceDeclarationSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "NamespaceKeyword")
    			return false;
    		if(source.Name.LocalName == "OpenBraceToken")
    			return false;
    		if(source.Name.LocalName == "CloseBraceToken")
    			return false;
    		if(source.Name.LocalName == "SemicolonToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneNamespaceDeclarationSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeNamespaceDeclarationSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreNamespaceDeclarationSelector(source);
    		PruneAfterNamespaceDeclarationSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneEnumDeclarationSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreEnumDeclarationSelector(XElement)"/> is not executed and <see cref="PruneEnumDeclarationSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeEnumDeclarationSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreEnumDeclarationSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterEnumDeclarationSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneEnumDeclarationSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreEnumDeclarationSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "EnumKeyword")
    			return false;
    		if(source.Name.LocalName == "OpenBraceToken")
    			return false;
    		if(source.Name.LocalName == "CloseBraceToken")
    			return false;
    		if(source.Name.LocalName == "SemicolonToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneEnumDeclarationSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeEnumDeclarationSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreEnumDeclarationSelector(source);
    		PruneAfterEnumDeclarationSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneClassDeclarationSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreClassDeclarationSelector(XElement)"/> is not executed and <see cref="PruneClassDeclarationSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeClassDeclarationSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreClassDeclarationSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterClassDeclarationSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneClassDeclarationSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreClassDeclarationSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "Keyword")
    			return false;
    		if(source.Name.LocalName == "OpenBraceToken")
    			return false;
    		if(source.Name.LocalName == "CloseBraceToken")
    			return false;
    		if(source.Name.LocalName == "SemicolonToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneClassDeclarationSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeClassDeclarationSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreClassDeclarationSelector(source);
    		PruneAfterClassDeclarationSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneStructDeclarationSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreStructDeclarationSelector(XElement)"/> is not executed and <see cref="PruneStructDeclarationSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeStructDeclarationSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreStructDeclarationSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterStructDeclarationSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneStructDeclarationSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreStructDeclarationSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "Keyword")
    			return false;
    		if(source.Name.LocalName == "OpenBraceToken")
    			return false;
    		if(source.Name.LocalName == "CloseBraceToken")
    			return false;
    		if(source.Name.LocalName == "SemicolonToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneStructDeclarationSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeStructDeclarationSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreStructDeclarationSelector(source);
    		PruneAfterStructDeclarationSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneInterfaceDeclarationSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreInterfaceDeclarationSelector(XElement)"/> is not executed and <see cref="PruneInterfaceDeclarationSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeInterfaceDeclarationSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreInterfaceDeclarationSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterInterfaceDeclarationSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneInterfaceDeclarationSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreInterfaceDeclarationSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "Keyword")
    			return false;
    		if(source.Name.LocalName == "OpenBraceToken")
    			return false;
    		if(source.Name.LocalName == "CloseBraceToken")
    			return false;
    		if(source.Name.LocalName == "SemicolonToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneInterfaceDeclarationSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeInterfaceDeclarationSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreInterfaceDeclarationSelector(source);
    		PruneAfterInterfaceDeclarationSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneFieldDeclarationSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreFieldDeclarationSelector(XElement)"/> is not executed and <see cref="PruneFieldDeclarationSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeFieldDeclarationSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreFieldDeclarationSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterFieldDeclarationSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneFieldDeclarationSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreFieldDeclarationSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "SemicolonToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneFieldDeclarationSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeFieldDeclarationSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreFieldDeclarationSelector(source);
    		PruneAfterFieldDeclarationSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneEventFieldDeclarationSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreEventFieldDeclarationSelector(XElement)"/> is not executed and <see cref="PruneEventFieldDeclarationSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeEventFieldDeclarationSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreEventFieldDeclarationSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterEventFieldDeclarationSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneEventFieldDeclarationSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreEventFieldDeclarationSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "EventKeyword")
    			return false;
    		if(source.Name.LocalName == "SemicolonToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneEventFieldDeclarationSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeEventFieldDeclarationSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreEventFieldDeclarationSelector(source);
    		PruneAfterEventFieldDeclarationSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneMethodDeclarationSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreMethodDeclarationSelector(XElement)"/> is not executed and <see cref="PruneMethodDeclarationSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeMethodDeclarationSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreMethodDeclarationSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterMethodDeclarationSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneMethodDeclarationSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreMethodDeclarationSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "SemicolonToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneMethodDeclarationSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeMethodDeclarationSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreMethodDeclarationSelector(source);
    		PruneAfterMethodDeclarationSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneOperatorDeclarationSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreOperatorDeclarationSelector(XElement)"/> is not executed and <see cref="PruneOperatorDeclarationSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeOperatorDeclarationSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreOperatorDeclarationSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterOperatorDeclarationSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneOperatorDeclarationSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreOperatorDeclarationSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "OperatorKeyword")
    			return false;
    		if(source.Name.LocalName == "SemicolonToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneOperatorDeclarationSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeOperatorDeclarationSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreOperatorDeclarationSelector(source);
    		PruneAfterOperatorDeclarationSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneConversionOperatorDeclarationSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreConversionOperatorDeclarationSelector(XElement)"/> is not executed and <see cref="PruneConversionOperatorDeclarationSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeConversionOperatorDeclarationSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreConversionOperatorDeclarationSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterConversionOperatorDeclarationSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneConversionOperatorDeclarationSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreConversionOperatorDeclarationSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "ImplicitOrExplicitKeyword")
    			return false;
    		if(source.Name.LocalName == "OperatorKeyword")
    			return false;
    		if(source.Name.LocalName == "SemicolonToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneConversionOperatorDeclarationSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeConversionOperatorDeclarationSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreConversionOperatorDeclarationSelector(source);
    		PruneAfterConversionOperatorDeclarationSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneConstructorDeclarationSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreConstructorDeclarationSelector(XElement)"/> is not executed and <see cref="PruneConstructorDeclarationSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeConstructorDeclarationSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreConstructorDeclarationSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterConstructorDeclarationSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneConstructorDeclarationSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreConstructorDeclarationSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "SemicolonToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneConstructorDeclarationSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeConstructorDeclarationSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreConstructorDeclarationSelector(source);
    		PruneAfterConstructorDeclarationSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneDestructorDeclarationSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreDestructorDeclarationSelector(XElement)"/> is not executed and <see cref="PruneDestructorDeclarationSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeDestructorDeclarationSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreDestructorDeclarationSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterDestructorDeclarationSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneDestructorDeclarationSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreDestructorDeclarationSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "TildeToken")
    			return false;
    		if(source.Name.LocalName == "SemicolonToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneDestructorDeclarationSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeDestructorDeclarationSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreDestructorDeclarationSelector(source);
    		PruneAfterDestructorDeclarationSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PrunePropertyDeclarationSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCorePropertyDeclarationSelector(XElement)"/> is not executed and <see cref="PrunePropertyDeclarationSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforePropertyDeclarationSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCorePropertyDeclarationSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterPropertyDeclarationSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PrunePropertyDeclarationSelector(XElement)"/>.</remarks>
        public virtual bool PruneCorePropertyDeclarationSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "SemicolonToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PrunePropertyDeclarationSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforePropertyDeclarationSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCorePropertyDeclarationSelector(source);
    		PruneAfterPropertyDeclarationSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneEventDeclarationSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreEventDeclarationSelector(XElement)"/> is not executed and <see cref="PruneEventDeclarationSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeEventDeclarationSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreEventDeclarationSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterEventDeclarationSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneEventDeclarationSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreEventDeclarationSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "EventKeyword")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneEventDeclarationSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeEventDeclarationSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreEventDeclarationSelector(source);
    		PruneAfterEventDeclarationSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneIndexerDeclarationSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreIndexerDeclarationSelector(XElement)"/> is not executed and <see cref="PruneIndexerDeclarationSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeIndexerDeclarationSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreIndexerDeclarationSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterIndexerDeclarationSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneIndexerDeclarationSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreIndexerDeclarationSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "ThisKeyword")
    			return false;
    		if(source.Name.LocalName == "SemicolonToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneIndexerDeclarationSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeIndexerDeclarationSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreIndexerDeclarationSelector(source);
    		PruneAfterIndexerDeclarationSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneSimpleBaseTypeSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreSimpleBaseTypeSelector(XElement)"/> is not executed and <see cref="PruneSimpleBaseTypeSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeSimpleBaseTypeSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreSimpleBaseTypeSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterSimpleBaseTypeSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneSimpleBaseTypeSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreSimpleBaseTypeSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneSimpleBaseTypeSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeSimpleBaseTypeSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreSimpleBaseTypeSelector(source);
    		PruneAfterSimpleBaseTypeSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneConstructorConstraintSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreConstructorConstraintSelector(XElement)"/> is not executed and <see cref="PruneConstructorConstraintSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeConstructorConstraintSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreConstructorConstraintSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterConstructorConstraintSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneConstructorConstraintSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreConstructorConstraintSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "NewKeyword")
    			return false;
    		if(source.Name.LocalName == "OpenParenToken")
    			return false;
    		if(source.Name.LocalName == "CloseParenToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneConstructorConstraintSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeConstructorConstraintSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreConstructorConstraintSelector(source);
    		PruneAfterConstructorConstraintSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneClassOrStructConstraintSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreClassOrStructConstraintSelector(XElement)"/> is not executed and <see cref="PruneClassOrStructConstraintSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeClassOrStructConstraintSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreClassOrStructConstraintSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterClassOrStructConstraintSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneClassOrStructConstraintSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreClassOrStructConstraintSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "ClassOrStructKeyword")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneClassOrStructConstraintSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeClassOrStructConstraintSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreClassOrStructConstraintSelector(source);
    		PruneAfterClassOrStructConstraintSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneTypeConstraintSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreTypeConstraintSelector(XElement)"/> is not executed and <see cref="PruneTypeConstraintSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeTypeConstraintSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreTypeConstraintSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterTypeConstraintSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneTypeConstraintSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreTypeConstraintSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneTypeConstraintSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeTypeConstraintSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreTypeConstraintSelector(source);
    		PruneAfterTypeConstraintSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneParameterListSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreParameterListSelector(XElement)"/> is not executed and <see cref="PruneParameterListSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeParameterListSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreParameterListSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterParameterListSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneParameterListSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreParameterListSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "OpenParenToken")
    			return false;
    		if(source.Name.LocalName == "CloseParenToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneParameterListSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeParameterListSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreParameterListSelector(source);
    		PruneAfterParameterListSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneBracketedParameterListSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreBracketedParameterListSelector(XElement)"/> is not executed and <see cref="PruneBracketedParameterListSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeBracketedParameterListSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreBracketedParameterListSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterBracketedParameterListSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneBracketedParameterListSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreBracketedParameterListSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "OpenBracketToken")
    			return false;
    		if(source.Name.LocalName == "CloseBracketToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneBracketedParameterListSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeBracketedParameterListSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreBracketedParameterListSelector(source);
    		PruneAfterBracketedParameterListSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneSkippedTokensTriviaSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreSkippedTokensTriviaSelector(XElement)"/> is not executed and <see cref="PruneSkippedTokensTriviaSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeSkippedTokensTriviaSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreSkippedTokensTriviaSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterSkippedTokensTriviaSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneSkippedTokensTriviaSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreSkippedTokensTriviaSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneSkippedTokensTriviaSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeSkippedTokensTriviaSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreSkippedTokensTriviaSelector(source);
    		PruneAfterSkippedTokensTriviaSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneDocumentationCommentTriviaSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreDocumentationCommentTriviaSelector(XElement)"/> is not executed and <see cref="PruneDocumentationCommentTriviaSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeDocumentationCommentTriviaSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreDocumentationCommentTriviaSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterDocumentationCommentTriviaSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneDocumentationCommentTriviaSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreDocumentationCommentTriviaSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "EndOfComment")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneDocumentationCommentTriviaSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeDocumentationCommentTriviaSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreDocumentationCommentTriviaSelector(source);
    		PruneAfterDocumentationCommentTriviaSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneEndIfDirectiveTriviaSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreEndIfDirectiveTriviaSelector(XElement)"/> is not executed and <see cref="PruneEndIfDirectiveTriviaSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeEndIfDirectiveTriviaSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreEndIfDirectiveTriviaSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterEndIfDirectiveTriviaSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneEndIfDirectiveTriviaSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreEndIfDirectiveTriviaSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "HashToken")
    			return false;
    		if(source.Name.LocalName == "EndIfKeyword")
    			return false;
    		if(source.Name.LocalName == "EndOfDirectiveToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneEndIfDirectiveTriviaSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeEndIfDirectiveTriviaSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreEndIfDirectiveTriviaSelector(source);
    		PruneAfterEndIfDirectiveTriviaSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneRegionDirectiveTriviaSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreRegionDirectiveTriviaSelector(XElement)"/> is not executed and <see cref="PruneRegionDirectiveTriviaSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeRegionDirectiveTriviaSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreRegionDirectiveTriviaSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterRegionDirectiveTriviaSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneRegionDirectiveTriviaSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreRegionDirectiveTriviaSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "HashToken")
    			return false;
    		if(source.Name.LocalName == "RegionKeyword")
    			return false;
    		if(source.Name.LocalName == "EndOfDirectiveToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneRegionDirectiveTriviaSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeRegionDirectiveTriviaSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreRegionDirectiveTriviaSelector(source);
    		PruneAfterRegionDirectiveTriviaSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneEndRegionDirectiveTriviaSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreEndRegionDirectiveTriviaSelector(XElement)"/> is not executed and <see cref="PruneEndRegionDirectiveTriviaSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeEndRegionDirectiveTriviaSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreEndRegionDirectiveTriviaSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterEndRegionDirectiveTriviaSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneEndRegionDirectiveTriviaSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreEndRegionDirectiveTriviaSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "HashToken")
    			return false;
    		if(source.Name.LocalName == "EndRegionKeyword")
    			return false;
    		if(source.Name.LocalName == "EndOfDirectiveToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneEndRegionDirectiveTriviaSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeEndRegionDirectiveTriviaSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreEndRegionDirectiveTriviaSelector(source);
    		PruneAfterEndRegionDirectiveTriviaSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneErrorDirectiveTriviaSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreErrorDirectiveTriviaSelector(XElement)"/> is not executed and <see cref="PruneErrorDirectiveTriviaSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeErrorDirectiveTriviaSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreErrorDirectiveTriviaSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterErrorDirectiveTriviaSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneErrorDirectiveTriviaSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreErrorDirectiveTriviaSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "HashToken")
    			return false;
    		if(source.Name.LocalName == "ErrorKeyword")
    			return false;
    		if(source.Name.LocalName == "EndOfDirectiveToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneErrorDirectiveTriviaSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeErrorDirectiveTriviaSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreErrorDirectiveTriviaSelector(source);
    		PruneAfterErrorDirectiveTriviaSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneWarningDirectiveTriviaSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreWarningDirectiveTriviaSelector(XElement)"/> is not executed and <see cref="PruneWarningDirectiveTriviaSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeWarningDirectiveTriviaSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreWarningDirectiveTriviaSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterWarningDirectiveTriviaSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneWarningDirectiveTriviaSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreWarningDirectiveTriviaSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "HashToken")
    			return false;
    		if(source.Name.LocalName == "WarningKeyword")
    			return false;
    		if(source.Name.LocalName == "EndOfDirectiveToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneWarningDirectiveTriviaSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeWarningDirectiveTriviaSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreWarningDirectiveTriviaSelector(source);
    		PruneAfterWarningDirectiveTriviaSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneBadDirectiveTriviaSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreBadDirectiveTriviaSelector(XElement)"/> is not executed and <see cref="PruneBadDirectiveTriviaSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeBadDirectiveTriviaSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreBadDirectiveTriviaSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterBadDirectiveTriviaSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneBadDirectiveTriviaSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreBadDirectiveTriviaSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "HashToken")
    			return false;
    		if(source.Name.LocalName == "EndOfDirectiveToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneBadDirectiveTriviaSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeBadDirectiveTriviaSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreBadDirectiveTriviaSelector(source);
    		PruneAfterBadDirectiveTriviaSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneDefineDirectiveTriviaSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreDefineDirectiveTriviaSelector(XElement)"/> is not executed and <see cref="PruneDefineDirectiveTriviaSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeDefineDirectiveTriviaSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreDefineDirectiveTriviaSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterDefineDirectiveTriviaSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneDefineDirectiveTriviaSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreDefineDirectiveTriviaSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "HashToken")
    			return false;
    		if(source.Name.LocalName == "DefineKeyword")
    			return false;
    		if(source.Name.LocalName == "EndOfDirectiveToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneDefineDirectiveTriviaSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeDefineDirectiveTriviaSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreDefineDirectiveTriviaSelector(source);
    		PruneAfterDefineDirectiveTriviaSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneUndefDirectiveTriviaSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreUndefDirectiveTriviaSelector(XElement)"/> is not executed and <see cref="PruneUndefDirectiveTriviaSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeUndefDirectiveTriviaSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreUndefDirectiveTriviaSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterUndefDirectiveTriviaSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneUndefDirectiveTriviaSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreUndefDirectiveTriviaSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "HashToken")
    			return false;
    		if(source.Name.LocalName == "UndefKeyword")
    			return false;
    		if(source.Name.LocalName == "EndOfDirectiveToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneUndefDirectiveTriviaSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeUndefDirectiveTriviaSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreUndefDirectiveTriviaSelector(source);
    		PruneAfterUndefDirectiveTriviaSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneLineDirectiveTriviaSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreLineDirectiveTriviaSelector(XElement)"/> is not executed and <see cref="PruneLineDirectiveTriviaSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeLineDirectiveTriviaSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreLineDirectiveTriviaSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterLineDirectiveTriviaSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneLineDirectiveTriviaSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreLineDirectiveTriviaSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "HashToken")
    			return false;
    		if(source.Name.LocalName == "LineKeyword")
    			return false;
    		if(source.Name.LocalName == "EndOfDirectiveToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneLineDirectiveTriviaSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeLineDirectiveTriviaSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreLineDirectiveTriviaSelector(source);
    		PruneAfterLineDirectiveTriviaSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PrunePragmaWarningDirectiveTriviaSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCorePragmaWarningDirectiveTriviaSelector(XElement)"/> is not executed and <see cref="PrunePragmaWarningDirectiveTriviaSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforePragmaWarningDirectiveTriviaSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCorePragmaWarningDirectiveTriviaSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterPragmaWarningDirectiveTriviaSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PrunePragmaWarningDirectiveTriviaSelector(XElement)"/>.</remarks>
        public virtual bool PruneCorePragmaWarningDirectiveTriviaSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "HashToken")
    			return false;
    		if(source.Name.LocalName == "PragmaKeyword")
    			return false;
    		if(source.Name.LocalName == "WarningKeyword")
    			return false;
    		if(source.Name.LocalName == "EndOfDirectiveToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PrunePragmaWarningDirectiveTriviaSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforePragmaWarningDirectiveTriviaSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCorePragmaWarningDirectiveTriviaSelector(source);
    		PruneAfterPragmaWarningDirectiveTriviaSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PrunePragmaChecksumDirectiveTriviaSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCorePragmaChecksumDirectiveTriviaSelector(XElement)"/> is not executed and <see cref="PrunePragmaChecksumDirectiveTriviaSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforePragmaChecksumDirectiveTriviaSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCorePragmaChecksumDirectiveTriviaSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterPragmaChecksumDirectiveTriviaSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PrunePragmaChecksumDirectiveTriviaSelector(XElement)"/>.</remarks>
        public virtual bool PruneCorePragmaChecksumDirectiveTriviaSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "HashToken")
    			return false;
    		if(source.Name.LocalName == "PragmaKeyword")
    			return false;
    		if(source.Name.LocalName == "ChecksumKeyword")
    			return false;
    		if(source.Name.LocalName == "EndOfDirectiveToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PrunePragmaChecksumDirectiveTriviaSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforePragmaChecksumDirectiveTriviaSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCorePragmaChecksumDirectiveTriviaSelector(source);
    		PruneAfterPragmaChecksumDirectiveTriviaSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneReferenceDirectiveTriviaSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreReferenceDirectiveTriviaSelector(XElement)"/> is not executed and <see cref="PruneReferenceDirectiveTriviaSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeReferenceDirectiveTriviaSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreReferenceDirectiveTriviaSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterReferenceDirectiveTriviaSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneReferenceDirectiveTriviaSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreReferenceDirectiveTriviaSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "HashToken")
    			return false;
    		if(source.Name.LocalName == "ReferenceKeyword")
    			return false;
    		if(source.Name.LocalName == "EndOfDirectiveToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneReferenceDirectiveTriviaSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeReferenceDirectiveTriviaSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreReferenceDirectiveTriviaSelector(source);
    		PruneAfterReferenceDirectiveTriviaSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneLoadDirectiveTriviaSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreLoadDirectiveTriviaSelector(XElement)"/> is not executed and <see cref="PruneLoadDirectiveTriviaSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeLoadDirectiveTriviaSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreLoadDirectiveTriviaSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterLoadDirectiveTriviaSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneLoadDirectiveTriviaSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreLoadDirectiveTriviaSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "HashToken")
    			return false;
    		if(source.Name.LocalName == "LoadKeyword")
    			return false;
    		if(source.Name.LocalName == "EndOfDirectiveToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneLoadDirectiveTriviaSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeLoadDirectiveTriviaSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreLoadDirectiveTriviaSelector(source);
    		PruneAfterLoadDirectiveTriviaSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneShebangDirectiveTriviaSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreShebangDirectiveTriviaSelector(XElement)"/> is not executed and <see cref="PruneShebangDirectiveTriviaSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeShebangDirectiveTriviaSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreShebangDirectiveTriviaSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterShebangDirectiveTriviaSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneShebangDirectiveTriviaSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreShebangDirectiveTriviaSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "HashToken")
    			return false;
    		if(source.Name.LocalName == "ExclamationToken")
    			return false;
    		if(source.Name.LocalName == "EndOfDirectiveToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneShebangDirectiveTriviaSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeShebangDirectiveTriviaSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreShebangDirectiveTriviaSelector(source);
    		PruneAfterShebangDirectiveTriviaSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneElseDirectiveTriviaSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreElseDirectiveTriviaSelector(XElement)"/> is not executed and <see cref="PruneElseDirectiveTriviaSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeElseDirectiveTriviaSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreElseDirectiveTriviaSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterElseDirectiveTriviaSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneElseDirectiveTriviaSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreElseDirectiveTriviaSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "HashToken")
    			return false;
    		if(source.Name.LocalName == "ElseKeyword")
    			return false;
    		if(source.Name.LocalName == "EndOfDirectiveToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneElseDirectiveTriviaSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeElseDirectiveTriviaSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreElseDirectiveTriviaSelector(source);
    		PruneAfterElseDirectiveTriviaSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneIfDirectiveTriviaSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreIfDirectiveTriviaSelector(XElement)"/> is not executed and <see cref="PruneIfDirectiveTriviaSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeIfDirectiveTriviaSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreIfDirectiveTriviaSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterIfDirectiveTriviaSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneIfDirectiveTriviaSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreIfDirectiveTriviaSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "HashToken")
    			return false;
    		if(source.Name.LocalName == "IfKeyword")
    			return false;
    		if(source.Name.LocalName == "EndOfDirectiveToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneIfDirectiveTriviaSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeIfDirectiveTriviaSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreIfDirectiveTriviaSelector(source);
    		PruneAfterIfDirectiveTriviaSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneElifDirectiveTriviaSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreElifDirectiveTriviaSelector(XElement)"/> is not executed and <see cref="PruneElifDirectiveTriviaSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeElifDirectiveTriviaSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreElifDirectiveTriviaSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterElifDirectiveTriviaSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneElifDirectiveTriviaSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreElifDirectiveTriviaSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "HashToken")
    			return false;
    		if(source.Name.LocalName == "ElifKeyword")
    			return false;
    		if(source.Name.LocalName == "EndOfDirectiveToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneElifDirectiveTriviaSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeElifDirectiveTriviaSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreElifDirectiveTriviaSelector(source);
    		PruneAfterElifDirectiveTriviaSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneTypeCrefSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreTypeCrefSelector(XElement)"/> is not executed and <see cref="PruneTypeCrefSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeTypeCrefSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreTypeCrefSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterTypeCrefSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneTypeCrefSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreTypeCrefSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneTypeCrefSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeTypeCrefSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreTypeCrefSelector(source);
    		PruneAfterTypeCrefSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneQualifiedCrefSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreQualifiedCrefSelector(XElement)"/> is not executed and <see cref="PruneQualifiedCrefSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeQualifiedCrefSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreQualifiedCrefSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterQualifiedCrefSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneQualifiedCrefSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreQualifiedCrefSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "DotToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneQualifiedCrefSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeQualifiedCrefSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreQualifiedCrefSelector(source);
    		PruneAfterQualifiedCrefSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneNameMemberCrefSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreNameMemberCrefSelector(XElement)"/> is not executed and <see cref="PruneNameMemberCrefSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeNameMemberCrefSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreNameMemberCrefSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterNameMemberCrefSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneNameMemberCrefSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreNameMemberCrefSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneNameMemberCrefSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeNameMemberCrefSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreNameMemberCrefSelector(source);
    		PruneAfterNameMemberCrefSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneIndexerMemberCrefSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreIndexerMemberCrefSelector(XElement)"/> is not executed and <see cref="PruneIndexerMemberCrefSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeIndexerMemberCrefSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreIndexerMemberCrefSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterIndexerMemberCrefSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneIndexerMemberCrefSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreIndexerMemberCrefSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "ThisKeyword")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneIndexerMemberCrefSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeIndexerMemberCrefSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreIndexerMemberCrefSelector(source);
    		PruneAfterIndexerMemberCrefSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneOperatorMemberCrefSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreOperatorMemberCrefSelector(XElement)"/> is not executed and <see cref="PruneOperatorMemberCrefSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeOperatorMemberCrefSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreOperatorMemberCrefSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterOperatorMemberCrefSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneOperatorMemberCrefSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreOperatorMemberCrefSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "OperatorKeyword")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneOperatorMemberCrefSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeOperatorMemberCrefSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreOperatorMemberCrefSelector(source);
    		PruneAfterOperatorMemberCrefSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneConversionOperatorMemberCrefSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreConversionOperatorMemberCrefSelector(XElement)"/> is not executed and <see cref="PruneConversionOperatorMemberCrefSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeConversionOperatorMemberCrefSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreConversionOperatorMemberCrefSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterConversionOperatorMemberCrefSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneConversionOperatorMemberCrefSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreConversionOperatorMemberCrefSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "ImplicitOrExplicitKeyword")
    			return false;
    		if(source.Name.LocalName == "OperatorKeyword")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneConversionOperatorMemberCrefSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeConversionOperatorMemberCrefSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreConversionOperatorMemberCrefSelector(source);
    		PruneAfterConversionOperatorMemberCrefSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneCrefParameterListSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreCrefParameterListSelector(XElement)"/> is not executed and <see cref="PruneCrefParameterListSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeCrefParameterListSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreCrefParameterListSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterCrefParameterListSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneCrefParameterListSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreCrefParameterListSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "OpenParenToken")
    			return false;
    		if(source.Name.LocalName == "CloseParenToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneCrefParameterListSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeCrefParameterListSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreCrefParameterListSelector(source);
    		PruneAfterCrefParameterListSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneCrefBracketedParameterListSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreCrefBracketedParameterListSelector(XElement)"/> is not executed and <see cref="PruneCrefBracketedParameterListSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeCrefBracketedParameterListSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreCrefBracketedParameterListSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterCrefBracketedParameterListSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneCrefBracketedParameterListSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreCrefBracketedParameterListSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "OpenBracketToken")
    			return false;
    		if(source.Name.LocalName == "CloseBracketToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneCrefBracketedParameterListSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeCrefBracketedParameterListSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreCrefBracketedParameterListSelector(source);
    		PruneAfterCrefBracketedParameterListSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneXmlElementSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreXmlElementSelector(XElement)"/> is not executed and <see cref="PruneXmlElementSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeXmlElementSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreXmlElementSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterXmlElementSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneXmlElementSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreXmlElementSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneXmlElementSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeXmlElementSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreXmlElementSelector(source);
    		PruneAfterXmlElementSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneXmlEmptyElementSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreXmlEmptyElementSelector(XElement)"/> is not executed and <see cref="PruneXmlEmptyElementSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeXmlEmptyElementSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreXmlEmptyElementSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterXmlEmptyElementSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneXmlEmptyElementSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreXmlEmptyElementSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "LessThanToken")
    			return false;
    		if(source.Name.LocalName == "SlashGreaterThanToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneXmlEmptyElementSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeXmlEmptyElementSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreXmlEmptyElementSelector(source);
    		PruneAfterXmlEmptyElementSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneXmlTextSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreXmlTextSelector(XElement)"/> is not executed and <see cref="PruneXmlTextSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeXmlTextSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreXmlTextSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterXmlTextSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneXmlTextSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreXmlTextSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneXmlTextSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeXmlTextSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreXmlTextSelector(source);
    		PruneAfterXmlTextSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneXmlCDataSectionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreXmlCDataSectionSelector(XElement)"/> is not executed and <see cref="PruneXmlCDataSectionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeXmlCDataSectionSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreXmlCDataSectionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterXmlCDataSectionSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneXmlCDataSectionSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreXmlCDataSectionSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "StartCDataToken")
    			return false;
    		if(source.Name.LocalName == "EndCDataToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneXmlCDataSectionSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeXmlCDataSectionSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreXmlCDataSectionSelector(source);
    		PruneAfterXmlCDataSectionSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneXmlProcessingInstructionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreXmlProcessingInstructionSelector(XElement)"/> is not executed and <see cref="PruneXmlProcessingInstructionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeXmlProcessingInstructionSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreXmlProcessingInstructionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterXmlProcessingInstructionSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneXmlProcessingInstructionSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreXmlProcessingInstructionSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "StartProcessingInstructionToken")
    			return false;
    		if(source.Name.LocalName == "EndProcessingInstructionToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneXmlProcessingInstructionSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeXmlProcessingInstructionSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreXmlProcessingInstructionSelector(source);
    		PruneAfterXmlProcessingInstructionSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneXmlCommentSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreXmlCommentSelector(XElement)"/> is not executed and <see cref="PruneXmlCommentSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeXmlCommentSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreXmlCommentSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterXmlCommentSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneXmlCommentSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreXmlCommentSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "LessThanExclamationMinusMinusToken")
    			return false;
    		if(source.Name.LocalName == "MinusMinusGreaterThanToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneXmlCommentSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeXmlCommentSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreXmlCommentSelector(source);
    		PruneAfterXmlCommentSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneXmlTextAttributeSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreXmlTextAttributeSelector(XElement)"/> is not executed and <see cref="PruneXmlTextAttributeSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeXmlTextAttributeSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreXmlTextAttributeSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterXmlTextAttributeSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneXmlTextAttributeSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreXmlTextAttributeSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "EqualsToken")
    			return false;
    		if(source.Name.LocalName == "StartQuoteToken")
    			return false;
    		if(source.Name.LocalName == "EndQuoteToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneXmlTextAttributeSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeXmlTextAttributeSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreXmlTextAttributeSelector(source);
    		PruneAfterXmlTextAttributeSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneXmlCrefAttributeSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreXmlCrefAttributeSelector(XElement)"/> is not executed and <see cref="PruneXmlCrefAttributeSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeXmlCrefAttributeSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreXmlCrefAttributeSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterXmlCrefAttributeSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneXmlCrefAttributeSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreXmlCrefAttributeSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "Name")
    			return false;
    		if(source.Name.LocalName == "EqualsToken")
    			return false;
    		if(source.Name.LocalName == "StartQuoteToken")
    			return false;
    		if(source.Name.LocalName == "EndQuoteToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneXmlCrefAttributeSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeXmlCrefAttributeSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreXmlCrefAttributeSelector(source);
    		PruneAfterXmlCrefAttributeSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneXmlNameAttributeSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreXmlNameAttributeSelector(XElement)"/> is not executed and <see cref="PruneXmlNameAttributeSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeXmlNameAttributeSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreXmlNameAttributeSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterXmlNameAttributeSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneXmlNameAttributeSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreXmlNameAttributeSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "Name")
    			return false;
    		if(source.Name.LocalName == "EqualsToken")
    			return false;
    		if(source.Name.LocalName == "StartQuoteToken")
    			return false;
    		if(source.Name.LocalName == "EndQuoteToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneXmlNameAttributeSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeXmlNameAttributeSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreXmlNameAttributeSelector(source);
    		PruneAfterXmlNameAttributeSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneParenthesizedExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreParenthesizedExpressionSelector(XElement)"/> is not executed and <see cref="PruneParenthesizedExpressionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeParenthesizedExpressionSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreParenthesizedExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterParenthesizedExpressionSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneParenthesizedExpressionSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreParenthesizedExpressionSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "OpenParenToken")
    			return false;
    		if(source.Name.LocalName == "CloseParenToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneParenthesizedExpressionSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeParenthesizedExpressionSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreParenthesizedExpressionSelector(source);
    		PruneAfterParenthesizedExpressionSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneTupleExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreTupleExpressionSelector(XElement)"/> is not executed and <see cref="PruneTupleExpressionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeTupleExpressionSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreTupleExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterTupleExpressionSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneTupleExpressionSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreTupleExpressionSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "OpenParenToken")
    			return false;
    		if(source.Name.LocalName == "CloseParenToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneTupleExpressionSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeTupleExpressionSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreTupleExpressionSelector(source);
    		PruneAfterTupleExpressionSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PrunePrefixUnaryExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCorePrefixUnaryExpressionSelector(XElement)"/> is not executed and <see cref="PrunePrefixUnaryExpressionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforePrefixUnaryExpressionSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCorePrefixUnaryExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterPrefixUnaryExpressionSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PrunePrefixUnaryExpressionSelector(XElement)"/>.</remarks>
        public virtual bool PruneCorePrefixUnaryExpressionSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "OperatorToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PrunePrefixUnaryExpressionSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforePrefixUnaryExpressionSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCorePrefixUnaryExpressionSelector(source);
    		PruneAfterPrefixUnaryExpressionSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneAwaitExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreAwaitExpressionSelector(XElement)"/> is not executed and <see cref="PruneAwaitExpressionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeAwaitExpressionSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreAwaitExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterAwaitExpressionSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneAwaitExpressionSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreAwaitExpressionSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "AwaitKeyword")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneAwaitExpressionSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeAwaitExpressionSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreAwaitExpressionSelector(source);
    		PruneAfterAwaitExpressionSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PrunePostfixUnaryExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCorePostfixUnaryExpressionSelector(XElement)"/> is not executed and <see cref="PrunePostfixUnaryExpressionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforePostfixUnaryExpressionSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCorePostfixUnaryExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterPostfixUnaryExpressionSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PrunePostfixUnaryExpressionSelector(XElement)"/>.</remarks>
        public virtual bool PruneCorePostfixUnaryExpressionSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "OperatorToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PrunePostfixUnaryExpressionSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforePostfixUnaryExpressionSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCorePostfixUnaryExpressionSelector(source);
    		PruneAfterPostfixUnaryExpressionSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneMemberAccessExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreMemberAccessExpressionSelector(XElement)"/> is not executed and <see cref="PruneMemberAccessExpressionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeMemberAccessExpressionSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreMemberAccessExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterMemberAccessExpressionSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneMemberAccessExpressionSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreMemberAccessExpressionSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "OperatorToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneMemberAccessExpressionSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeMemberAccessExpressionSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreMemberAccessExpressionSelector(source);
    		PruneAfterMemberAccessExpressionSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneConditionalAccessExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreConditionalAccessExpressionSelector(XElement)"/> is not executed and <see cref="PruneConditionalAccessExpressionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeConditionalAccessExpressionSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreConditionalAccessExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterConditionalAccessExpressionSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneConditionalAccessExpressionSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreConditionalAccessExpressionSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "OperatorToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneConditionalAccessExpressionSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeConditionalAccessExpressionSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreConditionalAccessExpressionSelector(source);
    		PruneAfterConditionalAccessExpressionSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneMemberBindingExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreMemberBindingExpressionSelector(XElement)"/> is not executed and <see cref="PruneMemberBindingExpressionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeMemberBindingExpressionSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreMemberBindingExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterMemberBindingExpressionSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneMemberBindingExpressionSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreMemberBindingExpressionSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "OperatorToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneMemberBindingExpressionSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeMemberBindingExpressionSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreMemberBindingExpressionSelector(source);
    		PruneAfterMemberBindingExpressionSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneElementBindingExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreElementBindingExpressionSelector(XElement)"/> is not executed and <see cref="PruneElementBindingExpressionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeElementBindingExpressionSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreElementBindingExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterElementBindingExpressionSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneElementBindingExpressionSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreElementBindingExpressionSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneElementBindingExpressionSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeElementBindingExpressionSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreElementBindingExpressionSelector(source);
    		PruneAfterElementBindingExpressionSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneImplicitElementAccessSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreImplicitElementAccessSelector(XElement)"/> is not executed and <see cref="PruneImplicitElementAccessSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeImplicitElementAccessSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreImplicitElementAccessSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterImplicitElementAccessSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneImplicitElementAccessSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreImplicitElementAccessSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneImplicitElementAccessSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeImplicitElementAccessSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreImplicitElementAccessSelector(source);
    		PruneAfterImplicitElementAccessSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneBinaryExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreBinaryExpressionSelector(XElement)"/> is not executed and <see cref="PruneBinaryExpressionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeBinaryExpressionSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreBinaryExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterBinaryExpressionSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneBinaryExpressionSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreBinaryExpressionSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "OperatorToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneBinaryExpressionSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeBinaryExpressionSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreBinaryExpressionSelector(source);
    		PruneAfterBinaryExpressionSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneAssignmentExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreAssignmentExpressionSelector(XElement)"/> is not executed and <see cref="PruneAssignmentExpressionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeAssignmentExpressionSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreAssignmentExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterAssignmentExpressionSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneAssignmentExpressionSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreAssignmentExpressionSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "OperatorToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneAssignmentExpressionSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeAssignmentExpressionSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreAssignmentExpressionSelector(source);
    		PruneAfterAssignmentExpressionSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneConditionalExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreConditionalExpressionSelector(XElement)"/> is not executed and <see cref="PruneConditionalExpressionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeConditionalExpressionSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreConditionalExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterConditionalExpressionSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneConditionalExpressionSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreConditionalExpressionSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "QuestionToken")
    			return false;
    		if(source.Name.LocalName == "ColonToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneConditionalExpressionSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeConditionalExpressionSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreConditionalExpressionSelector(source);
    		PruneAfterConditionalExpressionSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneLiteralExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreLiteralExpressionSelector(XElement)"/> is not executed and <see cref="PruneLiteralExpressionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeLiteralExpressionSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreLiteralExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterLiteralExpressionSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneLiteralExpressionSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreLiteralExpressionSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneLiteralExpressionSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeLiteralExpressionSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreLiteralExpressionSelector(source);
    		PruneAfterLiteralExpressionSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneMakeRefExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreMakeRefExpressionSelector(XElement)"/> is not executed and <see cref="PruneMakeRefExpressionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeMakeRefExpressionSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreMakeRefExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterMakeRefExpressionSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneMakeRefExpressionSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreMakeRefExpressionSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "Keyword")
    			return false;
    		if(source.Name.LocalName == "OpenParenToken")
    			return false;
    		if(source.Name.LocalName == "CloseParenToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneMakeRefExpressionSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeMakeRefExpressionSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreMakeRefExpressionSelector(source);
    		PruneAfterMakeRefExpressionSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneRefTypeExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreRefTypeExpressionSelector(XElement)"/> is not executed and <see cref="PruneRefTypeExpressionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeRefTypeExpressionSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreRefTypeExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterRefTypeExpressionSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneRefTypeExpressionSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreRefTypeExpressionSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "Keyword")
    			return false;
    		if(source.Name.LocalName == "OpenParenToken")
    			return false;
    		if(source.Name.LocalName == "CloseParenToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneRefTypeExpressionSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeRefTypeExpressionSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreRefTypeExpressionSelector(source);
    		PruneAfterRefTypeExpressionSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneRefValueExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreRefValueExpressionSelector(XElement)"/> is not executed and <see cref="PruneRefValueExpressionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeRefValueExpressionSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreRefValueExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterRefValueExpressionSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneRefValueExpressionSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreRefValueExpressionSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "Keyword")
    			return false;
    		if(source.Name.LocalName == "OpenParenToken")
    			return false;
    		if(source.Name.LocalName == "Comma")
    			return false;
    		if(source.Name.LocalName == "CloseParenToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneRefValueExpressionSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeRefValueExpressionSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreRefValueExpressionSelector(source);
    		PruneAfterRefValueExpressionSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneCheckedExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreCheckedExpressionSelector(XElement)"/> is not executed and <see cref="PruneCheckedExpressionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeCheckedExpressionSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreCheckedExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterCheckedExpressionSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneCheckedExpressionSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreCheckedExpressionSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "Keyword")
    			return false;
    		if(source.Name.LocalName == "OpenParenToken")
    			return false;
    		if(source.Name.LocalName == "CloseParenToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneCheckedExpressionSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeCheckedExpressionSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreCheckedExpressionSelector(source);
    		PruneAfterCheckedExpressionSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneDefaultExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreDefaultExpressionSelector(XElement)"/> is not executed and <see cref="PruneDefaultExpressionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeDefaultExpressionSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreDefaultExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterDefaultExpressionSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneDefaultExpressionSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreDefaultExpressionSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "Keyword")
    			return false;
    		if(source.Name.LocalName == "OpenParenToken")
    			return false;
    		if(source.Name.LocalName == "CloseParenToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneDefaultExpressionSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeDefaultExpressionSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreDefaultExpressionSelector(source);
    		PruneAfterDefaultExpressionSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneTypeOfExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreTypeOfExpressionSelector(XElement)"/> is not executed and <see cref="PruneTypeOfExpressionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeTypeOfExpressionSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreTypeOfExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterTypeOfExpressionSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneTypeOfExpressionSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreTypeOfExpressionSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "Keyword")
    			return false;
    		if(source.Name.LocalName == "OpenParenToken")
    			return false;
    		if(source.Name.LocalName == "CloseParenToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneTypeOfExpressionSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeTypeOfExpressionSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreTypeOfExpressionSelector(source);
    		PruneAfterTypeOfExpressionSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneSizeOfExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreSizeOfExpressionSelector(XElement)"/> is not executed and <see cref="PruneSizeOfExpressionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeSizeOfExpressionSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreSizeOfExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterSizeOfExpressionSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneSizeOfExpressionSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreSizeOfExpressionSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "Keyword")
    			return false;
    		if(source.Name.LocalName == "OpenParenToken")
    			return false;
    		if(source.Name.LocalName == "CloseParenToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneSizeOfExpressionSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeSizeOfExpressionSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreSizeOfExpressionSelector(source);
    		PruneAfterSizeOfExpressionSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneInvocationExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreInvocationExpressionSelector(XElement)"/> is not executed and <see cref="PruneInvocationExpressionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeInvocationExpressionSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreInvocationExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterInvocationExpressionSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneInvocationExpressionSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreInvocationExpressionSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneInvocationExpressionSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeInvocationExpressionSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreInvocationExpressionSelector(source);
    		PruneAfterInvocationExpressionSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneElementAccessExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreElementAccessExpressionSelector(XElement)"/> is not executed and <see cref="PruneElementAccessExpressionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeElementAccessExpressionSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreElementAccessExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterElementAccessExpressionSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneElementAccessExpressionSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreElementAccessExpressionSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneElementAccessExpressionSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeElementAccessExpressionSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreElementAccessExpressionSelector(source);
    		PruneAfterElementAccessExpressionSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneDeclarationExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreDeclarationExpressionSelector(XElement)"/> is not executed and <see cref="PruneDeclarationExpressionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeDeclarationExpressionSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreDeclarationExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterDeclarationExpressionSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneDeclarationExpressionSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreDeclarationExpressionSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneDeclarationExpressionSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeDeclarationExpressionSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreDeclarationExpressionSelector(source);
    		PruneAfterDeclarationExpressionSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneCastExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreCastExpressionSelector(XElement)"/> is not executed and <see cref="PruneCastExpressionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeCastExpressionSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreCastExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterCastExpressionSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneCastExpressionSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreCastExpressionSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "OpenParenToken")
    			return false;
    		if(source.Name.LocalName == "CloseParenToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneCastExpressionSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeCastExpressionSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreCastExpressionSelector(source);
    		PruneAfterCastExpressionSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneRefExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreRefExpressionSelector(XElement)"/> is not executed and <see cref="PruneRefExpressionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeRefExpressionSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreRefExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterRefExpressionSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneRefExpressionSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreRefExpressionSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "RefKeyword")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneRefExpressionSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeRefExpressionSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreRefExpressionSelector(source);
    		PruneAfterRefExpressionSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneInitializerExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreInitializerExpressionSelector(XElement)"/> is not executed and <see cref="PruneInitializerExpressionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeInitializerExpressionSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreInitializerExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterInitializerExpressionSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneInitializerExpressionSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreInitializerExpressionSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "OpenBraceToken")
    			return false;
    		if(source.Name.LocalName == "CloseBraceToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneInitializerExpressionSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeInitializerExpressionSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreInitializerExpressionSelector(source);
    		PruneAfterInitializerExpressionSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneObjectCreationExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreObjectCreationExpressionSelector(XElement)"/> is not executed and <see cref="PruneObjectCreationExpressionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeObjectCreationExpressionSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreObjectCreationExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterObjectCreationExpressionSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneObjectCreationExpressionSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreObjectCreationExpressionSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "NewKeyword")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneObjectCreationExpressionSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeObjectCreationExpressionSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreObjectCreationExpressionSelector(source);
    		PruneAfterObjectCreationExpressionSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneAnonymousObjectCreationExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreAnonymousObjectCreationExpressionSelector(XElement)"/> is not executed and <see cref="PruneAnonymousObjectCreationExpressionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeAnonymousObjectCreationExpressionSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreAnonymousObjectCreationExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterAnonymousObjectCreationExpressionSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneAnonymousObjectCreationExpressionSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreAnonymousObjectCreationExpressionSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "NewKeyword")
    			return false;
    		if(source.Name.LocalName == "OpenBraceToken")
    			return false;
    		if(source.Name.LocalName == "CloseBraceToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneAnonymousObjectCreationExpressionSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeAnonymousObjectCreationExpressionSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreAnonymousObjectCreationExpressionSelector(source);
    		PruneAfterAnonymousObjectCreationExpressionSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneArrayCreationExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreArrayCreationExpressionSelector(XElement)"/> is not executed and <see cref="PruneArrayCreationExpressionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeArrayCreationExpressionSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreArrayCreationExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterArrayCreationExpressionSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneArrayCreationExpressionSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreArrayCreationExpressionSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "NewKeyword")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneArrayCreationExpressionSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeArrayCreationExpressionSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreArrayCreationExpressionSelector(source);
    		PruneAfterArrayCreationExpressionSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneImplicitArrayCreationExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreImplicitArrayCreationExpressionSelector(XElement)"/> is not executed and <see cref="PruneImplicitArrayCreationExpressionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeImplicitArrayCreationExpressionSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreImplicitArrayCreationExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterImplicitArrayCreationExpressionSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneImplicitArrayCreationExpressionSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreImplicitArrayCreationExpressionSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "NewKeyword")
    			return false;
    		if(source.Name.LocalName == "OpenBracketToken")
    			return false;
    		if(source.Name.LocalName == "CloseBracketToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneImplicitArrayCreationExpressionSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeImplicitArrayCreationExpressionSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreImplicitArrayCreationExpressionSelector(source);
    		PruneAfterImplicitArrayCreationExpressionSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneStackAllocArrayCreationExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreStackAllocArrayCreationExpressionSelector(XElement)"/> is not executed and <see cref="PruneStackAllocArrayCreationExpressionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeStackAllocArrayCreationExpressionSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreStackAllocArrayCreationExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterStackAllocArrayCreationExpressionSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneStackAllocArrayCreationExpressionSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreStackAllocArrayCreationExpressionSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "StackAllocKeyword")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneStackAllocArrayCreationExpressionSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeStackAllocArrayCreationExpressionSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreStackAllocArrayCreationExpressionSelector(source);
    		PruneAfterStackAllocArrayCreationExpressionSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneQueryExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreQueryExpressionSelector(XElement)"/> is not executed and <see cref="PruneQueryExpressionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeQueryExpressionSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreQueryExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterQueryExpressionSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneQueryExpressionSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreQueryExpressionSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneQueryExpressionSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeQueryExpressionSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreQueryExpressionSelector(source);
    		PruneAfterQueryExpressionSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneOmittedArraySizeExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreOmittedArraySizeExpressionSelector(XElement)"/> is not executed and <see cref="PruneOmittedArraySizeExpressionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeOmittedArraySizeExpressionSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreOmittedArraySizeExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterOmittedArraySizeExpressionSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneOmittedArraySizeExpressionSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreOmittedArraySizeExpressionSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "OmittedArraySizeExpressionToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneOmittedArraySizeExpressionSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeOmittedArraySizeExpressionSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreOmittedArraySizeExpressionSelector(source);
    		PruneAfterOmittedArraySizeExpressionSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneInterpolatedStringExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreInterpolatedStringExpressionSelector(XElement)"/> is not executed and <see cref="PruneInterpolatedStringExpressionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeInterpolatedStringExpressionSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreInterpolatedStringExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterInterpolatedStringExpressionSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneInterpolatedStringExpressionSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreInterpolatedStringExpressionSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "StringStartToken")
    			return false;
    		if(source.Name.LocalName == "StringEndToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneInterpolatedStringExpressionSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeInterpolatedStringExpressionSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreInterpolatedStringExpressionSelector(source);
    		PruneAfterInterpolatedStringExpressionSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneIsPatternExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreIsPatternExpressionSelector(XElement)"/> is not executed and <see cref="PruneIsPatternExpressionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeIsPatternExpressionSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreIsPatternExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterIsPatternExpressionSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneIsPatternExpressionSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreIsPatternExpressionSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "IsKeyword")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneIsPatternExpressionSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeIsPatternExpressionSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreIsPatternExpressionSelector(source);
    		PruneAfterIsPatternExpressionSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneThrowExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreThrowExpressionSelector(XElement)"/> is not executed and <see cref="PruneThrowExpressionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeThrowExpressionSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreThrowExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterThrowExpressionSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneThrowExpressionSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreThrowExpressionSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "ThrowKeyword")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneThrowExpressionSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeThrowExpressionSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreThrowExpressionSelector(source);
    		PruneAfterThrowExpressionSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PrunePredefinedTypeSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCorePredefinedTypeSelector(XElement)"/> is not executed and <see cref="PrunePredefinedTypeSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforePredefinedTypeSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCorePredefinedTypeSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterPredefinedTypeSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PrunePredefinedTypeSelector(XElement)"/>.</remarks>
        public virtual bool PruneCorePredefinedTypeSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "Keyword")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PrunePredefinedTypeSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforePredefinedTypeSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCorePredefinedTypeSelector(source);
    		PruneAfterPredefinedTypeSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneArrayTypeSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreArrayTypeSelector(XElement)"/> is not executed and <see cref="PruneArrayTypeSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeArrayTypeSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreArrayTypeSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterArrayTypeSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneArrayTypeSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreArrayTypeSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneArrayTypeSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeArrayTypeSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreArrayTypeSelector(source);
    		PruneAfterArrayTypeSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PrunePointerTypeSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCorePointerTypeSelector(XElement)"/> is not executed and <see cref="PrunePointerTypeSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforePointerTypeSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCorePointerTypeSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterPointerTypeSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PrunePointerTypeSelector(XElement)"/>.</remarks>
        public virtual bool PruneCorePointerTypeSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "AsteriskToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PrunePointerTypeSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforePointerTypeSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCorePointerTypeSelector(source);
    		PruneAfterPointerTypeSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneNullableTypeSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreNullableTypeSelector(XElement)"/> is not executed and <see cref="PruneNullableTypeSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeNullableTypeSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreNullableTypeSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterNullableTypeSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneNullableTypeSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreNullableTypeSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "QuestionToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneNullableTypeSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeNullableTypeSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreNullableTypeSelector(source);
    		PruneAfterNullableTypeSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneTupleTypeSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreTupleTypeSelector(XElement)"/> is not executed and <see cref="PruneTupleTypeSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeTupleTypeSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreTupleTypeSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterTupleTypeSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneTupleTypeSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreTupleTypeSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "OpenParenToken")
    			return false;
    		if(source.Name.LocalName == "CloseParenToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneTupleTypeSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeTupleTypeSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreTupleTypeSelector(source);
    		PruneAfterTupleTypeSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneOmittedTypeArgumentSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreOmittedTypeArgumentSelector(XElement)"/> is not executed and <see cref="PruneOmittedTypeArgumentSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeOmittedTypeArgumentSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreOmittedTypeArgumentSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterOmittedTypeArgumentSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneOmittedTypeArgumentSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreOmittedTypeArgumentSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "OmittedTypeArgumentToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneOmittedTypeArgumentSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeOmittedTypeArgumentSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreOmittedTypeArgumentSelector(source);
    		PruneAfterOmittedTypeArgumentSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneRefTypeSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreRefTypeSelector(XElement)"/> is not executed and <see cref="PruneRefTypeSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeRefTypeSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreRefTypeSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterRefTypeSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneRefTypeSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreRefTypeSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "RefKeyword")
    			return false;
    		if(source.Name.LocalName == "ReadOnlyKeyword")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneRefTypeSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeRefTypeSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreRefTypeSelector(source);
    		PruneAfterRefTypeSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneQualifiedNameSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreQualifiedNameSelector(XElement)"/> is not executed and <see cref="PruneQualifiedNameSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeQualifiedNameSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreQualifiedNameSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterQualifiedNameSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneQualifiedNameSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreQualifiedNameSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "DotToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneQualifiedNameSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeQualifiedNameSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreQualifiedNameSelector(source);
    		PruneAfterQualifiedNameSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneAliasQualifiedNameSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreAliasQualifiedNameSelector(XElement)"/> is not executed and <see cref="PruneAliasQualifiedNameSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeAliasQualifiedNameSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreAliasQualifiedNameSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterAliasQualifiedNameSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneAliasQualifiedNameSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreAliasQualifiedNameSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "ColonColonToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneAliasQualifiedNameSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeAliasQualifiedNameSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreAliasQualifiedNameSelector(source);
    		PruneAfterAliasQualifiedNameSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneIdentifierNameSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreIdentifierNameSelector(XElement)"/> is not executed and <see cref="PruneIdentifierNameSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeIdentifierNameSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreIdentifierNameSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterIdentifierNameSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneIdentifierNameSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreIdentifierNameSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneIdentifierNameSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeIdentifierNameSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreIdentifierNameSelector(source);
    		PruneAfterIdentifierNameSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneGenericNameSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreGenericNameSelector(XElement)"/> is not executed and <see cref="PruneGenericNameSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeGenericNameSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreGenericNameSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterGenericNameSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneGenericNameSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreGenericNameSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneGenericNameSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeGenericNameSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreGenericNameSelector(source);
    		PruneAfterGenericNameSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneThisExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreThisExpressionSelector(XElement)"/> is not executed and <see cref="PruneThisExpressionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeThisExpressionSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreThisExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterThisExpressionSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneThisExpressionSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreThisExpressionSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "Token")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneThisExpressionSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeThisExpressionSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreThisExpressionSelector(source);
    		PruneAfterThisExpressionSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneBaseExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreBaseExpressionSelector(XElement)"/> is not executed and <see cref="PruneBaseExpressionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeBaseExpressionSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreBaseExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterBaseExpressionSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneBaseExpressionSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreBaseExpressionSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "Token")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneBaseExpressionSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeBaseExpressionSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreBaseExpressionSelector(source);
    		PruneAfterBaseExpressionSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneAnonymousMethodExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreAnonymousMethodExpressionSelector(XElement)"/> is not executed and <see cref="PruneAnonymousMethodExpressionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeAnonymousMethodExpressionSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreAnonymousMethodExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterAnonymousMethodExpressionSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneAnonymousMethodExpressionSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreAnonymousMethodExpressionSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "AsyncKeyword")
    			return false;
    		if(source.Name.LocalName == "DelegateKeyword")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneAnonymousMethodExpressionSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeAnonymousMethodExpressionSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreAnonymousMethodExpressionSelector(source);
    		PruneAfterAnonymousMethodExpressionSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneSimpleLambdaExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreSimpleLambdaExpressionSelector(XElement)"/> is not executed and <see cref="PruneSimpleLambdaExpressionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeSimpleLambdaExpressionSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreSimpleLambdaExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterSimpleLambdaExpressionSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneSimpleLambdaExpressionSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreSimpleLambdaExpressionSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "AsyncKeyword")
    			return false;
    		if(source.Name.LocalName == "ArrowToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneSimpleLambdaExpressionSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeSimpleLambdaExpressionSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreSimpleLambdaExpressionSelector(source);
    		PruneAfterSimpleLambdaExpressionSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneParenthesizedLambdaExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreParenthesizedLambdaExpressionSelector(XElement)"/> is not executed and <see cref="PruneParenthesizedLambdaExpressionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeParenthesizedLambdaExpressionSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreParenthesizedLambdaExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterParenthesizedLambdaExpressionSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneParenthesizedLambdaExpressionSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreParenthesizedLambdaExpressionSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "AsyncKeyword")
    			return false;
    		if(source.Name.LocalName == "ArrowToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneParenthesizedLambdaExpressionSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeParenthesizedLambdaExpressionSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreParenthesizedLambdaExpressionSelector(source);
    		PruneAfterParenthesizedLambdaExpressionSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneArgumentListSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreArgumentListSelector(XElement)"/> is not executed and <see cref="PruneArgumentListSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeArgumentListSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreArgumentListSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterArgumentListSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneArgumentListSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreArgumentListSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "OpenParenToken")
    			return false;
    		if(source.Name.LocalName == "CloseParenToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneArgumentListSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeArgumentListSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreArgumentListSelector(source);
    		PruneAfterArgumentListSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneBracketedArgumentListSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreBracketedArgumentListSelector(XElement)"/> is not executed and <see cref="PruneBracketedArgumentListSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeBracketedArgumentListSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreBracketedArgumentListSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterBracketedArgumentListSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneBracketedArgumentListSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreBracketedArgumentListSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "OpenBracketToken")
    			return false;
    		if(source.Name.LocalName == "CloseBracketToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneBracketedArgumentListSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeBracketedArgumentListSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreBracketedArgumentListSelector(source);
    		PruneAfterBracketedArgumentListSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneFromClauseSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreFromClauseSelector(XElement)"/> is not executed and <see cref="PruneFromClauseSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeFromClauseSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreFromClauseSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterFromClauseSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneFromClauseSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreFromClauseSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "FromKeyword")
    			return false;
    		if(source.Name.LocalName == "InKeyword")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneFromClauseSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeFromClauseSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreFromClauseSelector(source);
    		PruneAfterFromClauseSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneLetClauseSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreLetClauseSelector(XElement)"/> is not executed and <see cref="PruneLetClauseSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeLetClauseSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreLetClauseSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterLetClauseSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneLetClauseSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreLetClauseSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "LetKeyword")
    			return false;
    		if(source.Name.LocalName == "EqualsToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneLetClauseSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeLetClauseSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreLetClauseSelector(source);
    		PruneAfterLetClauseSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneJoinClauseSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreJoinClauseSelector(XElement)"/> is not executed and <see cref="PruneJoinClauseSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeJoinClauseSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreJoinClauseSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterJoinClauseSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneJoinClauseSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreJoinClauseSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "JoinKeyword")
    			return false;
    		if(source.Name.LocalName == "InKeyword")
    			return false;
    		if(source.Name.LocalName == "OnKeyword")
    			return false;
    		if(source.Name.LocalName == "EqualsKeyword")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneJoinClauseSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeJoinClauseSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreJoinClauseSelector(source);
    		PruneAfterJoinClauseSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneWhereClauseSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreWhereClauseSelector(XElement)"/> is not executed and <see cref="PruneWhereClauseSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeWhereClauseSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreWhereClauseSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterWhereClauseSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneWhereClauseSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreWhereClauseSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "WhereKeyword")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneWhereClauseSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeWhereClauseSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreWhereClauseSelector(source);
    		PruneAfterWhereClauseSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneOrderByClauseSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreOrderByClauseSelector(XElement)"/> is not executed and <see cref="PruneOrderByClauseSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeOrderByClauseSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreOrderByClauseSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterOrderByClauseSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneOrderByClauseSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreOrderByClauseSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "OrderByKeyword")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneOrderByClauseSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeOrderByClauseSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreOrderByClauseSelector(source);
    		PruneAfterOrderByClauseSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneSelectClauseSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreSelectClauseSelector(XElement)"/> is not executed and <see cref="PruneSelectClauseSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeSelectClauseSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreSelectClauseSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterSelectClauseSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneSelectClauseSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreSelectClauseSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "SelectKeyword")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneSelectClauseSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeSelectClauseSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreSelectClauseSelector(source);
    		PruneAfterSelectClauseSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneGroupClauseSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreGroupClauseSelector(XElement)"/> is not executed and <see cref="PruneGroupClauseSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeGroupClauseSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreGroupClauseSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterGroupClauseSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneGroupClauseSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreGroupClauseSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "GroupKeyword")
    			return false;
    		if(source.Name.LocalName == "ByKeyword")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneGroupClauseSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeGroupClauseSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreGroupClauseSelector(source);
    		PruneAfterGroupClauseSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneDeclarationPatternSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreDeclarationPatternSelector(XElement)"/> is not executed and <see cref="PruneDeclarationPatternSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeDeclarationPatternSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreDeclarationPatternSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterDeclarationPatternSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneDeclarationPatternSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreDeclarationPatternSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneDeclarationPatternSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeDeclarationPatternSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreDeclarationPatternSelector(source);
    		PruneAfterDeclarationPatternSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneConstantPatternSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreConstantPatternSelector(XElement)"/> is not executed and <see cref="PruneConstantPatternSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeConstantPatternSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreConstantPatternSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterConstantPatternSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneConstantPatternSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreConstantPatternSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneConstantPatternSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeConstantPatternSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreConstantPatternSelector(source);
    		PruneAfterConstantPatternSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneInterpolatedStringTextSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreInterpolatedStringTextSelector(XElement)"/> is not executed and <see cref="PruneInterpolatedStringTextSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeInterpolatedStringTextSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreInterpolatedStringTextSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterInterpolatedStringTextSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneInterpolatedStringTextSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreInterpolatedStringTextSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneInterpolatedStringTextSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeInterpolatedStringTextSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreInterpolatedStringTextSelector(source);
    		PruneAfterInterpolatedStringTextSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneInterpolationSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreInterpolationSelector(XElement)"/> is not executed and <see cref="PruneInterpolationSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeInterpolationSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreInterpolationSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterInterpolationSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneInterpolationSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreInterpolationSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "OpenBraceToken")
    			return false;
    		if(source.Name.LocalName == "CloseBraceToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneInterpolationSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeInterpolationSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreInterpolationSelector(source);
    		PruneAfterInterpolationSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneBlockSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreBlockSelector(XElement)"/> is not executed and <see cref="PruneBlockSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeBlockSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreBlockSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterBlockSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneBlockSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreBlockSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "OpenBraceToken")
    			return false;
    		if(source.Name.LocalName == "CloseBraceToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneBlockSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeBlockSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreBlockSelector(source);
    		PruneAfterBlockSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneLocalFunctionStatementSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreLocalFunctionStatementSelector(XElement)"/> is not executed and <see cref="PruneLocalFunctionStatementSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeLocalFunctionStatementSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreLocalFunctionStatementSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterLocalFunctionStatementSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneLocalFunctionStatementSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreLocalFunctionStatementSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "SemicolonToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneLocalFunctionStatementSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeLocalFunctionStatementSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreLocalFunctionStatementSelector(source);
    		PruneAfterLocalFunctionStatementSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneLocalDeclarationStatementSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreLocalDeclarationStatementSelector(XElement)"/> is not executed and <see cref="PruneLocalDeclarationStatementSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeLocalDeclarationStatementSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreLocalDeclarationStatementSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterLocalDeclarationStatementSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneLocalDeclarationStatementSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreLocalDeclarationStatementSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "SemicolonToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneLocalDeclarationStatementSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeLocalDeclarationStatementSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreLocalDeclarationStatementSelector(source);
    		PruneAfterLocalDeclarationStatementSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneExpressionStatementSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreExpressionStatementSelector(XElement)"/> is not executed and <see cref="PruneExpressionStatementSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeExpressionStatementSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreExpressionStatementSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterExpressionStatementSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneExpressionStatementSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreExpressionStatementSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "SemicolonToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneExpressionStatementSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeExpressionStatementSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreExpressionStatementSelector(source);
    		PruneAfterExpressionStatementSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneEmptyStatementSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreEmptyStatementSelector(XElement)"/> is not executed and <see cref="PruneEmptyStatementSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeEmptyStatementSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreEmptyStatementSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterEmptyStatementSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneEmptyStatementSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreEmptyStatementSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "SemicolonToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneEmptyStatementSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeEmptyStatementSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreEmptyStatementSelector(source);
    		PruneAfterEmptyStatementSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneLabeledStatementSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreLabeledStatementSelector(XElement)"/> is not executed and <see cref="PruneLabeledStatementSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeLabeledStatementSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreLabeledStatementSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterLabeledStatementSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneLabeledStatementSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreLabeledStatementSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "ColonToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneLabeledStatementSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeLabeledStatementSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreLabeledStatementSelector(source);
    		PruneAfterLabeledStatementSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneGotoStatementSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreGotoStatementSelector(XElement)"/> is not executed and <see cref="PruneGotoStatementSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeGotoStatementSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreGotoStatementSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterGotoStatementSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneGotoStatementSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreGotoStatementSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "GotoKeyword")
    			return false;
    		if(source.Name.LocalName == "CaseOrDefaultKeyword")
    			return false;
    		if(source.Name.LocalName == "SemicolonToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneGotoStatementSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeGotoStatementSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreGotoStatementSelector(source);
    		PruneAfterGotoStatementSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneBreakStatementSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreBreakStatementSelector(XElement)"/> is not executed and <see cref="PruneBreakStatementSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeBreakStatementSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreBreakStatementSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterBreakStatementSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneBreakStatementSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreBreakStatementSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "BreakKeyword")
    			return false;
    		if(source.Name.LocalName == "SemicolonToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneBreakStatementSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeBreakStatementSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreBreakStatementSelector(source);
    		PruneAfterBreakStatementSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneContinueStatementSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreContinueStatementSelector(XElement)"/> is not executed and <see cref="PruneContinueStatementSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeContinueStatementSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreContinueStatementSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterContinueStatementSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneContinueStatementSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreContinueStatementSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "ContinueKeyword")
    			return false;
    		if(source.Name.LocalName == "SemicolonToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneContinueStatementSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeContinueStatementSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreContinueStatementSelector(source);
    		PruneAfterContinueStatementSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneReturnStatementSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreReturnStatementSelector(XElement)"/> is not executed and <see cref="PruneReturnStatementSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeReturnStatementSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreReturnStatementSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterReturnStatementSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneReturnStatementSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreReturnStatementSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "ReturnKeyword")
    			return false;
    		if(source.Name.LocalName == "SemicolonToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneReturnStatementSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeReturnStatementSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreReturnStatementSelector(source);
    		PruneAfterReturnStatementSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneThrowStatementSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreThrowStatementSelector(XElement)"/> is not executed and <see cref="PruneThrowStatementSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeThrowStatementSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreThrowStatementSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterThrowStatementSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneThrowStatementSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreThrowStatementSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "ThrowKeyword")
    			return false;
    		if(source.Name.LocalName == "SemicolonToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneThrowStatementSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeThrowStatementSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreThrowStatementSelector(source);
    		PruneAfterThrowStatementSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneYieldStatementSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreYieldStatementSelector(XElement)"/> is not executed and <see cref="PruneYieldStatementSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeYieldStatementSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreYieldStatementSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterYieldStatementSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneYieldStatementSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreYieldStatementSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "YieldKeyword")
    			return false;
    		if(source.Name.LocalName == "ReturnOrBreakKeyword")
    			return false;
    		if(source.Name.LocalName == "SemicolonToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneYieldStatementSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeYieldStatementSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreYieldStatementSelector(source);
    		PruneAfterYieldStatementSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneWhileStatementSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreWhileStatementSelector(XElement)"/> is not executed and <see cref="PruneWhileStatementSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeWhileStatementSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreWhileStatementSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterWhileStatementSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneWhileStatementSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreWhileStatementSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "WhileKeyword")
    			return false;
    		if(source.Name.LocalName == "OpenParenToken")
    			return false;
    		if(source.Name.LocalName == "CloseParenToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneWhileStatementSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeWhileStatementSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreWhileStatementSelector(source);
    		PruneAfterWhileStatementSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneDoStatementSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreDoStatementSelector(XElement)"/> is not executed and <see cref="PruneDoStatementSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeDoStatementSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreDoStatementSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterDoStatementSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneDoStatementSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreDoStatementSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "DoKeyword")
    			return false;
    		if(source.Name.LocalName == "WhileKeyword")
    			return false;
    		if(source.Name.LocalName == "OpenParenToken")
    			return false;
    		if(source.Name.LocalName == "CloseParenToken")
    			return false;
    		if(source.Name.LocalName == "SemicolonToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneDoStatementSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeDoStatementSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreDoStatementSelector(source);
    		PruneAfterDoStatementSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneForStatementSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreForStatementSelector(XElement)"/> is not executed and <see cref="PruneForStatementSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeForStatementSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreForStatementSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterForStatementSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneForStatementSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreForStatementSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "ForKeyword")
    			return false;
    		if(source.Name.LocalName == "OpenParenToken")
    			return false;
    		if(source.Name.LocalName == "FirstSemicolonToken")
    			return false;
    		if(source.Name.LocalName == "SecondSemicolonToken")
    			return false;
    		if(source.Name.LocalName == "CloseParenToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneForStatementSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeForStatementSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreForStatementSelector(source);
    		PruneAfterForStatementSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneUsingStatementSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreUsingStatementSelector(XElement)"/> is not executed and <see cref="PruneUsingStatementSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeUsingStatementSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreUsingStatementSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterUsingStatementSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneUsingStatementSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreUsingStatementSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "UsingKeyword")
    			return false;
    		if(source.Name.LocalName == "OpenParenToken")
    			return false;
    		if(source.Name.LocalName == "CloseParenToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneUsingStatementSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeUsingStatementSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreUsingStatementSelector(source);
    		PruneAfterUsingStatementSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneFixedStatementSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreFixedStatementSelector(XElement)"/> is not executed and <see cref="PruneFixedStatementSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeFixedStatementSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreFixedStatementSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterFixedStatementSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneFixedStatementSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreFixedStatementSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "FixedKeyword")
    			return false;
    		if(source.Name.LocalName == "OpenParenToken")
    			return false;
    		if(source.Name.LocalName == "CloseParenToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneFixedStatementSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeFixedStatementSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreFixedStatementSelector(source);
    		PruneAfterFixedStatementSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneCheckedStatementSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreCheckedStatementSelector(XElement)"/> is not executed and <see cref="PruneCheckedStatementSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeCheckedStatementSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreCheckedStatementSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterCheckedStatementSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneCheckedStatementSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreCheckedStatementSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "Keyword")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneCheckedStatementSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeCheckedStatementSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreCheckedStatementSelector(source);
    		PruneAfterCheckedStatementSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneUnsafeStatementSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreUnsafeStatementSelector(XElement)"/> is not executed and <see cref="PruneUnsafeStatementSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeUnsafeStatementSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreUnsafeStatementSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterUnsafeStatementSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneUnsafeStatementSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreUnsafeStatementSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "UnsafeKeyword")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneUnsafeStatementSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeUnsafeStatementSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreUnsafeStatementSelector(source);
    		PruneAfterUnsafeStatementSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneLockStatementSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreLockStatementSelector(XElement)"/> is not executed and <see cref="PruneLockStatementSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeLockStatementSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreLockStatementSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterLockStatementSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneLockStatementSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreLockStatementSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "LockKeyword")
    			return false;
    		if(source.Name.LocalName == "OpenParenToken")
    			return false;
    		if(source.Name.LocalName == "CloseParenToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneLockStatementSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeLockStatementSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreLockStatementSelector(source);
    		PruneAfterLockStatementSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneIfStatementSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreIfStatementSelector(XElement)"/> is not executed and <see cref="PruneIfStatementSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeIfStatementSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreIfStatementSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterIfStatementSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneIfStatementSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreIfStatementSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "IfKeyword")
    			return false;
    		if(source.Name.LocalName == "OpenParenToken")
    			return false;
    		if(source.Name.LocalName == "CloseParenToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneIfStatementSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeIfStatementSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreIfStatementSelector(source);
    		PruneAfterIfStatementSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneSwitchStatementSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreSwitchStatementSelector(XElement)"/> is not executed and <see cref="PruneSwitchStatementSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeSwitchStatementSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreSwitchStatementSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterSwitchStatementSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneSwitchStatementSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreSwitchStatementSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "SwitchKeyword")
    			return false;
    		if(source.Name.LocalName == "OpenParenToken")
    			return false;
    		if(source.Name.LocalName == "CloseParenToken")
    			return false;
    		if(source.Name.LocalName == "OpenBraceToken")
    			return false;
    		if(source.Name.LocalName == "CloseBraceToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneSwitchStatementSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeSwitchStatementSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreSwitchStatementSelector(source);
    		PruneAfterSwitchStatementSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneTryStatementSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreTryStatementSelector(XElement)"/> is not executed and <see cref="PruneTryStatementSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeTryStatementSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreTryStatementSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterTryStatementSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneTryStatementSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreTryStatementSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "TryKeyword")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneTryStatementSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeTryStatementSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreTryStatementSelector(source);
    		PruneAfterTryStatementSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneForEachStatementSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreForEachStatementSelector(XElement)"/> is not executed and <see cref="PruneForEachStatementSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeForEachStatementSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreForEachStatementSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterForEachStatementSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneForEachStatementSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreForEachStatementSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "ForEachKeyword")
    			return false;
    		if(source.Name.LocalName == "OpenParenToken")
    			return false;
    		if(source.Name.LocalName == "InKeyword")
    			return false;
    		if(source.Name.LocalName == "CloseParenToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneForEachStatementSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeForEachStatementSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreForEachStatementSelector(source);
    		PruneAfterForEachStatementSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneForEachVariableStatementSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreForEachVariableStatementSelector(XElement)"/> is not executed and <see cref="PruneForEachVariableStatementSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeForEachVariableStatementSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreForEachVariableStatementSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterForEachVariableStatementSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneForEachVariableStatementSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreForEachVariableStatementSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "ForEachKeyword")
    			return false;
    		if(source.Name.LocalName == "OpenParenToken")
    			return false;
    		if(source.Name.LocalName == "InKeyword")
    			return false;
    		if(source.Name.LocalName == "CloseParenToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneForEachVariableStatementSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeForEachVariableStatementSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreForEachVariableStatementSelector(source);
    		PruneAfterForEachVariableStatementSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneSingleVariableDesignationSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreSingleVariableDesignationSelector(XElement)"/> is not executed and <see cref="PruneSingleVariableDesignationSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeSingleVariableDesignationSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreSingleVariableDesignationSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterSingleVariableDesignationSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneSingleVariableDesignationSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreSingleVariableDesignationSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneSingleVariableDesignationSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeSingleVariableDesignationSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreSingleVariableDesignationSelector(source);
    		PruneAfterSingleVariableDesignationSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneDiscardDesignationSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreDiscardDesignationSelector(XElement)"/> is not executed and <see cref="PruneDiscardDesignationSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeDiscardDesignationSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreDiscardDesignationSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterDiscardDesignationSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneDiscardDesignationSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreDiscardDesignationSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "UnderscoreToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneDiscardDesignationSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeDiscardDesignationSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreDiscardDesignationSelector(source);
    		PruneAfterDiscardDesignationSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneParenthesizedVariableDesignationSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreParenthesizedVariableDesignationSelector(XElement)"/> is not executed and <see cref="PruneParenthesizedVariableDesignationSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeParenthesizedVariableDesignationSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreParenthesizedVariableDesignationSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterParenthesizedVariableDesignationSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneParenthesizedVariableDesignationSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreParenthesizedVariableDesignationSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "OpenParenToken")
    			return false;
    		if(source.Name.LocalName == "CloseParenToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneParenthesizedVariableDesignationSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeParenthesizedVariableDesignationSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreParenthesizedVariableDesignationSelector(source);
    		PruneAfterParenthesizedVariableDesignationSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneCasePatternSwitchLabelSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreCasePatternSwitchLabelSelector(XElement)"/> is not executed and <see cref="PruneCasePatternSwitchLabelSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeCasePatternSwitchLabelSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreCasePatternSwitchLabelSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterCasePatternSwitchLabelSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneCasePatternSwitchLabelSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreCasePatternSwitchLabelSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "Keyword")
    			return false;
    		if(source.Name.LocalName == "ColonToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneCasePatternSwitchLabelSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeCasePatternSwitchLabelSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreCasePatternSwitchLabelSelector(source);
    		PruneAfterCasePatternSwitchLabelSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneCaseSwitchLabelSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreCaseSwitchLabelSelector(XElement)"/> is not executed and <see cref="PruneCaseSwitchLabelSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeCaseSwitchLabelSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreCaseSwitchLabelSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterCaseSwitchLabelSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneCaseSwitchLabelSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreCaseSwitchLabelSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "Keyword")
    			return false;
    		if(source.Name.LocalName == "ColonToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneCaseSwitchLabelSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeCaseSwitchLabelSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreCaseSwitchLabelSelector(source);
    		PruneAfterCaseSwitchLabelSelector(source, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneDefaultSwitchLabelSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>Selector.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCoreDefaultSwitchLabelSelector(XElement)"/> is not executed and <see cref="PruneDefaultSwitchLabelSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBeforeDefaultSwitchLabelSelector(XElement source, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreDefaultSwitchLabelSelector(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Children(SyntaxNodeOrToken?)"/>.</param>
        partial void PruneAfterDefaultSwitchLabelSelector(XElement source, ref bool result);
    
    	/// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneDefaultSwitchLabelSelector(XElement)"/>.</remarks>
        public virtual bool PruneCoreDefaultSwitchLabelSelector(XElement source)
        {
    		if(source != null)
    			throw new ArgumentNullException(nameof(source));
    
    		if(source.Name.LocalName == "Keyword")
    			return false;
    		if(source.Name.LocalName == "ColonToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines what element types remain (true) or not (false). 
        /// </summary>
        /// <param name="source">the element to prune.</param>
        /// <returns>true if the element would remain, false otherwise.</returns>
        public virtual bool PruneDefaultSwitchLabelSelector(XElement source)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBeforeDefaultSwitchLabelSelector(source, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCoreDefaultSwitchLabelSelector(source);
    		PruneAfterDefaultSwitchLabelSelector(source, ref result);
    		return result;
    	}
    
    }
}
// Generated helper templates
// Generated items
