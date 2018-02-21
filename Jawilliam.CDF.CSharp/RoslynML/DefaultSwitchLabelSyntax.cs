                                                    namespace Jawilliam.CDF.CSharp.RoslynML
                                                    {
                                                        using Microsoft.CodeAnalysis.CSharp;
                                                        using System;
                                                        using System.Collections.Generic;
                                                        using System.Linq;
                                                        using System.Xml.Linq;
                                                        
                                                        
                                                        public partial class RoslynML : CSharpSyntaxVisitor<XElement>
                                                        {
                                                        	/// <summary>
                                                            /// Called when the visitor visits a DefaultSwitchLabelSyntax node.
                                                            /// </summary>
                                                            public override XElement VisitDefaultSwitchLabel(Microsoft.CodeAnalysis.CSharp.Syntax.DefaultSwitchLabelSyntax node)
                                                            {
                                                                //var result = new DefaultSwitchLabelSyntax<TAnnotation>();
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
