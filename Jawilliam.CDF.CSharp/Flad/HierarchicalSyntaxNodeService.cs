using Jawilliam.CDF.Approach;
using Jawilliam.CDF.Approach.Annotations;
using Jawilliam.CDF.Approach.Services;
using Jawilliam.CDF.Approach.Services.Impl;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System.Collections.Generic;
using System.Linq;

namespace Jawilliam.CDF.CSharp.Flad
{
    ///// <summary>
    ///// Implements the hierarchical abstraction level of a <see cref="SyntaxNode"/> element.
    ///// </summary>
    //public class HierarchicalSyntaxNodeService<TAnnotation> : ServiceWithDependencies<IApproach<SyntaxNode>>, IHierarchicalAbstractionService<SyntaxNode>, IBeginDetection
    //     where TAnnotation : IHashingAnnotation, IHierarchicalAbstractionAnnotation, new()
    //{
    //    /// <summary>
    //    /// Initializes the instance.
    //    /// </summary>
    //    /// <param name="serviceLocator">the mechanism for dynamically loading a typed service.</param>
    //    public HierarchicalSyntaxNodeService(IApproach<SyntaxNode> serviceLocator) : base(serviceLocator)
    //    {
    //    }

    //    /// <summary>
    //    /// Access to the children of a node.
    //    /// </summary>
    //    /// <param name="node">node of interest.</param>
    //    /// <returns>the node's children.</returns>
    //    public virtual IEnumerable<SyntaxNode> Children(SyntaxNode node)
    //    {
    //        return node?.ChildNodes();
    //    }

    //    /// <summary>
    //    /// Access to the parent of a node.
    //    /// </summary>
    //    /// <param name="node">node of interest.</param>
    //    /// <returns>the node's parent.</returns>
    //    public virtual SyntaxNode Parent(SyntaxNode node)
    //    {
    //        return node.Parent;
    //    }

    //    /// <summary>
    //    /// Access to the label of a node.
    //    /// </summary>
    //    /// <param name="node">node of interest.</param>
    //    /// <returns>a numeric identifier of the node type.</returns>
    //    public virtual int Label(SyntaxNode node)
    //    {
    //        return node.RawKind;
    //    }

    //    /// <summary>
    //    /// Access to the value of a node.
    //    /// </summary>
    //    /// <param name="node">node of interest.</param>
    //    /// <returns>the value of the given node.</returns>
    //    public virtual object Value(SyntaxNode node)
    //    {
    //        return node != null && this.IsLeaf(node) ? node.ToString() : null;
    //    }

    //    /// <summary>
    //    /// Informs if a node it is leaf. 
    //    /// </summary>
    //    /// <param name="node">node of interest.</param>
    //    /// <returns>true if the given node is a leaf, false othwerwise.</returns>
    //    public virtual bool IsLeaf(SyntaxNode node)
    //    {
    //        return this.Children(node).Count() == 0;
    //    }

    //    /// <summary>
    //    /// Initializes the current service for detecting changes in a new revision pair.
    //    /// </summary>
    //    public virtual void BeginDetection()
    //    {
    //        var originals = this.ServiceLocator.Originals<SyntaxNode, TAnnotation>();
    //        var modifieds = this.ServiceLocator.Modifieds<SyntaxNode, TAnnotation>();

    //        var hierarchicalAbstraction = this.ServiceLocator.HierarchicalAbstraction();

    //        int i = 0;
    //        foreach (var original in this.ServiceLocator.Result.Original.PostOrder(hierarchicalAbstraction.Children))
    //        {
    //            ((IElementAnnotation<SyntaxNode>)this.ServiceLocator.Original<SyntaxNode, TAnnotation>(original)).Id = i++;
    //        }
    //        foreach (var modified in this.ServiceLocator.Result.Modified.PostOrder(hierarchicalAbstraction.Children))
    //        {
    //            ((IElementAnnotation<SyntaxNode>)this.ServiceLocator.Modified<SyntaxNode, TAnnotation>(modified)).Id = i++;
    //        }

    //        this.ComputeSize(this.ServiceLocator.Result.Original, originals, hierarchicalAbstraction);
    //        this.ComputeSize(this.ServiceLocator.Result.Modified, modifieds, hierarchicalAbstraction);

    //        var fullContentHasher = this.ServiceLocator.FullContentHasher<SyntaxNode, TAnnotation>(false);
    //        if (fullContentHasher != null)
    //        {
    //            foreach (var original in originals.Annotations.Keys)
    //            {
    //                originals.Annotations[original].FullHash = fullContentHasher.ComputeHash(original, originals);
    //            }
    //            foreach (var modified in modifieds.Annotations.Keys)
    //            {
    //                modifieds.Annotations[modified].FullHash = fullContentHasher.ComputeHash(modified, modifieds);
    //            }
    //        }
    //    }

    //    private void ComputeSize(SyntaxNode root, IAnnotationSetService<SyntaxNode, TAnnotation> annotationSet, IHierarchicalAbstractionService<SyntaxNode> hierarchicalAbstraction)
    //    {
    //        foreach (var element in root.PostOrder(hierarchicalAbstraction.Children))
    //        {
    //            var size = 1;
    //            if (!hierarchicalAbstraction.IsLeaf(element))
    //            {
    //                foreach (var c in hierarchicalAbstraction.Children(element))
    //                {
    //                    size += annotationSet.Annotations[c].Size;
    //                }
    //            }
    //            annotationSet.Annotations[element].Size = size;
    //        }
    //    }
    //}

