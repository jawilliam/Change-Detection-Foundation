using System;
using System.Linq;

namespace Jawilliam.CDF.Similarity.Metrics
{
    /// <summary>
    /// Defines those similarity metrics that applies over binary data (absence/presence).
    /// </summary>
    public interface IBinarySimetric<T>
    {
        /// <summary>
        /// Gets or sets the logic to compute the number of variables present in both sequences.
        /// </summary>
        Func<T[], T[], double> A { get; set; }

        /// <summary>
        /// Gets or sets the logic to compute the number of variables present in first sequence and absent from second sequence.
        /// </summary>
        Func<T[], T[], double> B { get; set; }

        /// <summary>
        /// Gets or sets the logic to compute the number of variables present in second sequence and absent from first sequence.
        /// </summary>
        Func<T[], T[], double> C { get; set; }

        /// <summary>
        /// Gets or sets the logic to compute the number of variables absent from both sequences.
        /// </summary>
        Func<T[], T[], double> D { get; set; }
    }

    /// <summary>
    /// Preferred base class for those simple similarity metrics that applies over binary data (absence/presence).
    /// </summary>
    [Serializable]
    public abstract class BinarySimetric<T> : VectorSimetric<T>, IBinarySimetric<T>
    {
        private Func<T[], T[], double> _a;
        private Func<T[], T[], double> _b;
        private Func<T[], T[], double> _c;
        private Func<T[], T[], double> _d;

        /// <summary>
        /// Gets or sets the logic to select the components of each (for first and second sequences) vector.
        /// </summary>
        public override VectorComponents.GetComponents<T> GetComponents
        {
            get { return this._getComponents ?? (this._getComponents = VectorComponents.ByTermFrequency); }
            set { this._getComponents = value; }
        }

        /// <summary>
        /// Gets or sets the logic to compute the number of variables present in both sequences.
        /// </summary>
        public virtual Func<T[], T[], double> A
        {
            get
            {
                return this._a ?? (this._a = delegate (T[] s1, T[] s2)
                {
                    double[] firstComponents, secondComponents;
                    this.GetComponents(s1, s2, this.Comparer, out firstComponents, out secondComponents);

                    return firstComponents.Select((arg1, i) => Math.Min(arg1, secondComponents[i])).Sum();
                });
            }
            set { this._a = value; }
        }

        /// <summary>
        /// Gets or sets the logic to compute the number of variables present in first sequence and absent from second sequence.
        /// </summary>
        public virtual Func<T[], T[], double> B
        {
            get
            {
                return this._b ?? (this._b = delegate (T[] s1, T[] s2)
                {
                    double[] firstComponents, secondComponents;
                    this.GetComponents(s1, s2, this.Comparer, out firstComponents, out secondComponents);

                    return firstComponents.Select((arg1, i) => Math.Abs(arg1 - secondComponents[i])).Sum();
                });
            }
            set { this._b = value; }
        }

        /// <summary>
        /// Gets or sets the logic to compute the number of variables present in second sequence and absent from first sequence.
        /// </summary>
        public virtual Func<T[], T[], double> C
        {
            get { return this._c ?? (this._c = (s1, s2) => 0); }
            set { this._c = value; }
        }

        /// <summary>
        /// Gets or sets the logic to compute the number of variables absent from both sequences.
        /// </summary>
        public virtual Func<T[], T[], double> D
        {
            get { return this._d ?? (this._d = (s1, s2) => 0); }
            set { this._d = value; }
        }
    }
}
