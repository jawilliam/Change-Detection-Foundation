        namespace Jawilliam.CDF.CSharp.RoslynML
        {
            using Microsoft.CodeAnalysis.CSharp;
            using System;
            using System.Collections.Generic;
            using System.Linq;
            using System.Xml.Linq;
            
            	//public virtual SyntaxToken<TAnnotation> OmittedArraySizeExpressionToken { get; private set; } 
            
            public partial class RoslynML : CSharpSyntaxVisitor<XElement>
            {
            	/// <summary>
                /// Called when the visitor visits a OmittedArraySizeExpressionSyntax node.
                /// </summary>
                public override XElement VisitOmittedArraySizeExpression(Microsoft.CodeAnalysis.CSharp.Syntax.OmittedArraySizeExpressionSyntax node)
                {
                    //var result = new OmittedArraySizeExpressionSyntax<TAnnotation>();
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
