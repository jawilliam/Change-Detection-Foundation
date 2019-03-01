namespace Jawilliam.CDF.Approach
{
    /// <summary>
    /// Defines a service that must be called when starting a step in the detection of changes.  
    /// </summary>
    public interface IBeginStep
    {
        /// <summary>
        /// Initializes the current service for a step in the detection of changes.
        /// </summary>
        void BeginStep();
    }
}
