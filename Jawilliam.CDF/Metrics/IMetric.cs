using System.Collections.Generic;
using System.Threading;

namespace Jawilliam.CDF.Metrics
{
    /// <summary>
    /// Defines a metric over a set of elements.
    /// </summary>
    /// <typeparam name="T">The concrete type of the elements for which the current metric will be computed.</typeparam>
    public interface IMetric<T>
    {
        /// <summary>
        /// Gets or sets a token for receiving cancellation notifications and answering to them.
        /// </summary>
        CancellationToken CancellationToken { get; set; }

        /// <summary>
        /// Computes the metric value between two sequences.
        /// </summary>
        /// <param name="set">the set of elements for which the current metric will be computed.</param>
        /// <returns>the metric value.</returns>
        double Compute(IEnumerable<T> set);
    }
}