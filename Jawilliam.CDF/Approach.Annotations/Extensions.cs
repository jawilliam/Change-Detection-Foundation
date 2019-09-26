using Jawilliam.CDF.Approach.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jawilliam.CDF.Approach.Annotations
{
    /// <summary>
    /// Shares extensions for loading regularly used annotations.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Exposes the annotations set of the original elements. 
        /// </summary>
        /// <typeparam name="TElement">Type of the supported elements.</typeparam>
        /// <typeparam name="TAnnotation">Type of the information to store for each element.</typeparam>
        /// <param name="serviceLocator">the context wherein dynamically loading any required service.</param>
        /// <returns>the service exposing the annotations set of the original elements. </returns>
        public static IAnnotationSetService<TElement, TAnnotation> Originals<TElement, TAnnotation>(this IServiceLocator serviceLocator) where TAnnotation : new()
        {
            Debug.Assert(serviceLocator != null);
            return serviceLocator.GetServiceOrThrowsException<IAnnotationSetService<TElement, TAnnotation>>((int)ServiceId.OriginalAnnotationSet);
        }

        /// <summary>
        /// Exposes the annotations set of the modified elements. 
        /// </summary>
        /// <typeparam name="TElement">Type of the supported elements.</typeparam>
        /// <typeparam name="TAnnotation">Type of the information to store for each element.</typeparam>
        /// <param name="serviceLocator">the context wherein dynamically loading any required service.</param>
        /// <returns>the service exposing the annotations set of the modified elements. </returns>
        public static IAnnotationSetService<TElement, TAnnotation> Modifieds<TElement, TAnnotation>(this IServiceLocator serviceLocator) where TAnnotation : new()
        {
            Debug.Assert(serviceLocator != null);
            return serviceLocator.GetServiceOrThrowsException<IAnnotationSetService<TElement, TAnnotation>>((int)ServiceId.ModifiedAnnotationSet);
        }

        /// <summary>
        /// Exposes the annotations set of the modified elements. 
        /// </summary>
        /// <typeparam name="TElement">Type of the supported elements.</typeparam>
        /// <typeparam name="TAnnotation">Type of the information to store for each element.</typeparam>
        /// <param name="serviceLocator">the context wherein dynamically loading any required service.</param>
        /// <returns>the service exposing the annotations set of the modified elements. </returns>
        public static IAnnotationSetService<TElement, TAnnotation> AnnotationSet<TElement, TAnnotation>(this IServiceLocator serviceLocator, TElement element) where TAnnotation : new()
        {
            if(serviceLocator == null)
                throw new ArgumentNullException(nameof(serviceLocator));
            if (element == null)
                throw new ArgumentNullException(nameof(element));

            var originals = serviceLocator.Originals<TElement, TAnnotation>();
            var modifieds = serviceLocator.Modifieds<TElement, TAnnotation>();

            if (originals.Annotations.ContainsKey(element) && !modifieds.Annotations.ContainsKey(element))
                return originals;

            if (!originals.Annotations.ContainsKey(element) && modifieds.Annotations.ContainsKey(element))
                return modifieds;

            if (originals.Annotations.ContainsKey(element) && modifieds.Annotations.ContainsKey(element))
                return modifieds;

            throw new KeyNotFoundException($"original and/or modified element not found: {element}");
        }

        /// <summary>
        /// Accesses the annotations of an original element. 
        /// </summary>
        /// <typeparam name="TElement">Type of the supported elements.</typeparam>
        /// <typeparam name="TAnnotation">Type of the information to store for each element.</typeparam>
        /// <param name="serviceLocator">the context wherein dynamically loading any required service.</param>
        /// <param name="original">original element.</param>
        /// <returns>the annotations of the given original element.</returns>
        public static TAnnotation Original<TElement, TAnnotation>(this IServiceLocator serviceLocator, TElement original) where TAnnotation : new()
        {
            if (!Originals<TElement, TAnnotation>(serviceLocator).Annotations.ContainsKey(original))
                throw new KeyNotFoundException($"original not found: {original}");

            //Debug.Assert(original != null && Originals<TElement, TAnnotation>(serviceLocator).Annotations.ContainsKey(original));
            return Originals<TElement, TAnnotation>(serviceLocator).Annotations[original];
        }

        /// <summary>
        /// Accesses the annotations of an modified element. 
        /// </summary>
        /// <typeparam name="TElement">Type of the supported elements.</typeparam>
        /// <typeparam name="TAnnotation">Type of the information to store for each element.</typeparam>
        /// <param name="serviceLocator">the context wherein dynamically loading any required service.</param>
        /// <param name="modified">modified element.</param>
        /// <returns>the annotations of the given modified element.</returns>
        public static TAnnotation Modified<TElement, TAnnotation>(this IServiceLocator serviceLocator, TElement modified) where TAnnotation : new()
        {
            if (!Modifieds<TElement, TAnnotation>(serviceLocator).Annotations.ContainsKey(modified))
                throw new KeyNotFoundException($"modified not found: {modified}");

            //Debug.Assert(modified != null && Modifieds<TElement, TAnnotation>(serviceLocator).Annotations.ContainsKey(modified));
            return Modifieds<TElement, TAnnotation>(serviceLocator).Annotations[modified];
        }

        /// <summary>
        /// Gets the full content hash of an element annotation.
        /// </summary>
        /// <typeparam name="TAnnotation">Type of the information to store for each element.</typeparam>
        /// <returns>the full content hash of the given element annotation.</returns>
        public static object GetFullContentHash<TAnnotation>(TAnnotation annotation) where TAnnotation : IHashingAnnotation, new()
        {
            return annotation.FullHash;
        }

        /// <summary>
        /// Sets the full content hash to an element annotation.
        /// </summary>
        /// <typeparam name="TAnnotation">Type of the information to store for each element.</typeparam>
        public static void SetFullContentHash<TAnnotation>(TAnnotation annotation, object hash) where TAnnotation : IHashingAnnotation, new()
        {
            annotation.FullHash = hash;
        }

        /// <summary>
        /// Gets the essential content hash of an element annotation.
        /// </summary>
        /// <typeparam name="TAnnotation">Type of the information to store for each element.</typeparam>
        /// <returns>the essential content hash of the given element annotation.</returns>
        public static object GetEssentialContentHash<TAnnotation>(TAnnotation annotation) where TAnnotation : IHashingAnnotation, new()
        {
            return annotation.EssentialHash;
        }

        /// <summary>
        /// Sets the essential content hash to an element annotation.
        /// </summary>
        /// <typeparam name="TAnnotation">Type of the information to store for each element.</typeparam>
        public static void SetEssentialContentHash<TAnnotation>(TAnnotation annotation, object hash) where TAnnotation : IHashingAnnotation, new()
        {
            annotation.EssentialHash = hash;
        }

        /// <summary>
        /// Gets the matching partner of the extended element or null if it does not have anyone yet. 
        /// </summary>
        public static TElement Partner<TElement, TAnnotation>(this TAnnotation source, bool original) where TAnnotation : IMatchingAnnotation<TElement>, IElementAnnotation<TElement>
        {
            if (source.Match == null)
                return default(TElement);

            return /*object.Equals(source.Element, source.Match.Original)*/ original ? source.Match.Modified : source.Match.Original;
        }
    }
}
