namespace Jawilliam.CDF.CSharp.RoslynML
{
    using Microsoft.CodeAnalysis.CSharp;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    	//public virtual SyntaxToken<TAnnotation> NewKeyword { get; private set; } 
    	//public virtual SyntaxToken<TAnnotation> OpenParenToken { get; private set; } 
    	//public virtual SyntaxToken<TAnnotation> CloseParenToken { get; private set; } 
    
    public partial class RoslynML : CSharpSyntaxVisitor<XElement>
    {
    	/// <summary>
        /// Called when the visitor visits a ConstructorConstraintSyntax node.
        /// </summary>
        public override XElement VisitConstructorConstraint(Microsoft.CodeAnalysis.CSharp.Syntax.ConstructorConstraintSyntax node)
        {
            //var result = new ConstructorConstraintSyntax<TAnnotation>();
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
