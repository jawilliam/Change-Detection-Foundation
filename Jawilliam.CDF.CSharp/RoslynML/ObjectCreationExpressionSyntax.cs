        namespace Jawilliam.CDF.CSharp.RoslynML
        {
            using Microsoft.CodeAnalysis.CSharp;
            using System;
            using System.Collections.Generic;
            using System.Linq;
            using System.Xml.Linq;
            
            	//public virtual SyntaxToken<TAnnotation> NewKeyword { get; private set; } 
            	//public virtual TypeSyntax<TAnnotation> Type { get; set; } 
            	//public virtual ArgumentListSyntax<TAnnotation> ArgumentList { get; set; } 
            	//public virtual InitializerExpressionSyntax<TAnnotation> Initializer { get; set; } 
            
            public partial class RoslynML : CSharpSyntaxVisitor<XElement>
            {
            	/// <summary>
                /// Called when the visitor visits a ObjectCreationExpressionSyntax node.
                /// </summary>
                public override XElement VisitObjectCreationExpression(Microsoft.CodeAnalysis.CSharp.Syntax.ObjectCreationExpressionSyntax node)
                {
                    //var result = new ObjectCreationExpressionSyntax<TAnnotation>();
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
