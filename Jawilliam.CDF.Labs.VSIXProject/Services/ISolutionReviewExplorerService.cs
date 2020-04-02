using Jawilliam.CDF.Labs.Common.DBModel;
using Jawilliam.CDF.Labs.VSIXProject.Models;
using System.Collections.Generic;

namespace Jawilliam.CDF.Labs.VSIXProject.Services
{
    /// <summary>
    /// Defines the <see cref="ViewModels.SolutionReviewExplorerViewModel"/>'s service.
    /// </summary>
    public interface ISolutionReviewExplorerService
    {
        /// <summary>
        /// Gets the delta comparisons existing in a given project between the given left approach and the given right approach. 
        /// </summary>
        /// <param name="project">project name.</param>
        /// <param name="leftApproach">left approach.</param>
        /// <param name="rightApproach">right approach.</param>
        /// <returns>A summary for each existing delta comparison.</returns>
        IEnumerable<DeltaComparisonDescriptor> GetDeltaComparisons(string project, ChangeDetectionApproaches leftApproach, ChangeDetectionApproaches rightApproach);
    }
}
