            namespace Jawilliam.CDF.CSharp.RoslynML
            {
                using Microsoft.CodeAnalysis.CSharp;
                using System;
                using System.Collections.Generic;
                using System.Linq;
                using System.Xml.Linq;
                
                	//public virtual SyntaxToken<TAnnotation> Keyword { get; set; } 
                
                public partial class RoslynML : CSharpSyntaxVisitor<XElement>
                {
                	/// <summary>
                    /// Called when the visitor visits a PredefinedTypeSyntax node.
                    /// </summary>
                    public override XElement VisitPredefinedType(Microsoft.CodeAnalysis.CSharp.Syntax.PredefinedTypeSyntax node)
                    {
                        //var result = new PredefinedTypeSyntax<TAnnotation>();
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
