namespace Jawilliam.CDF.Approach.Criterions.Simetric
{
    /// <summary>
    /// Preferred base class for the <see cref="ISimetric{T}"/> vector implementations.
    /// </summary>
    public abstract class VectorSimetric<T> : SimpleSimetric<T>
    {
        ///// <summary>
        ///// Gets or sets the kind of component to compute.
        ///// </summary>
        //public virtual VectorComponentKind Kind { get; set; } = VectorComponentKind.Existence;

        /// <summary>
        /// Stores the values of <see cref="GetComponents"/> property.
        /// </summary>
        internal VectorComponents.GetComponents<T> _getComponents;

        /// <summary>
        /// Gets or sets the logic to select the components of each (for first and second sequences) vector.
        /// </summary>
        public virtual VectorComponents.GetComponents<T> GetComponents
        {
            get { return this._getComponents ?? (this._getComponents = VectorComponents.ByTermExistence);}
            set { this._getComponents = value; }
        }

        ///// <summary>
        ///// Computes the vector components for each given tokens into the given sequences.
        ///// </summary>
        ///// <param name="tokens">Tokens to compute the components for.</param>
        ///// <param name="firstSequence">First sequence where to compute the components over.</param>
        ///// <param name="secondSequence">First sequence where to compute the components over.</param>
        ///// <param name="kind">kind of component to compute.</param>
        ///// <param name="comparer">the logic to support comparisons of objects for equality.</param>
        ///// <param name="firstResult">Returns the computed components related to the first sequence.</param>
        ///// <param name="secondResult">Returns the computed components related to the second sequence.</param>
        ///// <returns>tuple of each tokens and its respective component information, since the sequence, as follows: 
        ///// <see cref="Tuple{T1,T2}.Item1"/> as the token.
        ///// <see cref="Tuple{T1,T2}.Item2"/> as the component.</returns>
        ///// <typeparam name="TK"></typeparam>
        //protected virtual void GetComponents<TK>(IList<TK> tokens, TK[] firstSequence, TK[] secondSequence, VectorComponentKind kind, IEqualityComparer<TK> comparer, out double[] firstResult, out double[] secondResult) where TK : IEquatable<TK>
        //{
        //    switch (kind)
        //    {
        //        case VectorComponentKind.TermFrequency:
        //            firstResult = tokens.Select(t => (double)firstSequence.Count(ts => comparer.Equals(ts, t))).ToArray();
        //            secondResult = tokens.Select(t => (double)secondSequence.Count(ts => comparer.Equals(ts, t))).ToArray();
        //            break;
        //        case VectorComponentKind.Existence:
        //            firstResult = tokens.Select(t => firstSequence.Any(ts => comparer.Equals(ts, t)) ? 1d : 0d).ToArray();
        //            secondResult = tokens.Select(t => secondSequence.Any(ts => comparer.Equals(ts, t)) ? 1d : 0d).ToArray();
        //            break;
        //        case VectorComponentKind.Equality:
        //            if(firstSequence.Length != secondSequence.Length)
        //                throw new InvalidOperationException("First and second sequences must have same lengths.");
        //            firstResult = firstSequence.Select(t => 1d).ToArray();
        //            secondResult = firstSequence.Select((t, i) => comparer.Equals(t, secondSequence[i]) ? 1d : 0d).ToArray();
        //            break;
        //        case VectorComponentKind.EqualityExtended:
        //            int max = Math.Max(firstSequence.Length, secondSequence.Length);
        //            firstResult = Enumerable.Repeat(1d, max).ToArray();
        //            secondResult = new double[max];
        //            secondResult = secondResult.Select((t, i) => i < firstSequence.Length && i < secondSequence.Length && comparer.Equals(firstSequence[i], secondSequence[i]) ? 1d : 0d).ToArray();
        //            break;
        //        default:
        //            throw new NotSupportedException($"{kind} of component is not supported.");
        //    }
        //}

        
    }

    ///// <summary>
    ///// Contain options of component that can be computed as vector components.
    ///// </summary>
    //public enum VectorComponentKind
    //{
    //    TermFrequency,

    //    Existence,

    //    /// <summary>
    //    /// None processing is applied and the same initially data is returned.
    //    /// </summary>
    //    None,

    //    /// <summary>
    //    /// Each reflect a semantic of whether or not a[i] == b[i] (a[i] is always equals to 1 and b[i] is 1 if a[i] == b[i], otherwise is 0).
    //    /// </summary>
    //    Equality,

    //    /// <summary>
    //    /// Each reflect a semantic of whether or not a[i] == b[i] (a[i] is always equals to 1 and b[i] is 1 if a[i] == b[i] or i > b.Length(), otherwise is 0).
    //    /// </summary>
    //    EqualityExtended,

    //    // PDF: Probability Density
    //}
}
