using System.Collections.Generic;

namespace Jawilliam.CDF.UniDM
{
    /// <summary>
    /// Defines a transformation from one original document into another modified.
    /// </summary>
    /// <typeparam name="TDocument">Type of the documents</typeparam>
    public interface IChange<TDocument> : IElement
    {
        /// <summary>
        /// Applies the represented change to transform part of the original document into the modified one.
        /// </summary>
        /// <param name="original">original document (typically the older)</param>
        /// <param name="modified">modified document (typically the newer)</param>
        void Transform(TDocument original, TDocument modified);
    }
}
