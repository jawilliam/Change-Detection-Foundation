namespace Jawilliam.CDF.CSharp.RoslynML
{
    using Microsoft.CodeAnalysis.CSharp;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    	//public virtual SyntaxToken<TAnnotation> IntoKeyword { get; private set; } 
    	//public virtual SyntaxToken<TAnnotation> Identifier { get; set; } 
    	//public virtual QueryBodySyntax<TAnnotation> Body { get; set; } 
    
    public partial class RoslynML : CSharpSyntaxVisitor<XElement>
    {
    	/// <summary>
        /// Called when the visitor visits a QueryContinuationSyntax node.
        /// </summary>
        public override XElement VisitQueryContinuation(Microsoft.CodeAnalysis.CSharp.Syntax.QueryContinuationSyntax node)
        {
            //var result = new QueryContinuationSyntax<TAnnotation>();
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
