using Jawilliam.CDF.Approach.Annotations;
using Jawilliam.CDF.Approach.Criterions.Impl;
using Jawilliam.CDF.Approach.Criterions.Simetric;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Jawilliam.CDF.Approach.Services
{
    /// <summary>
    /// Shares extensions for loading regularly used services.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Exposes functionalities related to the matching set.
        /// </summary>
        /// <typeparam name="TElement">Type of the supported elements.</typeparam>
        /// <param name="serviceLocator">the context wherein dynamically loading any required service.</param>
        /// <param name="getServiceOrThrowsException">if true and the requested service does not exist, it throws an exception.</param>
        /// <returns>the service supporting functionalities related to the matching set.</returns>
        public static IMatchingSetService<TElement> MatchingSet<TElement>(this IServiceLocator serviceLocator, bool getServiceOrThrowsException = true)
        {
            Debug.Assert(serviceLocator != null);
            return getServiceOrThrowsException
                ? serviceLocator.GetServiceOrThrowsException<IMatchingSetService<TElement>>((int)ServiceId.MatchingSet)
                : serviceLocator.GetService<IMatchingSetService<TElement>>((int)ServiceId.MatchingSet);
        }

        /// <summary>
        /// Exposes functionalities related to the matching set.
        /// </summary>
        /// <typeparam name="TElement">Type of the supported elements.</typeparam>
        /// <param name="approach">the context wherein dynamically loading any required service.</param>
        /// <param name="getServiceOrThrowsException">if true and the requested service does not exist, it throws an exception.</param>
        /// <returns>the service supporting functionalities related to the matching set.</returns>
        public static IMatchingSetService<TElement> MatchingSet<TElement>(this IApproach<TElement> approach, bool getServiceOrThrowsException = true)
        {
            return MatchingSet<TElement>((IServiceLocator)approach, getServiceOrThrowsException);
        }

        /// <summary>
        /// Exposes functionalities for handling the textual nature of the supported elements. 
        /// </summary>
        /// <typeparam name="TElement">Type of the supported elements.</typeparam>
        /// <param name="serviceLocator">the context wherein dynamically loading any required service.</param>
        /// <param name="getServiceOrThrowsException">if true and the requested service does not exist, it throws an exception.</param>
        /// <returns>the service supporting functionalities for handling the textual nature of the supported elements. </returns>
        public static ITextualAbstractionService<TElement> TextualAbstraction<TElement>(this IServiceLocator serviceLocator, bool getServiceOrThrowsException = true)
        {
            Debug.Assert(serviceLocator != null);
            return getServiceOrThrowsException
                ? serviceLocator.GetServiceOrThrowsException<ITextualAbstractionService<TElement>>((int)ServiceId.TextualAbstraction)
                : serviceLocator.GetService<ITextualAbstractionService<TElement>>((int)ServiceId.TextualAbstraction);
        }

        /// <summary>
        /// Exposes functionalities for handling the textual nature of the supported elements. 
        /// </summary>
        /// <typeparam name="TElement">Type of the supported elements.</typeparam>
        /// <param name="approach">the context wherein dynamically loading any required service.</param>
        /// <param name="getServiceOrThrowsException">if true and the requested service does not exist, it throws an exception.</param>
        /// <returns>the service supporting functionalities for handling the textual nature of the supported elements. </returns>
        public static ITextualAbstractionService<TElement> TextualAbstraction<TElement>(this IApproach<TElement> approach, bool getServiceOrThrowsException = true)
        {
            return TextualAbstraction<TElement>((IServiceLocator)approach, getServiceOrThrowsException);
        }

        /// <summary>
        /// Exposes functionalities for handling the hierarchical nature of the supported elements. 
        /// </summary>
        /// <typeparam name="TElement">Type of the supported elements.</typeparam>
        /// <param name="serviceLocator">the context wherein dynamically loading any required service.</param>
        /// <param name="getServiceOrThrowsException">if true and the requested service does not exist, it throws an exception.</param>
        /// <returns>the service supporting functionalities for handling the hierarchical nature of the supported elements. </returns>
        public static IHierarchicalAbstractionService<TElement> HierarchicalAbstraction<TElement>(this IServiceLocator serviceLocator, bool getServiceOrThrowsException = true)
        {
            Debug.Assert(serviceLocator != null);
            return getServiceOrThrowsException
                ? serviceLocator.GetServiceOrThrowsException<IHierarchicalAbstractionService<TElement>>((int)ServiceId.HierarchicalAbstraction)
                : serviceLocator.GetService<IHierarchicalAbstractionService<TElement>>((int)ServiceId.HierarchicalAbstraction);
        }

        /// <summary>
        /// Exposes functionalities for handling the hierarchical nature of the supported elements. 
        /// </summary>
        /// <typeparam name="TElement">Type of the supported elements.</typeparam>
        /// <param name="approach">the context wherein dynamically loading any required service.</param>
        /// <param name="getServiceOrThrowsException">if true and the requested service does not exist, it throws an exception.</param>
        /// <returns>the service supporting functionalities for handling the hierarchical nature of the supported elements. </returns>
        public static IHierarchicalAbstractionService<TElement> HierarchicalAbstraction<TElement>(this IApproach<TElement> approach, bool getServiceOrThrowsException = true)
        {
            return HierarchicalAbstraction<TElement>((IServiceLocator)approach, getServiceOrThrowsException);
        }

        /// <summary>
        /// Exposes functionalities for handling the semantic nature of the supported elements. 
        /// </summary>
        /// <typeparam name="TElement">Type of the supported elements.</typeparam>
        /// <param name="serviceLocator">the context wherein dynamically loading any required service.</param>
        /// <param name="getServiceOrThrowsException">if true and the requested service does not exist, it throws an exception.</param>
        /// <returns>the service supporting functionalities for handling the semantic nature of the supported elements. </returns>
        public static ISemanticAbstractionService<TElement> SemanticAbstraction<TElement>(this IServiceLocator serviceLocator, bool getServiceOrThrowsException = true)
        {
            Debug.Assert(serviceLocator != null);
            return getServiceOrThrowsException
                ? serviceLocator.GetServiceOrThrowsException<ISemanticAbstractionService<TElement>>((int)ServiceId.SemanticAbstraction)
                : serviceLocator.GetService<ISemanticAbstractionService<TElement>>((int)ServiceId.SemanticAbstraction);
        }

        /// <summary>
        /// Exposes functionalities for handling the semantic nature of the supported elements. 
        /// </summary>
        /// <typeparam name="TElement">Type of the supported elements.</typeparam>
        /// <param name="approach">the context wherein dynamically loading any required service.</param>
        /// <param name="getServiceOrThrowsException">if true and the requested service does not exist, it throws an exception.</param>
        /// <returns>the service supporting functionalities for handling the semantic nature of the supported elements. </returns>
        public static ISemanticAbstractionService<TElement> SemanticAbstraction<TElement>(this IApproach<TElement> approach, bool getServiceOrThrowsException = true)
        {
            return SemanticAbstraction<TElement>((IServiceLocator)approach, getServiceOrThrowsException);
        }

        /// <summary>
        /// Exposes functionalities for computing full content hashes. 
        /// </summary>
        /// <typeparam name="TElement">Type of the supported elements.</typeparam>
        /// <param name="serviceLocator">the context wherein dynamically loading any required service.</param>
        /// <param name="getServiceOrThrowsException">if true and the requested service does not exist, it throws an exception.</param>
        /// <returns>the service supporting functionalities for computing full content hashes.</returns>
        public static IHashingService<TElement, TAnnotation> FullContentHasher<TElement, TAnnotation>(this IServiceLocator serviceLocator, bool getServiceOrThrowsException = true) where TAnnotation : new()
        {
            Debug.Assert(serviceLocator != null);
            return getServiceOrThrowsException
                ? serviceLocator.GetServiceOrThrowsException<IHashingService<TElement, TAnnotation>>((int)ServiceId.FullContentHasher)
                : serviceLocator.GetService<IHashingService<TElement, TAnnotation>>((int)ServiceId.FullContentHasher);
        }

        /// <summary>
        /// Exposes functionalities for computing full content hashes. 
        /// </summary>
        /// <typeparam name="TElement">Type of the supported elements.</typeparam>
        /// <param name="approach">the context wherein dynamically loading any required service.</param>
        /// <param name="getServiceOrThrowsException">if true and the requested service does not exist, it throws an exception.</param>
        /// <returns>the service supporting functionalities for computing full content hashes.</returns>
        public static IHashingService<TElement, TAnnotation> FullContentHasher<TElement, TAnnotation>(this IApproach<TElement> approach, bool getServiceOrThrowsException = true) where TAnnotation : new()
        {
            return FullContentHasher<TElement, TAnnotation>((IServiceLocator)approach, getServiceOrThrowsException);
        }

        /// <summary>
        /// Exposes functionalities for computing essential content hashes. 
        /// </summary>
        /// <typeparam name="TElement">Type of the supported elements.</typeparam>
        /// <param name="serviceLocator">the context wherein dynamically loading any required service.</param>
        /// <param name="getServiceOrThrowsException">if true and the requested service does not exist, it throws an exception.</param>
        /// <returns>the service supporting functionalities for computing essential content hashes.</returns>
        public static IHashingService<TElement, TAnnotation> EssentialContentHasher<TElement, TAnnotation>(this IServiceLocator serviceLocator, bool getServiceOrThrowsException = true) where TAnnotation : new()
        {
            Debug.Assert(serviceLocator != null);
            return getServiceOrThrowsException 
                ? serviceLocator.GetServiceOrThrowsException<IHashingService<TElement, TAnnotation>>((int)ServiceId.EssentialContentHasher)
                : serviceLocator.GetService<IHashingService<TElement, TAnnotation>>((int)ServiceId.EssentialContentHasher);
        }

        /// <summary>
        /// Exposes functionalities for computing essential content hashes. 
        /// </summary>
        /// <typeparam name="TElement">Type of the supported elements.</typeparam>
        /// <param name="approach">the context wherein dynamically loading any required service.</param>
        /// <param name="getServiceOrThrowsException">if true and the requested service does not exist, it throws an exception.</param>
        /// <returns>the service supporting functionalities for computing essential content hashes.</returns>
        public static IHashingService<TElement, TAnnotation> EssentialContentHasher<TElement, TAnnotation>(this IApproach<TElement> approach, bool getServiceOrThrowsException = true) where TAnnotation : new()
        {
            return EssentialContentHasher<TElement, TAnnotation>((IServiceLocator)approach, getServiceOrThrowsException);
        }

        /// <summary>
        /// Exposes functionalities to manage edit scripts. 
        /// </summary>
        /// <typeparam name="TElement">Type of the supported elements.</typeparam>
        /// <param name="serviceLocator">the context wherein dynamically loading any required service.</param>
        /// <param name="getServiceOrThrowsException">if true and the requested service does not exist, it throws an exception.</param>
        /// <returns>the service supporting functionalities to manage edit scripts.</returns>
        public static IEditScriptService<TElement> EditScript<TElement>(this IServiceLocator serviceLocator, bool getServiceOrThrowsException = true)
        {
            Debug.Assert(serviceLocator != null);
            return getServiceOrThrowsException
                ? serviceLocator.GetServiceOrThrowsException<IEditScriptService<TElement>>((int)ServiceId.EditScript)
                : serviceLocator.GetService<IEditScriptService<TElement>>((int)ServiceId.EditScript);
        }

        /// <summary>
        /// Exposes functionalities to manage edit scripts. 
        /// </summary>
        /// <typeparam name="TElement">Type of the supported elements.</typeparam>
        /// <param name="approach">the context wherein dynamically loading any required service.</param>
        /// <param name="getServiceOrThrowsException">if true and the requested service does not exist, it throws an exception.</param>
        /// <returns>the service supporting functionalities to manage edit scripts.</returns>
        public static IEditScriptService<TElement> EditScript<TElement>(this IApproach<TElement> approach, bool getServiceOrThrowsException = true)
        {
            return EditScript<TElement>((IServiceLocator)approach, getServiceOrThrowsException);
        }

        public static bool MatchEquality<TElement, TAnnotation>(this IServiceLocator approach, TElement first, TElement second) where TAnnotation : IMatchingAnnotation<TElement>, new()
        {
            Debug.Assert(first != null && second != null);
            Debug.Assert(approach.Originals<TElement, TAnnotation>().Annotations.ContainsKey(first) || approach.Modifieds<TElement, TAnnotation>().Annotations.ContainsKey(first));
            Debug.Assert(approach.Originals<TElement, TAnnotation>().Annotations.ContainsKey(second) || approach.Modifieds<TElement, TAnnotation>().Annotations.ContainsKey(second));

            if (object.Equals(first, second))
                return true;

            if (approach.Originals<TElement, TAnnotation>().Annotations.ContainsKey(first))
            {
                return (approach.Original<TElement, TAnnotation>(first).Candidates?.Any(c => object.Equals(c.Modified, second)) ?? false);
            }

            if (approach.Modifieds<TElement, TAnnotation>().Annotations.ContainsKey(first))
            {
                return (approach.Modified<TElement, TAnnotation>(first).Candidates?.Any(c => object.Equals(c.Original, second)) ?? false);
            }

            return false;
        }

        public static IEnumerable<TElement> _TermSelector<TElement, TAnnotation>(this IServiceLocator serviceLocator, IEnumerable<TElement> originals, IEnumerable<TElement> modifieds, IEqualityComparer<TElement> comparer)
            where TAnnotation : IMatchingAnnotation<TElement>, new()
        {
            Debug.Assert(originals != null && modifieds != null);

            var matched = originals.Where(o =>
            {
                var oAnnotation = serviceLocator.Original<TElement, TAnnotation>(o);
                return oAnnotation.Candidates.Any(c => modifieds.Any(ss => object.Equals(c.Modified, ss)));
            });
            foreach (var om in matched)
            {
                yield return om;
            }

            var unmatchedOriginals = originals.Where(o =>
            {
                var oAnnotation = serviceLocator.Original<TElement, TAnnotation>(o);
                return !oAnnotation.Candidates.Any(c => modifieds.Any(ss => object.Equals(c.Modified, ss)));
            });
            foreach (var o in unmatchedOriginals)
            {
                yield return o;
            }

            var unmatchedModifieds = modifieds.Where(o =>
            {
                var mAnnotation = serviceLocator.Modified<TElement, TAnnotation>(o);
                return !mAnnotation.Candidates.Any(c => originals.Any(ss => object.Equals(c.Original, ss)));
            });
            foreach (var m in unmatchedModifieds)
            {
                yield return m;
            }
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
        public static IEnumerable<TElement> _ByTermExistence<TElement, TAnnotation>(this IServiceLocator serviceLocator, TElement[] firstSequence, TElement[] secondSequence, 
            IEqualityComparer<TElement> comparer, out double[] firstResult, out double[] secondResult, 
            Func<IEnumerable<TElement>, IEnumerable<TElement>, IEqualityComparer<TElement>, IEnumerable<TElement>> termSelector = null)
        where TAnnotation : IMatchingAnnotation<TElement>, new()
        {
            return VectorComponents.ByTermExistence(firstSequence, secondSequence, 
                new MatchEqualityComparer<TElement, TAnnotation, IServiceLocator>(serviceLocator), 
                out firstResult, out secondResult, serviceLocator._TermSelector<TElement, TAnnotation>);
        }
    }
}
