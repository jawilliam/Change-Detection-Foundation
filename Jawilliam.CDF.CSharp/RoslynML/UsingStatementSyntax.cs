                                namespace Jawilliam.CDF.CSharp.RoslynML
                                {
                                    using Microsoft.CodeAnalysis.CSharp;
                                    using System;
                                    using System.Collections.Generic;
                                    using System.Linq;
                                    using System.Xml.Linq;
                                    
                                    	//public virtual SyntaxToken<TAnnotation> UsingKeyword { get; private set; } 
                                    	//public virtual SyntaxToken<TAnnotation> OpenParenToken { get; private set; } 
                                    	//public virtual VariableDeclarationSyntax<TAnnotation> Declaration { get; set; } 
                                    	//public virtual ExpressionSyntax<TAnnotation> Expression { get; set; } 
                                    	//public virtual SyntaxToken<TAnnotation> CloseParenToken { get; private set; } 
                                    	//public virtual StatementSyntax<TAnnotation> Statement { get; set; } 
                                    
                                    public partial class RoslynML : CSharpSyntaxVisitor<XElement>
                                    {
                                    	/// <summary>
                                        /// Called when the visitor visits a UsingStatementSyntax node.
                                        /// </summary>
                                        public override XElement VisitUsingStatement(Microsoft.CodeAnalysis.CSharp.Syntax.UsingStatementSyntax node)
                                        {
                                            //var result = new UsingStatementSyntax<TAnnotation>();
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
