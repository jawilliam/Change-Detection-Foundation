using Jawilliam.CDF.Labs.Common.DBModel;
using Jawilliam.CDF.Labs.VSIXProject.Models;
using System;
using System.Collections.Generic;

namespace Jawilliam.CDF.Labs.VSIXProject.Services.Impl
{
    /// <summary>
    /// Implements a EF-based <see cref="ViewModels.SolutionReviewExplorerViewModel"/>'s service that .
    /// </summary>
    public class MockSolutionReviewExplorerService : ISolutionReviewExplorerService
    {
        /// <summary>
        /// Gets the delta comparisons existing in a given project between the given left approach and the given right approach. 
        /// </summary>
        /// <param name="project">project name.</param>
        /// <param name="leftApproach">left approach.</param>
        /// <param name="rightApproach">right approach.</param>
        /// <returns>A summary for each existing delta comparison.</returns>
        public virtual IEnumerable<DeltaComparisonDescriptor> GetDeltaComparisons(string project, ChangeDetectionApproaches leftApproach, ChangeDetectionApproaches rightApproach)
        {
            yield return new DeltaComparisonDescriptor { Index = 1, LeftId = Guid.Empty, RightId = Guid.Empty, AllMismatches = 4, LrMismatches = 2, RlMismatches = 0 };
            yield return new DeltaComparisonDescriptor { Index = 2, LeftId = Guid.Empty, RightId = Guid.Empty, AllMismatches = 6, LrMismatches = 2, RlMismatches = 4 };
            yield return new DeltaComparisonDescriptor { Index = 3, LeftId = Guid.Empty, RightId = Guid.Empty, AllMismatches = 14, LrMismatches = 3, RlMismatches = 11 };
            yield return new DeltaComparisonDescriptor { Index = 4, LeftId = Guid.Empty, RightId = Guid.Empty, AllMismatches = 17, LrMismatches = 12, RlMismatches = 5 };
        }
    }
}
