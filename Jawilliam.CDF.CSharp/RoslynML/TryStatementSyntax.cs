                                namespace Jawilliam.CDF.CSharp.RoslynML
                                {
                                    using Microsoft.CodeAnalysis.CSharp;
                                    using System;
                                    using System.Collections.Generic;
                                    using System.Linq;
                                    using System.Xml.Linq;
                                    
                                    	//public virtual SyntaxToken<TAnnotation> TryKeyword { get; private set; } 
                                    	//public virtual BlockSyntax<TAnnotation> Block { get; set; } 
                                    	//public virtual SyntaxList<TAnnotation, CatchClauseSyntax<TAnnotation>> Catches { get; set; } 
                                    	//public virtual FinallyClauseSyntax<TAnnotation> Finally { get; set; } 
                                    
                                    public partial class RoslynML : CSharpSyntaxVisitor<XElement>
                                    {
                                    	/// <summary>
                                        /// Called when the visitor visits a TryStatementSyntax node.
                                        /// </summary>
                                        public override XElement VisitTryStatement(Microsoft.CodeAnalysis.CSharp.Syntax.TryStatementSyntax node)
                                        {
                                            //var result = new TryStatementSyntax<TAnnotation>();
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
