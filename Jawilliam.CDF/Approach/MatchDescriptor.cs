using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Jawilliam.CDF.Approach
{
    /// <summary>
    /// Describes a basic result of a change detection step.
    /// </summary>
    [Serializable]
    public class MatchDescriptor : RevisionPair<ElementVersion>, IXmlSerializable
    {
        /// <summary>
        /// Gets or sets the distance according to the current metric.
        /// </summary>
        public virtual double? Distance { get; set; }

        /// <summary>
        /// Gets or sets the similarity according to the current metric.
        /// </summary>
        public virtual double? Similarity { get; set; }

        /// <summary>
        /// Gets or sets if the current descriptor has been expanded.
        /// </summary>
        public virtual bool? Expanded { get; set; }

        /// <summary>
        /// This method is reserved and should not be used. When implementing the IXmlSerializable interface, you should return null (Nothing in Visual Basic) from this method, and instead, if specifying a custom schema is required, apply the <see cref="T:System.Xml.Serialization.XmlSchemaProviderAttribute"/> to the class.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Xml.Schema.XmlSchema"/> that describes the XML representation of the object that is produced by the <see cref="M:System.Xml.Serialization.IXmlSerializable.WriteXml(System.Xml.XmlWriter)"/> method and consumed by the <see cref="M:System.Xml.Serialization.IXmlSerializable.ReadXml(System.Xml.XmlReader)"/> method.
        /// </returns>
        public virtual XmlSchema GetSchema()
        {
            return null;
        }

        /// <summary>
        /// Generates an object from its XML representation.
        /// </summary>
        /// <param name="reader">The <see cref="T:System.Xml.XmlReader"/> stream from which the object is deserialized. </param>
        public virtual void ReadXml(XmlReader reader)
        {
            this.Original = new ElementVersion
            {
                Id = reader.GetAttribute("oId"),
                GlobalId = reader.GetAttribute("oGId"),
                Label = reader.GetAttribute("oLb"),
                Value = reader.GetAttribute("oVl")
            };

            this.Modified = new ElementVersion
            {
                Id = reader.GetAttribute("mId"),
                GlobalId = reader.GetAttribute("mGId"),
                Label = reader.GetAttribute("mLb"),
                Value = reader.GetAttribute("mVl")
            };

            var distanceAttribute = reader.GetAttribute("distance");
            if (distanceAttribute != null)
                this.Distance = XmlConvert.ToDouble(distanceAttribute);

            var similarityAttribute = reader.GetAttribute("similarity");
            if (similarityAttribute != null)
                this.Similarity = XmlConvert.ToDouble(similarityAttribute);

            var expandedAttribute = reader.GetAttribute("expanded");
            if (expandedAttribute != null)
                this.Expanded = XmlConvert.ToBoolean(expandedAttribute);

            reader.Read();
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public virtual void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("oId", this.Original.Id);
            writer.WriteAttributeString("mId", this.Modified.Id);

            if (this.Original.Label != null)
                writer.WriteAttributeString("oLb", this.Original.Label);
            if (this.Original.Value != null)
                writer.WriteAttributeString("oVl", this.Original.Value);
            if (this.Modified.Label != null)
                writer.WriteAttributeString("mLb", this.Modified.Label);
            if (this.Modified.Value != null)
                writer.WriteAttributeString("mVl", this.Modified.Value);

            if (this.Distance != null)
                writer.WriteAttributeString("distance", XmlConvert.ToString(this.Distance.Value));

            if (this.Similarity != null)
                writer.WriteAttributeString("similarity", XmlConvert.ToString(this.Similarity.Value));

            if (this.Expanded != null)
                writer.WriteAttributeString("expanded", XmlConvert.ToString(this.Expanded.Value));
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return $"Matched {Original} with {Modified}";
        }
    }
}
