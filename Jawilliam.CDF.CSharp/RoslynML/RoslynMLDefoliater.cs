
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Jawilliam.CDF.CSharp.RoslynML
{
    partial class RoslynML
    {
    	/// <summary>
        /// Called when a xml-format tree needs to be defoliated.
        /// </summary>
        /// <param name="tree">node of interest.</param>
        public virtual void Defoliate(XElement tree)
        {
            foreach (var c in tree.PostOrder(c => c.Elements()))
            {
                this.GetDefoliater(c)?.Invoke(c);
            }
        }
    
    	/// <summary>
        /// Gets the <see cref="IElementTypeServiceProvider"/> to provide information for the requested element type.
        /// </summary>
        /// <param name="node">node of interest.</param>
        public virtual Action<XElement> GetDefoliater(XElement node)
    	{
    		string type = node.Name.LocalName;
    		type = type == "tree" ? node.Attribute("typeLabel").Value : type;
    
    	    if(type == "Token" ||
    		   type == "TokenList" ||
    		   type == "CommentTrivia" ||
    		   type.StartsWith("List_of_") ||
    		   type.StartsWith("SeparatedList_of_"))
    			return null;
    
    		switch(node.Name.LocalName)
    		{
    			case "AttributeArgument": return null;
    			case "NameEquals": return this.DefoliateNameEquals;
    			case "TypeParameterList": return null;
    			case "TypeParameter": return null;
    			case "BaseList": return null;
    			case "TypeParameterConstraintClause": return null;
    			case "ExplicitInterfaceSpecifier": return null;
    			case "ConstructorInitializer": return null;
    			case "ArrowExpressionClause": return null;
    			case "AccessorList": return null;
    			case "AccessorDeclaration": return null;
    			case "Parameter": return null;
    			case "CrefParameter": return null;
    			case "XmlElementStartTag": return null;
    			case "XmlElementEndTag": return this.DefoliateXmlElementEndTag;
    			case "XmlName": return this.DefoliateXmlName;
    			case "XmlPrefix": return this.DefoliateXmlPrefix;
    			case "TypeArgumentList": return null;
    			case "ArrayRankSpecifier": return null;
    			case "TupleElement": return null;
    			case "Argument": return null;
    			case "NameColon": return this.DefoliateNameColon;
    			case "AnonymousObjectMemberDeclarator": return null;
    			case "QueryBody": return null;
    			case "JoinIntoClause": return this.DefoliateJoinIntoClause;
    			case "Ordering": return null;
    			case "QueryContinuation": return null;
    			case "WhenClause": return null;
    			case "InterpolationAlignmentClause": return null;
    			case "InterpolationFormatClause": return this.DefoliateInterpolationFormatClause;
    			case "VariableDeclaration": return null;
    			case "VariableDeclarator": return null;
    			case "EqualsValueClause": return null;
    			case "ElseClause": return null;
    			case "SwitchSection": return null;
    			case "CatchClause": return null;
    			case "CatchDeclaration": return null;
    			case "CatchFilterClause": return null;
    			case "FinallyClause": return null;
    			case "CompilationUnit": return null;
    			case "ExternAliasDirective": return this.DefoliateExternAliasDirective;
    			case "UsingDirective": return null;
    			case "AttributeList": return null;
    			case "AttributeTargetSpecifier": return this.DefoliateAttributeTargetSpecifier;
    			case "Attribute": return null;
    			case "AttributeArgumentList": return null;
    			case "DelegateDeclaration": return null;
    			case "EnumMemberDeclaration": return null;
    			case "IncompleteMember": return null;
    			case "GlobalStatement": return null;
    			case "NamespaceDeclaration": return null;
    			case "EnumDeclaration": return null;
    			case "ClassDeclaration": return null;
    			case "StructDeclaration": return null;
    			case "InterfaceDeclaration": return null;
    			case "FieldDeclaration": return null;
    			case "EventFieldDeclaration": return null;
    			case "MethodDeclaration": return null;
    			case "OperatorDeclaration": return null;
    			case "ConversionOperatorDeclaration": return null;
    			case "ConstructorDeclaration": return null;
    			case "DestructorDeclaration": return null;
    			case "PropertyDeclaration": return null;
    			case "EventDeclaration": return null;
    			case "IndexerDeclaration": return null;
    			case "SimpleBaseType": return null;
    			case "ConstructorConstraint": return this.DefoliateConstructorConstraint;
    			case "ClassOrStructConstraint": return this.DefoliateClassOrStructConstraint;
    			case "TypeConstraint": return null;
    			case "ParameterList": return null;
    			case "BracketedParameterList": return null;
    			case "SkippedTokensTrivia": return null;
    			case "DocumentationCommentTrivia": return null;
    			case "EndIfDirectiveTrivia": return this.DefoliateEndIfDirectiveTrivia;
    			case "RegionDirectiveTrivia": return this.DefoliateRegionDirectiveTrivia;
    			case "EndRegionDirectiveTrivia": return this.DefoliateEndRegionDirectiveTrivia;
    			case "ErrorDirectiveTrivia": return this.DefoliateErrorDirectiveTrivia;
    			case "WarningDirectiveTrivia": return this.DefoliateWarningDirectiveTrivia;
    			case "BadDirectiveTrivia": return this.DefoliateBadDirectiveTrivia;
    			case "DefineDirectiveTrivia": return this.DefoliateDefineDirectiveTrivia;
    			case "UndefDirectiveTrivia": return this.DefoliateUndefDirectiveTrivia;
    			case "LineDirectiveTrivia": return this.DefoliateLineDirectiveTrivia;
    			case "PragmaWarningDirectiveTrivia": return null;
    			case "PragmaChecksumDirectiveTrivia": return this.DefoliatePragmaChecksumDirectiveTrivia;
    			case "ReferenceDirectiveTrivia": return this.DefoliateReferenceDirectiveTrivia;
    			case "LoadDirectiveTrivia": return this.DefoliateLoadDirectiveTrivia;
    			case "ShebangDirectiveTrivia": return this.DefoliateShebangDirectiveTrivia;
    			case "ElseDirectiveTrivia": return this.DefoliateElseDirectiveTrivia;
    			case "IfDirectiveTrivia": return null;
    			case "ElifDirectiveTrivia": return null;
    			case "TypeCref": return null;
    			case "QualifiedCref": return null;
    			case "NameMemberCref": return null;
    			case "IndexerMemberCref": return null;
    			case "OperatorMemberCref": return null;
    			case "ConversionOperatorMemberCref": return null;
    			case "CrefParameterList": return null;
    			case "CrefBracketedParameterList": return null;
    			case "XmlElement": return null;
    			case "XmlEmptyElement": return null;
    			case "XmlText": return null;
    			case "XmlCDataSection": return null;
    			case "XmlProcessingInstruction": return null;
    			case "XmlComment": return null;
    			case "XmlTextAttribute": return null;
    			case "XmlCrefAttribute": return null;
    			case "XmlNameAttribute": return this.DefoliateXmlNameAttribute;
    			case "ParenthesizedExpression": return null;
    			case "TupleExpression": return null;
    			case "PrefixUnaryExpression": return null;
    			case "AwaitExpression": return null;
    			case "PostfixUnaryExpression": return null;
    			case "MemberAccessExpression": return null;
    			case "ConditionalAccessExpression": return null;
    			case "MemberBindingExpression": return null;
    			case "ElementBindingExpression": return null;
    			case "ImplicitElementAccess": return null;
    			case "BinaryExpression": return null;
    			case "AssignmentExpression": return null;
    			case "ConditionalExpression": return null;
    			case "LiteralExpression": return this.DefoliateLiteralExpression;
    			case "MakeRefExpression": return null;
    			case "RefTypeExpression": return null;
    			case "RefValueExpression": return null;
    			case "CheckedExpression": return null;
    			case "DefaultExpression": return null;
    			case "TypeOfExpression": return null;
    			case "SizeOfExpression": return null;
    			case "InvocationExpression": return null;
    			case "ElementAccessExpression": return null;
    			case "DeclarationExpression": return null;
    			case "CastExpression": return null;
    			case "RefExpression": return null;
    			case "InitializerExpression": return null;
    			case "ObjectCreationExpression": return null;
    			case "AnonymousObjectCreationExpression": return null;
    			case "ArrayCreationExpression": return null;
    			case "ImplicitArrayCreationExpression": return null;
    			case "StackAllocArrayCreationExpression": return null;
    			case "QueryExpression": return null;
    			case "OmittedArraySizeExpression": return this.DefoliateOmittedArraySizeExpression;
    			case "InterpolatedStringExpression": return null;
    			case "IsPatternExpression": return null;
    			case "ThrowExpression": return null;
    			case "PredefinedType": return this.DefoliatePredefinedType;
    			case "ArrayType": return null;
    			case "PointerType": return null;
    			case "NullableType": return null;
    			case "TupleType": return null;
    			case "OmittedTypeArgument": return this.DefoliateOmittedTypeArgument;
    			case "RefType": return null;
    			case "QualifiedName": return null;
    			case "AliasQualifiedName": return null;
    			case "IdentifierName": return this.DefoliateIdentifierName;
    			case "GenericName": return null;
    			case "ThisExpression": return this.DefoliateThisExpression;
    			case "BaseExpression": return this.DefoliateBaseExpression;
    			case "AnonymousMethodExpression": return null;
    			case "SimpleLambdaExpression": return null;
    			case "ParenthesizedLambdaExpression": return null;
    			case "ArgumentList": return null;
    			case "BracketedArgumentList": return null;
    			case "FromClause": return null;
    			case "LetClause": return null;
    			case "JoinClause": return null;
    			case "WhereClause": return null;
    			case "OrderByClause": return null;
    			case "SelectClause": return null;
    			case "GroupClause": return null;
    			case "DeclarationPattern": return null;
    			case "ConstantPattern": return null;
    			case "InterpolatedStringText": return this.DefoliateInterpolatedStringText;
    			case "Interpolation": return null;
    			case "Block": return null;
    			case "LocalFunctionStatement": return null;
    			case "LocalDeclarationStatement": return null;
    			case "ExpressionStatement": return null;
    			case "EmptyStatement": return this.DefoliateEmptyStatement;
    			case "LabeledStatement": return null;
    			case "GotoStatement": return null;
    			case "BreakStatement": return this.DefoliateBreakStatement;
    			case "ContinueStatement": return this.DefoliateContinueStatement;
    			case "ReturnStatement": return null;
    			case "ThrowStatement": return null;
    			case "YieldStatement": return null;
    			case "WhileStatement": return null;
    			case "DoStatement": return null;
    			case "ForStatement": return null;
    			case "UsingStatement": return null;
    			case "FixedStatement": return null;
    			case "CheckedStatement": return null;
    			case "UnsafeStatement": return null;
    			case "LockStatement": return null;
    			case "IfStatement": return null;
    			case "SwitchStatement": return null;
    			case "TryStatement": return null;
    			case "ForEachStatement": return null;
    			case "ForEachVariableStatement": return null;
    			case "SingleVariableDesignation": return this.DefoliateSingleVariableDesignation;
    			case "DiscardDesignation": return this.DefoliateDiscardDesignation;
    			case "ParenthesizedVariableDesignation": return null;
    			case "CasePatternSwitchLabel": return null;
    			case "CaseSwitchLabel": return null;
    			case "DefaultSwitchLabel": return this.DefoliateDefaultSwitchLabel;
    			default: throw new ArgumentException(nameof(node));
    		}
    	}
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Defoliate(XElement)"/>.
        /// </summary>
        /// <param name="node">node of interest.</param>
        /// <param name="ignoreCore">If true, the <see cref="DefoliateCore(XElement)"/> is not executed and <see cref="Defoliate(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DefoliateNameEqualsBefore(XElement node, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DefoliateCore(XElement)"/>.
        /// </summary>
        /// <param name="node">node of interest.</param>
        partial void DefoliateNameEqualsAfter(XElement node);
    
    	/// <summary>
        /// Called when a xml-format NameEqualsSyntax node can be defoliated.
        /// </summary>
        /// <param name="node">node of interest.</param>
        public virtual void DefoliateNameEqualsCore(XElement node)
        {
    		var value = node.Value;
            node.RemoveNodes();
            node.Add(new XText(value));
        }		
    	
        /// <summary>
        /// Called when a xml-format NameEqualsSyntax node can be defoliated.
        /// </summary>
        /// <param name="node">node of interest.</param>
        public virtual void DefoliateNameEquals(XElement node)
    	{
    		var ignoreCore = false;
    		DefoliateNameEqualsBefore(node, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.DefoliateNameEqualsCore(node);
    		DefoliateNameEqualsAfter(node);
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Defoliate(XElement)"/>.
        /// </summary>
        /// <param name="node">node of interest.</param>
        /// <param name="ignoreCore">If true, the <see cref="DefoliateCore(XElement)"/> is not executed and <see cref="Defoliate(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DefoliateXmlElementEndTagBefore(XElement node, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DefoliateCore(XElement)"/>.
        /// </summary>
        /// <param name="node">node of interest.</param>
        partial void DefoliateXmlElementEndTagAfter(XElement node);
    
    	/// <summary>
        /// Called when a xml-format XmlElementEndTagSyntax node can be defoliated.
        /// </summary>
        /// <param name="node">node of interest.</param>
        public virtual void DefoliateXmlElementEndTagCore(XElement node)
        {
    		var value = node.Value;
            node.RemoveNodes();
            node.Add(new XText(value));
        }		
    	
        /// <summary>
        /// Called when a xml-format XmlElementEndTagSyntax node can be defoliated.
        /// </summary>
        /// <param name="node">node of interest.</param>
        public virtual void DefoliateXmlElementEndTag(XElement node)
    	{
    		var ignoreCore = false;
    		DefoliateXmlElementEndTagBefore(node, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.DefoliateXmlElementEndTagCore(node);
    		DefoliateXmlElementEndTagAfter(node);
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Defoliate(XElement)"/>.
        /// </summary>
        /// <param name="node">node of interest.</param>
        /// <param name="ignoreCore">If true, the <see cref="DefoliateCore(XElement)"/> is not executed and <see cref="Defoliate(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DefoliateXmlNameBefore(XElement node, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DefoliateCore(XElement)"/>.
        /// </summary>
        /// <param name="node">node of interest.</param>
        partial void DefoliateXmlNameAfter(XElement node);
    
    	/// <summary>
        /// Called when a xml-format XmlNameSyntax node can be defoliated.
        /// </summary>
        /// <param name="node">node of interest.</param>
        public virtual void DefoliateXmlNameCore(XElement node)
        {
    		var value = node.Value;
            node.RemoveNodes();
            node.Add(new XText(value));
        }		
    	
        /// <summary>
        /// Called when a xml-format XmlNameSyntax node can be defoliated.
        /// </summary>
        /// <param name="node">node of interest.</param>
        public virtual void DefoliateXmlName(XElement node)
    	{
    		var ignoreCore = false;
    		DefoliateXmlNameBefore(node, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.DefoliateXmlNameCore(node);
    		DefoliateXmlNameAfter(node);
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Defoliate(XElement)"/>.
        /// </summary>
        /// <param name="node">node of interest.</param>
        /// <param name="ignoreCore">If true, the <see cref="DefoliateCore(XElement)"/> is not executed and <see cref="Defoliate(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DefoliateXmlPrefixBefore(XElement node, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DefoliateCore(XElement)"/>.
        /// </summary>
        /// <param name="node">node of interest.</param>
        partial void DefoliateXmlPrefixAfter(XElement node);
    
    	/// <summary>
        /// Called when a xml-format XmlPrefixSyntax node can be defoliated.
        /// </summary>
        /// <param name="node">node of interest.</param>
        public virtual void DefoliateXmlPrefixCore(XElement node)
        {
    		var value = node.Value;
            node.RemoveNodes();
            node.Add(new XText(value));
        }		
    	
        /// <summary>
        /// Called when a xml-format XmlPrefixSyntax node can be defoliated.
        /// </summary>
        /// <param name="node">node of interest.</param>
        public virtual void DefoliateXmlPrefix(XElement node)
    	{
    		var ignoreCore = false;
    		DefoliateXmlPrefixBefore(node, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.DefoliateXmlPrefixCore(node);
    		DefoliateXmlPrefixAfter(node);
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Defoliate(XElement)"/>.
        /// </summary>
        /// <param name="node">node of interest.</param>
        /// <param name="ignoreCore">If true, the <see cref="DefoliateCore(XElement)"/> is not executed and <see cref="Defoliate(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DefoliateNameColonBefore(XElement node, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DefoliateCore(XElement)"/>.
        /// </summary>
        /// <param name="node">node of interest.</param>
        partial void DefoliateNameColonAfter(XElement node);
    
    	/// <summary>
        /// Called when a xml-format NameColonSyntax node can be defoliated.
        /// </summary>
        /// <param name="node">node of interest.</param>
        public virtual void DefoliateNameColonCore(XElement node)
        {
    		var value = node.Value;
            node.RemoveNodes();
            node.Add(new XText(value));
        }		
    	
        /// <summary>
        /// Called when a xml-format NameColonSyntax node can be defoliated.
        /// </summary>
        /// <param name="node">node of interest.</param>
        public virtual void DefoliateNameColon(XElement node)
    	{
    		var ignoreCore = false;
    		DefoliateNameColonBefore(node, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.DefoliateNameColonCore(node);
    		DefoliateNameColonAfter(node);
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Defoliate(XElement)"/>.
        /// </summary>
        /// <param name="node">node of interest.</param>
        /// <param name="ignoreCore">If true, the <see cref="DefoliateCore(XElement)"/> is not executed and <see cref="Defoliate(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DefoliateJoinIntoClauseBefore(XElement node, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DefoliateCore(XElement)"/>.
        /// </summary>
        /// <param name="node">node of interest.</param>
        partial void DefoliateJoinIntoClauseAfter(XElement node);
    
    	/// <summary>
        /// Called when a xml-format JoinIntoClauseSyntax node can be defoliated.
        /// </summary>
        /// <param name="node">node of interest.</param>
        public virtual void DefoliateJoinIntoClauseCore(XElement node)
        {
    		var value = node.Value;
            node.RemoveNodes();
            node.Add(new XText(value));
        }		
    	
        /// <summary>
        /// Called when a xml-format JoinIntoClauseSyntax node can be defoliated.
        /// </summary>
        /// <param name="node">node of interest.</param>
        public virtual void DefoliateJoinIntoClause(XElement node)
    	{
    		var ignoreCore = false;
    		DefoliateJoinIntoClauseBefore(node, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.DefoliateJoinIntoClauseCore(node);
    		DefoliateJoinIntoClauseAfter(node);
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Defoliate(XElement)"/>.
        /// </summary>
        /// <param name="node">node of interest.</param>
        /// <param name="ignoreCore">If true, the <see cref="DefoliateCore(XElement)"/> is not executed and <see cref="Defoliate(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DefoliateInterpolationFormatClauseBefore(XElement node, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DefoliateCore(XElement)"/>.
        /// </summary>
        /// <param name="node">node of interest.</param>
        partial void DefoliateInterpolationFormatClauseAfter(XElement node);
    
    	/// <summary>
        /// Called when a xml-format InterpolationFormatClauseSyntax node can be defoliated.
        /// </summary>
        /// <param name="node">node of interest.</param>
        public virtual void DefoliateInterpolationFormatClauseCore(XElement node)
        {
    		var value = node.Value;
            node.RemoveNodes();
            node.Add(new XText(value));
        }		
    	
        /// <summary>
        /// Called when a xml-format InterpolationFormatClauseSyntax node can be defoliated.
        /// </summary>
        /// <param name="node">node of interest.</param>
        public virtual void DefoliateInterpolationFormatClause(XElement node)
    	{
    		var ignoreCore = false;
    		DefoliateInterpolationFormatClauseBefore(node, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.DefoliateInterpolationFormatClauseCore(node);
    		DefoliateInterpolationFormatClauseAfter(node);
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Defoliate(XElement)"/>.
        /// </summary>
        /// <param name="node">node of interest.</param>
        /// <param name="ignoreCore">If true, the <see cref="DefoliateCore(XElement)"/> is not executed and <see cref="Defoliate(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DefoliateExternAliasDirectiveBefore(XElement node, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DefoliateCore(XElement)"/>.
        /// </summary>
        /// <param name="node">node of interest.</param>
        partial void DefoliateExternAliasDirectiveAfter(XElement node);
    
    	/// <summary>
        /// Called when a xml-format ExternAliasDirectiveSyntax node can be defoliated.
        /// </summary>
        /// <param name="node">node of interest.</param>
        public virtual void DefoliateExternAliasDirectiveCore(XElement node)
        {
    		var value = node.Value;
            node.RemoveNodes();
            node.Add(new XText(value));
        }		
    	
        /// <summary>
        /// Called when a xml-format ExternAliasDirectiveSyntax node can be defoliated.
        /// </summary>
        /// <param name="node">node of interest.</param>
        public virtual void DefoliateExternAliasDirective(XElement node)
    	{
    		var ignoreCore = false;
    		DefoliateExternAliasDirectiveBefore(node, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.DefoliateExternAliasDirectiveCore(node);
    		DefoliateExternAliasDirectiveAfter(node);
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Defoliate(XElement)"/>.
        /// </summary>
        /// <param name="node">node of interest.</param>
        /// <param name="ignoreCore">If true, the <see cref="DefoliateCore(XElement)"/> is not executed and <see cref="Defoliate(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DefoliateAttributeTargetSpecifierBefore(XElement node, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DefoliateCore(XElement)"/>.
        /// </summary>
        /// <param name="node">node of interest.</param>
        partial void DefoliateAttributeTargetSpecifierAfter(XElement node);
    
    	/// <summary>
        /// Called when a xml-format AttributeTargetSpecifierSyntax node can be defoliated.
        /// </summary>
        /// <param name="node">node of interest.</param>
        public virtual void DefoliateAttributeTargetSpecifierCore(XElement node)
        {
    		var value = node.Value;
            node.RemoveNodes();
            node.Add(new XText(value));
        }		
    	
        /// <summary>
        /// Called when a xml-format AttributeTargetSpecifierSyntax node can be defoliated.
        /// </summary>
        /// <param name="node">node of interest.</param>
        public virtual void DefoliateAttributeTargetSpecifier(XElement node)
    	{
    		var ignoreCore = false;
    		DefoliateAttributeTargetSpecifierBefore(node, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.DefoliateAttributeTargetSpecifierCore(node);
    		DefoliateAttributeTargetSpecifierAfter(node);
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Defoliate(XElement)"/>.
        /// </summary>
        /// <param name="node">node of interest.</param>
        /// <param name="ignoreCore">If true, the <see cref="DefoliateCore(XElement)"/> is not executed and <see cref="Defoliate(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DefoliateConstructorConstraintBefore(XElement node, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DefoliateCore(XElement)"/>.
        /// </summary>
        /// <param name="node">node of interest.</param>
        partial void DefoliateConstructorConstraintAfter(XElement node);
    
    	/// <summary>
        /// Called when a xml-format ConstructorConstraintSyntax node can be defoliated.
        /// </summary>
        /// <param name="node">node of interest.</param>
        public virtual void DefoliateConstructorConstraintCore(XElement node)
        {
    		var value = node.Value;
            node.RemoveNodes();
            node.Add(new XText(value));
        }		
    	
        /// <summary>
        /// Called when a xml-format ConstructorConstraintSyntax node can be defoliated.
        /// </summary>
        /// <param name="node">node of interest.</param>
        public virtual void DefoliateConstructorConstraint(XElement node)
    	{
    		var ignoreCore = false;
    		DefoliateConstructorConstraintBefore(node, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.DefoliateConstructorConstraintCore(node);
    		DefoliateConstructorConstraintAfter(node);
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Defoliate(XElement)"/>.
        /// </summary>
        /// <param name="node">node of interest.</param>
        /// <param name="ignoreCore">If true, the <see cref="DefoliateCore(XElement)"/> is not executed and <see cref="Defoliate(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DefoliateClassOrStructConstraintBefore(XElement node, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DefoliateCore(XElement)"/>.
        /// </summary>
        /// <param name="node">node of interest.</param>
        partial void DefoliateClassOrStructConstraintAfter(XElement node);
    
    	/// <summary>
        /// Called when a xml-format ClassOrStructConstraintSyntax node can be defoliated.
        /// </summary>
        /// <param name="node">node of interest.</param>
        public virtual void DefoliateClassOrStructConstraintCore(XElement node)
        {
    		var value = node.Value;
            node.RemoveNodes();
            node.Add(new XText(value));
        }		
    	
        /// <summary>
        /// Called when a xml-format ClassOrStructConstraintSyntax node can be defoliated.
        /// </summary>
        /// <param name="node">node of interest.</param>
        public virtual void DefoliateClassOrStructConstraint(XElement node)
    	{
    		var ignoreCore = false;
    		DefoliateClassOrStructConstraintBefore(node, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.DefoliateClassOrStructConstraintCore(node);
    		DefoliateClassOrStructConstraintAfter(node);
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Defoliate(XElement)"/>.
        /// </summary>
        /// <param name="node">node of interest.</param>
        /// <param name="ignoreCore">If true, the <see cref="DefoliateCore(XElement)"/> is not executed and <see cref="Defoliate(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DefoliateEndIfDirectiveTriviaBefore(XElement node, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DefoliateCore(XElement)"/>.
        /// </summary>
        /// <param name="node">node of interest.</param>
        partial void DefoliateEndIfDirectiveTriviaAfter(XElement node);
    
    	/// <summary>
        /// Called when a xml-format EndIfDirectiveTriviaSyntax node can be defoliated.
        /// </summary>
        /// <param name="node">node of interest.</param>
        public virtual void DefoliateEndIfDirectiveTriviaCore(XElement node)
        {
    		var value = node.Value;
            node.RemoveNodes();
            node.Add(new XText(value));
        }		
    	
        /// <summary>
        /// Called when a xml-format EndIfDirectiveTriviaSyntax node can be defoliated.
        /// </summary>
        /// <param name="node">node of interest.</param>
        public virtual void DefoliateEndIfDirectiveTrivia(XElement node)
    	{
    		var ignoreCore = false;
    		DefoliateEndIfDirectiveTriviaBefore(node, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.DefoliateEndIfDirectiveTriviaCore(node);
    		DefoliateEndIfDirectiveTriviaAfter(node);
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Defoliate(XElement)"/>.
        /// </summary>
        /// <param name="node">node of interest.</param>
        /// <param name="ignoreCore">If true, the <see cref="DefoliateCore(XElement)"/> is not executed and <see cref="Defoliate(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DefoliateRegionDirectiveTriviaBefore(XElement node, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DefoliateCore(XElement)"/>.
        /// </summary>
        /// <param name="node">node of interest.</param>
        partial void DefoliateRegionDirectiveTriviaAfter(XElement node);
    
    	/// <summary>
        /// Called when a xml-format RegionDirectiveTriviaSyntax node can be defoliated.
        /// </summary>
        /// <param name="node">node of interest.</param>
        public virtual void DefoliateRegionDirectiveTriviaCore(XElement node)
        {
    		var value = node.Value;
            node.RemoveNodes();
            node.Add(new XText(value));
        }		
    	
        /// <summary>
        /// Called when a xml-format RegionDirectiveTriviaSyntax node can be defoliated.
        /// </summary>
        /// <param name="node">node of interest.</param>
        public virtual void DefoliateRegionDirectiveTrivia(XElement node)
    	{
    		var ignoreCore = false;
    		DefoliateRegionDirectiveTriviaBefore(node, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.DefoliateRegionDirectiveTriviaCore(node);
    		DefoliateRegionDirectiveTriviaAfter(node);
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Defoliate(XElement)"/>.
        /// </summary>
        /// <param name="node">node of interest.</param>
        /// <param name="ignoreCore">If true, the <see cref="DefoliateCore(XElement)"/> is not executed and <see cref="Defoliate(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DefoliateEndRegionDirectiveTriviaBefore(XElement node, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DefoliateCore(XElement)"/>.
        /// </summary>
        /// <param name="node">node of interest.</param>
        partial void DefoliateEndRegionDirectiveTriviaAfter(XElement node);
    
    	/// <summary>
        /// Called when a xml-format EndRegionDirectiveTriviaSyntax node can be defoliated.
        /// </summary>
        /// <param name="node">node of interest.</param>
        public virtual void DefoliateEndRegionDirectiveTriviaCore(XElement node)
        {
    		var value = node.Value;
            node.RemoveNodes();
            node.Add(new XText(value));
        }		
    	
        /// <summary>
        /// Called when a xml-format EndRegionDirectiveTriviaSyntax node can be defoliated.
        /// </summary>
        /// <param name="node">node of interest.</param>
        public virtual void DefoliateEndRegionDirectiveTrivia(XElement node)
    	{
    		var ignoreCore = false;
    		DefoliateEndRegionDirectiveTriviaBefore(node, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.DefoliateEndRegionDirectiveTriviaCore(node);
    		DefoliateEndRegionDirectiveTriviaAfter(node);
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Defoliate(XElement)"/>.
        /// </summary>
        /// <param name="node">node of interest.</param>
        /// <param name="ignoreCore">If true, the <see cref="DefoliateCore(XElement)"/> is not executed and <see cref="Defoliate(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DefoliateErrorDirectiveTriviaBefore(XElement node, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DefoliateCore(XElement)"/>.
        /// </summary>
        /// <param name="node">node of interest.</param>
        partial void DefoliateErrorDirectiveTriviaAfter(XElement node);
    
    	/// <summary>
        /// Called when a xml-format ErrorDirectiveTriviaSyntax node can be defoliated.
        /// </summary>
        /// <param name="node">node of interest.</param>
        public virtual void DefoliateErrorDirectiveTriviaCore(XElement node)
        {
    		var value = node.Value;
            node.RemoveNodes();
            node.Add(new XText(value));
        }		
    	
        /// <summary>
        /// Called when a xml-format ErrorDirectiveTriviaSyntax node can be defoliated.
        /// </summary>
        /// <param name="node">node of interest.</param>
        public virtual void DefoliateErrorDirectiveTrivia(XElement node)
    	{
    		var ignoreCore = false;
    		DefoliateErrorDirectiveTriviaBefore(node, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.DefoliateErrorDirectiveTriviaCore(node);
    		DefoliateErrorDirectiveTriviaAfter(node);
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Defoliate(XElement)"/>.
        /// </summary>
        /// <param name="node">node of interest.</param>
        /// <param name="ignoreCore">If true, the <see cref="DefoliateCore(XElement)"/> is not executed and <see cref="Defoliate(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DefoliateWarningDirectiveTriviaBefore(XElement node, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DefoliateCore(XElement)"/>.
        /// </summary>
        /// <param name="node">node of interest.</param>
        partial void DefoliateWarningDirectiveTriviaAfter(XElement node);
    
    	/// <summary>
        /// Called when a xml-format WarningDirectiveTriviaSyntax node can be defoliated.
        /// </summary>
        /// <param name="node">node of interest.</param>
        public virtual void DefoliateWarningDirectiveTriviaCore(XElement node)
        {
    		var value = node.Value;
            node.RemoveNodes();
            node.Add(new XText(value));
        }		
    	
        /// <summary>
        /// Called when a xml-format WarningDirectiveTriviaSyntax node can be defoliated.
        /// </summary>
        /// <param name="node">node of interest.</param>
        public virtual void DefoliateWarningDirectiveTrivia(XElement node)
    	{
    		var ignoreCore = false;
    		DefoliateWarningDirectiveTriviaBefore(node, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.DefoliateWarningDirectiveTriviaCore(node);
    		DefoliateWarningDirectiveTriviaAfter(node);
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Defoliate(XElement)"/>.
        /// </summary>
        /// <param name="node">node of interest.</param>
        /// <param name="ignoreCore">If true, the <see cref="DefoliateCore(XElement)"/> is not executed and <see cref="Defoliate(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DefoliateBadDirectiveTriviaBefore(XElement node, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DefoliateCore(XElement)"/>.
        /// </summary>
        /// <param name="node">node of interest.</param>
        partial void DefoliateBadDirectiveTriviaAfter(XElement node);
    
    	/// <summary>
        /// Called when a xml-format BadDirectiveTriviaSyntax node can be defoliated.
        /// </summary>
        /// <param name="node">node of interest.</param>
        public virtual void DefoliateBadDirectiveTriviaCore(XElement node)
        {
    		var value = node.Value;
            node.RemoveNodes();
            node.Add(new XText(value));
        }		
    	
        /// <summary>
        /// Called when a xml-format BadDirectiveTriviaSyntax node can be defoliated.
        /// </summary>
        /// <param name="node">node of interest.</param>
        public virtual void DefoliateBadDirectiveTrivia(XElement node)
    	{
    		var ignoreCore = false;
    		DefoliateBadDirectiveTriviaBefore(node, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.DefoliateBadDirectiveTriviaCore(node);
    		DefoliateBadDirectiveTriviaAfter(node);
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Defoliate(XElement)"/>.
        /// </summary>
        /// <param name="node">node of interest.</param>
        /// <param name="ignoreCore">If true, the <see cref="DefoliateCore(XElement)"/> is not executed and <see cref="Defoliate(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DefoliateDefineDirectiveTriviaBefore(XElement node, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DefoliateCore(XElement)"/>.
        /// </summary>
        /// <param name="node">node of interest.</param>
        partial void DefoliateDefineDirectiveTriviaAfter(XElement node);
    
    	/// <summary>
        /// Called when a xml-format DefineDirectiveTriviaSyntax node can be defoliated.
        /// </summary>
        /// <param name="node">node of interest.</param>
        public virtual void DefoliateDefineDirectiveTriviaCore(XElement node)
        {
    		var value = node.Value;
            node.RemoveNodes();
            node.Add(new XText(value));
        }		
    	
        /// <summary>
        /// Called when a xml-format DefineDirectiveTriviaSyntax node can be defoliated.
        /// </summary>
        /// <param name="node">node of interest.</param>
        public virtual void DefoliateDefineDirectiveTrivia(XElement node)
    	{
    		var ignoreCore = false;
    		DefoliateDefineDirectiveTriviaBefore(node, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.DefoliateDefineDirectiveTriviaCore(node);
    		DefoliateDefineDirectiveTriviaAfter(node);
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Defoliate(XElement)"/>.
        /// </summary>
        /// <param name="node">node of interest.</param>
        /// <param name="ignoreCore">If true, the <see cref="DefoliateCore(XElement)"/> is not executed and <see cref="Defoliate(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DefoliateUndefDirectiveTriviaBefore(XElement node, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DefoliateCore(XElement)"/>.
        /// </summary>
        /// <param name="node">node of interest.</param>
        partial void DefoliateUndefDirectiveTriviaAfter(XElement node);
    
    	/// <summary>
        /// Called when a xml-format UndefDirectiveTriviaSyntax node can be defoliated.
        /// </summary>
        /// <param name="node">node of interest.</param>
        public virtual void DefoliateUndefDirectiveTriviaCore(XElement node)
        {
    		var value = node.Value;
            node.RemoveNodes();
            node.Add(new XText(value));
        }		
    	
        /// <summary>
        /// Called when a xml-format UndefDirectiveTriviaSyntax node can be defoliated.
        /// </summary>
        /// <param name="node">node of interest.</param>
        public virtual void DefoliateUndefDirectiveTrivia(XElement node)
    	{
    		var ignoreCore = false;
    		DefoliateUndefDirectiveTriviaBefore(node, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.DefoliateUndefDirectiveTriviaCore(node);
    		DefoliateUndefDirectiveTriviaAfter(node);
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Defoliate(XElement)"/>.
        /// </summary>
        /// <param name="node">node of interest.</param>
        /// <param name="ignoreCore">If true, the <see cref="DefoliateCore(XElement)"/> is not executed and <see cref="Defoliate(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DefoliateLineDirectiveTriviaBefore(XElement node, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DefoliateCore(XElement)"/>.
        /// </summary>
        /// <param name="node">node of interest.</param>
        partial void DefoliateLineDirectiveTriviaAfter(XElement node);
    
    	/// <summary>
        /// Called when a xml-format LineDirectiveTriviaSyntax node can be defoliated.
        /// </summary>
        /// <param name="node">node of interest.</param>
        public virtual void DefoliateLineDirectiveTriviaCore(XElement node)
        {
    		var value = node.Value;
            node.RemoveNodes();
            node.Add(new XText(value));
        }		
    	
        /// <summary>
        /// Called when a xml-format LineDirectiveTriviaSyntax node can be defoliated.
        /// </summary>
        /// <param name="node">node of interest.</param>
        public virtual void DefoliateLineDirectiveTrivia(XElement node)
    	{
    		var ignoreCore = false;
    		DefoliateLineDirectiveTriviaBefore(node, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.DefoliateLineDirectiveTriviaCore(node);
    		DefoliateLineDirectiveTriviaAfter(node);
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Defoliate(XElement)"/>.
        /// </summary>
        /// <param name="node">node of interest.</param>
        /// <param name="ignoreCore">If true, the <see cref="DefoliateCore(XElement)"/> is not executed and <see cref="Defoliate(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DefoliatePragmaChecksumDirectiveTriviaBefore(XElement node, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DefoliateCore(XElement)"/>.
        /// </summary>
        /// <param name="node">node of interest.</param>
        partial void DefoliatePragmaChecksumDirectiveTriviaAfter(XElement node);
    
    	/// <summary>
        /// Called when a xml-format PragmaChecksumDirectiveTriviaSyntax node can be defoliated.
        /// </summary>
        /// <param name="node">node of interest.</param>
        public virtual void DefoliatePragmaChecksumDirectiveTriviaCore(XElement node)
        {
    		var value = node.Value;
            node.RemoveNodes();
            node.Add(new XText(value));
        }		
    	
        /// <summary>
        /// Called when a xml-format PragmaChecksumDirectiveTriviaSyntax node can be defoliated.
        /// </summary>
        /// <param name="node">node of interest.</param>
        public virtual void DefoliatePragmaChecksumDirectiveTrivia(XElement node)
    	{
    		var ignoreCore = false;
    		DefoliatePragmaChecksumDirectiveTriviaBefore(node, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.DefoliatePragmaChecksumDirectiveTriviaCore(node);
    		DefoliatePragmaChecksumDirectiveTriviaAfter(node);
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Defoliate(XElement)"/>.
        /// </summary>
        /// <param name="node">node of interest.</param>
        /// <param name="ignoreCore">If true, the <see cref="DefoliateCore(XElement)"/> is not executed and <see cref="Defoliate(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DefoliateReferenceDirectiveTriviaBefore(XElement node, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DefoliateCore(XElement)"/>.
        /// </summary>
        /// <param name="node">node of interest.</param>
        partial void DefoliateReferenceDirectiveTriviaAfter(XElement node);
    
    	/// <summary>
        /// Called when a xml-format ReferenceDirectiveTriviaSyntax node can be defoliated.
        /// </summary>
        /// <param name="node">node of interest.</param>
        public virtual void DefoliateReferenceDirectiveTriviaCore(XElement node)
        {
    		var value = node.Value;
            node.RemoveNodes();
            node.Add(new XText(value));
        }		
    	
        /// <summary>
        /// Called when a xml-format ReferenceDirectiveTriviaSyntax node can be defoliated.
        /// </summary>
        /// <param name="node">node of interest.</param>
        public virtual void DefoliateReferenceDirectiveTrivia(XElement node)
    	{
    		var ignoreCore = false;
    		DefoliateReferenceDirectiveTriviaBefore(node, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.DefoliateReferenceDirectiveTriviaCore(node);
    		DefoliateReferenceDirectiveTriviaAfter(node);
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Defoliate(XElement)"/>.
        /// </summary>
        /// <param name="node">node of interest.</param>
        /// <param name="ignoreCore">If true, the <see cref="DefoliateCore(XElement)"/> is not executed and <see cref="Defoliate(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DefoliateLoadDirectiveTriviaBefore(XElement node, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DefoliateCore(XElement)"/>.
        /// </summary>
        /// <param name="node">node of interest.</param>
        partial void DefoliateLoadDirectiveTriviaAfter(XElement node);
    
    	/// <summary>
        /// Called when a xml-format LoadDirectiveTriviaSyntax node can be defoliated.
        /// </summary>
        /// <param name="node">node of interest.</param>
        public virtual void DefoliateLoadDirectiveTriviaCore(XElement node)
        {
    		var value = node.Value;
            node.RemoveNodes();
            node.Add(new XText(value));
        }		
    	
        /// <summary>
        /// Called when a xml-format LoadDirectiveTriviaSyntax node can be defoliated.
        /// </summary>
        /// <param name="node">node of interest.</param>
        public virtual void DefoliateLoadDirectiveTrivia(XElement node)
    	{
    		var ignoreCore = false;
    		DefoliateLoadDirectiveTriviaBefore(node, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.DefoliateLoadDirectiveTriviaCore(node);
    		DefoliateLoadDirectiveTriviaAfter(node);
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Defoliate(XElement)"/>.
        /// </summary>
        /// <param name="node">node of interest.</param>
        /// <param name="ignoreCore">If true, the <see cref="DefoliateCore(XElement)"/> is not executed and <see cref="Defoliate(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DefoliateShebangDirectiveTriviaBefore(XElement node, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DefoliateCore(XElement)"/>.
        /// </summary>
        /// <param name="node">node of interest.</param>
        partial void DefoliateShebangDirectiveTriviaAfter(XElement node);
    
    	/// <summary>
        /// Called when a xml-format ShebangDirectiveTriviaSyntax node can be defoliated.
        /// </summary>
        /// <param name="node">node of interest.</param>
        public virtual void DefoliateShebangDirectiveTriviaCore(XElement node)
        {
    		var value = node.Value;
            node.RemoveNodes();
            node.Add(new XText(value));
        }		
    	
        /// <summary>
        /// Called when a xml-format ShebangDirectiveTriviaSyntax node can be defoliated.
        /// </summary>
        /// <param name="node">node of interest.</param>
        public virtual void DefoliateShebangDirectiveTrivia(XElement node)
    	{
    		var ignoreCore = false;
    		DefoliateShebangDirectiveTriviaBefore(node, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.DefoliateShebangDirectiveTriviaCore(node);
    		DefoliateShebangDirectiveTriviaAfter(node);
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Defoliate(XElement)"/>.
        /// </summary>
        /// <param name="node">node of interest.</param>
        /// <param name="ignoreCore">If true, the <see cref="DefoliateCore(XElement)"/> is not executed and <see cref="Defoliate(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DefoliateElseDirectiveTriviaBefore(XElement node, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DefoliateCore(XElement)"/>.
        /// </summary>
        /// <param name="node">node of interest.</param>
        partial void DefoliateElseDirectiveTriviaAfter(XElement node);
    
    	/// <summary>
        /// Called when a xml-format ElseDirectiveTriviaSyntax node can be defoliated.
        /// </summary>
        /// <param name="node">node of interest.</param>
        public virtual void DefoliateElseDirectiveTriviaCore(XElement node)
        {
    		var value = node.Value;
            node.RemoveNodes();
            node.Add(new XText(value));
        }		
    	
        /// <summary>
        /// Called when a xml-format ElseDirectiveTriviaSyntax node can be defoliated.
        /// </summary>
        /// <param name="node">node of interest.</param>
        public virtual void DefoliateElseDirectiveTrivia(XElement node)
    	{
    		var ignoreCore = false;
    		DefoliateElseDirectiveTriviaBefore(node, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.DefoliateElseDirectiveTriviaCore(node);
    		DefoliateElseDirectiveTriviaAfter(node);
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Defoliate(XElement)"/>.
        /// </summary>
        /// <param name="node">node of interest.</param>
        /// <param name="ignoreCore">If true, the <see cref="DefoliateCore(XElement)"/> is not executed and <see cref="Defoliate(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DefoliateXmlNameAttributeBefore(XElement node, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DefoliateCore(XElement)"/>.
        /// </summary>
        /// <param name="node">node of interest.</param>
        partial void DefoliateXmlNameAttributeAfter(XElement node);
    
    	/// <summary>
        /// Called when a xml-format XmlNameAttributeSyntax node can be defoliated.
        /// </summary>
        /// <param name="node">node of interest.</param>
        public virtual void DefoliateXmlNameAttributeCore(XElement node)
        {
    		var value = node.Value;
            node.RemoveNodes();
            node.Add(new XText(value));
        }		
    	
        /// <summary>
        /// Called when a xml-format XmlNameAttributeSyntax node can be defoliated.
        /// </summary>
        /// <param name="node">node of interest.</param>
        public virtual void DefoliateXmlNameAttribute(XElement node)
    	{
    		var ignoreCore = false;
    		DefoliateXmlNameAttributeBefore(node, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.DefoliateXmlNameAttributeCore(node);
    		DefoliateXmlNameAttributeAfter(node);
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Defoliate(XElement)"/>.
        /// </summary>
        /// <param name="node">node of interest.</param>
        /// <param name="ignoreCore">If true, the <see cref="DefoliateCore(XElement)"/> is not executed and <see cref="Defoliate(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DefoliateLiteralExpressionBefore(XElement node, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DefoliateCore(XElement)"/>.
        /// </summary>
        /// <param name="node">node of interest.</param>
        partial void DefoliateLiteralExpressionAfter(XElement node);
    
    	/// <summary>
        /// Called when a xml-format LiteralExpressionSyntax node can be defoliated.
        /// </summary>
        /// <param name="node">node of interest.</param>
        public virtual void DefoliateLiteralExpressionCore(XElement node)
        {
    		var value = node.Value;
            node.RemoveNodes();
            node.Add(new XText(value));
        }		
    	
        /// <summary>
        /// Called when a xml-format LiteralExpressionSyntax node can be defoliated.
        /// </summary>
        /// <param name="node">node of interest.</param>
        public virtual void DefoliateLiteralExpression(XElement node)
    	{
    		var ignoreCore = false;
    		DefoliateLiteralExpressionBefore(node, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.DefoliateLiteralExpressionCore(node);
    		DefoliateLiteralExpressionAfter(node);
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Defoliate(XElement)"/>.
        /// </summary>
        /// <param name="node">node of interest.</param>
        /// <param name="ignoreCore">If true, the <see cref="DefoliateCore(XElement)"/> is not executed and <see cref="Defoliate(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DefoliateOmittedArraySizeExpressionBefore(XElement node, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DefoliateCore(XElement)"/>.
        /// </summary>
        /// <param name="node">node of interest.</param>
        partial void DefoliateOmittedArraySizeExpressionAfter(XElement node);
    
    	/// <summary>
        /// Called when a xml-format OmittedArraySizeExpressionSyntax node can be defoliated.
        /// </summary>
        /// <param name="node">node of interest.</param>
        public virtual void DefoliateOmittedArraySizeExpressionCore(XElement node)
        {
    		var value = node.Value;
            node.RemoveNodes();
            node.Add(new XText(value));
        }		
    	
        /// <summary>
        /// Called when a xml-format OmittedArraySizeExpressionSyntax node can be defoliated.
        /// </summary>
        /// <param name="node">node of interest.</param>
        public virtual void DefoliateOmittedArraySizeExpression(XElement node)
    	{
    		var ignoreCore = false;
    		DefoliateOmittedArraySizeExpressionBefore(node, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.DefoliateOmittedArraySizeExpressionCore(node);
    		DefoliateOmittedArraySizeExpressionAfter(node);
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Defoliate(XElement)"/>.
        /// </summary>
        /// <param name="node">node of interest.</param>
        /// <param name="ignoreCore">If true, the <see cref="DefoliateCore(XElement)"/> is not executed and <see cref="Defoliate(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DefoliatePredefinedTypeBefore(XElement node, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DefoliateCore(XElement)"/>.
        /// </summary>
        /// <param name="node">node of interest.</param>
        partial void DefoliatePredefinedTypeAfter(XElement node);
    
    	/// <summary>
        /// Called when a xml-format PredefinedTypeSyntax node can be defoliated.
        /// </summary>
        /// <param name="node">node of interest.</param>
        public virtual void DefoliatePredefinedTypeCore(XElement node)
        {
    		var value = node.Value;
            node.RemoveNodes();
            node.Add(new XText(value));
        }		
    	
        /// <summary>
        /// Called when a xml-format PredefinedTypeSyntax node can be defoliated.
        /// </summary>
        /// <param name="node">node of interest.</param>
        public virtual void DefoliatePredefinedType(XElement node)
    	{
    		var ignoreCore = false;
    		DefoliatePredefinedTypeBefore(node, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.DefoliatePredefinedTypeCore(node);
    		DefoliatePredefinedTypeAfter(node);
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Defoliate(XElement)"/>.
        /// </summary>
        /// <param name="node">node of interest.</param>
        /// <param name="ignoreCore">If true, the <see cref="DefoliateCore(XElement)"/> is not executed and <see cref="Defoliate(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DefoliateOmittedTypeArgumentBefore(XElement node, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DefoliateCore(XElement)"/>.
        /// </summary>
        /// <param name="node">node of interest.</param>
        partial void DefoliateOmittedTypeArgumentAfter(XElement node);
    
    	/// <summary>
        /// Called when a xml-format OmittedTypeArgumentSyntax node can be defoliated.
        /// </summary>
        /// <param name="node">node of interest.</param>
        public virtual void DefoliateOmittedTypeArgumentCore(XElement node)
        {
    		var value = node.Value;
            node.RemoveNodes();
            node.Add(new XText(value));
        }		
    	
        /// <summary>
        /// Called when a xml-format OmittedTypeArgumentSyntax node can be defoliated.
        /// </summary>
        /// <param name="node">node of interest.</param>
        public virtual void DefoliateOmittedTypeArgument(XElement node)
    	{
    		var ignoreCore = false;
    		DefoliateOmittedTypeArgumentBefore(node, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.DefoliateOmittedTypeArgumentCore(node);
    		DefoliateOmittedTypeArgumentAfter(node);
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Defoliate(XElement)"/>.
        /// </summary>
        /// <param name="node">node of interest.</param>
        /// <param name="ignoreCore">If true, the <see cref="DefoliateCore(XElement)"/> is not executed and <see cref="Defoliate(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DefoliateIdentifierNameBefore(XElement node, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DefoliateCore(XElement)"/>.
        /// </summary>
        /// <param name="node">node of interest.</param>
        partial void DefoliateIdentifierNameAfter(XElement node);
    
    	/// <summary>
        /// Called when a xml-format IdentifierNameSyntax node can be defoliated.
        /// </summary>
        /// <param name="node">node of interest.</param>
        public virtual void DefoliateIdentifierNameCore(XElement node)
        {
    		var value = node.Value;
            node.RemoveNodes();
            node.Add(new XText(value));
        }		
    	
        /// <summary>
        /// Called when a xml-format IdentifierNameSyntax node can be defoliated.
        /// </summary>
        /// <param name="node">node of interest.</param>
        public virtual void DefoliateIdentifierName(XElement node)
    	{
    		var ignoreCore = false;
    		DefoliateIdentifierNameBefore(node, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.DefoliateIdentifierNameCore(node);
    		DefoliateIdentifierNameAfter(node);
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Defoliate(XElement)"/>.
        /// </summary>
        /// <param name="node">node of interest.</param>
        /// <param name="ignoreCore">If true, the <see cref="DefoliateCore(XElement)"/> is not executed and <see cref="Defoliate(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DefoliateThisExpressionBefore(XElement node, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DefoliateCore(XElement)"/>.
        /// </summary>
        /// <param name="node">node of interest.</param>
        partial void DefoliateThisExpressionAfter(XElement node);
    
    	/// <summary>
        /// Called when a xml-format ThisExpressionSyntax node can be defoliated.
        /// </summary>
        /// <param name="node">node of interest.</param>
        public virtual void DefoliateThisExpressionCore(XElement node)
        {
    		var value = node.Value;
            node.RemoveNodes();
            node.Add(new XText(value));
        }		
    	
        /// <summary>
        /// Called when a xml-format ThisExpressionSyntax node can be defoliated.
        /// </summary>
        /// <param name="node">node of interest.</param>
        public virtual void DefoliateThisExpression(XElement node)
    	{
    		var ignoreCore = false;
    		DefoliateThisExpressionBefore(node, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.DefoliateThisExpressionCore(node);
    		DefoliateThisExpressionAfter(node);
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Defoliate(XElement)"/>.
        /// </summary>
        /// <param name="node">node of interest.</param>
        /// <param name="ignoreCore">If true, the <see cref="DefoliateCore(XElement)"/> is not executed and <see cref="Defoliate(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DefoliateBaseExpressionBefore(XElement node, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DefoliateCore(XElement)"/>.
        /// </summary>
        /// <param name="node">node of interest.</param>
        partial void DefoliateBaseExpressionAfter(XElement node);
    
    	/// <summary>
        /// Called when a xml-format BaseExpressionSyntax node can be defoliated.
        /// </summary>
        /// <param name="node">node of interest.</param>
        public virtual void DefoliateBaseExpressionCore(XElement node)
        {
    		var value = node.Value;
            node.RemoveNodes();
            node.Add(new XText(value));
        }		
    	
        /// <summary>
        /// Called when a xml-format BaseExpressionSyntax node can be defoliated.
        /// </summary>
        /// <param name="node">node of interest.</param>
        public virtual void DefoliateBaseExpression(XElement node)
    	{
    		var ignoreCore = false;
    		DefoliateBaseExpressionBefore(node, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.DefoliateBaseExpressionCore(node);
    		DefoliateBaseExpressionAfter(node);
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Defoliate(XElement)"/>.
        /// </summary>
        /// <param name="node">node of interest.</param>
        /// <param name="ignoreCore">If true, the <see cref="DefoliateCore(XElement)"/> is not executed and <see cref="Defoliate(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DefoliateInterpolatedStringTextBefore(XElement node, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DefoliateCore(XElement)"/>.
        /// </summary>
        /// <param name="node">node of interest.</param>
        partial void DefoliateInterpolatedStringTextAfter(XElement node);
    
    	/// <summary>
        /// Called when a xml-format InterpolatedStringTextSyntax node can be defoliated.
        /// </summary>
        /// <param name="node">node of interest.</param>
        public virtual void DefoliateInterpolatedStringTextCore(XElement node)
        {
    		var value = node.Value;
            node.RemoveNodes();
            node.Add(new XText(value));
        }		
    	
        /// <summary>
        /// Called when a xml-format InterpolatedStringTextSyntax node can be defoliated.
        /// </summary>
        /// <param name="node">node of interest.</param>
        public virtual void DefoliateInterpolatedStringText(XElement node)
    	{
    		var ignoreCore = false;
    		DefoliateInterpolatedStringTextBefore(node, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.DefoliateInterpolatedStringTextCore(node);
    		DefoliateInterpolatedStringTextAfter(node);
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Defoliate(XElement)"/>.
        /// </summary>
        /// <param name="node">node of interest.</param>
        /// <param name="ignoreCore">If true, the <see cref="DefoliateCore(XElement)"/> is not executed and <see cref="Defoliate(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DefoliateEmptyStatementBefore(XElement node, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DefoliateCore(XElement)"/>.
        /// </summary>
        /// <param name="node">node of interest.</param>
        partial void DefoliateEmptyStatementAfter(XElement node);
    
    	/// <summary>
        /// Called when a xml-format EmptyStatementSyntax node can be defoliated.
        /// </summary>
        /// <param name="node">node of interest.</param>
        public virtual void DefoliateEmptyStatementCore(XElement node)
        {
    		var value = node.Value;
            node.RemoveNodes();
            node.Add(new XText(value));
        }		
    	
        /// <summary>
        /// Called when a xml-format EmptyStatementSyntax node can be defoliated.
        /// </summary>
        /// <param name="node">node of interest.</param>
        public virtual void DefoliateEmptyStatement(XElement node)
    	{
    		var ignoreCore = false;
    		DefoliateEmptyStatementBefore(node, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.DefoliateEmptyStatementCore(node);
    		DefoliateEmptyStatementAfter(node);
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Defoliate(XElement)"/>.
        /// </summary>
        /// <param name="node">node of interest.</param>
        /// <param name="ignoreCore">If true, the <see cref="DefoliateCore(XElement)"/> is not executed and <see cref="Defoliate(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DefoliateBreakStatementBefore(XElement node, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DefoliateCore(XElement)"/>.
        /// </summary>
        /// <param name="node">node of interest.</param>
        partial void DefoliateBreakStatementAfter(XElement node);
    
    	/// <summary>
        /// Called when a xml-format BreakStatementSyntax node can be defoliated.
        /// </summary>
        /// <param name="node">node of interest.</param>
        public virtual void DefoliateBreakStatementCore(XElement node)
        {
    		var value = node.Value;
            node.RemoveNodes();
            node.Add(new XText(value));
        }		
    	
        /// <summary>
        /// Called when a xml-format BreakStatementSyntax node can be defoliated.
        /// </summary>
        /// <param name="node">node of interest.</param>
        public virtual void DefoliateBreakStatement(XElement node)
    	{
    		var ignoreCore = false;
    		DefoliateBreakStatementBefore(node, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.DefoliateBreakStatementCore(node);
    		DefoliateBreakStatementAfter(node);
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Defoliate(XElement)"/>.
        /// </summary>
        /// <param name="node">node of interest.</param>
        /// <param name="ignoreCore">If true, the <see cref="DefoliateCore(XElement)"/> is not executed and <see cref="Defoliate(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DefoliateContinueStatementBefore(XElement node, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DefoliateCore(XElement)"/>.
        /// </summary>
        /// <param name="node">node of interest.</param>
        partial void DefoliateContinueStatementAfter(XElement node);
    
    	/// <summary>
        /// Called when a xml-format ContinueStatementSyntax node can be defoliated.
        /// </summary>
        /// <param name="node">node of interest.</param>
        public virtual void DefoliateContinueStatementCore(XElement node)
        {
    		var value = node.Value;
            node.RemoveNodes();
            node.Add(new XText(value));
        }		
    	
        /// <summary>
        /// Called when a xml-format ContinueStatementSyntax node can be defoliated.
        /// </summary>
        /// <param name="node">node of interest.</param>
        public virtual void DefoliateContinueStatement(XElement node)
    	{
    		var ignoreCore = false;
    		DefoliateContinueStatementBefore(node, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.DefoliateContinueStatementCore(node);
    		DefoliateContinueStatementAfter(node);
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Defoliate(XElement)"/>.
        /// </summary>
        /// <param name="node">node of interest.</param>
        /// <param name="ignoreCore">If true, the <see cref="DefoliateCore(XElement)"/> is not executed and <see cref="Defoliate(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DefoliateSingleVariableDesignationBefore(XElement node, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DefoliateCore(XElement)"/>.
        /// </summary>
        /// <param name="node">node of interest.</param>
        partial void DefoliateSingleVariableDesignationAfter(XElement node);
    
    	/// <summary>
        /// Called when a xml-format SingleVariableDesignationSyntax node can be defoliated.
        /// </summary>
        /// <param name="node">node of interest.</param>
        public virtual void DefoliateSingleVariableDesignationCore(XElement node)
        {
    		var value = node.Value;
            node.RemoveNodes();
            node.Add(new XText(value));
        }		
    	
        /// <summary>
        /// Called when a xml-format SingleVariableDesignationSyntax node can be defoliated.
        /// </summary>
        /// <param name="node">node of interest.</param>
        public virtual void DefoliateSingleVariableDesignation(XElement node)
    	{
    		var ignoreCore = false;
    		DefoliateSingleVariableDesignationBefore(node, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.DefoliateSingleVariableDesignationCore(node);
    		DefoliateSingleVariableDesignationAfter(node);
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Defoliate(XElement)"/>.
        /// </summary>
        /// <param name="node">node of interest.</param>
        /// <param name="ignoreCore">If true, the <see cref="DefoliateCore(XElement)"/> is not executed and <see cref="Defoliate(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DefoliateDiscardDesignationBefore(XElement node, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DefoliateCore(XElement)"/>.
        /// </summary>
        /// <param name="node">node of interest.</param>
        partial void DefoliateDiscardDesignationAfter(XElement node);
    
    	/// <summary>
        /// Called when a xml-format DiscardDesignationSyntax node can be defoliated.
        /// </summary>
        /// <param name="node">node of interest.</param>
        public virtual void DefoliateDiscardDesignationCore(XElement node)
        {
    		var value = node.Value;
            node.RemoveNodes();
            node.Add(new XText(value));
        }		
    	
        /// <summary>
        /// Called when a xml-format DiscardDesignationSyntax node can be defoliated.
        /// </summary>
        /// <param name="node">node of interest.</param>
        public virtual void DefoliateDiscardDesignation(XElement node)
    	{
    		var ignoreCore = false;
    		DefoliateDiscardDesignationBefore(node, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.DefoliateDiscardDesignationCore(node);
    		DefoliateDiscardDesignationAfter(node);
    	}
    
    	/// <summary>
        /// Method hook for implementing logic to execute before the <see cref="Defoliate(XElement)"/>.
        /// </summary>
        /// <param name="node">node of interest.</param>
        /// <param name="ignoreCore">If true, the <see cref="DefoliateCore(XElement)"/> is not executed and <see cref="Defoliate(XElement)"/> returns the current value of <paramref name="result"/>.</param>
        partial void DefoliateDefaultSwitchLabelBefore(XElement node, ref bool ignoreCore);
        
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="DefoliateCore(XElement)"/>.
        /// </summary>
        /// <param name="node">node of interest.</param>
        partial void DefoliateDefaultSwitchLabelAfter(XElement node);
    
    	/// <summary>
        /// Called when a xml-format DefaultSwitchLabelSyntax node can be defoliated.
        /// </summary>
        /// <param name="node">node of interest.</param>
        public virtual void DefoliateDefaultSwitchLabelCore(XElement node)
        {
    		var value = node.Value;
            node.RemoveNodes();
            node.Add(new XText(value));
        }		
    	
        /// <summary>
        /// Called when a xml-format DefaultSwitchLabelSyntax node can be defoliated.
        /// </summary>
        /// <param name="node">node of interest.</param>
        public virtual void DefoliateDefaultSwitchLabel(XElement node)
    	{
    		var ignoreCore = false;
    		DefoliateDefaultSwitchLabelBefore(node, ref ignoreCore);
    		if(ignoreCore) 
    			return;
    		
    		this.DefoliateDefaultSwitchLabelCore(node);
    		DefoliateDefaultSwitchLabelAfter(node);
    	}
    
    }
}
// Generated helper templates
// Generated items
