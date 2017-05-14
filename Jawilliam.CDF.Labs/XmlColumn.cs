using System;
using System.Text;

namespace Jawilliam.CDF.Labs
{
    [Serializable]
    public abstract class XmlColumn
    {
        /// <summary>
        /// Writes current instance like a XML document. 
        /// </summary>
        /// <returns>the serialized information.</returns>
        public virtual string WriteXmlColumn()
        {
            return XmlHelper.SerializeObject(this, Encoding.Unicode);
        }

        public static T ReadXmlColumn<T>(string raw, Encoding encoding)
        {
            return XmlHelper.DeserializeObject<T>(raw, encoding);
        }
    }
}
