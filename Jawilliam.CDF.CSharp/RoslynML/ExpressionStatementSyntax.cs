                                namespace Jawilliam.CDF.CSharp.RoslynML
                                {
                                    using Microsoft.CodeAnalysis.CSharp;
                                    using System;
                                    using System.Collections.Generic;
                                    using System.Linq;
                                    using System.Xml.Linq;
                                    
                                    	//public virtual ExpressionSyntax<TAnnotation> Expression { get; set; } 
                                    	//public virtual SyntaxToken<TAnnotation> SemicolonToken { get; private set; } 
                                    
                                    public partial class RoslynML : CSharpSyntaxVisitor<XElement>
                                    {
                                    	/// <summary>
                                        /// Called when the visitor visits a ExpressionStatementSyntax node.
                                        /// </summary>
                                        public override XElement VisitExpressionStatement(Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionStatementSyntax node)
                                        {
                                            //var result = new ExpressionStatementSyntax<TAnnotation>();
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
