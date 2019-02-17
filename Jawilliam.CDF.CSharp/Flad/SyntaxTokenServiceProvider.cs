using Jawilliam.CDF.Approach.Flad;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jawilliam.CDF.CSharp.Flad
{
    /// <summary>
    /// Provides language-aware services regarding <see cref="SyntaxToken"/>.
    /// </summary>
    public class SyntaxTokenServiceProvider : ElementTypeServiceProvider, 
        INameEqualityCondition<SyntaxToken, SyntaxToken>,
        ISignatureEqualityCondition<SyntaxToken, SyntaxToken>
    {
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        /// <param name="languageServiceProvider">the container <see cref="LanguageServiceProvider"/>.</param>
        public SyntaxTokenServiceProvider(LanguageServiceProvider languageServiceProvider) : base(languageServiceProvider) { }

        /// <summary>
        /// Determines if two <see cref="SyntaxToken"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool NameExactlyEqual(SyntaxToken original, SyntaxToken modified)
        {
            if (original == null || modified == null)
                return false;

            if (!string.IsNullOrWhiteSpace(original.ValueText) && !string.IsNullOrWhiteSpace(modified.ValueText) && original.ValueText == modified.ValueText)
                return true;

            return false;
        }

        /// <summary>
        /// Determines if two <see cref="SyntaxToken"/> elements are signature-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool SignatureExactlyEqual(SyntaxToken original, SyntaxToken modified)
        {
            if (original == null || modified == null)
                return false;

            if (!string.IsNullOrWhiteSpace(original.ValueText) && !string.IsNullOrWhiteSpace(modified.ValueText) && original.ValueText == modified.ValueText)
                return true;

            return false;
        }
    }
}
