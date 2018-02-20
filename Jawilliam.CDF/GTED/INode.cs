namespace Jawilliam.CDF.GTED
{
    /// <summary>
    /// Defines a tree node.
    /// </summary>
    public interface INode
    {
        /// <summary>
        /// Get or sets the value.
        /// </summary>
        object Value { get; set; }

        /// <summary>
        /// Gets or sets the label.
        /// </summary>
        object Label { get; set; }
    }
}
