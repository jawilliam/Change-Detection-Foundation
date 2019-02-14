using Jawilliam.CDF.Approach.Base;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jawilliam.CDF.CSharp.Flad
{
    /// <summary>
    /// Implements a same name-based choice for source code change detection.
    /// </summary>
    public class CSharpNameEqualityChoice : Choice<SyntaxNode, SyntaxNode>
    {
        /// <summary>
        /// Gets the steps wherein the current choice will be actively executed.
        /// </summary>
        public override IList<long> SupportedSteps => new List<long>
        {
            (long)(CSharpFladStepInfo.Equality | CSharpFladStepInfo.Name)
        };

        /// <summary>
        /// Core implementation of <see cref="OnStep"/>.
        /// </summary>
        public override void CoreOnStep()
        {
            throw new NotImplementedException();
        }
    }
}
