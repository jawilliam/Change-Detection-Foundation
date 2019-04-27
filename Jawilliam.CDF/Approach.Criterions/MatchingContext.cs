using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jawilliam.CDF.Approach.Criterions
{
    /// <summary>
    /// Describes the context wherein certain matching criterion is currently running.
    /// </summary>
    /// <typeparam name="TElement">Type of the supported elements.</typeparam>
    public class MatchingContext<TElement> : RuntimeContext<TElement>
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="approach">the approach wherein certain detection component is currently running.</param>
        public MatchingContext(IApproach<TElement> approach) : base(approach)
        {
        }

        /// <summary>
        /// Gets or sets the on running matching logic.
        /// </summary>
        public int? Criterion { get; set; }

        /// <summary>
        /// Stores the value of <see cref="HScope"/>.
        /// </summary>
        private RevisionPair<TElement> _hScope;

        /// <summary>
        /// Gets or sets the original and modified "roots" delimiting a high-level discovery scope (e.g., a conceptual type, member, or block).  
        /// </summary>
        public virtual RevisionPair<TElement> HScope => this._hScope ?? (this._hScope = new RevisionPair<TElement>());

        /// <summary>
        /// Stores the value of <see cref="LScope"/>.
        /// </summary>
        private RevisionPair<TElement> _lScope;

        /// <summary>
        /// Gets or sets the original and modified "roots" delimiting a lower-level discovery scope, which normally means the conceptual parents.  
        /// </summary>
        public virtual RevisionPair<TElement> LScope => this._lScope ?? (this._lScope = new RevisionPair<TElement>());
    }
}
