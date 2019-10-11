using Jawilliam.CDF.Labs.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Jawilliam.CDF.Labs
{
    /// <summary>
    /// Base logic for the imprecision diagnostic by comparing two solutions.
    /// </summary>
    /// <typeparam name="TSymptom">type of the recognized symptoms.</typeparam>
    public abstract class ImprecisionComparison<TSymptom> : BaseImprecisionComparison<TSymptom> where TSymptom : Symptom
    {
        /// <summary>
        /// Looks for symptoms of imprecision.
        /// </summary>
        /// <param name="leftDelta">left delta.</param> 
        /// <param name="rightDelta">right delta.</param>
        /// <param name="pair">file revision pair being analized.</param>
        /// <param name="token">mechanism for cancelling the analisys.</param>
        public abstract IEnumerable<TSymptom> Compare(Delta leftDelta, Delta rightDelta, FileRevisionPair pair, CancellationToken token);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="saveChanges"></param>
        /// <param name="pair"></param>
        /// <param name="leftDelta"></param>
        /// <param name="rightDelta"></param>
        /// <param name="token"></param>
        protected override void RecognizeCore(bool saveChanges, FileRevisionPair pair, Delta leftDelta, Delta rightDelta, CancellationToken token)
        {
            var symptoms = this.Compare(leftDelta, rightDelta, pair, token).ToList();
            foreach (var betweenSymptom in symptoms)
            {
                if (saveChanges)
                    leftDelta.Symptoms.Add(betweenSymptom);
            }
        }
    }
}
