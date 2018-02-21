namespace Jawilliam.CDF.CSharp.RoslynML
{
    using Microsoft.CodeAnalysis.CSharp;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    	//public virtual SyntaxToken<TAnnotation> PragmaKeyword { get; private set; } 
    	//public virtual SyntaxToken<TAnnotation> ChecksumKeyword { get; private set; } 
    	//public virtual SyntaxToken<TAnnotation> File { get; set; } 
    	//public virtual SyntaxToken<TAnnotation> Guid { get; set; } 
    	//public virtual SyntaxToken<TAnnotation> Bytes { get; set; } 
    
    public partial class RoslynML : CSharpSyntaxVisitor<XElement>
    {
    	/// <summary>
        /// Called when the visitor visits a PragmaChecksumDirectiveTriviaSyntax node.
        /// </summary>
        public override XElement VisitPragmaChecksumDirectiveTrivia(Microsoft.CodeAnalysis.CSharp.Syntax.PragmaChecksumDirectiveTriviaSyntax node)
        {
            //var result = new PragmaChecksumDirectiveTriviaSyntax<TAnnotation>();
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
