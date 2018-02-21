namespace Jawilliam.CDF.CSharp.RoslynML
{
    using Microsoft.CodeAnalysis.CSharp;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    	//public virtual TypeSyntax<TAnnotation> Name { get; set; } 
    	//public virtual CrefParameterListSyntax<TAnnotation> Parameters { get; set; } 
    
    public partial class RoslynML : CSharpSyntaxVisitor<XElement>
    {
    	/// <summary>
        /// Called when the visitor visits a NameMemberCrefSyntax node.
        /// </summary>
        public override XElement VisitNameMemberCref(Microsoft.CodeAnalysis.CSharp.Syntax.NameMemberCrefSyntax node)
        {
            //var result = new NameMemberCrefSyntax<TAnnotation>();
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
