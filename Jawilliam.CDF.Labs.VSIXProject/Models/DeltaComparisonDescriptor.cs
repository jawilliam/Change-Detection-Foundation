using System;

namespace Jawilliam.CDF.Labs.VSIXProject.Models
{
    /// <summary>
    /// Represents a summary view of a delta comparison.
    /// </summary>
    public class DeltaComparisonDescriptor
    {
        /// <summary>
        /// Gets or sets row number given a particular ordering (e.g., by <see cref="LeftId"/>).
        /// </summary>
        public virtual int Index { get; set; }

        /// <summary>
        /// Gets or sets the left delta's Id. 
        /// </summary>
        public virtual Guid LeftId { get; set; }

        /// <summary>
        /// Gets or sets the right delta's Id. 
        /// </summary>
        public virtual Guid RightId { get; set; }

        /// <summary>
        /// Gets or sets the total amount of disagreement matches.
        /// </summary>
        public virtual int AllMismatches { get; set; }

        /// <summary>
        /// Gets or sets the total amount of LR-disagreement matches.
        /// </summary>
        public virtual int LrMismatches { get; set; }

        /// <summary>
        /// Gets or sets the total amount of RL-disagreement matches.
        /// </summary>
        public virtual int RlMismatches { get; set; }
    }
}
