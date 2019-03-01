namespace Jawilliam.CDF.Approach
{
    /// <summary>
    /// Defines a service that must be called when ending the detection of changes in a revision pair. 
    /// </summary>
    public interface IEndDetection
    {
        /// <summary>
        /// Finalizes the current service after completing the detection of changes in a revision pair.
        /// </summary>
        void EndDetection();
    }
}
