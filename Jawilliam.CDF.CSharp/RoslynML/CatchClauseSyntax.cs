namespace Jawilliam.CDF.CSharp.RoslynML
{
    using Microsoft.CodeAnalysis.CSharp;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    	//public virtual SyntaxToken<TAnnotation> CatchKeyword { get; private set; } 
    	//public virtual CatchDeclarationSyntax<TAnnotation> Declaration { get; set; } 
    	//public virtual CatchFilterClauseSyntax<TAnnotation> Filter { get; set; } 
    	//public virtual BlockSyntax<TAnnotation> Block { get; set; } 
    
    public partial class RoslynML : CSharpSyntaxVisitor<XElement>
    {
    	/// <summary>
        /// Called when the visitor visits a CatchClauseSyntax node.
        /// </summary>
        public override XElement VisitCatchClause(Microsoft.CodeAnalysis.CSharp.Syntax.CatchClauseSyntax node)
        {
            //var result = new CatchClauseSyntax<TAnnotation>();
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
