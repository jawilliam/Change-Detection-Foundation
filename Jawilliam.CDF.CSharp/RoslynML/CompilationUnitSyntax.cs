namespace Jawilliam.CDF.CSharp.RoslynML
{
    using Microsoft.CodeAnalysis.CSharp;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    	//public virtual SyntaxList<TAnnotation, ExternAliasDirectiveSyntax<TAnnotation>> Externs { get; set; } 
    	//public virtual SyntaxList<TAnnotation, UsingDirectiveSyntax<TAnnotation>> Usings { get; set; } 
    	//public virtual SyntaxList<TAnnotation, AttributeListSyntax<TAnnotation>> AttributeLists { get; set; } 
    	//public virtual SyntaxList<TAnnotation, MemberDeclarationSyntax<TAnnotation>> Members { get; set; } 
    	//public virtual SyntaxToken<TAnnotation> EndOfFileToken { get; private set; } 
    
    public partial class RoslynML : CSharpSyntaxVisitor<XElement>
    {
    	/// <summary>
        /// Called when the visitor visits a CompilationUnitSyntax node.
        /// </summary>
        public override XElement VisitCompilationUnit(Microsoft.CodeAnalysis.CSharp.Syntax.CompilationUnitSyntax node)
        {
            //var result = new CompilationUnitSyntax<TAnnotation>();
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
