using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Jawilliam.CDF
{
    /// <summary>
    /// Contains shared methods for resolving domain concerns in source code change detection.
    /// </summary>
    public static class DomainExtensions
    {
        /// <summary>
        /// Returns the ancestors determining the subtypes of a given labeled element.
        /// </summary>
        /// <param name="source">labeled element for which returning the ancestors.</param>
        /// <param name="parent">the how to access the parent for each element.</param>
        /// <param name="isLabel">the how to determine if a given element is an labeled.</param>
        /// <returns>the ancestors that qualify the type of labeled element.</returns>
        public static IEnumerable<T> LabelOf<T>(this T source, Func<T, T> parent, Func<T, bool> isLabel)
        {
            Debug.Assert(isLabel != null);
            Debug.Assert(isLabel(source), "The source element is expected to be a labeled element.");
            var temp = source;
            do
            {
                var parentElement = parent(temp);
                temp = default(T);
                if (object.Equals(parentElement, default(T))) continue;

                yield return parentElement;

                if (isLabel(parentElement))
                    temp = parentElement;
            }
            while (!object.Equals(temp, default(T)));
        }
    }
}
