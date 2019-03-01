using Jawilliam.CDF.Approach.Annotations;

namespace Jawilliam.CDF.Approach.Services
{
    /// <summary>
    /// Defines the support for hashing computing.
    /// </summary>
    /// <typeparam name="TElement">Type of the hashable elements.</typeparam>
    /// <typeparam name="TAnnotation">Type of the information to store for each element.</typeparam>
    public interface IHashingService<TElement, TAnnotation> : IService where TAnnotation : new()
    {
        /// <summary>
        /// Computes the hash of a node.
        /// </summary>
        /// <param name="element">node to get the hash for.</param>
        /// <param name="annotationSet">the corresponding annotation set.</param>
        /// <returns>the corresponding hash.</returns>
        object ComputeHash(TElement element, IAnnotationSetService<TElement, TAnnotation> annotationSet);

        ///// <summary>
        ///// Computes the hash of a text.
        ///// </summary>
        ///// <param name="text">text to get the hash for.</param>
        ///// <returns>the corresponding hash.</returns>
        //object ComputeHash(string text);
    }
}
