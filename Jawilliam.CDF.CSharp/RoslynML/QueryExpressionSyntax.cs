        namespace Jawilliam.CDF.CSharp.RoslynML
        {
            using Microsoft.CodeAnalysis.CSharp;
            using System;
            using System.Collections.Generic;
            using System.Linq;
            using System.Xml.Linq;
            
            	//public virtual FromClauseSyntax<TAnnotation> FromClause { get; set; } 
            	//public virtual QueryBodySyntax<TAnnotation> Body { get; set; } 
            
            public partial class RoslynML : CSharpSyntaxVisitor<XElement>
            {
            	/// <summary>
                /// Called when the visitor visits a QueryExpressionSyntax node.
                /// </summary>
                public override XElement VisitQueryExpression(Microsoft.CodeAnalysis.CSharp.Syntax.QueryExpressionSyntax node)
                {
                    //var result = new QueryExpressionSyntax<TAnnotation>();
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
