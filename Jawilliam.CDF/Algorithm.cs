namespace Jawilliam.CDF
{
    /// <summary>
    /// Base class for the implementations of a procedure of change detection.
    /// </summary>
    /// <typeparam name="TArgs">Concrete type of the arguments.</typeparam>
    /// <typeparam name="TResult">Concrete type of the result.</typeparam>
    public abstract class Algorithm<TArgs, TResult> : IAlgorithm<TArgs, TResult>
    {
        /// <summary>
        /// Gets the arguments initially given, i.e., the input with which the current procedure is currently executing.
        /// </summary>
        public virtual TArgs Args { get; private set; }

        /// <summary>
        /// Gets the output information.
        /// </summary>
        public virtual TResult Result { get; protected set; }

        /// <summary>
        /// Executes the current procedure given a particular input.
        /// </summary>
        /// <param name="args">arguments initially given, i.e., the input with which the current procedure will execute.</param>
        public virtual void Proceed(TArgs args)
        {
            this.Args = args;
        }
    }
}
