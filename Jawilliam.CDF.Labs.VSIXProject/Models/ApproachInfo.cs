using Jawilliam.CDF.Labs.Common.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jawilliam.CDF.Labs.VSIXProject.Models
{
    /// <summary>
    /// Describes a SCCD approach.
    /// </summary>
    public class ApproachInfo
    {
        /// <summary>
        /// Gets or sets sets a name.
        /// </summary>
        public virtual string Title { get; set; }

        /// <summary>
        /// Gets or sets sets the approach.
        /// </summary>
        public virtual ChangeDetectionApproaches Approach { get; set; }

        /// <summary>
        /// Gets or sets sets the direction. FORWARD (true) | BACKWARD (false).
        /// </summary>
        public virtual bool Forward { get; set; }

        /// <summary>
        /// Gets or sets sets the file format.
        /// </summary>
        public virtual FileFormatKind FileFormat { get; set; }
    }
}
