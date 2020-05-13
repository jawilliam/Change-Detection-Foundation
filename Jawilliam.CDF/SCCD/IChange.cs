namespace Jawilliam.CDF.SCCD
{
    /// <summary>
    /// Describes a language-aware change.
    /// </summary>
    public interface IChange
    {
        /// <summary>
        /// Gets or sets the specific type of current change.
        /// </summary>
        int Kind { get; set; }
    }

    /// <summary>
    /// Describes the possible change types.
    /// </summary>
    public enum ChangeTaxonomy : int
    {

    }
}
