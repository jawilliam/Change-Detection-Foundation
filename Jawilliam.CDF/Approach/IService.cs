namespace Jawilliam.CDF.Approach
{
    /// <summary>
    /// Defines a functionality dynamically accesible in a <see cref="IApproach{TElement, TRevision, TAnnotation}"/>. 
    /// </summary>
    public interface IService
    {
        /// <summary>
        /// Gets an additional way of identifying the current service.
        /// </summary>
        int Id { get; }
    }
}
