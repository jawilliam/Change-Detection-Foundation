namespace Jawilliam.CDF.Actions
{
    /// <summary>
    /// Represents a basic "insert" action.
    /// </summary>
    /// <typeparam name="TElement">Type of the supported elements.</typeparam>
    public class EditInsert<TElement> : EditAction<TElement>
    {
        /// <summary>
        /// Gets the current action.
        /// </summary>
        public override ActionKind Kind => ActionKind.Insert;

        /// <summary>
        /// Gets or sets the k-index of the element to be inserted.
        /// </summary>
        public virtual int Position { get; set; }

        /// <summary>
        /// Gets or sets the node to be the parent of the node to be inserted.
        /// </summary>
        public virtual TElement Parent { get; set; }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return $"Insert {this.Element} into {this.Parent} at {this.Position}";
        }
    }
}