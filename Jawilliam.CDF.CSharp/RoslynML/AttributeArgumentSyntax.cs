namespace Jawilliam.CDF.CSharp.RoslynML
{
    using Microsoft.CodeAnalysis.CSharp;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    	//public virtual NameEqualsSyntax<TAnnotation> NameEquals { get; set; } 
    	//public virtual NameColonSyntax<TAnnotation> NameColon { get; set; } 
    	//public virtual ExpressionSyntax<TAnnotation> Expression { get; set; } 
    
    public partial class RoslynML : CSharpSyntaxVisitor<XElement>
    {
    	/// <summary>
        /// Called when the visitor visits a AttributeArgumentSyntax node.
        /// </summary>
        public override XElement VisitAttributeArgument(Microsoft.CodeAnalysis.CSharp.Syntax.AttributeArgumentSyntax node)
        {
            //var result = new AttributeArgumentSyntax<TAnnotation>();
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
