namespace Jawilliam.CDF.Approach.Base
{
    /// <summary>
    /// Base class for the implementations of a procedure of change detection.
    /// </summary>
    /// <typeparam name="TArgs">Concrete type of the arguments.</typeparam>
    /// <typeparam name="TResult">Concrete type of the result.</typeparam>
    public abstract class Procedure<TArgs, TResult> : IProcedure<TArgs, TResult>
    {
        /// <summary>
        /// Gets the arguments initially given, i.e., the input with which the current procedure is currently executing.
        /// </summary>
        public virtual TArgs Args { get; protected set; }

        /// <summary>
        /// Gets the output information.
        /// </summary>
        public virtual TResult Result { get; protected set; }

        /// <summary>
        /// Executes the current procedure given a particular input.
        /// </summary>
        /// <param name="args">arguments initially given, i.e., the input with which the current procedure will execute.</param>
        void IProcedure<TArgs, TResult>.Proceed(TArgs args)
        {
            this.Args = args;
            this.CoreProceed();
        }

        /// <summary>
        /// The core implementation of the procedure.
        /// </summary>
        protected abstract void CoreProceed();

        /// <summary>
        /// Gets the arguments initially given, i.e., the input with which the current procedure is currently executing.
        /// </summary>
        TArgs IProcedure<TArgs, TResult>.Args => this.Args;

        /// <summary>
        /// Gets the output information.
        /// </summary>
        TResult IProcedure<TArgs, TResult>.Result => this.Result;
    }
}
