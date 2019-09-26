using Jawilliam.CDF.Approach.Annotations;
using System.Collections.Generic;

namespace Jawilliam.CDF.Approach.Services.Impl
{
    /// <summary>
    /// Offers the hierarchical abstractions of <see cref="IEditScriptService{TElement}"/>.
    /// </summary>
    /// <typeparam name="TNode">Type of the supported elements.</typeparam>
    public class AnnotatedHierarchicalAbstractionService<TNode, TAnnotation> : ServiceWithDependencies<IApproach<TNode>>, IHierarchicalAbstractionService<TNode, TAnnotation>
         where TAnnotation : IHierarchicalStructureAnnotation<TNode>, new()
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="serviceLocator">the mechanism for dynamically loading a typed service.</param>
        public AnnotatedHierarchicalAbstractionService(IApproach<TNode> serviceLocator) : base(serviceLocator)
        {
        }

        /// <summary>
        /// Access to the children of a node.
        /// </summary>
        /// <param name="node">node of interest.</param>
        /// <param name="annotationSet">the corresponding annotation set.</param>
        /// <param name="includeTrivia">defines if the trivia would be (true), or not (false), considered</param>
        /// <returns>the node's children.</returns>
        public virtual IEnumerable<TNode> Children(TNode node, IAnnotationSetService<TNode, TAnnotation> annotationSet, bool includeTrivia = false)
        {
            return annotationSet.Annotations[node].Children;
        }

        /// <summary>
        /// Access to the parent of a node.
        /// </summary>
        /// <param name="node">node of interest.</param>
        /// <param name="annotationSet">the corresponding annotation set.</param>
        /// <returns>the node's parent.</returns>
        public virtual TNode Parent(TNode node, IAnnotationSetService<TNode, TAnnotation> annotationSet)
        {
            return annotationSet.Annotations[node].Parent;
        }

        /// <summary>
        /// Access to the label of a node.
        /// </summary>
        /// <param name="node">node of interest.</param>
        /// <param name="annotationSet">the corresponding annotation set.</param>
        /// <returns>a numeric identifier of the node type.</returns>
        public virtual int Label(TNode node, IAnnotationSetService<TNode, TAnnotation> annotationSet)
        {
            return this.ServiceLocator.HierarchicalAbstraction<TNode, TAnnotation>(full: true).Label(node, annotationSet);
        }

        /// <summary>
        /// Access to the value of a node.
        /// </summary>
        /// <param name="node">node of interest.</param>
        /// <param name="annotationSet">the corresponding annotation set.</param>
        /// <returns>the value of the given node.</returns>
        public virtual object Value(TNode node, IAnnotationSetService<TNode, TAnnotation> annotationSet)
        {
            return this.ServiceLocator.HierarchicalAbstraction<TNode, TAnnotation>(full: true).Value(node, annotationSet);
        }

        /// <summary>
        /// Informs if a node it is leaf. 
        /// </summary>
        /// <param name="node">node of interest.</param>
        /// <param name="annotationSet">the corresponding annotation set.</param>
        /// <returns>true if the given node is a leaf, false othwerwise.</returns>
        public virtual bool IsLeaf(TNode node, IAnnotationSetService<TNode, TAnnotation> annotationSet)
        {
            return this.ServiceLocator.HierarchicalAbstraction<TNode, TAnnotation>(full: true).IsLeaf(node, annotationSet);
        }

        ///// <summary>
        ///// Implements the <see cref="IEditScriptService{TElement}.OriginalsHierarchicalAbstraction"/>.
        ///// </summary>
        //public class Originals : McesHierarchicalSyntaxNodeService<TNode, TAnnotation>, IHierarchicalAbstractionService<TNode, TAnnotation>
        //{
        //    /// <summary>
        //    /// Initializes the instance.
        //    /// </summary>
        //    /// <param name="serviceLocator">the mechanism for dynamically loading a typed service.</param>
        //    public Originals(IApproach<TNode> serviceLocator) : base(serviceLocator)
        //    {
        //    }

        //    /// <summary>
        //    /// Access to the children of a node.
        //    /// </summary>
        //    /// <param name="node">node of interest.</param>
        //    /// <param name="annotationSet">the corresponding annotation set.</param>
        //    /// <param name="includeTrivia">defines if the trivia would be (true), or not (false), considered</param>
        //    /// <returns>the node's children.</returns>
        //    public override IEnumerable<TNode> Children(TNode node, IAnnotationSetService<TNode, TAnnotation> annotationSet, bool includeTrivia = false)
        //    {
        //        return this.ServiceLocator.Original<TNode, TAnnotation>(node).Children;
        //    }

        //    /// <summary>
        //    /// Access to the parent of a node.
        //    /// </summary>
        //    /// <param name="node">node of interest.</param>
        //    /// <param name="annotationSet">the corresponding annotation set.</param>
        //    /// <returns>the node's parent.</returns>
        //    public override TNode Parent(TNode node, IAnnotationSetService<TNode, TAnnotation> annotationSet)
        //    {
        //        return this.ServiceLocator.Original<TNode, TAnnotation>(node).Parent;
        //    }
        //}

        ///// <summary>
        ///// Implements the <see cref="IEditScriptService{TElement}.ModifiedsHierarchicalAbstraction"/>.
        ///// </summary>
        //public class Modifieds : McesHierarchicalSyntaxNodeService<TNode, TAnnotation>, IHierarchicalAbstractionService<TNode, TAnnotation>
        //{
        //    /// <summary>
        //    /// Initializes the instance.
        //    /// </summary>
        //    /// <param name="serviceLocator">the mechanism for dynamically loading a typed service.</param>
        //    public Modifieds(IApproach<TNode> serviceLocator) : base(serviceLocator)
        //    {
        //    }

        //    /// <summary>
        //    /// Access to the children of a node.
        //    /// </summary>
        //    /// <param name="node">node of interest.</param>
        //    /// <param name="annotationSet">the corresponding annotation set.</param>
        //    /// <param name="includeTrivia">defines if the trivia would be (true), or not (false), considered</param>
        //    /// <returns>the node's children.</returns>
        //    public override IEnumerable<TNode> Children(TNode node, IAnnotationSetService<TNode, TAnnotation> annotationSet, bool includeTrivia = false)
        //    {
        //        return this.ServiceLocator.Modified<TNode, TAnnotation>(node).Children;
        //    }

        //    /// <summary>
        //    /// Access to the parent of a node.
        //    /// </summary>
        //    /// <param name="node">node of interest.</param>
        //    /// <param name="annotationSet">the corresponding annotation set.</param>
        //    /// <returns>the node's parent.</returns>
        //    public override TNode Parent(TNode node, IAnnotationSetService<TNode, TAnnotation> annotationSet)
        //    {
        //        return this.ServiceLocator.Modified<TNode, TAnnotation>(node).Parent;
        //    }
        //}
    }
}
