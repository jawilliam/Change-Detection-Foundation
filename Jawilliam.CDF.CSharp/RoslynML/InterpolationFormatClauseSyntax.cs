namespace Jawilliam.CDF.CSharp.RoslynML
{
    using Microsoft.CodeAnalysis.CSharp;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    	//public virtual SyntaxToken<TAnnotation> ColonToken { get; private set; } 
    	//public virtual SyntaxToken<TAnnotation> FormatStringToken { get; private set; } 
    
    public partial class RoslynML : CSharpSyntaxVisitor<XElement>
    {
    	/// <summary>
        /// Called when the visitor visits a InterpolationFormatClauseSyntax node.
        /// </summary>
        public override XElement VisitInterpolationFormatClause(Microsoft.CodeAnalysis.CSharp.Syntax.InterpolationFormatClauseSyntax node)
        {
            //var result = new InterpolationFormatClauseSyntax<TAnnotation>();
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
