namespace Jawilliam.CDF.CSharp.RoslynML
{
    using Microsoft.CodeAnalysis.CSharp;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    	//public virtual TypeSyntax<TAnnotation> Type { get; set; } 
    	//public virtual SeparatedSyntaxList<TAnnotation, VariableDeclaratorSyntax<TAnnotation>> Variables { get; set; } 
    
    public partial class RoslynML : CSharpSyntaxVisitor<XElement>
    {
    	/// <summary>
        /// Called when the visitor visits a VariableDeclarationSyntax node.
        /// </summary>
        public override XElement VisitVariableDeclaration(Microsoft.CodeAnalysis.CSharp.Syntax.VariableDeclarationSyntax node)
        {
            //var result = new VariableDeclarationSyntax<TAnnotation>();
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
