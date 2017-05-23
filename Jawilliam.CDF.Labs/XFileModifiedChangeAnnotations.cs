using System;
using System.Text;
using System.Xml.Serialization;

namespace Jawilliam.CDF.Labs
{
    /// <summary>
    /// Contains the XML annotations for a file version content summary.
    /// </summary>
    [Serializable]
    [XmlRoot("Annotations")]
    public class XFileModifiedChangeAnnotations : XmlColumn
    {
        /// <summary>
        /// Gets or sets whether or not the related content registers source code changes.
        /// </summary>
        [XmlAttribute("sourceCodeChanges")]
        public virtual bool SourceCodeChanges { get; set; }

        /// <summary>
        /// Reconstructs an object from the associated XML string.
        /// </summary>
        /// <param name="text">the raw XML.</param>
        /// <param name="encoding">the encoding of the read raw XML.</param>
        /// <returns>The instance reconstructed from the given text.</returns>
        public static XFileModifiedChangeAnnotations Read(string text, Encoding encoding)
        {
            return XmlHelper.DeserializeObject<XFileModifiedChangeAnnotations>(text ?? "<Annotations/>", encoding);
        }
    }
}
