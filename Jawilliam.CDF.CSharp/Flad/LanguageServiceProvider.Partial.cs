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
        /// Determines if two <see cref="SeparatedSyntaxList{VariableDeclaratorSyntax}"/> elements are name-based exactly equal.
        /// </summary>
        /// <param name="original">the original version.</param>
        /// <param name="modified">the modified version.</param>
        /// <returns>true if they are exactly equal, otherwise returns false.</returns>
        public virtual bool NameExactlyEqual(SeparatedSyntaxList<VariableDeclaratorSyntax> original, SeparatedSyntaxList<VariableDeclaratorSyntax> modified)
        {
            if (original.Count != modified.Count) return false;
            for (int i = 0; i < original.Count; i++)
            {
                if (original[i].Identifier.ValueText != modified[i].Identifier.ValueText)
                    return false;
            }
            return true;
        }
    }
}
