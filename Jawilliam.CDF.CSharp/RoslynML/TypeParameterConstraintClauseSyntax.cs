namespace Jawilliam.CDF.CSharp.RoslynML
{
    using Microsoft.CodeAnalysis.CSharp;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    	//public virtual SyntaxToken<TAnnotation> WhereKeyword { get; private set; } 
    	//public virtual IdentifierNameSyntax<TAnnotation> Name { get; set; } 
    	//public virtual SyntaxToken<TAnnotation> ColonToken { get; private set; } 
    	//public virtual SeparatedSyntaxList<TAnnotation, TypeParameterConstraintSyntax<TAnnotation>> Constraints { get; set; } 
    
    public partial class RoslynML : CSharpSyntaxVisitor<XElement>
    {
    	/// <summary>
        /// Called when the visitor visits a TypeParameterConstraintClauseSyntax node.
        /// </summary>
        public override XElement VisitTypeParameterConstraintClause(Microsoft.CodeAnalysis.CSharp.Syntax.TypeParameterConstraintClauseSyntax node)
        {
            //var result = new TypeParameterConstraintClauseSyntax<TAnnotation>();
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
