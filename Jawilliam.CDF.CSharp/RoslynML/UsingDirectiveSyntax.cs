namespace Jawilliam.CDF.CSharp.RoslynML
{
    using Microsoft.CodeAnalysis.CSharp;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    	//public virtual SyntaxToken<TAnnotation> UsingKeyword { get; private set; } 
    	//public virtual SyntaxToken<TAnnotation> StaticKeyword { get; set; } 
    	//public virtual NameEqualsSyntax<TAnnotation> Alias { get; set; } 
    	//public virtual NameSyntax<TAnnotation> Name { get; set; } 
    	//public virtual SyntaxToken<TAnnotation> SemicolonToken { get; private set; } 
    
    public partial class RoslynML : CSharpSyntaxVisitor<XElement>
    {
    	/// <summary>
        /// Called when the visitor visits a UsingDirectiveSyntax node.
        /// </summary>
        public override XElement VisitUsingDirective(Microsoft.CodeAnalysis.CSharp.Syntax.UsingDirectiveSyntax node)
        {
            //var result = new UsingDirectiveSyntax<TAnnotation>();
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
