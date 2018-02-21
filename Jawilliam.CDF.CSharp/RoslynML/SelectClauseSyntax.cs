                namespace Jawilliam.CDF.CSharp.RoslynML
                {
                    using Microsoft.CodeAnalysis.CSharp;
                    using System;
                    using System.Collections.Generic;
                    using System.Linq;
                    using System.Xml.Linq;
                    
                    	//public virtual SyntaxToken<TAnnotation> SelectKeyword { get; private set; } 
                    	//public virtual ExpressionSyntax<TAnnotation> Expression { get; set; } 
                    
                    public partial class RoslynML : CSharpSyntaxVisitor<XElement>
                    {
                    	/// <summary>
                        /// Called when the visitor visits a SelectClauseSyntax node.
                        /// </summary>
                        public override XElement VisitSelectClause(Microsoft.CodeAnalysis.CSharp.Syntax.SelectClauseSyntax node)
                        {
                            //var result = new SelectClauseSyntax<TAnnotation>();
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
