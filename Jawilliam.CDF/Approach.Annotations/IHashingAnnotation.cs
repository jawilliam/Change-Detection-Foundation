namespace Jawilliam.CDF.Approach.Annotations
{
    /// <summary>
    /// Defines information related to the hashing.
    /// </summary>
    public interface IHashingAnnotation
    {
        /// <summary>
        /// Gets or sets the full content hash. 
        /// </summary>
        object FullHash { get; set; }

        /// <summary>
        /// Gets or sets the relevant content hash. 
        /// </summary>
        object EssentialHash { get; set; }
    }
}
