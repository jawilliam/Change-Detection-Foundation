namespace Jawilliam.CDF.Approach
{
    /// <summary>
    /// Implements a logic for determining if two elements match or not.
    /// </summary>
    /// <typeparam name="T">Type of the comparing elements.</typeparam>
    public abstract class MatchingCriterion<T> : Procedure<RevisionPair<T>, bool>, IMatchingCriterion<T>
    {
        /// <summary>
        /// Gets or sets a transformation to apply before the matching occurs.
        /// </summary>
        public virtual IMatchingTransformation<T> Transform { get; set; }

        /// <summary>
        /// Backing field for the <see cref="DetectionStep"/> property.
        /// </summary>
        private DetectionStep<T> _detectionStep;

        /// <summary>
        /// Gets the internally used detection step information.
        /// </summary>
        protected virtual DetectionStep<T> DetectionStep => this._detectionStep ?? (this._detectionStep = new DetectionStep<T>());

        /// <summary>
        /// Determines if the given elements are or not similar.
        /// </summary>
        /// <param name="pair">the comparing elements and contextual information.</param>
        /// <param name="distance">if it is sopported, it returns the distance value.</param>
        /// <param name="similarity">if it is sopported, it returns a similarity value between 0 and 1 (0 = no similarity, 1 = perfectly similar).</param>
        /// <returns>True if the elements are similar, otherwise it returns false.</returns>
        public bool Match(DetectionStep<T> pair, out double? distance, out double similarity)
        {
            T transformedOriginal = pair.Original, transformedModified = pair.Modified;
            Transform?.Transform(pair, out transformedOriginal, out transformedModified);
            this.DetectionStep.Original = transformedOriginal;
            this.DetectionStep.Modified = transformedModified;
            this.DetectionStep.Approach = pair.Approach;

            return this.CoreMatch(out distance, out similarity);
        }

        /// <summary>
        /// Determines if the given elements are or not similar.
        /// </summary>
        /// <param name="distance">if it is sopported, it returns the distance value.</param>
        /// <param name="similarity">if it is sopported, it returns a similarity value between 0 and 1 (0 = no similarity, 1 = perfectly similar).</param>
        /// <returns>True if the elements are similar, otherwise it returns false.</returns>
        protected abstract bool CoreMatch(out double? distance, out double similarity);
    }
}
