namespace Jawilliam.CDF.CSharp.RoslynML
{
    using Microsoft.CodeAnalysis.CSharp;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    	//public virtual SyntaxToken<TAnnotation> OpenBracketToken { get; private set; } 
    	//public virtual SyntaxToken<TAnnotation> CloseBracketToken { get; private set; } 
    
    public partial class RoslynML : CSharpSyntaxVisitor<XElement>
    {
    	/// <summary>
        /// Called when the visitor visits a BracketedParameterListSyntax node.
        /// </summary>
        public override XElement VisitBracketedParameterList(Microsoft.CodeAnalysis.CSharp.Syntax.BracketedParameterListSyntax node)
        {
            //var result = new BracketedParameterListSyntax<TAnnotation>();
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
