                            namespace Jawilliam.CDF.CSharp.RoslynML
                            {
                                using Microsoft.CodeAnalysis.CSharp;
                                using System;
                                using System.Collections.Generic;
                                using System.Linq;
                                using System.Xml.Linq;
                                
                                	//public virtual SyntaxToken<TAnnotation> OpenBraceToken { get; private set; } 
                                	//public virtual ExpressionSyntax<TAnnotation> Expression { get; set; } 
                                	//public virtual InterpolationAlignmentClauseSyntax<TAnnotation> AlignmentClause { get; set; } 
                                	//public virtual InterpolationFormatClauseSyntax<TAnnotation> FormatClause { get; set; } 
                                	//public virtual SyntaxToken<TAnnotation> CloseBraceToken { get; private set; } 
                                
                                public partial class RoslynML : CSharpSyntaxVisitor<XElement>
                                {
                                	/// <summary>
                                    /// Called when the visitor visits a InterpolationSyntax node.
                                    /// </summary>
                                    public override XElement VisitInterpolation(Microsoft.CodeAnalysis.CSharp.Syntax.InterpolationSyntax node)
                                    {
                                        //var result = new InterpolationSyntax<TAnnotation>();
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
