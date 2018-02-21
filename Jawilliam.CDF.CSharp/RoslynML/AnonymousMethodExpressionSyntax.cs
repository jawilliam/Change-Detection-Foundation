                namespace Jawilliam.CDF.CSharp.RoslynML
                {
                    using Microsoft.CodeAnalysis.CSharp;
                    using System;
                    using System.Collections.Generic;
                    using System.Linq;
                    using System.Xml.Linq;
                    
                    	//public virtual SyntaxToken<TAnnotation> DelegateKeyword { get; private set; } 
                    	//public virtual ParameterListSyntax<TAnnotation> ParameterList { get; set; } 
                    
                    public partial class RoslynML : CSharpSyntaxVisitor<XElement>
                    {
                    	/// <summary>
                        /// Called when the visitor visits a AnonymousMethodExpressionSyntax node.
                        /// </summary>
                        public override XElement VisitAnonymousMethodExpression(Microsoft.CodeAnalysis.CSharp.Syntax.AnonymousMethodExpressionSyntax node)
                        {
                            //var result = new AnonymousMethodExpressionSyntax<TAnnotation>();
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
