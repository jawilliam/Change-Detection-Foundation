namespace Jawilliam.CDF.CSharp.RoslynML
{
    using Microsoft.CodeAnalysis.CSharp;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    	//public virtual TypeSyntax<TAnnotation> ReturnType { get; set; } 
    	//public virtual SyntaxToken<TAnnotation> OperatorKeyword { get; private set; } 
    	//public virtual SyntaxToken<TAnnotation> OperatorToken { get; set; } 
    	//public virtual ArrowExpressionClauseSyntax<TAnnotation> ExpressionBody { get; set; } 
    
    public partial class RoslynML : CSharpSyntaxVisitor<XElement>
    {
    	/// <summary>
        /// Called when the visitor visits a OperatorDeclarationSyntax node.
        /// </summary>
        public override XElement VisitOperatorDeclaration(Microsoft.CodeAnalysis.CSharp.Syntax.OperatorDeclarationSyntax node)
        {
            //var result = new OperatorDeclarationSyntax<TAnnotation>();
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
