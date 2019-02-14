namespace Jawilliam.CDF.Approach
{
    /// <summary>
    /// Loads the original and modified versions to compare. 
    /// </summary>
    /// <typeparam name="T">Type of the elements contained in the original and modified versions.</typeparam>
    /// <param name="original">returns the loaded original version.</param>
    /// <param name="modified">returns the loaded modified version.</param>
    /// <returns>returns true if both versions were successfully loaded.</returns>
    public delegate bool LoadRevisionPairDelegate<T>(out T original, out T modified);
}
