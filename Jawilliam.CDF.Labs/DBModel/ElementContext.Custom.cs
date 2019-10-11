using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Jawilliam.CDF.Labs.DBModel
{
    partial class ElementContext
    {
        public override string ToString()
        {
            return this.Element.Hint != null
                ? $"{this.Element.Id}:{this.Element.Type}({this.Element.Hint})"
                : $"{this.Element.Id}:{this.Element.Type}";
        }

        /// <summary>
        /// Generates an object from its XML representation.
        /// </summary>
        /// <param name="reader">The <see cref="T:System.Xml.XmlReader"/> stream from which the object is deserialized. </param>
        public virtual void ReadXml(XmlReader reader, string elementPrefix)
        {
            this.Element = new ElementDescription();
            this.Element.ReadXml(reader, elementPrefix);
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public virtual void WriteXml(XmlWriter writer, string elementPrefix)
        {
            if (this.Element != null)
                this.Element.WriteXml(writer, elementPrefix);
        }
    }
}
