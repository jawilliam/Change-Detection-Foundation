using Jawilliam.CDF.Actions;
using Jawilliam.CDF.Approach.Annotations;
using System.Linq;

namespace Jawilliam.CDF.Approach.Services.Impl
{
    /// <summary>
    /// Implements the support for managing edit scripts, for example when generating a "Minimum Conforming Edit Script".
    /// </summary>
    /// <typeparam name="TElement">Type of the supported elements.</typeparam>
    /// <typeparam name="TAnnotation">Type of the information to store for each element.</typeparam>
    public class EditScriptService<TElement, TAnnotation> : ServiceWithDependencies<IApproach<TElement>>, IEditScriptService<TElement> where TAnnotation : IMcesAnnotation<TElement>, new()
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="serviceLocator">the mechanism for dynamically loading a typed service.</param>
        public EditScriptService(IApproach<TElement> serviceLocator) : base(serviceLocator)
        {
        }

        /// <summary>
        /// Initializes the current service for a edit script generation. Unlike the <see cref="IBeginStep"/> or <see cref="IBeginDetection"/>, this is supposed to be invoked by <see cref="IChoice.OnStep"/>. 
        /// </summary>
        public virtual void Begin()
        {
            var hierachicalAbstraction = this.ServiceLocator.HierarchicalAbstraction();
            foreach (var original in this.ServiceLocator.Result.Original.PostOrder(hierachicalAbstraction.Children))
            {
                var oAnnotation = this.ServiceLocator.Original<TElement, TAnnotation>(original);
                oAnnotation.Children = hierachicalAbstraction.Children(original).ToList();
                foreach (var oChild in oAnnotation.Children)
                {
                    this.ServiceLocator.Original<TElement, TAnnotation>(oChild).Parent = original;
                }
            }

            foreach (var modified in this.ServiceLocator.Result.Modified.PostOrder(hierachicalAbstraction.Children))
            {
                var mAnnotation = this.ServiceLocator.Modified<TElement, TAnnotation>(modified);
                mAnnotation.Children = hierachicalAbstraction.Children(modified).ToList();
                foreach (var mChild in mAnnotation.Children)
                {
                    this.ServiceLocator.Modified<TElement, TAnnotation>(mChild).Parent = modified;
                }
            }
        }

        /// <summary>
        /// Finalizes the current service after a edit script generation. Unlike the <see cref="IEndStep"/> or <see cref="IEndDetection"/>, this is supposed to be invoked by <see cref="IChoice.OnStep"/>.
        /// </summary>
        public virtual void End()
        {
            var hierachicalAbstraction = this.ServiceLocator.HierarchicalAbstraction();
            foreach (var original in this.ServiceLocator.Result.Original.PostOrder(hierachicalAbstraction.Children))
            {
                var oAnnotation = this.ServiceLocator.Original<TElement, TAnnotation>(original);
                foreach (var oChild in oAnnotation.Children)
                {
                    this.ServiceLocator.Original<TElement, TAnnotation>(oChild).Parent = default(TElement);
                }
                oAnnotation.Children = null;
            }

            foreach (var modified in this.ServiceLocator.Result.Modified.PostOrder(hierachicalAbstraction.Children))
            {
                var mAnnotation = this.ServiceLocator.Modified<TElement, TAnnotation>(modified);
                foreach (var mChild in mAnnotation.Children)
                {
                    this.ServiceLocator.Modified<TElement, TAnnotation>(mChild).Parent = default(TElement);
                }
                mAnnotation.Children = null;
            }
        }

        /// <summary>
        /// Inserts a copy of a (modified) element in the original parent.
        /// </summary>
        /// <param name="modified">(modified) element whose copy will be inserted.</param>
        /// <param name="position">as the k-th child of,</param>
        /// <param name="parent">the given (original) parent.</param>
        public virtual void Insert(TElement modified, int position, TElement parent)
        {
            this.Insert(modified, position, parent, true);
        }

        /// <summary>
        /// Inserts a copy of a (modified) element in the original parent.
        /// </summary>
        /// <param name="modified">(modified) element whose copy will be inserted.</param>
        /// <param name="position">as the k-th child of,</param>
        /// <param name="parent">the given (original) parent.</param>
        /// <param name="addActions">indicates if the actions will be registered.</param>
        public virtual void Insert(TElement modified, int position, TElement parent, bool addActions)
        {
            var mAnnotation = this.ServiceLocator.Modified<TElement, TAnnotation>(modified);
            var pAnnotation = this.ServiceLocator.Original<TElement, TAnnotation>(parent);

            this.ServiceLocator.Originals<TElement, TAnnotation>().Init(new[] { modified });
            var oAnnotation = this.ServiceLocator.Original<TElement, TAnnotation>(modified);

            this.ServiceLocator.MatchingSet().Partners(new MatchInfo<TElement>((int)MatchInfoId.Insert) { Original = modified, Modified = modified });
            pAnnotation.Children.Insert(position, modified);
            oAnnotation.Parent = parent;

            if (addActions)
            {
                var insertAction = new EditInsert<TElement> { Element = modified, Position = position, Parent = parent };
                oAnnotation.Actions.Add(insertAction);
                pAnnotation.Actions.Add(insertAction);
            }
        }

        /// <summary>
        /// Deletes a (original) element from its parent.
        /// </summary>
        /// <param name="original">modified version to insert,</param>
        public virtual void Delete(TElement original)
        {
            this.Delete(original, true);
        }

