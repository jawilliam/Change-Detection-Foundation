using System;
using System.Collections.Generic;
using System.Linq;

namespace Jawilliam.CDF.Approach.Impl
{
    /// <summary>
    /// Base class to implement logic to execute under the context of a step in the detection of changes.
    /// </summary>
    /// <typeparam name="TElement">Type of the supported elements.</typeparam>
    public abstract class Choice<TElement> : IChoice 
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="approach">the solution wherein the current choice will be called</param>
        public Choice(IApproach<TElement> approach)
        {
            this.Approach = approach != null ? approach : throw new ArgumentNullException(nameof(approach));
        }

        /// <summary>
        /// Gets or sets the solution wherein the current choice will be called.
        /// </summary>
        public IApproach<TElement> Approach { get; private set; }

        /// <summary>
        /// Executes the current choice under the context of a step in the detection of changes.
        /// </summary>
        void IChoice.OnStep()
        {
            if (this.SupportedStep())
                this.CoreOnStep();
        }

        internal bool SupportedStep()
        {
            return this.SupportedSteps.Any(s => (this.Approach.Step & s) == s);
        }

        /// <summary>
        /// Gets the steps wherein the current choice will be actively executed.
        /// </summary>
        protected abstract IList<long> SupportedSteps { get; }

        /// <summary>
        /// Core implementation of <see cref="OnStep"/>.
        /// </summary>
        protected abstract void CoreOnStep();
    }
}
