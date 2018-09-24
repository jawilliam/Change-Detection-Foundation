using System;
using System.Xml;

namespace Jawilliam.CDF.Actions
{
    /// <summary>
    /// Represents a basic "delete" operation.
    /// </summary>
    [Serializable]
    public class DeleteOperationDescriptor : OperationDescriptor
    {
        /// <summary>
        /// Gets the current action.
        /// </summary>
        public override ActionKind Action => ActionKind.Delete;

        /// <summary>
        /// Generates an object from its XML representation.
        /// </summary>
        /// <param name="reader">The <see cref="T:System.Xml.XmlReader"/> stream from which the object is deserialized. </param>
        public override void ReadXml(XmlReader reader)
        {
            base.ReadXml(reader);

            reader.Read();
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return $"Delete {Element.Label}({Element.Id})";
        }
    }
}