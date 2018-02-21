namespace Jawilliam.CDF.CSharp.RoslynML
{
    using Microsoft.CodeAnalysis.CSharp;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    	//public virtual SyntaxToken<TAnnotation> EqualsToken { get; private set; } 
    	//public virtual ExpressionSyntax<TAnnotation> Value { get; set; } 
    
    public partial class RoslynML : CSharpSyntaxVisitor<XElement>
    {
    	/// <summary>
        /// Called when the visitor visits a EqualsValueClauseSyntax node.
        /// </summary>
        public override XElement VisitEqualsValueClause(Microsoft.CodeAnalysis.CSharp.Syntax.EqualsValueClauseSyntax node)
        {
            //var result = new EqualsValueClauseSyntax<TAnnotation>();
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
