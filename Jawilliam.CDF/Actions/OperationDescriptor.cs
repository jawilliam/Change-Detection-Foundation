using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Jawilliam.CDF.Actions
{
    /// <summary>
    /// Describes a basic result of a change detection differencing.
    /// </summary>
    [Serializable]
    public abstract class OperationDescriptor : ActionDescriptor, IXmlSerializable
    {
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
            //var kind = reader.GetAttribute("kind");
            //if (kind == null) throw new MissingValueException("kind can not be null");

            //if (!Equals(Enum.Parse(typeof(ActionKind), kind), this.Action))
            //    throw new InvalidOperationException($"An {Enum.GetName(typeof(ActionKind), this.Action)} operation is expected.");

            this.Element = new ElementDescriptor
            {
                Id = reader.GetAttribute("eId"),
                Label = reader.GetAttribute("eLb")
            };
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public virtual void WriteXml(XmlWriter writer)
        {
            //writer.WriteAttributeString("kind", Enum.GetName(typeof(ActionKind), this.Action));

            if (this.Element.Id != null)
                writer.WriteAttributeString("eId", this.Element.Id);

            if (this.Element.Label != null)
                writer.WriteAttributeString("eLb", this.Element.Label);
        }

        /// <summary>
        /// Gets or sets the element to be operated.
        /// </summary>
        public virtual ElementDescriptor Element { get; set; }
    }
}