﻿namespace Jawilliam.CDF.CSharp.RoslynML
{
    using Microsoft.CodeAnalysis.CSharp;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    	//public virtual SyntaxToken<TAnnotation> IntoKeyword { get; private set; } 
    	//public virtual SyntaxToken<TAnnotation> Identifier { get; set; } 
    
    public partial class RoslynML : CSharpSyntaxVisitor<XElement>
    {
    	/// <summary>
        /// Called when the visitor visits a JoinIntoClauseSyntax node.
        /// </summary>
        public override XElement VisitJoinIntoClause(Microsoft.CodeAnalysis.CSharp.Syntax.JoinIntoClauseSyntax node)
        {
            //var result = new JoinIntoClauseSyntax<TAnnotation>();
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
