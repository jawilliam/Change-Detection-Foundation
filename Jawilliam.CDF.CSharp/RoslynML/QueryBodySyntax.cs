namespace Jawilliam.CDF.CSharp.RoslynML
{
    using Microsoft.CodeAnalysis.CSharp;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    	//public virtual SyntaxList<TAnnotation, QueryClauseSyntax<TAnnotation>> Clauses { get; set; } 
    	//public virtual SelectOrGroupClauseSyntax<TAnnotation> SelectOrGroup { get; set; } 
    	//public virtual QueryContinuationSyntax<TAnnotation> Continuation { get; set; } 
    
    public partial class RoslynML : CSharpSyntaxVisitor<XElement>
    {
    	/// <summary>
        /// Called when the visitor visits a QueryBodySyntax node.
        /// </summary>
        public override XElement VisitQueryBody(Microsoft.CodeAnalysis.CSharp.Syntax.QueryBodySyntax node)
        {
            //var result = new QueryBodySyntax<TAnnotation>();
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
