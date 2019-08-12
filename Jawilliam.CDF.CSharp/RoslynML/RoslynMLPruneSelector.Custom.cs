using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;

namespace Jawilliam.CDF.CSharp.RoslynML
{
    partial class RoslynMLPruneSelector
    {
        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneSelectorCore(XElement)"/>.</param>
        partial void PruneSelectorAfter(XElement property, ref bool result)
        {
            if (property.Parent?.Name.LocalName == "List_of_XmlNode")
                result = this.PruneXmlNodeList(property);
        }

        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneCatchDeclarationSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneCatchDeclarationSelectorCore(XElement)"/>.</param>
        partial void PruneCatchDeclarationSelectorAfter(XElement property, ref bool result)
        {
            if (property.Attribute("part")?.Value == "Identifier" && (string.IsNullOrEmpty(property.Value) || string.IsNullOrWhiteSpace(property.Value)))
                result = false;
        }

        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneAccessorDeclarationSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneAccessorDeclarationSelectorCore(XElement)"/>.</param>
        partial void PruneAccessorDeclarationSelectorAfter(XElement property, ref bool result)
        {
            if (property.Parent?.Attribute("kind")?.Value != "UnknownAccessorDeclaration" && property.Attribute("part")?.Value == "Keyword")
                result = false;
        }

        /// <summary>
        /// Determines which properties should remain (true) or which properties should not remain (false) according to the type of parent element.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <returns>true if the property would remain, false otherwise.</returns>
        public virtual bool PruneXmlNodeList(XElement property)
        {
            if (property == null)
                throw new ArgumentNullException(nameof(property));

            if (property.Name.LocalName == "XmlText")
            {
                var elements = property.Elements().ToArray();
                if (elements.Length == 1 && elements[0].Attribute("part")?.Value == "TextTokens")
                {
                    if (elements[0].Elements().All(e => e.Name.LocalName == "Token" && (string.IsNullOrEmpty(e.Value) ||
                                                                                 string.IsNullOrWhiteSpace(e.Value) ||
                                                                                 e.Value.Trim(' ') == "///")))
                        return false;
                }
            }

            return true;
        }

        //// <summary>
        ///// Method hook for implementing logic to execute after the <see cref="PruneXmlTextSelectorCore(XElement)"/>.
        ///// </summary>
        ///// <param name="property">the property being questioned.</param>
        ///// <param name="result">Mechanism to modify the result of <see cref="PruneXmlTextSelectorCore(XElement)"/>.</param>
        //partial void PruneXmlTextSelectorAfter(XElement property, ref bool result)
        //{
        //    if (property.Attribute("part")?.Value == "TextTokens")
        //    {
        //        if (property.Elements().All(e => e.Name.LocalName == "Token" && (string.IsNullOrEmpty(e.Value) ||
        //                                                                         string.IsNullOrWhiteSpace(e.Value) ||
        //                                                                         e.Value.Trim(' ') == "///")))
        //            result = false;
        //    }
        //}

        /// <summary>
        /// Method hook for implementing logic to execute after the <see cref="PruneTupleElementSelectorCore(XElement)"/>.
        /// </summary>
        /// <param name="property">the property being questioned.</param>
        /// <param name="result">Mechanism to modify the result of <see cref="PruneTupleElementSelectorCore(XElement)"/>.</param>
        partial void PruneTupleElementSelectorAfter(XElement property, ref bool result)
        {
            if (property.Attribute("part")?.Value == "Identifier" && (string.IsNullOrEmpty(property.Value) || string.IsNullOrWhiteSpace(property.Value)))
                result = false;
        }
    }
}
