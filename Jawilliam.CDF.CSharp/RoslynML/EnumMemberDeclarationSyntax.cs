namespace Jawilliam.CDF.CSharp.RoslynML
{
    using Microsoft.CodeAnalysis.CSharp;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    	//public virtual SyntaxList<TAnnotation, AttributeListSyntax<TAnnotation>> AttributeLists { get; set; } 
    	//public virtual SyntaxToken<TAnnotation> Identifier { get; set; } 
    	//public virtual EqualsValueClauseSyntax<TAnnotation> EqualsValue { get; set; } 
    
    public partial class RoslynML : CSharpSyntaxVisitor<XElement>
    {
    	/// <summary>
        /// Called when the visitor visits a EnumMemberDeclarationSyntax node.
        /// </summary>
        public override XElement VisitEnumMemberDeclaration(Microsoft.CodeAnalysis.CSharp.Syntax.EnumMemberDeclarationSyntax node)
        {
            //var result = new EnumMemberDeclarationSyntax<TAnnotation>();
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
