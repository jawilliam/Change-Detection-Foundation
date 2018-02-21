namespace Jawilliam.CDF.CSharp.RoslynML
{
    using Microsoft.CodeAnalysis.CSharp;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    	//public virtual SyntaxToken<TAnnotation> LineKeyword { get; private set; } 
    	//public virtual SyntaxToken<TAnnotation> Line { get; set; } 
    	//public virtual SyntaxToken<TAnnotation> File { get; set; } 
    
    public partial class RoslynML : CSharpSyntaxVisitor<XElement>
    {
    	/// <summary>
        /// Called when the visitor visits a LineDirectiveTriviaSyntax node.
        /// </summary>
        public override XElement VisitLineDirectiveTrivia(Microsoft.CodeAnalysis.CSharp.Syntax.LineDirectiveTriviaSyntax node)
        {
            //var result = new LineDirectiveTriviaSyntax<TAnnotation>();
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
