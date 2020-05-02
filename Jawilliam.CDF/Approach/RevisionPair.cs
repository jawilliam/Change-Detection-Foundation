using System;

namespace Jawilliam.CDF.Approach
{
    /// <summary>
    /// Defines a revision pair.
    /// </summary>
    /// <typeparam name="T">Type of the elements.</typeparam>
    [Serializable]
    public class RevisionPair<T>
    {
        /// <summary>
        /// Gets or sets the element original version.
        /// </summary>
        public virtual T Original { get; set; }

        /// <summary>
        /// Gets or sets the element modified version.
        /// </summary>
        public virtual T Modified { get; set; }
    }
}