namespace Jawilliam.CDF
{
    /// <summary>
    /// Defines a procedure.
    /// </summary>
    /// <typeparam name="TArgs">Concrete type of the arguments.</typeparam>
    public interface IProcedure<TArgs>
    {
        /// <summary>
        /// Executes the current procedure given a particular input.
        /// </summary>
        /// <param name="args">arguments initially given, i.e., the input with which the current procedure will execute.</param>
        void Proceed(TArgs args);

        /// <summary>
        /// Gets the arguments initially given, i.e., the input with which the current procedure is currently executing.
        /// </summary>
        TArgs Args { get; }
    }
}