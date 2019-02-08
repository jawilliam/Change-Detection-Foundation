using System;
using System.Collections.Generic;
using System.Linq;

namespace Jawilliam.CDF.Approach
{
    /// <summary>
    /// Base class to implement logic to execute under the context of a step in the detection of changes.
    /// </summary>
    public abstract class Choice<T> : IChoice<T>
    {
        /// <summary>
        /// Gets or sets the solution wherein the current procedure is being called.
        /// </summary>
        public abstract IFrameworkApproach<T> Approach { get; set; }

        /// <summary>
        /// Executes the current choice under the context of a step in the detection of changes.
        /// </summary>
        public void OnStep()
        {
            if (this.Approach == null) throw new NullReferenceException("Approach must be setted.");
            if (this.SupportedSteps.Any(s => this.Approach.Step == s))
                this.CoreOnStep();
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
