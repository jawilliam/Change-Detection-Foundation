using System;

namespace Jawilliam.CDF.CSharp.Flad
{
    /// <summary>
    /// Contains options to describe a step in change detection.
    /// </summary>
    [Flags]
    public enum CSharpFladStepInfo : long
    {
        None = 0,

        /// <summary>
        /// Matching discovery.
        /// </summary>
        MatchingPhase = 1,

        /// <summary>
        /// Difference computing.
        /// </summary>
        DifferencingPhase = 2,

        /// <summary>
        /// Changes report.
        /// </summary>
        ReportPhase = 4,

        /// <summary>
        /// Exactly equal (e.g., match exactly equal names).
        /// </summary>
        Equality = 8,

        /// <summary>
        /// Approximately equal (e.g., match approximately equal names).
        /// </summary>
        Similarity = 16,

        Signature = 32,

        Name = 64,

        Head = 128,
    }
}
