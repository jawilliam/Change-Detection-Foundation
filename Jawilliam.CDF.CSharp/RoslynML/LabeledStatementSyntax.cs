                                namespace Jawilliam.CDF.CSharp.RoslynML
                                {
                                    using Microsoft.CodeAnalysis.CSharp;
                                    using System;
                                    using System.Collections.Generic;
                                    using System.Linq;
                                    using System.Xml.Linq;
                                    
                                    	//public virtual SyntaxToken<TAnnotation> Identifier { get; set; } 
                                    	//public virtual SyntaxToken<TAnnotation> ColonToken { get; private set; } 
                                    	//public virtual StatementSyntax<TAnnotation> Statement { get; set; } 
                                    
                                    public partial class RoslynML : CSharpSyntaxVisitor<XElement>
                                    {
                                    	/// <summary>
                                        /// Called when the visitor visits a LabeledStatementSyntax node.
                                        /// </summary>
                                        public override XElement VisitLabeledStatement(Microsoft.CodeAnalysis.CSharp.Syntax.LabeledStatementSyntax node)
                                        {
                                            //var result = new LabeledStatementSyntax<TAnnotation>();
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
