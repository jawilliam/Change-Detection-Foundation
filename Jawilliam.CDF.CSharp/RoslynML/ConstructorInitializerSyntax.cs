namespace Jawilliam.CDF.CSharp.RoslynML
{
    using Microsoft.CodeAnalysis.CSharp;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    	//public virtual SyntaxToken<TAnnotation> ColonToken { get; private set; } 
    	//public virtual SyntaxToken<TAnnotation> ThisOrBaseKeyword { get; set; } 
    	//public virtual ArgumentListSyntax<TAnnotation> ArgumentList { get; set; } 
    
    public partial class RoslynML : CSharpSyntaxVisitor<XElement>
    {
    	/// <summary>
        /// Called when the visitor visits a ConstructorInitializerSyntax node.
        /// </summary>
        public override XElement VisitConstructorInitializer(Microsoft.CodeAnalysis.CSharp.Syntax.ConstructorInitializerSyntax node)
        {
            //var result = new ConstructorInitializerSyntax<TAnnotation>();
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
