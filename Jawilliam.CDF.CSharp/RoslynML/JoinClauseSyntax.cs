                namespace Jawilliam.CDF.CSharp.RoslynML
                {
                    using Microsoft.CodeAnalysis.CSharp;
                    using System;
                    using System.Collections.Generic;
                    using System.Linq;
                    using System.Xml.Linq;
                    
                    	//public virtual SyntaxToken<TAnnotation> JoinKeyword { get; private set; } 
                    	//public virtual TypeSyntax<TAnnotation> Type { get; set; } 
                    	//public virtual SyntaxToken<TAnnotation> Identifier { get; set; } 
                    	//public virtual SyntaxToken<TAnnotation> InKeyword { get; private set; } 
                    	//public virtual ExpressionSyntax<TAnnotation> InExpression { get; set; } 
                    	//public virtual SyntaxToken<TAnnotation> OnKeyword { get; private set; } 
                    	//public virtual ExpressionSyntax<TAnnotation> LeftExpression { get; set; } 
                    	//public virtual SyntaxToken<TAnnotation> EqualsKeyword { get; private set; } 
                    	//public virtual ExpressionSyntax<TAnnotation> RightExpression { get; set; } 
                    	//public virtual JoinIntoClauseSyntax<TAnnotation> Into { get; set; } 
                    
                    public partial class RoslynML : CSharpSyntaxVisitor<XElement>
                    {
                    	/// <summary>
                        /// Called when the visitor visits a JoinClauseSyntax node.
                        /// </summary>
                        public override XElement VisitJoinClause(Microsoft.CodeAnalysis.CSharp.Syntax.JoinClauseSyntax node)
                        {
                            //var result = new JoinClauseSyntax<TAnnotation>();
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
