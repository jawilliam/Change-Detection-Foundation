using System;
using System.Xml;

namespace Jawilliam.CDF.Actions
{
    /// <summary>
    /// Represents a basic "move" operation.
    /// </summary>
    [Serializable]
    public class MoveOperationDescriptor : BaseMoveOperationDescriptor
    {
        /// <summary>
        /// Gets the current action.
        /// </summary>
        public override ActionKind Action => ActionKind.Move;

        /// <summary>
        /// Gets or sets the node to be the parent of the node to be inserted.
        /// </summary>
        public virtual ElementVersion Parent { get; set; }

        /// <summary>
        /// Generates an object from its XML representation.
        /// </summary>
        /// <param name="reader">The <see cref="T:System.Xml.XmlReader"/> stream from which the object is deserialized. </param>
        public override void ReadXml(XmlReader reader)
        {
            base.ReadXml(reader);

            var parent = new ElementVersion
            {
                Id = reader.GetAttribute("pId"),
                Label = reader.GetAttribute("pLb"),
                Value = reader.GetAttribute("pVl")
            };
            this.Parent = parent.Id != null || parent.Label != null ? parent : null;

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

            if (this.Parent != null)
            {
                if (this.Parent.Id != null)
                    writer.WriteAttributeString("pId", this.Parent.Id);

                if (this.Parent.Label != null)
                    writer.WriteAttributeString("pLb", this.Parent.Label);

                if (this.Parent.Value != null)
                    writer.WriteAttributeString("pVl", this.Parent.Value);
            }

            writer.WriteAttributeString("pos", XmlConvert.ToString(this.Position));
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return $"Move {Element.Label}({Element.Id}) into {this.Parent.Label}({this.Parent.Id}) at {this.Position} expanded={this.Expanded ?? false}";
        }
    }
}