namespace Jawilliam.CDF.Approach.Services
{
    /// <summary>
    /// Provides language-specific information for the source code change detection.
    /// </summary>
    public interface ILanguageServiceProvider : IService
    {
        ///// <summary>
        ///// Gets the <see cref="IElementTypeServiceProvider"/> to provide information for the requested element type.
        ///// </summary>
        ///// <param name="type">requested element type.</param>
        ///// <param name="subtype">optionally the element type can be refined to an specific subtype.</param>
        ///// <returns><see cref="IElementTypeServiceProvider"/> implementation intended to provide information for the requested element type.</returns>
        //IElementTypeServiceProvider GetElementTypeServiceProvider(string type, string subtype = null);

        /// <summary>
        /// Gets the <see cref="IElementTypeServiceProvider"/> to provide information for a given element.
        /// </summary>
        /// <param name="elementType">given element.</param>
        /// <returns><see cref="IElementTypeServiceProvider"/> implementation intended to provide information for the given element.</returns>
        IElementTypeServiceProvider GetElementTypeServiceProvider(object elementType);
    }
}
