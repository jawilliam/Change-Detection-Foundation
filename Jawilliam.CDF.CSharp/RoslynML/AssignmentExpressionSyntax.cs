namespace Jawilliam.CDF.CSharp.RoslynML
{
    using Microsoft.CodeAnalysis.CSharp;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    	//public virtual ExpressionSyntax<TAnnotation> Left { get; set; } 
    	//public virtual SyntaxToken<TAnnotation> OperatorToken { get; set; } 
    	//public virtual ExpressionSyntax<TAnnotation> Right { get; set; } 
    
    public partial class RoslynML : CSharpSyntaxVisitor<XElement>
    {
    	/// <summary>
        /// Called when the visitor visits a AssignmentExpressionSyntax node.
        /// </summary>
        public override XElement VisitAssignmentExpression(Microsoft.CodeAnalysis.CSharp.Syntax.AssignmentExpressionSyntax node)
        {
            //var result = new AssignmentExpressionSyntax<TAnnotation>();
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
