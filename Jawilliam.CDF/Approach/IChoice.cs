namespace Jawilliam.CDF.Approach
{
    /// <summary>
    /// Defines a logic to execute under the context of a step in the detection of changes.
    /// </summary>
    public interface IChoice
    {
        /// <summary>
        /// Executes the current choice under the context of a step in the detection of changes.
        /// </summary>
        void OnStep();
    }
}
