using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
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
                new { Abbreviature = "GGMCRD", Value = SubcorpusKind.GlobalGeneralRatioLvGtMedianCloserRandom },
                new { Abbreviature = "GGNA", Value = SubcorpusKind.GlobalGeneralRatioLvGtNotAssigned },
                new { Abbreviature = "GGRD", Value = SubcorpusKind.GlobalGeneralRatioLvGtRandom },

                new { Abbreviature = "GDHO", Value = SubcorpusKind.GlobalDeletionPorcentageLvGtHigherOutlier },
                new { Abbreviature = "GDLO", Value = SubcorpusKind.GlobalDeletionPorcentageLvGtLowerOutlier },
                new { Abbreviature = "GDMC", Value = SubcorpusKind.GlobalDeletionPorcentageLvGtMedianCloser },
                new { Abbreviature = "GDMCRD", Value = SubcorpusKind.GlobalDeletionPorcentageLvGtMedianCloserRandom },
                new { Abbreviature = "GDNA", Value = SubcorpusKind.GlobalDeletionPorcentageLvGtNotAssigned },
                new { Abbreviature = "GDRD", Value = SubcorpusKind.GlobalDeletionPorcentageLvGtRandom },

                new { Abbreviature = "GIHO", Value = SubcorpusKind.GlobalInsertionPorcentageLvGtHigherOutlier },
                new { Abbreviature = "GILO", Value = SubcorpusKind.GlobalInsertionPorcentageLvGtLowerOutlier },
                new { Abbreviature = "GIMC", Value = SubcorpusKind.GlobalInsertionPorcentageLvGtMedianCloser },
                new { Abbreviature = "GIMCRD", Value = SubcorpusKind.GlobalInsertionPorcentageLvGtMedianCloserRandom },
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

        /// <summary>
        /// Summarizes the count of elements for each kind of subcorpus.
        /// </summary>
        /// <param name="sqlRepository">the SQL database repository in which to analyze the file versions.</param>
        /// <param name="approach"></param>
        public virtual void SummarizeSymptoms(GitRepository sqlRepository, ChangeDetectionApproaches approach, bool namesRow)
        {
            //int totalOfMn = 0;
            //int totalOfMnClasses = 0;
            //int totalOfMnProperties = 0;
            //int totalOfMnFields = 0;
            //int totalOfMnFunctions = 0;
            //int totalOfMnVariables = 0;
            //int totalOfMi = 0;
            //int totalOfMiThis = 0;
            //int totalOfMiBase = 0;
            //int totalOfMiBltInNonBltInTypes = 0;
            //int totalOfMiNull = 0;
            //int totalOfMiTrue = 0;
            //int totalOfMiFalse = 0;
            //int totalOfMiLiterals = 0;
            //int totalOfMiRenames = 0;
            //int totalOfMiOperators = 0;

            if (namesRow)
                this.Report.AppendLine("Project;MN;MN-Class;MN-Interface;MN-Enum;MN-Struct;MN-prop;MN-fld;MN-ev;MN-func;MN-ctor;MN-dtor;MN-farg;MN-aarg;MN-var;MN-others;IM;IM-this;IM-base;IM-btinNonbtinTypes;IM-null;IM-true;IM-false;IM-literals;IM-names;IM-optors");

            var mn = sqlRepository.Symptoms.OfType<MissedElementSymptom>().Count();
            //var mnNamespaces = sqlRepository.Symptoms.OfType<MissedElementSymptom>().Count(s => s.Original.Element.Type == "namespace" && s.Modified.Element.Type == "namespace");
            var mnClasses = sqlRepository.Symptoms.OfType<MissedElementSymptom>().Count(s => s.Original.Element.Type == "class" && s.Modified.Element.Type == "class");
            var mnInterfaces = sqlRepository.Symptoms.OfType<MissedElementSymptom>().Count(s => s.Original.Element.Type == "interface" && s.Modified.Element.Type == "interface");
            var mnEnums = sqlRepository.Symptoms.OfType<MissedElementSymptom>().Count(s => s.Original.Element.Type == "enum" && s.Modified.Element.Type == "enum");
            var mnStructs = sqlRepository.Symptoms.OfType<MissedElementSymptom>().Count(s => s.Original.Element.Type == "struct" && s.Modified.Element.Type == "struct");
            var mnEnumValues = sqlRepository.Symptoms.OfType<MissedElementSymptom>().Count(s => s.Original.Element.Type == "enumvalue" && s.Modified.Element.Type == "enumvalue");
            var mnProperties = sqlRepository.Symptoms.OfType<MissedElementSymptom>().Count(s => s.Original.Element.Type == "property" && s.Modified.Element.Type == "property");
            var mnFields = sqlRepository.Symptoms.OfType<MissedElementSymptom>().Count(s => s.Original.Element.Type == "field" && s.Modified.Element.Type == "field");
            var mnFunctions = sqlRepository.Symptoms.OfType<MissedElementSymptom>().Count(s => s.Original.Element.Type == "function" && s.Modified.Element.Type == "function");
            var mnConstructors = sqlRepository.Symptoms.OfType<MissedElementSymptom>().Count(s => s.Original.Element.Type == "constructor" && s.Modified.Element.Type == "constructor");
            var mnDestructors = sqlRepository.Symptoms.OfType<MissedElementSymptom>().Count(s => s.Original.Element.Type == "destructor" && s.Modified.Element.Type == "destructor");
            var mnFormalArguments = sqlRepository.Symptoms.OfType<MissedElementSymptom>().Count(s => s.Original.Element.Type == "formal argument" && s.Modified.Element.Type == "formal argument");
            var mnActualArguments = sqlRepository.Symptoms.OfType<MissedElementSymptom>().Count(s => s.Original.Element.Type == "actual argument" && s.Modified.Element.Type == "actual argument");
            var mnVariables = sqlRepository.Symptoms.OfType<MissedElementSymptom>().Count(s => s.Original.Element.Type == "variable" && s.Modified.Element.Type == "variable");
            var mi = sqlRepository.Symptoms.OfType<IncompatibleMatchingSymptom>().Count();
            var miThis = sqlRepository.Symptoms.OfType<IncompatibleMatchingSymptom>().Count(s => s.Pattern == "this instance expression");
            var miBase = sqlRepository.Symptoms.OfType<IncompatibleMatchingSymptom>().Count(s => s.Pattern == "base instance expression");
            var miBltInNonBltInTypes = sqlRepository.Symptoms.OfType<IncompatibleMatchingSymptom>().Count(s => s.Pattern == "builtin type updates to non-builtin type");
            var miNull = sqlRepository.Symptoms.OfType<IncompatibleMatchingSymptom>().Count(s => s.Pattern == "null literal mismatch");
            var miTrue = sqlRepository.Symptoms.OfType<IncompatibleMatchingSymptom>().Count(s => s.Pattern == "true literal mismatch");
            var miFalse = sqlRepository.Symptoms.OfType<IncompatibleMatchingSymptom>().Count(s => s.Pattern == "false literal mismatch");
            var miLiterals = sqlRepository.Symptoms.OfType<IncompatibleMatchingSymptom>().Count(s => s.Pattern == "literals update");
            var miRenames = sqlRepository.Symptoms.OfType<IncompatibleMatchingSymptom>().Count(s => s.Pattern == "renames");
            var miOperators = sqlRepository.Symptoms.OfType<IncompatibleMatchingSymptom>().Count(s => s.Pattern == "different operators");
            this.Report.AppendLine($"{sqlRepository.Name};" +
                                   $"{mn};" +
                                   $"{mnClasses};" +
                                   $"{mnInterfaces};" +
                                   $"{mnEnums};" +
                                   $"{mnStructs};" +
                                   $"{mnProperties};" +
                                   $"{mnFields};" +
                                   $"{mnEnumValues};" +
                                   $"{mnFunctions};" +
                                   $"{mnConstructors};" +
                                   $"{mnDestructors};" +
                                   $"{mnFormalArguments};" +
                                   $"{mnActualArguments};" +
                                   $"{mnVariables};" +
                                   $"{mn - (mnClasses + mnInterfaces + mnEnums + mnStructs + mnProperties + mnFields + mnFunctions + mnConstructors + mnDestructors +mnFormalArguments+ mnActualArguments + mnEnumValues + mnVariables)};" +
                                   $"{mi};" +
                                   $"{miThis};" +
                                   $"{miBase};" +
                                   $"{miBltInNonBltInTypes};" +
                                   $"{miNull};" +
                                   $"{miTrue};" +
                                   $"{miFalse};" +
                                   $"{miLiterals};" +
                                   $"{miRenames};" +
                                   $"{miOperators}");
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

                        int insertionIndex = originalTree.PostOrder(n => n.Children).Max(n => int.Parse(n.Root.Id));

                        var originalTransformations = new Dictionary<string, TransformationInfo>();
                        var modifiedTransformations = new Dictionary<string, TransformationInfo>();

                        foreach (var action in detectionResult.Actions)
                        {
                            token.ThrowIfCancellationRequested();

                            ElementTree element;
                            TransformationInfo transformationInfo;
                            switch (action.Action)
                            {
                                case ActionKind.Update:
                                    var updateAction = (UpdateOperationDescriptor) action;
                                    element = originalTree.PostOrder(n => n.Children).Single(n => n.Root.Id == updateAction.Element.Id);
                                    transformationInfo = this.GetOrCreateTransformationInfo(originalTransformations,
                                        modifiedTransformations, element, "original");
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
                                    ++insertionIndex;
                                    transformationInfo = new TransformationInfo
                                    {
                                        Id = insertAction.Element.Id,
                                        Type = insertAction.Element.Label,
                                        Version = "modified",
                                        ScopeHint = null,
                                        Self = new Transformations { Insertions = 1 },
                                        FromATotalOfChildren = 0,
                                        WithATotalOfOperatorsOfChildren = 0,
                                        Children = new Transformations(),
                                        FromATotalOfDescendants = 0,
                                        WithATotalOfOperatorsOfDescendants = 0,
                                        Descendants = new Transformations()
                                    };
                                    originalTransformations[insertAction.Element.Id] = transformationInfo;
                                    detectionResult.Matches.Add(new RevisionDescriptor
                                    {
                                        Original = new ElementDescriptor
                                        {
                                            Id = insertionIndex.ToString(),
                                            Label = insertAction.Element.Label,
                                            Value = insertAction.Element.Value
                                        },
                                        Modified = new ElementDescriptor
                                        {
                                            Id = insertAction.Element.Id,
                                            Label = insertAction.Element.Label,
                                            Value = insertAction.Element.Value
                                        }
                                    });

                                    var parentMatch = detectionResult.Matches.Single(m => m.Modified.Id == insertAction.Parent.Id); 
                                    var parentElement = originalTree.PostOrder(n => n.Children).Single(n => n.Root.Id == parentMatch.Original.Id);
                                    //if (transformationInfo.ScopeHint == null)
                                    //{
                                    //    transformationInfo.ScopeHint = $"{insertAction.Parent.Label}:{insertAction.Parent.Id}";
                                    //    var context = this.NameContexts.SingleOrDefault(nc => nc.Criterion(parentElement));
                                    //    transformationInfo.ScopeHint += "##" + (context != null
                                    //            ? this.GetPath(context.OuterScopes(parentElement))
                                    //            : this.GetPath(parentElement.Ancestors().Where(ancestor => ancestor.Root.Label == "block")));
                                    //}

                                    var children = new List<ElementTree>(parentElement.Children)
                                    {
                                        new ElementTree
                                        {
                                            Parent = parentElement,
                                            Root = new ElementDescriptor
                                            {
                                                Id = insertionIndex.ToString(), 
                                                Label = insertAction.Element.Label,
                                                Value = insertAction.Element.Value
                                            }
                                        }
                                    };
                                    parentElement.Children = children;
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
                                    element = originalTree.PostOrder(n => n.Children).Single(n => n.Root.Id == deleteAction.Element.Id);
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
                                    element = originalTree.PostOrder(n => n.Children).Single(n => n.Root.Id == moveAction.Element.Id);
                                    var parentsMatches = detectionResult.Matches.Where(m => m.Modified.Id == moveAction.Parent.Id).ToList();
                                    RevisionDescriptor parentsMatch;
                                    if (parentsMatches.Count > 1)
                                    {
                                        parentsMatch = parentsMatches.Single(delegate(RevisionDescriptor descriptor)
                                        {
                                            var o = originalTree.PostOrder(n => n.Children).Single(n => n.Root.Id == descriptor.Original.Id);
                                            return !o.Children.Contains(element);
                                        });
                                    }
                                    else
                                    {
                                        parentsMatch = parentsMatches.Single();
                                    }
                                    var fromParentElement = element.Parent;
                                    parentElement = originalTree.PostOrder(n => n.Children).Single(n => n.Root.Id == parentsMatch.Original.Id);
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
                        this.Report.AppendLine($"CANCELED;{pair.Id};{sqlRepository.Name}");
                        throw;
                    }
                    catch (OutOfMemoryException)
                    {
                        this.Report.AppendLine($"OUTOFMEMORY;{pair.Id};{sqlRepository.Name}");
                        throw;
                    }
                },
            cancel, false, "Principal");
        }

        private TransformationInfo GetOrCreateTransformationInfo(Dictionary<string, TransformationInfo> originalTransformationsInfo,
            Dictionary<string, TransformationInfo> modifiedTransformationsInfo, ElementTree element, string version)
        {
            var transformationsInfo = version == "original" ? originalTransformationsInfo : modifiedTransformationsInfo;
            if (transformationsInfo.ContainsKey(element.Root.Id))
                return transformationsInfo[element.Root.Id];

            return CreateTransformationInfo(element, version, transformationsInfo);
        }

        //private TransformationInfo GetOrCreateTransformationInfo(Dictionary<string, TransformationInfo> originalTransformationsInfo,
        //   Dictionary<string, TransformationInfo> modifiedTransformationsInfo, ElementDescriptor element, string version)
        //{
        //    var transformationsInfo = version == "original" ? originalTransformationsInfo : modifiedTransformationsInfo;
        //    if (transformationsInfo.ContainsKey(element.Id))
        //        return transformationsInfo[element.Id];

        //    var t = new TransformationInfo
        //    {
        //        Id = element.Id,
        //        Type = element.Label,
        //        Version = version,
        //        ScopeHint = null,
        //        Self = new Transformations(),
        //        FromATotalOfChildren = -1,
        //        WithATotalOfOperatorsOfChildren = -1,
        //        Children = new Transformations(),
        //        FromATotalOfDescendants = -1,
        //        WithATotalOfOperatorsOfDescendants = -1,
        //        Descendants = new Transformations()
        //    };

        //    transformationsInfo[element.Id] = t;

        //    return t;
        //}

        private TransformationInfo CreateTransformationInfo(ElementTree element, string version, Dictionary<string, TransformationInfo> transformationsInfo)
        {
            var context = this.NameContexts.SingleOrDefault(nc => nc.Criterion(element));
            var t = new TransformationInfo
            {
                Id = element.Root.Id,
                Type = context?.NameOf(element) ?? element.Root.Label,
                Version = version,
                //ScopeHint = context != null
                //    ? this.GetPath(context.OuterScopes(element))
                //    : this.GetPath(element.Ancestors().Where(ancestor => ancestor.Root.Label == "block")),
                Self = new Transformations(),
                FromATotalOfChildren = element.Children.Count(),
                WithATotalOfOperatorsOfChildren = element.Children.Count(c => c.Root.Label == "operator"),
                Children = new Transformations(),
                FromATotalOfDescendants = element.PostOrder(n => n.Children)
                    .Count(d => d != element && !element.Children.Contains(d)),
                WithATotalOfOperatorsOfDescendants = element.PostOrder(n => n.Children)
                    .Count(d => d != element && d.Root.Label == "operator" && !element.Children.Contains(d)),
                Descendants = new Transformations()
            };

            transformationsInfo[element.Root.Id] = t;

            return t;
        }

        private void PropagateTransformation(IEnumerable<ElementTree> over, Func<TransformationInfo, int> getTransformation, Action<TransformationInfo, int> setTransformation, ElementTree ast, 
            Dictionary<string, TransformationInfo> originalTransformationsInfo,
            Dictionary<string, TransformationInfo> modifiedTransformationsInfo)
        {
            foreach (var ancestor in over)
            {
                //match = detectionResult.Matches.Single(m => m.Original.Id == ancestor.Root.Id);
                var ancestorTree = ast.PostOrder(n => n.Children).Single(n => n.Root.Id == ancestor.Root.Id);
                var transformationInfo = ancestorTree == null 
                    ? this.GetOrCreateTransformationInfo(originalTransformationsInfo, modifiedTransformationsInfo,
                                                        ancestor, "modified")
                    : this.GetOrCreateTransformationInfo(originalTransformationsInfo,
                    modifiedTransformationsInfo, ancestorTree,
                    ast.PostOrder(n => n.Children).Any(n => n == ancestorTree)
                                            ? "original"
                                            : "modified");
                setTransformation(transformationInfo, getTransformation(transformationInfo) + 1);
            }
        }

        public virtual void RateMissedNameSymptoms(GitRepository sqlRepository, 
            ChangeDetectionApproaches approach,
            SourceCodeCleaner cleaner, string originalFilePath, string modifiedFilePath)
        {
            this.Analyze(sqlRepository, "redundancy analysis",
              f => f.Principal.Deltas.Any(d => d.Approach == approach &&
                                               d.Matching != null &&
                                               d.Differencing != null &&
                                               d.Report == null &&
                                               d.Symptoms.OfType<MissedNameSymptom>().Any(s => s.Original.Element.Type == "formal argument" && s.Modified.Element.Type == "formal argument")),
                delegate (FileRevisionPair pair, CancellationToken token)
                {
                    //if (skipThese?.Invoke(pair) ?? false) return;

                    var delta = sqlRepository.Deltas.Single(d => d.RevisionPair.Id == pair.Principal.Id && d.Approach == approach);
                    var symptomIds = sqlRepository.Symptoms.OfType<MissedNameSymptom>()
                        .Where(s => s.Delta.Id == delta.Id)
                        .Where(s => s.Original.Element.Type == "formal argument" && s.Modified.Element.Type == "formal argument")
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
                        sqlRepository.Symptoms.OfType<MissedNameSymptom>().Where(s => s.Id == symptomId).Load();
                        var symptom = delta.Symptoms.OfType<MissedNameSymptom>().Single(s => s.Id == symptomId);

                        var o = pairs.SingleOrDefault(p => p.Oid == symptom.Original.Element.Id);
                        var m = pairs.SingleOrDefault(p => p.Mid == symptom.Modified.Element.Id);
                        if (o != null && m != null)
                        {
                            Review review = null;
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
                            var oElement = original.DescendantNodesAndSelf().OfType<ParameterSyntax>()
                                .Where(e => e.Identifier.ValueText == symptom.Original.Element.Hint)
                                .ToList();
                            var mElement = modified.DescendantNodesAndSelf().OfType<ParameterSyntax>()
                                .Where(e => e.Identifier.ValueText == symptom.Modified.Element.Hint)
                                .ToList();
                            string oLine = "-1", mLine = "-1";
                            if (oElement.Count == 1 && mElement.Count == 1)
                            {
                                oLine = (oElement.Single().GetLocation().GetLineSpan().StartLinePosition.Line + 1).ToString(CultureInfo.InvariantCulture);
                                mLine = (mElement.Single().GetLocation().GetLineSpan().StartLinePosition.Line + 1).ToString(CultureInfo.InvariantCulture);
                            }
                            else
                            {
                                var classPattern = new Regex(@"##class:(\d+)\(([^##]*)\)##");
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
                                        oElement = oMethods.Single().DescendantNodesAndSelf().OfType<ParameterSyntax>()
                                            .Where(e => e.Identifier.ValueText == symptom.Original.Element.Hint)
                                            .ToList();
                                        mElement = mMethods.Single().DescendantNodesAndSelf().OfType<ParameterSyntax>()
                                            .Where(e => e.Identifier.ValueText == symptom.Modified.Element.Hint)
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
                                


                                //var oClass = original.DescendantNodesAndSelf().OfType<BaseTypeDeclarationSyntax>()
                                //    .Where(c => c.Identifier.ValueText == oClassName)
                                //    .ToList();
                                //var mClass = modified.DescendantNodesAndSelf().OfType<BaseTypeDeclarationSyntax>()
                                //    .Where(c => c.Identifier.ValueText == mClassName)
                                //    .ToList();

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
                                //if (oClass.Count == 1 && mClass.Count == 1)
                                //{
                                //    oElement = oClass.Single().DescendantNodesAndSelf().OfType<ParameterSyntax>()
                                //        .Where(e => e.Identifier.ValueText == symptom.Original.Element.Hint)
                                //        .ToList();
                                //    mElement = mClass.Single().DescendantNodesAndSelf().OfType<ParameterSyntax>()
                                //        .Where(e => e.Identifier.ValueText == symptom.Modified.Element.Hint)
                                //        .ToList();
                                //    if (oElement.Count == 1 && mElement.Count == 1)
                                //    {
                                //        oLine = (oElement.Single().GetLocation().GetLineSpan().StartLinePosition.Line + 1).ToString(CultureInfo.InvariantCulture);
                                //        mLine = (mElement.Single().GetLocation().GetLineSpan().StartLinePosition.Line + 1).ToString(CultureInfo.InvariantCulture);
                                //    }

                                //    if (oClass.Single().Identifier.ValueText != mClass.Single().Identifier.ValueText)
                                //    {
                                //        prefix = "Imprecise ";
                                //        match = " not ";
                                //    }
                                //}
                                //else
                                //;
                            }

                            int oClasses = original.DescendantNodesAndSelf().OfType<BaseTypeDeclarationSyntax>().Count();
                            int mClasses = modified.DescendantNodesAndSelf().OfType<BaseTypeDeclarationSyntax>().Count();
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
                            }
                    }
                },
            null, true, "Principal.FileVersion.Content", "Principal.FromFileVersion.Content");
        }

        public virtual void RateIncompatibleMatchingSymptoms(GitRepository sqlRepository,
            ChangeDetectionApproaches approach,
            SourceCodeCleaner cleaner, string originalFilePath, string modifiedFilePath)
        {
            this.Analyze(sqlRepository, "incompatible analysis",
              f => f.Principal.Deltas.Any(d => d.Approach == approach &&
                                               d.Matching != null &&
                                               d.Differencing != null &&
                                               d.Report == null &&
                                               d.Symptoms.OfType<IncompatibleMatchingSymptom>().Any()),
                delegate (FileRevisionPair pair, CancellationToken token)
                {
                    //if (skipThese?.Invoke(pair) ?? false) return;

                    var delta = sqlRepository.Deltas.Single(d => d.RevisionPair.Id == pair.Principal.Id && d.Approach == approach);
                    var symptomIds = sqlRepository.Symptoms.OfType<IncompatibleMatchingSymptom>()
                        .Where(s => s.Delta.Id == delta.Id)
                        .Select(s => s.Id).ToList();

                    //var cleaner = new SourceCodeCleaner();
                    var original = SyntaxFactory.ParseCompilationUnit(pair.Principal.FromFileVersion.Content.SourceCode).SyntaxTree.GetRoot();
                    var modified = SyntaxFactory.ParseCompilationUnit(pair.Principal.FileVersion.Content.SourceCode).SyntaxTree.GetRoot();

                    var preprocessedOriginal = cleaner != null ? cleaner.Clean(original) : original;
                    var preprocessedModified = cleaner != null ? cleaner.Clean(modified) : modified;
                    System.IO.File.WriteAllText(originalFilePath, preprocessedOriginal.ToFullString(), Encoding.Default);
                    System.IO.File.WriteAllText(modifiedFilePath, preprocessedModified.ToFullString(), Encoding.Default);

                    foreach (var symptomId in symptomIds)
                    {
                        sqlRepository.Symptoms.OfType<IncompatibleMatchingSymptom>().Where(s => s.Id == symptomId).Load();
                        var symptom = delta.Symptoms.OfType<IncompatibleMatchingSymptom>().Single(s => s.Id == symptomId);
                        string originalElement = $"({symptom.Original.Element.Id})-{symptom.Original.Element.Type} \"{symptom.Original.Element.Hint}\"";
                        string modifiedElement = $"({symptom.Modified.Element.Id})-{symptom.Modified.Element.Type} \"{symptom.Modified.Element.Hint}\"";
                        var review = new Review
                        {
                            Id = Guid.NewGuid(),
                            Kind = ReviewKind.Spuriosity_IncompatibleMatches,
                            CaseKind = CaseKind.Symptom,
                            Severity = ReviewSeverity.Bad,
                            Subject = $"Spurious update - {symptom.Original.Element.Type} " +
                                                 $"\"{symptom.Original.Element.Hint}\"-(ol:{-1}, " +
                                                 $"oid:{symptom.Original.Element.Id})" +
                                      $" should not match to {symptom.Modified.Element.Type} " +
                                                 $"\"{symptom.Modified.Element.Hint}\"-(ml:{-1}, " +
                                                 $"mid:{symptom.Modified.Element.Id})",
                            Comments = "",
                            Topics = Topics.Matching /**//*Topics.Domain*/ /* | Topics.Matching *//*| Topics.Differencing*/ /*| Topics.Report*/,
                            SpuriousMatch = true,
                            SpuriousChanges = true
                        };
                        switch (symptom.Pattern)
                        {
                            case "this instance expression":
                                //if (symptom.Original.Element.Hint != "this")
                                //{
                                //    review.Subject =
                                //        $"Spurious update - {symptom.Original.Element.Type} \"{symptom.Original.Element.Hint}\"" +
                                //        $"-(ol:{-1}, oid:{symptom.Original.Element.Id})" +
                                //        $" should not match to an instance expression \"{symptom.Modified.Element.Hint}\"" +
                                //        $"-(ml:{-1}, mid:{symptom.Modified.Element.Id})";
                                //}
                                //else
                                //{
                                //    review.Subject =
                                //        $"Spurious update - an instance expression \"{symptom.Original.Element.Hint}\"" +
                                //        $"-(ol:{-1}, oid:{symptom.Original.Element.Id})" +
                                //        $" should not match to {symptom.Modified.Element.Type} \"{symptom.Modified.Element.Hint}\"" +
                                //        $"-(ml:{-1}, mid:{symptom.Modified.Element.Id})";
                                //}
                                review.ArbitraryMatch = true;
                                review.UnnaturalMatch = true;
                                break;
                            case "base instance expression":
                                //review.Subject = $"Spurious update - {symptom.Original.Element.Type} " +
                                //                 $"\"{symptom.Original.Element.Hint}\"-(ol:{-1}, " +
                                //                 $"oid:{symptom.Original.Element.Id})" +
                                //$" should not match to {symptom.Modified.Element.Type} " +
                                //                 $"\"{symptom.Modified.Element.Hint}\"-(ml:{-1}, " +
                                //                 $"mid:{symptom.Modified.Element.Id})";

                                //if (symptom.Original.Element.Hint != "base")
                                //{
                                //    review.Subject =
                                //        $"Spurious update - {symptom.Original.Element.Type} \"{symptom.Original.Element.Hint}\"" +
                                //        $"-(ol:{-1}, oid:{symptom.Original.Element.Id})" +
                                //        $" should not match to an instance expression \"{symptom.Modified.Element.Hint}\"" +
                                //        $"-(ml:{-1}, mid:{symptom.Modified.Element.Id})";
                                //}
                                //else
                                //{
                                //    review.Subject =
                                //        $"Spurious update - an instance expression \"{symptom.Original.Element.Hint}\"" +
                                //        $"-(ol:{-1}, oid:{symptom.Original.Element.Id})" +
                                //        $" should not match to {symptom.Modified.Element.Type} \"{symptom.Modified.Element.Hint}\"" +
                                //        $"-(ml:{-1}, mid:{symptom.Modified.Element.Id})";
                                //}
                                review.ArbitraryMatch = true;
                                review.UnnaturalMatch = true;
                                break;
                            //case "incompatible comments?":
                            case "builtin type updates to non-builtin type":
                                review.ArbitraryMatch = true;
                                break;
                            case "null literal mismatch":
                            case "true literal mismatch":
                            case "false literal mismatch":
                            case "literals update":
                                review.UnnaturalMatch = true;
                                break;
                            case "renames":
                            case "different operators":
                                review.UnnaturalMatch = true;
                                //review.Subject = $"Spurious update - {symptom.Original.Element.Type} \"{symptom.Original.Element.Hint}\"-(ol:{-1}, oid:{symptom.Original.Element.Id})" +
                                //$" should not match to {symptom.Modified.Element.Type} \"{symptom.Modified.Element.Hint}\"-(ml:{-1}, mid:{symptom.Modified.Element.Id})";
                                break;
                            
                            default:
                                ;
                                throw new NotImplementedException();
                        }
                        pair.Reviews.Add(review);
                    }
                },
            null, true, "Principal.FileVersion.Content", "Principal.FromFileVersion.Content");
        }
    }
}
