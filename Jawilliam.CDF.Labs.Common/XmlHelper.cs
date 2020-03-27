using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Jawilliam.CDF.Labs
{
    public class XmlHelper
    {
        #region Serialize and deserialize objects as Xml using generic types

        private static Encoding XmlEncoding => new UTF8Encoding(false); //property to avoid having common static variable

        /// <summary>
        /// Serialize an object into an XML string
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string SerializeObject(object obj)
        {
            return SerializeObject(obj, XmlEncoding);
        }

        /// <summary>
        /// Serialize an object into an XML string
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string SerializeObject(object obj, Encoding encoding)
        {
            XmlTextWriter xmlTextWriter = null;
            try
            {
                var memoryStream = new MemoryStream();

                var xs = new XmlSerializer(obj.GetType());
                xmlTextWriter = new XmlTextWriter(memoryStream, encoding);
                xs.Serialize(xmlTextWriter, obj);
                memoryStream = (MemoryStream)xmlTextWriter.BaseStream;

                var xmlString = encoding.GetString(memoryStream.ToArray());

                return xmlString;
            }
            finally
            {
                xmlTextWriter?.Close();
            }
        }


        /// <summary>
        /// Reconstruct an object from an XML string
        /// </summary>
        /// <param name="xml"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static T DeserializeObject<T>(string xml, Encoding encoding)
        {
            var xs = new XmlSerializer(typeof(T));

            var newraw = xml.Replace("<?xml version=\"1.0\" encoding=\"utf-16\"?>", "");
            var arr = encoding.GetBytes(newraw);
            var memoryStream = new MemoryStream(arr);

            //XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, encoding);
            return (T)xs.Deserialize(memoryStream);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="raw"></param>
        /// <returns></returns>
        public static T ReadXmlColumn<T>(string raw)
        {
            string newraw = "<?xml version=\"1.0\" encoding=\"utf-16\"?>" + raw;
            return XmlHelper.DeserializeObject<T>(newraw, Encoding.Unicode);
        }


        #endregion
    }
}
