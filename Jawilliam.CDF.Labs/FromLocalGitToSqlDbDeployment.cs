using System;
using System.Collections.Generic;
using System.Data.Entity;
using LibGit2Sharp;
using System.Linq;
using System.IO;
using System.Diagnostics;
using System.Text;

namespace Jawilliam.CDF.Labs
{
    /// <summary>
    /// Base class for our abstractions of Git repositories into SQL databases. 
    /// </summary>
    public class FromLocalGitToSqlDbDeployment
    {
        ///// <summary>
        ///// Stores the value for the property <see cref="Repository"/>.
        ///// </summary>
        //private Repository _repository;

        ///// <summary>
        ///// Creates an instance with the path given like the folder root.
        ///// </summary>
        ///// <param name="name">Name of the data set.</param>
        ///// <param name="path">Folder root path.</param>
        //protected FromLocalGitToSqlDbDeployment(string name, string path) : this(name, new Repository(path))
        //{
        //}

        ///// <summary>
        ///// Creates an instance wrapping the <see cref="Repository"/>.
        ///// </summary>
        ///// <param name="name">Name of the data set.</param>
        ///// <param name="repository"><see cref="Repository"/> to wrap.</param>
        //public FromLocalGitToSqlDbDeployment(string name, Repository repository)
        //{
        //    if (name == null)
        //        throw new ArgumentNullException("name");

        //    if (repository == null)
        //        throw new ArgumentNullException("repository");

        //    this.Name = name;
        //    this.Repository = repository;
        //}

        ///// <summary>
        ///// Gets the name of the data set.
        ///// </summary>
        //public string Name { get; private set; }

        ///// <summary>
        ///// Gets the <see cref="Repository"/> being wrapped.
        ///// </summary>
        //public virtual Repository Repository
        //{
        //    get { return this._repository; }
        //    set
        //    {
        //        if (value == null)
        //            throw new ArgumentNullException("value");

        //        this._repository = value;
        //    }
        //}

        /// <summary>
        /// Gets or sets the warnings to report.
        /// </summary>
        public StringBuilder Warnings { get; set; }

