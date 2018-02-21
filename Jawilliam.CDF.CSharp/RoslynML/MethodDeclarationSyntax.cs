namespace Jawilliam.CDF.CSharp.RoslynML
{
    using Microsoft.CodeAnalysis.CSharp;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    	//public virtual TypeSyntax<TAnnotation> ReturnType { get; set; } 
    	//public virtual ExplicitInterfaceSpecifierSyntax<TAnnotation> ExplicitInterfaceSpecifier { get; set; } 
    	//public virtual SyntaxToken<TAnnotation> Identifier { get; set; } 
    	//public virtual TypeParameterListSyntax<TAnnotation> TypeParameterList { get; set; } 
    	//public virtual SyntaxList<TAnnotation, TypeParameterConstraintClauseSyntax<TAnnotation>> ConstraintClauses { get; set; } 
    	//public virtual ArrowExpressionClauseSyntax<TAnnotation> ExpressionBody { get; set; } 
    
    public partial class RoslynML : CSharpSyntaxVisitor<XElement>
    {
    	/// <summary>
        /// Called when the visitor visits a MethodDeclarationSyntax node.
        /// </summary>
        public override XElement VisitMethodDeclaration(Microsoft.CodeAnalysis.CSharp.Syntax.MethodDeclarationSyntax node)
        {
            //var result = new MethodDeclarationSyntax<TAnnotation>();
            //var oldConverter = result.Converter;
            //try
            //{
            //    result.Converter = this;
            //    result.Copy(node);
            //}
            //finally
            //{
            //    result.Converter = oldConverter;
            //}
            //
            //return result;
    		return null;
        }
    }
}
