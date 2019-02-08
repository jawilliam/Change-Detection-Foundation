using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Jawilliam.CDF.Approach
{
    /// <summary>
    /// Base class of an approach or algorithm of change detection.
    /// </summary>
    /// <typeparam name="T">Type of the elements.</typeparam>
    public abstract class FrameworkApproach<T> : Procedure<RevisionPair<TextReader>, DetectionResult>, IFrameworkApproach<T>
    {
        /// <summary>
        /// Gets the choices to iterate for detecting the changes of a revision pair.
        /// </summary>
        public abstract IList<IChoice<T>> Choices { get; }

        /// <summary>
        /// Gets the steps to take for detecting the changes of a revision pair.
        /// </summary>
        public virtual IList<long> Steps { get; }

        /// <summary>
        /// Gets or sets the current step.
        /// </summary>
        public virtual long CurrentStep { get; set; }

        /// <summary>
        /// Gets the heuristics to execute in the current step.
        /// </summary>
        long IFrameworkApproach<T>.Step { get; }

        /// <summary>
        /// Notifies and iterates the choices.
        /// </summary>
        protected override void CoreProceed()
        {
            this.CurrentStep = (long)StepInfo.None;
            this.BeginDetection();

            foreach (var step in this.Steps)
            {
                this.CurrentStep = step;
                this.BeginStep();
                this.OnStep();
                this.EndStep();
            }

            this.CurrentStep = (long)StepInfo.None;
            this.EndDetection();
            this.MatchingInfo.Clear();
        }

        /// <summary>
        /// Initializes the solution for detecting changes in a new revision pair.
        /// </summary>
        protected virtual void BeginDetection()
        {
            this.Choices.OfType<IChoiceWithBeginDetection<T>>().ForEach(delegate (IChoiceWithBeginDetection<T> c) { c.Approach = this; c.BeginDetection(); });
        }

        /// <summary>
        /// Initializes the current choice for a step in the detection of changes.
        /// </summary>
        protected virtual void BeginStep()
        {
            this.Choices.OfType<IChoiceWithBeginStep<T>>().ForEach(delegate (IChoiceWithBeginStep<T> c) { c.Approach = this; c.BeginStep(); });
        }

        /// <summary>
        /// Executes the solution under the context of a step in the detection of changes.
        /// </summary>
        public virtual void OnStep()
        {            
            this.Choices.ForEach(delegate (IChoice<T> c) { c.Approach = this; c.OnStep(); });
        }

        /// <summary>
        /// Finalizes the current choice after the completion of a step in the detection of changes.
        /// </summary>
        protected virtual void EndStep()
        {
            this.Choices.OfType<IChoiceWithEndStep<T>>().ForEach(delegate (IChoiceWithEndStep<T> c) { c.Approach = this; c.EndStep(); });
        }

        /// <summary>
        /// Finalizes the current choice after completing the detection of changes in a revision pair.
        /// </summary>
        protected virtual void EndDetection()
        {
            this.Choices.OfType<IChoiceWithEndDetection<T>>().ForEach(delegate (IChoiceWithEndDetection<T> c) { c.Approach = this; c.EndDetection(); });
        }

        /// <summary>
        /// Gets the structure to store the matches.
        /// </summary>
        public virtual MatchingInfo<T> MatchingInfo { get; private set; }
    }
}
