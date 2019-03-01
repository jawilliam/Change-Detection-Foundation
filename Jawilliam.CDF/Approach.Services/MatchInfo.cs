namespace Jawilliam.CDF.Approach.Services
{
    /// <summary>
    /// Contains informations associated to a matching criterion.
    /// </summary>
    /// <typeparam name="TElement">Type of the supported elements.</typeparam>
    public class MatchInfo<TElement> : RevisionPair<TElement>
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="criterion">identifies under what conditions was determined the current match.</param>
        public MatchInfo(int criterion)
        {
            this.Criterion = criterion;
        }
        
        /// <summary>
        /// Identifies under what conditions was determined the current match.
        /// </summary>
        public int Criterion { get; private set; }
    }
}
