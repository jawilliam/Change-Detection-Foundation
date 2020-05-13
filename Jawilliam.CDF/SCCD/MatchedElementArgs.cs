using System;

namespace Jawilliam.CDF.SCCD
{
    /// <summary>
    /// Provides data for the <see cref="INotifyMatchedElement{TElement}.MatchedElement"/>.
    /// </summary>
    /// <typeparam name="TElement">Type of the notified elements.</typeparam>
    public class MatchedElementArgs<TElement> : EventArgs
    {
        /// <summary>
        /// Gets or sets the original version of the matched element.
        /// </summary>
        public virtual TElement Original { get; set; }

        /// <summary>
        /// Gets or sets the modified version of the matched element.
        /// </summary>
        public virtual TElement Modified { get; set; }
    }
}

    