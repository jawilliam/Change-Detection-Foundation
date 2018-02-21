namespace Jawilliam.CDF.CSharp.RoslynML
{
    using Microsoft.CodeAnalysis.CSharp;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    	//public virtual NameColonSyntax<TAnnotation> NameColon { get; set; } 
    	//public virtual SyntaxToken<TAnnotation> RefOrOutKeyword { get; set; } 
    	//public virtual ExpressionSyntax<TAnnotation> Expression { get; set; } 
    
    public partial class RoslynML : CSharpSyntaxVisitor<XElement>
    {
    	/// <summary>
        /// Called when the visitor visits a ArgumentSyntax node.
        /// </summary>
        public override XElement VisitArgument(Microsoft.CodeAnalysis.CSharp.Syntax.ArgumentSyntax node)
        {
            //var result = new ArgumentSyntax<TAnnotation>();
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
