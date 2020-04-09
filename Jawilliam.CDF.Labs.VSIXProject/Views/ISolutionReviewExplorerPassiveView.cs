namespace Jawilliam.CDF.Labs.VSIXProject.Views
{
    /// <summary>
    /// Defines a passive view mode for the <see cref="SolutionReviewExplorerControl"/>.
    /// </summary>
    public interface ISolutionReviewExplorerPassiveView
    {
        /// <summary>
        /// Requests that the given object must be shown in the properties window.
        /// </summary>
        /// <param name="source">object to show in the properties windows.</param>
        void ShowProperties(object source);
    }
}
