namespace Jawilliam.CDF.CSharp.RoslynML
{
    using Microsoft.CodeAnalysis.CSharp;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    	//public virtual SyntaxToken<TAnnotation> LessThanToken { get; private set; } 
    	//public virtual XmlNameSyntax<TAnnotation> Name { get; set; } 
    	//public virtual SyntaxList<TAnnotation, XmlAttributeSyntax<TAnnotation>> Attributes { get; set; } 
    	//public virtual SyntaxToken<TAnnotation> SlashGreaterThanToken { get; private set; } 
    
    public partial class RoslynML : CSharpSyntaxVisitor<XElement>
    {
    	/// <summary>
        /// Called when the visitor visits a XmlEmptyElementSyntax node.
        /// </summary>
        public override XElement VisitXmlEmptyElement(Microsoft.CodeAnalysis.CSharp.Syntax.XmlEmptyElementSyntax node)
        {
            //var result = new XmlEmptyElementSyntax<TAnnotation>();
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
