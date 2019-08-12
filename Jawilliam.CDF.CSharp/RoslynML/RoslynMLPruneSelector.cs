
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Jawilliam.CDF.CSharp.RoslynML
{
    public partial class RoslynMLPruneSelector
    {
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneSelectorCore(XElement)"/> is not executed and <see cref="PruneSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneSelectorCore(XElement)"/>.</param>
        partial void PruneSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneSelector(XElement)"/>.</remarks>
        public virtual bool PruneSelectorCore(XElement property)
    	{
    		if(property.Parent == null)
    			return true;
    
    		switch(property.Parent.Name.LocalName)
    		{
    			case "AttributeArgument": return this.PruneAttributeArgumentSelector(property);
    			case "NameEquals": return this.PruneNameEqualsSelector(property);
    			case "TypeParameterList": return this.PruneTypeParameterListSelector(property);
    			case "TypeParameter": return this.PruneTypeParameterSelector(property);
    			case "BaseList": return this.PruneBaseListSelector(property);
    			case "TypeParameterConstraintClause": return this.PruneTypeParameterConstraintClauseSelector(property);
    			case "ExplicitInterfaceSpecifier": return this.PruneExplicitInterfaceSpecifierSelector(property);
    			case "ConstructorInitializer": return this.PruneConstructorInitializerSelector(property);
    			case "ArrowExpressionClause": return this.PruneArrowExpressionClauseSelector(property);
    			case "AccessorList": return this.PruneAccessorListSelector(property);
    			case "AccessorDeclaration": return this.PruneAccessorDeclarationSelector(property);
    			case "Parameter": return this.PruneParameterSelector(property);
    			case "CrefParameter": return this.PruneCrefParameterSelector(property);
    			case "XmlElementStartTag": return this.PruneXmlElementStartTagSelector(property);
    			case "XmlElementEndTag": return this.PruneXmlElementEndTagSelector(property);
    			case "XmlName": return this.PruneXmlNameSelector(property);
    			case "XmlPrefix": return this.PruneXmlPrefixSelector(property);
    			case "TypeArgumentList": return this.PruneTypeArgumentListSelector(property);
    			case "ArrayRankSpecifier": return this.PruneArrayRankSpecifierSelector(property);
    			case "TupleElement": return this.PruneTupleElementSelector(property);
    			case "Argument": return this.PruneArgumentSelector(property);
    			case "NameColon": return this.PruneNameColonSelector(property);
    			case "AnonymousObjectMemberDeclarator": return this.PruneAnonymousObjectMemberDeclaratorSelector(property);
    			case "QueryBody": return this.PruneQueryBodySelector(property);
    			case "JoinIntoClause": return this.PruneJoinIntoClauseSelector(property);
    			case "Ordering": return this.PruneOrderingSelector(property);
    			case "QueryContinuation": return this.PruneQueryContinuationSelector(property);
    			case "WhenClause": return this.PruneWhenClauseSelector(property);
    			case "InterpolationAlignmentClause": return this.PruneInterpolationAlignmentClauseSelector(property);
    			case "InterpolationFormatClause": return this.PruneInterpolationFormatClauseSelector(property);
    			case "VariableDeclaration": return this.PruneVariableDeclarationSelector(property);
    			case "VariableDeclarator": return this.PruneVariableDeclaratorSelector(property);
    			case "EqualsValueClause": return this.PruneEqualsValueClauseSelector(property);
    			case "ElseClause": return this.PruneElseClauseSelector(property);
    			case "SwitchSection": return this.PruneSwitchSectionSelector(property);
    			case "CatchClause": return this.PruneCatchClauseSelector(property);
    			case "CatchDeclaration": return this.PruneCatchDeclarationSelector(property);
    			case "CatchFilterClause": return this.PruneCatchFilterClauseSelector(property);
    			case "FinallyClause": return this.PruneFinallyClauseSelector(property);
    			case "CompilationUnit": return this.PruneCompilationUnitSelector(property);
    			case "ExternAliasDirective": return this.PruneExternAliasDirectiveSelector(property);
    			case "UsingDirective": return this.PruneUsingDirectiveSelector(property);
    			case "AttributeList": return this.PruneAttributeListSelector(property);
    			case "AttributeTargetSpecifier": return this.PruneAttributeTargetSpecifierSelector(property);
    			case "Attribute": return this.PruneAttributeSelector(property);
    			case "AttributeArgumentList": return this.PruneAttributeArgumentListSelector(property);
    			case "DelegateDeclaration": return this.PruneDelegateDeclarationSelector(property);
    			case "EnumMemberDeclaration": return this.PruneEnumMemberDeclarationSelector(property);
    			case "IncompleteMember": return this.PruneIncompleteMemberSelector(property);
    			case "GlobalStatement": return this.PruneGlobalStatementSelector(property);
    			case "NamespaceDeclaration": return this.PruneNamespaceDeclarationSelector(property);
    			case "EnumDeclaration": return this.PruneEnumDeclarationSelector(property);
    			case "ClassDeclaration": return this.PruneClassDeclarationSelector(property);
    			case "StructDeclaration": return this.PruneStructDeclarationSelector(property);
    			case "InterfaceDeclaration": return this.PruneInterfaceDeclarationSelector(property);
    			case "FieldDeclaration": return this.PruneFieldDeclarationSelector(property);
    			case "EventFieldDeclaration": return this.PruneEventFieldDeclarationSelector(property);
    			case "MethodDeclaration": return this.PruneMethodDeclarationSelector(property);
    			case "OperatorDeclaration": return this.PruneOperatorDeclarationSelector(property);
    			case "ConversionOperatorDeclaration": return this.PruneConversionOperatorDeclarationSelector(property);
    			case "ConstructorDeclaration": return this.PruneConstructorDeclarationSelector(property);
    			case "DestructorDeclaration": return this.PruneDestructorDeclarationSelector(property);
    			case "PropertyDeclaration": return this.PrunePropertyDeclarationSelector(property);
    			case "EventDeclaration": return this.PruneEventDeclarationSelector(property);
    			case "IndexerDeclaration": return this.PruneIndexerDeclarationSelector(property);
    			case "SimpleBaseType": return this.PruneSimpleBaseTypeSelector(property);
    			case "ConstructorConstraint": return this.PruneConstructorConstraintSelector(property);
    			case "ClassOrStructConstraint": return this.PruneClassOrStructConstraintSelector(property);
    			case "TypeConstraint": return this.PruneTypeConstraintSelector(property);
    			case "ParameterList": return this.PruneParameterListSelector(property);
    			case "BracketedParameterList": return this.PruneBracketedParameterListSelector(property);
    			case "SkippedTokensTrivia": return this.PruneSkippedTokensTriviaSelector(property);
    			case "DocumentationCommentTrivia": return this.PruneDocumentationCommentTriviaSelector(property);
    			case "EndIfDirectiveTrivia": return this.PruneEndIfDirectiveTriviaSelector(property);
    			case "RegionDirectiveTrivia": return this.PruneRegionDirectiveTriviaSelector(property);
    			case "EndRegionDirectiveTrivia": return this.PruneEndRegionDirectiveTriviaSelector(property);
    			case "ErrorDirectiveTrivia": return this.PruneErrorDirectiveTriviaSelector(property);
    			case "WarningDirectiveTrivia": return this.PruneWarningDirectiveTriviaSelector(property);
    			case "BadDirectiveTrivia": return this.PruneBadDirectiveTriviaSelector(property);
    			case "DefineDirectiveTrivia": return this.PruneDefineDirectiveTriviaSelector(property);
    			case "UndefDirectiveTrivia": return this.PruneUndefDirectiveTriviaSelector(property);
    			case "LineDirectiveTrivia": return this.PruneLineDirectiveTriviaSelector(property);
    			case "PragmaWarningDirectiveTrivia": return this.PrunePragmaWarningDirectiveTriviaSelector(property);
    			case "PragmaChecksumDirectiveTrivia": return this.PrunePragmaChecksumDirectiveTriviaSelector(property);
    			case "ReferenceDirectiveTrivia": return this.PruneReferenceDirectiveTriviaSelector(property);
    			case "LoadDirectiveTrivia": return this.PruneLoadDirectiveTriviaSelector(property);
    			case "ShebangDirectiveTrivia": return this.PruneShebangDirectiveTriviaSelector(property);
    			case "ElseDirectiveTrivia": return this.PruneElseDirectiveTriviaSelector(property);
    			case "IfDirectiveTrivia": return this.PruneIfDirectiveTriviaSelector(property);
    			case "ElifDirectiveTrivia": return this.PruneElifDirectiveTriviaSelector(property);
    			case "TypeCref": return this.PruneTypeCrefSelector(property);
    			case "QualifiedCref": return this.PruneQualifiedCrefSelector(property);
    			case "NameMemberCref": return this.PruneNameMemberCrefSelector(property);
    			case "IndexerMemberCref": return this.PruneIndexerMemberCrefSelector(property);
    			case "OperatorMemberCref": return this.PruneOperatorMemberCrefSelector(property);
    			case "ConversionOperatorMemberCref": return this.PruneConversionOperatorMemberCrefSelector(property);
    			case "CrefParameterList": return this.PruneCrefParameterListSelector(property);
    			case "CrefBracketedParameterList": return this.PruneCrefBracketedParameterListSelector(property);
    			case "XmlElement": return this.PruneXmlElementSelector(property);
    			case "XmlEmptyElement": return this.PruneXmlEmptyElementSelector(property);
    			case "XmlText": return this.PruneXmlTextSelector(property);
    			case "XmlCDataSection": return this.PruneXmlCDataSectionSelector(property);
    			case "XmlProcessingInstruction": return this.PruneXmlProcessingInstructionSelector(property);
    			case "XmlComment": return this.PruneXmlCommentSelector(property);
    			case "XmlTextAttribute": return this.PruneXmlTextAttributeSelector(property);
    			case "XmlCrefAttribute": return this.PruneXmlCrefAttributeSelector(property);
    			case "XmlNameAttribute": return this.PruneXmlNameAttributeSelector(property);
    			case "ParenthesizedExpression": return this.PruneParenthesizedExpressionSelector(property);
    			case "TupleExpression": return this.PruneTupleExpressionSelector(property);
    			case "PrefixUnaryExpression": return this.PrunePrefixUnaryExpressionSelector(property);
    			case "AwaitExpression": return this.PruneAwaitExpressionSelector(property);
    			case "PostfixUnaryExpression": return this.PrunePostfixUnaryExpressionSelector(property);
    			case "MemberAccessExpression": return this.PruneMemberAccessExpressionSelector(property);
    			case "ConditionalAccessExpression": return this.PruneConditionalAccessExpressionSelector(property);
    			case "MemberBindingExpression": return this.PruneMemberBindingExpressionSelector(property);
    			case "ElementBindingExpression": return this.PruneElementBindingExpressionSelector(property);
    			case "ImplicitElementAccess": return this.PruneImplicitElementAccessSelector(property);
    			case "BinaryExpression": return this.PruneBinaryExpressionSelector(property);
    			case "AssignmentExpression": return this.PruneAssignmentExpressionSelector(property);
    			case "ConditionalExpression": return this.PruneConditionalExpressionSelector(property);
    			case "LiteralExpression": return this.PruneLiteralExpressionSelector(property);
    			case "MakeRefExpression": return this.PruneMakeRefExpressionSelector(property);
    			case "RefTypeExpression": return this.PruneRefTypeExpressionSelector(property);
    			case "RefValueExpression": return this.PruneRefValueExpressionSelector(property);
    			case "CheckedExpression": return this.PruneCheckedExpressionSelector(property);
    			case "DefaultExpression": return this.PruneDefaultExpressionSelector(property);
    			case "TypeOfExpression": return this.PruneTypeOfExpressionSelector(property);
    			case "SizeOfExpression": return this.PruneSizeOfExpressionSelector(property);
    			case "InvocationExpression": return this.PruneInvocationExpressionSelector(property);
    			case "ElementAccessExpression": return this.PruneElementAccessExpressionSelector(property);
    			case "DeclarationExpression": return this.PruneDeclarationExpressionSelector(property);
    			case "CastExpression": return this.PruneCastExpressionSelector(property);
    			case "RefExpression": return this.PruneRefExpressionSelector(property);
    			case "InitializerExpression": return this.PruneInitializerExpressionSelector(property);
    			case "ObjectCreationExpression": return this.PruneObjectCreationExpressionSelector(property);
    			case "AnonymousObjectCreationExpression": return this.PruneAnonymousObjectCreationExpressionSelector(property);
    			case "ArrayCreationExpression": return this.PruneArrayCreationExpressionSelector(property);
    			case "ImplicitArrayCreationExpression": return this.PruneImplicitArrayCreationExpressionSelector(property);
    			case "StackAllocArrayCreationExpression": return this.PruneStackAllocArrayCreationExpressionSelector(property);
    			case "QueryExpression": return this.PruneQueryExpressionSelector(property);
    			case "OmittedArraySizeExpression": return this.PruneOmittedArraySizeExpressionSelector(property);
    			case "InterpolatedStringExpression": return this.PruneInterpolatedStringExpressionSelector(property);
    			case "IsPatternExpression": return this.PruneIsPatternExpressionSelector(property);
    			case "ThrowExpression": return this.PruneThrowExpressionSelector(property);
    			case "PredefinedType": return this.PrunePredefinedTypeSelector(property);
    			case "ArrayType": return this.PruneArrayTypeSelector(property);
    			case "PointerType": return this.PrunePointerTypeSelector(property);
    			case "NullableType": return this.PruneNullableTypeSelector(property);
    			case "TupleType": return this.PruneTupleTypeSelector(property);
    			case "OmittedTypeArgument": return this.PruneOmittedTypeArgumentSelector(property);
    			case "RefType": return this.PruneRefTypeSelector(property);
    			case "QualifiedName": return this.PruneQualifiedNameSelector(property);
    			case "AliasQualifiedName": return this.PruneAliasQualifiedNameSelector(property);
    			case "IdentifierName": return this.PruneIdentifierNameSelector(property);
    			case "GenericName": return this.PruneGenericNameSelector(property);
    			case "ThisExpression": return this.PruneThisExpressionSelector(property);
    			case "BaseExpression": return this.PruneBaseExpressionSelector(property);
    			case "AnonymousMethodExpression": return this.PruneAnonymousMethodExpressionSelector(property);
    			case "SimpleLambdaExpression": return this.PruneSimpleLambdaExpressionSelector(property);
    			case "ParenthesizedLambdaExpression": return this.PruneParenthesizedLambdaExpressionSelector(property);
    			case "ArgumentList": return this.PruneArgumentListSelector(property);
    			case "BracketedArgumentList": return this.PruneBracketedArgumentListSelector(property);
    			case "FromClause": return this.PruneFromClauseSelector(property);
    			case "LetClause": return this.PruneLetClauseSelector(property);
    			case "JoinClause": return this.PruneJoinClauseSelector(property);
    			case "WhereClause": return this.PruneWhereClauseSelector(property);
    			case "OrderByClause": return this.PruneOrderByClauseSelector(property);
    			case "SelectClause": return this.PruneSelectClauseSelector(property);
    			case "GroupClause": return this.PruneGroupClauseSelector(property);
    			case "DeclarationPattern": return this.PruneDeclarationPatternSelector(property);
    			case "ConstantPattern": return this.PruneConstantPatternSelector(property);
    			case "InterpolatedStringText": return this.PruneInterpolatedStringTextSelector(property);
    			case "Interpolation": return this.PruneInterpolationSelector(property);
    			case "Block": return this.PruneBlockSelector(property);
    			case "LocalFunctionStatement": return this.PruneLocalFunctionStatementSelector(property);
    			case "LocalDeclarationStatement": return this.PruneLocalDeclarationStatementSelector(property);
    			case "ExpressionStatement": return this.PruneExpressionStatementSelector(property);
    			case "EmptyStatement": return this.PruneEmptyStatementSelector(property);
    			case "LabeledStatement": return this.PruneLabeledStatementSelector(property);
    			case "GotoStatement": return this.PruneGotoStatementSelector(property);
    			case "BreakStatement": return this.PruneBreakStatementSelector(property);
    			case "ContinueStatement": return this.PruneContinueStatementSelector(property);
    			case "ReturnStatement": return this.PruneReturnStatementSelector(property);
    			case "ThrowStatement": return this.PruneThrowStatementSelector(property);
    			case "YieldStatement": return this.PruneYieldStatementSelector(property);
    			case "WhileStatement": return this.PruneWhileStatementSelector(property);
    			case "DoStatement": return this.PruneDoStatementSelector(property);
    			case "ForStatement": return this.PruneForStatementSelector(property);
    			case "UsingStatement": return this.PruneUsingStatementSelector(property);
    			case "FixedStatement": return this.PruneFixedStatementSelector(property);
    			case "CheckedStatement": return this.PruneCheckedStatementSelector(property);
    			case "UnsafeStatement": return this.PruneUnsafeStatementSelector(property);
    			case "LockStatement": return this.PruneLockStatementSelector(property);
    			case "IfStatement": return this.PruneIfStatementSelector(property);
    			case "SwitchStatement": return this.PruneSwitchStatementSelector(property);
    			case "TryStatement": return this.PruneTryStatementSelector(property);
    			case "ForEachStatement": return this.PruneForEachStatementSelector(property);
    			case "ForEachVariableStatement": return this.PruneForEachVariableStatementSelector(property);
    			case "SingleVariableDesignation": return this.PruneSingleVariableDesignationSelector(property);
    			case "DiscardDesignation": return this.PruneDiscardDesignationSelector(property);
    			case "ParenthesizedVariableDesignation": return this.PruneParenthesizedVariableDesignationSelector(property);
    			case "CasePatternSwitchLabel": return this.PruneCasePatternSwitchLabelSelector(property);
    			case "CaseSwitchLabel": return this.PruneCaseSwitchLabelSelector(property);
    			case "DefaultSwitchLabel": return this.PruneDefaultSwitchLabelSelector(property);
    			default: return true;//throw new ArgumentException($"The type {property.Parent.Name.LocalName} has not been found.");
    		}
    	}		
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneSelectorCore(property);
    		PruneSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneAttributeArgumentSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneAttributeArgumentSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneAttributeArgumentSelectorCore(XElement)"/> is not executed and <see cref="PruneAttributeArgumentSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneAttributeArgumentSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneAttributeArgumentSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneAttributeArgumentSelectorCore(XElement)"/>.</param>
        partial void PruneAttributeArgumentSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneAttributeArgumentSelector(XElement)"/>.</remarks>
        public virtual bool PruneAttributeArgumentSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneAttributeArgumentSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneAttributeArgumentSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneAttributeArgumentSelectorCore(property);
    		PruneAttributeArgumentSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneNameEqualsSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneNameEqualsSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneNameEqualsSelectorCore(XElement)"/> is not executed and <see cref="PruneNameEqualsSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneNameEqualsSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneNameEqualsSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneNameEqualsSelectorCore(XElement)"/>.</param>
        partial void PruneNameEqualsSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneNameEqualsSelector(XElement)"/>.</remarks>
        public virtual bool PruneNameEqualsSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "EqualsToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneNameEqualsSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneNameEqualsSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneNameEqualsSelectorCore(property);
    		PruneNameEqualsSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneTypeParameterListSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneTypeParameterListSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneTypeParameterListSelectorCore(XElement)"/> is not executed and <see cref="PruneTypeParameterListSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneTypeParameterListSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneTypeParameterListSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneTypeParameterListSelectorCore(XElement)"/>.</param>
        partial void PruneTypeParameterListSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneTypeParameterListSelector(XElement)"/>.</remarks>
        public virtual bool PruneTypeParameterListSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "LessThanToken")
    			return false;
    		if(property.Attribute("part")?.Value == "GreaterThanToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneTypeParameterListSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneTypeParameterListSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneTypeParameterListSelectorCore(property);
    		PruneTypeParameterListSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneTypeParameterSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneTypeParameterSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneTypeParameterSelectorCore(XElement)"/> is not executed and <see cref="PruneTypeParameterSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneTypeParameterSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneTypeParameterSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneTypeParameterSelectorCore(XElement)"/>.</param>
        partial void PruneTypeParameterSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneTypeParameterSelector(XElement)"/>.</remarks>
        public virtual bool PruneTypeParameterSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "VarianceKeyword")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneTypeParameterSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneTypeParameterSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneTypeParameterSelectorCore(property);
    		PruneTypeParameterSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneBaseListSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneBaseListSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneBaseListSelectorCore(XElement)"/> is not executed and <see cref="PruneBaseListSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBaseListSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneBaseListSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneBaseListSelectorCore(XElement)"/>.</param>
        partial void PruneBaseListSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneBaseListSelector(XElement)"/>.</remarks>
        public virtual bool PruneBaseListSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "ColonToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneBaseListSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBaseListSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneBaseListSelectorCore(property);
    		PruneBaseListSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneTypeParameterConstraintClauseSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneTypeParameterConstraintClauseSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneTypeParameterConstraintClauseSelectorCore(XElement)"/> is not executed and <see cref="PruneTypeParameterConstraintClauseSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneTypeParameterConstraintClauseSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneTypeParameterConstraintClauseSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneTypeParameterConstraintClauseSelectorCore(XElement)"/>.</param>
        partial void PruneTypeParameterConstraintClauseSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneTypeParameterConstraintClauseSelector(XElement)"/>.</remarks>
        public virtual bool PruneTypeParameterConstraintClauseSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "WhereKeyword")
    			return false;
    		if(property.Attribute("part")?.Value == "ColonToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneTypeParameterConstraintClauseSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneTypeParameterConstraintClauseSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneTypeParameterConstraintClauseSelectorCore(property);
    		PruneTypeParameterConstraintClauseSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneExplicitInterfaceSpecifierSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneExplicitInterfaceSpecifierSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneExplicitInterfaceSpecifierSelectorCore(XElement)"/> is not executed and <see cref="PruneExplicitInterfaceSpecifierSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneExplicitInterfaceSpecifierSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneExplicitInterfaceSpecifierSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneExplicitInterfaceSpecifierSelectorCore(XElement)"/>.</param>
        partial void PruneExplicitInterfaceSpecifierSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneExplicitInterfaceSpecifierSelector(XElement)"/>.</remarks>
        public virtual bool PruneExplicitInterfaceSpecifierSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "DotToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneExplicitInterfaceSpecifierSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneExplicitInterfaceSpecifierSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneExplicitInterfaceSpecifierSelectorCore(property);
    		PruneExplicitInterfaceSpecifierSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneConstructorInitializerSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneConstructorInitializerSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneConstructorInitializerSelectorCore(XElement)"/> is not executed and <see cref="PruneConstructorInitializerSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneConstructorInitializerSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneConstructorInitializerSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneConstructorInitializerSelectorCore(XElement)"/>.</param>
        partial void PruneConstructorInitializerSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneConstructorInitializerSelector(XElement)"/>.</remarks>
        public virtual bool PruneConstructorInitializerSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "ColonToken")
    			return false;
    		if(property.Attribute("part")?.Value == "ThisOrBaseKeyword")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneConstructorInitializerSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneConstructorInitializerSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneConstructorInitializerSelectorCore(property);
    		PruneConstructorInitializerSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneArrowExpressionClauseSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneArrowExpressionClauseSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneArrowExpressionClauseSelectorCore(XElement)"/> is not executed and <see cref="PruneArrowExpressionClauseSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneArrowExpressionClauseSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneArrowExpressionClauseSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneArrowExpressionClauseSelectorCore(XElement)"/>.</param>
        partial void PruneArrowExpressionClauseSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneArrowExpressionClauseSelector(XElement)"/>.</remarks>
        public virtual bool PruneArrowExpressionClauseSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "ArrowToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneArrowExpressionClauseSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneArrowExpressionClauseSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneArrowExpressionClauseSelectorCore(property);
    		PruneArrowExpressionClauseSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneAccessorListSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneAccessorListSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneAccessorListSelectorCore(XElement)"/> is not executed and <see cref="PruneAccessorListSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneAccessorListSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneAccessorListSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneAccessorListSelectorCore(XElement)"/>.</param>
        partial void PruneAccessorListSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneAccessorListSelector(XElement)"/>.</remarks>
        public virtual bool PruneAccessorListSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "OpenBraceToken")
    			return false;
    		if(property.Attribute("part")?.Value == "CloseBraceToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneAccessorListSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneAccessorListSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneAccessorListSelectorCore(property);
    		PruneAccessorListSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneAccessorDeclarationSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneAccessorDeclarationSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneAccessorDeclarationSelectorCore(XElement)"/> is not executed and <see cref="PruneAccessorDeclarationSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneAccessorDeclarationSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneAccessorDeclarationSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneAccessorDeclarationSelectorCore(XElement)"/>.</param>
        partial void PruneAccessorDeclarationSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneAccessorDeclarationSelector(XElement)"/>.</remarks>
        public virtual bool PruneAccessorDeclarationSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "SemicolonToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneAccessorDeclarationSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneAccessorDeclarationSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneAccessorDeclarationSelectorCore(property);
    		PruneAccessorDeclarationSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneParameterSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneParameterSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneParameterSelectorCore(XElement)"/> is not executed and <see cref="PruneParameterSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneParameterSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneParameterSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneParameterSelectorCore(XElement)"/>.</param>
        partial void PruneParameterSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneParameterSelector(XElement)"/>.</remarks>
        public virtual bool PruneParameterSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneParameterSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneParameterSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneParameterSelectorCore(property);
    		PruneParameterSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneCrefParameterSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneCrefParameterSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCrefParameterSelectorCore(XElement)"/> is not executed and <see cref="PruneCrefParameterSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneCrefParameterSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCrefParameterSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneCrefParameterSelectorCore(XElement)"/>.</param>
        partial void PruneCrefParameterSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneCrefParameterSelector(XElement)"/>.</remarks>
        public virtual bool PruneCrefParameterSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "RefKindKeyword")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneCrefParameterSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneCrefParameterSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCrefParameterSelectorCore(property);
    		PruneCrefParameterSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneXmlElementStartTagSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneXmlElementStartTagSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneXmlElementStartTagSelectorCore(XElement)"/> is not executed and <see cref="PruneXmlElementStartTagSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneXmlElementStartTagSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneXmlElementStartTagSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneXmlElementStartTagSelectorCore(XElement)"/>.</param>
        partial void PruneXmlElementStartTagSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneXmlElementStartTagSelector(XElement)"/>.</remarks>
        public virtual bool PruneXmlElementStartTagSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "LessThanToken")
    			return false;
    		if(property.Attribute("part")?.Value == "GreaterThanToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneXmlElementStartTagSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneXmlElementStartTagSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneXmlElementStartTagSelectorCore(property);
    		PruneXmlElementStartTagSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneXmlElementEndTagSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneXmlElementEndTagSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneXmlElementEndTagSelectorCore(XElement)"/> is not executed and <see cref="PruneXmlElementEndTagSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneXmlElementEndTagSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneXmlElementEndTagSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneXmlElementEndTagSelectorCore(XElement)"/>.</param>
        partial void PruneXmlElementEndTagSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneXmlElementEndTagSelector(XElement)"/>.</remarks>
        public virtual bool PruneXmlElementEndTagSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "LessThanSlashToken")
    			return false;
    		if(property.Attribute("part")?.Value == "GreaterThanToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneXmlElementEndTagSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneXmlElementEndTagSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneXmlElementEndTagSelectorCore(property);
    		PruneXmlElementEndTagSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneXmlNameSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneXmlNameSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneXmlNameSelectorCore(XElement)"/> is not executed and <see cref="PruneXmlNameSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneXmlNameSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneXmlNameSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneXmlNameSelectorCore(XElement)"/>.</param>
        partial void PruneXmlNameSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneXmlNameSelector(XElement)"/>.</remarks>
        public virtual bool PruneXmlNameSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneXmlNameSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneXmlNameSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneXmlNameSelectorCore(property);
    		PruneXmlNameSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneXmlPrefixSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneXmlPrefixSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneXmlPrefixSelectorCore(XElement)"/> is not executed and <see cref="PruneXmlPrefixSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneXmlPrefixSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneXmlPrefixSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneXmlPrefixSelectorCore(XElement)"/>.</param>
        partial void PruneXmlPrefixSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneXmlPrefixSelector(XElement)"/>.</remarks>
        public virtual bool PruneXmlPrefixSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "ColonToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneXmlPrefixSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneXmlPrefixSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneXmlPrefixSelectorCore(property);
    		PruneXmlPrefixSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneTypeArgumentListSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneTypeArgumentListSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneTypeArgumentListSelectorCore(XElement)"/> is not executed and <see cref="PruneTypeArgumentListSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneTypeArgumentListSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneTypeArgumentListSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneTypeArgumentListSelectorCore(XElement)"/>.</param>
        partial void PruneTypeArgumentListSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneTypeArgumentListSelector(XElement)"/>.</remarks>
        public virtual bool PruneTypeArgumentListSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "LessThanToken")
    			return false;
    		if(property.Attribute("part")?.Value == "GreaterThanToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneTypeArgumentListSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneTypeArgumentListSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneTypeArgumentListSelectorCore(property);
    		PruneTypeArgumentListSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneArrayRankSpecifierSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneArrayRankSpecifierSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneArrayRankSpecifierSelectorCore(XElement)"/> is not executed and <see cref="PruneArrayRankSpecifierSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneArrayRankSpecifierSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneArrayRankSpecifierSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneArrayRankSpecifierSelectorCore(XElement)"/>.</param>
        partial void PruneArrayRankSpecifierSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneArrayRankSpecifierSelector(XElement)"/>.</remarks>
        public virtual bool PruneArrayRankSpecifierSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "OpenBracketToken")
    			return false;
    		if(property.Attribute("part")?.Value == "CloseBracketToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneArrayRankSpecifierSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneArrayRankSpecifierSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneArrayRankSpecifierSelectorCore(property);
    		PruneArrayRankSpecifierSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneTupleElementSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneTupleElementSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneTupleElementSelectorCore(XElement)"/> is not executed and <see cref="PruneTupleElementSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneTupleElementSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneTupleElementSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneTupleElementSelectorCore(XElement)"/>.</param>
        partial void PruneTupleElementSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneTupleElementSelector(XElement)"/>.</remarks>
        public virtual bool PruneTupleElementSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneTupleElementSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneTupleElementSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneTupleElementSelectorCore(property);
    		PruneTupleElementSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneArgumentSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneArgumentSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneArgumentSelectorCore(XElement)"/> is not executed and <see cref="PruneArgumentSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneArgumentSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneArgumentSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneArgumentSelectorCore(XElement)"/>.</param>
        partial void PruneArgumentSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneArgumentSelector(XElement)"/>.</remarks>
        public virtual bool PruneArgumentSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "RefKindKeyword")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneArgumentSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneArgumentSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneArgumentSelectorCore(property);
    		PruneArgumentSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneNameColonSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneNameColonSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneNameColonSelectorCore(XElement)"/> is not executed and <see cref="PruneNameColonSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneNameColonSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneNameColonSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneNameColonSelectorCore(XElement)"/>.</param>
        partial void PruneNameColonSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneNameColonSelector(XElement)"/>.</remarks>
        public virtual bool PruneNameColonSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "ColonToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneNameColonSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneNameColonSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneNameColonSelectorCore(property);
    		PruneNameColonSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneAnonymousObjectMemberDeclaratorSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneAnonymousObjectMemberDeclaratorSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneAnonymousObjectMemberDeclaratorSelectorCore(XElement)"/> is not executed and <see cref="PruneAnonymousObjectMemberDeclaratorSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneAnonymousObjectMemberDeclaratorSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneAnonymousObjectMemberDeclaratorSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneAnonymousObjectMemberDeclaratorSelectorCore(XElement)"/>.</param>
        partial void PruneAnonymousObjectMemberDeclaratorSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneAnonymousObjectMemberDeclaratorSelector(XElement)"/>.</remarks>
        public virtual bool PruneAnonymousObjectMemberDeclaratorSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneAnonymousObjectMemberDeclaratorSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneAnonymousObjectMemberDeclaratorSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneAnonymousObjectMemberDeclaratorSelectorCore(property);
    		PruneAnonymousObjectMemberDeclaratorSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneQueryBodySelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneQueryBodySelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneQueryBodySelectorCore(XElement)"/> is not executed and <see cref="PruneQueryBodySelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneQueryBodySelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneQueryBodySelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneQueryBodySelectorCore(XElement)"/>.</param>
        partial void PruneQueryBodySelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneQueryBodySelector(XElement)"/>.</remarks>
        public virtual bool PruneQueryBodySelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneQueryBodySelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneQueryBodySelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneQueryBodySelectorCore(property);
    		PruneQueryBodySelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneJoinIntoClauseSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneJoinIntoClauseSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneJoinIntoClauseSelectorCore(XElement)"/> is not executed and <see cref="PruneJoinIntoClauseSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneJoinIntoClauseSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneJoinIntoClauseSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneJoinIntoClauseSelectorCore(XElement)"/>.</param>
        partial void PruneJoinIntoClauseSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneJoinIntoClauseSelector(XElement)"/>.</remarks>
        public virtual bool PruneJoinIntoClauseSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "IntoKeyword")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneJoinIntoClauseSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneJoinIntoClauseSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneJoinIntoClauseSelectorCore(property);
    		PruneJoinIntoClauseSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneOrderingSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneOrderingSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneOrderingSelectorCore(XElement)"/> is not executed and <see cref="PruneOrderingSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneOrderingSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneOrderingSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneOrderingSelectorCore(XElement)"/>.</param>
        partial void PruneOrderingSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneOrderingSelector(XElement)"/>.</remarks>
        public virtual bool PruneOrderingSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "AscendingOrDescendingKeyword")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneOrderingSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneOrderingSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneOrderingSelectorCore(property);
    		PruneOrderingSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneQueryContinuationSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneQueryContinuationSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneQueryContinuationSelectorCore(XElement)"/> is not executed and <see cref="PruneQueryContinuationSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneQueryContinuationSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneQueryContinuationSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneQueryContinuationSelectorCore(XElement)"/>.</param>
        partial void PruneQueryContinuationSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneQueryContinuationSelector(XElement)"/>.</remarks>
        public virtual bool PruneQueryContinuationSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "IntoKeyword")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneQueryContinuationSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneQueryContinuationSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneQueryContinuationSelectorCore(property);
    		PruneQueryContinuationSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneWhenClauseSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneWhenClauseSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneWhenClauseSelectorCore(XElement)"/> is not executed and <see cref="PruneWhenClauseSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneWhenClauseSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneWhenClauseSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneWhenClauseSelectorCore(XElement)"/>.</param>
        partial void PruneWhenClauseSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneWhenClauseSelector(XElement)"/>.</remarks>
        public virtual bool PruneWhenClauseSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "WhenKeyword")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneWhenClauseSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneWhenClauseSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneWhenClauseSelectorCore(property);
    		PruneWhenClauseSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneInterpolationAlignmentClauseSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneInterpolationAlignmentClauseSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneInterpolationAlignmentClauseSelectorCore(XElement)"/> is not executed and <see cref="PruneInterpolationAlignmentClauseSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneInterpolationAlignmentClauseSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneInterpolationAlignmentClauseSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneInterpolationAlignmentClauseSelectorCore(XElement)"/>.</param>
        partial void PruneInterpolationAlignmentClauseSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneInterpolationAlignmentClauseSelector(XElement)"/>.</remarks>
        public virtual bool PruneInterpolationAlignmentClauseSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "CommaToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneInterpolationAlignmentClauseSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneInterpolationAlignmentClauseSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneInterpolationAlignmentClauseSelectorCore(property);
    		PruneInterpolationAlignmentClauseSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneInterpolationFormatClauseSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneInterpolationFormatClauseSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneInterpolationFormatClauseSelectorCore(XElement)"/> is not executed and <see cref="PruneInterpolationFormatClauseSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneInterpolationFormatClauseSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneInterpolationFormatClauseSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneInterpolationFormatClauseSelectorCore(XElement)"/>.</param>
        partial void PruneInterpolationFormatClauseSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneInterpolationFormatClauseSelector(XElement)"/>.</remarks>
        public virtual bool PruneInterpolationFormatClauseSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "ColonToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneInterpolationFormatClauseSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneInterpolationFormatClauseSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneInterpolationFormatClauseSelectorCore(property);
    		PruneInterpolationFormatClauseSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneVariableDeclarationSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneVariableDeclarationSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneVariableDeclarationSelectorCore(XElement)"/> is not executed and <see cref="PruneVariableDeclarationSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneVariableDeclarationSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneVariableDeclarationSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneVariableDeclarationSelectorCore(XElement)"/>.</param>
        partial void PruneVariableDeclarationSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneVariableDeclarationSelector(XElement)"/>.</remarks>
        public virtual bool PruneVariableDeclarationSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneVariableDeclarationSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneVariableDeclarationSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneVariableDeclarationSelectorCore(property);
    		PruneVariableDeclarationSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneVariableDeclaratorSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneVariableDeclaratorSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneVariableDeclaratorSelectorCore(XElement)"/> is not executed and <see cref="PruneVariableDeclaratorSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneVariableDeclaratorSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneVariableDeclaratorSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneVariableDeclaratorSelectorCore(XElement)"/>.</param>
        partial void PruneVariableDeclaratorSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneVariableDeclaratorSelector(XElement)"/>.</remarks>
        public virtual bool PruneVariableDeclaratorSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneVariableDeclaratorSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneVariableDeclaratorSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneVariableDeclaratorSelectorCore(property);
    		PruneVariableDeclaratorSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneEqualsValueClauseSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneEqualsValueClauseSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneEqualsValueClauseSelectorCore(XElement)"/> is not executed and <see cref="PruneEqualsValueClauseSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneEqualsValueClauseSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneEqualsValueClauseSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneEqualsValueClauseSelectorCore(XElement)"/>.</param>
        partial void PruneEqualsValueClauseSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneEqualsValueClauseSelector(XElement)"/>.</remarks>
        public virtual bool PruneEqualsValueClauseSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "EqualsToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneEqualsValueClauseSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneEqualsValueClauseSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneEqualsValueClauseSelectorCore(property);
    		PruneEqualsValueClauseSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneElseClauseSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneElseClauseSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneElseClauseSelectorCore(XElement)"/> is not executed and <see cref="PruneElseClauseSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneElseClauseSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneElseClauseSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneElseClauseSelectorCore(XElement)"/>.</param>
        partial void PruneElseClauseSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneElseClauseSelector(XElement)"/>.</remarks>
        public virtual bool PruneElseClauseSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "ElseKeyword")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneElseClauseSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneElseClauseSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneElseClauseSelectorCore(property);
    		PruneElseClauseSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneSwitchSectionSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneSwitchSectionSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneSwitchSectionSelectorCore(XElement)"/> is not executed and <see cref="PruneSwitchSectionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneSwitchSectionSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneSwitchSectionSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneSwitchSectionSelectorCore(XElement)"/>.</param>
        partial void PruneSwitchSectionSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneSwitchSectionSelector(XElement)"/>.</remarks>
        public virtual bool PruneSwitchSectionSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneSwitchSectionSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneSwitchSectionSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneSwitchSectionSelectorCore(property);
    		PruneSwitchSectionSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneCatchClauseSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneCatchClauseSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCatchClauseSelectorCore(XElement)"/> is not executed and <see cref="PruneCatchClauseSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneCatchClauseSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCatchClauseSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneCatchClauseSelectorCore(XElement)"/>.</param>
        partial void PruneCatchClauseSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneCatchClauseSelector(XElement)"/>.</remarks>
        public virtual bool PruneCatchClauseSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "CatchKeyword")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneCatchClauseSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneCatchClauseSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCatchClauseSelectorCore(property);
    		PruneCatchClauseSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneCatchDeclarationSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneCatchDeclarationSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCatchDeclarationSelectorCore(XElement)"/> is not executed and <see cref="PruneCatchDeclarationSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneCatchDeclarationSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCatchDeclarationSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneCatchDeclarationSelectorCore(XElement)"/>.</param>
        partial void PruneCatchDeclarationSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneCatchDeclarationSelector(XElement)"/>.</remarks>
        public virtual bool PruneCatchDeclarationSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "OpenParenToken")
    			return false;
    		if(property.Attribute("part")?.Value == "CloseParenToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneCatchDeclarationSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneCatchDeclarationSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCatchDeclarationSelectorCore(property);
    		PruneCatchDeclarationSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneCatchFilterClauseSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneCatchFilterClauseSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCatchFilterClauseSelectorCore(XElement)"/> is not executed and <see cref="PruneCatchFilterClauseSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneCatchFilterClauseSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCatchFilterClauseSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneCatchFilterClauseSelectorCore(XElement)"/>.</param>
        partial void PruneCatchFilterClauseSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneCatchFilterClauseSelector(XElement)"/>.</remarks>
        public virtual bool PruneCatchFilterClauseSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "WhenKeyword")
    			return false;
    		if(property.Attribute("part")?.Value == "OpenParenToken")
    			return false;
    		if(property.Attribute("part")?.Value == "CloseParenToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneCatchFilterClauseSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneCatchFilterClauseSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCatchFilterClauseSelectorCore(property);
    		PruneCatchFilterClauseSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneFinallyClauseSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneFinallyClauseSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneFinallyClauseSelectorCore(XElement)"/> is not executed and <see cref="PruneFinallyClauseSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneFinallyClauseSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneFinallyClauseSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneFinallyClauseSelectorCore(XElement)"/>.</param>
        partial void PruneFinallyClauseSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneFinallyClauseSelector(XElement)"/>.</remarks>
        public virtual bool PruneFinallyClauseSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "FinallyKeyword")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneFinallyClauseSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneFinallyClauseSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneFinallyClauseSelectorCore(property);
    		PruneFinallyClauseSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneCompilationUnitSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneCompilationUnitSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCompilationUnitSelectorCore(XElement)"/> is not executed and <see cref="PruneCompilationUnitSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneCompilationUnitSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCompilationUnitSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneCompilationUnitSelectorCore(XElement)"/>.</param>
        partial void PruneCompilationUnitSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneCompilationUnitSelector(XElement)"/>.</remarks>
        public virtual bool PruneCompilationUnitSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "EndOfFileToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneCompilationUnitSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneCompilationUnitSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCompilationUnitSelectorCore(property);
    		PruneCompilationUnitSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneExternAliasDirectiveSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneExternAliasDirectiveSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneExternAliasDirectiveSelectorCore(XElement)"/> is not executed and <see cref="PruneExternAliasDirectiveSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneExternAliasDirectiveSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneExternAliasDirectiveSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneExternAliasDirectiveSelectorCore(XElement)"/>.</param>
        partial void PruneExternAliasDirectiveSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneExternAliasDirectiveSelector(XElement)"/>.</remarks>
        public virtual bool PruneExternAliasDirectiveSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "ExternKeyword")
    			return false;
    		if(property.Attribute("part")?.Value == "AliasKeyword")
    			return false;
    		if(property.Attribute("part")?.Value == "SemicolonToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneExternAliasDirectiveSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneExternAliasDirectiveSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneExternAliasDirectiveSelectorCore(property);
    		PruneExternAliasDirectiveSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneUsingDirectiveSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneUsingDirectiveSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneUsingDirectiveSelectorCore(XElement)"/> is not executed and <see cref="PruneUsingDirectiveSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneUsingDirectiveSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneUsingDirectiveSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneUsingDirectiveSelectorCore(XElement)"/>.</param>
        partial void PruneUsingDirectiveSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneUsingDirectiveSelector(XElement)"/>.</remarks>
        public virtual bool PruneUsingDirectiveSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "UsingKeyword")
    			return false;
    		if(property.Attribute("part")?.Value == "StaticKeyword")
    			return false;
    		if(property.Attribute("part")?.Value == "SemicolonToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneUsingDirectiveSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneUsingDirectiveSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneUsingDirectiveSelectorCore(property);
    		PruneUsingDirectiveSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneAttributeListSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneAttributeListSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneAttributeListSelectorCore(XElement)"/> is not executed and <see cref="PruneAttributeListSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneAttributeListSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneAttributeListSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneAttributeListSelectorCore(XElement)"/>.</param>
        partial void PruneAttributeListSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneAttributeListSelector(XElement)"/>.</remarks>
        public virtual bool PruneAttributeListSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "OpenBracketToken")
    			return false;
    		if(property.Attribute("part")?.Value == "CloseBracketToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneAttributeListSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneAttributeListSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneAttributeListSelectorCore(property);
    		PruneAttributeListSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneAttributeTargetSpecifierSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneAttributeTargetSpecifierSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneAttributeTargetSpecifierSelectorCore(XElement)"/> is not executed and <see cref="PruneAttributeTargetSpecifierSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneAttributeTargetSpecifierSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneAttributeTargetSpecifierSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneAttributeTargetSpecifierSelectorCore(XElement)"/>.</param>
        partial void PruneAttributeTargetSpecifierSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneAttributeTargetSpecifierSelector(XElement)"/>.</remarks>
        public virtual bool PruneAttributeTargetSpecifierSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "ColonToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneAttributeTargetSpecifierSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneAttributeTargetSpecifierSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneAttributeTargetSpecifierSelectorCore(property);
    		PruneAttributeTargetSpecifierSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneAttributeSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneAttributeSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneAttributeSelectorCore(XElement)"/> is not executed and <see cref="PruneAttributeSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneAttributeSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneAttributeSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneAttributeSelectorCore(XElement)"/>.</param>
        partial void PruneAttributeSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneAttributeSelector(XElement)"/>.</remarks>
        public virtual bool PruneAttributeSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneAttributeSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneAttributeSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneAttributeSelectorCore(property);
    		PruneAttributeSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneAttributeArgumentListSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneAttributeArgumentListSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneAttributeArgumentListSelectorCore(XElement)"/> is not executed and <see cref="PruneAttributeArgumentListSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneAttributeArgumentListSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneAttributeArgumentListSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneAttributeArgumentListSelectorCore(XElement)"/>.</param>
        partial void PruneAttributeArgumentListSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneAttributeArgumentListSelector(XElement)"/>.</remarks>
        public virtual bool PruneAttributeArgumentListSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "OpenParenToken")
    			return false;
    		if(property.Attribute("part")?.Value == "CloseParenToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneAttributeArgumentListSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneAttributeArgumentListSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneAttributeArgumentListSelectorCore(property);
    		PruneAttributeArgumentListSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneDelegateDeclarationSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneDelegateDeclarationSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneDelegateDeclarationSelectorCore(XElement)"/> is not executed and <see cref="PruneDelegateDeclarationSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneDelegateDeclarationSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneDelegateDeclarationSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneDelegateDeclarationSelectorCore(XElement)"/>.</param>
        partial void PruneDelegateDeclarationSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneDelegateDeclarationSelector(XElement)"/>.</remarks>
        public virtual bool PruneDelegateDeclarationSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "DelegateKeyword")
    			return false;
    		if(property.Attribute("part")?.Value == "SemicolonToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneDelegateDeclarationSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneDelegateDeclarationSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneDelegateDeclarationSelectorCore(property);
    		PruneDelegateDeclarationSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneEnumMemberDeclarationSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneEnumMemberDeclarationSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneEnumMemberDeclarationSelectorCore(XElement)"/> is not executed and <see cref="PruneEnumMemberDeclarationSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneEnumMemberDeclarationSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneEnumMemberDeclarationSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneEnumMemberDeclarationSelectorCore(XElement)"/>.</param>
        partial void PruneEnumMemberDeclarationSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneEnumMemberDeclarationSelector(XElement)"/>.</remarks>
        public virtual bool PruneEnumMemberDeclarationSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneEnumMemberDeclarationSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneEnumMemberDeclarationSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneEnumMemberDeclarationSelectorCore(property);
    		PruneEnumMemberDeclarationSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneIncompleteMemberSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneIncompleteMemberSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneIncompleteMemberSelectorCore(XElement)"/> is not executed and <see cref="PruneIncompleteMemberSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneIncompleteMemberSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneIncompleteMemberSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneIncompleteMemberSelectorCore(XElement)"/>.</param>
        partial void PruneIncompleteMemberSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneIncompleteMemberSelector(XElement)"/>.</remarks>
        public virtual bool PruneIncompleteMemberSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneIncompleteMemberSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneIncompleteMemberSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneIncompleteMemberSelectorCore(property);
    		PruneIncompleteMemberSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneGlobalStatementSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneGlobalStatementSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneGlobalStatementSelectorCore(XElement)"/> is not executed and <see cref="PruneGlobalStatementSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneGlobalStatementSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneGlobalStatementSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneGlobalStatementSelectorCore(XElement)"/>.</param>
        partial void PruneGlobalStatementSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneGlobalStatementSelector(XElement)"/>.</remarks>
        public virtual bool PruneGlobalStatementSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneGlobalStatementSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneGlobalStatementSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneGlobalStatementSelectorCore(property);
    		PruneGlobalStatementSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneNamespaceDeclarationSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneNamespaceDeclarationSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneNamespaceDeclarationSelectorCore(XElement)"/> is not executed and <see cref="PruneNamespaceDeclarationSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneNamespaceDeclarationSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneNamespaceDeclarationSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneNamespaceDeclarationSelectorCore(XElement)"/>.</param>
        partial void PruneNamespaceDeclarationSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneNamespaceDeclarationSelector(XElement)"/>.</remarks>
        public virtual bool PruneNamespaceDeclarationSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "NamespaceKeyword")
    			return false;
    		if(property.Attribute("part")?.Value == "OpenBraceToken")
    			return false;
    		if(property.Attribute("part")?.Value == "CloseBraceToken")
    			return false;
    		if(property.Attribute("part")?.Value == "SemicolonToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneNamespaceDeclarationSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneNamespaceDeclarationSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneNamespaceDeclarationSelectorCore(property);
    		PruneNamespaceDeclarationSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneEnumDeclarationSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneEnumDeclarationSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneEnumDeclarationSelectorCore(XElement)"/> is not executed and <see cref="PruneEnumDeclarationSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneEnumDeclarationSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneEnumDeclarationSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneEnumDeclarationSelectorCore(XElement)"/>.</param>
        partial void PruneEnumDeclarationSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneEnumDeclarationSelector(XElement)"/>.</remarks>
        public virtual bool PruneEnumDeclarationSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "EnumKeyword")
    			return false;
    		if(property.Attribute("part")?.Value == "OpenBraceToken")
    			return false;
    		if(property.Attribute("part")?.Value == "CloseBraceToken")
    			return false;
    		if(property.Attribute("part")?.Value == "SemicolonToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneEnumDeclarationSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneEnumDeclarationSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneEnumDeclarationSelectorCore(property);
    		PruneEnumDeclarationSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneClassDeclarationSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneClassDeclarationSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneClassDeclarationSelectorCore(XElement)"/> is not executed and <see cref="PruneClassDeclarationSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneClassDeclarationSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneClassDeclarationSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneClassDeclarationSelectorCore(XElement)"/>.</param>
        partial void PruneClassDeclarationSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneClassDeclarationSelector(XElement)"/>.</remarks>
        public virtual bool PruneClassDeclarationSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "Keyword")
    			return false;
    		if(property.Attribute("part")?.Value == "OpenBraceToken")
    			return false;
    		if(property.Attribute("part")?.Value == "CloseBraceToken")
    			return false;
    		if(property.Attribute("part")?.Value == "SemicolonToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneClassDeclarationSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneClassDeclarationSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneClassDeclarationSelectorCore(property);
    		PruneClassDeclarationSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneStructDeclarationSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneStructDeclarationSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneStructDeclarationSelectorCore(XElement)"/> is not executed and <see cref="PruneStructDeclarationSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneStructDeclarationSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneStructDeclarationSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneStructDeclarationSelectorCore(XElement)"/>.</param>
        partial void PruneStructDeclarationSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneStructDeclarationSelector(XElement)"/>.</remarks>
        public virtual bool PruneStructDeclarationSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "Keyword")
    			return false;
    		if(property.Attribute("part")?.Value == "OpenBraceToken")
    			return false;
    		if(property.Attribute("part")?.Value == "CloseBraceToken")
    			return false;
    		if(property.Attribute("part")?.Value == "SemicolonToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneStructDeclarationSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneStructDeclarationSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneStructDeclarationSelectorCore(property);
    		PruneStructDeclarationSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneInterfaceDeclarationSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneInterfaceDeclarationSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneInterfaceDeclarationSelectorCore(XElement)"/> is not executed and <see cref="PruneInterfaceDeclarationSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneInterfaceDeclarationSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneInterfaceDeclarationSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneInterfaceDeclarationSelectorCore(XElement)"/>.</param>
        partial void PruneInterfaceDeclarationSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneInterfaceDeclarationSelector(XElement)"/>.</remarks>
        public virtual bool PruneInterfaceDeclarationSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "Keyword")
    			return false;
    		if(property.Attribute("part")?.Value == "OpenBraceToken")
    			return false;
    		if(property.Attribute("part")?.Value == "CloseBraceToken")
    			return false;
    		if(property.Attribute("part")?.Value == "SemicolonToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneInterfaceDeclarationSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneInterfaceDeclarationSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneInterfaceDeclarationSelectorCore(property);
    		PruneInterfaceDeclarationSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneFieldDeclarationSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneFieldDeclarationSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneFieldDeclarationSelectorCore(XElement)"/> is not executed and <see cref="PruneFieldDeclarationSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneFieldDeclarationSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneFieldDeclarationSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneFieldDeclarationSelectorCore(XElement)"/>.</param>
        partial void PruneFieldDeclarationSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneFieldDeclarationSelector(XElement)"/>.</remarks>
        public virtual bool PruneFieldDeclarationSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "SemicolonToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneFieldDeclarationSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneFieldDeclarationSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneFieldDeclarationSelectorCore(property);
    		PruneFieldDeclarationSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneEventFieldDeclarationSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneEventFieldDeclarationSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneEventFieldDeclarationSelectorCore(XElement)"/> is not executed and <see cref="PruneEventFieldDeclarationSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneEventFieldDeclarationSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneEventFieldDeclarationSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneEventFieldDeclarationSelectorCore(XElement)"/>.</param>
        partial void PruneEventFieldDeclarationSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneEventFieldDeclarationSelector(XElement)"/>.</remarks>
        public virtual bool PruneEventFieldDeclarationSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "EventKeyword")
    			return false;
    		if(property.Attribute("part")?.Value == "SemicolonToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneEventFieldDeclarationSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneEventFieldDeclarationSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneEventFieldDeclarationSelectorCore(property);
    		PruneEventFieldDeclarationSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneMethodDeclarationSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneMethodDeclarationSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneMethodDeclarationSelectorCore(XElement)"/> is not executed and <see cref="PruneMethodDeclarationSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneMethodDeclarationSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneMethodDeclarationSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneMethodDeclarationSelectorCore(XElement)"/>.</param>
        partial void PruneMethodDeclarationSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneMethodDeclarationSelector(XElement)"/>.</remarks>
        public virtual bool PruneMethodDeclarationSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "SemicolonToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneMethodDeclarationSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneMethodDeclarationSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneMethodDeclarationSelectorCore(property);
    		PruneMethodDeclarationSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneOperatorDeclarationSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneOperatorDeclarationSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneOperatorDeclarationSelectorCore(XElement)"/> is not executed and <see cref="PruneOperatorDeclarationSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneOperatorDeclarationSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneOperatorDeclarationSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneOperatorDeclarationSelectorCore(XElement)"/>.</param>
        partial void PruneOperatorDeclarationSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneOperatorDeclarationSelector(XElement)"/>.</remarks>
        public virtual bool PruneOperatorDeclarationSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "OperatorKeyword")
    			return false;
    		if(property.Attribute("part")?.Value == "SemicolonToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneOperatorDeclarationSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneOperatorDeclarationSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneOperatorDeclarationSelectorCore(property);
    		PruneOperatorDeclarationSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneConversionOperatorDeclarationSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneConversionOperatorDeclarationSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneConversionOperatorDeclarationSelectorCore(XElement)"/> is not executed and <see cref="PruneConversionOperatorDeclarationSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneConversionOperatorDeclarationSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneConversionOperatorDeclarationSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneConversionOperatorDeclarationSelectorCore(XElement)"/>.</param>
        partial void PruneConversionOperatorDeclarationSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneConversionOperatorDeclarationSelector(XElement)"/>.</remarks>
        public virtual bool PruneConversionOperatorDeclarationSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "ImplicitOrExplicitKeyword")
    			return false;
    		if(property.Attribute("part")?.Value == "OperatorKeyword")
    			return false;
    		if(property.Attribute("part")?.Value == "SemicolonToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneConversionOperatorDeclarationSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneConversionOperatorDeclarationSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneConversionOperatorDeclarationSelectorCore(property);
    		PruneConversionOperatorDeclarationSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneConstructorDeclarationSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneConstructorDeclarationSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneConstructorDeclarationSelectorCore(XElement)"/> is not executed and <see cref="PruneConstructorDeclarationSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneConstructorDeclarationSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneConstructorDeclarationSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneConstructorDeclarationSelectorCore(XElement)"/>.</param>
        partial void PruneConstructorDeclarationSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneConstructorDeclarationSelector(XElement)"/>.</remarks>
        public virtual bool PruneConstructorDeclarationSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "SemicolonToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneConstructorDeclarationSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneConstructorDeclarationSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneConstructorDeclarationSelectorCore(property);
    		PruneConstructorDeclarationSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneDestructorDeclarationSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneDestructorDeclarationSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneDestructorDeclarationSelectorCore(XElement)"/> is not executed and <see cref="PruneDestructorDeclarationSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneDestructorDeclarationSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneDestructorDeclarationSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneDestructorDeclarationSelectorCore(XElement)"/>.</param>
        partial void PruneDestructorDeclarationSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneDestructorDeclarationSelector(XElement)"/>.</remarks>
        public virtual bool PruneDestructorDeclarationSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "TildeToken")
    			return false;
    		if(property.Attribute("part")?.Value == "SemicolonToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneDestructorDeclarationSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneDestructorDeclarationSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneDestructorDeclarationSelectorCore(property);
    		PruneDestructorDeclarationSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PrunePropertyDeclarationSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PrunePropertyDeclarationSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PrunePropertyDeclarationSelectorCore(XElement)"/> is not executed and <see cref="PrunePropertyDeclarationSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PrunePropertyDeclarationSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PrunePropertyDeclarationSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PrunePropertyDeclarationSelectorCore(XElement)"/>.</param>
        partial void PrunePropertyDeclarationSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PrunePropertyDeclarationSelector(XElement)"/>.</remarks>
        public virtual bool PrunePropertyDeclarationSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "SemicolonToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PrunePropertyDeclarationSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PrunePropertyDeclarationSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PrunePropertyDeclarationSelectorCore(property);
    		PrunePropertyDeclarationSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneEventDeclarationSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneEventDeclarationSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneEventDeclarationSelectorCore(XElement)"/> is not executed and <see cref="PruneEventDeclarationSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneEventDeclarationSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneEventDeclarationSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneEventDeclarationSelectorCore(XElement)"/>.</param>
        partial void PruneEventDeclarationSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneEventDeclarationSelector(XElement)"/>.</remarks>
        public virtual bool PruneEventDeclarationSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "EventKeyword")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneEventDeclarationSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneEventDeclarationSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneEventDeclarationSelectorCore(property);
    		PruneEventDeclarationSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneIndexerDeclarationSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneIndexerDeclarationSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneIndexerDeclarationSelectorCore(XElement)"/> is not executed and <see cref="PruneIndexerDeclarationSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneIndexerDeclarationSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneIndexerDeclarationSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneIndexerDeclarationSelectorCore(XElement)"/>.</param>
        partial void PruneIndexerDeclarationSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneIndexerDeclarationSelector(XElement)"/>.</remarks>
        public virtual bool PruneIndexerDeclarationSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "ThisKeyword")
    			return false;
    		if(property.Attribute("part")?.Value == "SemicolonToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneIndexerDeclarationSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneIndexerDeclarationSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneIndexerDeclarationSelectorCore(property);
    		PruneIndexerDeclarationSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneSimpleBaseTypeSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneSimpleBaseTypeSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneSimpleBaseTypeSelectorCore(XElement)"/> is not executed and <see cref="PruneSimpleBaseTypeSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneSimpleBaseTypeSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneSimpleBaseTypeSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneSimpleBaseTypeSelectorCore(XElement)"/>.</param>
        partial void PruneSimpleBaseTypeSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneSimpleBaseTypeSelector(XElement)"/>.</remarks>
        public virtual bool PruneSimpleBaseTypeSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneSimpleBaseTypeSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneSimpleBaseTypeSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneSimpleBaseTypeSelectorCore(property);
    		PruneSimpleBaseTypeSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneConstructorConstraintSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneConstructorConstraintSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneConstructorConstraintSelectorCore(XElement)"/> is not executed and <see cref="PruneConstructorConstraintSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneConstructorConstraintSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneConstructorConstraintSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneConstructorConstraintSelectorCore(XElement)"/>.</param>
        partial void PruneConstructorConstraintSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneConstructorConstraintSelector(XElement)"/>.</remarks>
        public virtual bool PruneConstructorConstraintSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "NewKeyword")
    			return false;
    		if(property.Attribute("part")?.Value == "OpenParenToken")
    			return false;
    		if(property.Attribute("part")?.Value == "CloseParenToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneConstructorConstraintSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneConstructorConstraintSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneConstructorConstraintSelectorCore(property);
    		PruneConstructorConstraintSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneClassOrStructConstraintSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneClassOrStructConstraintSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneClassOrStructConstraintSelectorCore(XElement)"/> is not executed and <see cref="PruneClassOrStructConstraintSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneClassOrStructConstraintSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneClassOrStructConstraintSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneClassOrStructConstraintSelectorCore(XElement)"/>.</param>
        partial void PruneClassOrStructConstraintSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneClassOrStructConstraintSelector(XElement)"/>.</remarks>
        public virtual bool PruneClassOrStructConstraintSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "ClassOrStructKeyword")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneClassOrStructConstraintSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneClassOrStructConstraintSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneClassOrStructConstraintSelectorCore(property);
    		PruneClassOrStructConstraintSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneTypeConstraintSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneTypeConstraintSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneTypeConstraintSelectorCore(XElement)"/> is not executed and <see cref="PruneTypeConstraintSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneTypeConstraintSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneTypeConstraintSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneTypeConstraintSelectorCore(XElement)"/>.</param>
        partial void PruneTypeConstraintSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneTypeConstraintSelector(XElement)"/>.</remarks>
        public virtual bool PruneTypeConstraintSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneTypeConstraintSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneTypeConstraintSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneTypeConstraintSelectorCore(property);
    		PruneTypeConstraintSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneParameterListSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneParameterListSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneParameterListSelectorCore(XElement)"/> is not executed and <see cref="PruneParameterListSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneParameterListSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneParameterListSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneParameterListSelectorCore(XElement)"/>.</param>
        partial void PruneParameterListSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneParameterListSelector(XElement)"/>.</remarks>
        public virtual bool PruneParameterListSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "OpenParenToken")
    			return false;
    		if(property.Attribute("part")?.Value == "CloseParenToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneParameterListSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneParameterListSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneParameterListSelectorCore(property);
    		PruneParameterListSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneBracketedParameterListSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneBracketedParameterListSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneBracketedParameterListSelectorCore(XElement)"/> is not executed and <see cref="PruneBracketedParameterListSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBracketedParameterListSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneBracketedParameterListSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneBracketedParameterListSelectorCore(XElement)"/>.</param>
        partial void PruneBracketedParameterListSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneBracketedParameterListSelector(XElement)"/>.</remarks>
        public virtual bool PruneBracketedParameterListSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "OpenBracketToken")
    			return false;
    		if(property.Attribute("part")?.Value == "CloseBracketToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneBracketedParameterListSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBracketedParameterListSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneBracketedParameterListSelectorCore(property);
    		PruneBracketedParameterListSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneSkippedTokensTriviaSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneSkippedTokensTriviaSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneSkippedTokensTriviaSelectorCore(XElement)"/> is not executed and <see cref="PruneSkippedTokensTriviaSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneSkippedTokensTriviaSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneSkippedTokensTriviaSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneSkippedTokensTriviaSelectorCore(XElement)"/>.</param>
        partial void PruneSkippedTokensTriviaSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneSkippedTokensTriviaSelector(XElement)"/>.</remarks>
        public virtual bool PruneSkippedTokensTriviaSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneSkippedTokensTriviaSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneSkippedTokensTriviaSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneSkippedTokensTriviaSelectorCore(property);
    		PruneSkippedTokensTriviaSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneDocumentationCommentTriviaSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneDocumentationCommentTriviaSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneDocumentationCommentTriviaSelectorCore(XElement)"/> is not executed and <see cref="PruneDocumentationCommentTriviaSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneDocumentationCommentTriviaSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneDocumentationCommentTriviaSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneDocumentationCommentTriviaSelectorCore(XElement)"/>.</param>
        partial void PruneDocumentationCommentTriviaSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneDocumentationCommentTriviaSelector(XElement)"/>.</remarks>
        public virtual bool PruneDocumentationCommentTriviaSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "EndOfComment")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneDocumentationCommentTriviaSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneDocumentationCommentTriviaSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneDocumentationCommentTriviaSelectorCore(property);
    		PruneDocumentationCommentTriviaSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneEndIfDirectiveTriviaSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneEndIfDirectiveTriviaSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneEndIfDirectiveTriviaSelectorCore(XElement)"/> is not executed and <see cref="PruneEndIfDirectiveTriviaSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneEndIfDirectiveTriviaSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneEndIfDirectiveTriviaSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneEndIfDirectiveTriviaSelectorCore(XElement)"/>.</param>
        partial void PruneEndIfDirectiveTriviaSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneEndIfDirectiveTriviaSelector(XElement)"/>.</remarks>
        public virtual bool PruneEndIfDirectiveTriviaSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "HashToken")
    			return false;
    		if(property.Attribute("part")?.Value == "EndIfKeyword")
    			return false;
    		if(property.Attribute("part")?.Value == "EndOfDirectiveToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneEndIfDirectiveTriviaSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneEndIfDirectiveTriviaSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneEndIfDirectiveTriviaSelectorCore(property);
    		PruneEndIfDirectiveTriviaSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneRegionDirectiveTriviaSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneRegionDirectiveTriviaSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneRegionDirectiveTriviaSelectorCore(XElement)"/> is not executed and <see cref="PruneRegionDirectiveTriviaSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneRegionDirectiveTriviaSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneRegionDirectiveTriviaSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneRegionDirectiveTriviaSelectorCore(XElement)"/>.</param>
        partial void PruneRegionDirectiveTriviaSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneRegionDirectiveTriviaSelector(XElement)"/>.</remarks>
        public virtual bool PruneRegionDirectiveTriviaSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "HashToken")
    			return false;
    		if(property.Attribute("part")?.Value == "RegionKeyword")
    			return false;
    		if(property.Attribute("part")?.Value == "EndOfDirectiveToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneRegionDirectiveTriviaSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneRegionDirectiveTriviaSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneRegionDirectiveTriviaSelectorCore(property);
    		PruneRegionDirectiveTriviaSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneEndRegionDirectiveTriviaSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneEndRegionDirectiveTriviaSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneEndRegionDirectiveTriviaSelectorCore(XElement)"/> is not executed and <see cref="PruneEndRegionDirectiveTriviaSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneEndRegionDirectiveTriviaSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneEndRegionDirectiveTriviaSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneEndRegionDirectiveTriviaSelectorCore(XElement)"/>.</param>
        partial void PruneEndRegionDirectiveTriviaSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneEndRegionDirectiveTriviaSelector(XElement)"/>.</remarks>
        public virtual bool PruneEndRegionDirectiveTriviaSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "HashToken")
    			return false;
    		if(property.Attribute("part")?.Value == "EndRegionKeyword")
    			return false;
    		if(property.Attribute("part")?.Value == "EndOfDirectiveToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneEndRegionDirectiveTriviaSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneEndRegionDirectiveTriviaSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneEndRegionDirectiveTriviaSelectorCore(property);
    		PruneEndRegionDirectiveTriviaSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneErrorDirectiveTriviaSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneErrorDirectiveTriviaSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneErrorDirectiveTriviaSelectorCore(XElement)"/> is not executed and <see cref="PruneErrorDirectiveTriviaSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneErrorDirectiveTriviaSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneErrorDirectiveTriviaSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneErrorDirectiveTriviaSelectorCore(XElement)"/>.</param>
        partial void PruneErrorDirectiveTriviaSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneErrorDirectiveTriviaSelector(XElement)"/>.</remarks>
        public virtual bool PruneErrorDirectiveTriviaSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "HashToken")
    			return false;
    		if(property.Attribute("part")?.Value == "ErrorKeyword")
    			return false;
    		if(property.Attribute("part")?.Value == "EndOfDirectiveToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneErrorDirectiveTriviaSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneErrorDirectiveTriviaSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneErrorDirectiveTriviaSelectorCore(property);
    		PruneErrorDirectiveTriviaSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneWarningDirectiveTriviaSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneWarningDirectiveTriviaSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneWarningDirectiveTriviaSelectorCore(XElement)"/> is not executed and <see cref="PruneWarningDirectiveTriviaSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneWarningDirectiveTriviaSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneWarningDirectiveTriviaSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneWarningDirectiveTriviaSelectorCore(XElement)"/>.</param>
        partial void PruneWarningDirectiveTriviaSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneWarningDirectiveTriviaSelector(XElement)"/>.</remarks>
        public virtual bool PruneWarningDirectiveTriviaSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "HashToken")
    			return false;
    		if(property.Attribute("part")?.Value == "WarningKeyword")
    			return false;
    		if(property.Attribute("part")?.Value == "EndOfDirectiveToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneWarningDirectiveTriviaSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneWarningDirectiveTriviaSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneWarningDirectiveTriviaSelectorCore(property);
    		PruneWarningDirectiveTriviaSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneBadDirectiveTriviaSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneBadDirectiveTriviaSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneBadDirectiveTriviaSelectorCore(XElement)"/> is not executed and <see cref="PruneBadDirectiveTriviaSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBadDirectiveTriviaSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneBadDirectiveTriviaSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneBadDirectiveTriviaSelectorCore(XElement)"/>.</param>
        partial void PruneBadDirectiveTriviaSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneBadDirectiveTriviaSelector(XElement)"/>.</remarks>
        public virtual bool PruneBadDirectiveTriviaSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "HashToken")
    			return false;
    		if(property.Attribute("part")?.Value == "EndOfDirectiveToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneBadDirectiveTriviaSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBadDirectiveTriviaSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneBadDirectiveTriviaSelectorCore(property);
    		PruneBadDirectiveTriviaSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneDefineDirectiveTriviaSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneDefineDirectiveTriviaSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneDefineDirectiveTriviaSelectorCore(XElement)"/> is not executed and <see cref="PruneDefineDirectiveTriviaSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneDefineDirectiveTriviaSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneDefineDirectiveTriviaSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneDefineDirectiveTriviaSelectorCore(XElement)"/>.</param>
        partial void PruneDefineDirectiveTriviaSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneDefineDirectiveTriviaSelector(XElement)"/>.</remarks>
        public virtual bool PruneDefineDirectiveTriviaSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "HashToken")
    			return false;
    		if(property.Attribute("part")?.Value == "DefineKeyword")
    			return false;
    		if(property.Attribute("part")?.Value == "EndOfDirectiveToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneDefineDirectiveTriviaSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneDefineDirectiveTriviaSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneDefineDirectiveTriviaSelectorCore(property);
    		PruneDefineDirectiveTriviaSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneUndefDirectiveTriviaSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneUndefDirectiveTriviaSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneUndefDirectiveTriviaSelectorCore(XElement)"/> is not executed and <see cref="PruneUndefDirectiveTriviaSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneUndefDirectiveTriviaSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneUndefDirectiveTriviaSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneUndefDirectiveTriviaSelectorCore(XElement)"/>.</param>
        partial void PruneUndefDirectiveTriviaSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneUndefDirectiveTriviaSelector(XElement)"/>.</remarks>
        public virtual bool PruneUndefDirectiveTriviaSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "HashToken")
    			return false;
    		if(property.Attribute("part")?.Value == "UndefKeyword")
    			return false;
    		if(property.Attribute("part")?.Value == "EndOfDirectiveToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneUndefDirectiveTriviaSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneUndefDirectiveTriviaSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneUndefDirectiveTriviaSelectorCore(property);
    		PruneUndefDirectiveTriviaSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneLineDirectiveTriviaSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneLineDirectiveTriviaSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneLineDirectiveTriviaSelectorCore(XElement)"/> is not executed and <see cref="PruneLineDirectiveTriviaSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneLineDirectiveTriviaSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneLineDirectiveTriviaSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneLineDirectiveTriviaSelectorCore(XElement)"/>.</param>
        partial void PruneLineDirectiveTriviaSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneLineDirectiveTriviaSelector(XElement)"/>.</remarks>
        public virtual bool PruneLineDirectiveTriviaSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "HashToken")
    			return false;
    		if(property.Attribute("part")?.Value == "LineKeyword")
    			return false;
    		if(property.Attribute("part")?.Value == "EndOfDirectiveToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneLineDirectiveTriviaSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneLineDirectiveTriviaSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneLineDirectiveTriviaSelectorCore(property);
    		PruneLineDirectiveTriviaSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PrunePragmaWarningDirectiveTriviaSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PrunePragmaWarningDirectiveTriviaSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PrunePragmaWarningDirectiveTriviaSelectorCore(XElement)"/> is not executed and <see cref="PrunePragmaWarningDirectiveTriviaSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PrunePragmaWarningDirectiveTriviaSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PrunePragmaWarningDirectiveTriviaSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PrunePragmaWarningDirectiveTriviaSelectorCore(XElement)"/>.</param>
        partial void PrunePragmaWarningDirectiveTriviaSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PrunePragmaWarningDirectiveTriviaSelector(XElement)"/>.</remarks>
        public virtual bool PrunePragmaWarningDirectiveTriviaSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "HashToken")
    			return false;
    		if(property.Attribute("part")?.Value == "PragmaKeyword")
    			return false;
    		if(property.Attribute("part")?.Value == "WarningKeyword")
    			return false;
    		if(property.Attribute("part")?.Value == "EndOfDirectiveToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PrunePragmaWarningDirectiveTriviaSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PrunePragmaWarningDirectiveTriviaSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PrunePragmaWarningDirectiveTriviaSelectorCore(property);
    		PrunePragmaWarningDirectiveTriviaSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PrunePragmaChecksumDirectiveTriviaSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PrunePragmaChecksumDirectiveTriviaSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PrunePragmaChecksumDirectiveTriviaSelectorCore(XElement)"/> is not executed and <see cref="PrunePragmaChecksumDirectiveTriviaSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PrunePragmaChecksumDirectiveTriviaSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PrunePragmaChecksumDirectiveTriviaSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PrunePragmaChecksumDirectiveTriviaSelectorCore(XElement)"/>.</param>
        partial void PrunePragmaChecksumDirectiveTriviaSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PrunePragmaChecksumDirectiveTriviaSelector(XElement)"/>.</remarks>
        public virtual bool PrunePragmaChecksumDirectiveTriviaSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "HashToken")
    			return false;
    		if(property.Attribute("part")?.Value == "PragmaKeyword")
    			return false;
    		if(property.Attribute("part")?.Value == "ChecksumKeyword")
    			return false;
    		if(property.Attribute("part")?.Value == "EndOfDirectiveToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PrunePragmaChecksumDirectiveTriviaSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PrunePragmaChecksumDirectiveTriviaSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PrunePragmaChecksumDirectiveTriviaSelectorCore(property);
    		PrunePragmaChecksumDirectiveTriviaSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneReferenceDirectiveTriviaSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneReferenceDirectiveTriviaSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneReferenceDirectiveTriviaSelectorCore(XElement)"/> is not executed and <see cref="PruneReferenceDirectiveTriviaSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneReferenceDirectiveTriviaSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneReferenceDirectiveTriviaSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneReferenceDirectiveTriviaSelectorCore(XElement)"/>.</param>
        partial void PruneReferenceDirectiveTriviaSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneReferenceDirectiveTriviaSelector(XElement)"/>.</remarks>
        public virtual bool PruneReferenceDirectiveTriviaSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "HashToken")
    			return false;
    		if(property.Attribute("part")?.Value == "ReferenceKeyword")
    			return false;
    		if(property.Attribute("part")?.Value == "EndOfDirectiveToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneReferenceDirectiveTriviaSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneReferenceDirectiveTriviaSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneReferenceDirectiveTriviaSelectorCore(property);
    		PruneReferenceDirectiveTriviaSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneLoadDirectiveTriviaSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneLoadDirectiveTriviaSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneLoadDirectiveTriviaSelectorCore(XElement)"/> is not executed and <see cref="PruneLoadDirectiveTriviaSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneLoadDirectiveTriviaSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneLoadDirectiveTriviaSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneLoadDirectiveTriviaSelectorCore(XElement)"/>.</param>
        partial void PruneLoadDirectiveTriviaSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneLoadDirectiveTriviaSelector(XElement)"/>.</remarks>
        public virtual bool PruneLoadDirectiveTriviaSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "HashToken")
    			return false;
    		if(property.Attribute("part")?.Value == "LoadKeyword")
    			return false;
    		if(property.Attribute("part")?.Value == "EndOfDirectiveToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneLoadDirectiveTriviaSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneLoadDirectiveTriviaSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneLoadDirectiveTriviaSelectorCore(property);
    		PruneLoadDirectiveTriviaSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneShebangDirectiveTriviaSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneShebangDirectiveTriviaSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneShebangDirectiveTriviaSelectorCore(XElement)"/> is not executed and <see cref="PruneShebangDirectiveTriviaSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneShebangDirectiveTriviaSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneShebangDirectiveTriviaSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneShebangDirectiveTriviaSelectorCore(XElement)"/>.</param>
        partial void PruneShebangDirectiveTriviaSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneShebangDirectiveTriviaSelector(XElement)"/>.</remarks>
        public virtual bool PruneShebangDirectiveTriviaSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "HashToken")
    			return false;
    		if(property.Attribute("part")?.Value == "ExclamationToken")
    			return false;
    		if(property.Attribute("part")?.Value == "EndOfDirectiveToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneShebangDirectiveTriviaSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneShebangDirectiveTriviaSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneShebangDirectiveTriviaSelectorCore(property);
    		PruneShebangDirectiveTriviaSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneElseDirectiveTriviaSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneElseDirectiveTriviaSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneElseDirectiveTriviaSelectorCore(XElement)"/> is not executed and <see cref="PruneElseDirectiveTriviaSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneElseDirectiveTriviaSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneElseDirectiveTriviaSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneElseDirectiveTriviaSelectorCore(XElement)"/>.</param>
        partial void PruneElseDirectiveTriviaSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneElseDirectiveTriviaSelector(XElement)"/>.</remarks>
        public virtual bool PruneElseDirectiveTriviaSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "HashToken")
    			return false;
    		if(property.Attribute("part")?.Value == "ElseKeyword")
    			return false;
    		if(property.Attribute("part")?.Value == "EndOfDirectiveToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneElseDirectiveTriviaSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneElseDirectiveTriviaSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneElseDirectiveTriviaSelectorCore(property);
    		PruneElseDirectiveTriviaSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneIfDirectiveTriviaSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneIfDirectiveTriviaSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneIfDirectiveTriviaSelectorCore(XElement)"/> is not executed and <see cref="PruneIfDirectiveTriviaSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneIfDirectiveTriviaSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneIfDirectiveTriviaSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneIfDirectiveTriviaSelectorCore(XElement)"/>.</param>
        partial void PruneIfDirectiveTriviaSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneIfDirectiveTriviaSelector(XElement)"/>.</remarks>
        public virtual bool PruneIfDirectiveTriviaSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "HashToken")
    			return false;
    		if(property.Attribute("part")?.Value == "IfKeyword")
    			return false;
    		if(property.Attribute("part")?.Value == "EndOfDirectiveToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneIfDirectiveTriviaSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneIfDirectiveTriviaSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneIfDirectiveTriviaSelectorCore(property);
    		PruneIfDirectiveTriviaSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneElifDirectiveTriviaSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneElifDirectiveTriviaSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneElifDirectiveTriviaSelectorCore(XElement)"/> is not executed and <see cref="PruneElifDirectiveTriviaSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneElifDirectiveTriviaSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneElifDirectiveTriviaSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneElifDirectiveTriviaSelectorCore(XElement)"/>.</param>
        partial void PruneElifDirectiveTriviaSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneElifDirectiveTriviaSelector(XElement)"/>.</remarks>
        public virtual bool PruneElifDirectiveTriviaSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "HashToken")
    			return false;
    		if(property.Attribute("part")?.Value == "ElifKeyword")
    			return false;
    		if(property.Attribute("part")?.Value == "EndOfDirectiveToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneElifDirectiveTriviaSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneElifDirectiveTriviaSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneElifDirectiveTriviaSelectorCore(property);
    		PruneElifDirectiveTriviaSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneTypeCrefSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneTypeCrefSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneTypeCrefSelectorCore(XElement)"/> is not executed and <see cref="PruneTypeCrefSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneTypeCrefSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneTypeCrefSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneTypeCrefSelectorCore(XElement)"/>.</param>
        partial void PruneTypeCrefSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneTypeCrefSelector(XElement)"/>.</remarks>
        public virtual bool PruneTypeCrefSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneTypeCrefSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneTypeCrefSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneTypeCrefSelectorCore(property);
    		PruneTypeCrefSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneQualifiedCrefSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneQualifiedCrefSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneQualifiedCrefSelectorCore(XElement)"/> is not executed and <see cref="PruneQualifiedCrefSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneQualifiedCrefSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneQualifiedCrefSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneQualifiedCrefSelectorCore(XElement)"/>.</param>
        partial void PruneQualifiedCrefSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneQualifiedCrefSelector(XElement)"/>.</remarks>
        public virtual bool PruneQualifiedCrefSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "DotToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneQualifiedCrefSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneQualifiedCrefSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneQualifiedCrefSelectorCore(property);
    		PruneQualifiedCrefSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneNameMemberCrefSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneNameMemberCrefSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneNameMemberCrefSelectorCore(XElement)"/> is not executed and <see cref="PruneNameMemberCrefSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneNameMemberCrefSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneNameMemberCrefSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneNameMemberCrefSelectorCore(XElement)"/>.</param>
        partial void PruneNameMemberCrefSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneNameMemberCrefSelector(XElement)"/>.</remarks>
        public virtual bool PruneNameMemberCrefSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneNameMemberCrefSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneNameMemberCrefSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneNameMemberCrefSelectorCore(property);
    		PruneNameMemberCrefSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneIndexerMemberCrefSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneIndexerMemberCrefSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneIndexerMemberCrefSelectorCore(XElement)"/> is not executed and <see cref="PruneIndexerMemberCrefSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneIndexerMemberCrefSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneIndexerMemberCrefSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneIndexerMemberCrefSelectorCore(XElement)"/>.</param>
        partial void PruneIndexerMemberCrefSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneIndexerMemberCrefSelector(XElement)"/>.</remarks>
        public virtual bool PruneIndexerMemberCrefSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "ThisKeyword")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneIndexerMemberCrefSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneIndexerMemberCrefSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneIndexerMemberCrefSelectorCore(property);
    		PruneIndexerMemberCrefSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneOperatorMemberCrefSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneOperatorMemberCrefSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneOperatorMemberCrefSelectorCore(XElement)"/> is not executed and <see cref="PruneOperatorMemberCrefSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneOperatorMemberCrefSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneOperatorMemberCrefSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneOperatorMemberCrefSelectorCore(XElement)"/>.</param>
        partial void PruneOperatorMemberCrefSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneOperatorMemberCrefSelector(XElement)"/>.</remarks>
        public virtual bool PruneOperatorMemberCrefSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "OperatorKeyword")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneOperatorMemberCrefSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneOperatorMemberCrefSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneOperatorMemberCrefSelectorCore(property);
    		PruneOperatorMemberCrefSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneConversionOperatorMemberCrefSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneConversionOperatorMemberCrefSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneConversionOperatorMemberCrefSelectorCore(XElement)"/> is not executed and <see cref="PruneConversionOperatorMemberCrefSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneConversionOperatorMemberCrefSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneConversionOperatorMemberCrefSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneConversionOperatorMemberCrefSelectorCore(XElement)"/>.</param>
        partial void PruneConversionOperatorMemberCrefSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneConversionOperatorMemberCrefSelector(XElement)"/>.</remarks>
        public virtual bool PruneConversionOperatorMemberCrefSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "ImplicitOrExplicitKeyword")
    			return false;
    		if(property.Attribute("part")?.Value == "OperatorKeyword")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneConversionOperatorMemberCrefSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneConversionOperatorMemberCrefSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneConversionOperatorMemberCrefSelectorCore(property);
    		PruneConversionOperatorMemberCrefSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneCrefParameterListSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneCrefParameterListSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCrefParameterListSelectorCore(XElement)"/> is not executed and <see cref="PruneCrefParameterListSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneCrefParameterListSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCrefParameterListSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneCrefParameterListSelectorCore(XElement)"/>.</param>
        partial void PruneCrefParameterListSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneCrefParameterListSelector(XElement)"/>.</remarks>
        public virtual bool PruneCrefParameterListSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "OpenParenToken")
    			return false;
    		if(property.Attribute("part")?.Value == "CloseParenToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneCrefParameterListSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneCrefParameterListSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCrefParameterListSelectorCore(property);
    		PruneCrefParameterListSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneCrefBracketedParameterListSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneCrefBracketedParameterListSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCrefBracketedParameterListSelectorCore(XElement)"/> is not executed and <see cref="PruneCrefBracketedParameterListSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneCrefBracketedParameterListSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCrefBracketedParameterListSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneCrefBracketedParameterListSelectorCore(XElement)"/>.</param>
        partial void PruneCrefBracketedParameterListSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneCrefBracketedParameterListSelector(XElement)"/>.</remarks>
        public virtual bool PruneCrefBracketedParameterListSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "OpenBracketToken")
    			return false;
    		if(property.Attribute("part")?.Value == "CloseBracketToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneCrefBracketedParameterListSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneCrefBracketedParameterListSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCrefBracketedParameterListSelectorCore(property);
    		PruneCrefBracketedParameterListSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneXmlElementSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneXmlElementSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneXmlElementSelectorCore(XElement)"/> is not executed and <see cref="PruneXmlElementSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneXmlElementSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneXmlElementSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneXmlElementSelectorCore(XElement)"/>.</param>
        partial void PruneXmlElementSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneXmlElementSelector(XElement)"/>.</remarks>
        public virtual bool PruneXmlElementSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneXmlElementSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneXmlElementSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneXmlElementSelectorCore(property);
    		PruneXmlElementSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneXmlEmptyElementSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneXmlEmptyElementSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneXmlEmptyElementSelectorCore(XElement)"/> is not executed and <see cref="PruneXmlEmptyElementSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneXmlEmptyElementSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneXmlEmptyElementSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneXmlEmptyElementSelectorCore(XElement)"/>.</param>
        partial void PruneXmlEmptyElementSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneXmlEmptyElementSelector(XElement)"/>.</remarks>
        public virtual bool PruneXmlEmptyElementSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "LessThanToken")
    			return false;
    		if(property.Attribute("part")?.Value == "SlashGreaterThanToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneXmlEmptyElementSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneXmlEmptyElementSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneXmlEmptyElementSelectorCore(property);
    		PruneXmlEmptyElementSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneXmlTextSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneXmlTextSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneXmlTextSelectorCore(XElement)"/> is not executed and <see cref="PruneXmlTextSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneXmlTextSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneXmlTextSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneXmlTextSelectorCore(XElement)"/>.</param>
        partial void PruneXmlTextSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneXmlTextSelector(XElement)"/>.</remarks>
        public virtual bool PruneXmlTextSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneXmlTextSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneXmlTextSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneXmlTextSelectorCore(property);
    		PruneXmlTextSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneXmlCDataSectionSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneXmlCDataSectionSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneXmlCDataSectionSelectorCore(XElement)"/> is not executed and <see cref="PruneXmlCDataSectionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneXmlCDataSectionSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneXmlCDataSectionSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneXmlCDataSectionSelectorCore(XElement)"/>.</param>
        partial void PruneXmlCDataSectionSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneXmlCDataSectionSelector(XElement)"/>.</remarks>
        public virtual bool PruneXmlCDataSectionSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "StartCDataToken")
    			return false;
    		if(property.Attribute("part")?.Value == "EndCDataToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneXmlCDataSectionSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneXmlCDataSectionSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneXmlCDataSectionSelectorCore(property);
    		PruneXmlCDataSectionSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneXmlProcessingInstructionSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneXmlProcessingInstructionSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneXmlProcessingInstructionSelectorCore(XElement)"/> is not executed and <see cref="PruneXmlProcessingInstructionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneXmlProcessingInstructionSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneXmlProcessingInstructionSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneXmlProcessingInstructionSelectorCore(XElement)"/>.</param>
        partial void PruneXmlProcessingInstructionSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneXmlProcessingInstructionSelector(XElement)"/>.</remarks>
        public virtual bool PruneXmlProcessingInstructionSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "StartProcessingInstructionToken")
    			return false;
    		if(property.Attribute("part")?.Value == "EndProcessingInstructionToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneXmlProcessingInstructionSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneXmlProcessingInstructionSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneXmlProcessingInstructionSelectorCore(property);
    		PruneXmlProcessingInstructionSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneXmlCommentSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneXmlCommentSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneXmlCommentSelectorCore(XElement)"/> is not executed and <see cref="PruneXmlCommentSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneXmlCommentSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneXmlCommentSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneXmlCommentSelectorCore(XElement)"/>.</param>
        partial void PruneXmlCommentSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneXmlCommentSelector(XElement)"/>.</remarks>
        public virtual bool PruneXmlCommentSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "LessThanExclamationMinusMinusToken")
    			return false;
    		if(property.Attribute("part")?.Value == "MinusMinusGreaterThanToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneXmlCommentSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneXmlCommentSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneXmlCommentSelectorCore(property);
    		PruneXmlCommentSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneXmlTextAttributeSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneXmlTextAttributeSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneXmlTextAttributeSelectorCore(XElement)"/> is not executed and <see cref="PruneXmlTextAttributeSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneXmlTextAttributeSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneXmlTextAttributeSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneXmlTextAttributeSelectorCore(XElement)"/>.</param>
        partial void PruneXmlTextAttributeSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneXmlTextAttributeSelector(XElement)"/>.</remarks>
        public virtual bool PruneXmlTextAttributeSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "EqualsToken")
    			return false;
    		if(property.Attribute("part")?.Value == "StartQuoteToken")
    			return false;
    		if(property.Attribute("part")?.Value == "EndQuoteToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneXmlTextAttributeSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneXmlTextAttributeSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneXmlTextAttributeSelectorCore(property);
    		PruneXmlTextAttributeSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneXmlCrefAttributeSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneXmlCrefAttributeSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneXmlCrefAttributeSelectorCore(XElement)"/> is not executed and <see cref="PruneXmlCrefAttributeSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneXmlCrefAttributeSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneXmlCrefAttributeSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneXmlCrefAttributeSelectorCore(XElement)"/>.</param>
        partial void PruneXmlCrefAttributeSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneXmlCrefAttributeSelector(XElement)"/>.</remarks>
        public virtual bool PruneXmlCrefAttributeSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "Name")
    			return false;
    		if(property.Attribute("part")?.Value == "EqualsToken")
    			return false;
    		if(property.Attribute("part")?.Value == "StartQuoteToken")
    			return false;
    		if(property.Attribute("part")?.Value == "EndQuoteToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneXmlCrefAttributeSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneXmlCrefAttributeSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneXmlCrefAttributeSelectorCore(property);
    		PruneXmlCrefAttributeSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneXmlNameAttributeSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneXmlNameAttributeSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneXmlNameAttributeSelectorCore(XElement)"/> is not executed and <see cref="PruneXmlNameAttributeSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneXmlNameAttributeSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneXmlNameAttributeSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneXmlNameAttributeSelectorCore(XElement)"/>.</param>
        partial void PruneXmlNameAttributeSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneXmlNameAttributeSelector(XElement)"/>.</remarks>
        public virtual bool PruneXmlNameAttributeSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "Name")
    			return false;
    		if(property.Attribute("part")?.Value == "EqualsToken")
    			return false;
    		if(property.Attribute("part")?.Value == "StartQuoteToken")
    			return false;
    		if(property.Attribute("part")?.Value == "EndQuoteToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneXmlNameAttributeSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneXmlNameAttributeSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneXmlNameAttributeSelectorCore(property);
    		PruneXmlNameAttributeSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneParenthesizedExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneParenthesizedExpressionSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneParenthesizedExpressionSelectorCore(XElement)"/> is not executed and <see cref="PruneParenthesizedExpressionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneParenthesizedExpressionSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneParenthesizedExpressionSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneParenthesizedExpressionSelectorCore(XElement)"/>.</param>
        partial void PruneParenthesizedExpressionSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneParenthesizedExpressionSelector(XElement)"/>.</remarks>
        public virtual bool PruneParenthesizedExpressionSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "OpenParenToken")
    			return false;
    		if(property.Attribute("part")?.Value == "CloseParenToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneParenthesizedExpressionSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneParenthesizedExpressionSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneParenthesizedExpressionSelectorCore(property);
    		PruneParenthesizedExpressionSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneTupleExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneTupleExpressionSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneTupleExpressionSelectorCore(XElement)"/> is not executed and <see cref="PruneTupleExpressionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneTupleExpressionSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneTupleExpressionSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneTupleExpressionSelectorCore(XElement)"/>.</param>
        partial void PruneTupleExpressionSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneTupleExpressionSelector(XElement)"/>.</remarks>
        public virtual bool PruneTupleExpressionSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "OpenParenToken")
    			return false;
    		if(property.Attribute("part")?.Value == "CloseParenToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneTupleExpressionSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneTupleExpressionSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneTupleExpressionSelectorCore(property);
    		PruneTupleExpressionSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PrunePrefixUnaryExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PrunePrefixUnaryExpressionSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PrunePrefixUnaryExpressionSelectorCore(XElement)"/> is not executed and <see cref="PrunePrefixUnaryExpressionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PrunePrefixUnaryExpressionSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PrunePrefixUnaryExpressionSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PrunePrefixUnaryExpressionSelectorCore(XElement)"/>.</param>
        partial void PrunePrefixUnaryExpressionSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PrunePrefixUnaryExpressionSelector(XElement)"/>.</remarks>
        public virtual bool PrunePrefixUnaryExpressionSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "OperatorToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PrunePrefixUnaryExpressionSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PrunePrefixUnaryExpressionSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PrunePrefixUnaryExpressionSelectorCore(property);
    		PrunePrefixUnaryExpressionSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneAwaitExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneAwaitExpressionSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneAwaitExpressionSelectorCore(XElement)"/> is not executed and <see cref="PruneAwaitExpressionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneAwaitExpressionSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneAwaitExpressionSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneAwaitExpressionSelectorCore(XElement)"/>.</param>
        partial void PruneAwaitExpressionSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneAwaitExpressionSelector(XElement)"/>.</remarks>
        public virtual bool PruneAwaitExpressionSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "AwaitKeyword")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneAwaitExpressionSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneAwaitExpressionSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneAwaitExpressionSelectorCore(property);
    		PruneAwaitExpressionSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PrunePostfixUnaryExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PrunePostfixUnaryExpressionSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PrunePostfixUnaryExpressionSelectorCore(XElement)"/> is not executed and <see cref="PrunePostfixUnaryExpressionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PrunePostfixUnaryExpressionSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PrunePostfixUnaryExpressionSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PrunePostfixUnaryExpressionSelectorCore(XElement)"/>.</param>
        partial void PrunePostfixUnaryExpressionSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PrunePostfixUnaryExpressionSelector(XElement)"/>.</remarks>
        public virtual bool PrunePostfixUnaryExpressionSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "OperatorToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PrunePostfixUnaryExpressionSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PrunePostfixUnaryExpressionSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PrunePostfixUnaryExpressionSelectorCore(property);
    		PrunePostfixUnaryExpressionSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneMemberAccessExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneMemberAccessExpressionSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneMemberAccessExpressionSelectorCore(XElement)"/> is not executed and <see cref="PruneMemberAccessExpressionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneMemberAccessExpressionSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneMemberAccessExpressionSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneMemberAccessExpressionSelectorCore(XElement)"/>.</param>
        partial void PruneMemberAccessExpressionSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneMemberAccessExpressionSelector(XElement)"/>.</remarks>
        public virtual bool PruneMemberAccessExpressionSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "OperatorToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneMemberAccessExpressionSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneMemberAccessExpressionSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneMemberAccessExpressionSelectorCore(property);
    		PruneMemberAccessExpressionSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneConditionalAccessExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneConditionalAccessExpressionSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneConditionalAccessExpressionSelectorCore(XElement)"/> is not executed and <see cref="PruneConditionalAccessExpressionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneConditionalAccessExpressionSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneConditionalAccessExpressionSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneConditionalAccessExpressionSelectorCore(XElement)"/>.</param>
        partial void PruneConditionalAccessExpressionSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneConditionalAccessExpressionSelector(XElement)"/>.</remarks>
        public virtual bool PruneConditionalAccessExpressionSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "OperatorToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneConditionalAccessExpressionSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneConditionalAccessExpressionSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneConditionalAccessExpressionSelectorCore(property);
    		PruneConditionalAccessExpressionSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneMemberBindingExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneMemberBindingExpressionSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneMemberBindingExpressionSelectorCore(XElement)"/> is not executed and <see cref="PruneMemberBindingExpressionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneMemberBindingExpressionSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneMemberBindingExpressionSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneMemberBindingExpressionSelectorCore(XElement)"/>.</param>
        partial void PruneMemberBindingExpressionSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneMemberBindingExpressionSelector(XElement)"/>.</remarks>
        public virtual bool PruneMemberBindingExpressionSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "OperatorToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneMemberBindingExpressionSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneMemberBindingExpressionSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneMemberBindingExpressionSelectorCore(property);
    		PruneMemberBindingExpressionSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneElementBindingExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneElementBindingExpressionSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneElementBindingExpressionSelectorCore(XElement)"/> is not executed and <see cref="PruneElementBindingExpressionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneElementBindingExpressionSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneElementBindingExpressionSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneElementBindingExpressionSelectorCore(XElement)"/>.</param>
        partial void PruneElementBindingExpressionSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneElementBindingExpressionSelector(XElement)"/>.</remarks>
        public virtual bool PruneElementBindingExpressionSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneElementBindingExpressionSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneElementBindingExpressionSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneElementBindingExpressionSelectorCore(property);
    		PruneElementBindingExpressionSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneImplicitElementAccessSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneImplicitElementAccessSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneImplicitElementAccessSelectorCore(XElement)"/> is not executed and <see cref="PruneImplicitElementAccessSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneImplicitElementAccessSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneImplicitElementAccessSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneImplicitElementAccessSelectorCore(XElement)"/>.</param>
        partial void PruneImplicitElementAccessSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneImplicitElementAccessSelector(XElement)"/>.</remarks>
        public virtual bool PruneImplicitElementAccessSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneImplicitElementAccessSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneImplicitElementAccessSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneImplicitElementAccessSelectorCore(property);
    		PruneImplicitElementAccessSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneBinaryExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneBinaryExpressionSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneBinaryExpressionSelectorCore(XElement)"/> is not executed and <see cref="PruneBinaryExpressionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBinaryExpressionSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneBinaryExpressionSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneBinaryExpressionSelectorCore(XElement)"/>.</param>
        partial void PruneBinaryExpressionSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneBinaryExpressionSelector(XElement)"/>.</remarks>
        public virtual bool PruneBinaryExpressionSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "OperatorToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneBinaryExpressionSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBinaryExpressionSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneBinaryExpressionSelectorCore(property);
    		PruneBinaryExpressionSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneAssignmentExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneAssignmentExpressionSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneAssignmentExpressionSelectorCore(XElement)"/> is not executed and <see cref="PruneAssignmentExpressionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneAssignmentExpressionSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneAssignmentExpressionSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneAssignmentExpressionSelectorCore(XElement)"/>.</param>
        partial void PruneAssignmentExpressionSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneAssignmentExpressionSelector(XElement)"/>.</remarks>
        public virtual bool PruneAssignmentExpressionSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "OperatorToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneAssignmentExpressionSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneAssignmentExpressionSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneAssignmentExpressionSelectorCore(property);
    		PruneAssignmentExpressionSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneConditionalExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneConditionalExpressionSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneConditionalExpressionSelectorCore(XElement)"/> is not executed and <see cref="PruneConditionalExpressionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneConditionalExpressionSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneConditionalExpressionSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneConditionalExpressionSelectorCore(XElement)"/>.</param>
        partial void PruneConditionalExpressionSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneConditionalExpressionSelector(XElement)"/>.</remarks>
        public virtual bool PruneConditionalExpressionSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "QuestionToken")
    			return false;
    		if(property.Attribute("part")?.Value == "ColonToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneConditionalExpressionSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneConditionalExpressionSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneConditionalExpressionSelectorCore(property);
    		PruneConditionalExpressionSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneLiteralExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneLiteralExpressionSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneLiteralExpressionSelectorCore(XElement)"/> is not executed and <see cref="PruneLiteralExpressionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneLiteralExpressionSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneLiteralExpressionSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneLiteralExpressionSelectorCore(XElement)"/>.</param>
        partial void PruneLiteralExpressionSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneLiteralExpressionSelector(XElement)"/>.</remarks>
        public virtual bool PruneLiteralExpressionSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneLiteralExpressionSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneLiteralExpressionSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneLiteralExpressionSelectorCore(property);
    		PruneLiteralExpressionSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneMakeRefExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneMakeRefExpressionSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneMakeRefExpressionSelectorCore(XElement)"/> is not executed and <see cref="PruneMakeRefExpressionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneMakeRefExpressionSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneMakeRefExpressionSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneMakeRefExpressionSelectorCore(XElement)"/>.</param>
        partial void PruneMakeRefExpressionSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneMakeRefExpressionSelector(XElement)"/>.</remarks>
        public virtual bool PruneMakeRefExpressionSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "Keyword")
    			return false;
    		if(property.Attribute("part")?.Value == "OpenParenToken")
    			return false;
    		if(property.Attribute("part")?.Value == "CloseParenToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneMakeRefExpressionSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneMakeRefExpressionSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneMakeRefExpressionSelectorCore(property);
    		PruneMakeRefExpressionSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneRefTypeExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneRefTypeExpressionSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneRefTypeExpressionSelectorCore(XElement)"/> is not executed and <see cref="PruneRefTypeExpressionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneRefTypeExpressionSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneRefTypeExpressionSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneRefTypeExpressionSelectorCore(XElement)"/>.</param>
        partial void PruneRefTypeExpressionSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneRefTypeExpressionSelector(XElement)"/>.</remarks>
        public virtual bool PruneRefTypeExpressionSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "Keyword")
    			return false;
    		if(property.Attribute("part")?.Value == "OpenParenToken")
    			return false;
    		if(property.Attribute("part")?.Value == "CloseParenToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneRefTypeExpressionSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneRefTypeExpressionSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneRefTypeExpressionSelectorCore(property);
    		PruneRefTypeExpressionSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneRefValueExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneRefValueExpressionSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneRefValueExpressionSelectorCore(XElement)"/> is not executed and <see cref="PruneRefValueExpressionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneRefValueExpressionSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneRefValueExpressionSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneRefValueExpressionSelectorCore(XElement)"/>.</param>
        partial void PruneRefValueExpressionSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneRefValueExpressionSelector(XElement)"/>.</remarks>
        public virtual bool PruneRefValueExpressionSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "Keyword")
    			return false;
    		if(property.Attribute("part")?.Value == "OpenParenToken")
    			return false;
    		if(property.Attribute("part")?.Value == "Comma")
    			return false;
    		if(property.Attribute("part")?.Value == "CloseParenToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneRefValueExpressionSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneRefValueExpressionSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneRefValueExpressionSelectorCore(property);
    		PruneRefValueExpressionSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneCheckedExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneCheckedExpressionSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCheckedExpressionSelectorCore(XElement)"/> is not executed and <see cref="PruneCheckedExpressionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneCheckedExpressionSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCheckedExpressionSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneCheckedExpressionSelectorCore(XElement)"/>.</param>
        partial void PruneCheckedExpressionSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneCheckedExpressionSelector(XElement)"/>.</remarks>
        public virtual bool PruneCheckedExpressionSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "Keyword")
    			return false;
    		if(property.Attribute("part")?.Value == "OpenParenToken")
    			return false;
    		if(property.Attribute("part")?.Value == "CloseParenToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneCheckedExpressionSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneCheckedExpressionSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCheckedExpressionSelectorCore(property);
    		PruneCheckedExpressionSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneDefaultExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneDefaultExpressionSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneDefaultExpressionSelectorCore(XElement)"/> is not executed and <see cref="PruneDefaultExpressionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneDefaultExpressionSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneDefaultExpressionSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneDefaultExpressionSelectorCore(XElement)"/>.</param>
        partial void PruneDefaultExpressionSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneDefaultExpressionSelector(XElement)"/>.</remarks>
        public virtual bool PruneDefaultExpressionSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "Keyword")
    			return false;
    		if(property.Attribute("part")?.Value == "OpenParenToken")
    			return false;
    		if(property.Attribute("part")?.Value == "CloseParenToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneDefaultExpressionSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneDefaultExpressionSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneDefaultExpressionSelectorCore(property);
    		PruneDefaultExpressionSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneTypeOfExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneTypeOfExpressionSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneTypeOfExpressionSelectorCore(XElement)"/> is not executed and <see cref="PruneTypeOfExpressionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneTypeOfExpressionSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneTypeOfExpressionSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneTypeOfExpressionSelectorCore(XElement)"/>.</param>
        partial void PruneTypeOfExpressionSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneTypeOfExpressionSelector(XElement)"/>.</remarks>
        public virtual bool PruneTypeOfExpressionSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "Keyword")
    			return false;
    		if(property.Attribute("part")?.Value == "OpenParenToken")
    			return false;
    		if(property.Attribute("part")?.Value == "CloseParenToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneTypeOfExpressionSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneTypeOfExpressionSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneTypeOfExpressionSelectorCore(property);
    		PruneTypeOfExpressionSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneSizeOfExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneSizeOfExpressionSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneSizeOfExpressionSelectorCore(XElement)"/> is not executed and <see cref="PruneSizeOfExpressionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneSizeOfExpressionSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneSizeOfExpressionSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneSizeOfExpressionSelectorCore(XElement)"/>.</param>
        partial void PruneSizeOfExpressionSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneSizeOfExpressionSelector(XElement)"/>.</remarks>
        public virtual bool PruneSizeOfExpressionSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "Keyword")
    			return false;
    		if(property.Attribute("part")?.Value == "OpenParenToken")
    			return false;
    		if(property.Attribute("part")?.Value == "CloseParenToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneSizeOfExpressionSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneSizeOfExpressionSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneSizeOfExpressionSelectorCore(property);
    		PruneSizeOfExpressionSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneInvocationExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneInvocationExpressionSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneInvocationExpressionSelectorCore(XElement)"/> is not executed and <see cref="PruneInvocationExpressionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneInvocationExpressionSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneInvocationExpressionSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneInvocationExpressionSelectorCore(XElement)"/>.</param>
        partial void PruneInvocationExpressionSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneInvocationExpressionSelector(XElement)"/>.</remarks>
        public virtual bool PruneInvocationExpressionSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneInvocationExpressionSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneInvocationExpressionSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneInvocationExpressionSelectorCore(property);
    		PruneInvocationExpressionSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneElementAccessExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneElementAccessExpressionSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneElementAccessExpressionSelectorCore(XElement)"/> is not executed and <see cref="PruneElementAccessExpressionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneElementAccessExpressionSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneElementAccessExpressionSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneElementAccessExpressionSelectorCore(XElement)"/>.</param>
        partial void PruneElementAccessExpressionSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneElementAccessExpressionSelector(XElement)"/>.</remarks>
        public virtual bool PruneElementAccessExpressionSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneElementAccessExpressionSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneElementAccessExpressionSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneElementAccessExpressionSelectorCore(property);
    		PruneElementAccessExpressionSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneDeclarationExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneDeclarationExpressionSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneDeclarationExpressionSelectorCore(XElement)"/> is not executed and <see cref="PruneDeclarationExpressionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneDeclarationExpressionSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneDeclarationExpressionSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneDeclarationExpressionSelectorCore(XElement)"/>.</param>
        partial void PruneDeclarationExpressionSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneDeclarationExpressionSelector(XElement)"/>.</remarks>
        public virtual bool PruneDeclarationExpressionSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneDeclarationExpressionSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneDeclarationExpressionSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneDeclarationExpressionSelectorCore(property);
    		PruneDeclarationExpressionSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneCastExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneCastExpressionSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCastExpressionSelectorCore(XElement)"/> is not executed and <see cref="PruneCastExpressionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneCastExpressionSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCastExpressionSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneCastExpressionSelectorCore(XElement)"/>.</param>
        partial void PruneCastExpressionSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneCastExpressionSelector(XElement)"/>.</remarks>
        public virtual bool PruneCastExpressionSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "OpenParenToken")
    			return false;
    		if(property.Attribute("part")?.Value == "CloseParenToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneCastExpressionSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneCastExpressionSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCastExpressionSelectorCore(property);
    		PruneCastExpressionSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneRefExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneRefExpressionSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneRefExpressionSelectorCore(XElement)"/> is not executed and <see cref="PruneRefExpressionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneRefExpressionSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneRefExpressionSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneRefExpressionSelectorCore(XElement)"/>.</param>
        partial void PruneRefExpressionSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneRefExpressionSelector(XElement)"/>.</remarks>
        public virtual bool PruneRefExpressionSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "RefKeyword")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneRefExpressionSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneRefExpressionSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneRefExpressionSelectorCore(property);
    		PruneRefExpressionSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneInitializerExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneInitializerExpressionSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneInitializerExpressionSelectorCore(XElement)"/> is not executed and <see cref="PruneInitializerExpressionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneInitializerExpressionSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneInitializerExpressionSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneInitializerExpressionSelectorCore(XElement)"/>.</param>
        partial void PruneInitializerExpressionSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneInitializerExpressionSelector(XElement)"/>.</remarks>
        public virtual bool PruneInitializerExpressionSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "OpenBraceToken")
    			return false;
    		if(property.Attribute("part")?.Value == "CloseBraceToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneInitializerExpressionSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneInitializerExpressionSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneInitializerExpressionSelectorCore(property);
    		PruneInitializerExpressionSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneObjectCreationExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneObjectCreationExpressionSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneObjectCreationExpressionSelectorCore(XElement)"/> is not executed and <see cref="PruneObjectCreationExpressionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneObjectCreationExpressionSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneObjectCreationExpressionSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneObjectCreationExpressionSelectorCore(XElement)"/>.</param>
        partial void PruneObjectCreationExpressionSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneObjectCreationExpressionSelector(XElement)"/>.</remarks>
        public virtual bool PruneObjectCreationExpressionSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "NewKeyword")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneObjectCreationExpressionSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneObjectCreationExpressionSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneObjectCreationExpressionSelectorCore(property);
    		PruneObjectCreationExpressionSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneAnonymousObjectCreationExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneAnonymousObjectCreationExpressionSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneAnonymousObjectCreationExpressionSelectorCore(XElement)"/> is not executed and <see cref="PruneAnonymousObjectCreationExpressionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneAnonymousObjectCreationExpressionSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneAnonymousObjectCreationExpressionSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneAnonymousObjectCreationExpressionSelectorCore(XElement)"/>.</param>
        partial void PruneAnonymousObjectCreationExpressionSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneAnonymousObjectCreationExpressionSelector(XElement)"/>.</remarks>
        public virtual bool PruneAnonymousObjectCreationExpressionSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "NewKeyword")
    			return false;
    		if(property.Attribute("part")?.Value == "OpenBraceToken")
    			return false;
    		if(property.Attribute("part")?.Value == "CloseBraceToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneAnonymousObjectCreationExpressionSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneAnonymousObjectCreationExpressionSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneAnonymousObjectCreationExpressionSelectorCore(property);
    		PruneAnonymousObjectCreationExpressionSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneArrayCreationExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneArrayCreationExpressionSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneArrayCreationExpressionSelectorCore(XElement)"/> is not executed and <see cref="PruneArrayCreationExpressionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneArrayCreationExpressionSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneArrayCreationExpressionSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneArrayCreationExpressionSelectorCore(XElement)"/>.</param>
        partial void PruneArrayCreationExpressionSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneArrayCreationExpressionSelector(XElement)"/>.</remarks>
        public virtual bool PruneArrayCreationExpressionSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "NewKeyword")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneArrayCreationExpressionSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneArrayCreationExpressionSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneArrayCreationExpressionSelectorCore(property);
    		PruneArrayCreationExpressionSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneImplicitArrayCreationExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneImplicitArrayCreationExpressionSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneImplicitArrayCreationExpressionSelectorCore(XElement)"/> is not executed and <see cref="PruneImplicitArrayCreationExpressionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneImplicitArrayCreationExpressionSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneImplicitArrayCreationExpressionSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneImplicitArrayCreationExpressionSelectorCore(XElement)"/>.</param>
        partial void PruneImplicitArrayCreationExpressionSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneImplicitArrayCreationExpressionSelector(XElement)"/>.</remarks>
        public virtual bool PruneImplicitArrayCreationExpressionSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "NewKeyword")
    			return false;
    		if(property.Attribute("part")?.Value == "OpenBracketToken")
    			return false;
    		if(property.Attribute("part")?.Value == "CloseBracketToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneImplicitArrayCreationExpressionSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneImplicitArrayCreationExpressionSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneImplicitArrayCreationExpressionSelectorCore(property);
    		PruneImplicitArrayCreationExpressionSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneStackAllocArrayCreationExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneStackAllocArrayCreationExpressionSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneStackAllocArrayCreationExpressionSelectorCore(XElement)"/> is not executed and <see cref="PruneStackAllocArrayCreationExpressionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneStackAllocArrayCreationExpressionSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneStackAllocArrayCreationExpressionSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneStackAllocArrayCreationExpressionSelectorCore(XElement)"/>.</param>
        partial void PruneStackAllocArrayCreationExpressionSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneStackAllocArrayCreationExpressionSelector(XElement)"/>.</remarks>
        public virtual bool PruneStackAllocArrayCreationExpressionSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "StackAllocKeyword")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneStackAllocArrayCreationExpressionSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneStackAllocArrayCreationExpressionSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneStackAllocArrayCreationExpressionSelectorCore(property);
    		PruneStackAllocArrayCreationExpressionSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneQueryExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneQueryExpressionSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneQueryExpressionSelectorCore(XElement)"/> is not executed and <see cref="PruneQueryExpressionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneQueryExpressionSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneQueryExpressionSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneQueryExpressionSelectorCore(XElement)"/>.</param>
        partial void PruneQueryExpressionSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneQueryExpressionSelector(XElement)"/>.</remarks>
        public virtual bool PruneQueryExpressionSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneQueryExpressionSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneQueryExpressionSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneQueryExpressionSelectorCore(property);
    		PruneQueryExpressionSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneOmittedArraySizeExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneOmittedArraySizeExpressionSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneOmittedArraySizeExpressionSelectorCore(XElement)"/> is not executed and <see cref="PruneOmittedArraySizeExpressionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneOmittedArraySizeExpressionSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneOmittedArraySizeExpressionSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneOmittedArraySizeExpressionSelectorCore(XElement)"/>.</param>
        partial void PruneOmittedArraySizeExpressionSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneOmittedArraySizeExpressionSelector(XElement)"/>.</remarks>
        public virtual bool PruneOmittedArraySizeExpressionSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "OmittedArraySizeExpressionToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneOmittedArraySizeExpressionSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneOmittedArraySizeExpressionSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneOmittedArraySizeExpressionSelectorCore(property);
    		PruneOmittedArraySizeExpressionSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneInterpolatedStringExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneInterpolatedStringExpressionSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneInterpolatedStringExpressionSelectorCore(XElement)"/> is not executed and <see cref="PruneInterpolatedStringExpressionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneInterpolatedStringExpressionSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneInterpolatedStringExpressionSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneInterpolatedStringExpressionSelectorCore(XElement)"/>.</param>
        partial void PruneInterpolatedStringExpressionSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneInterpolatedStringExpressionSelector(XElement)"/>.</remarks>
        public virtual bool PruneInterpolatedStringExpressionSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "StringStartToken")
    			return false;
    		if(property.Attribute("part")?.Value == "StringEndToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneInterpolatedStringExpressionSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneInterpolatedStringExpressionSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneInterpolatedStringExpressionSelectorCore(property);
    		PruneInterpolatedStringExpressionSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneIsPatternExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneIsPatternExpressionSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneIsPatternExpressionSelectorCore(XElement)"/> is not executed and <see cref="PruneIsPatternExpressionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneIsPatternExpressionSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneIsPatternExpressionSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneIsPatternExpressionSelectorCore(XElement)"/>.</param>
        partial void PruneIsPatternExpressionSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneIsPatternExpressionSelector(XElement)"/>.</remarks>
        public virtual bool PruneIsPatternExpressionSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "IsKeyword")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneIsPatternExpressionSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneIsPatternExpressionSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneIsPatternExpressionSelectorCore(property);
    		PruneIsPatternExpressionSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneThrowExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneThrowExpressionSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneThrowExpressionSelectorCore(XElement)"/> is not executed and <see cref="PruneThrowExpressionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneThrowExpressionSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneThrowExpressionSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneThrowExpressionSelectorCore(XElement)"/>.</param>
        partial void PruneThrowExpressionSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneThrowExpressionSelector(XElement)"/>.</remarks>
        public virtual bool PruneThrowExpressionSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "ThrowKeyword")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneThrowExpressionSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneThrowExpressionSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneThrowExpressionSelectorCore(property);
    		PruneThrowExpressionSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PrunePredefinedTypeSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PrunePredefinedTypeSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PrunePredefinedTypeSelectorCore(XElement)"/> is not executed and <see cref="PrunePredefinedTypeSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PrunePredefinedTypeSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PrunePredefinedTypeSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PrunePredefinedTypeSelectorCore(XElement)"/>.</param>
        partial void PrunePredefinedTypeSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PrunePredefinedTypeSelector(XElement)"/>.</remarks>
        public virtual bool PrunePredefinedTypeSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PrunePredefinedTypeSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PrunePredefinedTypeSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PrunePredefinedTypeSelectorCore(property);
    		PrunePredefinedTypeSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneArrayTypeSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneArrayTypeSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneArrayTypeSelectorCore(XElement)"/> is not executed and <see cref="PruneArrayTypeSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneArrayTypeSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneArrayTypeSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneArrayTypeSelectorCore(XElement)"/>.</param>
        partial void PruneArrayTypeSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneArrayTypeSelector(XElement)"/>.</remarks>
        public virtual bool PruneArrayTypeSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneArrayTypeSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneArrayTypeSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneArrayTypeSelectorCore(property);
    		PruneArrayTypeSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PrunePointerTypeSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PrunePointerTypeSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PrunePointerTypeSelectorCore(XElement)"/> is not executed and <see cref="PrunePointerTypeSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PrunePointerTypeSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PrunePointerTypeSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PrunePointerTypeSelectorCore(XElement)"/>.</param>
        partial void PrunePointerTypeSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PrunePointerTypeSelector(XElement)"/>.</remarks>
        public virtual bool PrunePointerTypeSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "AsteriskToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PrunePointerTypeSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PrunePointerTypeSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PrunePointerTypeSelectorCore(property);
    		PrunePointerTypeSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneNullableTypeSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneNullableTypeSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneNullableTypeSelectorCore(XElement)"/> is not executed and <see cref="PruneNullableTypeSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneNullableTypeSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneNullableTypeSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneNullableTypeSelectorCore(XElement)"/>.</param>
        partial void PruneNullableTypeSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneNullableTypeSelector(XElement)"/>.</remarks>
        public virtual bool PruneNullableTypeSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "QuestionToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneNullableTypeSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneNullableTypeSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneNullableTypeSelectorCore(property);
    		PruneNullableTypeSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneTupleTypeSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneTupleTypeSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneTupleTypeSelectorCore(XElement)"/> is not executed and <see cref="PruneTupleTypeSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneTupleTypeSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneTupleTypeSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneTupleTypeSelectorCore(XElement)"/>.</param>
        partial void PruneTupleTypeSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneTupleTypeSelector(XElement)"/>.</remarks>
        public virtual bool PruneTupleTypeSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "OpenParenToken")
    			return false;
    		if(property.Attribute("part")?.Value == "CloseParenToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneTupleTypeSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneTupleTypeSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneTupleTypeSelectorCore(property);
    		PruneTupleTypeSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneOmittedTypeArgumentSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneOmittedTypeArgumentSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneOmittedTypeArgumentSelectorCore(XElement)"/> is not executed and <see cref="PruneOmittedTypeArgumentSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneOmittedTypeArgumentSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneOmittedTypeArgumentSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneOmittedTypeArgumentSelectorCore(XElement)"/>.</param>
        partial void PruneOmittedTypeArgumentSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneOmittedTypeArgumentSelector(XElement)"/>.</remarks>
        public virtual bool PruneOmittedTypeArgumentSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "OmittedTypeArgumentToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneOmittedTypeArgumentSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneOmittedTypeArgumentSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneOmittedTypeArgumentSelectorCore(property);
    		PruneOmittedTypeArgumentSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneRefTypeSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneRefTypeSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneRefTypeSelectorCore(XElement)"/> is not executed and <see cref="PruneRefTypeSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneRefTypeSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneRefTypeSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneRefTypeSelectorCore(XElement)"/>.</param>
        partial void PruneRefTypeSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneRefTypeSelector(XElement)"/>.</remarks>
        public virtual bool PruneRefTypeSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "RefKeyword")
    			return false;
    		if(property.Attribute("part")?.Value == "ReadOnlyKeyword")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneRefTypeSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneRefTypeSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneRefTypeSelectorCore(property);
    		PruneRefTypeSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneQualifiedNameSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneQualifiedNameSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneQualifiedNameSelectorCore(XElement)"/> is not executed and <see cref="PruneQualifiedNameSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneQualifiedNameSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneQualifiedNameSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneQualifiedNameSelectorCore(XElement)"/>.</param>
        partial void PruneQualifiedNameSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneQualifiedNameSelector(XElement)"/>.</remarks>
        public virtual bool PruneQualifiedNameSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "DotToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneQualifiedNameSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneQualifiedNameSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneQualifiedNameSelectorCore(property);
    		PruneQualifiedNameSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneAliasQualifiedNameSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneAliasQualifiedNameSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneAliasQualifiedNameSelectorCore(XElement)"/> is not executed and <see cref="PruneAliasQualifiedNameSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneAliasQualifiedNameSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneAliasQualifiedNameSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneAliasQualifiedNameSelectorCore(XElement)"/>.</param>
        partial void PruneAliasQualifiedNameSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneAliasQualifiedNameSelector(XElement)"/>.</remarks>
        public virtual bool PruneAliasQualifiedNameSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "ColonColonToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneAliasQualifiedNameSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneAliasQualifiedNameSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneAliasQualifiedNameSelectorCore(property);
    		PruneAliasQualifiedNameSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneIdentifierNameSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneIdentifierNameSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneIdentifierNameSelectorCore(XElement)"/> is not executed and <see cref="PruneIdentifierNameSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneIdentifierNameSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneIdentifierNameSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneIdentifierNameSelectorCore(XElement)"/>.</param>
        partial void PruneIdentifierNameSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneIdentifierNameSelector(XElement)"/>.</remarks>
        public virtual bool PruneIdentifierNameSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneIdentifierNameSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneIdentifierNameSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneIdentifierNameSelectorCore(property);
    		PruneIdentifierNameSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneGenericNameSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneGenericNameSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneGenericNameSelectorCore(XElement)"/> is not executed and <see cref="PruneGenericNameSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneGenericNameSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneGenericNameSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneGenericNameSelectorCore(XElement)"/>.</param>
        partial void PruneGenericNameSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneGenericNameSelector(XElement)"/>.</remarks>
        public virtual bool PruneGenericNameSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneGenericNameSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneGenericNameSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneGenericNameSelectorCore(property);
    		PruneGenericNameSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneThisExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneThisExpressionSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneThisExpressionSelectorCore(XElement)"/> is not executed and <see cref="PruneThisExpressionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneThisExpressionSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneThisExpressionSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneThisExpressionSelectorCore(XElement)"/>.</param>
        partial void PruneThisExpressionSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneThisExpressionSelector(XElement)"/>.</remarks>
        public virtual bool PruneThisExpressionSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "Token")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneThisExpressionSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneThisExpressionSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneThisExpressionSelectorCore(property);
    		PruneThisExpressionSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneBaseExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneBaseExpressionSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneBaseExpressionSelectorCore(XElement)"/> is not executed and <see cref="PruneBaseExpressionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBaseExpressionSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneBaseExpressionSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneBaseExpressionSelectorCore(XElement)"/>.</param>
        partial void PruneBaseExpressionSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneBaseExpressionSelector(XElement)"/>.</remarks>
        public virtual bool PruneBaseExpressionSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "Token")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneBaseExpressionSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBaseExpressionSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneBaseExpressionSelectorCore(property);
    		PruneBaseExpressionSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneAnonymousMethodExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneAnonymousMethodExpressionSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneAnonymousMethodExpressionSelectorCore(XElement)"/> is not executed and <see cref="PruneAnonymousMethodExpressionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneAnonymousMethodExpressionSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneAnonymousMethodExpressionSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneAnonymousMethodExpressionSelectorCore(XElement)"/>.</param>
        partial void PruneAnonymousMethodExpressionSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneAnonymousMethodExpressionSelector(XElement)"/>.</remarks>
        public virtual bool PruneAnonymousMethodExpressionSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "AsyncKeyword")
    			return false;
    		if(property.Attribute("part")?.Value == "DelegateKeyword")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneAnonymousMethodExpressionSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneAnonymousMethodExpressionSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneAnonymousMethodExpressionSelectorCore(property);
    		PruneAnonymousMethodExpressionSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneSimpleLambdaExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneSimpleLambdaExpressionSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneSimpleLambdaExpressionSelectorCore(XElement)"/> is not executed and <see cref="PruneSimpleLambdaExpressionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneSimpleLambdaExpressionSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneSimpleLambdaExpressionSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneSimpleLambdaExpressionSelectorCore(XElement)"/>.</param>
        partial void PruneSimpleLambdaExpressionSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneSimpleLambdaExpressionSelector(XElement)"/>.</remarks>
        public virtual bool PruneSimpleLambdaExpressionSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "AsyncKeyword")
    			return false;
    		if(property.Attribute("part")?.Value == "ArrowToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneSimpleLambdaExpressionSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneSimpleLambdaExpressionSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneSimpleLambdaExpressionSelectorCore(property);
    		PruneSimpleLambdaExpressionSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneParenthesizedLambdaExpressionSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneParenthesizedLambdaExpressionSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneParenthesizedLambdaExpressionSelectorCore(XElement)"/> is not executed and <see cref="PruneParenthesizedLambdaExpressionSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneParenthesizedLambdaExpressionSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneParenthesizedLambdaExpressionSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneParenthesizedLambdaExpressionSelectorCore(XElement)"/>.</param>
        partial void PruneParenthesizedLambdaExpressionSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneParenthesizedLambdaExpressionSelector(XElement)"/>.</remarks>
        public virtual bool PruneParenthesizedLambdaExpressionSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "AsyncKeyword")
    			return false;
    		if(property.Attribute("part")?.Value == "ArrowToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneParenthesizedLambdaExpressionSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneParenthesizedLambdaExpressionSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneParenthesizedLambdaExpressionSelectorCore(property);
    		PruneParenthesizedLambdaExpressionSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneArgumentListSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneArgumentListSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneArgumentListSelectorCore(XElement)"/> is not executed and <see cref="PruneArgumentListSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneArgumentListSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneArgumentListSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneArgumentListSelectorCore(XElement)"/>.</param>
        partial void PruneArgumentListSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneArgumentListSelector(XElement)"/>.</remarks>
        public virtual bool PruneArgumentListSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "OpenParenToken")
    			return false;
    		if(property.Attribute("part")?.Value == "CloseParenToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneArgumentListSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneArgumentListSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneArgumentListSelectorCore(property);
    		PruneArgumentListSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneBracketedArgumentListSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneBracketedArgumentListSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneBracketedArgumentListSelectorCore(XElement)"/> is not executed and <see cref="PruneBracketedArgumentListSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBracketedArgumentListSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneBracketedArgumentListSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneBracketedArgumentListSelectorCore(XElement)"/>.</param>
        partial void PruneBracketedArgumentListSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneBracketedArgumentListSelector(XElement)"/>.</remarks>
        public virtual bool PruneBracketedArgumentListSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "OpenBracketToken")
    			return false;
    		if(property.Attribute("part")?.Value == "CloseBracketToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneBracketedArgumentListSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBracketedArgumentListSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneBracketedArgumentListSelectorCore(property);
    		PruneBracketedArgumentListSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneFromClauseSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneFromClauseSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneFromClauseSelectorCore(XElement)"/> is not executed and <see cref="PruneFromClauseSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneFromClauseSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneFromClauseSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneFromClauseSelectorCore(XElement)"/>.</param>
        partial void PruneFromClauseSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneFromClauseSelector(XElement)"/>.</remarks>
        public virtual bool PruneFromClauseSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "FromKeyword")
    			return false;
    		if(property.Attribute("part")?.Value == "InKeyword")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneFromClauseSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneFromClauseSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneFromClauseSelectorCore(property);
    		PruneFromClauseSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneLetClauseSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneLetClauseSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneLetClauseSelectorCore(XElement)"/> is not executed and <see cref="PruneLetClauseSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneLetClauseSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneLetClauseSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneLetClauseSelectorCore(XElement)"/>.</param>
        partial void PruneLetClauseSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneLetClauseSelector(XElement)"/>.</remarks>
        public virtual bool PruneLetClauseSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "LetKeyword")
    			return false;
    		if(property.Attribute("part")?.Value == "EqualsToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneLetClauseSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneLetClauseSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneLetClauseSelectorCore(property);
    		PruneLetClauseSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneJoinClauseSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneJoinClauseSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneJoinClauseSelectorCore(XElement)"/> is not executed and <see cref="PruneJoinClauseSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneJoinClauseSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneJoinClauseSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneJoinClauseSelectorCore(XElement)"/>.</param>
        partial void PruneJoinClauseSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneJoinClauseSelector(XElement)"/>.</remarks>
        public virtual bool PruneJoinClauseSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "JoinKeyword")
    			return false;
    		if(property.Attribute("part")?.Value == "InKeyword")
    			return false;
    		if(property.Attribute("part")?.Value == "OnKeyword")
    			return false;
    		if(property.Attribute("part")?.Value == "EqualsKeyword")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneJoinClauseSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneJoinClauseSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneJoinClauseSelectorCore(property);
    		PruneJoinClauseSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneWhereClauseSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneWhereClauseSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneWhereClauseSelectorCore(XElement)"/> is not executed and <see cref="PruneWhereClauseSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneWhereClauseSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneWhereClauseSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneWhereClauseSelectorCore(XElement)"/>.</param>
        partial void PruneWhereClauseSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneWhereClauseSelector(XElement)"/>.</remarks>
        public virtual bool PruneWhereClauseSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "WhereKeyword")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneWhereClauseSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneWhereClauseSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneWhereClauseSelectorCore(property);
    		PruneWhereClauseSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneOrderByClauseSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneOrderByClauseSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneOrderByClauseSelectorCore(XElement)"/> is not executed and <see cref="PruneOrderByClauseSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneOrderByClauseSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneOrderByClauseSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneOrderByClauseSelectorCore(XElement)"/>.</param>
        partial void PruneOrderByClauseSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneOrderByClauseSelector(XElement)"/>.</remarks>
        public virtual bool PruneOrderByClauseSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "OrderByKeyword")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneOrderByClauseSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneOrderByClauseSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneOrderByClauseSelectorCore(property);
    		PruneOrderByClauseSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneSelectClauseSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneSelectClauseSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneSelectClauseSelectorCore(XElement)"/> is not executed and <see cref="PruneSelectClauseSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneSelectClauseSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneSelectClauseSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneSelectClauseSelectorCore(XElement)"/>.</param>
        partial void PruneSelectClauseSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneSelectClauseSelector(XElement)"/>.</remarks>
        public virtual bool PruneSelectClauseSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "SelectKeyword")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneSelectClauseSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneSelectClauseSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneSelectClauseSelectorCore(property);
    		PruneSelectClauseSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneGroupClauseSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneGroupClauseSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneGroupClauseSelectorCore(XElement)"/> is not executed and <see cref="PruneGroupClauseSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneGroupClauseSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneGroupClauseSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneGroupClauseSelectorCore(XElement)"/>.</param>
        partial void PruneGroupClauseSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneGroupClauseSelector(XElement)"/>.</remarks>
        public virtual bool PruneGroupClauseSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "GroupKeyword")
    			return false;
    		if(property.Attribute("part")?.Value == "ByKeyword")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneGroupClauseSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneGroupClauseSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneGroupClauseSelectorCore(property);
    		PruneGroupClauseSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneDeclarationPatternSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneDeclarationPatternSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneDeclarationPatternSelectorCore(XElement)"/> is not executed and <see cref="PruneDeclarationPatternSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneDeclarationPatternSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneDeclarationPatternSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneDeclarationPatternSelectorCore(XElement)"/>.</param>
        partial void PruneDeclarationPatternSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneDeclarationPatternSelector(XElement)"/>.</remarks>
        public virtual bool PruneDeclarationPatternSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneDeclarationPatternSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneDeclarationPatternSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneDeclarationPatternSelectorCore(property);
    		PruneDeclarationPatternSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneConstantPatternSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneConstantPatternSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneConstantPatternSelectorCore(XElement)"/> is not executed and <see cref="PruneConstantPatternSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneConstantPatternSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneConstantPatternSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneConstantPatternSelectorCore(XElement)"/>.</param>
        partial void PruneConstantPatternSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneConstantPatternSelector(XElement)"/>.</remarks>
        public virtual bool PruneConstantPatternSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneConstantPatternSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneConstantPatternSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneConstantPatternSelectorCore(property);
    		PruneConstantPatternSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneInterpolatedStringTextSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneInterpolatedStringTextSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneInterpolatedStringTextSelectorCore(XElement)"/> is not executed and <see cref="PruneInterpolatedStringTextSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneInterpolatedStringTextSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneInterpolatedStringTextSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneInterpolatedStringTextSelectorCore(XElement)"/>.</param>
        partial void PruneInterpolatedStringTextSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneInterpolatedStringTextSelector(XElement)"/>.</remarks>
        public virtual bool PruneInterpolatedStringTextSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneInterpolatedStringTextSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneInterpolatedStringTextSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneInterpolatedStringTextSelectorCore(property);
    		PruneInterpolatedStringTextSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneInterpolationSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneInterpolationSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneInterpolationSelectorCore(XElement)"/> is not executed and <see cref="PruneInterpolationSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneInterpolationSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneInterpolationSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneInterpolationSelectorCore(XElement)"/>.</param>
        partial void PruneInterpolationSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneInterpolationSelector(XElement)"/>.</remarks>
        public virtual bool PruneInterpolationSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "OpenBraceToken")
    			return false;
    		if(property.Attribute("part")?.Value == "CloseBraceToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneInterpolationSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneInterpolationSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneInterpolationSelectorCore(property);
    		PruneInterpolationSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneBlockSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneBlockSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneBlockSelectorCore(XElement)"/> is not executed and <see cref="PruneBlockSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBlockSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneBlockSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneBlockSelectorCore(XElement)"/>.</param>
        partial void PruneBlockSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneBlockSelector(XElement)"/>.</remarks>
        public virtual bool PruneBlockSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "OpenBraceToken")
    			return false;
    		if(property.Attribute("part")?.Value == "CloseBraceToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneBlockSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBlockSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneBlockSelectorCore(property);
    		PruneBlockSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneLocalFunctionStatementSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneLocalFunctionStatementSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneLocalFunctionStatementSelectorCore(XElement)"/> is not executed and <see cref="PruneLocalFunctionStatementSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneLocalFunctionStatementSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneLocalFunctionStatementSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneLocalFunctionStatementSelectorCore(XElement)"/>.</param>
        partial void PruneLocalFunctionStatementSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneLocalFunctionStatementSelector(XElement)"/>.</remarks>
        public virtual bool PruneLocalFunctionStatementSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "SemicolonToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneLocalFunctionStatementSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneLocalFunctionStatementSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneLocalFunctionStatementSelectorCore(property);
    		PruneLocalFunctionStatementSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneLocalDeclarationStatementSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneLocalDeclarationStatementSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneLocalDeclarationStatementSelectorCore(XElement)"/> is not executed and <see cref="PruneLocalDeclarationStatementSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneLocalDeclarationStatementSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneLocalDeclarationStatementSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneLocalDeclarationStatementSelectorCore(XElement)"/>.</param>
        partial void PruneLocalDeclarationStatementSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneLocalDeclarationStatementSelector(XElement)"/>.</remarks>
        public virtual bool PruneLocalDeclarationStatementSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "SemicolonToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneLocalDeclarationStatementSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneLocalDeclarationStatementSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneLocalDeclarationStatementSelectorCore(property);
    		PruneLocalDeclarationStatementSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneExpressionStatementSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneExpressionStatementSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneExpressionStatementSelectorCore(XElement)"/> is not executed and <see cref="PruneExpressionStatementSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneExpressionStatementSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneExpressionStatementSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneExpressionStatementSelectorCore(XElement)"/>.</param>
        partial void PruneExpressionStatementSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneExpressionStatementSelector(XElement)"/>.</remarks>
        public virtual bool PruneExpressionStatementSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "SemicolonToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneExpressionStatementSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneExpressionStatementSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneExpressionStatementSelectorCore(property);
    		PruneExpressionStatementSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneEmptyStatementSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneEmptyStatementSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneEmptyStatementSelectorCore(XElement)"/> is not executed and <see cref="PruneEmptyStatementSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneEmptyStatementSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneEmptyStatementSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneEmptyStatementSelectorCore(XElement)"/>.</param>
        partial void PruneEmptyStatementSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneEmptyStatementSelector(XElement)"/>.</remarks>
        public virtual bool PruneEmptyStatementSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "SemicolonToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneEmptyStatementSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneEmptyStatementSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneEmptyStatementSelectorCore(property);
    		PruneEmptyStatementSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneLabeledStatementSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneLabeledStatementSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneLabeledStatementSelectorCore(XElement)"/> is not executed and <see cref="PruneLabeledStatementSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneLabeledStatementSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneLabeledStatementSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneLabeledStatementSelectorCore(XElement)"/>.</param>
        partial void PruneLabeledStatementSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneLabeledStatementSelector(XElement)"/>.</remarks>
        public virtual bool PruneLabeledStatementSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "ColonToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneLabeledStatementSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneLabeledStatementSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneLabeledStatementSelectorCore(property);
    		PruneLabeledStatementSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneGotoStatementSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneGotoStatementSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneGotoStatementSelectorCore(XElement)"/> is not executed and <see cref="PruneGotoStatementSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneGotoStatementSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneGotoStatementSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneGotoStatementSelectorCore(XElement)"/>.</param>
        partial void PruneGotoStatementSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneGotoStatementSelector(XElement)"/>.</remarks>
        public virtual bool PruneGotoStatementSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "GotoKeyword")
    			return false;
    		if(property.Attribute("part")?.Value == "CaseOrDefaultKeyword")
    			return false;
    		if(property.Attribute("part")?.Value == "SemicolonToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneGotoStatementSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneGotoStatementSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneGotoStatementSelectorCore(property);
    		PruneGotoStatementSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneBreakStatementSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneBreakStatementSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneBreakStatementSelectorCore(XElement)"/> is not executed and <see cref="PruneBreakStatementSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneBreakStatementSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneBreakStatementSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneBreakStatementSelectorCore(XElement)"/>.</param>
        partial void PruneBreakStatementSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneBreakStatementSelector(XElement)"/>.</remarks>
        public virtual bool PruneBreakStatementSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "BreakKeyword")
    			return false;
    		if(property.Attribute("part")?.Value == "SemicolonToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneBreakStatementSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneBreakStatementSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneBreakStatementSelectorCore(property);
    		PruneBreakStatementSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneContinueStatementSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneContinueStatementSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneContinueStatementSelectorCore(XElement)"/> is not executed and <see cref="PruneContinueStatementSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneContinueStatementSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneContinueStatementSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneContinueStatementSelectorCore(XElement)"/>.</param>
        partial void PruneContinueStatementSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneContinueStatementSelector(XElement)"/>.</remarks>
        public virtual bool PruneContinueStatementSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "ContinueKeyword")
    			return false;
    		if(property.Attribute("part")?.Value == "SemicolonToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneContinueStatementSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneContinueStatementSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneContinueStatementSelectorCore(property);
    		PruneContinueStatementSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneReturnStatementSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneReturnStatementSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneReturnStatementSelectorCore(XElement)"/> is not executed and <see cref="PruneReturnStatementSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneReturnStatementSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneReturnStatementSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneReturnStatementSelectorCore(XElement)"/>.</param>
        partial void PruneReturnStatementSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneReturnStatementSelector(XElement)"/>.</remarks>
        public virtual bool PruneReturnStatementSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "ReturnKeyword")
    			return false;
    		if(property.Attribute("part")?.Value == "SemicolonToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneReturnStatementSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneReturnStatementSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneReturnStatementSelectorCore(property);
    		PruneReturnStatementSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneThrowStatementSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneThrowStatementSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneThrowStatementSelectorCore(XElement)"/> is not executed and <see cref="PruneThrowStatementSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneThrowStatementSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneThrowStatementSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneThrowStatementSelectorCore(XElement)"/>.</param>
        partial void PruneThrowStatementSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneThrowStatementSelector(XElement)"/>.</remarks>
        public virtual bool PruneThrowStatementSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "ThrowKeyword")
    			return false;
    		if(property.Attribute("part")?.Value == "SemicolonToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneThrowStatementSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneThrowStatementSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneThrowStatementSelectorCore(property);
    		PruneThrowStatementSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneYieldStatementSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneYieldStatementSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneYieldStatementSelectorCore(XElement)"/> is not executed and <see cref="PruneYieldStatementSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneYieldStatementSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneYieldStatementSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneYieldStatementSelectorCore(XElement)"/>.</param>
        partial void PruneYieldStatementSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneYieldStatementSelector(XElement)"/>.</remarks>
        public virtual bool PruneYieldStatementSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "YieldKeyword")
    			return false;
    		if(property.Attribute("part")?.Value == "ReturnOrBreakKeyword")
    			return false;
    		if(property.Attribute("part")?.Value == "SemicolonToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneYieldStatementSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneYieldStatementSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneYieldStatementSelectorCore(property);
    		PruneYieldStatementSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneWhileStatementSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneWhileStatementSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneWhileStatementSelectorCore(XElement)"/> is not executed and <see cref="PruneWhileStatementSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneWhileStatementSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneWhileStatementSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneWhileStatementSelectorCore(XElement)"/>.</param>
        partial void PruneWhileStatementSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneWhileStatementSelector(XElement)"/>.</remarks>
        public virtual bool PruneWhileStatementSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "WhileKeyword")
    			return false;
    		if(property.Attribute("part")?.Value == "OpenParenToken")
    			return false;
    		if(property.Attribute("part")?.Value == "CloseParenToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneWhileStatementSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneWhileStatementSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneWhileStatementSelectorCore(property);
    		PruneWhileStatementSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneDoStatementSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneDoStatementSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneDoStatementSelectorCore(XElement)"/> is not executed and <see cref="PruneDoStatementSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneDoStatementSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneDoStatementSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneDoStatementSelectorCore(XElement)"/>.</param>
        partial void PruneDoStatementSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneDoStatementSelector(XElement)"/>.</remarks>
        public virtual bool PruneDoStatementSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "DoKeyword")
    			return false;
    		if(property.Attribute("part")?.Value == "WhileKeyword")
    			return false;
    		if(property.Attribute("part")?.Value == "OpenParenToken")
    			return false;
    		if(property.Attribute("part")?.Value == "CloseParenToken")
    			return false;
    		if(property.Attribute("part")?.Value == "SemicolonToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneDoStatementSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneDoStatementSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneDoStatementSelectorCore(property);
    		PruneDoStatementSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneForStatementSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneForStatementSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneForStatementSelectorCore(XElement)"/> is not executed and <see cref="PruneForStatementSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneForStatementSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneForStatementSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneForStatementSelectorCore(XElement)"/>.</param>
        partial void PruneForStatementSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneForStatementSelector(XElement)"/>.</remarks>
        public virtual bool PruneForStatementSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "ForKeyword")
    			return false;
    		if(property.Attribute("part")?.Value == "OpenParenToken")
    			return false;
    		if(property.Attribute("part")?.Value == "FirstSemicolonToken")
    			return false;
    		if(property.Attribute("part")?.Value == "SecondSemicolonToken")
    			return false;
    		if(property.Attribute("part")?.Value == "CloseParenToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneForStatementSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneForStatementSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneForStatementSelectorCore(property);
    		PruneForStatementSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneUsingStatementSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneUsingStatementSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneUsingStatementSelectorCore(XElement)"/> is not executed and <see cref="PruneUsingStatementSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneUsingStatementSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneUsingStatementSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneUsingStatementSelectorCore(XElement)"/>.</param>
        partial void PruneUsingStatementSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneUsingStatementSelector(XElement)"/>.</remarks>
        public virtual bool PruneUsingStatementSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "UsingKeyword")
    			return false;
    		if(property.Attribute("part")?.Value == "OpenParenToken")
    			return false;
    		if(property.Attribute("part")?.Value == "CloseParenToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneUsingStatementSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneUsingStatementSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneUsingStatementSelectorCore(property);
    		PruneUsingStatementSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneFixedStatementSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneFixedStatementSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneFixedStatementSelectorCore(XElement)"/> is not executed and <see cref="PruneFixedStatementSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneFixedStatementSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneFixedStatementSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneFixedStatementSelectorCore(XElement)"/>.</param>
        partial void PruneFixedStatementSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneFixedStatementSelector(XElement)"/>.</remarks>
        public virtual bool PruneFixedStatementSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "FixedKeyword")
    			return false;
    		if(property.Attribute("part")?.Value == "OpenParenToken")
    			return false;
    		if(property.Attribute("part")?.Value == "CloseParenToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneFixedStatementSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneFixedStatementSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneFixedStatementSelectorCore(property);
    		PruneFixedStatementSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneCheckedStatementSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneCheckedStatementSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCheckedStatementSelectorCore(XElement)"/> is not executed and <see cref="PruneCheckedStatementSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneCheckedStatementSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCheckedStatementSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneCheckedStatementSelectorCore(XElement)"/>.</param>
        partial void PruneCheckedStatementSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneCheckedStatementSelector(XElement)"/>.</remarks>
        public virtual bool PruneCheckedStatementSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "Keyword")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneCheckedStatementSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneCheckedStatementSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCheckedStatementSelectorCore(property);
    		PruneCheckedStatementSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneUnsafeStatementSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneUnsafeStatementSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneUnsafeStatementSelectorCore(XElement)"/> is not executed and <see cref="PruneUnsafeStatementSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneUnsafeStatementSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneUnsafeStatementSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneUnsafeStatementSelectorCore(XElement)"/>.</param>
        partial void PruneUnsafeStatementSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneUnsafeStatementSelector(XElement)"/>.</remarks>
        public virtual bool PruneUnsafeStatementSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "UnsafeKeyword")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneUnsafeStatementSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneUnsafeStatementSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneUnsafeStatementSelectorCore(property);
    		PruneUnsafeStatementSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneLockStatementSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneLockStatementSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneLockStatementSelectorCore(XElement)"/> is not executed and <see cref="PruneLockStatementSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneLockStatementSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneLockStatementSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneLockStatementSelectorCore(XElement)"/>.</param>
        partial void PruneLockStatementSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneLockStatementSelector(XElement)"/>.</remarks>
        public virtual bool PruneLockStatementSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "LockKeyword")
    			return false;
    		if(property.Attribute("part")?.Value == "OpenParenToken")
    			return false;
    		if(property.Attribute("part")?.Value == "CloseParenToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneLockStatementSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneLockStatementSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneLockStatementSelectorCore(property);
    		PruneLockStatementSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneIfStatementSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneIfStatementSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneIfStatementSelectorCore(XElement)"/> is not executed and <see cref="PruneIfStatementSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneIfStatementSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneIfStatementSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneIfStatementSelectorCore(XElement)"/>.</param>
        partial void PruneIfStatementSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneIfStatementSelector(XElement)"/>.</remarks>
        public virtual bool PruneIfStatementSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "IfKeyword")
    			return false;
    		if(property.Attribute("part")?.Value == "OpenParenToken")
    			return false;
    		if(property.Attribute("part")?.Value == "CloseParenToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneIfStatementSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneIfStatementSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneIfStatementSelectorCore(property);
    		PruneIfStatementSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneSwitchStatementSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneSwitchStatementSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneSwitchStatementSelectorCore(XElement)"/> is not executed and <see cref="PruneSwitchStatementSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneSwitchStatementSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneSwitchStatementSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneSwitchStatementSelectorCore(XElement)"/>.</param>
        partial void PruneSwitchStatementSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneSwitchStatementSelector(XElement)"/>.</remarks>
        public virtual bool PruneSwitchStatementSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "SwitchKeyword")
    			return false;
    		if(property.Attribute("part")?.Value == "OpenParenToken")
    			return false;
    		if(property.Attribute("part")?.Value == "CloseParenToken")
    			return false;
    		if(property.Attribute("part")?.Value == "OpenBraceToken")
    			return false;
    		if(property.Attribute("part")?.Value == "CloseBraceToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneSwitchStatementSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneSwitchStatementSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneSwitchStatementSelectorCore(property);
    		PruneSwitchStatementSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneTryStatementSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneTryStatementSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneTryStatementSelectorCore(XElement)"/> is not executed and <see cref="PruneTryStatementSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneTryStatementSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneTryStatementSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneTryStatementSelectorCore(XElement)"/>.</param>
        partial void PruneTryStatementSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneTryStatementSelector(XElement)"/>.</remarks>
        public virtual bool PruneTryStatementSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "TryKeyword")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneTryStatementSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneTryStatementSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneTryStatementSelectorCore(property);
    		PruneTryStatementSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneForEachStatementSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneForEachStatementSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneForEachStatementSelectorCore(XElement)"/> is not executed and <see cref="PruneForEachStatementSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneForEachStatementSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneForEachStatementSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneForEachStatementSelectorCore(XElement)"/>.</param>
        partial void PruneForEachStatementSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneForEachStatementSelector(XElement)"/>.</remarks>
        public virtual bool PruneForEachStatementSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "ForEachKeyword")
    			return false;
    		if(property.Attribute("part")?.Value == "OpenParenToken")
    			return false;
    		if(property.Attribute("part")?.Value == "InKeyword")
    			return false;
    		if(property.Attribute("part")?.Value == "CloseParenToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneForEachStatementSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneForEachStatementSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneForEachStatementSelectorCore(property);
    		PruneForEachStatementSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneForEachVariableStatementSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneForEachVariableStatementSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneForEachVariableStatementSelectorCore(XElement)"/> is not executed and <see cref="PruneForEachVariableStatementSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneForEachVariableStatementSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneForEachVariableStatementSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneForEachVariableStatementSelectorCore(XElement)"/>.</param>
        partial void PruneForEachVariableStatementSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneForEachVariableStatementSelector(XElement)"/>.</remarks>
        public virtual bool PruneForEachVariableStatementSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "ForEachKeyword")
    			return false;
    		if(property.Attribute("part")?.Value == "OpenParenToken")
    			return false;
    		if(property.Attribute("part")?.Value == "InKeyword")
    			return false;
    		if(property.Attribute("part")?.Value == "CloseParenToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneForEachVariableStatementSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneForEachVariableStatementSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneForEachVariableStatementSelectorCore(property);
    		PruneForEachVariableStatementSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneSingleVariableDesignationSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneSingleVariableDesignationSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneSingleVariableDesignationSelectorCore(XElement)"/> is not executed and <see cref="PruneSingleVariableDesignationSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneSingleVariableDesignationSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneSingleVariableDesignationSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneSingleVariableDesignationSelectorCore(XElement)"/>.</param>
        partial void PruneSingleVariableDesignationSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneSingleVariableDesignationSelector(XElement)"/>.</remarks>
        public virtual bool PruneSingleVariableDesignationSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneSingleVariableDesignationSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneSingleVariableDesignationSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneSingleVariableDesignationSelectorCore(property);
    		PruneSingleVariableDesignationSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneDiscardDesignationSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneDiscardDesignationSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneDiscardDesignationSelectorCore(XElement)"/> is not executed and <see cref="PruneDiscardDesignationSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneDiscardDesignationSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneDiscardDesignationSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneDiscardDesignationSelectorCore(XElement)"/>.</param>
        partial void PruneDiscardDesignationSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneDiscardDesignationSelector(XElement)"/>.</remarks>
        public virtual bool PruneDiscardDesignationSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "UnderscoreToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneDiscardDesignationSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneDiscardDesignationSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneDiscardDesignationSelectorCore(property);
    		PruneDiscardDesignationSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneParenthesizedVariableDesignationSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneParenthesizedVariableDesignationSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneParenthesizedVariableDesignationSelectorCore(XElement)"/> is not executed and <see cref="PruneParenthesizedVariableDesignationSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneParenthesizedVariableDesignationSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneParenthesizedVariableDesignationSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneParenthesizedVariableDesignationSelectorCore(XElement)"/>.</param>
        partial void PruneParenthesizedVariableDesignationSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneParenthesizedVariableDesignationSelector(XElement)"/>.</remarks>
        public virtual bool PruneParenthesizedVariableDesignationSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "OpenParenToken")
    			return false;
    		if(property.Attribute("part")?.Value == "CloseParenToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneParenthesizedVariableDesignationSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneParenthesizedVariableDesignationSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneParenthesizedVariableDesignationSelectorCore(property);
    		PruneParenthesizedVariableDesignationSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneCasePatternSwitchLabelSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneCasePatternSwitchLabelSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCasePatternSwitchLabelSelectorCore(XElement)"/> is not executed and <see cref="PruneCasePatternSwitchLabelSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneCasePatternSwitchLabelSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCasePatternSwitchLabelSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneCasePatternSwitchLabelSelectorCore(XElement)"/>.</param>
        partial void PruneCasePatternSwitchLabelSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneCasePatternSwitchLabelSelector(XElement)"/>.</remarks>
        public virtual bool PruneCasePatternSwitchLabelSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "Keyword")
    			return false;
    		if(property.Attribute("part")?.Value == "ColonToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneCasePatternSwitchLabelSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneCasePatternSwitchLabelSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCasePatternSwitchLabelSelectorCore(property);
    		PruneCasePatternSwitchLabelSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneCaseSwitchLabelSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneCaseSwitchLabelSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneCaseSwitchLabelSelectorCore(XElement)"/> is not executed and <see cref="PruneCaseSwitchLabelSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneCaseSwitchLabelSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCaseSwitchLabelSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneCaseSwitchLabelSelectorCore(XElement)"/>.</param>
        partial void PruneCaseSwitchLabelSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneCaseSwitchLabelSelector(XElement)"/>.</remarks>
        public virtual bool PruneCaseSwitchLabelSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "Keyword")
    			return false;
    		if(property.Attribute("part")?.Value == "ColonToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneCaseSwitchLabelSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneCaseSwitchLabelSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneCaseSwitchLabelSelectorCore(property);
    		PruneCaseSwitchLabelSelectorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="PruneDefaultSwitchLabelSelector(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneDefaultSwitchLabelSelector(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="PruneDefaultSwitchLabelSelectorCore(XElement)"/> is not executed and <see cref="PruneDefaultSwitchLabelSelector(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void PruneDefaultSwitchLabelSelectorBefore(XElement property, ref bool result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneDefaultSwitchLabelSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneDefaultSwitchLabelSelectorCore(XElement)"/>.</param>
        partial void PruneDefaultSwitchLabelSelectorAfter(XElement property, ref bool result);
    
    	/// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        /// <remarks>This is the default implementation for <see cref="PruneDefaultSwitchLabelSelector(XElement)"/>.</remarks>
        public virtual bool PruneDefaultSwitchLabelSelectorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "Keyword")
    			return false;
    		if(property.Attribute("part")?.Value == "ColonToken")
    			return false;
    		
    		return true;
        }	
    	
        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneDefaultSwitchLabelSelector(XElement property)
    	{
    		bool result = true;
    		var ignoreCore = false;
    		PruneDefaultSwitchLabelSelectorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.PruneDefaultSwitchLabelSelectorCore(property);
    		PruneDefaultSwitchLabelSelectorAfter(property, ref result);
    		return result;
    	}
    
    }
}
// Generated helper templates
// Generated items
