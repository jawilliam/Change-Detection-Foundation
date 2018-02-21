namespace Jawilliam.CDF.CSharp.RoslynML
{
    using Microsoft.CodeAnalysis.CSharp;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    	//public virtual SyntaxToken<TAnnotation> UndefKeyword { get; private set; } 
    	//public virtual SyntaxToken<TAnnotation> Name { get; set; } 
    
    public partial class RoslynML : CSharpSyntaxVisitor<XElement>
    {
    	/// <summary>
        /// Called when the visitor visits a UndefDirectiveTriviaSyntax node.
        /// </summary>
        public override XElement VisitUndefDirectiveTrivia(Microsoft.CodeAnalysis.CSharp.Syntax.UndefDirectiveTriviaSyntax node)
        {
            //var result = new UndefDirectiveTriviaSyntax<TAnnotation>();
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
