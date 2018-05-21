namespace Jawilliam.CDF.UniDM
{
    /// <summary>
    /// Describes the fact that there exists a relation among changes. 
    /// </summary>
    public interface IChangeRelation
    {
        /// <summary>
        /// Gets the type of the relation.
        /// </summary>
        int Kind { get; }
    }
}
