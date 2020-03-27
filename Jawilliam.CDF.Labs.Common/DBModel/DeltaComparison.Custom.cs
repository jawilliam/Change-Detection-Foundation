using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Jawilliam.CDF.Labs.Common.DBModel
{
    partial class DeltaComparison
    {
        /// <summary>
        /// Gets or sets the detection result.
        /// </summary>
        public virtual XMatchingComparison XMatching
        {
            get { return XMatchingComparison.Read(this.Matching, Encoding.Unicode); }
            set
            {
                this.Matching = value != null ? value.WriteXmlColumn() : throw new ArgumentNullException(nameof(value));
            }
        }

        [XmlRoot("MatchingComparison")]
        public class XMatchingComparison
        {
            /// <summary>
            /// The backing field for the <see cref="Matching"/> property. 
            /// </summary>
            private List<BetweenSymptom> _matching;

            /// <summary>
            /// Gets or sets the actions set.
            /// </summary>
            [XmlArray("Matching")]
            [XmlArrayItem("LrMatch", typeof(LRMatchSymptom))]
            [XmlArrayItem("RlMatch", typeof(RLMatchSymptom))]
            public virtual List<BetweenSymptom> Matching
            {
                get { return this._matching ?? (this._matching = new List<BetweenSymptom>()); }
                set { this._matching = value; }
            }

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
            public static XMatchingComparison Read(string text, Encoding encoding)
            {
                return XmlHelper.DeserializeObject<XMatchingComparison>(text ?? "<MatchingComparison/>", encoding);
            }
        }
    }
}
