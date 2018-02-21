namespace Jawilliam.CDF.CSharp.RoslynML
{
    using Microsoft.CodeAnalysis.CSharp;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    	//public virtual SyntaxToken<TAnnotation> Identifier { get; set; } 
    	//public virtual BracketedArgumentListSyntax<TAnnotation> ArgumentList { get; set; } 
    	//public virtual EqualsValueClauseSyntax<TAnnotation> Initializer { get; set; } 
    
    public partial class RoslynML : CSharpSyntaxVisitor<XElement>
    {
    	/// <summary>
        /// Called when the visitor visits a VariableDeclaratorSyntax node.
        /// </summary>
        public override XElement VisitVariableDeclarator(Microsoft.CodeAnalysis.CSharp.Syntax.VariableDeclaratorSyntax node)
        {
            //var result = new VariableDeclaratorSyntax<TAnnotation>();
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
