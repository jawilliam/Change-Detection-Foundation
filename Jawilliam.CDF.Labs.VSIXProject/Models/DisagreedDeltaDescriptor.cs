using System;

namespace Jawilliam.CDF.Labs.VSIXProject.Models
{
    public partial class DisagreedDeltaDescriptor : DisagreedDeltaBase
    {
        /// <summary>
        /// Gets or sets row number given a particular ordering (e.g., by <see cref="LeftId"/>).
        /// </summary>
        public virtual int Index { get; set; }

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