        /// <summary>
        /// Deletes a (original) element from its parent.
        /// </summary>
        /// <param name="original">modified version to insert,</param>
        /// <param name="addActions">indicates if the actions will be registered.</param>
        public virtual void Delete(TElement original, bool addActions)
        {
            var oAnnotation = this.ServiceLocator.Original<TElement, TAnnotation>(original);
            var pAnnotation = this.ServiceLocator.Original<TElement, TAnnotation>(this.OriginalsHierarchicalAbstraction.Parent(original));
            pAnnotation.Children.Remove(original);
            oAnnotation.Parent = default(TElement);

            if (addActions)
            {
                var deleteAction = new EditDelete<TElement> { Element = original };
                oAnnotation.Actions.Add(deleteAction);
                pAnnotation.Actions.Add(deleteAction);
            }
        }

        /// <summary>
        /// Updates the original version of an element, so that it is equal to its modified version.
        /// </summary>
        /// <param name="original">original version.</param>
        /// <param name="modified">modified version.</param>
        public virtual void Update(TElement original, TElement modified)
        {
            var oAnnotation = this.ServiceLocator.Original<TElement, TAnnotation>(original);
            var mAnnotation = this.ServiceLocator.Modified<TElement, TAnnotation>(modified);

            var updateAction = new EditUpdate<TElement> { Element = original, NewElement = modified };
            oAnnotation.Actions.Add(updateAction);
            mAnnotation.Actions.Add(updateAction);
        }

        /// <summary>
        /// Aligns an (original) element under its parent.
        /// </summary>
        /// <param name="original">(original) element to align,</param>
        /// <param name="position">as the k-th child of (its parent).</param>
        public virtual void Align(TElement original, int position)
        {
            var parent = this.OriginalsHierarchicalAbstraction.Parent(original);
            var pAnnotation = this.ServiceLocator.Original<TElement, TAnnotation>(parent);
            int fromCurrentKChild = pAnnotation.Children.IndexOf(original);
            pAnnotation.Children.Remove(original);
            pAnnotation.Children.Insert(fromCurrentKChild < position ? position - 1 : position, original);
            //this.Insert(original, fromCurrentKChild < position ? position - 1 : position, parent, false);

            var alignAction = new EditAlign<TElement> { Element = original, Position = position, Parent = parent };
            this.ServiceLocator.Original<TElement, TAnnotation>(original).Actions.Add(alignAction);
            pAnnotation.Actions.Add(alignAction);
        }

        /// <summary>
        /// Moves an (original) element into a different parent.
        /// </summary>
        /// <param name="original">(original) element to move.</param>
        /// <param name="position">as the k-th child of,</param>
        /// <param name="parent">the given (original) parent.</param>
        public virtual void Move(TElement original, int position, TElement parent)
        {
            var oAnnotation = this.ServiceLocator.Original<TElement, TAnnotation>(original);
            var oldParentAnnotation = this.ServiceLocator.Original<TElement, TAnnotation>(oAnnotation.Parent);

            var newParentAnnotation = this.ServiceLocator.Original<TElement, TAnnotation>(parent);
            //int fromCurrentKChild = pAnnotation.Children.IndexOf(original);
            oldParentAnnotation.Children.Remove(original);
            newParentAnnotation.Children.Insert(position, original);
            //pAnnotation.Children.Insert(fromCurrentKChild < position ? position - 1 : position, original);

            
            oAnnotation.Parent = parent;
            //this.Delete(original, false);
            //this.Insert(original, position, parent, false);

            var moveAction = new EditMove<TElement> { Element = original, Position = position, Parent = parent };
            oAnnotation.Actions.Add(moveAction);
            oldParentAnnotation.Actions.Add(moveAction);
            newParentAnnotation.Actions.Add(moveAction);
        }

        /// <summary>
        /// Stores the value of <see cref="OriginalsHierarchicalAbstraction"/>.
        /// </summary>
        private IHierarchicalAbstractionService<TElement> _originalsHierarchicalAbstraction;

        /// <summary>
        /// Exposes functionalities for hierarchically handling the hierarchical original versions. 
        /// </summary>
        public virtual IHierarchicalAbstractionService<TElement> OriginalsHierarchicalAbstraction
        {
            get => this._originalsHierarchicalAbstraction ?? (this._originalsHierarchicalAbstraction = new McesHierarchicalSyntaxNodeService<TElement, TAnnotation>.Originals(this.ServiceLocator));
            set => this._originalsHierarchicalAbstraction = value;
        }

        /// <summary>
        /// Stores the value of <see cref="ModifiedsHierarchicalAbstraction"/>.
        /// </summary>
        private IHierarchicalAbstractionService<TElement> _modifiedsHierarchicalAbstraction;

        /// <summary>
        /// Exposes functionalities for hierarchically handling the hierarchical modified versions. 
        /// </summary>
        public virtual IHierarchicalAbstractionService<TElement> ModifiedsHierarchicalAbstraction
        {
            get => this._modifiedsHierarchicalAbstraction ?? (this._modifiedsHierarchicalAbstraction = new McesHierarchicalSyntaxNodeService<TElement, TAnnotation>.Modifieds(this.ServiceLocator));
            set => this._modifiedsHierarchicalAbstraction = value;
        }
    }
}
