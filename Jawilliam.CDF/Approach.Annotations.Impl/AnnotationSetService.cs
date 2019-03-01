using Jawilliam.CDF.Approach.Services.Impl;
using System.Collections.Generic;

namespace Jawilliam.CDF.Approach.Annotations.Impl
{
    /// <summary>
    /// Stores information available for the elements.
    /// </summary>
    /// <typeparam name="TElement">Type of the elements.</typeparam>
    /// <typeparam name="TAnnotation">Type of the information to store for each element.</typeparam>
    public class AnnotationSetService<TElement, TAnnotation> : Service, IAnnotationSetService<TElement, TAnnotation>, IEndDetection 
        where TAnnotation : IElementAnnotation<TElement>, new()
    {
        /// <summary>
        /// Stores the value of <see cref="Annotations"/>.
        /// </summary>
        Dictionary<TElement, TAnnotation> _annotations;

        /// <summary>
        /// Gets or sets the matches per original element. 
        /// </summary>
        public virtual Dictionary<TElement, TAnnotation> Annotations
        {
            get { return this._annotations ?? (this._annotations = new Dictionary<TElement, TAnnotation>()); }
            set { this._annotations = value; }
        }

        /// <summary>
        /// Initializes the structure with the set of elements to annotate.
        /// </summary>
        /// <param name="elements"></param>
        public virtual void Init(IEnumerable<TElement> elements)
        {
            foreach (var element in elements)
            {
                var annotation = new TAnnotation { Element = element };
                this.Annotations.Add(element, annotation);
            }
        }

        /// <summary>
        /// Finalizes the current service after completing the detection of changes in a revision pair.
        /// </summary>
        public virtual void EndDetection()
        {
            this.Annotations.Clear();
        }
    }
}
