                namespace Jawilliam.CDF.CSharp.RoslynML
                {
                    using Microsoft.CodeAnalysis.CSharp;
                    using System;
                    using System.Collections.Generic;
                    using System.Linq;
                    using System.Xml.Linq;
                    
                    	//public virtual NameSyntax<TAnnotation> Left { get; set; } 
                    	//public virtual SyntaxToken<TAnnotation> DotToken { get; private set; } 
                    	//public virtual SimpleNameSyntax<TAnnotation> Right { get; set; } 
                    
                    public partial class RoslynML : CSharpSyntaxVisitor<XElement>
                    {
                    	/// <summary>
                        /// Called when the visitor visits a QualifiedNameSyntax node.
                        /// </summary>
                        public override XElement VisitQualifiedName(Microsoft.CodeAnalysis.CSharp.Syntax.QualifiedNameSyntax node)
                        {
                            //var result = new QualifiedNameSyntax<TAnnotation>();
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
