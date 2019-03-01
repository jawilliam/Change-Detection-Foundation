//namespace Jawilliam.CDF.Approach
//{
//    /// <summary>
//    /// Defines a logic for determining if two elements match or not.
//    /// </summary>
//    /// <typeparam name="T">Type of the comparing elements.</typeparam>
//    /// <typeparam name="K">The type of the really processed representation when comparing two elements.</typeparam>
//    public interface IMatchingCriterion<T, K> //: IFrameworkProcedure<RevisionPair<T>, System.Tuple<bool, MatchDescriptor>>
//    {
//        /// <summary>
//        /// Gets or sets a transformation to apply before the matching occurs.
//        /// </summary>
//        ConvertDelegate<T, K> Transform { get; set; }

//        /// <summary>
//        /// Determines if the given elements are or not similar.
//        /// </summary>
//        /// <param name="pair">the comparing elements and contextual information.</param>
//        /// <param name="matchingPair">If the elements are similar it returns an structure describing the result, for example
//        /// the similarity and/or a distance value. If the the elements are not similar, it returns null.</param>
//        /// <returns>True if the elements are similar, otherwise it returns false.</returns>
//        bool Match(RevisionPair<T> pair, out MatchDescriptor matchingPair);
//    }
//}
