using Jawilliam.CDF.Actions;
using Jawilliam.CDF.Approach;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jawilliam.CDF.Evaluation
{
    /// <summary>
    /// Finds symptoms of redundant changes w.r.t. a matching set.
    /// </summary>
    public class MatchingSetRedundancyFinder : RedundancyFinder
    {
        /// <summary>
        /// Stores the value of the <see cref="MatchingSet"/> property.
        /// </summary>
        private IEnumerable<RevisionDescriptor> _matchingSet;

        /// <summary>
        /// Gets or sets the matching set discovered by a comparing (e.g., candidate) solution.
        /// </summary>
        public virtual IEnumerable<RevisionDescriptor> MatchingSet
        {
            get { return this._matchingSet == null ? throw new ArgumentNullException("Must specify the discovered matching set") : this._matchingSet; }
            set { this._matchingSet = value == null ? throw new ArgumentNullException("value") : value; }
        }

        /// <summary>
        /// Informs whether two original and modified versions.
        /// </summary>
        /// <param name="pattern">redundancy pattern being looking for.</param>
        /// <param name="originalId">id of the original element.</param>
        /// <param name="modifiedId">id of the modified element.</param>
        /// <returns>true if the given versions are redundant, false otherwise.</returns>
        protected override bool AreRedundant(RedundancyPattern pattern, string originalId, string modifiedId)
        {
            return this.MatchingSet.Any(match => match.Original.Id == originalId && match.Modified.Id == modifiedId);
        }
    }
}
