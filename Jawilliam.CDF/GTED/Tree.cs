using System.Collections.Generic;

namespace Jawilliam.CDF.GTED
{
    /// <summary>
    /// Implements a tree data structure.
    /// </summary>
    public class Tree : ITree
    {
        /// <summary>
        /// Gets or sets the parent tree.
        /// </summary>
        public virtual ITree Parent { get; set; }

        /// <summary>
        /// Gets or sets the root node.
        /// </summary>
        public virtual INode Root { get; set; }

        /// <summary>
        /// Gets the children of the current tree.
        /// </summary>
        public virtual IList<ITree> Children { get; } = new List<ITree>();
    }
}
