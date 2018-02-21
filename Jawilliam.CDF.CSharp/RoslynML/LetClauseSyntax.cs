                namespace Jawilliam.CDF.CSharp.RoslynML
                {
                    using Microsoft.CodeAnalysis.CSharp;
                    using System;
                    using System.Collections.Generic;
                    using System.Linq;
                    using System.Xml.Linq;
                    
                    	//public virtual SyntaxToken<TAnnotation> LetKeyword { get; private set; } 
                    	//public virtual SyntaxToken<TAnnotation> Identifier { get; set; } 
                    	//public virtual SyntaxToken<TAnnotation> EqualsToken { get; private set; } 
                    	//public virtual ExpressionSyntax<TAnnotation> Expression { get; set; } 
                    
                    public partial class RoslynML : CSharpSyntaxVisitor<XElement>
                    {
                    	/// <summary>
                        /// Called when the visitor visits a LetClauseSyntax node.
                        /// </summary>
                        public override XElement VisitLetClause(Microsoft.CodeAnalysis.CSharp.Syntax.LetClauseSyntax node)
                        {
                            //var result = new LetClauseSyntax<TAnnotation>();
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
