                                namespace Jawilliam.CDF.CSharp.RoslynML
                                {
                                    using Microsoft.CodeAnalysis.CSharp;
                                    using System;
                                    using System.Collections.Generic;
                                    using System.Linq;
                                    using System.Xml.Linq;
                                    
                                    	//public virtual SyntaxToken<TAnnotation> ForKeyword { get; private set; } 
                                    	//public virtual SyntaxToken<TAnnotation> OpenParenToken { get; private set; } 
                                    	//public virtual VariableDeclarationSyntax<TAnnotation> Declaration { get; set; } 
                                    	//public virtual SeparatedSyntaxList<TAnnotation, ExpressionSyntax<TAnnotation>> Initializers { get; set; } 
                                    	//public virtual SyntaxToken<TAnnotation> FirstSemicolonToken { get; private set; } 
                                    	//public virtual ExpressionSyntax<TAnnotation> Condition { get; set; } 
                                    	//public virtual SyntaxToken<TAnnotation> SecondSemicolonToken { get; private set; } 
                                    	//public virtual SeparatedSyntaxList<TAnnotation, ExpressionSyntax<TAnnotation>> Incrementors { get; set; } 
                                    	//public virtual SyntaxToken<TAnnotation> CloseParenToken { get; private set; } 
                                    	//public virtual StatementSyntax<TAnnotation> Statement { get; set; } 
                                    
                                    public partial class RoslynML : CSharpSyntaxVisitor<XElement>
                                    {
                                    	/// <summary>
                                        /// Called when the visitor visits a ForStatementSyntax node.
                                        /// </summary>
                                        public override XElement VisitForStatement(Microsoft.CodeAnalysis.CSharp.Syntax.ForStatementSyntax node)
                                        {
                                            //var result = new ForStatementSyntax<TAnnotation>();
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
