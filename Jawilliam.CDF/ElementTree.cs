using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using Jawilliam.CDF.Approach;

namespace Jawilliam.CDF
{
    /// <summary>
    /// Represents a tree of element descriptors.
    /// </summary>
    [Serializable]
    [XmlRoot("Item")]
    public class ElementTree : IXmlSerializable
    {
        /// <summary>
        /// Gets or sets the root element descriptor.
        /// </summary>
        public virtual ElementDescriptor Root { get; set; }

        /// <summary>
        /// Gets or sets the parent element descriptor.
        /// </summary>
        public virtual ElementTree Parent { get; set; }

        /// <summary>
        /// Gets or sets the element descriptor children.
        /// </summary>
        public virtual IEnumerable<ElementTree> Children { get; set; }


        /// <summary>
        /// Writes current instance like a XML document. 
        /// </summary>
        /// <returns>the serialized information.</returns>
        public virtual string WriteXmlColumn()
        {
            return XmlHelper.SerializeObject(this, Encoding.Unicode);
        }

        /// <summary>
        /// Reconstructs an object from the associated XML string.
        /// </summary>
        /// <param name="text">the raw XML.</param>
        /// <param name="encoding">the encoding of the read raw XML.</param>
        /// <returns>The instance reconstructed from the given text.</returns>
        public static ElementTree Read(string text, Encoding encoding)
        {
            return XmlHelper.DeserializeObject<ElementTree>(text ?? "<Item/>", encoding);
        }

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
            this.ReadXml(reader, true);
        }

        /// <summary>
        /// Generates an object from its XML representation.
        /// </summary>
        /// <param name="reader">The <see cref="T:System.Xml.XmlReader"/> stream from which the object is deserialized. </param>
        public virtual void ReadXml(XmlReader reader, bool readNext = false)
        {
            this.Root = new ElementDescriptor
            {
                Id = reader.GetAttribute("eId"),
                Label = reader.GetAttribute("eLb"),
                Value = reader.GetAttribute("eVl")
            };

            var children = new List<ElementTree>();
            if (reader.ReadToDescendant("Item"))
            {
                var child = new ElementTree();
                child.ReadXml(reader, false);
                children.Add(child);

                while (reader.ReadToNextSibling("Item"))
                {
                    var sibling = new ElementTree();
                    sibling.ReadXml(reader, false);
                    children.Add(sibling);
                }

                this.Children = children;
                foreach (var elementTree in this.Children)
                {
                    elementTree.Parent = this;
                }
            }

            if(readNext)
                reader.Read();
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public virtual void WriteXml(XmlWriter writer)
        {
            if (this.Root.Id != null)
                writer.WriteAttributeString("eId", this.Root.Id);

            if (this.Root.Label != null)
                writer.WriteAttributeString("eLb", this.Root.Label);

            if (this.Root.Value != null)
                writer.WriteAttributeString("eVl", this.Root.Value);

            if (this.Children?.Any() == true)
            {
                //writer.WriteStartElement("Children");
                foreach (var elementTree in this.Children)
                {
                    writer.WriteStartElement("Item");
                    elementTree.WriteXml(writer);
                    writer.WriteEndElement();
                }
            }
        }
    }
}
