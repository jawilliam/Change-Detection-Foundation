            namespace Jawilliam.CDF.CSharp.RoslynML
            {
                using Microsoft.CodeAnalysis.CSharp;
                using System;
                using System.Collections.Generic;
                using System.Linq;
                using System.Xml.Linq;
                
                	//public virtual TypeSyntax<TAnnotation> ElementType { get; set; } 
                	//public virtual SyntaxToken<TAnnotation> QuestionToken { get; private set; } 
                
                public partial class RoslynML : CSharpSyntaxVisitor<XElement>
                {
                	/// <summary>
                    /// Called when the visitor visits a NullableTypeSyntax node.
                    /// </summary>
                    public override XElement VisitNullableType(Microsoft.CodeAnalysis.CSharp.Syntax.NullableTypeSyntax node)
                    {
                        //var result = new NullableTypeSyntax<TAnnotation>();
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
