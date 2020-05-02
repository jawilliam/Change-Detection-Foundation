using Jawilliam.CDF.Labs.Common.DBModel;
using System;
using System.Collections.ObjectModel;
using System.Xml.Linq;

namespace Jawilliam.CDF.Labs.VSIXProject.Models
{
    /// <summary>
    /// Represents a summary view of a delta comparison.
    /// </summary>
    public partial class DisagreedDeltaContent : DisagreedDeltaBase
    {
        private XAstRevisionPair _fullAsts;

        ///// <summary>
        ///// Gets or sets the delta comparison. 
        ///// </summary>
        //public virtual DeltaComparison Comparison { get; set; }

        /// <summary>
        /// Gets or sets the XML-format full abstract syntax trees.
        /// </summary>
        public virtual XAstRevisionPair FullAsts
        {
            get => this._fullAsts ?? (this._fullAsts = new XAstRevisionPair());
            set => this._fullAsts = value;
        }

        /// <summary>
        /// Gets or sets the source code version pair.
        /// </summary>
        public virtual (FileContent, FileContent) ContentVersionPair { get; set; }

        /// <summary>
        /// Gets or sets the delta containing expected behaviors.
        /// </summary>
        public virtual Delta Review { get; set; }

        /// <summary>
        /// Gets or sets the matches under review.
        /// </summary>
        public virtual ObservableCollection<RateableMatch> DisagreedMatches { get; set; }
    }
}
