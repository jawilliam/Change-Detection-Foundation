using Jawilliam.CDF.Approach.Services;

namespace Jawilliam.CDF.Approach.Criterions.Impl
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TElement">Type of the supported elements.</typeparam>
    public class SimilarityMatchInfo<TElement> : MatchInfo<TElement>
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="criterion">identifies under what conditions was determined the current match.</param>
        public SimilarityMatchInfo(int criterion) : base(criterion)
        {
        }

        /// <summary>
        /// Get or sets the similarity value.
        /// </summary>
        public virtual double Value { get; set; }
    }
}
