namespace Jawilliam.CDF.Actions
{
    /// <summary>
    /// Represents a basic "delete" action.
    /// </summary>
    /// <typeparam name="TElement">Type of the supported elements.</typeparam>
    public class EditDelete<TElement> : EditAction<TElement>
    {
        /// <summary>
        /// Gets the current action.
        /// </summary>
        public override ActionKind Kind => ActionKind.Delete;

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return $"Delete {Element}";
        }
    }
}