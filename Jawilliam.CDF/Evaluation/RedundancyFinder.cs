using Jawilliam.CDF.Actions;
using System.Collections.Generic;

namespace Jawilliam.CDF.Evaluation
{
    /// <summary>
    /// Finds redundant changes on a given delta.
    /// </summary>
    public abstract class RedundancyFinder
    {
        /// <summary>
        /// Defines the logic of corrections by redundancy.
        /// </summary>
        /// <param name="pattern">redundancy pattern to look for.</param>
        /// <param name="delta">diagnosable delta</param>
        /// <returns>Symptoms of redundant changes.</returns>
        public abstract IEnumerable<(RedundancyPattern Pattern, ActionDescriptor Original, ActionDescriptor AndOriginal, ActionDescriptor Modified, ActionDescriptor AndModified)> Find(IEnumerable<ActionDescriptor> delta);
    }
}
