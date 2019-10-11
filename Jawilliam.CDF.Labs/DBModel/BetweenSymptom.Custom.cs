using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Jawilliam.CDF.Labs.DBModel
{
    [Serializable]
    [KnownType(typeof(LRMatchSymptom))]
    [KnownType(typeof(RLMatchSymptom))]
    public abstract partial class BetweenSymptom : IXmlSerializable
    {
        /// <summary>
        /// Writes current instance like a XML document. 
        /// </summary>
        /// <returns>the serialized information.</returns>
        public virtual string WriteXmlColumn()
        {
            return XmlHelper.SerializeObject(this, Encoding.Unicode);
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
        public abstract void ReadXml(XmlReader reader, bool readNext = false);

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public abstract void WriteXml(XmlWriter writer);
    }

    [XmlRoot("LrMatch")]
    public partial class LRMatchSymptom : BetweenSymptom
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LRMatchSymptom()
        {
            this.Left = new BetweenMatchInfo();
            this.OriginalAtRight = new BetweenMatchInfo();
            this.ModifiedAtRight = new BetweenMatchInfo();
        }


        public BetweenMatchInfo Left { get; set; }
        public BetweenMatchInfo OriginalAtRight { get; set; }
        public BetweenMatchInfo ModifiedAtRight { get; set; }

        /// <summary>
        /// Reconstructs an object from the associated XML string.
        /// </summary>
        /// <param name="text">the raw XML.</param>
        /// <param name="encoding">the encoding of the read raw XML.</param>
        /// <returns>The instance reconstructed from the given text.</returns>
        public static ElementTree Read(string text, Encoding encoding)
        {
            return XmlHelper.DeserializeObject<ElementTree>(text ?? "<LrMatch/>", encoding);
        }

        /// <summary>
        /// Generates an object from its XML representation.
        /// </summary>
        /// <param name="reader">The <see cref="T:System.Xml.XmlReader"/> stream from which the object is deserialized. </param>
        public override void ReadXml(XmlReader reader, bool readNext = false)
        {
            this.Left = new BetweenMatchInfo();
            this.Left.ReadXml(reader, "Left");

            this.OriginalAtRight = new BetweenMatchInfo();
            this.OriginalAtRight.ReadXml(reader, "OriginalAtRight");

            this.ModifiedAtRight = new BetweenMatchInfo();
            this.ModifiedAtRight.ReadXml(reader, "ModifiedAtRight");

            if (readNext)
                reader.Read();
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public override void WriteXml(XmlWriter writer)
        {
            //writer.WriteStartElement("LrMatch");

            if (this.Left != null)
                this.Left.WriteXml(writer, "Left");

            if (this.OriginalAtRight != null)
                this.OriginalAtRight.WriteXml(writer, "OriginalAtRight");

            if (this.ModifiedAtRight != null)
                this.ModifiedAtRight.WriteXml(writer, "ModifiedAtRight");

            //writer.WriteEndElement();
        }
    }

    [XmlRoot("RlMatch")]
    public partial class RLMatchSymptom : BetweenSymptom
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RLMatchSymptom()
        {
            this.Right = new BetweenMatchInfo();
            this.OriginalAtLeft = new BetweenMatchInfo();
            this.ModifiedAtLeft = new BetweenMatchInfo();
        }

        public BetweenMatchInfo Right { get; set; }
        public BetweenMatchInfo OriginalAtLeft { get; set; }
        public BetweenMatchInfo ModifiedAtLeft { get; set; }

        /// <summary>
        /// Reconstructs an object from the associated XML string.
        /// </summary>
        /// <param name="text">the raw XML.</param>
        /// <param name="encoding">the encoding of the read raw XML.</param>
        /// <returns>The instance reconstructed from the given text.</returns>
        public static ElementTree Read(string text, Encoding encoding)
        {
            return XmlHelper.DeserializeObject<ElementTree>(text ?? "<RlMatch/>", encoding);
        }

        /// <summary>
        /// Generates an object from its XML representation.
        /// </summary>
        /// <param name="reader">The <see cref="T:System.Xml.XmlReader"/> stream from which the object is deserialized. </param>
        public override void ReadXml(XmlReader reader, bool readNext = false)
        {
            this.Right = new BetweenMatchInfo();
            this.Right.ReadXml(reader, "Right");

            this.OriginalAtLeft = new BetweenMatchInfo();
            this.OriginalAtLeft.ReadXml(reader, "OriginalAtLeft");

            this.ModifiedAtLeft = new BetweenMatchInfo();
            this.ModifiedAtLeft.ReadXml(reader, "ModifiedAtLeft");

            if (readNext)
                reader.Read();
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public override void WriteXml(XmlWriter writer)
        {
            //writer.WriteStartElement("RlMatch");

            if (this.Right != null)
                this.Right.WriteXml(writer, "Right");

            if (this.OriginalAtLeft != null)
                this.OriginalAtLeft.WriteXml(writer, "OriginalAtLeft");

            if (this.ModifiedAtLeft != null)
                this.ModifiedAtLeft.WriteXml(writer, "ModifiedAtLeft");

            //writer.WriteEndElement();
        }
    }
}
