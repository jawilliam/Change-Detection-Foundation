using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jawilliam.CDF.Labs
{
    partial class GitRepository
    {
        /// <summary>
        /// Save all the changes so far and detach all the entities.
        /// </summary>
        public virtual void Flush()
        {
            this.SaveChanges();
            foreach (var dbEntityEntry in this.ChangeTracker.Entries())
            {
                dbEntityEntry.State = System.Data.Entity.EntityState.Detached;
            }
        }

        /// <summary>
        /// Gets or sets the name of the current repository.
        /// </summary>
        public virtual string Name { get; set; }
    }
}
