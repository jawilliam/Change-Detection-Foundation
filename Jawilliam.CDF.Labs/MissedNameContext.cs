using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jawilliam.CDF.Labs
{
    /// <summary>
    /// Describes a context to search for missed match.
    /// </summary>
    public class MissedNameContext
    {
        /// <summary>
        /// Gets or sets the label of the target elements.
        /// </summary>
        public virtual string Label { get; set; }

        ///// <summary>
        ///// Gets or sets the type of the target elements.
        ///// </summary>
        //public virtual string Type { get; set; }

        /// <summary>
        /// Gets or sets the logic to describe the element being named by the target name element.
        /// </summary>
        public virtual Func<ElementTree, string> NameOf { get; set; }

        /// <summary>
        /// Gets or sets a criterion to identify the name elements of interest.
        /// </summary>
        public virtual Func<ElementTree, bool> Criterion { get; set; }

        /// <summary>
        /// Gets or sets the logic to select the ancestor scopes to search for redundant conterparts.
        /// </summary>
        public virtual Func<ElementTree, IEnumerable<ElementTree>> OuterScopes { get; set; }
    }
}
