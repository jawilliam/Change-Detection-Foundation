using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Data.Entity;
using System.Linq.Expressions;

namespace Jawilliam.CDF.Labs
{
    /// <summary>
    /// Base class for the analysis logic of a specific repository object.
    /// </summary>
    public class RepositoryObjectAnalyzer<T> where T: RepositoryObject
    {
        /// <summary>
        /// Analyzes a given repository object.
        /// </summary>
        /// <param name="fileVersion">the repository object for analyzing.</param>
        /// <param name="cancelToken">logic for receiving the cancellation notifications.</param>
        public delegate void AnalyzeDelegate(T repositoryObject, CancellationToken cancelToken);

        /// <summary>
        /// Gets or sets the warnings to report.
        /// </summary>
        public StringBuilder Warnings { get; set; }

        /// <summary>
        /// Analyzes every file version of the given repository.
        /// </summary>
        /// <param name="sqlRepository">the SQL database repository in which to analyze the file versions.</param>
        /// <param name="onThese"></param>
        protected virtual void Analyze(GitRepository sqlRepository, string repositoryObjectName, Expression<Func<T, bool>> onThese, AnalyzeDelegate analysis, params string[] includes)
        {
            if (analysis == null) throw new ArgumentNullException("analysis");

            var repositoryObjectIds = sqlRepository.RepositoryObjects.OfType<T>()
                    .Where(onThese)
                    .Select(fv => fv.Id).ToList();

            int counter = 0;
            foreach (var repositoryObjectId in repositoryObjectIds)
            {
                var repositoryObjectQuery = sqlRepository.RepositoryObjects.OfType<T>();
                foreach (var include in includes)
                {
                    repositoryObjectQuery = repositoryObjectQuery.Include(include);
                }
                T repositoryObject = repositoryObjectQuery.Single(c => c.Id == repositoryObjectId);

                Console.Out.WriteLine($"Analyzing the {++counter}-{repositoryObjectName} ({repositoryObjectIds.Count}) of {sqlRepository.Name}");
                var cancellationTokenSource = new CancellationTokenSource();
                var cancellationToken = cancellationTokenSource.Token;
                try
                {
                    try
                    {
                        var t = Task.Run(() => analysis(repositoryObject, cancellationToken), cancellationToken);
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
                        this.Warnings.AppendLine($"5 minutes Timeout - {repositoryObjectName}-{repositoryObject.Id}");
                    }

                }
                catch (InsufficientExecutionStackException)
                {
                    this.Warnings.AppendLine($"InsufficientExecutionStack - fileversion-{repositoryObjectName}-{repositoryObject.Id}");
                }
                catch (OperationCanceledException)
                {
                    this.Warnings.AppendLine($"5 minutes Timeout - {repositoryObjectName}-{repositoryObject.Id}");
                }

                Console.Out.WriteLine($"Saving the {counter}-file version ({repositoryObjectIds.Count}) of {sqlRepository.Name}");
                sqlRepository.Flush();
            }
        }
    }
}
