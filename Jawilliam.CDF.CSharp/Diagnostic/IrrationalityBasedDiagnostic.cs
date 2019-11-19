
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Jawilliam.CDF.CSharp.Diagnostic
{
    public partial class IrrationalityBasedDiagnostic
    {
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Delete(XElement)"/>.
        /// </summary>
        /// <param name="element">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="Delete(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeleteCore(XElement)"/> is not executed and <see cref="Delete(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeleteBefore(XElement element, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
    
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeleteCore(XElement)"/>.
        /// </summary>
        /// <param name="element">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeleteCore(XElement)"/>.</param>
        partial void DeleteAfter(XElement element, ref IEnumerable<Imprecision> result);
        
        /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="element">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="Delete(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeleteCore(XElement element)
    	{
    		if(element.Parent == null)
    			throw new InvalidOperationException("The parent of a modified element cannot be null.");
    
    		switch(element.Parent.Name.LocalName)
    		{
    			case "AttributeArgument": return this.DeletedFromAttributeArgument(element);
    			case "NameEquals": return this.DeletedFromNameEquals(element);
    			case "TypeParameterList": return this.DeletedFromTypeParameterList(element);
    			case "TypeParameter": return this.DeletedFromTypeParameter(element);
    			case "BaseList": return this.DeletedFromBaseList(element);
    			case "TypeParameterConstraintClause": return this.DeletedFromTypeParameterConstraintClause(element);
    			case "ExplicitInterfaceSpecifier": return this.DeletedFromExplicitInterfaceSpecifier(element);
    			case "ConstructorInitializer": return this.DeletedFromConstructorInitializer(element);
    			case "ArrowExpressionClause": return this.DeletedFromArrowExpressionClause(element);
    			case "AccessorList": return this.DeletedFromAccessorList(element);
    			case "AccessorDeclaration": return this.DeletedFromAccessorDeclaration(element);
    			case "Parameter": return this.DeletedFromParameter(element);
    			case "CrefParameter": return this.DeletedFromCrefParameter(element);
    			case "XmlElementStartTag": return this.DeletedFromXmlElementStartTag(element);
    			case "XmlElementEndTag": return this.DeletedFromXmlElementEndTag(element);
    			case "XmlName": return this.DeletedFromXmlName(element);
    			case "XmlPrefix": return this.DeletedFromXmlPrefix(element);
    			case "TypeArgumentList": return this.DeletedFromTypeArgumentList(element);
    			case "ArrayRankSpecifier": return this.DeletedFromArrayRankSpecifier(element);
    			case "TupleElement": return this.DeletedFromTupleElement(element);
    			case "Argument": return this.DeletedFromArgument(element);
    			case "NameColon": return this.DeletedFromNameColon(element);
    			case "AnonymousObjectMemberDeclarator": return this.DeletedFromAnonymousObjectMemberDeclarator(element);
    			case "QueryBody": return this.DeletedFromQueryBody(element);
    			case "JoinIntoClause": return this.DeletedFromJoinIntoClause(element);
    			case "Ordering": return this.DeletedFromOrdering(element);
    			case "QueryContinuation": return this.DeletedFromQueryContinuation(element);
    			case "WhenClause": return this.DeletedFromWhenClause(element);
    			case "InterpolationAlignmentClause": return this.DeletedFromInterpolationAlignmentClause(element);
    			case "InterpolationFormatClause": return this.DeletedFromInterpolationFormatClause(element);
    			case "VariableDeclaration": return this.DeletedFromVariableDeclaration(element);
    			case "VariableDeclarator": return this.DeletedFromVariableDeclarator(element);
    			case "EqualsValueClause": return this.DeletedFromEqualsValueClause(element);
    			case "ElseClause": return this.DeletedFromElseClause(element);
    			case "SwitchSection": return this.DeletedFromSwitchSection(element);
    			case "CatchClause": return this.DeletedFromCatchClause(element);
    			case "CatchDeclaration": return this.DeletedFromCatchDeclaration(element);
    			case "CatchFilterClause": return this.DeletedFromCatchFilterClause(element);
    			case "FinallyClause": return this.DeletedFromFinallyClause(element);
    			case "CompilationUnit": return this.DeletedFromCompilationUnit(element);
    			case "ExternAliasDirective": return this.DeletedFromExternAliasDirective(element);
    			case "UsingDirective": return this.DeletedFromUsingDirective(element);
    			case "AttributeList": return this.DeletedFromAttributeList(element);
    			case "AttributeTargetSpecifier": return this.DeletedFromAttributeTargetSpecifier(element);
    			case "Attribute": return this.DeletedFromAttribute(element);
    			case "AttributeArgumentList": return this.DeletedFromAttributeArgumentList(element);
    			case "DelegateDeclaration": return this.DeletedFromDelegateDeclaration(element);
    			case "EnumMemberDeclaration": return this.DeletedFromEnumMemberDeclaration(element);
    			case "IncompleteMember": return this.DeletedFromIncompleteMember(element);
    			case "GlobalStatement": return this.DeletedFromGlobalStatement(element);
    			case "NamespaceDeclaration": return this.DeletedFromNamespaceDeclaration(element);
    			case "EnumDeclaration": return this.DeletedFromEnumDeclaration(element);
    			case "ClassDeclaration": return this.DeletedFromClassDeclaration(element);
    			case "StructDeclaration": return this.DeletedFromStructDeclaration(element);
    			case "InterfaceDeclaration": return this.DeletedFromInterfaceDeclaration(element);
    			case "FieldDeclaration": return this.DeletedFromFieldDeclaration(element);
    			case "EventFieldDeclaration": return this.DeletedFromEventFieldDeclaration(element);
    			case "MethodDeclaration": return this.DeletedFromMethodDeclaration(element);
    			case "OperatorDeclaration": return this.DeletedFromOperatorDeclaration(element);
    			case "ConversionOperatorDeclaration": return this.DeletedFromConversionOperatorDeclaration(element);
    			case "ConstructorDeclaration": return this.DeletedFromConstructorDeclaration(element);
    			case "DestructorDeclaration": return this.DeletedFromDestructorDeclaration(element);
    			case "PropertyDeclaration": return this.DeletedFromPropertyDeclaration(element);
    			case "EventDeclaration": return this.DeletedFromEventDeclaration(element);
    			case "IndexerDeclaration": return this.DeletedFromIndexerDeclaration(element);
    			case "SimpleBaseType": return this.DeletedFromSimpleBaseType(element);
    			case "ConstructorConstraint": return this.DeletedFromConstructorConstraint(element);
    			case "ClassOrStructConstraint": return this.DeletedFromClassOrStructConstraint(element);
    			case "TypeConstraint": return this.DeletedFromTypeConstraint(element);
    			case "ParameterList": return this.DeletedFromParameterList(element);
    			case "BracketedParameterList": return this.DeletedFromBracketedParameterList(element);
    			case "SkippedTokensTrivia": return this.DeletedFromSkippedTokensTrivia(element);
    			case "DocumentationCommentTrivia": return this.DeletedFromDocumentationCommentTrivia(element);
    			case "EndIfDirectiveTrivia": return this.DeletedFromEndIfDirectiveTrivia(element);
    			case "RegionDirectiveTrivia": return this.DeletedFromRegionDirectiveTrivia(element);
    			case "EndRegionDirectiveTrivia": return this.DeletedFromEndRegionDirectiveTrivia(element);
    			case "ErrorDirectiveTrivia": return this.DeletedFromErrorDirectiveTrivia(element);
    			case "WarningDirectiveTrivia": return this.DeletedFromWarningDirectiveTrivia(element);
    			case "BadDirectiveTrivia": return this.DeletedFromBadDirectiveTrivia(element);
    			case "DefineDirectiveTrivia": return this.DeletedFromDefineDirectiveTrivia(element);
    			case "UndefDirectiveTrivia": return this.DeletedFromUndefDirectiveTrivia(element);
    			case "LineDirectiveTrivia": return this.DeletedFromLineDirectiveTrivia(element);
    			case "PragmaWarningDirectiveTrivia": return this.DeletedFromPragmaWarningDirectiveTrivia(element);
    			case "PragmaChecksumDirectiveTrivia": return this.DeletedFromPragmaChecksumDirectiveTrivia(element);
    			case "ReferenceDirectiveTrivia": return this.DeletedFromReferenceDirectiveTrivia(element);
    			case "LoadDirectiveTrivia": return this.DeletedFromLoadDirectiveTrivia(element);
    			case "ShebangDirectiveTrivia": return this.DeletedFromShebangDirectiveTrivia(element);
    			case "ElseDirectiveTrivia": return this.DeletedFromElseDirectiveTrivia(element);
    			case "IfDirectiveTrivia": return this.DeletedFromIfDirectiveTrivia(element);
    			case "ElifDirectiveTrivia": return this.DeletedFromElifDirectiveTrivia(element);
    			case "TypeCref": return this.DeletedFromTypeCref(element);
    			case "QualifiedCref": return this.DeletedFromQualifiedCref(element);
    			case "NameMemberCref": return this.DeletedFromNameMemberCref(element);
    			case "IndexerMemberCref": return this.DeletedFromIndexerMemberCref(element);
    			case "OperatorMemberCref": return this.DeletedFromOperatorMemberCref(element);
    			case "ConversionOperatorMemberCref": return this.DeletedFromConversionOperatorMemberCref(element);
    			case "CrefParameterList": return this.DeletedFromCrefParameterList(element);
    			case "CrefBracketedParameterList": return this.DeletedFromCrefBracketedParameterList(element);
    			case "XmlElement": return this.DeletedFromXmlElement(element);
    			case "XmlEmptyElement": return this.DeletedFromXmlEmptyElement(element);
    			case "XmlText": return this.DeletedFromXmlText(element);
    			case "XmlCDataSection": return this.DeletedFromXmlCDataSection(element);
    			case "XmlProcessingInstruction": return this.DeletedFromXmlProcessingInstruction(element);
    			case "XmlComment": return this.DeletedFromXmlComment(element);
    			case "XmlTextAttribute": return this.DeletedFromXmlTextAttribute(element);
    			case "XmlCrefAttribute": return this.DeletedFromXmlCrefAttribute(element);
    			case "XmlNameAttribute": return this.DeletedFromXmlNameAttribute(element);
    			case "ParenthesizedExpression": return this.DeletedFromParenthesizedExpression(element);
    			case "TupleExpression": return this.DeletedFromTupleExpression(element);
    			case "PrefixUnaryExpression": return this.DeletedFromPrefixUnaryExpression(element);
    			case "AwaitExpression": return this.DeletedFromAwaitExpression(element);
    			case "PostfixUnaryExpression": return this.DeletedFromPostfixUnaryExpression(element);
    			case "MemberAccessExpression": return this.DeletedFromMemberAccessExpression(element);
    			case "ConditionalAccessExpression": return this.DeletedFromConditionalAccessExpression(element);
    			case "MemberBindingExpression": return this.DeletedFromMemberBindingExpression(element);
    			case "ElementBindingExpression": return this.DeletedFromElementBindingExpression(element);
    			case "ImplicitElementAccess": return this.DeletedFromImplicitElementAccess(element);
    			case "BinaryExpression": return this.DeletedFromBinaryExpression(element);
    			case "AssignmentExpression": return this.DeletedFromAssignmentExpression(element);
    			case "ConditionalExpression": return this.DeletedFromConditionalExpression(element);
    			case "LiteralExpression": return this.DeletedFromLiteralExpression(element);
    			case "MakeRefExpression": return this.DeletedFromMakeRefExpression(element);
    			case "RefTypeExpression": return this.DeletedFromRefTypeExpression(element);
    			case "RefValueExpression": return this.DeletedFromRefValueExpression(element);
    			case "CheckedExpression": return this.DeletedFromCheckedExpression(element);
    			case "DefaultExpression": return this.DeletedFromDefaultExpression(element);
    			case "TypeOfExpression": return this.DeletedFromTypeOfExpression(element);
    			case "SizeOfExpression": return this.DeletedFromSizeOfExpression(element);
    			case "InvocationExpression": return this.DeletedFromInvocationExpression(element);
    			case "ElementAccessExpression": return this.DeletedFromElementAccessExpression(element);
    			case "DeclarationExpression": return this.DeletedFromDeclarationExpression(element);
    			case "CastExpression": return this.DeletedFromCastExpression(element);
    			case "RefExpression": return this.DeletedFromRefExpression(element);
    			case "InitializerExpression": return this.DeletedFromInitializerExpression(element);
    			case "ObjectCreationExpression": return this.DeletedFromObjectCreationExpression(element);
    			case "AnonymousObjectCreationExpression": return this.DeletedFromAnonymousObjectCreationExpression(element);
    			case "ArrayCreationExpression": return this.DeletedFromArrayCreationExpression(element);
    			case "ImplicitArrayCreationExpression": return this.DeletedFromImplicitArrayCreationExpression(element);
    			case "StackAllocArrayCreationExpression": return this.DeletedFromStackAllocArrayCreationExpression(element);
    			case "QueryExpression": return this.DeletedFromQueryExpression(element);
    			case "OmittedArraySizeExpression": return this.DeletedFromOmittedArraySizeExpression(element);
    			case "InterpolatedStringExpression": return this.DeletedFromInterpolatedStringExpression(element);
    			case "IsPatternExpression": return this.DeletedFromIsPatternExpression(element);
    			case "ThrowExpression": return this.DeletedFromThrowExpression(element);
    			case "PredefinedType": return this.DeletedFromPredefinedType(element);
    			case "ArrayType": return this.DeletedFromArrayType(element);
    			case "PointerType": return this.DeletedFromPointerType(element);
    			case "NullableType": return this.DeletedFromNullableType(element);
    			case "TupleType": return this.DeletedFromTupleType(element);
    			case "OmittedTypeArgument": return this.DeletedFromOmittedTypeArgument(element);
    			case "RefType": return this.DeletedFromRefType(element);
    			case "QualifiedName": return this.DeletedFromQualifiedName(element);
    			case "AliasQualifiedName": return this.DeletedFromAliasQualifiedName(element);
    			case "IdentifierName": return this.DeletedFromIdentifierName(element);
    			case "GenericName": return this.DeletedFromGenericName(element);
    			case "ThisExpression": return this.DeletedFromThisExpression(element);
    			case "BaseExpression": return this.DeletedFromBaseExpression(element);
    			case "AnonymousMethodExpression": return this.DeletedFromAnonymousMethodExpression(element);
    			case "SimpleLambdaExpression": return this.DeletedFromSimpleLambdaExpression(element);
    			case "ParenthesizedLambdaExpression": return this.DeletedFromParenthesizedLambdaExpression(element);
    			case "ArgumentList": return this.DeletedFromArgumentList(element);
    			case "BracketedArgumentList": return this.DeletedFromBracketedArgumentList(element);
    			case "FromClause": return this.DeletedFromFromClause(element);
    			case "LetClause": return this.DeletedFromLetClause(element);
    			case "JoinClause": return this.DeletedFromJoinClause(element);
    			case "WhereClause": return this.DeletedFromWhereClause(element);
    			case "OrderByClause": return this.DeletedFromOrderByClause(element);
    			case "SelectClause": return this.DeletedFromSelectClause(element);
    			case "GroupClause": return this.DeletedFromGroupClause(element);
    			case "DeclarationPattern": return this.DeletedFromDeclarationPattern(element);
    			case "ConstantPattern": return this.DeletedFromConstantPattern(element);
    			case "InterpolatedStringText": return this.DeletedFromInterpolatedStringText(element);
    			case "Interpolation": return this.DeletedFromInterpolation(element);
    			case "Block": return this.DeletedFromBlock(element);
    			case "LocalFunctionStatement": return this.DeletedFromLocalFunctionStatement(element);
    			case "LocalDeclarationStatement": return this.DeletedFromLocalDeclarationStatement(element);
    			case "ExpressionStatement": return this.DeletedFromExpressionStatement(element);
    			case "EmptyStatement": return this.DeletedFromEmptyStatement(element);
    			case "LabeledStatement": return this.DeletedFromLabeledStatement(element);
    			case "GotoStatement": return this.DeletedFromGotoStatement(element);
    			case "BreakStatement": return this.DeletedFromBreakStatement(element);
    			case "ContinueStatement": return this.DeletedFromContinueStatement(element);
    			case "ReturnStatement": return this.DeletedFromReturnStatement(element);
    			case "ThrowStatement": return this.DeletedFromThrowStatement(element);
    			case "YieldStatement": return this.DeletedFromYieldStatement(element);
    			case "WhileStatement": return this.DeletedFromWhileStatement(element);
    			case "DoStatement": return this.DeletedFromDoStatement(element);
    			case "ForStatement": return this.DeletedFromForStatement(element);
    			case "UsingStatement": return this.DeletedFromUsingStatement(element);
    			case "FixedStatement": return this.DeletedFromFixedStatement(element);
    			case "CheckedStatement": return this.DeletedFromCheckedStatement(element);
    			case "UnsafeStatement": return this.DeletedFromUnsafeStatement(element);
    			case "LockStatement": return this.DeletedFromLockStatement(element);
    			case "IfStatement": return this.DeletedFromIfStatement(element);
    			case "SwitchStatement": return this.DeletedFromSwitchStatement(element);
    			case "TryStatement": return this.DeletedFromTryStatement(element);
    			case "ForEachStatement": return this.DeletedFromForEachStatement(element);
    			case "ForEachVariableStatement": return this.DeletedFromForEachVariableStatement(element);
    			case "SingleVariableDesignation": return this.DeletedFromSingleVariableDesignation(element);
    			case "DiscardDesignation": return this.DeletedFromDiscardDesignation(element);
    			case "ParenthesizedVariableDesignation": return this.DeletedFromParenthesizedVariableDesignation(element);
    			case "CasePatternSwitchLabel": return this.DeletedFromCasePatternSwitchLabel(element);
    			case "CaseSwitchLabel": return this.DeletedFromCaseSwitchLabel(element);
    			case "DefaultSwitchLabel": return this.DeletedFromDefaultSwitchLabel(element);
                case "SingleLineCommentTrivia": return this.DeletedFromSingleLineCommentTrivia(element);
                case "MultiLineCommentTrivia": return this.DeletedFromMultiLineCommentTrivia(element);
    			default: throw new ArgumentException($"The type {element.Parent.Name.LocalName} has not been found.");;//return true
    		}
    	}		
    	
        /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="element">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> Delete(XElement element)
        {
            IEnumerable<Imprecision> result = new Imprecision[0];
        	var ignoreCore = false;
        	DeleteBefore(element, ref result, ref ignoreCore);
        	if(ignoreCore) 
        		return result;
        	
        	result = this.DeleteCore(element);
        	DeleteAfter(element, ref result);
        	return result;
        }
    
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromAttributeArgument(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromAttributeArgument(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromAttributeArgumentCore(XElement)"/> is not executed and <see cref="DeletedFromAttributeArgument(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromAttributeArgumentBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromAttributeArgumentCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromAttributeArgumentCore(XElement)"/>.</param>
        partial void DeletedFromAttributeArgumentAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromAttributeArgument(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromAttributeArgumentCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		yield break;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromAttributeArgument(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromAttributeArgumentBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromAttributeArgumentCore(property);
    		DeletedFromAttributeArgumentAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromNameEquals(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromNameEquals(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromNameEqualsCore(XElement)"/> is not executed and <see cref="DeletedFromNameEquals(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromNameEqualsBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromNameEqualsCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromNameEqualsCore(XElement)"/>.</param>
        partial void DeletedFromNameEqualsAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromNameEquals(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromNameEqualsCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "EqualsToken")
    			return false;
    		
    		return true;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromNameEquals(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromNameEqualsBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromNameEqualsCore(property);
    		DeletedFromNameEqualsAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromTypeParameterList(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromTypeParameterList(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromTypeParameterListCore(XElement)"/> is not executed and <see cref="DeletedFromTypeParameterList(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromTypeParameterListBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromTypeParameterListCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromTypeParameterListCore(XElement)"/>.</param>
        partial void DeletedFromTypeParameterListAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromTypeParameterList(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromTypeParameterListCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromTypeParameterList(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromTypeParameterListBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromTypeParameterListCore(property);
    		DeletedFromTypeParameterListAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromTypeParameter(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromTypeParameter(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromTypeParameterCore(XElement)"/> is not executed and <see cref="DeletedFromTypeParameter(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromTypeParameterBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromTypeParameterCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromTypeParameterCore(XElement)"/>.</param>
        partial void DeletedFromTypeParameterAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromTypeParameter(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromTypeParameterCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "VarianceKeyword")
    			return false;
    		
    		return true;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromTypeParameter(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromTypeParameterBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromTypeParameterCore(property);
    		DeletedFromTypeParameterAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromBaseList(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromBaseList(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromBaseListCore(XElement)"/> is not executed and <see cref="DeletedFromBaseList(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromBaseListBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromBaseListCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromBaseListCore(XElement)"/>.</param>
        partial void DeletedFromBaseListAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromBaseList(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromBaseListCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "ColonToken")
    			return false;
    		
    		return true;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromBaseList(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromBaseListBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromBaseListCore(property);
    		DeletedFromBaseListAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromTypeParameterConstraintClause(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromTypeParameterConstraintClause(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromTypeParameterConstraintClauseCore(XElement)"/> is not executed and <see cref="DeletedFromTypeParameterConstraintClause(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromTypeParameterConstraintClauseBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromTypeParameterConstraintClauseCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromTypeParameterConstraintClauseCore(XElement)"/>.</param>
        partial void DeletedFromTypeParameterConstraintClauseAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromTypeParameterConstraintClause(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromTypeParameterConstraintClauseCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromTypeParameterConstraintClause(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromTypeParameterConstraintClauseBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromTypeParameterConstraintClauseCore(property);
    		DeletedFromTypeParameterConstraintClauseAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromExplicitInterfaceSpecifier(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromExplicitInterfaceSpecifier(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromExplicitInterfaceSpecifierCore(XElement)"/> is not executed and <see cref="DeletedFromExplicitInterfaceSpecifier(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromExplicitInterfaceSpecifierBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromExplicitInterfaceSpecifierCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromExplicitInterfaceSpecifierCore(XElement)"/>.</param>
        partial void DeletedFromExplicitInterfaceSpecifierAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromExplicitInterfaceSpecifier(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromExplicitInterfaceSpecifierCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "DotToken")
    			return false;
    		
    		return true;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromExplicitInterfaceSpecifier(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromExplicitInterfaceSpecifierBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromExplicitInterfaceSpecifierCore(property);
    		DeletedFromExplicitInterfaceSpecifierAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromConstructorInitializer(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromConstructorInitializer(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromConstructorInitializerCore(XElement)"/> is not executed and <see cref="DeletedFromConstructorInitializer(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromConstructorInitializerBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromConstructorInitializerCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromConstructorInitializerCore(XElement)"/>.</param>
        partial void DeletedFromConstructorInitializerAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromConstructorInitializer(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromConstructorInitializerCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromConstructorInitializer(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromConstructorInitializerBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromConstructorInitializerCore(property);
    		DeletedFromConstructorInitializerAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromArrowExpressionClause(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromArrowExpressionClause(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromArrowExpressionClauseCore(XElement)"/> is not executed and <see cref="DeletedFromArrowExpressionClause(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromArrowExpressionClauseBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromArrowExpressionClauseCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromArrowExpressionClauseCore(XElement)"/>.</param>
        partial void DeletedFromArrowExpressionClauseAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromArrowExpressionClause(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromArrowExpressionClauseCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "ArrowToken")
    			return false;
    		
    		return true;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromArrowExpressionClause(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromArrowExpressionClauseBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromArrowExpressionClauseCore(property);
    		DeletedFromArrowExpressionClauseAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromAccessorList(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromAccessorList(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromAccessorListCore(XElement)"/> is not executed and <see cref="DeletedFromAccessorList(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromAccessorListBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromAccessorListCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromAccessorListCore(XElement)"/>.</param>
        partial void DeletedFromAccessorListAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromAccessorList(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromAccessorListCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromAccessorList(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromAccessorListBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromAccessorListCore(property);
    		DeletedFromAccessorListAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromAccessorDeclaration(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromAccessorDeclaration(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromAccessorDeclarationCore(XElement)"/> is not executed and <see cref="DeletedFromAccessorDeclaration(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromAccessorDeclarationBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromAccessorDeclarationCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromAccessorDeclarationCore(XElement)"/>.</param>
        partial void DeletedFromAccessorDeclarationAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromAccessorDeclaration(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromAccessorDeclarationCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "SemicolonToken")
    			return false;
    		
    		return true;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromAccessorDeclaration(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromAccessorDeclarationBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromAccessorDeclarationCore(property);
    		DeletedFromAccessorDeclarationAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromParameter(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromParameter(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromParameterCore(XElement)"/> is not executed and <see cref="DeletedFromParameter(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromParameterBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromParameterCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromParameterCore(XElement)"/>.</param>
        partial void DeletedFromParameterAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromParameter(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromParameterCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		yield break;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromParameter(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromParameterBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromParameterCore(property);
    		DeletedFromParameterAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromCrefParameter(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromCrefParameter(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromCrefParameterCore(XElement)"/> is not executed and <see cref="DeletedFromCrefParameter(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromCrefParameterBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromCrefParameterCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromCrefParameterCore(XElement)"/>.</param>
        partial void DeletedFromCrefParameterAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromCrefParameter(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromCrefParameterCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "RefKindKeyword")
    			return false;
    		
    		return true;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromCrefParameter(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromCrefParameterBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromCrefParameterCore(property);
    		DeletedFromCrefParameterAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromXmlElementStartTag(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromXmlElementStartTag(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromXmlElementStartTagCore(XElement)"/> is not executed and <see cref="DeletedFromXmlElementStartTag(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromXmlElementStartTagBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromXmlElementStartTagCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromXmlElementStartTagCore(XElement)"/>.</param>
        partial void DeletedFromXmlElementStartTagAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromXmlElementStartTag(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromXmlElementStartTagCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromXmlElementStartTag(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromXmlElementStartTagBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromXmlElementStartTagCore(property);
    		DeletedFromXmlElementStartTagAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromXmlElementEndTag(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromXmlElementEndTag(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromXmlElementEndTagCore(XElement)"/> is not executed and <see cref="DeletedFromXmlElementEndTag(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromXmlElementEndTagBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromXmlElementEndTagCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromXmlElementEndTagCore(XElement)"/>.</param>
        partial void DeletedFromXmlElementEndTagAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromXmlElementEndTag(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromXmlElementEndTagCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromXmlElementEndTag(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromXmlElementEndTagBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromXmlElementEndTagCore(property);
    		DeletedFromXmlElementEndTagAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromXmlName(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromXmlName(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromXmlNameCore(XElement)"/> is not executed and <see cref="DeletedFromXmlName(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromXmlNameBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromXmlNameCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromXmlNameCore(XElement)"/>.</param>
        partial void DeletedFromXmlNameAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromXmlName(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromXmlNameCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		yield break;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromXmlName(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromXmlNameBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromXmlNameCore(property);
    		DeletedFromXmlNameAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromXmlPrefix(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromXmlPrefix(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromXmlPrefixCore(XElement)"/> is not executed and <see cref="DeletedFromXmlPrefix(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromXmlPrefixBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromXmlPrefixCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromXmlPrefixCore(XElement)"/>.</param>
        partial void DeletedFromXmlPrefixAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromXmlPrefix(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromXmlPrefixCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "ColonToken")
    			return false;
    		
    		return true;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromXmlPrefix(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromXmlPrefixBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromXmlPrefixCore(property);
    		DeletedFromXmlPrefixAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromTypeArgumentList(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromTypeArgumentList(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromTypeArgumentListCore(XElement)"/> is not executed and <see cref="DeletedFromTypeArgumentList(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromTypeArgumentListBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromTypeArgumentListCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromTypeArgumentListCore(XElement)"/>.</param>
        partial void DeletedFromTypeArgumentListAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromTypeArgumentList(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromTypeArgumentListCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromTypeArgumentList(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromTypeArgumentListBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromTypeArgumentListCore(property);
    		DeletedFromTypeArgumentListAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromArrayRankSpecifier(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromArrayRankSpecifier(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromArrayRankSpecifierCore(XElement)"/> is not executed and <see cref="DeletedFromArrayRankSpecifier(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromArrayRankSpecifierBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromArrayRankSpecifierCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromArrayRankSpecifierCore(XElement)"/>.</param>
        partial void DeletedFromArrayRankSpecifierAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromArrayRankSpecifier(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromArrayRankSpecifierCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromArrayRankSpecifier(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromArrayRankSpecifierBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromArrayRankSpecifierCore(property);
    		DeletedFromArrayRankSpecifierAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromTupleElement(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromTupleElement(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromTupleElementCore(XElement)"/> is not executed and <see cref="DeletedFromTupleElement(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromTupleElementBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromTupleElementCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromTupleElementCore(XElement)"/>.</param>
        partial void DeletedFromTupleElementAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromTupleElement(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromTupleElementCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		yield break;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromTupleElement(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromTupleElementBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromTupleElementCore(property);
    		DeletedFromTupleElementAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromArgument(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromArgument(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromArgumentCore(XElement)"/> is not executed and <see cref="DeletedFromArgument(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromArgumentBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromArgumentCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromArgumentCore(XElement)"/>.</param>
        partial void DeletedFromArgumentAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromArgument(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromArgumentCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "RefKindKeyword")
    			return false;
    		
    		return true;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromArgument(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromArgumentBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromArgumentCore(property);
    		DeletedFromArgumentAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromNameColon(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromNameColon(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromNameColonCore(XElement)"/> is not executed and <see cref="DeletedFromNameColon(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromNameColonBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromNameColonCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromNameColonCore(XElement)"/>.</param>
        partial void DeletedFromNameColonAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromNameColon(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromNameColonCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "ColonToken")
    			return false;
    		
    		return true;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromNameColon(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromNameColonBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromNameColonCore(property);
    		DeletedFromNameColonAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromAnonymousObjectMemberDeclarator(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromAnonymousObjectMemberDeclarator(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromAnonymousObjectMemberDeclaratorCore(XElement)"/> is not executed and <see cref="DeletedFromAnonymousObjectMemberDeclarator(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromAnonymousObjectMemberDeclaratorBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromAnonymousObjectMemberDeclaratorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromAnonymousObjectMemberDeclaratorCore(XElement)"/>.</param>
        partial void DeletedFromAnonymousObjectMemberDeclaratorAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromAnonymousObjectMemberDeclarator(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromAnonymousObjectMemberDeclaratorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		yield break;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromAnonymousObjectMemberDeclarator(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromAnonymousObjectMemberDeclaratorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromAnonymousObjectMemberDeclaratorCore(property);
    		DeletedFromAnonymousObjectMemberDeclaratorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromQueryBody(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromQueryBody(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromQueryBodyCore(XElement)"/> is not executed and <see cref="DeletedFromQueryBody(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromQueryBodyBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromQueryBodyCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromQueryBodyCore(XElement)"/>.</param>
        partial void DeletedFromQueryBodyAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromQueryBody(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromQueryBodyCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		yield break;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromQueryBody(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromQueryBodyBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromQueryBodyCore(property);
    		DeletedFromQueryBodyAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromJoinIntoClause(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromJoinIntoClause(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromJoinIntoClauseCore(XElement)"/> is not executed and <see cref="DeletedFromJoinIntoClause(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromJoinIntoClauseBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromJoinIntoClauseCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromJoinIntoClauseCore(XElement)"/>.</param>
        partial void DeletedFromJoinIntoClauseAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromJoinIntoClause(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromJoinIntoClauseCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "IntoKeyword")
    			return false;
    		
    		return true;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromJoinIntoClause(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromJoinIntoClauseBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromJoinIntoClauseCore(property);
    		DeletedFromJoinIntoClauseAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromOrdering(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromOrdering(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromOrderingCore(XElement)"/> is not executed and <see cref="DeletedFromOrdering(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromOrderingBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromOrderingCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromOrderingCore(XElement)"/>.</param>
        partial void DeletedFromOrderingAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromOrdering(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromOrderingCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "AscendingOrDescendingKeyword")
    			return false;
    		
    		return true;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromOrdering(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromOrderingBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromOrderingCore(property);
    		DeletedFromOrderingAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromQueryContinuation(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromQueryContinuation(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromQueryContinuationCore(XElement)"/> is not executed and <see cref="DeletedFromQueryContinuation(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromQueryContinuationBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromQueryContinuationCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromQueryContinuationCore(XElement)"/>.</param>
        partial void DeletedFromQueryContinuationAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromQueryContinuation(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromQueryContinuationCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "IntoKeyword")
    			return false;
    		
    		return true;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromQueryContinuation(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromQueryContinuationBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromQueryContinuationCore(property);
    		DeletedFromQueryContinuationAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromWhenClause(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromWhenClause(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromWhenClauseCore(XElement)"/> is not executed and <see cref="DeletedFromWhenClause(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromWhenClauseBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromWhenClauseCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromWhenClauseCore(XElement)"/>.</param>
        partial void DeletedFromWhenClauseAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromWhenClause(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromWhenClauseCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "WhenKeyword")
    			return false;
    		
    		return true;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromWhenClause(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromWhenClauseBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromWhenClauseCore(property);
    		DeletedFromWhenClauseAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromInterpolationAlignmentClause(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromInterpolationAlignmentClause(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromInterpolationAlignmentClauseCore(XElement)"/> is not executed and <see cref="DeletedFromInterpolationAlignmentClause(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromInterpolationAlignmentClauseBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromInterpolationAlignmentClauseCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromInterpolationAlignmentClauseCore(XElement)"/>.</param>
        partial void DeletedFromInterpolationAlignmentClauseAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromInterpolationAlignmentClause(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromInterpolationAlignmentClauseCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "CommaToken")
    			return false;
    		
    		return true;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromInterpolationAlignmentClause(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromInterpolationAlignmentClauseBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromInterpolationAlignmentClauseCore(property);
    		DeletedFromInterpolationAlignmentClauseAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromInterpolationFormatClause(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromInterpolationFormatClause(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromInterpolationFormatClauseCore(XElement)"/> is not executed and <see cref="DeletedFromInterpolationFormatClause(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromInterpolationFormatClauseBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromInterpolationFormatClauseCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromInterpolationFormatClauseCore(XElement)"/>.</param>
        partial void DeletedFromInterpolationFormatClauseAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromInterpolationFormatClause(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromInterpolationFormatClauseCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "ColonToken")
    			return false;
    		
    		return true;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromInterpolationFormatClause(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromInterpolationFormatClauseBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromInterpolationFormatClauseCore(property);
    		DeletedFromInterpolationFormatClauseAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromVariableDeclaration(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromVariableDeclaration(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromVariableDeclarationCore(XElement)"/> is not executed and <see cref="DeletedFromVariableDeclaration(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromVariableDeclarationBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromVariableDeclarationCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromVariableDeclarationCore(XElement)"/>.</param>
        partial void DeletedFromVariableDeclarationAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromVariableDeclaration(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromVariableDeclarationCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		yield break;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromVariableDeclaration(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromVariableDeclarationBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromVariableDeclarationCore(property);
    		DeletedFromVariableDeclarationAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromVariableDeclarator(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromVariableDeclarator(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromVariableDeclaratorCore(XElement)"/> is not executed and <see cref="DeletedFromVariableDeclarator(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromVariableDeclaratorBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromVariableDeclaratorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromVariableDeclaratorCore(XElement)"/>.</param>
        partial void DeletedFromVariableDeclaratorAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromVariableDeclarator(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromVariableDeclaratorCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		yield break;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromVariableDeclarator(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromVariableDeclaratorBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromVariableDeclaratorCore(property);
    		DeletedFromVariableDeclaratorAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromEqualsValueClause(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromEqualsValueClause(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromEqualsValueClauseCore(XElement)"/> is not executed and <see cref="DeletedFromEqualsValueClause(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromEqualsValueClauseBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromEqualsValueClauseCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromEqualsValueClauseCore(XElement)"/>.</param>
        partial void DeletedFromEqualsValueClauseAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromEqualsValueClause(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromEqualsValueClauseCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "EqualsToken")
    			return false;
    		
    		return true;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromEqualsValueClause(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromEqualsValueClauseBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromEqualsValueClauseCore(property);
    		DeletedFromEqualsValueClauseAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromElseClause(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromElseClause(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromElseClauseCore(XElement)"/> is not executed and <see cref="DeletedFromElseClause(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromElseClauseBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromElseClauseCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromElseClauseCore(XElement)"/>.</param>
        partial void DeletedFromElseClauseAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromElseClause(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromElseClauseCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "ElseKeyword")
    			return false;
    		
    		return true;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromElseClause(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromElseClauseBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromElseClauseCore(property);
    		DeletedFromElseClauseAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromSwitchSection(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromSwitchSection(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromSwitchSectionCore(XElement)"/> is not executed and <see cref="DeletedFromSwitchSection(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromSwitchSectionBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromSwitchSectionCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromSwitchSectionCore(XElement)"/>.</param>
        partial void DeletedFromSwitchSectionAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromSwitchSection(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromSwitchSectionCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		yield break;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromSwitchSection(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromSwitchSectionBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromSwitchSectionCore(property);
    		DeletedFromSwitchSectionAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromCatchClause(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromCatchClause(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromCatchClauseCore(XElement)"/> is not executed and <see cref="DeletedFromCatchClause(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromCatchClauseBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromCatchClauseCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromCatchClauseCore(XElement)"/>.</param>
        partial void DeletedFromCatchClauseAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromCatchClause(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromCatchClauseCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "CatchKeyword")
    			return false;
    		
    		return true;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromCatchClause(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromCatchClauseBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromCatchClauseCore(property);
    		DeletedFromCatchClauseAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromCatchDeclaration(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromCatchDeclaration(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromCatchDeclarationCore(XElement)"/> is not executed and <see cref="DeletedFromCatchDeclaration(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromCatchDeclarationBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromCatchDeclarationCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromCatchDeclarationCore(XElement)"/>.</param>
        partial void DeletedFromCatchDeclarationAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromCatchDeclaration(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromCatchDeclarationCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromCatchDeclaration(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromCatchDeclarationBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromCatchDeclarationCore(property);
    		DeletedFromCatchDeclarationAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromCatchFilterClause(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromCatchFilterClause(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromCatchFilterClauseCore(XElement)"/> is not executed and <see cref="DeletedFromCatchFilterClause(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromCatchFilterClauseBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromCatchFilterClauseCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromCatchFilterClauseCore(XElement)"/>.</param>
        partial void DeletedFromCatchFilterClauseAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromCatchFilterClause(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromCatchFilterClauseCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromCatchFilterClause(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromCatchFilterClauseBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromCatchFilterClauseCore(property);
    		DeletedFromCatchFilterClauseAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromFinallyClause(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromFinallyClause(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromFinallyClauseCore(XElement)"/> is not executed and <see cref="DeletedFromFinallyClause(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromFinallyClauseBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromFinallyClauseCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromFinallyClauseCore(XElement)"/>.</param>
        partial void DeletedFromFinallyClauseAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromFinallyClause(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromFinallyClauseCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "FinallyKeyword")
    			return false;
    		
    		return true;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromFinallyClause(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromFinallyClauseBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromFinallyClauseCore(property);
    		DeletedFromFinallyClauseAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromCompilationUnit(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromCompilationUnit(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromCompilationUnitCore(XElement)"/> is not executed and <see cref="DeletedFromCompilationUnit(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromCompilationUnitBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromCompilationUnitCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromCompilationUnitCore(XElement)"/>.</param>
        partial void DeletedFromCompilationUnitAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromCompilationUnit(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromCompilationUnitCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "EndOfFileToken")
    			return false;
    		
    		return true;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromCompilationUnit(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromCompilationUnitBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromCompilationUnitCore(property);
    		DeletedFromCompilationUnitAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromExternAliasDirective(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromExternAliasDirective(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromExternAliasDirectiveCore(XElement)"/> is not executed and <see cref="DeletedFromExternAliasDirective(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromExternAliasDirectiveBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromExternAliasDirectiveCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromExternAliasDirectiveCore(XElement)"/>.</param>
        partial void DeletedFromExternAliasDirectiveAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromExternAliasDirective(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromExternAliasDirectiveCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromExternAliasDirective(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromExternAliasDirectiveBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromExternAliasDirectiveCore(property);
    		DeletedFromExternAliasDirectiveAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromUsingDirective(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromUsingDirective(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromUsingDirectiveCore(XElement)"/> is not executed and <see cref="DeletedFromUsingDirective(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromUsingDirectiveBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromUsingDirectiveCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromUsingDirectiveCore(XElement)"/>.</param>
        partial void DeletedFromUsingDirectiveAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromUsingDirective(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromUsingDirectiveCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromUsingDirective(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromUsingDirectiveBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromUsingDirectiveCore(property);
    		DeletedFromUsingDirectiveAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromAttributeList(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromAttributeList(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromAttributeListCore(XElement)"/> is not executed and <see cref="DeletedFromAttributeList(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromAttributeListBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromAttributeListCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromAttributeListCore(XElement)"/>.</param>
        partial void DeletedFromAttributeListAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromAttributeList(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromAttributeListCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromAttributeList(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromAttributeListBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromAttributeListCore(property);
    		DeletedFromAttributeListAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromAttributeTargetSpecifier(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromAttributeTargetSpecifier(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromAttributeTargetSpecifierCore(XElement)"/> is not executed and <see cref="DeletedFromAttributeTargetSpecifier(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromAttributeTargetSpecifierBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromAttributeTargetSpecifierCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromAttributeTargetSpecifierCore(XElement)"/>.</param>
        partial void DeletedFromAttributeTargetSpecifierAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromAttributeTargetSpecifier(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromAttributeTargetSpecifierCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "ColonToken")
    			return false;
    		
    		return true;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromAttributeTargetSpecifier(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromAttributeTargetSpecifierBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromAttributeTargetSpecifierCore(property);
    		DeletedFromAttributeTargetSpecifierAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromAttribute(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromAttribute(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromAttributeCore(XElement)"/> is not executed and <see cref="DeletedFromAttribute(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromAttributeBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromAttributeCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromAttributeCore(XElement)"/>.</param>
        partial void DeletedFromAttributeAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromAttribute(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromAttributeCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		yield break;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromAttribute(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromAttributeBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromAttributeCore(property);
    		DeletedFromAttributeAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromAttributeArgumentList(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromAttributeArgumentList(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromAttributeArgumentListCore(XElement)"/> is not executed and <see cref="DeletedFromAttributeArgumentList(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromAttributeArgumentListBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromAttributeArgumentListCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromAttributeArgumentListCore(XElement)"/>.</param>
        partial void DeletedFromAttributeArgumentListAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromAttributeArgumentList(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromAttributeArgumentListCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromAttributeArgumentList(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromAttributeArgumentListBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromAttributeArgumentListCore(property);
    		DeletedFromAttributeArgumentListAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromDelegateDeclaration(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromDelegateDeclaration(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromDelegateDeclarationCore(XElement)"/> is not executed and <see cref="DeletedFromDelegateDeclaration(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromDelegateDeclarationBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromDelegateDeclarationCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromDelegateDeclarationCore(XElement)"/>.</param>
        partial void DeletedFromDelegateDeclarationAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromDelegateDeclaration(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromDelegateDeclarationCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromDelegateDeclaration(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromDelegateDeclarationBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromDelegateDeclarationCore(property);
    		DeletedFromDelegateDeclarationAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromEnumMemberDeclaration(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromEnumMemberDeclaration(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromEnumMemberDeclarationCore(XElement)"/> is not executed and <see cref="DeletedFromEnumMemberDeclaration(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromEnumMemberDeclarationBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromEnumMemberDeclarationCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromEnumMemberDeclarationCore(XElement)"/>.</param>
        partial void DeletedFromEnumMemberDeclarationAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromEnumMemberDeclaration(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromEnumMemberDeclarationCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		yield break;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromEnumMemberDeclaration(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromEnumMemberDeclarationBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromEnumMemberDeclarationCore(property);
    		DeletedFromEnumMemberDeclarationAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromIncompleteMember(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromIncompleteMember(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromIncompleteMemberCore(XElement)"/> is not executed and <see cref="DeletedFromIncompleteMember(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromIncompleteMemberBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromIncompleteMemberCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromIncompleteMemberCore(XElement)"/>.</param>
        partial void DeletedFromIncompleteMemberAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromIncompleteMember(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromIncompleteMemberCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		yield break;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromIncompleteMember(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromIncompleteMemberBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromIncompleteMemberCore(property);
    		DeletedFromIncompleteMemberAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromGlobalStatement(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromGlobalStatement(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromGlobalStatementCore(XElement)"/> is not executed and <see cref="DeletedFromGlobalStatement(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromGlobalStatementBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromGlobalStatementCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromGlobalStatementCore(XElement)"/>.</param>
        partial void DeletedFromGlobalStatementAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromGlobalStatement(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromGlobalStatementCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		yield break;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromGlobalStatement(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromGlobalStatementBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromGlobalStatementCore(property);
    		DeletedFromGlobalStatementAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromNamespaceDeclaration(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromNamespaceDeclaration(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromNamespaceDeclarationCore(XElement)"/> is not executed and <see cref="DeletedFromNamespaceDeclaration(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromNamespaceDeclarationBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromNamespaceDeclarationCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromNamespaceDeclarationCore(XElement)"/>.</param>
        partial void DeletedFromNamespaceDeclarationAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromNamespaceDeclaration(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromNamespaceDeclarationCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromNamespaceDeclaration(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromNamespaceDeclarationBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromNamespaceDeclarationCore(property);
    		DeletedFromNamespaceDeclarationAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromEnumDeclaration(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromEnumDeclaration(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromEnumDeclarationCore(XElement)"/> is not executed and <see cref="DeletedFromEnumDeclaration(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromEnumDeclarationBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromEnumDeclarationCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromEnumDeclarationCore(XElement)"/>.</param>
        partial void DeletedFromEnumDeclarationAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromEnumDeclaration(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromEnumDeclarationCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromEnumDeclaration(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromEnumDeclarationBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromEnumDeclarationCore(property);
    		DeletedFromEnumDeclarationAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromClassDeclaration(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromClassDeclaration(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromClassDeclarationCore(XElement)"/> is not executed and <see cref="DeletedFromClassDeclaration(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromClassDeclarationBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromClassDeclarationCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromClassDeclarationCore(XElement)"/>.</param>
        partial void DeletedFromClassDeclarationAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromClassDeclaration(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromClassDeclarationCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromClassDeclaration(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromClassDeclarationBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromClassDeclarationCore(property);
    		DeletedFromClassDeclarationAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromStructDeclaration(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromStructDeclaration(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromStructDeclarationCore(XElement)"/> is not executed and <see cref="DeletedFromStructDeclaration(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromStructDeclarationBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromStructDeclarationCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromStructDeclarationCore(XElement)"/>.</param>
        partial void DeletedFromStructDeclarationAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromStructDeclaration(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromStructDeclarationCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromStructDeclaration(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromStructDeclarationBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromStructDeclarationCore(property);
    		DeletedFromStructDeclarationAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromInterfaceDeclaration(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromInterfaceDeclaration(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromInterfaceDeclarationCore(XElement)"/> is not executed and <see cref="DeletedFromInterfaceDeclaration(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromInterfaceDeclarationBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromInterfaceDeclarationCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromInterfaceDeclarationCore(XElement)"/>.</param>
        partial void DeletedFromInterfaceDeclarationAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromInterfaceDeclaration(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromInterfaceDeclarationCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromInterfaceDeclaration(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromInterfaceDeclarationBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromInterfaceDeclarationCore(property);
    		DeletedFromInterfaceDeclarationAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromFieldDeclaration(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromFieldDeclaration(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromFieldDeclarationCore(XElement)"/> is not executed and <see cref="DeletedFromFieldDeclaration(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromFieldDeclarationBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromFieldDeclarationCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromFieldDeclarationCore(XElement)"/>.</param>
        partial void DeletedFromFieldDeclarationAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromFieldDeclaration(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromFieldDeclarationCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "SemicolonToken")
    			return false;
    		
    		return true;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromFieldDeclaration(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromFieldDeclarationBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromFieldDeclarationCore(property);
    		DeletedFromFieldDeclarationAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromEventFieldDeclaration(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromEventFieldDeclaration(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromEventFieldDeclarationCore(XElement)"/> is not executed and <see cref="DeletedFromEventFieldDeclaration(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromEventFieldDeclarationBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromEventFieldDeclarationCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromEventFieldDeclarationCore(XElement)"/>.</param>
        partial void DeletedFromEventFieldDeclarationAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromEventFieldDeclaration(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromEventFieldDeclarationCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromEventFieldDeclaration(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromEventFieldDeclarationBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromEventFieldDeclarationCore(property);
    		DeletedFromEventFieldDeclarationAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromMethodDeclaration(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromMethodDeclaration(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromMethodDeclarationCore(XElement)"/> is not executed and <see cref="DeletedFromMethodDeclaration(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromMethodDeclarationBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromMethodDeclarationCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromMethodDeclarationCore(XElement)"/>.</param>
        partial void DeletedFromMethodDeclarationAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromMethodDeclaration(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromMethodDeclarationCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "SemicolonToken")
    			return false;
    		
    		return true;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromMethodDeclaration(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromMethodDeclarationBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromMethodDeclarationCore(property);
    		DeletedFromMethodDeclarationAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromOperatorDeclaration(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromOperatorDeclaration(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromOperatorDeclarationCore(XElement)"/> is not executed and <see cref="DeletedFromOperatorDeclaration(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromOperatorDeclarationBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromOperatorDeclarationCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromOperatorDeclarationCore(XElement)"/>.</param>
        partial void DeletedFromOperatorDeclarationAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromOperatorDeclaration(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromOperatorDeclarationCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromOperatorDeclaration(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromOperatorDeclarationBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromOperatorDeclarationCore(property);
    		DeletedFromOperatorDeclarationAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromConversionOperatorDeclaration(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromConversionOperatorDeclaration(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromConversionOperatorDeclarationCore(XElement)"/> is not executed and <see cref="DeletedFromConversionOperatorDeclaration(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromConversionOperatorDeclarationBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromConversionOperatorDeclarationCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromConversionOperatorDeclarationCore(XElement)"/>.</param>
        partial void DeletedFromConversionOperatorDeclarationAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromConversionOperatorDeclaration(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromConversionOperatorDeclarationCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromConversionOperatorDeclaration(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromConversionOperatorDeclarationBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromConversionOperatorDeclarationCore(property);
    		DeletedFromConversionOperatorDeclarationAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromConstructorDeclaration(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromConstructorDeclaration(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromConstructorDeclarationCore(XElement)"/> is not executed and <see cref="DeletedFromConstructorDeclaration(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromConstructorDeclarationBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromConstructorDeclarationCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromConstructorDeclarationCore(XElement)"/>.</param>
        partial void DeletedFromConstructorDeclarationAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromConstructorDeclaration(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromConstructorDeclarationCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "SemicolonToken")
    			return false;
    		
    		return true;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromConstructorDeclaration(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromConstructorDeclarationBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromConstructorDeclarationCore(property);
    		DeletedFromConstructorDeclarationAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromDestructorDeclaration(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromDestructorDeclaration(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromDestructorDeclarationCore(XElement)"/> is not executed and <see cref="DeletedFromDestructorDeclaration(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromDestructorDeclarationBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromDestructorDeclarationCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromDestructorDeclarationCore(XElement)"/>.</param>
        partial void DeletedFromDestructorDeclarationAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromDestructorDeclaration(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromDestructorDeclarationCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromDestructorDeclaration(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromDestructorDeclarationBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromDestructorDeclarationCore(property);
    		DeletedFromDestructorDeclarationAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromPropertyDeclaration(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromPropertyDeclaration(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromPropertyDeclarationCore(XElement)"/> is not executed and <see cref="DeletedFromPropertyDeclaration(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromPropertyDeclarationBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromPropertyDeclarationCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromPropertyDeclarationCore(XElement)"/>.</param>
        partial void DeletedFromPropertyDeclarationAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromPropertyDeclaration(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromPropertyDeclarationCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "SemicolonToken")
    			return false;
    		
    		return true;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromPropertyDeclaration(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromPropertyDeclarationBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromPropertyDeclarationCore(property);
    		DeletedFromPropertyDeclarationAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromEventDeclaration(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromEventDeclaration(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromEventDeclarationCore(XElement)"/> is not executed and <see cref="DeletedFromEventDeclaration(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromEventDeclarationBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromEventDeclarationCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromEventDeclarationCore(XElement)"/>.</param>
        partial void DeletedFromEventDeclarationAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromEventDeclaration(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromEventDeclarationCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "EventKeyword")
    			return false;
    		
    		return true;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromEventDeclaration(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromEventDeclarationBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromEventDeclarationCore(property);
    		DeletedFromEventDeclarationAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromIndexerDeclaration(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromIndexerDeclaration(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromIndexerDeclarationCore(XElement)"/> is not executed and <see cref="DeletedFromIndexerDeclaration(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromIndexerDeclarationBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromIndexerDeclarationCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromIndexerDeclarationCore(XElement)"/>.</param>
        partial void DeletedFromIndexerDeclarationAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromIndexerDeclaration(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromIndexerDeclarationCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromIndexerDeclaration(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromIndexerDeclarationBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromIndexerDeclarationCore(property);
    		DeletedFromIndexerDeclarationAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromSimpleBaseType(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromSimpleBaseType(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromSimpleBaseTypeCore(XElement)"/> is not executed and <see cref="DeletedFromSimpleBaseType(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromSimpleBaseTypeBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromSimpleBaseTypeCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromSimpleBaseTypeCore(XElement)"/>.</param>
        partial void DeletedFromSimpleBaseTypeAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromSimpleBaseType(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromSimpleBaseTypeCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		yield break;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromSimpleBaseType(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromSimpleBaseTypeBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromSimpleBaseTypeCore(property);
    		DeletedFromSimpleBaseTypeAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromConstructorConstraint(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromConstructorConstraint(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromConstructorConstraintCore(XElement)"/> is not executed and <see cref="DeletedFromConstructorConstraint(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromConstructorConstraintBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromConstructorConstraintCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromConstructorConstraintCore(XElement)"/>.</param>
        partial void DeletedFromConstructorConstraintAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromConstructorConstraint(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromConstructorConstraintCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromConstructorConstraint(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromConstructorConstraintBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromConstructorConstraintCore(property);
    		DeletedFromConstructorConstraintAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromClassOrStructConstraint(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromClassOrStructConstraint(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromClassOrStructConstraintCore(XElement)"/> is not executed and <see cref="DeletedFromClassOrStructConstraint(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromClassOrStructConstraintBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromClassOrStructConstraintCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromClassOrStructConstraintCore(XElement)"/>.</param>
        partial void DeletedFromClassOrStructConstraintAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromClassOrStructConstraint(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromClassOrStructConstraintCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "ClassOrStructKeyword")
    			return false;
    		
    		return true;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromClassOrStructConstraint(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromClassOrStructConstraintBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromClassOrStructConstraintCore(property);
    		DeletedFromClassOrStructConstraintAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromTypeConstraint(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromTypeConstraint(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromTypeConstraintCore(XElement)"/> is not executed and <see cref="DeletedFromTypeConstraint(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromTypeConstraintBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromTypeConstraintCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromTypeConstraintCore(XElement)"/>.</param>
        partial void DeletedFromTypeConstraintAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromTypeConstraint(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromTypeConstraintCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		yield break;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromTypeConstraint(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromTypeConstraintBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromTypeConstraintCore(property);
    		DeletedFromTypeConstraintAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromParameterList(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromParameterList(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromParameterListCore(XElement)"/> is not executed and <see cref="DeletedFromParameterList(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromParameterListBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromParameterListCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromParameterListCore(XElement)"/>.</param>
        partial void DeletedFromParameterListAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromParameterList(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromParameterListCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromParameterList(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromParameterListBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromParameterListCore(property);
    		DeletedFromParameterListAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromBracketedParameterList(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromBracketedParameterList(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromBracketedParameterListCore(XElement)"/> is not executed and <see cref="DeletedFromBracketedParameterList(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromBracketedParameterListBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromBracketedParameterListCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromBracketedParameterListCore(XElement)"/>.</param>
        partial void DeletedFromBracketedParameterListAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromBracketedParameterList(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromBracketedParameterListCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromBracketedParameterList(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromBracketedParameterListBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromBracketedParameterListCore(property);
    		DeletedFromBracketedParameterListAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromSkippedTokensTrivia(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromSkippedTokensTrivia(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromSkippedTokensTriviaCore(XElement)"/> is not executed and <see cref="DeletedFromSkippedTokensTrivia(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromSkippedTokensTriviaBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromSkippedTokensTriviaCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromSkippedTokensTriviaCore(XElement)"/>.</param>
        partial void DeletedFromSkippedTokensTriviaAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromSkippedTokensTrivia(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromSkippedTokensTriviaCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		yield break;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromSkippedTokensTrivia(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromSkippedTokensTriviaBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromSkippedTokensTriviaCore(property);
    		DeletedFromSkippedTokensTriviaAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromDocumentationCommentTrivia(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromDocumentationCommentTrivia(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromDocumentationCommentTriviaCore(XElement)"/> is not executed and <see cref="DeletedFromDocumentationCommentTrivia(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromDocumentationCommentTriviaBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromDocumentationCommentTriviaCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromDocumentationCommentTriviaCore(XElement)"/>.</param>
        partial void DeletedFromDocumentationCommentTriviaAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromDocumentationCommentTrivia(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromDocumentationCommentTriviaCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "EndOfComment")
    			return false;
    		
    		return true;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromDocumentationCommentTrivia(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromDocumentationCommentTriviaBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromDocumentationCommentTriviaCore(property);
    		DeletedFromDocumentationCommentTriviaAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromEndIfDirectiveTrivia(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromEndIfDirectiveTrivia(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromEndIfDirectiveTriviaCore(XElement)"/> is not executed and <see cref="DeletedFromEndIfDirectiveTrivia(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromEndIfDirectiveTriviaBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromEndIfDirectiveTriviaCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromEndIfDirectiveTriviaCore(XElement)"/>.</param>
        partial void DeletedFromEndIfDirectiveTriviaAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromEndIfDirectiveTrivia(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromEndIfDirectiveTriviaCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromEndIfDirectiveTrivia(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromEndIfDirectiveTriviaBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromEndIfDirectiveTriviaCore(property);
    		DeletedFromEndIfDirectiveTriviaAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromRegionDirectiveTrivia(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromRegionDirectiveTrivia(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromRegionDirectiveTriviaCore(XElement)"/> is not executed and <see cref="DeletedFromRegionDirectiveTrivia(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromRegionDirectiveTriviaBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromRegionDirectiveTriviaCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromRegionDirectiveTriviaCore(XElement)"/>.</param>
        partial void DeletedFromRegionDirectiveTriviaAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromRegionDirectiveTrivia(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromRegionDirectiveTriviaCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromRegionDirectiveTrivia(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromRegionDirectiveTriviaBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromRegionDirectiveTriviaCore(property);
    		DeletedFromRegionDirectiveTriviaAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromEndRegionDirectiveTrivia(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromEndRegionDirectiveTrivia(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromEndRegionDirectiveTriviaCore(XElement)"/> is not executed and <see cref="DeletedFromEndRegionDirectiveTrivia(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromEndRegionDirectiveTriviaBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromEndRegionDirectiveTriviaCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromEndRegionDirectiveTriviaCore(XElement)"/>.</param>
        partial void DeletedFromEndRegionDirectiveTriviaAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromEndRegionDirectiveTrivia(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromEndRegionDirectiveTriviaCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromEndRegionDirectiveTrivia(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromEndRegionDirectiveTriviaBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromEndRegionDirectiveTriviaCore(property);
    		DeletedFromEndRegionDirectiveTriviaAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromErrorDirectiveTrivia(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromErrorDirectiveTrivia(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromErrorDirectiveTriviaCore(XElement)"/> is not executed and <see cref="DeletedFromErrorDirectiveTrivia(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromErrorDirectiveTriviaBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromErrorDirectiveTriviaCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromErrorDirectiveTriviaCore(XElement)"/>.</param>
        partial void DeletedFromErrorDirectiveTriviaAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromErrorDirectiveTrivia(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromErrorDirectiveTriviaCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromErrorDirectiveTrivia(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromErrorDirectiveTriviaBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromErrorDirectiveTriviaCore(property);
    		DeletedFromErrorDirectiveTriviaAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromWarningDirectiveTrivia(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromWarningDirectiveTrivia(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromWarningDirectiveTriviaCore(XElement)"/> is not executed and <see cref="DeletedFromWarningDirectiveTrivia(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromWarningDirectiveTriviaBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromWarningDirectiveTriviaCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromWarningDirectiveTriviaCore(XElement)"/>.</param>
        partial void DeletedFromWarningDirectiveTriviaAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromWarningDirectiveTrivia(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromWarningDirectiveTriviaCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromWarningDirectiveTrivia(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromWarningDirectiveTriviaBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromWarningDirectiveTriviaCore(property);
    		DeletedFromWarningDirectiveTriviaAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromBadDirectiveTrivia(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromBadDirectiveTrivia(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromBadDirectiveTriviaCore(XElement)"/> is not executed and <see cref="DeletedFromBadDirectiveTrivia(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromBadDirectiveTriviaBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromBadDirectiveTriviaCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromBadDirectiveTriviaCore(XElement)"/>.</param>
        partial void DeletedFromBadDirectiveTriviaAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromBadDirectiveTrivia(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromBadDirectiveTriviaCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromBadDirectiveTrivia(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromBadDirectiveTriviaBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromBadDirectiveTriviaCore(property);
    		DeletedFromBadDirectiveTriviaAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromDefineDirectiveTrivia(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromDefineDirectiveTrivia(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromDefineDirectiveTriviaCore(XElement)"/> is not executed and <see cref="DeletedFromDefineDirectiveTrivia(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromDefineDirectiveTriviaBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromDefineDirectiveTriviaCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromDefineDirectiveTriviaCore(XElement)"/>.</param>
        partial void DeletedFromDefineDirectiveTriviaAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromDefineDirectiveTrivia(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromDefineDirectiveTriviaCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromDefineDirectiveTrivia(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromDefineDirectiveTriviaBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromDefineDirectiveTriviaCore(property);
    		DeletedFromDefineDirectiveTriviaAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromUndefDirectiveTrivia(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromUndefDirectiveTrivia(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromUndefDirectiveTriviaCore(XElement)"/> is not executed and <see cref="DeletedFromUndefDirectiveTrivia(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromUndefDirectiveTriviaBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromUndefDirectiveTriviaCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromUndefDirectiveTriviaCore(XElement)"/>.</param>
        partial void DeletedFromUndefDirectiveTriviaAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromUndefDirectiveTrivia(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromUndefDirectiveTriviaCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromUndefDirectiveTrivia(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromUndefDirectiveTriviaBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromUndefDirectiveTriviaCore(property);
    		DeletedFromUndefDirectiveTriviaAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromLineDirectiveTrivia(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromLineDirectiveTrivia(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromLineDirectiveTriviaCore(XElement)"/> is not executed and <see cref="DeletedFromLineDirectiveTrivia(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromLineDirectiveTriviaBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromLineDirectiveTriviaCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromLineDirectiveTriviaCore(XElement)"/>.</param>
        partial void DeletedFromLineDirectiveTriviaAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromLineDirectiveTrivia(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromLineDirectiveTriviaCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromLineDirectiveTrivia(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromLineDirectiveTriviaBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromLineDirectiveTriviaCore(property);
    		DeletedFromLineDirectiveTriviaAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromPragmaWarningDirectiveTrivia(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromPragmaWarningDirectiveTrivia(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromPragmaWarningDirectiveTriviaCore(XElement)"/> is not executed and <see cref="DeletedFromPragmaWarningDirectiveTrivia(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromPragmaWarningDirectiveTriviaBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromPragmaWarningDirectiveTriviaCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromPragmaWarningDirectiveTriviaCore(XElement)"/>.</param>
        partial void DeletedFromPragmaWarningDirectiveTriviaAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromPragmaWarningDirectiveTrivia(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromPragmaWarningDirectiveTriviaCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromPragmaWarningDirectiveTrivia(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromPragmaWarningDirectiveTriviaBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromPragmaWarningDirectiveTriviaCore(property);
    		DeletedFromPragmaWarningDirectiveTriviaAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromPragmaChecksumDirectiveTrivia(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromPragmaChecksumDirectiveTrivia(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromPragmaChecksumDirectiveTriviaCore(XElement)"/> is not executed and <see cref="DeletedFromPragmaChecksumDirectiveTrivia(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromPragmaChecksumDirectiveTriviaBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromPragmaChecksumDirectiveTriviaCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromPragmaChecksumDirectiveTriviaCore(XElement)"/>.</param>
        partial void DeletedFromPragmaChecksumDirectiveTriviaAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromPragmaChecksumDirectiveTrivia(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromPragmaChecksumDirectiveTriviaCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromPragmaChecksumDirectiveTrivia(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromPragmaChecksumDirectiveTriviaBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromPragmaChecksumDirectiveTriviaCore(property);
    		DeletedFromPragmaChecksumDirectiveTriviaAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromReferenceDirectiveTrivia(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromReferenceDirectiveTrivia(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromReferenceDirectiveTriviaCore(XElement)"/> is not executed and <see cref="DeletedFromReferenceDirectiveTrivia(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromReferenceDirectiveTriviaBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromReferenceDirectiveTriviaCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromReferenceDirectiveTriviaCore(XElement)"/>.</param>
        partial void DeletedFromReferenceDirectiveTriviaAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromReferenceDirectiveTrivia(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromReferenceDirectiveTriviaCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromReferenceDirectiveTrivia(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromReferenceDirectiveTriviaBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromReferenceDirectiveTriviaCore(property);
    		DeletedFromReferenceDirectiveTriviaAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromLoadDirectiveTrivia(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromLoadDirectiveTrivia(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromLoadDirectiveTriviaCore(XElement)"/> is not executed and <see cref="DeletedFromLoadDirectiveTrivia(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromLoadDirectiveTriviaBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromLoadDirectiveTriviaCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromLoadDirectiveTriviaCore(XElement)"/>.</param>
        partial void DeletedFromLoadDirectiveTriviaAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromLoadDirectiveTrivia(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromLoadDirectiveTriviaCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromLoadDirectiveTrivia(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromLoadDirectiveTriviaBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromLoadDirectiveTriviaCore(property);
    		DeletedFromLoadDirectiveTriviaAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromShebangDirectiveTrivia(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromShebangDirectiveTrivia(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromShebangDirectiveTriviaCore(XElement)"/> is not executed and <see cref="DeletedFromShebangDirectiveTrivia(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromShebangDirectiveTriviaBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromShebangDirectiveTriviaCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromShebangDirectiveTriviaCore(XElement)"/>.</param>
        partial void DeletedFromShebangDirectiveTriviaAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromShebangDirectiveTrivia(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromShebangDirectiveTriviaCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromShebangDirectiveTrivia(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromShebangDirectiveTriviaBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromShebangDirectiveTriviaCore(property);
    		DeletedFromShebangDirectiveTriviaAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromElseDirectiveTrivia(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromElseDirectiveTrivia(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromElseDirectiveTriviaCore(XElement)"/> is not executed and <see cref="DeletedFromElseDirectiveTrivia(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromElseDirectiveTriviaBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromElseDirectiveTriviaCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromElseDirectiveTriviaCore(XElement)"/>.</param>
        partial void DeletedFromElseDirectiveTriviaAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromElseDirectiveTrivia(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromElseDirectiveTriviaCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromElseDirectiveTrivia(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromElseDirectiveTriviaBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromElseDirectiveTriviaCore(property);
    		DeletedFromElseDirectiveTriviaAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromIfDirectiveTrivia(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromIfDirectiveTrivia(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromIfDirectiveTriviaCore(XElement)"/> is not executed and <see cref="DeletedFromIfDirectiveTrivia(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromIfDirectiveTriviaBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromIfDirectiveTriviaCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromIfDirectiveTriviaCore(XElement)"/>.</param>
        partial void DeletedFromIfDirectiveTriviaAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromIfDirectiveTrivia(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromIfDirectiveTriviaCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromIfDirectiveTrivia(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromIfDirectiveTriviaBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromIfDirectiveTriviaCore(property);
    		DeletedFromIfDirectiveTriviaAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromElifDirectiveTrivia(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromElifDirectiveTrivia(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromElifDirectiveTriviaCore(XElement)"/> is not executed and <see cref="DeletedFromElifDirectiveTrivia(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromElifDirectiveTriviaBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromElifDirectiveTriviaCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromElifDirectiveTriviaCore(XElement)"/>.</param>
        partial void DeletedFromElifDirectiveTriviaAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromElifDirectiveTrivia(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromElifDirectiveTriviaCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromElifDirectiveTrivia(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromElifDirectiveTriviaBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromElifDirectiveTriviaCore(property);
    		DeletedFromElifDirectiveTriviaAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromTypeCref(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromTypeCref(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromTypeCrefCore(XElement)"/> is not executed and <see cref="DeletedFromTypeCref(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromTypeCrefBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromTypeCrefCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromTypeCrefCore(XElement)"/>.</param>
        partial void DeletedFromTypeCrefAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromTypeCref(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromTypeCrefCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		yield break;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromTypeCref(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromTypeCrefBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromTypeCrefCore(property);
    		DeletedFromTypeCrefAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromQualifiedCref(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromQualifiedCref(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromQualifiedCrefCore(XElement)"/> is not executed and <see cref="DeletedFromQualifiedCref(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromQualifiedCrefBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromQualifiedCrefCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromQualifiedCrefCore(XElement)"/>.</param>
        partial void DeletedFromQualifiedCrefAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromQualifiedCref(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromQualifiedCrefCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "DotToken")
    			return false;
    		
    		return true;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromQualifiedCref(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromQualifiedCrefBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromQualifiedCrefCore(property);
    		DeletedFromQualifiedCrefAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromNameMemberCref(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromNameMemberCref(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromNameMemberCrefCore(XElement)"/> is not executed and <see cref="DeletedFromNameMemberCref(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromNameMemberCrefBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromNameMemberCrefCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromNameMemberCrefCore(XElement)"/>.</param>
        partial void DeletedFromNameMemberCrefAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromNameMemberCref(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromNameMemberCrefCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		yield break;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromNameMemberCref(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromNameMemberCrefBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromNameMemberCrefCore(property);
    		DeletedFromNameMemberCrefAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromIndexerMemberCref(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromIndexerMemberCref(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromIndexerMemberCrefCore(XElement)"/> is not executed and <see cref="DeletedFromIndexerMemberCref(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromIndexerMemberCrefBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromIndexerMemberCrefCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromIndexerMemberCrefCore(XElement)"/>.</param>
        partial void DeletedFromIndexerMemberCrefAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromIndexerMemberCref(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromIndexerMemberCrefCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "ThisKeyword")
    			return false;
    		
    		return true;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromIndexerMemberCref(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromIndexerMemberCrefBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromIndexerMemberCrefCore(property);
    		DeletedFromIndexerMemberCrefAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromOperatorMemberCref(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromOperatorMemberCref(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromOperatorMemberCrefCore(XElement)"/> is not executed and <see cref="DeletedFromOperatorMemberCref(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromOperatorMemberCrefBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromOperatorMemberCrefCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromOperatorMemberCrefCore(XElement)"/>.</param>
        partial void DeletedFromOperatorMemberCrefAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromOperatorMemberCref(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromOperatorMemberCrefCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "OperatorKeyword")
    			return false;
    		
    		return true;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromOperatorMemberCref(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromOperatorMemberCrefBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromOperatorMemberCrefCore(property);
    		DeletedFromOperatorMemberCrefAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromConversionOperatorMemberCref(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromConversionOperatorMemberCref(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromConversionOperatorMemberCrefCore(XElement)"/> is not executed and <see cref="DeletedFromConversionOperatorMemberCref(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromConversionOperatorMemberCrefBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromConversionOperatorMemberCrefCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromConversionOperatorMemberCrefCore(XElement)"/>.</param>
        partial void DeletedFromConversionOperatorMemberCrefAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromConversionOperatorMemberCref(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromConversionOperatorMemberCrefCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromConversionOperatorMemberCref(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromConversionOperatorMemberCrefBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromConversionOperatorMemberCrefCore(property);
    		DeletedFromConversionOperatorMemberCrefAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromCrefParameterList(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromCrefParameterList(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromCrefParameterListCore(XElement)"/> is not executed and <see cref="DeletedFromCrefParameterList(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromCrefParameterListBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromCrefParameterListCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromCrefParameterListCore(XElement)"/>.</param>
        partial void DeletedFromCrefParameterListAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromCrefParameterList(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromCrefParameterListCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromCrefParameterList(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromCrefParameterListBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromCrefParameterListCore(property);
    		DeletedFromCrefParameterListAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromCrefBracketedParameterList(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromCrefBracketedParameterList(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromCrefBracketedParameterListCore(XElement)"/> is not executed and <see cref="DeletedFromCrefBracketedParameterList(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromCrefBracketedParameterListBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromCrefBracketedParameterListCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromCrefBracketedParameterListCore(XElement)"/>.</param>
        partial void DeletedFromCrefBracketedParameterListAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromCrefBracketedParameterList(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromCrefBracketedParameterListCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromCrefBracketedParameterList(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromCrefBracketedParameterListBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromCrefBracketedParameterListCore(property);
    		DeletedFromCrefBracketedParameterListAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromXmlElement(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromXmlElement(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromXmlElementCore(XElement)"/> is not executed and <see cref="DeletedFromXmlElement(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromXmlElementBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromXmlElementCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromXmlElementCore(XElement)"/>.</param>
        partial void DeletedFromXmlElementAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromXmlElement(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromXmlElementCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		yield break;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromXmlElement(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromXmlElementBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromXmlElementCore(property);
    		DeletedFromXmlElementAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromXmlEmptyElement(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromXmlEmptyElement(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromXmlEmptyElementCore(XElement)"/> is not executed and <see cref="DeletedFromXmlEmptyElement(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromXmlEmptyElementBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromXmlEmptyElementCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromXmlEmptyElementCore(XElement)"/>.</param>
        partial void DeletedFromXmlEmptyElementAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromXmlEmptyElement(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromXmlEmptyElementCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromXmlEmptyElement(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromXmlEmptyElementBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromXmlEmptyElementCore(property);
    		DeletedFromXmlEmptyElementAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromXmlText(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromXmlText(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromXmlTextCore(XElement)"/> is not executed and <see cref="DeletedFromXmlText(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromXmlTextBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromXmlTextCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromXmlTextCore(XElement)"/>.</param>
        partial void DeletedFromXmlTextAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromXmlText(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromXmlTextCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		yield break;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromXmlText(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromXmlTextBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromXmlTextCore(property);
    		DeletedFromXmlTextAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromXmlCDataSection(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromXmlCDataSection(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromXmlCDataSectionCore(XElement)"/> is not executed and <see cref="DeletedFromXmlCDataSection(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromXmlCDataSectionBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromXmlCDataSectionCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromXmlCDataSectionCore(XElement)"/>.</param>
        partial void DeletedFromXmlCDataSectionAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromXmlCDataSection(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromXmlCDataSectionCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromXmlCDataSection(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromXmlCDataSectionBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromXmlCDataSectionCore(property);
    		DeletedFromXmlCDataSectionAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromXmlProcessingInstruction(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromXmlProcessingInstruction(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromXmlProcessingInstructionCore(XElement)"/> is not executed and <see cref="DeletedFromXmlProcessingInstruction(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromXmlProcessingInstructionBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromXmlProcessingInstructionCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromXmlProcessingInstructionCore(XElement)"/>.</param>
        partial void DeletedFromXmlProcessingInstructionAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromXmlProcessingInstruction(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromXmlProcessingInstructionCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromXmlProcessingInstruction(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromXmlProcessingInstructionBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromXmlProcessingInstructionCore(property);
    		DeletedFromXmlProcessingInstructionAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromXmlComment(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromXmlComment(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromXmlCommentCore(XElement)"/> is not executed and <see cref="DeletedFromXmlComment(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromXmlCommentBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromXmlCommentCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromXmlCommentCore(XElement)"/>.</param>
        partial void DeletedFromXmlCommentAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromXmlComment(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromXmlCommentCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromXmlComment(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromXmlCommentBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromXmlCommentCore(property);
    		DeletedFromXmlCommentAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromXmlTextAttribute(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromXmlTextAttribute(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromXmlTextAttributeCore(XElement)"/> is not executed and <see cref="DeletedFromXmlTextAttribute(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromXmlTextAttributeBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromXmlTextAttributeCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromXmlTextAttributeCore(XElement)"/>.</param>
        partial void DeletedFromXmlTextAttributeAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromXmlTextAttribute(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromXmlTextAttributeCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromXmlTextAttribute(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromXmlTextAttributeBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromXmlTextAttributeCore(property);
    		DeletedFromXmlTextAttributeAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromXmlCrefAttribute(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromXmlCrefAttribute(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromXmlCrefAttributeCore(XElement)"/> is not executed and <see cref="DeletedFromXmlCrefAttribute(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromXmlCrefAttributeBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromXmlCrefAttributeCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromXmlCrefAttributeCore(XElement)"/>.</param>
        partial void DeletedFromXmlCrefAttributeAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromXmlCrefAttribute(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromXmlCrefAttributeCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromXmlCrefAttribute(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromXmlCrefAttributeBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromXmlCrefAttributeCore(property);
    		DeletedFromXmlCrefAttributeAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromXmlNameAttribute(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromXmlNameAttribute(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromXmlNameAttributeCore(XElement)"/> is not executed and <see cref="DeletedFromXmlNameAttribute(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromXmlNameAttributeBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromXmlNameAttributeCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromXmlNameAttributeCore(XElement)"/>.</param>
        partial void DeletedFromXmlNameAttributeAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromXmlNameAttribute(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromXmlNameAttributeCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromXmlNameAttribute(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromXmlNameAttributeBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromXmlNameAttributeCore(property);
    		DeletedFromXmlNameAttributeAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromParenthesizedExpression(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromParenthesizedExpression(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromParenthesizedExpressionCore(XElement)"/> is not executed and <see cref="DeletedFromParenthesizedExpression(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromParenthesizedExpressionBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromParenthesizedExpressionCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromParenthesizedExpressionCore(XElement)"/>.</param>
        partial void DeletedFromParenthesizedExpressionAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromParenthesizedExpression(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromParenthesizedExpressionCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromParenthesizedExpression(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromParenthesizedExpressionBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromParenthesizedExpressionCore(property);
    		DeletedFromParenthesizedExpressionAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromTupleExpression(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromTupleExpression(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromTupleExpressionCore(XElement)"/> is not executed and <see cref="DeletedFromTupleExpression(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromTupleExpressionBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromTupleExpressionCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromTupleExpressionCore(XElement)"/>.</param>
        partial void DeletedFromTupleExpressionAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromTupleExpression(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromTupleExpressionCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromTupleExpression(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromTupleExpressionBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromTupleExpressionCore(property);
    		DeletedFromTupleExpressionAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromPrefixUnaryExpression(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromPrefixUnaryExpression(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromPrefixUnaryExpressionCore(XElement)"/> is not executed and <see cref="DeletedFromPrefixUnaryExpression(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromPrefixUnaryExpressionBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromPrefixUnaryExpressionCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromPrefixUnaryExpressionCore(XElement)"/>.</param>
        partial void DeletedFromPrefixUnaryExpressionAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromPrefixUnaryExpression(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromPrefixUnaryExpressionCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "OperatorToken")
    			return false;
    		
    		return true;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromPrefixUnaryExpression(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromPrefixUnaryExpressionBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromPrefixUnaryExpressionCore(property);
    		DeletedFromPrefixUnaryExpressionAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromAwaitExpression(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromAwaitExpression(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromAwaitExpressionCore(XElement)"/> is not executed and <see cref="DeletedFromAwaitExpression(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromAwaitExpressionBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromAwaitExpressionCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromAwaitExpressionCore(XElement)"/>.</param>
        partial void DeletedFromAwaitExpressionAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromAwaitExpression(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromAwaitExpressionCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "AwaitKeyword")
    			return false;
    		
    		return true;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromAwaitExpression(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromAwaitExpressionBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromAwaitExpressionCore(property);
    		DeletedFromAwaitExpressionAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromPostfixUnaryExpression(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromPostfixUnaryExpression(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromPostfixUnaryExpressionCore(XElement)"/> is not executed and <see cref="DeletedFromPostfixUnaryExpression(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromPostfixUnaryExpressionBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromPostfixUnaryExpressionCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromPostfixUnaryExpressionCore(XElement)"/>.</param>
        partial void DeletedFromPostfixUnaryExpressionAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromPostfixUnaryExpression(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromPostfixUnaryExpressionCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "OperatorToken")
    			return false;
    		
    		return true;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromPostfixUnaryExpression(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromPostfixUnaryExpressionBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromPostfixUnaryExpressionCore(property);
    		DeletedFromPostfixUnaryExpressionAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromMemberAccessExpression(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromMemberAccessExpression(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromMemberAccessExpressionCore(XElement)"/> is not executed and <see cref="DeletedFromMemberAccessExpression(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromMemberAccessExpressionBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromMemberAccessExpressionCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromMemberAccessExpressionCore(XElement)"/>.</param>
        partial void DeletedFromMemberAccessExpressionAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromMemberAccessExpression(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromMemberAccessExpressionCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "OperatorToken")
    			return false;
    		
    		return true;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromMemberAccessExpression(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromMemberAccessExpressionBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromMemberAccessExpressionCore(property);
    		DeletedFromMemberAccessExpressionAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromConditionalAccessExpression(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromConditionalAccessExpression(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromConditionalAccessExpressionCore(XElement)"/> is not executed and <see cref="DeletedFromConditionalAccessExpression(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromConditionalAccessExpressionBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromConditionalAccessExpressionCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromConditionalAccessExpressionCore(XElement)"/>.</param>
        partial void DeletedFromConditionalAccessExpressionAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromConditionalAccessExpression(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromConditionalAccessExpressionCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "OperatorToken")
    			return false;
    		
    		return true;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromConditionalAccessExpression(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromConditionalAccessExpressionBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromConditionalAccessExpressionCore(property);
    		DeletedFromConditionalAccessExpressionAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromMemberBindingExpression(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromMemberBindingExpression(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromMemberBindingExpressionCore(XElement)"/> is not executed and <see cref="DeletedFromMemberBindingExpression(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromMemberBindingExpressionBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromMemberBindingExpressionCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromMemberBindingExpressionCore(XElement)"/>.</param>
        partial void DeletedFromMemberBindingExpressionAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromMemberBindingExpression(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromMemberBindingExpressionCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "OperatorToken")
    			return false;
    		
    		return true;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromMemberBindingExpression(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromMemberBindingExpressionBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromMemberBindingExpressionCore(property);
    		DeletedFromMemberBindingExpressionAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromElementBindingExpression(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromElementBindingExpression(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromElementBindingExpressionCore(XElement)"/> is not executed and <see cref="DeletedFromElementBindingExpression(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromElementBindingExpressionBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromElementBindingExpressionCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromElementBindingExpressionCore(XElement)"/>.</param>
        partial void DeletedFromElementBindingExpressionAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromElementBindingExpression(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromElementBindingExpressionCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		yield break;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromElementBindingExpression(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromElementBindingExpressionBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromElementBindingExpressionCore(property);
    		DeletedFromElementBindingExpressionAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromImplicitElementAccess(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromImplicitElementAccess(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromImplicitElementAccessCore(XElement)"/> is not executed and <see cref="DeletedFromImplicitElementAccess(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromImplicitElementAccessBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromImplicitElementAccessCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromImplicitElementAccessCore(XElement)"/>.</param>
        partial void DeletedFromImplicitElementAccessAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromImplicitElementAccess(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromImplicitElementAccessCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		yield break;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromImplicitElementAccess(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromImplicitElementAccessBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromImplicitElementAccessCore(property);
    		DeletedFromImplicitElementAccessAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromBinaryExpression(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromBinaryExpression(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromBinaryExpressionCore(XElement)"/> is not executed and <see cref="DeletedFromBinaryExpression(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromBinaryExpressionBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromBinaryExpressionCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromBinaryExpressionCore(XElement)"/>.</param>
        partial void DeletedFromBinaryExpressionAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromBinaryExpression(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromBinaryExpressionCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "OperatorToken")
    			return false;
    		
    		return true;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromBinaryExpression(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromBinaryExpressionBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromBinaryExpressionCore(property);
    		DeletedFromBinaryExpressionAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromAssignmentExpression(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromAssignmentExpression(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromAssignmentExpressionCore(XElement)"/> is not executed and <see cref="DeletedFromAssignmentExpression(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromAssignmentExpressionBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromAssignmentExpressionCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromAssignmentExpressionCore(XElement)"/>.</param>
        partial void DeletedFromAssignmentExpressionAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromAssignmentExpression(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromAssignmentExpressionCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "OperatorToken")
    			return false;
    		
    		return true;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromAssignmentExpression(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromAssignmentExpressionBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromAssignmentExpressionCore(property);
    		DeletedFromAssignmentExpressionAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromConditionalExpression(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromConditionalExpression(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromConditionalExpressionCore(XElement)"/> is not executed and <see cref="DeletedFromConditionalExpression(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromConditionalExpressionBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromConditionalExpressionCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromConditionalExpressionCore(XElement)"/>.</param>
        partial void DeletedFromConditionalExpressionAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromConditionalExpression(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromConditionalExpressionCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromConditionalExpression(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromConditionalExpressionBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromConditionalExpressionCore(property);
    		DeletedFromConditionalExpressionAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromLiteralExpression(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromLiteralExpression(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromLiteralExpressionCore(XElement)"/> is not executed and <see cref="DeletedFromLiteralExpression(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromLiteralExpressionBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromLiteralExpressionCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromLiteralExpressionCore(XElement)"/>.</param>
        partial void DeletedFromLiteralExpressionAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromLiteralExpression(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromLiteralExpressionCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		yield break;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromLiteralExpression(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromLiteralExpressionBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromLiteralExpressionCore(property);
    		DeletedFromLiteralExpressionAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromMakeRefExpression(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromMakeRefExpression(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromMakeRefExpressionCore(XElement)"/> is not executed and <see cref="DeletedFromMakeRefExpression(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromMakeRefExpressionBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromMakeRefExpressionCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromMakeRefExpressionCore(XElement)"/>.</param>
        partial void DeletedFromMakeRefExpressionAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromMakeRefExpression(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromMakeRefExpressionCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromMakeRefExpression(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromMakeRefExpressionBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromMakeRefExpressionCore(property);
    		DeletedFromMakeRefExpressionAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromRefTypeExpression(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromRefTypeExpression(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromRefTypeExpressionCore(XElement)"/> is not executed and <see cref="DeletedFromRefTypeExpression(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromRefTypeExpressionBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromRefTypeExpressionCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromRefTypeExpressionCore(XElement)"/>.</param>
        partial void DeletedFromRefTypeExpressionAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromRefTypeExpression(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromRefTypeExpressionCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromRefTypeExpression(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromRefTypeExpressionBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromRefTypeExpressionCore(property);
    		DeletedFromRefTypeExpressionAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromRefValueExpression(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromRefValueExpression(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromRefValueExpressionCore(XElement)"/> is not executed and <see cref="DeletedFromRefValueExpression(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromRefValueExpressionBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromRefValueExpressionCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromRefValueExpressionCore(XElement)"/>.</param>
        partial void DeletedFromRefValueExpressionAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromRefValueExpression(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromRefValueExpressionCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromRefValueExpression(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromRefValueExpressionBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromRefValueExpressionCore(property);
    		DeletedFromRefValueExpressionAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromCheckedExpression(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromCheckedExpression(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromCheckedExpressionCore(XElement)"/> is not executed and <see cref="DeletedFromCheckedExpression(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromCheckedExpressionBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromCheckedExpressionCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromCheckedExpressionCore(XElement)"/>.</param>
        partial void DeletedFromCheckedExpressionAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromCheckedExpression(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromCheckedExpressionCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromCheckedExpression(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromCheckedExpressionBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromCheckedExpressionCore(property);
    		DeletedFromCheckedExpressionAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromDefaultExpression(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromDefaultExpression(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromDefaultExpressionCore(XElement)"/> is not executed and <see cref="DeletedFromDefaultExpression(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromDefaultExpressionBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromDefaultExpressionCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromDefaultExpressionCore(XElement)"/>.</param>
        partial void DeletedFromDefaultExpressionAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromDefaultExpression(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromDefaultExpressionCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromDefaultExpression(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromDefaultExpressionBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromDefaultExpressionCore(property);
    		DeletedFromDefaultExpressionAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromTypeOfExpression(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromTypeOfExpression(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromTypeOfExpressionCore(XElement)"/> is not executed and <see cref="DeletedFromTypeOfExpression(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromTypeOfExpressionBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromTypeOfExpressionCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromTypeOfExpressionCore(XElement)"/>.</param>
        partial void DeletedFromTypeOfExpressionAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromTypeOfExpression(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromTypeOfExpressionCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromTypeOfExpression(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromTypeOfExpressionBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromTypeOfExpressionCore(property);
    		DeletedFromTypeOfExpressionAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromSizeOfExpression(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromSizeOfExpression(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromSizeOfExpressionCore(XElement)"/> is not executed and <see cref="DeletedFromSizeOfExpression(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromSizeOfExpressionBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromSizeOfExpressionCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromSizeOfExpressionCore(XElement)"/>.</param>
        partial void DeletedFromSizeOfExpressionAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromSizeOfExpression(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromSizeOfExpressionCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromSizeOfExpression(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromSizeOfExpressionBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromSizeOfExpressionCore(property);
    		DeletedFromSizeOfExpressionAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromInvocationExpression(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromInvocationExpression(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromInvocationExpressionCore(XElement)"/> is not executed and <see cref="DeletedFromInvocationExpression(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromInvocationExpressionBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromInvocationExpressionCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromInvocationExpressionCore(XElement)"/>.</param>
        partial void DeletedFromInvocationExpressionAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromInvocationExpression(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromInvocationExpressionCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		yield break;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromInvocationExpression(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromInvocationExpressionBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromInvocationExpressionCore(property);
    		DeletedFromInvocationExpressionAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromElementAccessExpression(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromElementAccessExpression(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromElementAccessExpressionCore(XElement)"/> is not executed and <see cref="DeletedFromElementAccessExpression(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromElementAccessExpressionBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromElementAccessExpressionCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromElementAccessExpressionCore(XElement)"/>.</param>
        partial void DeletedFromElementAccessExpressionAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromElementAccessExpression(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromElementAccessExpressionCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		yield break;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromElementAccessExpression(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromElementAccessExpressionBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromElementAccessExpressionCore(property);
    		DeletedFromElementAccessExpressionAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromDeclarationExpression(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromDeclarationExpression(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromDeclarationExpressionCore(XElement)"/> is not executed and <see cref="DeletedFromDeclarationExpression(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromDeclarationExpressionBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromDeclarationExpressionCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromDeclarationExpressionCore(XElement)"/>.</param>
        partial void DeletedFromDeclarationExpressionAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromDeclarationExpression(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromDeclarationExpressionCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		yield break;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromDeclarationExpression(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromDeclarationExpressionBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromDeclarationExpressionCore(property);
    		DeletedFromDeclarationExpressionAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromCastExpression(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromCastExpression(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromCastExpressionCore(XElement)"/> is not executed and <see cref="DeletedFromCastExpression(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromCastExpressionBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromCastExpressionCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromCastExpressionCore(XElement)"/>.</param>
        partial void DeletedFromCastExpressionAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromCastExpression(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromCastExpressionCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromCastExpression(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromCastExpressionBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromCastExpressionCore(property);
    		DeletedFromCastExpressionAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromRefExpression(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromRefExpression(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromRefExpressionCore(XElement)"/> is not executed and <see cref="DeletedFromRefExpression(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromRefExpressionBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromRefExpressionCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromRefExpressionCore(XElement)"/>.</param>
        partial void DeletedFromRefExpressionAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromRefExpression(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromRefExpressionCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "RefKeyword")
    			return false;
    		
    		return true;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromRefExpression(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromRefExpressionBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromRefExpressionCore(property);
    		DeletedFromRefExpressionAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromInitializerExpression(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromInitializerExpression(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromInitializerExpressionCore(XElement)"/> is not executed and <see cref="DeletedFromInitializerExpression(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromInitializerExpressionBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromInitializerExpressionCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromInitializerExpressionCore(XElement)"/>.</param>
        partial void DeletedFromInitializerExpressionAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromInitializerExpression(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromInitializerExpressionCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromInitializerExpression(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromInitializerExpressionBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromInitializerExpressionCore(property);
    		DeletedFromInitializerExpressionAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromObjectCreationExpression(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromObjectCreationExpression(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromObjectCreationExpressionCore(XElement)"/> is not executed and <see cref="DeletedFromObjectCreationExpression(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromObjectCreationExpressionBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromObjectCreationExpressionCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromObjectCreationExpressionCore(XElement)"/>.</param>
        partial void DeletedFromObjectCreationExpressionAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromObjectCreationExpression(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromObjectCreationExpressionCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "NewKeyword")
    			return false;
    		
    		return true;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromObjectCreationExpression(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromObjectCreationExpressionBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromObjectCreationExpressionCore(property);
    		DeletedFromObjectCreationExpressionAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromAnonymousObjectCreationExpression(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromAnonymousObjectCreationExpression(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromAnonymousObjectCreationExpressionCore(XElement)"/> is not executed and <see cref="DeletedFromAnonymousObjectCreationExpression(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromAnonymousObjectCreationExpressionBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromAnonymousObjectCreationExpressionCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromAnonymousObjectCreationExpressionCore(XElement)"/>.</param>
        partial void DeletedFromAnonymousObjectCreationExpressionAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromAnonymousObjectCreationExpression(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromAnonymousObjectCreationExpressionCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromAnonymousObjectCreationExpression(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromAnonymousObjectCreationExpressionBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromAnonymousObjectCreationExpressionCore(property);
    		DeletedFromAnonymousObjectCreationExpressionAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromArrayCreationExpression(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromArrayCreationExpression(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromArrayCreationExpressionCore(XElement)"/> is not executed and <see cref="DeletedFromArrayCreationExpression(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromArrayCreationExpressionBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromArrayCreationExpressionCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromArrayCreationExpressionCore(XElement)"/>.</param>
        partial void DeletedFromArrayCreationExpressionAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromArrayCreationExpression(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromArrayCreationExpressionCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "NewKeyword")
    			return false;
    		
    		return true;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromArrayCreationExpression(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromArrayCreationExpressionBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromArrayCreationExpressionCore(property);
    		DeletedFromArrayCreationExpressionAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromImplicitArrayCreationExpression(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromImplicitArrayCreationExpression(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromImplicitArrayCreationExpressionCore(XElement)"/> is not executed and <see cref="DeletedFromImplicitArrayCreationExpression(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromImplicitArrayCreationExpressionBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromImplicitArrayCreationExpressionCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromImplicitArrayCreationExpressionCore(XElement)"/>.</param>
        partial void DeletedFromImplicitArrayCreationExpressionAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromImplicitArrayCreationExpression(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromImplicitArrayCreationExpressionCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromImplicitArrayCreationExpression(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromImplicitArrayCreationExpressionBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromImplicitArrayCreationExpressionCore(property);
    		DeletedFromImplicitArrayCreationExpressionAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromStackAllocArrayCreationExpression(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromStackAllocArrayCreationExpression(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromStackAllocArrayCreationExpressionCore(XElement)"/> is not executed and <see cref="DeletedFromStackAllocArrayCreationExpression(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromStackAllocArrayCreationExpressionBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromStackAllocArrayCreationExpressionCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromStackAllocArrayCreationExpressionCore(XElement)"/>.</param>
        partial void DeletedFromStackAllocArrayCreationExpressionAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromStackAllocArrayCreationExpression(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromStackAllocArrayCreationExpressionCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "StackAllocKeyword")
    			return false;
    		
    		return true;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromStackAllocArrayCreationExpression(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromStackAllocArrayCreationExpressionBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromStackAllocArrayCreationExpressionCore(property);
    		DeletedFromStackAllocArrayCreationExpressionAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromQueryExpression(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromQueryExpression(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromQueryExpressionCore(XElement)"/> is not executed and <see cref="DeletedFromQueryExpression(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromQueryExpressionBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromQueryExpressionCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromQueryExpressionCore(XElement)"/>.</param>
        partial void DeletedFromQueryExpressionAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromQueryExpression(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromQueryExpressionCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		yield break;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromQueryExpression(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromQueryExpressionBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromQueryExpressionCore(property);
    		DeletedFromQueryExpressionAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromOmittedArraySizeExpression(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromOmittedArraySizeExpression(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromOmittedArraySizeExpressionCore(XElement)"/> is not executed and <see cref="DeletedFromOmittedArraySizeExpression(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromOmittedArraySizeExpressionBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromOmittedArraySizeExpressionCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromOmittedArraySizeExpressionCore(XElement)"/>.</param>
        partial void DeletedFromOmittedArraySizeExpressionAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromOmittedArraySizeExpression(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromOmittedArraySizeExpressionCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "OmittedArraySizeExpressionToken")
    			return false;
    		
    		return true;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromOmittedArraySizeExpression(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromOmittedArraySizeExpressionBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromOmittedArraySizeExpressionCore(property);
    		DeletedFromOmittedArraySizeExpressionAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromInterpolatedStringExpression(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromInterpolatedStringExpression(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromInterpolatedStringExpressionCore(XElement)"/> is not executed and <see cref="DeletedFromInterpolatedStringExpression(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromInterpolatedStringExpressionBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromInterpolatedStringExpressionCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromInterpolatedStringExpressionCore(XElement)"/>.</param>
        partial void DeletedFromInterpolatedStringExpressionAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromInterpolatedStringExpression(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromInterpolatedStringExpressionCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromInterpolatedStringExpression(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromInterpolatedStringExpressionBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromInterpolatedStringExpressionCore(property);
    		DeletedFromInterpolatedStringExpressionAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromIsPatternExpression(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromIsPatternExpression(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromIsPatternExpressionCore(XElement)"/> is not executed and <see cref="DeletedFromIsPatternExpression(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromIsPatternExpressionBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromIsPatternExpressionCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromIsPatternExpressionCore(XElement)"/>.</param>
        partial void DeletedFromIsPatternExpressionAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromIsPatternExpression(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromIsPatternExpressionCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "IsKeyword")
    			return false;
    		
    		return true;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromIsPatternExpression(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromIsPatternExpressionBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromIsPatternExpressionCore(property);
    		DeletedFromIsPatternExpressionAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromThrowExpression(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromThrowExpression(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromThrowExpressionCore(XElement)"/> is not executed and <see cref="DeletedFromThrowExpression(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromThrowExpressionBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromThrowExpressionCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromThrowExpressionCore(XElement)"/>.</param>
        partial void DeletedFromThrowExpressionAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromThrowExpression(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromThrowExpressionCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "ThrowKeyword")
    			return false;
    		
    		return true;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromThrowExpression(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromThrowExpressionBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromThrowExpressionCore(property);
    		DeletedFromThrowExpressionAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromPredefinedType(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromPredefinedType(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromPredefinedTypeCore(XElement)"/> is not executed and <see cref="DeletedFromPredefinedType(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromPredefinedTypeBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromPredefinedTypeCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromPredefinedTypeCore(XElement)"/>.</param>
        partial void DeletedFromPredefinedTypeAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromPredefinedType(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromPredefinedTypeCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		yield break;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromPredefinedType(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromPredefinedTypeBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromPredefinedTypeCore(property);
    		DeletedFromPredefinedTypeAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromArrayType(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromArrayType(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromArrayTypeCore(XElement)"/> is not executed and <see cref="DeletedFromArrayType(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromArrayTypeBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromArrayTypeCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromArrayTypeCore(XElement)"/>.</param>
        partial void DeletedFromArrayTypeAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromArrayType(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromArrayTypeCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		yield break;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromArrayType(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromArrayTypeBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromArrayTypeCore(property);
    		DeletedFromArrayTypeAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromPointerType(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromPointerType(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromPointerTypeCore(XElement)"/> is not executed and <see cref="DeletedFromPointerType(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromPointerTypeBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromPointerTypeCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromPointerTypeCore(XElement)"/>.</param>
        partial void DeletedFromPointerTypeAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromPointerType(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromPointerTypeCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "AsteriskToken")
    			return false;
    		
    		return true;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromPointerType(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromPointerTypeBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromPointerTypeCore(property);
    		DeletedFromPointerTypeAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromNullableType(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromNullableType(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromNullableTypeCore(XElement)"/> is not executed and <see cref="DeletedFromNullableType(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromNullableTypeBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromNullableTypeCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromNullableTypeCore(XElement)"/>.</param>
        partial void DeletedFromNullableTypeAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromNullableType(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromNullableTypeCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "QuestionToken")
    			return false;
    		
    		return true;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromNullableType(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromNullableTypeBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromNullableTypeCore(property);
    		DeletedFromNullableTypeAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromTupleType(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromTupleType(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromTupleTypeCore(XElement)"/> is not executed and <see cref="DeletedFromTupleType(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromTupleTypeBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromTupleTypeCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromTupleTypeCore(XElement)"/>.</param>
        partial void DeletedFromTupleTypeAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromTupleType(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromTupleTypeCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromTupleType(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromTupleTypeBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromTupleTypeCore(property);
    		DeletedFromTupleTypeAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromOmittedTypeArgument(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromOmittedTypeArgument(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromOmittedTypeArgumentCore(XElement)"/> is not executed and <see cref="DeletedFromOmittedTypeArgument(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromOmittedTypeArgumentBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromOmittedTypeArgumentCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromOmittedTypeArgumentCore(XElement)"/>.</param>
        partial void DeletedFromOmittedTypeArgumentAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromOmittedTypeArgument(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromOmittedTypeArgumentCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "OmittedTypeArgumentToken")
    			return false;
    		
    		return true;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromOmittedTypeArgument(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromOmittedTypeArgumentBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromOmittedTypeArgumentCore(property);
    		DeletedFromOmittedTypeArgumentAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromRefType(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromRefType(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromRefTypeCore(XElement)"/> is not executed and <see cref="DeletedFromRefType(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromRefTypeBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromRefTypeCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromRefTypeCore(XElement)"/>.</param>
        partial void DeletedFromRefTypeAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromRefType(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromRefTypeCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromRefType(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromRefTypeBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromRefTypeCore(property);
    		DeletedFromRefTypeAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromQualifiedName(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromQualifiedName(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromQualifiedNameCore(XElement)"/> is not executed and <see cref="DeletedFromQualifiedName(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromQualifiedNameBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromQualifiedNameCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromQualifiedNameCore(XElement)"/>.</param>
        partial void DeletedFromQualifiedNameAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromQualifiedName(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromQualifiedNameCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "DotToken")
    			return false;
    		
    		return true;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromQualifiedName(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromQualifiedNameBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromQualifiedNameCore(property);
    		DeletedFromQualifiedNameAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromAliasQualifiedName(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromAliasQualifiedName(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromAliasQualifiedNameCore(XElement)"/> is not executed and <see cref="DeletedFromAliasQualifiedName(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromAliasQualifiedNameBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromAliasQualifiedNameCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromAliasQualifiedNameCore(XElement)"/>.</param>
        partial void DeletedFromAliasQualifiedNameAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromAliasQualifiedName(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromAliasQualifiedNameCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "ColonColonToken")
    			return false;
    		
    		return true;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromAliasQualifiedName(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromAliasQualifiedNameBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromAliasQualifiedNameCore(property);
    		DeletedFromAliasQualifiedNameAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromIdentifierName(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromIdentifierName(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromIdentifierNameCore(XElement)"/> is not executed and <see cref="DeletedFromIdentifierName(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromIdentifierNameBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromIdentifierNameCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromIdentifierNameCore(XElement)"/>.</param>
        partial void DeletedFromIdentifierNameAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromIdentifierName(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromIdentifierNameCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		yield break;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromIdentifierName(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromIdentifierNameBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromIdentifierNameCore(property);
    		DeletedFromIdentifierNameAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromGenericName(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromGenericName(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromGenericNameCore(XElement)"/> is not executed and <see cref="DeletedFromGenericName(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromGenericNameBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromGenericNameCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromGenericNameCore(XElement)"/>.</param>
        partial void DeletedFromGenericNameAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromGenericName(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromGenericNameCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		yield break;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromGenericName(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromGenericNameBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromGenericNameCore(property);
    		DeletedFromGenericNameAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromThisExpression(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromThisExpression(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromThisExpressionCore(XElement)"/> is not executed and <see cref="DeletedFromThisExpression(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromThisExpressionBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromThisExpressionCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromThisExpressionCore(XElement)"/>.</param>
        partial void DeletedFromThisExpressionAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromThisExpression(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromThisExpressionCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "Token")
    			return false;
    		
    		return true;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromThisExpression(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromThisExpressionBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromThisExpressionCore(property);
    		DeletedFromThisExpressionAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromBaseExpression(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromBaseExpression(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromBaseExpressionCore(XElement)"/> is not executed and <see cref="DeletedFromBaseExpression(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromBaseExpressionBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromBaseExpressionCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromBaseExpressionCore(XElement)"/>.</param>
        partial void DeletedFromBaseExpressionAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromBaseExpression(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromBaseExpressionCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "Token")
    			return false;
    		
    		return true;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromBaseExpression(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromBaseExpressionBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromBaseExpressionCore(property);
    		DeletedFromBaseExpressionAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromAnonymousMethodExpression(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromAnonymousMethodExpression(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromAnonymousMethodExpressionCore(XElement)"/> is not executed and <see cref="DeletedFromAnonymousMethodExpression(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromAnonymousMethodExpressionBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromAnonymousMethodExpressionCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromAnonymousMethodExpressionCore(XElement)"/>.</param>
        partial void DeletedFromAnonymousMethodExpressionAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromAnonymousMethodExpression(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromAnonymousMethodExpressionCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromAnonymousMethodExpression(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromAnonymousMethodExpressionBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromAnonymousMethodExpressionCore(property);
    		DeletedFromAnonymousMethodExpressionAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromSimpleLambdaExpression(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromSimpleLambdaExpression(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromSimpleLambdaExpressionCore(XElement)"/> is not executed and <see cref="DeletedFromSimpleLambdaExpression(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromSimpleLambdaExpressionBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromSimpleLambdaExpressionCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromSimpleLambdaExpressionCore(XElement)"/>.</param>
        partial void DeletedFromSimpleLambdaExpressionAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromSimpleLambdaExpression(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromSimpleLambdaExpressionCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromSimpleLambdaExpression(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromSimpleLambdaExpressionBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromSimpleLambdaExpressionCore(property);
    		DeletedFromSimpleLambdaExpressionAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromParenthesizedLambdaExpression(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromParenthesizedLambdaExpression(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromParenthesizedLambdaExpressionCore(XElement)"/> is not executed and <see cref="DeletedFromParenthesizedLambdaExpression(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromParenthesizedLambdaExpressionBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromParenthesizedLambdaExpressionCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromParenthesizedLambdaExpressionCore(XElement)"/>.</param>
        partial void DeletedFromParenthesizedLambdaExpressionAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromParenthesizedLambdaExpression(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromParenthesizedLambdaExpressionCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromParenthesizedLambdaExpression(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromParenthesizedLambdaExpressionBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromParenthesizedLambdaExpressionCore(property);
    		DeletedFromParenthesizedLambdaExpressionAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromArgumentList(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromArgumentList(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromArgumentListCore(XElement)"/> is not executed and <see cref="DeletedFromArgumentList(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromArgumentListBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromArgumentListCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromArgumentListCore(XElement)"/>.</param>
        partial void DeletedFromArgumentListAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromArgumentList(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromArgumentListCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromArgumentList(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromArgumentListBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromArgumentListCore(property);
    		DeletedFromArgumentListAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromBracketedArgumentList(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromBracketedArgumentList(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromBracketedArgumentListCore(XElement)"/> is not executed and <see cref="DeletedFromBracketedArgumentList(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromBracketedArgumentListBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromBracketedArgumentListCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromBracketedArgumentListCore(XElement)"/>.</param>
        partial void DeletedFromBracketedArgumentListAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromBracketedArgumentList(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromBracketedArgumentListCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromBracketedArgumentList(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromBracketedArgumentListBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromBracketedArgumentListCore(property);
    		DeletedFromBracketedArgumentListAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromFromClause(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromFromClause(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromFromClauseCore(XElement)"/> is not executed and <see cref="DeletedFromFromClause(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromFromClauseBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromFromClauseCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromFromClauseCore(XElement)"/>.</param>
        partial void DeletedFromFromClauseAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromFromClause(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromFromClauseCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromFromClause(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromFromClauseBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromFromClauseCore(property);
    		DeletedFromFromClauseAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromLetClause(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromLetClause(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromLetClauseCore(XElement)"/> is not executed and <see cref="DeletedFromLetClause(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromLetClauseBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromLetClauseCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromLetClauseCore(XElement)"/>.</param>
        partial void DeletedFromLetClauseAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromLetClause(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromLetClauseCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromLetClause(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromLetClauseBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromLetClauseCore(property);
    		DeletedFromLetClauseAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromJoinClause(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromJoinClause(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromJoinClauseCore(XElement)"/> is not executed and <see cref="DeletedFromJoinClause(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromJoinClauseBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromJoinClauseCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromJoinClauseCore(XElement)"/>.</param>
        partial void DeletedFromJoinClauseAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromJoinClause(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromJoinClauseCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromJoinClause(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromJoinClauseBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromJoinClauseCore(property);
    		DeletedFromJoinClauseAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromWhereClause(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromWhereClause(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromWhereClauseCore(XElement)"/> is not executed and <see cref="DeletedFromWhereClause(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromWhereClauseBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromWhereClauseCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromWhereClauseCore(XElement)"/>.</param>
        partial void DeletedFromWhereClauseAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromWhereClause(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromWhereClauseCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "WhereKeyword")
    			return false;
    		
    		return true;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromWhereClause(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromWhereClauseBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromWhereClauseCore(property);
    		DeletedFromWhereClauseAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromOrderByClause(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromOrderByClause(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromOrderByClauseCore(XElement)"/> is not executed and <see cref="DeletedFromOrderByClause(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromOrderByClauseBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromOrderByClauseCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromOrderByClauseCore(XElement)"/>.</param>
        partial void DeletedFromOrderByClauseAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromOrderByClause(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromOrderByClauseCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "OrderByKeyword")
    			return false;
    		
    		return true;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromOrderByClause(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromOrderByClauseBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromOrderByClauseCore(property);
    		DeletedFromOrderByClauseAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromSelectClause(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromSelectClause(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromSelectClauseCore(XElement)"/> is not executed and <see cref="DeletedFromSelectClause(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromSelectClauseBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromSelectClauseCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromSelectClauseCore(XElement)"/>.</param>
        partial void DeletedFromSelectClauseAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromSelectClause(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromSelectClauseCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "SelectKeyword")
    			return false;
    		
    		return true;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromSelectClause(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromSelectClauseBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromSelectClauseCore(property);
    		DeletedFromSelectClauseAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromGroupClause(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromGroupClause(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromGroupClauseCore(XElement)"/> is not executed and <see cref="DeletedFromGroupClause(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromGroupClauseBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromGroupClauseCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromGroupClauseCore(XElement)"/>.</param>
        partial void DeletedFromGroupClauseAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromGroupClause(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromGroupClauseCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromGroupClause(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromGroupClauseBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromGroupClauseCore(property);
    		DeletedFromGroupClauseAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromDeclarationPattern(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromDeclarationPattern(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromDeclarationPatternCore(XElement)"/> is not executed and <see cref="DeletedFromDeclarationPattern(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromDeclarationPatternBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromDeclarationPatternCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromDeclarationPatternCore(XElement)"/>.</param>
        partial void DeletedFromDeclarationPatternAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromDeclarationPattern(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromDeclarationPatternCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		yield break;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromDeclarationPattern(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromDeclarationPatternBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromDeclarationPatternCore(property);
    		DeletedFromDeclarationPatternAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromConstantPattern(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromConstantPattern(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromConstantPatternCore(XElement)"/> is not executed and <see cref="DeletedFromConstantPattern(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromConstantPatternBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromConstantPatternCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromConstantPatternCore(XElement)"/>.</param>
        partial void DeletedFromConstantPatternAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromConstantPattern(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromConstantPatternCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		yield break;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromConstantPattern(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromConstantPatternBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromConstantPatternCore(property);
    		DeletedFromConstantPatternAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromInterpolatedStringText(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromInterpolatedStringText(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromInterpolatedStringTextCore(XElement)"/> is not executed and <see cref="DeletedFromInterpolatedStringText(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromInterpolatedStringTextBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromInterpolatedStringTextCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromInterpolatedStringTextCore(XElement)"/>.</param>
        partial void DeletedFromInterpolatedStringTextAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromInterpolatedStringText(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromInterpolatedStringTextCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		yield break;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromInterpolatedStringText(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromInterpolatedStringTextBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromInterpolatedStringTextCore(property);
    		DeletedFromInterpolatedStringTextAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromInterpolation(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromInterpolation(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromInterpolationCore(XElement)"/> is not executed and <see cref="DeletedFromInterpolation(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromInterpolationBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromInterpolationCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromInterpolationCore(XElement)"/>.</param>
        partial void DeletedFromInterpolationAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromInterpolation(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromInterpolationCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromInterpolation(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromInterpolationBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromInterpolationCore(property);
    		DeletedFromInterpolationAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromBlock(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromBlock(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromBlockCore(XElement)"/> is not executed and <see cref="DeletedFromBlock(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromBlockBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromBlockCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromBlockCore(XElement)"/>.</param>
        partial void DeletedFromBlockAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromBlock(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromBlockCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromBlock(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromBlockBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromBlockCore(property);
    		DeletedFromBlockAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromLocalFunctionStatement(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromLocalFunctionStatement(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromLocalFunctionStatementCore(XElement)"/> is not executed and <see cref="DeletedFromLocalFunctionStatement(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromLocalFunctionStatementBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromLocalFunctionStatementCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromLocalFunctionStatementCore(XElement)"/>.</param>
        partial void DeletedFromLocalFunctionStatementAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromLocalFunctionStatement(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromLocalFunctionStatementCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "SemicolonToken")
    			return false;
    		
    		return true;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromLocalFunctionStatement(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromLocalFunctionStatementBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromLocalFunctionStatementCore(property);
    		DeletedFromLocalFunctionStatementAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromLocalDeclarationStatement(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromLocalDeclarationStatement(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromLocalDeclarationStatementCore(XElement)"/> is not executed and <see cref="DeletedFromLocalDeclarationStatement(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromLocalDeclarationStatementBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromLocalDeclarationStatementCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromLocalDeclarationStatementCore(XElement)"/>.</param>
        partial void DeletedFromLocalDeclarationStatementAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromLocalDeclarationStatement(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromLocalDeclarationStatementCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "SemicolonToken")
    			return false;
    		
    		return true;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromLocalDeclarationStatement(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromLocalDeclarationStatementBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromLocalDeclarationStatementCore(property);
    		DeletedFromLocalDeclarationStatementAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromExpressionStatement(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromExpressionStatement(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromExpressionStatementCore(XElement)"/> is not executed and <see cref="DeletedFromExpressionStatement(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromExpressionStatementBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromExpressionStatementCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromExpressionStatementCore(XElement)"/>.</param>
        partial void DeletedFromExpressionStatementAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromExpressionStatement(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromExpressionStatementCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "SemicolonToken")
    			return false;
    		
    		return true;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromExpressionStatement(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromExpressionStatementBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromExpressionStatementCore(property);
    		DeletedFromExpressionStatementAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromEmptyStatement(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromEmptyStatement(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromEmptyStatementCore(XElement)"/> is not executed and <see cref="DeletedFromEmptyStatement(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromEmptyStatementBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromEmptyStatementCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromEmptyStatementCore(XElement)"/>.</param>
        partial void DeletedFromEmptyStatementAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromEmptyStatement(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromEmptyStatementCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "SemicolonToken")
    			return false;
    		
    		return true;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromEmptyStatement(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromEmptyStatementBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromEmptyStatementCore(property);
    		DeletedFromEmptyStatementAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromLabeledStatement(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromLabeledStatement(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromLabeledStatementCore(XElement)"/> is not executed and <see cref="DeletedFromLabeledStatement(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromLabeledStatementBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromLabeledStatementCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromLabeledStatementCore(XElement)"/>.</param>
        partial void DeletedFromLabeledStatementAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromLabeledStatement(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromLabeledStatementCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "ColonToken")
    			return false;
    		
    		return true;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromLabeledStatement(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromLabeledStatementBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromLabeledStatementCore(property);
    		DeletedFromLabeledStatementAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromGotoStatement(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromGotoStatement(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromGotoStatementCore(XElement)"/> is not executed and <see cref="DeletedFromGotoStatement(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromGotoStatementBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromGotoStatementCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromGotoStatementCore(XElement)"/>.</param>
        partial void DeletedFromGotoStatementAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromGotoStatement(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromGotoStatementCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromGotoStatement(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromGotoStatementBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromGotoStatementCore(property);
    		DeletedFromGotoStatementAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromBreakStatement(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromBreakStatement(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromBreakStatementCore(XElement)"/> is not executed and <see cref="DeletedFromBreakStatement(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromBreakStatementBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromBreakStatementCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromBreakStatementCore(XElement)"/>.</param>
        partial void DeletedFromBreakStatementAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromBreakStatement(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromBreakStatementCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromBreakStatement(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromBreakStatementBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromBreakStatementCore(property);
    		DeletedFromBreakStatementAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromContinueStatement(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromContinueStatement(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromContinueStatementCore(XElement)"/> is not executed and <see cref="DeletedFromContinueStatement(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromContinueStatementBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromContinueStatementCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromContinueStatementCore(XElement)"/>.</param>
        partial void DeletedFromContinueStatementAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromContinueStatement(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromContinueStatementCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromContinueStatement(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromContinueStatementBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromContinueStatementCore(property);
    		DeletedFromContinueStatementAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromReturnStatement(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromReturnStatement(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromReturnStatementCore(XElement)"/> is not executed and <see cref="DeletedFromReturnStatement(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromReturnStatementBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromReturnStatementCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromReturnStatementCore(XElement)"/>.</param>
        partial void DeletedFromReturnStatementAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromReturnStatement(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromReturnStatementCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromReturnStatement(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromReturnStatementBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromReturnStatementCore(property);
    		DeletedFromReturnStatementAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromThrowStatement(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromThrowStatement(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromThrowStatementCore(XElement)"/> is not executed and <see cref="DeletedFromThrowStatement(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromThrowStatementBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromThrowStatementCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromThrowStatementCore(XElement)"/>.</param>
        partial void DeletedFromThrowStatementAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromThrowStatement(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromThrowStatementCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromThrowStatement(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromThrowStatementBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromThrowStatementCore(property);
    		DeletedFromThrowStatementAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromYieldStatement(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromYieldStatement(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromYieldStatementCore(XElement)"/> is not executed and <see cref="DeletedFromYieldStatement(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromYieldStatementBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromYieldStatementCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromYieldStatementCore(XElement)"/>.</param>
        partial void DeletedFromYieldStatementAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromYieldStatement(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromYieldStatementCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromYieldStatement(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromYieldStatementBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromYieldStatementCore(property);
    		DeletedFromYieldStatementAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromWhileStatement(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromWhileStatement(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromWhileStatementCore(XElement)"/> is not executed and <see cref="DeletedFromWhileStatement(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromWhileStatementBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromWhileStatementCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromWhileStatementCore(XElement)"/>.</param>
        partial void DeletedFromWhileStatementAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromWhileStatement(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromWhileStatementCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromWhileStatement(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromWhileStatementBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromWhileStatementCore(property);
    		DeletedFromWhileStatementAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromDoStatement(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromDoStatement(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromDoStatementCore(XElement)"/> is not executed and <see cref="DeletedFromDoStatement(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromDoStatementBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromDoStatementCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromDoStatementCore(XElement)"/>.</param>
        partial void DeletedFromDoStatementAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromDoStatement(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromDoStatementCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromDoStatement(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromDoStatementBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromDoStatementCore(property);
    		DeletedFromDoStatementAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromForStatement(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromForStatement(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromForStatementCore(XElement)"/> is not executed and <see cref="DeletedFromForStatement(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromForStatementBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromForStatementCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromForStatementCore(XElement)"/>.</param>
        partial void DeletedFromForStatementAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromForStatement(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromForStatementCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromForStatement(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromForStatementBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromForStatementCore(property);
    		DeletedFromForStatementAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromUsingStatement(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromUsingStatement(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromUsingStatementCore(XElement)"/> is not executed and <see cref="DeletedFromUsingStatement(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromUsingStatementBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromUsingStatementCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromUsingStatementCore(XElement)"/>.</param>
        partial void DeletedFromUsingStatementAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromUsingStatement(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromUsingStatementCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromUsingStatement(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromUsingStatementBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromUsingStatementCore(property);
    		DeletedFromUsingStatementAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromFixedStatement(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromFixedStatement(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromFixedStatementCore(XElement)"/> is not executed and <see cref="DeletedFromFixedStatement(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromFixedStatementBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromFixedStatementCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromFixedStatementCore(XElement)"/>.</param>
        partial void DeletedFromFixedStatementAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromFixedStatement(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromFixedStatementCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromFixedStatement(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromFixedStatementBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromFixedStatementCore(property);
    		DeletedFromFixedStatementAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromCheckedStatement(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromCheckedStatement(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromCheckedStatementCore(XElement)"/> is not executed and <see cref="DeletedFromCheckedStatement(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromCheckedStatementBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromCheckedStatementCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromCheckedStatementCore(XElement)"/>.</param>
        partial void DeletedFromCheckedStatementAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromCheckedStatement(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromCheckedStatementCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "Keyword")
    			return false;
    		
    		return true;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromCheckedStatement(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromCheckedStatementBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromCheckedStatementCore(property);
    		DeletedFromCheckedStatementAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromUnsafeStatement(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromUnsafeStatement(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromUnsafeStatementCore(XElement)"/> is not executed and <see cref="DeletedFromUnsafeStatement(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromUnsafeStatementBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromUnsafeStatementCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromUnsafeStatementCore(XElement)"/>.</param>
        partial void DeletedFromUnsafeStatementAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromUnsafeStatement(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromUnsafeStatementCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "UnsafeKeyword")
    			return false;
    		
    		return true;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromUnsafeStatement(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromUnsafeStatementBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromUnsafeStatementCore(property);
    		DeletedFromUnsafeStatementAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromLockStatement(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromLockStatement(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromLockStatementCore(XElement)"/> is not executed and <see cref="DeletedFromLockStatement(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromLockStatementBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromLockStatementCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromLockStatementCore(XElement)"/>.</param>
        partial void DeletedFromLockStatementAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromLockStatement(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromLockStatementCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromLockStatement(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromLockStatementBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromLockStatementCore(property);
    		DeletedFromLockStatementAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromIfStatement(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromIfStatement(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromIfStatementCore(XElement)"/> is not executed and <see cref="DeletedFromIfStatement(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromIfStatementBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromIfStatementCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromIfStatementCore(XElement)"/>.</param>
        partial void DeletedFromIfStatementAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromIfStatement(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromIfStatementCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromIfStatement(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromIfStatementBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromIfStatementCore(property);
    		DeletedFromIfStatementAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromSwitchStatement(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromSwitchStatement(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromSwitchStatementCore(XElement)"/> is not executed and <see cref="DeletedFromSwitchStatement(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromSwitchStatementBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromSwitchStatementCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromSwitchStatementCore(XElement)"/>.</param>
        partial void DeletedFromSwitchStatementAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromSwitchStatement(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromSwitchStatementCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromSwitchStatement(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromSwitchStatementBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromSwitchStatementCore(property);
    		DeletedFromSwitchStatementAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromTryStatement(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromTryStatement(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromTryStatementCore(XElement)"/> is not executed and <see cref="DeletedFromTryStatement(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromTryStatementBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromTryStatementCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromTryStatementCore(XElement)"/>.</param>
        partial void DeletedFromTryStatementAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromTryStatement(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromTryStatementCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "TryKeyword")
    			return false;
    		
    		return true;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromTryStatement(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromTryStatementBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromTryStatementCore(property);
    		DeletedFromTryStatementAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromForEachStatement(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromForEachStatement(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromForEachStatementCore(XElement)"/> is not executed and <see cref="DeletedFromForEachStatement(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromForEachStatementBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromForEachStatementCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromForEachStatementCore(XElement)"/>.</param>
        partial void DeletedFromForEachStatementAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromForEachStatement(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromForEachStatementCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromForEachStatement(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromForEachStatementBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromForEachStatementCore(property);
    		DeletedFromForEachStatementAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromForEachVariableStatement(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromForEachVariableStatement(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromForEachVariableStatementCore(XElement)"/> is not executed and <see cref="DeletedFromForEachVariableStatement(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromForEachVariableStatementBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromForEachVariableStatementCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromForEachVariableStatementCore(XElement)"/>.</param>
        partial void DeletedFromForEachVariableStatementAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromForEachVariableStatement(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromForEachVariableStatementCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromForEachVariableStatement(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromForEachVariableStatementBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromForEachVariableStatementCore(property);
    		DeletedFromForEachVariableStatementAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromSingleVariableDesignation(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromSingleVariableDesignation(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromSingleVariableDesignationCore(XElement)"/> is not executed and <see cref="DeletedFromSingleVariableDesignation(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromSingleVariableDesignationBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromSingleVariableDesignationCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromSingleVariableDesignationCore(XElement)"/>.</param>
        partial void DeletedFromSingleVariableDesignationAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromSingleVariableDesignation(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromSingleVariableDesignationCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		yield break;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromSingleVariableDesignation(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromSingleVariableDesignationBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromSingleVariableDesignationCore(property);
    		DeletedFromSingleVariableDesignationAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromDiscardDesignation(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromDiscardDesignation(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromDiscardDesignationCore(XElement)"/> is not executed and <see cref="DeletedFromDiscardDesignation(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromDiscardDesignationBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromDiscardDesignationCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromDiscardDesignationCore(XElement)"/>.</param>
        partial void DeletedFromDiscardDesignationAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromDiscardDesignation(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromDiscardDesignationCore(XElement property)
        {
    		if(property == null)
    			throw new ArgumentNullException(nameof(property));
    
    		if(property.Attribute("part")?.Value == "UnderscoreToken")
    			return false;
    		
    		return true;
        }	
    	
         /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromDiscardDesignation(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromDiscardDesignationBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromDiscardDesignationCore(property);
    		DeletedFromDiscardDesignationAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromParenthesizedVariableDesignation(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromParenthesizedVariableDesignation(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromParenthesizedVariableDesignationCore(XElement)"/> is not executed and <see cref="DeletedFromParenthesizedVariableDesignation(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromParenthesizedVariableDesignationBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromParenthesizedVariableDesignationCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromParenthesizedVariableDesignationCore(XElement)"/>.</param>
        partial void DeletedFromParenthesizedVariableDesignationAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromParenthesizedVariableDesignation(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromParenthesizedVariableDesignationCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromParenthesizedVariableDesignation(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromParenthesizedVariableDesignationBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromParenthesizedVariableDesignationCore(property);
    		DeletedFromParenthesizedVariableDesignationAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromCasePatternSwitchLabel(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromCasePatternSwitchLabel(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromCasePatternSwitchLabelCore(XElement)"/> is not executed and <see cref="DeletedFromCasePatternSwitchLabel(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromCasePatternSwitchLabelBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromCasePatternSwitchLabelCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromCasePatternSwitchLabelCore(XElement)"/>.</param>
        partial void DeletedFromCasePatternSwitchLabelAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromCasePatternSwitchLabel(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromCasePatternSwitchLabelCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromCasePatternSwitchLabel(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromCasePatternSwitchLabelBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromCasePatternSwitchLabelCore(property);
    		DeletedFromCasePatternSwitchLabelAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromCaseSwitchLabel(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromCaseSwitchLabel(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromCaseSwitchLabelCore(XElement)"/> is not executed and <see cref="DeletedFromCaseSwitchLabel(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromCaseSwitchLabelBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromCaseSwitchLabelCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromCaseSwitchLabelCore(XElement)"/>.</param>
        partial void DeletedFromCaseSwitchLabelAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromCaseSwitchLabel(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromCaseSwitchLabelCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromCaseSwitchLabel(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromCaseSwitchLabelBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromCaseSwitchLabelCore(property);
    		DeletedFromCaseSwitchLabelAfter(property, ref result);
    		return result;
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="DeletedFromDefaultSwitchLabel(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromDefaultSwitchLabel(XElement)"/>.</param>
        /// <param name="ignoreCore">If true, the <see cref="DeletedFromDefaultSwitchLabelCore(XElement)"/> is not executed and <see cref="DeletedFromDefaultSwitchLabel(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DeletedFromDefaultSwitchLabelBefore(XElement property, ref IEnumerable<Imprecision> result, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DeletedFromDefaultSwitchLabelCore(XElement)"/>.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="DeletedFromDefaultSwitchLabelCore(XElement)"/>.</param>
        partial void DeletedFromDefaultSwitchLabelAfter(XElement property, ref IEnumerable<Imprecision> result);
    
    	 /// <summary>
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        /// <remarks>This is the default implementation for <see cref="DeletedFromDefaultSwitchLabel(XElement)"/>.</remarks>
        public virtual IEnumerable<Imprecision> DeletedFromDefaultSwitchLabelCore(XElement property)
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
        /// Analyzes a delete action.
        /// </summary>
        /// <param name="property">deleted element.</param>
        /// <returns>the imprecisions supposedly detected.</returns>
        public virtual IEnumerable<Imprecision> DeletedFromDefaultSwitchLabel(XElement property)
    	{
    		IEnumerable<Imprecision> result = null;
    		var ignoreCore = false;
    		DeletedFromDefaultSwitchLabelBefore(property, ref result, ref ignoreCore);
    		if(ignoreCore) 
    			return result;
    		
    		result = this.DeletedFromDefaultSwitchLabelCore(property);
    		DeletedFromDefaultSwitchLabelAfter(property, ref result);
    		return result;
    	}
    
    }
}
// Generated helper templates
// Generated items
