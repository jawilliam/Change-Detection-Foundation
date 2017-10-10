using System;
using System.Text;
using System.Xml.Serialization;

namespace Jawilliam.CDF.Labs
{
    /// <summary>
    /// Describes the transformation applied over a subset of interest (e.g., children or descendants).
    /// </summary>
    public class Transformations
    {     
        /// <summary>
        /// Gets or sets the count of insertions transforming any descendant.
        /// </summary>
        [XmlAttribute("insertions")]
        public virtual int Insertions { get; set; }

        /// <summary>
        /// Gets or sets the count of deletions transforming any descendant.
        /// </summary>
        [XmlAttribute("deletions")]
        public virtual int Deletions { get; set; }

        /// <summary>
        /// Gets or sets the count of updates transforming any descendant.
        /// </summary>
        [XmlAttribute("updates")]
        public virtual int Updates { get; set; }

        /// <summary>
        /// Gets or sets the count of moves transforming any descendant (as the origin).
        /// </summary>
        [XmlAttribute("fromMoves")]
        public virtual int FromMoves { get; set; }

        /// <summary>
        /// Gets or sets the count of moves transforming any descendant (as the target).
        /// </summary>
        [XmlAttribute("toMoves")]
        public virtual int ToMoves { get; set; }

        /// <summary>
        /// Gets or sets the count of aligns transforming any descendant.
        /// </summary>
        [XmlAttribute("aligns")]
        public virtual int Aligns { get; set; }
    }

    /// <summary>
    /// Represents the transformation information, key for example to study the spuriosity of the element in turn.
    /// </summary>
    [Serializable, XmlRoot("Transformation")]
    public class TransformationInfo
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
        /// Gets or sets the identification of the current element.
        /// </summary>
        [XmlAttribute("id")]
        public virtual string Id { get; set; }

        /// <summary>
        /// Gets or sets information to complement the identification of the current element.
        /// </summary>
        [XmlAttribute("hint")]
        public virtual string Hint { get; set; }

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

        /// <summary>
        /// Gets or sets the scope of the current element.
        /// </summary>
        [XmlElement("ScopeHint")]
        public virtual string ScopeHint { get; set; }
    }

    /// <summary>
    /// Represents the transformations information, key for example to study the spuriosity of the file revision pair in turn.
    /// </summary>
    [Serializable]
    [XmlRoot("TransformationsInfo")]
    public class XTransformationsInfo : XmlColumn
    {
        /// <summary>
        /// Gets or sets all the transformations in one and other file version.
        /// </summary>
        [XmlArray("Transformations")]
        [XmlArrayItem("Transformation")]
        public virtual TransformationInfo[] Transformations { get; set; }

        /// <summary>
        /// Reconstructs an object from the associated XML string.
        /// </summary>
        /// <param name="text">the raw XML.</param>
        /// <param name="encoding">the encoding of the read raw XML.</param>
        /// <returns>The instance reconstructed from the given text.</returns>
        public static XTransformationsInfo Read(string text, Encoding encoding)
        {
            return XmlHelper.DeserializeObject<XTransformationsInfo>(text ?? "<TransformationsInfo/>", encoding);
        }
    }
}
