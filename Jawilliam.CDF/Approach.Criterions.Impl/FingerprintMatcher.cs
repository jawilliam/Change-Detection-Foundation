using Jawilliam.CDF.Approach.Annotations;
using Jawilliam.CDF.Approach.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Jawilliam.CDF.Approach.Criterions.Impl
{
    /// <summary>
    /// Base class for implementating <see cref="IMatcher{TElement}"/>.
    /// </summary>
    /// <typeparam name="TElement">Type of the supported elements.</typeparam>
    /// <typeparam name="TAnnotation">Type of the information to store for each element.</typeparam>
    public class FingerprintMatcher<TElement, TAnnotation> : Matcher<TElement, TAnnotation, IServiceLocator>, IMatcher<TElement> where TAnnotation : IHashingAnnotation, new()
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="serviceLocator">the service locator to internally use.</param>
        /// <param name="getHash">gets the logic to read the hash of an element.</param>
        /// <param name="setHash">sets the logic to write the hash of an element.</param>
        /// <param name="newMatchInfo">gets the logic to create and initialize the match associated to two element versions.</param>
        public FingerprintMatcher(IServiceLocator serviceLocator, GetHashDelegate getHash, SetHashDelegate setHash, NewMatchInfoDelegate newMatchInfo) : base(serviceLocator)
        {
            this.GetHash = getHash ?? throw new ArgumentNullException(nameof(getHash));
            this.SetHash = setHash ?? throw new ArgumentNullException(nameof(setHash));
            this.NewMatchInfo = newMatchInfo ?? throw new ArgumentNullException(nameof(newMatchInfo));
        }

        /// <summary>
        /// Gets the logic to read the hash of an element.
        /// </summary>
        public GetHashDelegate GetHash { get; set; }

        /// <summary>
        /// Sets the logic to write the hash of an element.
        /// </summary>
        public SetHashDelegate SetHash { get; set; }

        /// <summary>
        /// Gets the logic to create and initialize the match associated to two element versions.
        /// </summary>
        public NewMatchInfoDelegate NewMatchInfo { get; set; }

        /// <summary>
        /// Discovers the candidate matches of a given node.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>candidate matches for the given node.</returns>
        public override IEnumerable<MatchInfo<TElement>> Matches(TElement original, MatchingContext<TElement> context)
        {
            var hierarchicalAbstraction = this.ServiceLocator.HierarchicalAbstraction<TElement, TAnnotation>();
            var matchingSet = this.ServiceLocator.MatchingSet<TElement>();

            var oAnnotation = this.ServiceLocator.Original<TElement, TAnnotation>(original);
            foreach (var m in context.LScope.Modified
                              .PostOrder(o1 => hierarchicalAbstraction
                              .Children(o1, this.ServiceLocator.Modifieds<TElement, TAnnotation>(), true))
                              .Where(matchingSet.Modifieds.Unmatched))
            {
                var mAnnotation = this.ServiceLocator.Modified<TElement, TAnnotation>(m);
                var oHash = this.GetHash(oAnnotation);
                if (this.Compatible(original, m) && oHash != null && object.Equals(oHash, this.GetHash(mAnnotation)))
                    yield return this.NewMatchInfo(original, m);
            }
        }

        /// <summary>
        /// Tries to identify a best match among multiple candidate matches. 
        /// </summary>
        /// <param name="candidates">candidate matches.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>the best match if it was possible to identify some one, null otherwise.</returns>
        public override MatchInfo<TElement> TieBreak(IEnumerable<MatchInfo<TElement>> candidates, MatchingContext<TElement> context)
        {
            if (candidates?.Count() == 1)
            {
                var candidate = candidates.Single();
                var hierarchicalAbstraction = this.ServiceLocator.HierarchicalAbstraction<TElement, TAnnotation>();

                var originals = this.ServiceLocator.Originals<TElement, TAnnotation>();
                var modifieds = this.ServiceLocator.Modifieds<TElement, TAnnotation>();

                var oAnnotation = originals.Annotations[candidate.Original];
                var mAnnotation = modifieds.Annotations[candidate.Modified];

                if (!context.LScope.Original.PostOrder(o1 => hierarchicalAbstraction.Children(o1, originals))
                        .Any(n => object.Equals(n, candidate.Original) &&
                                  object.Equals(this.GetHash(this.ServiceLocator.Original<TElement, TAnnotation>(n)), this.GetHash(oAnnotation))) &&
                    !context.LScope.Modified.PostOrder(o1 => hierarchicalAbstraction.Children(o1, modifieds))
                        .Any(n => object.Equals(n, candidate.Modified) &&
                                  object.Equals(this.GetHash(this.ServiceLocator.Modified<TElement, TAnnotation>(n)), this.GetHash(mAnnotation))))
                    return candidate;
            }
            return null;
        }

        /// <summary>
        /// Notifies that two comparing versions have been finally identified as a match (i.e., they are matching partners).
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="context">the context wherein certain matching criterion is currently running.</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        public override IEnumerable<MatchInfo<TElement>> Partners(TElement original, TElement modified, MatchingContext<TElement> context)
        {
            return this.IdenticalSubtreePartners(original, modified, context);
        }

        ///// <summary>
        ///// Discovers the candidate matches of a given node.
        ///// </summary>
        ///// <param name="original">the original version.</param>
        ///// <param name="originalContext">the original context (e.g., the root of the original AST).</param>
        ///// <param name="modifiedContext">the modified context (e.g., the root of the modified AST).</param>
        ///// <returns>candidate matches for the given node.</returns>
        //public override IEnumerable<MatchInfo<TElement>> Matches(TElement original, TElement originalContext, TElement modifiedContext)
        //{
        //    var hierarchicalAbstraction = this.ServiceLocator.HierarchicalAbstraction<TElement>();
        //    var matchingSet = this.ServiceLocator.MatchingSet<TElement>();

        //    var oAnnotation = this.ServiceLocator.Original<TElement, TAnnotation>(original);
        //    foreach (var m in modifiedContext.PostOrder(hierarchicalAbstraction.Children).Where(matchingSet.Modifieds.Unmatched))
        //    {
        //        var mAnnotation = this.ServiceLocator.Modified<TElement, TAnnotation>(m);
        //        var oHash = this.GetHash(oAnnotation);
        //        if (this.Compatible(original, m) && oHash != null && object.Equals(oHash, this.GetHash(mAnnotation)))
        //            yield return this.NewMatchInfo(original, m);
        //    }
        //}

        ///// <summary>
        ///// Tries to identify a best match among multiple candidate matches. 
        ///// </summary>
        ///// <param name="candidates">candidate matches.</param>
        ///// <param name="originalContext">the original context (e.g., the root of the original AST).</param>
        ///// <param name="modifiedContext">the modified context (e.g., the root of the modified AST).</param>
        ///// <returns>the best match if it was possible to identify some one, null otherwise.</returns>
        //public override MatchInfo<TElement> TieBreak(IEnumerable<MatchInfo<TElement>> candidates, TElement originalContext, TElement modifiedContext)
        //{
        //    if (candidates?.Count() == 1)
        //    {
        //        var candidate = candidates.Single();
        //        var hierarchicalAbstraction = this.ServiceLocator.HierarchicalAbstraction<TElement>();
        //        var oAnnotation = this.ServiceLocator.Original<TElement, TAnnotation>(candidate.Original);
        //        var mAnnotation = this.ServiceLocator.Modified<TElement, TAnnotation>(candidate.Modified);

        //        if (!originalContext.PostOrder(hierarchicalAbstraction.Children)
        //                .Any(n => object.Equals(n, candidate.Original) &&
        //                          object.Equals(this.GetHash(this.ServiceLocator.Original<TElement, TAnnotation>(n)), this.GetHash(oAnnotation))) &&
        //            !modifiedContext.PostOrder(hierarchicalAbstraction.Children)
        //                .Any(n => object.Equals(n, candidate.Modified) &&
        //                          object.Equals(this.GetHash(this.ServiceLocator.Modified<TElement, TAnnotation>(n)), this.GetHash(mAnnotation))))
        //            return candidate;
        //    }
        //    return null;
        //}

        ///// <summary>
        ///// Notifies that two comparing versions have been finally identified as a match (i.e., they are matching partners).
        ///// </summary>
        ///// <param name="original">the original version.</param>
        ///// <param name="modified">the modified version.</param>
        ///// <param name="originalContext">the original context (e.g., the root of the original AST).</param>
        ///// <param name="modifiedContext">the modified context (e.g., the root of the modified AST).</param>
        ///// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        //public override IEnumerable<MatchInfo<TElement>> Partners(TElement original, TElement modified, TElement originalContext, TElement modifiedContext)
        //{
        //    return this.IdenticalSubtreePartners(original, modified, originalContext, modifiedContext);
        //}

        /// <summary>
        /// Gets the hash of an element.
        /// </summary>
        /// <param name="annotation">annotation of the element to get hash of.</param>
        /// <returns>the hash stored as annotation of the given element.</returns>
        public delegate object GetHashDelegate(TAnnotation annotation);

        /// <summary>
        /// Sets the hash from the annotation of an element.
        /// </summary>
        /// <param name="annotation">annotation wherein to set the hash.</param>
        /// <param name="hash">hash to set.</param>
        public delegate void SetHashDelegate(TAnnotation annotation, object hash);

        /// <summary>
        /// Creates and initializes the match among two element versions.
        /// </summary>
        /// <param name="original">original version.</param>
        /// <param name="modified">modified version.</param>
        /// <returns> the <see cref="MatchInfo{TElement}"/> corresponding to the given element versions.</returns>
        public delegate MatchInfo<TElement> NewMatchInfoDelegate(TElement original, TElement modified);
    }
}
