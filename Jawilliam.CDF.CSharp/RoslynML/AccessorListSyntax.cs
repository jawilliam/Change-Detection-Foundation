namespace Jawilliam.CDF.CSharp.RoslynML
{
    using Microsoft.CodeAnalysis.CSharp;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    	//public virtual SyntaxToken<TAnnotation> OpenBraceToken { get; private set; } 
    	//public virtual SyntaxList<TAnnotation, AccessorDeclarationSyntax<TAnnotation>> Accessors { get; set; } 
    	//public virtual SyntaxToken<TAnnotation> CloseBraceToken { get; private set; } 
    
    public partial class RoslynML : CSharpSyntaxVisitor<XElement>
    {
    	/// <summary>
        /// Called when the visitor visits a AccessorListSyntax node.
        /// </summary>
        public override XElement VisitAccessorList(Microsoft.CodeAnalysis.CSharp.Syntax.AccessorListSyntax node)
        {
            //var result = new AccessorListSyntax<TAnnotation>();
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
