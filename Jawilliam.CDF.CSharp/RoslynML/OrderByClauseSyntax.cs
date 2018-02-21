                namespace Jawilliam.CDF.CSharp.RoslynML
                {
                    using Microsoft.CodeAnalysis.CSharp;
                    using System;
                    using System.Collections.Generic;
                    using System.Linq;
                    using System.Xml.Linq;
                    
                    	//public virtual SyntaxToken<TAnnotation> OrderByKeyword { get; private set; } 
                    	//public virtual SeparatedSyntaxList<TAnnotation, OrderingSyntax<TAnnotation>> Orderings { get; set; } 
                    
                    public partial class RoslynML : CSharpSyntaxVisitor<XElement>
                    {
                    	/// <summary>
                        /// Called when the visitor visits a OrderByClauseSyntax node.
                        /// </summary>
                        public override XElement VisitOrderByClause(Microsoft.CodeAnalysis.CSharp.Syntax.OrderByClauseSyntax node)
                        {
                            //var result = new OrderByClauseSyntax<TAnnotation>();
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
