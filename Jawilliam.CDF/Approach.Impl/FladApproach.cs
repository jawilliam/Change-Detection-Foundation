using Jawilliam.CDF.Approach.Annotations;
using Jawilliam.CDF.Approach.Annotations.Impl;
using Jawilliam.CDF.Approach.Services;
using Jawilliam.CDF.Approach.Services.Impl;

namespace Jawilliam.CDF.Approach.Impl
{
    /// <summary>
    /// Fully Language-Aware source code Deltas.
    /// </summary>
    /// <typeparam name="TElement">Type of the supported elements.</typeparam>
    public abstract class FladApproach<TElement, TAnnotation> : Approach<TElement> where TAnnotation : Annotation<TElement>, IMatchingAnnotation<TElement>, new()
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <remarks>Sets up common services: <see cref="IAnnotationSetService{TElement, TAnnotation}"/>, <see cref="IMatchingSetService{TElement}"/>.</remarks>
        public FladApproach()
        {
            this.Services.Add((int)ServiceId.OriginalAnnotationSet, new AnnotationSetService<TElement, TAnnotation> { Id = (int)ServiceId.OriginalAnnotationSet });
            this.Services.Add((int)ServiceId.ModifiedAnnotationSet, new AnnotationSetService<TElement, TAnnotation> { Id = (int)ServiceId.ModifiedAnnotationSet });
            this.Services.Add((int)ServiceId.MatchingSet, new MatchingSetService<TElement, TAnnotation>(this) { Id = (int)ServiceId.MatchingSet });
        }
    }
}
