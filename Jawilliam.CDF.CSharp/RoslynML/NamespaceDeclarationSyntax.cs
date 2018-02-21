namespace Jawilliam.CDF.CSharp.RoslynML
{
    using Microsoft.CodeAnalysis.CSharp;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    	//public virtual SyntaxToken<TAnnotation> NamespaceKeyword { get; private set; } 
    	//public virtual NameSyntax<TAnnotation> Name { get; set; } 
    	//public virtual SyntaxToken<TAnnotation> OpenBraceToken { get; private set; } 
    	//public virtual SyntaxList<TAnnotation, ExternAliasDirectiveSyntax<TAnnotation>> Externs { get; set; } 
    	//public virtual SyntaxList<TAnnotation, UsingDirectiveSyntax<TAnnotation>> Usings { get; set; } 
    	//public virtual SyntaxList<TAnnotation, MemberDeclarationSyntax<TAnnotation>> Members { get; set; } 
    	//public virtual SyntaxToken<TAnnotation> CloseBraceToken { get; private set; } 
    	//public virtual SyntaxToken<TAnnotation> SemicolonToken { get; set; } 
    
    public partial class RoslynML : CSharpSyntaxVisitor<XElement>
    {
    	/// <summary>
        /// Called when the visitor visits a NamespaceDeclarationSyntax node.
        /// </summary>
        public override XElement VisitNamespaceDeclaration(Microsoft.CodeAnalysis.CSharp.Syntax.NamespaceDeclarationSyntax node)
        {
            //var result = new NamespaceDeclarationSyntax<TAnnotation>();
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
