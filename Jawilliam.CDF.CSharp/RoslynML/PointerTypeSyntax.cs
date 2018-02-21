            namespace Jawilliam.CDF.CSharp.RoslynML
            {
                using Microsoft.CodeAnalysis.CSharp;
                using System;
                using System.Collections.Generic;
                using System.Linq;
                using System.Xml.Linq;
                
                	//public virtual TypeSyntax<TAnnotation> ElementType { get; set; } 
                	//public virtual SyntaxToken<TAnnotation> AsteriskToken { get; private set; } 
                
                public partial class RoslynML : CSharpSyntaxVisitor<XElement>
                {
                	/// <summary>
                    /// Called when the visitor visits a PointerTypeSyntax node.
                    /// </summary>
                    public override XElement VisitPointerType(Microsoft.CodeAnalysis.CSharp.Syntax.PointerTypeSyntax node)
                    {
                        //var result = new PointerTypeSyntax<TAnnotation>();
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
