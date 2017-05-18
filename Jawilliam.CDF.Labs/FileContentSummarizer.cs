using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System.IO;
using System.Threading;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Jawilliam.CDF.Labs
{
    /// <summary>
    /// Implements the logic to collect general statistics about the content of a file version.
    /// </summary>
    public class FileContentSummarizer : FileVersionAnalyzer
    {
        /// <summary>
        /// Analyzes a given file version.
        /// </summary>
        /// <param name="fileVersion">the file version for analyzing.</param>
        /// <param name="cancelToken">logic for receiving the cancellation notifications.</param>
        public override void Analyze(FileVersion fileVersion, CancellationToken cancelToken)
        {
            if (fileVersion.Content?.SourceCode == null)
                return;

            var root = SyntaxFactory.ParseCompilationUnit(fileVersion.Content.SourceCode).SyntaxTree.GetRoot();
            var contentNode = root.NormalizeWhitespace("", Environment.NewLine);
            this.SetLinesOfCodeMetrics(fileVersion, contentNode.ToFullString());

            Dictionary<string, XSyntaxElementTypeSummary> syntaxTypes = new Dictionary<string, XSyntaxElementTypeSummary>(300);
            string parentSyntaxType;
            string parentName;
            var typeDeclarations = contentNode.DescendantNodesAndSelf(descendIntoTrivia: true)
                .OfType<BaseTypeDeclarationSyntax>()
                .ToList();

            foreach (var typeDeclaration in typeDeclarations)
            {
                parentSyntaxType = Enum.GetName(typeof (SyntaxKind), typeDeclaration.RawKind);
                parentName = typeDeclaration.Identifier.Text;
                foreach (var syntaxNode in typeDeclaration.DescendantNodesAndSelf(descendIntoTrivia: true, descendIntoChildren: node => node == typeDeclaration || !(node is BaseTypeDeclarationSyntax)))
                {
                    if (syntaxNode == typeDeclaration) continue;
                    this.AnalyzeInParent(cancelToken, syntaxNode, parentName, parentSyntaxType, syntaxTypes);
                }
            }

            parentSyntaxType = "";
            parentName = "";
            foreach (var syntaxNode in contentNode.DescendantNodesAndSelf(descendIntoTrivia: true, descendIntoChildren: node => !(node is BaseTypeDeclarationSyntax)))
            {
                this.AnalyzeInParent(cancelToken, syntaxNode, parentName, parentSyntaxType, syntaxTypes);
            }

            XSyntaxKindAnnotations annotations = new XSyntaxKindAnnotations
            {
                ElementTypes = syntaxTypes.Values.ToArray()
            };
            fileVersion.ContentSummary.SyntaxKindAnnotations = annotations.WriteXmlColumn();
        }

        private void AnalyzeInParent(CancellationToken cancelToken, SyntaxNode syntaxNode, string parentName, string parentSyntaxType, Dictionary<string, XSyntaxElementTypeSummary> syntaxTypes)
        {
            if (cancelToken.IsCancellationRequested)
            {
                // Clean up here, then...
                cancelToken.ThrowIfCancellationRequested();
            }

            string syntaxName = $"{Enum.GetName(typeof (SyntaxKind), syntaxNode.RawKind)}#{parentName}#{parentSyntaxType}";
            XSyntaxElementTypeSummary syntaxType = null;
            if (syntaxTypes.ContainsKey(syntaxName))
            {
                syntaxType = syntaxTypes[syntaxName];
            }
            else
            {
                syntaxType = new XSyntaxElementTypeSummary
                {
                    ParentSyntaxType = parentSyntaxType,
                    ParentName = parentName,
                    SyntaxType = Enum.GetName(typeof(SyntaxKind), syntaxNode.RawKind)
                };
                syntaxTypes[syntaxName] = syntaxType;
            }
            syntaxType.Total += 1;
        }

        /// <summary>
        /// Computes the lines counting metrics.
        /// </summary>
        /// <param name="fileVersion">the file version for analyzing.</param>
        /// <param name="content">the source code content of the file version for analyzing.</param>
        private void SetLinesOfCodeMetrics(FileVersion fileVersion, string content)
        {
            try
            {
                var countOfLinesMetric = new CountOfLinesMetric(new StringReader(content));

                fileVersion.ContentSummary.TotalLines = countOfLinesMetric.Lines.Count();
                fileVersion.ContentSummary.CommentLines = countOfLinesMetric.Comments;
                fileVersion.ContentSummary.BlankLines = countOfLinesMetric.InBlank;
                fileVersion.ContentSummary.CodeLines = countOfLinesMetric.Code;
                fileVersion.ContentSummary.StatementLines = countOfLinesMetric.Statements;
            }
            catch (Exception)
            {
                this.Warnings.AppendLine($"LinesMetricException - fileversion-{fileVersion.Id}");
            }
        }
    }
}
