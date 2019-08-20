using Jawilliam.CDF.Approach;
using Jawilliam.CDF.Approach.Annotations;
using Jawilliam.CDF.Approach.Services;
using System;

namespace Jawilliam.CDF.CSharp.Flad
{
    /// <summary>
    /// Stores information available for the elements.
    /// </summary>
    /// <typeparam name="TElement">Type of the elements.</typeparam>
    /// <typeparam name="TAnnotation">Type of the information to store for each element.</typeparam>
    public class AnnotationSetService<TElement, TAnnotation> : Jawilliam.CDF.Approach.Annotations.Impl.AnnotationSetService<TElement, TAnnotation>
        where TAnnotation : IElementAnnotation<TElement>, new()
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="approach">the solution wherein the current choice will be called</param>
        public AnnotationSetService(IApproach<TElement> approach)
        {
            this.Approach = approach ?? throw new ArgumentNullException(nameof(approach));
        }

        /// <summary>
        /// Gets or sets the solution wherein the current choice will be called.
        /// </summary>
        public IApproach<TElement> Approach { get; private set; }
    }

    /// <summary>
    /// Stores information available for the original elements.
    /// </summary>
    /// <typeparam name="TElement">Type of the elements.</typeparam>
    /// <typeparam name="TAnnotation">Type of the information to store for each element.</typeparam>
    public class OriginalSetService<TElement, TAnnotation> : AnnotationSetService<TElement, TAnnotation>, IBeginDetection where TAnnotation : IElementAnnotation<TElement>, new()
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="approach">the solution wherein the current choice will be called</param>
        public OriginalSetService(IApproach<TElement> approach) : base(approach)
        {
            this.Id = (int)ServiceId.OriginalAnnotationSet;
        }

        /// <summary>
        /// Initializes the current service for detecting changes in a new revision pair.
        /// </summary>
        public virtual void BeginDetection()
        {
            var hierarchicalAbstraction = this.Approach.HierarchicalAbstraction(full: true);
            var originals = this.Approach.Result.Original.PostOrder(e => hierarchicalAbstraction.Children(e));
            this.Approach.Originals<TElement, TAnnotation>().Init(originals);
        }
    }

    /// <summary>
    /// Stores information available for the modified elements.
    /// </summary>
    /// <typeparam name="TElement">Type of the elements.</typeparam>
    /// <typeparam name="TAnnotation">Type of the information to store for each element.</typeparam>
    public class ModifiedSetService<TElement, TAnnotation> : AnnotationSetService<TElement, TAnnotation>, IBeginDetection where TAnnotation : IElementAnnotation<TElement>, new()
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="approach">the solution wherein the current choice will be called</param>
        public ModifiedSetService(IApproach<TElement> approach) : base(approach)
        {
            this.Id = (int)ServiceId.ModifiedAnnotationSet;
        }

        /// <summary>
        /// Initializes the current service for detecting changes in a new revision pair.
        /// </summary>
        public virtual void BeginDetection()
        {
            var hierarchicalAbstraction = this.Approach.HierarchicalAbstraction(full: true);
            var modifieds = this.Approach.Result.Modified.PostOrder(e => hierarchicalAbstraction.Children(e));
            this.Approach.Modifieds<TElement, TAnnotation>().Init(modifieds);
        }
    }
}
