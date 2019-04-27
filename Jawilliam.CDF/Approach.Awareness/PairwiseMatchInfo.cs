using Jawilliam.CDF.Approach.Services;

namespace Jawilliam.CDF.Approach.Awareness
{
    /// <summary>
    /// Describes a pairwise matching by bubbling or tunneling.
    /// </summary>
    /// <typeparam name="TElement">Type of the supported elements.</typeparam>
    public abstract class PairwiseMatchInfo<TElement> : MatchInfo<TElement>
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="criterion">identifies under what conditions was determined the current match.</param>
        internal PairwiseMatchInfo(int criterion) : base(criterion)
        {
        }

        /// <summary>
        /// Previously detected match, from which the current one was detected.
        /// </summary>
        public virtual RevisionPair<TElement> On { get; set; }

        /// <summary>
        /// Pairwise matching because their parents were previously matched.
        /// </summary>
        public class Tunneling : PairwiseMatchInfo<TElement>
        {
            /// <summary>
            /// Initializes the instance.
            /// </summary>
            public Tunneling() : base((int)MatchInfoCriterions.PairwiseTunneling) { }
        }

        /// <summary>
        /// Pairwise matching because some of their children were previously matched.
        /// </summary>
        public class Bubbling : PairwiseMatchInfo<TElement>
        {
            /// <summary>
            /// Initializes the instance.
            /// </summary>
            public Bubbling() : base((int)MatchInfoCriterions.PairwiseBubbling) { }
        }
    }
}
