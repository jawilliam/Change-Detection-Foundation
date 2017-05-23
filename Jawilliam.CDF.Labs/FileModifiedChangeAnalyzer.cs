using System;
using System.Linq;
using System.Threading;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System.Linq.Expressions;
using Jawilliam.CDF.Similarity.Metrics;

namespace Jawilliam.CDF.Labs
{
    /// <summary>
    /// Implements the analysis of a file modified changes.
    /// </summary>
    public class FileModifiedChangeAnalyzer : RepositoryObjectAnalyzer<FileModifiedChange>
    {
        /// <summary>
        /// Analyzes if there actually are source code changes between the file modified pairs of the given repository.
        /// </summary>
        /// <param name="sqlRepository">the SQL database repository in which to analyze the file versions.</param>
        public virtual void AnalyzeIfThereAreSourceCodeChanges(GitRepository sqlRepository)
        {
            this.Analyze(sqlRepository, "file modified change", f => true, delegate (FileModifiedChange repositoryObject, CancellationToken cancelToken)
            {
                var originalRoot = SyntaxFactory.ParseCompilationUnit(repositoryObject.FromFileVersion.Content.SourceCode).SyntaxTree.GetRoot();
                var originalContentNode = originalRoot.NormalizeWhitespace("", Environment.NewLine);

                var modifiedRoot = SyntaxFactory.ParseCompilationUnit(repositoryObject.FileVersion.Content.SourceCode).SyntaxTree.GetRoot();
                var modifiedContentNode = modifiedRoot.NormalizeWhitespace("", Environment.NewLine);

                var xAnnotations = repositoryObject.XAnnotations;
                xAnnotations.SourceCodeChanges = originalContentNode.ToFullString() == modifiedContentNode.ToFullString();
                repositoryObject.XAnnotations = xAnnotations;
            }, 
            "FileVersion.Content", "FromFileVersion.Content");
        }

        /// <summary>
        /// Analyzes if there actually are source code changes between the file modified pairs of the given repository.
        /// </summary>
        /// <param name="sqlRepository">the SQL database repository in which to analyze the file versions.</param>
        public virtual void LevenshteinDiff(GitRepository sqlRepository)
        {
            this.Analyze(sqlRepository, "file modified change", f => true, delegate (FileModifiedChange repositoryObject, CancellationToken cancelToken)
            {
                var originalRoot = SyntaxFactory.ParseCompilationUnit(repositoryObject.FromFileVersion.Content.SourceCode).SyntaxTree.GetRoot();
                var originalContentNode = originalRoot.NormalizeWhitespace("", Environment.NewLine);

                var modifiedRoot = SyntaxFactory.ParseCompilationUnit(repositoryObject.FileVersion.Content.SourceCode).SyntaxTree.GetRoot();
                var modifiedContentNode = modifiedRoot.NormalizeWhitespace("", Environment.NewLine);
                
                var originalTokens = originalContentNode.DescendantTokens(descendIntoTrivia: true).ToList();
                var modifiedTokens = modifiedContentNode.DescendantTokens(descendIntoTrivia: true).ToList();

                var levenshtein = new LevenshteinSimetric<SyntaxToken>();
                levenshtein.Comparer = new SyntaxTokenEqualityComparer();
                levenshtein.GetSimilarity(originalTokens, modifiedTokens);
            }, 
            "FileVersion.Content", "FromFileVersion.Content");
        }
    }
}
