using Jawilliam.CDF.Approach.Annotations;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Jawilliam.CDF.Approach.Services.Impl
{
    /// <summary>
    /// Base class to implement logic to execute under the context of a step in the detection of changes.
    /// </summary>
    /// <typeparam name="TElement">Type of the supported elements.</typeparam>
    /// <typeparam name="TAnnotation">Type of the information to store for each element.</typeparam>
    public class MatchingSetService<TElement, TAnnotation> : ServiceWithDependencies, IMatchingSetService<TElement> where TAnnotation : IMatchingAnnotation<TElement>, new()
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="serviceLocator">the mechanism for dynamically loading a typed service.</param>
        public MatchingSetService(IServiceLocator serviceLocator) : base(serviceLocator)
        {
        }

        /// <summary>
        /// Adds a (candidate) match both in the <see cref="Originals"/> and in the <see cref="Modifieds"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        public virtual void Pair(TElement original, TElement modified)
        {
            this.Pair(new MatchInfo<TElement>(default(int)) { Original = original, Modified = modified });
        }

        /// <summary>
        /// Adds a (candidate) match both in the <see cref="Originals"/> and in the <see cref="Modifieds"/>.
        /// </summary>
        /// <param name="matchInfo">the match.</param>
        public virtual void Pair(MatchInfo<TElement> matchInfo)
        {
            // Sets the match for the original.
            var originals = this.ServiceLocator.Originals<TElement, TAnnotation>();
            HashSet<MatchInfo<TElement>> partners = originals.Annotations[matchInfo.Original].Candidates;
            var target = partners.SingleOrDefault(p => object.Equals(p.Modified, matchInfo.Modified));
            if (target == null)
                partners.Add(matchInfo);
            else if(target != matchInfo)
                throw new ApplicationException($"There already is a match among these element versions.");

            // Sets the match for the modified.
            var modifieds = this.ServiceLocator.Modifieds<TElement, TAnnotation>();
            partners = modifieds.Annotations[matchInfo.Modified].Candidates;
            target = partners.SingleOrDefault(p => object.Equals(p.Original, matchInfo.Original));
            if (target == null)
                partners.Add(matchInfo);
            else if (target != matchInfo)
                throw new ApplicationException($"There already is a match among these element versions.");
        }

        /// <summary>
        /// Informs if there is a pair among two given versions.
        /// </summary>
        /// <param name="original">original version.</param>
        /// <param name="modified">modified version.</param>
        /// <returns>true if there is a pair among two given versions; otherwise, false.</returns>
        public virtual bool Paired(TElement original, TElement modified)
        {
            return this.ServiceLocator.Original<TElement, TAnnotation>(original).Candidates?.Any(c => object.Equals(c.Modified, modified)) ?? false;
        }

        /// <summary>
        /// Removes a (candidate) match both in the <see cref="Originals"/> and in the <see cref="Modifieds"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        public virtual void Unpair(TElement original, TElement modified)
        {
            // Removes the match for the original.
            var originals = this.ServiceLocator.Originals<TElement, TAnnotation>();
            HashSet<MatchInfo<TElement>> partners = originals.Annotations[original].Candidates;
            var target = partners?.SingleOrDefault(p => object.Equals(p.Modified, modified));
            if (target != null)
                partners.Remove(target);

            // Removes the match for the modified.
            var modifieds = this.ServiceLocator.Modifieds<TElement, TAnnotation>();
            partners = modifieds.Annotations[modified].Candidates;
            target = partners?.SingleOrDefault(p => object.Equals(p.Original, original));
            if (target != null)
                partners.Remove(target);
        }

        /// <summary>
        /// Notifies that, the two given versions have been definitively matched, which will be stored both in the <see cref="Originals"/> and in the <see cref="Modifieds"/>.
        /// </summary>
        /// <param name="original">original element.</param>
        /// <param name="modified">modified element.</param>
        public virtual void Partners(TElement original, TElement modified)
        {
            var originals = this.ServiceLocator.Originals<TElement, TAnnotation>();
            var matchInfo = originals.Annotations[original].Candidates.SingleOrDefault(c => object.Equals(c.Original, original) && object.Equals(c.Modified, modified));
            this.Partners(matchInfo ?? new MatchInfo<TElement>(default(int)) { Original = original, Modified = modified });
        }

        /// <summary>
        /// Notifies that, the two given versions have been definitively matched, which will be stored both in the <see cref="Originals"/> and in the <see cref="Modifieds"/>.
        /// </summary>
        /// <param name="matchInfo">the match.</param>
        public virtual void Partners(MatchInfo<TElement> matchInfo)
        {
            // logic for the original's annotations.
            var originals = this.ServiceLocator.Originals<TElement, TAnnotation>();
            var partners = originals.Annotations[matchInfo.Original].Candidates;
            foreach (var p in partners.Where(p => !object.Equals(p.Modified, matchInfo.Modified)).ToList())
            {
                this.Unpair(matchInfo.Original, p.Modified);
            }

            // logic for the original's annotations.
            var modifieds = this.ServiceLocator.Modifieds<TElement, TAnnotation>();
            partners = modifieds.Annotations[matchInfo.Modified].Candidates;
            foreach (var p in partners.Where(p => !object.Equals(p.Original, matchInfo.Original)).ToList())
            {
                this.Unpair(p.Original, matchInfo.Modified);
            }

            // adds the match (in case it does not exist).
            this.Pair(matchInfo);
            originals.Annotations[matchInfo.Original].Match = originals.Annotations[matchInfo.Original].Candidates.Single();
            modifieds.Annotations[matchInfo.Modified].Match = modifieds.Annotations[matchInfo.Modified].Candidates.Single();

            // Postconditions.
            Debug.Assert(originals.Annotations[matchInfo.Original].Candidates.Single() == modifieds.Annotations[matchInfo.Modified].Candidates.Single());
            Debug.Assert(originals.Annotations[matchInfo.Original].Match == modifieds.Annotations[matchInfo.Modified].Match && originals.Annotations[matchInfo.Original].Match != null);
            Debug.Assert(object.Equals(originals.Annotations[matchInfo.Original].Match.Original, matchInfo.Original));
            Debug.Assert(object.Equals(originals.Annotations[matchInfo.Original].Match.Modified, matchInfo.Modified));
        }

        ///// <summary>
        ///// Informs if an original version has not (candidate) matches.
        ///// </summary>
        ///// <param name="element">original version.</param>
        ///// <returns>true if the original version has not matches, false otherwise.</returns>
        //public virtual bool UnpairedOriginal(TElement element)
        //{
        //    return this.ServiceLocator.Original<TElement, TAnnotation>(element).Candidates.Count == 0;
        //}

        ///// <summary>
        ///// Informs if an modified version has not (candidate) matches.
        ///// </summary>
        ///// <param name="element">modified version.</param>
        ///// <returns>true if the modified version has not matches, false otherwise.</returns>
        //public virtual bool UnpairedModified(TElement element)
        //{
        //    return this.ServiceLocator.Modified<TElement, TAnnotation>(element).Candidates.Count == 0;
        //}

        ///// <summary>
        ///// Informs if an original version has not matching partner.
        ///// </summary>
        ///// <param name="element">original version.</param>
        ///// <returns>true if the original version has not matching partner, false otherwise.</returns>
        //public virtual bool UnmatchedOriginal(TElement element)
        //{
        //    return this.ServiceLocator.Original<TElement, TAnnotation>(element).Match == null;
        //}

        ///// <summary>
        ///// Informs if an modified version has not matching partner.
        ///// </summary>
        ///// <param name="element">modified version.</param>
        ///// <returns>true if the modified version has not matching partner, false otherwise.</returns>
        //public virtual bool UnmatchedModified(TElement element)
        //{
        //    return this.ServiceLocator.Modified<TElement, TAnnotation>(element).Match == null;
        //}

        /// <summary>
        /// Stores the value of <see cref="Originals"/>.
        /// </summary>
        private IMatchingVersionService<TElement> _originals;

        /// <summary>
        /// Exposes matching set functionalities related to the original elements.
        /// </summary>
        public virtual IMatchingVersionService<TElement> Originals
        {
            get { return this._originals ?? (this._originals = new MatchingVersionService(this, (TElement element) => this.ServiceLocator.Original<TElement, TAnnotation>(element))); }
        }

        /// <summary>
        /// Stores the value of <see cref="Modifieds"/>.
        /// </summary>
        private IMatchingVersionService<TElement> _modifieds;

        /// <summary>
        /// Exposes matching set functionalities related to the modified elements.
        /// </summary>
        public virtual IMatchingVersionService<TElement> Modifieds
        {
            get { return this._modifieds ?? (this._modifieds = new MatchingVersionService(this, (TElement element) => this.ServiceLocator.Modified<TElement, TAnnotation>(element))); }
        }

        /// <summary>
        /// Implements the logic of <see cref="IMatchingVersionService{TElement}"/> internally used by a <see cref="MatchingSetService{TElement, TAnnotation}"/>.
        /// </summary>
        protected class MatchingVersionService : IMatchingVersionService<TElement>
        {
            /// <summary>
            /// Initializes the instance.
            /// </summary>
            /// <param name="matchingSet">container matching set.</param>
            /// <param name="getVersion">Logic to access the annotation corresponding to a given element.</param>
            public MatchingVersionService(MatchingSetService<TElement, TAnnotation> matchingSet, Func<TElement, TAnnotation> getVersion)
            {
                this.MatchingSet = matchingSet ?? throw new ArgumentNullException(nameof(matchingSet));
                this.GetVersion = getVersion ?? throw new ArgumentNullException(nameof(getVersion));
            }

            /// <summary>
            /// Gets the container matching set.
            /// </summary>
            public MatchingSetService<TElement, TAnnotation> MatchingSet { get; private set; }

            /// <summary>
            /// Gets the annotation corresponding to a given element.
            /// </summary>
            public Func<TElement, TAnnotation> GetVersion { get; private set; }

            /// <summary>
            /// Informs if an element has not (candidate) matches.
            /// </summary>
            /// <param name="element">element of interest.</param>
            /// <returns>true if the element has not matches, false otherwise.</returns>
            public virtual bool Unpaired(TElement element)
            {
                return this.GetVersion(element).Candidates.Count == 0;
            }

            /// <summary>
            /// Informs if an version has not matching partner.
            /// </summary>
            /// <param name="element">element of interest.</param>
            /// <returns>true if the element has not matching partner, false otherwise.</returns>
            public virtual bool Unmatched(TElement element)
            {
                return this.GetVersion(element).Match == null;
            }

            /// <summary>
            /// Disables any possibility of matching the given element.
            /// </summary>
            /// <param name="element">element of interest.</param>
            /// <remarks>this is the inverse of <see cref="EnableMatching(TElement)"/>.</remarks>
            public virtual void DisableMatching(TElement element)
            {
                this.GetVersion(element).CanMatch = false;
            }

            /// <summary>
            /// Enables the given element to be matched.
            /// </summary>
            /// <param name="element">element of interest.</param>
            /// <remarks>this is the inverse of <see cref="DisableMatching(TElement)"/>.</remarks>
            public virtual void EnableMatching(TElement element)
            {
                this.GetVersion(element).CanMatch = true;
            }
        }
    }
}
