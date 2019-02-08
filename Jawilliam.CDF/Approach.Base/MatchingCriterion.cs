//namespace Jawilliam.CDF.Approach
//{
//    /// <summary>
//    /// Implements a logic for determining if two elements match or not.
//    /// </summary>
//    /// <typeparam name="T">Type of the comparing elements.</typeparam>
//    /// <typeparam name="K">The type of the really processed representation when comparing two elements.</typeparam>
//    public abstract class MatchingCriterion<T, K> : Procedure<RevisionPair<T>, System.Tuple<bool, MatchDescriptor>>, IMatchingCriterion<T, K>
//    {
//        /// <summary>
//        /// Gets or sets a transformation to apply before the matching occurs.
//        /// </summary>
//        public virtual ConvertDelegate<T, K> Transform { get; set; }

//        /// <summary>
//        /// The core implementation for determining if the given elements are or not similar.
//        /// </summary>
//        protected override void CoreProceed()
//        {
//            T transformedOriginal = this.Args.Original, transformedModified = this.Args.Modified;
//            Transform?.Invoke(this.Args, out transformedOriginal, out transformedModified);
//            this.Args.Original = transformedOriginal;
//            this.Args.Modified = transformedModified;
//        }

//        /// <summary>
//        /// Determines if the given elements are or not similar.
//        /// </summary>
//        /// <param name="pair">the comparing elements and contextual information.</param>
//        /// <param name="matchingPair">If the elements are similar it returns an structure describing the result, for example
//        /// the similarity and/or a distance value. If the the elements are not similar, it returns null.</param>
//        /// <returns>True if the elements are similar, otherwise it returns false.</returns>
//        public bool Match(RevisionPair<T> pair, out MatchDescriptor matchingPair)
//        {
//            ((IProcedure<RevisionPair<T>, System.Tuple<bool, MatchDescriptor>>)this).Proceed(pair);
//            matchingPair = this.Result.Item2;
//            return this.Result.Item1;
//        }
//    }
//}
