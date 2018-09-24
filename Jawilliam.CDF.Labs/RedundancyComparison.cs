using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Jawilliam.CDF.Actions;
using Jawilliam.CDF.Approach;
using Jawilliam.CDF.Evaluation;
using Jawilliam.CDF.Labs.DBModel;

namespace Jawilliam.CDF.Labs
{
    /// <summary>
    /// Reports symptoms of imprecision by comparing redundant changes among two SCCD solutions.
    /// </summary>
    public class RedundancyComparison : ImprecisionComparison<RedundancySymptom>
    {
        /// <summary>
        /// Gets or sets the configuration for the comparison.
        /// </summary>
        public virtual ImprecisionComparisonCriterion Config { get; set; }

        /// <summary>
        /// Looks for symptoms of imprecision.
        /// </summary>
        /// <param name="skipThese">local criterion for determining elements that should be ignored.</param>
        /// <param name="saveChanges">Enables or disables the persistence of the changes.</param>
        public override void Recognize(Func<FileRevisionPair, bool> skipThese = null, bool saveChanges = true)
        {
            this.Recognize(this.Config, skipThese, saveChanges);
        }

        /// <summary>
        /// Looks for symptoms of imprecision.
        /// </summary>
        /// <param name="leftDelta">left delta.</param> 
        /// <param name="rightDelta">right delta.</param>
        /// <param name="pair">file revision pair being analized.</param>
        /// <param name="token">mechanism for cancelling the analisys.</param>
        public override IEnumerable<RedundancySymptom> Compare(Delta leftDelta, Delta rightDelta, FileRevisionPair pair, CancellationToken token)
        {
            var leftOriginalTree = this.Config.GetTree((leftDelta, pair, true));
            var leftModifiedTree = this.Config.GetTree((leftDelta, pair, false));
            var leftDetectionResult = (DetectionResult)leftDelta.DetectionResult;

            var rightOriginalTree = this.Config.GetTree((rightDelta, pair, true));
            var rightModifiedTree = this.Config.GetTree((rightDelta, pair, false));
            var rightDetectionResult = (DetectionResult)rightDelta.DetectionResult;

            RedundancyFinder finder = new MatchingSetRedundancyFinder { MatchingSet = rightDetectionResult.Matches, Delta = leftDetectionResult };
            (Evaluation.RedundancyPattern pattern, ElementDescriptor MissedOriginal, ElementDescriptor MissedModified,
             ElementDescriptor SpuriousOriginal, ElementDescriptor SpuriousModified,
             ElementDescriptor AndSpuriousOriginal, ElementDescriptor AndSpuriousModified)[] symptoms = finder.Find().ToArray();

            foreach (var symptom in symptoms)
            {
                yield return new RedundancySymptom
                {
                    Id = Guid.NewGuid(),
                    DeltaApproach = leftDelta.Approach,
                    CorrectorApproach = rightDelta.Approach,
                    IsTop = true,
                    Pattern = (DBModel.RedundancyPattern)symptom.pattern,
                    MissedOriginal = this.CreateElementDescriptor(symptom.MissedOriginal),
                    MissedModified = this.CreateElementDescriptor(symptom.MissedModified),
                    SpuriousOriginal = this.CreateElementDescriptor(symptom.SpuriousOriginal),
                    SpuriousModified = this.CreateElementDescriptor(symptom.SpuriousModified),
                    AndSpuriousOriginal = this.CreateElementDescriptor(symptom.AndSpuriousOriginal),
                    AndSpuriousModified = this.CreateElementDescriptor(symptom.AndSpuriousModified)
                };
            }

            if (this.Config.TwoWay)
            {
                finder = new MatchingSetRedundancyFinder { MatchingSet = leftDetectionResult.Matches, Delta = rightDetectionResult };
                symptoms = finder.Find().ToArray();

                foreach (var symptom in symptoms)
                {
                    yield return new RedundancySymptom
                    {
                        Id = Guid.NewGuid(),
                        DeltaApproach = rightDelta.Approach,
                        CorrectorApproach = leftDelta.Approach,
                        IsTop = true,                        
                        Pattern = (DBModel.RedundancyPattern)symptom.pattern,
                        MissedOriginal = this.CreateElementDescriptor(symptom.MissedOriginal),
                        MissedModified = this.CreateElementDescriptor(symptom.MissedModified),
                        SpuriousOriginal = this.CreateElementDescriptor(symptom.SpuriousOriginal),
                        SpuriousModified = this.CreateElementDescriptor(symptom.SpuriousModified),
                        AndSpuriousOriginal = this.CreateElementDescriptor(symptom.AndSpuriousOriginal),
                        AndSpuriousModified = this.CreateElementDescriptor(symptom.AndSpuriousModified)
                    };
                }
            }
        }

        private ElementDescription CreateElementDescriptor(ElementDescriptor version)
        {
            return new ElementDescription
            {
                Id = version?.Id ?? "-1",
                Type = version?.Label ?? "",
                Hint = version?.Value
            };
        }
        
        /// <summary>
        /// Gathers a referential summary and save it in <see cref="FileRevisionPairAnalyzer.Report"/>.
        /// </summary>
        public override void ReportSummary()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Iterates symptoms to be rated.
        /// </summary>
        public override void Rate()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns a configuration to check for reversible changes.
        /// </summary>
        public virtual void ConfigGumTreeVsReversedGumTree()
        {
            this.Config = new ImprecisionComparisonCriterion();
            base.ConfigGumTreeVsReversedGumTree(this.Config);
        }

        /// <summary>
        /// Returns a configuration to check for reversible changes.
        /// </summary>
        /// <param name="leftName"></param>
        /// <param name="leftApproach"></param>
        /// <param name="rightApproach"></param>
        /// <param name="rightName"></param>
        public virtual void ConfigLeftVsRight((ChangeDetectionApproaches Approach, string Name) left, (ChangeDetectionApproaches Approach, string Name) right)
        {
            this.Config = new ImprecisionComparisonCriterion
            {
                Left = left.Approach,
                LeftName = left.Name,
                Right = right.Approach,
                RightName = right.Name,
                TwoWay = true
            };
        }
    }
}