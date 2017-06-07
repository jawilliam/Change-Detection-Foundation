using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Jawilliam.CDF.Metrics.Quality
{
    /// <summary>
    /// Computes a distance based on the set of edit operation and a cost model.
    /// </summary>
    /// <typeparam name="T">The concrete type of the elements for which the current metric will be computed.</typeparam>
    public class EditDistance<T> : IMetric<T>
    {
        /// <summary>
        /// Gets or sets a token for receiving cancellation notifications and answering to them.
        /// </summary>
        public CancellationToken CancellationToken { get; set; }

        /// <summary>
        /// Backing field for the <see cref="CostModel"/> property.
        /// </summary>
        private Func<T, double> _costModel;

        /// <summary>
        /// Defines a cost model to compute the distance.
        /// </summary>
        /// <remarks>By default it is an unweighted edit distance (i.e. cost 1 for each operation), which is equivalent
        /// to the count of operations.</remarks>
        public virtual Func<T, double> CostModel
        {
            get { return this._costModel ?? (this._costModel = descriptor => 1); }
            set { this._costModel = value; }
        }

        /// <summary>
        /// Computes the metric value between two sequences.
        /// </summary>
        /// <param name="set">the set of elements for which the current metric will be computed.</param>
        /// <returns>the metric value.</returns>
        public virtual double Compute(IEnumerable<T> set)
        {
            return set.Sum(o => this.CostModel(o));
        }
    }
}
