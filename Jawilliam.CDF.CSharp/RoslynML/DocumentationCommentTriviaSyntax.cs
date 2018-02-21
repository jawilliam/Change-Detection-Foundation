namespace Jawilliam.CDF.CSharp.RoslynML
{
    using Microsoft.CodeAnalysis.CSharp;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    	//public virtual SyntaxList<TAnnotation, XmlNodeSyntax<TAnnotation>> Content { get; set; } 
    	//public virtual SyntaxToken<TAnnotation> EndOfComment { get; private set; } 
    
    public partial class RoslynML : CSharpSyntaxVisitor<XElement>
    {
    	/// <summary>
        /// Called when the visitor visits a DocumentationCommentTriviaSyntax node.
        /// </summary>
        public override XElement VisitDocumentationCommentTrivia(Microsoft.CodeAnalysis.CSharp.Syntax.DocumentationCommentTriviaSyntax node)
        {
            //var result = new DocumentationCommentTriviaSyntax<TAnnotation>();
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
