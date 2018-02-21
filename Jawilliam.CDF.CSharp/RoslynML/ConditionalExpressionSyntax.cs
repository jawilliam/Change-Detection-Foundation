namespace Jawilliam.CDF.CSharp.RoslynML
{
    using Microsoft.CodeAnalysis.CSharp;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    	//public virtual ExpressionSyntax<TAnnotation> Condition { get; set; } 
    	//public virtual SyntaxToken<TAnnotation> QuestionToken { get; private set; } 
    	//public virtual ExpressionSyntax<TAnnotation> WhenTrue { get; set; } 
    	//public virtual SyntaxToken<TAnnotation> ColonToken { get; private set; } 
    	//public virtual ExpressionSyntax<TAnnotation> WhenFalse { get; set; } 
    
    public partial class RoslynML : CSharpSyntaxVisitor<XElement>
    {
    	/// <summary>
        /// Called when the visitor visits a ConditionalExpressionSyntax node.
        /// </summary>
        public override XElement VisitConditionalExpression(Microsoft.CodeAnalysis.CSharp.Syntax.ConditionalExpressionSyntax node)
        {
            //var result = new ConditionalExpressionSyntax<TAnnotation>();
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
