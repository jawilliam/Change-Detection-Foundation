namespace Jawilliam.CDF.Approach
{
    /// <summary>
    /// Defines a pair of element versions, i.e., the original and the modified.
    /// </summary>
    public class RevisionPair<T>
    {
        /// <summary>
        /// Gets or sets the element original version.
        /// </summary>
        public T Original { get; set; }

        /// <summary>
        /// Gets or sets the element modified version.
        /// </summary>
        public T Modified { get; set; }
    }
}