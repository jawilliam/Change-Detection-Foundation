using System;

namespace Jawilliam.CDF.CSharp.Awareness
{
    /// <summary>
    /// Base class for implementations of <see cref="IElementTypeServiceProvider"/>. 
    /// </summary>
    public abstract class ElementTypeServiceProvider : Jawilliam.CDF.Approach.Services.Impl.ElementTypeServiceProvider
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public ElementTypeServiceProvider(LanguageServiceProvider languageServiceProvider)
        {
            this.LanguageServiceProvider = languageServiceProvider == null ? throw new ArgumentNullException(nameof(languageServiceProvider)) : languageServiceProvider;
        }
    
        /// <summary>
        /// Gets the container <see cref="LanguageServiceProvider"/>.
        /// </summary>
        public LanguageServiceProvider LanguageServiceProvider { get; private set; }
    }
}
