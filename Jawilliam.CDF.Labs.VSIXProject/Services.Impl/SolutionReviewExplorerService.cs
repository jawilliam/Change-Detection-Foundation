using Jawilliam.CDF.Labs.Common.DBModel;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using Jawilliam.CDF.Labs.VSIXProject.Models;

namespace Jawilliam.CDF.Labs.VSIXProject.Services.Impl
{
    /// <summary>
    /// Implements a EF-based <see cref="ViewModels.SolutionReviewExplorerViewModel"/>'s service that .
    /// </summary>
    public class SolutionReviewExplorerService : ISolutionReviewExplorerService
    {
        public virtual Configuration GetAppConfig()
        {
            ExeConfigurationFileMap configMap = new ExeConfigurationFileMap();
            configMap.ExeConfigFilename = @"app.config"; // the path of the custom app.config
            return ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
        }

        /// <summary>
        /// Gets the delta comparisons existing in a given project between the given left approach and the given right approach. 
        /// </summary>
        /// <param name="project">project name.</param>
        /// <param name="leftApproach">left approach.</param>
        /// <param name="rightApproach">right approach.</param>
        /// <returns>A summary for each existing delta comparison.</returns>
        public virtual IEnumerable<DeltaComparisonDescriptor> GetDeltaComparisons(string project, ChangeDetectionApproaches leftApproach, ChangeDetectionApproaches rightApproach)
        {
            IList<DeltaComparison> deltaComparisons = null;
            Configuration config = this.GetAppConfig();
            var connectionString = config.ConnectionStrings.ConnectionStrings[project].ConnectionString;

            using (var db = new GitRepository(connectionString) { Name = project })
            {
                deltaComparisons = db.DeltaComparisonSet.AsNoTracking().Where(s =>
                     (s.Left.Approach == leftApproach && s.Right.Approach == rightApproach) ||
                     (s.Right.Approach == leftApproach && s.Left.Approach == rightApproach)).ToList();                
            }

            return deltaComparisons.Select(delegate (DeltaComparison deltaComparison, int i)
            {
                var xComparison = deltaComparison.XMatching;

                var lr = (xComparison.Matching?.OfType<LRMatchSymptom>().Count(s => s.Left.Approach == (int)leftApproach) ?? 0) +
                         (xComparison.Matching?.OfType<RLMatchSymptom>().Count(s => s.Right.Approach == (int)leftApproach) ?? 0);
                var rl = (xComparison.Matching?.OfType<LRMatchSymptom>().Count(s => s.Left.Approach == (int)rightApproach) ?? 0) +
                         (xComparison.Matching?.OfType<RLMatchSymptom>().Count(s => s.Right.Approach == (int)rightApproach) ?? 0);
                var total = lr + rl;

                return new DeltaComparisonDescriptor{ 
                    Index = i + 1,
                    LeftId = deltaComparison.LeftId,
                    RightId = deltaComparison.RightId,
                    AllMismatches = total,
                    LrMismatches = lr,
                    RlMismatches = rl };
            });
        }
    }
}
