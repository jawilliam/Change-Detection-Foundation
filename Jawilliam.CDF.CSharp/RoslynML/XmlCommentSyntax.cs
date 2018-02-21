namespace Jawilliam.CDF.CSharp.RoslynML
{
    using Microsoft.CodeAnalysis.CSharp;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    	//public virtual SyntaxToken<TAnnotation> LessThanExclamationMinusMinusToken { get; private set; } 
    	//public virtual SyntaxTokenList<TAnnotation> TextTokens { get; set; } 
    	//public virtual SyntaxToken<TAnnotation> MinusMinusGreaterThanToken { get; private set; } 
    
    public partial class RoslynML : CSharpSyntaxVisitor<XElement>
    {
    	/// <summary>
        /// Called when the visitor visits a XmlCommentSyntax node.
        /// </summary>
        public override XElement VisitXmlComment(Microsoft.CodeAnalysis.CSharp.Syntax.XmlCommentSyntax node)
        {
            //var result = new XmlCommentSyntax<TAnnotation>();
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
