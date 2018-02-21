                            namespace Jawilliam.CDF.CSharp.RoslynML
                            {
                                using Microsoft.CodeAnalysis.CSharp;
                                using System;
                                using System.Collections.Generic;
                                using System.Linq;
                                using System.Xml.Linq;
                                
                                	//public virtual SyntaxToken<TAnnotation> TextToken { get; set; } 
                                
                                public partial class RoslynML : CSharpSyntaxVisitor<XElement>
                                {
                                	/// <summary>
                                    /// Called when the visitor visits a InterpolatedStringTextSyntax node.
                                    /// </summary>
                                    public override XElement VisitInterpolatedStringText(Microsoft.CodeAnalysis.CSharp.Syntax.InterpolatedStringTextSyntax node)
                                    {
                                        //var result = new InterpolatedStringTextSyntax<TAnnotation>();
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
