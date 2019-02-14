using System;
using System.Collections.Generic;
using System.Linq;

namespace Jawilliam.CDF.Approach.Base
{
    /// <summary>
    /// Base class to implement logic to execute under the context of a step in the detection of changes.
    /// </summary>
    /// <typeparam name="TElement">Type of the supported elements.</typeparam>
    /// <typeparam name="TRevision">Type of the comparing versions.</typeparam>
    public abstract class Choice<TElement, TRevision> : IChoice<TElement, TRevision>
    {
        /// <summary>
        /// Gets or sets the solution wherein the current procedure is being called.
        /// </summary>
        public virtual IApproach<TElement, TRevision> Approach { get; set; }

        /// <summary>
        /// Executes the current choice under the context of a step in the detection of changes.
        /// </summary>
        void IChoice<TElement, TRevision>.OnStep()
        {
            if (this.Approach == null) throw new NullReferenceException("Approach must be setted.");
            if (this.SupportedStep())
                this.CoreOnStep();
        }

        internal bool SupportedStep()
        {
            return this.SupportedSteps.Any(s => (this.Approach.Step & s) != 0);
        }

        /// <summary>
        /// Gets the steps wherein the current choice will be actively executed.
        /// </summary>
        public abstract IList<long> SupportedSteps { get; }

        /// <summary>
        /// Core implementation of <see cref="OnStep"/>.
        /// </summary>
        public abstract void CoreOnStep();
    }
}
