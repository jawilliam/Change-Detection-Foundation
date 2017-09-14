using System;

namespace Jawilliam.CDF.Approach
{
    /// <summary>
    /// Defines a pair of element versions, i.e., the original and the modified.
    /// </summary>
    /// <typeparam name="TOriginal">Type of the original elements.</typeparam>
    /// <typeparam name="TModified">Type of the modified elements.</typeparam>
    [Serializable]
    public class RevisionPair<TOriginal, TModified>
    {
        /// <summary>
        /// Gets or sets the element original version.
        /// </summary>
        public TOriginal Original { get; set; }

        /// <summary>
        /// Gets or sets the element modified version.
        /// </summary>
        public TModified Modified { get; set; }
    }

    /// <summary>
    /// Defines a pair of element versions, i.e., the original and the modified.
    /// </summary>
    /// <typeparam name="T">Type of the elements.</typeparam>
    [Serializable]
    public class RevisionPair<T> : RevisionPair<T, T> {}
}