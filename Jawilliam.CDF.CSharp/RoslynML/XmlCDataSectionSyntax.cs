namespace Jawilliam.CDF.CSharp.RoslynML
{
    using Microsoft.CodeAnalysis.CSharp;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    	//public virtual SyntaxToken<TAnnotation> StartCDataToken { get; private set; } 
    	//public virtual SyntaxTokenList<TAnnotation> TextTokens { get; set; } 
    	//public virtual SyntaxToken<TAnnotation> EndCDataToken { get; private set; } 
    
    public partial class RoslynML : CSharpSyntaxVisitor<XElement>
    {
    	/// <summary>
        /// Called when the visitor visits a XmlCDataSectionSyntax node.
        /// </summary>
        public override XElement VisitXmlCDataSection(Microsoft.CodeAnalysis.CSharp.Syntax.XmlCDataSectionSyntax node)
        {
            //var result = new XmlCDataSectionSyntax<TAnnotation>();
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
