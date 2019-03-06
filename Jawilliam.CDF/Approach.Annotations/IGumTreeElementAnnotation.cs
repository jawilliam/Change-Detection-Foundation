namespace Jawilliam.CDF.Approach.Annotations
{
    /// <summary>
    /// Defines information specially related to elements according to GumTree (e.g., the identifier in an GumTree styled AST).
    /// </summary>
    public interface IGumTreeElementAnnotation
    {
        /// <summary>
        /// Gets or sets a numeric identifier for the extended element.
        /// </summary>
        int Id { get; set; }
    }
}
