using Jawilliam.CDF.Approach;
using Jawilliam.CDF.Approach.Annotations;
using Jawilliam.CDF.Approach.Services;
using Jawilliam.CDF.Approach.Services.Impl;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Jawilliam.CDF.CSharp.Flad
{
    /// <summary>
    /// Implements the hierarchical abstraction level of a <see cref="SyntaxNode"/> element.
    /// </summary>
    /// <typeparam name="TAnnotation">Type of the information to store for each element.</typeparam>
    public class HierarchicalSyntaxNodeService<TAnnotation> : ServiceWithDependencies<IApproach<SyntaxNodeOrToken?>>
        , IHierarchicalAbstractionService<SyntaxNodeOrToken?, TAnnotation>, IBeginDetection
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
        /// <param name="includeTrivia">defines if the trivia would be (true), or not (false), considered</param>
        /// <param name="annotationSet">the corresponding annotation set.</param>
        /// <returns>the node's children.</returns>
        public virtual IEnumerable<SyntaxNodeOrToken?> Children(SyntaxNodeOrToken? node, IAnnotationSetService<SyntaxNodeOrToken?, TAnnotation> annotationSet, bool includeTrivia = false)
        {
            foreach (var item in node?.ChildNodesAndTokens())
            {
                yield return item;
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

        private void AttachTrivia(SyntaxNodeOrToken? node, IAnnotationSetService<SyntaxNodeOrToken?, TAnnotation> annotationSet)
        {
            var descendantTrivia = new List<object>();
            var leadingTrivia = new List<object>();
            var trailingTrivia = new List<object>();
            if (node?.IsNode ?? false)
            {
                var asNode = node?.AsNode();
                foreach (var item in asNode.DescendantTrivia().Where(d => this.ShouldThisTriviaBeAttachedHere(node, d)))
                {
                    if (item.HasStructure)
                        descendantTrivia.Add((SyntaxNodeOrToken?)item.GetStructure());
                    else descendantTrivia.Add(item);
                    this._attachedTrivia.Add(item, item);
                }
            }
            else if (node?.IsToken ?? false)
            {
                var token = node.Value.AsToken();
                if (token.HasLeadingTrivia)
                {
                    foreach (var tr in token.LeadingTrivia.Where(d => this.ShouldThisTriviaBeAttachedHere(node, d)))
                    {
                        if (tr.HasStructure)
                            leadingTrivia.Add((SyntaxNodeOrToken?)tr.GetStructure());
                        else leadingTrivia.Add(tr);
                        this._attachedTrivia.Add(tr, tr);
                    }
                }
                if (token.HasTrailingTrivia)
                {
                    foreach (var tt in token.TrailingTrivia.Where(d => this.ShouldThisTriviaBeAttachedHere(node, d)))
                    {
                        if (tt.HasStructure)
                            trailingTrivia.Add((SyntaxNodeOrToken?)tt.GetStructure());
                        else trailingTrivia.Add(tt);
                        this._attachedTrivia.Add(tt, tt);
                    }
                }
            }

            annotationSet.Annotations[node].DescendantTrivia = descendantTrivia?.Any() ?? false ? descendantTrivia.ToArray() : null;
            annotationSet.Annotations[node].LeadingTrivia = leadingTrivia?.Any() ?? false ? leadingTrivia?.ToArray() : null;
            annotationSet.Annotations[node].TrailingTrivia = trailingTrivia?.Any() ?? false ? trailingTrivia?.ToArray() : null;
        }

        private Hashtable _attachedTrivia;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="trivia"></param>
        /// <returns></returns>
        internal virtual bool ShouldThisTriviaBeAttachedHere(SyntaxNodeOrToken? node, SyntaxTrivia trivia)
        {
            if (!trivia.HasStructure &&
                trivia.Kind() != SyntaxKind.SingleLineCommentTrivia &&
                trivia.Kind() != SyntaxKind.MultiLineCommentTrivia)
                return false;

            if (!trivia.HasStructure)
                return true;

            if (node?.IsNode ?? false)
            {
                var asNode = node?.AsNode();
                var structure = trivia.GetStructure();
                var parentOrStructuredTriviaParent = structure.GetType()
                    .GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                    .Where(p => p.Name == "ParentOrStructuredTriviaParent" && p.DeclaringType == typeof(CSharpSyntaxNode))
                    .Single().GetValue(structure);

                if (parentOrStructuredTriviaParent == asNode)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Access to the parent of a node.
        /// </summary>
        /// <param name="node">node of interest.</param>
        /// <param name="annotationSet">the corresponding annotation set.</param>
        /// <returns>the node's parent.</returns>
        public virtual SyntaxNodeOrToken? Parent(SyntaxNodeOrToken? node, IAnnotationSetService<SyntaxNodeOrToken?, TAnnotation> annotationSet)
        {
            return node.Value.Parent;
        }

        /// <summary>
        /// Access to the label of a node.
        /// </summary>
        /// <param name="node">node of interest.</param>
        /// <param name="annotationSet">the corresponding annotation set.</param>
        /// <returns>a numeric identifier of the node type.</returns>
        public virtual int Label(SyntaxNodeOrToken? node, IAnnotationSetService<SyntaxNodeOrToken?, TAnnotation> annotationSet)
        {
            return node.Value.RawKind;
        }

        /// <summary>
        /// Access to the value of a node.
        /// </summary>
        /// <param name="node">node of interest.</param>
        /// <param name="annotationSet">the corresponding annotation set.</param>
        /// <returns>the value of the given node.</returns>
        public virtual object Value(SyntaxNodeOrToken? node, IAnnotationSetService<SyntaxNodeOrToken?, TAnnotation> annotationSet)
        {
            return node != null && this.IsLeaf(node, annotationSet) ? node?.ToString() : null;
        }

        /// <summary>
        /// Informs if a node it is leaf. 
        /// </summary>
        /// <param name="node">node of interest.</param>
        /// <param name="annotationSet">the corresponding annotation set.</param>
        /// <returns>true if the given node is a leaf, false othwerwise.</returns>
        public virtual bool IsLeaf(SyntaxNodeOrToken? node, IAnnotationSetService<SyntaxNodeOrToken?, TAnnotation> annotationSet)
        {
            return this.Children(node.Value, annotationSet).Count() == 0;
        }

        /// <summary>
        /// Suppresses (true) or not (false) the execution of <see cref="BeginDetection"/>.
        /// </summary>
        public virtual bool SuppressBeginDetection { get; set; }

        /// <summary>
        /// Initializes the current service for detecting changes in a new revision pair.
        /// </summary>
        public virtual void BeginDetection()
        {
            if (this.SuppressBeginDetection)
                return;

            var originals = this.ServiceLocator.Originals<SyntaxNodeOrToken?, TAnnotation>();
            var modifieds = this.ServiceLocator.Modifieds<SyntaxNodeOrToken?, TAnnotation>();

            var hierarchicalAbstraction = this.ServiceLocator.HierarchicalAbstraction<SyntaxNodeOrToken?, TAnnotation>(full: true);
            var topologicalAbstraction = this.ServiceLocator.HierarchicalAbstraction<SyntaxNodeOrToken?, TAnnotation>(full: false);

            this._attachedTrivia = new Hashtable();
            int i = 0;
            try
            {
                foreach (var original in this.ServiceLocator.Result.Original.PostOrder(c => hierarchicalAbstraction.Children(c, originals)))
                {
                    ((IElementAnnotation<SyntaxNodeOrToken?>)originals.Annotations[original]).Id = i++;
                    this.AttachTrivia(original, originals);
                }
                foreach (var modified in this.ServiceLocator.Result.Modified.PostOrder(c => hierarchicalAbstraction.Children(c, modifieds)))
                {
                    ((IElementAnnotation<SyntaxNodeOrToken?>)modifieds.Annotations[modified]).Id = i++;
                    this.AttachTrivia(modified, modifieds);
                }
            }
            finally
            {
                this._attachedTrivia = null;
            }

            // Trivia
            foreach (var original in this.ServiceLocator.Result.Original.PostOrder(c => hierarchicalAbstraction.Children(c, originals)))
            {
                var annotation = originals.Annotations[original];
                if (annotation.DescendantTrivia != null)
                    this._BeginTrivia(annotation.DescendantTrivia.OfType<SyntaxNodeOrToken?>(), originals, ref i);
                if (annotation.LeadingTrivia != null)
                    this._BeginTrivia(annotation.LeadingTrivia.OfType<SyntaxNodeOrToken?>(), originals, ref i);
                if (annotation.TrailingTrivia != null)
                    this._BeginTrivia(annotation.TrailingTrivia.OfType<SyntaxNodeOrToken?>(), originals, ref i);
            }
            foreach (var modified in this.ServiceLocator.Result.Modified.PostOrder(c => hierarchicalAbstraction.Children(c, modifieds)))
            {
                var annotation = modifieds.Annotations[modified];
                if (annotation.DescendantTrivia != null)
                    this._BeginTrivia(annotation.DescendantTrivia.OfType<SyntaxNodeOrToken?>(), modifieds, ref i);
                if (annotation.LeadingTrivia != null)
                    this._BeginTrivia(annotation.LeadingTrivia.OfType<SyntaxNodeOrToken?>(), modifieds, ref i);
                if (annotation.TrailingTrivia != null)
                    this._BeginTrivia(annotation.TrailingTrivia.OfType<SyntaxNodeOrToken?>(), modifieds, ref i);
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

        private void _BeginTrivia(IEnumerable<SyntaxNodeOrToken?> triviaElements, IAnnotationSetService<SyntaxNodeOrToken?, TAnnotation> annotationSet, ref int i)
        {
            var hierarchicalAbstraction = this.ServiceLocator.HierarchicalAbstraction<SyntaxNodeOrToken?, TAnnotation>(full: true);
            foreach (var triviaElement in triviaElements)
            {
                foreach (var t in triviaElement.PostOrder(c => hierarchicalAbstraction.Children(c, annotationSet)))
                {
                    annotationSet.Init(new[] { t });
                    ((IElementAnnotation<SyntaxNodeOrToken?>)annotationSet.Annotations[t]).Id = i++;
                }
            }
        }

        private void ComputeSize(SyntaxNodeOrToken? root, IAnnotationSetService<SyntaxNodeOrToken?, TAnnotation> annotationSet, IHierarchicalAbstractionService<SyntaxNodeOrToken?, TAnnotation> hierarchicalAbstraction)
        {
            foreach (var element in root.PostOrder(c => hierarchicalAbstraction.Children(c, annotationSet)))
            {
                var size = 1;
                if (!hierarchicalAbstraction.IsLeaf(element, annotationSet))
                {
                    foreach (var c in hierarchicalAbstraction.Children(element, annotationSet))
                    {
                        size += annotationSet.Annotations[c].Size;
                    }
                }
                annotationSet.Annotations[element].Size = size;

                foreach (var c in hierarchicalAbstraction.Children(element, annotationSet))
                {
                    var annotation = annotationSet.Annotations[c];
                    if (annotation.DescendantTrivia != null)
                        this.ComputeSize(annotation.DescendantTrivia.OfType<SyntaxNodeOrToken?>(), annotationSet, hierarchicalAbstraction);
                    if (annotation.LeadingTrivia != null)
                        this.ComputeSize(annotation.LeadingTrivia.OfType<SyntaxNodeOrToken?>(), annotationSet, hierarchicalAbstraction);
                    if (annotation.TrailingTrivia != null)
                        this.ComputeSize(annotation.TrailingTrivia.OfType<SyntaxNodeOrToken?>(), annotationSet, hierarchicalAbstraction);
                }
            }
        }

        private void ComputeSize(IEnumerable<SyntaxNodeOrToken?> roots, IAnnotationSetService<SyntaxNodeOrToken?, TAnnotation> annotationSet, IHierarchicalAbstractionService<SyntaxNodeOrToken?, TAnnotation> hierarchicalAbstraction)
        {
            foreach (var root in roots)
            {
                this.ComputeSize(root, annotationSet, hierarchicalAbstraction);
            }
        }
    }
}
