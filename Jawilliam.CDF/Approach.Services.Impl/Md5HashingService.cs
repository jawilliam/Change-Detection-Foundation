using Jawilliam.CDF.Approach.Annotations;
using System;
using System.Numerics;
using System.Text;

namespace Jawilliam.CDF.Approach.Services.Impl
{
    /// <summary>
    /// Implements a <see cref="IHashingService{TElement}"/> based on <see cref="System.Security.Cryptography.MD5"/>
    /// </summary>
    /// <typeparam name="TElement">Type of the hashable elements.</typeparam>
    /// <typeparam name="TAnnotation">Type of the information to store for each element.</typeparam>
    public class Md5HashingService<TElement, TAnnotation> : HashingService<TElement, TAnnotation> where TAnnotation : IHierarchicalAbstractionAnnotation, new()
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="serviceLocator">the mechanism for dynamically loading a typed service.</param>
        /// <param name="getHash">how to get the hash of an element annotation.</param>
        /// <param name="setHash">how to set the hash to the annotation of an element.</param>
        /// <param name="annotationSet">the corresponding annotation set.</param>
        public Md5HashingService(IApproach<TElement> serviceLocator, Func<TAnnotation, object> getHash, Action<TAnnotation, object> setHash) : base(serviceLocator, getHash, setHash)
        {
        }

        ///// <summary>
        ///// Computes the hash of a node.
        ///// </summary>
        ///// <param name="element">node to get the hash for.</param>
        ///// <returns>the corresponding hash.</returns>
        //public virtual object ComputeHash(TElement element)
        //{
        //    var textualAbstraction = this.ServiceLocator.GetServiceOrThrowsException<ITextualAbstractionService<TElement>>((int)ServiceId.TextualAbstraction);
        //    return this.ComputeHash(textualAbstraction.FullText(element));
        //}

        /// <summary>
        /// Computes the hash of a text.
        /// </summary>
        /// <param name="text">text to get the hash for.</param>
        /// <returns>the corresponding hash.</returns>
        protected override object ComputeHash(string text)
        {
            byte[] data;
            using (var md5 = System.Security.Cryptography.MD5.Create())
            {
                data = md5.ComputeHash(Encoding.UTF8.GetBytes(text));
                return this.byteArrayToInt(data);
            }
        }
    }
}
