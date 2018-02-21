                namespace Jawilliam.CDF.CSharp.RoslynML
                {
                    using Microsoft.CodeAnalysis.CSharp;
                    using System;
                    using System.Collections.Generic;
                    using System.Linq;
                    using System.Xml.Linq;
                    
                    	//public virtual IdentifierNameSyntax<TAnnotation> Alias { get; set; } 
                    	//public virtual SyntaxToken<TAnnotation> ColonColonToken { get; private set; } 
                    	//public virtual SimpleNameSyntax<TAnnotation> Name { get; set; } 
                    
                    public partial class RoslynML : CSharpSyntaxVisitor<XElement>
                    {
                    	/// <summary>
                        /// Called when the visitor visits a AliasQualifiedNameSyntax node.
                        /// </summary>
                        public override XElement VisitAliasQualifiedName(Microsoft.CodeAnalysis.CSharp.Syntax.AliasQualifiedNameSyntax node)
                        {
                            //var result = new AliasQualifiedNameSyntax<TAnnotation>();
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
