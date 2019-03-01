namespace Jawilliam.CDF.Approach.Services
{
    /// <summary>
    /// Options for identifying, for example, the <see cref="MatchInfo{TElement}.Criterion"/>. 
    /// </summary>
    public enum MatchInfoId : int
    {
        Unknown = 0,
        
        /// <summary>
        /// The matched versions have identical full content.
        /// </summary>
        IdenticalFullHash = 1,

        /// <summary>
        /// The matched versions have identical essential content.
        /// </summary>
        IdenticalEssentialHash = 2
    }
}
