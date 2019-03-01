namespace Jawilliam.CDF.Approach.Annotations
{
    /// <summary>
    /// Defines a link between the annotation and the annotated element.
    /// </summary>
    /// <typeparam name="TElement">Type of the element.</typeparam>
    public interface IElementAnnotation<TElement>
    {
        /// <summary>
        /// Gets or sets the extended element.
        /// </summary>
        TElement Element { get; set; }
    }
}
