        namespace Jawilliam.CDF.CSharp.RoslynML
        {
            using Microsoft.CodeAnalysis.CSharp;
            using System;
            using System.Collections.Generic;
            using System.Linq;
            using System.Xml.Linq;
            
            	//public virtual SyntaxToken<TAnnotation> NewKeyword { get; private set; } 
            	//public virtual SyntaxToken<TAnnotation> OpenBracketToken { get; private set; } 
            	//public virtual SyntaxTokenList<TAnnotation> Commas { get; set; } 
            	//public virtual SyntaxToken<TAnnotation> CloseBracketToken { get; private set; } 
            	//public virtual InitializerExpressionSyntax<TAnnotation> Initializer { get; set; } 
            
            public partial class RoslynML : CSharpSyntaxVisitor<XElement>
            {
            	/// <summary>
                /// Called when the visitor visits a ImplicitArrayCreationExpressionSyntax node.
                /// </summary>
                public override XElement VisitImplicitArrayCreationExpression(Microsoft.CodeAnalysis.CSharp.Syntax.ImplicitArrayCreationExpressionSyntax node)
                {
                    //var result = new ImplicitArrayCreationExpressionSyntax<TAnnotation>();
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
