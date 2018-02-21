                                namespace Jawilliam.CDF.CSharp.RoslynML
                                {
                                    using Microsoft.CodeAnalysis.CSharp;
                                    using System;
                                    using System.Collections.Generic;
                                    using System.Linq;
                                    using System.Xml.Linq;
                                    
                                    	//public virtual SyntaxToken<TAnnotation> ForEachKeyword { get; private set; } 
                                    	//public virtual SyntaxToken<TAnnotation> OpenParenToken { get; private set; } 
                                    	//public virtual TypeSyntax<TAnnotation> Type { get; set; } 
                                    	//public virtual SyntaxToken<TAnnotation> Identifier { get; set; } 
                                    	//public virtual SyntaxToken<TAnnotation> InKeyword { get; private set; } 
                                    	//public virtual ExpressionSyntax<TAnnotation> Expression { get; set; } 
                                    	//public virtual SyntaxToken<TAnnotation> CloseParenToken { get; private set; } 
                                    	//public virtual StatementSyntax<TAnnotation> Statement { get; set; } 
                                    
                                    public partial class RoslynML : CSharpSyntaxVisitor<XElement>
                                    {
                                    	/// <summary>
                                        /// Called when the visitor visits a ForEachStatementSyntax node.
                                        /// </summary>
                                        public override XElement VisitForEachStatement(Microsoft.CodeAnalysis.CSharp.Syntax.ForEachStatementSyntax node)
                                        {
                                            //var result = new ForEachStatementSyntax<TAnnotation>();
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
