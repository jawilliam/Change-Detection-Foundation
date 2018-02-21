namespace Jawilliam.CDF.CSharp.RoslynML
{
    using Microsoft.CodeAnalysis.CSharp;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    	//public virtual SyntaxToken<TAnnotation> OpenBracketToken { get; private set; } 
    	//public virtual SeparatedSyntaxList<TAnnotation, ExpressionSyntax<TAnnotation>> Sizes { get; set; } 
    	//public virtual SyntaxToken<TAnnotation> CloseBracketToken { get; private set; } 
    
    public partial class RoslynML : CSharpSyntaxVisitor<XElement>
    {
    	/// <summary>
        /// Called when the visitor visits a ArrayRankSpecifierSyntax node.
        /// </summary>
        public override XElement VisitArrayRankSpecifier(Microsoft.CodeAnalysis.CSharp.Syntax.ArrayRankSpecifierSyntax node)
        {
            //var result = new ArrayRankSpecifierSyntax<TAnnotation>();
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
