namespace Jawilliam.CDF.CSharp.RoslynML
{
    using Microsoft.CodeAnalysis.CSharp;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    	//public virtual NameEqualsSyntax<TAnnotation> NameEquals { get; set; } 
    	//public virtual ExpressionSyntax<TAnnotation> Expression { get; set; } 
    
    public partial class RoslynML : CSharpSyntaxVisitor<XElement>
    {
    	/// <summary>
        /// Called when the visitor visits a AnonymousObjectMemberDeclaratorSyntax node.
        /// </summary>
        public override XElement VisitAnonymousObjectMemberDeclarator(Microsoft.CodeAnalysis.CSharp.Syntax.AnonymousObjectMemberDeclaratorSyntax node)
        {
            //var result = new AnonymousObjectMemberDeclaratorSyntax<TAnnotation>();
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
