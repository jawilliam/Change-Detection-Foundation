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
    }
}
