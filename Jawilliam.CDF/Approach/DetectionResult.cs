using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Jawilliam.CDF.Actions;

namespace Jawilliam.CDF.Approach
{
    /// <summary>
    /// Defines the standard output for a change detection approach over two versions of a file or fragment.
    /// </summary>
    /// <typeparam name="TRevision">Type of the comparing versions.</typeparam>
    [Serializable]
    [XmlRoot("Result")]
    public class DetectionResult<TRevision> : RevisionPair<TRevision>
    {
        /// <summary>
        /// The backing field for the <see cref="Matches"/> property. 
        /// </summary>
        private List<MatchDescriptor> _matches;

        /// <summary>
        /// Gets or sets the matching set.
        /// </summary>
        [XmlArray("Matches")]
        [XmlArrayItem("Match")]
        public virtual List<MatchDescriptor> Matches
        {
            get { return this._matches ?? (this._matches = new List<MatchDescriptor>()); }
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
        public static DetectionResult<TRevision> Read(string text, Encoding encoding)
        {
            return XmlHelper.DeserializeObject<DetectionResult<TRevision>>(text ?? "<Result/>", encoding);
        }

        /// <summary>
        /// Replaces the referred <see cref="ElementVersion.GlobalId"/>s by their equivalent <see cref="ElementVersion.Id"/>s.
        /// </summary>
        /// <param name="original">the original tree used to generate the current delta.</param>
        /// <param name="modified">the modified tree used to generate the current delta.</param>
        public virtual void FromGlobalToIdDefinitions(ElementTree original, ElementTree modified)
        {
            var oDict = original.PostOrder(n => n.Children).Where(n => n.Root.GlobalId != null).ToDictionary(n => n.Root.GlobalId);
            var mDict = modified.PostOrder(n => n.Children).Where(n => n.Root.GlobalId != null).ToDictionary(n => n.Root.GlobalId);

            ElementTree tree;
            foreach (var match in this.Matches)
            {
                tree = oDict[match.Original.Id];
                match.Original.Id = tree.Root.Id;
                tree = mDict[match.Modified.Id];
                match.Modified.Id = tree.Root.Id;
            }
            
            foreach (var action in this.Actions)
            {
                switch (action.Action)
                {
                    case ActionKind.None:
                        break;
                    case ActionKind.Update:
                        var update = (UpdateOperationDescriptor)action;
                        tree = oDict[update.Element.Id];
                        update.Element.Id = tree.Root.Id;
                        break;
                    case ActionKind.Insert:
                        var insert = (InsertOperationDescriptor)action;
                        tree = mDict[insert.Element.Id];
                        insert.Element.Id = tree.Root.Id;
                        //tree = oDict[insert.Parent.Id];
                        //insert.Parent.Id = tree.Root.Id;
                        break;
                    case ActionKind.Delete:
                        var delete = (DeleteOperationDescriptor)action;
                        tree = oDict[delete.Element.Id];
                        delete.Element.Id = tree.Root.Id;
                        break;
                    case ActionKind.Move:
                        var move = (MoveOperationDescriptor)action;
                        tree = oDict[move.Element.Id];
                        move.Element.Id = tree.Root.Id;
                        //tree = oDict[move.Parent.Id];
                        //move.Parent.Id = tree.Root.Id;
                        break;
                    case ActionKind.Align:
                        var align = (AlignOperationDescriptor)action;
                        tree = oDict[align.Element.Id];
                        align.Element.Id = tree.Root.Id;
                        break;
                    default: throw new ArgumentException("unexpected action type.");
                }
            }
        }
    }

    /// <summary>
    /// Defines the standard output for a change detection approach over a pair of element versions, i.e., the original and the modified.
    /// </summary>
    [Serializable]
    [XmlRoot("Result")]
    public class DetectionResult : DetectionResult<object>
    {
        /// <summary>
        /// Reconstructs an object from the associated XML string.
        /// </summary>
        /// <param name="text">the raw XML.</param>
        /// <param name="encoding">the encoding of the read raw XML.</param>
        /// <returns>The instance reconstructed from the given text.</returns>
        public new static DetectionResult Read(string text, Encoding encoding)
        {
            return XmlHelper.DeserializeObject<DetectionResult>(text ?? "<Result/>", encoding);
        }
    }
}
