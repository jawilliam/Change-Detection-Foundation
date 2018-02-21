                                namespace Jawilliam.CDF.CSharp.RoslynML
                                {
                                    using Microsoft.CodeAnalysis.CSharp;
                                    using System;
                                    using System.Collections.Generic;
                                    using System.Linq;
                                    using System.Xml.Linq;
                                    
                                    	//public virtual SyntaxToken<TAnnotation> SemicolonToken { get; private set; } 
                                    
                                    public partial class RoslynML : CSharpSyntaxVisitor<XElement>
                                    {
                                    	/// <summary>
                                        /// Called when the visitor visits a EmptyStatementSyntax node.
                                        /// </summary>
                                        public override XElement VisitEmptyStatement(Microsoft.CodeAnalysis.CSharp.Syntax.EmptyStatementSyntax node)
                                        {
                                            //var result = new EmptyStatementSyntax<TAnnotation>();
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
