namespace Jawilliam.CDF.CSharp.RoslynML
{
    using Microsoft.CodeAnalysis.CSharp;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    	//public virtual SyntaxToken<TAnnotation> StartProcessingInstructionToken { get; private set; } 
    	//public virtual XmlNameSyntax<TAnnotation> Name { get; set; } 
    	//public virtual SyntaxTokenList<TAnnotation> TextTokens { get; set; } 
    	//public virtual SyntaxToken<TAnnotation> EndProcessingInstructionToken { get; private set; } 
    
    public partial class RoslynML : CSharpSyntaxVisitor<XElement>
    {
    	/// <summary>
        /// Called when the visitor visits a XmlProcessingInstructionSyntax node.
        /// </summary>
        public override XElement VisitXmlProcessingInstruction(Microsoft.CodeAnalysis.CSharp.Syntax.XmlProcessingInstructionSyntax node)
        {
            //var result = new XmlProcessingInstructionSyntax<TAnnotation>();
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
