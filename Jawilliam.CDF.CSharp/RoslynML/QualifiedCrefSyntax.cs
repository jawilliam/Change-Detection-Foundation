namespace Jawilliam.CDF.CSharp.RoslynML
{
    using Microsoft.CodeAnalysis.CSharp;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    	//public virtual TypeSyntax<TAnnotation> Container { get; set; } 
    	//public virtual SyntaxToken<TAnnotation> DotToken { get; private set; } 
    	//public virtual MemberCrefSyntax<TAnnotation> Member { get; set; } 
    
    public partial class RoslynML : CSharpSyntaxVisitor<XElement>
    {
    	/// <summary>
        /// Called when the visitor visits a QualifiedCrefSyntax node.
        /// </summary>
        public override XElement VisitQualifiedCref(Microsoft.CodeAnalysis.CSharp.Syntax.QualifiedCrefSyntax node)
        {
            //var result = new QualifiedCrefSyntax<TAnnotation>();
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
