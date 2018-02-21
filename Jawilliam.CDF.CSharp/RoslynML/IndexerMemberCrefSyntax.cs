namespace Jawilliam.CDF.CSharp.RoslynML
{
    using Microsoft.CodeAnalysis.CSharp;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    	//public virtual SyntaxToken<TAnnotation> ThisKeyword { get; private set; } 
    	//public virtual CrefBracketedParameterListSyntax<TAnnotation> Parameters { get; set; } 
    
    public partial class RoslynML : CSharpSyntaxVisitor<XElement>
    {
    	/// <summary>
        /// Called when the visitor visits a IndexerMemberCrefSyntax node.
        /// </summary>
        public override XElement VisitIndexerMemberCref(Microsoft.CodeAnalysis.CSharp.Syntax.IndexerMemberCrefSyntax node)
        {
            //var result = new IndexerMemberCrefSyntax<TAnnotation>();
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
