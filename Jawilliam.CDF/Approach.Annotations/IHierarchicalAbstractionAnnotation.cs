namespace Jawilliam.CDF.Approach.Services
{
    /// <summary>
    /// Defines the hierarchical abstraction level of a node element.
    /// </summary>
    /// <typeparam name="TNode">Type of the supported elements.</typeparam>
    public interface IHierarchicalAbstractionAnnotation
    {
        /// <summary>
        /// Gets or sets the size of the annotated subtree. 
        /// </summary>
        int Size { get; set; }

        /// <summary>
        /// Gets or sets the leading trivia.
        /// </summary>
        object[] LeadingTrivia { get; set; }

        /// <summary>
        /// Gets or sets the trailing trivia.
        /// </summary>
        object[] TrailingTrivia { get; set; }

        /// <summary>
        /// Gets or sets the structured trivia.
        /// </summary>
        object[] DescendantTrivia { get; set; }
    }
}
