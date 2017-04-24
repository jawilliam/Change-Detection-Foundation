using System;
using System.Collections.Generic;
using System.Text;

namespace Jawilliam.CDF.Labs
{
    /// <summary>
    /// Base class for our abstractions of Git repositories into SQL databases. 
    /// </summary>
    public class FromLocalGitToSqlDbDeployment
    {
        /// <summary>
        /// Stores the value for the property <see cref="Repository"/>.
        /// </summary>
        private LibGit2Sharp.Repository _repository;

        /// <summary>
        /// Creates an instance with the path given like the folder root.
        /// </summary>
        /// <param name="name">Name of the data set.</param>
        /// <param name="path">Folder root path.</param>
        protected FromLocalGitToSqlDbDeployment(string name, string path) : this(name, new LibGit2Sharp.Repository(path))
        {
        }

        /// <summary>
        /// Creates an instance wrapping the <see cref="LibGit2Sharp.Repository"/>.
        /// </summary>
        /// <param name="name">Name of the data set.</param>
        /// <param name="repository"><see cref="LibGit2Sharp.Repository"/> to wrap.</param>
        public FromLocalGitToSqlDbDeployment(string name, LibGit2Sharp.Repository repository)
        {
            if (name == null)
                throw new ArgumentNullException("name");

            if (repository == null)
                throw new ArgumentNullException("repository");

            this.Name = name;
            this.Repository = repository;
        }

        /// <summary>
        /// Gets the name of the data set.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the <see cref="LibGit2Sharp.Repository"/> being wrapped.
        /// </summary>
        public virtual LibGit2Sharp.Repository Repository
        {
            get { return this._repository; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");

                this._repository = value;
            }
        }

        /// <summary>
        /// Deploys the data set content into a folder.
        /// </summary>
        /// <param name="folderPath">the SQL database repository in where deploy.</param>
        public virtual void Deploy(GitRepository sqlRepository)
        { }
    }
}
