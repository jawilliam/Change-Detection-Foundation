using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jawilliam.CDF.Metrics
{
    /// <summary>
    /// Implements an extraction of relative threshold.
    /// </summary>
    public class RelativeThreshold
    {
        /// <summary>
        /// Gets or sets the minimum porcent of systems that should follow real design rules. 
        /// </summary>
        public virtual double Min { get; set; } = 0.9;

        /// <summary>
        /// Gets or sets the percentile-th where the tail distribution starts at. 
        /// </summary>
        public virtual double MedianTail { get; set; } = 90;

        /// <summary>
        /// Gets or sets a minimal description of the corpus: <see cref="KeyValuePair{TKey,TValue}.Key"/> and
        /// <see cref="KeyValuePair{TKey,TValue}.Value"/> describes the Id (e.g., name) and the percentile list 
        /// of the system in turn, respectively.  
        /// </summary>
        public virtual IEnumerable<KeyValuePair<string, double[]>> Corpus { get; set; }

        private Func<string, double> _tail;

        /// <summary>
        /// Gets or sets the logic to get the percentil of a given project where its tail starts at.
        /// </summary>
        public virtual Func<string, double> Tail
        {
            get { return this._tail ?? (this._tail = projectId => this.Corpus.Single(s => s.Key == projectId).Value[89]);}
            set { this._tail = value; }
        }

        /// <summary>
        /// Gets or sets the logic to test if a project of interest satisfies the porcentage less than or equal to the threshold.
        /// </summary>
        public virtual LessThanOrEqualToDelegate DoPercentageOfProjectIsLessThanOrEqualToThreshold { get; set; }

        /// <summary>
        /// Computes the compliance rate.
        /// </summary>
        /// <param name="percent">porcentage to be satisfied.</param>
        /// <param name="threshold">the threshold to be satisfied.</param>
        /// <param name="medianTail">the median of the tails in the corpus.</param>
        /// <param name="penalty"></param>
        /// <returns></returns>
        public virtual double GetComplianceRate(double percent, double threshold, double medianTail, out double penalty)
        {
            int count = this.Corpus.Sum(system => this.DoPercentageOfProjectIsLessThanOrEqualToThreshold(system.Key, percent, threshold) ? 1 : 0);
            double complianceRate = count*1d/this.Corpus.Count();

            double penalty1 = complianceRate < this.Min 
                ? (this.Min - complianceRate) / this.Min
                : 0;
            double penalty2 = threshold > medianTail
                ? (threshold - medianTail)/medianTail
                : 0;
            penalty = penalty1 + penalty2;
            return complianceRate;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="thresholds">thresholds to evaluate.</param>
        /// <param name="percentages">percentages to evaluate.</param>
        /// <param name="medianTail">the median of the tails in the corpus.</param>
        /// <param name="percent">will contain the winner percent.</param>
        /// <returns>the winner threshold.</returns>
        public virtual double ComputeThreshold(double[] thresholds, double[] percentages, double medianTail, out double percent)
        {
            var candidates = new List<Tuple<double, double, double, double>>(thresholds.Count() * percentages.Count());
            double penalty, complianceRate;
            for (int i = 0; i < thresholds.Count(); i++)
            {
                for (int j = 0; j < percentages.Count(); j++)
                {
                    complianceRate = this.GetComplianceRate(percentages[j], thresholds[i], medianTail, out penalty);
                    candidates.Add(new Tuple<double, double, double, double>(percentages[j], thresholds[i], complianceRate, penalty));
                }
            }

            var minComplianceRatePenalty = candidates.Min(c => c.Item4);
            var winners = candidates.Where(c => c.Item4 == minComplianceRatePenalty)
                .OrderByDescending(w => w.Item1).ThenBy(w => w.Item2)
                .ToList();
            var winner = winners.First();
            percent = winner.Item1;
            return winner.Item2;
        }

        /// <summary>
        /// Logic to tests if a project of interest satisfies the porcentage less than or equal to the threshold. 
        /// </summary>
        /// <param name="projectId">Identification of the project.</param>
        /// <param name="percent">porcentage to be satisfied.</param>
        /// <param name="threshold">the threshold to be satisfied.</param>
        /// <returns>Whether or not the project of interest satisfies the porcentage less than or equal to the threshold.</returns>
        public delegate bool LessThanOrEqualToDelegate(string projectId, double percent, double threshold);
    }
}
