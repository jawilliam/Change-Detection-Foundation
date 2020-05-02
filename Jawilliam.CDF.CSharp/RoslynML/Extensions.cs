using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace Jawilliam.CDF.CSharp.RoslynML
{
    /// <summary>
    /// Shares extensions.
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// Returns the RoslynML id of the represented element. 
        /// </summary>
        /// <param name="source">The xml-based represented element.</param>
        /// <returns>the "RmID" attribute value.</returns>
        public static string RmId(this XElement source)
        {
            return source != null
                ? source.Attribute("RmID")?.Value ?? throw new InvalidOperationException("RmID attribute cannot be null")
                : throw new ArgumentNullException(nameof(source));
        }

        /// <summary>
        /// Returns the Roslyn-like GtID of the represented element. 
        /// </summary>
        /// <param name="source">The xml-based represented element.</param>
        /// <returns>the "GtID" attribute value.</returns>
        public static string GtID(this XElement source)
        {
            return source != null
                ? source.Attribute("GtID")?.Value ?? throw new InvalidOperationException("GtID attribute cannot be null")
                : throw new ArgumentNullException(nameof(source));
        }

        /// <summary>
        /// Returns a dictionary indexing the elements having RoslynML Id.
        /// </summary>
        /// <param name="source">The xml-based represented element.</param>
        /// <returns>a dictionary indexing with their RoslynML Id those elements having RoslynML Id.</returns>
        public static Dictionary<string, XElement> ToRmDictionary(this XElement source)
        {
            return source?.PostOrder(n => n.Elements()
                        .Where(ne => ne is XNode))
                        .ToDictionary(n => n.RmId());
        }

        /// <summary>
        /// Returns a dictionary indexing the elements having Roslyn-like GumTree Id.
        /// </summary>
        /// <param name="source">The xml-based represented element.</param>
        /// <returns>a dictionary indexing with their Roslyn-like GumTree Id those elements having Roslyn-like GumTree Id</returns>
        public static Dictionary<string, XElement> ToGtDictionary(this XElement source)
        {
            return source?.PostOrder(n => n.Elements()
                       .Where(ne => ne is XNode))
                       .Where(ne => ne.Attribute("GtID")?.Value != null)
                       .ToDictionary(n => n.GtID());
        }

        /// <summary>
        /// Returns the start line of the represented element. 
        /// </summary>
        /// <param name="source">The xml-based represented element.</param>
        /// <returns>the "startLine" attribute value.</returns>
        public static int StartLine(this XElement source)
        {
            return source != null
                ? XmlConvert.ToInt32(source.Attribute("startLine")?.Value ?? throw new InvalidOperationException("startLine attribute cannot be null"))
                : throw new ArgumentNullException(nameof(source));
        }

        /// <summary>
        /// Returns the start column of the represented element. 
        /// </summary>
        /// <param name="source">The xml-based represented element.</param>
        /// <returns>the "startColumn" attribute value.</returns>
        public static int StartColumn(this XElement source)
        {
            return source != null 
                ? XmlConvert.ToInt32(source.Attribute("startColumn")?.Value ?? throw new InvalidOperationException("startColumn attribute cannot be null")) 
                : throw new ArgumentNullException(nameof(source));
        }

        /// <summary>
        /// Returns the label of the represented element. 
        /// </summary>
        /// <param name="source">The xml-based represented element.</param>
        /// <returns>the "kind" attribute value, if it exists, otherwise the XML element name.</returns>
        public static string Label(this XElement source)
        {
            return source != null
                ? source.Attribute("kind")?.Value ?? source.Name.LocalName
                : throw new ArgumentNullException(nameof(source));
        }

        /// <summary>
        /// Returns a content hint of the represented element. 
        /// </summary>
        /// <param name="source">The xml-based represented element.</param>
        /// <returns>the first 30 characters of the element value.</returns>
        public static string Hint(this XElement source)
        {
            var content = source != null
                ? source.Value
                : throw new ArgumentNullException(nameof(source));

            return content.Length > 30 ? content.Substring(0, 30) : content;
        }

        /// <summary>
        /// Returns a content hint of the given content. 
        /// </summary>
        /// <param name="source">The full content.</param>
        /// <returns>the first 30 characters of the content.</returns>
        public static string Hint(this string source)
        {
            var content = source ?? throw new ArgumentNullException(nameof(source));
            return content.Length > 30 ? content.Substring(0, 30) : content;
        }
    }
}
