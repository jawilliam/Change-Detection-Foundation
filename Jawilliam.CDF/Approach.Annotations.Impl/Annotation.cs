using Jawilliam.CDF.Approach.Services;
using System.Collections.Generic;

namespace Jawilliam.CDF.Approach.Annotations.Impl
{
    /// <summary>
    /// Structures the information available for a element version.
    /// </summary>
    /// <typeparam name="TElement">Type of the annotable elements.</typeparam>
    public class Annotation<TElement> : IElementAnnotation<TElement>, IMatchingAnnotation<TElement>, IHashingAnnotation, IHierarchicalAbstractionAnnotation
    {
        /// <summary>
        /// Gets or sets the extended element.
        /// </summary>
        public virtual TElement Element { get; set; }

        /// <summary>
        /// Stores the value of <see cref="Candidates"/>.
        /// </summary>
        private HashSet<MatchInfo<TElement>> _candidates;

        /// <summary>
        /// Gets or sets the candidate matches of the extended element. 
        /// </summary>
        public virtual HashSet<MatchInfo<TElement>> Candidates
        {
            get { return this._candidates ?? (this._candidates = new HashSet<MatchInfo<TElement>>()); }
            set { this._candidates = value; }
        }

        /// <summary>
        /// Gets or sets the discovered match for the extended element. 
        /// </summary>
        public virtual MatchInfo<TElement> Match { get; set; }

        /// <summary>
        /// Gets the matching partner of the extended element or null if it does not have anyone yet. 
        /// </summary>
        public virtual TElement Partner
        {
            get
            {
                if (this.Match == null)
                    return default(TElement);

                return object.Equals(this.Element, this.Match.Original) ? this.Match.Modified : this.Match.Original;
            }
        }

        /// <summary>
        /// Gets or sets the full content hash. 
        /// </summary>
        public virtual object FullHash { get; set; }

        /// <summary>
        /// Gets or sets the relevant content hash. 
        /// </summary>
        public virtual object EssentialHash { get; set; }

        /// <summary>
        /// Gets or sets the size of the annotated subtree. 
        /// </summary>
        public virtual int Size { get; set; }
    }
}
