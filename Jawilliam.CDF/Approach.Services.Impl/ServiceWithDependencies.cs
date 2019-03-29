using System;

namespace Jawilliam.CDF.Approach.Services.Impl
{
    /// <summary>
    /// Base class of the services which depends on other services.
    /// </summary>
    /// <typeparam name="TServiceLocator">the mechanism for dynamically loading a typed service.</typeparam>
    public class ServiceWithDependencies<TServiceLocator> : Service where TServiceLocator : IServiceLocator
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="serviceLocator">the mechanism for dynamically loading a typed service.</param>
        public ServiceWithDependencies(TServiceLocator serviceLocator)
        {
            this.ServiceLocator = serviceLocator != null ? serviceLocator : throw new ArgumentNullException(nameof(serviceLocator));
        }

        /// <summary>
        /// Gets or sets the mechanism for dynamically loading a typed service.
        /// </summary>
        public TServiceLocator ServiceLocator { get; private set; }
    }

    /// <summary>
    /// Base class of the services which depends on other services.
    /// </summary>
    public class ServiceWithDependencies : ServiceWithDependencies<IServiceLocator>
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="serviceLocator">the mechanism for dynamically loading a typed service.</param>
        public ServiceWithDependencies(IServiceLocator serviceLocator) : base(serviceLocator)
        {
        }
    }
}
