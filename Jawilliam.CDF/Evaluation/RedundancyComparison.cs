using Jawilliam.CDF.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jawilliam.CDF.Evaluation
{
    /// <summary>
    /// Defines the logic to compare solutions based on redundant changes and related indicators.
    /// </summary>
    public class RedundancyComparison
    {
        /// <summary>
        /// Stores the value of the <see cref="Delta"/> property.
        /// </summary>
        private IEnumerable<ActionDescriptor> _delta;

        /// <summary>
        /// Gets or sets the actions conforming the diagnosable delta.
        /// </summary>
        public virtual IEnumerable<ActionDescriptor> Delta
        {
            get { return this._delta == null ? throw new ArgumentNullException("Must specify a diagnosable delta") : this._delta; }
            set { this._delta = value == null ? throw new ArgumentNullException("value") :  value; }
        }

        /// <summary>
        /// Stores the value of the <see cref="Corrector"/> property.
        /// </summary>
        private RedundancyFinder _corrector;

        /// <summary>
        /// Gets or sets the logic to look for symptoms of redundant changes.
        /// </summary>
        public virtual RedundancyFinder Corrector
        {
            get { return this._corrector == null ? throw new ArgumentNullException("Must specify the corrector") : this._corrector; }
            set { this._corrector = value == null ? throw new ArgumentNullException("value") : value; }
        }
    }
}
