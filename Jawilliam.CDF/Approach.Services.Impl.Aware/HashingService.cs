using System;

namespace Jawilliam.CDF.Approach.Services.Impl.Aware
{
    /// <summary>
    /// Tentative base class for the implementations of <see cref="IHashingService{TElement}"/>.
    /// </summary>
    /// <typeparam name="TElement">Type of the hashable elements.</typeparam>
    /// <typeparam name="TAnnotation">Type of the information to store for each element.</typeparam>
    public class HashingService<TElement, TAnnotation> : Jawilliam.CDF.Approach.Services.Impl.HashingService<TElement, TAnnotation> where TAnnotation : IHierarchicalAbstractionAnnotation, new()
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="serviceLocator">the mechanism for dynamically loading a typed service.</param>
        /// <param name="getHash">how to get the hash of an element annotation.</param>
        /// <param name="setHash">how to set the hash to the annotation of an element.</param>
        public HashingService(IApproach<TElement> serviceLocator, Func<TAnnotation, object> getHash, Action<TAnnotation, object> setHash) : base(serviceLocator, getHash, setHash)
        {
        }

        /// <summary>
        /// Gets the internally used <see cref="ITextualAbstractionService{TElement}"/>.
        /// </summary>
        internal override IHierarchicalAbstractionService<TElement> HierarchicalAbstraction
        {
            get
            {
                return this.ServiceLocator.HierarchicalAbstraction(full: true);
            }
        }
    }
}
