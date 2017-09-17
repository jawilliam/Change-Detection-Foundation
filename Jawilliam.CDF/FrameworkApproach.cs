using System.IO;

namespace Jawilliam.CDF
{
    /// <summary>
    /// Defines an approach or algorithm of change detection that is implemented based on the Change Detection Foundation framework.
    /// </summary>
    public abstract class FrameworkApproach : IApproach<RevisionPair<TextReader>>
    {
        /// <summary>
        /// Executes the current procedure given a particular input.
        /// </summary>
        /// <param name="args">arguments initially given, i.e., the input with which the current procedure will execute.</param>
        public abstract void Proceed(RevisionPair<TextReader> args);

        /// <summary>
        /// Gets the arguments initially given, i.e., the input with which the current procedure is currently executing.
        /// </summary>
        RevisionPair<TextReader> IProcedure<RevisionPair<TextReader>>.Args => this.Args;

        /// <summary>
        /// Gets the output information.
        /// </summary>
        DetectionResult IAlgorithm<RevisionPair<TextReader>, DetectionResult>.Result => this.Result;

        /// <summary>
        /// Gets the arguments initially given, i.e., the input with which the current procedure is currently executing.
        /// </summary>
        public virtual RevisionPair<TextReader> Args { get; protected set; }

        /// <summary>
        /// Gets the output information.
        /// </summary>
        public virtual DetectionResult Result { get; protected set; }
    }
}