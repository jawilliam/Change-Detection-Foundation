                                namespace Jawilliam.CDF.CSharp.RoslynML
                                {
                                    using Microsoft.CodeAnalysis.CSharp;
                                    using System;
                                    using System.Collections.Generic;
                                    using System.Linq;
                                    using System.Xml.Linq;
                                    
                                    	//public virtual SyntaxToken<TAnnotation> GotoKeyword { get; private set; } 
                                    	//public virtual SyntaxToken<TAnnotation> CaseOrDefaultKeyword { get; set; } 
                                    	//public virtual ExpressionSyntax<TAnnotation> Expression { get; set; } 
                                    	//public virtual SyntaxToken<TAnnotation> SemicolonToken { get; private set; } 
                                    
                                    public partial class RoslynML : CSharpSyntaxVisitor<XElement>
                                    {
                                    	/// <summary>
                                        /// Called when the visitor visits a GotoStatementSyntax node.
                                        /// </summary>
                                        public override XElement VisitGotoStatement(Microsoft.CodeAnalysis.CSharp.Syntax.GotoStatementSyntax node)
                                        {
                                            //var result = new GotoStatementSyntax<TAnnotation>();
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
