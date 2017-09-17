using System;
using System.IO;

namespace Jawilliam.CDF.Flacda
{
    /// <summary>
    /// Implements the FLACDA (Fully Language-aware Change Detection Algorithm) approach.
    /// </summary>
    public class FlacdaApproach : FrameworkApproach
    {
        /// <summary>
        /// Gets or sets the matching procedure.
        /// </summary>
        public virtual IProcedure<FlacdaApproach> Matching { get; set; }

        /// <summary>
        /// Gets or sets the matching procedure.
        /// </summary>
        public virtual IProcedure<FlacdaApproach> Differencing { get; set; }

        /// <summary>
        /// Gets or sets the matching procedure.
        /// </summary>
        public virtual IProcedure<FlacdaApproach> Report { get; set; }

        /// <summary>
        /// Executes the current procedure given a particular input.
        /// </summary>
        /// <param name="args">arguments initially given, i.e., the input with which the current procedure will execute.</param>
        public override void Proceed(RevisionPair<TextReader> args)
        {
            throw new NotImplementedException();
        }
    }
}
