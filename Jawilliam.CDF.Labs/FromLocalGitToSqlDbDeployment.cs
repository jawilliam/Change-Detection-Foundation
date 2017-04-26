using System;
using System.Collections.Generic;
using System.Data.Entity;
using LibGit2Sharp;
using System.Linq;
using System.IO;
using System.Diagnostics;

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
        private Repository _repository;

        /// <summary>
        /// Creates an instance with the path given like the folder root.
        /// </summary>
        /// <param name="name">Name of the data set.</param>
        /// <param name="path">Folder root path.</param>
        protected FromLocalGitToSqlDbDeployment(string name, string path) : this(name, new Repository(path))
        {
        }

        /// <summary>
        /// Creates an instance wrapping the <see cref="Repository"/>.
        /// </summary>
        /// <param name="name">Name of the data set.</param>
        /// <param name="repository"><see cref="Repository"/> to wrap.</param>
        public FromLocalGitToSqlDbDeployment(string name, Repository repository)
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
        /// Gets the <see cref="Repository"/> being wrapped.
        /// </summary>
        public virtual Repository Repository
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
        {
            const CommitSortStrategies sortBy = CommitSortStrategies.Topological | CommitSortStrategies.Time | CommitSortStrategies.Reverse;
            var commits = Repository.Commits.QueryBy(new CommitFilter { SortBy = sortBy }).ToArray();

            var branches = Repository.Branches.ToArray();
            var otherCommits = branches.SelectMany(b => b.Commits).Except(commits).OrderBy(c => c.Committer.When).ToArray();
            var allCommits = commits.Union(otherCommits).OrderBy(c => c.Committer.When).ToArray();

            // Contributors...
            Console.Out.Write($"Starting the contributors of {sqlRepository.Name}");
            var contributorObjects = this.GetDeployedContributors(allCommits, sqlRepository);
            Console.Out.Write($"Ending the contributors of {sqlRepository.Name}");


            // Commits...
            Console.Out.Write($"Starting the commits of {sqlRepository.Name}");
            var commitObjects = new Dictionary<string, Commit>(allCommits.Length);
            for (var i = 0; i < allCommits.Length; i++)
            {
                var commit = allCommits[i];
                var author = contributorObjects.Single(c => c.Name == commit.Committer.Name && c.Email == commit.Committer.Email);
                var commitObject = this.GetDeployedCommit(author, commit, i + 1, sqlRepository);
                commitObjects[commitObject.ExternalID] = commitObject;

                foreach (var parent in commit.Parents)
                {
                    commitObject.Parents.Add(commitObjects[parent.Id.Sha]);
                }
            }
            Console.Out.Write($"Ending the commits of {sqlRepository.Name}");

            // Branches...
            Console.Out.Write($"Starting the branches of {sqlRepository.Name}");
            this.DeployBranches(branches, commitObjects, sqlRepository);
            Console.Out.Write($"Ending the branches of {sqlRepository.Name}");

            Console.Out.Write($"Starting the general information of {sqlRepository.Name}");
            sqlRepository.Flush();
            Console.Out.Write($"Ending the general information of {sqlRepository.Name}");



            // Revision pairs...
            Console.Out.Write($"Starting the file changes of {sqlRepository.Name}");
            this.DeployFileChanges(allCommits, sqlRepository);
            Console.Out.Write($"Ending the file changes of {sqlRepository.Name}");
        }

        /// <summary>
        /// Deploys the authors of the commits.
        /// </summary>
        /// <param name="commits">the commits for which find the authors.</param>
        /// <param name="repositoryDb">the repository database in which deploying the authors.</param>
        /// <returns>the deployed authors.</returns>
        protected virtual Contributor[] GetDeployedContributors(LibGit2Sharp.Commit[] commits, GitRepository repositoryDb)
        {
            var authors = commits.Select(c => c.Committer).Distinct(new CommitterComparer());

            var contributorObjects = authors.Select(delegate (Signature author)
            {
                var contributor = repositoryDb.RepositoryObjects.Create<Contributor>();
                contributor.Id = Guid.NewGuid();
                contributor.Name = author.Name;
                contributor.Email = author.Email;

                repositoryDb.RepositoryObjects.Add(contributor);

                return contributor;
            }).ToArray();

            return contributorObjects;
        }

        /// <summary>
        /// Deploys a commit.
        /// </summary>
        /// <param name="author">the author of the commit which will be deployed.</param>
        /// <param name="commit">the commit which will be deployed.</param>
        /// <param name="i">the index for the commit which will be deployed.</param>
        /// <param name="repositoryDb">the repository database in which the commit will be deployed.</param>
        /// <returns>the deployed commit.</returns>
        protected virtual Commit GetDeployedCommit(Contributor author, LibGit2Sharp.Commit commit, int i, GitRepository repositoryDb)
        {
            var commitObject = repositoryDb.RepositoryObjects.Create<Commit>();
            commitObject.Committer = author;
            commitObject.Date = commit.Committer.When;
            commitObject.ExternalID = commit.Id.Sha;
            commitObject.Id = Guid.NewGuid();
            commitObject.Index = i;
            commitObject.Message = commit.Message;

            repositoryDb.RepositoryObjects.Add(commitObject);
            return commitObject;
        }

        /// <summary>
        /// Deploys the branches of commits.
        /// </summary>
        /// <param name="branches">the branches will be deployed.</param>
        /// <param name="commitObjects">all of the existing commits.</param>
        /// <param name="repositoryDb">the repository database in which the branches will be deployed.</param>
        protected virtual void DeployBranches(LibGit2Sharp.Branch[] branches, IReadOnlyDictionary<string, Commit> commitObjects, GitRepository repositoryDb)
        {
            foreach (var branch in branches)
            {
                var branchObject = repositoryDb.RepositoryObjects.Create<Branch>();
                branchObject.FullName = branch.CanonicalName;
                branchObject.Id = Guid.NewGuid();
                branchObject.Tip = commitObjects[branch.Tip.Id.Sha];

                foreach (var commitId in branch.Commits.Select(c => c.Id.Sha))
                {
                    branchObject.Commits.Add(commitObjects[commitId]);
                }

                repositoryDb.RepositoryObjects.Add(branchObject);
            }
        }

        /// <summary>
        /// Deploys the changes between source code files. 
        /// </summary>
        /// <param name="localCommits">all the commits previously discovered in the local Git repository being deployed.</param>
        /// <param name="repositoryDb">the repository database in which the file changes will be deployed.</param>
        protected virtual void DeployFileChanges(LibGit2Sharp.Commit[] localCommits, GitRepository repositoryDb)
        {
            var commitIds = (from c in repositoryDb.RepositoryObjects.OfType<Commit>().OrderBy(c => c.Index)
                            select  c.ExternalID).ToArray();

            var commitCounter = 0;
            foreach (var commitId in commitIds)
            {
                var commit = repositoryDb.RepositoryObjects.OfType<Commit>().Include(c => c.Parents).Single(c => c.ExternalID == commitId);

                var parents = commit.Parents.DefaultIfEmpty(null).ToArray();
                var parentCounter = 0;
                foreach (var parent in commit.Parents.DefaultIfEmpty(null))
                {
                    Console.Out.Write($"Starting the {++parentCounter}-parent (of {parents.Length}) in the {++commitCounter}-commit (of {commitIds.Length}) of {repositoryDb.Name}");

                    var nativeCommit = localCommits.Single(c => c.Id.Sha == commit.ExternalID);
                    var nativeParent = parent != null ? localCommits.Single(c => c.Id.Sha == parent.ExternalID) : null;

                    var comparationOptions = new CompareOptions { IncludeUnmodified = false, Similarity = SimilarityOptions.None };
                    var patches = this.Repository.Diff.Compare<Patch>(nativeParent?.Tree, nativeCommit.Tree, compareOptions: comparationOptions);
                    foreach (var patch in patches.Where(p => Path.GetExtension(p.Path) == ".cs"))
                    {
                        switch (patch.Status)
                        {
                            case ChangeKind.Added:
                            case ChangeKind.Deleted:
                            case ChangeKind.Modified:
                            case ChangeKind.Renamed:
                                this.DeployFileChange(patch, nativeCommit, commit, nativeParent, parent, repositoryDb);
                                Console.Out.Write($"Starting save the {parentCounter}-parent (of {parents.Length}) in the {commitCounter}-commit (of {commitIds.Length}) of {repositoryDb.Name}");
                                repositoryDb.SaveChanges();
                                Console.Out.Write($"Ending save the {parentCounter}-parent (of {parents.Length}) in the {commitCounter}-commit (of {commitIds.Length}) of {repositoryDb.Name}");
                                break;
                            default:
                                break;
                        }
                    }
                    Console.Out.Write($"Ending the {parentCounter}-parent (of {parents.Length}) in the {commitCounter}-commit (of {commitIds.Length}) of {repositoryDb.Name}");
                }

                Console.Out.Write($"Starting flush of the {commitCounter}-commit (of {commitIds.Length}) of {repositoryDb.Name}");
                repositoryDb.Flush();
                Console.Out.Write($"Ending flush of the {commitCounter}-commit (of {commitIds.Length}) of {repositoryDb.Name}");
            }
        }

        /// <summary>
        /// Deploys a file change.
        /// </summary>
        /// <param name="patch">the patch describing the change according to the local Git repository.</param>
        /// <param name="localCommit">the commit according to the local Git repository.</param>
        /// <param name="dbCommit">the commit according to the databse Git repository.</param>
        /// <param name="localParentCommit">the parent commit according to the local Git repository.</param>
        /// <param name="dbParentCommit">the parent commit according to the databse Git repository.</param>
        /// <param name="repositoryDb">the repository database in which the file change will be deployed.</param>
        protected virtual void DeployFileChange(PatchEntryChanges patch, LibGit2Sharp.Commit localCommit, Commit dbCommit, LibGit2Sharp.Commit localParentCommit, Commit dbParentCommit, GitRepository repositoryDb)
        {
            FileChange change;
            FileVersion originalFileVersionObject = null, modifiedFileVersion = null;
            switch (patch.Status)
            {
                case ChangeKind.Added:
                    Debug.Assert(patch.Path == patch.OldPath && patch.OldOid.RawId.All(x => x == 0));
                    modifiedFileVersion = repositoryDb.RepositoryObjects.OfType<FileVersion>()
                        .SingleOrDefault(fv => fv.Path == patch.Path && fv.ExternalID == patch.Oid.Sha)
                        ?? this.GetDeployedFileVersion(localCommit, patch.Oid.Sha, patch.Path, repositoryDb);
                    change = repositoryDb.FileChanges.Create<FileAddedChange>();
                    change.FileVersion = modifiedFileVersion;
                    break;
                case ChangeKind.Deleted:
                    Debug.Assert(patch.Path == patch.OldPath && patch.Oid.RawId.All(x => x == 0));
                    originalFileVersionObject = repositoryDb.RepositoryObjects.OfType<FileVersion>().Single(fv => fv.Path == patch.OldPath && fv.ExternalID == patch.OldOid.Sha);
                    change = repositoryDb.FileChanges.Create<FileDeletedChange>();
                    change.FileVersion = originalFileVersionObject;
                    break;
                case ChangeKind.Modified:
                case ChangeKind.Renamed:
                    Debug.Assert(patch.Status == ChangeKind.Renamed || patch.Path == patch.OldPath);
                    originalFileVersionObject = repositoryDb.RepositoryObjects.OfType<FileVersion>()
                        .Single(fv => fv.Path == patch.OldPath && fv.ExternalID == patch.OldOid.Sha);
                    modifiedFileVersion = repositoryDb.RepositoryObjects.OfType<FileVersion>()
                        .SingleOrDefault(fv => fv.Path == patch.Path && fv.ExternalID == patch.Oid.Sha)
                        ?? this.GetDeployedFileVersion(localCommit, patch.Oid.Sha, patch.Path, repositoryDb);
                    change = patch.Status == ChangeKind.Renamed
                        ? repositoryDb.FileChanges.Create<FileRenamedChange>()
                        : repositoryDb.FileChanges.Create<FileModifiedChange>();
                    ((FileModifiedChange)change).FromFileVersion = originalFileVersionObject;
                    ((FileModifiedChange)change).FileVersion = modifiedFileVersion;
                    ((FileModifiedChange)change).ToPath = patch.Path;
                    if (patch.Status == ChangeKind.Renamed)
                    {
                        ((FileRenamedChange)change).FromPath = patch.OldPath;
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"The kind {patch.Status} of patch is not supported.");
            }

            change.LinesAdded = patch.LinesAdded;
            change.LinesDeleted = patch.LinesDeleted;
            change.ParentCommitId = dbParentCommit.Id;
            change.ChildCommitId = dbCommit.Id;
            if (patch.Status != ChangeKind.Added)
            {
                change.Patch = patch.Patch;
            }

            Debug.Assert(originalFileVersionObject != null || modifiedFileVersion != null);
            repositoryDb.FileChanges.Add(change);
        }

        /// <summary>
        /// Deploys a file version.
        /// </summary>
        /// <param name="localCommit">the commit according to the local Git repository.</param>
        /// <param name="patchId">the ID of the patch describing the change according to the local Git repository.</param>
        /// <param name="patchPath">the path of the patch describing the change according to the local Git repository.</param>
        /// <param name="repositoryDb">the repository database in which the file version will be deployed.</param>
        /// <returns>the deployed file version.</returns>
        protected virtual FileVersion GetDeployedFileVersion(LibGit2Sharp.Commit localCommit, string patchId, string patchPath, GitRepository repositoryDb)
        {
            var content = (Blob)localCommit[patchPath].Target;

            var fileVersion = repositoryDb.RepositoryObjects.Create<FileVersion>();
            fileVersion.Id = Guid.NewGuid();
            fileVersion.ExternalID = patchId;
            fileVersion.Path = patchPath;

            fileVersion.Content = repositoryDb.FileContents.Create();
            fileVersion.Content.Id = Guid.NewGuid();
            fileVersion.Content.SourceCode = content.GetContentText();

            fileVersion.ContentSummary = repositoryDb.FileContentSummaries.Create();
            fileVersion.ContentSummary.Id = Guid.NewGuid();
            fileVersion.ContentSummary.Size = content.Size;

            repositoryDb.RepositoryObjects.Add(fileVersion);
            return fileVersion;
        }

        /// <summary>
        /// Represents logic to compare contributors for equality.
        /// </summary>
        private class CommitterComparer : IEqualityComparer<Signature>
        {
            /// <summary>
            /// Determines whether the specified objects are equal.
            /// </summary>
            /// <returns>
            /// true if the specified objects are equal; otherwise, false.
            /// </returns>
            /// <param name="x">The first object to compare.</param>
            /// <param name="y">The second object to compare.</param>
            public bool Equals(Signature x, Signature y)
            {
                return x.Name == y.Name && x.Email == y.Email;
            }

            /// <summary>
            /// Returns a hash code for the specified object.
            /// </summary>
            /// <returns>
            /// A hash code for the specified object.
            /// </returns>
            /// <param name="obj">The <see cref="T:System.Object"/> for which a hash code is to be returned.</param><exception cref="T:System.ArgumentNullException">The type of <paramref name="obj"/> is a reference type and <paramref name="obj"/> is null.</exception>
            public int GetHashCode(Signature obj)
            {
                return (obj.Name + obj.Email).GetHashCode();
            }
        }
    }
}
