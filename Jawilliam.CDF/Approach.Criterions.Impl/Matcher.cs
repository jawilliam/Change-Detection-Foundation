using Jawilliam.CDF.Approach.Annotations;
using Jawilliam.CDF.Approach.Criterions.Simetric;
using Jawilliam.CDF.Approach.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Jawilliam.CDF.Approach.Criterions.Impl
{
    /// <summary>
    /// Base class for implementating <see cref="IMatcher{TElement}"/>.
    /// </summary>
    /// <typeparam name="TElement">Type of the supported elements.</typeparam>
    public abstract class Matcher<TElement, TServiceLocator> : IMatcher<TElement> where TServiceLocator : IServiceLocator
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="serviceLocator">the service locator to internally use.</param>
        public Matcher(TServiceLocator serviceLocator)
        {
            this.ServiceLocator = !object.Equals(serviceLocator, default(TServiceLocator)) ? serviceLocator : throw new ArgumentNullException(nameof(serviceLocator));
        }

        /// <summary>
        /// Allows to dynamically load a typed service.
        /// </summary>
        public TServiceLocator ServiceLocator { get; private set; }

        /// <summary>
        /// Discovers the candidate matches of a given node.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="originalContext">the original context (e.g., the root of the original AST).</param>
        /// <param name="modifiedContext">the modified context (e.g., the root of the modified AST).</param>
        /// <returns>candidate matches for the given node.</returns>
        public abstract IEnumerable<MatchInfo<TElement>> Matches(TElement original, TElement originalContext, TElement modifiedContext);

        /// <summary>
        /// Tries to identify a best match among multiple candidate matches. 
        /// </summary>
        /// <param name="candidates">candidate matches.</param>
        /// <param name="originalContext">the original context (e.g., the root of the original AST).</param>
        /// <param name="modifiedContext">the modified context (e.g., the root of the modified AST).</param>
        /// <returns>the best match if it was possible to identify some one, null otherwise.</returns>
        public virtual MatchInfo<TElement> TieBreak(IEnumerable<MatchInfo<TElement>> candidates, TElement originalContext, TElement modifiedContext)
        {
            return candidates?.Count() == 1 ? candidates.Single() : null;
        }

        /// <summary>
        /// Notifies that two comparing versions have been finally identified as a match (i.e., they are matching partners).
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="originalContext">the original context (e.g., the root of the original AST).</param>
        /// <param name="modifiedContext">the modified context (e.g., the root of the modified AST).</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        public virtual IEnumerable<MatchInfo<TElement>> Partners(TElement original, TElement modified, TElement originalContext, TElement modifiedContext)
        {
            yield break;
        }

        /// <summary>
        /// Notifies that two identical versions have been finally identified as a match (i.e., they are matching partners).
        /// </summary>
        /// <param name="hierarchicalAbstraction">the hierarchical abstractions service.</param>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="originalContext">the original context (e.g., the root of the original AST).</param>
        /// <param name="modifiedContext">the modified context (e.g., the root of the modified AST).</param>
        /// <returns>Matches inferable after taking for granted the match among the given versions.</returns>
        protected virtual IEnumerable<MatchInfo<TElement>> IdenticalSubtrees(IHierarchicalAbstractionService<TElement> hierarchicalAbstraction, TElement original, TElement modified, TElement originalContext, TElement modifiedContext)
        {
            var oChildren = hierarchicalAbstraction.Children(original).ToArray();
            var mChildren = hierarchicalAbstraction.Children(modified).ToArray();
            for (int i = 0; i < oChildren.Count() ; i++)
            {
                var oChild = oChildren[i];

                if (i < mChildren.Length)
                {
                    var mChild = mChildren[i];

                    yield return new MatchInfo<TElement>((int)MatchingCriterionIds.PairwiseIdenticalSubtree) { Original = oChild, Modified = mChild };
                    foreach (var pairwiseMatch in this.IdenticalSubtrees(hierarchicalAbstraction, oChild, mChild, originalContext, modifiedContext) ?? new MatchInfo<TElement>[0])
                    {
                        yield return pairwiseMatch;
                    }
                }
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

        internal IEnumerable<TElement> _TermSelector<TAnnotation>(IEnumerable<TElement> originals, IEnumerable<TElement> modifieds, IEqualityComparer<TElement> comparer) where TAnnotation : IMatchingAnnotation<TElement>, new()
        {
            Debug.Assert(originals != null && modifieds != null);

            var matched = originals.Where(o =>
            {
                var oAnnotation = this.ServiceLocator.Original<TElement, TAnnotation>(o);
                return oAnnotation.Candidates.Any(c => modifieds.Any(ss => object.Equals(c.Modified, ss)));
            });
            foreach (var om in matched)
            {
                yield return om;
            }

            var unmatchedOriginals = originals.Where(o =>
            {
                var oAnnotation = this.ServiceLocator.Original<TElement, TAnnotation>(o);
                return !oAnnotation.Candidates.Any(c => modifieds.Any(ss => object.Equals(c.Modified, ss)));
            });
            foreach (var o in unmatchedOriginals)
            {
                yield return o;
            }

            var unmatchedModifieds = modifieds.Where(o =>
            {
                var mAnnotation = this.ServiceLocator.Modified<TElement, TAnnotation>(o);
                return !mAnnotation.Candidates.Any(c => originals.Any(ss => object.Equals(c.Original, ss)));
            });
            foreach (var m in unmatchedModifieds)
            {
                yield return m;
            }
        }

        internal bool _AreEqual<TAnnotation>(TElement first, TElement second) where TAnnotation : IMatchingAnnotation<TElement>, new()
        {
            Debug.Assert(first != null && second != null);
            Debug.Assert(this.ServiceLocator.Originals<TElement, TAnnotation>().Annotations.ContainsKey(first) || this.ServiceLocator.Modifieds<TElement, TAnnotation>().Annotations.ContainsKey(first));
            Debug.Assert(this.ServiceLocator.Originals<TElement, TAnnotation>().Annotations.ContainsKey(second) || this.ServiceLocator.Modifieds<TElement, TAnnotation>().Annotations.ContainsKey(second));

            if (object.Equals(first, second))
                return true;

            if (this.ServiceLocator.Originals<TElement, TAnnotation>().Annotations.ContainsKey(first))
            {
                return (this.ServiceLocator.Original<TElement, TAnnotation>(first).Candidates?.Any(c => object.Equals(c.Modified, second)) ?? false);
            }

            if (this.ServiceLocator.Modifieds<TElement, TAnnotation>().Annotations.ContainsKey(first))
            {
                return (this.ServiceLocator.Modified<TElement, TAnnotation>(first).Candidates?.Any(c => object.Equals(c.Original, second)) ?? false);
            }

            return false;
        }

        /// <summary>
        /// Computes the existence of each unique term.
        /// </summary>
        /// <param name="firstSequence">First sequence where to compute the components over.</param>
        /// <param name="secondSequence">First sequence where to compute the components over.</param>
        /// <param name="comparer">the logic to support comparisons of objects for equality.</param>
        /// <param name="firstResult">Returns the computed components related to the first sequence.</param>
        /// <param name="secondResult">Returns the computed components related to the second sequence.</param>
        /// <param name="termSelector">Function to compute the terms.</param>
        /// <returns>The unique terms that the existences was computed for.</returns>
        internal virtual IEnumerable<TElement> ByTermExistence<TAnnotation>(TElement[] firstSequence, TElement[] secondSequence, IEqualityComparer<TElement> comparer, out double[] firstResult, out double[] secondResult, Func<IEnumerable<TElement>, IEnumerable<TElement>, IEqualityComparer<TElement>, IEnumerable<TElement>> termSelector = null)
        where TAnnotation : IMatchingAnnotation<TElement>, new()
        {
            return VectorComponents.ByTermExistence(firstSequence, secondSequence, new EqualityComparer<TAnnotation>(this), out firstResult, out secondResult, this._TermSelector<TAnnotation>);
        }

        /// <summary>
        /// Defines methods to support the comparison of objects for equality, based on <see cref="Matcher{TElement, TServiceLocator}._AreEqual{TAnnotation}(TElement, TElement)"/>.
        /// </summary>
        internal protected class EqualityComparer<TAnnotation> : IEqualityComparer<TElement> where TAnnotation : IMatchingAnnotation<TElement>, new()
        {
            /// <summary>
            /// Initializes the instance.
            /// </summary>
            /// <param name="baseSimetric"></param>
            public EqualityComparer(Matcher<TElement, TServiceLocator> baseSimetric)
            {
                this.Source = baseSimetric ?? throw new ArgumentNullException(nameof(baseSimetric));
            }

            /// <summary>
            /// References the corresponding <see cref="Matcher{TElement, TServiceLocator}"/>.
            /// </summary>
            public virtual Matcher<TElement, TServiceLocator> Source { get; private set; }

            /// <summary>
            /// Determines whether the specified objects are equal.
            /// </summary>
            /// <param name="x">The first object of type T to compare.</param>
            /// <param name="y">The second object of type T to compare.</param>
            /// <returns>true if the specified objects are equal; otherwise, false.</returns>
            public virtual bool Equals(TElement x, TElement y)
            {
                return this.Source._AreEqual<TAnnotation>(x, y);
            }

            /// <summary>
            /// Returns a hash code for the specified object.
            /// </summary>
            /// <param name="obj">The Object for which a hash code is to be returned.</param>
            /// <returns>A hash code for the specified object.</returns>
            public int GetHashCode(TElement obj)
            {
                return obj == null ? 0 : obj.GetHashCode();
            }
        }
    }
}
