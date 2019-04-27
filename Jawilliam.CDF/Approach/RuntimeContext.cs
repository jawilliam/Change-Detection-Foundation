using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jawilliam.CDF.Approach
{
    /// <summary>
    /// Describes the context wherein certain detection component is currently running.
    /// </summary>
    /// <typeparam name="TElement">Type of the supported elements.</typeparam>
    public class RuntimeContext<TElement>
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="approach">the approach wherein certain detection component is currently running.</param>
        public RuntimeContext(IApproach<TElement> approach)
        {
            this.Approach = approach ?? throw new ArgumentNullException(nameof(approach));
        }

        /// <summary>
        /// Gets the approach wherein certain detection component is currently running.
        /// </summary>
        public IApproach<TElement> Approach { get; private set; }
    }
}
