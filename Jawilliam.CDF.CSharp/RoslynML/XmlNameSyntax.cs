﻿namespace Jawilliam.CDF.CSharp.RoslynML
{
    using Microsoft.CodeAnalysis.CSharp;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    	//public virtual XmlPrefixSyntax<TAnnotation> Prefix { get; set; } 
    	//public virtual SyntaxToken<TAnnotation> LocalName { get; set; } 
    
    public partial class RoslynML : CSharpSyntaxVisitor<XElement>
    {
    	/// <summary>
        /// Called when the visitor visits a XmlNameSyntax node.
        /// </summary>
        public override XElement VisitXmlName(Microsoft.CodeAnalysis.CSharp.Syntax.XmlNameSyntax node)
        {
            //var result = new XmlNameSyntax<TAnnotation>();
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
