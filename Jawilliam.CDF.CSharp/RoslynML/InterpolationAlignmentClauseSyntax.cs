namespace Jawilliam.CDF.CSharp.RoslynML
{
    using Microsoft.CodeAnalysis.CSharp;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    	//public virtual SyntaxToken<TAnnotation> CommaToken { get; private set; } 
    	//public virtual ExpressionSyntax<TAnnotation> Value { get; set; } 
    
    public partial class RoslynML : CSharpSyntaxVisitor<XElement>
    {
    	/// <summary>
        /// Called when the visitor visits a InterpolationAlignmentClauseSyntax node.
        /// </summary>
        public override XElement VisitInterpolationAlignmentClause(Microsoft.CodeAnalysis.CSharp.Syntax.InterpolationAlignmentClauseSyntax node)
        {
            //var result = new InterpolationAlignmentClauseSyntax<TAnnotation>();
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
