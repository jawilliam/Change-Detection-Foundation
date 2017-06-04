using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System.Linq.Expressions;
using System.Text;
using System.Xml.Linq;
using Jawilliam.CDF.Approach;
using Jawilliam.CDF.Approach.GumTree;
using Jawilliam.CDF.Similarity.Metrics;

namespace Jawilliam.CDF.Labs
{
    /// <summary>
    /// Implements the analysis of a file modified changes.
    /// </summary>
    public class FileModifiedChangeAnalyzer : RepositoryObjectAnalyzer<FileModifiedChange>
    {
        /// <summary>
        /// Analyzes a given repository object.
        /// </summary>
        /// <param name="repositoryObject">the repository object for analyzing.</param>
        /// <param name="cancelToken">logic for receiving the cancellation notifications.</param>
        /// <param name="original">the normalized tree representing the original version.</param>
        /// <param name="modified">the normalized tree representing the modified version.</param>
        public delegate void CoreAnalyzeDelegate(FileModifiedChange repositoryObject, SyntaxNode original, SyntaxNode modified, CancellationToken cancelToken);

        /// <summary>
        /// Analyzes every file version of the given repository.
        /// </summary>
        /// <param name="sqlRepository">the SQL database repository in which to analyze the file versions.</param>
        /// <param name="onThese">expression to filter the objects of interest.</param>
        /// <param name="analysis">an action for characterizing the analysis.</param>
        /// <param name="includes">paths to include in the query.</param>
        protected virtual void Analyze(GitRepository sqlRepository, Expression<Func<FileModifiedChange, bool>> onThese, AnalyzeDelegate analysis, params string[] includes)
        {
            this.Analyze(sqlRepository, "file modified change",
                onThese ?? (f => f.FromFileVersion.ContentSummary.TotalLines != null && f.FileVersion.ContentSummary.TotalLines != null),
                analysis,
                includes ?? new []{"FileVersion.Content", "FileVersion.ContentSummary", "FromFileVersion.ContentSummary", "FromFileVersion.Content"});
        }

        /// <summary>
        /// Analyzes every file version of the given repository.
        /// </summary>
        /// <param name="sqlRepository">the SQL database repository in which to analyze the file versions.</param>
        /// <param name="onThese">expression to filter the objects of interest.</param>
        /// <param name="analysis">an action for characterizing the analysis given the normalized trees.</param>
        /// <param name="includes">paths to include in the query.</param>
        protected virtual void Analyze(GitRepository sqlRepository, Expression<Func<FileModifiedChange, bool>> onThese, CoreAnalyzeDelegate analysis, params string[] includes)
        {
            this.Analyze(sqlRepository, "file modified change",
                onThese ?? (f => f.FromFileVersion.ContentSummary.TotalLines != null && f.FileVersion.ContentSummary.TotalLines != null),
                delegate (FileModifiedChange repositoryObject, CancellationToken cancelToken)
                {
                    var originalRoot = SyntaxFactory.ParseCompilationUnit(repositoryObject.FromFileVersion.Content.SourceCode).SyntaxTree.GetRoot();
                    var originalContentNode = originalRoot.NormalizeWhitespace("", Environment.NewLine);

                    var modifiedRoot = SyntaxFactory.ParseCompilationUnit(repositoryObject.FileVersion.Content.SourceCode).SyntaxTree.GetRoot();
                    var modifiedContentNode = modifiedRoot.NormalizeWhitespace("", Environment.NewLine);

                    analysis(repositoryObject, originalContentNode, modifiedContentNode, cancelToken);
                },
            includes ?? new[] { "FileVersion.Content", "FileVersion.ContentSummary", "FromFileVersion.ContentSummary", "FromFileVersion.Content" });
        }

        /// <summary>
        /// Analyzes if there actually are source code changes between the file modified pairs of the given repository.
        /// </summary>
        /// <param name="sqlRepository">the SQL database repository in which to analyze the file versions.</param>
        public virtual void AnalyzeIfThereAreSourceCodeChanges(GitRepository sqlRepository)
        {
            this.Analyze(sqlRepository, "file modified change", 
                f => f.FromFileVersion.ContentSummary.TotalLines != null && f.FileVersion.ContentSummary.TotalLines != null, 
                delegate (FileModifiedChange repositoryObject, CancellationToken cancelToken)
            {
                //if (repositoryObject.FromFileVersion.Content.SourceCode == null ||
                //    repositoryObject.FileVersion.Content.SourceCode == null)
                //    return;

                var originalRoot = SyntaxFactory.ParseCompilationUnit(repositoryObject.FromFileVersion.Content.SourceCode).SyntaxTree.GetRoot();
                var originalContentNode = originalRoot.NormalizeWhitespace("", Environment.NewLine);

                var modifiedRoot = SyntaxFactory.ParseCompilationUnit(repositoryObject.FileVersion.Content.SourceCode).SyntaxTree.GetRoot();
                var modifiedContentNode = modifiedRoot.NormalizeWhitespace("", Environment.NewLine);

                var xAnnotations = repositoryObject.XAnnotations;
                xAnnotations.SourceCodeChanges = originalContentNode.ToFullString() != modifiedContentNode.ToFullString();
                repositoryObject.XAnnotations = xAnnotations;
            }, 
            "FileVersion.Content", "FileVersion.ContentSummary", "FromFileVersion.ContentSummary", "FromFileVersion.Content");
        }

