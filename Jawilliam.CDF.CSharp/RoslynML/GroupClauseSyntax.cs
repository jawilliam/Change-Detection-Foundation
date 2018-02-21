                namespace Jawilliam.CDF.CSharp.RoslynML
                {
                    using Microsoft.CodeAnalysis.CSharp;
                    using System;
                    using System.Collections.Generic;
                    using System.Linq;
                    using System.Xml.Linq;
                    
                    	//public virtual SyntaxToken<TAnnotation> GroupKeyword { get; private set; } 
                    	//public virtual ExpressionSyntax<TAnnotation> GroupExpression { get; set; } 
                    	//public virtual SyntaxToken<TAnnotation> ByKeyword { get; private set; } 
                    	//public virtual ExpressionSyntax<TAnnotation> ByExpression { get; set; } 
                    
                    public partial class RoslynML : CSharpSyntaxVisitor<XElement>
                    {
                    	/// <summary>
                        /// Called when the visitor visits a GroupClauseSyntax node.
                        /// </summary>
                        public override XElement VisitGroupClause(Microsoft.CodeAnalysis.CSharp.Syntax.GroupClauseSyntax node)
                        {
                            //var result = new GroupClauseSyntax<TAnnotation>();
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
