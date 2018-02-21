namespace Jawilliam.CDF.CSharp.RoslynML
{
    using Microsoft.CodeAnalysis.CSharp;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    	//public virtual SyntaxList<TAnnotation, AttributeListSyntax<TAnnotation>> AttributeLists { get; set; } 
    	//public virtual SyntaxToken<TAnnotation> VarianceKeyword { get; set; } 
    	//public virtual SyntaxToken<TAnnotation> Identifier { get; set; } 
    
    public partial class RoslynML : CSharpSyntaxVisitor<XElement>
    {
    	/// <summary>
        /// Called when the visitor visits a TypeParameterSyntax node.
        /// </summary>
        public override XElement VisitTypeParameter(Microsoft.CodeAnalysis.CSharp.Syntax.TypeParameterSyntax node)
        {
            //var result = new TypeParameterSyntax<TAnnotation>();
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
