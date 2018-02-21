namespace Jawilliam.CDF.CSharp.RoslynML
{
    using Microsoft.CodeAnalysis.CSharp;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    	//public virtual ExpressionSyntax<TAnnotation> Expression { get; set; } 
    	//public virtual SyntaxToken<TAnnotation> OperatorToken { get; private set; } 
    	//public virtual ExpressionSyntax<TAnnotation> WhenNotNull { get; set; } 
    
    public partial class RoslynML : CSharpSyntaxVisitor<XElement>
    {
    	/// <summary>
        /// Called when the visitor visits a ConditionalAccessExpressionSyntax node.
        /// </summary>
        public override XElement VisitConditionalAccessExpression(Microsoft.CodeAnalysis.CSharp.Syntax.ConditionalAccessExpressionSyntax node)
        {
            //var result = new ConditionalAccessExpressionSyntax<TAnnotation>();
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
