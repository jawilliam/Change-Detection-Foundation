namespace Jawilliam.CDF.Actions
{
    /// <summary>
    /// Represents a basic "align" action.
    /// </summary>
    /// <typeparam name="TElement">Type of the supported elements.</typeparam>
    public class EditAlign<TElement> : BaseEditMove<TElement>
    {
        /// <summary>
        /// Gets the current action.
        /// </summary>
        public override ActionKind Kind => ActionKind.Align;

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
            return $"Align {this.Element} into {this.Parent} at {this.Position}";
        }
    }
}