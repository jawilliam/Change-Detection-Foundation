namespace Jawilliam.CDF.CSharp.RoslynML
{
    using Microsoft.CodeAnalysis.CSharp;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    	//public virtual SyntaxToken<TAnnotation> ThisKeyword { get; private set; } 
    	//public virtual BracketedParameterListSyntax<TAnnotation> ParameterList { get; set; } 
    	//public virtual ArrowExpressionClauseSyntax<TAnnotation> ExpressionBody { get; set; } 
    	//public virtual SyntaxToken<TAnnotation> SemicolonToken { get; set; } 
    
    public partial class RoslynML : CSharpSyntaxVisitor<XElement>
    {
    	/// <summary>
        /// Called when the visitor visits a IndexerDeclarationSyntax node.
        /// </summary>
        public override XElement VisitIndexerDeclaration(Microsoft.CodeAnalysis.CSharp.Syntax.IndexerDeclarationSyntax node)
        {
            //var result = new IndexerDeclarationSyntax<TAnnotation>();
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
