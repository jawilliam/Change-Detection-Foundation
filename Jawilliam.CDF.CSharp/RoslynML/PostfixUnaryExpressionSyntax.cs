namespace Jawilliam.CDF.CSharp.RoslynML
{
    using Microsoft.CodeAnalysis.CSharp;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    	//public virtual ExpressionSyntax<TAnnotation> Operand { get; set; } 
    	//public virtual SyntaxToken<TAnnotation> OperatorToken { get; set; } 
    
    public partial class RoslynML : CSharpSyntaxVisitor<XElement>
    {
    	/// <summary>
        /// Called when the visitor visits a PostfixUnaryExpressionSyntax node.
        /// </summary>
        public override XElement VisitPostfixUnaryExpression(Microsoft.CodeAnalysis.CSharp.Syntax.PostfixUnaryExpressionSyntax node)
        {
            //var result = new PostfixUnaryExpressionSyntax<TAnnotation>();
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
