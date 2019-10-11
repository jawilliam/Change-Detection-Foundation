using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Jawilliam.CDF.Labs.DBModel
{
    partial class BetweenMatchInfo
    {
        /// <summary>
        /// Generates an object from its XML representation.
        /// </summary>
        /// <param name="reader">The <see cref="T:System.Xml.XmlReader"/> stream from which the object is deserialized. </param>
        public virtual void ReadXml(XmlReader reader, string prefix)
        {
            this.Approach = XmlConvert.ToInt32(reader.GetAttribute($"{prefix}Approach"));

            this.Original = new ElementContext();
            this.Original.ReadXml(reader, $"{prefix}O");

            this.Modified = new ElementContext();
            this.Modified.ReadXml(reader, $"{prefix}M");
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public virtual void WriteXml(XmlWriter writer, string prefix)
        {
            if (this.Approach != null)
                writer.WriteAttributeString($"{prefix}Approach", XmlConvert.ToString(this.Approach.Value));

            if (this.Original != null)
                this.Original.WriteXml(writer, $"{prefix}O");

            if (this.Modified != null)
                this.Modified.WriteXml(writer, $"{prefix}M");
        }
    }
}
