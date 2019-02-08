namespace Jawilliam.CDF.Approach
{
    /// <summary>
    /// Converts two comparing elements into the corresponding variants that will be finally compared.
    /// </summary>
    /// <param name="pair">the comparing elements and contextual information.</param>
    /// <param name="resultingOriginal">the original variant to be finally compared.</param>
    /// <param name="resultingModified">the original variant to be finally compared.</param>
    /// <typeparam name="T">Type of the elements to be transformed.</typeparam>    /// 
    /// <typeparam name="K">The type of the really processed representation when comparing two elements.</typeparam>
    public delegate void ConvertDelegate<T, K>(RevisionPair<T> pair, out K resultingOriginal, out K resultingModified);
}
