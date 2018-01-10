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
using System.Xml.Schema;
using Jawilliam.CDF.Actions;
using Jawilliam.CDF.Approach;
using Jawilliam.CDF.Metrics;
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
        private KeyValuePair<string, double>[] _relativeThresholds = new[]
            {
                new KeyValuePair<string, double>("class", 0.75),
                new KeyValuePair<string, double>("expr_stmt", 0.50),
                new KeyValuePair<string, double>("call", 0.34),
                new KeyValuePair<string, double>("block", 0.50),
                new KeyValuePair<string, double>("namespace", 0.77),
                new KeyValuePair<string, double>("function", 0.61),
                new KeyValuePair<string, double>("argument", 0.34),
                new KeyValuePair<string, double>("argument_list", 0.37),
                new KeyValuePair<string, double>("decl", 0.46),
                new KeyValuePair<string, double>("init", 0.50),
                new KeyValuePair<string, double>("expr", 0.29),
                new KeyValuePair<string, double>("decl_stmt", 0.50),
                new KeyValuePair<string, double>("if", 0.52),
                new KeyValuePair<string, double>("then", 0.50),
                new KeyValuePair<string, double>("name", 0.09),
                new KeyValuePair<string, double>("condition", 0.50),
                new KeyValuePair<string, double>("lambda", 0.56),
                new KeyValuePair<string, double>("else", 0.55),
                new KeyValuePair<string, double>("constructor", 0.65),
                new KeyValuePair<string, double>("try", 0.61),
                new KeyValuePair<string, double>("return", 0.50),
                new KeyValuePair<string, double>("type", 0.23),
                new KeyValuePair<string, double>("foreach", 0.61),
                new KeyValuePair<string, double>("using_stmt", 0.55)
            };

        /// <summary>
        /// Analyzes the similarity in according with a given similarity metric, such as Levenshtein.
        /// </summary>
        /// <param name="sqlRepository">the SQL database repository in which to analyze the file versions.</param>
        /// <param name="approach"></param>
        /// <param name="skipThese">local criterion for determining elements that should be ignored.</param>
        /// <param name="csvDescriptions">CSV lines describing different cases of the subcorpus.</param>
        /// <param name="subcorpusPrefix">the kind of subcorpus.</param>
        public virtual void SetSubcorpus(GitRepository sqlRepository, ChangeDetectionApproaches approach, 
            Func<FileRevisionPair, bool> skipThese, string[] csvDescriptions, string subcorpusPrefix,
            Func<Delta, SubcorpusKind?> getSubcorpus, Action<Delta, SubcorpusKind?> setSubcorpus)
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
                        //OutlierRandom = values[9].TrimStart('\"').TrimEnd('\"'),
                        MedianCloser = values[14],
                        MedianCloserRandom = values[12]
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
                            subcorpusSpec |= SubcorpusKind.RatioLvGtHigherOutlier;
                        if (description.Outlier == "Low")
                            subcorpusSpec |= SubcorpusKind.RatioLvGtLowerOutlier;
                        if (description.Random == "TRUE")
                            subcorpusSpec |= SubcorpusKind.RatioLvGtRandom;
                        if (description.MedianCloser == "\"Low\"")
                            subcorpusSpec |= SubcorpusKind.RatioLvGtMedianCloserLow;
                        if (description.MedianCloser == "\"High\"")
                            subcorpusSpec |= SubcorpusKind.RatioLvGtMedianCloserHigh;
                        if (description.MedianCloser == "\"Median\"")
                            subcorpusSpec |= SubcorpusKind.RatioLvGtMedianCloserExact;
                        if (description.MedianCloserRandom == "TRUE")
                            subcorpusSpec |= SubcorpusKind.RatioLvGtMedianCloserRandom;
                    }
                    else
                    {
                        subcorpusSpec = SubcorpusKind.NotAssigned;
                    }

                    if (subcorpusSpec != SubcorpusKind.None)
                    {
                        var subcorpus = getSubcorpus(delta);
                        setSubcorpus(delta, subcorpus == null ? subcorpusSpec : subcorpus | subcorpusSpec);
                    }
                }, null, true, "Principal");
        }

        /// <summary>
        /// Summarizes the count of elements for each kind of subcorpus.
        /// </summary>
        /// <param name="sqlRepository">the SQL database repository in which to analyze the file versions.</param>
        /// <param name="symptomApproach"></param>
        public virtual void SummarizeSubcorpusSelection(GitRepository sqlRepository, ChangeDetectionApproaches symptomApproach, ChangeDetectionApproaches subcorpusApproach, bool namesRow)
        {
            this.Analyze(sqlRepository, "summary of subcorpus choices",
              f => f.Principal.Deltas.Any(d => d.Approach == symptomApproach &&
                                               d.Matching != null &&
                                               d.Differencing != null &&
                                               d.Report == null)
                                               &&
                    f.Principal.Deltas.Any(d => d.Approach == subcorpusApproach/* &&
                                               (d.GlobalSubcorpus != null ||
                                               d.GlobalInsertPorcentageSubcorpus != null ||
                                               d.GlobalDeletePorcentageSubcorpus != null ||
                                               d.GlobalUpdatePorcentageSubcorpus != null ||
                                               d.GlobalMovePorcentageSubcorpus != null)*/),
                delegate (FileRevisionPair pair, CancellationToken token)
                {
                    //if (skipThese?.Invoke(pair) ?? false) return;

                    var delta = sqlRepository.Deltas.Single(d => d.RevisionPair.Id == pair.Principal.Id && d.Approach == symptomApproach);
                    if (namesRow)
                        this.Report.AppendLine("Project;Frp;GHO;GLO;GHMC;GEMC;GLMC;GNA;" + 
                                                           "IHO;ILO;IHMC;IEMC;ILMC;INA;" + 
                                                           "DHO;DLO;DHMC;DEMC;DLMC;DNA;" +
                                                           "UHO;ULO;UHMC;UEMC;ULMC;UNA;" +
                                                           "MHO;MLO;MHMC;MEMC;MLMC;MNA;" +
                                                           "MN;MN-Class;MN-Interface;MN-Enum;MN-Struct;MN-prop;MN-fld;MN-ev;MN-func;MN-ctor;MN-dtor;MN-farg;MN-aarg;MN-var;MN-others;" +
                                                           "IM;IM-this;IM-base;IM-btinNonbtinTypes;IM-null;IM-true;IM-false;IM-literals;IM-names;IM-optors");

                    var mn = sqlRepository.Symptoms.Where(d => d.Delta.Id == delta.Id).OfType<MissedElementSymptom>().Count();
                    //var mnNamespaces = sqlRepository.Symptoms.OfType<MissedElementSymptom>().Count(s => s.Original.Element.Type == "namespace" && s.Modified.Element.Type == "namespace");
                    var mnClasses = sqlRepository.Symptoms.Where(d => d.Delta.Id == delta.Id).OfType<MissedElementSymptom>().Count(s => s.Original.Element.Type == "class" && s.Modified.Element.Type == "class");
                    var mnInterfaces = sqlRepository.Symptoms.Where(d => d.Delta.Id == delta.Id).OfType<MissedElementSymptom>().Count(s => s.Original.Element.Type == "interface" && s.Modified.Element.Type == "interface");
                    var mnEnums = sqlRepository.Symptoms.Where(d => d.Delta.Id == delta.Id).OfType<MissedElementSymptom>().Count(s => s.Original.Element.Type == "enum" && s.Modified.Element.Type == "enum");
                    var mnStructs = sqlRepository.Symptoms.Where(d => d.Delta.Id == delta.Id).OfType<MissedElementSymptom>().Count(s => s.Original.Element.Type == "struct" && s.Modified.Element.Type == "struct");
                    var mnEnumValues = sqlRepository.Symptoms.Where(d => d.Delta.Id == delta.Id).OfType<MissedElementSymptom>().Count(s => s.Original.Element.Type == "enumvalue" && s.Modified.Element.Type == "enumvalue");
                    var mnProperties = sqlRepository.Symptoms.Where(d => d.Delta.Id == delta.Id).OfType<MissedElementSymptom>().Count(s => s.Original.Element.Type == "property" && s.Modified.Element.Type == "property");
                    var mnFields = sqlRepository.Symptoms.Where(d => d.Delta.Id == delta.Id).OfType<MissedElementSymptom>().Count(s => s.Original.Element.Type == "field" && s.Modified.Element.Type == "field");
                    var mnFunctions = sqlRepository.Symptoms.Where(d => d.Delta.Id == delta.Id).OfType<MissedElementSymptom>().Count(s => s.Original.Element.Type == "function" && s.Modified.Element.Type == "function");
                    var mnConstructors = sqlRepository.Symptoms.Where(d => d.Delta.Id == delta.Id).OfType<MissedElementSymptom>().Count(s => s.Original.Element.Type == "constructor" && s.Modified.Element.Type == "constructor");
                    var mnDestructors = sqlRepository.Symptoms.Where(d => d.Delta.Id == delta.Id).OfType<MissedElementSymptom>().Count(s => s.Original.Element.Type == "destructor" && s.Modified.Element.Type == "destructor");
                    var mnFormalArguments = sqlRepository.Symptoms.Where(d => d.Delta.Id == delta.Id).OfType<MissedElementSymptom>().Count(s => s.Original.Element.Type == "formal argument" && s.Modified.Element.Type == "formal argument");
                    var mnActualArguments = sqlRepository.Symptoms.Where(d => d.Delta.Id == delta.Id).OfType<MissedElementSymptom>().Count(s => s.Original.Element.Type == "actual argument" && s.Modified.Element.Type == "actual argument");
                    var mnVariables = sqlRepository.Symptoms.Where(d => d.Delta.Id == delta.Id).OfType<MissedElementSymptom>().Count(s => s.Original.Element.Type == "variable" && s.Modified.Element.Type == "variable");
                    var mi = sqlRepository.Symptoms.Where(d => d.Delta.Id == delta.Id).OfType<IncompatibleMatchingSymptom>().Count();
                    var miThis = sqlRepository.Symptoms.Where(d => d.Delta.Id == delta.Id).OfType<IncompatibleMatchingSymptom>().Count(s => s.Pattern == "this instance expression");
                    var miBase = sqlRepository.Symptoms.Where(d => d.Delta.Id == delta.Id).OfType<IncompatibleMatchingSymptom>().Count(s => s.Pattern == "base instance expression");
                    var miBltInNonBltInTypes = sqlRepository.Symptoms.Where(d => d.Delta.Id == delta.Id).OfType<IncompatibleMatchingSymptom>().Count(s => s.Pattern == "builtin type updates to non-builtin type");
                    var miNull = sqlRepository.Symptoms.Where(d => d.Delta.Id == delta.Id).OfType<IncompatibleMatchingSymptom>().Count(s => s.Pattern == "null literal mismatch");
                    var miTrue = sqlRepository.Symptoms.Where(d => d.Delta.Id == delta.Id).OfType<IncompatibleMatchingSymptom>().Count(s => s.Pattern == "true literal mismatch");
                    var miFalse = sqlRepository.Symptoms.Where(d => d.Delta.Id == delta.Id).OfType<IncompatibleMatchingSymptom>().Count(s => s.Pattern == "false literal mismatch");
                    var miLiterals = sqlRepository.Symptoms.Where(d => d.Delta.Id == delta.Id).OfType<IncompatibleMatchingSymptom>().Count(s => s.Pattern == "literals update");
                    var miRenames = sqlRepository.Symptoms.Where(d => d.Delta.Id == delta.Id).OfType<IncompatibleMatchingSymptom>().Count(s => s.Pattern == "renames");
                    var miOperators = sqlRepository.Symptoms.Where(d => d.Delta.Id == delta.Id).OfType<IncompatibleMatchingSymptom>().Count(s => s.Pattern == "different operators");

                    delta = sqlRepository.Deltas.Single(d => d.RevisionPair.Id == pair.Principal.Id && d.Approach == subcorpusApproach);
                    Func<SubcorpusKind?, SubcorpusKind, string> getSelection = (s, s1) => s == null ? "" : ((s.Value & s1) == s1).ToString(CultureInfo.InvariantCulture);

                    this.Report.AppendLine($"{sqlRepository.Name};{pair.Id};" + 
                                           $"{getSelection(delta.GlobalSubcorpus, SubcorpusKind.RatioLvGtHigherOutlier)};" +
                                           $"{getSelection(delta.GlobalSubcorpus, SubcorpusKind.RatioLvGtLowerOutlier)};" +
                                           $"{getSelection(delta.GlobalSubcorpus, SubcorpusKind.RatioLvGtMedianCloserHigh)};" +
                                           $"{getSelection(delta.GlobalSubcorpus, SubcorpusKind.RatioLvGtMedianCloserExact)};" +
                                           $"{getSelection(delta.GlobalSubcorpus, SubcorpusKind.RatioLvGtMedianCloserLow)};" +
                                           $"{getSelection(delta.GlobalSubcorpus, SubcorpusKind.NotAssigned)};" +
                                           $"{getSelection(delta.GlobalInsertPorcentageSubcorpus, SubcorpusKind.RatioLvGtHigherOutlier)};" +
                                           $"{getSelection(delta.GlobalInsertPorcentageSubcorpus, SubcorpusKind.RatioLvGtLowerOutlier)};" +
                                           $"{getSelection(delta.GlobalInsertPorcentageSubcorpus, SubcorpusKind.RatioLvGtMedianCloserHigh)};" +
                                           $"{getSelection(delta.GlobalInsertPorcentageSubcorpus, SubcorpusKind.RatioLvGtMedianCloserExact)};" +
                                           $"{getSelection(delta.GlobalInsertPorcentageSubcorpus, SubcorpusKind.RatioLvGtMedianCloserLow)};" +
                                           $"{getSelection(delta.GlobalInsertPorcentageSubcorpus, SubcorpusKind.NotAssigned)};" +
                                           $"{getSelection(delta.GlobalDeletePorcentageSubcorpus, SubcorpusKind.RatioLvGtHigherOutlier)};" +
                                           $"{getSelection(delta.GlobalDeletePorcentageSubcorpus, SubcorpusKind.RatioLvGtLowerOutlier)};" +
                                           $"{getSelection(delta.GlobalDeletePorcentageSubcorpus, SubcorpusKind.RatioLvGtMedianCloserHigh)};" +
                                           $"{getSelection(delta.GlobalDeletePorcentageSubcorpus, SubcorpusKind.RatioLvGtMedianCloserExact)};" +
                                           $"{getSelection(delta.GlobalDeletePorcentageSubcorpus, SubcorpusKind.RatioLvGtMedianCloserLow)};" +
                                           $"{getSelection(delta.GlobalDeletePorcentageSubcorpus, SubcorpusKind.NotAssigned)};" +
                                           $"{getSelection(delta.GlobalUpdatePorcentageSubcorpus, SubcorpusKind.RatioLvGtHigherOutlier)};" +
                                           $"{getSelection(delta.GlobalUpdatePorcentageSubcorpus, SubcorpusKind.RatioLvGtLowerOutlier)};" +
                                           $"{getSelection(delta.GlobalUpdatePorcentageSubcorpus, SubcorpusKind.RatioLvGtMedianCloserHigh)};" +
                                           $"{getSelection(delta.GlobalUpdatePorcentageSubcorpus, SubcorpusKind.RatioLvGtMedianCloserExact)};" +
                                           $"{getSelection(delta.GlobalUpdatePorcentageSubcorpus, SubcorpusKind.RatioLvGtMedianCloserLow)};" +
                                           $"{getSelection(delta.GlobalUpdatePorcentageSubcorpus, SubcorpusKind.NotAssigned)};" +
                                           $"{getSelection(delta.GlobalMovePorcentageSubcorpus, SubcorpusKind.RatioLvGtHigherOutlier)};" +
                                           $"{getSelection(delta.GlobalMovePorcentageSubcorpus, SubcorpusKind.RatioLvGtLowerOutlier)};" +
                                           $"{getSelection(delta.GlobalMovePorcentageSubcorpus, SubcorpusKind.RatioLvGtMedianCloserHigh)};" +
                                           $"{getSelection(delta.GlobalMovePorcentageSubcorpus, SubcorpusKind.RatioLvGtMedianCloserExact)};" +
                                           $"{getSelection(delta.GlobalMovePorcentageSubcorpus, SubcorpusKind.RatioLvGtMedianCloserLow)};" +
                                           $"{getSelection(delta.GlobalMovePorcentageSubcorpus, SubcorpusKind.NotAssigned)};" +
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
                                           $"{mn - (mnClasses + mnInterfaces + mnEnums + mnStructs + mnProperties + mnFields + mnFunctions + mnConstructors + mnDestructors + mnFormalArguments + mnActualArguments + mnEnumValues + mnVariables)};" +
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
                },
            () => {}, false, "Principal");
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

            var mn = sqlRepository.Symptoms.OfType<MissedElementSymptom>().Count(s => sqlRepository.FileRevisionPairs.Any(frp => frp.Principal == s.Delta.RevisionPair && (frp.Flags == null || (frp.Flags & RevisionPairFlags.EnumAnomalies) == 0)));
            //var mnNamespaces = sqlRepository.Symptoms.OfType<MissedElementSymptom>().Count(s => s.Original.Element.Type == "namespace" && s.Modified.Element.Type == "namespace");
            var mnClasses = sqlRepository.Symptoms.OfType<MissedElementSymptom>().Count(s => s.Original.Element.Type == "class" && s.Modified.Element.Type == "class" && sqlRepository.FileRevisionPairs.Any(frp => frp.Principal == s.Delta.RevisionPair && (frp.Flags == null || (frp.Flags & RevisionPairFlags.EnumAnomalies) == 0)));
            var mnInterfaces = sqlRepository.Symptoms.OfType<MissedElementSymptom>().Count(s => s.Original.Element.Type == "interface" && s.Modified.Element.Type == "interface" && sqlRepository.FileRevisionPairs.Any(frp => frp.Principal == s.Delta.RevisionPair && (frp.Flags == null || (frp.Flags & RevisionPairFlags.EnumAnomalies) == 0)));
            var mnEnums = sqlRepository.Symptoms.OfType<MissedElementSymptom>().Count(s => s.Original.Element.Type == "enum" && s.Modified.Element.Type == "enum" && sqlRepository.FileRevisionPairs.Any(frp => frp.Principal == s.Delta.RevisionPair && (frp.Flags == null || (frp.Flags & RevisionPairFlags.EnumAnomalies) == 0)));
            var mnStructs = sqlRepository.Symptoms.OfType<MissedElementSymptom>().Count(s => s.Original.Element.Type == "struct" && s.Modified.Element.Type == "struct" && sqlRepository.FileRevisionPairs.Any(frp => frp.Principal == s.Delta.RevisionPair && (frp.Flags == null || (frp.Flags & RevisionPairFlags.EnumAnomalies) == 0)));
            var mnEnumValues = sqlRepository.Symptoms.OfType<MissedElementSymptom>().Count(s => s.Original.Element.Type == "enumvalue" && s.Original.Element.Hint != null && s.Modified.Element.Type == "enumvalue" && s.Modified.Element.Hint != null && sqlRepository.FileRevisionPairs.Any(frp => frp.Principal == s.Delta.RevisionPair && (frp.Flags == null || (frp.Flags & RevisionPairFlags.EnumAnomalies) == 0)));
            var mnProperties = sqlRepository.Symptoms.OfType<MissedElementSymptom>().Count(s => s.Original.Element.Type == "property" && s.Modified.Element.Type == "property" && sqlRepository.FileRevisionPairs.Any(frp => frp.Principal == s.Delta.RevisionPair && (frp.Flags == null || (frp.Flags & RevisionPairFlags.EnumAnomalies) == 0)));
            var mnFields = sqlRepository.Symptoms.OfType<MissedElementSymptom>().Count(s => s.Original.Element.Type == "field" && s.Modified.Element.Type == "field" && sqlRepository.FileRevisionPairs.Any(frp => frp.Principal == s.Delta.RevisionPair && (frp.Flags == null || (frp.Flags & RevisionPairFlags.EnumAnomalies) == 0)));
            var mnFunctions = sqlRepository.Symptoms.OfType<MissedElementSymptom>().Count(s => s.Original.Element.Type == "function" && s.Modified.Element.Type == "function" && sqlRepository.FileRevisionPairs.Any(frp => frp.Principal == s.Delta.RevisionPair && (frp.Flags == null || (frp.Flags & RevisionPairFlags.EnumAnomalies) == 0)));
            var mnConstructors = sqlRepository.Symptoms.OfType<MissedElementSymptom>().Count(s => s.Original.Element.Type == "constructor" && s.Modified.Element.Type == "constructor" && sqlRepository.FileRevisionPairs.Any(frp => frp.Principal == s.Delta.RevisionPair && (frp.Flags == null || (frp.Flags & RevisionPairFlags.EnumAnomalies) == 0)));
            var mnDestructors = sqlRepository.Symptoms.OfType<MissedElementSymptom>().Count(s => s.Original.Element.Type == "destructor" && s.Modified.Element.Type == "destructor" && sqlRepository.FileRevisionPairs.Any(frp => frp.Principal == s.Delta.RevisionPair && (frp.Flags == null || (frp.Flags & RevisionPairFlags.EnumAnomalies) == 0)));
            var mnFormalArguments = sqlRepository.Symptoms.OfType<MissedElementSymptom>().Count(s => s.Original.Element.Type == "formal argument" && s.Modified.Element.Type == "formal argument" && s.Modified.Element.Hint.Length > 1 && s.Original.Element.Hint.Length > 1 && sqlRepository.FileRevisionPairs.Any(frp => frp.Principal == s.Delta.RevisionPair && (frp.Flags == null || (frp.Flags & RevisionPairFlags.EnumAnomalies) == 0)));
            var mnActualArguments = sqlRepository.Symptoms.OfType<MissedElementSymptom>().Count(s => s.Original.Element.Type == "actual argument" && s.Modified.Element.Type == "actual argument" && s.Modified.Element.Hint.Length > 1 && s.Original.Element.Hint.Length > 1 && sqlRepository.FileRevisionPairs.Any(frp => frp.Principal == s.Delta.RevisionPair && (frp.Flags == null || (frp.Flags & RevisionPairFlags.EnumAnomalies) == 0)));
            var mnVariables = sqlRepository.Symptoms.OfType<MissedElementSymptom>().Count(s => s.Original.Element.Type == "variable" && s.Modified.Element.Type == "variable" && s.Modified.Element.Hint.Length > 1 && s.Original.Element.Hint.Length > 1 && sqlRepository.FileRevisionPairs.Any(frp => frp.Principal == s.Delta.RevisionPair && (frp.Flags == null || (frp.Flags & RevisionPairFlags.EnumAnomalies) == 0)));
            var mi = sqlRepository.Symptoms.OfType<IncompatibleMatchingSymptom>().Count(s => sqlRepository.FileRevisionPairs.Any(frp => frp.Principal == s.Delta.RevisionPair && (frp.Flags == null || (frp.Flags & RevisionPairFlags.EnumAnomalies) == 0)));
            var miThis = sqlRepository.Symptoms.OfType<IncompatibleMatchingSymptom>().Count(s => s.Pattern == "this instance expression" && sqlRepository.FileRevisionPairs.Any(frp => frp.Principal == s.Delta.RevisionPair && (frp.Flags == null || (frp.Flags & RevisionPairFlags.EnumAnomalies) == 0)));
            var miBase = sqlRepository.Symptoms.OfType<IncompatibleMatchingSymptom>().Count(s => s.Pattern == "base instance expression" && sqlRepository.FileRevisionPairs.Any(frp => frp.Principal == s.Delta.RevisionPair && (frp.Flags == null || (frp.Flags & RevisionPairFlags.EnumAnomalies) == 0)));
            var miBltInNonBltInTypes = sqlRepository.Symptoms.OfType<IncompatibleMatchingSymptom>().Count(s => s.Pattern == "builtin type updates to non-builtin type" && sqlRepository.FileRevisionPairs.Any(frp => frp.Principal == s.Delta.RevisionPair && (frp.Flags == null || (frp.Flags & RevisionPairFlags.EnumAnomalies) == 0)));
            var miNull = sqlRepository.Symptoms.OfType<IncompatibleMatchingSymptom>().Count(s => s.Pattern == "null literal mismatch" && sqlRepository.FileRevisionPairs.Any(frp => frp.Principal == s.Delta.RevisionPair && (frp.Flags == null || (frp.Flags & RevisionPairFlags.EnumAnomalies) == 0)));
            var miTrue = sqlRepository.Symptoms.OfType<IncompatibleMatchingSymptom>().Count(s => s.Pattern == "true literal mismatch" && sqlRepository.FileRevisionPairs.Any(frp => frp.Principal == s.Delta.RevisionPair && (frp.Flags == null || (frp.Flags & RevisionPairFlags.EnumAnomalies) == 0)));
            var miFalse = sqlRepository.Symptoms.OfType<IncompatibleMatchingSymptom>().Count(s => s.Pattern == "false literal mismatch" && sqlRepository.FileRevisionPairs.Any(frp => frp.Principal == s.Delta.RevisionPair && (frp.Flags == null || (frp.Flags & RevisionPairFlags.EnumAnomalies) == 0)));
            var miLiterals = sqlRepository.Symptoms.OfType<IncompatibleMatchingSymptom>().Count(s => s.Pattern == "literals update" && sqlRepository.FileRevisionPairs.Any(frp => frp.Principal == s.Delta.RevisionPair && (frp.Flags == null || (frp.Flags & RevisionPairFlags.EnumAnomalies) == 0)));
            var miRenames = sqlRepository.Symptoms.OfType<IncompatibleMatchingSymptom>().Count(s => s.Pattern == "renames" && sqlRepository.FileRevisionPairs.Any(frp => frp.Principal == s.Delta.RevisionPair && (frp.Flags == null || (frp.Flags & RevisionPairFlags.EnumAnomalies) == 0)));
            var miOperators = sqlRepository.Symptoms.OfType<IncompatibleMatchingSymptom>().Count(s => s.Pattern == "different operators" && sqlRepository.FileRevisionPairs.Any(frp => frp.Principal == s.Delta.RevisionPair && (frp.Flags == null || (frp.Flags & RevisionPairFlags.EnumAnomalies) == 0)));
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

        /// <summary>
        /// Summarizes the spuriosity by element types.
        /// </summary>
        /// <param name="sqlRepository">the SQL database repository in which to analyze the file versions.</param>
        /// <param name="cancel">Action to execute cancellation logic.</param>
        /// <param name="approach"></param>
        /// <param name="skipThese">local criterion for determining elements that should be ignored.</param>
        public virtual void SummarizeSpuriosity(GitRepository sqlRepository, Action cancel, ChangeDetectionApproaches approach, Func<FileRevisionPair, bool> skipThese)
        {
            this.Analyze(sqlRepository, "spuriosity summary",
              f => f.Principal.Deltas.Any(d => d.Approach == approach &&
                                               d.Matching != null &&
                                               d.Differencing != null &&
                                               d.Report == null && d.Symptoms.OfType<SpuriositySymptom>().Any()),
                delegate (FileRevisionPair pair, CancellationToken token)
                {
                    if (skipThese?.Invoke(pair) ?? false) return;

                    var delta = sqlRepository.Deltas.Single(d => d.RevisionPair.Id == pair.Principal.Id && d.Approach == approach);
                    sqlRepository.Symptoms.OfType<SpuriositySymptom>().Where(s => s.Delta.Id == delta.Id).Load();
                    var spuriosity = delta.Symptoms.OfType<SpuriositySymptom>().First();
                    var transformationsInfo = XTransformationsInfo.Read(spuriosity.TransformationsInfo, Encoding.Unicode);
                    var syntaxTypes = new Dictionary<string, TransformationSummary>(300);

                    try
                    {
                        foreach (var ti in transformationsInfo.Transformations.Where(t => t.Version == "original" && t.Type != null))
                        {
                            TransformationSummary summary;
                            if (syntaxTypes.ContainsKey(ti.Type))
                                summary = syntaxTypes[ti.Type];
                            else
                            {
                                summary = new TransformationSummary
                                {
                                    Type = ti.Type,
                                    Self = new Transformations(),
                                    Children = new Transformations(),
                                    Descendants = new Transformations(),
                                };
                                syntaxTypes[ti.Type] = summary;
                            }

                            summary.Self.Insertions += ti.Self?.Insertions ?? 0;
                            summary.Self.Deletions += ti.Self?.Deletions ?? 0;
                            summary.Self.Updates += ti.Self?.Updates ?? 0;
                            summary.Self.FromMoves += ti.Self?.FromMoves ?? 0;
                            summary.Self.ToMoves += ti.Self?.ToMoves ?? 0;
                            summary.Self.Aligns += ti.Self?.Aligns ?? 0;

                            summary.Children.Insertions += ti.Children?.Insertions ?? 0;
                            summary.Children.Deletions += ti.Children?.Deletions ?? 0;
                            summary.Children.Updates += ti.Children?.Updates ?? 0;
                            summary.Children.FromMoves += ti.Children?.FromMoves ?? 0;
                            summary.Children.ToMoves += ti.Children?.ToMoves ?? 0;
                            summary.Children.Aligns += ti.Children?.Aligns ?? 0;

                            summary.Descendants.Insertions += ti.Descendants?.Insertions ?? 0;
                            summary.Descendants.Deletions += ti.Descendants?.Deletions ?? 0;
                            summary.Descendants.Updates += ti.Descendants?.Updates ?? 0;
                            summary.Descendants.FromMoves += ti.Descendants?.FromMoves ?? 0;
                            summary.Descendants.ToMoves += ti.Descendants?.ToMoves ?? 0;
                            summary.Descendants.Aligns += ti.Descendants?.Aligns ?? 0;

                            summary.Total += 1;

                            int inChanges = 0, outChanges = 0;
                            inChanges += ti.Children?.Insertions ?? 0;
                            inChanges += ti.Descendants?.Insertions ?? 0;
                            inChanges += ti.Children?.ToMoves ?? 0;
                            inChanges += ti.Descendants?.ToMoves ?? 0;
                            inChanges += ti.Children?.Updates ?? 0;
                            inChanges += ti.Descendants?.Updates ?? 0;
                            outChanges += ti.Children?.Deletions ?? 0;
                            outChanges += ti.Descendants?.Deletions ?? 0;
                            outChanges += ti.Children?.FromMoves ?? 0;
                            outChanges += ti.Descendants?.FromMoves ?? 0;

                            var spuriosityIndex = inChanges == 0 || outChanges == 0
                                ? 0d
                                : Math.Min(inChanges, outChanges) * 1d / Math.Max(inChanges, outChanges);

                            summary.Spuriosity += spuriosityIndex;
                            // Save the column for summary of spuriosity...
                        }

                        foreach (var t in syntaxTypes.Values)
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

                        var annotations = new XTransformationsSummary()
                        {
                           Transformations  = syntaxTypes.Values.ToArray()
                        };
                        spuriosity.TransformationSummary = annotations.WriteXmlColumn();
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
            cancel, false, new string[] { "Principal.FromFileVersion.Content", "Principal.FileVersion.Content" });
        }

        /// <summary>
        /// Finds some spurious element types according to relative thresholds of spuriosity.
        /// </summary>
        /// <param name="sqlRepository">the SQL database repository in which to analyze the file versions.</param>
        /// <param name="cancel">Action to execute cancellation logic.</param>
        /// <param name="approach"></param>
        /// <param name="skipThese">local criterion for determining elements that should be ignored.</param>
        public virtual void FindSpuriousElements(GitRepository sqlRepository, Action cancel, ChangeDetectionApproaches approach, Func<FileRevisionPair, bool> skipThese)
        {
            this.Analyze(sqlRepository, "spuriosity summary",
              f => f.Principal.Deltas.Any(d => d.Approach == approach &&
                                               d.Matching != null &&
                                               d.Differencing != null &&
                                               d.Report == null && d.Symptoms.OfType<SpuriositySymptom>().Any()),
                delegate (FileRevisionPair pair, CancellationToken token)
                {
                    if (skipThese?.Invoke(pair) ?? false) return;

                    var delta = sqlRepository.Deltas.Single(d => d.RevisionPair.Id == pair.Principal.Id && d.Approach == approach);
                    sqlRepository.Symptoms.OfType<SpuriositySymptom>().Where(s => s.Delta.Id == delta.Id).Load();
                    var spuriosity = delta.Symptoms.OfType<SpuriositySymptom>().First();
                    var transformationsInfo = XTransformationsInfo.Read(spuriosity.TransformationsInfo, Encoding.Unicode);
                    var syntaxTypes = new Dictionary<string, TransformationSummary>(300);

                    //var original = SyntaxFactory.ParseCompilationUnit(pair.Principal.FromFileVersion.Content.SourceCode).SyntaxTree.GetRoot();
                    //var modified = SyntaxFactory.ParseCompilationUnit(pair.Principal.FileVersion.Content.SourceCode).SyntaxTree.GetRoot();

                    //var preprocessedOriginal = cleaner != null ? cleaner.Clean(original) : original;
                    //var preprocessedModified = cleaner != null ? cleaner.Clean(modified) : modified;
                    //System.IO.File.WriteAllText(originalFilePath, preprocessedOriginal.ToFullString(), Encoding.Default);
                    //System.IO.File.WriteAllText(modifiedFilePath, preprocessedModified.ToFullString(), Encoding.Default);

                    var originalTree = ElementTree.Read(delta.OriginalTree, Encoding.Unicode);
                    try
                    {
                        foreach (var ti in transformationsInfo.Transformations.Where(t => t.Version == "original" && 
                                                                                          t.Type != null &&
                                                                                          _relativeThresholds.Any(s => s.Key == t.Type)))
                        {
                            TransformationSummary summary;
                            if (syntaxTypes.ContainsKey(ti.Type))
                                summary = syntaxTypes[ti.Type];
                            else
                            {
                                summary = new TransformationSummary
                                {
                                    Type = ti.Type,
                                    Self = new Transformations(),
                                    Children = new Transformations(),
                                    Descendants = new Transformations(),
                                };
                                syntaxTypes[ti.Type] = summary;
                            }

                            summary.Self.Insertions += ti.Self?.Insertions ?? 0;
                            summary.Self.Deletions += ti.Self?.Deletions ?? 0;
                            summary.Self.Updates += ti.Self?.Updates ?? 0;
                            summary.Self.FromMoves += ti.Self?.FromMoves ?? 0;
                            summary.Self.ToMoves += ti.Self?.ToMoves ?? 0;
                            summary.Self.Aligns += ti.Self?.Aligns ?? 0;

                            summary.Children.Insertions += ti.Children?.Insertions ?? 0;
                            summary.Children.Deletions += ti.Children?.Deletions ?? 0;
                            summary.Children.Updates += ti.Children?.Updates ?? 0;
                            summary.Children.FromMoves += ti.Children?.FromMoves ?? 0;
                            summary.Children.ToMoves += ti.Children?.ToMoves ?? 0;
                            summary.Children.Aligns += ti.Children?.Aligns ?? 0;

                            summary.Descendants.Insertions += ti.Descendants?.Insertions ?? 0;
                            summary.Descendants.Deletions += ti.Descendants?.Deletions ?? 0;
                            summary.Descendants.Updates += ti.Descendants?.Updates ?? 0;
                            summary.Descendants.FromMoves += ti.Descendants?.FromMoves ?? 0;
                            summary.Descendants.ToMoves += ti.Descendants?.ToMoves ?? 0;
                            summary.Descendants.Aligns += ti.Descendants?.Aligns ?? 0;

                            summary.Total += 1;

                            int inChanges = 0, outChanges = 0;
                            inChanges += ti.Children?.Insertions ?? 0;
                            inChanges += ti.Descendants?.Insertions ?? 0;
                            inChanges += ti.Children?.ToMoves ?? 0;
                            inChanges += ti.Descendants?.ToMoves ?? 0;
                            inChanges += ti.Children?.Updates ?? 0;
                            inChanges += ti.Descendants?.Updates ?? 0;
                            outChanges += ti.Children?.Deletions ?? 0;
                            outChanges += ti.Descendants?.Deletions ?? 0;
                            outChanges += ti.Children?.FromMoves ?? 0;
                            outChanges += ti.Descendants?.FromMoves ?? 0;

                            var spuriosityIndex = inChanges == 0 || outChanges == 0
                                ? 0d
                                : Math.Min(inChanges, outChanges) * 1d / Math.Max(inChanges, outChanges);

                            var relativeThreshold = _relativeThresholds.Single(s => s.Key == ti.Type);
                            if (spuriosityIndex > relativeThreshold.Value)
                            {
                                var originalElement = originalTree.PostOrder(n => n.Children).First(n => n.Root.Id == ti.Id);
                                delta.Symptoms.Add(new SpuriousElementSymptom
                                {
                                    Id = Guid.NewGuid(),
                                    Pattern = $">{relativeThreshold.Value.ToString(CultureInfo.InvariantCulture)}",
                                    Original = new ElementContext
                                    {
                                        Element = new ElementDescription
                                        {
                                            Id = originalElement.Root.Id,
                                            Type = relativeThreshold.Key,
                                            Hint = ""
                                        },
                                        ScopeHint = this.GetPath(originalElement.Ancestors().Where(ancestor => ancestor.Root.Label == "block"))
                                    },
                                    Modified = new ElementContext
                                    {
                                        Element = new ElementDescription { Id = "-1", Type = "", Hint = "" },
                                        ScopeHint = ""
                                    }
                                });
                            }
                            // Save the column for summary of spuriosity...
                        }

                        //foreach (var t in syntaxTypes.Values)
                        //{
                        //    if (t.Self.Insertions == 0 && t.Self.Deletions == 0 && t.Self.Updates == 0 &&
                        //       t.Self.FromMoves == 0 && t.Self.ToMoves == 0 && t.Self.Aligns == 0)
                        //        t.Self = null;

                        //    if (t.Children.Insertions == 0 && t.Children.Deletions == 0 && t.Children.Updates == 0 &&
                        //       t.Children.FromMoves == 0 && t.Children.ToMoves == 0 && t.Children.Aligns == 0)
                        //        t.Children = null;

                        //    if (t.Descendants.Insertions == 0 && t.Descendants.Deletions == 0 && t.Descendants.Updates == 0 &&
                        //       t.Descendants.FromMoves == 0 && t.Descendants.ToMoves == 0 && t.Descendants.Aligns == 0)
                        //        t.Descendants = null;
                        //}

                        //var annotations = new XTransformationsSummary()
                        //{
                        //    Transformations = syntaxTypes.Values.ToArray()
                        //};
                        //spuriosity.TransformationSummary = annotations.WriteXmlColumn();
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
            cancel, false, new string[] { "Principal.FromFileVersion.Content", "Principal.FileVersion.Content" });
        }

        /// <summary>
        /// Computes all the element types that have been summarized in terms of spuriosity.
        /// </summary>
        /// <param name="sqlRepository">the SQL database repository in which to analyze the file versions.</param>
        /// <param name="cancel">Action to execute cancellation logic.</param>
        /// <param name="approach"></param>
        /// <param name="skipThese">local criterion for determining elements that should be ignored.</param>
        /// <param name="syntaxTypes"></param>
        public virtual void ReportTypesOfSpuriositySummary(GitRepository sqlRepository, Action cancel, ChangeDetectionApproaches approach, Func<FileRevisionPair, bool> skipThese, HashSet<string> syntaxTypes)
        {
            this.Analyze(sqlRepository, "universe of element types in spuriosity summary",
              f => f.Principal.Deltas.Any(d => d.Approach == approach &&
                                               d.Matching != null &&
                                               d.Differencing != null &&
                                               d.Report == null && d.Symptoms.OfType<SpuriositySymptom>().Any()),
                delegate (FileRevisionPair pair, CancellationToken token)
                {
                    if (skipThese?.Invoke(pair) ?? false) return;

                    var delta = sqlRepository.Deltas.Single(d => d.RevisionPair.Id == pair.Principal.Id && d.Approach == approach);
                    sqlRepository.Symptoms.OfType<SpuriositySymptom>().Where(s => s.Delta.Id == delta.Id).Load();
                    var spuriosity = delta.Symptoms.OfType<SpuriositySymptom>().First();
                    var transformationsInfo = XTransformationsInfo.Read(spuriosity.TransformationsInfo, Encoding.Unicode);

                    try
                    {
                        foreach (var ti in transformationsInfo.Transformations.Where(t => t.Version == "original" && t.Type != null))
                        {
                            if (!syntaxTypes.Contains(ti.Type))
                            {
                                syntaxTypes.Add(ti.Type);
                                this.Report.AppendLine(ti.Type);
                            }
                        }
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
            cancel, false, new string[] { "Principal" });
        }

        /// <summary>
        /// Computes all the spuriosity summaries existing in the corpus organized by file revision pairs (rows) and element types (columns).
        /// </summary>
        /// <param name="sqlRepository">the SQL database repository in which to analyze the file versions.</param>
        /// <param name="cancel">Action to execute cancellation logic.</param>
        /// <param name="approach"></param>
        /// <param name="skipThese">local criterion for determining elements that should be ignored.</param>
        /// <param name="syntaxTypes"></param>
        public virtual void ReportSpuriositySummariesPerElementTypes(GitRepository sqlRepository, Action cancel, ChangeDetectionApproaches approach, Func<FileRevisionPair, bool> skipThese, IList<string> syntaxTypes, bool namesRow)
        {
            StringBuilder line = null;
            if (namesRow)
            {
                line = new StringBuilder(syntaxTypes.Count * 2 + 2);
                line.Append($"Project;Frp");
                foreach (var syntaxType in syntaxTypes)
                {
                    line.Append($";Tt-{syntaxType};Sp-{syntaxType}");
                }
                this.Report.AppendLine(line.ToString());
            }

            this.Analyze(sqlRepository, "spuriosity summary in the corpus per element types",
              f => f.Principal.Deltas.Any(d => d.Approach == approach &&
                                               d.Matching != null &&
                                               d.Differencing != null &&
                                               d.Report == null && d.Symptoms.OfType<SpuriositySymptom>().Any()),
                delegate (FileRevisionPair pair, CancellationToken token)
                {
                    if (skipThese?.Invoke(pair) ?? false) return;

                    var delta = sqlRepository.Deltas.Single(d => d.RevisionPair.Id == pair.Principal.Id && d.Approach == approach);
                    sqlRepository.Symptoms.OfType<SpuriositySymptom>().Where(s => s.Delta.Id == delta.Id).Load();
                    var spuriosity = delta.Symptoms.OfType<SpuriositySymptom>().First();
                    var transformationsInfo = XTransformationsSummary.Read(spuriosity.TransformationSummary, Encoding.Unicode);

                    line = new StringBuilder(syntaxTypes.Count * 2 + 2);
                    line.Append($"{sqlRepository.Name};{pair.Id}");
                    foreach (var syntaxType in syntaxTypes)
                    {
                        var summary = transformationsInfo.Transformations.SingleOrDefault(t => t.Type == syntaxType);
                        line.Append($";{summary?.Total ?? 0};{summary?.Spuriosity ?? 0}");
                    }
                    this.Report.AppendLine(line.ToString());
                },
            cancel, false, new string[] { "Principal" });
        }

        /// <summary>
        /// Summarizes the spuriosity by element types.
        /// </summary>
        /// <param name="sqlRepository">the SQL database repository in which to analyze the file versions.</param>
        /// <param name="approach"></param>
        public virtual void SummarizeSpuriousElements(GitRepository sqlRepository, ChangeDetectionApproaches approach, bool namesRow)
        {
            var elementTypes = this._relativeThresholds.OrderBy(r => r.Key).ToArray();
            if (namesRow)
                this.Report.AppendLine(elementTypes.Aggregate("Project", (s, e) => $"{s};{e.Key}"));

            StringBuilder line = new StringBuilder();
            line.Append(sqlRepository.Name);
            foreach (var keyValuePair in elementTypes)
            {
                var ghostChanges = sqlRepository.Symptoms.OfType<SpuriousElementSymptom>()
                    .Count(g => g.Original.Element.Type == keyValuePair.Key);
                var ghostChangesInFiles = sqlRepository.FileRevisionPairs
                    .Count(f => f.Principal.Deltas.Any(d => d.Approach == approach &&
                                                            d.Symptoms.OfType<GhostSymptom>()
                                                                .Any(g => g.Original.Element.Type == keyValuePair.Key)));
                line.Append($";{ghostChanges};{ghostChangesInFiles}");
            }

            this.Report.AppendLine(line.ToString());
        }

        /// <summary>
        /// Summarizes the ghost changes (by misrepresented comments) by element types.
        /// </summary>
        /// <param name="sqlRepository">the SQL database repository in which to analyze the file versions.</param>
        /// <param name="approach"></param>
        public virtual void SummarizeGhostConsequencesOfMisrepresentedComments(GitRepository sqlRepository, ChangeDetectionApproaches approach, bool namesRow)
        {
            if (namesRow)
                this.Report.AppendLine("Project;Gt;GtInFrp;Gi;GiInFrp;Gd;GdInFrp;Gu;GuInFrp;Gm;GmInFrp;" +
                     //"GtUnit;GtInFrpUnit;GiUnit;GiUnitInFrp;GdUnit;GdUnitInFrp;GuUnit;GuUnitInFrp;GmUnit;GmUnitInFrp;" +
                     //"GtNamespace;GtInFrpNamespace;GiNamespace;GiNamespaceInFrp;GdNamespace;GdNamespaceInFrp;GuNamespace;GuNamespaceInFrp;GmNamespace;GmNamespaceInFrp;" +
                     "GtInterface;GtInFrpInterface;GiInterface;GiInterfaceInFrp;GdInterface;GdInterfaceInFrp;GuInterface;GuInterfaceInFrp;GmInterface;GmInterfaceInFrp;" +
                     "GtClass;GtInFrpClass;GiClass;GiClassInFrp;GdClass;GdClassInFrp;GuClass;GuClassInFrp;GmClass;GmClassInFrp;" +
                     //"GtStruct;GtInFrpStruct;GiStruct;GiStructInFrp;GdStruct;GdStructInFrp;GuStruct;GuStructInFrp;GmStruct;GmStructInFrp;" +
                     "GtEnum;GtInFrpEnum;GiEnum;GiEnumInFrp;GdEnum;GdEnumInFrp;GuEnum;GuEnumInFrp;GmEnum;GmEnumInFrp;" +
                     "GtFunction;GtInFrpFunction;GiFunction;GiFunctionInFrp;GdFunction;GdFunctionInFrp;GuFunction;GuFunctionInFrp;GmFunction;GmFunctionInFrp;" +
                     "GtConstructor;GtInFrpConstructor;GiConstructor;GiConstructorInFrp;GdConstructor;GdConstructorInFrp;GuConstructor;GuConstructorInFrp;GmConstructor;GmConstructorInFrp;" +
                     "GtDestructor;GtInFrpDestructor;GiDestructor;GiDestructorInFrp;GdDestructor;GdDestructorInFrp;GuDestructor;GuDestructorInFrp;GmDestructor;GmDestructorInFrp;" +
                     "GtProperty;GtInFrpProperty;GiProperty;GiPropertyInFrp;GdProperty;GdPropertyInFrp;GuProperty;GuPropertyInFrp;GmProperty;GmPropertyInFrp");

            var ghostChanges = sqlRepository.Symptoms.OfType<GhostSymptom>()
                .Count(g => g.Modified.Element.Id != "-1");
            var ghostChangesInFiles = sqlRepository.FileRevisionPairs
                .Count(f => f.Principal.Deltas.Any(d => d.Approach == approach && 
                                                        d.Symptoms.OfType<GhostSymptom>().Any(g => g.Modified.Element.Id != "-1")));

            var insertGhostChanges = sqlRepository.Symptoms.OfType<GhostSymptom>()
                .Count(g => g.Modified.Element.Id != "-1" &&
                            g.Pattern == "insert - uncommented code vs. commented code");
            var insertGhostChangesInFiles = sqlRepository.FileRevisionPairs
                .Count(f => f.Principal.Deltas.Any(d => d.Approach == approach && 
                                                        d.Symptoms.OfType<GhostSymptom>()
                                                        .Any(g => g.Modified.Element.Id != "-1" && 
                                                                  g.Pattern == "insert - uncommented code vs. commented code")));

            var deleteGhostChanges = sqlRepository.Symptoms.OfType<GhostSymptom>()
                .Count(g => g.Modified.Element.Id != "-1" &&
                            g.Pattern == "delete - uncommented code vs. commented code");
            var deleteGhostChangesInFiles = sqlRepository.FileRevisionPairs
                .Count(f => f.Principal.Deltas.Any(d => d.Approach == approach &&
                                                        d.Symptoms.OfType<GhostSymptom>()
                                                        .Any(g => g.Modified.Element.Id != "-1" &&
                                                                  g.Pattern == "delete - uncommented code vs. commented code")));

            var updateGhostChanges = sqlRepository.Symptoms.OfType<GhostSymptom>()
                .Count(g => g.Modified.Element.Id != "-1" && 
                            g.Pattern == "update - uncommented code vs. commented code");
            var updateGhostChangesInFiles = sqlRepository.FileRevisionPairs
                .Count(f => f.Principal.Deltas.Any(d => d.Approach == approach &&
                                                        d.Symptoms.OfType<GhostSymptom>()
                                                        .Any(g => g.Modified.Element.Id != "-1" &&
                                                                  g.Pattern == "update - uncommented code vs. commented code")));

            var moveGhostChanges = sqlRepository.Symptoms.OfType<GhostSymptom>()
                .Count(g => g.Modified.Element.Id != "-1" &&
                            g.Pattern == "move - uncommented code vs. commented code");
            var moveGhostChangesInFiles = sqlRepository.FileRevisionPairs
                .Count(f => f.Principal.Deltas.Any(d => d.Approach == approach &&
                                                        d.Symptoms.OfType<GhostSymptom>()
                                                        .Any(g => g.Modified.Element.Id != "-1" &&
                                                                  g.Pattern == "move - uncommented code vs. commented code")));

            //// Unit
            //int unitGhostChangesInFiles, unitInsertGhostChanges, unitInsertGhostChangesInFiles, unitDeleteGhostChanges,
            //    unitDeleteGhostChangesInFiles, unitUpdateGhostChanges, unitUpdateGhostChangesInFiles, unitMoveGhostChanges,
            //    unitMoveGhostChangesInFiles;
            //var unitGhostChanges = this.ElementTypeGhostChanges(sqlRepository, approach, "unit",
            //    out unitGhostChangesInFiles, out unitInsertGhostChanges, out unitInsertGhostChangesInFiles,
            //    out unitDeleteGhostChanges, out unitDeleteGhostChangesInFiles,
            //    out unitUpdateGhostChanges, out unitUpdateGhostChangesInFiles,
            //    out unitMoveGhostChanges, out unitMoveGhostChangesInFiles);

            //// Namespace
            //int namespaceGhostChangesInFiles, namespaceInsertGhostChanges, namespaceInsertGhostChangesInFiles, namespaceDeleteGhostChanges,
            //    namespaceDeleteGhostChangesInFiles, namespaceUpdateGhostChanges, namespaceUpdateGhostChangesInFiles, namespaceMoveGhostChanges,
            //    namespaceMoveGhostChangesInFiles;
            //var namespaceGhostChanges = this.ElementTypeGhostChanges(sqlRepository, approach, "namespace",
            //    out namespaceGhostChangesInFiles, out namespaceInsertGhostChanges, out namespaceInsertGhostChangesInFiles,
            //    out namespaceDeleteGhostChanges, out namespaceDeleteGhostChangesInFiles,
            //    out namespaceUpdateGhostChanges, out namespaceUpdateGhostChangesInFiles,
            //    out namespaceMoveGhostChanges, out namespaceMoveGhostChangesInFiles);

            // Interface
            int interfaceGhostChangesInFiles, interfaceInsertGhostChanges, interfaceInsertGhostChangesInFiles, interfaceDeleteGhostChanges,
                interfaceDeleteGhostChangesInFiles, interfaceUpdateGhostChanges, interfaceUpdateGhostChangesInFiles, interfaceMoveGhostChanges,
                interfaceMoveGhostChangesInFiles;
            var interfaceGhostChanges = this.ElementTypeGhostChanges(sqlRepository, approach, "interface",
                out interfaceGhostChangesInFiles, out interfaceInsertGhostChanges, out interfaceInsertGhostChangesInFiles,
                out interfaceDeleteGhostChanges, out interfaceDeleteGhostChangesInFiles,
                out interfaceUpdateGhostChanges, out interfaceUpdateGhostChangesInFiles,
                out interfaceMoveGhostChanges, out interfaceMoveGhostChangesInFiles);

            // Class
            int classGhostChangesInFiles, classInsertGhostChanges, classInsertGhostChangesInFiles, classDeleteGhostChanges,
                classDeleteGhostChangesInFiles, classUpdateGhostChanges, classUpdateGhostChangesInFiles, classMoveGhostChanges,
                classMoveGhostChangesInFiles;
            var classGhostChanges = this.ElementTypeGhostChanges(sqlRepository, approach, "class",
                out classGhostChangesInFiles, out classInsertGhostChanges, out classInsertGhostChangesInFiles,
                out classDeleteGhostChanges, out classDeleteGhostChangesInFiles,
                out classUpdateGhostChanges, out classUpdateGhostChangesInFiles,
                out classMoveGhostChanges, out classMoveGhostChangesInFiles);

            //// Struct
            //int structGhostChangesInFiles, structInsertGhostChanges, structInsertGhostChangesInFiles, structDeleteGhostChanges,
            //    structDeleteGhostChangesInFiles, structUpdateGhostChanges, structUpdateGhostChangesInFiles, structMoveGhostChanges,
            //    structMoveGhostChangesInFiles;
            //var structGhostChanges = this.ElementTypeGhostChanges(sqlRepository, approach, "struct",
            //    out structGhostChangesInFiles, out structInsertGhostChanges, out structInsertGhostChangesInFiles,
            //    out structDeleteGhostChanges, out structDeleteGhostChangesInFiles,
            //    out structUpdateGhostChanges, out structUpdateGhostChangesInFiles,
            //    out structMoveGhostChanges, out structMoveGhostChangesInFiles);

            // Enum
            int enumGhostChangesInFiles, enumInsertGhostChanges, enumInsertGhostChangesInFiles, enumDeleteGhostChanges,
                enumDeleteGhostChangesInFiles, enumUpdateGhostChanges, enumUpdateGhostChangesInFiles, enumMoveGhostChanges,
                enumMoveGhostChangesInFiles;
            var enumGhostChanges = this.ElementTypeGhostChanges(sqlRepository, approach, "enum",
                out enumGhostChangesInFiles, out enumInsertGhostChanges, out enumInsertGhostChangesInFiles,
                out enumDeleteGhostChanges, out enumDeleteGhostChangesInFiles,
                out enumUpdateGhostChanges, out enumUpdateGhostChangesInFiles,
                out enumMoveGhostChanges, out enumMoveGhostChangesInFiles);

            // Function
            int functionGhostChangesInFiles, functionInsertGhostChanges, functionInsertGhostChangesInFiles, functionDeleteGhostChanges,
                functionDeleteGhostChangesInFiles, functionUpdateGhostChanges, functionUpdateGhostChangesInFiles, functionMoveGhostChanges,
                functionMoveGhostChangesInFiles;
            var functionGhostChanges = this.ElementTypeGhostChanges(sqlRepository, approach, "function",
                out functionGhostChangesInFiles, out functionInsertGhostChanges, out functionInsertGhostChangesInFiles,
                out functionDeleteGhostChanges, out functionDeleteGhostChangesInFiles,
                out functionUpdateGhostChanges, out functionUpdateGhostChangesInFiles,
                out functionMoveGhostChanges, out functionMoveGhostChangesInFiles);

            // Constructor
            int constructorGhostChangesInFiles, constructorInsertGhostChanges, constructorInsertGhostChangesInFiles, constructorDeleteGhostChanges,
                constructorDeleteGhostChangesInFiles, constructorUpdateGhostChanges, constructorUpdateGhostChangesInFiles, constructorMoveGhostChanges,
                constructorMoveGhostChangesInFiles;
            var constructorGhostChanges = this.ElementTypeGhostChanges(sqlRepository, approach, "constructor",
                out constructorGhostChangesInFiles, out constructorInsertGhostChanges, out constructorInsertGhostChangesInFiles,
                out constructorDeleteGhostChanges, out constructorDeleteGhostChangesInFiles,
                out constructorUpdateGhostChanges, out constructorUpdateGhostChangesInFiles,
                out constructorMoveGhostChanges, out constructorMoveGhostChangesInFiles);

            // Destructor
            int destructorGhostChangesInFiles, destructorInsertGhostChanges, destructorInsertGhostChangesInFiles, destructorDeleteGhostChanges,
                destructorDeleteGhostChangesInFiles, destructorUpdateGhostChanges, destructorUpdateGhostChangesInFiles, destructorMoveGhostChanges,
                destructorMoveGhostChangesInFiles;
            var destructorGhostChanges = this.ElementTypeGhostChanges(sqlRepository, approach, "destructor",
                out destructorGhostChangesInFiles, out destructorInsertGhostChanges, out destructorInsertGhostChangesInFiles,
                out destructorDeleteGhostChanges, out destructorDeleteGhostChangesInFiles,
                out destructorUpdateGhostChanges, out destructorUpdateGhostChangesInFiles,
                out destructorMoveGhostChanges, out destructorMoveGhostChangesInFiles);

            // Property
            int propertyGhostChangesInFiles, propertyInsertGhostChanges, propertyInsertGhostChangesInFiles, propertyDeleteGhostChanges,
                propertyDeleteGhostChangesInFiles, propertyUpdateGhostChanges, propertyUpdateGhostChangesInFiles, propertyMoveGhostChanges,
                propertyMoveGhostChangesInFiles;
            var propertyGhostChanges = this.ElementTypeGhostChanges(sqlRepository, approach, "property",
                out propertyGhostChangesInFiles, out propertyInsertGhostChanges, out propertyInsertGhostChangesInFiles,
                out propertyDeleteGhostChanges, out propertyDeleteGhostChangesInFiles,
                out propertyUpdateGhostChanges, out propertyUpdateGhostChangesInFiles,
                out propertyMoveGhostChanges, out propertyMoveGhostChangesInFiles);

            //var mnNamespaces = sqlRepository.Symptoms.OfType<MissedElementSymptom>().Count(s => s.Original.Element.Type == "namespace" && s.Modified.Element.Type == "namespace");
            this.Report.AppendLine($"{sqlRepository.Name};" +
                                   $"{ghostChanges};" +
                                   $"{ghostChangesInFiles};" +
                                   $"{insertGhostChanges};" +
                                   $"{insertGhostChangesInFiles};" +
                                   $"{deleteGhostChanges};" +
                                   $"{deleteGhostChangesInFiles};" +
                                   $"{updateGhostChanges};" +
                                   $"{updateGhostChangesInFiles};" +
                                   $"{moveGhostChanges};" +
                                   $"{moveGhostChangesInFiles};" +
                                   //$"{unitGhostChanges};" +
                                   //$"{unitGhostChangesInFiles};" +
                                   //$"{unitInsertGhostChanges};" +
                                   //$"{unitInsertGhostChangesInFiles};" +
                                   //$"{unitDeleteGhostChanges};" +
                                   //$"{unitDeleteGhostChangesInFiles};" +
                                   //$"{unitUpdateGhostChanges};" +
                                   //$"{unitUpdateGhostChangesInFiles};" +
                                   //$"{unitMoveGhostChanges};" +
                                   //$"{unitMoveGhostChangesInFiles};" +
                                   //$"{namespaceGhostChanges};" +
                                   //$"{namespaceGhostChangesInFiles};" +
                                   //$"{namespaceInsertGhostChanges};" +
                                   //$"{namespaceInsertGhostChangesInFiles};" +
                                   //$"{namespaceDeleteGhostChanges};" +
                                   //$"{namespaceDeleteGhostChangesInFiles};" +
                                   //$"{namespaceUpdateGhostChanges};" +
                                   //$"{namespaceUpdateGhostChangesInFiles};" +
                                   //$"{namespaceMoveGhostChanges};" +
                                   //$"{namespaceMoveGhostChangesInFiles};" +
                                   $"{interfaceGhostChanges};" +
                                   $"{interfaceGhostChangesInFiles};" +
                                   $"{interfaceInsertGhostChanges};" +
                                   $"{interfaceInsertGhostChangesInFiles};" +
                                   $"{interfaceDeleteGhostChanges};" +
                                   $"{interfaceDeleteGhostChangesInFiles};" +
                                   $"{interfaceUpdateGhostChanges};" +
                                   $"{interfaceUpdateGhostChangesInFiles};" +
                                   $"{interfaceMoveGhostChanges};" +
                                   $"{interfaceMoveGhostChangesInFiles};" +
                                   $"{classGhostChanges};" +
                                   $"{classGhostChangesInFiles};" +
                                   $"{classInsertGhostChanges};" +
                                   $"{classInsertGhostChangesInFiles};" +
                                   $"{classDeleteGhostChanges};" +
                                   $"{classDeleteGhostChangesInFiles};" +
                                   $"{classUpdateGhostChanges};" +
                                   $"{classUpdateGhostChangesInFiles};" +
                                   $"{classMoveGhostChanges};" +
                                   $"{classMoveGhostChangesInFiles};" +
                                   //$"{structGhostChanges};" +
                                   //$"{structGhostChangesInFiles};" +
                                   //$"{structInsertGhostChanges};" +
                                   //$"{structInsertGhostChangesInFiles};" +
                                   //$"{structDeleteGhostChanges};" +
                                   //$"{structDeleteGhostChangesInFiles};" +
                                   //$"{structUpdateGhostChanges};" +
                                   //$"{structUpdateGhostChangesInFiles};" +
                                   //$"{structMoveGhostChanges};" +
                                   //$"{structMoveGhostChangesInFiles};" +
                                   $"{enumGhostChanges};" +
                                   $"{enumGhostChangesInFiles};" +
                                   $"{enumInsertGhostChanges};" +
                                   $"{enumInsertGhostChangesInFiles};" +
                                   $"{enumDeleteGhostChanges};" +
                                   $"{enumDeleteGhostChangesInFiles};" +
                                   $"{enumUpdateGhostChanges};" +
                                   $"{enumUpdateGhostChangesInFiles};" +
                                   $"{enumMoveGhostChanges};" +
                                   $"{enumMoveGhostChangesInFiles};" +
                                   $"{functionGhostChanges};" +
                                   $"{functionGhostChangesInFiles};" +
                                   $"{functionInsertGhostChanges};" +
                                   $"{functionInsertGhostChangesInFiles};" +
                                   $"{functionDeleteGhostChanges};" +
                                   $"{functionDeleteGhostChangesInFiles};" +
                                   $"{functionUpdateGhostChanges};" +
                                   $"{functionUpdateGhostChangesInFiles};" +
                                   $"{functionMoveGhostChanges};" +
                                   $"{functionMoveGhostChangesInFiles};" +
                                   $"{constructorGhostChanges};" +
                                   $"{constructorGhostChangesInFiles};" +
                                   $"{constructorInsertGhostChanges};" +
                                   $"{constructorInsertGhostChangesInFiles};" +
                                   $"{constructorDeleteGhostChanges};" +
                                   $"{constructorDeleteGhostChangesInFiles};" +
                                   $"{constructorUpdateGhostChanges};" +
                                   $"{constructorUpdateGhostChangesInFiles};" +
                                   $"{constructorMoveGhostChanges};" +
                                   $"{constructorMoveGhostChangesInFiles};" +
                                   $"{destructorGhostChanges};" +
                                   $"{destructorGhostChangesInFiles};" +
                                   $"{destructorInsertGhostChanges};" +
                                   $"{destructorInsertGhostChangesInFiles};" +
                                   $"{destructorDeleteGhostChanges};" +
                                   $"{destructorDeleteGhostChangesInFiles};" +
                                   $"{destructorUpdateGhostChanges};" +
                                   $"{destructorUpdateGhostChangesInFiles};" +
                                   $"{destructorMoveGhostChanges};" +
                                   $"{destructorMoveGhostChangesInFiles};" +
                                   $"{propertyGhostChanges};" +
                                   $"{propertyGhostChangesInFiles};" +
                                   $"{propertyInsertGhostChanges};" +
                                   $"{propertyInsertGhostChangesInFiles};" +
                                   $"{propertyDeleteGhostChanges};" +
                                   $"{propertyDeleteGhostChangesInFiles};" +
                                   $"{propertyUpdateGhostChanges};" +
                                   $"{propertyUpdateGhostChangesInFiles};" +
                                   $"{propertyMoveGhostChanges};" +
                                   $"{propertyMoveGhostChangesInFiles}");
        }

        private int ElementTypeGhostChanges(GitRepository sqlRepository, ChangeDetectionApproaches approach, string elementType,
            out int unitGhostChangesInFiles, out int unitInsertGhostChanges, out int unitInsertGhostChangesInFiles,
            out int unitDeleteGhostChanges, out int unitDeleteGhostChangesInFiles, out int unitUpdateGhostChanges,
            out int unitUpdateGhostChangesInFiles, out int unitMoveGhostChanges, out int unitMoveGhostChangesInFiles)
        {
            var unitGhostChanges = sqlRepository.Symptoms.OfType<GhostSymptom>()
                .Count(g => g.Modified.Element.Id != "-1" &&
                            g.Original.Element.Type == elementType);
            unitGhostChangesInFiles = sqlRepository.FileRevisionPairs
                .Count(f => f.Principal.Deltas.Any(d => d.Approach == approach &&
                                                        d.Symptoms.OfType<GhostSymptom>()
                                                            .Any(g => g.Modified.Element.Id != "-1" &&
                                                                      g.Original.Element.Type == elementType)));

            unitInsertGhostChanges = sqlRepository.Symptoms.OfType<GhostSymptom>()
                .Count(g => g.Modified.Element.Id != "-1" &&
                            g.Pattern == "insert - uncommented code vs. commented code" &&
                            g.Original.Element.Type == elementType);
            unitInsertGhostChangesInFiles = sqlRepository.FileRevisionPairs
                .Count(f => f.Principal.Deltas.Any(d => d.Approach == approach &&
                                                        d.Symptoms.OfType<GhostSymptom>()
                                                            .Any(g => g.Modified.Element.Id != "-1" &&
                                                                      g.Pattern ==
                                                                      "insert - uncommented code vs. commented code" &&
                                                                      g.Original.Element.Type == elementType)));

            unitDeleteGhostChanges = sqlRepository.Symptoms.OfType<GhostSymptom>()
                .Count(g => g.Modified.Element.Id != "-1" &&
                            g.Pattern == "delete - uncommented code vs. commented code" &&
                            g.Original.Element.Type == elementType);
            unitDeleteGhostChangesInFiles = sqlRepository.FileRevisionPairs
                .Count(f => f.Principal.Deltas.Any(d => d.Approach == approach &&
                                                        d.Symptoms.OfType<GhostSymptom>()
                                                            .Any(g => g.Modified.Element.Id != "-1" &&
                                                                      g.Pattern ==
                                                                      "delete - uncommented code vs. commented code" &&
                                                                      g.Original.Element.Type == elementType)));

            unitUpdateGhostChanges = sqlRepository.Symptoms.OfType<GhostSymptom>()
                .Count(g => g.Modified.Element.Id != "-1" &&
                            g.Pattern == "update - uncommented code vs. commented code" &&
                            g.Original.Element.Type == elementType);
            unitUpdateGhostChangesInFiles = sqlRepository.FileRevisionPairs
                .Count(f => f.Principal.Deltas.Any(d => d.Approach == approach &&
                                                        d.Symptoms.OfType<GhostSymptom>()
                                                            .Any(g => g.Modified.Element.Id != "-1" &&
                                                                      g.Pattern ==
                                                                      "update - uncommented code vs. commented code" &&
                                                                      g.Original.Element.Type == elementType)));

            unitMoveGhostChanges = sqlRepository.Symptoms.OfType<GhostSymptom>()
                .Count(g => g.Modified.Element.Id != "-1" &&
                            g.Pattern == "move - uncommented code vs. commented code" &&
                            g.Original.Element.Type == elementType);
            unitMoveGhostChangesInFiles = sqlRepository.FileRevisionPairs
                .Count(f => f.Principal.Deltas.Any(d => d.Approach == approach &&
                                                        d.Symptoms.OfType<GhostSymptom>()
                                                            .Any(g => g.Modified.Element.Id != "-1" &&
                                                                      g.Pattern == "move - uncommented code vs. commented code" &&
                                                                      g.Original.Element.Type == elementType)));
            return unitGhostChanges;
        }

        /// <summary>
        /// Analyzes the similarity in according with a given similarity metric, such as Levenshtein.
        /// </summary>
        /// <param name="sqlRepository">the SQL database repository in which to analyze the file versions.</param>
        /// <param name="cancel">Action to execute cancellation logic.</param>
        /// <param name="withoutComments"></param>
        /// <param name="skipThese">local criterion for determining elements that should be ignored.</param>
        public virtual void SaveGhostConsequencesOfMisrepresentedComments(GitRepository sqlRepository, Action cancel, ChangeDetectionApproaches withoutComments, ChangeDetectionApproaches withComments, Func<FileRevisionPair, bool> skipThese)
        {
            Func<ElementTree, bool> elementsOfInterest = (ElementTree t) =>
                t.Root.Label == "unit" ||
                t.Root.Label == "namespace" ||
                t.Root.Label == "interface" ||
                t.Root.Label == "class" ||
                t.Root.Label == "struct" ||
                t.Root.Label == "enum" ||
                t.Root.Label == "function" ||
                //.Root/t.Label == "function_decl" ||
                t.Root.Label == "constructor" ||
                t.Root.Label == "destructor" ||
                t.Root.Label == "property";

            this.Analyze(sqlRepository, "ghost changes by misrepresented comments",
              f => f.Principal.Deltas.Any(d => d.Approach == withoutComments &&
                                               d.Matching != null &&
                                               d.Differencing != null &&
                                               d.Report == null) &&
                   f.Principal.Deltas.Any(d => d.Approach == withComments &&
                                               d.Matching != null &&
                                               d.Differencing != null &&
                                               d.Report == null),
                delegate (FileRevisionPair pair, CancellationToken token)
                {
                    if (skipThese?.Invoke(pair) ?? false) return;

                    var deltaWithoutComments = sqlRepository.Deltas.Single(d => d.RevisionPair.Id == pair.Principal.Id && d.Approach == withoutComments);
                    var detectionResultWithoutComments = (DetectionResult)deltaWithoutComments.DetectionResult;
                    var originalTreeWithoutComments = ElementTree.Read(deltaWithoutComments.OriginalTree, Encoding.Unicode);
                    var modifiedTreeWithoutComments = ElementTree.Read(deltaWithoutComments.ModifiedTree, Encoding.Unicode);

                    var deltaWithComments = sqlRepository.Deltas.Single(d => d.RevisionPair.Id == pair.Principal.Id && d.Approach == withComments);
                    var detectionResultWithComments = (DetectionResult)deltaWithComments.DetectionResult;
                    var originalTreeWithComments = ElementTree.Read(deltaWithComments.OriginalTree, Encoding.Unicode);
                    var modifiedTreeWithComments = ElementTree.Read(deltaWithComments.ModifiedTree, Encoding.Unicode);

                    try
                    {
                        var ghostSymptoms = FindDifferenceSetOfChanges<InsertOperationDescriptor>(detectionResultWithoutComments,
                            modifiedTreeWithoutComments, elementsOfInterest, detectionResultWithComments,
                            modifiedTreeWithComments, "insert");
                        foreach (var ghostSymptom in ghostSymptoms)
                        {
                            deltaWithComments.Symptoms.Add(ghostSymptom);
                        }

                        ghostSymptoms = FindDifferenceSetOfChanges<DeleteOperationDescriptor>(detectionResultWithoutComments,
                            originalTreeWithoutComments, elementsOfInterest, detectionResultWithComments,
                            originalTreeWithComments, "delete");
                        foreach (var ghostSymptom in ghostSymptoms)
                        {
                            deltaWithComments.Symptoms.Add(ghostSymptom);
                        }

                        ghostSymptoms = FindDifferenceSetOfChanges<UpdateOperationDescriptor>(detectionResultWithoutComments,
                            originalTreeWithoutComments, elementsOfInterest, detectionResultWithComments,
                            originalTreeWithComments, "update");
                        foreach (var ghostSymptom in ghostSymptoms)
                        {
                            deltaWithComments.Symptoms.Add(ghostSymptom);
                        }

                        ghostSymptoms = FindDifferenceSetOfChanges<MoveOperationDescriptor>(detectionResultWithoutComments,
                            originalTreeWithoutComments, elementsOfInterest, detectionResultWithComments,
                            originalTreeWithComments, "move");
                        foreach (var ghostSymptom in ghostSymptoms)
                        {
                            deltaWithComments.Symptoms.Add(ghostSymptom);
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

        private IEnumerable<GhostSymptom> FindDifferenceSetOfChanges<TOperation>(DetectionResult detectionResultWithoutComments, ElementTree treeWithoutComments, Func<ElementTree, bool> elementsOfInterest, DetectionResult detectionResultWithComments, ElementTree treeWithComments, string operationName) where TOperation : OperationDescriptor
        {
            var candidateMovesWithoutComments = detectionResultWithoutComments.Actions.OfType<TOperation>()
                .Where(m => m.Element.Label == "name")
                .Select(t => treeWithoutComments.PostOrder(n => n.Children).First(n => n.Root.Id == t.Element.Id))
                .Select(t => new CandidateName {Tree = t, Context = this.NameContexts.SingleOrDefault(nm => nm.Criterion(t))})
                .Where(t => t.Context != null && elementsOfInterest(ContainerScope(t.Tree)))
                .ToList();
            var candidateMovesWithComments = detectionResultWithComments.Actions.OfType<TOperation>()
                .Where(m => m.Element.Label == "name")
                .Select(t => treeWithComments.PostOrder(n => n.Children).First(n => n.Root.Id == t.Element.Id))
                .Select(t => new CandidateName {Tree = t, Context = this.NameContexts.SingleOrDefault(nm => nm.Criterion(t))})
                .Where(t => t.Context != null && elementsOfInterest(ContainerScope(t.Tree)))
                .ToList();
            var allNames = candidateMovesWithoutComments.Select(c => c.Tree.Root.Value)
                .Union(candidateMovesWithComments.Select(c => c.Tree.Root.Value))
                .Distinct()
                .ToList();

            foreach (var name in allNames)
            {
                var namedMovesWithoutComments = candidateMovesWithoutComments.Where(c => c.Tree.Root.Value == name).ToList();
                var namedMovesWithComments = candidateMovesWithComments.Where(c => c.Tree.Root.Value == name).ToList();
                var allLabels = namedMovesWithoutComments.Select(c => c.Context.NameOf(c.Tree))
                    .Union(namedMovesWithComments.Select(c => c.Context.NameOf(c.Tree)))
                    .Distinct()
                    .ToList();

                foreach (var label in allLabels)
                {
                    var movesWithoutComments = namedMovesWithoutComments.Where(c => c.Context.NameOf(c.Tree) == label);
                    var movesWithComments = namedMovesWithComments.Where(c => c.Context.NameOf(c.Tree) == label);
                    if (movesWithoutComments.Count() != movesWithComments.Count())
                    {
                        var conceptualMoves = (from m in movesWithoutComments.DefaultIfEmpty(null)
                            from mc in movesWithComments.DefaultIfEmpty(null)
                            select new {m, mc}).ToList();

                        foreach (var conceptualMove in conceptualMoves)
                        {
                            yield return new GhostSymptom
                            {
                                Id = Guid.NewGuid(),
                                Pattern = $"{operationName} - uncommented code vs. commented code",
                                Original = new ElementContext
                                {
                                    Element = new ElementDescription
                                    {
                                        Id = conceptualMove.m == null ? "-1" : conceptualMove.m.Tree.Root.Id,
                                        Type = label,
                                        Hint = conceptualMove.m == null ? "" : name
                                    },
                                    ScopeHint =
                                        conceptualMove.m == null
                                            ? ""
                                            : this.GetPath(conceptualMove.m.Context.OuterScopes(conceptualMove.m.Tree))
                                },
                                Modified = new ElementContext
                                {
                                    Element = new ElementDescription
                                    {
                                        Id = conceptualMove.mc == null ? "-1" : conceptualMove.mc.Tree.Root.Id,
                                        Type = label,
                                        Hint = conceptualMove.mc == null ? "" : name
                                    },
                                    ScopeHint =
                                        conceptualMove.mc == null
                                            ? ""
                                            : this.GetPath(conceptualMove.mc.Context.OuterScopes(conceptualMove.mc.Tree))
                                }
                            };
                        }
                    }
                }
            }
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
              f => (f.Flags == null || (f.Flags & RevisionPairFlags.EnumAnomalies) == 0) && f.Principal.Deltas.Any(d => d.Approach == approach &&
                                               d.Matching != null &&
                                               d.Differencing != null &&
                                               d.Report == null &&
                                               d.Symptoms.OfType<MissedNameSymptom>().Any(s => s.Original.Element.Type == "actual argument" && s.Modified.Element.Type == "actual argument")),
                delegate (FileRevisionPair pair, CancellationToken token)
                {
                    //if (skipThese?.Invoke(pair) ?? false) return;
                    //if ((pair.Flags & RevisionPairFlags.EnumAnomalies) != 0)
                    //    return;

                    var delta = sqlRepository.Deltas.Single(d => d.RevisionPair.Id == pair.Principal.Id && d.Approach == approach);
                    var symptomIds = sqlRepository.Symptoms.OfType<MissedNameSymptom>()
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
                        sqlRepository.Symptoms.OfType<MissedNameSymptom>().Where(s => s.Id == symptomId).Load();
                        var symptom = delta.Symptoms.OfType<MissedNameSymptom>().Single(s => s.Id == symptomId);

                        if (symptom.Original.Element.Hint == null || symptom.Modified.Element.Hint == null ||
                            symptom.Original.Element.Hint.Length == 1 ||
                            symptom.Modified.Element.Hint.Length == 1)
                            continue;

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
                                                /*d.Symptoms.OfType<IncompatibleMatchingSymptom>().Any(s => s.Pattern == "this instance expression")*/
                                                /*d.Symptoms.OfType<IncompatibleMatchingSymptom>().Any(s => s.Pattern == "base instance expression")*/
                                                /*d.Symptoms.OfType<IncompatibleMatchingSymptom>().Any(s => s.Pattern == "null literal mismatch")*/
                                                /*d.Symptoms.OfType<IncompatibleMatchingSymptom>().Any(s => s.Pattern == "builtin type updates to non-builtin type")*/
                                                /*d.Symptoms.OfType<IncompatibleMatchingSymptom>().Any(s => s.Pattern == "literals update")*/
                                                /*d.Symptoms.OfType<IncompatibleMatchingSymptom>().Any(s => s.Pattern == "renames")*/
                                                /*d.Symptoms.OfType<IncompatibleMatchingSymptom>().Any(s => s.Pattern == "different operators")*/
                                                d.Symptoms.OfType<IncompatibleMatchingSymptom>().Any(s => s.Pattern == "true literal mismatch")
                                                /*d.Symptoms.OfType<IncompatibleMatchingSymptom>().Any(s => s.Pattern == "false literal mismatch")*/),
                delegate (FileRevisionPair pair, CancellationToken token)
                {
                    //if (skipThese?.Invoke(pair) ?? false) return;

                    var delta = sqlRepository.Deltas.Single(d => d.RevisionPair.Id == pair.Principal.Id && d.Approach == approach);
                    var symptomIds = sqlRepository.Symptoms.OfType<IncompatibleMatchingSymptom>()
                        //.Where(s => s.Delta.Id == delta.Id && s.Pattern == "this instance expression")
                        //.Where(s => s.Delta.Id == delta.Id && s.Pattern == "base instance expression")
                        //.Where(s => s.Delta.Id == delta.Id && s.Pattern == "null literal mismatch")
                        //.Where(s => s.Delta.Id == delta.Id && s.Pattern == "builtin type updates to non-builtin type")
                        //.Where(s => s.Delta.Id == delta.Id && s.Pattern == "literals update")
                        //.Where(s => s.Delta.Id == delta.Id && s.Pattern == "renames")
                        //.Where(s => s.Delta.Id == delta.Id && s.Pattern == "different operators")
                        .Where(s => s.Delta.Id == delta.Id && s.Pattern == "true literal mismatch")
                        //.Where(s => s.Delta.Id == delta.Id && s.Pattern == "false literal mismatch")
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
                            Subject = $"Spurious update ({symptom.Pattern}) - {symptom.Original.Element.Type} " +
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
                            case "base instance expression":
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
                        int oClasses = original.DescendantNodesAndSelf().OfType<BaseTypeDeclarationSyntax>().Count();
                        int mClasses = modified.DescendantNodesAndSelf().OfType<BaseTypeDeclarationSyntax>().Count();
                        pair.Reviews.Add(review);
                    }
                },
            null, true, "Principal.FileVersion.Content", "Principal.FromFileVersion.Content");
        }

        /// <summary>
        /// Analyzes the similarity in according with a given similarity metric, such as Levenshtein.
        /// </summary>
        /// <param name="sqlRepository">the SQL database repository in which to analyze the file versions.</param>
        /// <param name="cancel">Action to execute cancellation logic.</param>
        /// <param name="approach"></param>
        /// <param name="skipThese">local criterion for determining elements that should be ignored.</param>
        public virtual void AnalyzingSpuriosity(GitRepository sqlRepository, Action cancel, ChangeDetectionApproaches approach, Func<FileRevisionPair, bool> skipThese,
            SourceCodeCleaner cleaner, string originalFilePath, string modifiedFilePath)
        {
            this.Analyze(sqlRepository, "spuriosity analysis",
              f => f.Principal.Deltas.Any(d => d.Approach == approach &&
                                               d.Matching != null &&
                                               d.Differencing != null &&
                                               d.Report == null && d.Symptoms.OfType<SpuriositySymptom>().Any()),
                delegate (FileRevisionPair pair, CancellationToken token)
                {
                    if (skipThese?.Invoke(pair) ?? false) return;

                    var delta = sqlRepository.Deltas.Single(d => d.RevisionPair.Id == pair.Principal.Id && d.Approach == approach);
                    var original = SyntaxFactory.ParseCompilationUnit(pair.Principal.FromFileVersion.Content.SourceCode).SyntaxTree.GetRoot();
                    var modified = SyntaxFactory.ParseCompilationUnit(pair.Principal.FileVersion.Content.SourceCode).SyntaxTree.GetRoot();

                    //var cleaner = new SourceCodeCleaner();
                    var preprocessedOriginal = cleaner != null ? cleaner.Clean(original) : original;
                    var preprocessedModified = cleaner != null ? cleaner.Clean(modified) : modified;
                    System.IO.File.WriteAllText(originalFilePath, preprocessedOriginal.ToFullString(), Encoding.Default);
                    System.IO.File.WriteAllText(modifiedFilePath, preprocessedModified.ToFullString(), Encoding.Default);

                    try
                    {
                        sqlRepository.Symptoms.OfType<SpuriositySymptom>().Where(s => s.Delta.Id == delta.Id).Load();
                        var spuriosity = delta.Symptoms.OfType<SpuriositySymptom>().Single();
                        var transformationsInfo = XTransformationsInfo.Read(spuriosity.TransformationsInfo, Encoding.Unicode);

                        foreach (var ti in transformationsInfo.Transformations)
                        {
                            if (/*(ti.Self == null || ti.Self.Insertions == 0) && */
                                (ti.FromATotalOfDescendants > 0 || ti.FromATotalOfChildren > 0))
                            {
                                int inChanges = 0, outChanges = 0;
                                //inChanges += ti.Children?.Insertions ?? 0;
                                //inChanges += ti.Descendants?.Insertions ?? 0;
                                inChanges += ti.Children?.ToMoves ?? 0;
                                inChanges += ti.Descendants?.ToMoves ?? 0;
                                inChanges += ti.Children?.Updates ?? 0;
                                inChanges += ti.Descendants?.Updates ?? 0;

                                //outChanges += ti.Children?.Deletions ?? 0;
                                //outChanges += ti.Descendants?.Deletions ?? 0;
                                outChanges += ti.Children?.FromMoves ?? 0;
                                outChanges += ti.Descendants?.FromMoves ?? 0;

                                var max = Math.Max(inChanges, outChanges);
                                var min = Math.Min(inChanges, outChanges);

                                int treeSize = ti.FromATotalOfDescendants + ti.FromATotalOfChildren;
                                int inRatio = inChanges / treeSize;
                                int outRatio = outChanges / treeSize;

                                if (outChanges != 0 && inChanges != 0 && (treeSize > 4) && (inChanges + outChanges)/2d*treeSize > 0.6)
                                    ;
                            }
                        }
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
            cancel, false, new string[] { "Principal.FromFileVersion.Content", "Principal.FileVersion.Content" });
        }

        public virtual void CalculateRelativeThresholds(IEnumerable<GitRepository> sqlRepositories, IEnumerable<string> elementTypes, IEnumerable<KeyValuePair<string, double>> medianTails)
        {
            var medianTailsTh = medianTails.ToArray();
            int i = 0;
            var total = elementTypes.Count();
            foreach (var elementType in elementTypes)
            {
                var corpus = new List<KeyValuePair<string, double[]>>(106);
                foreach (var sqlRepository in sqlRepositories)
                {
                    var path = $"E:/Phd/Analysis/UniquePairs/Median/{sqlRepository.Name}PercentilesForSp-{elementType}.csv";
                    if (System.IO.File.Exists(path))
                    {
                        var lines = System.IO.File.ReadAllLines(path);
                        corpus.Add(new KeyValuePair<string, double[]>(sqlRepository.Name, 
                            lines.Skip(2)
                                .Select(s =>
                                {
                                    var values = s.Split(new[] {";"}, StringSplitOptions.RemoveEmptyEntries);
                                    return double.Parse(values[1], CultureInfo.InvariantCulture);
                                }).ToArray()));
                    }
                    else
                    {
                        corpus.Add(new KeyValuePair<string, double[]>(sqlRepository.Name, Enumerable.Repeat(0, 100).Select(v => v * 1d).ToArray()));
                    }
                }

                var rt = new RelativeThreshold
                {
                    Corpus = corpus,
                    DoPercentageOfProjectIsLessThanOrEqualToThreshold = delegate (string id, double percent, double threshold)
                    {
                        var project = corpus.Single(s => s.Key == id);
                        var targetPercentile = (int)(project.Value.Count() * percent / 100);
                        return project.Value[targetPercentile - 1] <= threshold;
                    },
                    Tail = id => corpus.Single(s => s.Key == id).Value[90],
                    MedianTail = 8
                };

                double winnerPercent;
                var medianTail = medianTailsTh.Single(t => t.Key == $"\"Sp-{elementType}\"").Value;
                var winnerThreshold = rt.ComputeThreshold(Enumerable.Range(0, 100).Select(v => v * 1d/100).ToArray(), 
                    Enumerable.Range(1, 100).Select(v => v * 1d).ToArray(), 
                    medianTail, 
                    out winnerPercent);
                this.Report.AppendLine($"{elementType};" +
                                       $"{winnerThreshold};" +
                                       $"{winnerPercent};" +
                                       $"{winnerPercent}% should have {elementType}'s spuriosity <= {winnerThreshold}");
                Console.WriteLine($"{elementType} - {++i} of {total}:    {winnerPercent}% should have {elementType}'s spuriosity <= {winnerThreshold}");

            }
        }
    }
}
