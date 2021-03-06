﻿using Jawilliam.CDF.Labs.DBModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Jawilliam.CDF.Labs
{
    /// <summary>
    /// Implements the loading of a file modified change for review.
    /// </summary>
    public class RevisionPairReview
    {
        /// <summary>
        /// Loads a set of revisions pairs of interest.
        /// </summary>
        /// <param name="sqlRepository">the SQL database repository from which loading the file versions.</param>
        /// <param name="onThese">expression to filter the objects of interest.</param>
        /// <param name="includes">paths to include in the query.</param>
        /// <returns>A set of interest that satisfy the filtering expression.</returns>
        public virtual IEnumerable<FileModifiedChange> Load(GitRepository sqlRepository, Expression<Func<FileModifiedChange, bool>> onThese, params string[] includes)
        {
            var repositoryObjectIds = sqlRepository.RepositoryObjects.OfType<FileModifiedChange>()
                    .Where(onThese)
                    .Select(fv => fv.Id).ToList();

            foreach (var repositoryObjectId in repositoryObjectIds)
            {
                var repositoryObjectQuery = sqlRepository.RepositoryObjects.OfType<FileModifiedChange>();
                repositoryObjectQuery = (includes ?? new []{ "FileVersion.Content", "FromFileVersion.Content"})
                    .Aggregate(repositoryObjectQuery,
                    (current, include) => current.Include(include));

                yield return repositoryObjectQuery.Single(c => c.Id == repositoryObjectId);
            }
        }

        /// <summary>
        /// Loads a set of revisions pairs of interest.
        /// </summary>
        /// <param name="sqlRepository">the SQL database repository from which loading the file versions.</param>
        /// <param name="onThese">expression to filter the objects of interest.</param>
        /// <param name="includes">paths to include in the query.</param>
        /// <returns>A set of interest that satisfy the filtering expression.</returns>
        public virtual IEnumerable<FileModifiedChange> Load(GitRepository sqlRepository, Expression<Func<FileRevisionPair, bool>> onThese, params string[] includes)
        {
            var principalIds = sqlRepository.FileRevisionPairs
                    .Where(onThese)
                    .Select(fv => fv.Principal.Id).ToList();

            foreach (var repositoryObjectId in principalIds)
            {
                var repositoryObjectQuery = sqlRepository.RepositoryObjects.OfType<FileModifiedChange>();
                repositoryObjectQuery = (includes ?? new[] { "FileVersion.Content", "FromFileVersion.Content" })
                    .Aggregate(repositoryObjectQuery,
                    (current, include) => current.Include(include));

                yield return repositoryObjectQuery.Single(c => c.Id == repositoryObjectId);
            }
        }

        /// <summary>
        /// Loads a revisions pair of interest.
        /// </summary>
        /// <param name="sqlRepository">the SQL database repository from which loading the file versions.</param>
        /// <param name="id">an ID specifying the revision pair of interest.</param>
        /// <param name="includes">paths to include in the query.</param>
        /// <returns>A set of interest that satisfy the filtering expression.</returns>
        public virtual FileModifiedChange Load(GitRepository sqlRepository, Guid id, params string[] includes)
        {
            return this.Load(sqlRepository, (FileModifiedChange change) => change.Id == id, includes).Single();
        }

        /// <summary>
        /// Loads the revision pair that is the principal of the identified file revision pair.
        /// </summary>
        /// <param name="sqlRepository">the SQL database repository from which loading the file versions.</param>
        /// <param name="id">an ID specifying the revision pair of interest.</param>
        /// <param name="includes">paths to include in the query.</param>
        /// <returns>A set of interest that satisfy the filtering expression.</returns>
        public virtual FileModifiedChange LoadPrincipal(GitRepository sqlRepository, Guid id, params string[] includes)
        {
            return this.Load(sqlRepository, (FileRevisionPair change) => change.Id == id, includes).Single();
        }
    }
}
