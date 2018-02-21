namespace Jawilliam.CDF.CSharp.RoslynML
{
    using Microsoft.CodeAnalysis.CSharp;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    	//public virtual SyntaxToken<TAnnotation> OpenBracketToken { get; private set; } 
    	//public virtual AttributeTargetSpecifierSyntax<TAnnotation> Target { get; set; } 
    	//public virtual SeparatedSyntaxList<TAnnotation, AttributeSyntax<TAnnotation>> Attributes { get; set; } 
    	//public virtual SyntaxToken<TAnnotation> CloseBracketToken { get; private set; } 
    
    public partial class RoslynML : CSharpSyntaxVisitor<XElement>
    {
    	/// <summary>
        /// Called when the visitor visits a AttributeListSyntax node.
        /// </summary>
        public override XElement VisitAttributeList(Microsoft.CodeAnalysis.CSharp.Syntax.AttributeListSyntax node)
        {
            //var result = new AttributeListSyntax<TAnnotation>();
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
