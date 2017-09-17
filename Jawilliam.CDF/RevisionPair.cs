using System;

namespace Jawilliam.CDF
{
    /// <summary>
    /// Defines a pair of element versions, i.e., the original and the modified.
    /// </summary>
    /// <typeparam name="T">Type of the elements.</typeparam>
    [Serializable]
    public class RevisionPair<T>
    {
        /// <summary>
        /// Gets or sets the element original version.
        /// </summary>
        public T Original { get; set; }

        /// <summary>
        /// Gets or sets the element modified version.
        /// </summary>
        public T Modified { get; set; }
    }
}