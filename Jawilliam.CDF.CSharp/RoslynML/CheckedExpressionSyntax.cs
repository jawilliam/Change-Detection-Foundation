namespace Jawilliam.CDF.CSharp.RoslynML
{
    using Microsoft.CodeAnalysis.CSharp;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    	//public virtual SyntaxToken<TAnnotation> Keyword { get; private set; } 
    	//public virtual SyntaxToken<TAnnotation> OpenParenToken { get; private set; } 
    	//public virtual ExpressionSyntax<TAnnotation> Expression { get; set; } 
    	//public virtual SyntaxToken<TAnnotation> CloseParenToken { get; private set; } 
    
    public partial class RoslynML : CSharpSyntaxVisitor<XElement>
    {
    	/// <summary>
        /// Called when the visitor visits a CheckedExpressionSyntax node.
        /// </summary>
        public override XElement VisitCheckedExpression(Microsoft.CodeAnalysis.CSharp.Syntax.CheckedExpressionSyntax node)
        {
            //var result = new CheckedExpressionSyntax<TAnnotation>();
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
