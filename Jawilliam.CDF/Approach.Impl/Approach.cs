using Jawilliam.CDF.Approach.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Jawilliam.CDF.Approach.Impl
{
    /// <summary>
    /// Base class of an approach or algorithm of change detection.
    /// </summary>
    /// <typeparam name="TElement">Type of the supported elements.</typeparam>
    public abstract class Approach<TElement> : Procedure<LoadRevisionPairDelegate<TElement>, DetectionResult<TElement>>, IApproach<TElement>
    {
        /// <summary>
        /// Gets the choices to iterate for detecting the changes of a revision pair.
        /// </summary>
        public abstract IList<IChoice> Choices { get; }

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
        long IApproach<TElement>.Step => this.CurrentStep;

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
        public override DetectionResult<TElement> Result { get => base.Result ?? (base.Result = new DetectionResult<TElement>()); protected set => base.Result = value; }

        /// <summary>
        /// Initializes the solution for detecting changes in a new revision pair.
        /// </summary>
        protected virtual void BeginDetection()
        {
            ///TODO: //this.getsethis.AnnotationSet = null;
            this.Result = null;

            TElement original, modified;
            if (this.Args == null)
                throw new ApplicationException("Unspecified args.");

            if (!this.Args(out original, out modified))
                throw new ApplicationException("Could not load the revision pair.");
            this.Result.Original = original;
            this.Result.Modified = modified;

            this.Services.Values.OfType<IBeginDetection>().OrderBy(s => ((IService)s).Id).ForEach(c => c.BeginDetection());
            this.Choices.OfType<IBeginDetection>().ForEach(c => c.BeginDetection());

            var matchingSet = this.MatchingSet(false);
            if (matchingSet != null)
                matchingSet.Partners(new MatchInfo<TElement>((int)MatchInfoCriterions.RootsAlwaysMatch) { Original = this.Result.Original, Modified = this.Result.Modified } );
        }

        /// <summary>
        /// Initializes the current choice for a step in the detection of changes.
        /// </summary>
        protected virtual void BeginStep()
        {
            this.Services.Values.OfType<IBeginStep>().OrderBy(s => ((IService)s).Id).ForEach(c => c.BeginStep());
            this.Choices.OfType<IBeginStep>().ForEach(c => c.BeginStep());
        }

        /// <summary>
        /// Executes the solution under the context of a step in the detection of changes.
        /// </summary>
        public virtual void OnStep()
        {            
            this.Choices.ForEach(c => c.OnStep());
        }

        /// <summary>
        /// Finalizes the current choice after the completion of a step in the detection of changes.
        /// </summary>
        protected virtual void EndStep()
        {
            this.Choices.OfType<IEndStep>().ForEach(c => c.EndStep());
            this.Services.Values.OfType<IEndStep>().OrderBy(s => ((IService)s).Id).ForEach(c => c.EndStep());
        }

        /// <summary>
        /// Finalizes the current choice after completing the detection of changes in a revision pair.
        /// </summary>
        protected virtual void EndDetection()
        {
            this.Choices.OfType<IEndDetection>().ForEach(c => c.EndDetection());
            this.Services.Values.OfType<IEndDetection>().OrderBy(s => ((IService)s).Id).ForEach(c => c.EndDetection());
        }

        /// <summary>
        /// Stores the value of <see cref="Services"/>.
        /// </summary>
        private Dictionary<int, IService> _services;

        /// <summary>
        /// Contains those services that have been explicitly registered. 
        /// </summary>
        protected virtual Dictionary<int, IService> Services
        {
            get => this._services ?? (this._services = new Dictionary<int, IService>());
            set => this._services = value;
        }

        /// <summary>
        /// Gets a typed service in case some one exists.
        /// </summary>
        /// <typeparam name="TService">the type of the requested service.</typeparam>
        /// <param name="id">identifies the requested service.</param>
        /// <returns>a typed service in case some one exists, otherwise returns null</returns>
        public virtual TService GetService<TService>(int id) where TService : IService
        {
            return this.Services.ContainsKey(id) ? (TService)this.Services[id] : default(TService);
        }

        /// <summary>
        /// Gets a typed service in case some one exists.
        /// </summary>
        /// <typeparam name="TService">the type of the requested service.</typeparam>
        /// <param name="id">identifies the requested service.</param>
        /// <returns>a typed service in case some one exists, otherwise throws an exception.</returns>
        public virtual TService GetServiceOrThrowsException<TService>(int id) where TService : IService
        {
            var service = this.GetService<TService>(id);
            return service != null
                ? service
                : throw new ApplicationException($"{typeof(TService).FullName} service not found.");
        }

        /// <summary>
        /// Detects the changes occurred in a revision pair.
        /// </summary>
        /// <param name="args">a mechanism for loading the versions to compare.</param>
        public virtual DetectionResult<TElement> GetChanges(LoadRevisionPairDelegate<TElement> args)
        {
            ((IProcedure<LoadRevisionPairDelegate<TElement>, DetectionResult<TElement>>)this).Proceed(args);
            return this.Result;
        }
    }
}
