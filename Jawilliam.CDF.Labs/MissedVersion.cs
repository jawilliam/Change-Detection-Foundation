using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jawilliam.CDF.Labs
{
    /// <summary>
    /// Describes a version of a missed match.
    /// </summary>
    public class MissedVersion
    {
        /// <summary>
        /// Gets or sets the type of missed version (e.g., field, variable).
        /// </summary>
        public virtual string Type { get; set; }
        
        /// <summary>
        /// Gets or sets the conceptual version of the missed element.
        /// </summary>
        public virtual ElementTree Element { get; set; }

        /// <summary>
        /// Gets or sets an ancestor describing the scope of the conceptual version.
        /// </summary>
        public virtual ElementTree Reference { get; set; }

        /// <summary>
        /// Gets or sets the lower scope version concetually matched.
        /// </summary>
        public virtual ElementTree MatchedReference { get; set; }

        /// <summary>
        /// Gets or sets the scopes analyzed to search for redundant changes.
        /// </summary>
        public virtual IEnumerable<ElementTree> Scopes { get; set; }
    }
}
