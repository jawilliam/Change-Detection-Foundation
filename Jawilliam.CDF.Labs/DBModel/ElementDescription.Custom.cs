﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Jawilliam.CDF.Labs.DBModel
{
    partial class ElementDescription
    {
        public override string ToString()
        {
            return $"{this.Id}:{this.Type}";
        }

        /// <summary>
        /// Generates an object from its XML representation.
        /// </summary>
        /// <param name="reader">The <see cref="T:System.Xml.XmlReader"/> stream from which the object is deserialized. </param>
        public virtual void ReadXml(XmlReader reader, string elementPrefix)
        {
            Id = reader.GetAttribute($"{elementPrefix}Id");
            Type = reader.GetAttribute($"{elementPrefix}Type");
            Hint = reader.GetAttribute($"{elementPrefix}Hint");
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public virtual void WriteXml(XmlWriter writer, string elementPrefix)
        {
            if (this.Id != null)
                writer.WriteAttributeString($"{elementPrefix}Id", this.Id);

            if (this.Type != null)
                writer.WriteAttributeString($"{elementPrefix}Type", this.Type);

            if (this.Hint != null)
                writer.WriteAttributeString($"{elementPrefix}Hint", this.Hint);
        }
    }
}
