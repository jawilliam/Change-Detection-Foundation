using System;
using System.Linq;
using System.Data.Entity;

namespace Jawilliam.CDF.Labs
{
    /// <summary>
    /// Base class for the file versions analysis logic.
    /// </summary>
    public abstract class FileVersionAnalyzer
    {
        /// <summary>
        /// Analyzes every file version of the given repository.
        /// </summary>
        /// <param name="sqlRepository">the SQL database repository in which to analyze the file versions.</param>
        public virtual void Analyze(GitRepository sqlRepository)
        {
            var fileVersionIds = sqlRepository.RepositoryObjects.OfType<FileVersion>().Select(fv => fv.Id).ToList();
            int counter = 0;
            foreach (var fileVersionId in fileVersionIds)
            {
                var fileVersion = sqlRepository.RepositoryObjects.OfType<FileVersion>()
                    .Include(fv => fv.Content)
                    .Include(fv => fv.ContentSummary)
                    .Single(c => c.Id == fileVersionId);

                Console.Out.WriteLine($"Analyzing the {++counter}-file version ({fileVersionIds.Count}) of {sqlRepository.Name}");
                this.Analyze(fileVersion);
                Console.Out.WriteLine($"Saving the {counter}-file version ({fileVersionIds.Count}) of {sqlRepository.Name}");
                sqlRepository.Flush();
            }
        }

        /// <summary>
        /// Analyzes a given file version.
        /// </summary>
        /// <param name="fileVersion">the file version for analyzing.</param>
        public abstract void Analyze(FileVersion fileVersion);
    }
}
