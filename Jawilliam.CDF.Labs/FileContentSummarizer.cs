using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System.IO;

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
        public override void Analyze(FileVersion fileVersion)
        {
            var contentNode = SyntaxFactory.ParseCompilationUnit(fileVersion.Content.SourceCode).SyntaxTree.GetRoot().NormalizeWhitespace("", Environment.NewLine);
            this.SetLinesOfCodeMetrics(fileVersion, contentNode.ToFullString());

            Dictionary<string, XSyntaxElementTypeSummary> syntaxTypes = new Dictionary<string, XSyntaxElementTypeSummary>(300);
            foreach (var syntaxNode in contentNode.DescendantNodesAndSelf(descendIntoTrivia: true))
            {
                string syntaxName = Enum.GetName(typeof(SyntaxKind), syntaxNode.RawKind);
                XSyntaxElementTypeSummary syntaxType = null;
                if (syntaxTypes.ContainsKey(syntaxName))
                {
                    syntaxType = syntaxTypes[syntaxName];
                }
                else
                {
                    syntaxType = new XSyntaxElementTypeSummary { Name = syntaxName };
                    syntaxTypes[syntaxName] = syntaxType;
                }
                syntaxType.Total += 1;
            }

            XSyntaxKindAnnotations annotations = new XSyntaxKindAnnotations
            {
                ElementTypes = syntaxTypes.Values.ToArray()
            };
            fileVersion.ContentSummary.SyntaxKindAnnotations = annotations.WriteXmlColumn();
        }

        /// <summary>
        /// Computes the lines counting metrics.
        /// </summary>
        /// <param name="fileVersion">the file version for analyzing.</param>
        /// <param name="content">the source code content of the file version for analyzing.</param>
        private void SetLinesOfCodeMetrics(FileVersion fileVersion, string content)
        {
            CountOfLinesMetric countOfLinesMetric = null;
            try
            {
                countOfLinesMetric = new CountOfLinesMetric(new StringReader(content));

                fileVersion.ContentSummary.TotalLines = countOfLinesMetric.Lines.Count();
                fileVersion.ContentSummary.CommentLines = countOfLinesMetric.Comments;
                fileVersion.ContentSummary.BlankLines = countOfLinesMetric.InBlank;
                fileVersion.ContentSummary.CodeLines = countOfLinesMetric.Code;
                fileVersion.ContentSummary.StatementLines = countOfLinesMetric.Statements;
            }
            catch (Exception)
            {
            }
        }
    }
}
