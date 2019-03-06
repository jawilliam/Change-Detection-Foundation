using System.Collections.Generic;

namespace Jawilliam.CDF.Approach.Services
{
    /// <summary>
    /// Defines the hierarchical abstraction level of a node element.
    /// </summary>
    /// <typeparam name="TNode">Type of the supported elements.</typeparam>
    public interface IHierarchicalAbstractionService<TNode> : IService
    {
        /// <summary>
        /// Access to the children of a node.
        /// </summary>
        /// <param name="node">node of interest.</param>
        /// <returns>the node's children.</returns>
        IEnumerable<TNode> Children(TNode node);

        /// <summary>
        /// Access to the parent of a node.
        /// </summary>
        /// <param name="node">node of interest.</param>
        /// <returns>the node's parent.</returns>
        TNode Parent(TNode node);

        /// <summary>
        /// Access to the label of a node.
        /// </summary>
        /// <param name="node">node of interest.</param>
        /// <returns>a numeric identifier of the node type.</returns>
        int Label(TNode node);

        /// <summary>
        /// Access to the value of a node.
        /// </summary>
        /// <param name="node">node of interest.</param>
        /// <returns>the value of the given node.</returns>
        object Value(TNode node);

        /// <summary>
        /// Informs if a node it is leaf. 
        /// </summary>
        /// <param name="node">node of interest.</param>
        /// <returns>true if the given node is a leaf, false othwerwise.</returns>
        bool IsLeaf(TNode node);
    }
}
