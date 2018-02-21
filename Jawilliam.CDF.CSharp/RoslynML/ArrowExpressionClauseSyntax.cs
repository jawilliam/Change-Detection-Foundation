namespace Jawilliam.CDF.CSharp.RoslynML
{
    using Microsoft.CodeAnalysis.CSharp;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    	//public virtual SyntaxToken<TAnnotation> ArrowToken { get; private set; } 
    	//public virtual ExpressionSyntax<TAnnotation> Expression { get; set; } 
    
    public partial class RoslynML : CSharpSyntaxVisitor<XElement>
    {
    	/// <summary>
        /// Called when the visitor visits a ArrowExpressionClauseSyntax node.
        /// </summary>
        public override XElement VisitArrowExpressionClause(Microsoft.CodeAnalysis.CSharp.Syntax.ArrowExpressionClauseSyntax node)
        {
            //var result = new ArrowExpressionClauseSyntax<TAnnotation>();
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
