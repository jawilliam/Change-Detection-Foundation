namespace Jawilliam.CDF.Approach
{
    /// <summary>
    /// Defines a transformation before the matching occurs.
    /// </summary>
    /// <typeparam name="TApproach">the type of the supporting approach.</typeparam>
    /// <typeparam name="T">Type of the elements to be transformed.</typeparam>
    public interface IMatchingTransformation<TApproach, T>
    {
        /// <summary>
        /// Transforms the two comparing elements into the corresponding variants to be finally compared.
        /// </summary>
        /// <param name="pair">the comparing elements and contextual information.</param>
        /// <param name="resultingOriginal">the original variant to be finally compared.</param>
        /// <param name="resultingModified">the original variant to be finally compared.</param>
        void Transform(DetectionStep<TApproach, T> pair, out T resultingOriginal, out T resultingModified);
    }
}
