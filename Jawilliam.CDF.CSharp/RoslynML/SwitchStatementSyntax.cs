                                namespace Jawilliam.CDF.CSharp.RoslynML
                                {
                                    using Microsoft.CodeAnalysis.CSharp;
                                    using System;
                                    using System.Collections.Generic;
                                    using System.Linq;
                                    using System.Xml.Linq;
                                    
                                    	//public virtual SyntaxToken<TAnnotation> SwitchKeyword { get; private set; } 
                                    	//public virtual SyntaxToken<TAnnotation> OpenParenToken { get; private set; } 
                                    	//public virtual ExpressionSyntax<TAnnotation> Expression { get; set; } 
                                    	//public virtual SyntaxToken<TAnnotation> CloseParenToken { get; private set; } 
                                    	//public virtual SyntaxToken<TAnnotation> OpenBraceToken { get; private set; } 
                                    	//public virtual SyntaxList<TAnnotation, SwitchSectionSyntax<TAnnotation>> Sections { get; set; } 
                                    	//public virtual SyntaxToken<TAnnotation> CloseBraceToken { get; private set; } 
                                    
                                    public partial class RoslynML : CSharpSyntaxVisitor<XElement>
                                    {
                                    	/// <summary>
                                        /// Called when the visitor visits a SwitchStatementSyntax node.
                                        /// </summary>
                                        public override XElement VisitSwitchStatement(Microsoft.CodeAnalysis.CSharp.Syntax.SwitchStatementSyntax node)
                                        {
                                            //var result = new SwitchStatementSyntax<TAnnotation>();
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
