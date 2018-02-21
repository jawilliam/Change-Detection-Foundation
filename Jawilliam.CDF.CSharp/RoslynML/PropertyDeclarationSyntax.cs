namespace Jawilliam.CDF.CSharp.RoslynML
{
    using Microsoft.CodeAnalysis.CSharp;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    	//public virtual SyntaxToken<TAnnotation> Identifier { get; set; } 
    	//public virtual ArrowExpressionClauseSyntax<TAnnotation> ExpressionBody { get; set; } 
    	//public virtual EqualsValueClauseSyntax<TAnnotation> Initializer { get; set; } 
    	//public virtual SyntaxToken<TAnnotation> SemicolonToken { get; set; } 
    
    public partial class RoslynML : CSharpSyntaxVisitor<XElement>
    {
    	/// <summary>
        /// Called when the visitor visits a PropertyDeclarationSyntax node.
        /// </summary>
        public override XElement VisitPropertyDeclaration(Microsoft.CodeAnalysis.CSharp.Syntax.PropertyDeclarationSyntax node)
        {
            //var result = new PropertyDeclarationSyntax<TAnnotation>();
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
