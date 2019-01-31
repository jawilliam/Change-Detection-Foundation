namespace Jawilliam.CDF.Approach
{
    /// <summary>
    /// Implements a logic for determining if two elements match or not.
    /// </summary>
    /// <typeparam name="T">Type of the comparing elements.</typeparam>
    public abstract class MatchingCriterion<T> : Procedure<DetectionStep<T>, (bool, MatchingPair<T>)>, IMatchingCriterion<T>
    {
        /// <summary>
        /// Gets or sets a transformation to apply before the matching occurs.
        /// </summary>
        public virtual TransformDelegate<T> Transform { get; set; }

        ///// <summary>
        ///// Backing field for the <see cref="DetectionStep"/> property.
        ///// </summary>
        //private DetectionStep<T> _detectionStep;

        ///// <summary>
        ///// Gets the internally and used detection step information. The contained elements are already transformed.
        ///// </summary>
        //protected virtual DetectionStep<T> DetectionStep => this._detectionStep ?? (this._detectionStep = new DetectionStep<T>());

        /// <summary>
        /// The core implementation for determining if the given elements are or not similar.
        /// </summary>
        protected override void CoreProceed()
        {
            T transformedOriginal = this.Args.Original, transformedModified = this.Args.Modified;
            Transform?.Invoke(this.Args, out transformedOriginal, out transformedModified);
            this.Args.Original = transformedOriginal;
            this.Args.Modified = transformedModified;
            //this.Args.Approach = this.Args.Approach;
        }

        /// <summary>
        /// Determines if the given elements are or not similar.
        /// </summary>
        /// <param name="pair">the comparing elements and contextual information.</param>
        /// <param name="matchingPair">If the elements are similar it returns an structure describing the result, for example
        /// the similarity and/or a distance value. If the the elements are not similar, it returns null.</param>
        /// <returns>True if the elements are similar, otherwise it returns false.</returns>
        public bool Match(DetectionStep<T> pair, out MatchingPair<T> matchingPair)
        {
            ((IProcedure<DetectionStep<T>, (bool, MatchingPair<T>)>)this).Proceed(pair);
            matchingPair = this.Result.Item2;
            return this.Result.Item1;
        }

        ///// <summary>
        ///// The core implementation for determining if the given elements are or not similar.
        ///// </summary>
        ///// <param name="matchingPair">If the elements are similar it returns an structure describing the result, for example
        ///// the similarity and/or a distance value. If the the elements are not similar, it returns null.</param>
        ///// <returns>True if the elements are similar, otherwise it returns false.</returns>
        //protected abstract bool CoreMatch(out MatchingPair<T> matchingPair);
    }
}
