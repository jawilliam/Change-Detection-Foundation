using Jawilliam.CDF.Approach.Annotations;
using Jawilliam.CDF.Approach.Criterions;
using Jawilliam.CDF.Approach.Criterions.Simetric;
using Jawilliam.CDF.Approach.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Jawilliam.CDF.Approach.Choices
{
    /// <summary>
    /// Base class for implementing matching discovery choices based on a <see cref="IMatcher{TElement}"/>.
    /// </summary>
    /// <typeparam name="TElement">Type of the supported elements.</typeparam>
    /// <typeparam name="TAnnotation">Type of the information to store for each element.</typeparam>
    public partial class MatchingTieBreakChoice<TElement, TAnnotation> : Choice<TElement>
        where TAnnotation : IMatchingAnnotation<TElement>, IElementAnnotation<TElement>, IHierarchicalAbstractionAnnotation, new()
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="approach">the solution wherein the current choice will be called</param>
        /// <param name="metric">the similarity metric.</param>
        public MatchingTieBreakChoice(IApproach<TElement> approach) : base(approach)
        {
        }

        /// <summary>
        /// Stores the value of <see cref="Metric"/>.
        /// </summary>
        private ISimetric<TElement> _metric;

        /// <summary>
        /// Gets the similarity metric.
        /// </summary>
        public ISimetric<TElement> Metric
        {
            get => this._metric ?? (this._metric = new DiceCoefficientSimetric<TElement>());
            set { this._metric = value ?? throw new ArgumentNullException(nameof(value)); }
        }

        ///// <summary>
        ///// Gets or sets the similarity threshold.
        ///// </summary>
        //public virtual double Threshold { get; set; }

        /// <summary>
        /// Stores the value of <see cref="Traverse"/>.
        /// </summary>
        private Func<TElement, IAnnotationSetService<TElement, TAnnotation>, IEnumerable<TElement>> _traverse;

        /// <summary>
        /// Gets the strategy to traverse the original AST.
        /// </summary>
        public Func<TElement, IAnnotationSetService<TElement, TAnnotation>, IEnumerable<TElement>> Traverse
        {
            get => this._traverse ?? (this._traverse = (o, annSet) => o.BreadthFirstOrder(o1 => this.Approach.HierarchicalAbstraction<TElement, TAnnotation>().Children(o1, annSet)));
            set { this._traverse = value ?? throw new ArgumentNullException(nameof(value)); }
        }

        /// <summary>
        /// Gets the steps wherein the current choice will be actively executed.
        /// </summary>
        protected override IList<long> SupportedSteps => new List<long>
        {
            (long)(StepInfo.Equality | StepInfo.Subtree)
        };

        /// <summary>
        /// Core implementation of <see cref="OnStep"/>.
        /// </summary>
        /// <remarks>By default, it implements a customizable MTDiff's "IdenticalSubtree" optimization.</remarks>
        protected override void CoreOnStep()
        {
            var semanticAbstraction = this.Approach.SemanticAbstraction();
            var hierarchicalAbstraction = this.Approach.HierarchicalAbstraction<TElement, TAnnotation>();
            var matchingSet = this.Approach.MatchingSet();

            var originals = this.Approach.Originals<TElement, TAnnotation>();
            var modifieds = this.Approach.Modifieds<TElement, TAnnotation>();

            var candidates = this.Traverse(this.Approach.Result.Original, originals)
                .SelectMany(o =>
                {
                    var oAnnotation = originals.Annotations[o];
                    return oAnnotation.Candidates?.Count > 1 ? oAnnotation.Candidates : new HashSet<MatchInfo<TElement>>();
                });

            var parentSimilarities = from c in candidates.Where(c => c.Criterion == (int)MatchInfoCriterions.IdenticalFullHash)
                                     let pOriginalAnnotation = originals.Annotations[hierarchicalAbstraction.Parent(c.Original, originals)]
                                     let pModifiedAnnotation = modifieds.Annotations[hierarchicalAbstraction.Parent(c.Modified, modifieds)]
                                     select new
                                     {
                                         Candidate = c,
                                         Similarity = this.Metric.GetSimilarity(pOriginalAnnotation.Element.Leaves(o1 => hierarchicalAbstraction.Children(o1, originals), o1 => hierarchicalAbstraction.IsLeaf(o1, originals)).Where(semanticAbstraction.IsEssential),
                                                                                pModifiedAnnotation.Element.Leaves(o1 => hierarchicalAbstraction.Children(o1, modifieds), o1 => hierarchicalAbstraction.IsLeaf(o1, modifieds)).Where(semanticAbstraction.IsEssential)),
                                         Ratio = Math.Min(pOriginalAnnotation.Size, pModifiedAnnotation.Size) * 1d / Math.Max(pOriginalAnnotation.Size, pModifiedAnnotation.Size),
                                         MaxSize = Math.Max(pOriginalAnnotation.Size, pModifiedAnnotation.Size),
                                     };

            var list = parentSimilarities.OrderByDescending(c => c.MaxSize).ThenByDescending(c => c.Similarity).ThenByDescending(c => c.Ratio).ToList();
            foreach (var c in parentSimilarities.OrderByDescending(c => c.Similarity).ThenByDescending(c => c.Ratio).ToList())
            {
                if(matchingSet.Originals.Unmatched(c.Candidate.Original) && matchingSet.Modifieds.Unmatched(c.Candidate.Modified))
                    matchingSet.Partners(c.Candidate);
            }
        }
    }
}
