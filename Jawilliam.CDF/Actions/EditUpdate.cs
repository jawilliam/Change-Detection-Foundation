namespace Jawilliam.CDF.Actions
{
    /// <summary>
    /// Represents a basic "update" action.
    /// </summary>
    /// <typeparam name="TElement">Type of the supported elements.</typeparam>
    public class EditUpdate<TElement> : EditAction<TElement>
    {
        /// <summary>
        /// Gets the current action.
        /// </summary>
        public override ActionKind Kind => ActionKind.Update;

        /// <summary>
        /// The element with the new value to replace with.
        /// </summary>
        public virtual TElement NewElement { get; set; }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return $"Update {Element}";
        }
    }
}