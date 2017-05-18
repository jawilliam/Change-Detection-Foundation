using System;
using System.Linq;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Jawilliam.CDF.Labs
{
    /// <summary>
    /// Base class for the file versions analysis logic.
    /// </summary>
    public abstract class FileVersionAnalyzer
    {
        /// <summary>
        /// Gets or sets the warnings to report.
        /// </summary>
        public StringBuilder Warnings { get; set; }

        /// <summary>
        /// Analyzes every file version of the given repository.
        /// </summary>
        /// <param name="sqlRepository">the SQL database repository in which to analyze the file versions.</param>
        /// <param name="onTheseFielVersions"></param>
        public virtual void Analyze(GitRepository sqlRepository, Expression<Func<FileVersion, bool>> onTheseFielVersions)
        {
            var fileVersionIds = sqlRepository.RepositoryObjects.OfType<FileVersion>()
                    .Where(onTheseFielVersions)
                    //.Where(fv => fv.Id != new Guid("bce066c9-066d-46fe-a155-3e0c06e0830e")) a problematic file in CoreFx
                    .Select(fv => fv.Id).ToList();
            int counter = 0;
            foreach (var fileVersionId in fileVersionIds)
            {
                var fileVersion = sqlRepository.RepositoryObjects.OfType<FileVersion>()
                    .Include(fv => fv.Content)
                    .Include(fv => fv.ContentSummary)
                    .Single(c => c.Id == fileVersionId);

                Console.Out.WriteLine($"Analyzing the {++counter}-file version ({fileVersionIds.Count}) of {sqlRepository.Name}");
                var cancellationTokenSource = new CancellationTokenSource();
                var cancellationToken = cancellationTokenSource.Token;
                try
                {
                    try
                    {
                        var t = Task.Run(() => this.Analyze(fileVersion, cancellationToken), cancellationToken);
                        t.Wait(300000);
                        cancellationTokenSource.Cancel();

                        t.Wait();
                    }
                    catch (AggregateException ae)
                    {
                        throw ae.InnerException;
                    }
                    catch (OperationCanceledException)
                    {
                        this.Warnings.AppendLine($"5 minutes Timeout - fileversion-{fileVersion.Id}");
                    }

                }
                catch (InsufficientExecutionStackException)
                {
                    this.Warnings.AppendLine($"InsufficientExecutionStack - fileversion-{fileVersion.Id}");
                }
                catch (OperationCanceledException)
                {
                    this.Warnings.AppendLine($"5 minutes Timeout - fileversion-{fileVersion.Id}");
                }

                Console.Out.WriteLine($"Saving the {counter}-file version ({fileVersionIds.Count}) of {sqlRepository.Name}");
                sqlRepository.Flush();
            }
        }

        /// <summary>
        /// Analyzes a given file version.
        /// </summary>
        /// <param name="fileVersion">the file version for analyzing.</param>
        /// <param name="cancelToken">logic for receiving the cancellation notifications.</param>
        public abstract void Analyze(FileVersion fileVersion, CancellationToken cancelToken);
    }
}
