using Jawilliam.CDF.Actions;
using Jawilliam.CDF.Approach.Annotations;
using Jawilliam.CDF.Approach.Impl;
using Jawilliam.CDF.Approach.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jawilliam.CDF.Approach.Choices
{
    /// <summary>
    /// Implements a differencing computing according to the Minimum Conforming Edit Script of Chawathe et al.
    /// </summary>
    /// <typeparam name="TElement">Type of the supported elements.</typeparam>
    /// <typeparam name="TAnnotation">Type of the information to store for each element.</typeparam>
    public class McesReportChoice<TElement, TAnnotation> : Choice<TElement> where TAnnotation : IElementAnnotation<TElement>, IGumTreeElementAnnotation, IMatchingAnnotation<TElement>, IMcesAnnotation<TElement>, new()
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="approach">the solution wherein the current choice will be called</param>
        /// <param name="criterion">the matching criterion.</param>
        public McesReportChoice(IApproach<TElement> approach) : base(approach)
        {
        }

        /// <summary>
        /// Gets the steps wherein the current choice will be actively executed.
        /// </summary>
        protected override IList<long> SupportedSteps => new List<long>
        {
            (long)(StepInfo.ReportPhase)
        };

        /// <summary>
        /// Core implementation of <see cref="OnStep"/>.
        /// </summary>
        /// <remarks>Reports the actions computed by <see cref="McesDifferencingChoice{TElement, TAnnotation}"/>.</remarks>
        protected override void CoreOnStep()
        {
            var hierarchicalAbstraction = this.Approach.HierarchicalAbstraction();
            var textualAbstraction = this.Approach.TextualAbstraction();
            foreach (var modified in this.Approach.Result.Modified.BreadthFirstOrder(hierarchicalAbstraction.Children))
            {
                var original = this.Approach.Modified<TElement, TAnnotation>(modified).Partner;
                var oAnnotation = this.Approach.Original<TElement, TAnnotation>(original);

                // Inserts
                foreach (var insert in oAnnotation.Actions.OfType<EditInsert<TElement>>().Where(i => object.Equals(i.Element, original)))
                {
                    this.Approach.Result.Actions.Add(new InsertOperationDescriptor
                    {
                        Element = new ElementVersion
                        {
                            Id = ((IElementAnnotation<TElement>)oAnnotation).Id.ToString(CultureInfo.InvariantCulture),
                            Label = hierarchicalAbstraction.Label(insert.Element).ToString(CultureInfo.InvariantCulture),
                            Value = textualAbstraction.FullText(insert.Element)
                        },
                        Position = insert.Position,
                        Parent = new ElementVersion
                        {
                            Id = ((IElementAnnotation<TElement>)this.Approach.Original<TElement, TAnnotation>(insert.Parent)).Id.ToString(CultureInfo.InvariantCulture),
                            Label = hierarchicalAbstraction.Label(insert.Parent).ToString(CultureInfo.InvariantCulture),
                            Value = textualAbstraction.FullText(insert.Parent)
                        }
                    });
                }

                // Updates
                foreach (var update in oAnnotation.Actions.OfType<EditUpdate<TElement>>().Where(u => object.Equals(u.Element, original)))
                {
                    this.Approach.Result.Actions.Add(new UpdateOperationDescriptor
                    {
                        Element = new ElementVersion
                        {
                            Id = ((IElementAnnotation<TElement>)oAnnotation).Id.ToString(CultureInfo.InvariantCulture),
                            Label = hierarchicalAbstraction.Label(update.Element).ToString(CultureInfo.InvariantCulture),
                            Value = textualAbstraction.FullText(update.Element)
                        },
                        Value = hierarchicalAbstraction.Value(update.NewElement)?.ToString(),
                    });
                }

                // Moves
                foreach (var move in oAnnotation.Actions.OfType<EditMove<TElement>>().Where(m => object.Equals(m.Element, original)))
                {
                    this.Approach.Result.Actions.Add(new MoveOperationDescriptor
                    {
                        Element = new ElementVersion
                        {
                            Id = ((IElementAnnotation<TElement>)oAnnotation).Id.ToString(CultureInfo.InvariantCulture),
                            Label = hierarchicalAbstraction.Label(move.Element).ToString(CultureInfo.InvariantCulture),
                            Value = textualAbstraction.FullText(move.Element)
                        },
                        Position = move.Position,
                        Parent = new ElementVersion
                        {
                            Id = ((IElementAnnotation<TElement>)this.Approach.Original<TElement, TAnnotation>(move.Parent)).Id.ToString(),
                            Label = hierarchicalAbstraction.Label(move.Parent).ToString(CultureInfo.InvariantCulture),
                            Value = textualAbstraction.FullText(move.Parent)
                        }
                    });
                }

                // Aligns
                foreach (var align in oAnnotation.Actions.OfType<EditAlign<TElement>>().Where(a => object.Equals(a.Element, original)))
                {
                    this.Approach.Result.Actions.Add(new AlignOperationDescriptor
                    {
                        Element = new ElementVersion
                        {
                            Id = ((IElementAnnotation<TElement>)oAnnotation).Id.ToString(CultureInfo.InvariantCulture),
                            Label = hierarchicalAbstraction.Label(align.Element).ToString(CultureInfo.InvariantCulture),
                            Value = textualAbstraction.FullText(align.Element)
                        },
                        Position = align.Position
                    });
                }
            }

            // Deletes
            foreach (var original in this.Approach.Result.Original.PostOrder(hierarchicalAbstraction.Children))
            {
                var oAnnotation = this.Approach.Original<TElement, TAnnotation>(original);
                foreach (var delete in oAnnotation.Actions.OfType<EditDelete<TElement>>().Where(i => object.Equals(i.Element, original)))
                {
                    this.Approach.Result.Actions.Add(new DeleteOperationDescriptor
                    {
                        Element = new ElementVersion
                        {
                            Id = ((IElementAnnotation<TElement>)oAnnotation).Id.ToString(CultureInfo.InvariantCulture),
                            Label = hierarchicalAbstraction.Label(delete.Element).ToString(CultureInfo.InvariantCulture),
                            Value = textualAbstraction.FullText(delete.Element)
                        }
                    });
                }
            }

            foreach (var original in this.Approach.Result.Original.PreOrder(hierarchicalAbstraction.Children))
            {
                var oAnnotation = this.Approach.Original<TElement, TAnnotation>(original);
                if (oAnnotation.Partner != null)
                {
                    var mAnnotation = this.Approach.Modified<TElement, TAnnotation>(oAnnotation.Partner);
                    this.Approach.Result.Matches.Add(new MatchDescriptor
                    {
                        Original = new ElementVersion
                        {
                            Id = ((IElementAnnotation<TElement>)oAnnotation).Id.ToString(CultureInfo.InvariantCulture),
                            Label = hierarchicalAbstraction.Label(original).ToString(CultureInfo.InvariantCulture),
                            Value = textualAbstraction.FullText(original)
                        },
                        Modified = new ElementVersion
                        {
                            Id = ((IElementAnnotation<TElement>)mAnnotation).Id.ToString(CultureInfo.InvariantCulture),
                            Label = hierarchicalAbstraction.Label(oAnnotation.Partner).ToString(CultureInfo.InvariantCulture),
                            Value = textualAbstraction.FullText(oAnnotation.Partner)
                        }
                    });
                }
            }
        }
    }
}
