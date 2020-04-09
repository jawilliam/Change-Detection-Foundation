using System;

namespace Jawilliam.CDF.Labs.VSIXProject.Models
{
    /// <summary>
    /// Represents a summary view of a delta comparison.
    /// </summary>
    public class DisagreedDeltaBase
    {
        /// <summary>
        /// Gets or sets the left delta's Id. 
        /// </summary>
        public virtual Guid LeftId { get; set; }

        /// <summary>
        /// Gets or sets the right delta's Id. 
        /// </summary>
        public virtual Guid RightId { get; set; }
    }
}
