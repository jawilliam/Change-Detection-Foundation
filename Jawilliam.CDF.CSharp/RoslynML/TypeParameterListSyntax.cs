namespace Jawilliam.CDF.CSharp.RoslynML
{
    using Microsoft.CodeAnalysis.CSharp;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    	//public virtual SyntaxToken<TAnnotation> LessThanToken { get; private set; } 
    	//public virtual SeparatedSyntaxList<TAnnotation, TypeParameterSyntax<TAnnotation>> Parameters { get; set; } 
    	//public virtual SyntaxToken<TAnnotation> GreaterThanToken { get; private set; } 
    
    public partial class RoslynML : CSharpSyntaxVisitor<XElement>
    {
    	/// <summary>
        /// Called when the visitor visits a TypeParameterListSyntax node.
        /// </summary>
        public override XElement VisitTypeParameterList(Microsoft.CodeAnalysis.CSharp.Syntax.TypeParameterListSyntax node)
        {
            //var result = new TypeParameterListSyntax<TAnnotation>();
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
