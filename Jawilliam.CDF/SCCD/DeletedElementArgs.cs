using System;

namespace Jawilliam.CDF.SCCD
{
    /// <summary>
    /// Provides data for the <see cref="INotifyDeletedElement{TElement}.DeletedElement"/>.
    /// </summary>
    /// <typeparam name="TElement">Type of the notified elements.</typeparam>
    public class DeletedElementArgs<TElement> : EventArgs
    {
        /// <summary>
        /// Gets or sets the deleted element version.
        /// </summary>
        public virtual TElement Original { get; set; }
    }
}

    