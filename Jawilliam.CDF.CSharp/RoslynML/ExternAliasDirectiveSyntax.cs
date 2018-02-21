namespace Jawilliam.CDF.CSharp.RoslynML
{
    using Microsoft.CodeAnalysis.CSharp;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    	//public virtual SyntaxToken<TAnnotation> ExternKeyword { get; private set; } 
    	//public virtual SyntaxToken<TAnnotation> AliasKeyword { get; private set; } 
    	//public virtual SyntaxToken<TAnnotation> Identifier { get; set; } 
    	//public virtual SyntaxToken<TAnnotation> SemicolonToken { get; private set; } 
    
    public partial class RoslynML : CSharpSyntaxVisitor<XElement>
    {
    	/// <summary>
        /// Called when the visitor visits a ExternAliasDirectiveSyntax node.
        /// </summary>
        public override XElement VisitExternAliasDirective(Microsoft.CodeAnalysis.CSharp.Syntax.ExternAliasDirectiveSyntax node)
        {
            //var result = new ExternAliasDirectiveSyntax<TAnnotation>();
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
