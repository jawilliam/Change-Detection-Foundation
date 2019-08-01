using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;

namespace Jawilliam.CDF.CSharp.RoslynML
{
    partial class RoslynMLPruner
    {
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreCatchDeclaration(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        partial void PruneAfterCatchDeclaration(XElement source)
        {
            this.Prune(source, delegate (XElement e)
            {
                if (e.Name.LocalName == "Identifier" && (string.IsNullOrEmpty(e.Value) || string.IsNullOrWhiteSpace(e.Value)))
                    return true;
                return false;
            });
        }

        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreAccessorDeclaration(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        partial void PruneAfterAccessorDeclaration(XElement source)
        {
            var kindAttribute = source.Attribute("kind");
            if (kindAttribute?.Value != "UnknownAccessorDeclaration")
            {
                this.Prune(source, delegate (XElement e)
                {
                    if (e.Name.LocalName == "Keyword")
                        return true;
                    return false;
                });
            }
        }

        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreDocumentationCommentTrivia(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        partial void PruneAfterDocumentationCommentTrivia(XElement source)
        {
            this.Prune(source, delegate (XElement e)
            {
                if (e.Name.LocalName == "XmlText" && (string.IsNullOrEmpty(e.Value) || string.IsNullOrWhiteSpace(e.Value) || e.Value.Trim(' ') == "///"))
                    return true;
                return false;
            });
        }

        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCoreTupleElement(XElement)"/>.
        /// </summary>
        /// <param name="source">the element to prune.</param>
        partial void PruneAfterTupleElement(XElement source)
        {
            this.Prune(source, delegate (XElement e)
            {
                if (e.Name.LocalName == "Identifier" && (string.IsNullOrEmpty(e.Value) || string.IsNullOrWhiteSpace(e.Value)))
                    return true;
                return false;
            });
        }
    }
}
