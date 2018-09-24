using Jawilliam.CDF.Actions;
using Jawilliam.CDF.Approach;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jawilliam.CDF.Evaluation
{
    /// <summary>
    /// Finds symptoms of redundant changes.
    /// </summary>
    public abstract class RedundancyFinder
    {
        /// <summary>
        /// Stores the value of the <see cref="Delta"/> property.
        /// </summary>
        private DetectionResult _delta;

        /// <summary>
        /// Gets or sets the actions conforming the diagnosable delta.
        /// </summary>
        public virtual DetectionResult Delta
        {
            get { return this._delta == null ? throw new ArgumentNullException("Must specify a diagnosable delta") : this._delta; }
            set { this._delta = value == null ? throw new ArgumentNullException("value") :  value; }
        }

        /// <summary>
        /// Defines the logic of corrections by redundancy.
        /// </summary>
        /// <param name="pattern">redundancy pattern to look for.</param>
        /// <param name="delta">diagnosable delta</param>
        /// <returns>Symptoms of redundant changes.</returns>
        public virtual IEnumerable<(RedundancyPattern Pattern, ElementDescriptor MissedOriginal, ElementDescriptor MissedModified, 
                                                               ElementDescriptor SpuriousOriginal, ElementDescriptor SpuriousModified,
                                                               ElementDescriptor AndSpuriousOriginal, ElementDescriptor AndSpuriousModified)> Find()
        {
            var deletions = this.Delta.Actions.Where(a => a.Action == ActionKind.Delete).Cast<DeleteOperationDescriptor>().ToArray();
            var insertions = this.Delta.Actions.Where(a => a.Action == ActionKind.Insert).Cast<InsertOperationDescriptor>().ToArray();
            var updates = this.Delta.Actions.Where(a => a.Action == ActionKind.Update).Cast<UpdateOperationDescriptor>().ToArray();
            var fullUpdates = updates.Select(a => new { Action = a, Match = this.Delta.Matches.Single(m => m.Original.Id == a.Element.Id) }).ToArray();
            var moves = this.Delta.Actions.Where(a => a.Action == ActionKind.Move).Cast<MoveOperationDescriptor>().ToArray();
            var fullMoves = moves.Select(a => new { Action = a, Match = this.Delta.Matches.Single(m => m.Original.Id == a.Element.Id) }).ToArray();

            var symptomsOfDI = from d in deletions
                               from i in insertions
                               where this.AreRedundant(RedundancyPattern.DI, d.Element.Id, i.Element.Id)
                               select (Pattern: RedundancyPattern.DI, MissedOriginal: d.Element, MissedModified: i.Element,
                                       SpuriousOriginal: null as ElementDescriptor, SpuriousModified: null as ElementDescriptor,
                                       AndSpuriousOriginal: null as ElementDescriptor, AndSpuriousModified: null as ElementDescriptor);

            var symptomsOfUI = from u in fullUpdates.Where(ua => !moves.Any(ma => ma.Element.Id == ua.Action.Element.Id))
                               from i in insertions
                               where this.AreRedundant(RedundancyPattern.UI, u.Action.Element.Id, i.Element.Id)
                               select (Pattern: RedundancyPattern.UI, MissedOriginal: u.Action.Element, MissedModified: i.Element,
                                       SpuriousOriginal: u.Action.Element, SpuriousModified: u.Match.Modified,
                                       AndSpuriousOriginal: null as ElementDescriptor, AndSpuriousModified: null as ElementDescriptor);

            var symptomsOfUM_I = from u in fullUpdates.Where(ua => moves.Any(ma => ma.Element.Id == ua.Action.Element.Id))
                                 from i in insertions
                                 where this.AreRedundant(RedundancyPattern.UMI, u.Action.Element.Id, i.Element.Id)
                                 select (Pattern: RedundancyPattern.UMI, MissedOriginal: u.Action.Element, MissedModified: i.Element,
                                         SpuriousOriginal: u.Action.Element, SpuriousModified: u.Match.Modified,
                                         AndSpuriousOriginal: null as ElementDescriptor, AndSpuriousModified: null as ElementDescriptor);

            var symptomsOfDU = from d in deletions
                               from u in fullUpdates.Where(ua => !moves.Any(ma => ma.Element.Id == ua.Action.Element.Id))
                               where this.AreRedundant(RedundancyPattern.DU, d.Element.Id, u.Match.Modified.Id)
                               select (Pattern: RedundancyPattern.DU, MissedOriginal: d.Element, MissedModified: u.Match.Modified,
                                       SpuriousOriginal: null as ElementDescriptor, SpuriousModified: null as ElementDescriptor,
                                       AndSpuriousOriginal: u.Action.Element, AndSpuriousModified: u.Match.Modified);

            var symptomsOfD_UM = from d in deletions
                                 from u in fullUpdates.Where(ua => moves.Any(ma => ma.Element.Id == ua.Action.Element.Id))
                                 where this.AreRedundant(RedundancyPattern.DUM, d.Element.Id, u.Match.Modified.Id)
                                 select (Pattern: RedundancyPattern.DUM, MissedOriginal: d.Element, MissedModified: u.Match.Modified,
                                         SpuriousOriginal: null as ElementDescriptor, SpuriousModified: null as ElementDescriptor,
                                         AndSpuriousOriginal: u.Action.Element, AndSpuriousModified: u.Match.Modified);

            var symptomsOfUU = from u1 in fullUpdates.Where(ua => !moves.Any(ma => ma.Element.Id == ua.Action.Element.Id))
                               from u2 in fullUpdates.Where(ua => ua != u1 && !moves.Any(ma => ma.Element.Id == ua.Action.Element.Id))
                               where this.AreRedundant(RedundancyPattern.UU, u1.Action.Element.Id, u2.Match.Modified.Id)
                               select (Pattern: RedundancyPattern.UU, MissedOriginal: u1.Action.Element, MissedModified: u2.Match.Modified,
                                       SpuriousOriginal: u1.Action.Element, SpuriousModified: u1.Match.Modified,
                                       AndSpuriousOriginal: u2.Action.Element, AndSpuriousModified: u2.Match.Modified);

            var symptomsOfUM_U = from u1 in fullUpdates.Where(ua => moves.Any(ma => ma.Element.Id == ua.Action.Element.Id))
                                 from u2 in fullUpdates.Where(ua => ua != u1 && !moves.Any(ma => ma.Element.Id == ua.Action.Element.Id))
                                 where this.AreRedundant(RedundancyPattern.UMU, u1.Action.Element.Id, u2.Match.Modified.Id)
                                 select (Pattern: RedundancyPattern.UMU, MissedOriginal: u1.Action.Element, MissedModified: u2.Match.Modified,
                                         SpuriousOriginal: u1.Action.Element, SpuriousModified: u1.Match.Modified,
                                         AndSpuriousOriginal: u2.Action.Element, AndSpuriousModified: u2.Match.Modified);

            var symptomsOfU_UM = from u1 in fullUpdates.Where(ua => !moves.Any(ma => ma.Element.Id == ua.Action.Element.Id))
                                 from u2 in fullUpdates.Where(ua => ua != u1 && moves.Any(ma => ma.Element.Id == ua.Action.Element.Id))
                                 where this.AreRedundant(RedundancyPattern.UUM, u1.Action.Element.Id, u2.Match.Modified.Id)
                                 select (Pattern: RedundancyPattern.UUM, MissedOriginal: u1.Action.Element, MissedModified: u2.Match.Modified,
                                         SpuriousOriginal: u1.Action.Element, SpuriousModified: u1.Match.Modified,
                                         AndSpuriousOriginal: u2.Action.Element, AndSpuriousModified: u2.Match.Modified);

            var symptomsOfUM_UM = from u1 in fullUpdates.Where(ua => moves.Any(ma => ma.Element.Id == ua.Action.Element.Id))
                                  from u2 in fullUpdates.Where(ua => ua != u1 && moves.Any(ma => ma.Element.Id == ua.Action.Element.Id))
                                  where this.AreRedundant(RedundancyPattern.UMUM, u1.Action.Element.Id, u2.Match.Modified.Id)
                                  select (Pattern: RedundancyPattern.UMUM, MissedOriginal: u1.Action.Element, MissedModified: u2.Match.Modified,
                                         SpuriousOriginal: u1.Action.Element, SpuriousModified: u1.Match.Modified,
                                         AndSpuriousOriginal: u2.Action.Element, AndSpuriousModified: u2.Match.Modified);

            var symptomsOfDM = from d in deletions
                               from m in fullMoves.Where(ma => !updates.Any(um => um.Element.Id == ma.Action.Element.Id))
                               where this.AreRedundant(RedundancyPattern.DM, d.Element.Id, m.Match.Modified.Id)
                               select (Pattern: RedundancyPattern.DM, MissedOriginal: d.Element, MissedModified: m.Match.Modified,
                                       SpuriousOriginal: null as ElementDescriptor, SpuriousModified: null as ElementDescriptor,
                                       AndSpuriousOriginal: m.Action.Element, AndSpuriousModified: m.Match.Modified);

            var symptomsOfMI = from m in fullMoves.Where(ma => !updates.Any(um => um.Element.Id == ma.Action.Element.Id))
                               from i in insertions
                               where this.AreRedundant(RedundancyPattern.MI, m.Action.Element.Id, i.Element.Id)
                               select (Pattern: RedundancyPattern.MI, MissedOriginal: m.Action.Element, MissedModified: i.Element,
                                       SpuriousOriginal: m.Action.Element, SpuriousModified: m.Match.Modified,
                                       AndSpuriousOriginal: null as ElementDescriptor, AndSpuriousModified: null as ElementDescriptor);

            var symptomsOfMM = from m1 in fullMoves.Where(ma => !updates.Any(um => um.Element.Id == ma.Action.Element.Id))
                               from m2 in fullMoves.Where(ma => ma != m1 && !updates.Any(um => um.Element.Id == ma.Action.Element.Id))
                               where this.AreRedundant(RedundancyPattern.MM, m1.Action.Element.Id, m2.Match.Modified.Id)
                               select (Pattern: RedundancyPattern.MM, MissedOriginal: m1.Action.Element, MissedModified: m2.Match.Modified,
                                       SpuriousOriginal: m1.Action.Element, SpuriousModified: m1.Match.Modified,
                                       AndSpuriousOriginal: m2.Action.Element, AndSpuriousModified: m2.Match.Modified);

            var symptomsOfUM_M = from m1 in fullMoves.Where(ma => updates.Any(um => um.Element.Id == ma.Action.Element.Id))
                                 from m2 in fullMoves.Where(ma => ma != m1 && !updates.Any(um => um.Element.Id == ma.Action.Element.Id))
                                 where this.AreRedundant(RedundancyPattern.UMM, m1.Action.Element.Id, m2.Match.Modified.Id)
                                 select (Pattern: RedundancyPattern.UMM, MissedOriginal: m1.Action.Element, MissedModified: m2.Match.Modified,
                                       SpuriousOriginal: m1.Action.Element, SpuriousModified: m1.Match.Modified,
                                       AndSpuriousOriginal: m2.Action.Element, AndSpuriousModified: m2.Match.Modified);

            var symptomsOfM_UM = from m1 in fullMoves.Where(ma => !updates.Any(um => um.Element.Id == ma.Action.Element.Id))
                                 from m2 in fullMoves.Where(ma => ma != m1 && updates.Any(um => um.Element.Id == ma.Action.Element.Id))
                                 where this.AreRedundant(RedundancyPattern.MUM, m1.Action.Element.Id, m2.Match.Modified.Id)
                                 select (Pattern: RedundancyPattern.MUM, MissedOriginal: m1.Action.Element, MissedModified: m2.Match.Modified,
                                       SpuriousOriginal: m1.Action.Element, SpuriousModified: m1.Match.Modified,
                                       AndSpuriousOriginal: m2.Action.Element, AndSpuriousModified: m2.Match.Modified);

            var symptomsOfUM = from u in fullUpdates.Where(ua => !moves.Any(ma => ma.Element.Id == ua.Action.Element.Id))
                               from m in fullMoves.Where(ma => !updates.Any(um => um.Element.Id == ma.Action.Element.Id))
                               where this.AreRedundant(RedundancyPattern.UM, u.Action.Element.Id, m.Match.Modified.Id)
                               select (Pattern: RedundancyPattern.UM, MissedOriginal: u.Action.Element, MissedModified: m.Match.Modified,
                                       SpuriousOriginal: u.Action.Element, SpuriousModified: u.Match.Modified,
                                       AndSpuriousOriginal: m.Action.Element, AndSpuriousModified: m.Match.Modified);

            var symptomsOfMU = from m in fullMoves.Where(ma => !updates.Any(um => um.Element.Id == ma.Action.Element.Id))
                               from u in fullUpdates.Where(ua => !moves.Any(ma => ma.Element.Id == ua.Action.Element.Id))
                               where this.AreRedundant(RedundancyPattern.MU, m.Action.Element.Id, u.Match.Modified.Id)
                               select (Pattern: RedundancyPattern.MU, MissedOriginal: m.Action.Element, MissedModified: u.Match.Modified,
                                       SpuriousOriginal: m.Action.Element, SpuriousModified: m.Match.Modified,
                                       AndSpuriousOriginal: u.Action.Element, AndSpuriousModified: u.Match.Modified);

            return symptomsOfDI.Union(symptomsOfUI).Union(symptomsOfUM_I).Union(symptomsOfDU).Union(symptomsOfD_UM).Union(symptomsOfUU)
                .Union(symptomsOfUM_U).Union(symptomsOfU_UM).Union(symptomsOfUM_UM).Union(symptomsOfDM).Union(symptomsOfMI).Union(symptomsOfMM)
                .Union(symptomsOfUM_M).Union(symptomsOfM_UM).Union(symptomsOfUM).Union(symptomsOfMU);
        }

        /// <summary>
        /// Informs whether two original and modified versions.
        /// </summary>
        /// <param name="pattern">redundancy pattern being looking for.</param>
        /// <param name="originalId">id of the original element.</param>
        /// <param name="modifiedId">id of the modified element.</param>
        /// <returns>true if the given versions are redundant, false otherwise.</returns>
        protected abstract bool AreRedundant(RedundancyPattern pattern, string originalId, string modifiedId);
    }
}
