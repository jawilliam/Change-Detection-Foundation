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
        /// Called when the visitor visits a CrefBracketedParameterListSyntax node.
        /// </summary>
        public override XElement VisitCrefBracketedParameterList(Microsoft.CodeAnalysis.CSharp.Syntax.CrefBracketedParameterListSyntax node)
        {
            //var result = new CrefBracketedParameterListSyntax<TAnnotation>();
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
