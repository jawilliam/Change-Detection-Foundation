using System;
using System.Xml;

namespace Jawilliam.CDF.Actions
{
    /// <summary>
    /// Represents a basic "update" operation.
    /// </summary>
    [Serializable]
    public class UpdateOperationDescriptor : OperationDescriptor
    {
        /// <summary>
        /// Gets the current action.
        /// </summary>
        public override ActionKind Action => ActionKind.Update;

        /// <summary>
        /// The new value to replace the old value.
        /// </summary>
        public virtual string Value { get; set; }

        /// <summary>
        /// Generates an object from its XML representation.
        /// </summary>
        /// <param name="reader">The <see cref="T:System.Xml.XmlReader"/> stream from which the object is deserialized. </param>
        public override void ReadXml(XmlReader reader)
        {
            base.ReadXml(reader);

            this.Value = reader.GetAttribute("val");
            if (this.Value == null) throw new MissingValueException("Value can not be null");

            reader.Read();
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public override void WriteXml(XmlWriter writer)
        {
            base.WriteXml(writer);
            writer.WriteAttributeString("val", this.Value);
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return $"Update {Element.Label}({Element.Id}) expanded={this.Expanded ?? false}";
        }
    }
}