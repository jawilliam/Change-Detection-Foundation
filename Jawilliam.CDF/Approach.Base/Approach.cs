using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Jawilliam.CDF.Approach.Base
{
    /// <summary>
    /// Base class of an approach or algorithm of change detection.
    /// </summary>
    /// <typeparam name="TElement">Type of the supported elements.</typeparam>
    /// <typeparam name="TRevision">Type of the comparing versions.</typeparam>
    public abstract class Approach<TElement, TRevision> : Procedure<LoadRevisionPairDelegate<TRevision>, DetectionResult<TRevision>>, IApproach<TElement, TRevision>
    {
        /// <summary>
        /// Gets the choices to iterate for detecting the changes of a revision pair.
        /// </summary>
        public abstract IList<IChoice<TElement, TRevision>> Choices { get; }

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
        long IApproach<TElement, TRevision>.Step => this.CurrentStep;

        /// <summary>
        /// Notifies and iterates the choices.
        /// </summary>
        protected override void CoreProceed()
        {
            this.CurrentStep = (long)StepInfo.None;
            this.BeginDetection();

            foreach (var step in (this.Steps ?? new List<long>()))
            {
                this.CurrentStep = step;
                this.BeginStep();
                this.OnStep();
                this.EndStep();
            }

            this.CurrentStep = (long)StepInfo.None;
            this.EndDetection();
        }

        /// <summary>
        /// Gets the output information.
        /// </summary>
        public override DetectionResult<TRevision> Result { get => base.Result ?? (base.Result = new DetectionResult<TRevision>()); protected set => base.Result = value; }

        /// <summary>
        /// Initializes the solution for detecting changes in a new revision pair.
        /// </summary>
        protected virtual void BeginDetection()
        {
            this.MatchingInfo = null;
            this.Result = null;

            TRevision original, modified;
            if (this.Args == null)
                throw new ApplicationException("Unspecified args.");

            if (!this.Args(out original, out modified))
                throw new ApplicationException("Could not load the revision pair.");
            this.Result.Original = original;
            this.Result.Modified = modified;

            this.Choices.OfType<IChoiceWithBeginDetection<TElement, TRevision>>().ForEach(delegate (IChoiceWithBeginDetection<TElement, TRevision> c) 
            {
                c.Approach = this;
                c.BeginDetection();
            });
        }

        /// <summary>
        /// Initializes the current choice for a step in the detection of changes.
        /// </summary>
        protected virtual void BeginStep()
        {
            this.Choices.OfType<IChoiceWithBeginStep<TElement, TRevision>>().ForEach(delegate (IChoiceWithBeginStep<TElement, TRevision> c) { c.Approach = this; c.BeginStep(); });
        }

        /// <summary>
        /// Executes the solution under the context of a step in the detection of changes.
        /// </summary>
        public virtual void OnStep()
        {            
            this.Choices.ForEach(delegate (IChoice<TElement, TRevision> c) { c.Approach = this; c.OnStep(); });
        }

        /// <summary>
        /// Finalizes the current choice after the completion of a step in the detection of changes.
        /// </summary>
        protected virtual void EndStep()
        {
            this.Choices.OfType<IChoiceWithEndStep<TElement, TRevision>>().ForEach(delegate (IChoiceWithEndStep<TElement, TRevision> c) { c.Approach = this; c.EndStep(); });
        }

        /// <summary>
        /// Finalizes the current choice after completing the detection of changes in a revision pair.
        /// </summary>
        protected virtual void EndDetection()
        {
            this.Choices.OfType<IChoiceWithEndDetection<TElement, TRevision>>().ForEach(delegate (IChoiceWithEndDetection<TElement, TRevision> c) { c.Approach = this; c.EndDetection(); });
        }

        /// <summary>
        /// Stores the value of <see cref="MatchingInfo"/>.
        /// </summary>
        private MatchingInfo<TElement> _matchingInfo;

        /// <summary>
        /// Gets the structure to store the matches.
        /// </summary>
        public virtual MatchingInfo<TElement> MatchingInfo
        {
            get { return this._matchingInfo ?? (this._matchingInfo = new MatchingInfo<TElement>()); }
            private set { this._matchingInfo = value; }
        }

        /// <summary>
        /// Gets a typed service in case some one exists.
        /// </summary>
        /// <typeparam name="TService">the type of the requested service.</typeparam>
        /// <returns>a typed service in case some one exists, otherwise returns null</returns>
        public abstract TService GetService<TService>();

        /// <summary>
        /// Gets a typed service in case some one exists.
        /// </summary>
        /// <typeparam name="TService">the type of the requested service.</typeparam>
        /// <returns>a typed service in case some one exists, otherwise throws an exception.</returns>
        public virtual TService GetServiceOrThrowsException<TService>()
        {
            var service = this.GetService<TService>();
            return !object.Equals(service, typeof(TService))
                ? service
                : throw new ApplicationException($"{typeof(TService).FullName} service not found.");
        }
    }
}
