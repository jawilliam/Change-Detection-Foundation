using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jawilliam.CDF.Labs
{
    /// <summary>
    /// Base logic for the imprecision diagnostic.
    /// </summary>
    /// <typeparam name="TSymptom">type of the recognized symptoms.</typeparam>
    public abstract class ImprecisionDiagnostic<TSymptom> : FileRevisionPairAnalyzer
    {
        /// <summary>
        /// Looks for symptoms of imprecision.
        /// </summary>
        /// <returns>Symptomatic imprecisions.</returns>
        public abstract IEnumerable<TSymptom> Recognize();

        /// <summary>
        /// Gathers a referential summary and save it in <see cref="FileRevisionPairAnalyzer.Report"/>.
        /// </summary>
        public abstract void ReportSummary();
    }
}