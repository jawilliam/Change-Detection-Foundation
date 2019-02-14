using Jawilliam.CDF.Approach.Base;
using System;
using System.Collections.Generic;

namespace Jawilliam.CDF.Approach.Flad
{
    /// <summary>
    /// Fully Language-Aware source code Deltas.
    /// </summary>
    /// <typeparam name="TElement">Type of the supported elements.</typeparam>
    /// <typeparam name="TRevision">Type of the comparing versions.</typeparam>
    public abstract class FladApproach<TElement, TRevision> : Approach<TElement, TRevision>
    {
        /// <summary>
        /// Stores the value of <see cref="ServiceContainer"/>.
        /// </summary>
        private Dictionary<Type, object> _serviceContainer;

        /// <summary>
        /// Contains those services that have been explicitly registered. 
        /// </summary>
        protected virtual Dictionary<Type, object> ServiceContainer
        {
            get => this._serviceContainer ?? (this._serviceContainer = new Dictionary<Type, object>());
            set => this._serviceContainer = value;
        }

        /// <summary>
        /// Gets a typed service in case some one exists.
        /// </summary>
        /// <typeparam name="TService">the type of the requested service.</typeparam>
        /// <returns>a typed service in case some one exists, otherwise returns null</returns>
        public override TService GetService<TService>()
        {
            return this.ServiceContainer.ContainsKey(typeof(TService)) ? (TService)this.ServiceContainer[typeof(TService)] : default(TService);
        }
    }
}
