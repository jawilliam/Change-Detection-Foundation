namespace Jawilliam.CDF.CSharp.RoslynML
{
    using Microsoft.CodeAnalysis.CSharp;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    	//public virtual XmlElementStartTagSyntax<TAnnotation> StartTag { get; set; } 
    	//public virtual SyntaxList<TAnnotation, XmlNodeSyntax<TAnnotation>> Content { get; set; } 
    	//public virtual XmlElementEndTagSyntax<TAnnotation> EndTag { get; set; } 
    
    public partial class RoslynML : CSharpSyntaxVisitor<XElement>
    {
    	/// <summary>
        /// Called when the visitor visits a XmlElementSyntax node.
        /// </summary>
        public override XElement VisitXmlElement(Microsoft.CodeAnalysis.CSharp.Syntax.XmlElementSyntax node)
        {
            //var result = new XmlElementSyntax<TAnnotation>();
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
