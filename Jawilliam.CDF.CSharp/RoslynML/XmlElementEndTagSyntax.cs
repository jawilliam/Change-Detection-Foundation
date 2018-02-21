namespace Jawilliam.CDF.CSharp.RoslynML
{
    using Microsoft.CodeAnalysis.CSharp;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    	//public virtual SyntaxToken<TAnnotation> LessThanSlashToken { get; private set; } 
    	//public virtual XmlNameSyntax<TAnnotation> Name { get; set; } 
    	//public virtual SyntaxToken<TAnnotation> GreaterThanToken { get; private set; } 
    
    public partial class RoslynML : CSharpSyntaxVisitor<XElement>
    {
    	/// <summary>
        /// Called when the visitor visits a XmlElementEndTagSyntax node.
        /// </summary>
        public override XElement VisitXmlElementEndTag(Microsoft.CodeAnalysis.CSharp.Syntax.XmlElementEndTagSyntax node)
        {
            //var result = new XmlElementEndTagSyntax<TAnnotation>();
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
