using System.Collections.Generic;

namespace Jawilliam.CDF.GumTree
{
    /// <summary>
    /// Defines the indexed priority list of GumTree.
    /// </summary>
    /// <typeparam name="T">the type of the supported elements.</typeparam>
    public interface IPriorityList<T>
    {
        /// <summary>
        /// Inserts an element.
        /// </summary>
        /// <param name="element">the element to insert.</param>
        void Push(T element);

        /// <summary>
        /// Returns the greatest height.
        /// </summary>
        int PeekMax { get; }

        /// <summary>
        /// Returns and removes the set of all nodes having a height equals to <see cref="PeekMax"/>.
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> Pop();

        /// <summary>
        /// Inserts all children of a given element.
        /// </summary>
        /// <param name="element">the element whose children must be opened.</param>
        void Open(T element);
    }
}
