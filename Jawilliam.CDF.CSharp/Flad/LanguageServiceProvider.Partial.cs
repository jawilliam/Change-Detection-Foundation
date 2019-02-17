using Jawilliam.CDF.Approach.Flad;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;

namespace Jawilliam.CDF.CSharp.Flad
{
    partial class LanguageServiceProvider
    {
        /// <summary>
        /// Determines if two typed elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <typeparam name="TOriginal">Type of the original version.</typeparam>
        /// <typeparam name="TModified">Type of the original version.</typeparam>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        private bool TryToRun<TOriginal, TModified>(TOriginal original, TModified modified, Type serviceProviderType, string functionalityName, out object result) where TOriginal : SyntaxNode where TModified : SyntaxNode
        {
            result = null;
            if (original != null && modified != null)
            {
                var serviceProvider = this.GetElementTypeServiceProvider((SyntaxKind)original.RawKind);
                if (serviceProvider != null)
                {
                    var functionality = serviceProvider.GetType().GetMethod(functionalityName, new[] { original.GetType(), modified.GetType() });
                    if (functionality != null)
                    {
                        result = (bool)functionality.Invoke(serviceProvider, new object[] { original, modified });
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Determines if two typed elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <typeparam name="TOriginal">Type of the original version.</typeparam>
        /// <typeparam name="TModified">Type of the original version.</typeparam>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool NameExactlyEqual<TOriginal, TModified>(TOriginal original, TModified modified) where TOriginal : SyntaxNode where TModified : SyntaxNode
        {
            if (this.TryToRun<TOriginal, TModified>(original, modified, typeof(INameEqualityCondition<,>), "NameExactlyEqual", out object result))
                return (bool)result;

            var serviceProvider = this.GetElementTypeServiceProvider(typeof(TOriginal).Name.ToString().Replace("Syntax", "")) as INameEqualityCondition<TOriginal, TModified>;
            return serviceProvider?.NameExactlyEqual(original, modified) ?? false;
        }

        /// <summary>
        /// Determines if two typed elements are signature-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <typeparam name="TOriginal">Type of the original version.</typeparam>
        /// <typeparam name="TModified">Type of the original version.</typeparam>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool SignatureExactlyEqual<TOriginal, TModified>(TOriginal original, TModified modified) where TOriginal : SyntaxNode where TModified : SyntaxNode
        {
            if (this.TryToRun<TOriginal, TModified>(original, modified, typeof(INameEqualityCondition<,>), "SignatureExactlyEqual", out object result))
                return (bool)result;

            var serviceProvider = this.GetElementTypeServiceProvider(typeof(TOriginal).Name.ToString().Replace("Syntax", "")) as ISignatureEqualityCondition<TOriginal, TModified>;
            return serviceProvider?.SignatureExactlyEqual(original, modified) ?? false;
        }

        /// <summary>
        /// Determines if two <see cref="SeparatedSyntaxList{TNode}"/> elements are exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <param name="equal">logic of equality.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        private bool ExactlyEqual<T>(SeparatedSyntaxList<T> original, SeparatedSyntaxList<T> modified, Func<T, T, bool> equal) where T : SyntaxNode
        {
            if (original == null || modified == null)
                return false;

            if (original.Count != modified.Count)
                return false;

            for (int i = 0; i < original.Count; i++)
            {
                if (!equal(original[i], modified[i]))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Determines if two <see cref="SeparatedSyntaxList{TNode}"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool NameExactlyEqual<T>(SeparatedSyntaxList<T> original, SeparatedSyntaxList<T> modified) where T : SyntaxNode
        {
            return this.ExactlyEqual(original, modified, this.NameExactlyEqual);
        }

        /// <summary>
        /// Determines if two <see cref="SeparatedSyntaxList{TNode}"/> elements are signature-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool SignatureExactlyEqual<T>(SeparatedSyntaxList<T> original, SeparatedSyntaxList<T> modified) where T : SyntaxNode
        {
            return this.ExactlyEqual(original, modified, this.SignatureExactlyEqual);
        }

        /// <summary>
        /// Provides language-specific information about the "SyntaxToken" type.
        /// </summary>
    	public virtual SyntaxTokenServiceProvider SyntaxTokenServiceProvider
        {
            get => _syntaxTokenServiceProvider ?? (_syntaxTokenServiceProvider = new SyntaxTokenServiceProvider(this));
            set => _syntaxTokenServiceProvider = value;
        }
        private SyntaxTokenServiceProvider _syntaxTokenServiceProvider;

        /// <summary>
        /// Determines if two <see cref="SyntaxToken"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool NameExactlyEqual(SyntaxToken original, SyntaxToken modified)
        {
            return this.SyntaxTokenServiceProvider.NameExactlyEqual(original, modified);
        }

        /// <summary>
        /// Determines if two <see cref="SyntaxToken"/> elements are signature-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool SignatureExactlyEqual(SyntaxToken original, SyntaxToken modified)
        {
            return this.SyntaxTokenServiceProvider.S(original, modified);
        }
    }
}
