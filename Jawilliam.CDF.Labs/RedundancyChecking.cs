using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Jawilliam.CDF.Actions;
using Jawilliam.CDF.Approach;

namespace Jawilliam.CDF.Labs
{
    /// <summary>
    /// Implements imprecision diagnostic through a redundancy checking.
    /// </summary>
    public class RedundancyChecking<TSubject> : ImprecisionDiagnostic<MissedElement>
    {
        //private string _mismatchingTarget = "MM";

        /// <summary>
        /// Returns a configuration to check for redundant names.
        /// </summary>
        /// <returns></returns>
        public virtual Criterion<CandidateName> ByRedundantNames()
        {
            return new Criterion<CandidateName>
            {
                IsSubject = m => m.Element.Label == "name", 
                Nickname = "Name",
                AsSubject = delegate(ElementTree tree)
                {
                    var context = this.NameContexts.SingleOrDefault(nm => nm.Criterion(tree));
                    return context == null ? null : new CandidateName {Tree = tree, Context = context};
                },
                GetScopes = a => a.Context.OuterScopes(a.Tree),
                FilterOut = delegate(CandidateName original, CandidateName modified, string pattern, DetectionResult detectionResult)
                {
                    switch (pattern)
                    {
                        case "UU":
                            return detectionResult.Matches.Any(m => m.Original.Id == original.Tree.Root.Id &&
                                                                    m.Modified.Id == modified.Tree.Root.Id);
                        case "MM":
                            return detectionResult.Matches.Any(m => m.Original.Id == original.Tree.Root.Id &&
                                                                    m.Modified.Id == modified.Tree.Root.Id);
                        default: return false;
                    }
                },
                AreRedundant = (original, modified, pattern, delta) => original.Tree.Root.Value == modified.Tree.Root.Value,
                AsResult = (original, modified, pattern, delta) => new MissedElement
                {
                    Modified = new MissedVersion
                    {
                        Type = modified.Context.NameOf(modified.Tree),
                        Element = modified.Tree,
                    },
                    Original = new MissedVersion
                    {
                        Type = original.Context.NameOf(original.Tree),
                        Element = original.Tree,
                    }
                }
            };
        }

        /// <summary>
        /// Gets or sets the configuration to check for redundancies.
        /// </summary>
        public virtual Criterion<TSubject> Config { get; set; }

        /// <summary>
        /// Finds possible missed matches MM.a (i.e., both t1 and t2 do not match to other element)
        /// </summary>
        /// <param name="delta">delta to analyze.</param>
        /// <returns>a collection of the candidate missed matches found in the given delta.</returns>
        public virtual IEnumerable<MissedElement> FindMissedMatchesAOfKeyedElement(Delta delta, CancellationToken token)
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
            foreach (var missedMatch in this.FindMissedMatches("DI", 
                deletedNames, insertedNames, matchedInsertionAncestors, token, detectionResult))
                yield return missedMatch;

