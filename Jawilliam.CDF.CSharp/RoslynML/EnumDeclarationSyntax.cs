namespace Jawilliam.CDF.CSharp.RoslynML
{
    using Microsoft.CodeAnalysis.CSharp;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    	//public virtual SyntaxToken<TAnnotation> EnumKeyword { get; private set; } 
    	//public virtual SeparatedSyntaxList<TAnnotation, EnumMemberDeclarationSyntax<TAnnotation>> Members { get; set; } 
    
    public partial class RoslynML : CSharpSyntaxVisitor<XElement>
    {
    	/// <summary>
        /// Called when the visitor visits a EnumDeclarationSyntax node.
        /// </summary>
        public override XElement VisitEnumDeclaration(Microsoft.CodeAnalysis.CSharp.Syntax.EnumDeclarationSyntax node)
        {
            //var result = new EnumDeclarationSyntax<TAnnotation>();
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
