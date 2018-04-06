using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jawilliam.CDF.Labs.DBModel
{
    partial class GitRepository
    {
        /// <summary>
        /// Initializes the instance with a particular name or connection string.
        /// </summary>
        /// <param name="nameOrConnectionString">the connection string, or the name to localize it inside the settings, e.g., the connection strings in the app.config.</param>
        public GitRepository(string nameOrConnectionString) : base(nameOrConnectionString)
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        /// <summary>
        /// Save all the changes so far and detach all the entities.
        /// </summary>
        public virtual void Flush(bool saveChanges = true)
        {
            if(saveChanges)
                this.SaveChanges();

            foreach (var dbEntityEntry in this.ChangeTracker.Entries().ToArray())
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
