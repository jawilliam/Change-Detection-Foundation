using Jawilliam.CDF.Approach.Annotations;
using Jawilliam.CDF.Approach.Services;
using System;
using System.Collections.Generic;

namespace Jawilliam.CDF.Approach.Criterions.Impl
{
    /// <summary>
    /// Base class for implementating <see cref="IMatcher{TElement}"/>.
    /// </summary>
    /// <typeparam name="TElement">Type of the supported elements.</typeparam>
    /// <typeparam name="TAnnotation">Type of the information to store for each element.</typeparam>
    public abstract class FingerprintMatcher<TElement, TAnnotation> : Matcher<TElement> where TAnnotation : IHashingAnnotation, new()
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="serviceLocator">the service locator to internally use.</param>
        public FingerprintMatcher(IServiceLocator serviceLocator)
        {
            this.ServiceLocator = serviceLocator ?? throw new ArgumentNullException(nameof(serviceLocator));
        }

        /// <summary>
        /// Allows to dynamically load a typed service.
        /// </summary>
        public IServiceLocator ServiceLocator { get; private set; }

        /// <summary>
        /// Gets the hash of an element.
        /// </summary>
        /// <param name="annotation">annotation of the element to get hash of.</param>
        /// <returns>the hash stored as annotation of the given element.</returns>
        protected abstract object GetHash(TAnnotation annotation);

        /// <summary>
        /// Sets the hash from the annotation of an element.
        /// </summary>
        /// <param name="annotation">annotation wherein to set the hash.</param>
        /// <param name="hash">hash to set.</param>
        protected abstract void SetHash(TAnnotation annotation, object hash);

        /// <summary>
        /// Creates and initializes the match among two element versions.
        /// </summary>
        /// <param name="original">original version.</param>
        /// <param name="modified">modified version.</param>
        /// <returns> the <see cref="MatchInfo{TElement}"/> corresponding to the given element versions.</returns>
        protected abstract MatchInfo<TElement> NewMatchInfo(TElement original, TElement modified);

        /// <summary>
        /// Discovers the candidate matches of a given node.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="originalContext">the original context (e.g., the root of the original AST).</param>
        /// <param name="modifiedContext">the modified context (e.g., the root of the modified AST).</param>
        /// <returns>candidate matches for the given node.</returns>
        public override IEnumerable<MatchInfo<TElement>> Matches(TElement original, TElement originalContext, TElement modifiedContext)
        {
            var hierarchicalAbstraction = this.ServiceLocator.HierarchicalAbstraction<TElement>();

            var oAnnotation = this.ServiceLocator.Original<TElement, TAnnotation>(original);
            foreach (var m in modifiedContext.PostOrder(hierarchicalAbstraction.Children))
            {
                var mAnnotation = this.ServiceLocator.Modified<TElement, TAnnotation>(m);
                var oHash = this.GetHash(oAnnotation);
                if (this.Compatible(original, m) && oHash != null && object.Equals(oHash, this.GetHash(mAnnotation)))
                    yield return this.NewMatchInfo(original, m);
            }
        }

        /// <summary>
        /// Determines if two comparing versions can match.
        /// </summary>
        /// <param name="original">original version.</param>
        /// <param name="modified">modified version.</param>
        /// <returns>true if they can match, false otherwise.</returns>
        protected virtual bool Compatible(TElement original, TElement modified)
        {
            var hierarchicalAbstraction = this.ServiceLocator.HierarchicalAbstraction<TElement>();
            return hierarchicalAbstraction.Label(original) == hierarchicalAbstraction.Label(modified);
        }

        /// <summary>
        /// Notifies that two comparing versions have been finally identified as a match (i.e., they are matching partners).
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="originalContext">the original context (e.g., the root of the original AST).</param>
        /// <param name="modifiedContext">the modified context (e.g., the root of the modified AST).</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        public override IEnumerable<MatchInfo<TElement>> Partners(TElement original, TElement modified, TElement originalContext, TElement modifiedContext)
        {
            var hierarchicalAbstraction = this.ServiceLocator.GetServiceOrThrowsException<IHierarchicalAbstractionService<TElement>>((int)ServiceId.HierarchicalAbstraction);
            return this.IdenticalSubtrees(hierarchicalAbstraction, original, modified, originalContext, modifiedContext);
        }
    }
}
