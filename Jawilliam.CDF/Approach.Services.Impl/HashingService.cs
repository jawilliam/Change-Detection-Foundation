using Jawilliam.CDF.Approach.Annotations;
using System;
using System.Collections.Generic;

namespace Jawilliam.CDF.Approach.Services.Impl
{
    /// <summary>
    /// Tentative base class for the implementations of <see cref="IHashingService{TElement}"/>.
    /// </summary>
    /// <typeparam name="TElement">Type of the hashable elements.</typeparam>
    /// <typeparam name="TAnnotation">Type of the information to store for each element.</typeparam>
    public class HashingService<TElement, TAnnotation> : ServiceWithDependencies<IApproach<TElement>>, IHashingService<TElement, TAnnotation> where TAnnotation : IHierarchicalAbstractionAnnotation, new()
    {
        internal static readonly int _Base = 33;

        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="serviceLocator">the mechanism for dynamically loading a typed service.</param>
        /// <param name="getHash">how to get the hash of an element annotation.</param>
        /// <param name="setHash">how to set the hash to the annotation of an element.</param>
        public HashingService(IApproach<TElement> serviceLocator, Func<TAnnotation, object> getHash, Action<TAnnotation, object> setHash) : base(serviceLocator)
        {
            this.GetHash = getHash ?? throw new ArgumentNullException(nameof(getHash));
            this.SetHash = setHash ?? throw new ArgumentNullException(nameof(setHash));
        }

        /// <summary>
        /// How to get the hash of an element annotation.
        /// </summary>
        public Func<TAnnotation, object> GetHash { get; private set; }

        /// <summary>
        /// How to set the hash to an element annotation.
        /// </summary>
        public Action<TAnnotation, object> SetHash { get; private set; }

        internal virtual int FPow(int a, int b)
        {
            if (b == 1)
                return a;

            int result = 1;
            while (b > 0)
            {
                if ((b & 1) != 0)
                    result *= a;

                b >>= 1;
                a *= a;
            }
            return result;
        }

        /// <summary>
        /// Computes the hash of a node.
        /// </summary>
        /// <param name="element">node to get the hash for.</param>
        /// <param name="annotationSet">the corresponding annotation set.</param>
        /// <returns>the corresponding hash.</returns>
        public virtual object ComputeHash(TElement element, IAnnotationSetService<TElement, TAnnotation> annotationSet)
        {
            return this.HierarchicalAbstraction.IsLeaf(element) 
                ? this.ComputeLeafHash(element, annotationSet)
                : this.ComputeInnerHash(element, annotationSet); ;
        }

        /// <summary>
        /// Computes the hash of a text.
        /// </summary>
        /// <param name="element">node to get the hash for.</param>
        /// <param name="annotationSet">the corresponding annotation set.</param>
        /// <returns>the corresponding hash.</returns>
        internal virtual object ComputeLeafHash(TElement element, IAnnotationSetService<TElement, TAnnotation> annotationSet)
        {
            var text = this.ServiceLocator.TextualAbstraction().FullText(element);
            return (text ?? "").GetHashCode();
        }

        /// <summary>
        /// Computes the hash of a text.
        /// </summary>
        /// <param name="element">node to get the hash for.</param>
        /// <param name="annotationSet">the corresponding annotation set.</param>
        /// <returns>the corresponding hash.</returns>
        internal virtual object ComputeInnerHash(TElement element, IAnnotationSetService<TElement, TAnnotation> annotationSet)
        {
            int size = annotationSet.Annotations[element].Size * 2 - 1;
            int hash = /*hashFunction(HashUtils.inSeed(t)) * */this.FPow(_Base, size);
            foreach (var c in this.HierarchicalAbstraction.Children(element))
            {
                TAnnotation cAnnotation = annotationSet.Annotations[c];
                size -= cAnnotation.Size * 2;
                hash += (int)this.GetHash(cAnnotation) * this.FPow(_Base, size);
            }

            return hash;
        }

        /// <summary>
        /// Gets the internally used <see cref="ITextualAbstractionService{TElement}"/>.
        /// </summary>
        internal virtual IHierarchicalAbstractionService<TElement> HierarchicalAbstraction
        {
            get { return this.ServiceLocator.HierarchicalAbstraction(); }
        }

        ///// <summary>
        ///// Access to the children of a node.
        ///// </summary>
        ///// <param name="node">node of interest.</param>
        ///// <returns>the node's children.</returns>
        //public virtual IEnumerable<TElement> Children(TElement node)
        //{
        //    return this.ServiceLocator.HierarchicalAbstraction().Children(node);
        //}

        ///// <summary>
        ///// Informs if a node it is leaf. 
        ///// </summary>
        ///// <param name="node">node of interest.</param>
        ///// <returns>true if the given node is a leaf, false othwerwise.</returns>
        //public virtual bool IsLeaf(TElement node)
        //{
        //    return this.ServiceLocator.HierarchicalAbstraction().IsLeaf(node);
        //}

        internal int byteArrayToInt(byte[] b)
        {
            return b[3] & 0xFF | (b[2] & 0xFF) << 8 | (b[1] & 0xFF) << 16 | (b[0] & 0xFF) << 24;
        }
    }
}
