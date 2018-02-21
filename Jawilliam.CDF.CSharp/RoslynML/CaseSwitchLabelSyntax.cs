                                                    namespace Jawilliam.CDF.CSharp.RoslynML
                                                    {
                                                        using Microsoft.CodeAnalysis.CSharp;
                                                        using System;
                                                        using System.Collections.Generic;
                                                        using System.Linq;
                                                        using System.Xml.Linq;
                                                        
                                                        	//public virtual ExpressionSyntax<TAnnotation> Value { get; set; } 
                                                        
                                                        public partial class RoslynML : CSharpSyntaxVisitor<XElement>
                                                        {
                                                        	/// <summary>
                                                            /// Called when the visitor visits a CaseSwitchLabelSyntax node.
                                                            /// </summary>
                                                            public override XElement VisitCaseSwitchLabel(Microsoft.CodeAnalysis.CSharp.Syntax.CaseSwitchLabelSyntax node)
                                                            {
                                                                //var result = new CaseSwitchLabelSyntax<TAnnotation>();
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
