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
    /// Finds redundant changes on a given delta w.r.t. a matching set.
    /// </summary>
    public class MatchingSetRedundancyFinder : RedundancyFinder
    {
        /// <summary>
        /// Stores the value of the <see cref="MatchingSet"/> property.
        /// </summary>
        private IEnumerable<RevisionDescriptor> _matchingSet;

        /// <summary>
        /// Gets or sets the matching set discovered by a comparing (e.g., candidate) solution.
        /// </summary>
        public virtual IEnumerable<RevisionDescriptor> MatchingSet
        {
            get { return this._matchingSet == null ? throw new ArgumentNullException("Must specify the discovered matching set") : this._matchingSet; }
            set { this._matchingSet = value == null ? throw new ArgumentNullException("value") : value; }
        }

        /// <summary>
        /// Defines the logic of corrections by redundancy.
        /// </summary>
        /// <param name="pattern">redundancy pattern to look for.</param>
        /// <param name="delta">diagnosable delta</param>
        /// <returns>Pairs of redundant actions describing redundant changes.</returns>
        public override IEnumerable<(RedundancyPattern Pattern, ActionDescriptor Original, ActionDescriptor AndOriginal, ActionDescriptor Modified, ActionDescriptor AndModified)> Find(IEnumerable<ActionDescriptor> delta)
        {
            var deletions = delta.Where(a => a.Action == ActionKind.Delete).Cast<DeleteOperationDescriptor>().ToArray();
            var insertions = delta.Where(a => a.Action == ActionKind.Insert).Cast<InsertOperationDescriptor>().ToArray();
            var updates = delta.Where(a => a.Action == ActionKind.Update).Cast<UpdateOperationDescriptor>();
            var moves = delta.Where(a => a.Action == ActionKind.Move).Cast<MoveOperationDescriptor>();

            var symptomsOfDI = from d in deletions
                               from i in insertions
                               where this.MatchingSet.Any(match => match.Original.Id == d.Element.Id && match.Modified.Id == i.Element.Id)
                               select (Pattern: RedundancyPattern.DI, Original: d as ActionDescriptor, AndOriginal: null as ActionDescriptor, Modified: i as ActionDescriptor, AndModified: null as ActionDescriptor);

            var symptomsOfUI = from u in updates.Where(ua => !moves.Any(ma => ma.Element.Id == ua.Element.Id))
                               from i in insertions
                               where this.MatchingSet.Any(match => match.Original.Id == u.Element.Id && match.Modified.Id == i.Element.Id)
                               select (Pattern: RedundancyPattern.UI, Original: u as ActionDescriptor, AndOriginal: null as ActionDescriptor, Modified: i as ActionDescriptor, AndModified: null as ActionDescriptor);

            var symptomsOfUM_I = from u in updates.Where(ua => moves.Any(ma => ma.Element.Id == ua.Element.Id))
                                 from i in insertions
                                 where this.MatchingSet.Any(match => match.Original.Id == u.Element.Id && match.Modified.Id == i.Element.Id)
                                 select (Pattern: RedundancyPattern.UMI, Original: u as ActionDescriptor, AndOriginal: (moves.Single(ma => ma.Element.Id == u.Element.Id)) as ActionDescriptor, Modified: i as ActionDescriptor, AndModified: null as ActionDescriptor);

            var symptomsOfDU = from d in deletions
                               from u in updates.Where(ua => !moves.Any(ma => ma.Element.Id == ua.Element.Id))
                               where this.MatchingSet.Any(match => match.Original.Id == d.Element.Id && match.Modified.Id == u.Element.Id)
                               select (Pattern: RedundancyPattern.DU, Original: d as ActionDescriptor, AndOriginal: null as ActionDescriptor, Modified: u as ActionDescriptor, AndModified: null as ActionDescriptor);

            var symptomsOfD_UM = from d in deletions
                                 from u in updates.Where(ua => moves.Any(ma => ma.Element.Id == ua.Element.Id))
                                 where this.MatchingSet.Any(match => match.Original.Id == d.Element.Id && match.Modified.Id == u.Element.Id)
                                 select (Pattern: RedundancyPattern.DUM, Original: d as ActionDescriptor, AndOriginal: null as ActionDescriptor, Modified: u as ActionDescriptor, AndModified: (moves.Single(ma => ma.Element.Id == u.Element.Id)) as ActionDescriptor);

            var symptomsOfUU = from u1 in updates.Where(ua => !moves.Any(ma => ma.Element.Id == ua.Element.Id))
                               from u2 in updates.Where(ua => !moves.Any(ma => ma.Element.Id == ua.Element.Id))
                               where this.MatchingSet.Any(match => match.Original.Id == u1.Element.Id && match.Modified.Id == u2.Element.Id)
                               select (Pattern: RedundancyPattern.UU, Original: u1 as ActionDescriptor, AndOriginal: null as ActionDescriptor, Modified: u2 as ActionDescriptor, AndModified: null as ActionDescriptor);

            var symptomsOfUM_U = from u1 in updates.Where(ua => moves.Any(ma => ma.Element.Id == ua.Element.Id))
                                from u2 in updates.Where(ua => !moves.Any(ma => ma.Element.Id == ua.Element.Id))
                                where this.MatchingSet.Any(match => match.Original.Id == u1.Element.Id && match.Modified.Id == u2.Element.Id)
                                select (Pattern: RedundancyPattern.UMU, Original: u1 as ActionDescriptor, AndOriginal: (moves.Single(ma => ma.Element.Id == u1.Element.Id)) as ActionDescriptor, Modified: u2 as ActionDescriptor, AndModified: null as ActionDescriptor);

            var symptomsOfU_UM = from u1 in updates.Where(ua => !moves.Any(ma => ma.Element.Id == ua.Element.Id))
                                 from u2 in updates.Where(ua => moves.Any(ma => ma.Element.Id == ua.Element.Id))
                                 where this.MatchingSet.Any(match => match.Original.Id == u1.Element.Id && match.Modified.Id == u2.Element.Id)
                                 select (Pattern: RedundancyPattern.UUM, Original: u1 as ActionDescriptor, AndOriginal: null as ActionDescriptor, Modified: u2 as ActionDescriptor, AndModified: (moves.Single(ma => ma.Element.Id == u2.Element.Id)) as ActionDescriptor);

            var symptomsOfUM_UM = from u1 in updates.Where(ua => moves.Any(ma => ma.Element.Id == ua.Element.Id))
                                  from u2 in updates.Where(ua => moves.Any(ma => ma.Element.Id == ua.Element.Id))
                                  where this.MatchingSet.Any(match => match.Original.Id == u1.Element.Id && match.Modified.Id == u2.Element.Id)
                                  select (Pattern: RedundancyPattern.UMUM, Original: u1 as ActionDescriptor, 
                                          AndOriginal: (moves.Single(ma => ma.Element.Id == u1.Element.Id)) as ActionDescriptor, 
                                          Modified: u2 as ActionDescriptor, AndModified: (moves.Single(ma => ma.Element.Id == u2.Element.Id)) as ActionDescriptor);

            var symptomsOfDM = from d in deletions
                               from m in moves.Where(ma => !updates.Any(um => um.Element.Id == ma.Element.Id))
                               where this.MatchingSet.Any(match => match.Original.Id == d.Element.Id && match.Modified.Id == m.Element.Id)
                               select (Pattern: RedundancyPattern.DM, Original: d as ActionDescriptor, AndOriginal: null as ActionDescriptor, Modified: m as ActionDescriptor, AndModified: null as ActionDescriptor);

            var symptomsOfMI = from m in moves.Where(ma => !updates.Any(um => um.Element.Id == ma.Element.Id))
                               from i in insertions
                               where this.MatchingSet.Any(match => match.Original.Id == m.Element.Id && match.Modified.Id == i.Element.Id)
                               select (Pattern: RedundancyPattern.MI, Original: m as ActionDescriptor, AndOriginal: null as ActionDescriptor, Modified: i as ActionDescriptor, AndModified: null as ActionDescriptor);

            var symptomsOfMM = from m1 in moves.Where(ma => !updates.Any(um => um.Element.Id == ma.Element.Id))
                               from m2 in moves.Where(ma => !updates.Any(um => um.Element.Id == ma.Element.Id))
                               where this.MatchingSet.Any(match => match.Original.Id == m1.Element.Id && match.Modified.Id == m2.Element.Id)
                               select (Pattern: RedundancyPattern.MM, Original: m1 as ActionDescriptor, AndOriginal: null as ActionDescriptor, Modified: m2 as ActionDescriptor, AndModified: null as ActionDescriptor);

            var symptomsOfUM_M = from m1 in moves.Where(ma => updates.Any(um => um.Element.Id == ma.Element.Id))
                               from m2 in moves.Where(ma => !updates.Any(um => um.Element.Id == ma.Element.Id))
                               where this.MatchingSet.Any(match => match.Original.Id == m1.Element.Id && match.Modified.Id == m2.Element.Id)
                               select (Pattern: RedundancyPattern.UMM, Original: (updates.Single(ma => ma.Element.Id == m1.Element.Id)) as ActionDescriptor, 
                                       AndOriginal: m1 as ActionDescriptor, 
                                       Modified: m2 as ActionDescriptor, AndModified: null as ActionDescriptor);

            var symptomsOfM_UM = from m1 in moves.Where(ma => !updates.Any(um => um.Element.Id == ma.Element.Id))
                               from m2 in moves.Where(ma => updates.Any(um => um.Element.Id == ma.Element.Id))
                               where this.MatchingSet.Any(match => match.Original.Id == m1.Element.Id && match.Modified.Id == m2.Element.Id)
                               select (Pattern: RedundancyPattern.MUM, Original: m1 as ActionDescriptor, AndOriginal: null as ActionDescriptor, 
                               Modified: (updates.Single(ma => ma.Element.Id == m2.Element.Id)) as ActionDescriptor, AndModified: m2 as ActionDescriptor);

            var symptomsOfUM = from u in updates.Where(ua => !moves.Any(ma => ma.Element.Id == ua.Element.Id))
                               from m in moves.Where(ma => !updates.Any(um => um.Element.Id == ma.Element.Id))
                               where this.MatchingSet.Any(match => match.Original.Id == u.Element.Id && match.Modified.Id == m.Element.Id)
                               select (Pattern: RedundancyPattern.UM, Original: u as ActionDescriptor, AndOriginal: null as ActionDescriptor, Modified: m as ActionDescriptor, AndModified: null as ActionDescriptor);

            var symptomsOfMU = from m in moves.Where(ma => !updates.Any(um => um.Element.Id == ma.Element.Id))
                               from u in updates.Where(ua => !moves.Any(ma => ma.Element.Id == ua.Element.Id))
                               where this.MatchingSet.Any(match => match.Original.Id == m.Element.Id && match.Modified.Id == u.Element.Id)
                               select (Pattern: RedundancyPattern.MU, Original: m as ActionDescriptor, AndOriginal: null as ActionDescriptor, Modified: u as ActionDescriptor, AndModified: null as ActionDescriptor);

            return symptomsOfDI.Union(symptomsOfUI).Union(symptomsOfUM_I).Union(symptomsOfDU).Union(symptomsOfD_UM).Union(symptomsOfUU)
                .Union(symptomsOfUM_U).Union(symptomsOfU_UM).Union(symptomsOfUM_UM).Union(symptomsOfDM).Union(symptomsOfMI).Union(symptomsOfMM)
                .Union(symptomsOfUM_M).Union(symptomsOfM_UM).Union(symptomsOfUM).Union(symptomsOfMU);
        }
    }
}
