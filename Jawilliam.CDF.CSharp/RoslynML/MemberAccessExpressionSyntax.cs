namespace Jawilliam.CDF.CSharp.RoslynML
{
    using Microsoft.CodeAnalysis.CSharp;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    	//public virtual ExpressionSyntax<TAnnotation> Expression { get; set; } 
    	//public virtual SyntaxToken<TAnnotation> OperatorToken { get; private set; } 
    	//public virtual SimpleNameSyntax<TAnnotation> Name { get; set; } 
    
    public partial class RoslynML : CSharpSyntaxVisitor<XElement>
    {
    	/// <summary>
        /// Called when the visitor visits a MemberAccessExpressionSyntax node.
        /// </summary>
        public override XElement VisitMemberAccessExpression(Microsoft.CodeAnalysis.CSharp.Syntax.MemberAccessExpressionSyntax node)
        {
            //var result = new MemberAccessExpressionSyntax<TAnnotation>();
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
