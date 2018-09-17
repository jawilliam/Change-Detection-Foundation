using Jawilliam.CDF.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jawilliam.CDF.Evaluation
{
    /// <summary>
    /// Compares two SCCD solutions by redundancy.
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
        /// Defines the logic of corrections by redundancy.
        /// </summary>
        /// <param name="pattern">the redundancy pattern to look for.</param>
        /// <param name="delta"></param>
        /// <returns></returns>
        public delegate IEnumerable<(ActionDescriptor Original, ActionDescriptor Modified)> Corrector(string pattern, IEnumerable<ActionDescriptor> delta);
    }
}
