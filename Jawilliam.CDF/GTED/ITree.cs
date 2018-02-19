using System.Collections.Generic;

namespace Jawilliam.CDF.GTED
{
    /// <summary>
    /// Defines a tree data structure.
    /// </summary>
    public interface ITree
    {
        /// <summary>
        /// Gets or sets the root node.
        /// </summary>
        INode Root { get; set; }

        /// <summary>
        /// Gets the children of the current tree.
        /// </summary>
        IList<ITree> Children { get; }
    }

    /// <summary>
    /// Defines a tree data structure.
    /// </summary>
    /// <typeparam name="TNode">Concrete type of the node.</typeparam>
    public interface ITree<TNode> where TNode : INode
    {
        /// <summary>
        /// Gets or sets the root node.
        /// </summary>
        TNode Root { get; set; }

        /// <summary>
        /// Gets the children of the current tree.
        /// </summary>
        IList<ITree<TNode>> Children { get; }
    }
}