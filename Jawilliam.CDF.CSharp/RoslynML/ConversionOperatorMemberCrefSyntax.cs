namespace Jawilliam.CDF.CSharp.RoslynML
{
    using Microsoft.CodeAnalysis.CSharp;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    	//public virtual SyntaxToken<TAnnotation> ImplicitOrExplicitKeyword { get; set; } 
    	//public virtual SyntaxToken<TAnnotation> OperatorKeyword { get; private set; } 
    	//public virtual TypeSyntax<TAnnotation> Type { get; set; } 
    	//public virtual CrefParameterListSyntax<TAnnotation> Parameters { get; set; } 
    
    public partial class RoslynML : CSharpSyntaxVisitor<XElement>
    {
    	/// <summary>
        /// Called when the visitor visits a ConversionOperatorMemberCrefSyntax node.
        /// </summary>
        public override XElement VisitConversionOperatorMemberCref(Microsoft.CodeAnalysis.CSharp.Syntax.ConversionOperatorMemberCrefSyntax node)
        {
            //var result = new ConversionOperatorMemberCrefSyntax<TAnnotation>();
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
