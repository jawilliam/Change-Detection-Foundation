﻿namespace Jawilliam.CDF.Approach
{
    /// <summary>
    /// Defines a logic for determining if two elements match or not.
    /// </summary>
    /// <typeparam name="T">Type of the comparing elements.</typeparam>
    public interface IMatchingCriterion<T> : IProcedure<DetectionStep<T>, (bool, MatchingPair<T>)>
    {
        /// <summary>
        /// Gets or sets a transformation to apply before the matching occurs.
        /// </summary>
        TransformDelegate<T> Transform { get; set; }

        /// <summary>
        /// Determines if the given elements are or not similar.
        /// </summary>
        /// <param name="pair">the comparing elements and contextual information.</param>
        /// <param name="matchingPair">If the elements are similar it returns an structure describing the result, for example
        /// the similarity and/or a distance value. If the the elements are not similar, it returns null.</param>
        /// <returns>True if the elements are similar, otherwise it returns false.</returns>
        bool Match(DetectionStep<T> pair, out MatchingPair<T> matchingPair);
    }
}
