                            namespace Jawilliam.CDF.CSharp.RoslynML
                            {
                                using Microsoft.CodeAnalysis.CSharp;
                                using System;
                                using System.Collections.Generic;
                                using System.Linq;
                                using System.Xml.Linq;
                                
                                	//public virtual SyntaxToken<TAnnotation> OpenBraceToken { get; private set; } 
                                	//public virtual SyntaxList<TAnnotation, StatementSyntax<TAnnotation>> Statements { get; set; } 
                                	//public virtual SyntaxToken<TAnnotation> CloseBraceToken { get; private set; } 
                                
                                public partial class RoslynML : CSharpSyntaxVisitor<XElement>
                                {
                                	/// <summary>
                                    /// Called when the visitor visits a BlockSyntax node.
                                    /// </summary>
                                    public override XElement VisitBlock(Microsoft.CodeAnalysis.CSharp.Syntax.BlockSyntax node)
                                    {
                                        //var result = new BlockSyntax<TAnnotation>();
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
