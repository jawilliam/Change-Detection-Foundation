using System;
using System.Text;
using System.Xml.Serialization;

namespace Jawilliam.CDF.Labs
{
    /// <summary>
    /// Contains statistics related with a specific syntax element type.
    /// </summary>
    [Serializable]
    [XmlRoot("ElementType")]
    public class XSyntaxElementTypeSummary : XmlColumn
    {
        /// <summary>
        /// Gets or sets the name of the related element type according to the <see cref="Microsoft.CodeAnalysis.CSharp.SyntaxKind"/>.
        /// </summary>
        [XmlAttribute("name")]
        public virtual string Name { get; set; }

        /// <summary>
        /// Gets or sets the total count.
        /// </summary>
        [XmlAttribute("total")]
        public virtual long Total { get; set; }

        /// <summary>
        /// Reconstructs an object from the associated XML string.
        /// </summary>
        /// <param name="text">the raw XML.</param>
        /// <param name="encoding">the encoding of the read raw XML.</param>
        /// <returns>The instance reconstructed from the given text.</returns>
        public static XSyntaxElementTypeSummary Read(string text, Encoding encoding)
        {
            return XmlHelper.DeserializeObject<XSyntaxElementTypeSummary>(text ?? "<ElementType/>", encoding);
        }
    }
}
