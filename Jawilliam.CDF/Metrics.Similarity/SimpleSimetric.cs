using System;
using System.Collections.Generic;

namespace Jawilliam.CDF.Metrics.Similarity
{
    /// <summary>
    /// Preferred base class of similarity metric that are implemented based on stand-alone logic.
    /// </summary>
    public abstract class SimpleSimetric<T> : BaseSimetric<T>
    {
        /// <summary>
        /// Stores the value of <see cref="Comparer"/> property.
        /// </summary>
        private IEqualityComparer<T> _comparer;

        /// <summary>
        /// Gets the logic to support comparisons of objects for equality.
        /// </summary>
        public override IEqualityComparer<T> Comparer
        {
            get { return this._comparer ?? (this._comparer = EqualityComparer<T>.Default); }
            set { this._comparer = value; }
        }
    }
}
