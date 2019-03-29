using Jawilliam.CDF.Approach.Services;
using Jawilliam.CDF.Approach.Services.Impl;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Jawilliam.CDF.CSharp.Flad
{
    /// <summary>
    /// Provides the semantic abstraction level of a <see cref="SyntaxNodeOrToken"/> element.
    /// </summary>
    public class SemanticAbstractionService : Service, ISemanticAbstractionService<SyntaxNodeOrToken?>
    {
        /// <summary>
        /// Determines if one element is a relevant piece of the source code content. 
        /// </summary>
        /// <param name="element">element to characterize.</param>
        /// <returns>true if the element is an essential part; otherwise false.</returns>
        public bool IsEssential(SyntaxNodeOrToken? element)
        {
            return !SyntaxFacts.IsPunctuation((SyntaxKind)element.Value.RawKind);
        }
    }
}
