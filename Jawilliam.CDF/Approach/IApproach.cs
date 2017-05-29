using System.IO;

namespace Jawilliam.CDF.Approach
{
    /// <summary>
    /// Defines an approach or algorithm of change detection.
    /// </summary>
    /// <typeparam name="TArgs">Concrete type of the arguments.</typeparam>
    public interface IApproach<TArgs> : IProcedure<TArgs, IDelta>
    {
    }

    /// <summary>
    /// Defines an approach or algorithm of change detection that is implemented based on the Change Detection Foundation framework.
    /// </summary>
    public interface IFrameworkApproach : IApproach<RevisionPair<TextReader>>
    {
        //IProcedure<IFrameworkApproach, >
    }
}
