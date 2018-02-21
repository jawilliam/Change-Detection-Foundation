namespace Jawilliam.CDF.CSharp.RoslynML
{
    using Microsoft.CodeAnalysis.CSharp;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    	//public virtual SyntaxToken<TAnnotation> PragmaKeyword { get; private set; } 
    	//public virtual SyntaxToken<TAnnotation> WarningKeyword { get; private set; } 
    	//public virtual SyntaxToken<TAnnotation> DisableOrRestoreKeyword { get; set; } 
    	//public virtual SeparatedSyntaxList<TAnnotation, ExpressionSyntax<TAnnotation>> ErrorCodes { get; set; } 
    
    public partial class RoslynML : CSharpSyntaxVisitor<XElement>
    {
    	/// <summary>
        /// Called when the visitor visits a PragmaWarningDirectiveTriviaSyntax node.
        /// </summary>
        public override XElement VisitPragmaWarningDirectiveTrivia(Microsoft.CodeAnalysis.CSharp.Syntax.PragmaWarningDirectiveTriviaSyntax node)
        {
            //var result = new PragmaWarningDirectiveTriviaSyntax<TAnnotation>();
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
