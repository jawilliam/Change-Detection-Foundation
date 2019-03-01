namespace Jawilliam.CDF.Approach
{
    /// <summary>
    /// Defines how to dynamically load a typed service.
    /// </summary>
    public interface IServiceLocator
    {
        /// <summary>
        /// Gets a typed service in case some one exists.
        /// </summary>
        /// <typeparam name="TService">the type of the requested service.</typeparam>
        /// <param name="id">identifies the requested service.</param>
        /// <returns>a typed service in case some one exists, otherwise returns null</returns>
        TService GetService<TService>(int id) where TService : IService;

        /// <summary>
        /// Gets a typed service in case some one exists.
        /// </summary>
        /// <typeparam name="TService">the type of the requested service.</typeparam>
        /// <param name="id">identifies the requested service.</param>
        /// <returns>a typed service in case some one exists, otherwise throws an exception.</returns>
        TService GetServiceOrThrowsException<TService>(int id) where TService : IService;
    }
}
