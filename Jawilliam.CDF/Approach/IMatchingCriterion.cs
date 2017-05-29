namespace Jawilliam.CDF.Approach
{
    /// <summary>
    /// Defines a logic for determining if two elements match or not.
    /// </summary>
    /// <typeparam name="T">Type of the comparing elements.</typeparam>
    public interface IMatchingCriterion<T> : IProcedure<RevisionPair<T>, bool>
    {
        /// <summary>
        /// Gets or sets a transformation to apply before the matching occurs.
        /// </summary>
        IMatchingTransformation<T> Transform { get; set; }

        /// <summary>
        /// Determines if the given elements are or not similar.
        /// </summary>
        /// <param name="pair">the comparing elements and contextual information.</param>
        /// <param name="distance">if it is sopported, it returns the distance value.</param>
        /// <param name="similarity">if it is sopported, it returns a similarity value between 0 and 1 (0 = no similarity, 1 = perfectly similar).</param>
        /// <returns>True if the elements are similar, otherwise it returns false.</returns>
        bool Match(DetectionStep<T> pair, out double? distance, out double similarity);
    }
}
