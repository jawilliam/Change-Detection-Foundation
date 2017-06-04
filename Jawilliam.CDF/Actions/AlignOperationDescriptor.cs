using System;
using System.Xml;

namespace Jawilliam.CDF.Actions
{
    /// <summary>
    /// Represents a basic "align" operation.
    /// </summary>
    [Serializable]
    public class AlignOperationDescriptor : BaseMoveOperationDescriptor
    {
        /// <summary>
        /// Gets the current action.
        /// </summary>
        public override ActionKind Action => ActionKind.Align;

        /// <summary>
        /// Generates an object from its XML representation.
        /// </summary>
        /// <param name="reader">The <see cref="T:System.Xml.XmlReader"/> stream from which the object is deserialized. </param>
        public override void ReadXml(XmlReader reader)
        {
            base.ReadXml(reader);

            var positionAttribute = reader.GetAttribute("pos");
            if (positionAttribute == null) throw new MissingValueException("Position can not be null");
            this.Position = XmlConvert.ToInt32(positionAttribute);

            reader.Read();
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public override void WriteXml(XmlWriter writer)
        {
            base.WriteXml(writer);
            writer.WriteAttributeString("pos", XmlConvert.ToString(this.Position));
        }
    }
}