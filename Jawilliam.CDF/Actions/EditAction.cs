namespace Jawilliam.CDF.Actions
{
    /// <summary>
    /// Describes a change detection action.
    /// </summary>
    /// <typeparam name="TElement">Type of the supported elements.</typeparam>
    public abstract class EditAction<TElement>
    {
        /// <summary>
        /// Gets the current action.
        /// </summary>
        public abstract ActionKind Kind { get; }

        /// <summary>
        /// Gets or sets the element to be operated.
        /// </summary>
        public virtual TElement Element { get; set; }
    }
}