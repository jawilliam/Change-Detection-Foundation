namespace Jawilliam.CDF.CSharp.RoslynML
{
    using Microsoft.CodeAnalysis.CSharp;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    	//public virtual SyntaxList<TAnnotation, AttributeListSyntax<TAnnotation>> AttributeLists { get; set; } 
    	//public virtual SyntaxTokenList<TAnnotation> Modifiers { get; set; } 
    	//public virtual SyntaxToken<TAnnotation> Keyword { get; set; } 
    	//public virtual BlockSyntax<TAnnotation> Body { get; set; } 
    	//public virtual SyntaxToken<TAnnotation> SemicolonToken { get; set; } 
    
    public partial class RoslynML : CSharpSyntaxVisitor<XElement>
    {
    	/// <summary>
        /// Called when the visitor visits a AccessorDeclarationSyntax node.
        /// </summary>
        public override XElement VisitAccessorDeclaration(Microsoft.CodeAnalysis.CSharp.Syntax.AccessorDeclarationSyntax node)
        {
            //var result = new AccessorDeclarationSyntax<TAnnotation>();
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
