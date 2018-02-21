namespace Jawilliam.CDF.CSharp.RoslynML
{
    using Microsoft.CodeAnalysis.CSharp;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    	//public virtual SyntaxList<TAnnotation, SwitchLabelSyntax<TAnnotation>> Labels { get; set; } 
    	//public virtual SyntaxList<TAnnotation, StatementSyntax<TAnnotation>> Statements { get; set; } 
    
    public partial class RoslynML : CSharpSyntaxVisitor<XElement>
    {
    	/// <summary>
        /// Called when the visitor visits a SwitchSectionSyntax node.
        /// </summary>
        public override XElement VisitSwitchSection(Microsoft.CodeAnalysis.CSharp.Syntax.SwitchSectionSyntax node)
        {
            //var result = new SwitchSectionSyntax<TAnnotation>();
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
