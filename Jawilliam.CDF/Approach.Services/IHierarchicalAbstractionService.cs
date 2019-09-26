using Jawilliam.CDF.Approach.Annotations;
using System.Collections.Generic;

namespace Jawilliam.CDF.Approach.Services
{
    /// <summary>
    /// Defines the hierarchical abstraction level of a node element.
    /// </summary>
    /// <typeparam name="TNode">Type of the supported elements.</typeparam>
    /// <typeparam name="TAnnotation">Type of the information to store for each element.</typeparam>
    public interface IHierarchicalAbstractionService<TNode, TAnnotation> : IService where TAnnotation : new()
    {
        /// <summary>
        /// Access to the children of a node.
        /// </summary>
        /// <param name="node">node of interest.</param>
        /// <param name="includeTrivia">defines if the trivia would be (true), or not (false), considered</param>
        /// <param name="annotationSet">the corresponding annotation set.</param>
        /// <returns>the node's children.</returns>
        IEnumerable<TNode> Children(TNode node, IAnnotationSetService<TNode, TAnnotation> annotationSet, bool includeTrivia = false);

        /// <summary>
        /// Access to the parent of a node.
        /// </summary>
        /// <param name="node">node of interest.</param>
        /// <param name="annotationSet">the corresponding annotation set.</param>
        /// <returns>the node's parent.</returns>
        TNode Parent(TNode node, IAnnotationSetService<TNode, TAnnotation> annotationSet);

        /// <summary>
        /// Access to the label of a node.
        /// </summary>
        /// <param name="node">node of interest.</param>
        /// <param name="annotationSet">the corresponding annotation set.</param>
        /// <returns>a numeric identifier of the node type.</returns>
        int Label(TNode node, IAnnotationSetService<TNode, TAnnotation> annotationSet);

        /// <summary>
        /// Access to the value of a node.
        /// </summary>
        /// <param name="node">node of interest.</param>
        /// <param name="annotationSet">the corresponding annotation set.</param>
        /// <returns>the value of the given node.</returns>
        object Value(TNode node, IAnnotationSetService<TNode, TAnnotation> annotationSet);

        /// <summary>
        /// Informs if a node it is leaf. 
        /// </summary>
        /// <param name="node">node of interest.</param>
        /// <param name="annotationSet">the corresponding annotation set.</param>
        /// <returns>true if the given node is a leaf, false othwerwise.</returns>
        bool IsLeaf(TNode node, IAnnotationSetService<TNode, TAnnotation> annotationSet);
    }
}
