namespace Jawilliam.CDF.Approach
{
    /// <summary>
    /// Defines a service that must be called when starting the detection of changes in a new revision pair.  
    /// </summary>
    public interface IBeginDetection 
    {
        /// <summary>
        /// Initializes the current service for detecting changes in a new revision pair.
        /// </summary>
        void BeginDetection();
    }
}