        /// <summary>
        /// Analyzes the similarity in according with a given similarity metric, such as Levenshtein.
        /// </summary>
        /// <param name="sqlRepository">the SQL database repository in which to analyze the file versions.</param>
        /// <param name="simetricName">the name of the similarity metric</param>
        /// <param name="simetric"></param>
        public virtual void SimetricDiff(GitRepository sqlRepository, string simetricName, ISimetric<SyntaxToken> simetric)
        {
            this.Analyze(sqlRepository, 
            (f => f.FromFileVersion.ContentSummary.TotalLines != null && f.FileVersion.ContentSummary.TotalLines != null && f.Deltas.All(d => d.Approach != ChangeDetectionApproaches.Simetrics)),
            delegate(FileModifiedChange repositoryObject, SyntaxNode original, SyntaxNode modified, CancellationToken token)
            {
                if (!repositoryObject.XAnnotations.SourceCodeChanges)
                    return;

                var originalTokens = original.DescendantTokens(descendIntoTrivia: true).ToList();
                var modifiedTokens = modified.DescendantTokens(descendIntoTrivia: true).ToList();

                sqlRepository.Deltas.Where(d => sqlRepository.RepositoryObjects.OfType<FileModifiedChange>()
                    .Any(f => f.Id == repositoryObject.Id && f.Deltas.Any(fd => fd.Approach == ChangeDetectionApproaches.Simetrics)))
                    .Load();

                var simetricDelta = repositoryObject.Deltas.SingleOrDefault(d => d.Approach == ChangeDetectionApproaches.Simetrics);
                if (simetricDelta == null)
                {
                    simetricDelta = new Delta { Id = Guid.NewGuid(), Approach = ChangeDetectionApproaches.Simetrics };
                    repositoryObject.Deltas.Add(simetricDelta);
                }

                var xDeltaAnnotations = simetricDelta.XAnnotations;
                var xSimetric = xDeltaAnnotations.Simetrics?.SingleOrDefault(s => s.Name == simetricName);
                if (xSimetric == null)
                {
                    xSimetric = new XDeltaAnnotations.XSimetric { Name = simetricName };
                    var xSimetrics = xDeltaAnnotations.Simetrics?.ToList() ?? new List<XDeltaAnnotations.XSimetric>(1);
                    xSimetrics.Add(xSimetric);
                    xDeltaAnnotations.Simetrics = xSimetrics.ToArray();
                }

                double? distance;
                simetric.CancellationToken = token;
                xSimetric.Similarity = simetric.GetSimilarity(originalTokens, modifiedTokens, out distance);
                Debug.Assert(distance != null, "distance != null");
                xSimetric.Distance = distance.Value;

                simetricDelta.XAnnotations = xDeltaAnnotations;
            }, 
            "FileVersion.Content", "FromFileVersion.Content");
        }

        /// <summary>
        /// Analyzes the similarity in according with a given similarity metric, such as Levenshtein.
        /// </summary>
        /// <param name="sqlRepository">the SQL database repository in which to analyze the file versions.</param>
        /// <param name="interopArgs">the arguments for the interoperability.</param>
        /// <param name="gumTree">the native approach based on the GumTree interoperability.</param>
        public virtual void NativeGumTreeDiff(GitRepository sqlRepository, GumTreeNativeApproach gumTree, InteropArgs interopArgs)
        {
            this.Analyze(sqlRepository,
            f => f.Deltas.Any(d => d.Approach == ChangeDetectionApproaches.Simetrics) && 
                 f.Deltas.All(d => d.Approach != ChangeDetectionApproaches.NativeGumTree), // I am running Levenshtein before, so the longer cases have been already rejected.
            delegate (FileModifiedChange repositoryObject, SyntaxNode original, SyntaxNode modified, CancellationToken token)
            {
                if (!repositoryObject.XAnnotations.SourceCodeChanges)
                    return;

                sqlRepository.Deltas.Where(d => sqlRepository.RepositoryObjects.OfType<FileModifiedChange>()
                    .Any(f => f.Id == repositoryObject.Id && f.Deltas.Any(fd => fd.Approach == ChangeDetectionApproaches.NativeGumTree)))
                    .Load();

                var simetricDelta = repositoryObject.Deltas.SingleOrDefault(d => d.Approach == ChangeDetectionApproaches.NativeGumTree);
                if (simetricDelta == null)
                {
                    simetricDelta = new Delta { Id = Guid.NewGuid(), Approach = ChangeDetectionApproaches.NativeGumTree };
                    //repositoryObject.Deltas.Add(simetricDelta);
                }

                System.IO.File.WriteAllText(interopArgs.Original, original.ToFullString());
                System.IO.File.WriteAllText(interopArgs.Modified, modified.ToFullString());

                gumTree.Proceed(interopArgs);
                var writeXmlColumn = gumTree.Result.WriteXmlColumn();
                var dr = DetectionResult.Read(writeXmlColumn, Encoding.Unicode);
                XElement result = XElement.Parse(writeXmlColumn.Replace("﻿<?xml version=\"1.0\" encoding=\"utf-16\"?>", ""));
                simetricDelta.Matching = new XDocument(result.Element("Matches")).ToString().Replace("\r\n", "").Replace(" />  <", "/><").Replace(">  <", "><");
                simetricDelta.Differencing = new XDocument(result.Element("Actions")).ToString().Replace("\r\n", "").Replace(" />  <", "/><").Replace(">  <", "><");
            },
            "FileVersion.Content", "FromFileVersion.Content");
        }
    }
}
