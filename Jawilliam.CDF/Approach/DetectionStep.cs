namespace Jawilliam.CDF.Approach
{
    /// <summary>
    /// Represents a step in an approach of change detection.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DetectionStep<T> : RevisionPair<T>
    {
        /// <summary>
        /// Gets or sets the approach in which the current step happens.
        /// </summary>
        public virtual IFrameworkApproach Approach { get; set; }
    }
}