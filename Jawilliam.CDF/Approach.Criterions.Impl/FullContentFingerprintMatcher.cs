using Jawilliam.CDF.Approach.Annotations;
using Jawilliam.CDF.Approach.Services;

namespace Jawilliam.CDF.Approach.Criterions.Impl
{
    /// <summary>
    /// Implements a <see cref="IMatcher{TElement}"/> based on the full content hash.
    /// </summary>
    /// <typeparam name="TElement">Type of the supported elements.</typeparam>
    /// <typeparam name="TAnnotation">Type of the information to store for each element.</typeparam>
    public class FullContentFingerprintMatcher<TElement, TAnnotation> : FingerprintMatcher<TElement, TAnnotation> where TAnnotation : IHashingAnnotation, new()
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="serviceLocator">the service locator to internally use.</param>
        public FullContentFingerprintMatcher(IServiceLocator serviceLocator) : base(serviceLocator)
        {
        }

        /// <summary>
        /// Gets the hash of an element.
        /// </summary>
        /// <param name="annotation">annotation of the element to get hash of.</param>
        /// <returns>the hash stored as annotation of the given element.</returns>
        protected override object GetHash(TAnnotation annotation)
        {
            return annotation.FullHash;
        }

        /// <summary>
        /// Sets the hash from the annotation of an element.
        /// </summary>
        /// <param name="annotation">annotation wherein to set the hash.</param>
        /// <param name="hash">hash to set.</param>
        protected override void SetHash(TAnnotation annotation, object hash)
        {
            annotation.FullHash = hash;
        }

        /// <summary>
        /// Creates and initializes the match among two element versions.
        /// </summary>
        /// <param name="original">original version.</param>
        /// <param name="modified">modified version.</param>
        /// <returns> the <see cref="MatchInfo{TElement}"/> corresponding to the given element versions.</returns>
        protected override MatchInfo<TElement> NewMatchInfo(TElement original, TElement modified)
        {
            return new MatchInfo<TElement>((int)MatchInfoId.IdenticalFullHash) { Original = original, Modified = modified };
        }
    }
}
