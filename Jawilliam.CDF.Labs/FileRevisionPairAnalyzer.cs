using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
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
        /// Gets or sets tthe count of milliseconds to declare a time out analysis.
        /// </summary>
        public int MillisecondsTimeout { get; set; } = 300000;

        /// <summary>
        /// Gets or sets the warnings to report.
        /// </summary>
        public StringBuilder Warnings { get; set; }

        /// <summary>
        /// Analyzes a given repository object.
        /// </summary>
        /// <param name="repositoryObject">the repository object for analyzing.</param>
        /// <param name="cancelToken">logic for receiving the cancellation notifications.</param>
        public delegate void AnalyzeDelegate(FileRevisionPair repositoryObject, CancellationToken cancelToken);

        /// <summary>
        /// Analyzes every file version of the given repository.
        /// </summary>
        /// <param name="sqlRepository">the SQL database repository in which to analyze the file versions.</param>
        /// <param name="repositoryObjectName"></param>
        /// <param name="onThese">expression to filter the objects of interest.</param>
        /// <param name="analysis">an action for characterizing the analysis.</param>
        /// <param name="cancel">Action to execute cancellation logic.</param>
        /// <param name="includes">paths to include in the query.</param>
        protected virtual void Analyze(GitRepository sqlRepository, string repositoryObjectName, Expression<Func<FileRevisionPair, bool>> onThese, AnalyzeDelegate analysis, Action cancel, params string[] includes)
        {
            if (analysis == null) throw new ArgumentNullException(nameof(analysis));

            var repositoryObjectIds = sqlRepository.Name == "OpenRA" 
                ? sqlRepository.FileRevisionPairs
                    .Where(onThese)
                    .Select(fv => fv.Id).ToList().Skip(1638).ToList()
                : sqlRepository.FileRevisionPairs
                    .Where(onThese)
                    .Select(fv => fv.Id).ToList();

            int counter = 0;
            foreach (var repositoryObjectId in repositoryObjectIds)
            {
                var repositoryObjectQuery = sqlRepository.FileRevisionPairs.AsQueryable();
                repositoryObjectQuery = includes.Aggregate(repositoryObjectQuery, (current, include) => current.Include(include));
                FileRevisionPair repositoryObject = repositoryObjectQuery.Single(c => c.Id == repositoryObjectId);

                Console.Out.WriteLine($"Analyzing the {++counter}-{repositoryObjectName} ({repositoryObjectIds.Count}) of {sqlRepository.Name}");
                var cancellationTokenSource = new CancellationTokenSource();
                var cancellationToken = cancellationTokenSource.Token;
                try
                {
                    try
                    {
                        var t = Task.Run(() => analysis(repositoryObject, cancellationToken), cancellationToken);
                        t.Wait(this.MillisecondsTimeout);
                        cancellationTokenSource.Cancel();
                        cancel?.Invoke();

                        t.Wait();
                    }
                    catch (AggregateException ae)
                    {
                        throw ae.InnerException;
                    }
                    catch (OperationCanceledException)
                    {
                        this.Warnings.AppendLine($"5 minutes Timeout - {repositoryObjectName}-{repositoryObject.Id}");
                    }
                    catch (OutOfMemoryException)
                    {
                        this.Warnings.AppendLine($"ERROR - {repositoryObjectName}-{repositoryObject.Id}");
                    }

                }
                catch (InsufficientExecutionStackException)
                {
                    this.Warnings.AppendLine($"InsufficientExecutionStack - fileversion-{repositoryObjectName}-{repositoryObject.Id}");
                }
                catch (OperationCanceledException)
                {
                    this.Warnings.AppendLine($"5 minutes Timeout - {repositoryObjectName}-{repositoryObject.Id}");
                }
                catch (InvalidOperationException)
                {
                    this.Warnings.AppendLine($"ERROR - {repositoryObjectName}-{repositoryObject.Id}");
                }
                catch (OutOfMemoryException)
                {
                    this.Warnings.AppendLine($"ERROR - {repositoryObjectName}-{repositoryObject.Id}");
                }

                Console.Out.WriteLine($"Saving the {counter}-file version ({repositoryObjectIds.Count}) of {sqlRepository.Name}");
                sqlRepository.Flush();
            }
        }

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
        /// <param name="sqlRepository">the SQL database repository in which to analyze the file versions.</param>
        /// <param name="onThese">expression to filter the objects of interest.</param>
        /// <param name="analysis">an action for characterizing the analysis.</param>
        /// <param name="cancel">Action to execute cancellation logic.</param>
        /// <param name="includes">paths to include in the query.</param>
        protected virtual void Analyze(GitRepository sqlRepository, Expression<Func<FileRevisionPair, bool>> onThese, AnalyzeDelegate analysis, Action cancel, params string[] includes)
        {
            this.Analyze(sqlRepository, "file modified change",
                onThese ?? (f => f.Principal.FromFileVersion.ContentSummary.TotalLines != null && f.Principal.FileVersion.ContentSummary.TotalLines != null),
                analysis, cancel,
                includes ?? new[] { "Principal.FileVersion.Content", "Principal.FileVersion.ContentSummary", "Principal.FromFileVersion.ContentSummary", "Principal.FromFileVersion.Content" });
        }

        /// <summary>
        /// Analyzes every file version of the given repository.
        /// </summary>
        /// <param name="sqlRepository">the SQL database repository in which to analyze the file versions.</param>
        /// <param name="onThese">expression to filter the objects of interest.</param>
        /// <param name="analysis">an action for characterizing the analysis given the normalized trees.</param>
        /// <param name="cancel">Action to execute cancellation logic.</param>
        /// <param name="includes">paths to include in the query.</param>
        protected virtual void Analyze(GitRepository sqlRepository, Expression<Func<FileRevisionPair, bool>> onThese, CoreAnalyzeDelegate analysis, Action cancel, params string[] includes)
        {
            this.Analyze(sqlRepository, "file modified change",
                onThese ?? (f => f.Principal.FromFileVersion.ContentSummary.TotalLines != null && f.Principal.FileVersion.ContentSummary.TotalLines != null),
                delegate (FileRevisionPair repositoryObject, CancellationToken cancelToken)
                {
                    var originalRoot = SyntaxFactory.ParseCompilationUnit(repositoryObject.Principal.FromFileVersion.Content.SourceCode).SyntaxTree.GetRoot();
                    var originalContentNode = originalRoot.NormalizeWhitespace("", Environment.NewLine);

                    var modifiedRoot = SyntaxFactory.ParseCompilationUnit(repositoryObject.Principal.FileVersion.Content.SourceCode).SyntaxTree.GetRoot();
                    var modifiedContentNode = modifiedRoot.NormalizeWhitespace("", Environment.NewLine);

                    analysis(repositoryObject, originalContentNode, modifiedContentNode, cancelToken);
                },
                cancel,
            includes ?? new[] { "Principal.FileVersion.Content", "Principal.FileVersion.ContentSummary", "Principal.FromFileVersion.ContentSummary", "Principal.FromFileVersion.Content" });
        }

        /// <summary>
        /// Analyzes the similarity in according with a given similarity metric, such as Levenshtein.
        /// </summary>
        /// <param name="sqlRepository">the SQL database repository in which to analyze the file versions.</param>
        /// <param name="interopArgs">the arguments for the interoperability.</param>
        /// <param name="gumTree">the native approach based on the GumTree interoperability.</param>
        /// <param name="cancel">Action to execute cancellation logic.</param>
        /// <param name="gumTreeApproach"></param>
        /// <param name="skipThese">local criterion for determining elements that should be ignored.</param>
        /// <param name="cleaner">A preprocessor for the source code in case it is desired.</param>
        public virtual void NativeGumTreeDiff(GitRepository sqlRepository, GumTreeNativeApproach gumTree, InteropArgs interopArgs, Action cancel, ChangeDetectionApproaches gumTreeApproach, Func<FileRevisionPair, bool> skipThese, SourceCodeCleaner cleaner = null)
        {
            this.Analyze(sqlRepository/*, f => f.Principal.Deltas.Any(d => d.Approach == gumTreeApproach)*/,
            f => f.Principal.Deltas.Any(d => d.Approach == ChangeDetectionApproaches.NativeGumTreeWithoutComments) /*&& 
                 f.Deltas.All(d => d.Approach != gumTreeApproach), // I am running Levenshtein before, so the longer cases have been already rejected.
            */,delegate (FileRevisionPair repositoryObject, SyntaxNode original, SyntaxNode modified, CancellationToken token)
            {
                if (!repositoryObject.Principal.XAnnotations.SourceCodeChanges || (skipThese?.Invoke(repositoryObject) ?? false))
                    return;

                sqlRepository.Deltas.Where(d => d.RevisionPair.Id == repositoryObject.Principal.Id && d.Approach == gumTreeApproach)
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
            },
            cancel,
            "Principal.FileVersion.Content", "Principal.FromFileVersion.Content");
        }
        
        /// <summary>
        /// Analyzes the similarity in according with a given similarity metric, such as Levenshtein.
        /// </summary>
        /// <param name="sqlRepository">the SQL database repository in which to analyze the file versions.</param>
        /// <param name="interopArgs">the arguments for the interoperability.</param>
        /// <param name="gumTree">the native approach based on the GumTree interoperability.</param>
        /// <param name="cancel">Action to execute cancellation logic.</param>
        /// <param name="gumTreeApproach"></param>
        /// <param name="skipThese">local criterion for determining elements that should be ignored.</param>
        /// <param name="cleaner">A preprocessor for the source code in case it is desired.</param>
        public virtual void SaveNativeTrees(GitRepository sqlRepository, GumTreeNativeApproach gumTree, InteropArgs interopArgs, Action cancel, ChangeDetectionApproaches gumTreeApproach, Func<FileRevisionPair, bool> skipThese, SourceCodeCleaner cleaner = null)
        {
            this.Analyze(sqlRepository,
              f => f.Principal.Deltas.Any(d => d.Approach == gumTreeApproach), 
              delegate (FileRevisionPair repositoryObject, SyntaxNode original, SyntaxNode modified, CancellationToken token)
              {
                  if (!repositoryObject.Principal.XAnnotations.SourceCodeChanges || (skipThese?.Invoke(repositoryObject) ?? false))
                      return;

                  sqlRepository.Deltas.Where(d => d.RevisionPair.Id == repositoryObject.Principal.Id && d.Approach == gumTreeApproach)
                      .Load();

                  var delta = repositoryObject.Principal.Deltas.Single(d => d.Approach == gumTreeApproach);
                  if (delta.Report != null || (delta.OriginalTree != null && delta.ModifiedTree != null)/* ||
                      delta.Id == Guid.Parse("0f962b83-5d9d-4206-98e8-aebce28b96ce") ||
                      delta.Id == Guid.Parse("dd055762-51a7-4fe2-8f0b-1fbeb0a058e0") ||
                      delta.Id == Guid.Parse("3cf9f44c-6542-41d5-9ee2-3c3359a47166") ||
                      delta.Id == Guid.Parse("a52d6658-64e9-4903-a650-302c5a2ac0ee") ||
                      delta.Id == Guid.Parse("5cdb1d99-555c-4395-9d4a-a97b25be5fc6") ||
                      delta.Id == Guid.Parse("8ccb108d-c8e6-457b-bf68-3f41069e7ed9") ||
                      delta.Id == Guid.Parse("5fd16607-6089-4ab9-91f0-788c88fb4c5c")*/)
                      return;

                  var preprocessedOriginal = cleaner != null ? cleaner.Clean(original) : original;
                  var preprocessedModified = cleaner != null ? cleaner.Clean(modified) : modified;
                  System.IO.File.WriteAllText(interopArgs.Original, preprocessedOriginal.ToFullString());
                  System.IO.File.WriteAllText(interopArgs.Modified, preprocessedModified.ToFullString());

                  //try
                  //{
                      var originalTree = gumTree.ParseTree(interopArgs, false);
                      var modifiedTree = gumTree.ParseTree(interopArgs, true);

                      int index = 0;
                      originalTree.PostOrder(t => t.Children).ForEach(t => t.Root.Id = index++.ToString(CultureInfo.InvariantCulture));
                      delta.OriginalTree = originalTree.WriteXmlColumn();

                      index = 0;
                      modifiedTree.PostOrder(t => t.Children).ForEach(t => t.Root.Id = index++.ToString(CultureInfo.InvariantCulture));
                      delta.ModifiedTree = modifiedTree.WriteXmlColumn();

                      // Checking heuristics 
                      //var detectionResult = (DetectionResult)delta.DetectionResult;
                      //foreach (var match in detectionResult.Matches)
                      //{
                      //    var o = originalTree.PreOrder(t => t.Children).Single(t => t.Root.Id == match.Original.Id);
                      //    var m = modifiedTree.PreOrder(t => t.Children).Single(t => t.Root.Id == match.Modified.Id);
                      //    Debug.Assert(o.Root.Label == match.Original.Label);
                      //    Debug.Assert(m.Root.Label == match.Original.Label);
                      //}

                      //foreach (var insert in detectionResult.Actions.OfType<InsertOperationDescriptor>())
                      //{
                      //    var element = modifiedTree.PreOrder(t => t.Children).Single(t => t.Root.Id == insert.Element.Id);
                      //    //var parent = originalTree.PreOrder(t => t.Children).Single(t => t.Root.Id == insert.Parent.Id);
                      //    Debug.Assert(element.Root.Label == insert.Element.Label);
                      //    //Debug.Assert(parent.Root.Label == insert.Parent.Label);
                      //}

                      //foreach (var delete in detectionResult.Actions.OfType<DeleteOperationDescriptor>())
                      //{
                      //    var element = originalTree.PreOrder(t => t.Children).Single(t => t.Root.Id == delete.Element.Id);
                      //    Debug.Assert(element.Root.Label == delete.Element.Label);
                      //}
                  //}
                  //catch (Exception e)
                  //{
                  //    ;
                  //    throw new InvalidOperationException();
                  //}
              },
            cancel,
            "Principal.FileVersion.Content", "Principal.FromFileVersion.Content");
        }

        /// <summary>
        /// Filters the file revision pairs that satisfy a particular criterion.
        /// </summary>
        /// <param name="sqlRepository">the SQL database repository in which to analyze the file versions.</param>
        /// <param name="repositoryObjectName">name of the repository</param>
        /// <param name="onThese">expression to filter the objects of interest.</param>
        /// <param name="action">the filtering criterion</param>
        /// <param name="includes">paths to include in the query.</param>
        public virtual void ForEach(GitRepository sqlRepository, string repositoryObjectName, Expression<Func<FileRevisionPair, bool>> onThese, Action<FileRevisionPair> action, params string[] includes)
        {
            var repositoryObjectIds = sqlRepository.FileRevisionPairs
                   .Where(onThese)
                   .Select(fv => fv.Id).ToList();

            var counter = 0;
            foreach (var repositoryObjectId in repositoryObjectIds)
            {
                var repositoryObjectQuery = sqlRepository.FileRevisionPairs.AsQueryable();
                repositoryObjectQuery = includes.Aggregate(repositoryObjectQuery, (current, include) => current.Include(include));
                var repositoryObject = repositoryObjectQuery.Single(c => c.Id == repositoryObjectId);

                Console.Out.WriteLine($"Analyzing the {++counter}-{repositoryObjectName} ({repositoryObjectIds.Count}) of {sqlRepository.Name}");
                action(repositoryObject);
            }
        }

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

        /// <summary>
        /// Finds possible missed matches MM.a (i.e., both t1 and t2 do not match to other element)
        /// </summary>
        /// <param name="delta">delta to analyze.</param>
        /// <returns>a collection of the candidate missed matches found in the given delta (element: <see cref="Tuple{T1,T2}.Item1"/>, ancestor: <see cref="Tuple{T1,T2}.Item2"/>).</returns>
        public virtual IEnumerable<Tuple<ElementTree, ElementTree>> FindMissedMatchesAOfKeyedElement(Delta delta)
        {
            var detectionResult = DetectionResult.Read($"<Result>{delta.Matching}{delta.Differencing}</Result>", Encoding.Unicode);
            var insertedNames = detectionResult.Actions.OfType<InsertOperationDescriptor>()
                .Where(m => m.Element.Label == "name" &&
                            !string.IsNullOrWhiteSpace(m.Element.Value) &&
                            !string.IsNullOrEmpty(m.Element.Value))
                .Select(t => delta.GetModifiedNode(t.Element.Id))
                .ToList();
            var deletedNames = detectionResult.Actions.OfType<DeleteOperationDescriptor>()
                .Where(m => m.Element.Label == "name" &&
                            !string.IsNullOrWhiteSpace(m.Element.Value) &&
                            !string.IsNullOrEmpty(m.Element.Value))
                .Select(t => delta.GetOriginalNode(t.Element.Id))
                .ToList();

            if(!deletedNames.Any())
                yield break;
            
            foreach (var insertedName in insertedNames)
            {
                var matchedAncestors = (from a in insertedName.Ancestors()
                                       let ancestorMatching = detectionResult.Matches.SingleOrDefault(m => m.Modified.Id == a.Root.Id)
                                       where ancestorMatching != null
                                       select new { Modified = a, Original = ancestorMatching.Original })
                                       .ToList();

                var candidate = matchedAncestors.FirstOrDefault(ancestor =>
                    deletedNames.Any(t => t.Root.Value == insertedName.Root.Value &&
                                          t.Ancestors().Any(a => ancestor.Original.Id == a.Root.Id)));

                if(candidate != null)
                    yield return new Tuple<ElementTree, ElementTree>(insertedName, candidate.Modified);

                ////var redundantCandidates = new List<Tuple<ElementTree, ElementTree>>();
                //foreach (var ancestor in matchedAncestors)
                //{
                //    var localCandidates = deletedNames.Where()
                //                                                  .ToList();
                //    if (localCandidates.Any())
                //    {
                //        foreach (var localCandidate in localCandidates)
                //        {
                //            yield return new Tuple<ElementTree, ElementTree>(localCandidate, ancestor.Ancestor);

                //        }
                //    }
                //}
            }
        }
    }
}
