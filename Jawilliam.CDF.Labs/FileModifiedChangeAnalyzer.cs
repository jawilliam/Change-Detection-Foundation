using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Jawilliam.CDF.Actions;
using Jawilliam.CDF.Approach;
using Jawilliam.CDF.Approach.GumTree;
using Jawilliam.CDF.Approach.Matching.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Jawilliam.CDF.Labs.DBModel;
using Jawilliam.CDF.Approach.Criterions.Simetric;

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
        /// <param name="cancel">Action to execute cancellation logic.</param>
        /// <param name="includes">paths to include in the query.</param>
        protected virtual void Analyze(GitRepository sqlRepository, Expression<Func<FileModifiedChange, bool>> onThese, AnalyzeDelegate analysis, Action cancel, params string[] includes)
        {
            this.Analyze(sqlRepository, "file modified change",
                onThese ?? (f => f.FromFileVersion.ContentSummary.TotalLines != null && f.FileVersion.ContentSummary.TotalLines != null),
                analysis, cancel,
                includes ?? new []{"FileVersion.Content", "FileVersion.ContentSummary", "FromFileVersion.ContentSummary", "FromFileVersion.Content"});
        }

        /// <summary>
        /// Analyzes every file version of the given repository.
        /// </summary>
        /// <param name="sqlRepository">the SQL database repository in which to analyze the file versions.</param>
        /// <param name="onThese">expression to filter the objects of interest.</param>
        /// <param name="analysis">an action for characterizing the analysis given the normalized trees.</param>
        /// <param name="cancel">Action to execute cancellation logic.</param>
        /// <param name="includes">paths to include in the query.</param>
        protected virtual void Analyze(GitRepository sqlRepository, Expression<Func<FileModifiedChange, bool>> onThese, CoreAnalyzeDelegate analysis, Action cancel, params string[] includes)
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
                cancel,
            includes ?? new[] { "FileVersion.Content", "FileVersion.ContentSummary", "FromFileVersion.ContentSummary", "FromFileVersion.Content" });
        }

        /// <summary>
        /// Analyzes if there actually are source code changes between the file modified pairs of the given repository.
        /// </summary>
        /// <param name="sqlRepository">the SQL database repository in which to analyze the file versions.</param>
        /// <param name="cancel">Action to execute cancellation logic.</param>
        public virtual void AnalyzeIfThereAreSourceCodeChanges(GitRepository sqlRepository, Action cancel)
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
            cancel,
            "FileVersion.Content", "FileVersion.ContentSummary", "FromFileVersion.ContentSummary", "FromFileVersion.Content");
        }

        /// <summary>
        /// Analyzes if there actually are only comment changes between the file modified pairs of the given repository.
        /// </summary>
        /// <param name="sqlRepository">the SQL database repository in which to analyze the file versions.</param>
        /// <param name="cancel">Action to execute cancellation logic.</param>
        public virtual void AnalyzeIfThereAreOnlyCommentChanges(GitRepository sqlRepository, Action cancel)
        {
            this.Analyze(sqlRepository, "file modified change",
                f => f.FromFileVersion.ContentSummary.TotalLines != null && f.FileVersion.ContentSummary.TotalLines != null,
                delegate (FileModifiedChange repositoryObject, CancellationToken cancelToken)
                {
                    if (repositoryObject.FromFileVersion.Content.SourceCode == null ||
                        repositoryObject.FileVersion.Content.SourceCode == null)
                        return;

                    SourceCodeCleaner cleaner = new SourceCodeCleaner
                    {
                        Normalize = true,
                        Indentation = "",
                        NewLine = Environment.NewLine,
                        RemoveComments = true
                    };

                    var xAnnotations = repositoryObject.XAnnotations;
                    if (!xAnnotations.SourceCodeChanges)
                        return;

                    var originalRoot = SyntaxFactory.ParseCompilationUnit(repositoryObject.FromFileVersion.Content.SourceCode).SyntaxTree.GetRoot();
                    var originalContentNode = cleaner.Clean(originalRoot);

                    var modifiedRoot = SyntaxFactory.ParseCompilationUnit(repositoryObject.FileVersion.Content.SourceCode).SyntaxTree.GetRoot();
                    var modifiedContentNode = cleaner.Clean(modifiedRoot);
                    
                    xAnnotations.OnlyCommentChanges = originalContentNode.ToFullString() == modifiedContentNode.ToFullString();
                    repositoryObject.XAnnotations = xAnnotations;
                },
            cancel,
            "FileVersion.Content", "FileVersion.ContentSummary", "FromFileVersion.ContentSummary", "FromFileVersion.Content");
        }

        /// <summary>
        /// Analyzes the similarity in according with a given similarity metric, such as Levenshtein.
        /// </summary>
        /// <param name="sqlRepository">the SQL database repository in which to analyze the file versions.</param>
        /// <param name="simetricName">the name of the similarity metric</param>
        /// <param name="simetric"></param>
        /// <param name="cancel">Action to execute cancellation logic.</param>
        /// <param name="skipThese">local criterion for determining elements that should be ignored.</param>
        /// <param name="onThese"></param>
        /// <param name="cleaner">A preprocessor for the source code in case it is desired.</param>
        public virtual void SimetricDiff(GitRepository sqlRepository, string simetricName, ISimetric<SyntaxToken> simetric, Action cancel, Func<FileModifiedChange, bool> skipThese, Expression<Func<FileModifiedChange, bool>> onThese, SourceCodeCleaner cleaner = null)
        {
            this.Analyze(sqlRepository, 
            onThese,
            delegate(FileModifiedChange repositoryObject, SyntaxNode original, SyntaxNode modified, CancellationToken token)
            {
                if (!repositoryObject.XAnnotations.SourceCodeChanges || (skipThese?.Invoke(repositoryObject) ?? false))
                    return;

                var preprocessedOriginal = cleaner != null ? cleaner.Clean(original) : original;
                var preprocessedModified = cleaner != null ? cleaner.Clean(modified) : modified;
                var originalTokens = preprocessedOriginal.DescendantTokens(descendIntoTrivia: true).ToList();
                var modifiedTokens = preprocessedModified.DescendantTokens(descendIntoTrivia: true).ToList();

                //sqlRepository.Deltas.Where(d => sqlRepository.RepositoryObjects.OfType<FileModifiedChange>()
                //    .Any(f => f.Id == repositoryObject.Id && f.Deltas.Any(fd => fd.Approach == ChangeDetectionApproaches.Simetrics)))
                //    .Load();
                sqlRepository.Deltas.Where(d => d.RevisionPair.Id == repositoryObject.Id && d.Approach == ChangeDetectionApproaches.Simetrics)
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
                //simetric.CancellationToken = token;
                xSimetric.Similarity = simetric.GetSimilarity(originalTokens, modifiedTokens, out distance);
                Debug.Assert(distance != null, "distance != null");
                xSimetric.Distance = distance.Value;

                simetricDelta.XAnnotations = xDeltaAnnotations;
            }, cancel,
            "FileVersion.Content", "FromFileVersion.Content");
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
        public virtual void NativeGumTreeDiff(GitRepository sqlRepository, GumTreeNativeApproach gumTree, InteropArgs interopArgs, Action cancel, ChangeDetectionApproaches gumTreeApproach, Func<FileModifiedChange, bool> skipThese, SourceCodeCleaner cleaner = null)
        {
            this.Analyze(sqlRepository,
                f => f.Deltas.Any(d => d.Approach == gumTreeApproach),
            //f => f.Deltas.Any(d => d.Approach == ChangeDetectionApproaches.Simetrics) && 
            //     f.Deltas.All(d => d.Approach != gumTreeApproach), // I am running Levenshtein before, so the longer cases have been already rejected.
            delegate (FileModifiedChange repositoryObject, SyntaxNode original, SyntaxNode modified, CancellationToken token)
            {
                if (!repositoryObject.XAnnotations.SourceCodeChanges || (skipThese?.Invoke(repositoryObject) ?? false))
                    return;

                sqlRepository.Deltas.Where(d => d.RevisionPair.Id == repositoryObject.Id && d.Approach == gumTreeApproach)
                    .Load();

                var delta = repositoryObject.Deltas.SingleOrDefault(d => d.Approach == gumTreeApproach);
                if (delta == null)
                {
                    delta = new Delta { Id = Guid.NewGuid(), Approach = gumTreeApproach };
                    repositoryObject.Deltas.Add(delta);
                }

                var preprocessedOriginal = cleaner != null ? cleaner.Clean(original) : original;
                var preprocessedModified = cleaner != null ? cleaner.Clean(modified) : modified;
                System.IO.File.WriteAllText(interopArgs.Original, preprocessedOriginal.ToFullString());
                System.IO.File.WriteAllText(interopArgs.Modified, preprocessedModified.ToFullString());

                try
                {
                    gumTree.Run(interopArgs);
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
                    XElement result =
                        XElement.Parse(writeXmlColumn.Replace("﻿<?xml version=\"1.0\" encoding=\"utf-16\"?>", ""));
                    delta.Matching =
                        new XDocument(result.Element("Matches")).ToString()
                            .Replace("\r\n", "")
                            .Replace(" />  <", "/><")
                            .Replace(">  <", "><");
                    delta.Differencing =
                        new XDocument(result.Element("Actions")).ToString()
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
            "FileVersion.Content", "FromFileVersion.Content");
        }

        /// <summary>
        /// Analyzes the similarity in according with a given similarity metric, such as Levenshtein.
        /// </summary>
        /// <param name="sqlRepository">the SQL database repository in which to analyze the file versions.</param>
        /// <param name="interopArgs">the arguments for the interoperability.</param>
        /// <param name="gumTree">the native approach based on the GumTree interoperability.</param>
        /// <param name="simetricName">the name of the similarity metric</param>
        /// <param name="simetric"></param>
        /// <param name="cancel">Action to execute cancellation logic.</param>
        /// <param name="gumTreeApproach"></param>
        /// <param name="skipThese">local criterion for determining elements that should be ignored.</param>
        /// <param name="cleaner">A preprocessor for the source code in case it is desired.</param>
        public virtual void NativeGumTreeAndSimetricDiffByMethods(GitRepository sqlRepository, GumTreeNativeApproach gumTree, string simetricName, ISimetric<SyntaxToken> simetric, InteropArgs interopArgs, Action cancel, ChangeDetectionApproaches gumTreeApproach, Func<FileModifiedChange, bool> skipThese, SourceCodeCleaner cleaner = null)
        {
            this.Analyze(sqlRepository,
            f => f.Deltas.Any(d => d.Approach == ChangeDetectionApproaches.Simetrics) &&
                 f.Deltas.Any(d => d.Approach == ChangeDetectionApproaches.NativeGumTreeWithoutComments),
            delegate (FileModifiedChange repositoryObject, SyntaxNode original, SyntaxNode modified, CancellationToken token)
            {
                if (!repositoryObject.XAnnotations.SourceCodeChanges || (skipThese?.Invoke(repositoryObject) ?? false))
                    return;

                sqlRepository.Deltas.Where(d => d.RevisionPair.Id == repositoryObject.Id && d.Approach == gumTreeApproach)
                    .Load();

                var delta = repositoryObject.Deltas.SingleOrDefault(d => d.Approach == gumTreeApproach);
                if (delta == null)
                {
                    delta = new Delta {Id = Guid.NewGuid(), Approach = gumTreeApproach};
                    repositoryObject.Deltas.Add(delta);
                }
                //else return;

                var preprocessedOriginal = cleaner != null ? cleaner.Clean(original) : original;
                var preprocessedModified = cleaner != null ? cleaner.Clean(modified) : modified;
                Func<MethodDeclarationSyntax, string> getName = syntax => syntax.Ancestors().Reverse()
                    .Where(a => a.Kind() == SyntaxKind.NamespaceDeclaration ||
                                a.Kind() == SyntaxKind.ClassDeclaration ||
                                a.Kind() == SyntaxKind.StructDeclaration ||
                                a.Kind() == SyntaxKind.InterfaceDeclaration)
                    .Aggregate("", (s, a) => s + (s == "" ? "" : ".") + (a.Kind() == SyntaxKind.NamespaceDeclaration
                        ? ((NamespaceDeclarationSyntax)a).Name.ToFullString()
                        : ((BaseTypeDeclarationSyntax)a).Identifier.ValueText +
                          ((TypeDeclarationSyntax)a).TypeParameterList?.ToFullString() ?? ""))?.Replace("\r\n", "")
                    + $".{syntax.Identifier.ValueText}";

                //Action getFullName = 
                var originalMethods = (from m in preprocessedOriginal.DescendantNodes().OfType<MethodDeclarationSyntax>()
                                       select new Data1 { Name = getName(m), Method = m, Matched = false }).ToList();
                var modifiedMethods = (from m in preprocessedModified.DescendantNodes().OfType<MethodDeclarationSyntax>()
                                       select new Data1 { Name = getName(m), Method = m, Matched = false }).ToList();
                //if (originalMethods.All(m => m.Method.Identifier.ValueText != "CreateHardLink"))
                //    return;

                List<Tuple<MethodDeclarationSyntax, MethodDeclarationSyntax, string, string>> sameNamedMethods = new List<Tuple<MethodDeclarationSyntax, MethodDeclarationSyntax, string, string>>();
                System.IO.File.WriteAllText(@"E:\Phd\Analysis\Original.cs", preprocessedOriginal.ToFullString());
                System.IO.File.WriteAllText(@"E:\Phd\Analysis\Modified.cs", preprocessedModified.ToFullString());
                var matcher = new MatchingProvider();

                foreach (var originalMethod in originalMethods)
                {
                    sameNamedMethods.AddRange(modifiedMethods.Where(modifiedMethod =>
                    {
                        var matchingResult = matcher.Match(originalMethod.Method, modifiedMethod.Method, MethodDeclarationMatchingOptions.GlobalKey);
                        if (matchingResult.HasFlag(MethodDeclarationMatchingOptions.GlobalKey))
                        {
                            Debug.Assert(!modifiedMethod.Matched && !originalMethod.Matched);
                            originalMethod.Matched = true;
                            modifiedMethod.Matched = true;
                            return true;
                        }
                        return false;
                    })
                    .Select(p => new Tuple<MethodDeclarationSyntax, MethodDeclarationSyntax, string, string>(originalMethod.Method, p.Method, originalMethod.Name, p.Name))
                    .ToList());
                }

                foreach (var originalMethod in originalMethods.Where(o => !o.Matched))
                {
                    if (modifiedMethods.Count(mm => !mm.Matched && mm.Method.Identifier.ValueText == originalMethod.Method.Identifier.ValueText) > 1)
                        ;

                    sameNamedMethods.AddRange(modifiedMethods.Where(o => !o.Matched).Where(modifiedMethod =>
                    {
                        if (originalMethod.Matched)
                            return false;
                        var matchingResult = matcher.Match(originalMethod.Method, modifiedMethod.Method, MethodDeclarationMatchingOptions.GlobalKey);
                        //if (matchingResult.HasFlag(MethodDeclarationMatchingOptions.GlobalKey))
                        //{
                        //    Debug.Assert(!modifiedMethod.Matched);
                        //    originalMethod.Matched = true;
                        //    modifiedMethod.Matched = true;
                        //    return true;
                        //}
                        if (originalMethod.Name == modifiedMethod.Name.Replace("Akka.Cluster.Proto.Msg", "Akka.Cluster.Proto") && matchingResult.HasFlag(MethodDeclarationMatchingOptions.RelativeKey))
                        {
                            Debug.Assert(!modifiedMethod.Matched && !originalMethod.Matched);
                            originalMethod.Matched = true;
                            modifiedMethod.Matched = true;
                            return true;
                        }
                        if (matchingResult.HasFlag(MethodDeclarationMatchingOptions.RelativeKey))
                        {
                            Debug.Assert(!modifiedMethod.Matched && !originalMethod.Matched);
                            originalMethod.Matched = true;
                            modifiedMethod.Matched = true;
                            return true;
                        }
                        if (matchingResult.HasFlag(MethodDeclarationMatchingOptions.LocalKey))
                        {
                            Debug.Assert(!modifiedMethod.Matched && !originalMethod.Matched);
                            originalMethod.Matched = true;
                            modifiedMethod.Matched = true;
                            return true;
                        }

                        if (matchingResult.HasFlag(MethodDeclarationMatchingOptions.Name) && !modifiedMethod.Matched)
                        {
                            ; //Check if it is a same conceptual but moved method
                            // return true;
                        }

                        return false;
                    })
                    .Select(p => new Tuple<MethodDeclarationSyntax, MethodDeclarationSyntax, string, string>(originalMethod.Method, p.Method, originalMethod.Name, p.Name))
                    .ToList());
                }
                //sameNamedMethods = sameNamedMethods.Where(m => m.Item1.ToFullString() != m.Item2.ToFullString()).ToList();

                if (!sameNamedMethods.Any())
                {
                    repositoryObject.Deltas.Remove(delta);
                    //sqlRepository.Deltas.Remove(delta);
                    return;
                }

                XElement matches = new XElement("Matches"), diffs = new XElement("Actions");
                foreach (var sameNamedMethod in sameNamedMethods)
                {
                    var originalContent = sameNamedMethod.Item1.ToFullString();
                    var modifiedContent = sameNamedMethod.Item2.ToFullString();
                    var unchangedMethod = originalContent == modifiedContent;

                    var id = Guid.NewGuid();
                    var matching = new XElement("MethodRevision", new XAttribute("sourceCodeChanges", XmlConvert.ToString(!unchangedMethod)));
                    this.SetPairInfo(matching, id, sameNamedMethod);
                    matches.Add(matching);
                    if (unchangedMethod)
                        continue;

                    System.IO.File.WriteAllText(interopArgs.Original, originalContent);
                    System.IO.File.WriteAllText(interopArgs.Modified, modifiedContent);
                    try
                    {
                        gumTree.Run(interopArgs);
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
                        matching.Add(XElement.Parse(result.Element("Matches").ToString().Replace("\r\n", "").Replace(" />  <", "/><").Replace(">  <", "><")));
                        var differencing = XElement.Parse(result.Element("Actions").ToString().Replace("\r\n", "").Replace(" />  <", "/><").Replace(">  <", "><"));
                        this.SetPairInfo(differencing, id, sameNamedMethod);
                        //differencing.Add(new XAttribute("id", id));
                        diffs.Add(differencing);

                        var originalTokens = sameNamedMethod.Item1.DescendantTokens(descendIntoTrivia: true).ToList();
                        var modifiedTokens = sameNamedMethod.Item2.DescendantTokens(descendIntoTrivia: true).ToList();

                        double? distance;
                        //simetric.CancellationToken = token;
                        var similarity = simetric.GetSimilarity(originalTokens, modifiedTokens, out distance);
                        Debug.Assert(distance != null, "distance != null");
                        differencing.Add(new XAttribute($"{simetricName}Similarity", similarity));
                        differencing.Add(new XAttribute($"{simetricName}Distance", distance.Value));
                    }
                }

                delta.Matching = matches.ToString();
                delta.Differencing = diffs.HasElements ? diffs.ToString().Replace("\r\n", "").Replace(" />  <", "/><").Replace(">  <", "><") : null;
            },
            cancel,
            "FileVersion.Content", "FromFileVersion.Content");
        }

        private void SetPairInfo(XElement element, Guid id, Tuple<MethodDeclarationSyntax, MethodDeclarationSyntax, string, string> sameNamedMethod)
        {
            element.Add(new XAttribute("id", id));

            if (sameNamedMethod.Item1.ExplicitInterfaceSpecifier != null)
                element.Add("omeis", sameNamedMethod.Item1.ExplicitInterfaceSpecifier.ToFullString().Replace("<", "&lt;").Replace(">", "&gt;"));
            element.Add(new XAttribute("om",
                $"{sameNamedMethod.Item3}" +
                $"{sameNamedMethod.Item1.TypeParameterList?.ToFullString() ?? ""}" +
                $"{sameNamedMethod.Item1.ParameterList.ToFullString()}"
                    .Replace("\r\n", "").Replace("<", "&lt;").Replace(">", "&gt;")));

            if (sameNamedMethod.Item2.ExplicitInterfaceSpecifier != null)
                element.Add("mmeis", sameNamedMethod.Item2.ExplicitInterfaceSpecifier.ToFullString().Replace("<", "&lt;").Replace(">", "&gt;"));
            element.Add(new XAttribute("mm",
                $"{sameNamedMethod.Item4}" +
                $"{sameNamedMethod.Item2.TypeParameterList?.ToFullString() ?? ""}" +
                $"{sameNamedMethod.Item2.ParameterList.ToFullString()}"
                    .Replace("\r\n", "").Replace("<", "&lt;").Replace(">", "&gt;")));
        }

        class Data1
        {
            internal string Name { get; set; }
            internal MethodDeclarationSyntax Method { get; set; }
            internal bool Matched { get; set; }
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
        public virtual void ComplementDeltaInfos(GitRepository sqlRepository, GumTreeNativeApproach gumTree, InteropArgs interopArgs, Action cancel, ChangeDetectionApproaches gumTreeApproach, Func<FileModifiedChange, bool> skipThese, SourceCodeCleaner cleaner = null)
        {
            this.Analyze(sqlRepository,
            f => f.Deltas.Any(d => d.Approach == gumTreeApproach),
            delegate (FileModifiedChange repositoryObject, SyntaxNode original, SyntaxNode modified, CancellationToken token)
            {
                if (!repositoryObject.XAnnotations.SourceCodeChanges || (skipThese?.Invoke(repositoryObject) ?? false))
                    return;

                sqlRepository.Deltas.Where(d => d.RevisionPair.Id == repositoryObject.Id && d.Approach == gumTreeApproach).Load();
                var delta = repositoryObject.Deltas.Single(d => d.Approach == gumTreeApproach);

                var preprocessedOriginal = cleaner != null ? cleaner.Clean(original) : original;
                var preprocessedModified = cleaner != null ? cleaner.Clean(modified) : modified;
                System.IO.File.WriteAllText(interopArgs.Original, preprocessedOriginal.ToFullString());
                System.IO.File.WriteAllText(interopArgs.Modified, preprocessedModified.ToFullString());

                var detectionResult = DetectionResult.Read($"<Result>{delta.Matching}{delta.Differencing}</Result>", Encoding.Unicode);

                var diff = gumTree.ExecuteDiffCommand(new InteropArgs());
                var lines = diff.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
                var temp = "";
                var lines1 = lines;
                lines = lines.Select(delegate(string s, int p)
                {
                    temp += s + "\n";
                    if (p < lines1.Length - 1 &&
                        !lines1[p + 1].StartsWith("Match ") &&
                        !lines1[p + 1].StartsWith("Insert ") &&
                        !lines1[p + 1].StartsWith("Update ") &&
                        !lines1[p + 1].StartsWith("Delete ") &&
                        !lines1[p + 1].StartsWith("Move "))
                    {
                        return null;
                    }

                    string g = temp.TrimEnd('\n');
                    temp = "";
                    return g;
                }).ToArray();
                lines = lines.Where(l => l != null).ToArray();
                gumTree.CompleteDeltaInfo(detectionResult.Matches, detectionResult.Actions.OfType<OperationDescriptor>(), lines);

                var writeXmlColumn = detectionResult.WriteXmlColumn();
                XElement result = XElement.Parse(writeXmlColumn.Replace("﻿<?xml version=\"1.0\" encoding=\"utf-16\"?>", ""));
                delta.Matching = new XDocument(result.Element("Matches")).ToString()
                        .Replace("\r\n", "")
                        .Replace(" />  <", "/><")
                        .Replace(">  <", "><");
                delta.Differencing = new XDocument(result.Element("Actions")).ToString()
                        .Replace("\r\n", "")
                        .Replace(" />  <", "/><")
                        .Replace(">  <", "><");
            },
            cancel,
            "FileVersion.Content", "FromFileVersion.Content");
        }
    }
}
