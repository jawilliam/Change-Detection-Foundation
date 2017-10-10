using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Jawilliam.CDF.Actions;
using Jawilliam.CDF.Approach;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Jawilliam.CDF.Labs
{
    /// <summary>
    /// Implements delta examination.
    /// </summary>
    public class DeltaAnalyzer : FileRevisionPairAnalyzer
    {
        /// <summary>
        /// Analyzes the similarity in according with a given similarity metric, such as Levenshtein.
        /// </summary>
        /// <param name="sqlRepository">the SQL database repository in which to analyze the file versions.</param>
        /// <param name="approach"></param>
        /// <param name="skipThese">local criterion for determining elements that should be ignored.</param>
        /// <param name="csvDescriptions">CSV lines describing different cases of the subcorpus.</param>
        /// <param name="subcorpusPrefix">the kind of subcorpus.</param>
        public virtual void SetSubcorpus(GitRepository sqlRepository, ChangeDetectionApproaches approach, Func<FileRevisionPair, bool> skipThese, string[] csvDescriptions, string subcorpusPrefix)
        {
            var descriptions = csvDescriptions.Skip(1)
                .Where(l => !string.IsNullOrEmpty(l) && l.Split(new[] {";"}, StringSplitOptions.RemoveEmptyEntries)[0] == $"\"{sqlRepository.Name}\"")
                .Select(delegate(string line)
                {
                    var values = line.Split(new[] {";"}, StringSplitOptions.RemoveEmptyEntries);
                    return new
                    {
                        Id = Guid.Parse(values[1].TrimStart('\"').TrimEnd('\"')),
                        Outlier = values[9].TrimStart('\"').TrimEnd('\"'),
                        Random = values[10].TrimStart('\"').TrimEnd('\"'),
                        MedianCloser = values[12]
                    };
                }).ToList();
            this.Analyze(sqlRepository, $"{Enum.GetName(typeof(ChangeDetectionApproaches), approach)}Deltas",
              f => f.Principal.Deltas.Any(d => d.Approach == approach &&
                                               d.Matching != null &&
                                               d.Differencing != null &&
                                               d.Report == null),
                delegate (FileRevisionPair pair, CancellationToken token)
                {
                    if (skipThese?.Invoke(pair) ?? false) return;

                    var delta = sqlRepository.Deltas.Single(d => d.RevisionPair.Id == pair.Principal.Id && d.Approach == approach);
                    var description = descriptions.FirstOrDefault(d => d.Id == pair.Principal.Id);

                    var subcorpusSpec = SubcorpusKind.None;
                    if (description != null)
                    {
                        if (description.Outlier == "High")
                            subcorpusSpec |= (SubcorpusKind)Enum.Parse(typeof (SubcorpusKind), $"{subcorpusPrefix}HigherOutlier");
                        if (description.Outlier == "Low")
                            subcorpusSpec |= (SubcorpusKind)Enum.Parse(typeof(SubcorpusKind), $"{subcorpusPrefix}LowerOutlier");
                        if (description.Random == "TRUE")
                            subcorpusSpec |= (SubcorpusKind)Enum.Parse(typeof(SubcorpusKind), $"{subcorpusPrefix}Random");
                        if (description.MedianCloser == "TRUE")
                            subcorpusSpec |= (SubcorpusKind)Enum.Parse(typeof(SubcorpusKind), $"{subcorpusPrefix}MedianCloser");
                    }
                    else
                    {
                        subcorpusSpec = (SubcorpusKind)Enum.Parse(typeof(SubcorpusKind), $"{subcorpusPrefix}NotAssigned");
                    }

                    if (subcorpusSpec != SubcorpusKind.None)
                        delta.Subcorpus = delta.Subcorpus == null ? subcorpusSpec : delta.Subcorpus | subcorpusSpec;
                }, null, true, "Principal");
        }

        /// <summary>
        /// Summarizes the count of elements for each kind of subcorpus.
        /// </summary>
        /// <param name="sqlRepository">the SQL database repository in which to analyze the file versions.</param>
        /// <param name="approach"></param>
        public virtual void SummarizeSubcorpusSelection(GitRepository sqlRepository, ChangeDetectionApproaches approach, bool namesRow)
        {
            var valuesDesc = new[]
            {
                new { Abbreviature = "GGHO", Value = SubcorpusKind.GlobalGeneralRatioLvGtHigherOutlier },
                new { Abbreviature = "GGLO", Value = SubcorpusKind.GlobalGeneralRatioLvGtLowerOutlier },
                new { Abbreviature = "GGMC", Value = SubcorpusKind.GlobalGeneralRatioLvGtMedianCloser },
                new { Abbreviature = "GGNA", Value = SubcorpusKind.GlobalGeneralRatioLvGtNotAssigned },
                new { Abbreviature = "GGRD", Value = SubcorpusKind.GlobalGeneralRatioLvGtRandom },

                new { Abbreviature = "GDHO", Value = SubcorpusKind.GlobalDeletionPorcentageLvGtHigherOutlier },
                new { Abbreviature = "GDLO", Value = SubcorpusKind.GlobalDeletionPorcentageLvGtLowerOutlier },
                new { Abbreviature = "GDMC", Value = SubcorpusKind.GlobalDeletionPorcentageLvGtMedianCloser },
                new { Abbreviature = "GDNA", Value = SubcorpusKind.GlobalDeletionPorcentageLvGtNotAssigned },
                new { Abbreviature = "GDRD", Value = SubcorpusKind.GlobalDeletionPorcentageLvGtRandom },

                new { Abbreviature = "GIHO", Value = SubcorpusKind.GlobalInsertionPorcentageLvGtHigherOutlier },
                new { Abbreviature = "GILO", Value = SubcorpusKind.GlobalInsertionPorcentageLvGtLowerOutlier },
                new { Abbreviature = "GIMC", Value = SubcorpusKind.GlobalInsertionPorcentageLvGtMedianCloser },
                new { Abbreviature = "GINA", Value = SubcorpusKind.GlobalInsertionPorcentageLvGtNotAssigned },
                new { Abbreviature = "GIRD", Value = SubcorpusKind.GlobalInsertionPorcentageLvGtRandom },

                new { Abbreviature = "GUHO", Value = SubcorpusKind.GlobalUpdatePorcentageLvGtHigherOutlier },
                new { Abbreviature = "GULO", Value = SubcorpusKind.GlobalUpdatePorcentageLvGtLowerOutlier },
                new { Abbreviature = "GUMC", Value = SubcorpusKind.GlobalUpdatePorcentageLvGtMedianCloser },
                new { Abbreviature = "GUNA", Value = SubcorpusKind.GlobalUpdatePorcentageLvGtNotAssigned },
                new { Abbreviature = "GURD", Value = SubcorpusKind.GlobalUpdatePorcentageLvGtRandom },

                new { Abbreviature = "GMHO", Value = SubcorpusKind.GlobalMovePorcentageLvGtHigherOutlier },
                new { Abbreviature = "GMLO", Value = SubcorpusKind.GlobalMovePorcentageLvGtLowerOutlier },
                new { Abbreviature = "GMMC", Value = SubcorpusKind.GlobalMovePorcentageLvGtMedianCloser },
                new { Abbreviature = "GMNA", Value = SubcorpusKind.GlobalMovePorcentageLvGtNotAssigned },
                new { Abbreviature = "GMRD", Value = SubcorpusKind.GlobalMovePorcentageLvGtRandom }
            };

            IDictionary<SubcorpusKind, int> total = new Dictionary<SubcorpusKind, int>();
            var values = Enum.GetValues(typeof(SubcorpusKind)).Cast<SubcorpusKind>().ToList();
            if (namesRow)
                this.Report.AppendLine("Project" + valuesDesc.Aggregate("", (s, kind) => $"{s};{kind.Abbreviature}"));

            string report = sqlRepository.Name + valuesDesc.Aggregate("", (current, value) => $"{current};{sqlRepository.Deltas.Count(d => d.Approach == approach && d.Subcorpus != null && ((d.Subcorpus.Value & value.Value) == value.Value))}");
            this.Report.AppendLine(report);
        }

        //public virtual void ClearConfusingNames(GitRepository sqlRepository)
        //{
        //    var repositoryObjectIds = sqlRepository.Deltas
        //            .Where(d => d.Approach == ChangeDetectionApproaches.NativeGumTree &&
        //                        d.Symptoms.OfType<NameCoexistenceSymptom>().Any())
        //            .Select(fv => fv.Id).ToList();

        //    int counter = 0;
        //    foreach (var repositoryObjectId in repositoryObjectIds)
        //    {
        //        var delta = sqlRepository.Deltas.Include("Symptoms").Single(c => c.Id == repositoryObjectId);

        //        foreach (var symptom in delta.Symptoms.OfType<NameCoexistenceSymptom>().ToList())
        //        {
        //            sqlRepository.Symptoms.Remove(symptom);
        //        }
        //        sqlRepository.Flush(true);
        //        Console.WriteLine($"{sqlRepository.Name}-{++counter} of {repositoryObjectIds.Count}");
        //    }
        //}

        public virtual void RepairConfusingNames(GitRepository sqlRepository)
        {
            var repositoryObjectIds = sqlRepository.Deltas
                    .Where(d => d.Approach == ChangeDetectionApproaches.NativeGumTree &&
                                d.Symptoms.OfType<NameCoexistenceSymptom>().Any())
                    .Select(fv => fv.Id).ToList();

            int counter = 0;
            foreach (var repositoryObjectId in repositoryObjectIds)
            {
                var delta = sqlRepository.Deltas.Include("Symptoms").Single(c => c.Id == repositoryObjectId);
                var originalTree = ElementTree.Read(delta.OriginalTree, Encoding.Unicode);
                var modifiedTree = ElementTree.Read(delta.ModifiedTree, Encoding.Unicode);

                foreach (var symptom in delta.Symptoms.OfType<NameCoexistenceSymptom>())
                {
                    var original = originalTree.PostOrder(n => n.Children).First(n => n.Root.Id == symptom.Original.Element.Id);
                    var coexistingOriginal = originalTree.PostOrder(n => n.Children).First(n => n.Root.Id == symptom.CoexistingOriginal.Element.Id);
                    var modified = modifiedTree.PostOrder(n => n.Children).First(n => n.Root.Id == symptom.Modified.Element.Id);

                    symptom.Original.Element.Type = this.NameContexts.Single(nc => nc.Criterion(original)).NameOf(original);
                    symptom.CoexistingOriginal.Element.Type = this.NameContexts.Single(nc => nc.Criterion(coexistingOriginal)).NameOf(coexistingOriginal);
                    symptom.Modified.Element.Type = this.NameContexts.Single(nc => nc.Criterion(modified)).NameOf(modified);

                    symptom.Original.Element.Hint = original.Root.Value;
                    symptom.CoexistingOriginal.Element.Hint = coexistingOriginal.Root.Value;
                    symptom.Modified.Element.Hint = modified.Root.Value;
                }
                sqlRepository.Flush(true);
                Console.WriteLine($"{sqlRepository.Name}-{++counter} of {repositoryObjectIds.Count}");
            }
        }

        /// <summary>
        /// Analyzes the similarity in according with a given similarity metric, such as Levenshtein.
        /// </summary>
        /// <param name="sqlRepository">the SQL database repository in which to analyze the file versions.</param>
        /// <param name="cancel">Action to execute cancellation logic.</param>
        /// <param name="approach"></param>
        /// <param name="skipThese">local criterion for determining elements that should be ignored.</param>
        public virtual void SaveIncompatibleMatches(GitRepository sqlRepository, Action cancel, ChangeDetectionApproaches approach, Func<FileRevisionPair, bool> skipThese)
        {
            var incompatibilities = new Func<ElementTree, ElementTree, string>[]
            {
                delegate(ElementTree o, ElementTree m)
                {
                    //if ((o.Root.Label == "name" && o.Root.Value == "this" && m.Root.Value != "this") ||
                    //    (m.Root.Label == "name" && m.Root.Value == "this" && o.Root.Value != "this"))
                    //    return "this instance expression";

                    //if ((o.Root.Label == "name" && o.Root.Value == "base" && m.Root.Value != "base") ||
                    //    (m.Root.Label == "name" && m.Root.Value == "base" && o.Root.Value != "base"))
                    //    return "base instance expression";

                    //if (o.Root.Label == "comment" && m.Root.Label == "comment" &&
                    //    ((o.Root.Value == "///" && m.Root.Value != "///") ||
                    //     (m.Root.Value == "///" && o.Root.Value != "///")))
                    //{
                    //    return "incompatible comments?";
                    //}

                    //if (o.Root.Label == "name" && m.Root.Label == "name")
                    //{
                    //    TypeSyntax originalType = null, modifiedType = null;
                    //    try
                    //    {
                    //        originalType = SyntaxFactory.ParseTypeName(o.Root.Value);
                    //        modifiedType = SyntaxFactory.ParseTypeName(m.Root.Value);
                    //    }catch (Exception){}

                    //    if (originalType != null && modifiedType != null)
                    //    {
                    //        var voidType = new { TypeNames = new[] { "void", "Void"}};
                    //        var types = new[]
                    //        {
                    //             new { TypeNames = new[] { "bool", "Boolean"}}
                    //            ,new { TypeNames = new[] { "byte", "Byte"}}
                    //            ,new { TypeNames = new[] { "sbyte", "SByte"}}
                    //            ,new { TypeNames = new[] { "char", "Char"}}
                    //            ,new { TypeNames = new[] { "decimal", "Decimal"}}
                    //            ,new { TypeNames = new[] { "double", "Double"}}
                    //            ,new { TypeNames = new[] { "float", "Single"}}
                    //            ,new { TypeNames = new[] { "int", "Int32"}}
                    //            ,new { TypeNames = new[] { "uint", "UInt32"}}
                    //            ,new { TypeNames = new[] { "long", "Int64"}}
                    //            ,new { TypeNames = new[] { "ulong", "UInt64"}}
                    //            ,new { TypeNames = new[] { "object", "Object"}}
                    //            ,new { TypeNames = new[] { "short", "Int16"}}
                    //            ,new { TypeNames = new[] { "ushort", "UInt16"}}
                    //            ,new { TypeNames = new[] { "string", "String"}}
                    //            ,voidType
                    //        };

                    //        var oType = types.SingleOrDefault(t => t.TypeNames.Contains(originalType.ToFullString()));
                    //        var mType = types.SingleOrDefault(t => t.TypeNames.Contains(modifiedType.ToFullString()));
                    //        if((originalType.ToFullString() == "var" && mType != voidType) ||
                    //           (modifiedType.ToFullString() == "var" && oType != voidType))
                    //            return null;

                    //        if(oType != mType)
                    //            return "builtin type updates to non-builtin type";
                    //    }
                    //}

                    //if ((o.Root.Label == "literal" && o.Root.Value == "null" && m.Root.Value != "null") ||
                    //    (m.Root.Label == "literal" && m.Root.Value == "null" && o.Root.Value != "null"))
                    //    return "null literal mismatch";

                    //if ((o.Root.Label == "literal" && o.Root.Value == "true" && m.Root.Value != "true" && m.Root.Value != "false") ||
                    //    (m.Root.Label == "literal" && m.Root.Value == "true" && o.Root.Value != "true" && o.Root.Value != "false"))
                    //    return "true literal mismatch";

                    //if ((o.Root.Label == "literal" && o.Root.Value == "false" && m.Root.Value != "false" && m.Root.Value != "true") ||
                    //    (m.Root.Label == "literal" && m.Root.Value == "false" && o.Root.Value != "false" && o.Root.Value != "true"))
                    //    return "false literal mismatch";

                    //if (o.Root.Label == "literal" && m.Root.Label == "literal")
                    //{
                    //    ExpressionSyntax originalLiteral = null, modifiedLiteral = null;
                    //    try
                    //    {
                    //        originalLiteral = SyntaxFactory.ParseExpression(o.Root.Value);
                    //        modifiedLiteral = SyntaxFactory.ParseExpression(m.Root.Value);
                    //    }catch (Exception){}

                    //    if (originalLiteral != null && modifiedLiteral != null)
                    //    {
                    //        if ((originalLiteral.Kind() == SyntaxKind.TrueLiteralExpression ||
                    //             originalLiteral.Kind() == SyntaxKind.FalseLiteralExpression) &&
                    //            (modifiedLiteral.Kind() == SyntaxKind.TrueLiteralExpression ||
                    //             modifiedLiteral.Kind() == SyntaxKind.FalseLiteralExpression))
                    //            return null;

                    //        if ((originalLiteral.Kind() == SyntaxKind.ThisExpression ||
                    //             originalLiteral.Kind() == SyntaxKind.BaseExpression) &&
                    //            (modifiedLiteral.Kind() == SyntaxKind.ThisExpression ||
                    //             modifiedLiteral.Kind() == SyntaxKind.BaseExpression))
                    //            return null;

                    //        if(originalLiteral.RawKind != modifiedLiteral.RawKind && 
                    //           originalLiteral.ToFullString()?.Trim('"').Trim('\'') !=
                    //           modifiedLiteral.ToFullString()?.Trim('"').Trim('\''))
                    //            return "literals update";
                    //    }
                    //}

                    //var namedOriginal = this.NameContexts.SingleOrDefault(nc => nc.Criterion(o));
                    //var namedModified = this.NameContexts.SingleOrDefault(nc => nc.Criterion(m));
                    //if (namedOriginal?.NameOf(o) != null && namedModified?.NameOf(m) != null &&
                    //    namedOriginal.NameOf(o) != namedModified.NameOf(m))
                    //    return "renames";

                    //if (o.Root.Label == "operator" && m.Root.Label == "operator" &&
                    //    o.Root.Value != m.Root.Value)
                    //    return "different operators";

                    return null;
                }
            };
            this.Analyze(sqlRepository, "incompatible matches",
              f => f.Principal.Deltas.Any(d => d.Approach == approach &&
                                               d.Matching != null &&
                                               d.Differencing != null &&
                                               d.Report == null),
                delegate (FileRevisionPair pair, CancellationToken token)
                {
                    if (skipThese?.Invoke(pair) ?? false) return;

                    var delta = sqlRepository.Deltas.Single(d => d.RevisionPair.Id == pair.Principal.Id && d.Approach == approach);
                    try
                    {
                        var incompatibleMatches = this.FindIncompatibleMatches(delta, incompatibilities, token);
                        foreach (var incompatibleMatch in incompatibleMatches)
                        {
                            delta.Symptoms.Add(incompatibleMatch);
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
                },
            cancel, false, "Principal");
        }

        /// <summary>
        /// Finds incompatible matches.
        /// </summary>
        /// <param name="delta">the delta where analyzing symtomatic imprecisions.</param>
        /// <param name="token">a mechanism to cancell </param>
        /// <param name="incompatibilities">a collection of functions, each of which search for (and returns accordingly)
        /// an incompatiple matching pattern detected among a pair of elements, or null when there is not such incompatibilities.</param>
        public virtual IEnumerable<IncompatibleMatchingSymptom> FindIncompatibleMatches(Delta delta, IEnumerable<Func<ElementTree, ElementTree, string>> incompatibilities, CancellationToken token)
        {
            var detectionResult = (DetectionResult)delta.DetectionResult;
            if (!detectionResult.Matches.Any())
                yield break;

            var originalTree = ElementTree.Read(delta.OriginalTree, Encoding.Unicode);
            var modifiedTree = ElementTree.Read(delta.ModifiedTree, Encoding.Unicode);
            var enumerableIncompatibilities = incompatibilities as Func<ElementTree, ElementTree, string>[] ?? incompatibilities.ToArray();

            foreach (var update in detectionResult.Actions.OfType<UpdateOperationDescriptor>())
            {
                var match = detectionResult.Matches.Single(m => m.Original.Id == update.Element.Id);
                var modified = modifiedTree.PostOrder(n => n.Children).First(n => n.Root.Id == match.Modified.Id);
                var original = originalTree.PostOrder(n => n.Children).First(n => n.Root.Id == update.Element.Id);

                foreach (var incompatibility in enumerableIncompatibilities)
                {
                    string incompatibilityPattern = incompatibility(original, modified);
                    if (incompatibilityPattern != null)
                    {
                        var originalContext = this.NameContexts.SingleOrDefault(nc => nc.Criterion(original));
                        var modifiedContext = this.NameContexts.SingleOrDefault(nc => nc.Criterion(modified));
                        yield return new IncompatibleMatchingSymptom
                        {
                            Id = Guid.NewGuid(),
                            Pattern = incompatibilityPattern,
                            Original = new ElementContext
                            {
                                Element = new ElementDescription
                                {
                                    Id = original.Root.Id,
                                    Type = originalContext?.NameOf(original) ?? original.Root.Label,
                                    Hint = original.Root.Value
                                },
                                ScopeHint = originalContext != null 
                                    ? this.GetPath(originalContext.OuterScopes(original)) 
                                    : this.GetPath(original.Ancestors().Where(ancestor => ancestor.Root.Label == "block"))
                            },
                            Modified = new ElementContext
                            {
                                Element = new ElementDescription
                                {
                                    Id = modified.Root.Id,
                                    Type = modifiedContext?.NameOf(modified) ?? modified.Root.Label,
                                    Hint = modified.Root.Value
                                },
                                ScopeHint = modifiedContext != null
                                    ? this.GetPath(modifiedContext.OuterScopes(modified))
                                    : this.GetPath(modified.Ancestors().Where(ancestor => ancestor.Root.Label == "block"))
                            }
                        };
                    }
                }
            }
        }



        /// <summary>
        /// Analyzes the similarity in according with a given similarity metric, such as Levenshtein.
        /// </summary>
        /// <param name="sqlRepository">the SQL database repository in which to analyze the file versions.</param>
        /// <param name="cancel">Action to execute cancellation logic.</param>
        /// <param name="approach"></param>
        /// <param name="skipThese">local criterion for determining elements that should be ignored.</param>
        public virtual void SaveSpuriosityInfo(GitRepository sqlRepository, Action cancel, ChangeDetectionApproaches approach, Func<FileRevisionPair, bool> skipThese)
        {
            this.Analyze(sqlRepository, "spuriosity analysis",
              f => f.Principal.Deltas.Any(d => d.Approach == approach &&
                                               d.Matching != null &&
                                               d.Differencing != null &&
                                               d.Report == null),
                delegate (FileRevisionPair pair, CancellationToken token)
                {
                    if (skipThese?.Invoke(pair) ?? false) return;

                    var delta = sqlRepository.Deltas.Single(d => d.RevisionPair.Id == pair.Principal.Id && d.Approach == approach);
                    try
                    {
                        var originalTree = ElementTree.Read(delta.OriginalTree, Encoding.Unicode);
                        var modifiedTree = ElementTree.Read(delta.ModifiedTree, Encoding.Unicode);
                        var detectionResult = (DetectionResult)delta.DetectionResult;

                        var originalTransformations = new Dictionary<string, TransformationInfo>();
                        var modifiedTransformations = new Dictionary<string, TransformationInfo>();

                        foreach (var action in detectionResult.Actions)
                        {
                            ElementTree element;
                            TransformationInfo transformationInfo;
                            switch (action.Action)
                            {
                                case ActionKind.Update:
                                    var updateAction = (UpdateOperationDescriptor) action;
                                    element = originalTree.PostOrder(n => n.Children).First(n => n.Root.Id == updateAction.Element.Id);
                                    transformationInfo = this.GetOrCreateTransformationInfo(originalTransformations, modifiedTransformations,
                                        element, "original");
                                    transformationInfo.Self.Updates += 1;
                                    this.PropagateTransformation(new[]{ element.Parent }, 
                                        info => info.Children.Updates, 
                                        (info, i) => info.Children.Updates = i, 
                                        originalTree, originalTransformations, modifiedTransformations);
                                    this.PropagateTransformation(element.Parent.Ancestors(),
                                        info => info.Descendants.Updates,
                                        (info, i) => info.Descendants.Updates = i,
                                        originalTree, originalTransformations, modifiedTransformations);
                                    break;
                                case ActionKind.Insert:
                                    var insertAction = (InsertOperationDescriptor)action;
                                    element = originalTree.PostOrder(n => n.Children).First(n => n.Root.Id == insertAction.Element.Id);
                                    transformationInfo = this.GetOrCreateTransformationInfo(originalTransformations,
                                        modifiedTransformations, element, "modified");
                                    transformationInfo.Self.Insertions += 1;

                                    var parentElement = originalTree.PostOrder(n => n.Children).FirstOrDefault(n => n.Root.Id == insertAction.Parent.Id);
                                    this.PropagateTransformation(new[] { parentElement },
                                        info => info.Children.Insertions,
                                        (info, i) => info.Children.Insertions = i,
                                        originalTree, originalTransformations, modifiedTransformations);
                                    this.PropagateTransformation(parentElement.Ancestors(),
                                        info => info.Descendants.Insertions,
                                        (info, i) => info.Descendants.Insertions = i,
                                        originalTree, originalTransformations, modifiedTransformations);
                                    break;
                                case ActionKind.Delete:
                                    var deleteAction = (DeleteOperationDescriptor)action;
                                    element = originalTree.PostOrder(n => n.Children).First(n => n.Root.Id == deleteAction.Element.Id);
                                    transformationInfo = this.GetOrCreateTransformationInfo(originalTransformations, modifiedTransformations,
                                        element, "original");
                                    transformationInfo.Self.Deletions += 1;
                                    this.PropagateTransformation(new[] { element.Parent },
                                        info => info.Children.Deletions,
                                        (info, i) => info.Children.Deletions = i,
                                        originalTree, originalTransformations, modifiedTransformations);
                                    this.PropagateTransformation(element.Parent.Ancestors(),
                                        info => info.Descendants.Deletions,
                                        (info, i) => info.Descendants.Deletions = i,
                                        originalTree, originalTransformations, modifiedTransformations);
                                    break;
                                case ActionKind.Move:
                                    var moveAction = (MoveOperationDescriptor)action;
                                    var parentsMatch = detectionResult.Matches.Single(m => m.Modified.Id == moveAction.Parent.Id);
                                    var fromParentElement = originalTree.PostOrder(n => n.Children).First(n => n.Root.Id == parentsMatch.Original.Id);
                                    parentElement = modifiedTree.PostOrder(n => n.Children).First(n => n.Root.Id == moveAction.Parent.Id);
                                    element = originalTree.PostOrder(n => n.Children).First(n => n.Root.Id == moveAction.Element.Id);
                                    transformationInfo = this.GetOrCreateTransformationInfo(originalTransformations, modifiedTransformations, element, "original");

                                    if (fromParentElement == parentElement) // aligns
                                    {
                                        transformationInfo.Self.Aligns += 1;
                                        this.PropagateTransformation(new[] {fromParentElement},
                                            info => info.Children.Aligns,
                                            (info, i) => info.Children.Aligns = i,
                                            originalTree, originalTransformations, modifiedTransformations);
                                        this.PropagateTransformation(fromParentElement.Ancestors(),
                                            info => info.Descendants.Aligns,
                                            (info, i) => info.Descendants.Aligns = i,
                                            originalTree, originalTransformations, modifiedTransformations);
                                    }
                                    else
                                    {
                                        transformationInfo.Self.FromMoves += 1;
                                        this.PropagateTransformation(new[] { fromParentElement },
                                            info => info.Children.FromMoves,
                                            (info, i) => info.Children.FromMoves = i,
                                            originalTree, originalTransformations, modifiedTransformations);
                                        this.PropagateTransformation(fromParentElement.Ancestors(),
                                            info => info.Descendants.FromMoves,
                                            (info, i) => info.Descendants.FromMoves = i,
                                            originalTree, originalTransformations, modifiedTransformations);

                                        this.PropagateTransformation(new[] { parentElement },
                                        info => info.Children.ToMoves,
                                        (info, i) => info.Children.ToMoves = i,
                                        originalTree, originalTransformations, modifiedTransformations);
                                        this.PropagateTransformation(parentElement.Ancestors(),
                                            info => info.Descendants.ToMoves,
                                            (info, i) => info.Descendants.ToMoves = i,
                                            originalTree, originalTransformations, modifiedTransformations);
                                    }
                                    break;
                                //case ActionKind.Align: // Not supported by GumTree
                                //    break;
                                default:
                                    throw new ArgumentOutOfRangeException();
                            }
                        }

                        var transformationInfos = originalTransformations.Values.Union(modifiedTransformations.Values).ToArray();
                        foreach(var t in transformationInfos)
                        {
                            if (t.Self.Insertions == 0 && t.Self.Deletions == 0 && t.Self.Updates == 0 &&
                               t.Self.FromMoves == 0 && t.Self.ToMoves == 0 && t.Self.Aligns == 0)
                                t.Self = null;

                            if (t.Children.Insertions == 0 && t.Children.Deletions == 0 && t.Children.Updates == 0 &&
                               t.Children.FromMoves == 0 && t.Children.ToMoves == 0 && t.Children.Aligns == 0)
                                t.Children = null;

                            if (t.Descendants.Insertions == 0 && t.Descendants.Deletions == 0 && t.Descendants.Updates == 0 &&
                               t.Descendants.FromMoves == 0 && t.Descendants.ToMoves == 0 && t.Descendants.Aligns == 0)
                                t.Descendants = null;
                        }

                        var xTransformationsInfo = new XTransformationsInfo
                        {
                            Transformations = transformationInfos
                        };
                        delta.Symptoms.Add(new SpuriositySymptom
                        {
                            Id = Guid.NewGuid(),
                            TransformationsInfo = xTransformationsInfo.WriteXmlColumn()
                        });
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
                },
            cancel, false, "Principal");
        }

        private TransformationInfo GetOrCreateTransformationInfo(Dictionary<string, TransformationInfo> originalTransformationsInfo,
            Dictionary<string, TransformationInfo> modifiedTransformationsInfo, ElementTree element, string version)
        {
            var id = element.Root.Id;
            var transformationsInfo = version == "original" ? originalTransformationsInfo : modifiedTransformationsInfo;
            if (transformationsInfo.ContainsKey(id))
                return transformationsInfo[id];

            var context = element != null ? this.NameContexts.SingleOrDefault(nc => nc.Criterion(element)) : null;
            var t = new TransformationInfo
            {
                Id = id,
                Type = context?.NameOf(element) ?? element.Root.Label,
                Version = version,
                ScopeHint = context != null
                   ? this.GetPath(context.OuterScopes(element))
                   : this.GetPath(element.Ancestors().Where(ancestor => ancestor.Root.Label == "block")),
                Self = new Transformations(),
                FromATotalOfChildren = element.Children.Count(),
                WithATotalOfOperatorsOfChildren = element.Children.Count(c => c.Root.Label == "operator"),
                Children = new Transformations(),
                FromATotalOfDescendants = element.PostOrder(n => n.Children).Count(d => d != element && !element.Children.Contains(d)),
                WithATotalOfOperatorsOfDescendants = element.PostOrder(n => n.Children).Count(d => d != element && d.Root.Label == "operator" && !element.Children.Contains(d)),
                Descendants = new Transformations()
            };

            transformationsInfo[id] = t;

            return t;
        }

        private void PropagateTransformation(IEnumerable<ElementTree> over, Func<TransformationInfo, int> getTransformation, Action<TransformationInfo, int> setTransformation, ElementTree ast, 
            Dictionary<ElementTree, TransformationInfo> originalTransformationsInfo,
            Dictionary<ElementTree, TransformationInfo> modifiedtransformationsInfo)
        {
            foreach (var ancestor in over)
            {
                //match = detectionResult.Matches.Single(m => m.Original.Id == ancestor.Root.Id);
                var ancestorTree = ast.PostOrder(n => n.Children).First(n => n.Root.Id == ancestor.Root.Id);
                var transformationInfo = this.GetOrCreateTransformationInfo(originalTransformationsInfo,
                    modifiedtransformationsInfo, ancestorTree,
                    ast.PostOrder(n => n.Children).Any(n => n == ancestorTree)
                                            ? "original"
                                            : "modified");
                setTransformation(transformationInfo, getTransformation(transformationInfo) + 1);
            }
        }
    }
}
