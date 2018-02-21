        namespace Jawilliam.CDF.CSharp.RoslynML
        {
            using Microsoft.CodeAnalysis.CSharp;
            using System;
            using System.Collections.Generic;
            using System.Linq;
            using System.Xml.Linq;
            
            	//public virtual SyntaxToken<TAnnotation> NewKeyword { get; private set; } 
            	//public virtual SyntaxToken<TAnnotation> OpenBraceToken { get; private set; } 
            	//public virtual SeparatedSyntaxList<TAnnotation, AnonymousObjectMemberDeclaratorSyntax<TAnnotation>> Initializers { get; set; } 
            	//public virtual SyntaxToken<TAnnotation> CloseBraceToken { get; private set; } 
            
            public partial class RoslynML : CSharpSyntaxVisitor<XElement>
            {
            	/// <summary>
                /// Called when the visitor visits a AnonymousObjectCreationExpressionSyntax node.
                /// </summary>
                public override XElement VisitAnonymousObjectCreationExpression(Microsoft.CodeAnalysis.CSharp.Syntax.AnonymousObjectCreationExpressionSyntax node)
                {
                    //var result = new AnonymousObjectCreationExpressionSyntax<TAnnotation>();
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
