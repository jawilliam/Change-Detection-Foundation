using Jawilliam.CDF.Approach;
using Jawilliam.CDF.Approach.Annotations;
using Jawilliam.CDF.Approach.Services;
using Jawilliam.CDF.CSharp.Flad;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Jawilliam.CDF.CSharp.Awareness
{
    /// <summary>
    /// Implements the topological abstraction level of a <see cref="SyntaxNode"/> element.
    /// </summary>
    /// <typeparam name="TAnnotation">Type of the information to store for each element.</typeparam>
    public class TopologicalAbstraction<TAnnotation> : HierarchicalSyntaxNodeService<TAnnotation> where TAnnotation : IHashingAnnotation, IHierarchicalAbstractionAnnotation, new()
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="serviceLocator">the mechanism for dynamically loading a typed service.</param>
        public TopologicalAbstraction(IApproach<SyntaxNodeOrToken?> serviceLocator) : base(serviceLocator)
        {
        }

        /// <summary>
        /// Access to the children of a node.
        /// </summary>
        /// <param name="node">node of interest.</param>
        /// <param name="includeTrivia">defines if the trivia would be (true), or not (false), considered</param>
        /// <param name="annotationSet">the corresponding annotation set.</param>
        /// <returns>the node's children.</returns>
        public override IEnumerable<SyntaxNodeOrToken?> Children(SyntaxNodeOrToken? node, IAnnotationSetService<SyntaxNodeOrToken?, TAnnotation> annotationSet, bool includeTrivia = false)
        {
            if (node == null)
                throw new ArgumentNullException(nameof(node));

            var languageProvider = this.ServiceLocator.LanguageProvider();
            var result = languageProvider.GetElementTypeServiceProvider(node) is IHierarchicalAbstractionService<SyntaxNodeOrToken?, TAnnotation> elementTypeProvider 
                ? elementTypeProvider.Children(node, annotationSet) 
                : base.Children(node, annotationSet);

            foreach (var r in result)
            {
                yield return r;
            }

            if (includeTrivia)
            {
                var annotation = annotationSet.Annotations[node];
                if (annotation.DescendantTrivia != null)
                    foreach (var item in annotation.DescendantTrivia.OfType<SyntaxNodeOrToken?>())
                    {
                        yield return item;
                    }
                if (annotation.LeadingTrivia != null)
                    foreach (var item in annotation.DescendantTrivia.OfType<SyntaxNodeOrToken?>())
                    {
                        yield return item;
                    }
                if (annotation.TrailingTrivia != null)
                    foreach (var item in annotation.DescendantTrivia.OfType<SyntaxNodeOrToken?>())
                    {
                        yield return item;
                    }
            }
        }

        /// <summary>
        /// Access to the parent of a node.
        /// </summary>
        /// <param name="node">node of interest.</param>
        /// <returns>the node's parent.</returns>
        public override SyntaxNodeOrToken? Parent(SyntaxNodeOrToken? node, IAnnotationSetService<SyntaxNodeOrToken?, TAnnotation> annotationSet)
        {
            if (node == null)
                throw new ArgumentNullException(nameof(node));

            var languageProvider = this.ServiceLocator.LanguageProvider();
            return languageProvider.GetElementTypeServiceProvider(node) is IHierarchicalAbstractionService<SyntaxNodeOrToken?, TAnnotation> elementTypeProvider
                ? elementTypeProvider.Parent(node, annotationSet)
                : base.Parent(node, annotationSet);
        }

        /// <summary>
        /// Access to the label of a node.
        /// </summary>
        /// <param name="node">node of interest.</param>
        /// <returns>a numeric identifier of the node type.</returns>
        public override int Label(SyntaxNodeOrToken? node, IAnnotationSetService<SyntaxNodeOrToken?, TAnnotation> annotationSet)
        {
            if (node == null)
                throw new ArgumentNullException(nameof(node));

            var languageProvider = this.ServiceLocator.LanguageProvider();
            return languageProvider.GetElementTypeServiceProvider(node) is IHierarchicalAbstractionService<SyntaxNodeOrToken?, TAnnotation> elementTypeProvider
                ? elementTypeProvider.Label(node, annotationSet)
                : base.Label(node, annotationSet);
        }

        /// <summary>
        /// Access to the value of a node.
        /// </summary>
        /// <param name="node">node of interest.</param>
        /// <returns>the value of the given node.</returns>
        public override object Value(SyntaxNodeOrToken? node, IAnnotationSetService<SyntaxNodeOrToken?, TAnnotation> annotationSet)
        {
            if (node == null)
                throw new ArgumentNullException(nameof(node));

            var languageProvider = this.ServiceLocator.LanguageProvider();
            return languageProvider.GetElementTypeServiceProvider(node) is IHierarchicalAbstractionService<SyntaxNodeOrToken?, TAnnotation> elementTypeProvider
                ? elementTypeProvider.Value(node, annotationSet)
                : base.Value(node, annotationSet);
        }

        /// <summary>
        /// Informs if a node it is leaf. 
        /// </summary>
        /// <param name="node">node of interest.</param>
        /// <returns>true if the given node is a leaf, false othwerwise.</returns>
        public override bool IsLeaf(SyntaxNodeOrToken? node, IAnnotationSetService<SyntaxNodeOrToken?, TAnnotation> annotationSet)
        {
            if (node == null)
                throw new ArgumentNullException(nameof(node));

            var languageProvider = this.ServiceLocator.LanguageProvider();
            return languageProvider.GetElementTypeServiceProvider(node) is IHierarchicalAbstractionService<SyntaxNodeOrToken?, TAnnotation> elementTypeProvider
                ? elementTypeProvider.IsLeaf(node, annotationSet)
                : base.IsLeaf(node, annotationSet);
        }
    }
}
