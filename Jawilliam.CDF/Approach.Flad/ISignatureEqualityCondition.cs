namespace Jawilliam.CDF.Approach.Flad
{
    /// <summary>
    /// Defines a same signature-based equality condition for two element versions. 
    /// </summary>
    /// <typeparam name="TOriginal">Type of the original version.</typeparam>
    /// <typeparam name="TModified">Type of the original version.</typeparam>
    public interface ISignatureEqualityCondition<TOriginal, TModified>
    {
        /// <summary>
        /// Determines if two typed elements are signature-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        bool SignatureExactlyEqual(TOriginal original, TModified modified);
    }
}