    /// <summary>
    /// Implements the hierarchical abstraction level of a <see cref="SyntaxNode"/> element.
    /// </summary>
    /// <typeparam name="TAnnotation">Type of the information to store for each element.</typeparam>
    public class HierarchicalSyntaxNodeService<TAnnotation> : ServiceWithDependencies<IApproach<SyntaxNodeOrToken?>>, IHierarchicalAbstractionService<SyntaxNodeOrToken?>, IBeginDetection
         where TAnnotation : IHashingAnnotation, IHierarchicalAbstractionAnnotation, new()
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="serviceLocator">the mechanism for dynamically loading a typed service.</param>
        public HierarchicalSyntaxNodeService(IApproach<SyntaxNodeOrToken?> serviceLocator) : base(serviceLocator)
        {
        }

        /// <summary>
        /// Access to the children of a node.
        /// </summary>
        /// <param name="node">node of interest.</param>
        /// <returns>the node's children.</returns>
        public virtual IEnumerable<SyntaxNodeOrToken?> Children(SyntaxNodeOrToken? node)
        {
            foreach (var item in node?.ChildNodesAndTokens())
            {
                yield return item;
            }
        }

        /// <summary>
        /// Access to the parent of a node.
        /// </summary>
        /// <param name="node">node of interest.</param>
        /// <returns>the node's parent.</returns>
        public virtual SyntaxNodeOrToken? Parent(SyntaxNodeOrToken? node)
        {
            return node.Value.Parent;
        }

        /// <summary>
        /// Access to the label of a node.
        /// </summary>
        /// <param name="node">node of interest.</param>
        /// <returns>a numeric identifier of the node type.</returns>
        public virtual int Label(SyntaxNodeOrToken? node)
        {
            return node.Value.RawKind;
        }

        /// <summary>
        /// Access to the value of a node.
        /// </summary>
        /// <param name="node">node of interest.</param>
        /// <returns>the value of the given node.</returns>
        public virtual object Value(SyntaxNodeOrToken? node)
        {
            return node != null && this.IsLeaf(node) ? node?.ToString() : null;
        }

        /// <summary>
        /// Informs if a node it is leaf. 
        /// </summary>
        /// <param name="node">node of interest.</param>
        /// <returns>true if the given node is a leaf, false othwerwise.</returns>
        public virtual bool IsLeaf(SyntaxNodeOrToken? node)
        {
            return this.Children(node.Value).Count() == 0;
        }

        /// <summary>
        /// Initializes the current service for detecting changes in a new revision pair.
        /// </summary>
        public virtual void BeginDetection()
        {
            var originals = this.ServiceLocator.Originals<SyntaxNodeOrToken?, TAnnotation>();
            var modifieds = this.ServiceLocator.Modifieds<SyntaxNodeOrToken?, TAnnotation>();

            var hierarchicalAbstraction = this.ServiceLocator.HierarchicalAbstraction(full: true);
            var topologicalAbstraction = this.ServiceLocator.HierarchicalAbstraction(full: false);

            int i = 0;
            foreach (var original in this.ServiceLocator.Result.Original.PostOrder(hierarchicalAbstraction.Children))
            {
                ((IElementAnnotation<SyntaxNodeOrToken?>)this.ServiceLocator.Original<SyntaxNodeOrToken?, TAnnotation>(original)).Id = i++;
            }
            foreach (var modified in this.ServiceLocator.Result.Modified.PostOrder(hierarchicalAbstraction.Children))
            {
                ((IElementAnnotation<SyntaxNodeOrToken?>)this.ServiceLocator.Modified<SyntaxNodeOrToken?, TAnnotation>(modified)).Id = i++;
            }

            this.ComputeSize(this.ServiceLocator.Result.Original, originals, topologicalAbstraction);
            this.ComputeSize(this.ServiceLocator.Result.Modified, modifieds, topologicalAbstraction);

            var fullContentHasher = this.ServiceLocator.FullContentHasher<SyntaxNodeOrToken?, TAnnotation>(false);
            if (fullContentHasher != null)
            {
                foreach (var original in originals.Annotations.Keys)
                {
                    originals.Annotations[original].FullHash = fullContentHasher.ComputeHash(original, originals);
                }
                foreach (var modified in modifieds.Annotations.Keys)
                {
                    modifieds.Annotations[modified].FullHash = fullContentHasher.ComputeHash(modified, modifieds);
                }
            }
        }

        private void ComputeSize(SyntaxNodeOrToken? root, IAnnotationSetService<SyntaxNodeOrToken?, TAnnotation> annotationSet, IHierarchicalAbstractionService<SyntaxNodeOrToken?> hierarchicalAbstraction)
        {
            foreach (var element in root.PostOrder(hierarchicalAbstraction.Children))
            {
                var size = 1;
                if (!hierarchicalAbstraction.IsLeaf(element))
                {
                    foreach (var c in hierarchicalAbstraction.Children(element))
                    {
                        size += annotationSet.Annotations[c].Size;
                    }
                }
                annotationSet.Annotations[element].Size = size;
            }
        }
    }
}
