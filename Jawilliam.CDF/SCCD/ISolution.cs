using Autofac;

namespace Jawilliam.CDF.SCCD
{
    /// <summary>
    /// Defines a Source Code Change Detection (SCCD) solution.
    /// </summary>
    /// <typeparam name="TElement">Type of the supported elements.</typeparam>
    public interface ISolution<TElement>
    {
        /// <summary>
        /// Detects how to transform the original element into the modified one.
        /// </summary>
        /// <param name="originalCode">original element.</param>
        /// <param name="modifiedCode">modified element.</param>
        /// <returns>An structure describing both the discovered matches and the computed actions.</returns>
        IDetection<TElement> Detect(TElement original, TElement modified);

        /// <summary>
        /// The mechanism to resolve the required services.
        /// </summary>
        IContainer Container { get; }
    }
}
