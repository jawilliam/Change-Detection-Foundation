using Jawilliam.CDF.Approach;
using Jawilliam.CDF.Labs.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Jawilliam.CDF.Labs
{
    public class CorpusInfo : FileRevisionPairAnalyzer
    {
        /// <summary>
        /// Saves a report of interruptions and some size-related metrics.
        /// </summary>
        /// <param name="reportPath">full path to save the report.</param>
        /// <param name="skipThese"></param>
        /// <param name="headRow"></param>
        public virtual void SaveInterruptionsVersusSize(string reportPath, Func<FileRevisionPair, bool> skipThese = null)
        {
            this.Analyze(f => f.Principal.Deltas.Any(d => d.Approach == ChangeDetectionApproaches.NativeGumTree &&
                                               d.Matching != null &&
                                               d.Differencing != null &&
                                               d.Report == null) ||
                              f.Principal.Deltas.Any(d => d.Approach == ChangeDetectionApproaches.InverseOfNativeGumTree &&
                                               d.Matching != null &&
                                               d.Differencing != null &&
                                               d.Report == null) ||
                              f.Principal.Deltas.Any(d => d.Approach == ChangeDetectionApproaches.NativeGumTreeWithChangeDistillerMatcher &&
                                               d.Matching != null &&
                                               d.Differencing != null &&
                                               d.Report == null) ||
                              f.Principal.Deltas.Any(d => d.Approach == ChangeDetectionApproaches.InverseOfNativeGumTreeWithChangeDistillerMatcher &&
                                               d.Matching != null &&
                                               d.Differencing != null &&
                                               d.Report == null) ||
                              f.Principal.Deltas.Any(d => d.Approach == ChangeDetectionApproaches.NativeGumTreeWithXyMatcher &&
                                               d.Matching != null &&
                                               d.Differencing != null &&
                                               d.Report == null) ||
                              f.Principal.Deltas.Any(d => d.Approach == ChangeDetectionApproaches.InverseOfNativeGumTreeWithXyMatcher &&
                                               d.Matching != null &&
                                               d.Differencing != null &&
                                               d.Report == null),
                delegate (FileRevisionPair pair, CancellationToken token)
                {
                    if (skipThese?.Invoke(pair) ?? false) return;                    

                    var reportLine = new StringBuilder();
                    reportLine.Append($"{this.SqlRepository.Name}");
                    reportLine.Append(pair.Principal.FromFileVersion.ContentSummary.CodeLines == null ? ";-1" : $";{pair.Principal.FromFileVersion.ContentSummary.CodeLines}");
                    reportLine.Append(pair.Principal.FromFileVersion.ContentSummary.CommentLines == null ? ";-1" : $";{pair.Principal.FromFileVersion.ContentSummary.CommentLines}");
                    reportLine.Append(pair.Principal.FromFileVersion.ContentSummary.StatementLines == null ? ";-1" : $";{pair.Principal.FromFileVersion.ContentSummary.StatementLines}");
                    reportLine.Append(pair.Principal.FileVersion.ContentSummary.CodeLines == null ? ";-1" : $";{pair.Principal.FileVersion.ContentSummary.CodeLines}");
                    reportLine.Append(pair.Principal.FileVersion.ContentSummary.CommentLines == null ? ";-1" : $";{pair.Principal.FileVersion.ContentSummary.CommentLines}");
                    reportLine.Append(pair.Principal.FileVersion.ContentSummary.StatementLines == null ? ";-1" : $";{pair.Principal.FileVersion.ContentSummary.StatementLines}");

                    var delta = this.SqlRepository.Deltas.SingleOrDefault(d => d.RevisionPair.Id == pair.Principal.Id && d.Approach == ChangeDetectionApproaches.NativeGumTree &&
                                               d.Matching != null &&
                                               d.Differencing != null &&
                                               d.Report == null);
                    reportLine.Append(delta?.OriginalTree == null ? ";-1" : $";{ElementTree.Read(delta.OriginalTree, Encoding.Unicode).PreOrder(n => n.Children).Count()}");
                    reportLine.Append(delta?.ModifiedTree == null ? ";-1" : $";{ElementTree.Read(delta.ModifiedTree, Encoding.Unicode).PreOrder(n => n.Children).Count()}");

                    var dr = (DetectionResult)delta?.DetectionResult;
                    reportLine.Append(dr == null ? ";-1" : $";{dr.Matches.Count}");
                    reportLine.Append(dr == null ? ";-1" : $";{dr.Actions.Count}");

                    delta = this.SqlRepository.Deltas.SingleOrDefault(d => d.RevisionPair.Id == pair.Principal.Id && d.Approach == ChangeDetectionApproaches.InverseOfNativeGumTree &&
                                               d.Matching != null &&
                                               d.Differencing != null &&
                                               d.Report == null);
                    dr = (DetectionResult)delta?.DetectionResult;
                    reportLine.Append(dr == null ? ";-1" : $";{dr.Matches.Count}");
                    reportLine.Append(dr == null ? ";-1" : $";{dr.Actions.Count}");

                    delta = this.SqlRepository.Deltas.SingleOrDefault(d => d.RevisionPair.Id == pair.Principal.Id && d.Approach == ChangeDetectionApproaches.NativeGumTreeWithChangeDistillerMatcher &&
                                               d.Matching != null &&
                                               d.Differencing != null &&
                                               d.Report == null);
                    dr = (DetectionResult)delta?.DetectionResult;
                    reportLine.Append(dr == null ? ";-1" : $";{dr.Matches.Count}");
                    reportLine.Append(dr == null ? ";-1" : $";{dr.Actions.Count}");

                    delta = this.SqlRepository.Deltas.SingleOrDefault(d => d.RevisionPair.Id == pair.Principal.Id && d.Approach == ChangeDetectionApproaches.InverseOfNativeGumTreeWithChangeDistillerMatcher &&
                                               d.Matching != null &&
                                               d.Differencing != null &&
                                               d.Report == null);
                    dr = (DetectionResult)delta?.DetectionResult;
                    reportLine.Append(dr == null ? ";-1" : $";{dr.Matches.Count}");
                    reportLine.Append(dr == null ? ";-1" : $";{dr.Actions.Count}");

                    delta = this.SqlRepository.Deltas.SingleOrDefault(d => d.RevisionPair.Id == pair.Principal.Id && d.Approach == ChangeDetectionApproaches.NativeGumTreeWithXyMatcher &&
                                               d.Matching != null &&
                                               d.Differencing != null &&
                                               d.Report == null);
                    dr = (DetectionResult)delta?.DetectionResult;
                    reportLine.Append(dr == null ? ";-1" : $";{dr.Matches.Count}");
                    reportLine.Append(dr == null ? ";-1" : $";{dr.Actions.Count}");

                    delta = this.SqlRepository.Deltas.SingleOrDefault(d => d.RevisionPair.Id == pair.Principal.Id && d.Approach == ChangeDetectionApproaches.InverseOfNativeGumTreeWithXyMatcher &&
                                               d.Matching != null &&
                                               d.Differencing != null &&
                                               d.Report == null);
                    dr = (DetectionResult)delta?.DetectionResult;
                    reportLine.Append(dr == null ? ";-1" : $";{dr.Matches.Count}");
                    reportLine.Append(dr == null ? ";-1" : $";{dr.Actions.Count}");

                    System.IO.File.AppendAllText(reportPath, Environment.NewLine + reportLine.ToString());
                    //try
                    //{
                    //}
                    //catch (OperationCanceledException)
                    //{
                    //    this.Report.AppendLine($"CANCELED;{pair.Id}");
                    //    throw;
                    //}
                    //catch (OutOfMemoryException)
                    //{
                    //    this.Report.AppendLine($"OUTOFMEMORY;{pair.Id}");
                    //    throw;
                    //}
                }, false, "Principal.FileVersion.ContentSummary", "Principal.FromFileVersion.ContentSummary", "Principal");
        }

        //public virtual void SaveInterruptionsReportInto(string reportPath, Func<FileRevisionPair, bool> skipThese)
        //{
        //    this.Analyze(f => f.Principal.Deltas.Any(d => d.Approach == ChangeDetectionApproaches.NativeGumTree &&
        //                                       d.Matching != null &&
        //                                       d.Differencing != null &&
        //                                       d.Report == null) ||
        //                      f.Principal.Deltas.Any(d => d.Approach == ChangeDetectionApproaches.InverseOfNativeGumTree &&
        //                                       d.Matching != null &&
        //                                       d.Differencing != null &&
        //                                       d.Report == null) ||
        //                      f.Principal.Deltas.Any(d => d.Approach == ChangeDetectionApproaches.NativeGumTreeWithChangeDistillerMatcher &&
        //                                       d.Matching != null &&
        //                                       d.Differencing != null &&
        //                                       d.Report == null) ||
        //                      f.Principal.Deltas.Any(d => d.Approach == ChangeDetectionApproaches.InverseOfNativeGumTreeWithChangeDistillerMatcher &&
        //                                       d.Matching != null &&
        //                                       d.Differencing != null &&
        //                                       d.Report == null) ||
        //                      f.Principal.Deltas.Any(d => d.Approach == ChangeDetectionApproaches.NativeGumTreeWithXyMatcher &&
        //                                       d.Matching != null &&
        //                                       d.Differencing != null &&
        //                                       d.Report == null) ||
        //                      f.Principal.Deltas.Any(d => d.Approach == ChangeDetectionApproaches.InverseOfNativeGumTreeWithXyMatcher &&
        //                                       d.Matching != null &&
        //                                       d.Differencing != null &&
        //                                       d.Report == null),
        //        delegate (FileRevisionPair pair, CancellationToken token)
        //        {
        //            if (skipThese?.Invoke(pair) ?? false) return;

        //            var reportLine = new StringBuilder();
        //            reportLine.Append($"{this.SqlRepository.Name}");
        //            reportLine.Append($"{pair.Principal.FromFileVersion.ContentSummary.CodeLines}");
        //            reportLine.Append($"{pair.Principal.FromFileVersion.ContentSummary.CommentLines}");
        //            reportLine.Append($"{pair.Principal.FromFileVersion.ContentSummary.StatementLines}"); ;
        //            reportLine.Append($"{pair.Principal.FileVersion.ContentSummary.CodeLines}");
        //            reportLine.Append($"{pair.Principal.FileVersion.ContentSummary.CommentLines}");
        //            reportLine.Append($"{pair.Principal.FileVersion.ContentSummary.StatementLines}");
        //            reportLine.Append($"{this.SqlRepository.Name}");
        //            reportLine.Append($"{this.SqlRepository.Name}");

        //            var delta = this.SqlRepository.Deltas.Single(d => d.RevisionPair.Id == pair.Principal.Id && d.Approach == ChangeDetectionApproaches.NativeGumTree);
        //            try
        //            {
        //            }
        //            catch (OperationCanceledException)
        //            {
        //                this.Report.AppendLine($"CANCELED;{pair.Id}");
        //                throw;
        //            }
        //            catch (OutOfMemoryException)
        //            {
        //                this.Report.AppendLine($"OUTOFMEMORY;{pair.Id}");
        //                throw;
        //            }
        //        }, true, "Principal.FileVersion.ContentSummary", "Principal.FromFileVersion.ContentSummary", "Principal");
        //}
    }
}
