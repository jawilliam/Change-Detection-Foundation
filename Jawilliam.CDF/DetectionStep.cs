namespace Jawilliam.CDF
{
    /// <summary>
    /// Represents a step in an approach of change detection.
    /// </summary>
    /// <typeparam name="TApproach">the type of the supporting approach.</typeparam>
    /// <typeparam name="T">the type of the supported elements</typeparam>
    public class DetectionStep<TApproach, T> : RevisionPair<T>
    {
        /// <summary>
        /// Gets or sets the approach in which the current step happens.
        /// </summary>
        public virtual TApproach Approach { get; set; }
    }
}