        namespace Jawilliam.CDF.CSharp.RoslynML
        {
            using Microsoft.CodeAnalysis.CSharp;
            using System;
            using System.Collections.Generic;
            using System.Linq;
            using System.Xml.Linq;
            
            	//public virtual SyntaxToken<TAnnotation> NewKeyword { get; private set; } 
            	//public virtual ArrayTypeSyntax<TAnnotation> Type { get; set; } 
            	//public virtual InitializerExpressionSyntax<TAnnotation> Initializer { get; set; } 
            
            public partial class RoslynML : CSharpSyntaxVisitor<XElement>
            {
            	/// <summary>
                /// Called when the visitor visits a ArrayCreationExpressionSyntax node.
                /// </summary>
                public override XElement VisitArrayCreationExpression(Microsoft.CodeAnalysis.CSharp.Syntax.ArrayCreationExpressionSyntax node)
                {
                    //var result = new ArrayCreationExpressionSyntax<TAnnotation>();
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
