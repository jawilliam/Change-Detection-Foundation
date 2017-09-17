namespace Jawilliam.CDF
{
    /// <summary>
    /// Defines a procedure that returns a result.
    /// </summary>
    /// <typeparam name="TArgs">Concrete type of the arguments.</typeparam>
    /// <typeparam name="TResult">Concrete type of the result.</typeparam>
    public interface IAlgorithm<TArgs, out TResult> : IProcedure<TArgs>
    {
        /// <summary>
        /// Gets the output information.
        /// </summary>
        TResult Result { get; }
    }
}
