using System.Collections.Generic;

namespace Jawilliam.CDF.GTED
{
    /// <summary>
    /// Defines
    /// </summary>
    public interface IForest
    {
        /// <summary>
        /// Gets the children connected components of the current forest.
        /// </summary>
        IList<ITree> Components { get; }
    }
}