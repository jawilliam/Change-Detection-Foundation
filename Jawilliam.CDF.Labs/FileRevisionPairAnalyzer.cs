using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Jawilliam.CDF.Actions;
using Jawilliam.CDF.Approach;
using Jawilliam.CDF.Approach.GumTree;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Jawilliam.CDF.Labs
{
    /// <summary>
    /// Implements the analysis of an unique pair of a file modified changes.
    /// </summary>
    public class FileRevisionPairAnalyzer
    {
        /// <summary>
        /// Gets or sets the SQL database repository in which to analyze the file versions.
        /// </summary>
        public virtual GitRepository SqlRepository { get; set; }

        /// <summary>
        /// Gets or sets the expression to filter the file revision pairs of interest.
        /// </summary>
        public virtual Expression<Func<FileRevisionPair, bool>> OnThese { get; set; }

        /// <summary>
        /// Gets or sets a cancellation logic.
        /// </summary>
        public virtual Action Cancel { get; set; }

        /// <summary>
        /// Gets or sets tthe count of milliseconds to declare a time out analysis.
        /// </summary>
        public int MillisecondsTimeout { get; set; } = 300000;

        /// <summary>
        /// Gets or sets the warnings to report.
        /// </summary>
        public StringBuilder Warnings { get; set; }

        /// <summary>
        /// Gets or sets the warnings to report.
        /// </summary>
        public StringBuilder Report { get; set; }

        /// <summary>
        /// Analyzes a given repository object.
        /// </summary>
        /// <param name="repositoryObject">the repository object for analyzing.</param>
        /// <param name="cancelToken">logic for receiving the cancellation notifications.</param>
        public delegate void AnalyzeDelegate(FileRevisionPair repositoryObject, CancellationToken cancelToken);

        /// <summary>
        /// Analyzes a given repository object.
        /// </summary>
        /// <param name="repositoryObject">the repository object for analyzing.</param>
        /// <param name="cancelToken">logic for receiving the cancellation notifications.</param>
        /// <param name="original">the normalized tree representing the original version.</param>
        /// <param name="modified">the normalized tree representing the modified version.</param>
        public delegate void CoreAnalyzeDelegate(FileRevisionPair repositoryObject, SyntaxNode original, SyntaxNode modified, CancellationToken cancelToken);

        /// <summary>
        /// Analyzes every file version of the given repository.
        /// </summary>
        /// <param name="onThese"></param>
        /// <param name="analysis">an action for characterizing the analysis.</param>
        /// <param name="saveChanges">Enables or disables the persistence of the changes.</param>
        /// <param name="includes">paths to include in the query.</param>
        protected virtual void Analyze(Expression<Func<FileRevisionPair, bool>> onThese, AnalyzeDelegate analysis, bool saveChanges = true, params string[] includes)
        {
            if (analysis == null) throw new ArgumentNullException(nameof(analysis));

            var repositoryObjectIds = /*sqlRepository.Name == "mono"
                ? sqlRepository.FileRevisionPairs
                    .Where(onThese)
                    .Select(fv => fv.Id).ToList().Skip(8).ToList()
                :*/ this.SqlRepository.FileRevisionPairs
                    .Where(onThese)
                    .Select(fv => fv.Id).ToList();

            int counter = 0;
            foreach (var repositoryObjectId in repositoryObjectIds)
            {
                var repositoryObjectQuery = saveChanges 
                    ? this.SqlRepository.FileRevisionPairs.AsQueryable()
                    : this.SqlRepository.FileRevisionPairs.AsQueryable().AsNoTracking();

                repositoryObjectQuery = includes.Aggregate(repositoryObjectQuery, (current, include) => current.Include(include));
                FileRevisionPair repositoryObject = repositoryObjectQuery.Single(c => c.Id == repositoryObjectId);

                Console.Out.WriteLine($"Analyzing the {++counter}-{this.SqlRepository.Name} ({repositoryObjectIds.Count}) of {this.SqlRepository.Name}");
                var cancellationTokenSource = new CancellationTokenSource();
                var cancellationToken = cancellationTokenSource.Token;
                try
                {
                    try
                    {
                        var t = Task.Run(() => analysis(repositoryObject, cancellationToken), cancellationToken);
                        t.Wait(this.MillisecondsTimeout);
                        cancellationTokenSource.Cancel();
                        this.Cancel?.Invoke();

                        t.Wait();
                    }
                    catch (AggregateException ae) { throw ae.InnerException; }
                    catch (OperationCanceledException) { this.Warnings.AppendLine($"TIMEOUT - {this.SqlRepository.Name}-{repositoryObject.Id}"); }
                    catch (OutOfMemoryException) { this.Warnings.AppendLine($"OUTOFMEMORY - {this.SqlRepository.Name}-{repositoryObject.Id}"); }
                }
                catch (InsufficientExecutionStackException) { this.Warnings.AppendLine($"InsufficientExecutionStack - fileversion-{this.SqlRepository.Name}-{repositoryObject.Id}"); }
                catch (OperationCanceledException) { this.Warnings.AppendLine($"TIMEOUT - {this.SqlRepository.Name}-{repositoryObject.Id}"); }
                catch (InvalidOperationException) { this.Warnings.AppendLine($"INVALIDOPERATION - {this.SqlRepository.Name}-{repositoryObject.Id}"); }
                catch (OutOfMemoryException) { this.Warnings.AppendLine($"OUTOFMEMORY - {this.SqlRepository.Name}-{repositoryObject.Id}"); }
                catch (Exception) { this.Warnings.AppendLine($"ERROR - {this.SqlRepository.Name}-{repositoryObject.Id}"); }

                Console.Out.WriteLine($"Saving the {counter}-file version ({repositoryObjectIds.Count}) of {this.SqlRepository.Name}");
                this.SqlRepository.Flush(saveChanges);
            }
        }

        /// <summary>
        /// Analyzes every file version of the given repository.
        /// </summary>
        /// <param name="onThese">expression to filter the objects of interest.</param>
        /// <param name="analysis">an action for characterizing the analysis given the normalized trees.</param>
        /// <param name="saveChanges">Enables or disables the persistence of the changes.</param>
        /// <param name="includes">paths to include in the query.</param>
        protected virtual void Analyze(Expression<Func<FileRevisionPair, bool>> onThese, CoreAnalyzeDelegate analysis, bool saveChanges = true, params string[] includes)
        {
            this.Analyze(onThese ?? (f => f.Principal.FromFileVersion.ContentSummary.TotalLines != null && f.Principal.FileVersion.ContentSummary.TotalLines != null),
            delegate (FileRevisionPair repositoryObject, CancellationToken cancelToken)
            {
                var originalRoot = SyntaxFactory.ParseCompilationUnit(repositoryObject.Principal.FromFileVersion.Content.SourceCode).SyntaxTree.GetRoot();
                var originalContentNode = originalRoot.NormalizeWhitespace("", Environment.NewLine);

                var modifiedRoot = SyntaxFactory.ParseCompilationUnit(repositoryObject.Principal.FileVersion.Content.SourceCode).SyntaxTree.GetRoot();
                var modifiedContentNode = modifiedRoot.NormalizeWhitespace("", Environment.NewLine);

                analysis(repositoryObject, originalContentNode, modifiedContentNode, cancelToken);
            },
            saveChanges,
            includes ?? new[]
            {
                "Principal.FileVersion.Content",
                "Principal.FileVersion.ContentSummary",
                "Principal.FromFileVersion.ContentSummary",
                "Principal.FromFileVersion.Content"
            });
        }

        /// <summary>
        /// Analyzes the similarity in according with a given similarity metric, such as Levenshtein.
        /// </summary>
        /// <param name="interopArgs">the arguments for the interoperability.</param>
        /// <param name="gumTree">the native approach based on the GumTree interoperability.</param>
        /// <param name="gumTreeApproach"></param>
        /// <param name="skipThese">local criterion for determining elements that should be ignored.</param>
        /// <param name="cleaner">A preprocessor for the source code in case it is desired.</param>
        public virtual void NativeGumTreeDiff(GumTreeNativeApproach gumTree, InteropArgs interopArgs, ChangeDetectionApproaches gumTreeApproach, Func<FileRevisionPair, bool> skipThese, SourceCodeCleaner cleaner = null)
        {
            this.Analyze(/*this.SqlRepository, f => f.Principal.Deltas.Any(d => d.Approach == gumTreeApproach),*/
            f => f.Principal.Deltas.Any(d => d.Approach == ChangeDetectionApproaches.NativeGumTreeWithoutComments) /*&& 
                 f.Deltas.All(d => d.Approach != gumTreeApproach), // I am running Levenshtein before, so the longer cases have been already rejected.
            */,delegate (FileRevisionPair repositoryObject, SyntaxNode original, SyntaxNode modified, CancellationToken token)
            {
                if (!repositoryObject.Principal.XAnnotations.SourceCodeChanges || (skipThese?.Invoke(repositoryObject) ?? false))
                    return;

                this.SqlRepository.Deltas.Where(d => d.RevisionPair.Id == repositoryObject.Principal.Id && d.Approach == gumTreeApproach)
                    .Load();

                var delta = repositoryObject.Principal.Deltas.SingleOrDefault(d => d.Approach == gumTreeApproach);
                //if (delta != null) return;
                if (delta == null)
                {
                    delta = new Delta { Id = Guid.NewGuid(), Approach = gumTreeApproach };
                    repositoryObject.Principal.Deltas.Add(delta);
                }

                var preprocessedOriginal = cleaner != null ? cleaner.Clean(original) : original;
                var preprocessedModified = cleaner != null ? cleaner.Clean(modified) : modified;
                System.IO.File.WriteAllText(interopArgs.Original, preprocessedOriginal.ToFullString());
                System.IO.File.WriteAllText(interopArgs.Modified, preprocessedModified.ToFullString());

                try
                {
                    gumTree.Proceed(interopArgs);
                }
                catch (Exception e)
                {
                    if (string.IsNullOrEmpty(gumTree.Result.Error))
                        gumTree.Result.Error = e.Message;

                    throw;
                }
                finally
                {
                    var writeXmlColumn = gumTree.Result.WriteXmlColumn();
                    XElement result = XElement.Parse(writeXmlColumn.Replace("﻿<?xml version=\"1.0\" encoding=\"utf-16\"?>", ""));
                    delta.Matching = new XDocument(result.Element("Matches")).ToString()
                            .Replace("\r\n", "")
                            .Replace(" />  <", "/><")
                            .Replace(">  <", "><");
                    delta.Differencing = new XDocument(result.Element("Actions")).ToString()
                            .Replace("\r\n", "")
                            .Replace(" />  <", "/><")
                            .Replace(">  <", "><");

                    if (!string.IsNullOrEmpty(gumTree.Result?.Error))
                        delta.Report = result.ToString()
                            .Replace("\r\n", "")
                            .Replace(" />  <", "/><")
                            .Replace(">  <", "><");
                }
            }, true,
            "Principal.FileVersion.Content", "Principal.FromFileVersion.Content");
        }

        /// <summary>
        /// Analyzes the similarity in according with a given similarity metric, such as Levenshtein.
        /// </summary>
        /// <param name="interopArgs">the arguments for the interoperability.</param>
        /// <param name="gumTree">the native approach based on the GumTree interoperability.</param>
        /// <param name="gumTreeApproach"></param>
        /// <param name="skipThese">local criterion for determining elements that should be ignored.</param>
        /// <param name="cleaner">A preprocessor for the source code in case it is desired.</param>
        public virtual void InverseNativeGumTreeDiff(GumTreeNativeApproach gumTree, InteropArgs interopArgs, ChangeDetectionApproaches gumTreeApproach, Func<FileRevisionPair, bool> skipThese, SourceCodeCleaner cleaner = null)
        {
            this.Analyze(/*this.SqlRepository, f => f.Principal.Deltas.Any(d => d.Approach == gumTreeApproach),*/
            f => f.Principal.Deltas.Any(d => d.Approach == ChangeDetectionApproaches.NativeGumTree) /*&& 
                 f.Deltas.All(d => d.Approach != gumTreeApproach), // I am running Levenshtein before, so the longer cases have been already rejected.
            */, delegate (FileRevisionPair repositoryObject, SyntaxNode original, SyntaxNode modified, CancellationToken token)
              {
                  if (!repositoryObject.Principal.XAnnotations.SourceCodeChanges || (skipThese?.Invoke(repositoryObject) ?? false))
                      return;

                  this.SqlRepository.Deltas.Where(d => d.RevisionPair.Id == repositoryObject.Principal.Id && d.Approach == gumTreeApproach)
                      .Load();

                  var delta = repositoryObject.Principal.Deltas.SingleOrDefault(d => d.Approach == gumTreeApproach);
                  //if (delta != null) return;
                  if (delta == null)
                  {
                      delta = new Delta { Id = Guid.NewGuid(), Approach = gumTreeApproach };
                      repositoryObject.Principal.Deltas.Add(delta);
                  }

                  var preprocessedOriginal = cleaner != null ? cleaner.Clean(original) : original;
                  var preprocessedModified = cleaner != null ? cleaner.Clean(modified) : modified;
                  System.IO.File.WriteAllText(interopArgs.Modified, preprocessedOriginal.ToFullString());
                  System.IO.File.WriteAllText(interopArgs.Original, preprocessedModified.ToFullString());

                  try
                  {
                      gumTree.Proceed(interopArgs);
                  }
                  catch (Exception e)
                  {
                      if (string.IsNullOrEmpty(gumTree.Result.Error))
                          gumTree.Result.Error = e.Message;

                      throw;
                  }
                  finally
                  {
                      var writeXmlColumn = gumTree.Result.WriteXmlColumn();
                      XElement result = XElement.Parse(writeXmlColumn.Replace("﻿<?xml version=\"1.0\" encoding=\"utf-16\"?>", ""));
                      delta.Matching = new XDocument(result.Element("Matches")).ToString()
                              .Replace("\r\n", "")
                              .Replace(" />  <", "/><")
                              .Replace(">  <", "><");
                      delta.Differencing = new XDocument(result.Element("Actions")).ToString()
                              .Replace("\r\n", "")
                              .Replace(" />  <", "/><")
                              .Replace(">  <", "><");

                      if (!string.IsNullOrEmpty(gumTree.Result?.Error))
                          delta.Report = result.ToString()
                              .Replace("\r\n", "")
                              .Replace(" />  <", "/><")
                              .Replace(">  <", "><");
                  }
              }, true,
            "Principal.FileVersion.Content", "Principal.FromFileVersion.Content");
        }


        /// <summary>
        /// Analyzes the similarity in according with a given similarity metric, such as Levenshtein.
        /// </summary>
        /// <param name="interopArgs">the arguments for the interoperability.</param>
        /// <param name="gumTree">the native approach based on the GumTree interoperability.</param>
        /// <param name="gumTreeApproach"></param>
        /// <param name="skipThese">local criterion for determining elements that should be ignored.</param>
        /// <param name="cleaner">A preprocessor for the source code in case it is desired.</param>
        public virtual void SaveNativeTrees(GumTreeNativeApproach gumTree, InteropArgs interopArgs, ChangeDetectionApproaches gumTreeApproach, Func<FileRevisionPair, bool> skipThese, SourceCodeCleaner cleaner = null, bool reverseFileVersions = false)
        {
            this.Analyze(f => f.Principal.Deltas.Any(d => d.Approach == gumTreeApproach &&
                                               d.Matching != null &&
                                               d.Differencing != null &&
                                               d.Report == null), 
              delegate (FileRevisionPair repositoryObject, SyntaxNode original, SyntaxNode modified, CancellationToken token)
              {
                  if (!repositoryObject.Principal.XAnnotations.SourceCodeChanges || (skipThese?.Invoke(repositoryObject) ?? false))
                      return;

                  this.SqlRepository.Deltas.Where(d => d.RevisionPair.Id == repositoryObject.Principal.Id && d.Approach == gumTreeApproach)
                      .Load();

                  var delta = repositoryObject.Principal.Deltas.Single(d => d.Approach == gumTreeApproach);
                  if (delta.Report != null || (delta.OriginalTree != null && delta.ModifiedTree != null))
                      return;

                  var preprocessedOriginal = cleaner != null ? cleaner.Clean(original) : original;
                  var preprocessedModified = cleaner != null ? cleaner.Clean(modified) : modified;
                  System.IO.File.WriteAllText(interopArgs.Original, preprocessedOriginal.ToFullString());
                  System.IO.File.WriteAllText(interopArgs.Modified, preprocessedModified.ToFullString());

                  var originalTree = gumTree.ParseTree(interopArgs, reverseFileVersions);
                  var modifiedTree = gumTree.ParseTree(interopArgs, !reverseFileVersions);
                  
                  int index = 0;
                  originalTree.PostOrder(t => t.Children).ForEach(t => t.Root.Id = index++.ToString(CultureInfo.InvariantCulture));
                  delta.OriginalTree = originalTree.WriteXmlColumn();
                  
                  index = 0;
                  modifiedTree.PostOrder(t => t.Children).ForEach(t => t.Root.Id = index++.ToString(CultureInfo.InvariantCulture));
                  delta.ModifiedTree = modifiedTree.WriteXmlColumn();
              }, true,
            "Principal.FileVersion.Content", "Principal.FromFileVersion.Content");
        }

        /// <summary>
        /// Filters the file revision pairs that satisfy a particular criterion.
        /// </summary>
        /// <param name="onThese">expression to filter the objects of interest.</param>
        /// <param name="action">the filtering criterion</param>
        /// <param name="includes">paths to include in the query.</param>
        public virtual void ForEach(Expression<Func<FileRevisionPair, bool>> onThese, Action<FileRevisionPair> action, params string[] includes)
        {
            var repositoryObjectIds = this.SqlRepository.FileRevisionPairs
                   .Where(onThese)
                   .Select(fv => fv.Id).ToList();

            var counter = 0;
            foreach (var repositoryObjectId in repositoryObjectIds)
            {
                var repositoryObjectQuery = this.SqlRepository.FileRevisionPairs.AsQueryable();
                repositoryObjectQuery = includes.Aggregate(repositoryObjectQuery, (current, include) => current.Include(include));
                var repositoryObject = repositoryObjectQuery.Single(c => c.Id == repositoryObjectId);

                Console.Out.WriteLine($"Analyzing the {++counter}-{this.SqlRepository.Name} ({repositoryObjectIds.Count}) of {this.SqlRepository.Name}");
                action(repositoryObject);
            }
        }

        internal string GetBreadcrum(ElementTree element)
        {
            string elementName = null;
            if (element.Root.Label == "block")
            {
                var blockOf = element.LabelOf(t => t.Parent, t => t.Root.Label == "block")
                                     .First(t => t.Root.Label != "block");

                elementName = blockOf.NameOf(t => t.Children, t => t.Root.Label, t => t.Root.Value);
                return elementName != null
                    ? $"{element.Root.Label}:{element.Root.Id}({blockOf.Root.Label}-{elementName})"
                    : $"{element.Root.Label}:{element.Root.Id}({blockOf.Root.Label})";
            }

            elementName = element.NameOf(t => t.Children, t => t.Root.Label, t => t.Root.Value);
            return elementName != null
                ? $"{element.Root.Label}:{element.Root.Id}({elementName})"
                : $"{element.Root.Label}:{element.Root.Id}";
        }

        protected string GetPath(IEnumerable<ElementTree> trees) => trees.Aggregate("", (s, ancestor) => s != ""
           ? $"{s}##{this.GetBreadcrum(ancestor)}"
           : this.GetBreadcrum(ancestor));

        /// <summary>
        /// Analyzes the similarity in according with a given similarity metric, such as Levenshtein.
        /// </summary>
        /// <param name="approach"></param>
        /// <param name="skipThese">local criterion for determining elements that should be ignored.</param>
        public virtual void SaveConfusingRenames(ChangeDetectionApproaches approach, Func<FileRevisionPair, bool> skipThese)
        {
            this.Analyze(f => f.Principal.Deltas.Any(d => d.Approach == approach &&
                                               d.Matching != null &&
                                               d.Differencing != null &&
                                               d.Report == null),
                delegate (FileRevisionPair pair, CancellationToken token)
                {
                    if (skipThese?.Invoke(pair) ?? false) return;

                    var delta = this.SqlRepository.Deltas.Single(d => d.RevisionPair.Id == pair.Principal.Id && d.Approach == approach);
                    try
                    {
                        var coexistingNames = this.FindConfusingRenames(delta, token);

                        foreach (var coexistingName in coexistingNames)
                        {
                            delta.Symptoms.Add(coexistingName);
                            //var originalAncestorOfReference = missedMatchA.Original.Element.LabelOf(t => t.Parent, t => t.Root.Label == "name")
                            //    .First(a => a.Root.Label != "name").Ancestors().First();
                            //var modifiedAncestorOfReference = missedMatchA.Modified.Element.LabelOf(t => t.Parent, t => t.Root.Label == "name")
                            //    .First(a => a.Root.Label != "name").Ancestors().First();
                            ////var coexistingAncestorOfReference = missedMatchA.Original.MatchedReference.LabelOf(t => t.Parent, t => t.Root.Label == "name")
                            ////    .First(a => a.Root.Label != "name").Ancestors().First();
                            //this.Report.AppendLine($"{missedMatchA.Original.Type};" +
                            //                       $"{missedMatchA.Modified.Type};" +
                            //                       $"{this.GetBreadcrum(missedMatchA.Original.Element)};" +
                            //                       $"{this.GetBreadcrum(missedMatchA.Modified.Element)};" +
                            //                       $"{this.GetBreadcrum(missedMatchA.Modified.MatchedReference)};" +
                            //                       $"{this.GetBreadcrum(missedMatchA.Original.Element.LabelOf(t => t.Parent, t => t.Root.Label == "name").First(a => a.Root.Label != "name"))};" +
                            //                       $"{this.GetBreadcrum(missedMatchA.Modified.Element.LabelOf(t => t.Parent, t => t.Root.Label == "name").First(a => a.Root.Label != "name"))};" +
                            //                       $"{this.GetBreadcrum(missedMatchA.Modified.MatchedReference.LabelOf(t => t.Parent, t => t.Root.Label == "name").First(a => a.Root.Label != "name"))};" +
                            //                       $"{this.GetPath(missedMatchA.Original.Element.LabelOf(t => t.Parent, t => t.Root.Label == "name").First(a => a.Root.Label != "name").Ancestors())};" +
                            //                       $"{this.GetPath(missedMatchA.Modified.Element.LabelOf(t => t.Parent, t => t.Root.Label == "name").First(a => a.Root.Label != "name").Ancestors())}");
                            ////delta.Symptoms.Add(new MissedNameSymptom
                            ////{
                            ////    Id = Guid.NewGuid(),
                            ////    Pattern = missedMatchA.Case,
                            ////    Original = new MissedMatch
                            ////    {
                            ////        Element = new ElementDescription
                            ////        {
                            ////            Hint = missedMatchA.Original.Element.Root.Value,
                            ////            Id = missedMatchA.Original.Element.Root.Id,
                            ////            Type = missedMatchA.Original.Type
                            ////        },
                            ////        AncestorOfReference = new ElementDescription
                            ////        {
                            ////            Hint = this.GetBreadcrum(originalAncestorOfReference),
                            ////            Id = originalAncestorOfReference.Root.Id,
                            ////            Type = originalAncestorOfReference.Root.Label
                            ////        }/*,
                            ////        CommonAncestorOfReference = new ElementDescription
                            ////        {
                            ////            Hint = this.GetBreadcrum(missedMatchA.Original.MatchedReference),
                            ////            Id = missedMatchA.Original.MatchedReference.Root.Id,
                            ////            Type = missedMatchA.Original.MatchedReference.Root.Label
                            ////        }*/,
                            ////        ScopeHint = this.GetPath(missedMatchA.Original.Element.LabelOf(t => t.Parent, t => t.Root.Label == "name").First(a => a.Root.Label != "name").Ancestors())
                            ////    },
                            ////    Modified = new MissedMatch
                            ////    {
                            ////        Element = new ElementDescription
                            ////        {
                            ////            Hint = missedMatchA.Modified.Element.Root.Value,
                            ////            Id = missedMatchA.Modified.Element.Root.Id,
                            ////            Type = missedMatchA.Modified.Type
                            ////        },
                            ////        AncestorOfReference = new ElementDescription
                            ////        {
                            ////            Hint = this.GetBreadcrum(modifiedAncestorOfReference),
                            ////            Id = modifiedAncestorOfReference.Root.Id,
                            ////            Type = modifiedAncestorOfReference.Root.Label
                            ////        }/*,
                            ////        CommonAncestorOfReference = new ElementDescription
                            ////        {
                            ////            Hint = this.GetBreadcrum(missedMatchA.Modified.MatchedReference),
                            ////            Id = missedMatchA.Modified.MatchedReference.Root.Id,
                            ////            Type = missedMatchA.Modified.MatchedReference.Root.Label
                            ////        }*/,
                            ////        ScopeHint = this.GetPath(missedMatchA.Modified.Element.LabelOf(t => t.Parent, t => t.Root.Label == "name").First(a => a.Root.Label != "name").Ancestors())
                            ////    }
                            ////});
                        }
                    }
                    catch (OperationCanceledException)
                    {
                        this.Report.AppendLine($"CANCELED;{pair.Id}");
                        throw;
                    }
                    catch (OutOfMemoryException)
                    {
                        this.Report.AppendLine($"OUTOFMEMORY;{pair.Id}");
                        throw;
                    }
                }, true, "Principal");
        }

        //private ElementTree GetReference(ElementTree element)
        //{
        //    string elementName = null;
        //    if (element.Root.Label == "block")
        //    {
        //        var blockOf = element.LabelOf(t => t.Parent, t => t.Root.Label == "block")
        //                             .First(t => t.Root.Label != "block");

        //        return blockOf.NameOf(t => t.Children, t => t.Root.Label, t => t.Root.Value);
        //        return elementName != null
        //            ? $"{element.Root.Label}:{element.Root.Id}({blockOf.Root.Label}-{elementName})"
        //            : $"{element.Root.Label}:{element.Root.Id}({blockOf.Root.Label})";
        //    }

        //    elementName = element.NameOf(t => t.Children, t => t.Root.Label, t => t.Root.Value);
        //    return elementName != null
        //        ? $"{element.Root.Label}:{element.Root.Id}({elementName})"
        //        : $"{element.Root.Label}:{element.Root.Id}";
        //}

        //public virtual void FindMissedMatchesAOfKeyedElement(Delta delta)
        //{
        //    this.Warnings = new StringBuilder();
        //    try
        //    {
        //        var detectionResult = DetectionResult.Read($"<Result>{delta.Matching}{delta.Differencing}</Result>", Encoding.Unicode);
        //        var candidateBadCases = from m in detectionResult.Actions.OfType<InsertOperationDescriptor>()
        //                                    //let matchingPair = detectionResult.Matches.Single(mp => mp.Original.Id == m.Element.Id)
        //                                    //let insert = detectionResult.Actions.OfType<InsertOperationDescriptor>().SingleOrDefault(i => i.)
        //                                where m.Element.Label == "name" &&
        //                                      m.Element.Value != "get" &&
        //                                      m.Element.Value != "set" &&
        //                                      m.Element.Value != "add" &&
        //                                      m.Element.Value != "remove" &&
        //                                      !string.IsNullOrWhiteSpace(m.Element.Value) &&
        //                                      !string.IsNullOrEmpty(m.Element.Value) &&
        //                                      (m.Parent.Label == "function" ||
        //                                       m.Parent.Label == "function_decl" ||
        //                                       m.Parent.Label == "namespace" ||
        //                                       m.Parent.Label == "class" ||
        //                                       m.Parent.Label == "struct" ||
        //                                       m.Parent.Label == "interface" ||
        //                                       m.Parent.Label == "decl_stmt" ||
        //                                       m.Parent.Label == "constructor" ||
        //                                       m.Parent.Label == "destructor" ||
        //                                       m.Parent.Label == "enum") &&
        //                                      detectionResult.Matches.Any(n => n.Original.Label == "name" &&
        //                                                                       n.Original.Value == m.Element.Value)
        //                                select m;

        //        var candidateBadCases2 = from m in detectionResult.Actions.OfType<UpdateOperationDescriptor>()
        //                                     //let matchingPair = detectionResult.Matches.Single(mp => mp.Original.Id == m.Element.Id)
        //                                     //let insert = detectionResult.Actions.OfType<InsertOperationDescriptor>().SingleOrDefault(i => i.)
        //                                 where m.Element.Label == "name" &&
        //                                       m.Element.Value != "get" &&
        //                                       m.Element.Value != "set" &&
        //                                       m.Element.Value != "add" &&
        //                                       m.Element.Value != "remove" &&
        //                                       !string.IsNullOrWhiteSpace(m.Element.Value) &&
        //                                       !string.IsNullOrEmpty(m.Element.Value) &&
        //                                       detectionResult.Matches.Any(n => n.Original.Label == "name" &&
        //                                                                        n.Original.Value == m.Element.Value)
        //                                 select m;

        //        foreach (var badCase in candidateBadCases)
        //        {
        //            analyzer.Warnings.AppendLine($"{project.Name};{pair.Principal.Id};{badCase.Parent.Label};{badCase.Element.Label}:{badCase.Element.Value}");
        //        }

        //        foreach (var badCase in candidateBadCases2)
        //        {
        //            analyzer.Warnings.AppendLine($"{project.Name};{pair.Principal.Id};#DELETION#;{badCase.Element.Label}:{badCase.Element.Value}");
        //        }

        //        System.IO.File.AppendAllText($@"E:\Phd\Analysis\BadRenamesFor{Enum.GetName(typeof(ChangeDetectionApproaches), approach)}.txt", analyzer.Warnings.ToString());

        //    }
        //    catch (Exception)
        //    {
        //    }
        //}

        internal ElementTree ContainerScope(ElementTree t) => t.Ancestors().First(
                    a => a.Root.Label == "unit" ||
                         a.Root.Label == "namespace" ||
                         a.Root.Label == "interface" ||
                         a.Root.Label == "class" ||
                         a.Root.Label == "struct" ||
                         a.Root.Label == "enum" ||
                         a.Root.Label == "function" ||
                         a.Root.Label == "function_decl" ||
                         a.Root.Label == "constructor" ||
                         a.Root.Label == "destructor" ||
                         a.Root.Label == "property" ||
                         a.Root.Label == "call" ||
                         a.Root.Label == "parameter");

        protected virtual IEnumerable<MissedNameContext> NameContexts
        {
            get
            {
                yield return new MissedNameContext
                {
                    Label = "decl", /*Type = "Field",*/
                    NameOf = delegate(ElementTree tree)
                    {
                        var scope = ContainerScope(tree);
                        switch (scope.Root.Label)
                        {
                            case "interface":
                            case "class":
                            case "struct": return "field";
                            case "enum": return "enumvalue";
                            case "call": return "actual argument";
                            case "parameter": return "formal argument";
                            default: return "variable";
                        }
                    },
                    Criterion = t => t.IsVariableDeclarationName(n => n.Parent, n => n.Root.Label),
                    OuterScopes = tree => tree.Ancestors().Where(ancestor => ancestor.Root.Label == "block")
                };
                yield return new MissedNameContext
                {
                    Label = "function", /*Type = "Function",*/
                    NameOf = t => "function",
                    Criterion = t => t.IsFunctionDefinitionName(n => n.Parent, n => n.Root.Label) &&
                                     t.Root.Value != "get" && t.Root.Value != "set" &&
                                     t.Root.Value != "add" && t.Root.Value != "remove" &&
                                     !string.IsNullOrEmpty(t.Root.Value),
                    OuterScopes = tree => tree.Ancestors().Where(ancestor => ancestor.Root.Label == "block")
                };
                yield return new MissedNameContext
                {
                    Label = "constructor", /*Type = "Property",*/
                    NameOf = t => "constructor",
                    Criterion = t => t.IsConstructorName(n => n.Parent, n => n.Root.Label),
                    OuterScopes = tree => tree.Ancestors().Where(ancestor => ancestor.Root.Label == "block")
                };
                yield return new MissedNameContext
                {
                    Label = "destructor", /*Type = "Property",*/
                    NameOf = t => "destructor",
                    Criterion = t => t.IsDestructorName(n => n.Parent, n => n.Root.Label),
                    OuterScopes = tree => tree.Ancestors().Where(ancestor => ancestor.Root.Label == "block")
                };
                yield return new MissedNameContext
                {
                    Label = "property", /*Type = "Property",*/
                    NameOf = t => "property",
                    Criterion = t => t.IsPropertyName(n => n.Parent, n => n.Root.Label),
                    OuterScopes = tree => tree.Ancestors().Where(ancestor => ancestor.Root.Label == "block")
                };
                yield return new MissedNameContext
                {
                    Label = "class", /*Type = "Property",*/
                    NameOf = t => "class",
                    Criterion = t => t.IsClassName(n => n.Parent, n => n.Root.Label),
                    OuterScopes = tree => tree.Ancestors().Where(ancestor => ancestor.Root.Label == "block")
                };
                yield return new MissedNameContext
                {
                    Label = "struct", /*Type = "Property",*/
                    NameOf = t => "struct",
                    Criterion = t => t.IsStructName(n => n.Parent, n => n.Root.Label),
                    OuterScopes = tree => tree.Ancestors().Where(ancestor => ancestor.Root.Label == "block" ||
                                                                             ancestor.Root.Label == "namespace" ||
                                                                             ancestor.Root.Label == "unit")
                };
                yield return new MissedNameContext
                {
                    Label = "interface", /*Type = "Property",*/
                    NameOf = t => "interface",
                    Criterion = t => t.IsInterfaceName(n => n.Parent, n => n.Root.Label),
                    OuterScopes = tree => tree.Ancestors().Where(ancestor => ancestor.Root.Label == "block" ||
                                                                             ancestor.Root.Label == "namespace" ||
                                                                             ancestor.Root.Label == "unit")
                };
                yield return new MissedNameContext
                {
                    Label = "enum", /*Type = "Property",*/
                    NameOf = t => "enum",
                    Criterion = t => t.IsEnumName(n => n.Parent, n => n.Root.Label),
                    OuterScopes = tree => tree.Ancestors().Where(ancestor => ancestor.Root.Label == "block" ||
                                                                             ancestor.Root.Label == "namespace" ||
                                                                             ancestor.Root.Label == "unit")
                };
                // missing the namespaces...
            }
        }

        /// <summary>
        /// Represents an element name must be analyzed.
        /// </summary>
        public class CandidateName
        {
            /// <summary>
            /// Gets or sets the tree representing the candidate element name.
            /// </summary>
            public virtual ElementTree Tree { get; set; }

            /// <summary>
            /// Gets or sets the context of the candidate element name.
            /// </summary>
            public virtual MissedNameContext Context { get; set; }
        }
        
        public virtual IEnumerable<NameCoexistenceSymptom> FindConfusingRenames(Delta delta, CancellationToken token)
        {
            var detectionResult = (DetectionResult)delta.DetectionResult;
            if (!detectionResult.Actions.OfType<UpdateOperationDescriptor>().Any())
                yield break;

            var originalTree = ElementTree.Read(delta.OriginalTree, Encoding.Unicode);
            var modifiedTree = ElementTree.Read(delta.ModifiedTree, Encoding.Unicode);

            var updates = detectionResult.Actions.OfType<UpdateOperationDescriptor>()
                .Where(m => m.Element.Label == "name")
                .Select(delegate (UpdateOperationDescriptor t)
                {
                    var match = detectionResult.Matches.Single(m => m.Original.Id == t.Element.Id);
                    var modified = modifiedTree.PostOrder(n => n.Children).First(n => n.Root.Id == match.Modified.Id);
                    var original = originalTree.PostOrder(n => n.Children).First(n => n.Root.Id == t.Element.Id);
                    return new RevisionPair<ElementTree, ElementTree>
                    {
                        Original = original,
                        Modified = modified
                    };
                })
                //.Select(t => )
                .Select(t => new { Matching = t, Context = this.NameContexts.SingleOrDefault(nm => nm.Criterion(t.Original) && nm.Criterion(t.Modified)) })
                .Where(t => t.Context != null)
                //.Select(t => new { CandidateName = t, OriginalTree = detectionResult.Matches.SingleOrDefault(m => m.Modified.Id == t.Tree.Root.Id) })
                .ToList();

            var renameContexts = new HashSet<MissedNameContext>();
            foreach (var update in updates.Where(u => !renameContexts.Contains(u.Context)))
            {
                renameContexts.Add(update.Context);
            }
            
            // Analysis per name type.
            foreach (var missedNameContext in renameContexts)
            {
                var existingNames = originalTree.PostOrder(n => n.Children).Where(n => missedNameContext.Criterion(n)).ToList();
                foreach (var update in updates.Where(u => u.Context == missedNameContext))
                {
                    var existingName = existingNames.FirstOrDefault(n => n.Root.Value == update.Matching.Modified.Root.Value);
                    //var originalName = existingNames.FirstOrDefault(n => n.Root.Value == update.Matching.Original.Root.Value);

                    if (existingName != null)
                    {
                        yield return new NameCoexistenceSymptom
                        {
                            Id = Guid.NewGuid(),
                            Original = new ElementContext
                            {
                                Element = new ElementDescription
                                {
                                    Id = update.Matching.Original.Root.Id,
                                    Type = this.NameContexts.Single(nc => nc.Criterion(update.Matching.Original)).NameOf(update.Matching.Original),
                                    Hint = update.Matching.Original.Root.Value
                                },
                                ScopeHint = this.GetPath(update.Context.OuterScopes(update.Matching.Original))
                            },
                            Modified = new ElementContext
                            {
                                Element = new ElementDescription
                                {
                                    Id = update.Matching.Modified.Root.Id,
                                    Type = this.NameContexts.Single(nc => nc.Criterion(update.Matching.Modified)).NameOf(update.Matching.Modified),
                                    Hint = update.Matching.Modified.Root.Value
                                },
                                ScopeHint = this.GetPath(update.Context.OuterScopes(update.Matching.Modified))
                            },
                            CoexistingOriginal = new ElementContext
                            {
                                Element = new ElementDescription
                                {
                                    Id = existingName.Root.Id,
                                    Type = this.NameContexts.Single(nc => nc.Criterion(existingName)).NameOf(existingName),
                                    Hint = existingName.Root.Value
                                },
                                ScopeHint = this.GetPath(update.Context.OuterScopes(existingName))
                            }
                        };
                    }
                }
            }

            //var updatedNamesM = detectionResult.Actions.OfType<UpdateOperationDescriptor>()
            //    .Where(m => m.Element.Label == "name")
            //    .Select(delegate (UpdateOperationDescriptor t)
            //    {
            //        var match = detectionResult.Matches.Single(m => m.Original.Id == t.Element.Id);
            //        return modifiedTree.PostOrder(n => n.Children).First(n => n.Root.Id == match.Modified.Id);
            //    })
            //    .Select(t => new CandidateName { Tree = t, Context = this.NameContexts.SingleOrDefault(nm => nm.Criterion(t)) })
            //    .Where(t => t.Context != null)
            //    .ToList();
        }

        /// <summary>
        /// Reports a summary of the file revision pairs of the given Git SQL database.
        /// </summary>
        /// <returns><see cref="Tuple{T1,T2,T3}.Item1"/> total of file revision pairs, <see cref="Tuple{T1,T2,T3}.Item2"/> count 
        /// of revision pairs with source code changes, and <see cref="Tuple{T1,T2,T3}.Item3"/> of revision pairs with only comment changes.</returns>
        public virtual Tuple<int, int, int> Summarize()
        {
            int frpWithCodeChanges = 0, frpWithOnlyCommentChanges = 0;
            foreach (var fileRevisionPair in this.SqlRepository.FileRevisionPairs.AsNoTracking().Include(frp => frp.Principal))
            {
                var sourceCodeChanges = fileRevisionPair.Principal.XAnnotations.SourceCodeChanges;
                frpWithCodeChanges += sourceCodeChanges ? 1 : 0;
                frpWithOnlyCommentChanges += sourceCodeChanges && fileRevisionPair.Principal.XAnnotations.OnlyCommentChanges ? 1 : 0;
            }
            return new Tuple<int, int, int>(this.SqlRepository.FileRevisionPairs.Count(),
                                            frpWithCodeChanges,
                                            frpWithOnlyCommentChanges);
        }
    }
}
