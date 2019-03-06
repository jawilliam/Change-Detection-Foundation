namespace Jawilliam.CDF.Actions
{
    /// <summary>
    /// Base class of the representations for the basic "move" and "align" actions.
    /// </summary>
    /// <typeparam name="TElement">Type of the supported elements.</typeparam>
    public abstract class BaseEditMove<TElement> : EditAction<TElement>
    {
        /// <summary>
        /// Gets or sets the k-index of the element to be inserted.
        /// </summary>
        public virtual int Position { get; set; }
    }
}
