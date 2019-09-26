using Jawilliam.CDF.Approach.Annotations.Impl;
using Jawilliam.CDF.Approach.Services;
using Microsoft.CodeAnalysis;

namespace Jawilliam.CDF.CSharp.Awareness
{
    /// <summary>
    /// The language-provided implementation of Flad.
    /// </summary>
    public class Flad : Jawilliam.CDF.CSharp.Flad.BaseFlad
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        public Flad()
        {
            this.Services[(int)ServiceId.TopologicalAbstraction] = new TopologicalAbstraction<Annotation<SyntaxNodeOrToken?>>(this)
            {
                Id = (int)ServiceId.TopologicalAbstraction,
                SuppressBeginDetection = true
            };

            LanguageServiceProvider languageProvider = new LanguageServiceProvider { Id = (int)ServiceId.LanguageProvider };
            this.Services.Add((int)ServiceId.LanguageProvider, languageProvider);
            this.MatchingSet().PartnersEvent += languageProvider.PartnersEventHandler;
        }
    }
}
