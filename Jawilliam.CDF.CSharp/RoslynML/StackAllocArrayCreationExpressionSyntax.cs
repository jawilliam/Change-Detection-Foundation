        namespace Jawilliam.CDF.CSharp.RoslynML
        {
            using Microsoft.CodeAnalysis.CSharp;
            using System;
            using System.Collections.Generic;
            using System.Linq;
            using System.Xml.Linq;
            
            	//public virtual SyntaxToken<TAnnotation> StackAllocKeyword { get; private set; } 
            	//public virtual TypeSyntax<TAnnotation> Type { get; set; } 
            
            public partial class RoslynML : CSharpSyntaxVisitor<XElement>
            {
            	/// <summary>
                /// Called when the visitor visits a StackAllocArrayCreationExpressionSyntax node.
                /// </summary>
                public override XElement VisitStackAllocArrayCreationExpression(Microsoft.CodeAnalysis.CSharp.Syntax.StackAllocArrayCreationExpressionSyntax node)
                {
                    //var result = new StackAllocArrayCreationExpressionSyntax<TAnnotation>();
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