        /// <summary>
        /// Deploys the data set content into a folder.
        /// </summary>
        /// <param name="localRepository">the local Git repository from which to deploy.</param>
        /// <param name="sqlRepository">the SQL database repository in which to deploy.</param>
        public virtual void Deploy(Repository localRepository, GitRepository sqlRepository)
        {
            const CommitSortStrategies sortBy = CommitSortStrategies.Topological | CommitSortStrategies.Time | CommitSortStrategies.Reverse;
            var commits = localRepository.Commits.QueryBy(new CommitFilter { SortBy = sortBy }).ToArray();

            var branches = localRepository.Branches.ToArray();
            var otherCommits = branches.SelectMany(b => b.Commits).Except(commits).OrderBy(c => c.Committer.When).ToArray();
            var allCommits = commits.Union(otherCommits).OrderBy(c => c.Committer.When).ToArray();

            // Contributors...
            Console.Out.WriteLine($"Starting the contributors of {sqlRepository.Name}");
            this.GetDeployedContributors(allCommits, sqlRepository);
            sqlRepository.Flush();
            Console.Out.WriteLine($"Ending the contributors of {sqlRepository.Name}");

            // Commits...
            Console.Out.WriteLine($"Starting the commits of {sqlRepository.Name}");
            //var commitObjects = new Dictionary<string, Commit>(allCommits.Length);
            for (var i = 0; i < allCommits.Length; i++)
            {
                Console.Out.WriteLine($"Starting {i}-commits ({allCommits.Length}) of {sqlRepository.Name}");
                var commit = allCommits[i];
                var author = sqlRepository.RepositoryObjects.OfType<Contributor>().First(c => c.Name == commit.Committer.Name && c.Email == commit.Committer.Email);
                this.GetDeployedCommit(author, commit, i + 1, sqlRepository);
                sqlRepository.Flush();
                Console.Out.WriteLine($"Ending {i}-commits ({allCommits.Length}) of {sqlRepository.Name}");
                //commitObjects[commitObject.ExternalID] = commitObject;
            }

            foreach (var commit in allCommits)
            {
                //var commitObject = commitObjects[commit.Id.Sha];
                foreach (var parent in commit.Parents)
                {
                    var commitObject = sqlRepository.RepositoryObjects.OfType<Commit>().Single(c => c.ExternalID == commit.Id.Sha);
                    var parentObject = sqlRepository.RepositoryObjects.OfType<Commit>().Single(c => c.ExternalID == parent.Id.Sha);
                    commitObject.Parents.Add(parentObject);
                    sqlRepository.Flush();
                }
            }
            
            Console.Out.WriteLine($"Ending the commits of {sqlRepository.Name}");

            // Branches...
            Console.Out.WriteLine($"Starting the branches of {sqlRepository.Name}");
            this.DeployBranches(branches/*, commitObjects*/, sqlRepository);
            Console.Out.WriteLine($"Ending the branches of {sqlRepository.Name}");

            Console.Out.WriteLine($"Starting the general information of {sqlRepository.Name}");
            sqlRepository.Flush();
            Console.Out.WriteLine($"Ending the general information of {sqlRepository.Name}");

            // Revision pairs...
            Console.Out.WriteLine($"Starting the file changes of {sqlRepository.Name}");
            this.DeployFileChanges(localRepository, allCommits, sqlRepository, delegate (PatchEntryChanges changes)
            {
                switch (changes.Status)
                {
                    case ChangeKind.Added:
                    case ChangeKind.Deleted:
                    case ChangeKind.Modified:
                    case ChangeKind.Renamed:
                        return true;
                    default:
                        return false;
                }
            }, SimilarityOptions.Default);
            Console.Out.WriteLine($"Ending the file changes of {sqlRepository.Name}");

            //Console.Out.WriteLine($"Starting the non-renamed file changes of {sqlRepository.Name}");
            //this.DeployFileChanges(localRepository, allCommits, sqlRepository, delegate(PatchEntryChanges changes)
            //{
            //    switch (changes.Status)
            //    {
            //        case ChangeKind.Added:
            //        case ChangeKind.Deleted:
            //        case ChangeKind.Modified:
            //            return true;
            //        default:
            //            return false;
            //    }
            //}, SimilarityOptions.None);
            //Console.Out.WriteLine($"Ending the renamed file changes of {sqlRepository.Name}");

            //Console.Out.WriteLine($"Starting the renamed file changes of {sqlRepository.Name}");
            //this.DeployFileChanges(localRepository, allCommits, sqlRepository, delegate (PatchEntryChanges changes)
            //{
            //    switch (changes.Status)
            //    {
            //        case ChangeKind.Renamed:
            //            return true;
            //        default:
            //            return false;
            //    }
            //}, SimilarityOptions.Default);
            //Console.Out.WriteLine($"Ending the renamed file changes of {sqlRepository.Name}");
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
        ///// <param name="commitObjects">all of the existing commits.</param>
        /// <param name="repositoryDb">the repository database in which the branches will be deployed.</param>
        protected virtual void DeployBranches(LibGit2Sharp.Branch[] branches, GitRepository repositoryDb)
        {
            int total = branches.Length;
            int counter = 0;
            foreach (var branch in branches)
            {
                Console.Out.WriteLine($"Starting {++counter}-branches (of {total}) the file changes of {repositoryDb.Name}");
                var branchObject = repositoryDb.RepositoryObjects.Create<Branch>();
                branchObject.FullName = branch.CanonicalName;
                branchObject.Id = Guid.NewGuid();
                var commitObject = repositoryDb.RepositoryObjects.OfType<Commit>().Single(c => c.ExternalID == branch.Tip.Id.Sha);
                branchObject.Tip = commitObject;

                int commitCounter = 0;
                var commitIds = branch.Commits.Select(c => c.Id.Sha).ToArray();
                foreach (var commitId in commitIds)
                {
                    Console.Out.WriteLine($"Starting to assemble the {++commitCounter}-commit (of {commitIds.Length}) for the {counter}-branches (of {total}) the file changes of {repositoryDb.Name}");
                    commitObject = repositoryDb.RepositoryObjects.OfType<Commit>().Single(c => c.ExternalID == commitId);
                    branchObject.Commits.Add(commitObject);
                    Console.Out.WriteLine($"Ending to assemble the {commitCounter}-commit (of {commitIds.Length}) for the {counter}-branches (of {total}) the file changes of {repositoryDb.Name}");
                }

                repositoryDb.RepositoryObjects.Add(branchObject);
                repositoryDb.Flush();

                Console.Out.WriteLine($"Ending {counter}-branches (of {total}) the file changes of {repositoryDb.Name}");
            }
        }

        /// <summary>
        /// Deploys the changes between source code files. 
        /// </summary>
        /// <param name="localRepository">the local Git repository from which to deploy.</param>
        /// <param name="localCommits">all the commits previously discovered in the local Git repository being deployed.</param>
        /// <param name="repositoryDb">the repository database in which the file changes will be deployed.</param>
        /// <param name="supportedChange"></param>
        /// <param name="similarityOptions"></param>
        protected virtual void DeployFileChanges(Repository localRepository, LibGit2Sharp.Commit[] localCommits, GitRepository repositoryDb, Func<PatchEntryChanges,bool> supportedChange, SimilarityOptions similarityOptions)
        {
            var commitIds = (from c in repositoryDb.RepositoryObjects.OfType<Commit>().OrderBy(c => c.Index)
                            select  c.ExternalID).ToArray();

            var commitCounter = 0;
            foreach (var commitId in commitIds)
            {
                var commit = repositoryDb.RepositoryObjects.OfType<Commit>().Include(c => c.Parents).Single(c => c.ExternalID == commitId);

                var parents = commit.Parents.DefaultIfEmpty(null).ToArray();
                var parentCounter = 0;
                commitCounter++;
                foreach (var parent in commit.Parents.DefaultIfEmpty(null))
                {
                    Console.Out.WriteLine($"Starting the {++parentCounter}-parent (of {parents.Length}) in the {commitCounter}-commit (of {commitIds.Length}) of {repositoryDb.Name}");

                    var nativeCommit = localCommits.Single(c => c.Id.Sha == commit.ExternalID);
                    var nativeParent = parent != null ? localCommits.Single(c => c.Id.Sha == parent.ExternalID) : null;

                    var comparationOptions = new CompareOptions { IncludeUnmodified = false, Similarity = similarityOptions };
                    Patch patches = null;
                    try
                    {
                        patches = localRepository.Diff.Compare<Patch>(nativeParent?.Tree, nativeCommit.Tree,
                            compareOptions: comparationOptions);
                    }
                    catch (OutOfMemoryException)
                    {
                        this.Warnings.AppendLine(
                            $"OutOfMemory - commit-{commit.ExternalID}({commit.Index})   parent-{parent?.ExternalID ?? "parent"}({parent?.Index ?? -1})");
                        //throw;
                    }
                    catch (LibGit2SharpException lx) when ((lx.Message?.ToLowerInvariant() ?? "") == "out of memory")
                    {
                        this.Warnings.AppendLine(
                            $"OutOfMemory - commit-{commit.ExternalID}({commit.Index})   parent-{parent?.ExternalID ?? "parent"}({parent?.Index ?? -1})");
                        //throw;
                    }
                    catch (LibGit2SharpException lx)
                    {
                        this.Warnings.AppendLine(
                            $"OtherError - commit-{commit.ExternalID}({commit.Index})   parent-{parent?.ExternalID ?? "parent"}({parent?.Index ?? -1})");

                    }

                    if (patches != null)
                    {
                        foreach (var patch in patches.Where(p => Path.GetExtension(p.Path) == ".cs"))
                        {
                            if (supportedChange(patch))
                            {
                                this.DeployFileChange(patch, nativeCommit, commit, nativeParent, parent, repositoryDb);
                                Console.Out.WriteLine($"Starting save the {parentCounter}-parent (of {parents.Length}) in the {commitCounter}-commit (of {commitIds.Length}) of {repositoryDb.Name}");
                                repositoryDb.SaveChanges();
                                Console.Out.WriteLine($"Ending save the {parentCounter}-parent (of {parents.Length}) in the {commitCounter}-commit (of {commitIds.Length}) of {repositoryDb.Name}");
                                break;
                            }
                        }
                    }

                    Console.Out.WriteLine($"Ending the {parentCounter}-parent (of {parents.Length}) in the {commitCounter}-commit (of {commitIds.Length}) of {repositoryDb.Name}");
                }

                Console.Out.WriteLine($"Starting flush of the {commitCounter}-commit (of {commitIds.Length}) of {repositoryDb.Name}");
                repositoryDb.Flush();
                Console.Out.WriteLine($"Ending flush of the {commitCounter}-commit (of {commitIds.Length}) of {repositoryDb.Name}");
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
                    change = repositoryDb.RepositoryObjects.Create<FileAddedChange>();
                    change.FileVersion = modifiedFileVersion;
                    break;
                case ChangeKind.Deleted:
                    Debug.Assert(patch.Path == patch.OldPath && patch.Oid.RawId.All(x => x == 0));
                    originalFileVersionObject = repositoryDb.RepositoryObjects.OfType<FileVersion>()
                        .SingleOrDefault(fv => fv.Path == patch.OldPath && fv.ExternalID == patch.OldOid.Sha)
                        ?? this.GetDeployedFileVersion(localCommit, patch.OldOid.Sha, patch.OldPath, repositoryDb);
                    change = repositoryDb.RepositoryObjects.Create<FileDeletedChange>();
                    change.FileVersion = originalFileVersionObject;
                    break;
                case ChangeKind.Modified:
                case ChangeKind.Renamed:
                    Debug.Assert(patch.Status == ChangeKind.Renamed || patch.Path == patch.OldPath);
                    originalFileVersionObject = repositoryDb.RepositoryObjects.OfType<FileVersion>()
                        .FirstOrDefault(fv => fv.Path == patch.OldPath && fv.ExternalID == patch.OldOid.Sha) 
                        ?? this.GetDeployedFileVersion(localCommit, patch.OldOid.Sha, patch.OldPath, repositoryDb);
                    modifiedFileVersion = repositoryDb.RepositoryObjects.OfType<FileVersion>()
                        .FirstOrDefault(fv => fv.Path == patch.Path && fv.ExternalID == patch.Oid.Sha)
                        ?? this.GetDeployedFileVersion(localCommit, patch.Oid.Sha, patch.Path, repositoryDb);
                    change = patch.Status == ChangeKind.Renamed
                        ? repositoryDb.RepositoryObjects.Create<FileRenamedChange>()
                        : repositoryDb.RepositoryObjects.Create<FileModifiedChange>();
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

            change.Id = Guid.NewGuid();
            change.LinesAdded = patch.LinesAdded;
            change.LinesDeleted = patch.LinesDeleted;
            change.FromCommit = dbParentCommit;
            change.ToCommit = dbCommit;
            if (patch.Status != ChangeKind.Added)
            {
                change.Patch = patch.Patch;
            }

            Debug.Assert(originalFileVersionObject != null || modifiedFileVersion != null);
            repositoryDb.RepositoryObjects.Add(change);
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
            var content = (Blob)localCommit[patchPath]?.Target;

            var fileVersion = repositoryDb.RepositoryObjects.Create<FileVersion>();
            fileVersion.Id = Guid.NewGuid();
            fileVersion.ExternalID = patchId;
            fileVersion.Path = patchPath;

            fileVersion.Content = repositoryDb.FileContents.Create();
            fileVersion.Content.Id = Guid.NewGuid();
            fileVersion.Content.SourceCode = content?.GetContentText();

            fileVersion.ContentSummary = repositoryDb.FileContentSummaries.Create();
            fileVersion.ContentSummary.Id = Guid.NewGuid();
            fileVersion.ContentSummary.Size = content?.Size ?? 0;

            repositoryDb.RepositoryObjects.Add(fileVersion);
            return fileVersion;
        }

        /// <summary>
        /// Repairs the indexes for the initially deployed commits. 
        /// </summary>
        /// <param name="localRepository">the local Git repository from which the initial deployment was done.</param>
        /// <param name="sqlRepository">the SQL database repository in which the initial deployment was done.</param>
        /// <remarks>This is required because the initial deployment does not order well the commits that are no contained into the master branch.</remarks>
        public virtual void RepairCommitIndexes(Repository localRepository, GitRepository sqlRepository)
        {
            const CommitSortStrategies sortBy = CommitSortStrategies.Topological | CommitSortStrategies.Time | CommitSortStrategies.Reverse;
            var commits = localRepository.Commits.QueryBy(new CommitFilter { IncludeReachableFrom = localRepository.Refs, SortBy = sortBy }).ToArray();
            var dbCommitIds = sqlRepository.RepositoryObjects.OfType<Commit>().Select(c => c.Id).ToArray();
            //Debug.Assert(commits.Length > dbCommitIds.Count(), "There is any problem");

            int j = 0;
            foreach (var dbCommitId in dbCommitIds)
            {
                Console.Out.WriteLine($"Removing the index of the {++j}-commit (of {dbCommitIds.Count()}) of {sqlRepository.Name}");
                var commit = sqlRepository.RepositoryObjects.OfType<Commit>().Single(c => c.Id == dbCommitId);
                commit.Index = int.MaxValue;
                sqlRepository.Flush();
            }
            
            for (int i = 0; i < commits.Length; i++)
            {
                Console.Out.WriteLine($"Repairing the {i + 1}-commit (of {dbCommitIds.Count()}) of {sqlRepository.Name}");
                var i1 = i;
                var sha = commits[i1].Sha;
                var commit = sqlRepository.RepositoryObjects.OfType<Commit>().SingleOrDefault(c => c.ExternalID == sha);
                if (commit != null)
                {
                    commit.Index = i + 1;
                    sqlRepository.Flush();
                }
            }

            var uncoveredCommitIds = sqlRepository.RepositoryObjects.OfType<Commit>().Where(c => c.Index == int.MaxValue).Select(c => c.Id);
            foreach (var dbCommitId in uncoveredCommitIds)
            {
                var hasFileVersions = (from co in sqlRepository.RepositoryObjects.OfType<Commit>()
                    where co.Id == dbCommitId && (co.BackwardChanges.Any() || co.ForwardChanges.Any())
                    select co).Any();

                this.Warnings.AppendLine(hasFileVersions
                    ? $"Commit {dbCommitId} is not covered and it has file versions"
                    : $"Commit {dbCommitId} is not covered but it not has file versions");
            }
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

        /// <summary>
        /// Deploys the file revision pairs and their relation with the conceptual file.
        /// </summary> 
        /// <param name="sqlRepository">the SQL database repository in which the initial deployment was done.</param>
        public virtual void DeployFileRevisionPairs(GitRepository sqlRepository)
        {
            var revisionPairIds = sqlRepository.RepositoryObjects.OfType<FileModifiedChange>()
                .Select(m => new { FromVersion = m.FromFileVersion.Id, ToVersion = m.FileVersion.Id }).ToList()
                .Select(m => $"{m.FromVersion.ToString()}##{m.ToVersion.ToString()}")
                .Distinct()
                .ToList();

            int i = 0;
            foreach (var revisionPairId in revisionPairIds)
            {
                var ids = revisionPairId.Split(new []{"##"}, StringSplitOptions.RemoveEmptyEntries);
                var fromId = Guid.Parse(ids[0]);
                var toId = Guid.Parse(ids[1]);

                var revisionPairs = (from fmc in sqlRepository.RepositoryObjects.OfType<FileModifiedChange>()
                    where fmc.FromFileVersion.Id == fromId && fmc.FileVersion.Id == toId
                    orderby fmc.ToCommit.Index/*, fmc.FromCommit.Index*/
                    select new
                    {
                        RevisionPair = fmc,
                        FromCommit = fmc.FromCommit.Index,
                        ToCommit = fmc.ToCommit.Index
                    }).ToList();

                sqlRepository.RepositoryObjects.Add(new File
                {
                    Id = Guid.NewGuid(),
                    RevisionPairs = new List<FileRevisionPair>
                    {
                        new FileRevisionPair
                        {
                            Id = Guid.NewGuid(),
                            Principal = revisionPairs[0].RevisionPair,
                            Copies = revisionPairs.Skip(1).Select(rp => rp.RevisionPair).ToList(),
                            Versioning = new PairRevisionInfo {FromVersion = -1, Path = "", ToVersion = -1}
                        }
                    }
                });

                sqlRepository.Flush();
                Console.Out.WriteLine($"{sqlRepository.Name}: Revision pair #{++i} of ({revisionPairIds.Count})");
            }
        }

        /// <summary>
        /// Checks some concerns about the file revision pairs, such as the fact that the principal contains all the required information.
        /// </summary> 
        /// <param name="sqlRepository">the SQL database repository in which the initial deployment was done.</param>
        public virtual void CheckFileRevisionPairs(GitRepository sqlRepository)
        {
            var revisionPairIds = sqlRepository.FileRevisionPairs.Select(frp => frp.Id).ToList();

            //var revisionPairs = sqlRepository.FileRevisionPairs.AsNoTracking()
            //    .Include(frp => frp.Principal.Deltas)
            //    .Include(frp => frp.Copies.Select(c => c.Deltas));
            int total = sqlRepository.FileRevisionPairs.Count();
            int i = 0;
            foreach (var revisionPairId in revisionPairIds)
            {
                var fileRevisionPair = sqlRepository.FileRevisionPairs.AsNoTracking()
                    .Where(frp => frp.Id == revisionPairId)
                    .Include(frp => frp.Principal/*.Deltas*/)
                    .Include(frp => frp.Copies/*.Select(c => c.Deltas)*/)
                    .Single();

                Debug.Assert(fileRevisionPair.Copies.All(c => c.XAnnotations.SourceCodeChanges == fileRevisionPair.Principal.XAnnotations.SourceCodeChanges));
                Debug.Assert(fileRevisionPair.Copies.All(c => c.XAnnotations.OnlyCommentChanges == fileRevisionPair.Principal.XAnnotations.OnlyCommentChanges));

                var principalDeltas = sqlRepository.Deltas.AsNoTracking().Where(d => d.RevisionPair.Id == fileRevisionPair.Principal.Id).ToList();
                foreach (var copy in fileRevisionPair.Copies)
                {
                    Debug.Assert(fileRevisionPair.Principal.Annotations == copy.Annotations);

                    var copyDeltas = sqlRepository.Deltas.AsNoTracking().Where(d => d.RevisionPair.Id == copy.Id).ToList();
                    foreach (var copyDelta in copyDeltas)
                    {
                        var principalDelta = principalDeltas.SingleOrDefault(d => d.Approach == copyDelta.Approach);
                        Debug.Assert(principalDelta != null);
                        //Debug.Assert(principalDelta.Annotations == copyDelta.Annotations);
                        if (principalDelta.Annotations != copyDelta.Annotations)
                        {
                            this.Warnings.AppendLine($"annotations##{sqlRepository.Name}##{revisionPairId}##{copyDelta.Id}");
                        }
                        //Debug.Assert(principalDelta.DetectionResult. == copyDelta.DetectionResult);
                        //Debug.Assert(principalDelta.Differencing == copyDelta.Differencing);
                        if (principalDelta.Differencing != copyDelta.Differencing)
                        {
                            this.Warnings.AppendLine($"differencing##{sqlRepository.Name}##{revisionPairId}##{copyDelta.Id}");
                        }
                        if (principalDelta.Matching != copyDelta.Matching)
                        {
                            this.Warnings.AppendLine($"matching##{sqlRepository.Name}##{revisionPairId}##{copyDelta.Id}");
                            //;

                            //var p = principalDelta.Matching.ToArray();
                            //var d = copyDelta.Matching.ToArray();
                            //int min = Math.Min(p.Length, d.Length);
                            //for (int j = 0; j < min; j++)
                            //{
                            //    if (p[j] != d[j])
                            //        ;
                            //}
                        }
                        //Debug.Assert(principalDelta.Matching == copyDelta.Matching);
                        Debug.Assert(principalDelta.Report == copyDelta.Report);
                    }
                }

                Console.Out.WriteLine($"{sqlRepository.Name}: Revision pair #{++i} checked of ({total})");

                //foreach (var dbEntityEntry in sqlRepository.ChangeTracker.Entries().ToArray())
                //{
                //    dbEntityEntry.State = System.Data.Entity.EntityState.Detached;
                //}
            }
        }

        /// <summary>
        /// Deploy the typed review notes for the new file revision pairs.
        /// </summary> 
        /// <param name="sqlRepository">the SQL database repository in which the initial deployment was done.</param>
        public virtual void DeployReviewsForFileRevisionPairs(GitRepository sqlRepository)
        {
            var revisionPairIds = sqlRepository.FileRevisionPairs.Select(frp => frp.Id).ToList();

            //var revisionPairs = sqlRepository.FileRevisionPairs.AsNoTracking()
            //    .Include(frp => frp.Principal.Deltas)
            //    .Include(frp => frp.Copies.Select(c => c.Deltas));
            int total = sqlRepository.FileRevisionPairs.Count();
            int i = 0;
            foreach (var revisionPairId in revisionPairIds)
            {
                var fileRevisionPair = sqlRepository.FileRevisionPairs
                    .Where(frp => frp.Id == revisionPairId)
                    .Include(frp => frp.Principal/*.Deltas*/)
                    .Include(frp => frp.Copies/*.Select(c => c.Deltas)*/)
                    .Single();

                var reviewNotes = fileRevisionPair.Principal.XAnnotations.ReviewNotes?.ToList();
                if ((reviewNotes?.Count(x => x.Review == "Ratio-LevenshteinGumTree-IgnoringCommentChangesLocalOutliers") ?? 0) == 0)
                    //reviewNotes.All(x => x.Review != "Ratio-LevenshteinGumTree-IgnoringCommentChangesLocalOutliers")
                    continue;

                //var reviewNotes = fileRevisionPair.Principal.XAnnotations.ReviewNotes.ToList();
                foreach (var rv in reviewNotes.ToList())
                {
                    var review = new Review
                    {
                        Id = Guid.NewGuid(),
                        CaseKind = CaseKind.Unknown,
                        Severity = (ReviewSeverity)Enum.Parse(typeof(ReviewSeverity), Enum.GetName(typeof(XFileModifiedChangeAnnotations.ReviewNoteKind), rv.Kind)),
                        Subject = rv.Title ?? "",
                        Comments = rv.Text,
                        Kind = ReviewKind.Ratio_LevenshteinGumTree_IgnoringCommentChanges_LocalOutliers,
                        Topics = /*Topics.None*//**/Topics.Domain /* | Topics.Matching *//*| Topics.Differencing*/ /*| Topics.Report*/,
                    };

                    fileRevisionPair.Reviews.Add(review);
                    reviewNotes.Remove(rv);
                }

                //sqlRepository.SaveChanges();
                var ann = fileRevisionPair.Principal.XAnnotations;
                ann.ReviewNotes = reviewNotes.ToArray();
                fileRevisionPair.Principal.XAnnotations = ann;
                //sqlRepository.SaveChanges();
            }
        }
    }
}
