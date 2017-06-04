using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Jawilliam.CDF.Actions;

namespace Jawilliam.CDF.Approach
{
    /// <summary>
    /// Defines the standard output for a change detection approach over a pair of element versions, i.e., the original and the modified.
    /// </summary>
    [Serializable]
    [XmlRoot("Result")]
    public class DetectionResult : RevisionPair<ElementDescriptor>
    {
        /// <summary>
        /// Gets or sets the matching set.
        /// </summary>
        [XmlArray("Matches")]
        [XmlArrayItem("Match")]
        public virtual List<RevisionDescriptor> Matches { get; set; }

        /// <summary>
        /// Gets or sets the actions set.
        /// </summary>
        [XmlArray("Actions")]
        [XmlArrayItem("Action")]
        public virtual List<ActionDescriptor> Actions { get; set; }

        /// <summary>
        /// Writes current instance like a XML document. 
        /// </summary>
        /// <returns>the serialized information.</returns>
        public virtual string WriteXmlColumn()
        {
            return XmlHelper.SerializeObject(this, Encoding.Unicode);
        }

        /// <summary>
        /// Reconstructs an object from the associated XML string.
        /// </summary>
        /// <param name="text">the raw XML.</param>
        /// <param name="encoding">the encoding of the read raw XML.</param>
        /// <returns>The instance reconstructed from the given text.</returns>
        public static DetectionResult Read(string text, Encoding encoding)
        {
            return XmlHelper.DeserializeObject<DetectionResult>(text ?? "<Result/>", encoding);
        }
    }
}
