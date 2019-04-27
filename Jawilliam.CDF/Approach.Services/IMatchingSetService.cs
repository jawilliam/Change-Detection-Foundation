namespace Jawilliam.CDF.Approach.Services
{
    /// <summary>
    /// Exposes functionalities related to the some version existing in the matching set.
    /// </summary>
    /// <typeparam name="TElement">Type of the supported elements.</typeparam>
    public interface IMatchingVersionService<TElement>
    {
        /// <summary>
        /// Informs if an element has not (candidate) matches.
        /// </summary>
        /// <param name="element">element of interest.</param>
        /// <returns>true if the element has not matches, false otherwise.</returns>
        bool Unpaired(TElement element);

        /// <summary>
        /// Informs if an version has not matching partner.
        /// </summary>
        /// <param name="element">element of interest.</param>
        /// <returns>true if the element has not matching partner, false otherwise.</returns>
        bool Unmatched(TElement element);

        /// <summary>
        /// Disables any possibility of matching the given element.
        /// </summary>
        /// <param name="element">element of interest.</param>
        /// <remarks>this is the inverse of <see cref="EnableMatching(TElement)"/>.</remarks>
        void DisableMatching(TElement element);

        /// <summary>
        /// Enables the given element to be matched.
        /// </summary>
        /// <param name="element">element of interest.</param>
        /// <remarks>this is the inverse of <see cref="DisableMatching(TElement)"/>.</remarks>
        void EnableMatching(TElement element);
    }

    /// <summary>
    /// Exposes functionalities related to the matching set.
    /// </summary>
    /// <typeparam name="TElement">Type of the supported elements.</typeparam>
    public interface IMatchingSetService<TElement> : IService
    {
        /// <summary>
        /// Adds a (candidate) match both in the <see cref="Originals"/> and in the <see cref="Modifieds"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        void Pair(TElement original, TElement modified);

        /// <summary>
        /// Adds a (candidate) match both in the <see cref="Originals"/> and in the <see cref="Modifieds"/>.
        /// </summary>
        /// <param name="matchInfo">the match.</param>
        void Pair(MatchInfo<TElement> matchInfo);

        /// <summary>
        /// Removes a (candidate) match both in the <see cref="Originals"/> and in the <see cref="Modifieds"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        void Unpair(TElement original, TElement modified);

        /// <summary>
        /// Informs if there is a pair among two given versions.
        /// </summary>
        /// <param name="original">original version.</param>
        /// <param name="modified">modified version.</param>
        /// <returns>true if there is a pair among two given versions; otherwise, false.</returns>
        bool Paired(TElement original, TElement modified);

        /// <summary>
        /// Notifies that, the two given versions have been definitively matched, which will be stored both in the <see cref="Originals"/> and in the <see cref="Modifieds"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        void Partners(TElement original, TElement modified);

        /// <summary>
        /// Notifies that, the two given versions have been definitively matched, which will be stored both in the <see cref="Originals"/> and in the <see cref="Modifieds"/>.
        /// </summary>
        /// <param name="matchInfo">the match.</param>
        void Partners(MatchInfo<TElement> matchInfo);

        /// <summary>
        /// Exposes matching set functionalities related to the original elements.
        /// </summary>
        IMatchingVersionService<TElement> Originals { get; }

        /// <summary>
        /// Exposes matching set functionalities related to the modified elements.
        /// </summary>
        IMatchingVersionService<TElement> Modifieds { get; }

        ///// <summary>
        ///// Informs if an modified version has not (candidate) matches.
        ///// </summary>
        ///// <param name="element">modified version.</param>
        ///// <returns>true if the modified version has not matches, false otherwise.</returns>
        //bool UnpairedModified(TElement element);

        ///// <summary>
        ///// Informs if an original version has not (candidate) matches.
        ///// </summary>
        ///// <param name="element">original version.</param>
        ///// <returns>true if the original version has not matches, false otherwise.</returns>
        //bool UnpairedOriginal(TElement element);

        ///// <summary>
        ///// Informs if an original version has not matching partner.
        ///// </summary>
        ///// <param name="element">original version.</param>
        ///// <returns>true if the original version has not matching partner, false otherwise.</returns>
        //bool UnmatchedOriginal(TElement element);

        ///// <summary>
        ///// Informs if an modified version has not matching partner.
        ///// </summary>
        ///// <param name="element">modified version.</param>
        ///// <returns>true if the modified version has not matching partner, false otherwise.</returns>
        //bool UnmatchedModified(TElement element);

        ///// <summary>
        ///// Disables the given original element to be matched.
        ///// </summary>
        ///// <param name="element">original element.</param>
        ///// <remarks>this is the inverse of <see cref="EnableOriginal(TElement)"/>.</remarks>
        //void DisableOriginal(TElement element);

        ///// <summary>
        ///// Disables the given modified element to be matched.
        ///// </summary>
        ///// <param name="element">modified element.</param>
        ///// <remarks>this is the inverse of <see cref="EnableModified(TElement)"/>.</remarks>
        //void DisableModified(TElement element);

        ///// <summary>
        ///// Enables the given original element to be matched.
        ///// </summary>
        ///// <param name="element">original element.</param>
        ///// <remarks>this is the inverse of <see cref="DisableOriginal(TElement)"/>.</remarks>
        //void EnableOriginal(TElement element);

        ///// <summary>
        ///// Enables the given modified element to be matched.
        ///// </summary>
        ///// <param name="element">modified element.</param>
        ///// <remarks>this is the inverse of <see cref="DisableModified(TElement)"/>.</remarks>
        //void EnableModified(TElement element);
    }
}