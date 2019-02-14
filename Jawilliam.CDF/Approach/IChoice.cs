namespace Jawilliam.CDF.Approach
{
    /// <summary>
    /// Defines a logic to execute under the context of a step in the detection of changes.
    /// </summary>
    /// <typeparam name="TElement">Type of the supported elements.</typeparam>
    /// <typeparam name="TRevision">Type of the comparing versions.</typeparam>
    public interface IChoice<TElement, TRevision>
    {
        /// <summary>
        /// Gets or sets the solution wherein the current procedure is being called.
        /// </summary>
        IApproach<TElement, TRevision> Approach { get; set; }

        /// <summary>
        /// Executes the current choice under the context of a step in the detection of changes.
        /// </summary>
        void OnStep();
    }

    /// <summary>
    /// Defines a choice that must be called when starting the detection of changes in a new revision pair.  
    /// </summary>
    /// <typeparam name="TElement">Type of the supported elements.</typeparam>
    /// <typeparam name="TRevision">Type of the comparing versions.</typeparam>
    public interface IChoiceWithBeginDetection<TElement, TRevision> : IChoice<TElement, TRevision>
    {
        /// <summary>
        /// Initializes the current choice for detecting changes in a new revision pair.
        /// </summary>
        void BeginDetection();
    }

    /// <summary>
    /// Defines a choice that must be called when ending the detection of changes in a revision pair. 
    /// </summary>
    /// <typeparam name="TElement">Type of the supported elements.</typeparam>
    /// <typeparam name="TRevision">Type of the comparing versions.</typeparam>
    public interface IChoiceWithEndDetection<TElement, TRevision> : IChoice<TElement, TRevision>
    {
        /// <summary>
        /// Finalizes the current choice after completing the detection of changes in a revision pair.
        /// </summary>
        void EndDetection();
    }

    /// <summary>
    /// Defines a choice that must be called when starting a step in the detection of changes.  
    /// </summary>
    /// <typeparam name="TElement">Type of the supported elements.</typeparam>
    /// <typeparam name="TRevision">Type of the comparing versions.</typeparam>
    public interface IChoiceWithBeginStep<TElement, TRevision> : IChoice<TElement, TRevision>
    {
        /// <summary>
        /// Initializes the current choice for a step in the detection of changes.
        /// </summary>
        void BeginStep();
    }

    /// <summary>
    /// Defines a choice that must be called when ending a step in the detection of changes. 
    /// </summary>
    /// <typeparam name="TElement">Type of the supported elements.</typeparam>
    /// <typeparam name="TRevision">Type of the comparing versions.</typeparam>
    public interface IChoiceWithEndStep<TElement, TRevision> : IChoice<TElement, TRevision>
    {
        /// <summary>
        /// Finalizes the current choice after the completion of a step in the detection of changes.
        /// </summary>
        void EndStep();
    }
}
