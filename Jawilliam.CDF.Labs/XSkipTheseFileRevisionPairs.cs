using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Jawilliam.CDF.Labs
{
    /// <summary>
    /// Contains the XML annotations for a file version content summary.
    /// </summary>
    [Serializable]
    [XmlRoot("SkipThese")]
    public class XSkipTheseFileRevisionPairs : XmlColumn
    {
        /// <summary>
        /// Gets or sets all affected projects.
        /// </summary>
        [XmlArray("Projects")]
        [XmlArrayItem("Project")]
        public virtual ProjectInfo[] Projects { get; set; } = new ProjectInfo[0];

        /// <summary>
        /// Reconstructs an object from the associated XML string.
        /// </summary>
        /// <param name="text">the raw XML.</param>
        /// <param name="encoding">the encoding of the read raw XML.</param>
        /// <returns>The instance reconstructed from the given text.</returns>
        public static XSkipTheseFileRevisionPairs Read(string text, Encoding encoding)
        {
            return XmlHelper.DeserializeObject<XSkipTheseFileRevisionPairs>(text ?? "<SkipThese/>", encoding);
        }

        /// <summary>
        /// Contains information related with a project of interest.
        /// </summary>
        public class ProjectInfo
        {
            /// <summary>
            /// Gets or sets the name of the project.
            /// </summary>
            [XmlAttribute("name")]
            public virtual string Name { get; set; }

            /// <summary>
            /// Gets or sets the file revision pairs to skip.
            /// </summary>
            [XmlArray("FileRevisionPairs")]
            [XmlArrayItem("Frp")]
            public virtual FileRevisionPairInfo[] FileRevisionPairs { get; set; }
        }

        /// <summary>
        /// Contains information related with a file revision pair of interest.
        /// </summary>
        public class FileRevisionPairInfo
        {
            /// <summary>
            /// Gets or sets the 'id' identifying the file revision pair of interest.
            /// </summary>
            [XmlAttribute("guid")]
            public virtual string Guid { get; set; }
        }
    }
}
