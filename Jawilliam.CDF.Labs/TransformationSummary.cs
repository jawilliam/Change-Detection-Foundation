using System;
using System.Text;
using System.Xml.Serialization;

namespace Jawilliam.CDF.Labs
{
    /// <summary>
    /// Represents the transformation information, key for example to study the spuriosity of the element in turn.
    /// </summary>
    [Serializable, XmlRoot("Transformation")]
    public class TransformationSummary
    {
        /// <summary>
        /// Informs whether or not the current element is an original version.
        /// </summary>
        [XmlAttribute("version")]
        public virtual string Version { get; set; }

        /// <summary>
        /// Gets or sets the type of the current element.
        /// </summary>
        [XmlAttribute("type")]
        public virtual string Type { get; set; }

        /// <summary>
        /// Gets or sets the total elements summarized.
        /// </summary>
        [XmlAttribute("total")]
        public virtual int Total { get; set; }

        /// <summary>
        /// Gets or sets the index of spuriosity.
        /// </summary>
        [XmlAttribute("spuriosity")]
        public virtual double Spuriosity { get; set; }

        /// <summary>
        /// Gets or sets the total of affectable elements, e.g., children or descendants.
        /// </summary>
        [XmlAttribute("descendants")]
        public virtual int FromATotalOfDescendants { get; set; }

        /// <summary>
        /// Gets or sets the total of affectable elements, e.g., children or descendants.
        /// </summary>
        [XmlAttribute("descendantOperators")]
        public virtual int WithATotalOfOperatorsOfDescendants { get; set; }

        /// <summary>
        /// Gets or sets the transformations affecting the non children descendants.
        /// </summary>
        [XmlElement("Descendants", IsNullable = true)]
        public virtual Transformations Descendants { get; set; }

        /// <summary>
        /// Gets or sets the total of affectable elements, e.g., children or descendants.
        /// </summary>
        [XmlAttribute("children")]
        public virtual int FromATotalOfChildren { get; set; }

        /// <summary>
        /// Gets or sets the total of affectable elements, e.g., children or descendants.
        /// </summary>
        [XmlAttribute("childOperators")]
        public virtual int WithATotalOfOperatorsOfChildren { get; set; }

        /// <summary>
        /// Gets or sets the transformations affecting only the children.
        /// </summary>
        [XmlElement("Children", IsNullable = true)]
        public virtual Transformations Children { get; set; }

        /// <summary>
        /// Gets or sets the transformations affecting only the children.
        /// </summary>
        [XmlElement("Self", IsNullable = true)]
        public virtual Transformations Self { get; set; }
    }

    /// <summary>
    /// Represents the transformations information, key for example to study the spuriosity of the file revision pair in turn.
    /// </summary>
    [Serializable]
    [XmlRoot("Summary")]
    public class XTransformationsSummary : XmlColumn
    {
        /// <summary>
        /// Gets or sets all the transformations in one and other file version.
        /// </summary>
        [XmlArray("Transformations")]
        [XmlArrayItem("Transformation")]
        public virtual TransformationSummary[] Transformations { get; set; }

        /// <summary>
        /// Reconstructs an object from the associated XML string.
        /// </summary>
        /// <param name="text">the raw XML.</param>
        /// <param name="encoding">the encoding of the read raw XML.</param>
        /// <returns>The instance reconstructed from the given text.</returns>
        public static XTransformationsSummary Read(string text, Encoding encoding)
        {
            return XmlHelper.DeserializeObject<XTransformationsSummary>(text ?? "<Summary/>", encoding);
        }
    }
}
