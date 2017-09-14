﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
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

            var repositoryObjectIds = sqlRepository.FileRevisionPairs
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

        protected virtual IEnumerable<MissedNameContext> NameContexts
        {
            get
            {
                Func<ElementTree, ElementTree> containerScope = t => t.Ancestors().First(
                    a => a.Root.Label == "unit" ||
                         a.Root.Label == "namespace" ||
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

                yield return new MissedNameContext
                {
                    Label = "decl", /*Type = "Field",*/
                    NameOf = delegate(ElementTree tree)
                    {
                        var scope = containerScope(tree);
                        switch (scope.Root.Label)
                        {
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
            }
        }

        /// <summary>
        /// Represents an element name must be analyzed.
        /// </summary>
        protected class CandidateName
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

        /// <summary>
        /// Finds possible missed matches MM.a (i.e., both t1 and t2 do not match to other element)
        /// </summary>
        /// <param name="delta">delta to analyze.</param>
        /// <returns>a collection of the candidate missed matches found in the given delta.</returns>
        public virtual IEnumerable<MissedMatch> FindMissedMatchesAOfKeyedElement(Delta delta)
        {
            //    Label = "namespace",
            //    Label = "using",
            var originalTree = ElementTree.Read(delta.OriginalTree, Encoding.Unicode);
            var modifiedTree = ElementTree.Read(delta.ModifiedTree, Encoding.Unicode);
            var detectionResult = (DetectionResult)delta.DetectionResult;

            // Missed matches - Deleted and Inserted
            var insertedNames = detectionResult.Actions.OfType<InsertOperationDescriptor>()
                .Where(m => m.Element.Label == "name")
                .Select(t => modifiedTree.PostOrder(n => n.Children).First(n => n.Root.Id == t.Element.Id))
                .Select(t => new CandidateName { Tree = t, Context = this.NameContexts.SingleOrDefault(nm => nm.Criterion(t)) })
                .Where(t => t.Context != null)
                .ToList();
            var deletedNames = detectionResult.Actions.OfType<DeleteOperationDescriptor>()
                .Where(m => m.Element.Label == "name")
                .Select(t => originalTree.PostOrder(n => n.Children).First(n => n.Root.Id == t.Element.Id))
                .Select(t => new CandidateName { Tree = t, Context = this.NameContexts.SingleOrDefault(nm => nm.Criterion(t)) })
                .Where(t => t.Context != null)
                .ToList();
            var matchedInsertionAncestors = (from a in insertedNames
                                             from outerScope in a.Context.OuterScopes(a.Tree)
                                             let ancestorMatching = detectionResult.Matches.SingleOrDefault(m => m.Modified.Id == outerScope.Root.Id)
                                             where ancestorMatching != null
                                             select new RevisionPair<ElementDescriptor, ElementTree> { Modified = outerScope, Original = ancestorMatching.Original })
                                            .ToList();
            foreach (var missedMatch in this.FindMissedMatches("MM.DI", deletedNames, insertedNames, matchedInsertionAncestors))
                yield return missedMatch;

            // Missed matches - Updated and Inserted
            var updatedNamesO = detectionResult.Actions.OfType<UpdateOperationDescriptor>()
                .Where(m => m.Element.Label == "name")
                .Select(t => originalTree.PostOrder(n => n.Children).First(n => n.Root.Id == t.Element.Id))
                .Select(t => new CandidateName { Tree = t, Context = this.NameContexts.SingleOrDefault(nm => nm.Criterion(t)) })
                .Where(t => t.Context != null)
                .ToList();
            foreach (var missedMatch in this.FindMissedMatches("MM.UI", updatedNamesO, insertedNames, matchedInsertionAncestors))
                yield return missedMatch;

            // Missed matches - Deleted and Updated
            var updatedNamesM = detectionResult.Actions.OfType<UpdateOperationDescriptor>()
                .Where(m => m.Element.Label == "name")
                .Select(delegate(UpdateOperationDescriptor t)
                {
                    var match = detectionResult.Matches.Single(m => m.Original.Id == t.Element.Id);
                    return modifiedTree.PostOrder(n => n.Children).First(n => n.Root.Id == match.Modified.Id);
                })
                .Select(t => new CandidateName { Tree = t, Context = this.NameContexts.SingleOrDefault(nm => nm.Criterion(t)) })
                .Where(t => t.Context != null)
                .ToList();
            var matchedUpdateAncestors = (from a in updatedNamesM
                                          from outerScope in a.Context.OuterScopes(a.Tree)
                                          let ancestorMatching = detectionResult.Matches.SingleOrDefault(m => m.Modified.Id == outerScope.Root.Id)
                                          where ancestorMatching != null
                                          select new RevisionPair<ElementDescriptor, ElementTree> { Modified = outerScope, Original = ancestorMatching.Original })
                                         .ToList();
            foreach (var missedMatch in this.FindMissedMatches("MM.DU", deletedNames, updatedNamesM, matchedUpdateAncestors))
                yield return missedMatch;

            foreach (var missedMatch in this.FindMissedMatches("MM.UU", updatedNamesO, updatedNamesM, matchedUpdateAncestors, 
                (or, mo) => detectionResult.Matches.Any(m => m.Original.Id == or.Tree.Root.Id && m.Modified.Id == mo.Tree.Root.Id)))
                yield return missedMatch;

            var movedNamesM = detectionResult.Actions.OfType<MoveOperationDescriptor>()
                .Where(m => m.Element.Label == "name")
                .Select(delegate (MoveOperationDescriptor t)
                {
                    var match = detectionResult.Matches.Single(m => m.Original.Id == t.Element.Id);
                    return modifiedTree.PostOrder(n => n.Children).First(n => n.Root.Id == match.Modified.Id);
                })
                .Select(t => new CandidateName { Tree = t, Context = this.NameContexts.SingleOrDefault(nm => nm.Criterion(t)) })
                .Where(t => t.Context != null)
                .ToList();
            var matchedMoveAncestors = (from a in movedNamesM
                                        from outerScope in a.Context.OuterScopes(a.Tree)
                                        let ancestorMatching = detectionResult.Matches.SingleOrDefault(m => m.Modified.Id == outerScope.Root.Id)
                                        where ancestorMatching != null
                                        select new RevisionPair<ElementDescriptor, ElementTree> { Modified = outerScope, Original = ancestorMatching.Original })
                                       .ToList();
            foreach (var missedMatch in this.FindMissedMatches("MM.DM", deletedNames, movedNamesM, matchedMoveAncestors))
                yield return missedMatch;

            var movedNamesO = detectionResult.Actions.OfType<MoveOperationDescriptor>()
                .Where(m => m.Element.Label == "name")
                .Select(delegate (MoveOperationDescriptor t)
                {
                    var match = detectionResult.Matches.Single(m => m.Original.Id == t.Element.Id);
                    return originalTree.PostOrder(n => n.Children).First(n => n.Root.Id == match.Original.Id);
                })
                .Select(t => new CandidateName { Tree = t, Context = this.NameContexts.SingleOrDefault(nm => nm.Criterion(t)) })
                .Where(t => t.Context != null)
                .ToList();
            foreach (var missedMatch in this.FindMissedMatches("MM.MI", movedNamesO, insertedNames, matchedInsertionAncestors))
                yield return missedMatch;

            foreach (var missedMatch in this.FindMissedMatches("MM.MM", movedNamesO, movedNamesM, matchedMoveAncestors,
                (or, mo) => detectionResult.Matches.Any(m => m.Original.Id == or.Tree.Root.Id && m.Modified.Id == mo.Tree.Root.Id)))
                yield return missedMatch;

            foreach (var missedMatch in this.FindMissedMatches("MM.M", movedNamesO, movedNamesM, matchedMoveAncestors))
                yield return missedMatch;

            foreach (var missedMatch in this.FindMissedMatches("MM.UM", updatedNamesO, movedNamesM, matchedMoveAncestors))
                yield return missedMatch;

            foreach (var missedMatch in this.FindMissedMatches("MM.MU", movedNamesO, updatedNamesM, matchedUpdateAncestors))
                yield return missedMatch;
        }

        protected virtual IEnumerable<MissedMatch> FindMissedMatches(string mismatchingCase, List<CandidateName> originalNames, List<CandidateName> modifiedNames, List<RevisionPair<ElementDescriptor, ElementTree>> matchedModifiedAncestors, Func<CandidateName, CandidateName, bool> skipThese = null)
        {
            if (originalNames.Any() && modifiedNames.Any())
            {
                foreach (var modifiedName in modifiedNames)
                {
                    foreach (var originalName in originalNames.Where(d => d.Tree.Root.Value == modifiedName.Tree.Root.Value))
                    {
                        if (skipThese != null && skipThese(originalName, modifiedName))
                            continue;

                        var originalScopes = originalName.Context.OuterScopes(originalName.Tree);
                        var candidate = matchedModifiedAncestors.FirstOrDefault(ma => originalScopes.Any(a => a.Root.Id == ma.Original.Id));
                        if (candidate != null)
                        {
                            yield return new MissedMatch
                            {
                                Case = mismatchingCase,
                                Modified = new MissedVersion
                                {
                                    Type = modifiedName.Context.NameOf(modifiedName.Tree),
                                    Element = modifiedName.Tree,
                                    MatchedReference = candidate.Modified,
                                    Scopes = modifiedName.Context.OuterScopes(modifiedName.Tree)
                                },
                                Original = new MissedVersion
                                {
                                    Type = originalName.Context.NameOf(originalName.Tree),
                                    Element = originalName.Tree,
                                    MatchedReference = originalScopes.Single(a => a.Root.Id == candidate.Original.Id),
                                    Scopes = originalName.Context.OuterScopes(originalName.Tree)
                                }
                            };
                        }
                    }
                }
            }
        }
    }
}
