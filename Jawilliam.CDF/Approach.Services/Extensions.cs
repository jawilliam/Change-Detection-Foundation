using System.Diagnostics;

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
    }
}
