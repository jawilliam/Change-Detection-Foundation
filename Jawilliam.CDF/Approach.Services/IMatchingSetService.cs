namespace Jawilliam.CDF.Approach.Services
{
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
        /// Informs if an modified version has not (candidate) matches.
        /// </summary>
        /// <param name="element">modified version.</param>
        /// <returns>true if the modified version has not matches, false otherwise.</returns>
        bool UnpairedModified(TElement element);

        /// <summary>
        /// Informs if an original version has not (candidate) matches.
        /// </summary>
        /// <param name="element">original version.</param>
        /// <returns>true if the original version has not matches, false otherwise.</returns>
        bool UnpairedOriginal(TElement element);

        /// <summary>
        /// Informs if an original version has not matching partner.
        /// </summary>
        /// <param name="element">original version.</param>
        /// <returns>true if the original version has not matching partner, false otherwise.</returns>
        bool UnmatchedOriginal(TElement element);

        /// <summary>
        /// Informs if an modified version has not matching partner.
        /// </summary>
        /// <param name="element">modified version.</param>
        /// <returns>true if the modified version has not matching partner, false otherwise.</returns>
        bool UnmatchedModified(TElement element);
    }
}