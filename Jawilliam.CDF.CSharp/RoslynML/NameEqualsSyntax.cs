namespace Jawilliam.CDF.CSharp.RoslynML
{
    using Microsoft.CodeAnalysis.CSharp;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    	//public virtual IdentifierNameSyntax<TAnnotation> Name { get; set; } 
    	//public virtual SyntaxToken<TAnnotation> EqualsToken { get; private set; } 
    
    public partial class RoslynML : CSharpSyntaxVisitor<XElement>
    {
    	/// <summary>
        /// Called when the visitor visits a NameEqualsSyntax node.
        /// </summary>
        public override XElement VisitNameEquals(Microsoft.CodeAnalysis.CSharp.Syntax.NameEqualsSyntax node)
        {
            //var result = new NameEqualsSyntax<TAnnotation>();
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
