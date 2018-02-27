
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Jawilliam.CDF.CSharp.RoslynML
{
    public partial class RoslynML : CSharpSyntaxVisitor<XElement>
    {
    	private static bool IsOperator(SyntaxKind kind)
        {
            switch (kind)
            {
                case SyntaxKind.TildeToken:
                case SyntaxKind.ExclamationToken:
                case SyntaxKind.PercentToken:
                case SyntaxKind.CaretToken:
                case SyntaxKind.AmpersandToken:
                case SyntaxKind.AsteriskToken:
                case SyntaxKind.MinusToken:
                case SyntaxKind.PlusToken:
                case SyntaxKind.EqualsToken:
                case SyntaxKind.BarToken:
                case SyntaxKind.ColonToken:
                case SyntaxKind.LessThanToken:
                case SyntaxKind.GreaterThanToken:
                case SyntaxKind.DotToken:
                case SyntaxKind.QuestionToken:
                case SyntaxKind.SlashToken:
                case SyntaxKind.BarBarToken:
                case SyntaxKind.AmpersandAmpersandToken:
                case SyntaxKind.MinusMinusToken:
                case SyntaxKind.PlusPlusToken:
                case SyntaxKind.ColonColonToken:
                case SyntaxKind.QuestionQuestionToken:
                case SyntaxKind.MinusGreaterThanToken:
                case SyntaxKind.ExclamationEqualsToken:
                case SyntaxKind.EqualsEqualsToken:
                case SyntaxKind.EqualsGreaterThanToken:
                case SyntaxKind.LessThanEqualsToken:
                case SyntaxKind.LessThanLessThanToken:
                case SyntaxKind.LessThanLessThanEqualsToken:
                case SyntaxKind.GreaterThanEqualsToken:
                case SyntaxKind.GreaterThanGreaterThanToken:
                case SyntaxKind.GreaterThanGreaterThanEqualsToken:
                case SyntaxKind.SlashEqualsToken:
                case SyntaxKind.AsteriskEqualsToken:
                case SyntaxKind.BarEqualsToken:
                case SyntaxKind.AmpersandEqualsToken:
                case SyntaxKind.PlusEqualsToken:
                case SyntaxKind.MinusEqualsToken:
                case SyntaxKind.CaretEqualsToken:
                case SyntaxKind.PercentEqualsToken:
                    return true;
        
                default:
                    return false;
            }
        }
    
        private static void ClassificationForPunctuation(XElement element, Microsoft.CodeAnalysis.SyntaxToken token)
        {
            if (IsOperator(token.Kind()))
            {
                // special cases...
                switch (token.Kind())
                {
                    case SyntaxKind.LessThanToken:
                    case SyntaxKind.GreaterThanToken:
                        // the < and > tokens of a type parameter list should be classified as
                        // punctuation; otherwise, they're operators.
                        if (token.Parent != null)
                        {
                            if (token.Parent.Kind() == SyntaxKind.TypeParameterList ||
                                token.Parent.Kind() == SyntaxKind.TypeArgumentList)
                            {
                                element.Add(new XAttribute("Punctuation", true));
                            }
                        }
    
                        break;
                    case SyntaxKind.ColonToken:
                        // the : for inheritance/implements or labels should be classified as
                        // punctuation; otherwise, it's from a conditional operator.
                        if (token.Parent != null)
                        {
                            if (token.Parent.Kind() != SyntaxKind.ConditionalExpression)
                            {
                                element.Add(new XAttribute("Punctuation", true));
                            }
                        }
    
                        break;
                }
    
                element.Add(new XAttribute("Operator", true));
            }
            else
            {
                element.Add(new XAttribute("Punctuation", true));
            }
        }
    
        /// <summary>
        /// Annotates an element with syntax metadata.
        /// </summary>
        /// <param name="element">the XML element being serialized.</param>
        /// <param name="node">the node being represented by the serializing XML element.</param>
        protected virtual void Annotate(XElement element, Microsoft.CodeAnalysis.SyntaxToken node)
        {
            if (SyntaxFacts.IsPunctuation(node.Kind()))
            {
                ClassificationForPunctuation(element, node);
            }
    
            // if (SyntaxFacts.IsPrefixUnaryExpressionOperatorToken(node.Kind()))
            // {
            //     element.Add(new XAttribute("PrefixUnaryOperator", true));
            // }
    		// 
            // if (SyntaxFacts.IsPostfixUnaryExpressionToken(node.Kind()))
            // {
            //     element.Add(new XAttribute("PostfixUnaryOperator", true));
            // }
    
            // if (SyntaxFacts.IsLiteralExpression(node.Kind()))
            // {
            //     element.Add(new XAttribute("Literal", true));
            // }
    
            // if (SyntaxFacts.IsInstanceExpression(node.Kind()))
            // {
            //     element.Add(new XAttribute("InstanceExpression", true));
            // }
    
            // if (SyntaxFacts.IsBinaryExpressionOperatorToken(node.Kind()))
            // {
            //     element.Add(new XAttribute("BinaryExpressionOperator", true));
            // }
    		// 
            // if (SyntaxFacts.IsAssignmentExpressionOperatorToken(node.Kind()))
            // {
            //     element.Add(new XAttribute("AssignmentExpressionOperator", true));
            // }
    
            //Keyword
            // if (SyntaxFacts.IsAccessorDeclarationKeyword(node.Kind()))
            // {
            //     element.Add(new XAttribute("AccessorDeclarationKeyword", true));
            // }
        }
    
        /// <summary>
        /// Annotates an element with syntax metadata.
        /// </summary>
        /// <param name="element">the XML element being serialized.</param>
        /// <param name="node">the node being represented by the serializing XML element.</param>
        protected virtual void Annotate(XElement element, Microsoft.CodeAnalysis.SyntaxNode node)
        {
            if (SyntaxFacts.IsAliasQualifier(node))
            {
                element.Add(new XAttribute("Keyword", true));
            }
        
            if (SyntaxFacts.IsKeywordKind(node.Kind()))
            {
                element.Add(new XAttribute("Keyword", true));
            }
        
            if (SyntaxFacts.IsReservedKeyword(node.Kind()))
            {
                element.Add(new XAttribute("ReservedKeyword", true));
            }
        
            if (SyntaxFacts.IsAttributeTargetSpecifier(node.Kind()))
            {
                element.Add(new XAttribute("AttributeTargetSpecifier", true));
            }
        
            if (SyntaxFacts.IsAccessibilityModifier(node.Kind()))
            {
                element.Add(new XAttribute("AccessibilityModifier", true));
            }
        
            if (SyntaxFacts.IsPreprocessorKeyword(node.Kind()))
            {
                element.Add(new XAttribute("PreprocessorKeyword", true));
            }
        
            if (SyntaxFacts.IsLanguagePunctuation(node.Kind()))
            {
                element.Add(new XAttribute("LanguagePunctuation", true));
            }
        
            if (SyntaxFacts.IsPreprocessorPunctuation(node.Kind()))
            {
                element.Add(new XAttribute("PreprocessorPunctuation", true));
            }
        
            if (SyntaxFacts.IsTrivia(node.Kind()))
            {
                element.Add(new XAttribute("Trivia", true));
            }
        
            if (SyntaxFacts.IsPreprocessorDirective(node.Kind()))
            {
                element.Add(new XAttribute("PreprocessorDirective", true));
            }
        
            if (SyntaxFacts.IsName(node.Kind()))
            {
                element.Add(new XAttribute("Name", true));
            }
        
            if (SyntaxFacts.IsPredefinedType(node.Kind()))
            {
                element.Add(new XAttribute("PredefinedType", true));
            }
        
            if (SyntaxFacts.IsTypeSyntax(node.Kind()))
            {
                element.Add(new XAttribute("TypeSyntax", true));
            }
        
            //if (SyntaxFacts.IsTypeDeclaration(node.Kind()))
            //{
            //    element.Add(new XAttribute("TypeDeclaration", true));
            //}
        
            if (SyntaxFacts.IsAssignmentExpression(node.Kind()))
            {
                element.Add(new XAttribute("AssignmentExpression", true));
            }
        
            if (SyntaxFacts.IsAccessorDeclaration(node.Kind()))
            {
                element.Add(new XAttribute("AccessorDeclaration", true));
            }
        
            if (SyntaxFacts.IsContextualKeyword(node.Kind()))
            {
                element.Add(new XAttribute("ContextualKeyword", true));
            }
        
            if (SyntaxFacts.IsQueryContextualKeyword(node.Kind()))
            {
                element.Add(new XAttribute("QueryContextualKeyword", true));
            }
        
            if (SyntaxFacts.IsTypeParameterVarianceKeyword(node.Kind()))
            {
                element.Add(new XAttribute("TypeParameterVarianceKeyword", true));
            }
        
            if (SyntaxFacts.IsDocumentationCommentTrivia(node.Kind()))
            {
                element.Add(new XAttribute("DocumentationCommentTrivia", true));
            }
        }
    
        /// <summary>
        /// Called when the visitor visits a AttributeArgumentListSyntax node.
        /// </summary>
        public virtual XElement VisitToken(Microsoft.CodeAnalysis.SyntaxToken node)
        {
    		var result = new XElement("Token");
            result.Add(new XText(node.ValueText));
            return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a AttributeSyntax node.
        /// </summary>
        public override XElement VisitAttribute(Microsoft.CodeAnalysis.CSharp.Syntax.AttributeSyntax node)
        {
    		var result = new XElement("Attribute");
    		var xName = this.Visit(node.Name);
    		xName.Add(new XAttribute("part", "Name"));
    		result.Add(xName);
    		if(node.ArgumentList != null)
    		{
    			var xArgumentList = this.Visit(node.ArgumentList);
    			xArgumentList.Add(new XAttribute("part", "ArgumentList"));
    			result.Add(xArgumentList);
    		}
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a AttributeArgumentListSyntax node.
        /// </summary>
        public override XElement VisitAttributeArgumentList(Microsoft.CodeAnalysis.CSharp.Syntax.AttributeArgumentListSyntax node)
        {
    		var result = new XElement("AttributeArgumentList");
    		var xOpenParenToken = new XElement("Token");
    		//xOpenParenToken.Add(new XAttribute("part", "OpenParenToken"));
    		result.Add(xOpenParenToken);
    		var xArguments = new XElement("SeparatedList_of_AttributeArgument");
    		xArguments.Add(new XAttribute("part", "Arguments"));
    		foreach(var x in node.Arguments)
    		{
    			xArguments.Add(this.Visit(x));
    		}
    		result.Add(xArguments);
    		var xCloseParenToken = new XElement("Token");
    		//xCloseParenToken.Add(new XAttribute("part", "CloseParenToken"));
    		result.Add(xCloseParenToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a AttributeArgumentSyntax node.
        /// </summary>
        public override XElement VisitAttributeArgument(Microsoft.CodeAnalysis.CSharp.Syntax.AttributeArgumentSyntax node)
        {
    		var result = new XElement("AttributeArgument");
    		if(node.NameEquals != null)
    		{
    			var xNameEquals = this.Visit(node.NameEquals);
    			xNameEquals.Add(new XAttribute("part", "NameEquals"));
    			result.Add(xNameEquals);
    		}
    		if(node.NameColon != null)
    		{
    			var xNameColon = this.Visit(node.NameColon);
    			xNameColon.Add(new XAttribute("part", "NameColon"));
    			result.Add(xNameColon);
    		}
    		var xExpression = this.Visit(node.Expression);
    		xExpression.Add(new XAttribute("part", "Expression"));
    		result.Add(xExpression);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a NameEqualsSyntax node.
        /// </summary>
        public override XElement VisitNameEquals(Microsoft.CodeAnalysis.CSharp.Syntax.NameEqualsSyntax node)
        {
    		var result = new XElement("NameEquals");
    		var xName = this.Visit(node.Name);
    		xName.Add(new XAttribute("part", "Name"));
    		result.Add(xName);
    		var xEqualsToken = new XElement("Token");
    		//xEqualsToken.Add(new XAttribute("part", "EqualsToken"));
    		result.Add(xEqualsToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a TypeParameterListSyntax node.
        /// </summary>
        public override XElement VisitTypeParameterList(Microsoft.CodeAnalysis.CSharp.Syntax.TypeParameterListSyntax node)
        {
    		var result = new XElement("TypeParameterList");
    		var xLessThanToken = new XElement("Token");
    		//xLessThanToken.Add(new XAttribute("part", "LessThanToken"));
    		result.Add(xLessThanToken);
    		var xParameters = new XElement("SeparatedList_of_TypeParameter");
    		xParameters.Add(new XAttribute("part", "Parameters"));
    		foreach(var x in node.Parameters)
    		{
    			xParameters.Add(this.Visit(x));
    		}
    		result.Add(xParameters);
    		var xGreaterThanToken = new XElement("Token");
    		//xGreaterThanToken.Add(new XAttribute("part", "GreaterThanToken"));
    		result.Add(xGreaterThanToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a TypeParameterSyntax node.
        /// </summary>
        public override XElement VisitTypeParameter(Microsoft.CodeAnalysis.CSharp.Syntax.TypeParameterSyntax node)
        {
    		var result = new XElement("TypeParameter");
    		var xAttributeLists = new XElement("List_of_AttributeList");
    		xAttributeLists.Add(new XAttribute("part", "AttributeLists"));
    		foreach(var x in node.AttributeLists)
    		{
    			xAttributeLists.Add(this.Visit(x));
    		}
    		result.Add(xAttributeLists);
    		if(node.VarianceKeyword != null)
    		{
    			var xVarianceKeyword = new XElement("Token");
    		//	xVarianceKeyword.Add(new XAttribute("part", "VarianceKeyword"));
    			result.Add(xVarianceKeyword);
    		}
    		var xIdentifier = new XElement("Token");
    		//xIdentifier.Add(new XAttribute("part", "Identifier"));
    		result.Add(xIdentifier);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a BaseListSyntax node.
        /// </summary>
        public override XElement VisitBaseList(Microsoft.CodeAnalysis.CSharp.Syntax.BaseListSyntax node)
        {
    		var result = new XElement("BaseList");
    		var xColonToken = new XElement("Token");
    		//xColonToken.Add(new XAttribute("part", "ColonToken"));
    		result.Add(xColonToken);
    		var xTypes = new XElement("SeparatedList_of_BaseType");
    		xTypes.Add(new XAttribute("part", "Types"));
    		foreach(var x in node.Types)
    		{
    			xTypes.Add(this.Visit(x));
    		}
    		result.Add(xTypes);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a TypeParameterConstraintClauseSyntax node.
        /// </summary>
        public override XElement VisitTypeParameterConstraintClause(Microsoft.CodeAnalysis.CSharp.Syntax.TypeParameterConstraintClauseSyntax node)
        {
    		var result = new XElement("TypeParameterConstraintClause");
    		var xWhereKeyword = new XElement("Token");
    		//xWhereKeyword.Add(new XAttribute("part", "WhereKeyword"));
    		result.Add(xWhereKeyword);
    		var xName = this.Visit(node.Name);
    		xName.Add(new XAttribute("part", "Name"));
    		result.Add(xName);
    		var xColonToken = new XElement("Token");
    		//xColonToken.Add(new XAttribute("part", "ColonToken"));
    		result.Add(xColonToken);
    		var xConstraints = new XElement("SeparatedList_of_TypeParameterConstraint");
    		xConstraints.Add(new XAttribute("part", "Constraints"));
    		foreach(var x in node.Constraints)
    		{
    			xConstraints.Add(this.Visit(x));
    		}
    		result.Add(xConstraints);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a ExplicitInterfaceSpecifierSyntax node.
        /// </summary>
        public override XElement VisitExplicitInterfaceSpecifier(Microsoft.CodeAnalysis.CSharp.Syntax.ExplicitInterfaceSpecifierSyntax node)
        {
    		var result = new XElement("ExplicitInterfaceSpecifier");
    		var xName = this.Visit(node.Name);
    		xName.Add(new XAttribute("part", "Name"));
    		result.Add(xName);
    		var xDotToken = new XElement("Token");
    		//xDotToken.Add(new XAttribute("part", "DotToken"));
    		result.Add(xDotToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a ConstructorInitializerSyntax node.
        /// </summary>
        public override XElement VisitConstructorInitializer(Microsoft.CodeAnalysis.CSharp.Syntax.ConstructorInitializerSyntax node)
        {
    		var result = new XElement("ConstructorInitializer");
    		var xColonToken = new XElement("Token");
    		//xColonToken.Add(new XAttribute("part", "ColonToken"));
    		result.Add(xColonToken);
    		var xThisOrBaseKeyword = new XElement("Token");
    		//xThisOrBaseKeyword.Add(new XAttribute("part", "ThisOrBaseKeyword"));
    		result.Add(xThisOrBaseKeyword);
    		var xArgumentList = this.Visit(node.ArgumentList);
    		xArgumentList.Add(new XAttribute("part", "ArgumentList"));
    		result.Add(xArgumentList);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a ArrowExpressionClauseSyntax node.
        /// </summary>
        public override XElement VisitArrowExpressionClause(Microsoft.CodeAnalysis.CSharp.Syntax.ArrowExpressionClauseSyntax node)
        {
    		var result = new XElement("ArrowExpressionClause");
    		var xArrowToken = new XElement("Token");
    		//xArrowToken.Add(new XAttribute("part", "ArrowToken"));
    		result.Add(xArrowToken);
    		var xExpression = this.Visit(node.Expression);
    		xExpression.Add(new XAttribute("part", "Expression"));
    		result.Add(xExpression);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a AccessorListSyntax node.
        /// </summary>
        public override XElement VisitAccessorList(Microsoft.CodeAnalysis.CSharp.Syntax.AccessorListSyntax node)
        {
    		var result = new XElement("AccessorList");
    		var xOpenBraceToken = new XElement("Token");
    		//xOpenBraceToken.Add(new XAttribute("part", "OpenBraceToken"));
    		result.Add(xOpenBraceToken);
    		var xAccessors = new XElement("List_of_AccessorDeclaration");
    		xAccessors.Add(new XAttribute("part", "Accessors"));
    		foreach(var x in node.Accessors)
    		{
    			xAccessors.Add(this.Visit(x));
    		}
    		result.Add(xAccessors);
    		var xCloseBraceToken = new XElement("Token");
    		//xCloseBraceToken.Add(new XAttribute("part", "CloseBraceToken"));
    		result.Add(xCloseBraceToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a AccessorDeclarationSyntax node.
        /// </summary>
        public override XElement VisitAccessorDeclaration(Microsoft.CodeAnalysis.CSharp.Syntax.AccessorDeclarationSyntax node)
        {
    		var result = new XElement("AccessorDeclaration");
    		var xAttributeLists = new XElement("List_of_AttributeList");
    		xAttributeLists.Add(new XAttribute("part", "AttributeLists"));
    		foreach(var x in node.AttributeLists)
    		{
    			xAttributeLists.Add(this.Visit(x));
    		}
    		result.Add(xAttributeLists);
    		var xModifiers = new XElement("TokenList");
    		xModifiers.Add(new XAttribute("part", "Modifiers"));
    		foreach(var x in node.Modifiers)
    		{
    			xModifiers.Add(new XText(x.ValueText));
    		}
    		result.Add(xModifiers);
    		var xKeyword = new XElement("Token");
    		//xKeyword.Add(new XAttribute("part", "Keyword"));
    		result.Add(xKeyword);
    		if(node.Body != null)
    		{
    			var xBody = this.Visit(node.Body);
    			xBody.Add(new XAttribute("part", "Body"));
    			result.Add(xBody);
    		}
    		if(node.SemicolonToken != null)
    		{
    			var xSemicolonToken = new XElement("Token");
    		//	xSemicolonToken.Add(new XAttribute("part", "SemicolonToken"));
    			result.Add(xSemicolonToken);
    		}
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a ParameterSyntax node.
        /// </summary>
        public override XElement VisitParameter(Microsoft.CodeAnalysis.CSharp.Syntax.ParameterSyntax node)
        {
    		var result = new XElement("Parameter");
    		var xAttributeLists = new XElement("List_of_AttributeList");
    		xAttributeLists.Add(new XAttribute("part", "AttributeLists"));
    		foreach(var x in node.AttributeLists)
    		{
    			xAttributeLists.Add(this.Visit(x));
    		}
    		result.Add(xAttributeLists);
    		var xModifiers = new XElement("TokenList");
    		xModifiers.Add(new XAttribute("part", "Modifiers"));
    		foreach(var x in node.Modifiers)
    		{
    			xModifiers.Add(new XText(x.ValueText));
    		}
    		result.Add(xModifiers);
    		if(node.Type != null)
    		{
    			var xType = this.Visit(node.Type);
    			xType.Add(new XAttribute("part", "Type"));
    			result.Add(xType);
    		}
    		var xIdentifier = new XElement("Token");
    		//xIdentifier.Add(new XAttribute("part", "Identifier"));
    		result.Add(xIdentifier);
    		if(node.Default != null)
    		{
    			var xDefault = this.Visit(node.Default);
    			xDefault.Add(new XAttribute("part", "Default"));
    			result.Add(xDefault);
    		}
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a CrefParameterSyntax node.
        /// </summary>
        public override XElement VisitCrefParameter(Microsoft.CodeAnalysis.CSharp.Syntax.CrefParameterSyntax node)
        {
    		var result = new XElement("CrefParameter");
    		if(node.RefOrOutKeyword != null)
    		{
    			var xRefOrOutKeyword = new XElement("Token");
    		//	xRefOrOutKeyword.Add(new XAttribute("part", "RefOrOutKeyword"));
    			result.Add(xRefOrOutKeyword);
    		}
    		var xType = this.Visit(node.Type);
    		xType.Add(new XAttribute("part", "Type"));
    		result.Add(xType);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a XmlElementStartTagSyntax node.
        /// </summary>
        public override XElement VisitXmlElementStartTag(Microsoft.CodeAnalysis.CSharp.Syntax.XmlElementStartTagSyntax node)
        {
    		var result = new XElement("XmlElementStartTag");
    		var xLessThanToken = new XElement("Token");
    		//xLessThanToken.Add(new XAttribute("part", "LessThanToken"));
    		result.Add(xLessThanToken);
    		var xName = this.Visit(node.Name);
    		xName.Add(new XAttribute("part", "Name"));
    		result.Add(xName);
    		var xAttributes = new XElement("List_of_XmlAttribute");
    		xAttributes.Add(new XAttribute("part", "Attributes"));
    		foreach(var x in node.Attributes)
    		{
    			xAttributes.Add(this.Visit(x));
    		}
    		result.Add(xAttributes);
    		var xGreaterThanToken = new XElement("Token");
    		//xGreaterThanToken.Add(new XAttribute("part", "GreaterThanToken"));
    		result.Add(xGreaterThanToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a XmlElementEndTagSyntax node.
        /// </summary>
        public override XElement VisitXmlElementEndTag(Microsoft.CodeAnalysis.CSharp.Syntax.XmlElementEndTagSyntax node)
        {
    		var result = new XElement("XmlElementEndTag");
    		var xLessThanSlashToken = new XElement("Token");
    		//xLessThanSlashToken.Add(new XAttribute("part", "LessThanSlashToken"));
    		result.Add(xLessThanSlashToken);
    		var xName = this.Visit(node.Name);
    		xName.Add(new XAttribute("part", "Name"));
    		result.Add(xName);
    		var xGreaterThanToken = new XElement("Token");
    		//xGreaterThanToken.Add(new XAttribute("part", "GreaterThanToken"));
    		result.Add(xGreaterThanToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a XmlNameSyntax node.
        /// </summary>
        public override XElement VisitXmlName(Microsoft.CodeAnalysis.CSharp.Syntax.XmlNameSyntax node)
        {
    		var result = new XElement("XmlName");
    		if(node.Prefix != null)
    		{
    			var xPrefix = this.Visit(node.Prefix);
    			xPrefix.Add(new XAttribute("part", "Prefix"));
    			result.Add(xPrefix);
    		}
    		var xLocalName = new XElement("Token");
    		//xLocalName.Add(new XAttribute("part", "LocalName"));
    		result.Add(xLocalName);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a XmlPrefixSyntax node.
        /// </summary>
        public override XElement VisitXmlPrefix(Microsoft.CodeAnalysis.CSharp.Syntax.XmlPrefixSyntax node)
        {
    		var result = new XElement("XmlPrefix");
    		var xPrefix = new XElement("Token");
    		//xPrefix.Add(new XAttribute("part", "Prefix"));
    		result.Add(xPrefix);
    		var xColonToken = new XElement("Token");
    		//xColonToken.Add(new XAttribute("part", "ColonToken"));
    		result.Add(xColonToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a TypeArgumentListSyntax node.
        /// </summary>
        public override XElement VisitTypeArgumentList(Microsoft.CodeAnalysis.CSharp.Syntax.TypeArgumentListSyntax node)
        {
    		var result = new XElement("TypeArgumentList");
    		var xLessThanToken = new XElement("Token");
    		//xLessThanToken.Add(new XAttribute("part", "LessThanToken"));
    		result.Add(xLessThanToken);
    		var xArguments = new XElement("SeparatedList_of_Type");
    		xArguments.Add(new XAttribute("part", "Arguments"));
    		foreach(var x in node.Arguments)
    		{
    			xArguments.Add(this.Visit(x));
    		}
    		result.Add(xArguments);
    		var xGreaterThanToken = new XElement("Token");
    		//xGreaterThanToken.Add(new XAttribute("part", "GreaterThanToken"));
    		result.Add(xGreaterThanToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a ArrayRankSpecifierSyntax node.
        /// </summary>
        public override XElement VisitArrayRankSpecifier(Microsoft.CodeAnalysis.CSharp.Syntax.ArrayRankSpecifierSyntax node)
        {
    		var result = new XElement("ArrayRankSpecifier");
    		var xOpenBracketToken = new XElement("Token");
    		//xOpenBracketToken.Add(new XAttribute("part", "OpenBracketToken"));
    		result.Add(xOpenBracketToken);
    		var xSizes = new XElement("SeparatedList_of_Expression");
    		xSizes.Add(new XAttribute("part", "Sizes"));
    		foreach(var x in node.Sizes)
    		{
    			xSizes.Add(this.Visit(x));
    		}
    		result.Add(xSizes);
    		var xCloseBracketToken = new XElement("Token");
    		//xCloseBracketToken.Add(new XAttribute("part", "CloseBracketToken"));
    		result.Add(xCloseBracketToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a TupleElementSyntax node.
        /// </summary>
        public override XElement VisitTupleElement(Microsoft.CodeAnalysis.CSharp.Syntax.TupleElementSyntax node)
        {
    		var result = new XElement("TupleElement");
    		var xType = this.Visit(node.Type);
    		xType.Add(new XAttribute("part", "Type"));
    		result.Add(xType);
    		if(node.Identifier != null)
    		{
    			var xIdentifier = new XElement("Token");
    		//	xIdentifier.Add(new XAttribute("part", "Identifier"));
    			result.Add(xIdentifier);
    		}
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a ArgumentSyntax node.
        /// </summary>
        public override XElement VisitArgument(Microsoft.CodeAnalysis.CSharp.Syntax.ArgumentSyntax node)
        {
    		var result = new XElement("Argument");
    		if(node.NameColon != null)
    		{
    			var xNameColon = this.Visit(node.NameColon);
    			xNameColon.Add(new XAttribute("part", "NameColon"));
    			result.Add(xNameColon);
    		}
    		if(node.RefOrOutKeyword != null)
    		{
    			var xRefOrOutKeyword = new XElement("Token");
    		//	xRefOrOutKeyword.Add(new XAttribute("part", "RefOrOutKeyword"));
    			result.Add(xRefOrOutKeyword);
    		}
    		var xExpression = this.Visit(node.Expression);
    		xExpression.Add(new XAttribute("part", "Expression"));
    		result.Add(xExpression);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a NameColonSyntax node.
        /// </summary>
        public override XElement VisitNameColon(Microsoft.CodeAnalysis.CSharp.Syntax.NameColonSyntax node)
        {
    		var result = new XElement("NameColon");
    		var xName = this.Visit(node.Name);
    		xName.Add(new XAttribute("part", "Name"));
    		result.Add(xName);
    		var xColonToken = new XElement("Token");
    		//xColonToken.Add(new XAttribute("part", "ColonToken"));
    		result.Add(xColonToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a AnonymousObjectMemberDeclaratorSyntax node.
        /// </summary>
        public override XElement VisitAnonymousObjectMemberDeclarator(Microsoft.CodeAnalysis.CSharp.Syntax.AnonymousObjectMemberDeclaratorSyntax node)
        {
    		var result = new XElement("AnonymousObjectMemberDeclarator");
    		if(node.NameEquals != null)
    		{
    			var xNameEquals = this.Visit(node.NameEquals);
    			xNameEquals.Add(new XAttribute("part", "NameEquals"));
    			result.Add(xNameEquals);
    		}
    		var xExpression = this.Visit(node.Expression);
    		xExpression.Add(new XAttribute("part", "Expression"));
    		result.Add(xExpression);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a QueryBodySyntax node.
        /// </summary>
        public override XElement VisitQueryBody(Microsoft.CodeAnalysis.CSharp.Syntax.QueryBodySyntax node)
        {
    		var result = new XElement("QueryBody");
    		var xClauses = new XElement("List_of_QueryClause");
    		xClauses.Add(new XAttribute("part", "Clauses"));
    		foreach(var x in node.Clauses)
    		{
    			xClauses.Add(this.Visit(x));
    		}
    		result.Add(xClauses);
    		var xSelectOrGroup = this.Visit(node.SelectOrGroup);
    		xSelectOrGroup.Add(new XAttribute("part", "SelectOrGroup"));
    		result.Add(xSelectOrGroup);
    		if(node.Continuation != null)
    		{
    			var xContinuation = this.Visit(node.Continuation);
    			xContinuation.Add(new XAttribute("part", "Continuation"));
    			result.Add(xContinuation);
    		}
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a JoinIntoClauseSyntax node.
        /// </summary>
        public override XElement VisitJoinIntoClause(Microsoft.CodeAnalysis.CSharp.Syntax.JoinIntoClauseSyntax node)
        {
    		var result = new XElement("JoinIntoClause");
    		var xIntoKeyword = new XElement("Token");
    		//xIntoKeyword.Add(new XAttribute("part", "IntoKeyword"));
    		result.Add(xIntoKeyword);
    		var xIdentifier = new XElement("Token");
    		//xIdentifier.Add(new XAttribute("part", "Identifier"));
    		result.Add(xIdentifier);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a OrderingSyntax node.
        /// </summary>
        public override XElement VisitOrdering(Microsoft.CodeAnalysis.CSharp.Syntax.OrderingSyntax node)
        {
    		var result = new XElement("Ordering");
    		var xExpression = this.Visit(node.Expression);
    		xExpression.Add(new XAttribute("part", "Expression"));
    		result.Add(xExpression);
    		if(node.AscendingOrDescendingKeyword != null)
    		{
    			var xAscendingOrDescendingKeyword = new XElement("Token");
    		//	xAscendingOrDescendingKeyword.Add(new XAttribute("part", "AscendingOrDescendingKeyword"));
    			result.Add(xAscendingOrDescendingKeyword);
    		}
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a QueryContinuationSyntax node.
        /// </summary>
        public override XElement VisitQueryContinuation(Microsoft.CodeAnalysis.CSharp.Syntax.QueryContinuationSyntax node)
        {
    		var result = new XElement("QueryContinuation");
    		var xIntoKeyword = new XElement("Token");
    		//xIntoKeyword.Add(new XAttribute("part", "IntoKeyword"));
    		result.Add(xIntoKeyword);
    		var xIdentifier = new XElement("Token");
    		//xIdentifier.Add(new XAttribute("part", "Identifier"));
    		result.Add(xIdentifier);
    		var xBody = this.Visit(node.Body);
    		xBody.Add(new XAttribute("part", "Body"));
    		result.Add(xBody);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a WhenClauseSyntax node.
        /// </summary>
        public override XElement VisitWhenClause(Microsoft.CodeAnalysis.CSharp.Syntax.WhenClauseSyntax node)
        {
    		var result = new XElement("WhenClause");
    		var xWhenKeyword = new XElement("Token");
    		//xWhenKeyword.Add(new XAttribute("part", "WhenKeyword"));
    		result.Add(xWhenKeyword);
    		var xCondition = this.Visit(node.Condition);
    		xCondition.Add(new XAttribute("part", "Condition"));
    		result.Add(xCondition);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a InterpolationAlignmentClauseSyntax node.
        /// </summary>
        public override XElement VisitInterpolationAlignmentClause(Microsoft.CodeAnalysis.CSharp.Syntax.InterpolationAlignmentClauseSyntax node)
        {
    		var result = new XElement("InterpolationAlignmentClause");
    		var xCommaToken = new XElement("Token");
    		//xCommaToken.Add(new XAttribute("part", "CommaToken"));
    		result.Add(xCommaToken);
    		var xValue = this.Visit(node.Value);
    		xValue.Add(new XAttribute("part", "Value"));
    		result.Add(xValue);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a InterpolationFormatClauseSyntax node.
        /// </summary>
        public override XElement VisitInterpolationFormatClause(Microsoft.CodeAnalysis.CSharp.Syntax.InterpolationFormatClauseSyntax node)
        {
    		var result = new XElement("InterpolationFormatClause");
    		var xColonToken = new XElement("Token");
    		//xColonToken.Add(new XAttribute("part", "ColonToken"));
    		result.Add(xColonToken);
    		var xFormatStringToken = new XElement("Token");
    		//xFormatStringToken.Add(new XAttribute("part", "FormatStringToken"));
    		result.Add(xFormatStringToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a VariableDeclarationSyntax node.
        /// </summary>
        public override XElement VisitVariableDeclaration(Microsoft.CodeAnalysis.CSharp.Syntax.VariableDeclarationSyntax node)
        {
    		var result = new XElement("VariableDeclaration");
    		var xType = this.Visit(node.Type);
    		xType.Add(new XAttribute("part", "Type"));
    		result.Add(xType);
    		var xVariables = new XElement("SeparatedList_of_VariableDeclarator");
    		xVariables.Add(new XAttribute("part", "Variables"));
    		foreach(var x in node.Variables)
    		{
    			xVariables.Add(this.Visit(x));
    		}
    		result.Add(xVariables);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a VariableDeclaratorSyntax node.
        /// </summary>
        public override XElement VisitVariableDeclarator(Microsoft.CodeAnalysis.CSharp.Syntax.VariableDeclaratorSyntax node)
        {
    		var result = new XElement("VariableDeclarator");
    		var xIdentifier = new XElement("Token");
    		//xIdentifier.Add(new XAttribute("part", "Identifier"));
    		result.Add(xIdentifier);
    		if(node.ArgumentList != null)
    		{
    			var xArgumentList = this.Visit(node.ArgumentList);
    			xArgumentList.Add(new XAttribute("part", "ArgumentList"));
    			result.Add(xArgumentList);
    		}
    		if(node.Initializer != null)
    		{
    			var xInitializer = this.Visit(node.Initializer);
    			xInitializer.Add(new XAttribute("part", "Initializer"));
    			result.Add(xInitializer);
    		}
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a EqualsValueClauseSyntax node.
        /// </summary>
        public override XElement VisitEqualsValueClause(Microsoft.CodeAnalysis.CSharp.Syntax.EqualsValueClauseSyntax node)
        {
    		var result = new XElement("EqualsValueClause");
    		var xEqualsToken = new XElement("Token");
    		//xEqualsToken.Add(new XAttribute("part", "EqualsToken"));
    		result.Add(xEqualsToken);
    		var xValue = this.Visit(node.Value);
    		xValue.Add(new XAttribute("part", "Value"));
    		result.Add(xValue);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a ElseClauseSyntax node.
        /// </summary>
        public override XElement VisitElseClause(Microsoft.CodeAnalysis.CSharp.Syntax.ElseClauseSyntax node)
        {
    		var result = new XElement("ElseClause");
    		var xElseKeyword = new XElement("Token");
    		//xElseKeyword.Add(new XAttribute("part", "ElseKeyword"));
    		result.Add(xElseKeyword);
    		var xStatement = this.Visit(node.Statement);
    		xStatement.Add(new XAttribute("part", "Statement"));
    		result.Add(xStatement);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a SwitchSectionSyntax node.
        /// </summary>
        public override XElement VisitSwitchSection(Microsoft.CodeAnalysis.CSharp.Syntax.SwitchSectionSyntax node)
        {
    		var result = new XElement("SwitchSection");
    		var xLabels = new XElement("List_of_SwitchLabel");
    		xLabels.Add(new XAttribute("part", "Labels"));
    		foreach(var x in node.Labels)
    		{
    			xLabels.Add(this.Visit(x));
    		}
    		result.Add(xLabels);
    		var xStatements = new XElement("List_of_Statement");
    		xStatements.Add(new XAttribute("part", "Statements"));
    		foreach(var x in node.Statements)
    		{
    			xStatements.Add(this.Visit(x));
    		}
    		result.Add(xStatements);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a CatchClauseSyntax node.
        /// </summary>
        public override XElement VisitCatchClause(Microsoft.CodeAnalysis.CSharp.Syntax.CatchClauseSyntax node)
        {
    		var result = new XElement("CatchClause");
    		var xCatchKeyword = new XElement("Token");
    		//xCatchKeyword.Add(new XAttribute("part", "CatchKeyword"));
    		result.Add(xCatchKeyword);
    		if(node.Declaration != null)
    		{
    			var xDeclaration = this.Visit(node.Declaration);
    			xDeclaration.Add(new XAttribute("part", "Declaration"));
    			result.Add(xDeclaration);
    		}
    		if(node.Filter != null)
    		{
    			var xFilter = this.Visit(node.Filter);
    			xFilter.Add(new XAttribute("part", "Filter"));
    			result.Add(xFilter);
    		}
    		var xBlock = this.Visit(node.Block);
    		xBlock.Add(new XAttribute("part", "Block"));
    		result.Add(xBlock);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a CatchDeclarationSyntax node.
        /// </summary>
        public override XElement VisitCatchDeclaration(Microsoft.CodeAnalysis.CSharp.Syntax.CatchDeclarationSyntax node)
        {
    		var result = new XElement("CatchDeclaration");
    		var xOpenParenToken = new XElement("Token");
    		//xOpenParenToken.Add(new XAttribute("part", "OpenParenToken"));
    		result.Add(xOpenParenToken);
    		var xType = this.Visit(node.Type);
    		xType.Add(new XAttribute("part", "Type"));
    		result.Add(xType);
    		if(node.Identifier != null)
    		{
    			var xIdentifier = new XElement("Token");
    		//	xIdentifier.Add(new XAttribute("part", "Identifier"));
    			result.Add(xIdentifier);
    		}
    		var xCloseParenToken = new XElement("Token");
    		//xCloseParenToken.Add(new XAttribute("part", "CloseParenToken"));
    		result.Add(xCloseParenToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a CatchFilterClauseSyntax node.
        /// </summary>
        public override XElement VisitCatchFilterClause(Microsoft.CodeAnalysis.CSharp.Syntax.CatchFilterClauseSyntax node)
        {
    		var result = new XElement("CatchFilterClause");
    		var xWhenKeyword = new XElement("Token");
    		//xWhenKeyword.Add(new XAttribute("part", "WhenKeyword"));
    		result.Add(xWhenKeyword);
    		var xOpenParenToken = new XElement("Token");
    		//xOpenParenToken.Add(new XAttribute("part", "OpenParenToken"));
    		result.Add(xOpenParenToken);
    		var xFilterExpression = this.Visit(node.FilterExpression);
    		xFilterExpression.Add(new XAttribute("part", "FilterExpression"));
    		result.Add(xFilterExpression);
    		var xCloseParenToken = new XElement("Token");
    		//xCloseParenToken.Add(new XAttribute("part", "CloseParenToken"));
    		result.Add(xCloseParenToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a FinallyClauseSyntax node.
        /// </summary>
        public override XElement VisitFinallyClause(Microsoft.CodeAnalysis.CSharp.Syntax.FinallyClauseSyntax node)
        {
    		var result = new XElement("FinallyClause");
    		var xFinallyKeyword = new XElement("Token");
    		//xFinallyKeyword.Add(new XAttribute("part", "FinallyKeyword"));
    		result.Add(xFinallyKeyword);
    		var xBlock = this.Visit(node.Block);
    		xBlock.Add(new XAttribute("part", "Block"));
    		result.Add(xBlock);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a CompilationUnitSyntax node.
        /// </summary>
        public override XElement VisitCompilationUnit(Microsoft.CodeAnalysis.CSharp.Syntax.CompilationUnitSyntax node)
        {
    		var result = new XElement("CompilationUnit");
    		var xExterns = new XElement("List_of_ExternAliasDirective");
    		xExterns.Add(new XAttribute("part", "Externs"));
    		foreach(var x in node.Externs)
    		{
    			xExterns.Add(this.Visit(x));
    		}
    		result.Add(xExterns);
    		var xUsings = new XElement("List_of_UsingDirective");
    		xUsings.Add(new XAttribute("part", "Usings"));
    		foreach(var x in node.Usings)
    		{
    			xUsings.Add(this.Visit(x));
    		}
    		result.Add(xUsings);
    		var xAttributeLists = new XElement("List_of_AttributeList");
    		xAttributeLists.Add(new XAttribute("part", "AttributeLists"));
    		foreach(var x in node.AttributeLists)
    		{
    			xAttributeLists.Add(this.Visit(x));
    		}
    		result.Add(xAttributeLists);
    		var xMembers = new XElement("List_of_MemberDeclaration");
    		xMembers.Add(new XAttribute("part", "Members"));
    		foreach(var x in node.Members)
    		{
    			xMembers.Add(this.Visit(x));
    		}
    		result.Add(xMembers);
    		var xEndOfFileToken = new XElement("Token");
    		//xEndOfFileToken.Add(new XAttribute("part", "EndOfFileToken"));
    		result.Add(xEndOfFileToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a ExternAliasDirectiveSyntax node.
        /// </summary>
        public override XElement VisitExternAliasDirective(Microsoft.CodeAnalysis.CSharp.Syntax.ExternAliasDirectiveSyntax node)
        {
    		var result = new XElement("ExternAliasDirective");
    		var xExternKeyword = new XElement("Token");
    		//xExternKeyword.Add(new XAttribute("part", "ExternKeyword"));
    		result.Add(xExternKeyword);
    		var xAliasKeyword = new XElement("Token");
    		//xAliasKeyword.Add(new XAttribute("part", "AliasKeyword"));
    		result.Add(xAliasKeyword);
    		var xIdentifier = new XElement("Token");
    		//xIdentifier.Add(new XAttribute("part", "Identifier"));
    		result.Add(xIdentifier);
    		var xSemicolonToken = new XElement("Token");
    		//xSemicolonToken.Add(new XAttribute("part", "SemicolonToken"));
    		result.Add(xSemicolonToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a UsingDirectiveSyntax node.
        /// </summary>
        public override XElement VisitUsingDirective(Microsoft.CodeAnalysis.CSharp.Syntax.UsingDirectiveSyntax node)
        {
    		var result = new XElement("UsingDirective");
    		var xUsingKeyword = new XElement("Token");
    		//xUsingKeyword.Add(new XAttribute("part", "UsingKeyword"));
    		result.Add(xUsingKeyword);
    		if(node.StaticKeyword != null)
    		{
    			var xStaticKeyword = new XElement("Token");
    		//	xStaticKeyword.Add(new XAttribute("part", "StaticKeyword"));
    			result.Add(xStaticKeyword);
    		}
    		if(node.Alias != null)
    		{
    			var xAlias = this.Visit(node.Alias);
    			xAlias.Add(new XAttribute("part", "Alias"));
    			result.Add(xAlias);
    		}
    		var xName = this.Visit(node.Name);
    		xName.Add(new XAttribute("part", "Name"));
    		result.Add(xName);
    		var xSemicolonToken = new XElement("Token");
    		//xSemicolonToken.Add(new XAttribute("part", "SemicolonToken"));
    		result.Add(xSemicolonToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a AttributeListSyntax node.
        /// </summary>
        public override XElement VisitAttributeList(Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax node)
        {
    		var result = new XElement("AttributeList");
    		var xOpenBracketToken = new XElement("Token");
    		//xOpenBracketToken.Add(new XAttribute("part", "OpenBracketToken"));
    		result.Add(xOpenBracketToken);
    		if(node.Target != null)
    		{
    			var xTarget = this.Visit(node.Target);
    			xTarget.Add(new XAttribute("part", "Target"));
    			result.Add(xTarget);
    		}
    		var xAttributes = new XElement("SeparatedList_of_Attribute");
    		xAttributes.Add(new XAttribute("part", "Attributes"));
    		foreach(var x in node.Attributes)
    		{
    			xAttributes.Add(this.Visit(x));
    		}
    		result.Add(xAttributes);
    		var xCloseBracketToken = new XElement("Token");
    		//xCloseBracketToken.Add(new XAttribute("part", "CloseBracketToken"));
    		result.Add(xCloseBracketToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a AttributeTargetSpecifierSyntax node.
        /// </summary>
        public override XElement VisitAttributeTargetSpecifier(Microsoft.CodeAnalysis.CSharp.Syntax.AttributeTargetSpecifierSyntax node)
        {
    		var result = new XElement("AttributeTargetSpecifier");
    		var xIdentifier = new XElement("Token");
    		//xIdentifier.Add(new XAttribute("part", "Identifier"));
    		result.Add(xIdentifier);
    		var xColonToken = new XElement("Token");
    		//xColonToken.Add(new XAttribute("part", "ColonToken"));
    		result.Add(xColonToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a DelegateDeclarationSyntax node.
        /// </summary>
        public override XElement VisitDelegateDeclaration(Microsoft.CodeAnalysis.CSharp.Syntax.DelegateDeclarationSyntax node)
        {
    		var result = new XElement("DelegateDeclaration");
    		var xAttributeLists = new XElement("List_of_AttributeList");
    		xAttributeLists.Add(new XAttribute("part", "AttributeLists"));
    		foreach(var x in node.AttributeLists)
    		{
    			xAttributeLists.Add(this.Visit(x));
    		}
    		result.Add(xAttributeLists);
    		var xModifiers = new XElement("TokenList");
    		xModifiers.Add(new XAttribute("part", "Modifiers"));
    		foreach(var x in node.Modifiers)
    		{
    			xModifiers.Add(new XText(x.ValueText));
    		}
    		result.Add(xModifiers);
    		var xDelegateKeyword = new XElement("Token");
    		//xDelegateKeyword.Add(new XAttribute("part", "DelegateKeyword"));
    		result.Add(xDelegateKeyword);
    		var xReturnType = this.Visit(node.ReturnType);
    		xReturnType.Add(new XAttribute("part", "ReturnType"));
    		result.Add(xReturnType);
    		var xIdentifier = new XElement("Token");
    		//xIdentifier.Add(new XAttribute("part", "Identifier"));
    		result.Add(xIdentifier);
    		if(node.TypeParameterList != null)
    		{
    			var xTypeParameterList = this.Visit(node.TypeParameterList);
    			xTypeParameterList.Add(new XAttribute("part", "TypeParameterList"));
    			result.Add(xTypeParameterList);
    		}
    		var xParameterList = this.Visit(node.ParameterList);
    		xParameterList.Add(new XAttribute("part", "ParameterList"));
    		result.Add(xParameterList);
    		var xConstraintClauses = new XElement("List_of_TypeParameterConstraintClause");
    		xConstraintClauses.Add(new XAttribute("part", "ConstraintClauses"));
    		foreach(var x in node.ConstraintClauses)
    		{
    			xConstraintClauses.Add(this.Visit(x));
    		}
    		result.Add(xConstraintClauses);
    		var xSemicolonToken = new XElement("Token");
    		//xSemicolonToken.Add(new XAttribute("part", "SemicolonToken"));
    		result.Add(xSemicolonToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a EnumMemberDeclarationSyntax node.
        /// </summary>
        public override XElement VisitEnumMemberDeclaration(Microsoft.CodeAnalysis.CSharp.Syntax.EnumMemberDeclarationSyntax node)
        {
    		var result = new XElement("EnumMemberDeclaration");
    		var xAttributeLists = new XElement("List_of_AttributeList");
    		xAttributeLists.Add(new XAttribute("part", "AttributeLists"));
    		foreach(var x in node.AttributeLists)
    		{
    			xAttributeLists.Add(this.Visit(x));
    		}
    		result.Add(xAttributeLists);
    		var xIdentifier = new XElement("Token");
    		//xIdentifier.Add(new XAttribute("part", "Identifier"));
    		result.Add(xIdentifier);
    		if(node.EqualsValue != null)
    		{
    			var xEqualsValue = this.Visit(node.EqualsValue);
    			xEqualsValue.Add(new XAttribute("part", "EqualsValue"));
    			result.Add(xEqualsValue);
    		}
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a IncompleteMemberSyntax node.
        /// </summary>
        public override XElement VisitIncompleteMember(Microsoft.CodeAnalysis.CSharp.Syntax.IncompleteMemberSyntax node)
        {
    		var result = new XElement("IncompleteMember");
    		var xAttributeLists = new XElement("List_of_AttributeList");
    		xAttributeLists.Add(new XAttribute("part", "AttributeLists"));
    		foreach(var x in node.AttributeLists)
    		{
    			xAttributeLists.Add(this.Visit(x));
    		}
    		result.Add(xAttributeLists);
    		var xModifiers = new XElement("TokenList");
    		xModifiers.Add(new XAttribute("part", "Modifiers"));
    		foreach(var x in node.Modifiers)
    		{
    			xModifiers.Add(new XText(x.ValueText));
    		}
    		result.Add(xModifiers);
    		if(node.Type != null)
    		{
    			var xType = this.Visit(node.Type);
    			xType.Add(new XAttribute("part", "Type"));
    			result.Add(xType);
    		}
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a GlobalStatementSyntax node.
        /// </summary>
        public override XElement VisitGlobalStatement(Microsoft.CodeAnalysis.CSharp.Syntax.GlobalStatementSyntax node)
        {
    		var result = new XElement("GlobalStatement");
    		var xStatement = this.Visit(node.Statement);
    		xStatement.Add(new XAttribute("part", "Statement"));
    		result.Add(xStatement);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a NamespaceDeclarationSyntax node.
        /// </summary>
        public override XElement VisitNamespaceDeclaration(Microsoft.CodeAnalysis.CSharp.Syntax.NamespaceDeclarationSyntax node)
        {
    		var result = new XElement("NamespaceDeclaration");
    		var xNamespaceKeyword = new XElement("Token");
    		//xNamespaceKeyword.Add(new XAttribute("part", "NamespaceKeyword"));
    		result.Add(xNamespaceKeyword);
    		var xName = this.Visit(node.Name);
    		xName.Add(new XAttribute("part", "Name"));
    		result.Add(xName);
    		var xOpenBraceToken = new XElement("Token");
    		//xOpenBraceToken.Add(new XAttribute("part", "OpenBraceToken"));
    		result.Add(xOpenBraceToken);
    		var xExterns = new XElement("List_of_ExternAliasDirective");
    		xExterns.Add(new XAttribute("part", "Externs"));
    		foreach(var x in node.Externs)
    		{
    			xExterns.Add(this.Visit(x));
    		}
    		result.Add(xExterns);
    		var xUsings = new XElement("List_of_UsingDirective");
    		xUsings.Add(new XAttribute("part", "Usings"));
    		foreach(var x in node.Usings)
    		{
    			xUsings.Add(this.Visit(x));
    		}
    		result.Add(xUsings);
    		var xMembers = new XElement("List_of_MemberDeclaration");
    		xMembers.Add(new XAttribute("part", "Members"));
    		foreach(var x in node.Members)
    		{
    			xMembers.Add(this.Visit(x));
    		}
    		result.Add(xMembers);
    		var xCloseBraceToken = new XElement("Token");
    		//xCloseBraceToken.Add(new XAttribute("part", "CloseBraceToken"));
    		result.Add(xCloseBraceToken);
    		if(node.SemicolonToken != null)
    		{
    			var xSemicolonToken = new XElement("Token");
    		//	xSemicolonToken.Add(new XAttribute("part", "SemicolonToken"));
    			result.Add(xSemicolonToken);
    		}
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a EnumDeclarationSyntax node.
        /// </summary>
        public override XElement VisitEnumDeclaration(Microsoft.CodeAnalysis.CSharp.Syntax.EnumDeclarationSyntax node)
        {
    		var result = new XElement("EnumDeclaration");
    		var xAttributeLists = new XElement("List_of_AttributeList");
    		xAttributeLists.Add(new XAttribute("part", "AttributeLists"));
    		foreach(var x in node.AttributeLists)
    		{
    			xAttributeLists.Add(this.Visit(x));
    		}
    		result.Add(xAttributeLists);
    		var xModifiers = new XElement("TokenList");
    		xModifiers.Add(new XAttribute("part", "Modifiers"));
    		foreach(var x in node.Modifiers)
    		{
    			xModifiers.Add(new XText(x.ValueText));
    		}
    		result.Add(xModifiers);
    		var xEnumKeyword = new XElement("Token");
    		//xEnumKeyword.Add(new XAttribute("part", "EnumKeyword"));
    		result.Add(xEnumKeyword);
    		var xIdentifier = new XElement("Token");
    		//xIdentifier.Add(new XAttribute("part", "Identifier"));
    		result.Add(xIdentifier);
    		if(node.BaseList != null)
    		{
    			var xBaseList = this.Visit(node.BaseList);
    			xBaseList.Add(new XAttribute("part", "BaseList"));
    			result.Add(xBaseList);
    		}
    		var xOpenBraceToken = new XElement("Token");
    		//xOpenBraceToken.Add(new XAttribute("part", "OpenBraceToken"));
    		result.Add(xOpenBraceToken);
    		var xMembers = new XElement("SeparatedList_of_EnumMemberDeclaration");
    		xMembers.Add(new XAttribute("part", "Members"));
    		foreach(var x in node.Members)
    		{
    			xMembers.Add(this.Visit(x));
    		}
    		result.Add(xMembers);
    		var xCloseBraceToken = new XElement("Token");
    		//xCloseBraceToken.Add(new XAttribute("part", "CloseBraceToken"));
    		result.Add(xCloseBraceToken);
    		if(node.SemicolonToken != null)
    		{
    			var xSemicolonToken = new XElement("Token");
    		//	xSemicolonToken.Add(new XAttribute("part", "SemicolonToken"));
    			result.Add(xSemicolonToken);
    		}
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a ClassDeclarationSyntax node.
        /// </summary>
        public override XElement VisitClassDeclaration(Microsoft.CodeAnalysis.CSharp.Syntax.ClassDeclarationSyntax node)
        {
    		var result = new XElement("ClassDeclaration");
    		var xAttributeLists = new XElement("List_of_AttributeList");
    		xAttributeLists.Add(new XAttribute("part", "AttributeLists"));
    		foreach(var x in node.AttributeLists)
    		{
    			xAttributeLists.Add(this.Visit(x));
    		}
    		result.Add(xAttributeLists);
    		var xModifiers = new XElement("TokenList");
    		xModifiers.Add(new XAttribute("part", "Modifiers"));
    		foreach(var x in node.Modifiers)
    		{
    			xModifiers.Add(new XText(x.ValueText));
    		}
    		result.Add(xModifiers);
    		var xKeyword = new XElement("Token");
    		//xKeyword.Add(new XAttribute("part", "Keyword"));
    		result.Add(xKeyword);
    		var xIdentifier = new XElement("Token");
    		//xIdentifier.Add(new XAttribute("part", "Identifier"));
    		result.Add(xIdentifier);
    		if(node.TypeParameterList != null)
    		{
    			var xTypeParameterList = this.Visit(node.TypeParameterList);
    			xTypeParameterList.Add(new XAttribute("part", "TypeParameterList"));
    			result.Add(xTypeParameterList);
    		}
    		if(node.BaseList != null)
    		{
    			var xBaseList = this.Visit(node.BaseList);
    			xBaseList.Add(new XAttribute("part", "BaseList"));
    			result.Add(xBaseList);
    		}
    		var xConstraintClauses = new XElement("List_of_TypeParameterConstraintClause");
    		xConstraintClauses.Add(new XAttribute("part", "ConstraintClauses"));
    		foreach(var x in node.ConstraintClauses)
    		{
    			xConstraintClauses.Add(this.Visit(x));
    		}
    		result.Add(xConstraintClauses);
    		var xOpenBraceToken = new XElement("Token");
    		//xOpenBraceToken.Add(new XAttribute("part", "OpenBraceToken"));
    		result.Add(xOpenBraceToken);
    		var xMembers = new XElement("List_of_MemberDeclaration");
    		xMembers.Add(new XAttribute("part", "Members"));
    		foreach(var x in node.Members)
    		{
    			xMembers.Add(this.Visit(x));
    		}
    		result.Add(xMembers);
    		var xCloseBraceToken = new XElement("Token");
    		//xCloseBraceToken.Add(new XAttribute("part", "CloseBraceToken"));
    		result.Add(xCloseBraceToken);
    		if(node.SemicolonToken != null)
    		{
    			var xSemicolonToken = new XElement("Token");
    		//	xSemicolonToken.Add(new XAttribute("part", "SemicolonToken"));
    			result.Add(xSemicolonToken);
    		}
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a StructDeclarationSyntax node.
        /// </summary>
        public override XElement VisitStructDeclaration(Microsoft.CodeAnalysis.CSharp.Syntax.StructDeclarationSyntax node)
        {
    		var result = new XElement("StructDeclaration");
    		var xAttributeLists = new XElement("List_of_AttributeList");
    		xAttributeLists.Add(new XAttribute("part", "AttributeLists"));
    		foreach(var x in node.AttributeLists)
    		{
    			xAttributeLists.Add(this.Visit(x));
    		}
    		result.Add(xAttributeLists);
    		var xModifiers = new XElement("TokenList");
    		xModifiers.Add(new XAttribute("part", "Modifiers"));
    		foreach(var x in node.Modifiers)
    		{
    			xModifiers.Add(new XText(x.ValueText));
    		}
    		result.Add(xModifiers);
    		var xKeyword = new XElement("Token");
    		//xKeyword.Add(new XAttribute("part", "Keyword"));
    		result.Add(xKeyword);
    		var xIdentifier = new XElement("Token");
    		//xIdentifier.Add(new XAttribute("part", "Identifier"));
    		result.Add(xIdentifier);
    		if(node.TypeParameterList != null)
    		{
    			var xTypeParameterList = this.Visit(node.TypeParameterList);
    			xTypeParameterList.Add(new XAttribute("part", "TypeParameterList"));
    			result.Add(xTypeParameterList);
    		}
    		if(node.BaseList != null)
    		{
    			var xBaseList = this.Visit(node.BaseList);
    			xBaseList.Add(new XAttribute("part", "BaseList"));
    			result.Add(xBaseList);
    		}
    		var xConstraintClauses = new XElement("List_of_TypeParameterConstraintClause");
    		xConstraintClauses.Add(new XAttribute("part", "ConstraintClauses"));
    		foreach(var x in node.ConstraintClauses)
    		{
    			xConstraintClauses.Add(this.Visit(x));
    		}
    		result.Add(xConstraintClauses);
    		var xOpenBraceToken = new XElement("Token");
    		//xOpenBraceToken.Add(new XAttribute("part", "OpenBraceToken"));
    		result.Add(xOpenBraceToken);
    		var xMembers = new XElement("List_of_MemberDeclaration");
    		xMembers.Add(new XAttribute("part", "Members"));
    		foreach(var x in node.Members)
    		{
    			xMembers.Add(this.Visit(x));
    		}
    		result.Add(xMembers);
    		var xCloseBraceToken = new XElement("Token");
    		//xCloseBraceToken.Add(new XAttribute("part", "CloseBraceToken"));
    		result.Add(xCloseBraceToken);
    		if(node.SemicolonToken != null)
    		{
    			var xSemicolonToken = new XElement("Token");
    		//	xSemicolonToken.Add(new XAttribute("part", "SemicolonToken"));
    			result.Add(xSemicolonToken);
    		}
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a InterfaceDeclarationSyntax node.
        /// </summary>
        public override XElement VisitInterfaceDeclaration(Microsoft.CodeAnalysis.CSharp.Syntax.InterfaceDeclarationSyntax node)
        {
    		var result = new XElement("InterfaceDeclaration");
    		var xAttributeLists = new XElement("List_of_AttributeList");
    		xAttributeLists.Add(new XAttribute("part", "AttributeLists"));
    		foreach(var x in node.AttributeLists)
    		{
    			xAttributeLists.Add(this.Visit(x));
    		}
    		result.Add(xAttributeLists);
    		var xModifiers = new XElement("TokenList");
    		xModifiers.Add(new XAttribute("part", "Modifiers"));
    		foreach(var x in node.Modifiers)
    		{
    			xModifiers.Add(new XText(x.ValueText));
    		}
    		result.Add(xModifiers);
    		var xKeyword = new XElement("Token");
    		//xKeyword.Add(new XAttribute("part", "Keyword"));
    		result.Add(xKeyword);
    		var xIdentifier = new XElement("Token");
    		//xIdentifier.Add(new XAttribute("part", "Identifier"));
    		result.Add(xIdentifier);
    		if(node.TypeParameterList != null)
    		{
    			var xTypeParameterList = this.Visit(node.TypeParameterList);
    			xTypeParameterList.Add(new XAttribute("part", "TypeParameterList"));
    			result.Add(xTypeParameterList);
    		}
    		if(node.BaseList != null)
    		{
    			var xBaseList = this.Visit(node.BaseList);
    			xBaseList.Add(new XAttribute("part", "BaseList"));
    			result.Add(xBaseList);
    		}
    		var xConstraintClauses = new XElement("List_of_TypeParameterConstraintClause");
    		xConstraintClauses.Add(new XAttribute("part", "ConstraintClauses"));
    		foreach(var x in node.ConstraintClauses)
    		{
    			xConstraintClauses.Add(this.Visit(x));
    		}
    		result.Add(xConstraintClauses);
    		var xOpenBraceToken = new XElement("Token");
    		//xOpenBraceToken.Add(new XAttribute("part", "OpenBraceToken"));
    		result.Add(xOpenBraceToken);
    		var xMembers = new XElement("List_of_MemberDeclaration");
    		xMembers.Add(new XAttribute("part", "Members"));
    		foreach(var x in node.Members)
    		{
    			xMembers.Add(this.Visit(x));
    		}
    		result.Add(xMembers);
    		var xCloseBraceToken = new XElement("Token");
    		//xCloseBraceToken.Add(new XAttribute("part", "CloseBraceToken"));
    		result.Add(xCloseBraceToken);
    		if(node.SemicolonToken != null)
    		{
    			var xSemicolonToken = new XElement("Token");
    		//	xSemicolonToken.Add(new XAttribute("part", "SemicolonToken"));
    			result.Add(xSemicolonToken);
    		}
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a FieldDeclarationSyntax node.
        /// </summary>
        public override XElement VisitFieldDeclaration(Microsoft.CodeAnalysis.CSharp.Syntax.FieldDeclarationSyntax node)
        {
    		var result = new XElement("FieldDeclaration");
    		var xAttributeLists = new XElement("List_of_AttributeList");
    		xAttributeLists.Add(new XAttribute("part", "AttributeLists"));
    		foreach(var x in node.AttributeLists)
    		{
    			xAttributeLists.Add(this.Visit(x));
    		}
    		result.Add(xAttributeLists);
    		var xModifiers = new XElement("TokenList");
    		xModifiers.Add(new XAttribute("part", "Modifiers"));
    		foreach(var x in node.Modifiers)
    		{
    			xModifiers.Add(new XText(x.ValueText));
    		}
    		result.Add(xModifiers);
    		var xDeclaration = this.Visit(node.Declaration);
    		xDeclaration.Add(new XAttribute("part", "Declaration"));
    		result.Add(xDeclaration);
    		var xSemicolonToken = new XElement("Token");
    		//xSemicolonToken.Add(new XAttribute("part", "SemicolonToken"));
    		result.Add(xSemicolonToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a EventFieldDeclarationSyntax node.
        /// </summary>
        public override XElement VisitEventFieldDeclaration(Microsoft.CodeAnalysis.CSharp.Syntax.EventFieldDeclarationSyntax node)
        {
    		var result = new XElement("EventFieldDeclaration");
    		var xAttributeLists = new XElement("List_of_AttributeList");
    		xAttributeLists.Add(new XAttribute("part", "AttributeLists"));
    		foreach(var x in node.AttributeLists)
    		{
    			xAttributeLists.Add(this.Visit(x));
    		}
    		result.Add(xAttributeLists);
    		var xModifiers = new XElement("TokenList");
    		xModifiers.Add(new XAttribute("part", "Modifiers"));
    		foreach(var x in node.Modifiers)
    		{
    			xModifiers.Add(new XText(x.ValueText));
    		}
    		result.Add(xModifiers);
    		var xEventKeyword = new XElement("Token");
    		//xEventKeyword.Add(new XAttribute("part", "EventKeyword"));
    		result.Add(xEventKeyword);
    		var xDeclaration = this.Visit(node.Declaration);
    		xDeclaration.Add(new XAttribute("part", "Declaration"));
    		result.Add(xDeclaration);
    		var xSemicolonToken = new XElement("Token");
    		//xSemicolonToken.Add(new XAttribute("part", "SemicolonToken"));
    		result.Add(xSemicolonToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a MethodDeclarationSyntax node.
        /// </summary>
        public override XElement VisitMethodDeclaration(Microsoft.CodeAnalysis.CSharp.Syntax.MethodDeclarationSyntax node)
        {
    		var result = new XElement("MethodDeclaration");
    		var xAttributeLists = new XElement("List_of_AttributeList");
    		xAttributeLists.Add(new XAttribute("part", "AttributeLists"));
    		foreach(var x in node.AttributeLists)
    		{
    			xAttributeLists.Add(this.Visit(x));
    		}
    		result.Add(xAttributeLists);
    		var xModifiers = new XElement("TokenList");
    		xModifiers.Add(new XAttribute("part", "Modifiers"));
    		foreach(var x in node.Modifiers)
    		{
    			xModifiers.Add(new XText(x.ValueText));
    		}
    		result.Add(xModifiers);
    		var xReturnType = this.Visit(node.ReturnType);
    		xReturnType.Add(new XAttribute("part", "ReturnType"));
    		result.Add(xReturnType);
    		if(node.ExplicitInterfaceSpecifier != null)
    		{
    			var xExplicitInterfaceSpecifier = this.Visit(node.ExplicitInterfaceSpecifier);
    			xExplicitInterfaceSpecifier.Add(new XAttribute("part", "ExplicitInterfaceSpecifier"));
    			result.Add(xExplicitInterfaceSpecifier);
    		}
    		var xIdentifier = new XElement("Token");
    		//xIdentifier.Add(new XAttribute("part", "Identifier"));
    		result.Add(xIdentifier);
    		if(node.TypeParameterList != null)
    		{
    			var xTypeParameterList = this.Visit(node.TypeParameterList);
    			xTypeParameterList.Add(new XAttribute("part", "TypeParameterList"));
    			result.Add(xTypeParameterList);
    		}
    		var xParameterList = this.Visit(node.ParameterList);
    		xParameterList.Add(new XAttribute("part", "ParameterList"));
    		result.Add(xParameterList);
    		var xConstraintClauses = new XElement("List_of_TypeParameterConstraintClause");
    		xConstraintClauses.Add(new XAttribute("part", "ConstraintClauses"));
    		foreach(var x in node.ConstraintClauses)
    		{
    			xConstraintClauses.Add(this.Visit(x));
    		}
    		result.Add(xConstraintClauses);
    		if(node.Body != null)
    		{
    			var xBody = this.Visit(node.Body);
    			xBody.Add(new XAttribute("part", "Body"));
    			result.Add(xBody);
    		}
    		if(node.ExpressionBody != null)
    		{
    			var xExpressionBody = this.Visit(node.ExpressionBody);
    			xExpressionBody.Add(new XAttribute("part", "ExpressionBody"));
    			result.Add(xExpressionBody);
    		}
    		if(node.SemicolonToken != null)
    		{
    			var xSemicolonToken = new XElement("Token");
    		//	xSemicolonToken.Add(new XAttribute("part", "SemicolonToken"));
    			result.Add(xSemicolonToken);
    		}
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a OperatorDeclarationSyntax node.
        /// </summary>
        public override XElement VisitOperatorDeclaration(Microsoft.CodeAnalysis.CSharp.Syntax.OperatorDeclarationSyntax node)
        {
    		var result = new XElement("OperatorDeclaration");
    		var xAttributeLists = new XElement("List_of_AttributeList");
    		xAttributeLists.Add(new XAttribute("part", "AttributeLists"));
    		foreach(var x in node.AttributeLists)
    		{
    			xAttributeLists.Add(this.Visit(x));
    		}
    		result.Add(xAttributeLists);
    		var xModifiers = new XElement("TokenList");
    		xModifiers.Add(new XAttribute("part", "Modifiers"));
    		foreach(var x in node.Modifiers)
    		{
    			xModifiers.Add(new XText(x.ValueText));
    		}
    		result.Add(xModifiers);
    		var xReturnType = this.Visit(node.ReturnType);
    		xReturnType.Add(new XAttribute("part", "ReturnType"));
    		result.Add(xReturnType);
    		var xOperatorKeyword = new XElement("Token");
    		//xOperatorKeyword.Add(new XAttribute("part", "OperatorKeyword"));
    		result.Add(xOperatorKeyword);
    		var xOperatorToken = new XElement("Token");
    		//xOperatorToken.Add(new XAttribute("part", "OperatorToken"));
    		result.Add(xOperatorToken);
    		var xParameterList = this.Visit(node.ParameterList);
    		xParameterList.Add(new XAttribute("part", "ParameterList"));
    		result.Add(xParameterList);
    		if(node.Body != null)
    		{
    			var xBody = this.Visit(node.Body);
    			xBody.Add(new XAttribute("part", "Body"));
    			result.Add(xBody);
    		}
    		if(node.ExpressionBody != null)
    		{
    			var xExpressionBody = this.Visit(node.ExpressionBody);
    			xExpressionBody.Add(new XAttribute("part", "ExpressionBody"));
    			result.Add(xExpressionBody);
    		}
    		if(node.SemicolonToken != null)
    		{
    			var xSemicolonToken = new XElement("Token");
    		//	xSemicolonToken.Add(new XAttribute("part", "SemicolonToken"));
    			result.Add(xSemicolonToken);
    		}
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a ConversionOperatorDeclarationSyntax node.
        /// </summary>
        public override XElement VisitConversionOperatorDeclaration(Microsoft.CodeAnalysis.CSharp.Syntax.ConversionOperatorDeclarationSyntax node)
        {
    		var result = new XElement("ConversionOperatorDeclaration");
    		var xAttributeLists = new XElement("List_of_AttributeList");
    		xAttributeLists.Add(new XAttribute("part", "AttributeLists"));
    		foreach(var x in node.AttributeLists)
    		{
    			xAttributeLists.Add(this.Visit(x));
    		}
    		result.Add(xAttributeLists);
    		var xModifiers = new XElement("TokenList");
    		xModifiers.Add(new XAttribute("part", "Modifiers"));
    		foreach(var x in node.Modifiers)
    		{
    			xModifiers.Add(new XText(x.ValueText));
    		}
    		result.Add(xModifiers);
    		var xImplicitOrExplicitKeyword = new XElement("Token");
    		//xImplicitOrExplicitKeyword.Add(new XAttribute("part", "ImplicitOrExplicitKeyword"));
    		result.Add(xImplicitOrExplicitKeyword);
    		var xOperatorKeyword = new XElement("Token");
    		//xOperatorKeyword.Add(new XAttribute("part", "OperatorKeyword"));
    		result.Add(xOperatorKeyword);
    		var xType = this.Visit(node.Type);
    		xType.Add(new XAttribute("part", "Type"));
    		result.Add(xType);
    		var xParameterList = this.Visit(node.ParameterList);
    		xParameterList.Add(new XAttribute("part", "ParameterList"));
    		result.Add(xParameterList);
    		if(node.Body != null)
    		{
    			var xBody = this.Visit(node.Body);
    			xBody.Add(new XAttribute("part", "Body"));
    			result.Add(xBody);
    		}
    		if(node.ExpressionBody != null)
    		{
    			var xExpressionBody = this.Visit(node.ExpressionBody);
    			xExpressionBody.Add(new XAttribute("part", "ExpressionBody"));
    			result.Add(xExpressionBody);
    		}
    		if(node.SemicolonToken != null)
    		{
    			var xSemicolonToken = new XElement("Token");
    		//	xSemicolonToken.Add(new XAttribute("part", "SemicolonToken"));
    			result.Add(xSemicolonToken);
    		}
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a ConstructorDeclarationSyntax node.
        /// </summary>
        public override XElement VisitConstructorDeclaration(Microsoft.CodeAnalysis.CSharp.Syntax.ConstructorDeclarationSyntax node)
        {
    		var result = new XElement("ConstructorDeclaration");
    		var xAttributeLists = new XElement("List_of_AttributeList");
    		xAttributeLists.Add(new XAttribute("part", "AttributeLists"));
    		foreach(var x in node.AttributeLists)
    		{
    			xAttributeLists.Add(this.Visit(x));
    		}
    		result.Add(xAttributeLists);
    		var xModifiers = new XElement("TokenList");
    		xModifiers.Add(new XAttribute("part", "Modifiers"));
    		foreach(var x in node.Modifiers)
    		{
    			xModifiers.Add(new XText(x.ValueText));
    		}
    		result.Add(xModifiers);
    		var xIdentifier = new XElement("Token");
    		//xIdentifier.Add(new XAttribute("part", "Identifier"));
    		result.Add(xIdentifier);
    		var xParameterList = this.Visit(node.ParameterList);
    		xParameterList.Add(new XAttribute("part", "ParameterList"));
    		result.Add(xParameterList);
    		if(node.Initializer != null)
    		{
    			var xInitializer = this.Visit(node.Initializer);
    			xInitializer.Add(new XAttribute("part", "Initializer"));
    			result.Add(xInitializer);
    		}
    		if(node.Body != null)
    		{
    			var xBody = this.Visit(node.Body);
    			xBody.Add(new XAttribute("part", "Body"));
    			result.Add(xBody);
    		}
    		if(node.SemicolonToken != null)
    		{
    			var xSemicolonToken = new XElement("Token");
    		//	xSemicolonToken.Add(new XAttribute("part", "SemicolonToken"));
    			result.Add(xSemicolonToken);
    		}
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a DestructorDeclarationSyntax node.
        /// </summary>
        public override XElement VisitDestructorDeclaration(Microsoft.CodeAnalysis.CSharp.Syntax.DestructorDeclarationSyntax node)
        {
    		var result = new XElement("DestructorDeclaration");
    		var xAttributeLists = new XElement("List_of_AttributeList");
    		xAttributeLists.Add(new XAttribute("part", "AttributeLists"));
    		foreach(var x in node.AttributeLists)
    		{
    			xAttributeLists.Add(this.Visit(x));
    		}
    		result.Add(xAttributeLists);
    		var xModifiers = new XElement("TokenList");
    		xModifiers.Add(new XAttribute("part", "Modifiers"));
    		foreach(var x in node.Modifiers)
    		{
    			xModifiers.Add(new XText(x.ValueText));
    		}
    		result.Add(xModifiers);
    		var xTildeToken = new XElement("Token");
    		//xTildeToken.Add(new XAttribute("part", "TildeToken"));
    		result.Add(xTildeToken);
    		var xIdentifier = new XElement("Token");
    		//xIdentifier.Add(new XAttribute("part", "Identifier"));
    		result.Add(xIdentifier);
    		var xParameterList = this.Visit(node.ParameterList);
    		xParameterList.Add(new XAttribute("part", "ParameterList"));
    		result.Add(xParameterList);
    		if(node.Body != null)
    		{
    			var xBody = this.Visit(node.Body);
    			xBody.Add(new XAttribute("part", "Body"));
    			result.Add(xBody);
    		}
    		if(node.SemicolonToken != null)
    		{
    			var xSemicolonToken = new XElement("Token");
    		//	xSemicolonToken.Add(new XAttribute("part", "SemicolonToken"));
    			result.Add(xSemicolonToken);
    		}
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a PropertyDeclarationSyntax node.
        /// </summary>
        public override XElement VisitPropertyDeclaration(Microsoft.CodeAnalysis.CSharp.Syntax.PropertyDeclarationSyntax node)
        {
    		var result = new XElement("PropertyDeclaration");
    		var xAttributeLists = new XElement("List_of_AttributeList");
    		xAttributeLists.Add(new XAttribute("part", "AttributeLists"));
    		foreach(var x in node.AttributeLists)
    		{
    			xAttributeLists.Add(this.Visit(x));
    		}
    		result.Add(xAttributeLists);
    		var xModifiers = new XElement("TokenList");
    		xModifiers.Add(new XAttribute("part", "Modifiers"));
    		foreach(var x in node.Modifiers)
    		{
    			xModifiers.Add(new XText(x.ValueText));
    		}
    		result.Add(xModifiers);
    		var xType = this.Visit(node.Type);
    		xType.Add(new XAttribute("part", "Type"));
    		result.Add(xType);
    		if(node.ExplicitInterfaceSpecifier != null)
    		{
    			var xExplicitInterfaceSpecifier = this.Visit(node.ExplicitInterfaceSpecifier);
    			xExplicitInterfaceSpecifier.Add(new XAttribute("part", "ExplicitInterfaceSpecifier"));
    			result.Add(xExplicitInterfaceSpecifier);
    		}
    		var xIdentifier = new XElement("Token");
    		//xIdentifier.Add(new XAttribute("part", "Identifier"));
    		result.Add(xIdentifier);
    		if(node.AccessorList != null)
    		{
    			var xAccessorList = this.Visit(node.AccessorList);
    			xAccessorList.Add(new XAttribute("part", "AccessorList"));
    			result.Add(xAccessorList);
    		}
    		if(node.ExpressionBody != null)
    		{
    			var xExpressionBody = this.Visit(node.ExpressionBody);
    			xExpressionBody.Add(new XAttribute("part", "ExpressionBody"));
    			result.Add(xExpressionBody);
    		}
    		if(node.Initializer != null)
    		{
    			var xInitializer = this.Visit(node.Initializer);
    			xInitializer.Add(new XAttribute("part", "Initializer"));
    			result.Add(xInitializer);
    		}
    		if(node.SemicolonToken != null)
    		{
    			var xSemicolonToken = new XElement("Token");
    		//	xSemicolonToken.Add(new XAttribute("part", "SemicolonToken"));
    			result.Add(xSemicolonToken);
    		}
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a EventDeclarationSyntax node.
        /// </summary>
        public override XElement VisitEventDeclaration(Microsoft.CodeAnalysis.CSharp.Syntax.EventDeclarationSyntax node)
        {
    		var result = new XElement("EventDeclaration");
    		var xAttributeLists = new XElement("List_of_AttributeList");
    		xAttributeLists.Add(new XAttribute("part", "AttributeLists"));
    		foreach(var x in node.AttributeLists)
    		{
    			xAttributeLists.Add(this.Visit(x));
    		}
    		result.Add(xAttributeLists);
    		var xModifiers = new XElement("TokenList");
    		xModifiers.Add(new XAttribute("part", "Modifiers"));
    		foreach(var x in node.Modifiers)
    		{
    			xModifiers.Add(new XText(x.ValueText));
    		}
    		result.Add(xModifiers);
    		var xEventKeyword = new XElement("Token");
    		//xEventKeyword.Add(new XAttribute("part", "EventKeyword"));
    		result.Add(xEventKeyword);
    		var xType = this.Visit(node.Type);
    		xType.Add(new XAttribute("part", "Type"));
    		result.Add(xType);
    		if(node.ExplicitInterfaceSpecifier != null)
    		{
    			var xExplicitInterfaceSpecifier = this.Visit(node.ExplicitInterfaceSpecifier);
    			xExplicitInterfaceSpecifier.Add(new XAttribute("part", "ExplicitInterfaceSpecifier"));
    			result.Add(xExplicitInterfaceSpecifier);
    		}
    		var xIdentifier = new XElement("Token");
    		//xIdentifier.Add(new XAttribute("part", "Identifier"));
    		result.Add(xIdentifier);
    		var xAccessorList = this.Visit(node.AccessorList);
    		xAccessorList.Add(new XAttribute("part", "AccessorList"));
    		result.Add(xAccessorList);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a IndexerDeclarationSyntax node.
        /// </summary>
        public override XElement VisitIndexerDeclaration(Microsoft.CodeAnalysis.CSharp.Syntax.IndexerDeclarationSyntax node)
        {
    		var result = new XElement("IndexerDeclaration");
    		var xAttributeLists = new XElement("List_of_AttributeList");
    		xAttributeLists.Add(new XAttribute("part", "AttributeLists"));
    		foreach(var x in node.AttributeLists)
    		{
    			xAttributeLists.Add(this.Visit(x));
    		}
    		result.Add(xAttributeLists);
    		var xModifiers = new XElement("TokenList");
    		xModifiers.Add(new XAttribute("part", "Modifiers"));
    		foreach(var x in node.Modifiers)
    		{
    			xModifiers.Add(new XText(x.ValueText));
    		}
    		result.Add(xModifiers);
    		var xType = this.Visit(node.Type);
    		xType.Add(new XAttribute("part", "Type"));
    		result.Add(xType);
    		if(node.ExplicitInterfaceSpecifier != null)
    		{
    			var xExplicitInterfaceSpecifier = this.Visit(node.ExplicitInterfaceSpecifier);
    			xExplicitInterfaceSpecifier.Add(new XAttribute("part", "ExplicitInterfaceSpecifier"));
    			result.Add(xExplicitInterfaceSpecifier);
    		}
    		var xThisKeyword = new XElement("Token");
    		//xThisKeyword.Add(new XAttribute("part", "ThisKeyword"));
    		result.Add(xThisKeyword);
    		var xParameterList = this.Visit(node.ParameterList);
    		xParameterList.Add(new XAttribute("part", "ParameterList"));
    		result.Add(xParameterList);
    		if(node.AccessorList != null)
    		{
    			var xAccessorList = this.Visit(node.AccessorList);
    			xAccessorList.Add(new XAttribute("part", "AccessorList"));
    			result.Add(xAccessorList);
    		}
    		if(node.ExpressionBody != null)
    		{
    			var xExpressionBody = this.Visit(node.ExpressionBody);
    			xExpressionBody.Add(new XAttribute("part", "ExpressionBody"));
    			result.Add(xExpressionBody);
    		}
    		if(node.SemicolonToken != null)
    		{
    			var xSemicolonToken = new XElement("Token");
    		//	xSemicolonToken.Add(new XAttribute("part", "SemicolonToken"));
    			result.Add(xSemicolonToken);
    		}
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a SimpleBaseTypeSyntax node.
        /// </summary>
        public override XElement VisitSimpleBaseType(Microsoft.CodeAnalysis.CSharp.Syntax.SimpleBaseTypeSyntax node)
        {
    		var result = new XElement("SimpleBaseType");
    		var xType = this.Visit(node.Type);
    		xType.Add(new XAttribute("part", "Type"));
    		result.Add(xType);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a ConstructorConstraintSyntax node.
        /// </summary>
        public override XElement VisitConstructorConstraint(Microsoft.CodeAnalysis.CSharp.Syntax.ConstructorConstraintSyntax node)
        {
    		var result = new XElement("ConstructorConstraint");
    		var xNewKeyword = new XElement("Token");
    		//xNewKeyword.Add(new XAttribute("part", "NewKeyword"));
    		result.Add(xNewKeyword);
    		var xOpenParenToken = new XElement("Token");
    		//xOpenParenToken.Add(new XAttribute("part", "OpenParenToken"));
    		result.Add(xOpenParenToken);
    		var xCloseParenToken = new XElement("Token");
    		//xCloseParenToken.Add(new XAttribute("part", "CloseParenToken"));
    		result.Add(xCloseParenToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a ClassOrStructConstraintSyntax node.
        /// </summary>
        public override XElement VisitClassOrStructConstraint(Microsoft.CodeAnalysis.CSharp.Syntax.ClassOrStructConstraintSyntax node)
        {
    		var result = new XElement("ClassOrStructConstraint");
    		var xClassOrStructKeyword = new XElement("Token");
    		//xClassOrStructKeyword.Add(new XAttribute("part", "ClassOrStructKeyword"));
    		result.Add(xClassOrStructKeyword);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a TypeConstraintSyntax node.
        /// </summary>
        public override XElement VisitTypeConstraint(Microsoft.CodeAnalysis.CSharp.Syntax.TypeConstraintSyntax node)
        {
    		var result = new XElement("TypeConstraint");
    		var xType = this.Visit(node.Type);
    		xType.Add(new XAttribute("part", "Type"));
    		result.Add(xType);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a ParameterListSyntax node.
        /// </summary>
        public override XElement VisitParameterList(Microsoft.CodeAnalysis.CSharp.Syntax.ParameterListSyntax node)
        {
    		var result = new XElement("ParameterList");
    		var xOpenParenToken = new XElement("Token");
    		//xOpenParenToken.Add(new XAttribute("part", "OpenParenToken"));
    		result.Add(xOpenParenToken);
    		var xParameters = new XElement("SeparatedList_of_Parameter");
    		xParameters.Add(new XAttribute("part", "Parameters"));
    		foreach(var x in node.Parameters)
    		{
    			xParameters.Add(this.Visit(x));
    		}
    		result.Add(xParameters);
    		var xCloseParenToken = new XElement("Token");
    		//xCloseParenToken.Add(new XAttribute("part", "CloseParenToken"));
    		result.Add(xCloseParenToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a BracketedParameterListSyntax node.
        /// </summary>
        public override XElement VisitBracketedParameterList(Microsoft.CodeAnalysis.CSharp.Syntax.BracketedParameterListSyntax node)
        {
    		var result = new XElement("BracketedParameterList");
    		var xOpenBracketToken = new XElement("Token");
    		//xOpenBracketToken.Add(new XAttribute("part", "OpenBracketToken"));
    		result.Add(xOpenBracketToken);
    		var xParameters = new XElement("SeparatedList_of_Parameter");
    		xParameters.Add(new XAttribute("part", "Parameters"));
    		foreach(var x in node.Parameters)
    		{
    			xParameters.Add(this.Visit(x));
    		}
    		result.Add(xParameters);
    		var xCloseBracketToken = new XElement("Token");
    		//xCloseBracketToken.Add(new XAttribute("part", "CloseBracketToken"));
    		result.Add(xCloseBracketToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a SkippedTokensTriviaSyntax node.
        /// </summary>
        public override XElement VisitSkippedTokensTrivia(Microsoft.CodeAnalysis.CSharp.Syntax.SkippedTokensTriviaSyntax node)
        {
    		var result = new XElement("SkippedTokensTrivia");
    		var xTokens = new XElement("TokenList");
    		xTokens.Add(new XAttribute("part", "Tokens"));
    		foreach(var x in node.Tokens)
    		{
    			xTokens.Add(new XText(x.ValueText));
    		}
    		result.Add(xTokens);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a DocumentationCommentTriviaSyntax node.
        /// </summary>
        public override XElement VisitDocumentationCommentTrivia(Microsoft.CodeAnalysis.CSharp.Syntax.DocumentationCommentTriviaSyntax node)
        {
    		var result = new XElement("DocumentationCommentTrivia");
    		var xContent = new XElement("List_of_XmlNode");
    		xContent.Add(new XAttribute("part", "Content"));
    		foreach(var x in node.Content)
    		{
    			xContent.Add(this.Visit(x));
    		}
    		result.Add(xContent);
    		var xEndOfComment = new XElement("Token");
    		//xEndOfComment.Add(new XAttribute("part", "EndOfComment"));
    		result.Add(xEndOfComment);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a EndIfDirectiveTriviaSyntax node.
        /// </summary>
        public override XElement VisitEndIfDirectiveTrivia(Microsoft.CodeAnalysis.CSharp.Syntax.EndIfDirectiveTriviaSyntax node)
        {
    		var result = new XElement("EndIfDirectiveTrivia");
    		var xHashToken = new XElement("Token");
    		//xHashToken.Add(new XAttribute("part", "HashToken"));
    		result.Add(xHashToken);
    		var xEndIfKeyword = new XElement("Token");
    		//xEndIfKeyword.Add(new XAttribute("part", "EndIfKeyword"));
    		result.Add(xEndIfKeyword);
    		var xEndOfDirectiveToken = new XElement("Token");
    		//xEndOfDirectiveToken.Add(new XAttribute("part", "EndOfDirectiveToken"));
    		result.Add(xEndOfDirectiveToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a RegionDirectiveTriviaSyntax node.
        /// </summary>
        public override XElement VisitRegionDirectiveTrivia(Microsoft.CodeAnalysis.CSharp.Syntax.RegionDirectiveTriviaSyntax node)
        {
    		var result = new XElement("RegionDirectiveTrivia");
    		var xHashToken = new XElement("Token");
    		//xHashToken.Add(new XAttribute("part", "HashToken"));
    		result.Add(xHashToken);
    		var xRegionKeyword = new XElement("Token");
    		//xRegionKeyword.Add(new XAttribute("part", "RegionKeyword"));
    		result.Add(xRegionKeyword);
    		var xEndOfDirectiveToken = new XElement("Token");
    		//xEndOfDirectiveToken.Add(new XAttribute("part", "EndOfDirectiveToken"));
    		result.Add(xEndOfDirectiveToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a EndRegionDirectiveTriviaSyntax node.
        /// </summary>
        public override XElement VisitEndRegionDirectiveTrivia(Microsoft.CodeAnalysis.CSharp.Syntax.EndRegionDirectiveTriviaSyntax node)
        {
    		var result = new XElement("EndRegionDirectiveTrivia");
    		var xHashToken = new XElement("Token");
    		//xHashToken.Add(new XAttribute("part", "HashToken"));
    		result.Add(xHashToken);
    		var xEndRegionKeyword = new XElement("Token");
    		//xEndRegionKeyword.Add(new XAttribute("part", "EndRegionKeyword"));
    		result.Add(xEndRegionKeyword);
    		var xEndOfDirectiveToken = new XElement("Token");
    		//xEndOfDirectiveToken.Add(new XAttribute("part", "EndOfDirectiveToken"));
    		result.Add(xEndOfDirectiveToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a ErrorDirectiveTriviaSyntax node.
        /// </summary>
        public override XElement VisitErrorDirectiveTrivia(Microsoft.CodeAnalysis.CSharp.Syntax.ErrorDirectiveTriviaSyntax node)
        {
    		var result = new XElement("ErrorDirectiveTrivia");
    		var xHashToken = new XElement("Token");
    		//xHashToken.Add(new XAttribute("part", "HashToken"));
    		result.Add(xHashToken);
    		var xErrorKeyword = new XElement("Token");
    		//xErrorKeyword.Add(new XAttribute("part", "ErrorKeyword"));
    		result.Add(xErrorKeyword);
    		var xEndOfDirectiveToken = new XElement("Token");
    		//xEndOfDirectiveToken.Add(new XAttribute("part", "EndOfDirectiveToken"));
    		result.Add(xEndOfDirectiveToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a WarningDirectiveTriviaSyntax node.
        /// </summary>
        public override XElement VisitWarningDirectiveTrivia(Microsoft.CodeAnalysis.CSharp.Syntax.WarningDirectiveTriviaSyntax node)
        {
    		var result = new XElement("WarningDirectiveTrivia");
    		var xHashToken = new XElement("Token");
    		//xHashToken.Add(new XAttribute("part", "HashToken"));
    		result.Add(xHashToken);
    		var xWarningKeyword = new XElement("Token");
    		//xWarningKeyword.Add(new XAttribute("part", "WarningKeyword"));
    		result.Add(xWarningKeyword);
    		var xEndOfDirectiveToken = new XElement("Token");
    		//xEndOfDirectiveToken.Add(new XAttribute("part", "EndOfDirectiveToken"));
    		result.Add(xEndOfDirectiveToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a BadDirectiveTriviaSyntax node.
        /// </summary>
        public override XElement VisitBadDirectiveTrivia(Microsoft.CodeAnalysis.CSharp.Syntax.BadDirectiveTriviaSyntax node)
        {
    		var result = new XElement("BadDirectiveTrivia");
    		var xHashToken = new XElement("Token");
    		//xHashToken.Add(new XAttribute("part", "HashToken"));
    		result.Add(xHashToken);
    		var xIdentifier = new XElement("Token");
    		//xIdentifier.Add(new XAttribute("part", "Identifier"));
    		result.Add(xIdentifier);
    		var xEndOfDirectiveToken = new XElement("Token");
    		//xEndOfDirectiveToken.Add(new XAttribute("part", "EndOfDirectiveToken"));
    		result.Add(xEndOfDirectiveToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a DefineDirectiveTriviaSyntax node.
        /// </summary>
        public override XElement VisitDefineDirectiveTrivia(Microsoft.CodeAnalysis.CSharp.Syntax.DefineDirectiveTriviaSyntax node)
        {
    		var result = new XElement("DefineDirectiveTrivia");
    		var xHashToken = new XElement("Token");
    		//xHashToken.Add(new XAttribute("part", "HashToken"));
    		result.Add(xHashToken);
    		var xDefineKeyword = new XElement("Token");
    		//xDefineKeyword.Add(new XAttribute("part", "DefineKeyword"));
    		result.Add(xDefineKeyword);
    		var xName = new XElement("Token");
    		//xName.Add(new XAttribute("part", "Name"));
    		result.Add(xName);
    		var xEndOfDirectiveToken = new XElement("Token");
    		//xEndOfDirectiveToken.Add(new XAttribute("part", "EndOfDirectiveToken"));
    		result.Add(xEndOfDirectiveToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a UndefDirectiveTriviaSyntax node.
        /// </summary>
        public override XElement VisitUndefDirectiveTrivia(Microsoft.CodeAnalysis.CSharp.Syntax.UndefDirectiveTriviaSyntax node)
        {
    		var result = new XElement("UndefDirectiveTrivia");
    		var xHashToken = new XElement("Token");
    		//xHashToken.Add(new XAttribute("part", "HashToken"));
    		result.Add(xHashToken);
    		var xUndefKeyword = new XElement("Token");
    		//xUndefKeyword.Add(new XAttribute("part", "UndefKeyword"));
    		result.Add(xUndefKeyword);
    		var xName = new XElement("Token");
    		//xName.Add(new XAttribute("part", "Name"));
    		result.Add(xName);
    		var xEndOfDirectiveToken = new XElement("Token");
    		//xEndOfDirectiveToken.Add(new XAttribute("part", "EndOfDirectiveToken"));
    		result.Add(xEndOfDirectiveToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a LineDirectiveTriviaSyntax node.
        /// </summary>
        public override XElement VisitLineDirectiveTrivia(Microsoft.CodeAnalysis.CSharp.Syntax.LineDirectiveTriviaSyntax node)
        {
    		var result = new XElement("LineDirectiveTrivia");
    		var xHashToken = new XElement("Token");
    		//xHashToken.Add(new XAttribute("part", "HashToken"));
    		result.Add(xHashToken);
    		var xLineKeyword = new XElement("Token");
    		//xLineKeyword.Add(new XAttribute("part", "LineKeyword"));
    		result.Add(xLineKeyword);
    		var xLine = new XElement("Token");
    		//xLine.Add(new XAttribute("part", "Line"));
    		result.Add(xLine);
    		if(node.File != null)
    		{
    			var xFile = new XElement("Token");
    		//	xFile.Add(new XAttribute("part", "File"));
    			result.Add(xFile);
    		}
    		var xEndOfDirectiveToken = new XElement("Token");
    		//xEndOfDirectiveToken.Add(new XAttribute("part", "EndOfDirectiveToken"));
    		result.Add(xEndOfDirectiveToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a PragmaWarningDirectiveTriviaSyntax node.
        /// </summary>
        public override XElement VisitPragmaWarningDirectiveTrivia(Microsoft.CodeAnalysis.CSharp.Syntax.PragmaWarningDirectiveTriviaSyntax node)
        {
    		var result = new XElement("PragmaWarningDirectiveTrivia");
    		var xHashToken = new XElement("Token");
    		//xHashToken.Add(new XAttribute("part", "HashToken"));
    		result.Add(xHashToken);
    		var xPragmaKeyword = new XElement("Token");
    		//xPragmaKeyword.Add(new XAttribute("part", "PragmaKeyword"));
    		result.Add(xPragmaKeyword);
    		var xWarningKeyword = new XElement("Token");
    		//xWarningKeyword.Add(new XAttribute("part", "WarningKeyword"));
    		result.Add(xWarningKeyword);
    		var xDisableOrRestoreKeyword = new XElement("Token");
    		//xDisableOrRestoreKeyword.Add(new XAttribute("part", "DisableOrRestoreKeyword"));
    		result.Add(xDisableOrRestoreKeyword);
    		var xErrorCodes = new XElement("SeparatedList_of_Expression");
    		xErrorCodes.Add(new XAttribute("part", "ErrorCodes"));
    		foreach(var x in node.ErrorCodes)
    		{
    			xErrorCodes.Add(this.Visit(x));
    		}
    		result.Add(xErrorCodes);
    		var xEndOfDirectiveToken = new XElement("Token");
    		//xEndOfDirectiveToken.Add(new XAttribute("part", "EndOfDirectiveToken"));
    		result.Add(xEndOfDirectiveToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a PragmaChecksumDirectiveTriviaSyntax node.
        /// </summary>
        public override XElement VisitPragmaChecksumDirectiveTrivia(Microsoft.CodeAnalysis.CSharp.Syntax.PragmaChecksumDirectiveTriviaSyntax node)
        {
    		var result = new XElement("PragmaChecksumDirectiveTrivia");
    		var xHashToken = new XElement("Token");
    		//xHashToken.Add(new XAttribute("part", "HashToken"));
    		result.Add(xHashToken);
    		var xPragmaKeyword = new XElement("Token");
    		//xPragmaKeyword.Add(new XAttribute("part", "PragmaKeyword"));
    		result.Add(xPragmaKeyword);
    		var xChecksumKeyword = new XElement("Token");
    		//xChecksumKeyword.Add(new XAttribute("part", "ChecksumKeyword"));
    		result.Add(xChecksumKeyword);
    		var xFile = new XElement("Token");
    		//xFile.Add(new XAttribute("part", "File"));
    		result.Add(xFile);
    		var xGuid = new XElement("Token");
    		//xGuid.Add(new XAttribute("part", "Guid"));
    		result.Add(xGuid);
    		var xBytes = new XElement("Token");
    		//xBytes.Add(new XAttribute("part", "Bytes"));
    		result.Add(xBytes);
    		var xEndOfDirectiveToken = new XElement("Token");
    		//xEndOfDirectiveToken.Add(new XAttribute("part", "EndOfDirectiveToken"));
    		result.Add(xEndOfDirectiveToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a ReferenceDirectiveTriviaSyntax node.
        /// </summary>
        public override XElement VisitReferenceDirectiveTrivia(Microsoft.CodeAnalysis.CSharp.Syntax.ReferenceDirectiveTriviaSyntax node)
        {
    		var result = new XElement("ReferenceDirectiveTrivia");
    		var xHashToken = new XElement("Token");
    		//xHashToken.Add(new XAttribute("part", "HashToken"));
    		result.Add(xHashToken);
    		var xReferenceKeyword = new XElement("Token");
    		//xReferenceKeyword.Add(new XAttribute("part", "ReferenceKeyword"));
    		result.Add(xReferenceKeyword);
    		var xFile = new XElement("Token");
    		//xFile.Add(new XAttribute("part", "File"));
    		result.Add(xFile);
    		var xEndOfDirectiveToken = new XElement("Token");
    		//xEndOfDirectiveToken.Add(new XAttribute("part", "EndOfDirectiveToken"));
    		result.Add(xEndOfDirectiveToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a LoadDirectiveTriviaSyntax node.
        /// </summary>
        public override XElement VisitLoadDirectiveTrivia(Microsoft.CodeAnalysis.CSharp.Syntax.LoadDirectiveTriviaSyntax node)
        {
    		var result = new XElement("LoadDirectiveTrivia");
    		var xHashToken = new XElement("Token");
    		//xHashToken.Add(new XAttribute("part", "HashToken"));
    		result.Add(xHashToken);
    		var xLoadKeyword = new XElement("Token");
    		//xLoadKeyword.Add(new XAttribute("part", "LoadKeyword"));
    		result.Add(xLoadKeyword);
    		var xFile = new XElement("Token");
    		//xFile.Add(new XAttribute("part", "File"));
    		result.Add(xFile);
    		var xEndOfDirectiveToken = new XElement("Token");
    		//xEndOfDirectiveToken.Add(new XAttribute("part", "EndOfDirectiveToken"));
    		result.Add(xEndOfDirectiveToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a ShebangDirectiveTriviaSyntax node.
        /// </summary>
        public override XElement VisitShebangDirectiveTrivia(Microsoft.CodeAnalysis.CSharp.Syntax.ShebangDirectiveTriviaSyntax node)
        {
    		var result = new XElement("ShebangDirectiveTrivia");
    		var xHashToken = new XElement("Token");
    		//xHashToken.Add(new XAttribute("part", "HashToken"));
    		result.Add(xHashToken);
    		var xExclamationToken = new XElement("Token");
    		//xExclamationToken.Add(new XAttribute("part", "ExclamationToken"));
    		result.Add(xExclamationToken);
    		var xEndOfDirectiveToken = new XElement("Token");
    		//xEndOfDirectiveToken.Add(new XAttribute("part", "EndOfDirectiveToken"));
    		result.Add(xEndOfDirectiveToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a ElseDirectiveTriviaSyntax node.
        /// </summary>
        public override XElement VisitElseDirectiveTrivia(Microsoft.CodeAnalysis.CSharp.Syntax.ElseDirectiveTriviaSyntax node)
        {
    		var result = new XElement("ElseDirectiveTrivia");
    		var xHashToken = new XElement("Token");
    		//xHashToken.Add(new XAttribute("part", "HashToken"));
    		result.Add(xHashToken);
    		var xElseKeyword = new XElement("Token");
    		//xElseKeyword.Add(new XAttribute("part", "ElseKeyword"));
    		result.Add(xElseKeyword);
    		var xEndOfDirectiveToken = new XElement("Token");
    		//xEndOfDirectiveToken.Add(new XAttribute("part", "EndOfDirectiveToken"));
    		result.Add(xEndOfDirectiveToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a IfDirectiveTriviaSyntax node.
        /// </summary>
        public override XElement VisitIfDirectiveTrivia(Microsoft.CodeAnalysis.CSharp.Syntax.IfDirectiveTriviaSyntax node)
        {
    		var result = new XElement("IfDirectiveTrivia");
    		var xHashToken = new XElement("Token");
    		//xHashToken.Add(new XAttribute("part", "HashToken"));
    		result.Add(xHashToken);
    		var xIfKeyword = new XElement("Token");
    		//xIfKeyword.Add(new XAttribute("part", "IfKeyword"));
    		result.Add(xIfKeyword);
    		var xCondition = this.Visit(node.Condition);
    		xCondition.Add(new XAttribute("part", "Condition"));
    		result.Add(xCondition);
    		var xEndOfDirectiveToken = new XElement("Token");
    		//xEndOfDirectiveToken.Add(new XAttribute("part", "EndOfDirectiveToken"));
    		result.Add(xEndOfDirectiveToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a ElifDirectiveTriviaSyntax node.
        /// </summary>
        public override XElement VisitElifDirectiveTrivia(Microsoft.CodeAnalysis.CSharp.Syntax.ElifDirectiveTriviaSyntax node)
        {
    		var result = new XElement("ElifDirectiveTrivia");
    		var xHashToken = new XElement("Token");
    		//xHashToken.Add(new XAttribute("part", "HashToken"));
    		result.Add(xHashToken);
    		var xElifKeyword = new XElement("Token");
    		//xElifKeyword.Add(new XAttribute("part", "ElifKeyword"));
    		result.Add(xElifKeyword);
    		var xCondition = this.Visit(node.Condition);
    		xCondition.Add(new XAttribute("part", "Condition"));
    		result.Add(xCondition);
    		var xEndOfDirectiveToken = new XElement("Token");
    		//xEndOfDirectiveToken.Add(new XAttribute("part", "EndOfDirectiveToken"));
    		result.Add(xEndOfDirectiveToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a TypeCrefSyntax node.
        /// </summary>
        public override XElement VisitTypeCref(Microsoft.CodeAnalysis.CSharp.Syntax.TypeCrefSyntax node)
        {
    		var result = new XElement("TypeCref");
    		var xType = this.Visit(node.Type);
    		xType.Add(new XAttribute("part", "Type"));
    		result.Add(xType);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a QualifiedCrefSyntax node.
        /// </summary>
        public override XElement VisitQualifiedCref(Microsoft.CodeAnalysis.CSharp.Syntax.QualifiedCrefSyntax node)
        {
    		var result = new XElement("QualifiedCref");
    		var xContainer = this.Visit(node.Container);
    		xContainer.Add(new XAttribute("part", "Container"));
    		result.Add(xContainer);
    		var xDotToken = new XElement("Token");
    		//xDotToken.Add(new XAttribute("part", "DotToken"));
    		result.Add(xDotToken);
    		var xMember = this.Visit(node.Member);
    		xMember.Add(new XAttribute("part", "Member"));
    		result.Add(xMember);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a NameMemberCrefSyntax node.
        /// </summary>
        public override XElement VisitNameMemberCref(Microsoft.CodeAnalysis.CSharp.Syntax.NameMemberCrefSyntax node)
        {
    		var result = new XElement("NameMemberCref");
    		var xName = this.Visit(node.Name);
    		xName.Add(new XAttribute("part", "Name"));
    		result.Add(xName);
    		if(node.Parameters != null)
    		{
    			var xParameters = this.Visit(node.Parameters);
    			xParameters.Add(new XAttribute("part", "Parameters"));
    			result.Add(xParameters);
    		}
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a IndexerMemberCrefSyntax node.
        /// </summary>
        public override XElement VisitIndexerMemberCref(Microsoft.CodeAnalysis.CSharp.Syntax.IndexerMemberCrefSyntax node)
        {
    		var result = new XElement("IndexerMemberCref");
    		var xThisKeyword = new XElement("Token");
    		//xThisKeyword.Add(new XAttribute("part", "ThisKeyword"));
    		result.Add(xThisKeyword);
    		if(node.Parameters != null)
    		{
    			var xParameters = this.Visit(node.Parameters);
    			xParameters.Add(new XAttribute("part", "Parameters"));
    			result.Add(xParameters);
    		}
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a OperatorMemberCrefSyntax node.
        /// </summary>
        public override XElement VisitOperatorMemberCref(Microsoft.CodeAnalysis.CSharp.Syntax.OperatorMemberCrefSyntax node)
        {
    		var result = new XElement("OperatorMemberCref");
    		var xOperatorKeyword = new XElement("Token");
    		//xOperatorKeyword.Add(new XAttribute("part", "OperatorKeyword"));
    		result.Add(xOperatorKeyword);
    		var xOperatorToken = new XElement("Token");
    		//xOperatorToken.Add(new XAttribute("part", "OperatorToken"));
    		result.Add(xOperatorToken);
    		if(node.Parameters != null)
    		{
    			var xParameters = this.Visit(node.Parameters);
    			xParameters.Add(new XAttribute("part", "Parameters"));
    			result.Add(xParameters);
    		}
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a ConversionOperatorMemberCrefSyntax node.
        /// </summary>
        public override XElement VisitConversionOperatorMemberCref(Microsoft.CodeAnalysis.CSharp.Syntax.ConversionOperatorMemberCrefSyntax node)
        {
    		var result = new XElement("ConversionOperatorMemberCref");
    		var xImplicitOrExplicitKeyword = new XElement("Token");
    		//xImplicitOrExplicitKeyword.Add(new XAttribute("part", "ImplicitOrExplicitKeyword"));
    		result.Add(xImplicitOrExplicitKeyword);
    		var xOperatorKeyword = new XElement("Token");
    		//xOperatorKeyword.Add(new XAttribute("part", "OperatorKeyword"));
    		result.Add(xOperatorKeyword);
    		var xType = this.Visit(node.Type);
    		xType.Add(new XAttribute("part", "Type"));
    		result.Add(xType);
    		if(node.Parameters != null)
    		{
    			var xParameters = this.Visit(node.Parameters);
    			xParameters.Add(new XAttribute("part", "Parameters"));
    			result.Add(xParameters);
    		}
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a CrefParameterListSyntax node.
        /// </summary>
        public override XElement VisitCrefParameterList(Microsoft.CodeAnalysis.CSharp.Syntax.CrefParameterListSyntax node)
        {
    		var result = new XElement("CrefParameterList");
    		var xOpenParenToken = new XElement("Token");
    		//xOpenParenToken.Add(new XAttribute("part", "OpenParenToken"));
    		result.Add(xOpenParenToken);
    		var xParameters = new XElement("SeparatedList_of_CrefParameter");
    		xParameters.Add(new XAttribute("part", "Parameters"));
    		foreach(var x in node.Parameters)
    		{
    			xParameters.Add(this.Visit(x));
    		}
    		result.Add(xParameters);
    		var xCloseParenToken = new XElement("Token");
    		//xCloseParenToken.Add(new XAttribute("part", "CloseParenToken"));
    		result.Add(xCloseParenToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a CrefBracketedParameterListSyntax node.
        /// </summary>
        public override XElement VisitCrefBracketedParameterList(Microsoft.CodeAnalysis.CSharp.Syntax.CrefBracketedParameterListSyntax node)
        {
    		var result = new XElement("CrefBracketedParameterList");
    		var xOpenBracketToken = new XElement("Token");
    		//xOpenBracketToken.Add(new XAttribute("part", "OpenBracketToken"));
    		result.Add(xOpenBracketToken);
    		var xParameters = new XElement("SeparatedList_of_CrefParameter");
    		xParameters.Add(new XAttribute("part", "Parameters"));
    		foreach(var x in node.Parameters)
    		{
    			xParameters.Add(this.Visit(x));
    		}
    		result.Add(xParameters);
    		var xCloseBracketToken = new XElement("Token");
    		//xCloseBracketToken.Add(new XAttribute("part", "CloseBracketToken"));
    		result.Add(xCloseBracketToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a XmlElementSyntax node.
        /// </summary>
        public override XElement VisitXmlElement(Microsoft.CodeAnalysis.CSharp.Syntax.XmlElementSyntax node)
        {
    		var result = new XElement("XmlElement");
    		var xStartTag = this.Visit(node.StartTag);
    		xStartTag.Add(new XAttribute("part", "StartTag"));
    		result.Add(xStartTag);
    		var xContent = new XElement("List_of_XmlNode");
    		xContent.Add(new XAttribute("part", "Content"));
    		foreach(var x in node.Content)
    		{
    			xContent.Add(this.Visit(x));
    		}
    		result.Add(xContent);
    		var xEndTag = this.Visit(node.EndTag);
    		xEndTag.Add(new XAttribute("part", "EndTag"));
    		result.Add(xEndTag);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a XmlEmptyElementSyntax node.
        /// </summary>
        public override XElement VisitXmlEmptyElement(Microsoft.CodeAnalysis.CSharp.Syntax.XmlEmptyElementSyntax node)
        {
    		var result = new XElement("XmlEmptyElement");
    		var xLessThanToken = new XElement("Token");
    		//xLessThanToken.Add(new XAttribute("part", "LessThanToken"));
    		result.Add(xLessThanToken);
    		var xName = this.Visit(node.Name);
    		xName.Add(new XAttribute("part", "Name"));
    		result.Add(xName);
    		var xAttributes = new XElement("List_of_XmlAttribute");
    		xAttributes.Add(new XAttribute("part", "Attributes"));
    		foreach(var x in node.Attributes)
    		{
    			xAttributes.Add(this.Visit(x));
    		}
    		result.Add(xAttributes);
    		var xSlashGreaterThanToken = new XElement("Token");
    		//xSlashGreaterThanToken.Add(new XAttribute("part", "SlashGreaterThanToken"));
    		result.Add(xSlashGreaterThanToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a XmlTextSyntax node.
        /// </summary>
        public override XElement VisitXmlText(Microsoft.CodeAnalysis.CSharp.Syntax.XmlTextSyntax node)
        {
    		var result = new XElement("XmlText");
    		var xTextTokens = new XElement("TokenList");
    		xTextTokens.Add(new XAttribute("part", "TextTokens"));
    		foreach(var x in node.TextTokens)
    		{
    			xTextTokens.Add(new XText(x.ValueText));
    		}
    		result.Add(xTextTokens);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a XmlCDataSectionSyntax node.
        /// </summary>
        public override XElement VisitXmlCDataSection(Microsoft.CodeAnalysis.CSharp.Syntax.XmlCDataSectionSyntax node)
        {
    		var result = new XElement("XmlCDataSection");
    		var xStartCDataToken = new XElement("Token");
    		//xStartCDataToken.Add(new XAttribute("part", "StartCDataToken"));
    		result.Add(xStartCDataToken);
    		var xTextTokens = new XElement("TokenList");
    		xTextTokens.Add(new XAttribute("part", "TextTokens"));
    		foreach(var x in node.TextTokens)
    		{
    			xTextTokens.Add(new XText(x.ValueText));
    		}
    		result.Add(xTextTokens);
    		var xEndCDataToken = new XElement("Token");
    		//xEndCDataToken.Add(new XAttribute("part", "EndCDataToken"));
    		result.Add(xEndCDataToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a XmlProcessingInstructionSyntax node.
        /// </summary>
        public override XElement VisitXmlProcessingInstruction(Microsoft.CodeAnalysis.CSharp.Syntax.XmlProcessingInstructionSyntax node)
        {
    		var result = new XElement("XmlProcessingInstruction");
    		var xStartProcessingInstructionToken = new XElement("Token");
    		//xStartProcessingInstructionToken.Add(new XAttribute("part", "StartProcessingInstructionToken"));
    		result.Add(xStartProcessingInstructionToken);
    		var xName = this.Visit(node.Name);
    		xName.Add(new XAttribute("part", "Name"));
    		result.Add(xName);
    		var xTextTokens = new XElement("TokenList");
    		xTextTokens.Add(new XAttribute("part", "TextTokens"));
    		foreach(var x in node.TextTokens)
    		{
    			xTextTokens.Add(new XText(x.ValueText));
    		}
    		result.Add(xTextTokens);
    		var xEndProcessingInstructionToken = new XElement("Token");
    		//xEndProcessingInstructionToken.Add(new XAttribute("part", "EndProcessingInstructionToken"));
    		result.Add(xEndProcessingInstructionToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a XmlCommentSyntax node.
        /// </summary>
        public override XElement VisitXmlComment(Microsoft.CodeAnalysis.CSharp.Syntax.XmlCommentSyntax node)
        {
    		var result = new XElement("XmlComment");
    		var xLessThanExclamationMinusMinusToken = new XElement("Token");
    		//xLessThanExclamationMinusMinusToken.Add(new XAttribute("part", "LessThanExclamationMinusMinusToken"));
    		result.Add(xLessThanExclamationMinusMinusToken);
    		var xTextTokens = new XElement("TokenList");
    		xTextTokens.Add(new XAttribute("part", "TextTokens"));
    		foreach(var x in node.TextTokens)
    		{
    			xTextTokens.Add(new XText(x.ValueText));
    		}
    		result.Add(xTextTokens);
    		var xMinusMinusGreaterThanToken = new XElement("Token");
    		//xMinusMinusGreaterThanToken.Add(new XAttribute("part", "MinusMinusGreaterThanToken"));
    		result.Add(xMinusMinusGreaterThanToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a XmlTextAttributeSyntax node.
        /// </summary>
        public override XElement VisitXmlTextAttribute(Microsoft.CodeAnalysis.CSharp.Syntax.XmlTextAttributeSyntax node)
        {
    		var result = new XElement("XmlTextAttribute");
    		var xName = this.Visit(node.Name);
    		xName.Add(new XAttribute("part", "Name"));
    		result.Add(xName);
    		var xEqualsToken = new XElement("Token");
    		//xEqualsToken.Add(new XAttribute("part", "EqualsToken"));
    		result.Add(xEqualsToken);
    		var xStartQuoteToken = new XElement("Token");
    		//xStartQuoteToken.Add(new XAttribute("part", "StartQuoteToken"));
    		result.Add(xStartQuoteToken);
    		var xTextTokens = new XElement("TokenList");
    		xTextTokens.Add(new XAttribute("part", "TextTokens"));
    		foreach(var x in node.TextTokens)
    		{
    			xTextTokens.Add(new XText(x.ValueText));
    		}
    		result.Add(xTextTokens);
    		var xEndQuoteToken = new XElement("Token");
    		//xEndQuoteToken.Add(new XAttribute("part", "EndQuoteToken"));
    		result.Add(xEndQuoteToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a XmlCrefAttributeSyntax node.
        /// </summary>
        public override XElement VisitXmlCrefAttribute(Microsoft.CodeAnalysis.CSharp.Syntax.XmlCrefAttributeSyntax node)
        {
    		var result = new XElement("XmlCrefAttribute");
    		var xName = this.Visit(node.Name);
    		xName.Add(new XAttribute("part", "Name"));
    		result.Add(xName);
    		var xEqualsToken = new XElement("Token");
    		//xEqualsToken.Add(new XAttribute("part", "EqualsToken"));
    		result.Add(xEqualsToken);
    		var xStartQuoteToken = new XElement("Token");
    		//xStartQuoteToken.Add(new XAttribute("part", "StartQuoteToken"));
    		result.Add(xStartQuoteToken);
    		var xCref = this.Visit(node.Cref);
    		xCref.Add(new XAttribute("part", "Cref"));
    		result.Add(xCref);
    		var xEndQuoteToken = new XElement("Token");
    		//xEndQuoteToken.Add(new XAttribute("part", "EndQuoteToken"));
    		result.Add(xEndQuoteToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a XmlNameAttributeSyntax node.
        /// </summary>
        public override XElement VisitXmlNameAttribute(Microsoft.CodeAnalysis.CSharp.Syntax.XmlNameAttributeSyntax node)
        {
    		var result = new XElement("XmlNameAttribute");
    		var xName = this.Visit(node.Name);
    		xName.Add(new XAttribute("part", "Name"));
    		result.Add(xName);
    		var xEqualsToken = new XElement("Token");
    		//xEqualsToken.Add(new XAttribute("part", "EqualsToken"));
    		result.Add(xEqualsToken);
    		var xStartQuoteToken = new XElement("Token");
    		//xStartQuoteToken.Add(new XAttribute("part", "StartQuoteToken"));
    		result.Add(xStartQuoteToken);
    		var xIdentifier = this.Visit(node.Identifier);
    		xIdentifier.Add(new XAttribute("part", "Identifier"));
    		result.Add(xIdentifier);
    		var xEndQuoteToken = new XElement("Token");
    		//xEndQuoteToken.Add(new XAttribute("part", "EndQuoteToken"));
    		result.Add(xEndQuoteToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a ParenthesizedExpressionSyntax node.
        /// </summary>
        public override XElement VisitParenthesizedExpression(Microsoft.CodeAnalysis.CSharp.Syntax.ParenthesizedExpressionSyntax node)
        {
    		var result = new XElement("ParenthesizedExpression");
    		var xOpenParenToken = new XElement("Token");
    		//xOpenParenToken.Add(new XAttribute("part", "OpenParenToken"));
    		result.Add(xOpenParenToken);
    		var xExpression = this.Visit(node.Expression);
    		xExpression.Add(new XAttribute("part", "Expression"));
    		result.Add(xExpression);
    		var xCloseParenToken = new XElement("Token");
    		//xCloseParenToken.Add(new XAttribute("part", "CloseParenToken"));
    		result.Add(xCloseParenToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a TupleExpressionSyntax node.
        /// </summary>
        public override XElement VisitTupleExpression(Microsoft.CodeAnalysis.CSharp.Syntax.TupleExpressionSyntax node)
        {
    		var result = new XElement("TupleExpression");
    		var xOpenParenToken = new XElement("Token");
    		//xOpenParenToken.Add(new XAttribute("part", "OpenParenToken"));
    		result.Add(xOpenParenToken);
    		var xArguments = new XElement("SeparatedList_of_Argument");
    		xArguments.Add(new XAttribute("part", "Arguments"));
    		foreach(var x in node.Arguments)
    		{
    			xArguments.Add(this.Visit(x));
    		}
    		result.Add(xArguments);
    		var xCloseParenToken = new XElement("Token");
    		//xCloseParenToken.Add(new XAttribute("part", "CloseParenToken"));
    		result.Add(xCloseParenToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a PrefixUnaryExpressionSyntax node.
        /// </summary>
        public override XElement VisitPrefixUnaryExpression(Microsoft.CodeAnalysis.CSharp.Syntax.PrefixUnaryExpressionSyntax node)
        {
    		var result = new XElement("PrefixUnaryExpression");
    		var xOperatorToken = new XElement("Token");
    		//xOperatorToken.Add(new XAttribute("part", "OperatorToken"));
    		result.Add(xOperatorToken);
    		var xOperand = this.Visit(node.Operand);
    		xOperand.Add(new XAttribute("part", "Operand"));
    		result.Add(xOperand);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a AwaitExpressionSyntax node.
        /// </summary>
        public override XElement VisitAwaitExpression(Microsoft.CodeAnalysis.CSharp.Syntax.AwaitExpressionSyntax node)
        {
    		var result = new XElement("AwaitExpression");
    		var xAwaitKeyword = new XElement("Token");
    		//xAwaitKeyword.Add(new XAttribute("part", "AwaitKeyword"));
    		result.Add(xAwaitKeyword);
    		var xExpression = this.Visit(node.Expression);
    		xExpression.Add(new XAttribute("part", "Expression"));
    		result.Add(xExpression);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a PostfixUnaryExpressionSyntax node.
        /// </summary>
        public override XElement VisitPostfixUnaryExpression(Microsoft.CodeAnalysis.CSharp.Syntax.PostfixUnaryExpressionSyntax node)
        {
    		var result = new XElement("PostfixUnaryExpression");
    		var xOperand = this.Visit(node.Operand);
    		xOperand.Add(new XAttribute("part", "Operand"));
    		result.Add(xOperand);
    		var xOperatorToken = new XElement("Token");
    		//xOperatorToken.Add(new XAttribute("part", "OperatorToken"));
    		result.Add(xOperatorToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a MemberAccessExpressionSyntax node.
        /// </summary>
        public override XElement VisitMemberAccessExpression(Microsoft.CodeAnalysis.CSharp.Syntax.MemberAccessExpressionSyntax node)
        {
    		var result = new XElement("MemberAccessExpression");
    		var xExpression = this.Visit(node.Expression);
    		xExpression.Add(new XAttribute("part", "Expression"));
    		result.Add(xExpression);
    		var xOperatorToken = new XElement("Token");
    		//xOperatorToken.Add(new XAttribute("part", "OperatorToken"));
    		result.Add(xOperatorToken);
    		var xName = this.Visit(node.Name);
    		xName.Add(new XAttribute("part", "Name"));
    		result.Add(xName);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a ConditionalAccessExpressionSyntax node.
        /// </summary>
        public override XElement VisitConditionalAccessExpression(Microsoft.CodeAnalysis.CSharp.Syntax.ConditionalAccessExpressionSyntax node)
        {
    		var result = new XElement("ConditionalAccessExpression");
    		var xExpression = this.Visit(node.Expression);
    		xExpression.Add(new XAttribute("part", "Expression"));
    		result.Add(xExpression);
    		var xOperatorToken = new XElement("Token");
    		//xOperatorToken.Add(new XAttribute("part", "OperatorToken"));
    		result.Add(xOperatorToken);
    		var xWhenNotNull = this.Visit(node.WhenNotNull);
    		xWhenNotNull.Add(new XAttribute("part", "WhenNotNull"));
    		result.Add(xWhenNotNull);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a MemberBindingExpressionSyntax node.
        /// </summary>
        public override XElement VisitMemberBindingExpression(Microsoft.CodeAnalysis.CSharp.Syntax.MemberBindingExpressionSyntax node)
        {
    		var result = new XElement("MemberBindingExpression");
    		var xOperatorToken = new XElement("Token");
    		//xOperatorToken.Add(new XAttribute("part", "OperatorToken"));
    		result.Add(xOperatorToken);
    		var xName = this.Visit(node.Name);
    		xName.Add(new XAttribute("part", "Name"));
    		result.Add(xName);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a ElementBindingExpressionSyntax node.
        /// </summary>
        public override XElement VisitElementBindingExpression(Microsoft.CodeAnalysis.CSharp.Syntax.ElementBindingExpressionSyntax node)
        {
    		var result = new XElement("ElementBindingExpression");
    		var xArgumentList = this.Visit(node.ArgumentList);
    		xArgumentList.Add(new XAttribute("part", "ArgumentList"));
    		result.Add(xArgumentList);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a ImplicitElementAccessSyntax node.
        /// </summary>
        public override XElement VisitImplicitElementAccess(Microsoft.CodeAnalysis.CSharp.Syntax.ImplicitElementAccessSyntax node)
        {
    		var result = new XElement("ImplicitElementAccess");
    		var xArgumentList = this.Visit(node.ArgumentList);
    		xArgumentList.Add(new XAttribute("part", "ArgumentList"));
    		result.Add(xArgumentList);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a BinaryExpressionSyntax node.
        /// </summary>
        public override XElement VisitBinaryExpression(Microsoft.CodeAnalysis.CSharp.Syntax.BinaryExpressionSyntax node)
        {
    		var result = new XElement("BinaryExpression");
    		var xLeft = this.Visit(node.Left);
    		xLeft.Add(new XAttribute("part", "Left"));
    		result.Add(xLeft);
    		var xOperatorToken = new XElement("Token");
    		//xOperatorToken.Add(new XAttribute("part", "OperatorToken"));
    		result.Add(xOperatorToken);
    		var xRight = this.Visit(node.Right);
    		xRight.Add(new XAttribute("part", "Right"));
    		result.Add(xRight);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a AssignmentExpressionSyntax node.
        /// </summary>
        public override XElement VisitAssignmentExpression(Microsoft.CodeAnalysis.CSharp.Syntax.AssignmentExpressionSyntax node)
        {
    		var result = new XElement("AssignmentExpression");
    		var xLeft = this.Visit(node.Left);
    		xLeft.Add(new XAttribute("part", "Left"));
    		result.Add(xLeft);
    		var xOperatorToken = new XElement("Token");
    		//xOperatorToken.Add(new XAttribute("part", "OperatorToken"));
    		result.Add(xOperatorToken);
    		var xRight = this.Visit(node.Right);
    		xRight.Add(new XAttribute("part", "Right"));
    		result.Add(xRight);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a ConditionalExpressionSyntax node.
        /// </summary>
        public override XElement VisitConditionalExpression(Microsoft.CodeAnalysis.CSharp.Syntax.ConditionalExpressionSyntax node)
        {
    		var result = new XElement("ConditionalExpression");
    		var xCondition = this.Visit(node.Condition);
    		xCondition.Add(new XAttribute("part", "Condition"));
    		result.Add(xCondition);
    		var xQuestionToken = new XElement("Token");
    		//xQuestionToken.Add(new XAttribute("part", "QuestionToken"));
    		result.Add(xQuestionToken);
    		var xWhenTrue = this.Visit(node.WhenTrue);
    		xWhenTrue.Add(new XAttribute("part", "WhenTrue"));
    		result.Add(xWhenTrue);
    		var xColonToken = new XElement("Token");
    		//xColonToken.Add(new XAttribute("part", "ColonToken"));
    		result.Add(xColonToken);
    		var xWhenFalse = this.Visit(node.WhenFalse);
    		xWhenFalse.Add(new XAttribute("part", "WhenFalse"));
    		result.Add(xWhenFalse);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a LiteralExpressionSyntax node.
        /// </summary>
        public override XElement VisitLiteralExpression(Microsoft.CodeAnalysis.CSharp.Syntax.LiteralExpressionSyntax node)
        {
    		var result = new XElement("LiteralExpression");
    		var xToken = new XElement("Token");
    		//xToken.Add(new XAttribute("part", "Token"));
    		result.Add(xToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a MakeRefExpressionSyntax node.
        /// </summary>
        public override XElement VisitMakeRefExpression(Microsoft.CodeAnalysis.CSharp.Syntax.MakeRefExpressionSyntax node)
        {
    		var result = new XElement("MakeRefExpression");
    		var xKeyword = new XElement("Token");
    		//xKeyword.Add(new XAttribute("part", "Keyword"));
    		result.Add(xKeyword);
    		var xOpenParenToken = new XElement("Token");
    		//xOpenParenToken.Add(new XAttribute("part", "OpenParenToken"));
    		result.Add(xOpenParenToken);
    		var xExpression = this.Visit(node.Expression);
    		xExpression.Add(new XAttribute("part", "Expression"));
    		result.Add(xExpression);
    		var xCloseParenToken = new XElement("Token");
    		//xCloseParenToken.Add(new XAttribute("part", "CloseParenToken"));
    		result.Add(xCloseParenToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a RefTypeExpressionSyntax node.
        /// </summary>
        public override XElement VisitRefTypeExpression(Microsoft.CodeAnalysis.CSharp.Syntax.RefTypeExpressionSyntax node)
        {
    		var result = new XElement("RefTypeExpression");
    		var xKeyword = new XElement("Token");
    		//xKeyword.Add(new XAttribute("part", "Keyword"));
    		result.Add(xKeyword);
    		var xOpenParenToken = new XElement("Token");
    		//xOpenParenToken.Add(new XAttribute("part", "OpenParenToken"));
    		result.Add(xOpenParenToken);
    		var xExpression = this.Visit(node.Expression);
    		xExpression.Add(new XAttribute("part", "Expression"));
    		result.Add(xExpression);
    		var xCloseParenToken = new XElement("Token");
    		//xCloseParenToken.Add(new XAttribute("part", "CloseParenToken"));
    		result.Add(xCloseParenToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a RefValueExpressionSyntax node.
        /// </summary>
        public override XElement VisitRefValueExpression(Microsoft.CodeAnalysis.CSharp.Syntax.RefValueExpressionSyntax node)
        {
    		var result = new XElement("RefValueExpression");
    		var xKeyword = new XElement("Token");
    		//xKeyword.Add(new XAttribute("part", "Keyword"));
    		result.Add(xKeyword);
    		var xOpenParenToken = new XElement("Token");
    		//xOpenParenToken.Add(new XAttribute("part", "OpenParenToken"));
    		result.Add(xOpenParenToken);
    		var xExpression = this.Visit(node.Expression);
    		xExpression.Add(new XAttribute("part", "Expression"));
    		result.Add(xExpression);
    		var xComma = new XElement("Token");
    		//xComma.Add(new XAttribute("part", "Comma"));
    		result.Add(xComma);
    		var xType = this.Visit(node.Type);
    		xType.Add(new XAttribute("part", "Type"));
    		result.Add(xType);
    		var xCloseParenToken = new XElement("Token");
    		//xCloseParenToken.Add(new XAttribute("part", "CloseParenToken"));
    		result.Add(xCloseParenToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a CheckedExpressionSyntax node.
        /// </summary>
        public override XElement VisitCheckedExpression(Microsoft.CodeAnalysis.CSharp.Syntax.CheckedExpressionSyntax node)
        {
    		var result = new XElement("CheckedExpression");
    		var xKeyword = new XElement("Token");
    		//xKeyword.Add(new XAttribute("part", "Keyword"));
    		result.Add(xKeyword);
    		var xOpenParenToken = new XElement("Token");
    		//xOpenParenToken.Add(new XAttribute("part", "OpenParenToken"));
    		result.Add(xOpenParenToken);
    		var xExpression = this.Visit(node.Expression);
    		xExpression.Add(new XAttribute("part", "Expression"));
    		result.Add(xExpression);
    		var xCloseParenToken = new XElement("Token");
    		//xCloseParenToken.Add(new XAttribute("part", "CloseParenToken"));
    		result.Add(xCloseParenToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a DefaultExpressionSyntax node.
        /// </summary>
        public override XElement VisitDefaultExpression(Microsoft.CodeAnalysis.CSharp.Syntax.DefaultExpressionSyntax node)
        {
    		var result = new XElement("DefaultExpression");
    		var xKeyword = new XElement("Token");
    		//xKeyword.Add(new XAttribute("part", "Keyword"));
    		result.Add(xKeyword);
    		var xOpenParenToken = new XElement("Token");
    		//xOpenParenToken.Add(new XAttribute("part", "OpenParenToken"));
    		result.Add(xOpenParenToken);
    		var xType = this.Visit(node.Type);
    		xType.Add(new XAttribute("part", "Type"));
    		result.Add(xType);
    		var xCloseParenToken = new XElement("Token");
    		//xCloseParenToken.Add(new XAttribute("part", "CloseParenToken"));
    		result.Add(xCloseParenToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a TypeOfExpressionSyntax node.
        /// </summary>
        public override XElement VisitTypeOfExpression(Microsoft.CodeAnalysis.CSharp.Syntax.TypeOfExpressionSyntax node)
        {
    		var result = new XElement("TypeOfExpression");
    		var xKeyword = new XElement("Token");
    		//xKeyword.Add(new XAttribute("part", "Keyword"));
    		result.Add(xKeyword);
    		var xOpenParenToken = new XElement("Token");
    		//xOpenParenToken.Add(new XAttribute("part", "OpenParenToken"));
    		result.Add(xOpenParenToken);
    		var xType = this.Visit(node.Type);
    		xType.Add(new XAttribute("part", "Type"));
    		result.Add(xType);
    		var xCloseParenToken = new XElement("Token");
    		//xCloseParenToken.Add(new XAttribute("part", "CloseParenToken"));
    		result.Add(xCloseParenToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a SizeOfExpressionSyntax node.
        /// </summary>
        public override XElement VisitSizeOfExpression(Microsoft.CodeAnalysis.CSharp.Syntax.SizeOfExpressionSyntax node)
        {
    		var result = new XElement("SizeOfExpression");
    		var xKeyword = new XElement("Token");
    		//xKeyword.Add(new XAttribute("part", "Keyword"));
    		result.Add(xKeyword);
    		var xOpenParenToken = new XElement("Token");
    		//xOpenParenToken.Add(new XAttribute("part", "OpenParenToken"));
    		result.Add(xOpenParenToken);
    		var xType = this.Visit(node.Type);
    		xType.Add(new XAttribute("part", "Type"));
    		result.Add(xType);
    		var xCloseParenToken = new XElement("Token");
    		//xCloseParenToken.Add(new XAttribute("part", "CloseParenToken"));
    		result.Add(xCloseParenToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a InvocationExpressionSyntax node.
        /// </summary>
        public override XElement VisitInvocationExpression(Microsoft.CodeAnalysis.CSharp.Syntax.InvocationExpressionSyntax node)
        {
    		var result = new XElement("InvocationExpression");
    		var xExpression = this.Visit(node.Expression);
    		xExpression.Add(new XAttribute("part", "Expression"));
    		result.Add(xExpression);
    		var xArgumentList = this.Visit(node.ArgumentList);
    		xArgumentList.Add(new XAttribute("part", "ArgumentList"));
    		result.Add(xArgumentList);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a ElementAccessExpressionSyntax node.
        /// </summary>
        public override XElement VisitElementAccessExpression(Microsoft.CodeAnalysis.CSharp.Syntax.ElementAccessExpressionSyntax node)
        {
    		var result = new XElement("ElementAccessExpression");
    		var xExpression = this.Visit(node.Expression);
    		xExpression.Add(new XAttribute("part", "Expression"));
    		result.Add(xExpression);
    		var xArgumentList = this.Visit(node.ArgumentList);
    		xArgumentList.Add(new XAttribute("part", "ArgumentList"));
    		result.Add(xArgumentList);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a DeclarationExpressionSyntax node.
        /// </summary>
        public override XElement VisitDeclarationExpression(Microsoft.CodeAnalysis.CSharp.Syntax.DeclarationExpressionSyntax node)
        {
    		var result = new XElement("DeclarationExpression");
    		var xType = this.Visit(node.Type);
    		xType.Add(new XAttribute("part", "Type"));
    		result.Add(xType);
    		var xDesignation = this.Visit(node.Designation);
    		xDesignation.Add(new XAttribute("part", "Designation"));
    		result.Add(xDesignation);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a CastExpressionSyntax node.
        /// </summary>
        public override XElement VisitCastExpression(Microsoft.CodeAnalysis.CSharp.Syntax.CastExpressionSyntax node)
        {
    		var result = new XElement("CastExpression");
    		var xOpenParenToken = new XElement("Token");
    		//xOpenParenToken.Add(new XAttribute("part", "OpenParenToken"));
    		result.Add(xOpenParenToken);
    		var xType = this.Visit(node.Type);
    		xType.Add(new XAttribute("part", "Type"));
    		result.Add(xType);
    		var xCloseParenToken = new XElement("Token");
    		//xCloseParenToken.Add(new XAttribute("part", "CloseParenToken"));
    		result.Add(xCloseParenToken);
    		var xExpression = this.Visit(node.Expression);
    		xExpression.Add(new XAttribute("part", "Expression"));
    		result.Add(xExpression);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a RefExpressionSyntax node.
        /// </summary>
        public override XElement VisitRefExpression(Microsoft.CodeAnalysis.CSharp.Syntax.RefExpressionSyntax node)
        {
    		var result = new XElement("RefExpression");
    		var xRefKeyword = new XElement("Token");
    		//xRefKeyword.Add(new XAttribute("part", "RefKeyword"));
    		result.Add(xRefKeyword);
    		var xExpression = this.Visit(node.Expression);
    		xExpression.Add(new XAttribute("part", "Expression"));
    		result.Add(xExpression);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a InitializerExpressionSyntax node.
        /// </summary>
        public override XElement VisitInitializerExpression(Microsoft.CodeAnalysis.CSharp.Syntax.InitializerExpressionSyntax node)
        {
    		var result = new XElement("InitializerExpression");
    		var xOpenBraceToken = new XElement("Token");
    		//xOpenBraceToken.Add(new XAttribute("part", "OpenBraceToken"));
    		result.Add(xOpenBraceToken);
    		var xExpressions = new XElement("SeparatedList_of_Expression");
    		xExpressions.Add(new XAttribute("part", "Expressions"));
    		foreach(var x in node.Expressions)
    		{
    			xExpressions.Add(this.Visit(x));
    		}
    		result.Add(xExpressions);
    		var xCloseBraceToken = new XElement("Token");
    		//xCloseBraceToken.Add(new XAttribute("part", "CloseBraceToken"));
    		result.Add(xCloseBraceToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a ObjectCreationExpressionSyntax node.
        /// </summary>
        public override XElement VisitObjectCreationExpression(Microsoft.CodeAnalysis.CSharp.Syntax.ObjectCreationExpressionSyntax node)
        {
    		var result = new XElement("ObjectCreationExpression");
    		var xNewKeyword = new XElement("Token");
    		//xNewKeyword.Add(new XAttribute("part", "NewKeyword"));
    		result.Add(xNewKeyword);
    		var xType = this.Visit(node.Type);
    		xType.Add(new XAttribute("part", "Type"));
    		result.Add(xType);
    		if(node.ArgumentList != null)
    		{
    			var xArgumentList = this.Visit(node.ArgumentList);
    			xArgumentList.Add(new XAttribute("part", "ArgumentList"));
    			result.Add(xArgumentList);
    		}
    		if(node.Initializer != null)
    		{
    			var xInitializer = this.Visit(node.Initializer);
    			xInitializer.Add(new XAttribute("part", "Initializer"));
    			result.Add(xInitializer);
    		}
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a AnonymousObjectCreationExpressionSyntax node.
        /// </summary>
        public override XElement VisitAnonymousObjectCreationExpression(Microsoft.CodeAnalysis.CSharp.Syntax.AnonymousObjectCreationExpressionSyntax node)
        {
    		var result = new XElement("AnonymousObjectCreationExpression");
    		var xNewKeyword = new XElement("Token");
    		//xNewKeyword.Add(new XAttribute("part", "NewKeyword"));
    		result.Add(xNewKeyword);
    		var xOpenBraceToken = new XElement("Token");
    		//xOpenBraceToken.Add(new XAttribute("part", "OpenBraceToken"));
    		result.Add(xOpenBraceToken);
    		var xInitializers = new XElement("SeparatedList_of_AnonymousObjectMemberDeclarator");
    		xInitializers.Add(new XAttribute("part", "Initializers"));
    		foreach(var x in node.Initializers)
    		{
    			xInitializers.Add(this.Visit(x));
    		}
    		result.Add(xInitializers);
    		var xCloseBraceToken = new XElement("Token");
    		//xCloseBraceToken.Add(new XAttribute("part", "CloseBraceToken"));
    		result.Add(xCloseBraceToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a ArrayCreationExpressionSyntax node.
        /// </summary>
        public override XElement VisitArrayCreationExpression(Microsoft.CodeAnalysis.CSharp.Syntax.ArrayCreationExpressionSyntax node)
        {
    		var result = new XElement("ArrayCreationExpression");
    		var xNewKeyword = new XElement("Token");
    		//xNewKeyword.Add(new XAttribute("part", "NewKeyword"));
    		result.Add(xNewKeyword);
    		var xType = this.Visit(node.Type);
    		xType.Add(new XAttribute("part", "Type"));
    		result.Add(xType);
    		if(node.Initializer != null)
    		{
    			var xInitializer = this.Visit(node.Initializer);
    			xInitializer.Add(new XAttribute("part", "Initializer"));
    			result.Add(xInitializer);
    		}
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a ImplicitArrayCreationExpressionSyntax node.
        /// </summary>
        public override XElement VisitImplicitArrayCreationExpression(Microsoft.CodeAnalysis.CSharp.Syntax.ImplicitArrayCreationExpressionSyntax node)
        {
    		var result = new XElement("ImplicitArrayCreationExpression");
    		var xNewKeyword = new XElement("Token");
    		//xNewKeyword.Add(new XAttribute("part", "NewKeyword"));
    		result.Add(xNewKeyword);
    		var xOpenBracketToken = new XElement("Token");
    		//xOpenBracketToken.Add(new XAttribute("part", "OpenBracketToken"));
    		result.Add(xOpenBracketToken);
    		var xCommas = new XElement("TokenList");
    		xCommas.Add(new XAttribute("part", "Commas"));
    		foreach(var x in node.Commas)
    		{
    			xCommas.Add(new XText(x.ValueText));
    		}
    		result.Add(xCommas);
    		var xCloseBracketToken = new XElement("Token");
    		//xCloseBracketToken.Add(new XAttribute("part", "CloseBracketToken"));
    		result.Add(xCloseBracketToken);
    		var xInitializer = this.Visit(node.Initializer);
    		xInitializer.Add(new XAttribute("part", "Initializer"));
    		result.Add(xInitializer);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a StackAllocArrayCreationExpressionSyntax node.
        /// </summary>
        public override XElement VisitStackAllocArrayCreationExpression(Microsoft.CodeAnalysis.CSharp.Syntax.StackAllocArrayCreationExpressionSyntax node)
        {
    		var result = new XElement("StackAllocArrayCreationExpression");
    		var xStackAllocKeyword = new XElement("Token");
    		//xStackAllocKeyword.Add(new XAttribute("part", "StackAllocKeyword"));
    		result.Add(xStackAllocKeyword);
    		var xType = this.Visit(node.Type);
    		xType.Add(new XAttribute("part", "Type"));
    		result.Add(xType);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a QueryExpressionSyntax node.
        /// </summary>
        public override XElement VisitQueryExpression(Microsoft.CodeAnalysis.CSharp.Syntax.QueryExpressionSyntax node)
        {
    		var result = new XElement("QueryExpression");
    		var xFromClause = this.Visit(node.FromClause);
    		xFromClause.Add(new XAttribute("part", "FromClause"));
    		result.Add(xFromClause);
    		var xBody = this.Visit(node.Body);
    		xBody.Add(new XAttribute("part", "Body"));
    		result.Add(xBody);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a OmittedArraySizeExpressionSyntax node.
        /// </summary>
        public override XElement VisitOmittedArraySizeExpression(Microsoft.CodeAnalysis.CSharp.Syntax.OmittedArraySizeExpressionSyntax node)
        {
    		var result = new XElement("OmittedArraySizeExpression");
    		var xOmittedArraySizeExpressionToken = new XElement("Token");
    		//xOmittedArraySizeExpressionToken.Add(new XAttribute("part", "OmittedArraySizeExpressionToken"));
    		result.Add(xOmittedArraySizeExpressionToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a InterpolatedStringExpressionSyntax node.
        /// </summary>
        public override XElement VisitInterpolatedStringExpression(Microsoft.CodeAnalysis.CSharp.Syntax.InterpolatedStringExpressionSyntax node)
        {
    		var result = new XElement("InterpolatedStringExpression");
    		var xStringStartToken = new XElement("Token");
    		//xStringStartToken.Add(new XAttribute("part", "StringStartToken"));
    		result.Add(xStringStartToken);
    		var xContents = new XElement("List_of_InterpolatedStringContent");
    		xContents.Add(new XAttribute("part", "Contents"));
    		foreach(var x in node.Contents)
    		{
    			xContents.Add(this.Visit(x));
    		}
    		result.Add(xContents);
    		var xStringEndToken = new XElement("Token");
    		//xStringEndToken.Add(new XAttribute("part", "StringEndToken"));
    		result.Add(xStringEndToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a IsPatternExpressionSyntax node.
        /// </summary>
        public override XElement VisitIsPatternExpression(Microsoft.CodeAnalysis.CSharp.Syntax.IsPatternExpressionSyntax node)
        {
    		var result = new XElement("IsPatternExpression");
    		var xExpression = this.Visit(node.Expression);
    		xExpression.Add(new XAttribute("part", "Expression"));
    		result.Add(xExpression);
    		var xPattern = this.Visit(node.Pattern);
    		xPattern.Add(new XAttribute("part", "Pattern"));
    		result.Add(xPattern);
    		var xIsKeyword = new XElement("Token");
    		//xIsKeyword.Add(new XAttribute("part", "IsKeyword"));
    		result.Add(xIsKeyword);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a ThrowExpressionSyntax node.
        /// </summary>
        public override XElement VisitThrowExpression(Microsoft.CodeAnalysis.CSharp.Syntax.ThrowExpressionSyntax node)
        {
    		var result = new XElement("ThrowExpression");
    		var xThrowKeyword = new XElement("Token");
    		//xThrowKeyword.Add(new XAttribute("part", "ThrowKeyword"));
    		result.Add(xThrowKeyword);
    		var xExpression = this.Visit(node.Expression);
    		xExpression.Add(new XAttribute("part", "Expression"));
    		result.Add(xExpression);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a PredefinedTypeSyntax node.
        /// </summary>
        public override XElement VisitPredefinedType(Microsoft.CodeAnalysis.CSharp.Syntax.PredefinedTypeSyntax node)
        {
    		var result = new XElement("PredefinedType");
    		var xKeyword = new XElement("Token");
    		//xKeyword.Add(new XAttribute("part", "Keyword"));
    		result.Add(xKeyword);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a ArrayTypeSyntax node.
        /// </summary>
        public override XElement VisitArrayType(Microsoft.CodeAnalysis.CSharp.Syntax.ArrayTypeSyntax node)
        {
    		var result = new XElement("ArrayType");
    		var xElementType = this.Visit(node.ElementType);
    		xElementType.Add(new XAttribute("part", "ElementType"));
    		result.Add(xElementType);
    		var xRankSpecifiers = new XElement("List_of_ArrayRankSpecifier");
    		xRankSpecifiers.Add(new XAttribute("part", "RankSpecifiers"));
    		foreach(var x in node.RankSpecifiers)
    		{
    			xRankSpecifiers.Add(this.Visit(x));
    		}
    		result.Add(xRankSpecifiers);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a PointerTypeSyntax node.
        /// </summary>
        public override XElement VisitPointerType(Microsoft.CodeAnalysis.CSharp.Syntax.PointerTypeSyntax node)
        {
    		var result = new XElement("PointerType");
    		var xElementType = this.Visit(node.ElementType);
    		xElementType.Add(new XAttribute("part", "ElementType"));
    		result.Add(xElementType);
    		var xAsteriskToken = new XElement("Token");
    		//xAsteriskToken.Add(new XAttribute("part", "AsteriskToken"));
    		result.Add(xAsteriskToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a NullableTypeSyntax node.
        /// </summary>
        public override XElement VisitNullableType(Microsoft.CodeAnalysis.CSharp.Syntax.NullableTypeSyntax node)
        {
    		var result = new XElement("NullableType");
    		var xElementType = this.Visit(node.ElementType);
    		xElementType.Add(new XAttribute("part", "ElementType"));
    		result.Add(xElementType);
    		var xQuestionToken = new XElement("Token");
    		//xQuestionToken.Add(new XAttribute("part", "QuestionToken"));
    		result.Add(xQuestionToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a TupleTypeSyntax node.
        /// </summary>
        public override XElement VisitTupleType(Microsoft.CodeAnalysis.CSharp.Syntax.TupleTypeSyntax node)
        {
    		var result = new XElement("TupleType");
    		var xOpenParenToken = new XElement("Token");
    		//xOpenParenToken.Add(new XAttribute("part", "OpenParenToken"));
    		result.Add(xOpenParenToken);
    		var xElements = new XElement("SeparatedList_of_TupleElement");
    		xElements.Add(new XAttribute("part", "Elements"));
    		foreach(var x in node.Elements)
    		{
    			xElements.Add(this.Visit(x));
    		}
    		result.Add(xElements);
    		var xCloseParenToken = new XElement("Token");
    		//xCloseParenToken.Add(new XAttribute("part", "CloseParenToken"));
    		result.Add(xCloseParenToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a OmittedTypeArgumentSyntax node.
        /// </summary>
        public override XElement VisitOmittedTypeArgument(Microsoft.CodeAnalysis.CSharp.Syntax.OmittedTypeArgumentSyntax node)
        {
    		var result = new XElement("OmittedTypeArgument");
    		var xOmittedTypeArgumentToken = new XElement("Token");
    		//xOmittedTypeArgumentToken.Add(new XAttribute("part", "OmittedTypeArgumentToken"));
    		result.Add(xOmittedTypeArgumentToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a RefTypeSyntax node.
        /// </summary>
        public override XElement VisitRefType(Microsoft.CodeAnalysis.CSharp.Syntax.RefTypeSyntax node)
        {
    		var result = new XElement("RefType");
    		var xRefKeyword = new XElement("Token");
    		//xRefKeyword.Add(new XAttribute("part", "RefKeyword"));
    		result.Add(xRefKeyword);
    		var xType = this.Visit(node.Type);
    		xType.Add(new XAttribute("part", "Type"));
    		result.Add(xType);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a QualifiedNameSyntax node.
        /// </summary>
        public override XElement VisitQualifiedName(Microsoft.CodeAnalysis.CSharp.Syntax.QualifiedNameSyntax node)
        {
    		var result = new XElement("QualifiedName");
    		var xLeft = this.Visit(node.Left);
    		xLeft.Add(new XAttribute("part", "Left"));
    		result.Add(xLeft);
    		var xDotToken = new XElement("Token");
    		//xDotToken.Add(new XAttribute("part", "DotToken"));
    		result.Add(xDotToken);
    		var xRight = this.Visit(node.Right);
    		xRight.Add(new XAttribute("part", "Right"));
    		result.Add(xRight);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a AliasQualifiedNameSyntax node.
        /// </summary>
        public override XElement VisitAliasQualifiedName(Microsoft.CodeAnalysis.CSharp.Syntax.AliasQualifiedNameSyntax node)
        {
    		var result = new XElement("AliasQualifiedName");
    		var xAlias = this.Visit(node.Alias);
    		xAlias.Add(new XAttribute("part", "Alias"));
    		result.Add(xAlias);
    		if(node.ColonColonToken != null)
    		{
    			var xColonColonToken = new XElement("Token");
    		//	xColonColonToken.Add(new XAttribute("part", "ColonColonToken"));
    			result.Add(xColonColonToken);
    		}
    		var xName = this.Visit(node.Name);
    		xName.Add(new XAttribute("part", "Name"));
    		result.Add(xName);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a IdentifierNameSyntax node.
        /// </summary>
        public override XElement VisitIdentifierName(Microsoft.CodeAnalysis.CSharp.Syntax.IdentifierNameSyntax node)
        {
    		var result = new XElement("IdentifierName");
    		var xIdentifier = new XElement("Token");
    		//xIdentifier.Add(new XAttribute("part", "Identifier"));
    		result.Add(xIdentifier);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a GenericNameSyntax node.
        /// </summary>
        public override XElement VisitGenericName(Microsoft.CodeAnalysis.CSharp.Syntax.GenericNameSyntax node)
        {
    		var result = new XElement("GenericName");
    		var xIdentifier = new XElement("Token");
    		//xIdentifier.Add(new XAttribute("part", "Identifier"));
    		result.Add(xIdentifier);
    		var xTypeArgumentList = this.Visit(node.TypeArgumentList);
    		xTypeArgumentList.Add(new XAttribute("part", "TypeArgumentList"));
    		result.Add(xTypeArgumentList);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a ThisExpressionSyntax node.
        /// </summary>
        public override XElement VisitThisExpression(Microsoft.CodeAnalysis.CSharp.Syntax.ThisExpressionSyntax node)
        {
    		var result = new XElement("ThisExpression");
    		var xToken = new XElement("Token");
    		//xToken.Add(new XAttribute("part", "Token"));
    		result.Add(xToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a BaseExpressionSyntax node.
        /// </summary>
        public override XElement VisitBaseExpression(Microsoft.CodeAnalysis.CSharp.Syntax.BaseExpressionSyntax node)
        {
    		var result = new XElement("BaseExpression");
    		var xToken = new XElement("Token");
    		//xToken.Add(new XAttribute("part", "Token"));
    		result.Add(xToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a AnonymousMethodExpressionSyntax node.
        /// </summary>
        public override XElement VisitAnonymousMethodExpression(Microsoft.CodeAnalysis.CSharp.Syntax.AnonymousMethodExpressionSyntax node)
        {
    		var result = new XElement("AnonymousMethodExpression");
    		if(node.AsyncKeyword != null)
    		{
    			var xAsyncKeyword = new XElement("Token");
    		//	xAsyncKeyword.Add(new XAttribute("part", "AsyncKeyword"));
    			result.Add(xAsyncKeyword);
    		}
    		var xDelegateKeyword = new XElement("Token");
    		//xDelegateKeyword.Add(new XAttribute("part", "DelegateKeyword"));
    		result.Add(xDelegateKeyword);
    		if(node.ParameterList != null)
    		{
    			var xParameterList = this.Visit(node.ParameterList);
    			xParameterList.Add(new XAttribute("part", "ParameterList"));
    			result.Add(xParameterList);
    		}
    		var xBody = this.Visit(node.Body);
    		xBody.Add(new XAttribute("part", "Body"));
    		result.Add(xBody);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a SimpleLambdaExpressionSyntax node.
        /// </summary>
        public override XElement VisitSimpleLambdaExpression(Microsoft.CodeAnalysis.CSharp.Syntax.SimpleLambdaExpressionSyntax node)
        {
    		var result = new XElement("SimpleLambdaExpression");
    		if(node.AsyncKeyword != null)
    		{
    			var xAsyncKeyword = new XElement("Token");
    		//	xAsyncKeyword.Add(new XAttribute("part", "AsyncKeyword"));
    			result.Add(xAsyncKeyword);
    		}
    		var xParameter = this.Visit(node.Parameter);
    		xParameter.Add(new XAttribute("part", "Parameter"));
    		result.Add(xParameter);
    		var xArrowToken = new XElement("Token");
    		//xArrowToken.Add(new XAttribute("part", "ArrowToken"));
    		result.Add(xArrowToken);
    		var xBody = this.Visit(node.Body);
    		xBody.Add(new XAttribute("part", "Body"));
    		result.Add(xBody);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a ParenthesizedLambdaExpressionSyntax node.
        /// </summary>
        public override XElement VisitParenthesizedLambdaExpression(Microsoft.CodeAnalysis.CSharp.Syntax.ParenthesizedLambdaExpressionSyntax node)
        {
    		var result = new XElement("ParenthesizedLambdaExpression");
    		if(node.AsyncKeyword != null)
    		{
    			var xAsyncKeyword = new XElement("Token");
    		//	xAsyncKeyword.Add(new XAttribute("part", "AsyncKeyword"));
    			result.Add(xAsyncKeyword);
    		}
    		var xParameterList = this.Visit(node.ParameterList);
    		xParameterList.Add(new XAttribute("part", "ParameterList"));
    		result.Add(xParameterList);
    		var xArrowToken = new XElement("Token");
    		//xArrowToken.Add(new XAttribute("part", "ArrowToken"));
    		result.Add(xArrowToken);
    		var xBody = this.Visit(node.Body);
    		xBody.Add(new XAttribute("part", "Body"));
    		result.Add(xBody);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a ArgumentListSyntax node.
        /// </summary>
        public override XElement VisitArgumentList(Microsoft.CodeAnalysis.CSharp.Syntax.ArgumentListSyntax node)
        {
    		var result = new XElement("ArgumentList");
    		var xOpenParenToken = new XElement("Token");
    		//xOpenParenToken.Add(new XAttribute("part", "OpenParenToken"));
    		result.Add(xOpenParenToken);
    		var xArguments = new XElement("SeparatedList_of_Argument");
    		xArguments.Add(new XAttribute("part", "Arguments"));
    		foreach(var x in node.Arguments)
    		{
    			xArguments.Add(this.Visit(x));
    		}
    		result.Add(xArguments);
    		var xCloseParenToken = new XElement("Token");
    		//xCloseParenToken.Add(new XAttribute("part", "CloseParenToken"));
    		result.Add(xCloseParenToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a BracketedArgumentListSyntax node.
        /// </summary>
        public override XElement VisitBracketedArgumentList(Microsoft.CodeAnalysis.CSharp.Syntax.BracketedArgumentListSyntax node)
        {
    		var result = new XElement("BracketedArgumentList");
    		var xOpenBracketToken = new XElement("Token");
    		//xOpenBracketToken.Add(new XAttribute("part", "OpenBracketToken"));
    		result.Add(xOpenBracketToken);
    		var xArguments = new XElement("SeparatedList_of_Argument");
    		xArguments.Add(new XAttribute("part", "Arguments"));
    		foreach(var x in node.Arguments)
    		{
    			xArguments.Add(this.Visit(x));
    		}
    		result.Add(xArguments);
    		var xCloseBracketToken = new XElement("Token");
    		//xCloseBracketToken.Add(new XAttribute("part", "CloseBracketToken"));
    		result.Add(xCloseBracketToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a FromClauseSyntax node.
        /// </summary>
        public override XElement VisitFromClause(Microsoft.CodeAnalysis.CSharp.Syntax.FromClauseSyntax node)
        {
    		var result = new XElement("FromClause");
    		var xFromKeyword = new XElement("Token");
    		//xFromKeyword.Add(new XAttribute("part", "FromKeyword"));
    		result.Add(xFromKeyword);
    		if(node.Type != null)
    		{
    			var xType = this.Visit(node.Type);
    			xType.Add(new XAttribute("part", "Type"));
    			result.Add(xType);
    		}
    		var xIdentifier = new XElement("Token");
    		//xIdentifier.Add(new XAttribute("part", "Identifier"));
    		result.Add(xIdentifier);
    		var xInKeyword = new XElement("Token");
    		//xInKeyword.Add(new XAttribute("part", "InKeyword"));
    		result.Add(xInKeyword);
    		var xExpression = this.Visit(node.Expression);
    		xExpression.Add(new XAttribute("part", "Expression"));
    		result.Add(xExpression);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a LetClauseSyntax node.
        /// </summary>
        public override XElement VisitLetClause(Microsoft.CodeAnalysis.CSharp.Syntax.LetClauseSyntax node)
        {
    		var result = new XElement("LetClause");
    		var xLetKeyword = new XElement("Token");
    		//xLetKeyword.Add(new XAttribute("part", "LetKeyword"));
    		result.Add(xLetKeyword);
    		var xIdentifier = new XElement("Token");
    		//xIdentifier.Add(new XAttribute("part", "Identifier"));
    		result.Add(xIdentifier);
    		var xEqualsToken = new XElement("Token");
    		//xEqualsToken.Add(new XAttribute("part", "EqualsToken"));
    		result.Add(xEqualsToken);
    		var xExpression = this.Visit(node.Expression);
    		xExpression.Add(new XAttribute("part", "Expression"));
    		result.Add(xExpression);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a JoinClauseSyntax node.
        /// </summary>
        public override XElement VisitJoinClause(Microsoft.CodeAnalysis.CSharp.Syntax.JoinClauseSyntax node)
        {
    		var result = new XElement("JoinClause");
    		var xJoinKeyword = new XElement("Token");
    		//xJoinKeyword.Add(new XAttribute("part", "JoinKeyword"));
    		result.Add(xJoinKeyword);
    		if(node.Type != null)
    		{
    			var xType = this.Visit(node.Type);
    			xType.Add(new XAttribute("part", "Type"));
    			result.Add(xType);
    		}
    		var xIdentifier = new XElement("Token");
    		//xIdentifier.Add(new XAttribute("part", "Identifier"));
    		result.Add(xIdentifier);
    		var xInKeyword = new XElement("Token");
    		//xInKeyword.Add(new XAttribute("part", "InKeyword"));
    		result.Add(xInKeyword);
    		var xInExpression = this.Visit(node.InExpression);
    		xInExpression.Add(new XAttribute("part", "InExpression"));
    		result.Add(xInExpression);
    		var xOnKeyword = new XElement("Token");
    		//xOnKeyword.Add(new XAttribute("part", "OnKeyword"));
    		result.Add(xOnKeyword);
    		var xLeftExpression = this.Visit(node.LeftExpression);
    		xLeftExpression.Add(new XAttribute("part", "LeftExpression"));
    		result.Add(xLeftExpression);
    		var xEqualsKeyword = new XElement("Token");
    		//xEqualsKeyword.Add(new XAttribute("part", "EqualsKeyword"));
    		result.Add(xEqualsKeyword);
    		var xRightExpression = this.Visit(node.RightExpression);
    		xRightExpression.Add(new XAttribute("part", "RightExpression"));
    		result.Add(xRightExpression);
    		if(node.Into != null)
    		{
    			var xInto = this.Visit(node.Into);
    			xInto.Add(new XAttribute("part", "Into"));
    			result.Add(xInto);
    		}
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a WhereClauseSyntax node.
        /// </summary>
        public override XElement VisitWhereClause(Microsoft.CodeAnalysis.CSharp.Syntax.WhereClauseSyntax node)
        {
    		var result = new XElement("WhereClause");
    		var xWhereKeyword = new XElement("Token");
    		//xWhereKeyword.Add(new XAttribute("part", "WhereKeyword"));
    		result.Add(xWhereKeyword);
    		var xCondition = this.Visit(node.Condition);
    		xCondition.Add(new XAttribute("part", "Condition"));
    		result.Add(xCondition);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a OrderByClauseSyntax node.
        /// </summary>
        public override XElement VisitOrderByClause(Microsoft.CodeAnalysis.CSharp.Syntax.OrderByClauseSyntax node)
        {
    		var result = new XElement("OrderByClause");
    		var xOrderByKeyword = new XElement("Token");
    		//xOrderByKeyword.Add(new XAttribute("part", "OrderByKeyword"));
    		result.Add(xOrderByKeyword);
    		var xOrderings = new XElement("SeparatedList_of_Ordering");
    		xOrderings.Add(new XAttribute("part", "Orderings"));
    		foreach(var x in node.Orderings)
    		{
    			xOrderings.Add(this.Visit(x));
    		}
    		result.Add(xOrderings);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a SelectClauseSyntax node.
        /// </summary>
        public override XElement VisitSelectClause(Microsoft.CodeAnalysis.CSharp.Syntax.SelectClauseSyntax node)
        {
    		var result = new XElement("SelectClause");
    		var xSelectKeyword = new XElement("Token");
    		//xSelectKeyword.Add(new XAttribute("part", "SelectKeyword"));
    		result.Add(xSelectKeyword);
    		var xExpression = this.Visit(node.Expression);
    		xExpression.Add(new XAttribute("part", "Expression"));
    		result.Add(xExpression);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a GroupClauseSyntax node.
        /// </summary>
        public override XElement VisitGroupClause(Microsoft.CodeAnalysis.CSharp.Syntax.GroupClauseSyntax node)
        {
    		var result = new XElement("GroupClause");
    		var xGroupKeyword = new XElement("Token");
    		//xGroupKeyword.Add(new XAttribute("part", "GroupKeyword"));
    		result.Add(xGroupKeyword);
    		var xGroupExpression = this.Visit(node.GroupExpression);
    		xGroupExpression.Add(new XAttribute("part", "GroupExpression"));
    		result.Add(xGroupExpression);
    		var xByKeyword = new XElement("Token");
    		//xByKeyword.Add(new XAttribute("part", "ByKeyword"));
    		result.Add(xByKeyword);
    		var xByExpression = this.Visit(node.ByExpression);
    		xByExpression.Add(new XAttribute("part", "ByExpression"));
    		result.Add(xByExpression);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a DeclarationPatternSyntax node.
        /// </summary>
        public override XElement VisitDeclarationPattern(Microsoft.CodeAnalysis.CSharp.Syntax.DeclarationPatternSyntax node)
        {
    		var result = new XElement("DeclarationPattern");
    		var xType = this.Visit(node.Type);
    		xType.Add(new XAttribute("part", "Type"));
    		result.Add(xType);
    		var xDesignation = this.Visit(node.Designation);
    		xDesignation.Add(new XAttribute("part", "Designation"));
    		result.Add(xDesignation);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a ConstantPatternSyntax node.
        /// </summary>
        public override XElement VisitConstantPattern(Microsoft.CodeAnalysis.CSharp.Syntax.ConstantPatternSyntax node)
        {
    		var result = new XElement("ConstantPattern");
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a InterpolatedStringTextSyntax node.
        /// </summary>
        public override XElement VisitInterpolatedStringText(Microsoft.CodeAnalysis.CSharp.Syntax.InterpolatedStringTextSyntax node)
        {
    		var result = new XElement("InterpolatedStringText");
    		var xTextToken = new XElement("Token");
    		//xTextToken.Add(new XAttribute("part", "TextToken"));
    		result.Add(xTextToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a InterpolationSyntax node.
        /// </summary>
        public override XElement VisitInterpolation(Microsoft.CodeAnalysis.CSharp.Syntax.InterpolationSyntax node)
        {
    		var result = new XElement("Interpolation");
    		var xOpenBraceToken = new XElement("Token");
    		//xOpenBraceToken.Add(new XAttribute("part", "OpenBraceToken"));
    		result.Add(xOpenBraceToken);
    		var xExpression = this.Visit(node.Expression);
    		xExpression.Add(new XAttribute("part", "Expression"));
    		result.Add(xExpression);
    		if(node.AlignmentClause != null)
    		{
    			var xAlignmentClause = this.Visit(node.AlignmentClause);
    			xAlignmentClause.Add(new XAttribute("part", "AlignmentClause"));
    			result.Add(xAlignmentClause);
    		}
    		if(node.FormatClause != null)
    		{
    			var xFormatClause = this.Visit(node.FormatClause);
    			xFormatClause.Add(new XAttribute("part", "FormatClause"));
    			result.Add(xFormatClause);
    		}
    		var xCloseBraceToken = new XElement("Token");
    		//xCloseBraceToken.Add(new XAttribute("part", "CloseBraceToken"));
    		result.Add(xCloseBraceToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a BlockSyntax node.
        /// </summary>
        public override XElement VisitBlock(Microsoft.CodeAnalysis.CSharp.Syntax.BlockSyntax node)
        {
    		var result = new XElement("Block");
    		var xOpenBraceToken = new XElement("Token");
    		//xOpenBraceToken.Add(new XAttribute("part", "OpenBraceToken"));
    		result.Add(xOpenBraceToken);
    		var xStatements = new XElement("List_of_Statement");
    		xStatements.Add(new XAttribute("part", "Statements"));
    		foreach(var x in node.Statements)
    		{
    			xStatements.Add(this.Visit(x));
    		}
    		result.Add(xStatements);
    		var xCloseBraceToken = new XElement("Token");
    		//xCloseBraceToken.Add(new XAttribute("part", "CloseBraceToken"));
    		result.Add(xCloseBraceToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a LocalFunctionStatementSyntax node.
        /// </summary>
        public override XElement VisitLocalFunctionStatement(Microsoft.CodeAnalysis.CSharp.Syntax.LocalFunctionStatementSyntax node)
        {
    		var result = new XElement("LocalFunctionStatement");
    		var xModifiers = new XElement("TokenList");
    		xModifiers.Add(new XAttribute("part", "Modifiers"));
    		foreach(var x in node.Modifiers)
    		{
    			xModifiers.Add(new XText(x.ValueText));
    		}
    		result.Add(xModifiers);
    		var xReturnType = this.Visit(node.ReturnType);
    		xReturnType.Add(new XAttribute("part", "ReturnType"));
    		result.Add(xReturnType);
    		var xIdentifier = new XElement("Token");
    		//xIdentifier.Add(new XAttribute("part", "Identifier"));
    		result.Add(xIdentifier);
    		if(node.TypeParameterList != null)
    		{
    			var xTypeParameterList = this.Visit(node.TypeParameterList);
    			xTypeParameterList.Add(new XAttribute("part", "TypeParameterList"));
    			result.Add(xTypeParameterList);
    		}
    		var xParameterList = this.Visit(node.ParameterList);
    		xParameterList.Add(new XAttribute("part", "ParameterList"));
    		result.Add(xParameterList);
    		var xConstraintClauses = new XElement("List_of_TypeParameterConstraintClause");
    		xConstraintClauses.Add(new XAttribute("part", "ConstraintClauses"));
    		foreach(var x in node.ConstraintClauses)
    		{
    			xConstraintClauses.Add(this.Visit(x));
    		}
    		result.Add(xConstraintClauses);
    		if(node.Body != null)
    		{
    			var xBody = this.Visit(node.Body);
    			xBody.Add(new XAttribute("part", "Body"));
    			result.Add(xBody);
    		}
    		if(node.ExpressionBody != null)
    		{
    			var xExpressionBody = this.Visit(node.ExpressionBody);
    			xExpressionBody.Add(new XAttribute("part", "ExpressionBody"));
    			result.Add(xExpressionBody);
    		}
    		if(node.SemicolonToken != null)
    		{
    			var xSemicolonToken = new XElement("Token");
    		//	xSemicolonToken.Add(new XAttribute("part", "SemicolonToken"));
    			result.Add(xSemicolonToken);
    		}
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a LocalDeclarationStatementSyntax node.
        /// </summary>
        public override XElement VisitLocalDeclarationStatement(Microsoft.CodeAnalysis.CSharp.Syntax.LocalDeclarationStatementSyntax node)
        {
    		var result = new XElement("LocalDeclarationStatement");
    		var xModifiers = new XElement("TokenList");
    		xModifiers.Add(new XAttribute("part", "Modifiers"));
    		foreach(var x in node.Modifiers)
    		{
    			xModifiers.Add(new XText(x.ValueText));
    		}
    		result.Add(xModifiers);
    		var xDeclaration = this.Visit(node.Declaration);
    		xDeclaration.Add(new XAttribute("part", "Declaration"));
    		result.Add(xDeclaration);
    		var xSemicolonToken = new XElement("Token");
    		//xSemicolonToken.Add(new XAttribute("part", "SemicolonToken"));
    		result.Add(xSemicolonToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a ExpressionStatementSyntax node.
        /// </summary>
        public override XElement VisitExpressionStatement(Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionStatementSyntax node)
        {
    		var result = new XElement("ExpressionStatement");
    		var xExpression = this.Visit(node.Expression);
    		xExpression.Add(new XAttribute("part", "Expression"));
    		result.Add(xExpression);
    		var xSemicolonToken = new XElement("Token");
    		//xSemicolonToken.Add(new XAttribute("part", "SemicolonToken"));
    		result.Add(xSemicolonToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a EmptyStatementSyntax node.
        /// </summary>
        public override XElement VisitEmptyStatement(Microsoft.CodeAnalysis.CSharp.Syntax.EmptyStatementSyntax node)
        {
    		var result = new XElement("EmptyStatement");
    		var xSemicolonToken = new XElement("Token");
    		//xSemicolonToken.Add(new XAttribute("part", "SemicolonToken"));
    		result.Add(xSemicolonToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a LabeledStatementSyntax node.
        /// </summary>
        public override XElement VisitLabeledStatement(Microsoft.CodeAnalysis.CSharp.Syntax.LabeledStatementSyntax node)
        {
    		var result = new XElement("LabeledStatement");
    		var xIdentifier = new XElement("Token");
    		//xIdentifier.Add(new XAttribute("part", "Identifier"));
    		result.Add(xIdentifier);
    		var xColonToken = new XElement("Token");
    		//xColonToken.Add(new XAttribute("part", "ColonToken"));
    		result.Add(xColonToken);
    		var xStatement = this.Visit(node.Statement);
    		xStatement.Add(new XAttribute("part", "Statement"));
    		result.Add(xStatement);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a GotoStatementSyntax node.
        /// </summary>
        public override XElement VisitGotoStatement(Microsoft.CodeAnalysis.CSharp.Syntax.GotoStatementSyntax node)
        {
    		var result = new XElement("GotoStatement");
    		var xGotoKeyword = new XElement("Token");
    		//xGotoKeyword.Add(new XAttribute("part", "GotoKeyword"));
    		result.Add(xGotoKeyword);
    		if(node.CaseOrDefaultKeyword != null)
    		{
    			var xCaseOrDefaultKeyword = new XElement("Token");
    		//	xCaseOrDefaultKeyword.Add(new XAttribute("part", "CaseOrDefaultKeyword"));
    			result.Add(xCaseOrDefaultKeyword);
    		}
    		if(node.Expression != null)
    		{
    			var xExpression = this.Visit(node.Expression);
    			xExpression.Add(new XAttribute("part", "Expression"));
    			result.Add(xExpression);
    		}
    		var xSemicolonToken = new XElement("Token");
    		//xSemicolonToken.Add(new XAttribute("part", "SemicolonToken"));
    		result.Add(xSemicolonToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a BreakStatementSyntax node.
        /// </summary>
        public override XElement VisitBreakStatement(Microsoft.CodeAnalysis.CSharp.Syntax.BreakStatementSyntax node)
        {
    		var result = new XElement("BreakStatement");
    		var xBreakKeyword = new XElement("Token");
    		//xBreakKeyword.Add(new XAttribute("part", "BreakKeyword"));
    		result.Add(xBreakKeyword);
    		var xSemicolonToken = new XElement("Token");
    		//xSemicolonToken.Add(new XAttribute("part", "SemicolonToken"));
    		result.Add(xSemicolonToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a ContinueStatementSyntax node.
        /// </summary>
        public override XElement VisitContinueStatement(Microsoft.CodeAnalysis.CSharp.Syntax.ContinueStatementSyntax node)
        {
    		var result = new XElement("ContinueStatement");
    		var xContinueKeyword = new XElement("Token");
    		//xContinueKeyword.Add(new XAttribute("part", "ContinueKeyword"));
    		result.Add(xContinueKeyword);
    		var xSemicolonToken = new XElement("Token");
    		//xSemicolonToken.Add(new XAttribute("part", "SemicolonToken"));
    		result.Add(xSemicolonToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a ReturnStatementSyntax node.
        /// </summary>
        public override XElement VisitReturnStatement(Microsoft.CodeAnalysis.CSharp.Syntax.ReturnStatementSyntax node)
        {
    		var result = new XElement("ReturnStatement");
    		var xReturnKeyword = new XElement("Token");
    		//xReturnKeyword.Add(new XAttribute("part", "ReturnKeyword"));
    		result.Add(xReturnKeyword);
    		if(node.Expression != null)
    		{
    			var xExpression = this.Visit(node.Expression);
    			xExpression.Add(new XAttribute("part", "Expression"));
    			result.Add(xExpression);
    		}
    		var xSemicolonToken = new XElement("Token");
    		//xSemicolonToken.Add(new XAttribute("part", "SemicolonToken"));
    		result.Add(xSemicolonToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a ThrowStatementSyntax node.
        /// </summary>
        public override XElement VisitThrowStatement(Microsoft.CodeAnalysis.CSharp.Syntax.ThrowStatementSyntax node)
        {
    		var result = new XElement("ThrowStatement");
    		var xThrowKeyword = new XElement("Token");
    		//xThrowKeyword.Add(new XAttribute("part", "ThrowKeyword"));
    		result.Add(xThrowKeyword);
    		if(node.Expression != null)
    		{
    			var xExpression = this.Visit(node.Expression);
    			xExpression.Add(new XAttribute("part", "Expression"));
    			result.Add(xExpression);
    		}
    		var xSemicolonToken = new XElement("Token");
    		//xSemicolonToken.Add(new XAttribute("part", "SemicolonToken"));
    		result.Add(xSemicolonToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a YieldStatementSyntax node.
        /// </summary>
        public override XElement VisitYieldStatement(Microsoft.CodeAnalysis.CSharp.Syntax.YieldStatementSyntax node)
        {
    		var result = new XElement("YieldStatement");
    		var xYieldKeyword = new XElement("Token");
    		//xYieldKeyword.Add(new XAttribute("part", "YieldKeyword"));
    		result.Add(xYieldKeyword);
    		var xReturnOrBreakKeyword = new XElement("Token");
    		//xReturnOrBreakKeyword.Add(new XAttribute("part", "ReturnOrBreakKeyword"));
    		result.Add(xReturnOrBreakKeyword);
    		if(node.Expression != null)
    		{
    			var xExpression = this.Visit(node.Expression);
    			xExpression.Add(new XAttribute("part", "Expression"));
    			result.Add(xExpression);
    		}
    		var xSemicolonToken = new XElement("Token");
    		//xSemicolonToken.Add(new XAttribute("part", "SemicolonToken"));
    		result.Add(xSemicolonToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a WhileStatementSyntax node.
        /// </summary>
        public override XElement VisitWhileStatement(Microsoft.CodeAnalysis.CSharp.Syntax.WhileStatementSyntax node)
        {
    		var result = new XElement("WhileStatement");
    		var xWhileKeyword = new XElement("Token");
    		//xWhileKeyword.Add(new XAttribute("part", "WhileKeyword"));
    		result.Add(xWhileKeyword);
    		var xOpenParenToken = new XElement("Token");
    		//xOpenParenToken.Add(new XAttribute("part", "OpenParenToken"));
    		result.Add(xOpenParenToken);
    		var xCondition = this.Visit(node.Condition);
    		xCondition.Add(new XAttribute("part", "Condition"));
    		result.Add(xCondition);
    		var xCloseParenToken = new XElement("Token");
    		//xCloseParenToken.Add(new XAttribute("part", "CloseParenToken"));
    		result.Add(xCloseParenToken);
    		var xStatement = this.Visit(node.Statement);
    		xStatement.Add(new XAttribute("part", "Statement"));
    		result.Add(xStatement);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a DoStatementSyntax node.
        /// </summary>
        public override XElement VisitDoStatement(Microsoft.CodeAnalysis.CSharp.Syntax.DoStatementSyntax node)
        {
    		var result = new XElement("DoStatement");
    		var xDoKeyword = new XElement("Token");
    		//xDoKeyword.Add(new XAttribute("part", "DoKeyword"));
    		result.Add(xDoKeyword);
    		var xStatement = this.Visit(node.Statement);
    		xStatement.Add(new XAttribute("part", "Statement"));
    		result.Add(xStatement);
    		var xWhileKeyword = new XElement("Token");
    		//xWhileKeyword.Add(new XAttribute("part", "WhileKeyword"));
    		result.Add(xWhileKeyword);
    		var xOpenParenToken = new XElement("Token");
    		//xOpenParenToken.Add(new XAttribute("part", "OpenParenToken"));
    		result.Add(xOpenParenToken);
    		var xCondition = this.Visit(node.Condition);
    		xCondition.Add(new XAttribute("part", "Condition"));
    		result.Add(xCondition);
    		var xCloseParenToken = new XElement("Token");
    		//xCloseParenToken.Add(new XAttribute("part", "CloseParenToken"));
    		result.Add(xCloseParenToken);
    		var xSemicolonToken = new XElement("Token");
    		//xSemicolonToken.Add(new XAttribute("part", "SemicolonToken"));
    		result.Add(xSemicolonToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a ForStatementSyntax node.
        /// </summary>
        public override XElement VisitForStatement(Microsoft.CodeAnalysis.CSharp.Syntax.ForStatementSyntax node)
        {
    		var result = new XElement("ForStatement");
    		var xForKeyword = new XElement("Token");
    		//xForKeyword.Add(new XAttribute("part", "ForKeyword"));
    		result.Add(xForKeyword);
    		var xOpenParenToken = new XElement("Token");
    		//xOpenParenToken.Add(new XAttribute("part", "OpenParenToken"));
    		result.Add(xOpenParenToken);
    		if(node.Declaration != null)
    		{
    			var xDeclaration = this.Visit(node.Declaration);
    			xDeclaration.Add(new XAttribute("part", "Declaration"));
    			result.Add(xDeclaration);
    		}
    		if(node.Initializers != null)
    		{
    			var xInitializers = new XElement("SeparatedList_of_Expression");
    			xInitializers.Add(new XAttribute("part", "Initializers"));
    			foreach(var x in node.Initializers)
    			{
    				xInitializers.Add(this.Visit(x));
    			}
    			result.Add(xInitializers);
    		}
    		var xFirstSemicolonToken = new XElement("Token");
    		//xFirstSemicolonToken.Add(new XAttribute("part", "FirstSemicolonToken"));
    		result.Add(xFirstSemicolonToken);
    		if(node.Condition != null)
    		{
    			var xCondition = this.Visit(node.Condition);
    			xCondition.Add(new XAttribute("part", "Condition"));
    			result.Add(xCondition);
    		}
    		var xSecondSemicolonToken = new XElement("Token");
    		//xSecondSemicolonToken.Add(new XAttribute("part", "SecondSemicolonToken"));
    		result.Add(xSecondSemicolonToken);
    		if(node.Incrementors != null)
    		{
    			var xIncrementors = new XElement("SeparatedList_of_Expression");
    			xIncrementors.Add(new XAttribute("part", "Incrementors"));
    			foreach(var x in node.Incrementors)
    			{
    				xIncrementors.Add(this.Visit(x));
    			}
    			result.Add(xIncrementors);
    		}
    		var xCloseParenToken = new XElement("Token");
    		//xCloseParenToken.Add(new XAttribute("part", "CloseParenToken"));
    		result.Add(xCloseParenToken);
    		var xStatement = this.Visit(node.Statement);
    		xStatement.Add(new XAttribute("part", "Statement"));
    		result.Add(xStatement);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a UsingStatementSyntax node.
        /// </summary>
        public override XElement VisitUsingStatement(Microsoft.CodeAnalysis.CSharp.Syntax.UsingStatementSyntax node)
        {
    		var result = new XElement("UsingStatement");
    		var xUsingKeyword = new XElement("Token");
    		//xUsingKeyword.Add(new XAttribute("part", "UsingKeyword"));
    		result.Add(xUsingKeyword);
    		var xOpenParenToken = new XElement("Token");
    		//xOpenParenToken.Add(new XAttribute("part", "OpenParenToken"));
    		result.Add(xOpenParenToken);
    		if(node.Declaration != null)
    		{
    			var xDeclaration = this.Visit(node.Declaration);
    			xDeclaration.Add(new XAttribute("part", "Declaration"));
    			result.Add(xDeclaration);
    		}
    		if(node.Expression != null)
    		{
    			var xExpression = this.Visit(node.Expression);
    			xExpression.Add(new XAttribute("part", "Expression"));
    			result.Add(xExpression);
    		}
    		var xCloseParenToken = new XElement("Token");
    		//xCloseParenToken.Add(new XAttribute("part", "CloseParenToken"));
    		result.Add(xCloseParenToken);
    		var xStatement = this.Visit(node.Statement);
    		xStatement.Add(new XAttribute("part", "Statement"));
    		result.Add(xStatement);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a FixedStatementSyntax node.
        /// </summary>
        public override XElement VisitFixedStatement(Microsoft.CodeAnalysis.CSharp.Syntax.FixedStatementSyntax node)
        {
    		var result = new XElement("FixedStatement");
    		var xFixedKeyword = new XElement("Token");
    		//xFixedKeyword.Add(new XAttribute("part", "FixedKeyword"));
    		result.Add(xFixedKeyword);
    		var xOpenParenToken = new XElement("Token");
    		//xOpenParenToken.Add(new XAttribute("part", "OpenParenToken"));
    		result.Add(xOpenParenToken);
    		var xDeclaration = this.Visit(node.Declaration);
    		xDeclaration.Add(new XAttribute("part", "Declaration"));
    		result.Add(xDeclaration);
    		var xCloseParenToken = new XElement("Token");
    		//xCloseParenToken.Add(new XAttribute("part", "CloseParenToken"));
    		result.Add(xCloseParenToken);
    		var xStatement = this.Visit(node.Statement);
    		xStatement.Add(new XAttribute("part", "Statement"));
    		result.Add(xStatement);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a CheckedStatementSyntax node.
        /// </summary>
        public override XElement VisitCheckedStatement(Microsoft.CodeAnalysis.CSharp.Syntax.CheckedStatementSyntax node)
        {
    		var result = new XElement("CheckedStatement");
    		var xKeyword = new XElement("Token");
    		//xKeyword.Add(new XAttribute("part", "Keyword"));
    		result.Add(xKeyword);
    		var xBlock = this.Visit(node.Block);
    		xBlock.Add(new XAttribute("part", "Block"));
    		result.Add(xBlock);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a UnsafeStatementSyntax node.
        /// </summary>
        public override XElement VisitUnsafeStatement(Microsoft.CodeAnalysis.CSharp.Syntax.UnsafeStatementSyntax node)
        {
    		var result = new XElement("UnsafeStatement");
    		var xUnsafeKeyword = new XElement("Token");
    		//xUnsafeKeyword.Add(new XAttribute("part", "UnsafeKeyword"));
    		result.Add(xUnsafeKeyword);
    		var xBlock = this.Visit(node.Block);
    		xBlock.Add(new XAttribute("part", "Block"));
    		result.Add(xBlock);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a LockStatementSyntax node.
        /// </summary>
        public override XElement VisitLockStatement(Microsoft.CodeAnalysis.CSharp.Syntax.LockStatementSyntax node)
        {
    		var result = new XElement("LockStatement");
    		var xLockKeyword = new XElement("Token");
    		//xLockKeyword.Add(new XAttribute("part", "LockKeyword"));
    		result.Add(xLockKeyword);
    		var xOpenParenToken = new XElement("Token");
    		//xOpenParenToken.Add(new XAttribute("part", "OpenParenToken"));
    		result.Add(xOpenParenToken);
    		var xExpression = this.Visit(node.Expression);
    		xExpression.Add(new XAttribute("part", "Expression"));
    		result.Add(xExpression);
    		var xCloseParenToken = new XElement("Token");
    		//xCloseParenToken.Add(new XAttribute("part", "CloseParenToken"));
    		result.Add(xCloseParenToken);
    		var xStatement = this.Visit(node.Statement);
    		xStatement.Add(new XAttribute("part", "Statement"));
    		result.Add(xStatement);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a IfStatementSyntax node.
        /// </summary>
        public override XElement VisitIfStatement(Microsoft.CodeAnalysis.CSharp.Syntax.IfStatementSyntax node)
        {
    		var result = new XElement("IfStatement");
    		var xIfKeyword = new XElement("Token");
    		//xIfKeyword.Add(new XAttribute("part", "IfKeyword"));
    		result.Add(xIfKeyword);
    		var xOpenParenToken = new XElement("Token");
    		//xOpenParenToken.Add(new XAttribute("part", "OpenParenToken"));
    		result.Add(xOpenParenToken);
    		var xCondition = this.Visit(node.Condition);
    		xCondition.Add(new XAttribute("part", "Condition"));
    		result.Add(xCondition);
    		var xCloseParenToken = new XElement("Token");
    		//xCloseParenToken.Add(new XAttribute("part", "CloseParenToken"));
    		result.Add(xCloseParenToken);
    		var xStatement = this.Visit(node.Statement);
    		xStatement.Add(new XAttribute("part", "Statement"));
    		result.Add(xStatement);
    		if(node.Else != null)
    		{
    			var xElse = this.Visit(node.Else);
    			xElse.Add(new XAttribute("part", "Else"));
    			result.Add(xElse);
    		}
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a SwitchStatementSyntax node.
        /// </summary>
        public override XElement VisitSwitchStatement(Microsoft.CodeAnalysis.CSharp.Syntax.SwitchStatementSyntax node)
        {
    		var result = new XElement("SwitchStatement");
    		var xSwitchKeyword = new XElement("Token");
    		//xSwitchKeyword.Add(new XAttribute("part", "SwitchKeyword"));
    		result.Add(xSwitchKeyword);
    		var xOpenParenToken = new XElement("Token");
    		//xOpenParenToken.Add(new XAttribute("part", "OpenParenToken"));
    		result.Add(xOpenParenToken);
    		var xExpression = this.Visit(node.Expression);
    		xExpression.Add(new XAttribute("part", "Expression"));
    		result.Add(xExpression);
    		var xCloseParenToken = new XElement("Token");
    		//xCloseParenToken.Add(new XAttribute("part", "CloseParenToken"));
    		result.Add(xCloseParenToken);
    		var xOpenBraceToken = new XElement("Token");
    		//xOpenBraceToken.Add(new XAttribute("part", "OpenBraceToken"));
    		result.Add(xOpenBraceToken);
    		var xSections = new XElement("List_of_SwitchSection");
    		xSections.Add(new XAttribute("part", "Sections"));
    		foreach(var x in node.Sections)
    		{
    			xSections.Add(this.Visit(x));
    		}
    		result.Add(xSections);
    		var xCloseBraceToken = new XElement("Token");
    		//xCloseBraceToken.Add(new XAttribute("part", "CloseBraceToken"));
    		result.Add(xCloseBraceToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a TryStatementSyntax node.
        /// </summary>
        public override XElement VisitTryStatement(Microsoft.CodeAnalysis.CSharp.Syntax.TryStatementSyntax node)
        {
    		var result = new XElement("TryStatement");
    		var xTryKeyword = new XElement("Token");
    		//xTryKeyword.Add(new XAttribute("part", "TryKeyword"));
    		result.Add(xTryKeyword);
    		var xBlock = this.Visit(node.Block);
    		xBlock.Add(new XAttribute("part", "Block"));
    		result.Add(xBlock);
    		var xCatches = new XElement("List_of_CatchClause");
    		xCatches.Add(new XAttribute("part", "Catches"));
    		foreach(var x in node.Catches)
    		{
    			xCatches.Add(this.Visit(x));
    		}
    		result.Add(xCatches);
    		if(node.Finally != null)
    		{
    			var xFinally = this.Visit(node.Finally);
    			xFinally.Add(new XAttribute("part", "Finally"));
    			result.Add(xFinally);
    		}
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a ForEachStatementSyntax node.
        /// </summary>
        public override XElement VisitForEachStatement(Microsoft.CodeAnalysis.CSharp.Syntax.ForEachStatementSyntax node)
        {
    		var result = new XElement("ForEachStatement");
    		var xForEachKeyword = new XElement("Token");
    		//xForEachKeyword.Add(new XAttribute("part", "ForEachKeyword"));
    		result.Add(xForEachKeyword);
    		var xOpenParenToken = new XElement("Token");
    		//xOpenParenToken.Add(new XAttribute("part", "OpenParenToken"));
    		result.Add(xOpenParenToken);
    		var xType = this.Visit(node.Type);
    		xType.Add(new XAttribute("part", "Type"));
    		result.Add(xType);
    		var xIdentifier = new XElement("Token");
    		//xIdentifier.Add(new XAttribute("part", "Identifier"));
    		result.Add(xIdentifier);
    		var xInKeyword = new XElement("Token");
    		//xInKeyword.Add(new XAttribute("part", "InKeyword"));
    		result.Add(xInKeyword);
    		var xExpression = this.Visit(node.Expression);
    		xExpression.Add(new XAttribute("part", "Expression"));
    		result.Add(xExpression);
    		var xCloseParenToken = new XElement("Token");
    		//xCloseParenToken.Add(new XAttribute("part", "CloseParenToken"));
    		result.Add(xCloseParenToken);
    		var xStatement = this.Visit(node.Statement);
    		xStatement.Add(new XAttribute("part", "Statement"));
    		result.Add(xStatement);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a SingleVariableDesignationSyntax node.
        /// </summary>
        public override XElement VisitSingleVariableDesignation(Microsoft.CodeAnalysis.CSharp.Syntax.SingleVariableDesignationSyntax node)
        {
    		var result = new XElement("SingleVariableDesignation");
    		var xIdentifier = new XElement("Token");
    		//xIdentifier.Add(new XAttribute("part", "Identifier"));
    		result.Add(xIdentifier);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a DiscardDesignationSyntax node.
        /// </summary>
        public override XElement VisitDiscardDesignation(Microsoft.CodeAnalysis.CSharp.Syntax.DiscardDesignationSyntax node)
        {
    		var result = new XElement("DiscardDesignation");
    		var xUnderscoreToken = new XElement("Token");
    		//xUnderscoreToken.Add(new XAttribute("part", "UnderscoreToken"));
    		result.Add(xUnderscoreToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a ParenthesizedVariableDesignationSyntax node.
        /// </summary>
        public override XElement VisitParenthesizedVariableDesignation(Microsoft.CodeAnalysis.CSharp.Syntax.ParenthesizedVariableDesignationSyntax node)
        {
    		var result = new XElement("ParenthesizedVariableDesignation");
    		var xOpenParenToken = new XElement("Token");
    		//xOpenParenToken.Add(new XAttribute("part", "OpenParenToken"));
    		result.Add(xOpenParenToken);
    		var xVariables = new XElement("SeparatedList_of_VariableDesignation");
    		xVariables.Add(new XAttribute("part", "Variables"));
    		foreach(var x in node.Variables)
    		{
    			xVariables.Add(this.Visit(x));
    		}
    		result.Add(xVariables);
    		var xCloseParenToken = new XElement("Token");
    		//xCloseParenToken.Add(new XAttribute("part", "CloseParenToken"));
    		result.Add(xCloseParenToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a CasePatternSwitchLabelSyntax node.
        /// </summary>
        public override XElement VisitCasePatternSwitchLabel(Microsoft.CodeAnalysis.CSharp.Syntax.CasePatternSwitchLabelSyntax node)
        {
    		var result = new XElement("CasePatternSwitchLabel");
    		var xKeyword = new XElement("Token");
    		//xKeyword.Add(new XAttribute("part", "Keyword"));
    		result.Add(xKeyword);
    		var xPattern = this.Visit(node.Pattern);
    		xPattern.Add(new XAttribute("part", "Pattern"));
    		result.Add(xPattern);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a CaseSwitchLabelSyntax node.
        /// </summary>
        public override XElement VisitCaseSwitchLabel(Microsoft.CodeAnalysis.CSharp.Syntax.CaseSwitchLabelSyntax node)
        {
    		var result = new XElement("CaseSwitchLabel");
    		var xKeyword = new XElement("Token");
    		//xKeyword.Add(new XAttribute("part", "Keyword"));
    		result.Add(xKeyword);
    		var xValue = this.Visit(node.Value);
    		xValue.Add(new XAttribute("part", "Value"));
    		result.Add(xValue);
    		var xColonToken = new XElement("Token");
    		//xColonToken.Add(new XAttribute("part", "ColonToken"));
    		result.Add(xColonToken);
    		return result;
        }
    
    	/// <summary>
        /// Called when the visitor visits a DefaultSwitchLabelSyntax node.
        /// </summary>
        public override XElement VisitDefaultSwitchLabel(Microsoft.CodeAnalysis.CSharp.Syntax.DefaultSwitchLabelSyntax node)
        {
    		var result = new XElement("DefaultSwitchLabel");
    		var xKeyword = new XElement("Token");
    		//xKeyword.Add(new XAttribute("part", "Keyword"));
    		result.Add(xKeyword);
    		var xColonToken = new XElement("Token");
    		//xColonToken.Add(new XAttribute("part", "ColonToken"));
    		result.Add(xColonToken);
    		return result;
        }
    
    }
}
// Generated helper templates
// Generated items
