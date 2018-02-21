                                namespace Jawilliam.CDF.CSharp.RoslynML
                                {
                                    using Microsoft.CodeAnalysis.CSharp;
                                    using System;
                                    using System.Collections.Generic;
                                    using System.Linq;
                                    using System.Xml.Linq;
                                    
                                    	//public virtual SyntaxToken<TAnnotation> DoKeyword { get; private set; } 
                                    	//public virtual StatementSyntax<TAnnotation> Statement { get; set; } 
                                    	//public virtual SyntaxToken<TAnnotation> WhileKeyword { get; private set; } 
                                    	//public virtual SyntaxToken<TAnnotation> OpenParenToken { get; private set; } 
                                    	//public virtual ExpressionSyntax<TAnnotation> Condition { get; set; } 
                                    	//public virtual SyntaxToken<TAnnotation> CloseParenToken { get; private set; } 
                                    	//public virtual SyntaxToken<TAnnotation> SemicolonToken { get; private set; } 
                                    
                                    public partial class RoslynML : CSharpSyntaxVisitor<XElement>
                                    {
                                    	/// <summary>
                                        /// Called when the visitor visits a DoStatementSyntax node.
                                        /// </summary>
                                        public override XElement VisitDoStatement(Microsoft.CodeAnalysis.CSharp.Syntax.DoStatementSyntax node)
                                        {
                                            //var result = new DoStatementSyntax<TAnnotation>();
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
