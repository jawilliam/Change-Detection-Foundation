namespace Jawilliam.CDF.CSharp.RoslynML
{
    using Microsoft.CodeAnalysis.CSharp;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    	//public virtual SyntaxList<TAnnotation, AttributeListSyntax<TAnnotation>> AttributeLists { get; set; } 
    	//public virtual SyntaxTokenList<TAnnotation> Modifiers { get; set; } 
    	//public virtual SyntaxToken<TAnnotation> DelegateKeyword { get; private set; } 
    	//public virtual TypeSyntax<TAnnotation> ReturnType { get; set; } 
    	//public virtual SyntaxToken<TAnnotation> Identifier { get; set; } 
    	//public virtual TypeParameterListSyntax<TAnnotation> TypeParameterList { get; set; } 
    	//public virtual ParameterListSyntax<TAnnotation> ParameterList { get; set; } 
    	//public virtual SyntaxList<TAnnotation, TypeParameterConstraintClauseSyntax<TAnnotation>> ConstraintClauses { get; set; } 
    	//public virtual SyntaxToken<TAnnotation> SemicolonToken { get; private set; } 
    
    public partial class RoslynML : CSharpSyntaxVisitor<XElement>
    {
    	/// <summary>
        /// Called when the visitor visits a DelegateDeclarationSyntax node.
        /// </summary>
        public override XElement VisitDelegateDeclaration(Microsoft.CodeAnalysis.CSharp.Syntax.DelegateDeclarationSyntax node)
        {
            //var result = new DelegateDeclarationSyntax<TAnnotation>();
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
