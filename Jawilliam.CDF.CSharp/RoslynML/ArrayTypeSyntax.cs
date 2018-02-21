            namespace Jawilliam.CDF.CSharp.RoslynML
            {
                using Microsoft.CodeAnalysis.CSharp;
                using System;
                using System.Collections.Generic;
                using System.Linq;
                using System.Xml.Linq;
                
                	//public virtual TypeSyntax<TAnnotation> ElementType { get; set; } 
                	//public virtual SyntaxList<TAnnotation, ArrayRankSpecifierSyntax<TAnnotation>> RankSpecifiers { get; set; } 
                
                public partial class RoslynML : CSharpSyntaxVisitor<XElement>
                {
                	/// <summary>
                    /// Called when the visitor visits a ArrayTypeSyntax node.
                    /// </summary>
                    public override XElement VisitArrayType(Microsoft.CodeAnalysis.CSharp.Syntax.ArrayTypeSyntax node)
                    {
                        //var result = new ArrayTypeSyntax<TAnnotation>();
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
