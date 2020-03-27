using System;
using System.Text;
using System.Xml.Serialization;

namespace Jawilliam.CDF.Labs
{
    /// <summary>
    /// Contains statistics per syntax element type.
    /// </summary>
    [Serializable]
    [XmlRoot("Annotations")]
    public class XSyntaxKindAnnotations : XmlColumn
    {
        /// <summary>
        /// Gets or sets the element type summaries.
        /// </summary>
        [XmlArray("ElementTypes")]
        [XmlArrayItem("ElementType")]
        public virtual XSyntaxElementTypeSummary[] ElementTypes { get; set; }

        /// <summary>
        /// Reconstructs an object from the associated XML string.
        /// </summary>
        /// <param name="text">the raw XML.</param>
        /// <param name="encoding">the encoding of the read raw XML.</param>
        /// <returns>The instance reconstructed from the given text.</returns>
        public static XSyntaxKindAnnotations Read(string text, Encoding encoding)
        {
            return XmlHelper.DeserializeObject<XSyntaxKindAnnotations>(text ?? "<Annotations/>", encoding);
        }
    }
}
