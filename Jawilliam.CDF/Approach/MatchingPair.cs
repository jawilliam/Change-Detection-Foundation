using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Jawilliam.CDF.Approach
{
    /// <summary>
    /// Represents a pair of element versions that match.
    /// </summary>
    /// <typeparam name="T">Type of the elements.</typeparam>
    public class MatchingPair<T> : RevisionPair<T>
    {
        /// <summary>
        /// Gets or sets the distance according to the current metric.
        /// </summary>
        [XmlAttribute("distance")]
        public virtual double? Distance { get; set; }

        /// <summary>
        /// Gets or sets the similarity according to the current metric.
        /// </summary>
        [XmlAttribute("similarity")]
        public virtual double? Similarity { get; set; }
    }
}
