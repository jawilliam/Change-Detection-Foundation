using Jawilliam.CDF.Approach;
using Jawilliam.CDF.Approach.Impl;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;

namespace Jawilliam.CDF.CSharp.Flad
{
    /// <summary>
    /// Implements a same name-based choice for source code change detection.
    /// </summary>
    public class CSharpNameEqualityChoice : Choice<SyntaxNode>
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="approach">the solution wherein the current choice will be called</param>
        public CSharpNameEqualityChoice(IApproach<SyntaxNode> approach) : base(approach)
        {
        }

        /// <summary>
        /// Gets the steps wherein the current choice will be actively executed.
        /// </summary>
        protected override IList<long> SupportedSteps => new List<long>
        {
            (long)(CSharpFladStepInfo.Equality | CSharpFladStepInfo.Name)
        };

        /// <summary>
        /// Core implementation of <see cref="OnStep"/>.
        /// </summary>
        protected override void CoreOnStep()
        {
            throw new NotImplementedException();
        }
    }
}
