        namespace Jawilliam.CDF.CSharp.RoslynML
        {
            using Microsoft.CodeAnalysis.CSharp;
            using System;
            using System.Collections.Generic;
            using System.Linq;
            using System.Xml.Linq;
            
            	//public virtual SyntaxToken<TAnnotation> StringStartToken { get; private set; } 
            	//public virtual SyntaxList<TAnnotation, InterpolatedStringContentSyntax<TAnnotation>> Contents { get; set; } 
            	//public virtual SyntaxToken<TAnnotation> StringEndToken { get; private set; } 
            
            public partial class RoslynML : CSharpSyntaxVisitor<XElement>
            {
            	/// <summary>
                /// Called when the visitor visits a InterpolatedStringExpressionSyntax node.
                /// </summary>
                public override XElement VisitInterpolatedStringExpression(Microsoft.CodeAnalysis.CSharp.Syntax.InterpolatedStringExpressionSyntax node)
                {
                    //var result = new InterpolatedStringExpressionSyntax<TAnnotation>();
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
