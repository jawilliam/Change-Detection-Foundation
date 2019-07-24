using Jawilliam.CDF.Approach;
using Jawilliam.CDF.Approach.Annotations;
using Jawilliam.CDF.Approach.Services;
using Jawilliam.CDF.CSharp.Flad;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;

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
        /// <returns>the node's children.</returns>
        public override IEnumerable<SyntaxNodeOrToken?> Children(SyntaxNodeOrToken? node)
        {
            if (node == null)
                throw new ArgumentNullException(nameof(node));

            var languageProvider = this.ServiceLocator.LanguageProvider();
            return languageProvider.GetElementTypeServiceProvider(node) is IHierarchicalAbstractionService<SyntaxNodeOrToken?> elementTypeProvider 
                ? elementTypeProvider.Children(node) 
                : base.Children(node);
        }

        /// <summary>
        /// Access to the parent of a node.
        /// </summary>
        /// <param name="node">node of interest.</param>
        /// <returns>the node's parent.</returns>
        public override SyntaxNodeOrToken? Parent(SyntaxNodeOrToken? node)
        {
            if (node == null)
                throw new ArgumentNullException(nameof(node));

            var languageProvider = this.ServiceLocator.LanguageProvider();
            return languageProvider.GetElementTypeServiceProvider(node) is IHierarchicalAbstractionService<SyntaxNodeOrToken?> elementTypeProvider
                ? elementTypeProvider.Parent(node)
                : base.Parent(node);
        }

        /// <summary>
        /// Access to the label of a node.
        /// </summary>
        /// <param name="node">node of interest.</param>
        /// <returns>a numeric identifier of the node type.</returns>
        public override int Label(SyntaxNodeOrToken? node)
        {
            if (node == null)
                throw new ArgumentNullException(nameof(node));

            var languageProvider = this.ServiceLocator.LanguageProvider();
            return languageProvider.GetElementTypeServiceProvider(node) is IHierarchicalAbstractionService<SyntaxNodeOrToken?> elementTypeProvider
                ? elementTypeProvider.Label(node)
                : base.Label(node);
        }

        /// <summary>
        /// Access to the value of a node.
        /// </summary>
        /// <param name="node">node of interest.</param>
        /// <returns>the value of the given node.</returns>
        public override object Value(SyntaxNodeOrToken? node)
        {
            if (node == null)
                throw new ArgumentNullException(nameof(node));

            var languageProvider = this.ServiceLocator.LanguageProvider();
            return languageProvider.GetElementTypeServiceProvider(node) is IHierarchicalAbstractionService<SyntaxNodeOrToken?> elementTypeProvider
                ? elementTypeProvider.Value(node)
                : base.Value(node);
        }

        /// <summary>
        /// Informs if a node it is leaf. 
        /// </summary>
        /// <param name="node">node of interest.</param>
        /// <returns>true if the given node is a leaf, false othwerwise.</returns>
        public override bool IsLeaf(SyntaxNodeOrToken? node)
        {
            if (node == null)
                throw new ArgumentNullException(nameof(node));

            var languageProvider = this.ServiceLocator.LanguageProvider();
            return languageProvider.GetElementTypeServiceProvider(node) is IHierarchicalAbstractionService<SyntaxNodeOrToken?> elementTypeProvider
                ? elementTypeProvider.IsLeaf(node)
                : base.IsLeaf(node);
        }
    }
}
