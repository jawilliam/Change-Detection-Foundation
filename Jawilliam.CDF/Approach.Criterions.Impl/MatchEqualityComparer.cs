using Jawilliam.CDF.Approach.Annotations;
using Jawilliam.CDF.Approach.Services;
using System;
using System.Collections.Generic;

namespace Jawilliam.CDF.Approach.Criterions.Impl
{
    /// <summary>
    /// Defines methods to support the comparison of objects for equality, based on <see cref="Services.Extensions.MatchEquality{TElement, TAnnotation}(IServiceLocator, TElement, TElement)"/>.
    /// </summary> 
    /// <typeparam name="TElement">Type of the supported elements.</typeparam>
    /// <typeparam name="TAnnotation">Type of the information to store for each element.</typeparam>
    /// <typeparam name="TServiceLocator">the mechanism for dynamically loading a typed service.</typeparam>
    public class MatchEqualityComparer<TElement, TAnnotation, TServiceLocator> : IEqualityComparer<TElement> 
        where TAnnotation : IMatchingAnnotation<TElement>, new()
        where TServiceLocator : IServiceLocator
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="serviceLocator">the mechanism for dynamically loading a typed service.</param>
        public MatchEqualityComparer(TServiceLocator serviceLocator)
        {
            this.ServiceLocator = serviceLocator != null ? serviceLocator : throw new ArgumentNullException(nameof(serviceLocator));
        }

        /// <summary>
        /// Mechanism for dynamically loading a typed service.
        /// </summary>
        public virtual TServiceLocator ServiceLocator { get; private set; }

        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <param name="x">The first object of type T to compare.</param>
        /// <param name="y">The second object of type T to compare.</param>
        /// <returns>true if the specified objects are equal; otherwise, false.</returns>
        public virtual bool Equals(TElement x, TElement y)
        {
            return this.ServiceLocator.MatchEquality<TElement, TAnnotation>(x, y);
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
