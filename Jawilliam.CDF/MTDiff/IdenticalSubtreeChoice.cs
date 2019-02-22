using Jawilliam.CDF.Approach;
using Jawilliam.CDF.Approach.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jawilliam.CDF.CSharp.MTDiff
{
    /// <summary>
    /// Implements the "Identical SubTree" optimization (A).
    /// </summary>
    /// <typeparam name="TElement">Type of the supported elements.</typeparam>
    /// <typeparam name="TRevision">Type of the comparing versions.</typeparam>
    public class IdenticalSubtreeChoice<TElement, TRevision> : Choice<TElement, TRevision>
    {
        /// <summary>
        /// Gets the steps wherein the current choice will be actively executed.
        /// </summary>
        public override IList<long> SupportedSteps => new List<long>
        {
            (long)(StepInfo.Equality | StepInfo.Subtree)
        };

        /// <summary>
        /// Core implementation of <see cref="OnStep"/>.
        /// </summary>
        public override void CoreOnStep()
        {
            throw new NotImplementedException();
        }

        public Func<SyntaxNode>
    }
}
