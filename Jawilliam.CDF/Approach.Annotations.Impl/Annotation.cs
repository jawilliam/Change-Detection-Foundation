using Jawilliam.CDF.Actions;
using Jawilliam.CDF.Approach.Services;
using System.Collections.Generic;

namespace Jawilliam.CDF.Approach.Annotations.Impl
{
    /// <summary>
    /// Structures the information available for a element version.
    /// </summary>
    /// <typeparam name="TElement">Type of the annotable elements.</typeparam>
    public class Annotation<TElement> : 
        IElementAnnotation<TElement>,
        IGumTreeElementAnnotation,
        IMatchingAnnotation<TElement>, 
        IHashingAnnotation, 
        IHierarchicalAbstractionAnnotation,
        IMcesAnnotation<TElement>
    {
        #region IElementAnnotation<TElement>

        /// <summary>
        /// Gets or sets the extended element.
        /// </summary>
        public virtual TElement Element { get; set; }

        /// <summary>
        /// Gets or sets a numeric identifier for the extended element.
        /// </summary>
        public virtual int Id { get; set; }

        #endregion

        #region IGumTreeElementAnnotation

        /// <summary>
        /// Gets or sets a numeric identifier for the extended element.
        /// </summary>
        int IGumTreeElementAnnotation.Id { get; set; }

        #endregion

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

        #region IMcesAnnotation

        /// <summary>
        /// Gets or sets whether or not the annotated node is "in order" or not.
        /// </summary>
        public virtual bool InOrder { get; set; }

        /// <summary>
        /// Stores the value of <see cref="Actions"/>.
        /// </summary>
        private IList<EditAction<TElement>> _actions;

        /// <summary>
        /// Gets the actions that affect the annotated element.
        /// </summary>
        public virtual IList<EditAction<TElement>> Actions
        {
            get => this._actions ?? (this._actions = new List<EditAction<TElement>>());
            set => this._actions = value;
        }

        /// <summary>
        /// Stores the value of <see cref="Children"/>.
        /// </summary>
        private IList<TElement> _children;

        /// <summary>
        /// Gets or sets the children of the annotated element.
        /// </summary>
        public virtual IList<TElement> Children
        {
            get => this._children ?? (this._children = new List<TElement>(10));
            set => this._children = value;
        }

        /// <summary>
        /// Gets or sets the parent of the annotated element.
        /// </summary>
        public virtual TElement Parent { get; set; }

        #endregion
    }
}
