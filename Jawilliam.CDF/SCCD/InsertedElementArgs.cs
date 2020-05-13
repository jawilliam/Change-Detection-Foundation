using System;

namespace Jawilliam.CDF.SCCD
{
    /// <summary>
    /// Provides data for the <see cref="INotifyInsertedElement{TElement}.InsertedElement"/>.
    /// </summary>
    /// <typeparam name="TElement">Type of the notified elements.</typeparam>
    public class InsertedElementArgs<TElement> : EventArgs
    {
        /// <summary>
        /// Gets or sets the inserted element version.
        /// </summary>
        public virtual TElement Modified { get; set; }
    }
}

    