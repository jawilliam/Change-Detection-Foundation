namespace Jawilliam.CDF.Approach.Services.Impl
{
    /// <summary>
    /// Base class for the implementations of <see cref="IService"/>. 
    /// </summary>
    public class Service : IService
    {
        /// <summary>
        /// Gets an additional way of identifying the current service.
        /// </summary>
        public virtual int Id { get; set; }
    }
}
