using Jawilliam.CDF.Approach;

namespace Jawilliam.CDF
{
    /// <summary>
    /// Defines an approach or algorithm of change detection.
    /// </summary>
    /// <typeparam name="TArgs">Concrete type of the arguments.</typeparam>
    public interface IApproach<TArgs> : IAlgorithm<TArgs, DetectionResult>
    {
    }
}
