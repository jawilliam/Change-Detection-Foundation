using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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

        public virtual void ClearConfusingNames(GitRepository sqlRepository)
        {
            var repositoryObjectIds = sqlRepository.Deltas
                    .Where(d => d.Approach == ChangeDetectionApproaches.NativeGumTree &&
                                d.Symptoms.OfType<NameCoexistenceSymptom>().Any())
                    .Select(fv => fv.Id).ToList();

            int counter = 0;
            foreach (var repositoryObjectId in repositoryObjectIds)
            {
                var delta = sqlRepository.Deltas.Include("Symptoms").Single(c => c.Id == repositoryObjectId);

                foreach (var symptom in delta.Symptoms.OfType<NameCoexistenceSymptom>().ToList())
                {
                    sqlRepository.Symptoms.Remove(symptom);
                }
                sqlRepository.Flush(true);
                Console.WriteLine($"{sqlRepository.Name}-{++counter} of {repositoryObjectIds.Count}");
            }
        }

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
    }
}
