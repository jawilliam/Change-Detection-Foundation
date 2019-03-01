namespace Jawilliam.CDF.Approach
{
    /// <summary>
    /// Defines a service that must be called when ending a step in the detection of changes. 
    /// </summary>
    public interface IEndStep 
    {
        /// <summary>
        /// Finalizes the current service after the completion of a step in the detection of changes.
        /// </summary>
        void EndStep();
    }
}
