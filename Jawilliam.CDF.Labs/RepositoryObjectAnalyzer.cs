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
        /// Gets or sets tthe count of milliseconds to declare a time out analysis.
        /// </summary>
        public int MillisecondsTimeout { get; set; } = 300000;

        /// <summary>
        /// Analyzes a given repository object.
        /// </summary>
        /// <param name="repositoryObject">the repository object for analyzing.</param>
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
        /// <param name="repositoryObjectName"></param>
        /// <param name="onThese">expression to filter the objects of interest.</param>
        /// <param name="analysis">an action for characterizing the analysis.</param>
        /// <param name="cancel">Action to execute cancellation logic.</param>
        /// <param name="includes">paths to include in the query.</param>
        protected virtual void Analyze(GitRepository sqlRepository, string repositoryObjectName, Expression<Func<T, bool>> onThese, AnalyzeDelegate analysis, Action cancel, params string[] includes)
        {
            if (analysis == null) throw new ArgumentNullException(nameof(analysis));

            var repositoryObjectIds = sqlRepository.RepositoryObjects.OfType<T>()
                    .Where(onThese)
                    .Select(fv => fv.Id).Reverse().ToList(); ///TODO: Remove the reverse here...

            int counter = 0;
            foreach (var repositoryObjectId in repositoryObjectIds)
            {
                var repositoryObjectQuery = sqlRepository.RepositoryObjects.OfType<T>();
                repositoryObjectQuery = includes.Aggregate(repositoryObjectQuery, (current, include) => current.Include(include));
                T repositoryObject = repositoryObjectQuery.Single(c => c.Id == repositoryObjectId);

                Console.Out.WriteLine($"Analyzing the {++counter}-{repositoryObjectName} ({repositoryObjectIds.Count}) of {sqlRepository.Name}");
                var cancellationTokenSource = new CancellationTokenSource();
                var cancellationToken = cancellationTokenSource.Token;
                try
                {
                    try
                    {
                        var t = Task.Run(() => analysis(repositoryObject, cancellationToken), cancellationToken);
                        t.Wait(this.MillisecondsTimeout);
                        cancellationTokenSource.Cancel();
                        cancel?.Invoke();

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
