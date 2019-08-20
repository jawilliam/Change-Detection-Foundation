using System.Collections.Generic;

namespace Jawilliam.CDF.Approach.Annotations
{
    /// <summary>
    /// Defines a store of information available for each element.
    /// </summary>
    /// <typeparam name="TElement">Type of the elements.</typeparam>
    /// <typeparam name="TAnnotation">Type of the information to store for each element.</typeparam>
    public interface IAnnotationSetService<TElement, TAnnotation> : IService, IEndDetection where TAnnotation : new()
    {
        /// <summary>
        /// Gets or sets the matches per original element. 
        /// </summary>
        Dictionary<TElement, TAnnotation> Annotations { get; set; }

        /// <summary>
        /// Initializes a set of elements to annotate.
        /// </summary>
        /// <param name="elements">the set of elements to initialize.</param>
        void Init(IEnumerable<TElement> elements);

        /// <summary>
        /// Gets or sets whether the annotations will be automatically clear, or not.
        /// </summary>
        bool KeepAnnotations { get; set; }
    }
}