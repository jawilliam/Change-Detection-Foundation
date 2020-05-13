using Autofac;

namespace Jawilliam.CDF.SCCD.Base
{
    /// <summary>
    /// Base class that makes the Source Code Change Detection (SCCD) solutions easier to implement.
    /// </summary>
    /// <typeparam name="TElement">Type of the supported elements.</typeparam>
    public class Solution<TElement> : ISolution<TElement>
    {
        private IDetection<TElement> _detection;

        /// <summary>
        /// Gets the currently or finally discovered matches.
        /// </summary>
        protected virtual IDetection<TElement> Detection
        {
            get => this._detection ?? (this._detection = new Detection<TElement>());
            set
            {
                this._detection = value;
            }
        }

        /// <summary>
        /// The mechanism to resolve the required services.
        /// </summary>
        public virtual IContainer Container { get; protected set; }

        /// <summary>
        /// Detects how to transform the original element into the modified one.
        /// </summary>
        /// <param name="originalCode">original element.</param>
        /// <param name="modifiedCode">modified element.</param>
        /// <returns>An structure describing both the discovered matches and the computed actions.</returns>
        public IDetection<TElement> Detect(TElement original, TElement modified)
        {
            if (this.Container == null)
            {
                var builder = new ContainerBuilder();
                builder.RegisterInstance(this).As<ISolution<TElement>>();
                this.Setup(builder);
                this.Container = builder.Build();
            }

            this.Detection = null;
            this.DetectBefore(original, modified);
            this.DetectCore(original, modified);
            this.DetectAfter(original, modified);
            return this.Detection;
        }

        /// <summary>
        /// Logic to execute before <see cref="DetectCore(TElement, TElement)"/>.
        /// </summary>
        /// <param name="originalCode">original element.</param>
        /// <param name="modifiedCode">modified element.</param>
        protected virtual void DetectBefore(TElement original, TElement modified) { }

        /// <summary>
        /// Core logic to execute within <see cref="Detect(TElement, TElement)"/>.
        /// </summary>
        /// <param name="originalCode">original element.</param>
        /// <param name="modifiedCode">modified element.</param>
        protected virtual void DetectCore(TElement original, TElement modified) { }

        /// <summary>
        /// Logic to execute after <see cref="DetectCore(TElement, TElement)"/>.
        /// </summary>
        /// <param name="originalCode">original element.</param>
        /// <param name="modifiedCode">modified element.</param>
        protected virtual void DetectAfter(TElement original, TElement modified) { }

        /// <summary>
        /// Sets up the required services. 
        /// </summary>
        /// <param name="builder">The container used to register the services.</param>
        protected virtual void Setup(ContainerBuilder builder) { }
    }
}
