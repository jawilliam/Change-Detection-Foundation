namespace Jawilliam.CDF.CSharp.RoslynML
{
    using Microsoft.CodeAnalysis.CSharp;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    	//public virtual SyntaxToken<TAnnotation> OperatorToken { get; set; } 
    	//public virtual ExpressionSyntax<TAnnotation> Operand { get; set; } 
    
    public partial class RoslynML : CSharpSyntaxVisitor<XElement>
    {
    	/// <summary>
        /// Called when the visitor visits a PrefixUnaryExpressionSyntax node.
        /// </summary>
        public override XElement VisitPrefixUnaryExpression(Microsoft.CodeAnalysis.CSharp.Syntax.PrefixUnaryExpressionSyntax node)
        {
            //var result = new PrefixUnaryExpressionSyntax<TAnnotation>();
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
