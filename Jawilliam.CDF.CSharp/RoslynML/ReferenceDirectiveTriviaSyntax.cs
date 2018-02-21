namespace Jawilliam.CDF.CSharp.RoslynML
{
    using Microsoft.CodeAnalysis.CSharp;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    	//public virtual SyntaxToken<TAnnotation> ReferenceKeyword { get; private set; } 
    	//public virtual SyntaxToken<TAnnotation> File { get; set; } 
    
    public partial class RoslynML : CSharpSyntaxVisitor<XElement>
    {
    	/// <summary>
        /// Called when the visitor visits a ReferenceDirectiveTriviaSyntax node.
        /// </summary>
        public override XElement VisitReferenceDirectiveTrivia(Microsoft.CodeAnalysis.CSharp.Syntax.ReferenceDirectiveTriviaSyntax node)
        {
            //var result = new ReferenceDirectiveTriviaSyntax<TAnnotation>();
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
