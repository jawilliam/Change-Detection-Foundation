using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Jawilliam.CDF.Actions;
using Jawilliam.CDF.Approach;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Jawilliam.CDF.Labs
{
    /// <summary>
    /// Implements imprecision diagnostic through a redundancy checking.
    /// </summary>
    public class RedundancyChecking<TSubject> : ImprecisionDiagnostic<MissedElement>
    {
        /// <summary>
        /// Gets or sets the configuration to check for redundancies.
        /// </summary>
        public virtual Criterion Config { get; set; }

        /// <summary>
        /// Finds symptoms of imprecisions by redundant changes in a given delta.
        /// </summary>
        /// <param name="delta">delta to analyze.</param>
        /// <param name="token">mechanism for cancelling the analisys.</param>
        /// <returns>a collection of the candidate missed matches found in the given delta.</returns>
        protected virtual IEnumerable<MissedElement> FindMissedMatches(Delta delta, CancellationToken token)
        {
            var originalTree = ElementTree.Read(delta.OriginalTree, Encoding.Unicode);
            var modifiedTree = ElementTree.Read(delta.ModifiedTree, Encoding.Unicode);
            var detectionResult = (DetectionResult)delta.DetectionResult;

            // Missed matches - Deleted and Inserted
            var insertedNames = detectionResult.Actions.OfType<InsertOperationDescriptor>()
                .Where(this.Config.IsSubject)
                .Select(t => modifiedTree.PostOrder(n => n.Children).First(n => n.Root.Id == t.Element.Id))
                .Select(this.Config.AsSubject)
                .Where(t => t != null)
                .ToList();
            var deletedNames = detectionResult.Actions.OfType<DeleteOperationDescriptor>()
                .Where(this.Config.IsSubject)
                .Select(t => originalTree.PostOrder(n => n.Children).First(n => n.Root.Id == t.Element.Id))
                .Select(this.Config.AsSubject)
                .Where(t => t != null)
                .ToList();
            var matchedInsertionAncestors = (from a in insertedNames
                                             from outerScope in this.Config.GetScopes(a)
                                             let ancestorMatching = detectionResult.Matches.SingleOrDefault(m => m.Modified.Id == outerScope.Root.Id)
                                             where ancestorMatching != null
                                             select new RevisionPair<ElementDescriptor, ElementTree> { Modified = outerScope, Original = ancestorMatching.Original })
                                            .ToList();
            foreach (var missedMatch in this.FindMissedMatchesBy("DI", 
                deletedNames, insertedNames, matchedInsertionAncestors, token, detectionResult))
                yield return missedMatch;

            // Missed matches - Updated and Inserted
            var updatedNamesO = detectionResult.Actions.OfType<UpdateOperationDescriptor>()
                .Where(this.Config.IsSubject)
                .Select(t => originalTree.PostOrder(n => n.Children).First(n => n.Root.Id == t.Element.Id))
                .Select(this.Config.AsSubject)
                .Where(t => t != null)
                .ToList();
            foreach (var missedMatch in this.FindMissedMatchesBy("UI", 
                updatedNamesO, insertedNames, matchedInsertionAncestors, token, detectionResult))
                yield return missedMatch;

            // Missed matches - Deleted and Updated
            var updatedNamesM = detectionResult.Actions.OfType<UpdateOperationDescriptor>()
                .Where(this.Config.IsSubject)
                .Cast<UpdateOperationDescriptor>()
                .Select(delegate (UpdateOperationDescriptor t)
                {
                    var match = detectionResult.Matches.Single(m => m.Original.Id == t.Element.Id);
                    return modifiedTree.PostOrder(n => n.Children).First(n => n.Root.Id == match.Modified.Id);
                })
                .Select(this.Config.AsSubject)
                .Where(t => t != null)
                .ToList();
            var matchedUpdateAncestors = (from a in updatedNamesM
                                          from outerScope in this.Config.GetScopes(a)
                                          let ancestorMatching = detectionResult.Matches.SingleOrDefault(m => m.Modified.Id == outerScope.Root.Id)
                                          where ancestorMatching != null
                                          select new RevisionPair<ElementDescriptor, ElementTree> { Modified = outerScope, Original = ancestorMatching.Original })
                                         .ToList();
            foreach (var missedMatch in this.FindMissedMatchesBy("DU", 
                deletedNames, updatedNamesM, matchedUpdateAncestors, token, detectionResult))
                yield return missedMatch;

            foreach (var missedMatch in this.FindMissedMatchesBy("UU", 
                updatedNamesO, updatedNamesM, matchedUpdateAncestors, token, detectionResult, 
                (or, mo) => this.Config.FilterOut(or, mo, "UU", detectionResult)))
                yield return missedMatch;

            var movedNamesM = detectionResult.Actions.OfType<MoveOperationDescriptor>()
                .Where(this.Config.IsSubject)
                .Cast<MoveOperationDescriptor>()
                .Select(delegate (MoveOperationDescriptor t)
                {
                    var match = detectionResult.Matches.Single(m => m.Original.Id == t.Element.Id);
                    return modifiedTree.PostOrder(n => n.Children).First(n => n.Root.Id == match.Modified.Id);
                })
                .Select(this.Config.AsSubject)
                .Where(t => t != null)
                .ToList();
            var matchedMoveAncestors = (from a in movedNamesM
                                        from outerScope in this.Config.GetScopes(a)
                                        let ancestorMatching = detectionResult.Matches.SingleOrDefault(m => m.Modified.Id == outerScope.Root.Id)
                                        where ancestorMatching != null
                                        select new RevisionPair<ElementDescriptor, ElementTree> { Modified = outerScope, Original = ancestorMatching.Original })
                                       .ToList();
            foreach (var missedMatch in this.FindMissedMatchesBy("DM", 
                deletedNames, movedNamesM, matchedMoveAncestors, token, detectionResult))
                yield return missedMatch;

            var movedNamesO = detectionResult.Actions.OfType<MoveOperationDescriptor>()
                .Where(this.Config.IsSubject)
                .Cast<MoveOperationDescriptor>()
                .Select(delegate (MoveOperationDescriptor t)
                {
                    var match = detectionResult.Matches.Single(m => m.Original.Id == t.Element.Id);
                    return originalTree.PostOrder(n => n.Children).First(n => n.Root.Id == match.Original.Id);
                })
                .Select(this.Config.AsSubject)
                .Where(t => t != null)
                .ToList();
            foreach (var missedMatch in this.FindMissedMatchesBy("MI", 
                movedNamesO, insertedNames, matchedInsertionAncestors, token, detectionResult))
                yield return missedMatch;

            foreach (var missedMatch in this.FindMissedMatchesBy("MM", 
                movedNamesO, movedNamesM, matchedMoveAncestors, token, detectionResult,
                (or, mo) => this.Config.FilterOut(or, mo, "MM", detectionResult)))
                yield return missedMatch;

            foreach (var missedMatch in this.FindMissedMatchesBy("M", 
                movedNamesO, movedNamesM, matchedMoveAncestors, token, detectionResult))
                yield return missedMatch;

            foreach (var missedMatch in this.FindMissedMatchesBy("UM", 
                updatedNamesO, movedNamesM, matchedMoveAncestors, token, detectionResult))
                yield return missedMatch;

            foreach (var missedMatch in this.FindMissedMatchesBy("MU", 
                movedNamesO, updatedNamesM, matchedUpdateAncestors, token, detectionResult))
                yield return missedMatch;
        }

        /// <summary>
        /// Finds subject mismatches by recognizing a specific redundancy pattern.
        /// </summary>
        /// <param name="pattern">redundancy pattern to look for.</param>
        /// <param name="originalSubjects">original subjects of interest.</param>
        /// <param name="modifiedSubjects">modified subjects of interest.</param>
        /// <param name="matchedModifiedAncestors"></param>
        /// <param name="delta">delta to analyze.</param>
        /// <param name="token">mechanism for cancelling the analisys.</param>
        /// <param name="skipThese"></param>
        /// <returns>symptoms of imprecisions by redundant changes.</returns>
        protected virtual IEnumerable<MissedElement> FindMissedMatchesBy(string pattern,
            List<TSubject> originalSubjects, List<TSubject> modifiedSubjects,
            List<RevisionPair<ElementDescriptor, ElementTree>> matchedModifiedAncestors,
            CancellationToken token, DetectionResult delta, 
            Func<TSubject, TSubject, bool> skipThese = null)
        {
            if (originalSubjects.Any() && modifiedSubjects.Any())
            {
                foreach (var modifiedSubject in modifiedSubjects)
                {
                    foreach (var originalSubject in originalSubjects.Where(d => this.Config.AreRedundant(d, modifiedSubject, pattern, delta)))
                    {
                        if (token.IsCancellationRequested)
                            token.ThrowIfCancellationRequested();

                        if (skipThese != null && skipThese(originalSubject, modifiedSubject))
                            continue;

                        var originalScopes = this.Config.GetScopes(originalSubject).ToList();
                        var candidate = matchedModifiedAncestors.FirstOrDefault(ma => originalScopes.Any(a => a.Root.Id == ma.Original.Id));
                        if (candidate != null)
                        {
                            var result = this.Config.AsResult(originalSubject, modifiedSubject, pattern, delta);
                            result.Case = $"{this.Config.Nickname}.{pattern}";
                            result.Original.MatchedReference = originalScopes.Single(a => a.Root.Id == candidate.Original.Id);
                            result.Original.Scopes = originalScopes;
                            result.Modified.MatchedReference = candidate.Modified;
                            result.Modified.Scopes = this.Config.GetScopes(modifiedSubject);
                            yield return result;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Looks for symptoms of imprecision.
        /// </summary>
        public override void Recognize()
        {
            this.Recognize(ChangeDetectionApproaches.NativeGumTree);
        }

        /// <summary>
        /// Looks for symptoms of imprecision.
        /// </summary>
        /// <param name="approach">change detection variant to consider for each file revision pair.</param>
        /// <param name="skipThese">local criterion for determining elements that should be ignored.</param>
        /// <param name="saveChanges">Enables or disables the persistence of the changes.</param>
        public virtual void Recognize(ChangeDetectionApproaches approach, Func<FileRevisionPair, bool> skipThese = null, bool saveChanges = true)
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
                        var missedMatchesA = this.FindMissedMatches(delta, token);
                        foreach (var missedMatchA in missedMatchesA)
                        {
                            var originalAncestorOfReference = missedMatchA.Original.Element.LabelOf(t => t.Parent, t => t.Root.Label == "name")
                                .First(a => a.Root.Label != "name").Ancestors().First();
                            var modifiedAncestorOfReference = missedMatchA.Modified.Element.LabelOf(t => t.Parent, t => t.Root.Label == "name")
                                .First(a => a.Root.Label != "name").Ancestors().First();
                            var missedNameSymptom = new MissedNameSymptom
                            {
                                Id = Guid.NewGuid(),
                                Pattern = missedMatchA.Case,
                                Original = new MissedMatch
                                {
                                    Element = new ElementDescription
                                    {
                                        Hint = missedMatchA.Original.Element.Root.Value,
                                        Id = missedMatchA.Original.Element.Root.Id,
                                        Type = missedMatchA.Original.Type
                                    },
                                    AncestorOfReference = new ElementDescription
                                    {
                                        Hint = this.GetBreadcrum(originalAncestorOfReference),
                                        Id = originalAncestorOfReference.Root.Id,
                                        Type = originalAncestorOfReference.Root.Label
                                    },
                                    CommonAncestorOfReference = new ElementDescription
                                    {
                                        Hint = this.GetBreadcrum(missedMatchA.Original.MatchedReference),
                                        Id = missedMatchA.Original.MatchedReference.Root.Id,
                                        Type = missedMatchA.Original.MatchedReference.Root.Label
                                    },
                                    ScopeHint = this.GetPath(missedMatchA.Original.Element.LabelOf(t => t.Parent, t => t.Root.Label == "name").First(a => a.Root.Label != "name").Ancestors())
                                },
                                Modified = new MissedMatch
                                {
                                    Element = new ElementDescription
                                    {
                                        Hint = missedMatchA.Modified.Element.Root.Value,
                                        Id = missedMatchA.Modified.Element.Root.Id,
                                        Type = missedMatchA.Modified.Type
                                    },
                                    AncestorOfReference = new ElementDescription
                                    {
                                        Hint = this.GetBreadcrum(modifiedAncestorOfReference),
                                        Id = modifiedAncestorOfReference.Root.Id,
                                        Type = modifiedAncestorOfReference.Root.Label
                                    },
                                    CommonAncestorOfReference = new ElementDescription
                                    {
                                        Hint = this.GetBreadcrum(missedMatchA.Modified.MatchedReference),
                                        Id = missedMatchA.Modified.MatchedReference.Root.Id,
                                        Type = missedMatchA.Modified.MatchedReference.Root.Label
                                    },
                                    ScopeHint = this.GetPath(missedMatchA.Modified.Element.LabelOf(t => t.Parent, t => t.Root.Label == "name").First(a => a.Root.Label != "name").Ancestors())
                                }
                            };

                            if(saveChanges)
                                delta.Symptoms.Add(missedNameSymptom);
                        }
                    }
                    catch (OperationCanceledException) { this.Report.AppendLine($"CANCELED;{pair.Id}"); throw; }
                    catch (OutOfMemoryException) { this.Report.AppendLine($"OUTOFMEMORY;{pair.Id}"); throw; }
                }, saveChanges, "Principal");
        }

        /// <summary>
        /// Iterates symptoms to be rated.
        /// </summary>
        public override void Rate()
        {
            this.Rate(ChangeDetectionApproaches.NativeGumTree, null, 
                @"E:\Phd\Analysis\Original.cs",
                @"E:\Phd\Analysis\Modified.cs");
        }

        /// <summary>
        /// Iterates symptoms to be rated.
        /// </summary>
        /// <param name="approach">change detection variant to consider for each file revision pair.</param>
        /// <param name="cleaner"></param>
        /// <param name="originalFilePath"></param>
        /// <param name="modifiedFilePath"></param>
        public virtual void Rate(ChangeDetectionApproaches approach, SourceCodeCleaner cleaner, string originalFilePath, string modifiedFilePath)
        {
            this.Analyze(f => (f.Flags == null || (f.Flags & RevisionPairFlags.EnumAnomalies) == 0) && f.Principal.Deltas.Any(d => d.Approach == approach &&
                                               d.Matching != null &&
                                               d.Differencing != null &&
                                               d.Report == null &&
                                               d.Symptoms.OfType<MissedNameSymptom>().Any(s => s.Original.Element.Type == "actual argument" && s.Modified.Element.Type == "actual argument")),
                delegate (FileRevisionPair pair, CancellationToken token)
                {
                    //if (skipThese?.Invoke(pair) ?? false) return;
                    //if ((pair.Flags & RevisionPairFlags.EnumAnomalies) != 0)
                    //    return;

                    var delta = this.SqlRepository.Deltas.Single(d => d.RevisionPair.Id == pair.Principal.Id && d.Approach == approach);
                    var symptomIds = this.SqlRepository.Symptoms.OfType<MissedNameSymptom>()
                        .Where(s => s.Delta.Id == delta.Id)
                        .Where(s => s.Original.Element.Type == "actual argument" && s.Modified.Element.Type == "actual argument")
                        .Select(s => s.Id).ToList();

                    //var cleaner = new SourceCodeCleaner();
                    var original = SyntaxFactory.ParseCompilationUnit(pair.Principal.FromFileVersion.Content.SourceCode).SyntaxTree.GetRoot();
                    var modified = SyntaxFactory.ParseCompilationUnit(pair.Principal.FileVersion.Content.SourceCode).SyntaxTree.GetRoot();

                    var preprocessedOriginal = cleaner != null ? cleaner.Clean(original) : original;
                    var preprocessedModified = cleaner != null ? cleaner.Clean(modified) : modified;
                    System.IO.File.WriteAllText(originalFilePath, preprocessedOriginal.ToFullString(), Encoding.Default);
                    System.IO.File.WriteAllText(modifiedFilePath, preprocessedModified.ToFullString(), Encoding.Default);

                    var pairs = new[]
                    {
                    //new { Oid="3104", Opg="414", Mid="3209", Mpg="437", Name = (string)null },
                    //new { Oid="3127", Opg="418", Mid="3280", Mpg="447", Name = (string)null },
                    new { Oid="-1", Opg="-1", Mid="-1", Mpg="-1", Name = (string)null },
                    //new { Oid="", Opg="", Mid="", Mpg="", Name = (string)null }
                    };

                    foreach (var symptomId in symptomIds)
                    {
                        this.SqlRepository.Symptoms.OfType<MissedNameSymptom>().Where(s => s.Id == symptomId).Load();
                        var symptom = delta.Symptoms.OfType<MissedNameSymptom>().Single(s => s.Id == symptomId);

                        if (symptom.Original.Element.Hint == null || symptom.Modified.Element.Hint == null ||
                            symptom.Original.Element.Hint.Length == 1 ||
                            symptom.Modified.Element.Hint.Length == 1)
                            continue;

                        var o = pairs.SingleOrDefault(p => p.Oid == symptom.Original.Element.Id);
                        var m = pairs.SingleOrDefault(p => p.Mid == symptom.Modified.Element.Id);
                        if (o != null && m != null)
                        {
                            Review review;
                            if (o != m)
                                review = new Review
                                {
                                    Id = Guid.NewGuid(),
                                    Kind = ReviewKind.Redundancy_MissedName,
                                    CaseKind = CaseKind.Symptom,
                                    Severity = ReviewSeverity.Bad,
                                    Subject = $"Imprecise Missed match - {symptom.Original.Element.Type} named by \"{o.Name ?? symptom.Original.Element.Hint}\"-(ol:{o.Opg}, oid:{symptom.Original.Element.Id})" +
                                          $" should not match to {symptom.Modified.Element.Type} named by \"{m.Name ?? symptom.Modified.Element.Hint}\"-(ml:{m.Mpg}, mid:{symptom.Modified.Element.Id})",
                                    Comments = "",
                                    Topics = Topics.Matching /**//*Topics.Domain*/ /* | Topics.Matching *//*| Topics.Differencing*/ /*| Topics.Report*/,
                                    MissedMatch = true,
                                    RedundantChanges = true
                                };
                            else
                                review = new Review
                                {
                                    Id = Guid.NewGuid(),
                                    Kind = ReviewKind.Redundancy_MissedName,
                                    CaseKind = CaseKind.Symptom,
                                    Severity = ReviewSeverity.Bad,
                                    Subject = $"Missed match - {symptom.Original.Element.Type} named by \"{o.Name ?? symptom.Original.Element.Hint}\"-(ol:{o.Opg}, oid:{symptom.Original.Element.Id})" +
                                      $" should match to {symptom.Modified.Element.Type} named by \"{m.Name ?? symptom.Modified.Element.Hint}\"-(ml:{m.Mpg}, mid:{symptom.Modified.Element.Id})",
                                    Comments = "",
                                    Topics = Topics.Matching /**//*Topics.Domain*/ /* | Topics.Matching *//*| Topics.Differencing*/ /*| Topics.Report*/,
                                    MissedMatch = true,
                                    RedundantChanges = true
                                };
                            pair.Reviews.Add(review);
                        }
                        else
                        {
                            string prefix = "", match = " ";
                            var oElement = original.DescendantNodesAndSelf().OfType<MethodCallExpression>().SelectMany(
                                expression =>
                                {
                                    List<SimpleNameSyntax> result = new List<SimpleNameSyntax>();
                                    foreach (var argument in expression.Arguments.OfType<SyntaxNode>())
                                    {
                                        result.AddRange(argument.DescendantNodesAndSelf().OfType<SimpleNameSyntax>());
                                    }

                                    return result;
                                })
                                .Where(e => e.Identifier.ValueText == symptom.Original.Element.Hint)
                                .ToList();
                            var mElement = modified.DescendantNodesAndSelf().OfType<MethodCallExpression>().SelectMany(
                                expression =>
                                {
                                    List<SimpleNameSyntax> result = new List<SimpleNameSyntax>();
                                    foreach (var argument in expression.Arguments.OfType<SyntaxNode>())
                                    {
                                        result.AddRange(argument.DescendantNodesAndSelf().OfType<SimpleNameSyntax>());
                                    }

                                    return result;
                                })
                                .Where(e => e.Identifier.ValueText == symptom.Original.Element.Hint)
                                .ToList();
                            string oLine = "-1", mLine = "-1";
                            //if (!oElement.Any() && !mElement.Any())
                            //{
                            //    pair.Flags = pair.Flags == null
                            //        ? RevisionPairFlags.EnumAnomalies
                            //        : pair.Flags | RevisionPairFlags.EnumAnomalies;
                            //}
                            if (oElement.Count == 1 && mElement.Count == 1)
                            {
                                oLine = (oElement.Single().GetLocation().GetLineSpan().StartLinePosition.Line + 1).ToString(CultureInfo.InvariantCulture);
                                mLine = (mElement.Single().GetLocation().GetLineSpan().StartLinePosition.Line + 1).ToString(CultureInfo.InvariantCulture);
                            }
                            else
                            {
                                var classPattern = new Regex(@"##class:(\d+)\(([^##]*)\)##");
                                //var enumPattern = new Regex(@"##enum:(\d+)\(([^##]*)\)##");
                                var methodPattern = new Regex(@"##function:(\d+)\(([^##]*)\)##");

                                var oClassName = classPattern.IsMatch(symptom.Original.ScopeHint)
                                    ? classPattern.Matches(symptom.Original.ScopeHint)[0].Groups[2].Value
                                    : null;
                                var mClassName = classPattern.IsMatch(symptom.Modified.ScopeHint)
                                    ? classPattern.Matches(symptom.Modified.ScopeHint)[0].Groups[2].Value
                                    : null;

                                var oMethodName = methodPattern.IsMatch(symptom.Original.ScopeHint)
                                    ? methodPattern.Matches(symptom.Original.ScopeHint)[0].Groups[2].Value
                                    : null;
                                var mMethodName = methodPattern.IsMatch(symptom.Modified.ScopeHint)
                                    ? methodPattern.Matches(symptom.Modified.ScopeHint)[0].Groups[2].Value
                                    : null;
                                if (oMethodName != null && mMethodName != null)
                                {
                                    var oMethods = original.DescendantNodesAndSelf().OfType<MethodDeclarationSyntax>()
                                        .Where(c => c.Identifier.ValueText == oMethodName)
                                        .ToList();
                                    var mMethods = modified.DescendantNodesAndSelf().OfType<MethodDeclarationSyntax>()
                                        .Where(c => c.Identifier.ValueText == mMethodName)
                                        .ToList();
                                    if (oMethods.Count == 1 && mMethods.Count == 1)
                                    {
                                        oElement = oMethods.Single().DescendantNodesAndSelf().OfType<MethodCallExpression>().SelectMany(
                                expression =>
                                {
                                    List<SimpleNameSyntax> result = new List<SimpleNameSyntax>();
                                    foreach (var argument in expression.Arguments.OfType<SyntaxNode>())
                                    {
                                        result.AddRange(argument.DescendantNodesAndSelf().OfType<SimpleNameSyntax>());
                                    }

                                    return result;
                                })
                                .Where(e => e.Identifier.ValueText == symptom.Original.Element.Hint)
                                .ToList();
                                        mElement = mMethods.Single().DescendantNodesAndSelf().OfType<MethodCallExpression>().SelectMany(
                                expression =>
                                {
                                    List<SimpleNameSyntax> result = new List<SimpleNameSyntax>();
                                    foreach (var argument in expression.Arguments.OfType<SyntaxNode>())
                                    {
                                        result.AddRange(argument.DescendantNodesAndSelf().OfType<SimpleNameSyntax>());
                                    }

                                    return result;
                                })
                                .Where(e => e.Identifier.ValueText == symptom.Original.Element.Hint)
                                .ToList();
                                        if (oElement.Count == 1 && mElement.Count == 1)
                                        {
                                            oLine = (oElement.Single().GetLocation().GetLineSpan().StartLinePosition.Line + 1).ToString(CultureInfo.InvariantCulture);
                                            mLine = (mElement.Single().GetLocation().GetLineSpan().StartLinePosition.Line + 1).ToString(CultureInfo.InvariantCulture);

                                            if (oMethods.Single().Identifier.ValueText != mMethods.Single().Identifier.ValueText)
                                            {
                                                prefix = "Imprecise ";
                                                match = " not ";
                                            }
                                        }
                                    }
                                }



                                var oClass = original.DescendantNodesAndSelf().OfType<ClassDeclarationSyntax>()
                                        .Where(c => c.Identifier.ValueText == oClassName)
                                        .ToList();
                                var mClass = modified.DescendantNodesAndSelf().OfType<ClassDeclarationSyntax>()
                                    .Where(c => c.Identifier.ValueText == mClassName)
                                    .ToList();

                                //Func<string, string> getClassName = delegate(string s)
                                //{
                                //    var parts = s.Split(new string[] {"class-"}, StringSplitOptions.RemoveEmptyEntries);
                                //    if (parts.Length == 2)
                                //    {
                                //        return parts[1].TrimEnd(')');
                                //    }

                                //    return null;
                                //};
                                //var oClass = original.DescendantNodesAndSelf().OfType<BaseTypeDeclarationSyntax>()
                                //    .Where(c => c.Identifier.ValueText == getClassName(symptom.Original.AncestorOfReference.Hint))
                                //    .ToList();
                                //var mClass = modified.DescendantNodesAndSelf().OfType<BaseTypeDeclarationSyntax>()
                                //    .Where(c => c.Identifier.ValueText == getClassName(symptom.Modified.AncestorOfReference.Hint))
                                //    .ToList();
                                //    if (oClass.Count == 1 && mClass.Count == 1)
                                //    {
                                //    //oElement = oClass.Single().DescendantNodesAndSelf().OfType<ConstructorDeclarationSyntax>()
                                //    //    .Where(e => e.Identifier.ValueText == oMethodName)
                                //    //    .ToList();
                                //    //mElement = mClass.Single().DescendantNodesAndSelf().OfType<ConstructorDeclarationSyntax>()
                                //    //    .Where(e => e.Identifier.ValueText == mMethodName)
                                //    //    .ToList();
                                //    oElement = oClass.Single().DescendantNodesAndSelf().OfType<EnumMemberDeclarationSyntax>()
                                //        .Where(e => e.Identifier.ValueText == symptom.Original.Element.Hint)
                                //        .ToList();
                                //    mElement = mClass.Single().DescendantNodesAndSelf().OfType<EnumMemberDeclarationSyntax>()
                                //        .Where(e => e.Identifier.ValueText == symptom.Modified.Element.Hint)
                                //        .ToList();
                                //    if (oElement.Count == 1 && mElement.Count == 1)
                                //        {
                                //            oLine = (oElement.Single().GetLocation().GetLineSpan().StartLinePosition.Line + 1).ToString(CultureInfo.InvariantCulture);
                                //            mLine = (mElement.Single().GetLocation().GetLineSpan().StartLinePosition.Line + 1).ToString(CultureInfo.InvariantCulture);
                                //        }

                                //        if (oClass.Single().Identifier.ValueText != mClass.Single().Identifier.ValueText)
                                //        {
                                //            prefix = "Imprecise ";
                                //            match = " not ";
                                //        }
                                //    }
                                //    //else
                                //    //;
                                //}
                            }

                            int oClasses = original.DescendantNodesAndSelf().OfType<BaseTypeDeclarationSyntax>().Count();
                            int mClasses = modified.DescendantNodesAndSelf().OfType<BaseTypeDeclarationSyntax>().Count();
                            //if(oClasses== 0|| mClasses == 0 && pair.Flags != null)
                            //{
                            //    pair.Flags = pair.Flags == RevisionPairFlags.EnumAnomalies ? null : pair.Flags & ~RevisionPairFlags.EnumAnomalies;
                            //}

                            string originalElement = $"({symptom.Original.Element.Id})-{symptom.Original.Element.Type} \"{symptom.Original.Element.Hint}\"";
                            string modifiedElement = $"({symptom.Modified.Element.Id})-{symptom.Modified.Element.Type} \"{symptom.Modified.Element.Hint}\"";
                            var review = new Review
                            {
                                Id = Guid.NewGuid(),
                                Kind = ReviewKind.Redundancy_MissedName,
                                CaseKind = CaseKind.Symptom,
                                Severity = ReviewSeverity.Bad,
                                Subject = $"{prefix}Missed match - {symptom.Original.Element.Type} named by \"{symptom.Original.Element.Hint}\"-(ol:{oLine}, oid:{symptom.Original.Element.Id})" +
                                          $" should{match}match to {symptom.Modified.Element.Type} named by \"{symptom.Modified.Element.Hint}\"-(ml:{mLine}, mid:{symptom.Modified.Element.Id})",
                                Comments = "",
                                Topics = Topics.Matching /**//*Topics.Domain*/ /* | Topics.Matching *//*| Topics.Differencing*/ /*| Topics.Report*/,
                                MissedMatch = true,
                                RedundantChanges = true
                            };
                            pair.Reviews.Add(review);
                            //sqlRepository.Symptoms.Remove(symptom);
                        }
                    }
                }, true, "Principal.FileVersion.Content", "Principal.FromFileVersion.Content");
        }

        /// <summary>
        /// Gathers a referential summary and save it in <see cref="FileRevisionPairAnalyzer.Report"/>.
        /// </summary>
        public override void ReportSummary()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Implements placeholders to configure the redundancy checking.
        /// </summary>
        ///// <typeparam name="TSubject">type of the elements </typeparam>
        public class Criterion
        {
            /// <summary>
            /// Determines if a given operation is candidate to look for mismatches.
            /// </summary>
            public virtual Func<OperationDescriptor, bool> IsSubject { get; set; }

            /// <summary>
            /// Gets or sets a name to refer the subjects of interest.  
            /// </summary>
            public virtual string Nickname { get; set; }

            /// <summary>
            /// Gets or sets the logic to produce a candidate subject.
            /// </summary>
            public Func<ElementTree, TSubject> AsSubject { get; set; }

            /// <summary>
            /// Gets or sets how to select the ancestor scopes to search for redundant subjects.
            /// </summary>
            public Func<TSubject, IEnumerable<ElementTree>> GetScopes { get; set; }

            /// <summary>
            /// Gets or sets how to filter fake redundant subjects.
            /// </summary>
            public Func<TSubject, TSubject, string, DetectionResult, bool> FilterOut { get; set; }

            /// <summary>
            /// Gets or sets how to test if two subjects are redundant with each other.
            /// </summary>
            public Func<TSubject, TSubject, string, DetectionResult, bool> AreRedundant { get; set; }

            /// <summary>
            /// Gets or sets how to shape the resulting redundancies.
            /// </summary>
            public Func<TSubject, TSubject, string, DetectionResult, MissedElement> AsResult { get; set; }
        }
    }
}