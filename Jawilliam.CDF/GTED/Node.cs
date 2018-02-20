namespace Jawilliam.CDF.GTED
{
    /// <summary>
    /// Implements a tree node.
    /// </summary>
    public class Node : INode
    {
        /// <summary>
        /// Get or sets the value.
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// Gets or sets the label.
        /// </summary>
        public object Label { get; set; }
    }
}
