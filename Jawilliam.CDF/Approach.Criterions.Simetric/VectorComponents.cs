using System;
using System.Collections.Generic;
using System.Linq;

namespace Jawilliam.CDF.Approach.Criterions.Simetric
{
    /// <summary>
    /// Contains shared methods related to componentization of vectors to be compared in terms of similarity.
    /// </summary>
    public static class VectorComponents
    {
        /// <summary>
        /// Computes the frequencies of each unique term.
        /// </summary>
        /// <typeparam name="T">Concrete type of each term.</typeparam>
        /// <param name="firstSequence">First sequence where to compute the components over.</param>
        /// <param name="secondSequence">First sequence where to compute the components over.</param>
        /// <param name="comparer">the logic to support comparisons of objects for equality.</param>
        /// <param name="firstResult">Returns the computed components related to the first sequence.</param>
        /// <param name="secondResult">Returns the computed components related to the second sequence.</param>
        /// <param name="termSelector">Function to compute the terms.</param>
        /// <returns>The unique terms that the frequencies was computed for.</returns>
        public static IEnumerable<T> ByTermFrequency<T>(T[] firstSequence, T[] secondSequence, IEqualityComparer<T> comparer, out double[] firstResult, out double[] secondResult, Func<IEnumerable<T>, IEnumerable<T>, IEqualityComparer<T>, IEnumerable<T>> termSelector = null)
        {
            if (firstSequence == null) throw new ArgumentNullException(nameof(firstSequence));
            if (secondSequence == null) throw new ArgumentNullException(nameof(secondSequence));

            var terms = termSelector?.Invoke(firstSequence, secondSequence, comparer).ToArray() ?? firstSequence.Union(secondSequence, comparer).ToArray();

            firstResult = terms.Select(t => (double)firstSequence.Count(ts => comparer.Equals(ts, t))).ToArray();
            secondResult = terms.Select(t => (double)secondSequence.Count(ts => comparer.Equals(ts, t))).ToArray();

            return terms;
        }

        /// <summary>
        /// Computes the existence of each unique term.
        /// </summary>
        /// <typeparam name="T">Concrete type of each term.</typeparam>
        /// <param name="firstSequence">First sequence where to compute the components over.</param>
        /// <param name="secondSequence">First sequence where to compute the components over.</param>
        /// <param name="comparer">the logic to support comparisons of objects for equality.</param>
        /// <param name="firstResult">Returns the computed components related to the first sequence.</param>
        /// <param name="secondResult">Returns the computed components related to the second sequence.</param>
        /// <param name="termSelector">Function to compute the terms.</param>
        /// <returns>The unique terms that the existences was computed for.</returns>
        public static IEnumerable<T> ByTermExistence<T>(T[] firstSequence, T[] secondSequence, IEqualityComparer<T> comparer, out double[] firstResult, out double[] secondResult, Func<IEnumerable<T>, IEnumerable<T>, IEqualityComparer<T>, IEnumerable<T>> termSelector = null)
        {
            if (firstSequence == null) throw new ArgumentNullException(nameof(firstSequence));
            if (secondSequence == null) throw new ArgumentNullException(nameof(secondSequence));

            var terms = termSelector?.Invoke(firstSequence, secondSequence, comparer).ToArray() ?? firstSequence.Union(secondSequence, comparer).ToArray();

            firstResult = terms.Select(t => firstSequence.Any(ts => comparer.Equals(ts, t)) ? 1d : 0d).ToArray();
            secondResult = terms.Select(t => secondSequence.Any(ts => comparer.Equals(ts, t)) ? 1d : 0d).ToArray();

            return terms;
        }

        /// <summary>
        /// Computes the equalities of each corresponding positions.
        /// </summary>
        /// <typeparam name="T">Concrete type of each term.</typeparam>
        /// <param name="firstSequence">First sequence where to compute the components over.</param>
        /// <param name="secondSequence">First sequence where to compute the components over.</param>
        /// <param name="comparer">the logic to support comparisons of objects for equality.</param>
        /// <param name="firstResult">Returns the computed components related to the first sequence.</param>
        /// <param name="secondResult">Returns the computed components related to the second sequence.</param>
        /// <param name="termSelector">Function to compute the terms.</param>
        /// <returns>The unique terms that the equalities was computed for.</returns>
        public static IEnumerable<T> ByPositionEquality<T>(T[] firstSequence, T[] secondSequence, IEqualityComparer<T> comparer, out double[] firstResult, out double[] secondResult, Func<IEnumerable<T>, IEnumerable<T>, IEqualityComparer<T>, IEnumerable<T>> termSelector = null)
        {
            if (firstSequence == null) throw new ArgumentNullException(nameof(firstSequence));
            if (secondSequence == null) throw new ArgumentNullException(nameof(secondSequence));

            var terms = termSelector?.Invoke(firstSequence, secondSequence, comparer).ToArray() ?? (firstSequence.Length > secondSequence.Length ? firstSequence : secondSequence).ToArray();

            firstResult = terms.Select((t, i) => i < firstSequence.Length && comparer.Equals(t, firstSequence[i]) ? 1d : 0d).ToArray();
            secondResult = terms.Select((t, i) => i < secondSequence.Length && comparer.Equals(t, secondSequence[i]) ? 1d : 0d).ToArray();

            return terms;
        }

        /// <summary>
        /// Computes the components for given sequences and optionally a term selector.
        /// </summary>
        /// <typeparam name="T">Concrete type of each term.</typeparam>
        /// <param name="firstSequence">First sequence where to compute the components over.</param>
        /// <param name="secondSequence">First sequence where to compute the components over.</param>
        /// <param name="areEqual">the logic to support comparisons of objects for equality.</param>
        /// <param name="firstResult">Returns the computed components related to the first sequence.</param>
        /// <param name="secondResult">Returns the computed components related to the second sequence.</param>
        /// <param name="termSelector">Function to compute the terms.</param>
        /// <returns>The unique terms that the components was computed for.</returns>
        public delegate IEnumerable<T> GetComponents<T>(T[] firstSequence, T[] secondSequence, IEqualityComparer<T> areEqual, out double[] firstResult, out double[] secondResult, Func<IEnumerable<T>, IEnumerable<T>, IEqualityComparer<T>, IEnumerable<T>> termSelector = null);
    }
}