            // Missed matches - Updated and Inserted
            var updatedNamesO = detectionResult.Actions.OfType<UpdateOperationDescriptor>()
                .Where(this.Config.IsSubject)
                .Select(t => originalTree.PostOrder(n => n.Children).First(n => n.Root.Id == t.Element.Id))
                .Select(this.Config.AsSubject)
                .Where(t => t != null)
                .ToList();
            foreach (var missedMatch in this.FindMissedMatches("UI", 
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
            foreach (var missedMatch in this.FindMissedMatches("DU", 
                deletedNames, updatedNamesM, matchedUpdateAncestors, token, detectionResult))
                yield return missedMatch;

            foreach (var missedMatch in this.FindMissedMatches("UU", 
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
            foreach (var missedMatch in this.FindMissedMatches("DM", 
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
            foreach (var missedMatch in this.FindMissedMatches("MI", 
                movedNamesO, insertedNames, matchedInsertionAncestors, token, detectionResult))
                yield return missedMatch;

            foreach (var missedMatch in this.FindMissedMatches("MM", 
                movedNamesO, movedNamesM, matchedMoveAncestors, token, detectionResult,
                (or, mo) => this.Config.FilterOut(or, mo, "MM", detectionResult)))
                yield return missedMatch;

            foreach (var missedMatch in this.FindMissedMatches("M", 
                movedNamesO, movedNamesM, matchedMoveAncestors, token, detectionResult))
                yield return missedMatch;

            foreach (var missedMatch in this.FindMissedMatches("UM", 
                updatedNamesO, movedNamesM, matchedMoveAncestors, token, detectionResult))
                yield return missedMatch;

            foreach (var missedMatch in this.FindMissedMatches("MU", 
                movedNamesO, updatedNamesM, matchedUpdateAncestors, token, detectionResult))
                yield return missedMatch;
        }

        protected virtual IEnumerable<MissedElement> FindMissedMatches(string mismatchingCase,
            List<TSubject> originalNames, List<TSubject> modifiedNames,
            List<RevisionPair<ElementDescriptor, ElementTree>> matchedModifiedAncestors,
            CancellationToken token, DetectionResult delta, Func<TSubject, TSubject, bool> skipThese = null)
        {
            if (originalNames.Any() && modifiedNames.Any())
            {
                foreach (var modifiedName in modifiedNames)
                {
                    foreach (var originalName in originalNames
                        .Where(d => this.Config.AreRedundant(d, modifiedName, mismatchingCase, delta)))
                    {
                        if (token.IsCancellationRequested)
                            token.ThrowIfCancellationRequested();

                        if (skipThese != null && skipThese(originalName, modifiedName))
                            continue;

                        var originalScopes = this.Config.GetScopes(originalName).ToList();
                        var candidate = matchedModifiedAncestors.FirstOrDefault(ma => originalScopes.Any(a => a.Root.Id == ma.Original.Id));
                        if (candidate != null)
                        {
                            var result = this.Config.AsResult(originalName, modifiedName, mismatchingCase, delta);
                            result.Case = $"{this.Config.Nickname}.{mismatchingCase}";
                            result.Original.MatchedReference = originalScopes.Single(a => a.Root.Id == candidate.Original.Id);
                            result.Original.Scopes = originalScopes;
                            result.Modified.MatchedReference = candidate.Modified;
                            result.Modified.Scopes = this.Config.GetScopes(modifiedName);

                            yield return result;
                        }
                    }
                }
            }
        }

        //protected virtual IEnumerable<MissedElement> FindMissedMatches(string mismatchingCase, 
        //    List<CandidateName> originalNames, List<CandidateName> modifiedNames, 
        //    List<RevisionPair<ElementDescriptor, ElementTree>> matchedModifiedAncestors, 
        //    CancellationToken token, Func<CandidateName, CandidateName, bool> skipThese = null)
        //{
        //    if (originalNames.Any() && modifiedNames.Any())
        //    {
        //        foreach (var modifiedName in modifiedNames)
        //        {
        //            foreach (var originalName in originalNames.Where(d => d.Tree.Root.Value == modifiedName.Tree.Root.Value))
        //            {
        //                if (token.IsCancellationRequested)
        //                    token.ThrowIfCancellationRequested();

        //                if (skipThese != null && skipThese(originalName, modifiedName))
        //                    continue;

        //                var originalScopes = originalName.Context.OuterScopes(originalName.Tree);
        //                var candidate = matchedModifiedAncestors.FirstOrDefault(ma => originalScopes.Any(a => a.Root.Id == ma.Original.Id));
        //                if (candidate != null)
        //                {
        //                    yield return new MissedElement
        //                    {
        //                        Case = mismatchingCase,
        //                        Modified = new MissedVersion
        //                        {
        //                            Type = modifiedName.Context.NameOf(modifiedName.Tree),
        //                            Element = modifiedName.Tree,
        //                            MatchedReference = candidate.Modified,
        //                            Scopes = modifiedName.Context.OuterScopes(modifiedName.Tree)
        //                        },
        //                        Original = new MissedVersion
        //                        {
        //                            Type = originalName.Context.NameOf(originalName.Tree),
        //                            Element = originalName.Tree,
        //                            MatchedReference = originalScopes.Single(a => a.Root.Id == candidate.Original.Id),
        //                            Scopes = originalName.Context.OuterScopes(originalName.Tree)
        //                        }
        //                    };
        //                }
        //            }
        //        }
        //    }
        //}

        /// <summary>
        /// Implements placeholders to configure the redundancy checking.
        /// </summary>
        /// <typeparam name="TSubject">type of the elements </typeparam>
        public class Criterion<TSubject>
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

        /// <summary>
        /// Looks for symptoms of imprecision.
        /// </summary>
        /// <returns>Symptomatic imprecisions.</returns>
        public override IEnumerable<MissedElement> Recognize()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gathers a referential summary and save it in <see cref="FileRevisionPairAnalyzer.Report"/>.
        /// </summary>
        public override void ReportSummary()
        {
            throw new NotImplementedException();
        }
    }
}