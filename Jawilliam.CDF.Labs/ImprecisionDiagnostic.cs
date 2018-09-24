using Jawilliam.CDF.Labs.DBModel;
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
        /// <param name="skipThese">local criterion for determining elements that should be ignored.</param>
        /// <param name="saveChanges">Enables or disables the persistence of the changes.</param>
        public abstract void Recognize(Func<FileRevisionPair, bool> skipThese = null, bool saveChanges = true);

        /// <summary>
        /// Gathers a referential summary and save it in <see cref="FileRevisionPairAnalyzer.Report"/>.
        /// </summary>
        public abstract void ReportSummary();

        /// <summary>
        /// Iterates symptoms to be rated.
        /// </summary>
        public abstract void Rate();

        ///// <summary>
        ///// Gets imprecision symptoms.
        ///// </summary>
        //public abstract IEnumerable<TSymptom> Symptoms { get; }
    }
}