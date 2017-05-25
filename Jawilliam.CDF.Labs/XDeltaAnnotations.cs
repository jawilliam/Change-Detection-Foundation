using System;
using System.Text;
using System.Xml.Serialization;

namespace Jawilliam.CDF.Labs
{
    /// <summary>
    /// Contains the XML annotations for a delta.
    /// </summary>
    [Serializable]
    [XmlRoot("Annotations")]
    public class XDeltaAnnotations : XmlColumn
    {
        /// <summary>
        /// Gets or sets the similarity and distance values according specific metrics, such as Levenshtein.
        /// </summary>
        [XmlArray("Simetrics")]
        [XmlArrayItem("Simetric")]
        public virtual XSimetric[] Simetrics { get; set; }

        /// <summary>
        /// Reconstructs an object from the associated XML string.
        /// </summary>
        /// <param name="text">the raw XML.</param>
        /// <param name="encoding">the encoding of the read raw XML.</param>
        /// <returns>The instance reconstructed from the given text.</returns>
        public static XDeltaAnnotations Read(string text, Encoding encoding)
        {
            return XmlHelper.DeserializeObject<XDeltaAnnotations>(text ?? "<Annotations/>", encoding);
        }

        /// <summary>
        /// Annotations for similarity and distance values according an specific metric, such as Levenshtein. 
        /// </summary>
        [Serializable]
        public class XSimetric
        {
            /// <summary>
            /// Gets or sets the name of the metric.
            /// </summary>
            [XmlAttribute("name")]
            public virtual string Name { get; set; }

            /// <summary>
            /// Gets or sets the distance according to the current metric.
            /// </summary>
            [XmlAttribute("distance")]
            public virtual double Distance { get; set; }

            /// <summary>
            /// Gets or sets the similarity according to the current metric.
            /// </summary>
            [XmlAttribute("similarity")]
            public virtual double Similarity { get; set; }
        }
    }
}
