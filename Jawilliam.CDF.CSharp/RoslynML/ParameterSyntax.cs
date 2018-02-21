namespace Jawilliam.CDF.CSharp.RoslynML
{
    using Microsoft.CodeAnalysis.CSharp;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    	//public virtual SyntaxList<TAnnotation, AttributeListSyntax<TAnnotation>> AttributeLists { get; set; } 
    	//public virtual SyntaxTokenList<TAnnotation> Modifiers { get; set; } 
    	//public virtual TypeSyntax<TAnnotation> Type { get; set; } 
    	//public virtual SyntaxToken<TAnnotation> Identifier { get; set; } 
    	//public virtual EqualsValueClauseSyntax<TAnnotation> Default { get; set; } 
    
    public partial class RoslynML : CSharpSyntaxVisitor<XElement>
    {
    	/// <summary>
        /// Called when the visitor visits a ParameterSyntax node.
        /// </summary>
        public override XElement VisitParameter(Microsoft.CodeAnalysis.CSharp.Syntax.ParameterSyntax node)
        {
            //var result = new ParameterSyntax<TAnnotation>();
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
