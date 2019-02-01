namespace Jawilliam.CDF.Approach
{
    /// <summary>
    /// Defines a procedure of change detection.
    /// </summary>
    /// <typeparam name="TArgs">Concrete type of the arguments.</typeparam>
    /// <typeparam name="TResult">Concrete type of the result.</typeparam>
    public interface IProcedure<TArgs, out TResult>
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

        /// <summary>
        /// Gets the output information.
        /// </summary>
        TResult Result { get; }
    }

    /// <summary>
    /// Defines a framework procedure for change detection.
    /// </summary>
    /// <typeparam name="TArgs">Concrete type of the arguments.</typeparam>
    /// <typeparam name="TResult">Concrete type of the result.</typeparam>
    public interface IFrameworkProcedure<TArgs, out TResult> : IProcedure<TArgs, TResult>
    {
        /// <summary>
        /// Gets or sets the solution wherein the current procedure is being called.
        /// </summary>
        IFrameworkApproach Context { get; set; }
    }
}
