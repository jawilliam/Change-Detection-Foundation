using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Jawilliam.CDF.Actions;

namespace Jawilliam.CDF
{
    /// <summary>
    /// Defines the standard output for a change detection approach over a pair of element versions, i.e., the original and the modified.
    /// </summary>
    [Serializable]
    [XmlRoot("Result")]
    public class DetectionResult : RevisionPair<ElementDescriptor>
    {
        /// <summary>
        /// The backing field for the <see cref="Matches"/> property. 
        /// </summary>
        private List<RevisionDescriptor> _matches;

        /// <summary>
        /// Gets or sets the matching set.
        /// </summary>
        [XmlArray("Matches")]
        [XmlArrayItem("Match")]
        public virtual List<RevisionDescriptor> Matches
        {
            get { return this._matches ?? (this._matches = new List<RevisionDescriptor>()); }
            set { this._matches = value; }
        }

        /// <summary>
        /// The backing field for the <see cref="Actions"/> property. 
        /// </summary>
        private List<ActionDescriptor> _actions;

        /// <summary>
        /// Gets or sets the actions set.
        /// </summary>
        [XmlArray("Actions")]
        [XmlArrayItem("Insert", typeof(InsertOperationDescriptor))]
        [XmlArrayItem("Delete", typeof(DeleteOperationDescriptor))]
        [XmlArrayItem("Update", typeof(UpdateOperationDescriptor))]
        [XmlArrayItem("Move", typeof(MoveOperationDescriptor))]
        [XmlArrayItem("Align", typeof(AlignOperationDescriptor))]
        public virtual List<ActionDescriptor> Actions
        {
            get { return this._actions ?? (this._actions = new List<ActionDescriptor>()); }
            set { this._actions = value; }
        }

        // Delta

        /// <summary>
        /// Gets or sets if some error interrupted the result.
        /// </summary>
        [XmlAttribute("error")]
        public virtual string Error { get; set; }

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
