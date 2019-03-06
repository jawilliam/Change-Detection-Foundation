using System;

namespace Jawilliam.CDF.Approach.Criterions.Simetric
{
    /// <summary>
    /// Preferred base class of similarity metric that are implemented based on stand-alone logic.
    /// </summary>
    public abstract class SimpleSimetric<T> : BaseSimetric<T>
    {
        /// <summary>
        /// Gets or sets the equality notion among two comparing elements.
        /// </summary>
        private Func<T, T, bool> _areEqual;

        /// <summary>
        /// Gets the logic to support comparisons of objects for equality.
        /// </summary>
        public override Func<T, T, bool> AreEqual
        {
            get { return this._areEqual ?? (this._areEqual = (x, y) => object.Equals(x, y)); }
            set { this._areEqual = value; }
        }
    }
}
