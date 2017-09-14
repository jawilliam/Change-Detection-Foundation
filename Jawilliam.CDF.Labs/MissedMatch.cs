namespace Jawilliam.CDF.Labs
{
    /// <summary>
    /// Describes a candidate missed match.
    /// </summary>
    public class MissedMatch
    {
        /// <summary>
        /// Gets or sets the type of missed match (DI, DT, TI, or TT)
        /// </summary>
        public virtual string Case { get; set; }

        /// <summary>
        /// Gets or sets the original version missed (i.e., MM.(D)I, MM.(D)T, MM.(T)I, MM.(T)T).
        /// </summary>
        public virtual MissedVersion Original { get; set; }

        /// <summary>
        /// Gets or sets the modified version missed (i.e., MM.D(I), MM.D(T), MM.T(I), MM.T(T)).
        /// </summary>
        public virtual MissedVersion Modified { get; set; }
    }
}